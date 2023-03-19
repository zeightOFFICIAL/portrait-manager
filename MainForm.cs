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
            FontsAndTextLoad(pfc);
            InitColorScheme();

            ParentLayoutsHide();
            LayoutHide(LayoutURLDialog);
            LayoutHide(LayoutFinalPage);
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
                using (forms.MyMessageDialog Hint = new forms.MyMessageDialog(Properties.TextVariables.HINT_FILEPAGE))
                {
                    Hint.ShowDialog();
                }
            }
        }
        private void ButtonToScalePage_Click(object sender, EventArgs e)
        {
            if (!_isNewLoaded)
            {
                DialogResult dr;
                using (forms.MyInquiryDialog Inquiry = new forms.MyInquiryDialog(Properties.TextVariables.INQR_NOIMAGE))
                {
                    Inquiry.ShowDialog();
                    dr = Inquiry.DialogResult;
                }
                if (dr == DialogResult.OK)
                {
                    ParentLayoutsHide();
                    LayoutReveal(LayoutScalePage);
                    LoadAllTempImages();
                    ResizeVisibleImagesToWindow();
                }
                else
                {
                    return;
                }
            }
            else
            {
                ParentLayoutsHide();
                LayoutReveal(LayoutScalePage);
                LoadAllTempImages();
                ResizeVisibleImagesToWindow();
            }
            if (Properties.Settings.Default.firstlaunch == true)
            {
                using (forms.MyMessageDialog Hint = new forms.MyMessageDialog(Properties.TextVariables.HINT_SCALEPAGE))
                {
                    Hint.ShowDialog();
                }
                Properties.Settings.Default.firstlaunch = false;
                Properties.Settings.Default.Save();
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
                using (forms.MyMessageDialog Hint = new forms.MyMessageDialog(Properties.TextVariables.HINT_EXTRACTPAGE))
                {
                    Hint.ShowDialog();
                }
                Properties.Settings.Default.folderfirstlaunch = false;
                Properties.Settings.Default.Save();
            }
        }
        private void ButtonToGalleryPage_Click(object sender, EventArgs e)
        {
            ParentLayoutsHide();
            LayoutReveal(LayoutGallery);
            if (!LoadGallery(DIR_DICT[_gameSelected]))
            {
                ButtonToMainPage3_Click(sender, e);
                return;
            }
            if (Properties.Settings.Default.folderfirstlaunch == true)
            {
                using (forms.MyMessageDialog Hint = new forms.MyMessageDialog(Properties.TextVariables.HINT_GALLERYPAGE))
                {
                    Hint.ShowDialog();
                }
                Properties.Settings.Default.folderfirstlaunch = false;
                Properties.Settings.Default.Save();
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
