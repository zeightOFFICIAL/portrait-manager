using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace PathfinderPortraitManager
{
    public partial class MainForm : Form
    {
        private const string RELATIVEPATH_TO_TEMPFULL = "temp\\portrait_full.png";
        private const string RELATIVEPATH_TO_TEMPPOOR = "temp\\portrait_poor.png";
        private const string LARGE_EXTENSION = "\\Fulllength.png";
        private const string MEDIUM_EXTENSION = "\\Medium.png";
        private const string SMALL_EXTENSION = "\\Small.png";
        private const float ASPECT_RATIO_LARGE = 1.479768786f;
        private const float ASPECT_RATIO_MED = 1.309090909f;
        private const float ASPECT_RATIO_SMALL = 1.308108108f;
        
        private Point _mousePos = new Point();
        private int _isDragging = 0;
        private bool _isAnyNewLoaded = false;
        private char _gameSelected = PathfinderPortraitManager.Properties.Settings.Default.defaultgametype;

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            LayoutsSetDockFill();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            ((Control)PicPortraitTemp).AllowDrop = true;

            PicPortraitTemp.DragDrop += PicPortraitTemp_DragDrop;
            PicPortraitLrg.MouseWheel += PicPortraitLrg_MouseWheel;
            PicPortraitMed.MouseWheel += PicPortraitMed_MouseWheel;
            PicPortraitSml.MouseWheel += PicPortraitSml_MouseWheel;

            LayoutsDisable();
            LayoutEnable(LayoutMainPage);

            PrivateFontCollection pfc = SystemControl.FileControl.InitCustomLabelFont(PathfinderPortraitManager.Properties.Resources.BebasNeue_Regular);
            FontsLoad(pfc);
            InitColorScheme(_gameSelected);
        }
        private void ButtonToFilePage_Click(object sender, EventArgs e)
        {
            ClearAndLoadToAccordingDefault("-1", _gameSelected);
            LoadAllTempImages();
            _isAnyNewLoaded = false;
            LayoutsDisable();
            LayoutEnable(LayoutFilePage);
            ResizeAllImagesToWindow();
            if (Properties.Settings.Default.firstlaunch == true)
            {
                using (Forms.MyHintDialog FileHint = new Forms.MyHintDialog("This is an image page. Here you can choose " +
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
            ClearToAccordingDefault(_gameSelected);
            LayoutsDisable();
            LayoutEnable(LayoutMainPage);
        }
        private void ButtonToScalePage_Click(object sender, EventArgs e)
        {
            if (_isAnyNewLoaded == false)
            {
                DialogResult DialogResult;
                using (Forms.MyChoiceDialog NoImageMessage = new Forms.MyChoiceDialog("You did not load any images. Proceed?"))
                {
                    DialogResult = NoImageMessage.ShowDialog();
                }
                if (DialogResult == DialogResult.OK)
                {
                    LayoutsDisable();
                    LayoutEnable(LayoutScalePage);
                    LoadAllTempImages();
                    ResizeAllImagesToWindow();
                    if (Properties.Settings.Default.firstlaunch == true)
                    {
                        using (Forms.MyHintDialog ScalingHint = new Forms.MyHintDialog("This is a scaling page. Here you can adjust the " +
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
                LayoutsDisable();
                LayoutEnable(LayoutScalePage);
                LoadAllTempImages();
                ResizeAllImagesToWindow();
                if (Properties.Settings.Default.firstlaunch == true)
                {
                    using (Forms.MyHintDialog ScalingHint = new Forms.MyHintDialog("This is a scaling page. Here you can adjust the " +
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
            LoadAllTempImages();
            LayoutsDisable();
            LayoutEnable(LayoutFilePage);
            ResizeAllImagesToWindow();
        }
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            DisposeAllImages();
            SystemControl.FileControl.TempImagesClear();
            Application.Exit();
        }
        private void ButtonToExtract_Click(object sender, EventArgs e)
        {
            LayoutsDisable();
            LayoutEnable(LayoutExtractPage);
            if (Properties.Settings.Default.folderfirstlaunch == true)
            {
                using (Forms.MyHintDialog FileHint = new Forms.MyHintDialog("This is an image page. Here you can choose " +
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
    }
}
