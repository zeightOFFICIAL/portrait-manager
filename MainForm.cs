/*    
    Pathfinder Portrait Manager. Desktop application for managing in game
    portraits for Pathfinder: Kingmaker and Pathfinder: Wrath of the Righteous
    Copyright (C) 2023 Artemii "Zeight" Saganenko
    LICENSE terms are written in LICENSE file
    Primal license header is written in Program.cs
*/

using PathfinderPortraitManager.sources;
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
        static GameTypeClass wotrType = new GameTypeClass("WOTR",
            Color.FromArgb(255, 20, 147), Color.FromArgb(20, 6, 30),
            Properties.Resources.icon_wotr, Properties.Resources.title_wotr,
            Properties.Resources.bg_wotr, Properties.Resources.placeholder_wotr,
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow")
            + "\\Owlcat Games\\Pathfinder Wrath Of The Righteous\\Portraits", "Pathfinder Portrait Manager (WoTR)");
        static GameTypeClass kingType = new GameTypeClass("KING",
            Color.FromArgb(218, 165, 32), Color.FromArgb(9, 28, 11),
            Properties.Resources.icon_path, Properties.Resources.title_path,
            Properties.Resources.bg_path, Properties.Resources.placeholder_path,
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow")
            + "\\Owlcat Games\\Pathfinder Kingmaker\\Portraits", "Pathfinder Portrait Manager (Kingmaker)");
        private static readonly Dictionary<char, GameTypeClass> GAME_TYPES = new Dictionary<char, GameTypeClass>
        {
            { 'p', kingType},
            { 'w', wotrType}
        };
        
        private static readonly Dictionary<char, string> DIRECTORIES_DICT = new Dictionary<char, string>
        {
            { 'p', Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow") +
                   "\\Owlcat Games\\Pathfinder Kingmaker\\Portraits"},
            { 'w', Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow") +
                   "\\Owlcat Games\\Pathfinder Wrath Of The Righteous\\Portraits"}
        };
        private static readonly Dictionary<char, Image> DEFAULTIMAGE_DICT = new Dictionary<char, Image>
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
        private bool _isAnyLoaded = false;
        private char _gameSelected = Properties.Settings.Default.defaultgametype;
        private PrivateFontCollection pfc;

        public MainForm()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Properties.Settings.Default.activelocal);
            Properties.Settings.Default.Save();
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            ParentLayoutsSetDockFill();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            PicPortraitTemp.AllowDrop = true;
            PicPortraitLrg.MouseWheel += PicPortraitLrg_MouseWheel;
            PicPortraitMed.MouseWheel += PicPortraitMed_MouseWheel;
            PicPortraitSml.MouseWheel += PicPortraitSml_MouseWheel;

            pfc = SystemControl.FileControl.InitCustomFont(Properties.Resources.BebasNeue_Regular);
            FontsAndTextLoad(pfc);
            InitColorScheme();

            ParentLayoutsHide();
            LayoutHide(LayoutURLDialog);
            LayoutHide(LayoutFinalPage);
            LayoutReveal(LayoutMainPage);
            //if (!SystemControl.FileControl.DirectoryExists())
            //{
            //    using (forms.MyMessageDialog Mesg = new forms.MyMessageDialog(Properties.TextVariables.MESG_GAMEFOLDERNOTFOUND))
            //    {
            //        Mesg.StartPosition = FormStartPosition.CenterScreen;
            //        Mesg.ShowDialog();
            //    }
            //}
        }
        private void ButtonToFilePage_Click(object sender, EventArgs e)
        {
            SafeCopyAllImages("!DEFAULT!");
            LoadAllTempImages();
            _isAnyLoaded = false;
            ParentLayoutsHide();
            LayoutReveal(LayoutFilePage);
            ResizeVisibleImagesToWindow();
            if (Properties.Settings.Default.firstlaunch == true)
            {
                using (forms.MyMessageDialog HintDialog = new forms.MyMessageDialog(Properties.TextVariables.HINT_FILEPAGE))
                {
                    HintDialog.ShowDialog();
                }
            }
        }
        private void ButtonToScalePage_Click(object sender, EventArgs e)
        {
            if (!_isAnyLoaded)
            {
                DialogResult dr;
                using (forms.MyInquiryDialog InquiryDialog = new forms.MyInquiryDialog(Properties.TextVariables.INQR_NOIMAGECHOSEN))
                {
                    InquiryDialog.ShowDialog();
                    dr = InquiryDialog.DialogResult;
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
                using (forms.MyMessageDialog HintDialog = new forms.MyMessageDialog(Properties.TextVariables.HINT_SCALEPAGE))
                {
                    HintDialog.ShowDialog();
                }
                Properties.Settings.Default.firstlaunch = false;
                Properties.Settings.Default.Save();
            }
        }
        private void ButtonToFilePage2_Click(object sender, EventArgs e)
        {
            LoadAllTempImages();
            ParentLayoutsHide();
            LayoutReveal(LayoutFilePage);
            ResizeVisibleImagesToWindow();
        }
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            DisposePrimeImages();
            ClearImageLists(ListGallery, ImgListGallery);
            ClearImageLists(ListExtract, ImgListExtract);
            SystemControl.FileControl.TempImagesClear();
            Application.Exit();
        }
        private void ButtonToExtract_Click(object sender, EventArgs e)
        {
            ParentLayoutsHide();
            LayoutReveal(LayoutExtractPage);
            if (Properties.Settings.Default.folderfirstlaunch == true)
            {
                using (forms.MyMessageDialog HintDialog = new forms.MyMessageDialog(Properties.TextVariables.HINT_EXTRACTPAGE))
                {
                    HintDialog.ShowDialog();
                }
                Properties.Settings.Default.folderfirstlaunch = false;
                Properties.Settings.Default.Save();
            }
            ButtonExtractAll.Enabled = false;
            ButtonExtractSelected.Enabled = false;
            ButtonOpenFolders.Enabled = false;
        }
        private void ButtonToGalleryPage_Click(object sender, EventArgs e)
        {
            ParentLayoutsHide();
            LayoutReveal(LayoutGallery);
            if (!LoadGallery(DIRECTORIES_DICT[_gameSelected]))
            {
                ButtonToMainPage3_Click(sender, e);
                return;
            }
            if (Properties.Settings.Default.galleryfirstlaunch == true)
            {
                using (forms.MyMessageDialog HintDialog = new forms.MyMessageDialog(Properties.TextVariables.HINT_GALLERYPAGE))
                {
                    HintDialog.ShowDialog();
                }
                Properties.Settings.Default.galleryfirstlaunch = false;
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
            _extractFolderPath = "!NONE!";
            ClearImageLists(ListExtract, ImgListExtract);
            ParentLayoutsHide();
            LayoutReveal(LayoutMainPage);
        }
        private void ButtonToMainPage3_Click(object sender, EventArgs e)
        {
            ClearImageLists(ListGallery, ImgListGallery);
            ParentLayoutsHide();
            LayoutReveal(LayoutMainPage);
        }
        private void ButtonToMainPage4_Click(object sender, EventArgs e)
        {
            LayoutHide(LayoutFinalPage);
            ClearTempImages();
            _isAnyLoaded = false;
            ParentLayoutsHide();
            LayoutReveal(LayoutMainPage);
            ButtonToMainPageAndFolder.Enabled = true;
        }

        private void ButtonToSettingsPage_Click(object sender, EventArgs e)
        {
            LayoutHide(LayoutMainPage);
            LayoutReveal(LayoutSettingsPage);
        }

        private void SwapEnable(Button enableBtn, Button disableBtn)
        {
            enableBtn.BackColor = GAME_TYPES[_gameSelected].foreColor;
            enableBtn.ForeColor = GAME_TYPES[_gameSelected].backColor;
            enableBtn.Enabled = false;

            disableBtn.BackColor = Color.Black;
            disableBtn.ForeColor = Color.White;
            disableBtn.Enabled = true;
        }
        private void ButtonGameType_Click(object sender, EventArgs e)
        {
            Color fcolor, bcolor;
            if (_gameSelected == 'p')
            {
                _gameSelected = 'w';
                fcolor = GAME_TYPES[_gameSelected].foreColor;
                bcolor = GAME_TYPES[_gameSelected].backColor;
                SwapEnable(ButtonWotR, ButtonKingmaker);                
            }
            else
            {
                _gameSelected = 'p';
                fcolor = GAME_TYPES[_gameSelected].foreColor;
                bcolor = GAME_TYPES[_gameSelected].backColor;
                SwapEnable(ButtonKingmaker, ButtonWotR);
            }

            Icon = GAME_TYPES[_gameSelected].icon;
            LayoutMainPage.BackgroundImage.Dispose();
            LayoutMainPage.BackgroundImage = GAME_TYPES[_gameSelected].backImage;
            PictureBoxTitle.BackgroundImage.Dispose();
            PictureBoxTitle.BackgroundImage = GAME_TYPES[_gameSelected].titleImage;
            foreach (Control ctrl in Controls)
            {
                UpdateColorSchemeOnForm(ctrl, fcolor, bcolor);
            }
            Text = GAME_TYPES[_gameSelected].titleName;
        }
    }
}
