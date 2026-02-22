/*    
    Zeight Portrait Manager
    Desktop application for managing in-game portraits for games from Owlcat Games, 
    Obsidian Entertainment and inXile Entertainment. 
    Including: 
        1. Pathfinder: Kingmaker,
        2. Pathfinder: Wrath of the Righteous, 
        3. Warhammer 40000: Rogue Trader,
        4. Pillars of Eternity, 
        5. Pillars of Eternity: Deadfire, 
        6. Tyranny,
        7. Wasteland 3.
    Copyright (C) 2024 Artemii "Zeight" Saganenko.

    GPL-2.0 license terms are listed in LICENSE.md file.
    License header for this project is listed in Program.cs.
*/

using PortraitManager.forms;
using PortraitManager.sources;
using PortraitManager.Properties;

using System;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using SystemControl;
using System.IO;


namespace PortraitManager
{
    public partial class MainForm : Form, IMessageFilter
    {
        private const int WM_MOUSEWHEEL = 0x020A;

        private static char _gameSelected;

        /*
         * 100 - Start page (initial page, with no game type active)
         * 150 - Path page
         * 20* - Main page 
         * (
         *      201 - Pathfinder: Kingmaker, 
         *      202 - Pathfinder: Wotr, 
         *      203 - Rogue Trader
         *      204 - Pillars of Eternity
         *      205 - Pillars of Eternity: Deadfire
         *      206 - Tyranny
         *      207 - Wasteland 3
         * )
         * 30* - Portrait page
         * (
         *      301 - Pathfinder: Kingmaker, 
         *      302 - Pathfinder: Wotr, 
         *      303 - Rogue Trader
         *      304 - Pillars of Eternity
         *      305 - Pillars of Eternity: Deadfire
         *      306 - Tyranny
         *      307 - Wasteland 3
         * )
         * 
         * 3 - File page
         * 4 - Scale page
         * 5 - Extract page
         * 6 - Gallery page
         * 100 - File>web page
         * 200 - Scale>finish page
         * 65535 - Debug/Error
         */
        private static ushort _activeIndex = 100;

        /*
         * 1 - Large
         * 2 - Medium
         * 3 - Small
         * 4 - Large 2
         * 5 - Medium 2
         */
        private static ushort _activeMenuIndex = 0;

        private enum KingPortraitGroupSelection
        {
            Large,
            Medium,
            Small
        }

        private KingPortraitGroupSelection _activeKingPortraitGroup = KingPortraitGroupSelection.Large;


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
        private static Point _pictureDragStart = new Point();

        // Store original images for zoom without quality loss
        private static Image _originalImageLrg;
        private static Image _originalImageMed;
        private static Image _originalImageSml;
        // Track current zoom level as ratio to original size
        private static float _zoomLevelLrg = 1.0f;
        private static float _zoomLevelMed = 1.0f;
        private static float _zoomLevelSml = 1.0f;

