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

        private Point mouse_pos = new Point();
        private int is_dragging = 0;
        private bool is_loaded = false;

        public MainForm()
        {
            InitializeComponent();
            OverloadDockOnEverything();

            PicPortraitTemp.AllowDrop = true;

            PicPortraitTemp.DragDrop += PicPortraitTemp_DragDrop;
            PicPortraitLrg.MouseWheel += PicPortraitLrg_MouseWheel;
            PicPortraitMed.MouseWheel += PicPortraitMed_MouseWheel;
            PicPortraitSml.MouseWheel += PicPortraitSml_MouseWheel;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            AllToNotEnabled();
            ThisToEnabled(LayMainForm);
        }
        private void BtnNextToCreateNew_Click(object sender, EventArgs e)
        {
            ClearImages();
            SystemControl.FileControl.TempClear();

            is_loaded = false;
            SystemControl.FileControl.CreateTemp("-1", RELATIVEPATH_TO_TEMPFULL, RELATIVEPATH_TO_TEMPPOOR);
            LoadAllImages();

            AllToNotEnabled();
            ThisToEnabled(LayCreateForm);
        }
        private void BtnBackToMainForm_Click(object sender, EventArgs e)
        {
            ClearImages();

            AllToNotEnabled();
            ThisToEnabled(LayMainForm);
        }
        private void BtnNextToScaling_Click(object sender, EventArgs e)
        {
            if (is_loaded == false)
            {
                DialogResult dr = MessageBox.Show("You did not load any images. Proceed?", "No image!", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    AllToNotEnabled();
                    ThisToEnabled(LayScalingForm);
                    LoadAllImages();
                    ResizeImagesAsWindow();
                }
            }
            else
            {
                AllToNotEnabled();
                ThisToEnabled(LayScalingForm);
                LoadAllImages();
                ResizeImagesAsWindow();
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
            ClearImages();
            SystemControl.FileControl.TempClear();
            Application.Exit();
        }
    }
}
