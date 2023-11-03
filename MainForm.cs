/*    
    Pathfinder Portrait Manager. Desktop application for managing in game
    portraits for Pathfinder: Kingmaker and Pathfinder: Wrath of the Righteous
    Copyright (C) 2023 Artemii "Zeight" Saganenko
    LICENSE terms are written in LICENSE file
    Primal license header is written in Program.cs
*/

using PathfinderPortraitManager.forms;
using PathfinderPortraitManager.Properties;
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
        private static readonly GameTypeClass WRATH_TYPE = new GameTypeClass("Wrath of the Righteous",
            Color.FromArgb(255, 20, 147), Color.FromArgb(20, 6, 30),
            Resources.icon_wotr, Resources.title_wotr,
            Resources.bg_wotr, Resources.placeholder_wotr,
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow")
            + "\\Owlcat Games\\Pathfinder Wrath Of The Righteous\\Portraits", "Pathfinder Portrait Manager (WoTR)");
        private static readonly GameTypeClass KINGMAKER_TYPE = new GameTypeClass("Kingmaker",
            Color.FromArgb(218, 165, 32), Color.FromArgb(9, 28, 11),
            Resources.icon_path, Resources.title_path,
            Resources.bg_path, Resources.placeholder_path,
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow")
            + "\\Owlcat Games\\Pathfinder Kingmaker\\Portraits", "Pathfinder Portrait Manager (Kingmaker)");
        private static readonly Dictionary<char, GameTypeClass> GAME_TYPES = new Dictionary<char, GameTypeClass>
        {
            { 'p', KINGMAKER_TYPE},
            { 'w', WRATH_TYPE}
        };
        private static readonly Dictionary<char, string> ACTIVE_PATHS = new Dictionary<char, string>
        {
            { 'p', CoreSettings.Default.WOTRPath },
            { 'w', CoreSettings.Default.KINGPath }
        };

        private const string TEMP_LARGE_APPEND = "temp_DoNotDeleteWhileRunning\\FULL.png";
        private const string TEMP_MEDIUM_APPEND = "temp_DoNotDeleteWhileRunning\\MEDIUM.png";
        private const string TEMP_SMALL_APPEND = "temp_DoNotDeleteWhileRunning\\SMALL.png";
        private const string LARGE_APPEND = "\\Fulllength.png";
        private const string MEDIUM_APPEND = "\\Medium.png";
        private const string SMALL_APPEND = "\\Small.png";
        private const float LARGE_ASPECT = 1.479768786f;
        private const float MEDIUM_ASPECT = 1.309090909f;
        private const float SMALL_ASPECT = 1.308108108f;
        private static readonly string[] TEMP_APPENDS = { TEMP_LARGE_APPEND, TEMP_MEDIUM_APPEND, TEMP_SMALL_APPEND };
        private static readonly string[] APPENDS = { LARGE_APPEND, MEDIUM_APPEND, SMALL_APPEND };
        private static readonly float[] ASPECTS = { LARGE_ASPECT, MEDIUM_ASPECT, SMALL_ASPECT };

        private static ushort _imageSelectionFlag = 0;
        private static Point _mousePosition = new Point();
        private static int _isDraggingMouse = 0;
        private static bool _isAnyLoadedToPortraitPage = false;
        private static char _gameSelected = CoreSettings.Default.GameType;
        private static PrivateFontCollection _fontCollection;
        private static CancellationTokenSource _cancellationTokenSource;

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (UseStamps.Default.isFirstAny)
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentUICulture;
                CoreSettings.Default.KINGPath = KINGMAKER_TYPE.DefaultDirectory;
                CoreSettings.Default.WOTRPath = WRATH_TYPE.DefaultDirectory;
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
            Width = CoreSettings.Default.MaxWindowWidth;
            Height = CoreSettings.Default.MaxWindowHeight;
            FormInit();
            LanguageInit();

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
                    Message.StartPosition = FormStartPosition.CenterScreen;
                    Message.ShowDialog();
                }
            }

            if (!ValidateCustomPath(ACTIVE_PATHS[_gameSelected]) && (UseStamps.Default.isAwareNPC == "NotRevealed" || UseStamps.Default.isAwareNPC == "WorkRevealed"))
            {
                using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_CUSTOMNOTFOUND, CoreSettings.Default.SelectedLang))
                {
                    Message.StartPosition = FormStartPosition.CenterScreen;
                    Message.ShowDialog();
                }
                RemoveClickEventsFromCustomPortraitsButtons();
                CheckBoxVerified.Checked = false;
                UseStamps.Default.isAwareNPC = "NotWorkRevealed";
                UseStamps.Default.Save();
                ButtonLoadCustom.Visible = false;
                ButtonLoadCustomNPC.Visible = false;
                ButtonLoadCustomArmy.Visible = false;
            }
            else if (ValidateCustomPath(ACTIVE_PATHS[_gameSelected]) && (UseStamps.Default.isAwareNPC == "NotRevealed" || UseStamps.Default.isAwareNPC == "NotWorkRevealed"))
            {
                using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_CUSTOMFOUND, CoreSettings.Default.SelectedLang))
                {
                    Message.StartPosition = FormStartPosition.CenterScreen;
                    Message.ShowDialog();
                }
                AddClickEventsToCustomPortraitsButtons();
                CheckBoxVerified.Checked = true;
                UseStamps.Default.isAwareNPC = "WorkRevealed";
                UseStamps.Default.Save();
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
        }
        private void LanguageInit()
        {
            if (Thread.CurrentThread.CurrentUICulture == CultureInfo.GetCultureInfo("ru-RU") ||
                Thread.CurrentThread.CurrentUICulture == CultureInfo.GetCultureInfo("de-DE"))
            {
                FontsInitNotEN();
            }
            else
            {
                _fontCollection = SystemControl.FileControl.InitCustomFont(Resources.BebasNeue_Regular);
                FontsInit(_fontCollection);
            }
            TextsInit();
            LabelLang.Text = TextVariables.LABEL_LANG + " " + Thread.CurrentThread.CurrentUICulture.ToString();
        }
        private void FormInit()
        {
            CenterToScreen();
            ParentLayoutsSetDockFill();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateColorScheme();

            PicPortraitTemp.AllowDrop = true;
            PicPortraitLrg.MouseWheel += PicPortraitLrg_MouseWheel;
            PicPortraitMed.MouseWheel += PicPortraitMed_MouseWheel;
            PicPortraitSml.MouseWheel += PicPortraitSml_MouseWheel;

            ParentLayoutsDisable();
            RootFunctions.LayoutDisable(LayoutURLDialog);
            RootFunctions.LayoutDisable(LayoutFinalPage);
            RootFunctions.LayoutEnable(LayoutMainPage);
            CheckBoxVerified.AutoCheck = false;
        }
        private void ButtonToFilePage_Click(object sender, EventArgs e)
        {
            RestoreFilePageToInit();
            CreateAllImagesInTemp("!DEFAULT!", 100);
            GenerateImageSelectionFlagString(100);
            LoadTempImagesToPicBox(100);
            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutFilePage);
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
        }
        private void ButtonToScalePage_Click(object sender, EventArgs e)
        {
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
                        ResizeVisibleImagesToWindowSize();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                ParentLayoutsDisable();
                LoadAllTempImagesToPicBox();
                RootFunctions.LayoutEnable(LayoutScalePage);
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
            RestoreFilePageToInit();
            _isAnyLoadedToPortraitPage = true;
            LoadTempImagesToPicBox(_imageSelectionFlag);
            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutFilePage);
            ResizeVisibleImagesToWindowSize();
        }
        private void ButtonToFilePage3_Click(object sender, EventArgs e)
        {
            ButtonToFilePage3.BackColor = Color.Black;
            ButtonToFilePage3.ForeColor = Color.White;
            RestoreFilePageToInit();
            RootFunctions.LayoutDisable(LayoutFinalPage);
            ReplacePictureBoxImagesToDefault();
            SystemControl.FileControl.CreateTempImages("!DEFAULT!", TEMP_APPENDS, GAME_TYPES[_gameSelected].PlaceholderImage);
            LoadTempImagesToPicBox(_imageSelectionFlag);
            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutFilePage);
            ResizeVisibleImagesToWindowSize();
            GenerateImageSelectionFlagString(100);
            ButtonToMainPageAndFolder.Enabled = true;
        }
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            DisposePrimeImages();
            ClearImageListsSync(ListGallery, ImgListGallery);
            ClearImageListsSync(ListExtract, ImgListExtract);
            SystemControl.FileControl.ClearTempImages();
            Application.Exit();
        }
        private void ButtonToExtract_Click(object sender, EventArgs e)
        {
            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutExtractPage);
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
            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutGallery);
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
        }
        private void ButtonToMainPage_Click(object sender, EventArgs e)
        {
            ReplacePictureBoxImagesToDefault();
            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutMainPage);
        }
        private void ButtonToMainPage2_Click(object sender, EventArgs e)
        {
            _extractFolderPath = "!NONE!";
            _cancellationTokenSource?.Cancel();
            ClearImageListsSync(ListExtract, ImgListExtract);
            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutMainPage);
        }
        private void ButtonToMainPage3_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource?.Cancel();
            ClearImageListsSync(ListGallery, ImgListGallery);
            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutMainPage);
        }
        private void ButtonToMainPage4_Click(object sender, EventArgs e)
        {
            ButtonToMainPage4.BackColor = Color.Black;
            ButtonToMainPage4.ForeColor = Color.White;
            RestoreFilePageToInit();
            ReplacePictureBoxImagesToDefault();
            ParentLayoutsDisable();
            RootFunctions.LayoutDisable(LayoutFinalPage);
            RootFunctions.LayoutEnable(LayoutMainPage);
        }
        private void ButtonToMainPage5_Click(object sender, EventArgs e)
        {
            RootFunctions.LayoutDisable(LayoutSettingsPage);
            RootFunctions.LayoutEnable(LayoutMainPage);
            CoreSettings.Default.MaxWindowHeight = Height;
            CoreSettings.Default.MaxWindowWidth = Width;
            CoreSettings.Default.Save();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            ButtonValidatePath.Text = TextVariables.BUTTON_VALIDATE;
            ButtonValidatePath.BackColor = Color.Black;
            ButtonValidatePath.ForeColor = Color.White;
            ButtonValidatePath.Enabled = true;
            CenterToScreen();
        }
        private void ButtonToSettingsPage_Click(object sender, EventArgs e)
        {
            RootFunctions.LayoutDisable(LayoutMainPage);
            RootFunctions.LayoutEnable(LayoutSettingsPage);
            TextBoxFullPath.Text = ACTIVE_PATHS[_gameSelected];
            ButtonToMainPage5.ForeColor = Color.White;
            ButtonToMainPage5.BackColor = Color.Black;
            FormBorderStyle = FormBorderStyle.Sizable;
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

    }
}
