using System;
using System.Drawing;
using System.Windows.Forms;

namespace PathfinderKingmakerPortraitManager
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

        private static readonly Font _smlFont = new Font("Bebas Neue", 12);
        private static readonly Font _lrgFont = new Font("Bebas Neue", 20);

        private Point _mousePos = new Point();
        private int _isDragging = 0;
        private bool _isLoaded = false;

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            OverloadDockOnEverything();
            PicPortraitTemp.AllowDrop = true;

            PicPortraitTemp.DragDrop += PicPortraitTemp_DragDrop;
            PicPortraitLrg.MouseWheel += PicPortraitLrg_MouseWheel;
            PicPortraitMed.MouseWheel += PicPortraitMed_MouseWheel;
            PicPortraitSml.MouseWheel += PicPortraitSml_MouseWheel;

            AllToNotEnabled();
            ThisToEnabled(LayoutMainPage);
        }
        private void ButtonToFilePage_Click(object sender, EventArgs e)
        {
            ClearImages();
            SystemControl.FileControl.TempClear();

            _isLoaded = false;
            SystemControl.FileControl.CreateTemp("-1", RELATIVEPATH_TO_TEMPFULL, RELATIVEPATH_TO_TEMPPOOR);
            LoadAllImages();

            AllToNotEnabled();
            ThisToEnabled(LayoutFilePage);
            ResizeAllImagesAsWindow();
            if (Properties.Settings.Default.firstlaunch == true)
            {
                using (AuxForms.MyHintDialog FileHint = new AuxForms.MyHintDialog("This is an image page. Here you can choose " +
                    "whatever picture you want for your portrait. Local and web-stored images can be loaded. Press " +
                    "\"local image\", click on portrait, or simply drag and drop to load local image. Press " +
                    "\"web image\" to fetch image from web. Then press \"next\" to begin scaling or \"back\" " +
                    "to return to main page."))
                {
                    FileHint.ShowDialog();
                }
            }
        }
        private void ButtonToMainPage_Click(object sender, EventArgs e)
        {
            ClearImages();

            AllToNotEnabled();
            ThisToEnabled(LayoutMainPage);
        }
        private void ButtonToScalePage_Click(object sender, EventArgs e)
        {
            if (_isLoaded == false)
            {
                DialogResult DialogResult;
                using (AuxForms.MyChoiceDialog NoImageMessage = new AuxForms.MyChoiceDialog("You did not load any images. Proceed?"))
                {
                    DialogResult = NoImageMessage.ShowDialog();
                }
                if (DialogResult == DialogResult.OK)
                {
                    AllToNotEnabled();
                    ThisToEnabled(LayoutScalePage);
                    LoadAllImages();
                    ResizeAllImagesAsWindow();
                    if (Properties.Settings.Default.firstlaunch == true)
                    {
                        using (AuxForms.MyHintDialog ScalingHint = new AuxForms.MyHintDialog("This is a scaling page. Here you can adjust the " +
                            "portrait as you see fit. Click and drag to move cropping rectangle. " +
                            "Use mouse wheel to zoom in and out. Double-click on portrait to " +
                            "restore it to original state. Use \"Create\" button to generate " +
                            "portrait and \"Back\" to return to image page."))
                        {
                            ScalingHint.ShowDialog();
                        }
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
                    using (AuxForms.MyHintDialog ScalingHint = new AuxForms.MyHintDialog("This is a scaling page. Here you can adjust the " +
                        "portrait as you see fit. Click and drag to move cropping rectangle. " +
                        "Use mouse wheel to zoom in and out. Double-click on portrait to " +
                        "restore it to original state. Use \"Create\" button to generate " +
                        "portrait and \"Back\" to return to image page."))
                    {
                        ScalingHint.ShowDialog();
                    }
                    Properties.Settings.Default.firstlaunch = false;
                    Properties.Settings.Default.Save();
                }
            }
        }
        private void ButtonBackToFilePage_Click(object sender, EventArgs e)
        {
            LoadAllImages();

            AllToNotEnabled();
            ThisToEnabled(LayoutFilePage);
            ResizeAllImagesAsWindow();
        }
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            ClearImages();
            SystemControl.FileControl.TempClear();
            Application.Exit();
        }

        private void ButtonExtract_Click(object sender, EventArgs e)
        {
            AllToNotEnabled();
            ThisToEnabled(LayoutFolderLoad);
            if (Properties.Settings.Default.folderfirstlaunch == true)
            {
                using (AuxForms.MyHintDialog FileHint = new AuxForms.MyHintDialog("This is an image page. Here you can choose " +
                    "whatever picture you want for your portrait. Local and web-stored images can be loaded. Press " +
                    "\"local image\", click on portrait, or simply drag and drop to load local image. Press " +
                    "\"web image\" to fetch image from web. Then press \"next\" to begin scaling or \"back\" " +
                    "to return to main page."))
                {
                    FileHint.ShowDialog();
                    Properties.Settings.Default.folderfirstlaunch = false;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void ButtonBackToMainPage2_Click(object sender, EventArgs e)
        {
            AllToNotEnabled();
            ThisToEnabled(LayoutMainPage);
        }

        private void ButtonFolderHint_Click(object sender, EventArgs e)
        {
            using (AuxForms.MyHintDialog FileHint = new AuxForms.MyHintDialog("This is an image page. Here you can choose " +
                    "whatever picture you want for your portrait. Local and web-stored images can be loaded. Press " +
                    "\"local image\", click on portrait, or simply drag and drop to load local image. Press " +
                    "\"web image\" to fetch image from web. Then press \"next\" to begin scaling or \"back\" " +
                    "to return to main page."))
            {
                FileHint.ShowDialog();
            }
        }

        private void ButtonFolderChoose_Click(object sender, EventArgs e)
        {

        }
    }
}
