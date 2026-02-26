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

        // Open modal dialog to enter image URL and load image from web
        private void ButtonKingSelectWebModal_Click(object sender, EventArgs e)
        {
            if (!(sender is System.Windows.Forms.Button btn)) return;

            using (forms.MyWebDialog dlg = new forms.MyWebDialog("Enter image URL", Thread.CurrentThread.CurrentUICulture.ToString()))
            {
                dlg.StartPosition = FormStartPosition.CenterParent;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    var img = dlg.DownloadedImage;
                    if (img == null) return;

                    string tag = btn.Tag as string;
                    if (tag == "PicKingLrg")
                    {
                        PicKingLrg.Image = img;
                        _originalImageLrg = (Image)img.Clone();
                        _zoomLevelLrg = 1.0f;
                        // resize to fit parent panel like placeholder (allow ResizeImageToParentControl to run)
                        _allowAutoResize = true;
                        ResizeImageToParentControl(PicKingLrg, _originalImageLrg, PanelKingLrg);
                        _allowAutoResize = false;
                        // reset location and scrolling
                        PanelKingLrg.AutoScroll = false;
                        PicKingLrg.Location = new Point(0, 0);
                    }
                    else if (tag == "PicKingMed")
                    {
                        PicKingMed.Image = img;
                        _originalImageMed = (Image)img.Clone();
                        _zoomLevelMed = 1.0f;
                        _allowAutoResize = true;
                        ResizeImageToParentControl(PicKingMed, _originalImageMed, PanelKingMed);
                        _allowAutoResize = false;
                        PanelKingMed.AutoScroll = false;
                        PicKingMed.Location = new Point(0, 0);
                    }
                    else if (tag == "PicKingSml")
                    {
                        PicKingSml.Image = img;
                        _originalImageSml = (Image)img.Clone();
                        _zoomLevelSml = 1.0f;
                        _allowAutoResize = true;
                        ResizeImageToParentControl(PicKingSml, _originalImageSml, PanelKingSml);
                        _allowAutoResize = false;
                        PanelKingSml.AutoScroll = false;
                        PicKingSml.Location = new Point(0, 0);
                    }
                }
            }
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
        // Control automatic resize calls (only when loading placeholders or new images)
        private bool _allowAutoResize = false;
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
            // ensure placeholders are prepared with custom cover-scaling so one dimension
            // matches the PictureBox and the other may be larger (center-cropped)
            _allowAutoResize = true;
            ReplacePictureBoxImagesToDefault();
            _allowAutoResize = false;



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

        private void LabelKingCreatePortrait_Paint(object sender, PaintEventArgs e)
        {
            var lbl = sender as Label;
            if (lbl == null) return;
            // Only draw border for the currently selected label
            bool isSelected = false;
            if (lbl.Name == "LabelKingCreatePortraitLarge") isSelected = _activeKingPortraitGroup == KingPortraitGroupSelection.Large;
            else if (lbl.Name == "LabelKingCreatePortraitMedium") isSelected = _activeKingPortraitGroup == KingPortraitGroupSelection.Medium;
            else if (lbl.Name == "LabelKingCreatePortraitSmall") isSelected = _activeKingPortraitGroup == KingPortraitGroupSelection.Small;
            if (!isSelected) return;

            Color penColor = Color.White;
            try { penColor = GameTypes[_gameSelected].ForeColor; } catch { penColor = lbl.ForeColor; }
            using (var pen = new Pen(penColor))
            {
                int w = lbl.ClientSize.Width;
                int h = lbl.ClientSize.Height;
                // draw top, left and right only
                e.Graphics.DrawLine(pen, 0, 0, w - 1, 0); // top
                e.Graphics.DrawLine(pen, 0, 0, 0, h - 1); // left
                e.Graphics.DrawLine(pen, w - 1, 0, w - 1, h - 1); // right
            }
        }

        private void DrawGroupBorder(Control group, PaintEventArgs e, Label label)
        {
            if (group == null) return;
            Color col = Color.White;
            try { col = GameTypes[_gameSelected].ForeColor; } catch { if (label != null) col = label.ForeColor; }
            using (var pen = new Pen(col))
            {
                int w = group.ClientSize.Width;
                int h = group.ClientSize.Height;
                // left, right, bottom
                e.Graphics.DrawLine(pen, 0, 0, 0, h - 1);
                e.Graphics.DrawLine(pen, w - 1, 0, w - 1, h - 1);
                e.Graphics.DrawLine(pen, 0, h - 1, w - 1, h - 1);

                // top with gap under label (exclude area under the label)
                int gapStart = -1, gapEnd = -1;
                if (label != null && label.Visible)
                {
                    try
                    {
                        var lblScreen = label.PointToScreen(Point.Empty);
                        var lblInGroup = group.PointToClient(lblScreen);
                        gapStart = lblInGroup.X;
                        gapEnd = lblInGroup.X + label.Width;
                    }
                    catch { gapStart = -1; gapEnd = -1; }
                }

                if (gapStart < 0 || gapEnd <= 0 || gapStart >= w || gapEnd <= 0)
                {
                    // draw full top
                    e.Graphics.DrawLine(pen, 0, 0, w - 1, 0);
                }
                else
                {
                    // draw left segment up to the left edge of the label
                    int leftSegEnd = Math.Max(0, gapStart - 1);
                    if (leftSegEnd > 0)
                        e.Graphics.DrawLine(pen, 0, 0, leftSegEnd, 0);

                    // draw right segment starting after the right edge of the label
                    int rightSegStart = Math.Min(w - 1, gapEnd + 1);
                    if (rightSegStart < w - 1)
                        e.Graphics.DrawLine(pen, rightSegStart, 0, w - 1, 0);
                }
            }
        }

        private void LayoutKingPortraitGroupLarge_Paint(object sender, PaintEventArgs e)
        {
            DrawGroupBorder(sender as Control, e, LabelKingCreatePortraitLarge);
        }

        private void LayoutKingPortraitGroupMedium_Paint(object sender, PaintEventArgs e)
        {
            DrawGroupBorder(sender as Control, e, LabelKingCreatePortraitMedium);
        }

        private void LayoutKingPortraitGroupSmall_Paint(object sender, PaintEventArgs e)
        {
            DrawGroupBorder(sender as Control, e, LabelKingCreatePortraitSmall);
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
            _allowAutoResize = true;
            ReplacePictureBoxImagesToDefault();
            _allowAutoResize = false;
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
            // Create portrait using existing create flow then return to Pathfinder main page
            try
            {
                // attempt to run create portrait flow
                ButtonCreatePortrait_Click(sender, e);
            }
            catch { }

            // Ensure UI returns to Pathfinder main page (not the generic start page)
            try
            {
                _activeMenuIndex = 201;
                ParentLayoutsDisable();
                RootFunctions.LayoutEnable(LayoutMainPage);
                Focus();
            }
            catch { }
        }

        private void ButtonKingBackToPathfinder_Click(object sender, EventArgs e)
        {
            // Explicit button to return user to Pathfinder main page
            try
            {
                _activeMenuIndex = 201;
                ParentLayoutsDisable();
                RootFunctions.LayoutEnable(LayoutMainPage);
                Focus();
            }
            catch { }
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
            // If no stored original exists, fall back to using the currently displayed image
            // and store a deep copy as the original so subsequent resizes stay high-quality.
            if (original == null && pb.Image != null)
            {
                try
                {
                    var copy = new Bitmap(pb.Image);
                    StoreOriginalImage(pb, copy);
                    original = copy;
                }
                catch
                {
                    return;
                }
            }
            if (original == null || pb.Image == null) return;

            // Determine current zoom: prefer tracked zoom level, but compute from displayed
            // image size when possible so cover-mode images (which may be larger than the
            // picturebox control) behave correctly.
            float currentZoom = GetZoomLevel(pb);
            try
            {
                if (pb.Image != null && original.Width > 0)
                {
                    currentZoom = (float)pb.Image.Width / original.Width;
                }
            }
            catch { }

            float zoomStep = 0.1f;
            float newZoom = wheelDelta > 0 ? currentZoom + zoomStep : currentZoom - zoomStep;

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
            // disable docking so we can reposition/resize the PictureBox freely
            pb.Dock = DockStyle.None;
            // update control size to reflect new image dimensions so ClampPictureLocation
            // and other logic that relies on PictureBox.Width/Height behave correctly
            pb.SizeMode = PictureBoxSizeMode.Normal;
            pb.Size = new Size(newW, newH);
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
            // disable docking so location/size updates take effect and dragging works
            pic.Dock = DockStyle.None;
            pic.SizeMode = PictureBoxSizeMode.Normal;
            pic.Size = new Size(newW, newH);
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

            if (!GameTypes.TryGetValue(_gameSelected, out var gameType))
            {
                // No valid game selected (e.g. sentinel '-'), skip styling updates.
                _activeKingPortraitGroup = selection;
                LayoutKingPortraitGroupLarge.Visible = selection == KingPortraitGroupSelection.Large;
                LayoutKingPortraitGroupMedium.Visible = selection == KingPortraitGroupSelection.Medium;
                LayoutKingPortraitGroupSmall.Visible = selection == KingPortraitGroupSelection.Small;
                return;
            }

            _activeKingPortraitGroup = selection;

            LayoutKingPortraitGroupLarge.Visible = selection == KingPortraitGroupSelection.Large;
            LayoutKingPortraitGroupMedium.Visible = selection == KingPortraitGroupSelection.Medium;
            LayoutKingPortraitGroupSmall.Visible = selection == KingPortraitGroupSelection.Small;

            LayoutKingPortraitGroupLarge.BackColor = selection == KingPortraitGroupSelection.Large ? gameType.BackColor : Color.Transparent;
            LayoutKingPortraitGroupMedium.BackColor = selection == KingPortraitGroupSelection.Medium ? gameType.BackColor : Color.Transparent;
            LayoutKingPortraitGroupSmall.BackColor = selection == KingPortraitGroupSelection.Small ? gameType.BackColor : Color.Transparent;

            Color selBack = gameType.BackColor;
            Color selFore = gameType.ForeColor;

            LabelKingCreatePortraitLarge.BackColor = selection == KingPortraitGroupSelection.Large ? selBack : Color.Transparent;
            LabelKingCreatePortraitLarge.ForeColor = selection == KingPortraitGroupSelection.Large ? selFore : Color.White;
            LabelKingCreatePortraitMedium.BackColor = selection == KingPortraitGroupSelection.Medium ? selBack : Color.Transparent;
            LabelKingCreatePortraitMedium.ForeColor = selection == KingPortraitGroupSelection.Medium ? selFore : Color.White;
            LabelKingCreatePortraitSmall.BackColor = selection == KingPortraitGroupSelection.Small ? selBack : Color.Transparent;
            LabelKingCreatePortraitSmall.ForeColor = selection == KingPortraitGroupSelection.Small ? selFore : Color.White;
            // force repaint to update borders
            LabelKingCreatePortraitLarge?.Invalidate();
            LabelKingCreatePortraitMedium?.Invalidate();
            LabelKingCreatePortraitSmall?.Invalidate();
            // Update portrait buttons styles to match selected game colors
            UpdatePortraitButtonsStyle();
            // Ensure large/medium layouts use small group as reference for size/row styles
            ApplySmallLayoutReference();
            // Reset displayed images into default cover state and fit-to-panel only
            // when automatic resize is explicitly allowed. This prevents group
            // changes (label clicks) from forcing a zoom-out. Callers that intend
            // to perform a reset (placeholder load, loading a new image) should
            // set `_allowAutoResize = true` before calling SetKingPortraitGroup
            // or calling the resize helpers directly.
            if (_allowAutoResize)
            {
                try
                {
                    ReplacePictureBoxImagesToDefault();
                    if (selection == KingPortraitGroupSelection.Medium)
                    {
                        FitPictureToPanel(PicKingMed, PanelKingMed);
                    }
                    else if (selection == KingPortraitGroupSelection.Small)
                    {
                        FitPictureToPanel(PicKingSml, PanelKingSml);
                    }
                    else
                    {
                        // also ensure large has consistent zoom state
                        FitPictureToPanel(PicKingLrg, PanelKingLrg);
                    }
                }
                catch { }
            }
        }

        private void FitPictureToPanel(PictureBox pb, Panel panel)
        {
            if (pb == null || panel == null || pb.Image == null) return;

            // Determine original image stored or use current image as fallback
            Image original = GetOriginalImage(pb);
            if (original == null)
            {
                try { original = new Bitmap(pb.Image); }
                catch { return; }
            }

            int panelW = panel.ClientSize.Width;
            int panelH = panel.ClientSize.Height;
            if (panelW <= 0 || panelH <= 0) return;

            float imgAspect = (float)original.Width / original.Height;
            float panelAspect = (float)panelW / panelH;
            float minZoom = imgAspect > panelAspect
                ? (float)panelH / original.Height
                : (float)panelW / original.Width;

            int newW = Math.Max(1, (int)(original.Width * minZoom));
            int newH = Math.Max(1, (int)(original.Height * minZoom));

            Bitmap fitted = ImageControl.Direct.Resize(original, newW, newH);
            // dispose previous displayed image if it is not the original reference
            try { if (pb.Image != null && !object.ReferenceEquals(pb.Image, original)) pb.Image.Dispose(); } catch { }
            pb.Image = fitted;
            pb.Dock = DockStyle.None;
            pb.SizeMode = PictureBoxSizeMode.Normal;
            pb.Size = new Size(newW, newH);
            SetZoomLevel(pb, minZoom);
            // center the picture inside the panel
            pb.Location = new Point((panelW - pb.Width) / 2, (panelH - pb.Height) / 2);
        }

        private void ApplySmallLayoutReference()
        {
            if (LayoutKingPortraitGroupSmall == null) return;
            try
            {
                // Copy overall size so other groups align to small group area
                var refSize = LayoutKingPortraitGroupSmall.Size;
                LayoutKingPortraitGroupLarge.Size = refSize;
                LayoutKingPortraitGroupMedium.Size = refSize;

                // Copy row styles (counts and heights)
                CopyRowStyles(LayoutKingPortraitGroupSmall, LayoutKingPortraitGroupLarge);
                CopyRowStyles(LayoutKingPortraitGroupSmall, LayoutKingPortraitGroupMedium);

                // Ensure button panels (which are table layout panels) have the same row styles
                CopyRowStyles(PanelKingSmlButtons, PanelKingLrgButtons);
                CopyRowStyles(PanelKingSmlButtons, PanelKingMedButtons);

                // Determine bottom row height in pixels if absolute
                int bottomHeight = 40; // fallback
                if (LayoutKingPortraitGroupSmall.RowCount > 0)
                {
                    var last = LayoutKingPortraitGroupSmall.RowStyles[LayoutKingPortraitGroupSmall.RowCount - 1];
                    if (last.SizeType == SizeType.Absolute)
                        bottomHeight = (int)Math.Max(1, last.Height);
                }

                // Apply bottom button heights and ensure consistent minimums
                var zoomButtons = new Button[] {
                    ButtonKingLrgZoomIn, ButtonKingLrgZoomOut,
                    ButtonKingMedZoomIn, ButtonKingMedZoomOut,
                    ButtonKingSmlZoomIn, ButtonKingSmlZoomOut
                };
                foreach (var zb in zoomButtons)
                {
                    if (zb == null) continue;
                    zb.MinimumSize = new Size(0, bottomHeight);
                    zb.Height = bottomHeight;
                    zb.Dock = DockStyle.Fill;
                }

                // Use existing FontsInit helper to prepare fonts with larger sizes, then apply small font to buttons
                try { FontsInit(_fontCollection, 0, 24, 18, 16); } catch { }
                Font btnFont = null;
                try { btnFont = new Font(_fontCollection.Families[0], 16f); } catch { btnFont = this.Font; }

                var allButtons = new Button[] {
                    ButtonKingLrgWeb, ButtonKingLrgLocal, ButtonKingLrgZoomIn, ButtonKingLrgZoomOut,
                    ButtonKingMedWeb, ButtonKingMedLocal, ButtonKingMedZoomIn, ButtonKingMedZoomOut,
                    ButtonKingSmlWeb, ButtonKingSmlLocal, ButtonKingSmlZoomIn, ButtonKingSmlZoomOut
                };
                foreach (var b in allButtons)
                {
                    if (b == null) continue;
                    try { b.Font = btnFont; } catch { }
                    b.Cursor = Cursors.Hand;
                }
            }
            catch { }
        }

        private void CopyRowStyles(TableLayoutPanel from, TableLayoutPanel to)
        {
            if (from == null || to == null) return;
            try
            {
                to.SuspendLayout();
                to.RowStyles.Clear();
                to.RowCount = from.RowCount;
                for (int i = 0; i < from.RowStyles.Count; i++)
                {
                    var rs = from.RowStyles[i];
                    var ns = new RowStyle(rs.SizeType, rs.Height);
                    to.RowStyles.Add(ns);
                }
            }
            catch { }
            finally { try { to.ResumeLayout(); } catch { } }
        }

        private void UpdatePortraitButtonsStyle()
        {
            Color selBack = Color.Black;
            Color selFore = Color.White;
            try { selBack = GameTypes[_gameSelected].BackColor; selFore = GameTypes[_gameSelected].ForeColor; } catch { }

            var buttons = new Button[] {
                ButtonKingLrgWeb, ButtonKingLrgLocal, ButtonKingLrgZoomIn, ButtonKingLrgZoomOut,
                ButtonKingMedWeb, ButtonKingMedLocal, ButtonKingMedZoomIn, ButtonKingMedZoomOut,
                ButtonKingSmlWeb, ButtonKingSmlLocal, ButtonKingSmlZoomIn, ButtonKingSmlZoomOut
            };

            foreach (var btn in buttons)
            {
                if (btn == null) continue;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = selFore;
                btn.BackColor = selBack;
                btn.ForeColor = selFore;
                // make hover change to swapped colors (keep border as fore)
                btn.FlatAppearance.MouseOverBackColor = selFore;
                btn.FlatAppearance.MouseDownBackColor = selFore;

                // set text from resources when possible
                try
                {
                    if (btn.Name != null && btn.Name.IndexOf("Web", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        var s = TextVariables.ResourceManager.GetString("BUTTON_SELECT_WEB", TextVariables.Culture);
                        if (!string.IsNullOrEmpty(s)) btn.Text = s;
                    }
                    else if (btn.Name != null && btn.Name.IndexOf("Local", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        var s = TextVariables.ResourceManager.GetString("BUTTON_SELECT_LOCAL", TextVariables.Culture);
                        if (!string.IsNullOrEmpty(s)) btn.Text = s;
                    }
                    // leave zoom button text as is ("+" / "−")
                }
                catch { }

                // detach then attach to avoid duplicate handlers
                btn.MouseEnter -= PortraitButton_MouseEnter;
                btn.MouseLeave -= PortraitButton_MouseLeave;
                btn.MouseEnter += PortraitButton_MouseEnter;
                btn.MouseLeave += PortraitButton_MouseLeave;
            }
        }

        private void PortraitButton_MouseEnter(object sender, EventArgs e)
        {
            if (!(sender is Button btn)) return;
            Color selBack = Color.Black;
            Color selFore = Color.White;
            try { selBack = GameTypes[_gameSelected].BackColor; selFore = GameTypes[_gameSelected].ForeColor; } catch { }

            // swap fore and back on hover, keep border as fore
            btn.BackColor = selFore;
            btn.ForeColor = selBack;
            btn.FlatAppearance.BorderColor = selFore;
        }

        private void PortraitButton_MouseLeave(object sender, EventArgs e)
        {
            if (!(sender is Button btn)) return;
            Color selBack = Color.Black;
            Color selFore = Color.White;
            try { selBack = GameTypes[_gameSelected].BackColor; selFore = GameTypes[_gameSelected].ForeColor; } catch { }

            // restore original colors
            btn.BackColor = selBack;
            btn.ForeColor = selFore;
            btn.FlatAppearance.BorderColor = selFore;
        }

        private void LabelKingCreatePortraitLarge_MouseEnter(object sender, EventArgs e)
        {
            LabelKingCreatePortraitLarge.ForeColor = GameTypes[_gameSelected].ForeColor;
        }

        private void LabelKingCreatePortraitLarge_MouseLeave(object sender, EventArgs e)
        {
            LabelKingCreatePortraitLarge.ForeColor = _activeKingPortraitGroup == KingPortraitGroupSelection.Large ? GameTypes[_gameSelected].ForeColor : Color.White;
        }

        private void LabelKingCreatePortraitMedium_MouseEnter(object sender, EventArgs e)
        {
            LabelKingCreatePortraitMedium.ForeColor = GameTypes[_gameSelected].ForeColor;
        }

        private void LabelKingCreatePortraitMedium_MouseLeave(object sender, EventArgs e)
        {
            LabelKingCreatePortraitMedium.ForeColor = _activeKingPortraitGroup == KingPortraitGroupSelection.Medium ? GameTypes[_gameSelected].ForeColor : Color.White;
        }

        private void LabelKingCreatePortraitSmall_MouseEnter(object sender, EventArgs e)
        {
            LabelKingCreatePortraitSmall.ForeColor = GameTypes[_gameSelected].ForeColor;
        }

        private void LabelKingCreatePortraitSmall_MouseLeave(object sender, EventArgs e)
        {
            LabelKingCreatePortraitSmall.ForeColor = _activeKingPortraitGroup == KingPortraitGroupSelection.Small ? GameTypes[_gameSelected].ForeColor : Color.White;
        }
    }
}
