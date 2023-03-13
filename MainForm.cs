using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace PathfinderPortraitManager
{
    public partial class MainForm : Form
    {
        private static readonly Dictionary<char, string> ENV_DICT = new Dictionary<char, string>
        {
            { 'p', Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow") +
                   "\\Owlcat Games\\Pathfinder Kingmaker\\Portraits"},
            { 'w', Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow") +
                   "\\Owlcat Games\\Pathfinder Wrath Of The Righteous\\Portraits"}
        };
        private static readonly Dictionary<char, Image> DEF_DICT = new Dictionary<char, Image>
        {
            { 'p', Properties.Resources.placeholder_path},
            { 'w', Properties.Resources.placeholder_wotr}
        };
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
        private char _gameSelected = Properties.Settings.Default.defaultgametype;

        public MainForm()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Properties.Settings.Default.activelocal);
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            ParentLayoutsSetDockFill();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            PicPortraitTemp.AllowDrop = true;
            PicPortraitTemp.DragDrop += PicPortraitTemp_DragDrop;
            PicPortraitLrg.MouseWheel += PicPortraitLrg_MouseWheel;
            PicPortraitMed.MouseWheel += PicPortraitMed_MouseWheel;
            PicPortraitSml.MouseWheel += PicPortraitSml_MouseWheel;

            PrivateFontCollection pfc = SystemControl.FileControl.InitCustomFont(Properties.Resources.BebasNeue_Regular);
            FontsLoad(pfc);
            InitColorScheme(_gameSelected);

            ParentLayoutsHide();
            LayoutReveal(LayoutMainPage);
        }
        private void ButtonToFilePage_Click(object sender, EventArgs e)
        {
            SafeCopyAllImages("-1", _gameSelected);
            LoadAllTempImages();
            _isAnyNewLoaded = false;
            ParentLayoutsHide();
            LayoutReveal(LayoutFilePage);
            ResizeVisibleImagesToWindow();
            if (Properties.Settings.Default.firstlaunch == true)
            {
                using (Forms.MyHintDialog hintFilePage = new Forms.MyHintDialog(Properties.TextVariables.hintFilePage))
                {
                    hintFilePage.ShowDialog();
                }
            }
        }
        private void ButtonToMainPage_Click(object sender, EventArgs e)
        {
            ClearTempImages();
            ParentLayoutsHide();
            LayoutReveal(LayoutMainPage);
        }
        private void ButtonToScalePage_Click(object sender, EventArgs e)
        {
            if (!_isAnyNewLoaded)
            {
                DialogResult dialogResult;
                using (Forms.MyChoiceDialog inquiryNoImage = new Forms.MyChoiceDialog(Properties.TextVariables.inquiryNoImages))
                {
                    dialogResult = inquiryNoImage.ShowDialog();
                }
                if (dialogResult == DialogResult.OK)
                {
                    ParentLayoutsHide();
                    LayoutReveal(LayoutScalePage);
                    LoadAllTempImages();
                    ResizeVisibleImagesToWindow();
                    if (Properties.Settings.Default.firstlaunch == true)
                    {
                        using (Forms.MyHintDialog hintScalingPage = new Forms.MyHintDialog(Properties.TextVariables.hintScalingPage))
                        {
                            hintScalingPage.ShowDialog();
                        }
                        Properties.Settings.Default.firstlaunch = false;
                        Properties.Settings.Default.Save();
                    }
                }
            }
            else
            {
                ParentLayoutsHide();
                LayoutReveal(LayoutScalePage);
                LoadAllTempImages();
                ResizeVisibleImagesToWindow();
                if (Properties.Settings.Default.firstlaunch == true)
                {
                    using (Forms.MyHintDialog hintScalingPage = new Forms.MyHintDialog(Properties.TextVariables.hintScalingPage))
                    {
                        hintScalingPage.ShowDialog();
                    }
                    Properties.Settings.Default.firstlaunch = false;
                    Properties.Settings.Default.Save();
                }
            }
        }
        private void ButtonBackToFilePage_Click(object sender, EventArgs e)
        {
            LoadAllTempImages();
            ParentLayoutsHide();
            LayoutReveal(LayoutFilePage);
            ResizeVisibleImagesToWindow();
        }
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            DisposeAllImages();
            ClearGallery();
            SystemControl.FileControl.TempImagesClear();
            Application.Exit();
        }
        private void ButtonToExtract_Click(object sender, EventArgs e)
        {
            ParentLayoutsHide();
            LayoutReveal(LayoutExtractPage);
            if (Properties.Settings.Default.folderfirstlaunch == true)
            {
                using (Forms.MyHintDialog hintExtractPage = new Forms.MyHintDialog(Properties.TextVariables.hintExtractPage))
                {
                    hintExtractPage.ShowDialog();
                    Properties.Settings.Default.folderfirstlaunch = false;
                    Properties.Settings.Default.Save();
                }
            }
        }
        private void ButtonToGalleryPage_Click(object sender, EventArgs e)
        {
            string folderPath;
            ParentLayoutsHide();
            LayoutReveal(LayoutGallery);
            folderPath = ENV_DICT[_gameSelected];
            if (!LoadGallery(folderPath))
            {
                ButtonToMainPage3_Click(sender, e);
            }
        }
        private void ButtonToMainPage3_Click(object sender, EventArgs e)
        {
            ParentLayoutsHide();
            LayoutReveal(LayoutMainPage);
            ClearGallery();
        }
    }
}
