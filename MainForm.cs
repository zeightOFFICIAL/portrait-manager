/*    
    Portrait Manager: Owlcat. Desktop application for managing in game
    portraits for Owlcat Games products. Including: 1. Pathfinder: Kingmaker,
    2. Pathfinder: Wrath of the Righteous, 3. Warhammer 40000: Rogue Trader
    Copyright (C) 2024 Artemii "Zeight" Saganenko.

    GPL-2.0 license terms are listed in LICENSE file.
    License header for this project is listed in Program.cs.
*/

using OwlcatPortraitManager.forms;
using OwlcatPortraitManager.sources;
using OwlcatPortraitManager.Properties;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace OwlcatPortraitManager
{
    public partial class MainForm : Form
    {
        private static readonly GameTypeClass WRATH_TYPE = new GameTypeClass("Wrath of the Righteous",
            Color.FromArgb(255, 20, 147), Color.FromArgb(20, 6, 30),
            Resources.icon_wotr, Resources.title_wotr,
            Resources.bg_wotr, Resources.placeholder_wotr,
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow")
            + "\\Owlcat Games\\Pathfinder Wrath Of The Righteous\\Portraits", "Pathfinder Portrait Manager (WoTR)",
            185, 242, 330, 432, 692, 1024, 1.308108108f, 1.309090909f, 1.479768786f);

        private static readonly GameTypeClass KINGMAKER_TYPE = new GameTypeClass("Kingmaker",
            Color.FromArgb(218, 165, 32), Color.FromArgb(9, 28, 11),
            Resources.icon_path, Resources.title_path,
            Resources.bg_path, Resources.placeholder_path,
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow")
            + "\\Owlcat Games\\Pathfinder Kingmaker\\Portraits", "Pathfinder Portrait Manager (Kingmaker)",
            185, 242, 330, 432, 692, 1024, 1.308108108f, 1.309090909f, 1.479768786f);

        private static readonly GameTypeClass ROGUE_TYPE = new GameTypeClass("Rogue Trader",
            Color.FromArgb(255, 187, 0), Color.FromArgb(5, 0, 42),
            Resources.icon_rt, Resources.title_rt,
            Resources.bg_rt, Resources.placeholder_rt,
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow")
            + "\\Owlcat Games\\Warhammer 40000 Rogue Trader\\Portraits", "Warhammer Portrait Manager (Rogue Trader)",
            260, 336, 448, 600, 1080, 1480, 1.29230769231f, 1.33928571429f, 1.37037037037f);

        private static readonly GameTypeClass TYRANNY_TYPE = new GameTypeClass("Tyranny",
            Color.FromArgb(248, 34, 34), Color.FromArgb(43, 3, 3),
            Resources.icon_tyr, Resources.title_tyr,
            Resources.bg_tyr, Resources.placeholder_tyr,
            "__NONE__", "Tyranny Portrait Manager",
            76, 96, 0, 0, 210, 330, 1.2631f, 0f, 1.5714f);

        private static readonly GameTypeClass PILLARS_TYPE = new GameTypeClass("Pillars of Eternity",
            Color.FromArgb(50, 250, 200), Color.FromArgb(7, 33, 27),
            Resources.icon_poe, Resources.title_poe,
            Resources.bg_poe, Resources.placeholder_poe,
            "__NONE__", "Pillars of Eternity Portrait Manager",
            76, 96, 0, 0, 210, 330, 1.2631f, 0f, 1.5714f);

        private static readonly GameTypeClass DEADFIRE_TYPE = new GameTypeClass("Deadfire",
            Color.FromArgb(121, 208, 215), Color.FromArgb(27, 47, 49),
            Resources.icon_poed, Resources.title_poed,
            Resources.bg_poed, Resources.placeholder_poed,
            "__NONE__", "Pillars of Eternity Portrait Manager (Deadfire)",
            76, 96, 90, 141, 210, 330, 1.2631f, 1.5667f, 1.5714f);

        private static readonly GameTypeClass WASTE_TYPE = new GameTypeClass("Wasteland",
            Color.FromArgb(176, 200, 210), Color.FromArgb(35, 50, 50),
            Resources.icon_waste, Resources.title_waste,
            Resources.bg_waste, Resources.placeholder_waste,
            "__NONE__", "Wasteland Portrait Manager (Wasteland 3)",
            256, 256, 0, 0, 0, 0, 1.0f, 0f, 0f);

        private static readonly Dictionary<char, GameTypeClass> GAME_TYPES = new Dictionary<char, GameTypeClass>
        {
            { 'p', KINGMAKER_TYPE },
            { 'w', WRATH_TYPE },
            { 'r', ROGUE_TYPE },
            { 't', TYRANNY_TYPE },
            { 'e', PILLARS_TYPE },
            { 'd', DEADFIRE_TYPE },
            { 'l', WASTE_TYPE }
        };

        private static readonly Dictionary<char, string> ACTIVE_PATHS = new Dictionary<char, string>
        {
            { 'p', CoreSettings.Default.WOTRPath },
            { 'w', CoreSettings.Default.KINGPath },
            { 'r', CoreSettings.Default.ROGUEPath },
            { 't', CoreSettings.Default.TYRANNYPath },
            { 'e', CoreSettings.Default.PILLARSPath },
            { 'd', CoreSettings.Default.DEADFIREPath },
            { 'l', CoreSettings.Default.WASTEPath }
        };

        private const string TEMP_LARGE_APPEND = "temp_DoNotDeleteWhileRunning\\FULL.png";
        private const string TEMP_MEDIUM_APPEND = "temp_DoNotDeleteWhileRunning\\MEDIUM.png";
        private const string TEMP_SMALL_APPEND = "temp_DoNotDeleteWhileRunning\\SMALL.png";

        private const string LARGE_APPEND = "\\Fulllength.png";
        private const string MEDIUM_APPEND = "\\Medium.png";
        private const string SMALL_APPEND = "\\Small.png";
        private static readonly string[] TEMP_APPENDS = { TEMP_LARGE_APPEND, TEMP_MEDIUM_APPEND, TEMP_SMALL_APPEND };

        private static char _gameSelected = CoreSettings.Default.GameType;

        /*
         * 0 - Menu page
         * 1 - File page
         * 2 - Scale page
         * 3 - Extract page
         * 4 - Gallery page
         * 100 - File>web page
         * 200 - Scale>finish page
         */
        private static ushort _activeMenuIndex;
        /* 0 - all loaded
         * 1 - first loaded
         * 2 - first, second loaded
         * 100 - not loaded
         */
        private static ushort _imageSelectionFlag = 0;
        private static bool _isAnyLoadedToPortraitPage = false;
        private static bool _isAspectRatioFixed = false;

        private static ushort _isDraggingMouse = 0;
        private static Point _mousePosition = new Point();      

        private static PrivateFontCollection _fontCollection;

        private static CancellationTokenSource _cancellationTokenSource;


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _activeMenuIndex = 0;

            if (UseStamps.Default.isFirstAny)
            {
                var currentUICulture = CultureInfo.CurrentUICulture.ToString();
                if (currentUICulture == "en-US" ||
                    currentUICulture == "ru-RU" ||
                    currentUICulture == "de-DE"
                    )
                {
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentUICulture;
                }
                else
                {
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
                }
                
                CoreSettings.Default.KINGPath = KINGMAKER_TYPE.DefaultDirectory;
                CoreSettings.Default.WOTRPath = WRATH_TYPE.DefaultDirectory;
                CoreSettings.Default.ROGUEPath = ROGUE_TYPE.DefaultDirectory;
                CoreSettings.Default.MaxWindowHeight = Size.Height;
                CoreSettings.Default.MaxWindowWidth = Size.Width;
                CoreSettings.Default.SelectedLang = Thread.CurrentThread.CurrentUICulture.ToString();
                CoreSettings.Default.Save();

                UseStamps.Default.isFirstAny = false;
                UseStamps.Default.Save();
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(CoreSettings.Default.SelectedLang);
            }

            ACTIVE_PATHS['w'] = CoreSettings.Default.WOTRPath;
            ACTIVE_PATHS['p'] = CoreSettings.Default.KINGPath;
            ACTIVE_PATHS['r'] = CoreSettings.Default.ROGUEPath;
            Width = CoreSettings.Default.MaxWindowWidth;
            Height = CoreSettings.Default.MaxWindowHeight;

            _fontCollection = SystemControl.FileControl.InitCustomFont(Resources.BebasNeue_Regular, Resources.BebasNeue_Regular_ru);
            FormInit();
            LanguageInit();
            CenterToScreen();
            Show();

            if (!ValidatePortraitPath(ACTIVE_PATHS[_gameSelected]))
            {
                using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_GAMEFOLDERNOTFOUND, CoreSettings.Default.SelectedLang))
                {
                    Message.StartPosition = FormStartPosition.CenterScreen;
                    Message.ShowDialog();
                }

                RemoveClickEventsFromMainButtons();
            }
            else if (UseStamps.Default.isFirstAny)
            {
                using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_GAMEFOLDERFOUND, CoreSettings.Default.SelectedLang))
                {
                    Message.StartPosition = FormStartPosition.CenterParent;
                    Message.ShowDialog();
                }
            }

            if (_gameSelected == 'r')
            {
                RemoveClickEventsFromCustomPortraitsButtons();
                
                UseStamps.Default.isAwareNPC = "NotRevealed";
                UseStamps.Default.Save();

                CheckBoxVerified.Checked = false;
                ButtonLoadCustom.Visible = false;
                ButtonLoadCustomNPC.Visible = false;
                ButtonLoadCustomArmy.Visible = false;

                Focus();
                return;
            }

            if (!ValidateCustomPath(ACTIVE_PATHS[_gameSelected]) && 
                (UseStamps.Default.isAwareNPC == "NotRevealed" || UseStamps.Default.isAwareNPC == "WorkRevealed"))
            {
                using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_CUSTOMNOTFOUND, CoreSettings.Default.SelectedLang))
                {
                    Message.StartPosition = FormStartPosition.CenterScreen;
                    Message.ShowDialog();
                }

                RemoveClickEventsFromCustomPortraitsButtons();
                
                UseStamps.Default.isAwareNPC = "NotWorkRevealed";
                UseStamps.Default.Save();

                CheckBoxVerified.Checked = false;
                ButtonLoadCustom.Visible = false;
                ButtonLoadCustomNPC.Visible = false;
                ButtonLoadCustomArmy.Visible = false;
            }
            else if (ValidateCustomPath(ACTIVE_PATHS[_gameSelected]) && 
                (UseStamps.Default.isAwareNPC == "NotRevealed" || UseStamps.Default.isAwareNPC == "NotWorkRevealed"))
            {
                using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_CUSTOMFOUND, CoreSettings.Default.SelectedLang))
                {
                    Message.StartPosition = FormStartPosition.CenterScreen;
                    Message.ShowDialog();
                }

                AddClickEventsToCustomPortraitsButtons();
                
                UseStamps.Default.isAwareNPC = "WorkRevealed";
                UseStamps.Default.Save();

                CheckBoxVerified.Checked = true;
                ButtonLoadCustom.Visible = true;
                ButtonLoadCustomNPC.Visible = true;
                ButtonLoadCustomArmy.Visible = true;
            }

            if (UseStamps.Default.isAwareNPC == "WorkRevealed")
            {
                CheckBoxVerified.Checked = true;
            }
            else
            {
                CheckBoxVerified.Checked = false;
            }

            Focus();
        }

        private void LanguageInit()
        {
            if (Thread.CurrentThread.CurrentUICulture == CultureInfo.GetCultureInfo("ru-RU"))
            {
                FontsInit(_fontCollection, 1);
            }
            else
            {
                FontsInit(_fontCollection);
            }

            TextsInit();
            LabelLang.Text = TextVariables.LABEL_LANG + " " + Thread.CurrentThread.CurrentUICulture.ToString();
        }
        
        private void FormInit()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.Selectable, false);
            
            CenterToScreen();
            ParentLayoutsSetDockFill();            
            UpdateColorScheme();

            PicPortraitTemp.AllowDrop = true;
            PicPortraitLrg.MouseWheel += PicPortraitLrg_MouseWheel;
            PicPortraitMed.MouseWheel += PicPortraitMed_MouseWheel;
            PicPortraitSml.MouseWheel += PicPortraitSml_MouseWheel;

            ParentLayoutsDisable();
            RootFunctions.LayoutDisable(LayoutURLDialog);
            RootFunctions.LayoutDisable(LayoutFinalPage);
            RootFunctions.LayoutEnable(LayoutMainPage);
            Focus();

            CheckBoxVerified.AutoCheck = false;
        }
        
        private void ButtonToFilePage_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 1;

            RestoreFilePageToInit();
            CreateAllImagesInTemp("!DEFAULT!", 100);
            GenerateImageSelectionFlagString(100);
            LoadTempImagesToPicBox(100);

            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutFilePage);
            Focus();
            ResizeVisibleImagesToWindowSize();

            if (UseStamps.Default.isFirstPortrait == true)
            {
                using (MyMessageDialog Hint = new MyMessageDialog(TextVariables.HINT_FILEPAGE, CoreSettings.Default.SelectedLang))
                {
                    Hint.StartPosition = FormStartPosition.CenterParent;
                    Hint.ShowDialog();
                }

                UseStamps.Default.isFirstPortrait = false;
                UseStamps.Default.Save();
            }

            if (!_isAspectRatioFixed)
            {
                FixPicBoxAspectRatio(PanelPortraitLrg, GAME_TYPES[_gameSelected].GetLargeAspect());
                FixPicBoxAspectRatio(PanelPortraitMed, GAME_TYPES[_gameSelected].GetMediumAspect());
                FixPicBoxAspectRatio(PanelPortraitSml, GAME_TYPES[_gameSelected].GetSmallAspect());
                _isAspectRatioFixed = true;
            }
        }

        private void ButtonToScalePage_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 2;

            if (!_isAnyLoadedToPortraitPage)
            {
                using (MyInquiryDialog Inquiry = new MyInquiryDialog(TextVariables.INQR_NOIMAGECHOSEN, CoreSettings.Default.SelectedLang))
                {
                    Inquiry.StartPosition = FormStartPosition.CenterParent;
                    Inquiry.Width = Width - 16;
                    if (Inquiry.ShowDialog() == DialogResult.OK)
                    {
                        ParentLayoutsDisable();
                        LoadAllTempImagesToPicBox();

                        RootFunctions.LayoutEnable(LayoutScalePage);
                        Focus();
                        ResizeVisibleImagesToWindowSize();
                    }
                    else
                    {
                        _activeMenuIndex = 1;
                        return;
                    }
                }
            }
            else
            {
                ParentLayoutsDisable();
                LoadAllTempImagesToPicBox();

                RootFunctions.LayoutEnable(LayoutScalePage);
                Focus();
                ResizeVisibleImagesToWindowSize();
            }

            GenerateImageSelectionFlagString(0);

            if (UseStamps.Default.isFirstScaling)
            {
                using (MyMessageDialog Hint = new MyMessageDialog(TextVariables.HINT_SCALEPAGE, CoreSettings.Default.SelectedLang))
                {
                    Hint.StartPosition = FormStartPosition.CenterParent;
                    Hint.ShowDialog();
                }

                UseStamps.Default.isFirstScaling = false;
                UseStamps.Default.Save();
            }
        }
        
        private void ButtonToFilePage2_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 1;

            RestoreFilePageToInit();
            _isAnyLoadedToPortraitPage = true;
            LoadTempImagesToPicBox(_imageSelectionFlag);

            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutFilePage);
            Focus();
            ResizeVisibleImagesToWindowSize();

            Focus();
        }

        private void ButtonToFilePage3_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 1;

            ButtonToFilePage3.BackColor = Color.Black;
            ButtonToFilePage3.ForeColor = Color.White;
            RestoreFilePageToInit();
            RootFunctions.LayoutDisable(LayoutFinalPage);
            ReplacePictureBoxImagesToDefault();
            SystemControl.FileControl.CreateTempImages("!DEFAULT!", TEMP_APPENDS, GAME_TYPES[_gameSelected].PlaceholderImage);
            LoadTempImagesToPicBox(_imageSelectionFlag);

            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutFilePage);
            Focus();
            ResizeVisibleImagesToWindowSize();
            GenerateImageSelectionFlagString(100);
            ButtonToMainPageAndFolder.Enabled = true;
        }
        
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 0;

            DisposePrimeImages();
            ClearImageListsSync(ListGallery, ImgListGallery);
            ClearImageListsSync(ListExtract, ImgListExtract);
            SystemControl.FileControl.ClearTempImages();
            Application.Exit();
        }
        
        private void ButtonToExtract_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 3;

            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutExtractPage);
            Focus();

            ButtonExtractAll.Enabled = false;
            ButtonExtractSelected.Enabled = false;
            ButtonOpenFolders.Enabled = false;

            if (UseStamps.Default.isFirstExtract == true)
            {
                using (MyMessageDialog Hint = new MyMessageDialog(TextVariables.HINT_EXTRACTPAGE, CoreSettings.Default.SelectedLang))
                {
                    Hint.StartPosition = FormStartPosition.CenterParent;
                    Hint.ShowDialog();
                }

                UseStamps.Default.isFirstExtract = false;
                UseStamps.Default.Save();
            }
        }
        
        private void ButtonToGalleryPage_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 4;

            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutGallery);
            Focus();

            if (!LoadGallery(ACTIVE_PATHS[_gameSelected]))
            {
                ButtonToMainPage3_Click(sender, e);
                return;
            }

            if (UseStamps.Default.isFirstGallery == true)
            {
                using (MyMessageDialog Hint = new MyMessageDialog(TextVariables.HINT_GALLERYPAGE, CoreSettings.Default.SelectedLang))
                {
                    Hint.StartPosition = FormStartPosition.CenterParent;
                    Hint.ShowDialog();
                }

                UseStamps.Default.isFirstGallery = false;
                UseStamps.Default.Save();
            }

            if (_gameSelected == 'w')
            {
                ButtonLoadCustomArmy.Visible = true;
            }
            else if (_gameSelected == 'p')
            {
                ButtonLoadCustomArmy.Visible = false;
            }
        }
        
        private void ButtonToMainPage_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 0;

            ReplacePictureBoxImagesToDefault();
            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutMainPage);

            Focus();
        }

        private void ButtonToMainPage2_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 0;

            _extractFolderPath = "!NONE!";
            _cancellationTokenSource?.Cancel();
            ClearImageListsSync(ListExtract, ImgListExtract);

            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutMainPage);

            Focus();
        }

        private void ButtonToMainPage3_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 0;

            _cancellationTokenSource?.Cancel();
            ClearImageListsSync(ListGallery, ImgListGallery);

            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutMainPage);

            Focus();
        }

        private void ButtonToMainPage4_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 0;

            ButtonToMainPage4.BackColor = Color.Black;
            ButtonToMainPage4.ForeColor = Color.White;
            RestoreFilePageToInit();
            ReplacePictureBoxImagesToDefault();

            ParentLayoutsDisable();
            RootFunctions.LayoutDisable(LayoutFinalPage);
            RootFunctions.LayoutEnable(LayoutMainPage);

            Focus();
        }
       
        private void ButtonToMainPage5_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 0;

            CoreSettings.Default.GameType = _gameSelected;
            CoreSettings.Default.MaxWindowHeight = Height;
            CoreSettings.Default.MaxWindowWidth = Width;
            CoreSettings.Default.Save();

            FormBorderStyle = FormBorderStyle.FixedSingle;
            ButtonValidatePath.Text = TextVariables.BUTTON_VALIDATE;
            ButtonValidatePath.BackColor = Color.Black;
            ButtonValidatePath.ForeColor = Color.White;
            ButtonValidatePath.Enabled = true;
            CenterToScreen();
            Application.Restart();
            _isAspectRatioFixed = false;
            Focus();
        }
        
        private void ButtonToSettingsPage_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 5;

            RootFunctions.LayoutDisable(LayoutMainPage);
            RootFunctions.LayoutEnable(LayoutSettingsPage);

            TextBoxFullPath.Text = ACTIVE_PATHS[_gameSelected];
            ButtonToMainPage5.ForeColor = Color.White;
            ButtonToMainPage5.BackColor = Color.Black;
            FormBorderStyle = FormBorderStyle.Sizable;

            Focus();
        }

        private void MainForm_Closed(object sender, FormClosedEventArgs e)
        {
            DisposePrimeImages();
            ClearImageListsSync(ListGallery, ImgListGallery);
            ClearImageListsSync(ListExtract, ImgListExtract);
            SystemControl.FileControl.ClearTempImages();
            Dispose();
            Application.Exit();
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_activeMenuIndex == 0)
            {
                switch (e.KeyChar)
                {
                    case '1':
                        ButtonToFilePage_Click(sender, e);
                        break;
                    case '2':
                        ButtonToExtract_Click(sender, e);
                        break;
                    case '3':
                        ButtonToGalleryPage_Click(sender, e);
                        break;
                    case '\t':
                        PictureBoxTitle_Click(sender, e);
                        break;
                    case '\b':
                        ButtonExit_Click(sender, e);
                        break;
                }
            }
            else if (_activeMenuIndex == 1)
            {
                switch (e.KeyChar)
                {
                    case '1':
                        ButtonLocalPortraitLoad_Click(sender, e);
                        break;
                    case 'l':
                        ButtonLocalPortraitLoad_Click(sender, e);
                        break;
                    case '2':
                        ButtonWebPortraitLoad_Click(sender, e);
                        break;
                    case 'w':
                        ButtonWebPortraitLoad_Click(sender, e);
                        break;
                    case '\b':
                        ButtonToMainPage_Click(sender, e);
                        break;
                    case 'q':
                        ButtonToMainPage_Click(sender, e);
                        break;
                    case 'r':
                        ButtonToScalePage_Click(sender, e);
                        break;
                    case 'e':
                        ButtonNextImageType_Click(sender, e);
                        break;
                }
            }
            else if (_activeMenuIndex == 2)
            {
                switch (e.KeyChar)
                {
                    case 'q':
                        ButtonToFilePage2_Click(sender, e);
                        break;
                    case '\b':
                        ButtonToFilePage2_Click(sender, e);
                        break;
                    case 'e':
                        ButtonCreatePortrait_Click(sender, e);
                        break;
                    case 'r':
                        ResizeVisibleImagesToWindowSize();
                        break;

                }
            }
            else if (_activeMenuIndex == 100)
            {
                switch (e.KeyChar)
                {
                    case '1':
                        ButtonToMainPage4_Click(sender, e);
                        break;
                    case '2':
                        ButtonToFilePage3_Click(sender, e);
                        break;
                    case '3':
                        ButtonToMainPageAndFolder_Click(sender, e);
                        break;
                    case 'q':
                        ButtonToMainPage4_Click(sender, e);
                        break;
                    case '\b':
                        ButtonToMainPage4_Click(sender, e);
                        break;
                }
            }
            else if (_activeMenuIndex == 4)
            {
                switch (e.KeyChar)
                {
                    case 'o':
                        ButtonOpenFolder_Click(sender, e);
                        break;
                    case 'q':
                        ButtonToMainPage3_Click(sender, e);
                        break;
                    case '\b':
                        ButtonToMainPage3_Click(sender, e);
                        break;
                }
            }
            else if (_activeMenuIndex == 3)
            {
                switch (e.KeyChar)
                {
                    case 'e':
                        ButtonChooseFolder_Click(sender, e);
                        break;
                    case 'r':
                        ButtonExtractAll_Click(sender, e);
                        break;
                    case 'o':
                        ButtonOpenFolders_Click(sender, e);
                        break;
                    case 'q':
                        ButtonToMainPage2_Click(sender, e);
                        break;
                    case '\b':
                        ButtonToMainPage2_Click(sender, e);
                        break;
                }
            }
            else if (_activeMenuIndex == 200)
            {
                switch (e.KeyChar)
                {
                    case 'q':
                        ButtonDenyWeb_Click(sender, e);
                        break;
                    case '\b':
                        ButtonDenyWeb_Click(sender, e);
                        break;
                    case 'e':
                        ButtonLoadWeb_Click(sender, e);
                        break;

                }
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void ButtonStartKing_MouseEnter(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.start_path;
        }

        private void ButtonStartWotr_MouseEnter(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.start_wotr;
        }

        private void ButtonStartRt_MouseEnter(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.start_rt;
        }

        private void ButtonStartPoe_MouseEnter(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.start_poe;
        }

        private void ButtonStartPoed_MouseEnter(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.start_poed;
        }

        private void ButtonStartTyr_MouseEnter(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.start_tyr;
        }

        private void ButtonStartWaste_MouseEnter(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.start_waste;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.start_path;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.start_wotr;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.start_rt;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.start_poe;
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.start_poed;
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.start_tyr;
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.start_waste;
        }
    }
}
