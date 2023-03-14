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
        private static readonly Dictionary<char, string> DIR_DICT = new Dictionary<char, string>
        {
            { 'p', Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow") +
                   "\\Owlcat Games\\Pathfinder Kingmaker\\Portraits"},
            { 'w', Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow") +
                   "\\Owlcat Games\\Pathfinder Wrath Of The Righteous\\Portraits"}
        };
        private static readonly Dictionary<char, Image> DEFAULT_DICT = new Dictionary<char, Image>
        {
            { 'p', Properties.Resources.placeholder_path},
            { 'w', Properties.Resources.placeholder_wotr}
        };
        private const string RELATIVEPATH_TEMPFULL = "temp\\portrait_full.png";
        private const string RELATIVEPATH_TEMPPOOR = "temp\\portrait_poor.png";
        private const string LRG_APPEND = "\\Fulllength.png";
        private const string MED_APPEND = "\\Medium.png";
        private const string SML_APPEND = "\\Small.png";
        private const float LRG_ASPECT = 1.479768786f;
        private const float MED_ASPECT = 1.309090909f;
        private const float SML_ASPECT = 1.308108108f;

        private Point _mousePos = new Point();
        private int _isDragging = 0;
        private bool _isNewLoaded = false;
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
            FontsTextLoad(pfc);
            InitColorScheme(_gameSelected);

            ParentLayoutsHide();
            LayoutHide(LayoutURLDialog);
            LayoutHide(LayoutAnyHint);
            LayoutReveal(LayoutMainPage);
        }
        private void ButtonToFilePage_Click(object sender, EventArgs e)
        {
            SafeCopyAllImages("-1");
            LoadAllTempImages();
            _isNewLoaded = false;
            ParentLayoutsHide();
            LayoutReveal(LayoutFilePage);
            ResizeVisibleImagesToWindow();
            if (Properties.Settings.Default.firstlaunch == true)
            {
                //using (Forms.MyHintDialog HintFilePage = new Forms.MyHintDialog(Properties.TextVariables.HINT_FILEPAGE))
                //{
                //    HintFilePage.ShowDialog();
                //}
            }
        }
        private void ButtonToScalePage_Click(object sender, EventArgs e)
        {
            if (!_isNewLoaded)
            {
                DialogResult dialogResult;
                using (Forms.MyChoiceDialog InquiryNoImage = new Forms.MyChoiceDialog(Properties.TextVariables.MSG_NOIMAGES))
                {
                    dialogResult = InquiryNoImage.ShowDialog();
                }
                if (dialogResult == DialogResult.OK)
                {
                    ParentLayoutsHide();
                    LayoutReveal(LayoutScalePage);
                    LoadAllTempImages();
                    ResizeVisibleImagesToWindow();
                    if (Properties.Settings.Default.firstlaunch == true)
                    {
                        //using (Forms.MyHintDialog HintScalingPage = new Forms.MyHintDialog(Properties.TextVariables.HINT_SCALEPAGE))
                        //{
                        //    HintScalingPage.ShowDialog();
                        //}
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
                    //using (Forms.MyHintDialog HintScalingPage = new Forms.MyHintDialog(Properties.TextVariables.HINT_SCALEPAGE))
                    //{
                    //    HintScalingPage.ShowDialog();
                    //}
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
            DisposePrimeImages();
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
                //using (Forms.MyHintDialog HintExtractPage = new Forms.MyHintDialog(Properties.TextVariables.HINT_EXTRACTPAGE))
                //{
                 //   HintExtractPage.ShowDialog();
                //    Properties.Settings.Default.folderfirstlaunch = false;
                //    Properties.Settings.Default.Save();
               // }
            }
        }
        private void ButtonToGalleryPage_Click(object sender, EventArgs e)
        {
            ParentLayoutsHide();
            LayoutReveal(LayoutGallery);
            if (!LoadGallery(DIR_DICT[_gameSelected]))
            {
                ButtonToMainPage3_Click(sender, e);
            }
        }
        private void ButtonToMainPage_Click(object sender, EventArgs e)
        {
            ClearTempImages();
            ParentLayoutsHide();
            LayoutReveal(LayoutMainPage);
        }
        private void ButtonToMainPage2_Click(object sender, EventArgs e)
        {
            ParentLayoutsHide();
            LayoutReveal(LayoutMainPage);
        }
        private void ButtonToMainPage3_Click(object sender, EventArgs e)
        {
            ClearGallery();
            ParentLayoutsHide();
            LayoutReveal(LayoutMainPage);
        }
    }
}