        private static PrivateFontCollection _fontCollection;
        private static CancellationTokenSource _cancellationTokenSource;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;     
                return handleParam;
            }
        }

        public MainForm()
        {            
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.Selectable, false);
            Application.AddMessageFilter(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {            
            _fontCollection = FileControl.InitCustomFont(Resources.BebasNeue_Regular, Resources.BebasNeue_Regular_ru);
            _activeMenuIndex = 65535;
            SetClientSizeCore(750, 520);
            CenterToScreen();
            ParentLayoutsSetDockFill();
            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutStartMenu);
            LoadText();
            LoadFont(_fontCollection);
            LabelSelectPathSelected.Text = CoreSettings.Default.GamePath;

            if (CoreSettings.Default.GameType == '-')
            {
                _gameSelected = '-';
                RootFunctions.LayoutEnable(LayoutStartMenu);
                _activeMenuIndex = 100;                
            }
            else if (CoreSettings.Default.GameType == 'w')
            {
                _gameSelected = 'w';
                _activeMenuIndex = 202;
                LabelSelectPathNextToMain_Click(sender, e);

            }
            else if (CoreSettings.Default.GameType == 'r')
            {
                _gameSelected = 'r';
                _activeMenuIndex = 203;
                LabelSelectPathNextToMain_Click(sender, e);
            }
            else if (CoreSettings.Default.GameType == 'p')
            {
                _gameSelected = 'p';
                _activeMenuIndex = 204;
                LabelSelectPathNextToMain_Click(sender, e);
            }
            else if (CoreSettings.Default.GameType == 'd')
            {
                _gameSelected = 'd';
                _activeMenuIndex = 205;
                LabelSelectPathNextToMain_Click(sender, e);
            }
            else if (CoreSettings.Default.GameType == 't')
            {
                _gameSelected = 't';
                _activeMenuIndex = 206;
                LabelSelectPathNextToMain_Click(sender, e);
            }
            else if (CoreSettings.Default.GameType == 'l')
            {
                _gameSelected = 'l';
                _activeMenuIndex = 207;
                LabelSelectPathNextToMain_Click(sender, e);
            }
            else 
            {
                _gameSelected = 'k';
                _activeMenuIndex = 201;
                LabelSelectPathNextToMain_Click(sender, e);
            }

            Focus();
            SetKingPortraitGroup(KingPortraitGroupSelection.Large);



            //if (UseStamps.Default.isFirstAny)
            //{
            //    var currentUICulture = CultureInfo.CurrentUICulture.ToString();
            //    if (currentUICulture == "en-US" ||
            //        currentUICulture == "ru-RU" ||
            //        currentUICulture == "de-DE"
            //        )
            //    {
            //        Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentUICulture;
            //    }
            //    else
            //    {
            //        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            //    }

            //    CoreSettings.Default.KINGPath = KINGMAKER_TYPE.NormalDefaultDirectory;
            //    CoreSettings.Default.WOTRPath = WRATH_TYPE.NormalDefaultDirectory;
            //    CoreSettings.Default.ROGUEPath = ROGUE_TYPE.NormalDefaultDirectory;
            //    CoreSettings.Default.MaxWindowHeight = Size.Height;
            //    CoreSettings.Default.MaxWindowWidth = Size.Width;
            //    CoreSettings.Default.SelectedLang = Thread.CurrentThread.CurrentUICulture.ToString();
            //    CoreSettings.Default.Save();

            //    UseStamps.Default.isFirstAny = false;
            //    UseStamps.Default.Save();
            //}
            //else
            //{
            //    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(CoreSettings.Default.SelectedLang);
            //}

            //ACTIVE_PATHS['w'] = CoreSettings.Default.WOTRPath;
            //ACTIVE_PATHS['p'] = CoreSettings.Default.KINGPath;
            //ACTIVE_PATHS['r'] = CoreSettings.Default.ROGUEPath;
            //Width = CoreSettings.Default.MaxWindowWidth;
            //Height = CoreSettings.Default.MaxWindowHeight;



            //FormInit();
            //LanguageInit();
            //CenterToScreen();


            //if (!ValidatePortraitPath(ACTIVE_PATHS[_gameSelected]))
            //{
            //    using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_GAMEFOLDERNOTFOUND, CoreSettings.Default.SelectedLang))
            //    {
            //        Message.StartPosition = FormStartPosition.CenterScreen;
            //        Message.ShowDialog();
            //    }

            //    RemoveClickEventsFromMainButtons();
            //}
            //else if (UseStamps.Default.isFirstAny)
            //{
            //    using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_GAMEFOLDERFOUND, CoreSettings.Default.SelectedLang))
            //    {
            //        Message.StartPosition = FormStartPosition.CenterParent;
            //        Message.ShowDialog();
            //    }
            //}

            //if (_gameSelected == 'r')
            //{
            //    RemoveClickEventsFromCustomPortraitsButtons();

            //    UseStamps.Default.isAwareNPC = "NotRevealed";
            //    UseStamps.Default.Save();

            //    CheckBoxVerified.Checked = false;
            //    ButtonLoadCustom.Visible = false;
            //    ButtonLoadCustomNPC.Visible = false;
            //    ButtonLoadCustomArmy.Visible = false;

            //    Focus();
            //    return;
            //}

            //if (!ValidateCustomPath(ACTIVE_PATHS[_gameSelected]) && 
            //    (UseStamps.Default.isAwareNPC == "NotRevealed" || UseStamps.Default.isAwareNPC == "WorkRevealed"))
            //{
            //    using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_CUSTOMNOTFOUND, CoreSettings.Default.SelectedLang))
            //    {
            //        Message.StartPosition = FormStartPosition.CenterScreen;
            //        Message.ShowDialog();
            //    }

            //    RemoveClickEventsFromCustomPortraitsButtons();

            //    UseStamps.Default.isAwareNPC = "NotWorkRevealed";
            //    UseStamps.Default.Save();

            //    CheckBoxVerified.Checked = false;
            //    ButtonLoadCustom.Visible = false;
            //    ButtonLoadCustomNPC.Visible = false;
            //    ButtonLoadCustomArmy.Visible = false;
            //}
            //else if (ValidateCustomPath(ACTIVE_PATHS[_gameSelected]) && 
            //    (UseStamps.Default.isAwareNPC == "NotRevealed" || UseStamps.Default.isAwareNPC == "NotWorkRevealed"))
            //{
            //    using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_CUSTOMFOUND, CoreSettings.Default.SelectedLang))
            //    {
            //        Message.StartPosition = FormStartPosition.CenterScreen;
            //        Message.ShowDialog();
            //    }

            //    AddClickEventsToCustomPortraitsButtons();

            //    UseStamps.Default.isAwareNPC = "WorkRevealed";
            //    UseStamps.Default.Save();

            //    CheckBoxVerified.Checked = true;
            //    ButtonLoadCustom.Visible = true;
            //    ButtonLoadCustomNPC.Visible = true;
            //    ButtonLoadCustomArmy.Visible = true;
            //}

            //if (UseStamps.Default.isAwareNPC == "WorkRevealed")
            //{
            //    CheckBoxVerified.Checked = true;
            //}
            //else
            //{
            //    CheckBoxVerified.Checked = false;
            //}

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
            //LabelLang.Text = TextVariables.LABEL_LANG + " " + Thread.CurrentThread.CurrentUICulture.ToString();
        }
        
        private void FormInit()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.Selectable, false);
            
            CenterToScreen();
            ParentLayoutsSetDockFill();            
            UpdateColorScheme();

            //PicPortraitTemp.AllowDrop = true;
            //PicPortraitLrg.MouseWheel += PicPortraitLrg_MouseWheel;
            //PicPortraitMed.MouseWheel += PicPortraitMed_MouseWheel;
            //PicPortraitSml.MouseWheel += PicPortraitSml_MouseWheel;

            ParentLayoutsDisable();
            //RootFunctions.LayoutDisable(LayoutURLDialog);
            //RootFunctions.LayoutDisable(LayoutFinalPage);
            //RootFunctions.LayoutEnable(LayoutMainPage);
            RootFunctions.LayoutEnable(LayoutStartMenu);
            Focus();

            //CheckBoxVerified.AutoCheck = false;
        }
        
        private void ButtonToFilePage_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 1;

            RestoreFilePageToInit();
            CreateAllImagesInTemp("!DEFAULT!", 100);
            GenerateImageSelectionFlagString(100);
            LoadTempImagesToPicBox(100);

            ParentLayoutsDisable();
            //RootFunctions.LayoutEnable(LayoutFilePage);
            Focus();
            ResizeVisibleImagesToWindowSize();

            if (UseStamps.Default.isFirstPortrait == true)
            {
                //using (MyMessageDialog Hint = new MyMessageDialog(TextVariables.HINT_FILEPAGE, CoreSettings.Default.SelectedLang))
                //{
                //    Hint.StartPosition = FormStartPosition.CenterParent;
                //    Hint.ShowDialog();
                //}

                UseStamps.Default.isFirstPortrait = false;
                UseStamps.Default.Save();
            }

            if (!_isAspectRatioFixed)
            {
                //FixPicBoxAspectRatio(PanelPortraitLrg, GAME_TYPES[_gameSelected].GetLargeAspect());
                //FixPicBoxAspectRatio(PanelPortraitMed, GAME_TYPES[_gameSelected].GetMediumAspect());
                //FixPicBoxAspectRatio(PanelPortraitSml, GAME_TYPES[_gameSelected].GetSmallAspect());
                _isAspectRatioFixed = true;
            }
        }

        private void ButtonToScalePage_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 2;

            if (!_isAnyLoadedToPortraitPage)
            {
                //using (MyInquiryDialog Inquiry = new MyInquiryDialog(TextVariables.INQR_NOIMAGECHOSEN, CoreSettings.Default.SelectedLang))
                //{
                //    Inquiry.StartPosition = FormStartPosition.CenterParent;
                //    Inquiry.Width = Width - 16;
                //    if (Inquiry.ShowDialog() == DialogResult.OK)
                //    {
                //        ParentLayoutsDisable();
                //        LoadAllTempImagesToPicBox();

                //        RootFunctions.LayoutEnable(LayoutScalePage);
                //        Focus();
                //        ResizeVisibleImagesToWindowSize();
                //    }
                //    else
                //    {
                //        _activeMenuIndex = 1;
                //        return;
                //    }
                //}
            }
            else
            {
                ParentLayoutsDisable();
                LoadAllTempImagesToPicBox();

                //RootFunctions.LayoutEnable(LayoutScalePage);
                Focus();
                ResizeVisibleImagesToWindowSize();
            }

            GenerateImageSelectionFlagString(0);

            if (UseStamps.Default.isFirstScaling)
            {
                //using (MyMessageDialog Hint = new MyMessageDialog(TextVariables.HINT_SCALEPAGE, CoreSettings.Default.SelectedLang))
                //{
                //    Hint.StartPosition = FormStartPosition.CenterParent;
                //    Hint.ShowDialog();
                //}

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
            //RootFunctions.LayoutEnable(LayoutFilePage);
            Focus();
            ResizeVisibleImagesToWindowSize();

            Focus();
        }

        private void ButtonToFilePage3_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 1;

            //ButtonToFilePage3.BackColor = Color.Black;
            //ButtonToFilePage3.ForeColor = Color.White;
            RestoreFilePageToInit();
            //RootFunctions.LayoutDisable(LayoutFinalPage);
            ReplacePictureBoxImagesToDefault();
            //SystemControl.FileControl.CreateTempImages("!DEFAULT!", TEMP_APPENDS, GAME_TYPES[_gameSelected].PortraitPlaceholderImage);
            LoadTempImagesToPicBox(_imageSelectionFlag);

            ParentLayoutsDisable();
            //RootFunctions.LayoutEnable(LayoutFilePage);
            Focus();
            ResizeVisibleImagesToWindowSize();
            GenerateImageSelectionFlagString(100);
            //ButtonToMainPageAndFolder.Enabled = true;
        }
        
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 0;

            Application.RemoveMessageFilter(this);
            DisposePrimeImages();
            //ClearImageListsSync(ListGallery, ImgListGallery);
            //ClearImageListsSync(ListExtract, ImgListExtract);
            SystemControl.FileControl.ClearTempImages();
            Application.Exit();
        }
        
        private void ButtonToExtract_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 3;

            ParentLayoutsDisable();
            //RootFunctions.LayoutEnable(LayoutExtractPage);
            Focus();

            //ButtonExtractAll.Enabled = false;
            //ButtonExtractSelected.Enabled = false;
            //ButtonOpenFolders.Enabled = false;

            if (UseStamps.Default.isFirstExtract == true)
            {
                //using (MyMessageDialog Hint = new MyMessageDialog(TextVariables.HINT_EXTRACTPAGE, CoreSettings.Default.SelectedLang))
                //{
                //    Hint.StartPosition = FormStartPosition.CenterParent;
                //    Hint.ShowDialog();
                //}

                UseStamps.Default.isFirstExtract = false;
                UseStamps.Default.Save();
            }
        }
        
        private void ButtonToGalleryPage_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 4;

            ParentLayoutsDisable();
            //RootFunctions.LayoutEnable(LayoutGallery);
            Focus();

            //if (!LoadGallery(ACTIVE_PATHS[_gameSelected]))
            //{
            //    ButtonToMainPage3_Click(sender, e);
            //    return;
            //}

            if (UseStamps.Default.isFirstGallery == true)
            {
                //using (MyMessageDialog Hint = new MyMessageDialog(TextVariables.HINT_GALLERYPAGE, CoreSettings.Default.SelectedLang))
                //{
                //    Hint.StartPosition = FormStartPosition.CenterParent;
                //    Hint.ShowDialog();
                //}

                UseStamps.Default.isFirstGallery = false;
                UseStamps.Default.Save();
            }

            if (_gameSelected == 'w')
            {
                //ButtonLoadCustomArmy.Visible = true;
            }
            else if (_gameSelected == 'p')
            {
                //ButtonLoadCustomArmy.Visible = false;
            }
        }
        
        private void ButtonToMainPage_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 0;

            ReplacePictureBoxImagesToDefault();
            ParentLayoutsDisable();
            //RootFunctions.LayoutEnable(LayoutMainPage);

            Focus();
        }

        private void ButtonToMainPage2_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 0;

            _extractFolderPath = "!NONE!";
            _cancellationTokenSource?.Cancel();
            //ClearImageListsSync(ListExtract, ImgListExtract);

            ParentLayoutsDisable();
            //RootFunctions.LayoutEnable(LayoutMainPage);

            Focus();
        }

        private void ButtonToMainPage3_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 0;

            _cancellationTokenSource?.Cancel();
            //ClearImageListsSync(ListGallery, ImgListGallery);

            ParentLayoutsDisable();
            //RootFunctions.LayoutEnable(LayoutMainPage);

            Focus();
        }

        private void ButtonToMainPage4_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 0;

            //ButtonToMainPage4.BackColor = Color.Black;
            //ButtonToMainPage4.ForeColor = Color.White;
            RestoreFilePageToInit();
            ReplacePictureBoxImagesToDefault();

            ParentLayoutsDisable();
            //RootFunctions.LayoutDisable(LayoutFinalPage);
            //RootFunctions.LayoutEnable(LayoutMainPage);

            Focus();
        }
       
        private void ButtonToMainPage5_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 0;

            CoreSettings.Default.GameType = _gameSelected;
            //CoreSettings.Default.MaxWindowHeight = Height;
            //CoreSettings.Default.MaxWindowWidth = Width;
            CoreSettings.Default.Save();

            FormBorderStyle = FormBorderStyle.FixedSingle;
            //ButtonValidatePath.Text = TextVariables.BUTTON_VALIDATE;
            //ButtonValidatePath.BackColor = Color.Black;
            //ButtonValidatePath.ForeColor = Color.White;
            //ButtonValidatePath.Enabled = true;
            CenterToScreen();
            Application.Restart();
            _isAspectRatioFixed = false;
            Focus();
        }
        
        private void ButtonToSettingsPage_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 5;

            //RootFunctions.LayoutDisable(LayoutMainPage);
            //RootFunctions.LayoutEnable(LayoutSettingsPage);

            //TextBoxFullPath.Text = ACTIVE_PATHS[_gameSelected];
            //ButtonToMainPage5.ForeColor = Color.White;
            //ButtonToMainPage5.BackColor = Color.Black;
            FormBorderStyle = FormBorderStyle.Sizable;

            Focus();
        }

        private void MainForm_Closed(object sender, FormClosedEventArgs e)
        {
            DisposePrimeImages();
            //ClearImageListsSync(ListGallery, ImgListGallery);
            //ClearImageListsSync(ListExtract, ImgListExtract);
            FileControl.ClearTempImages();
            Dispose();
            Application.Exit();
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (_activeMenuIndex == 0)
            //{
            //    switch (e.KeyChar)
            //    {
            //        case '1':
            //            ButtonToFilePage_Click(sender, e);
            //            break;
            //        case '2':
            //            ButtonToExtract_Click(sender, e);
            //            break;
            //        case '3':
            //            ButtonToGalleryPage_Click(sender, e);
            //            break;
            //        case '\t':
            //            PictureBoxTitle_Click(sender, e);
            //            break;
            //        case '\b':
            //            ButtonExit_Click(sender, e);
            //            break;
            //    }
            //}
            //else if (_activeMenuIndex == 1)
            //{
            //    switch (e.KeyChar)
            //    {
            //        case '1':
            //            ButtonLocalPortraitLoad_Click(sender, e);
            //            break;
            //        case 'l':
            //            ButtonLocalPortraitLoad_Click(sender, e);
            //            break;
            //        case '2':
            //            ButtonWebPortraitLoad_Click(sender, e);
            //            break;
            //        case 'w':
            //            ButtonWebPortraitLoad_Click(sender, e);
            //            break;
            //        case '\b':
            //            ButtonToMainPage_Click(sender, e);
            //            break;
            //        case 'q':
            //            ButtonToMainPage_Click(sender, e);
            //            break;
            //        case 'r':
            //            ButtonToScalePage_Click(sender, e);
            //            break;
            //        case 'e':
            //            ButtonNextImageType_Click(sender, e);
            //            break;
            //    }
            //}
            //else if (_activeMenuIndex == 2)
            //{
            //    switch (e.KeyChar)
            //    {
            //        case 'q':
            //            ButtonToFilePage2_Click(sender, e);
            //            break;
            //        case '\b':
            //            ButtonToFilePage2_Click(sender, e);
            //            break;
            //        case 'e':
            //            ButtonCreatePortrait_Click(sender, e);
            //            break;
            //        case 'r':
            //            ResizeVisibleImagesToWindowSize();
            //            break;

            //    }
            //}
            //else if (_activeMenuIndex == 100)
            //{
            //    switch (e.KeyChar)
            //    {
            //        case '1':
            //            ButtonToMainPage4_Click(sender, e);
            //            break;
            //        case '2':
            //            ButtonToFilePage3_Click(sender, e);
            //            break;
            //        case '3':
            //            ButtonToMainPageAndFolder_Click(sender, e);
            //            break;
            //        case 'q':
            //            ButtonToMainPage4_Click(sender, e);
            //            break;
            //        case '\b':
            //            ButtonToMainPage4_Click(sender, e);
            //            break;
            //    }
            //}
            //else if (_activeMenuIndex == 4)
            //{
            //    switch (e.KeyChar)
            //    {
            //        case 'o':
            //            ButtonOpenFolder_Click(sender, e);
            //            break;
            //        case 'q':
            //            ButtonToMainPage3_Click(sender, e);
            //            break;
            //        case '\b':
            //            ButtonToMainPage3_Click(sender, e);
            //            break;
            //    }
            //}
            //else if (_activeMenuIndex == 3)
            //{
            //    switch (e.KeyChar)
            //    {
            //        case 'e':
            //            ButtonChooseFolder_Click(sender, e);
            //            break;
            //        case 'r':
            //            ButtonExtractAll_Click(sender, e);
            //            break;
            //        case 'o':
            //            ButtonOpenFolders_Click(sender, e);
            //            break;
            //        case 'q':
            //            ButtonToMainPage2_Click(sender, e);
            //            break;
            //        case '\b':
            //            ButtonToMainPage2_Click(sender, e);
            //            break;
            //    }
            //}
            //else if (_activeMenuIndex == 200)
            //{
            //    switch (e.KeyChar)
            //    {
            //        case 'q':
            //            ButtonDenyWeb_Click(sender, e);
            //            break;
            //        case '\b':
            //            ButtonDenyWeb_Click(sender, e);
            //            break;
            //        case 'e':
            //            ButtonLoadWeb_Click(sender, e);
            //            break;

            //    }
            //}
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        }










        private void LabelSelectPathNextToMain_Click(object sender, EventArgs e)
        {
            string selectedPath = LabelSelectPathSelected.Text;
            CoreSettings.Default.GamePath = "0";
            CoreSettings.Default.GameType = '-';
            CoreSettings.Default.Save();
            if (string.IsNullOrEmpty(selectedPath) || selectedPath == "-" || selectedPath == " - ")
            {
                return;
            }
            if (_gameSelected == 'k')
            {
                try
                {
                    if (!Directory.Exists(selectedPath) || string.IsNullOrWhiteSpace(selectedPath))
                        return;

                    selectedPath = selectedPath.Replace('/', '\\');

                    var dir = new DirectoryInfo(selectedPath);
                    while (dir != null &&
                            !dir.Name.Equals("Pathfinder Kingmaker", StringComparison.OrdinalIgnoreCase))
                        dir = dir.Parent;

                    if (dir == null)
                        return;

                    string rootPath = dir.FullName + Path.DirectorySeparatorChar;
                    string portraitsDir = Path.Combine(rootPath, "Portraits");
                    if (!Directory.Exists(portraitsDir))
                        Directory.CreateDirectory(portraitsDir);

                    LabelSelectPathSelected.Text = rootPath;
                    CoreSettings.Default.GamePath = rootPath;
                    CoreSettings.Default.GameType = 'k';
                    CoreSettings.Default.Save();
                    LayoutMainPage.BackgroundImage = Resources.path_menu_page;
                    _activeMenuIndex = 201;
                    ParentLayoutsDisable();
                    RootFunctions.LayoutEnable(LayoutMainPage);
                    Focus();
                }
                catch (Exception)
                {
                    return;
                }
            }
            else if (_gameSelected == 'w')
            {
                try
                {
                    if (!Directory.Exists(selectedPath) || string.IsNullOrWhiteSpace(selectedPath))
                        return;

                    selectedPath = selectedPath.Replace('/', '\\');

                    var dir = new DirectoryInfo(selectedPath);
                    while (dir != null &&
                            !dir.Name.Equals("Pathfinder Wrath Of The Righteous", StringComparison.OrdinalIgnoreCase))
                        dir = dir.Parent;

                    if (dir == null)
                        return;

                    string rootPath = dir.FullName + Path.DirectorySeparatorChar;
                    string portraitsDir = Path.Combine(rootPath, "Portraits");
                    if (!Directory.Exists(portraitsDir))
                        Directory.CreateDirectory(portraitsDir);

                    LabelSelectPathSelected.Text = rootPath;
                    CoreSettings.Default.GamePath = rootPath;
                    CoreSettings.Default.Save();
                    LayoutMainPage.BackgroundImage = Resources.wotr_menu_page;
                    _activeMenuIndex = 202;
                    ParentLayoutsDisable();
                    RootFunctions.LayoutEnable(LayoutMainPage);
                    Focus();
                }
                catch (Exception)
                {
                    return;
                }
            }
            else if (_gameSelected == 'r')
            {
                try
                {
                    if (!Directory.Exists(selectedPath) || string.IsNullOrWhiteSpace(selectedPath))
                        return;

                    selectedPath = selectedPath.Replace('/', '\\');

                    var dir = new DirectoryInfo(selectedPath);
                    while (dir != null &&
                            !dir.Name.Equals("Warhammer 40000 Rogue Trader", StringComparison.OrdinalIgnoreCase))
                        dir = dir.Parent;

                    if (dir == null)
                        return;

                    string rootPath = dir.FullName + Path.DirectorySeparatorChar;
                    string portraitsDir = Path.Combine(rootPath, "Portraits");
                    if (!Directory.Exists(portraitsDir))
                        Directory.CreateDirectory(portraitsDir);

                    LabelSelectPathSelected.Text = rootPath;
                    CoreSettings.Default.GamePath = rootPath;
                    CoreSettings.Default.GameType = 'r';
                    CoreSettings.Default.Save();
                    LayoutMainPage.BackgroundImage = Resources.rt_menu_page;
                    _activeMenuIndex = 203;
                    ParentLayoutsDisable();
                    RootFunctions.LayoutEnable(LayoutMainPage);
                    Focus();
                }
                catch (Exception)
                {
                    return;
                }
            }
            else if (_gameSelected == 'p')
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(selectedPath) || !Directory.Exists(selectedPath))
                        return;

                    selectedPath = selectedPath.Replace('/', '\\');

                    var dir = new DirectoryInfo(selectedPath);
                    while (dir != null &&
                           !dir.Name.Equals("Pillars of Eternity", StringComparison.OrdinalIgnoreCase))
                    {
                        dir = dir.Parent;
                    }

                    if (dir == null)
                        return;

                    string rootPath = dir.FullName + Path.DirectorySeparatorChar;
                    string portraitsRoot = Path.Combine(rootPath, "PillarsOfEternity_Data", "data", "art", "gui", "portraits");
                    if (!Directory.Exists(portraitsRoot))
                        return;

                    string maleDir = Path.Combine(portraitsRoot, "player", "male");
                    string femaleDir = Path.Combine(portraitsRoot, "player", "female");
                    Directory.CreateDirectory(maleDir);
                    Directory.CreateDirectory(femaleDir);

                    LabelSelectPathSelected.Text = rootPath;
                    CoreSettings.Default.GamePath = rootPath;
                    CoreSettings.Default.GameType = 'p';
                    CoreSettings.Default.Save();
                    LayoutMainPage.BackgroundImage = Resources.poe_menu_page;
                    _activeMenuIndex = 204;
                    ParentLayoutsDisable();
                    RootFunctions.LayoutEnable(LayoutMainPage);
                    Focus();
                }
                catch (Exception)
                {
                    return;
                }
            }
            else if (_gameSelected == 'd')
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(selectedPath) || !Directory.Exists(selectedPath))
                        return;

                    selectedPath = selectedPath.Replace('/', '\\');

                    var dir = new DirectoryInfo(selectedPath);
                    while (dir != null &&
                           !dir.Name.Equals("Pillars of Eternity II Deadfire", StringComparison.OrdinalIgnoreCase) &&
                           !dir.Name.Equals("Pillars of Eternity II", StringComparison.OrdinalIgnoreCase) &&
                           !dir.Name.Equals("PillarsOfEternityII", StringComparison.OrdinalIgnoreCase) &&
                           !dir.Name.Equals("Pillars of Eternity II - Deadfire", StringComparison.OrdinalIgnoreCase))
                    {
                        dir = dir.Parent;
                    }

                    if (dir == null)
                        return;

                    string rootPath = dir.FullName + Path.DirectorySeparatorChar;                    
                    string portraitsRoot = Path.Combine(rootPath, "PillarsOfEternityII_Data", "gui", "portraits");
                    if (!Directory.Exists(portraitsRoot))
                        return;

                    string maleDir = Path.Combine(portraitsRoot, "player", "male");
                    string femaleDir = Path.Combine(portraitsRoot, "player", "female");
                    Directory.CreateDirectory(maleDir);
                    Directory.CreateDirectory(femaleDir);

                    LabelSelectPathSelected.Text = rootPath;
                    CoreSettings.Default.GamePath = rootPath;
                    CoreSettings.Default.GameType = 'd';
                    CoreSettings.Default.Save();
                    LayoutMainPage.BackgroundImage = Resources.poed_menu_page;
                    _activeMenuIndex = 205;
                    ParentLayoutsDisable();
                    RootFunctions.LayoutEnable(LayoutMainPage);
                    Focus();
                }
                catch (Exception)
                {
                    return;
                }
            }
            else if (_gameSelected == 't')
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(selectedPath) || !Directory.Exists(selectedPath))
                        return;

                    var dir = new DirectoryInfo(selectedPath);
                    while (dir != null && !dir.Name.Equals("Tyranny", StringComparison.OrdinalIgnoreCase))
                        dir = dir.Parent;
                    if (dir == null)
                        return;

                    string rootPath = dir.FullName + Path.DirectorySeparatorChar;
                    string checkPath = Path.Combine(rootPath, "Data", "data", "art", "gui", "icons", "abilities");

                    if (!Directory.Exists(checkPath))
                        return;

                    string maleDir = Path.Combine(rootPath, "Data", "data", "art", "gui", "portraits", "player", "male");
                    string femaleDir = Path.Combine(rootPath, "Data", "data", "art", "gui", "portraits", "player", "female");
                    Directory.CreateDirectory(maleDir);
                    Directory.CreateDirectory(femaleDir);

                    LabelSelectPathSelected.Text = rootPath.ToLower();
                    CoreSettings.Default.GamePath = rootPath;
                    CoreSettings.Default.GameType = 't';
                    CoreSettings.Default.Save();
                    LayoutMainPage.BackgroundImage = Resources.tyr_menu_page;
                    _activeMenuIndex = 206;
                    ParentLayoutsDisable();
                    RootFunctions.LayoutEnable(LayoutMainPage);
                    Focus();
                }
                catch (Exception)
                {
                    return;
                }
            }
            else if (_gameSelected == 'l')
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(selectedPath) || !Directory.Exists(selectedPath))
                        return;

                    var dir = new DirectoryInfo(selectedPath);
                    while (dir != null && !dir.Name.Equals("Wasteland3", StringComparison.OrdinalIgnoreCase))
                        dir = dir.Parent;
                    if (dir == null)
                        return;

                    string rootPath = dir.FullName + Path.DirectorySeparatorChar;

                    string customPortraits = Path.Combine(rootPath, "Custom Portraits");
                    Directory.CreateDirectory(customPortraits);

                    LabelSelectPathSelected.Text = rootPath.ToLower();
                    CoreSettings.Default.GamePath = rootPath;
                    CoreSettings.Default.GameType = 'l';
                    CoreSettings.Default.Save();
                    LayoutMainPage.BackgroundImage = Resources.waste_menu_page;
                    _activeMenuIndex = 207;
                    ParentLayoutsDisable();
                    RootFunctions.LayoutEnable(LayoutMainPage);
                    Focus();
                }
                catch (Exception)
                {
                    return;
                }
            }
        }























        private void LayoutPathPage_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LabelSelectPathChoosePath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog FolderChoose = new FolderBrowserDialog()
            {
                SelectedPath = GameTypes[_gameSelected].DefaultDirectory,
                //Description = TextVariables.TEXT_FOLDEROPEN,
                ShowNewFolderButton = false,
            })
            {
                if (FolderChoose.ShowDialog() == DialogResult.OK)
                {
                    LabelSelectPathSelected.Text = FolderChoose.SelectedPath;
                }
                else
                {
                    FolderChoose.Dispose();
                    return;
                }
            }
        }

        private void LabelCreatePortrait_Click(object sender, EventArgs e)
        {
            if (_gameSelected == 'k')
            {
                ParentLayoutsDisable();
                RootFunctions.LayoutEnable(LayoutKingCreatePortrait);
                _activeMenuIndex = 301;
                Focus();
            }
        }

        private void LabelKingCreatePortraitLarge_Click(object sender, EventArgs e)
        {
            SetKingPortraitGroup(KingPortraitGroupSelection.Large);
        }

        private void LabelKingCreatePortraitMedium_Click(object sender, EventArgs e)
        {
            SetKingPortraitGroup(KingPortraitGroupSelection.Medium);
        }

        private void LabelKingCreatePortraitSmall_Click(object sender, EventArgs e)
        {
            SetKingPortraitGroup(KingPortraitGroupSelection.Small);
        }

        private void ButtonKingAction_Click(object sender, EventArgs e)
        {
            // placeholder action for right-side button
            MessageBox.Show("King action clicked", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ButtonKingSelectWeb_Click(object sender, EventArgs e)
        {
            // placeholder: open web selection dialog
            // sender.Tag contains picture box name currently, but for now do nothing
        }

        private void ButtonKingSelectLocal_Click(object sender, EventArgs e)
        {
            // Open local file dialog and set image with initial fit
            if (sender is Button btn && btn.Tag is string picName)
            {
                PictureBox pic = this.Controls.Find(picName, true).FirstOrDefault() as PictureBox;
                if (pic == null) return;

                using (OpenFileDialog ofd = new OpenFileDialog()
                {
                    Filter = "Image files|*.png;*.jpg;*.jpeg;*.bmp",
                    Multiselect = false
                })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (Image fileImg = Image.FromFile(ofd.FileName))
                            {
                                Bitmap copy = ImageControl.Direct.Resize(fileImg, fileImg.Width, fileImg.Height);
                                StoreOriginalImage(pic, copy);
                            }
                            FitImageToPanel(pic);
                        }
                        catch
                        {
                            return;
                        }
                    }
                }
            }
        }

        private void StoreOriginalImage(PictureBox pic, Image img)
        {
            if (pic.Name == "PicKingLrg")
            {
                _originalImageLrg?.Dispose();
                _originalImageLrg = img;
                _zoomLevelLrg = 1.0f;
            }
            else if (pic.Name == "PicKingMed")
            {
                _originalImageMed?.Dispose();
                _originalImageMed = img;
                _zoomLevelMed = 1.0f;
            }
            else if (pic.Name == "PicKingSml")
            {
                _originalImageSml?.Dispose();
                _originalImageSml = img;
                _zoomLevelSml = 1.0f;
            }
        }

        private Image GetOriginalImage(PictureBox pic)
        {
            if (pic.Name == "PicKingLrg") return _originalImageLrg;
            if (pic.Name == "PicKingMed") return _originalImageMed;
            if (pic.Name == "PicKingSml") return _originalImageSml;
            return null;
        }

        private float GetZoomLevel(PictureBox pic)
        {
            if (pic.Name == "PicKingLrg") return _zoomLevelLrg;
            if (pic.Name == "PicKingMed") return _zoomLevelMed;
            if (pic.Name == "PicKingSml") return _zoomLevelSml;
            return 1.0f;
        }

        private void SetZoomLevel(PictureBox pic, float zoom)
        {
            if (pic.Name == "PicKingLrg") _zoomLevelLrg = zoom;
            else if (pic.Name == "PicKingMed") _zoomLevelMed = zoom;
            else if (pic.Name == "PicKingSml") _zoomLevelSml = zoom;
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg != WM_MOUSEWHEEL) return false;

            Point cursor = Cursor.Position;
            Panel targetPanel = null;
            PictureBox targetPic = null;

            Panel[] panels = { PanelKingLrg, PanelKingMed, PanelKingSml };
            PictureBox[] pics = { PicKingLrg, PicKingMed, PicKingSml };

            for (int i = 0; i < panels.Length; i++)
            {
                if (panels[i] == null || !panels[i].Visible) continue;
                if (panels[i].RectangleToScreen(panels[i].ClientRectangle).Contains(cursor))
                {
                    targetPanel = panels[i];
                    targetPic = pics[i];
                    break;
                }
            }

            if (targetPanel == null || targetPic == null) return false;
            if (targetPic.Image == null) return false;

            int delta = (short)((m.WParam.ToInt64() >> 16) & 0xFFFF);
            Point localPos = targetPic.PointToClient(cursor);
            ZoomPortrait(targetPic, targetPanel, delta, localPos);
            return true;
        }

        private void ZoomPortrait(PictureBox pb, Panel panel, int wheelDelta, Point localPos)
        {
            Image original = GetOriginalImage(pb);
            if (original == null || pb.Image == null) return;

            float currentZoom = GetZoomLevel(pb);
            float zoomStep = 0.1f;
            float newZoom = wheelDelta > 0
                ? currentZoom + zoomStep
                : currentZoom - zoomStep;

            int panelW = panel.ClientSize.Width;
            int panelH = panel.ClientSize.Height;
            if (panelW <= 0 || panelH <= 0) return;

            float imgAspect = (float)original.Width / original.Height;
            float panelAspect = (float)panelW / panelH;
            float minZoom = imgAspect > panelAspect
                ? (float)panelH / original.Height
                : (float)panelW / original.Width;

            if (newZoom < minZoom) newZoom = minZoom;
            if (newZoom > 4.0f) newZoom = 4.0f;

            int newW = Math.Max(1, (int)(original.Width * newZoom));
            int newH = Math.Max(1, (int)(original.Height * newZoom));

            if (newW == pb.Width && newH == pb.Height)
                return;

            int oldW = pb.Width;
            int oldH = pb.Height;
            float relX = oldW <= 0 ? 0.5f : (float)localPos.X / oldW;
            float relY = oldH <= 0 ? 0.5f : (float)localPos.Y / oldH;

            Bitmap zoomed = ImageControl.Direct.Resize(original, newW, newH);
            Image old = pb.Image;
            pb.Image = zoomed;
            if (old != null && old != original)
                old.Dispose();
            SetZoomLevel(pb, newZoom);

            var desired = new Point(
                pb.Location.X - (int)(relX * newW - localPos.X),
                pb.Location.Y - (int)(relY * newH - localPos.Y));
            pb.Location = ClampPictureLocation(pb, panel, desired);
        }

        private void ButtonKingZoomIn_Click(object sender, EventArgs e)
        {
            ZoomFromButton(sender, 120);
        }

        private void ButtonKingZoomOut_Click(object sender, EventArgs e)
        {
            ZoomFromButton(sender, -120);
        }

        private void ZoomFromButton(object sender, int wheelDelta)
        {
            var button = sender as Button;
            if (button == null) return;

            string picName = button.Tag as string;
            if (string.IsNullOrEmpty(picName)) return;

            PictureBox pb = null;
            Panel panel = null;

            if (picName == "PicKingLrg") { pb = PicKingLrg; panel = PanelKingLrg; }
            else if (picName == "PicKingMed") { pb = PicKingMed; panel = PanelKingMed; }
            else if (picName == "PicKingSml") { pb = PicKingSml; panel = PanelKingSml; }

            if (pb == null || panel == null || pb.Image == null) return;

            Point center = new Point(pb.Width / 2, pb.Height / 2);
            ZoomPortrait(pb, panel, wheelDelta, center);
        }

        private void FitImageToPanel(PictureBox pic)
        {
            Image original = GetOriginalImage(pic);
            if (original == null) return;

            Panel panel = pic.Parent as Panel;
            if (panel == null) return;

            int panelW = panel.ClientSize.Width;
            int panelH = panel.ClientSize.Height;
            if (panelW <= 0 || panelH <= 0) return;

            float imgAspect = (float)original.Width / original.Height;
            float panelAspect = (float)panelW / panelH;

            int newW, newH;
            if (imgAspect > panelAspect)
            {
                newH = panelH;
                newW = Math.Max(1, (int)(panelH * imgAspect));
            }
            else
            {
                newW = panelW;
                newH = Math.Max(1, (int)(panelW / imgAspect));
            }

            float zoom = (float)newW / original.Width;
            SetZoomLevel(pic, zoom);

            Bitmap resized = ImageControl.Direct.Resize(original, newW, newH);
            Image oldImg = pic.Image;
            pic.Image = resized;
            if (oldImg != null && oldImg != original)
                oldImg.Dispose();

            int x = (panelW - newW) / 2;
            int y = (panelH - newH) / 2;
            pic.Location = new Point(x, y);
        }

        private void SetKingPortraitGroup(KingPortraitGroupSelection selection)
        {
            if (LayoutKingPortraitGroupLarge == null ||
                LayoutKingPortraitGroupMedium == null ||
                LayoutKingPortraitGroupSmall == null)
            {
                return;
            }

            _activeKingPortraitGroup = selection;

            LayoutKingPortraitGroupLarge.Visible = selection == KingPortraitGroupSelection.Large;
            LayoutKingPortraitGroupMedium.Visible = selection == KingPortraitGroupSelection.Medium;
            LayoutKingPortraitGroupSmall.Visible = selection == KingPortraitGroupSelection.Small;

            LayoutKingPortraitGroupLarge.BackColor = selection == KingPortraitGroupSelection.Large ? GameTypes[_gameSelected].BackColor : Color.Transparent;
            LayoutKingPortraitGroupMedium.BackColor = selection == KingPortraitGroupSelection.Medium ? GameTypes[_gameSelected].BackColor : Color.Transparent;
            LayoutKingPortraitGroupSmall.BackColor = selection == KingPortraitGroupSelection.Small ? GameTypes[_gameSelected].BackColor : Color.Transparent;

            Color selBack = GameTypes[_gameSelected].BackColor;
            Color selFore = GameTypes[_gameSelected].ForeColor;

            LabelKingCreatePortraitLarge.BackColor = selection == KingPortraitGroupSelection.Large ? selBack : Color.Transparent;
            LabelKingCreatePortraitLarge.ForeColor = selection == KingPortraitGroupSelection.Large ? selFore : Color.White;
            LabelKingCreatePortraitMedium.BackColor = selection == KingPortraitGroupSelection.Medium ? selBack : Color.Transparent;
            LabelKingCreatePortraitMedium.ForeColor = selection == KingPortraitGroupSelection.Medium ? selFore : Color.White;
            LabelKingCreatePortraitSmall.BackColor = selection == KingPortraitGroupSelection.Small ? selBack : Color.Transparent;
            LabelKingCreatePortraitSmall.ForeColor = selection == KingPortraitGroupSelection.Small ? selFore : Color.White;
        }

        private void LabelKingCreatePortraitLarge_MouseEnter(object sender, EventArgs e)
        {
            LabelKingCreatePortraitLarge.ForeColor = GameTypes[_gameSelected].ForeColor;
        }

        private void LabelKingCreatePortraitLarge_MouseLeave(object sender, EventArgs e)
        {
            LabelKingCreatePortraitLarge.ForeColor = Color.White;
        }

        private void LabelKingCreatePortraitMedium_MouseEnter(object sender, EventArgs e)
        {
            LabelKingCreatePortraitMedium.ForeColor = GameTypes[_gameSelected].ForeColor;
        }

        private void LabelKingCreatePortraitMedium_MouseLeave(object sender, EventArgs e)
        {
            LabelKingCreatePortraitMedium.ForeColor = Color.White;
        }

        private void LabelKingCreatePortraitSmall_MouseEnter(object sender, EventArgs e)
        {
            LabelKingCreatePortraitSmall.ForeColor = GameTypes[_gameSelected].ForeColor;
        }

        private void LabelKingCreatePortraitSmall_MouseLeave(object sender, EventArgs e)
        {
            LabelKingCreatePortraitSmall.ForeColor = Color.White;
        }
    }
}
