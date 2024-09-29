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
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Policy;


namespace PortraitManager
{
    public partial class MainForm : Form
    {
        private const string TEMP_LARGE_APPEND = "temp_DoNotDeleteWhileRunning\\FULL.png";
        private const string TEMP_MEDIUM_APPEND = "temp_DoNotDeleteWhileRunning\\MEDIUM.png";
        private const string TEMP_SMALL_APPEND = "temp_DoNotDeleteWhileRunning\\SMALL.png";

        private const string LARGE_APPEND = "\\Fulllength.png";
        private const string MEDIUM_APPEND = "\\Medium.png";
        private const string SMALL_APPEND = "\\Small.png";

        private static char _gameSelected;

        /*
         * 0 - Start page
         * 1 - Path page
         * 2 - Menu page
         * 3 - File page
         * 4 - Scale page
         * 5 - Extract page
         * 6 - Gallery page
         * 100 - File>web page
         * 200 - Scale>finish page
         * 65535 - Debug/Error
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
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.Selectable, false);
            InitializeComponent();          
        }

        private void MainForm_Load(object sender, EventArgs e)
        {            
            _fontCollection = SystemControl.FileControl.InitCustomFont(Resources.BebasNeue_Regular, Resources.BebasNeue_Regular_ru);
            _activeMenuIndex = 65535;
            SetClientSizeCore(750, 520);
            CenterToScreen();
            ParentLayoutsSetDockFill();
            ParentLayoutsDisable();
            LoadText();
            LoadFont(_fontCollection);         


            if (CoreSettings.Default.GameType == '-')
            {
                _gameSelected = '-';
                RootFunctions.LayoutEnable(LayoutStartMenu);
                _activeMenuIndex = 0;                
            }
            else if (CoreSettings.Default.GameType == 'w')
            {
                _gameSelected = 'w';
            }
            else if (CoreSettings.Default.GameType == 'r')
            {
                _gameSelected = 'r';
            }
            else if (CoreSettings.Default.GameType == 'p')
            {
                _gameSelected = 'p';
            }
            else if (CoreSettings.Default.GameType == 'd')
            {
                _gameSelected = 'd';
            }
            else if (CoreSettings.Default.GameType == 't')
            {
                _gameSelected = 't';
            }
            else if (CoreSettings.Default.GameType == 'l')
            {
                _gameSelected = 'l';
            }
            else
            {
                _gameSelected = 'k';
            }

            Focus();

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

            PicPortraitTemp.AllowDrop = true;
            PicPortraitLrg.MouseWheel += PicPortraitLrg_MouseWheel;
            PicPortraitMed.MouseWheel += PicPortraitMed_MouseWheel;
            PicPortraitSml.MouseWheel += PicPortraitSml_MouseWheel;

            ParentLayoutsDisable();
            RootFunctions.LayoutDisable(LayoutURLDialog);
            RootFunctions.LayoutDisable(LayoutFinalPage);
            //RootFunctions.LayoutEnable(LayoutMainPage);
            RootFunctions.LayoutEnable(LayoutStartMenu);
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

                RootFunctions.LayoutEnable(LayoutScalePage);
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
            //SystemControl.FileControl.CreateTempImages("!DEFAULT!", TEMP_APPENDS, GAME_TYPES[_gameSelected].PortraitPlaceholderImage);
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
            RootFunctions.LayoutEnable(LayoutGallery);
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
            //CoreSettings.Default.MaxWindowHeight = Height;
            //CoreSettings.Default.MaxWindowWidth = Width;
            CoreSettings.Default.Save();

            FormBorderStyle = FormBorderStyle.FixedSingle;
            //ButtonValidatePath.Text = TextVariables.BUTTON_VALIDATE;
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

            //TextBoxFullPath.Text = ACTIVE_PATHS[_gameSelected];
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

        private void LabelBackToStart_Click(object sender, EventArgs e)
        {
            _gameSelected = '-';
            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutStartMenu);
            _activeMenuIndex = 0;
        }

        private void LabelNextToMain_Click(object sender, EventArgs e)
        {

        }

        private void LabelBackToStart_MouseEnter(object sender, EventArgs e)
        {
            var font = LabelBackToStart.Font;

            LabelBackToStart.Font = new Font(font.FontFamily, 41);
            
        }

        private void LabelBackToStart_MouseLeave(object sender, EventArgs e)
        {
            var font = LabelBackToStart.Font;

            LabelBackToStart.Font = new Font(font.FontFamily, 27);
        }

        private void LabelNextToMain_MouseEnter(object sender, EventArgs e)
        {
            var font = LabelNextToMain.Font;

            LabelNextToMain.Font = new Font(font.FontFamily, 41);
        }

        private void LabelNextToMain_MouseLeave(object sender, EventArgs e)
        {
            var font = LabelNextToMain.Font;

            LabelNextToMain.Font = new Font(font.FontFamily, 27);
        }

        private void LayoutPathPage_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LabelResetPath_MouseEnter(object sender, EventArgs e)
        {
            var font = LabelStartResetPath.Font;

            LabelStartResetPath.Font = new Font(font.FontFamily, 21);
        }

        private void LabelResetPath_MouseLeave(object sender, EventArgs e)
        {
            var font = LabelStartResetPath.Font;

            LabelStartResetPath.Font = new Font(font.FontFamily, 13);
        }

        private void LabelSelectPath_MouseEnter(object sender, EventArgs e)
        {
            var font = LabelStartSelectPath.Font;

            LabelStartSelectPath.Font = new Font(font.FontFamily, 21);
        }

        private void LabelSelectPath_MouseLeave(object sender, EventArgs e)
        {
            var font = LabelStartSelectPath.Font;

            LabelStartSelectPath.Font = new Font(font.FontFamily, 13);
        }

        private void LabelStartResetPath_Click(object sender, EventArgs e)
        {
            TextBoxGameFolder.Text = GameTypes[_gameSelected].DefaultDirectory;
        }

        private void LabelStartSelectPath_Click(object sender, EventArgs e)
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
                    TextBoxGameFolder.Text = FolderChoose.SelectedPath;
                }
                else
                {
                    FolderChoose.Dispose();                    
                    return;
                }
            }
        }
    }
}
