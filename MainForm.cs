using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;


namespace PathfinderKINGPortrait
{
    public partial class MainForm : Form
    {
        private const string RELATIVEPATH_TO_TEMPFULL = "temp\\portrait_full.png";
        private const string RELATIVEPATH_TO_TEMPPOOR = "temp\\portrait_poor.png";
        private const float ASPECT_RATIO_LARGE = 1.479768786f;
        private const float ASPECT_RATIO_MED = 1.309090909f;
        private const float ASPECT_RATIO_SMALL = 1.308108108f;

        private Point mousept = new Point();
        private int dragging = 0;

        public MainForm()
        {
            InitializeComponent();

            PicPortraitTemp.AllowDrop = true;
            LayCreateForm.AllowDrop = true;
            PicPortraitTemp.DragDrop += PicPortraitTemp_DragDrop;

            PicPortraitLrg.MouseWheel += PicPortraitLrg_MouseWheel;
            PicPortraitMed.MouseWheel += PicPortraitMed_MouseWheel;
            PicPortraitSml.MouseWheel += PicPortraitSml_MouseWheel;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            AllToDockFill();
            AllToNotEnabled();
            ThisToEnabled(LayMainForm);
        }
        private void BtnNextToCreateNew_Click(object sender, EventArgs e)
        {
            AllImageClear();
            SystemControl.FileControl.TempClear();

            isloaded = false;
            SystemControl.FileControl.CreateTemp("-1");
            LoadAllImages();

            AllToNotEnabled();
            ThisToEnabled(LayCreateForm);
        }
        private void BtnBackToMainForm_Click(object sender, EventArgs e)
        {
            AllImageClear();

            AllToNotEnabled();
            ThisToEnabled(LayMainForm);
        }
        private void BtnNextToScaling_Click(object sender, EventArgs e)
        {
            if (isloaded == false)
            {
                DialogResult dr = MessageBox.Show("You did not load any images. Proceed?", "Image", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    AllToNotEnabled();
                    ThisToEnabled(LayScalingForm);
                    LoadAllImages();
                    AllImageResizeAsWindow();
                }
            }
            else
            {
                AllToNotEnabled();
                ThisToEnabled(LayScalingForm);
                LoadAllImages();
                AllImageResizeAsWindow();
            }
        }
        private void BtnBackToCreateNew_Click(object sender, EventArgs e)
        {
            LoadAllImages();

            AllToNotEnabled();
            ThisToEnabled(LayCreateForm);
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            AllImageClear();
            SystemControl.FileControl.TempClear();
            System.Windows.Forms.Application.Exit();
        }
        private void MainForm_Closed(object sender, FormClosedEventArgs e)
        {
            AllImageClear();
            SystemControl.FileControl.TempClear();
            System.Windows.Forms.Application.Exit();
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
            
        }
        private void BtnCreatePortrait_Click(object sender, EventArgs e)
        {
            string exoduspath;
            bool findplace = false;
            uint localname = 1000;
            exoduspath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow") +
                         "\\Owlcat Games\\Pathfinder Kingmaker\\Portraits";
            while (findplace == false)
            {
                string fullexoduspath = exoduspath + "\\" + Convert.ToString(localname);
                if (!Directory.Exists(fullexoduspath))
                {
                    Directory.CreateDirectory(fullexoduspath);
                    Image img;
                    img = ImageControl.Wraps.CropImage(PicPortraitLrg, PnlPortraitLrg, RELATIVEPATH_TO_TEMPFULL, ASPECT_RATIO_LARGE, 692, 1024);
                    img.Save(fullexoduspath + "\\Fulllength.png");
                    img = ImageControl.Wraps.CropImage(PicPortraitMed, PnlPortraitMed, RELATIVEPATH_TO_TEMPFULL, ASPECT_RATIO_MED, 330, 432);
                    img.Save(fullexoduspath + "\\Medium.png");
                    img = ImageControl.Wraps.CropImage(PicPortraitSml, PnlPortraitSml, RELATIVEPATH_TO_TEMPFULL, ASPECT_RATIO_SMALL, 185, 242);
                    img.Save(fullexoduspath + "\\Small.png");
                    img.Dispose();
                    findplace = true;
                }
                localname++;
            }
        }
        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            AllImageResizeAsWindow();
        }
    }
}
