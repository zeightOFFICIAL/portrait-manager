using System;
using System.Data.Design;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace PathfinderPortraitManager
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
        
        private Point _mousePos = new Point();
        private int _isDragging = 0;
        private bool _isLoaded = false;
        private char _gameSelected = 'p';

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            DockFillLayouts();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            PicPortraitTemp.DragDrop += PicPortraitTemp_DragDrop;
            PicPortraitLrg.MouseWheel += PicPortraitLrg_MouseWheel;
            PicPortraitMed.MouseWheel += PicPortraitMed_MouseWheel;
            PicPortraitSml.MouseWheel += PicPortraitSml_MouseWheel;

            DisableAllLayouts();
            EnableLayout(LayoutMainPage);

            PrivateFontCollection pfc = SystemControl.FileControl.InitCustomLabelFont(PathfinderPortraitManager.Properties.Resources.BebasNeue_Regular);
            ArrangeFonts(pfc);
        }
        private void ButtonToFilePage_Click(object sender, EventArgs e)
        {
            if (_gameSelected == 'p')
                using (Image placeholder = new Bitmap(PathfinderPortraitManager.Properties.Resources.placeholder_path))
                {
                    ClearImages(placeholder);
                    SystemControl.FileControl.TempImagesClear();
                    SystemControl.FileControl.TempImagesCreate("-1", RELATIVEPATH_TO_TEMPFULL, RELATIVEPATH_TO_TEMPPOOR, placeholder);
                }
            else
                using (Image placeholder = new Bitmap(PathfinderPortraitManager.Properties.Resources.placeholder_wotr))
                {
                    ClearImages(placeholder);
                    SystemControl.FileControl.TempImagesClear();
                    SystemControl.FileControl.TempImagesCreate("-1", RELATIVEPATH_TO_TEMPFULL, RELATIVEPATH_TO_TEMPPOOR, placeholder);
                }

            LoadAllImages();
            _isLoaded = false;
            DisableAllLayouts();
            EnableLayout(LayoutFilePage);
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
            if (_gameSelected == 'p')
                using (Image placeholder = new Bitmap(PathfinderPortraitManager.Properties.Resources.placeholder_path))
                    ClearImages(placeholder);
            else
                using (Image placeholder = new Bitmap(PathfinderPortraitManager.Properties.Resources.placeholder_wotr))
                    ClearImages(placeholder);

            DisableAllLayouts();
            EnableLayout(LayoutMainPage);
        }
        private void ButtonToScalePage_Click(object sender, EventArgs e)
        {
            if (_isLoaded == false)
            {
                DialogResult DialogResult;
                using (Forms.MyChoiceDialog NoImageMessage = new Forms.MyChoiceDialog("You did not load any images. Proceed?"))
                {
                    DialogResult = NoImageMessage.ShowDialog();
                }
                if (DialogResult == DialogResult.OK)
                {
                    DisableAllLayouts();
                    EnableLayout(LayoutScalePage);
                    LoadAllImages();
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
                DisableAllLayouts();
                EnableLayout(LayoutScalePage);
                LoadAllImages();
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
            LoadAllImages();

            DisableAllLayouts();
            EnableLayout(LayoutFilePage);
            ResizeAllImagesToWindow();
        }
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            DisposeImages();
            SystemControl.FileControl.TempImagesClear();
            Application.Exit();
        }

        private void ButtonToExtract_Click(object sender, EventArgs e)
        {
            DisableAllLayouts();
            EnableLayout(LayoutExtractPage);
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
