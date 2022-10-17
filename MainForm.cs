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
        private const string LARGE_EXTENRSION = "\\Fulllength.png";
        private const string MEDIUM_EXTENSION = "\\Medium.png";
        private const string SMALL_EXTENSION = "\\Small.png";
        private const float ASPECT_RATIO_LARGE = 1.479768786f;
        private const float ASPECT_RATIO_MED = 1.309090909f;
        private const float ASPECT_RATIO_SMALL = 1.308108108f;

        private static readonly Font smlfont = new Font("Bebas Neue", 12);
        private static readonly Font lrgfont = new Font("Bebas Neue", 20);

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
            ThisToEnabled(LayoutMainPage);
        }
        private void BtnNextToCreateNew_Click(object sender, EventArgs e)
        {
            ClearImages();
            SystemControl.FileControl.TempClear();

            is_loaded = false;
            SystemControl.FileControl.CreateTemp("-1", RELATIVEPATH_TO_TEMPFULL, RELATIVEPATH_TO_TEMPPOOR);
            LoadAllImages();

            AllToNotEnabled();
            ThisToEnabled(LayoutFilePage);
            ResizeAllImagesAsWindow();
            if (Properties.Settings.Default.firstlaunch == true)
            {
                using (AuxForms.FileHint fh = new AuxForms.FileHint())
                    fh.ShowDialog();
            }
        }
        private void BtnBackToMainForm_Click(object sender, EventArgs e)
        {
            ClearImages();

            AllToNotEnabled();
            ThisToEnabled(LayoutMainPage);
        }
        private void BtnNextToScaling_Click(object sender, EventArgs e)
        {
            if (is_loaded == false)
            {
                DialogResult dr = MessageBox.Show("You did not load any images. Proceed?", "No image!", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    AllToNotEnabled();
                    ThisToEnabled(LayoutScalePage);
                    LoadAllImages();
                    ResizeAllImagesAsWindow();
                    if (Properties.Settings.Default.firstlaunch == true)
                    {
                        using (AuxForms.ScalingHint sh = new AuxForms.ScalingHint())
                            sh.ShowDialog();
                        Properties.Settings.Default.firstlaunch = false;
                        Properties.Settings.Default.Save();
                    }
                }
            }
            else
            {
                AllToNotEnabled();
                ThisToEnabled(LayoutScalePage);
                LoadAllImages();
                ResizeAllImagesAsWindow();
                if (Properties.Settings.Default.firstlaunch == true)
                {
                    using (AuxForms.ScalingHint sh = new AuxForms.ScalingHint())
                        sh.ShowDialog();
                    Properties.Settings.Default.firstlaunch = false;
                    Properties.Settings.Default.Save();
                }
            }
                
        }
        private void BtnBackToCreateNew_Click(object sender, EventArgs e)
        {
            LoadAllImages();

            AllToNotEnabled();
            ThisToEnabled(LayoutFilePage);
            ResizeAllImagesAsWindow();
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            ClearImages();
            SystemControl.FileControl.TempClear();
            Application.Exit();
        }
    }
}
