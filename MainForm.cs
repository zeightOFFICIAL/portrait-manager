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
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using SystemControl;

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
            Small,
            Sml2
        }

        private void ButtonKingSelectWebModal_Click(object sender, EventArgs e)
        {
            if (!(sender is System.Windows.Forms.Button btn)) return;

            using (forms.MyWebDialog dlg = new forms.MyWebDialog())
            {
                dlg.StartPosition = FormStartPosition.CenterParent;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    var img = dlg.DownloadedImage;
                    if (img == null) return;

                    string tag = btn.Tag as string;
                    if (tag == "PicKingLrg")
                    {
                        StoreOriginalImage(PicKingLrg, new Bitmap(img));
                        FitImageToPanel(PicKingLrg);
                        _kingGroupLrgInitialized = true;
                    }
                    else if (tag == "PicKingMed")
                    {
                        StoreOriginalImage(PicKingMed, new Bitmap(img));
                        FitImageToPanel(PicKingMed);
                        _kingGroupMedInitialized = true;
                    }
                    else if (tag == "PicKingSml")
                    {
                        StoreOriginalImage(PicKingSml, new Bitmap(img));
                        FitImageToPanel(PicKingSml);
                        _kingGroupSmlInitialized = true;
                    }
                    else if (tag == "PicKingSml2")
                    {
                        StoreOriginalImage(PicKingSml2, new Bitmap(img));
                        FitImageToPanel(PicKingSml2);
                        _kingGroupSml2Initialized = true;
                    }
                    img.Dispose();
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

        private static Image _originalImageLrg;
        private static Image _originalImageMed;
        private static Image _originalImageSml;
        private static Image _originalImageSml2;
        private bool _allowAutoResize = false;
        private static float _zoomLevelLrg = 1.0f;
        private static float _zoomLevelMed = 1.0f;
        private static float _zoomLevelSml = 1.0f;
        private static float _zoomLevelSml2 = 1.0f;
        private bool _kingGroupLrgInitialized;
        private bool _kingGroupMedInitialized;
        private bool _kingGroupSmlInitialized;
        private bool _kingGroupSml2Initialized;

        private static PrivateFontCollection _fontCollection;
        private static CancellationTokenSource _cancellationTokenSource;

        private string _selectedArchivePath;
        private List<Tuple<string, Image>> _archiveEntries;
        private bool _overlayHovered;
        private string _shellTempDir;
        private List<Tuple<string, Image>> _galleryEntries;
        private string _selectedGalleryEntry;
        private string _overrideGallerySaveDir;

        private void FontInit()
        {
            _fontCollection = FileControl.InitCustomFont(Resources.BebasNeue_Regular);

            Font bebasNeueMainPage = new Font(_fontCollection.Families[0], 44),
                 bebasNeueMainPage2 = new Font(_fontCollection.Families[0], 30),
                 bebasNeueFullHeader = new Font(_fontCollection.Families[0], 25),
                 bebasNeue22 = new Font(_fontCollection.Families[0], 22),
                 bebasNeueHead = new Font(_fontCollection.Families[0], 21),
                 bebasNeueUnder = new Font(_fontCollection.Families[0], 17),
                 bebasNeueButton16 = new Font(_fontCollection.Families[0], 16f),
                 bebasNeueZoom = new Font(_fontCollection.Families[0], 14.85f),
                 bebasNeueMedium = new Font(_fontCollection.Families[0], 13),
                 bebasNeue12 = new Font(_fontCollection.Families[0], 12),
                 bebasNeue10 = new Font(_fontCollection.Families[0], 10f),
                 bebasNeueSmall = new Font(_fontCollection.Families[0], 9);

            ButtonStartKing.Font = bebasNeueMedium;
            ButtonStartWotr.Font = bebasNeueMedium;
            ButtonStartRt.Font = bebasNeueMedium;
            ButtonStartPoe.Font = bebasNeueMedium;
            ButtonStartPoed.Font = bebasNeueMedium;
            ButtonStartTyr.Font = bebasNeueMedium;
            ButtonStartW3.Font = bebasNeueMedium;
            LabelSelectPathTitle.Font = bebasNeueFullHeader;
            LabelSelectPathChoosePath.Font = bebasNeueUnder;
            LabelSelectPathResetPath.Font = bebasNeueUnder;
            LabelCreatePortrait.Font = bebasNeueMainPage;
            LabelExtract.Font = bebasNeueMainPage2;
            LabelBrowse.Font = bebasNeueMainPage2;
            LabelSettingsPage.Font = bebasNeueMainPage2;
            LabelExit.Font = bebasNeueMainPage2;
            LabelKingCreatePortraitLarge.Font = bebasNeueHead;
            LabelKingCreatePortraitMedium.Font = bebasNeueHead;
            LabelKingCreatePortraitSmall.Font = bebasNeueHead;
            LabelKingCreatePortraitSml2.Font = bebasNeueHead;
            ButtonKingCreateNewPortrait.Font = bebasNeueHead;
            ButtonKingBackToPathfinder.Font = bebasNeueHead;
            ButtonExtractAll.Font = bebasNeueHead;
            ButtonExtractSelected.Font = bebasNeueHead;
            ButtonExtractBack.Font = bebasNeueHead;
            ButtonExtractShowFolder.Font = bebasNeueHead;
            LabelGalleryTab.Font = bebasNeueHead;
            ButtonGalleryBack.Font = bebasNeueHead;
            ButtonGalleryClone.Font = bebasNeueHead;
            ButtonGalleryChange.Font = bebasNeueHead;
            ButtonGalleryDelete.Font = bebasNeueHead;

            Font btnFont16 = bebasNeueButton16;
            Font btnFontZoom = bebasNeueZoom;

            var allPortraitButtons = new Button[] {
                ButtonKingLrgWeb, ButtonKingLrgLocal, ButtonKingLrgZoomIn, ButtonKingLrgZoomOut, ButtonKingLrgZoomReset,
                ButtonKingMedWeb, ButtonKingMedLocal, ButtonKingMedZoomIn, ButtonKingMedZoomOut, ButtonKingMedZoomReset,
                ButtonKingSmlWeb, ButtonKingSmlLocal, ButtonKingSmlZoomIn, ButtonKingSmlZoomOut, ButtonKingSmlZoomReset,
                ButtonKingSml2Web, ButtonKingSml2Local, ButtonKingSml2ZoomIn, ButtonKingSml2ZoomOut, ButtonKingSml2ZoomReset
            };
            foreach (var b in allPortraitButtons)
            {
                if (b == null) continue;
                b.Font = btnFont16;
            }

            var zoomButtons = new Button[] {
                ButtonKingLrgZoomIn, ButtonKingLrgZoomOut, ButtonKingLrgZoomReset,
                ButtonKingMedZoomIn, ButtonKingMedZoomOut, ButtonKingMedZoomReset,
                ButtonKingSmlZoomIn, ButtonKingSmlZoomOut, ButtonKingSmlZoomReset,
                ButtonKingSml2ZoomIn, ButtonKingSml2ZoomOut, ButtonKingSml2ZoomReset
            };
            foreach (var zb in zoomButtons)
            {
                if (zb == null) continue;
                zb.Font = btnFontZoom;
            }

            Font hintFont = bebasNeue10;
            var hintLabels = new Label[] {
                LabelKingLrgHint, LabelKingMedHint, LabelKingSmlHint, LabelKingSml2Hint
            };
            foreach (var lbl in hintLabels)
            {
                if (lbl == null) continue;
                lbl.Font = hintFont;
            }
        }

        private void TextInit()
        {
            Text = TextVariables.MAIN_MENU_TITLE;
            ButtonStartKing.Text = TextVariables.NAME_KING;
            ButtonStartWotr.Text = TextVariables.NAME_WOTR;
            ButtonStartRt.Text = TextVariables.NAME_ROGUE;
            ButtonStartPoe.Text = TextVariables.NAME_PILLARS;
            ButtonStartPoed.Text = TextVariables.NAME_DEADFIRE;
            ButtonStartTyr.Text = TextVariables.NAME_TYR;
            ButtonStartW3.Text = TextVariables.NAME_WASTE;
            LabelStartAuthor.Text = TextVariables.MAIN_MENU_AUTHOR;
            LabelSelectPathTitle.Text = TextVariables.NAME_KING;
            LabelSelectPathChoosePath.Text = TextVariables.BUTTON_CHOOSE;
            LabelSelectPathResetPath.Text = TextVariables.BUTTON_RESET;
            LabelCreatePortrait.Text = TextVariables.BUTTON_CREATE;
            LabelExtract.Text = TextVariables.BUTTON_EXTRACT;
            LabelBrowse.Text = TextVariables.BUTTON_BROWSE;
            LabelSettingsPage.Text = TextVariables.BUTTON_SETTINGS;
            LabelExit.Text = TextVariables.BUTTON_EXIT;

            if (_gameSelected == 'd')
            {
                LabelKingCreatePortraitLarge.Text = "⍞ Full";
                LabelKingCreatePortraitMedium.Text = "⌻ Full²";
                LabelKingCreatePortraitSmall.Text = "⌼ Sml";
                LabelKingCreatePortraitSml2.Text = "⌼ Sml²";
            }
            else
            {
                LabelKingCreatePortraitLarge.Text = TextVariables.BUTTON_KINGCREATEPAGELRG;
                LabelKingCreatePortraitMedium.Text = TextVariables.BUTTON_KINGCREATEPAGEMID;
                LabelKingCreatePortraitSmall.Text = TextVariables.BUTTON_KINGCREATEPAGESML;
                LabelKingCreatePortraitSml2.Text = TextVariables.BUTTON_KINGCREATEPAGESML2;
            }

            ButtonKingCreateNewPortrait.Text = "Create >";
            ButtonKingBackToPathfinder.Text = "< Back";
            ButtonExtractAll.Text = TextVariables.BUTTON_EXTRACT_ALL;
            ButtonExtractSelected.Text = TextVariables.BUTTON_EXTRACT_SELECTED;
            ButtonExtractBack.Text = TextVariables.BUTTON_EXTRACT_BACK;
            ButtonExtractShowFolder.Text = TextVariables.BUTTON_EXTRACT_OPENFOLDER;
            LabelGalleryTab.Text = TextVariables.BUTTON_GALLERY;
            ButtonGalleryBack.Text = TextVariables.BUTTON_GALLERY_BACK;
            ButtonGalleryClone.Text = TextVariables.BUTTON_GALLERY_CLONE;
            ButtonGalleryChange.Text = TextVariables.BUTTON_GALLERY_CHANGE;
            ButtonGalleryDelete.Text = TextVariables.BUTTON_GALLERY_DELETE;

            LabelSelectPathExplain.Text = TextVariables.TEXT_EXPLAIN_PATH_KING;

            var webLocalButtons = new Button[] {
                ButtonKingLrgWeb, ButtonKingLrgLocal,
                ButtonKingMedWeb, ButtonKingMedLocal,
                ButtonKingSmlWeb, ButtonKingSmlLocal,
                ButtonKingSml2Web, ButtonKingSml2Local
            };
            foreach (var btn in webLocalButtons)
            {
                if (btn == null) continue;
                if (btn.Name != null && btn.Name.IndexOf("Web", StringComparison.OrdinalIgnoreCase) >= 0)
                    btn.Text = TextVariables.BUTTON_SELECT_WEB;
                else if (btn.Name != null && btn.Name.IndexOf("Local", StringComparison.OrdinalIgnoreCase) >= 0)
                    btn.Text = TextVariables.BUTTON_SELECT_LOCAL;
            }

            var zoomInButtons = new Button[] { ButtonKingLrgZoomIn, ButtonKingMedZoomIn, ButtonKingSmlZoomIn, ButtonKingSml2ZoomIn };
            foreach (var zb in zoomInButtons)
            {
                if (zb == null) continue;
                zb.Text = "\U0001F50D+";
            }
            var zoomOutButtons = new Button[] { ButtonKingLrgZoomOut, ButtonKingMedZoomOut, ButtonKingSmlZoomOut, ButtonKingSml2ZoomOut };
            foreach (var zb in zoomOutButtons)
            {
                if (zb == null) continue;
                zb.Text = "\U0001F50D\u2212";
            }
            var zoomResetButtons = new Button[] { ButtonKingLrgZoomReset, ButtonKingMedZoomReset, ButtonKingSmlZoomReset, ButtonKingSml2ZoomReset };
            foreach (var zb in zoomResetButtons)
            {
                if (zb == null) continue;
                zb.Text = "\u21ba";
            }
        }

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
            FontInit();
            TextInit();
            _activeMenuIndex = 65535;
            SetClientSizeCore(750, 520);
            CenterToScreen();
            ParentLayoutsSetDockFill();
            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutStartMenu);
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
            _allowAutoResize = true;
            ReplacePictureBoxImagesToDefault();
            _allowAutoResize = false;

            Focus();
            ApplyGameWindowStyle();
        }

        private void LabelKingCreatePortrait_Paint(object sender, PaintEventArgs e)
        {
            var lbl = sender as Label;
            if (lbl == null) return;
            bool isSelected = false;
            if (lbl.Name == "LabelKingCreatePortraitLarge") isSelected = _activeKingPortraitGroup == KingPortraitGroupSelection.Large;
            else if (lbl.Name == "LabelKingCreatePortraitMedium") isSelected = _activeKingPortraitGroup == KingPortraitGroupSelection.Medium;
            else if (lbl.Name == "LabelKingCreatePortraitSmall") isSelected = _activeKingPortraitGroup == KingPortraitGroupSelection.Small;
            else if (lbl.Name == "LabelKingCreatePortraitSml2") isSelected = _activeKingPortraitGroup == KingPortraitGroupSelection.Sml2;
            if (!isSelected) return;

            Color penColor = Color.White;
            try { penColor = GameTypes[_gameSelected].ForeColor; } catch { penColor = lbl.ForeColor; }
            using (var pen = new Pen(penColor))
            {
                int w = lbl.ClientSize.Width;
                int h = lbl.ClientSize.Height;
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
                e.Graphics.DrawLine(pen, 0, 0, 0, h - 1);
                e.Graphics.DrawLine(pen, w - 1, 0, w - 1, h - 1);
                e.Graphics.DrawLine(pen, 0, h - 1, w - 1, h - 1);

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
                    e.Graphics.DrawLine(pen, 0, 0, w - 1, 0);
                }
                else
                {
                    int leftSegEnd = Math.Max(0, gapStart - 1);
                    if (leftSegEnd > 0)
                        e.Graphics.DrawLine(pen, 0, 0, leftSegEnd, 0);

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

        private void LayoutKingPortraitGroupSml2_Paint(object sender, PaintEventArgs e)
        {
            DrawGroupBorder(sender as Control, e, LabelKingCreatePortraitSml2);
        }

        private void LayoutKingRight_Paint(object sender, PaintEventArgs e)
        {
            DrawGroupBorder(sender as Control, e, null);
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
        
        private void LabelExtract_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 5;

            Color gameBack, gameFore;
            try { gameBack = GameTypes[_gameSelected].BackColor; gameFore = GameTypes[_gameSelected].ForeColor; }
            catch { gameBack = Color.FromArgb(12, 12, 12); gameFore = Color.White; }

            PanelExtractContainer.BackColor = gameBack;
            PanelExtractOverlay.BackColor = gameBack;
            LayoutExtractRight.BackColor = gameBack;
            LayoutExtractRight.ForeColor = gameFore;
            _overlayHovered = false;

            foreach (var btn in new[] { ButtonExtractAll, ButtonExtractSelected, ButtonExtractShowFolder, ButtonExtractBack })
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = gameFore;
                btn.BackColor = gameBack;
                btn.ForeColor = gameFore;
                btn.FlatAppearance.MouseOverBackColor = gameFore;
                btn.FlatAppearance.MouseDownBackColor = gameFore;
                btn.TabStop = false;
            }

            ButtonExtractAll.Visible = false;
            ButtonExtractSelected.Visible = false;
            ButtonExtractShowFolder.Visible = true;
            ButtonExtractShowFolder.Text = TextVariables.BUTTON_EXTRACT_OPENFOLDER;
            ButtonExtractBack.Visible = true;
            LayoutExtractRight.RowStyles[0].Height = 0;
            LayoutExtractRight.RowStyles[1].Height = 0;
            LayoutExtractRight.RowStyles[2].Height = 50;
            LayoutExtractRight.RowStyles[3].Height = 50;

            _selectedArchivePath = null;
            ClearArchiveEntries();
            CleanupShellTempDir();
            FlowLayoutPanelExtract.Visible = false;
            PanelExtractOverlay.Visible = true;
            FlowLayoutPanelExtractBottom.Visible = false;

            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutExtractPage);
            Focus();
        }

        private void LabelBrowse_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 6;
            _selectedGalleryEntry = null;

            Color gameBack, gameFore;
            try { gameBack = GameTypes[_gameSelected].BackColor; gameFore = GameTypes[_gameSelected].ForeColor; }
            catch { gameBack = Color.FromArgb(12, 12, 12); gameFore = Color.White; }

            LabelGalleryTab.BackColor = gameBack;
            LabelGalleryTab.ForeColor = gameFore;
            PanelGalleryContainer.BackColor = gameBack;
            FlowLayoutPanelGallery.BackColor = gameBack;

            ButtonGalleryBack.FlatStyle = FlatStyle.Flat;
            ButtonGalleryBack.FlatAppearance.BorderSize = 1;
            ButtonGalleryBack.FlatAppearance.BorderColor = gameFore;
            ButtonGalleryBack.BackColor = gameBack;
            ButtonGalleryBack.ForeColor = gameFore;
            ButtonGalleryBack.FlatAppearance.MouseOverBackColor = gameFore;
            ButtonGalleryBack.FlatAppearance.MouseDownBackColor = gameFore;
            ButtonGalleryBack.TabStop = false;

            ButtonGalleryClone.FlatStyle = FlatStyle.Flat;
            ButtonGalleryClone.FlatAppearance.BorderSize = 1;
            ButtonGalleryClone.FlatAppearance.BorderColor = gameFore;
            ButtonGalleryClone.BackColor = gameBack;
            ButtonGalleryClone.ForeColor = gameFore;
            ButtonGalleryClone.FlatAppearance.MouseOverBackColor = gameFore;
            ButtonGalleryClone.FlatAppearance.MouseDownBackColor = gameFore;
            ButtonGalleryClone.TabStop = false;

            ButtonGalleryChange.FlatStyle = FlatStyle.Flat;
            ButtonGalleryChange.FlatAppearance.BorderSize = 1;
            ButtonGalleryChange.FlatAppearance.BorderColor = gameFore;
            ButtonGalleryChange.BackColor = gameBack;
            ButtonGalleryChange.ForeColor = gameFore;
            ButtonGalleryChange.FlatAppearance.MouseOverBackColor = gameFore;
            ButtonGalleryChange.FlatAppearance.MouseDownBackColor = gameFore;
            ButtonGalleryChange.TabStop = false;

            ButtonGalleryDelete.FlatStyle = FlatStyle.Flat;
            ButtonGalleryDelete.FlatAppearance.BorderSize = 1;
            ButtonGalleryDelete.FlatAppearance.BorderColor = gameFore;
            ButtonGalleryDelete.BackColor = gameBack;
            ButtonGalleryDelete.ForeColor = gameFore;
            ButtonGalleryDelete.FlatAppearance.MouseOverBackColor = gameFore;
            ButtonGalleryDelete.FlatAppearance.MouseDownBackColor = gameFore;
            ButtonGalleryDelete.TabStop = false;

            ClearGalleryEntries();
            LoadGalleryImages();
            UpdateGalleryRightPanel();

            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutGalleryPage);
            Focus();
        }

        private void LoadGalleryImageIntoCreatePage(string folderPath)
        {
            if (_gameSelected == 'd')
            {
                LoadDeadfireGalleryIntoCreatePage(folderPath);
                return;
            }

            string bestFile = FindBestGalleryImage(folderPath);
            if (bestFile == null) return;

            try
            {
                using (Image fileImg = Image.FromFile(bestFile))
                {
                    Bitmap copy = ImageControl.Direct.Resize(fileImg, fileImg.Width, fileImg.Height);

                    StoreOriginalImage(PicKingLrg, new Bitmap(copy));
                    FitImageToPanel(PicKingLrg);
                    MarkGroupInitialized(PicKingLrg);

                    if (GameTypes.TryGetValue(_gameSelected, out var gt) &&
                        HasPortraitSpecific(gt, "MEDIUM_WIDTH") &&
                        HasPortraitSpecific(gt, "MEDIUM_HEIGHT"))
                    {
                        StoreOriginalImage(PicKingMed, new Bitmap(copy));
                        FitImageToPanel(PicKingMed);
                        MarkGroupInitialized(PicKingMed);
                    }

                    StoreOriginalImage(PicKingSml, new Bitmap(copy));
                    FitImageToPanel(PicKingSml);
                    MarkGroupInitialized(PicKingSml);

                    StoreOriginalImage(PicKingSml2, new Bitmap(copy));
                    FitImageToPanel(PicKingSml2);
                    MarkGroupInitialized(PicKingSml2);

                    copy.Dispose();
                }
            }
            catch { }
        }

        private void LoadDeadfireGalleryIntoCreatePage(string folderPath)
        {
            string dir = Path.GetDirectoryName(folderPath);
            string prefix = Path.GetFileName(folderPath);

            try
            {
                string convoPath = Path.Combine(dir, prefix + "_convo.png");
                if (File.Exists(convoPath))
                {
                    using (Image convoImg = Image.FromFile(convoPath))
                    {
                        Bitmap convoCopy = ImageControl.Direct.Resize(convoImg, convoImg.Width, convoImg.Height);
                        StoreOriginalImage(PicKingMed, convoCopy);
                        FitImageToPanel(PicKingMed);
                        MarkGroupInitialized(PicKingMed);
                    }
                }

                string lgPath = Path.Combine(dir, prefix + "_lg.png");
                string bestFile = File.Exists(lgPath) ? lgPath : FindBestGalleryImage(folderPath);
                if (bestFile == null || !File.Exists(bestFile)) return;

                using (Image lgImg = Image.FromFile(bestFile))
                {
                    Bitmap lgCopy = ImageControl.Direct.Resize(lgImg, lgImg.Width, lgImg.Height);

                    StoreOriginalImage(PicKingLrg, new Bitmap(lgCopy));
                    FitImageToPanel(PicKingLrg);
                    MarkGroupInitialized(PicKingLrg);

                    StoreOriginalImage(PicKingSml, new Bitmap(lgCopy));
                    FitImageToPanel(PicKingSml);
                    MarkGroupInitialized(PicKingSml);

                    StoreOriginalImage(PicKingSml2, new Bitmap(lgCopy));
                    FitImageToPanel(PicKingSml2);
                    MarkGroupInitialized(PicKingSml2);

                    lgCopy.Dispose();
                }
            }
            catch { }
        }

        private void ButtonGalleryClone_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedGalleryEntry)) return;
            _overrideGallerySaveDir = null;
            LabelCreatePortrait_Click(sender, e);
            LoadGalleryImageIntoCreatePage(_selectedGalleryEntry);
        }

        private void ButtonGalleryChange_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedGalleryEntry)) return;
            _overrideGallerySaveDir = _selectedGalleryEntry;
            LabelCreatePortrait_Click(sender, e);
            LoadGalleryImageIntoCreatePage(_selectedGalleryEntry);
        }

        private void ButtonGalleryBack_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = GetMainMenuIndexForCurrentGame();

            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutMainPage);
            Focus();
        }

        private void LabelGalleryTab_Paint(object sender, PaintEventArgs e)
        {
            Color penColor = Color.White;
            try { penColor = GameTypes[_gameSelected].ForeColor; } catch { }
            using (var pen = new Pen(penColor))
            {
                int w = LabelGalleryTab.ClientSize.Width;
                int h = LabelGalleryTab.ClientSize.Height;
                e.Graphics.DrawLine(pen, 0, 0, w - 1, 0);
                e.Graphics.DrawLine(pen, 0, 0, 0, h - 1);
                e.Graphics.DrawLine(pen, w - 1, 0, w - 1, h - 1);
            }
        }

        private void LabelGalleryTab_MouseEnter(object sender, EventArgs e)
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gt)) return;
            LabelGalleryTab.ForeColor = gt.ForeColor;
        }

        private void LabelGalleryTab_MouseLeave(object sender, EventArgs e)
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gt)) return;
            LabelGalleryTab.ForeColor = gt.ForeColor;
        }

        private void PanelGalleryContainer_Paint(object sender, PaintEventArgs e)
        {
            Color col = Color.White;
            try { col = GameTypes[_gameSelected].ForeColor; } catch { }
            Panel group = (Panel)sender;
            using (var pen = new Pen(col))
            {
                int w = group.ClientSize.Width;
                int h = group.ClientSize.Height;
                e.Graphics.DrawLine(pen, 0, 0, 0, h - 1);
                e.Graphics.DrawLine(pen, w - 1, 0, w - 1, h - 1);
                e.Graphics.DrawLine(pen, 0, h - 1, w - 1, h - 1);

                int gapStart = -1, gapEnd = -1;
                if (LabelGalleryTab.Visible)
                {
                    try
                    {
                        var lblScreen = LabelGalleryTab.PointToScreen(Point.Empty);
                        var lblInGroup = group.PointToClient(lblScreen);
                        gapStart = lblInGroup.X;
                        gapEnd = lblInGroup.X + LabelGalleryTab.Width;
                    }
                    catch { }
                }

                if (gapStart < 0 || gapEnd <= 0 || gapStart >= w || gapEnd <= 0)
                {
                    e.Graphics.DrawLine(pen, 0, 0, w - 1, 0);
                }
                else
                {
                    int leftSegEnd = Math.Max(0, gapStart - 1);
                    if (leftSegEnd > 0)
                        e.Graphics.DrawLine(pen, 0, 0, leftSegEnd, 0);

                    int rightSegStart = Math.Min(w - 1, gapEnd + 1);
                    if (rightSegStart < w - 1)
                        e.Graphics.DrawLine(pen, rightSegStart, 0, w - 1, 0);
                }
            }
        }

        private void LayoutGalleryRight_Paint(object sender, PaintEventArgs e)
        {
            Color foreColor;
            try { foreColor = GameTypes[_gameSelected].ForeColor; } catch { foreColor = Color.FromArgb(60, 60, 60); }
            ControlPaint.DrawBorder(e.Graphics, ((TableLayoutPanel)sender).ClientRectangle,
                foreColor, ButtonBorderStyle.Solid);
        }

        private void UpdateGalleryRightPanel()
        {
            if (string.IsNullOrEmpty(_selectedGalleryEntry))
            {
                ButtonGalleryDelete.Visible = false;
                ButtonGalleryClone.Visible = false;
                ButtonGalleryChange.Visible = false;
                ButtonGalleryBack.Visible = true;
                LayoutGalleryRight.RowStyles[0].Height = 0;
                LayoutGalleryRight.RowStyles[1].Height = 0;
                LayoutGalleryRight.RowStyles[2].Height = 0;
                LayoutGalleryRight.RowStyles[3].Height = 100;
            }
            else
            {
                ButtonGalleryDelete.Visible = true;
                ButtonGalleryClone.Visible = true;
                ButtonGalleryChange.Visible = true;
                ButtonGalleryBack.Visible = true;
                LayoutGalleryRight.RowStyles[0].Height = 25;
                LayoutGalleryRight.RowStyles[1].Height = 25;
                LayoutGalleryRight.RowStyles[2].Height = 25;
                LayoutGalleryRight.RowStyles[3].Height = 25;
            }
        }

        private void ButtonGalleryBack_MouseEnter(object sender, EventArgs e)
        {
            Color selBack = Color.Black, selFore = Color.White;
            try { selBack = GameTypes[_gameSelected].BackColor; selFore = GameTypes[_gameSelected].ForeColor; } catch { }
            ButtonGalleryBack.BackColor = selFore;
            ButtonGalleryBack.ForeColor = selBack;
        }

        private void ButtonGalleryBack_MouseLeave(object sender, EventArgs e)
        {
            Color selBack = Color.Black, selFore = Color.White;
            try { selBack = GameTypes[_gameSelected].BackColor; selFore = GameTypes[_gameSelected].ForeColor; } catch { }
            ButtonGalleryBack.BackColor = selBack;
            ButtonGalleryBack.ForeColor = selFore;
        }

        private void ButtonGalleryClone_MouseEnter(object sender, EventArgs e)
        {
            Color selBack = Color.Black, selFore = Color.White;
            try { selBack = GameTypes[_gameSelected].BackColor; selFore = GameTypes[_gameSelected].ForeColor; } catch { }
            ButtonGalleryClone.BackColor = selFore;
            ButtonGalleryClone.ForeColor = selBack;
        }

        private void ButtonGalleryClone_MouseLeave(object sender, EventArgs e)
        {
            Color selBack = Color.Black, selFore = Color.White;
            try { selBack = GameTypes[_gameSelected].BackColor; selFore = GameTypes[_gameSelected].ForeColor; } catch { }
            ButtonGalleryClone.BackColor = selBack;
            ButtonGalleryClone.ForeColor = selFore;
        }

        private void ButtonGalleryChange_MouseEnter(object sender, EventArgs e)
        {
            Color selBack = Color.Black, selFore = Color.White;
            try { selBack = GameTypes[_gameSelected].BackColor; selFore = GameTypes[_gameSelected].ForeColor; } catch { }
            ButtonGalleryChange.BackColor = selFore;
            ButtonGalleryChange.ForeColor = selBack;
        }

        private void ButtonGalleryChange_MouseLeave(object sender, EventArgs e)
        {
            Color selBack = Color.Black, selFore = Color.White;
            try { selBack = GameTypes[_gameSelected].BackColor; selFore = GameTypes[_gameSelected].ForeColor; } catch { }
            ButtonGalleryChange.BackColor = selBack;
            ButtonGalleryChange.ForeColor = selFore;
        }

        private void ButtonGalleryDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedGalleryEntry)) return;
            using (var dlg = new forms.MyInquiryDialog("Delete this portrait set?"))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    DeleteGalleryPortraitSet(_selectedGalleryEntry);
                    _selectedGalleryEntry = null;
                    UpdateGalleryRightPanel();
                    LoadGalleryImages();
                }
            }
        }

        private void ButtonGalleryDelete_MouseEnter(object sender, EventArgs e)
        {
            Color selBack = Color.Black, selFore = Color.White;
            try { selBack = GameTypes[_gameSelected].BackColor; selFore = GameTypes[_gameSelected].ForeColor; } catch { }
            ButtonGalleryDelete.BackColor = selFore;
            ButtonGalleryDelete.ForeColor = selBack;
        }

        private void ButtonGalleryDelete_MouseLeave(object sender, EventArgs e)
        {
            Color selBack = Color.Black, selFore = Color.White;
            try { selBack = GameTypes[_gameSelected].BackColor; selFore = GameTypes[_gameSelected].ForeColor; } catch { }
            ButtonGalleryDelete.BackColor = selBack;
            ButtonGalleryDelete.ForeColor = selFore;
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
            if (string.IsNullOrEmpty(selectedPath) || selectedPath == "-" || selectedPath == " - ")
            {
                return;
            }
            if (_gameSelected == 'k')
            {
                try
                {
                    if (!Directory.Exists(selectedPath) || string.IsNullOrWhiteSpace(selectedPath))
                    {
                        MessageBox.Show("Could not locate the expected game data folder. Please make sure you select the root game installation directory.");
                        return;
                    }

                    selectedPath = selectedPath.Replace('/', '\\');

                    var dir = new DirectoryInfo(selectedPath);
                    while (dir != null &&
                            !dir.Name.Equals("Pathfinder Kingmaker", StringComparison.OrdinalIgnoreCase))
                        dir = dir.Parent;

                    if (dir == null)
                    {
                        MessageBox.Show("Could not locate the expected game data folder. Please make sure you select the root game installation directory.");
                        return;
                    }

                    string rootPath = dir.FullName + Path.DirectorySeparatorChar;
                    string portraitsDir = Path.Combine(rootPath, "Portraits");
                    if (!Directory.Exists(portraitsDir))
                        Directory.CreateDirectory(portraitsDir);

                    CoreSettings.Default.GamePath = "0";
                    CoreSettings.Default.GameType = '-';
                    CoreSettings.Default.Save();
                    LabelSelectPathSelected.Text = rootPath;
                    CoreSettings.Default.GamePath = rootPath;
                    CoreSettings.Default.GameType = 'k';
                    CoreSettings.Default.Save();
                    LayoutMainPage.BackgroundImage = Resources.path_menu_page;
                    _activeMenuIndex = 201;
                    ParentLayoutsDisable();
                    RootFunctions.LayoutEnable(LayoutMainPage);
                    PrepareKingCreatePortraitStyleState();
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
                    {
                        MessageBox.Show("Could not locate the expected game data folder. Please make sure you select the root game installation directory.");
                        return;
                    }

                    selectedPath = selectedPath.Replace('/', '\\');

                    var dir = new DirectoryInfo(selectedPath);
                    while (dir != null &&
                            !dir.Name.Equals("Pathfinder Wrath Of The Righteous", StringComparison.OrdinalIgnoreCase))
                        dir = dir.Parent;

                    if (dir == null)
                    {
                        MessageBox.Show("Could not locate the expected game data folder. Please make sure you select the root game installation directory.");
                        return;
                    }

                    string rootPath = dir.FullName + Path.DirectorySeparatorChar;
                    string portraitsDir = Path.Combine(rootPath, "Portraits");
                    if (!Directory.Exists(portraitsDir))
                        Directory.CreateDirectory(portraitsDir);

                    CoreSettings.Default.GamePath = "0";
                    CoreSettings.Default.GameType = '-';
                    CoreSettings.Default.Save();
                    LabelSelectPathSelected.Text = rootPath;
                    CoreSettings.Default.GamePath = rootPath;
                    CoreSettings.Default.GameType = 'w';
                    CoreSettings.Default.Save();
                    LayoutMainPage.BackgroundImage = Resources.wotr_menu_page;
                    _activeMenuIndex = 202;
                    ParentLayoutsDisable();
                    RootFunctions.LayoutEnable(LayoutMainPage);
                    PrepareKingCreatePortraitStyleState();
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
                    {
                        MessageBox.Show("Could not locate the expected game data folder. Please make sure you select the root game installation directory.");
                        return;
                    }

                    selectedPath = selectedPath.Replace('/', '\\');

                    var dir = new DirectoryInfo(selectedPath);
                    while (dir != null &&
                            !dir.Name.Equals("Warhammer 40000 Rogue Trader", StringComparison.OrdinalIgnoreCase))
                        dir = dir.Parent;

                    if (dir == null)
                    {
                        MessageBox.Show("Could not locate the expected game data folder. Please make sure you select the root game installation directory.");
                        return;
                    }

                    string rootPath = dir.FullName + Path.DirectorySeparatorChar;
                    string portraitsDir = Path.Combine(rootPath, "Portraits");
                    if (!Directory.Exists(portraitsDir))
                        Directory.CreateDirectory(portraitsDir);

                    CoreSettings.Default.GamePath = "0";
                    CoreSettings.Default.GameType = '-';
                    CoreSettings.Default.Save();
                    LabelSelectPathSelected.Text = rootPath;
                    CoreSettings.Default.GamePath = rootPath;
                    CoreSettings.Default.GameType = 'r';
                    CoreSettings.Default.Save();
                    LayoutMainPage.BackgroundImage = Resources.rt_menu_page;
                    _activeMenuIndex = 203;
                    ParentLayoutsDisable();
                    RootFunctions.LayoutEnable(LayoutMainPage);
                    PrepareKingCreatePortraitStyleState();
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
                    {
                        MessageBox.Show("Could not locate the expected game data folder. Please make sure you select the root game installation directory.");
                        return;
                    }

                    selectedPath = selectedPath.Replace('/', '\\');

                    var dir = new DirectoryInfo(selectedPath);
                    while (dir != null &&
                           !dir.Name.Equals("Pillars of Eternity", StringComparison.OrdinalIgnoreCase))
                    {
                        dir = dir.Parent;
                    }

                    if (dir == null)
                    {
                        MessageBox.Show("Could not locate the expected game data folder. Please make sure you select the root game installation directory.");
                        return;
                    }

                    string rootPath = dir.FullName + Path.DirectorySeparatorChar;
                    string portraitsRoot = Path.Combine(rootPath, "PillarsOfEternity_Data", "data", "art", "gui", "portraits");
                    if (!Directory.Exists(portraitsRoot))
                    {
                        MessageBox.Show("Could not locate the expected game data folder. Please make sure you select the root game installation directory.");
                        return;
                    }

                    string maleDir = Path.Combine(portraitsRoot, "player", "male");
                    string femaleDir = Path.Combine(portraitsRoot, "player", "female");
                    Directory.CreateDirectory(maleDir);
                    Directory.CreateDirectory(femaleDir);

                    CoreSettings.Default.GamePath = "0";
                    CoreSettings.Default.GameType = '-';
                    CoreSettings.Default.Save();
                    LabelSelectPathSelected.Text = rootPath;
                    CoreSettings.Default.GamePath = rootPath;
                    CoreSettings.Default.GameType = 'p';
                    CoreSettings.Default.Save();
                    LayoutMainPage.BackgroundImage = Resources.poe_menu_page;
                    _activeMenuIndex = 204;
                    ParentLayoutsDisable();
                    RootFunctions.LayoutEnable(LayoutMainPage);
                    PrepareKingCreatePortraitStyleState();
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
                    {
                        MessageBox.Show("Could not locate the expected game data folder. Please make sure you select the root game installation directory.");
                        return;
                    }

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
                    {
                        MessageBox.Show("Could not locate the expected game data folder. Please make sure you select the root game installation directory.");
                        return;
                    }

                    string rootPath = dir.FullName + Path.DirectorySeparatorChar;                    
                    string portraitsRoot = Path.Combine(rootPath, "PillarsOfEternityII_Data", "gui", "portraits");
                    if (!Directory.Exists(portraitsRoot))
                    {
                        MessageBox.Show("Could not locate the expected game data folder. Please make sure you select the root game installation directory.");
                        return;
                    }
                    string maleDir = Path.Combine(portraitsRoot, "player", "male");
                    string femaleDir = Path.Combine(portraitsRoot, "player", "female");
                    Directory.CreateDirectory(maleDir);
                    Directory.CreateDirectory(femaleDir);

                    CoreSettings.Default.GamePath = "0";
                    CoreSettings.Default.GameType = '-';
                    CoreSettings.Default.Save();
                    LabelSelectPathSelected.Text = rootPath;
                    CoreSettings.Default.GamePath = rootPath;
                    CoreSettings.Default.GameType = 'd';
                    CoreSettings.Default.Save();
                    LayoutMainPage.BackgroundImage = Resources.poed_menu_page;
                    _activeMenuIndex = 205;
                    ParentLayoutsDisable();
                    RootFunctions.LayoutEnable(LayoutMainPage);
                    PrepareKingCreatePortraitStyleState();
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
                    {
                        MessageBox.Show("Could not locate the expected game data folder. Please make sure you select the root game installation directory.");
                        return;
                    }

                    var dir = new DirectoryInfo(selectedPath);
                    while (dir != null && !dir.Name.Equals("Tyranny", StringComparison.OrdinalIgnoreCase))
                        dir = dir.Parent;
                    if (dir == null)
                    {
                        MessageBox.Show("Could not locate the expected game data folder. Please make sure you select the root game installation directory.");
                        return;
                    }

                    string rootPath = dir.FullName + Path.DirectorySeparatorChar;
                    string checkPath = Path.Combine(rootPath, "Tyranny_Data", "data", "art", "gui", "icons", "abilities");

                    if (!Directory.Exists(checkPath))
                    {
                        MessageBox.Show("Could not locate the expected game data folder. Please make sure you select the root game installation directory.");
                        return;
                    }

                    string maleDir = Path.Combine(rootPath, "Tyranny_Data", "data", "art", "gui", "portraits", "player", "male");
                    string femaleDir = Path.Combine(rootPath, "Tyranny_Data", "data", "art", "gui", "portraits", "player", "female");
                    Directory.CreateDirectory(maleDir);
                    Directory.CreateDirectory(femaleDir);

                    CoreSettings.Default.GamePath = "0";
                    CoreSettings.Default.GameType = '-';
                    CoreSettings.Default.Save();
                    LabelSelectPathSelected.Text = rootPath.ToLower();
                    CoreSettings.Default.GamePath = rootPath;
                    CoreSettings.Default.GameType = 't';
                    CoreSettings.Default.Save();
                    LayoutMainPage.BackgroundImage = Resources.tyr_menu_page;
                    _activeMenuIndex = 206;
                    ParentLayoutsDisable();
                    RootFunctions.LayoutEnable(LayoutMainPage);
                    PrepareKingCreatePortraitStyleState();
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
                    {
                        MessageBox.Show("Could not locate the expected game data folder. Please make sure you select the root game installation directory.");
                        return;
                    }

                    var dir = new DirectoryInfo(selectedPath);
                    while (dir != null && !dir.Name.Equals("Wasteland3", StringComparison.OrdinalIgnoreCase))
                        dir = dir.Parent;
                    if (dir == null)
                    {
                        MessageBox.Show("Could not locate the expected game data folder. Please make sure you select the root game installation directory.");
                        return;
                    }

                    string rootPath = dir.FullName + Path.DirectorySeparatorChar;

                    string customPortraits = Path.Combine(rootPath, "Custom Portraits");
                    Directory.CreateDirectory(customPortraits);

                    CoreSettings.Default.GamePath = "0";
                    CoreSettings.Default.GameType = '-';
                    CoreSettings.Default.Save();
                    LabelSelectPathSelected.Text = rootPath.ToLower();
                    CoreSettings.Default.GamePath = rootPath;
                    CoreSettings.Default.GameType = 'l';
                    CoreSettings.Default.Save();
                    LayoutMainPage.BackgroundImage = Resources.waste_menu_page;
                    _activeMenuIndex = 207;
                    ParentLayoutsDisable();
                    RootFunctions.LayoutEnable(LayoutMainPage);
                    PrepareKingCreatePortraitStyleState();
                    Focus();
                }
                catch (Exception)
                {
                    return;
                }
            }
            LabelBrowse.Visible = true;
            ApplyGameWindowStyle();
        }

        private void LayoutPathPage_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelExtractContainer_Paint(object sender, PaintEventArgs e)
        {
            Color foreColor;
            try { foreColor = GameTypes[_gameSelected].ForeColor; } catch { foreColor = Color.FromArgb(60, 60, 60); }
            ControlPaint.DrawBorder(e.Graphics, ((Panel)sender).ClientRectangle,
                foreColor, ButtonBorderStyle.Solid);
        }

        private void PanelExtractOverlay_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            Rectangle rect = panel.ClientRectangle;

            Color gameFore, gameBack;
            try { gameFore = GameTypes[_gameSelected].ForeColor; gameBack = GameTypes[_gameSelected].BackColor; }
            catch { gameFore = Color.White; gameBack = Color.FromArgb(12, 12, 12); }

            string title = TextVariables.BUTTON_SELECT_ARCHIVE;
            string folderIcon = "\U0001F4C1";
            string hint = TextVariables.EXTRACT_HINT_OVERLAY;
            string hintSub = TextVariables.EXTRACT_HINT_SUB;

            using (Font titleFont = new Font(_fontCollection.Families[0], 22))
            using (Font hintFont = new Font(_fontCollection.Families[0], 12))
            using (Font hintSubFont = new Font(_fontCollection.Families[0], 9))
            {
                string titleLine = title + "\n" + folderIcon;
                TextFormatFlags tf = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;

                Size titleSize = TextRenderer.MeasureText(e.Graphics, titleLine, titleFont,
                    new Size(rect.Width, 0), tf);
                Size hintSize = TextRenderer.MeasureText(e.Graphics, hint, hintFont,
                    new Size(rect.Width, 0), tf);
                Size hintSubSize = TextRenderer.MeasureText(e.Graphics, hintSub, hintSubFont,
                    new Size(rect.Width, 0), tf);

                int totalHeight = titleSize.Height + 16 + hintSize.Height + 6 + hintSubSize.Height;
                int yStart = (rect.Height - totalHeight) / 2;

                Color titleColor = _overlayHovered ? gameFore : Color.White;

                Rectangle titleRect = new Rectangle(0, yStart, rect.Width, titleSize.Height);
                TextRenderer.DrawText(e.Graphics, titleLine, titleFont, titleRect, titleColor, tf);

                Rectangle hintRect = new Rectangle(0, yStart + titleSize.Height + 16, rect.Width, hintSize.Height);
                TextRenderer.DrawText(e.Graphics, hint, hintFont, hintRect, Color.Gray, tf);

                Rectangle hintSubRect = new Rectangle(0, yStart + titleSize.Height + 16 + hintSize.Height + 6,
                    rect.Width, hintSubSize.Height);
                TextRenderer.DrawText(e.Graphics, hintSub, hintSubFont, hintSubRect, Color.Gray, tf);
            }
        }

        private void PanelExtractOverlay_MouseEnter(object sender, EventArgs e)
        {
            _overlayHovered = true;
            ((Panel)sender).Invalidate();
        }

        private void PanelExtractOverlay_MouseLeave(object sender, EventArgs e)
        {
            _overlayHovered = false;
            ((Panel)sender).Invalidate();
        }

        private void PanelExtractContainer_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void PanelExtractContainer_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (files == null || files.Length == 0) return;

            string path = files[0];
            if (Directory.Exists(path))
            {
                LoadArchiveThumbnails(path);
            }
            else
            {
                string ext = Path.GetExtension(path).ToLowerInvariant();
                if (ext == ".zip" || ext == ".7z" || ext == ".rar")
                    LoadArchiveThumbnails(path);
            }
        }

        private void LayoutExtractRight_Paint(object sender, PaintEventArgs e)
        {
            Color foreColor;
            try { foreColor = GameTypes[_gameSelected].ForeColor; } catch { foreColor = Color.FromArgb(60, 60, 60); }
            ControlPaint.DrawBorder(e.Graphics, ((TableLayoutPanel)sender).ClientRectangle,
                foreColor, ButtonBorderStyle.Solid);
        }

        private void UpdateExtractCounter()
        {
            int total = 0;
            int selected = 0;
            if (_archiveEntries != null)
            {
                total = _archiveEntries.Count;
                selected = FlowLayoutPanelExtract.Controls.OfType<CheckBox>().Count(cb => cb.Checked);
            }
            LabelExtractCounter.Text = "Total: " + total + " | Selected: " + selected;
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
            if (_gameSelected == 'k' || _gameSelected == 'w' || _gameSelected == 'r' ||
                _gameSelected == 'p' || _gameSelected == 't' || _gameSelected == 'd' || _gameSelected == 'l')
            {
                ParentLayoutsDisable();
                RootFunctions.LayoutEnable(LayoutKingCreatePortrait);
                _activeMenuIndex = GetCreatePortraitMenuIndexForCurrentGame();

                PrepareKingCreatePortraitView();
                PrepareKingCreatePortraitStyleState();
                TextInit();
                Focus();
            }
        }

        private ushort GetMainMenuIndexForCurrentGame()
        {
            if (_gameSelected == 'w') return 202;
            if (_gameSelected == 'r') return 203;
            if (_gameSelected == 'p') return 204;
            if (_gameSelected == 'd') return 205;
            if (_gameSelected == 't') return 206;
            if (_gameSelected == 'l') return 207;
            return 201;
        }

        private ushort GetCreatePortraitMenuIndexForCurrentGame()
        {
            if (_gameSelected == 'w') return 302;
            if (_gameSelected == 'r') return 303;
            if (_gameSelected == 'p') return 304;
            if (_gameSelected == 'd') return 305;
            if (_gameSelected == 't') return 306;
            if (_gameSelected == 'l') return 307;
            return 301;
        }

        private void PrepareKingCreatePortraitStyleState()
        {
            SetKingPortraitGroup(KingPortraitGroupSelection.Large);
            AdjustActivePortraitPanelAspect(KingPortraitGroupSelection.Medium);
            AdjustActivePortraitPanelAspect(KingPortraitGroupSelection.Small);
            AdjustActivePortraitPanelAspect(KingPortraitGroupSelection.Sml2);
            LayoutKingPortraitGroupLarge.Invalidate();
            LayoutKingPortraitGroupMedium.Invalidate();
            LayoutKingPortraitGroupSmall.Invalidate();
            LayoutKingPortraitGroupSml2.Invalidate();
            LayoutKingRight.Invalidate();
        }

        private void PrepareKingCreatePortraitView()
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gameType) || gameType.PlaceholderPortrait == null)
                return;

            StoreOriginalImage(PicKingLrg, new Bitmap(gameType.PlaceholderPortrait));
            StoreOriginalImage(PicKingSml, new Bitmap(gameType.PlaceholderPortrait));
            StoreOriginalImage(PicKingSml2, new Bitmap(gameType.PlaceholderPortrait));

            _kingGroupLrgInitialized = false;
            _kingGroupSmlInitialized = false;
            _kingGroupSml2Initialized = false;

            bool hasMed = HasPortraitSpecific(gameType, "MEDIUM_WIDTH") &&
                          HasPortraitSpecific(gameType, "MEDIUM_HEIGHT");

            if (hasMed)
            {
                StoreOriginalImage(PicKingMed, new Bitmap(gameType.PlaceholderPortrait));
                _kingGroupMedInitialized = false;
            }
            else
            {
                _kingGroupMedInitialized = true; // mark as initialized so EnsureKingGroup skips it
            }

            // Enable drag-and-drop onto each portrait PictureBox (file or URL text)
            WirePortraitDragDrop(PicKingLrg);
            WirePortraitDragDrop(PicKingSml);
            WirePortraitDragDrop(PicKingSml2);
            if (hasMed)
                WirePortraitDragDrop(PicKingMed);

            AdjustActivePortraitPanelAspect(KingPortraitGroupSelection.Large);
            EnsureKingGroupInitialized(KingPortraitGroupSelection.Large);
        }

        private float GetPortraitSpecificOrDefault(GameType gameType, string key, float fallback)
        {
            if (gameType == null) return fallback;
            try { return gameType.GetPortraitSpecific(key); }
            catch { return fallback; }
        }

        private void AdjustPortraitPanelAspect(Panel panel, float ar, float staticHeight)
        {
            if (panel == null) return;

            panel.SuspendLayout();
            try
            {
                panel.AutoSize = false;
                panel.Dock = DockStyle.None;
                panel.Anchor = AnchorStyles.None;
                int newWidth = (int)Math.Round(staticHeight / ar);
                panel.Size = new Size(newWidth, (int)staticHeight);
            }
            finally
            {
                panel.ResumeLayout();
            }
        }

        private void AdjustActivePortraitPanelAspect(KingPortraitGroupSelection selection)
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gameType)) return;

            if (selection == KingPortraitGroupSelection.Large)
            {
                if (!HasPortraitSpecific(gameType, "LARGE_WIDTH")) return;
                AdjustPortraitPanelAspect(
                    PanelKingLrg,
                    GetPortraitSpecificOrDefault(gameType, "LARGE_AR", 1.3f),
                    360f);
            }
            else if (selection == KingPortraitGroupSelection.Medium)
            {
                if (HasPortraitSpecific(gameType, "MEDIUM_WIDTH"))
                {
                    AdjustPortraitPanelAspect(
                        PanelKingMed,
                        GetPortraitSpecificOrDefault(gameType, "MEDIUM_AR", 1.3f),
                        360f);
                }
            }
            else if (selection == KingPortraitGroupSelection.Small)
            {
                if (!HasPortraitSpecific(gameType, "SMALL_WIDTH")) return;
                float smlHeight = (_gameSelected == 'l') ? 256f : 360f;
                AdjustPortraitPanelAspect(
                    PanelKingSml,
                    GetPortraitSpecificOrDefault(gameType, "SMALL_AR", 1.4f),
                    smlHeight);
            }
            else if (selection == KingPortraitGroupSelection.Sml2)
            {
                if (!HasPortraitSpecific(gameType, "SML2_WIDTH")) return;
                AdjustPortraitPanelAspect(
                    PanelKingSml2,
                    GetPortraitSpecificOrDefault(gameType, "SML2_AR", 1.4f),
                    360f);
            }
        }

        private void WirePortraitDragDrop(PictureBox pic)
        {
            if (pic == null) return;
            pic.AllowDrop = true;
            pic.DragEnter -= PicKing_DragEnter;
            pic.DragDrop  -= PicKing_DragDrop;
            pic.DragLeave -= PicKing_DragLeave;
            pic.DragEnter += PicKing_DragEnter;
            pic.DragDrop  += PicKing_DragDrop;
            pic.DragLeave += PicKing_DragLeave;
        }

        private void EnsureKingGroupInitialized(KingPortraitGroupSelection selection)
        {
            if (selection == KingPortraitGroupSelection.Large)
            {
                if (_kingGroupLrgInitialized) return;
                FitPictureToPanel(PicKingLrg, PanelKingLrg);
                _kingGroupLrgInitialized = true;
            }
            else if (selection == KingPortraitGroupSelection.Medium)
            {
                if (_kingGroupMedInitialized) return;
                FitPictureToPanel(PicKingMed, PanelKingMed);
                _kingGroupMedInitialized = true;
            }
            else if (selection == KingPortraitGroupSelection.Small)
            {
                if (_kingGroupSmlInitialized) return;
                FitPictureToPanel(PicKingSml, PanelKingSml);
                _kingGroupSmlInitialized = true;
            }
            else if (selection == KingPortraitGroupSelection.Sml2)
            {
                if (_kingGroupSml2Initialized) return;
                FitPictureToPanel(PicKingSml2, PanelKingSml2);
                _kingGroupSml2Initialized = true;
            }
        }

        private void ResetPortraitToOriginalDisplay(PictureBox pic)
        {
            if (pic == null) return;

            Image original = GetOriginalImage(pic);
            if (original == null) return;

            try
            {
                if (pic.Image != null && !object.ReferenceEquals(pic.Image, original))
                    pic.Image.Dispose();
            }
            catch { }

            pic.Dock = DockStyle.Fill;
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Location = new Point(0, 0);
            pic.Image = new Bitmap(original);
            SetZoomLevel(pic, 1.0f);
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

        private void LabelKingCreatePortraitSml2_Click(object sender, EventArgs e)
        {
            SetKingPortraitGroup(KingPortraitGroupSelection.Sml2);
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
                _activeMenuIndex = GetMainMenuIndexForCurrentGame();
                ParentLayoutsDisable();
                RootFunctions.LayoutEnable(LayoutMainPage);
                Focus();
            }
            catch { }
        }

        private void NavigateToMainPage()
        {
            try
            {
                _activeMenuIndex = GetMainMenuIndexForCurrentGame();
                ParentLayoutsDisable();
                RootFunctions.LayoutEnable(LayoutMainPage);
                Focus();
            }
            catch { }
        }

        private void ButtonKingBackToPathfinder_Click(object sender, EventArgs e)
        {
            // Explicit button to return user to the selected game's main page
            try
            {
                _overrideGallerySaveDir = null;
                _activeMenuIndex = GetMainMenuIndexForCurrentGame();
                ParentLayoutsDisable();
                RootFunctions.LayoutEnable(LayoutMainPage);
                PrepareKingCreatePortraitStyleState();
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
                    Filter = "Image files|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.webp",
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
                            MarkGroupInitialized(pic);
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
            else if (pic.Name == "PicKingSml2")
            {
                _originalImageSml2?.Dispose();
                _originalImageSml2 = img;
                _zoomLevelSml2 = 1.0f;
            }
        }

        private Image GetOriginalImage(PictureBox pic)
        {
            if (pic.Name == "PicKingLrg") return _originalImageLrg;
            if (pic.Name == "PicKingMed") return _originalImageMed;
            if (pic.Name == "PicKingSml") return _originalImageSml;
            if (pic.Name == "PicKingSml2") return _originalImageSml2;
            return null;
        }

        private float GetZoomLevel(PictureBox pic)
        {
            if (pic.Name == "PicKingLrg") return _zoomLevelLrg;
            if (pic.Name == "PicKingMed") return _zoomLevelMed;
            if (pic.Name == "PicKingSml") return _zoomLevelSml;
            if (pic.Name == "PicKingSml2") return _zoomLevelSml2;
            return 1.0f;
        }

        private void SetZoomLevel(PictureBox pic, float zoom)
        {
            if (pic.Name == "PicKingLrg") _zoomLevelLrg = zoom;
            else if (pic.Name == "PicKingMed") _zoomLevelMed = zoom;
            else if (pic.Name == "PicKingSml") _zoomLevelSml = zoom;
            else if (pic.Name == "PicKingSml2") _zoomLevelSml2 = zoom;
        }

        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        private const int DWMWA_BORDER_COLOR = 34;
        private const int DWMWA_CAPTION_COLOR = 35;
        private const int DWMWA_TEXT_COLOR = 36;

        private void ApplyGameWindowStyle()
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gameType)) return;

            try
            {
                int useDark = 1;
                DwmSetWindowAttribute(Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref useDark, sizeof(int));

                int borderColor = System.Drawing.ColorTranslator.ToWin32(gameType.ForeColor);
                DwmSetWindowAttribute(Handle, DWMWA_BORDER_COLOR, ref borderColor, sizeof(int));

                int captionColor = System.Drawing.ColorTranslator.ToWin32(gameType.BackColor);
                DwmSetWindowAttribute(Handle, DWMWA_CAPTION_COLOR, ref captionColor, sizeof(int));

                int textColor = System.Drawing.ColorTranslator.ToWin32(gameType.ForeColor);
                DwmSetWindowAttribute(Handle, DWMWA_TEXT_COLOR, ref textColor, sizeof(int));
            }
            catch { }
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg != WM_MOUSEWHEEL) return false;

            Point cursor = Cursor.Position;
            Panel targetPanel = null;
            PictureBox targetPic = null;

            Panel[] panels = { PanelKingLrg, PanelKingMed, PanelKingSml, PanelKingSml2 };
            PictureBox[] pics = { PicKingLrg, PicKingMed, PicKingSml, PicKingSml2 };

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

            float zoomStep = 0.08f;
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

            if ((pb == PicKingLrg || pb == PicKingSml2) && wheelDelta < 0 && Math.Abs(newZoom - minZoom) < 0.0001f)
            {
                pb.Location = new Point((panelW - newW) / 2, (panelH - newH) / 2);
                return;
            }

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

        private void ButtonKingZoomReset_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;
            string picName = button.Tag as string;
            if (string.IsNullOrEmpty(picName)) return;

            PictureBox pb = null;
            if (picName == "PicKingLrg") pb = PicKingLrg;
            else if (picName == "PicKingMed") pb = PicKingMed;
            else if (picName == "PicKingSml") pb = PicKingSml;
            else if (picName == "PicKingSml2") pb = PicKingSml2;

            if (pb == null || pb.Image == null) return;
            FitImageToPanel(pb);
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
            else if (picName == "PicKingSml2") { pb = PicKingSml2; panel = PanelKingSml2; }

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
                LayoutKingPortraitGroupSmall == null ||
                LayoutKingPortraitGroupSml2 == null)
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
                LayoutKingPortraitGroupSml2.Visible = selection == KingPortraitGroupSelection.Sml2;
                LabelKingCreatePortraitLarge.Visible = true;
                LabelKingCreatePortraitMedium.Visible = true;
                LabelKingCreatePortraitSmall.Visible = true;
                LabelKingCreatePortraitSml2.Visible = true;
                return;
            }

            bool hasMedium = HasPortraitSpecific(gameType, "MEDIUM_WIDTH") &&
                             HasPortraitSpecific(gameType, "MEDIUM_HEIGHT");
            bool hasLarge = HasPortraitSpecific(gameType, "LARGE_WIDTH") &&
                            HasPortraitSpecific(gameType, "LARGE_HEIGHT");
            bool hasSmall = HasPortraitSpecific(gameType, "SMALL_WIDTH") &&
                            HasPortraitSpecific(gameType, "SMALL_HEIGHT");
            bool hasSml2 = HasPortraitSpecific(gameType, "SML2_WIDTH") &&
                           HasPortraitSpecific(gameType, "SML2_HEIGHT");

            // Fall back to first available group if requested selection has no dimensions
            bool selectionAvailable =
                (selection == KingPortraitGroupSelection.Large && hasLarge) ||
                (selection == KingPortraitGroupSelection.Medium && hasMedium) ||
                (selection == KingPortraitGroupSelection.Small && hasSmall) ||
                (selection == KingPortraitGroupSelection.Sml2 && hasSml2);

            if (!selectionAvailable)
            {
                if (hasSmall) selection = KingPortraitGroupSelection.Small;
                else if (hasSml2) selection = KingPortraitGroupSelection.Sml2;
                else if (hasMedium) selection = KingPortraitGroupSelection.Medium;
                else if (hasLarge) selection = KingPortraitGroupSelection.Large;
            }

            _activeKingPortraitGroup = selection;

            LayoutKingPortraitGroupLarge.Visible = hasLarge && selection == KingPortraitGroupSelection.Large;
            LayoutKingPortraitGroupMedium.Visible = hasMedium && selection == KingPortraitGroupSelection.Medium;
            LayoutKingPortraitGroupSmall.Visible = hasSmall && selection == KingPortraitGroupSelection.Small;
            LayoutKingPortraitGroupSml2.Visible = hasSml2 && selection == KingPortraitGroupSelection.Sml2;

            LayoutKingPortraitGroupLarge.BackColor = selection == KingPortraitGroupSelection.Large ? gameType.BackColor : Color.Transparent;
            LayoutKingPortraitGroupMedium.BackColor = selection == KingPortraitGroupSelection.Medium ? gameType.BackColor : Color.Transparent;
            LayoutKingPortraitGroupSmall.BackColor = selection == KingPortraitGroupSelection.Small ? gameType.BackColor : Color.Transparent;
            LayoutKingPortraitGroupSml2.BackColor = selection == KingPortraitGroupSelection.Sml2 ? gameType.BackColor : Color.Transparent;
            LayoutKingRight.BackColor = gameType.BackColor;
            LayoutKingRight.ForeColor = gameType.ForeColor;

            Color selBack = gameType.BackColor;
            Color selFore = gameType.ForeColor;

            LabelKingCreatePortraitLarge.Visible = hasLarge;
            LabelKingCreatePortraitLarge.BackColor = hasLarge && selection == KingPortraitGroupSelection.Large ? selBack : Color.Transparent;
            LabelKingCreatePortraitLarge.ForeColor = hasLarge && selection == KingPortraitGroupSelection.Large ? selFore : Color.White;
            LabelKingCreatePortraitMedium.Visible = hasMedium;
            LabelKingCreatePortraitMedium.BackColor = hasMedium && selection == KingPortraitGroupSelection.Medium ? selBack : Color.Transparent;
            LabelKingCreatePortraitMedium.ForeColor = hasMedium && selection == KingPortraitGroupSelection.Medium ? selFore : Color.White;
            LabelKingCreatePortraitSmall.Visible = hasSmall;
            LabelKingCreatePortraitSmall.BackColor = hasSmall && selection == KingPortraitGroupSelection.Small ? selBack : Color.Transparent;
            LabelKingCreatePortraitSmall.ForeColor = hasSmall && selection == KingPortraitGroupSelection.Small ? selFore : Color.White;
            LabelKingCreatePortraitSml2.Visible = hasSml2;
            LabelKingCreatePortraitSml2.BackColor = hasSml2 && selection == KingPortraitGroupSelection.Sml2 ? selBack : Color.Transparent;
            LabelKingCreatePortraitSml2.ForeColor = hasSml2 && selection == KingPortraitGroupSelection.Sml2 ? selFore : Color.White;
            // force repaint to update borders
            LabelKingCreatePortraitLarge?.Invalidate();
            LabelKingCreatePortraitMedium?.Invalidate();
            LabelKingCreatePortraitSmall?.Invalidate();
            LabelKingCreatePortraitSml2?.Invalidate();
            AdjustActivePortraitPanelAspect(selection);
            EnsureKingGroupInitialized(selection);
            // Update portrait buttons styles to match selected game colors
            UpdatePortraitButtonsStyle();

            // Reset Small label margin to default left alignment
            LabelKingCreatePortraitSmall.Margin = new Padding(0, 0, 3, 0);

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
                    else if (selection == KingPortraitGroupSelection.Sml2)
                    {
                        FitPictureToPanel(PicKingSml2, PanelKingSml2);
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
                if (LayoutKingPortraitGroupMedium != null)
                    LayoutKingPortraitGroupMedium.Size = refSize;
                if (LayoutKingPortraitGroupSml2 != null)
                    LayoutKingPortraitGroupSml2.Size = refSize;

                // Copy row styles (counts and heights)
                CopyRowStyles(LayoutKingPortraitGroupSmall, LayoutKingPortraitGroupLarge);
                if (LayoutKingPortraitGroupMedium != null)
                    CopyRowStyles(LayoutKingPortraitGroupSmall, LayoutKingPortraitGroupMedium);
                if (LayoutKingPortraitGroupSml2 != null)
                    CopyRowStyles(LayoutKingPortraitGroupSmall, LayoutKingPortraitGroupSml2);

                // Ensure button panels (which are table layout panels) have the same row styles
                CopyRowStyles(PanelKingSmlButtons, PanelKingLrgButtons);
                if (PanelKingMedButtons != null)
                    CopyRowStyles(PanelKingSmlButtons, PanelKingMedButtons);
                if (PanelKingSml2Buttons != null)
                    CopyRowStyles(PanelKingSmlButtons, PanelKingSml2Buttons);

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
                    ButtonKingLrgZoomIn, ButtonKingLrgZoomOut, ButtonKingLrgZoomReset,
                    ButtonKingMedZoomIn, ButtonKingMedZoomOut, ButtonKingMedZoomReset,
                    ButtonKingSmlZoomIn, ButtonKingSmlZoomOut, ButtonKingSmlZoomReset,
                    ButtonKingSml2ZoomIn, ButtonKingSml2ZoomOut, ButtonKingSml2ZoomReset
                };
                foreach (var zb in zoomButtons)
                {
                    if (zb == null) continue;
                    zb.MinimumSize = new Size(0, bottomHeight);
                    zb.Height = bottomHeight;
                    zb.Dock = DockStyle.Fill;
                }

                var handCursorButtons = new Button[] {
                    ButtonKingLrgWeb, ButtonKingLrgLocal, ButtonKingLrgZoomIn, ButtonKingLrgZoomOut, ButtonKingLrgZoomReset,
                    ButtonKingMedWeb, ButtonKingMedLocal, ButtonKingMedZoomIn, ButtonKingMedZoomOut, ButtonKingMedZoomReset,
                    ButtonKingSmlWeb, ButtonKingSmlLocal, ButtonKingSmlZoomIn, ButtonKingSmlZoomOut, ButtonKingSmlZoomReset,
                    ButtonKingSml2Web, ButtonKingSml2Local, ButtonKingSml2ZoomIn, ButtonKingSml2ZoomOut, ButtonKingSml2ZoomReset
                };
                foreach (var b in handCursorButtons)
                {
                    if (b == null) continue;
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

            // Style hint labels above the Local/Web buttons — pick resource keys per game
            string lrgKey, medKey, smlKey, sml2Key;
            if (_gameSelected == 'r')
            {
                lrgKey = "HINT_RT_LRG";
                medKey = "HINT_RT_MED";
                smlKey = "HINT_RT_SML";
                sml2Key = null;
            }
            else if (_gameSelected == 'p' || _gameSelected == 't')
            {
                lrgKey = "HINT_PILLARS_LRG";
                medKey = null; // no medium for these games
                smlKey = "HINT_PILLARS_SML";
                sml2Key = null;
            }
            else if (_gameSelected == 'd')
            {
                lrgKey = "HINT_PILLARS_LRG";
                medKey = "HINT_PILLARS_MED";
                smlKey = "HINT_PILLARS_SML";
                sml2Key = "HINT_PILLARS_SML2";
            }
            else if (_gameSelected == 'l')
            {
                lrgKey = null; // no large for Wasteland 3
                medKey = null;
                smlKey = null; // set directly below
                sml2Key = null;
            }
            else
            {
                lrgKey = "HINT_KING_LRG";
                medKey = "HINT_KING_MED";
                smlKey = "HINT_KING_SML";
                sml2Key = null;
            }

            var hintLabels = new (System.Windows.Forms.Label lbl, string key)[]
            {
                (LabelKingLrgHint, lrgKey),
                (LabelKingMedHint, medKey),
                (LabelKingSmlHint, smlKey),
                (LabelKingSml2Hint, sml2Key),
            };
            foreach (var (lbl, key) in hintLabels)
            {
                if (lbl == null) continue;
                lbl.BackColor = selBack;
                lbl.ForeColor = selFore;
                lbl.TextAlign = ContentAlignment.TopLeft;
                try
                {
                    if (!string.IsNullOrEmpty(key))
                    {
                        var prop = typeof(TextVariables).GetProperty(key,
                            System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static |
                            System.Reflection.BindingFlags.NonPublic);
                        if (prop != null)
                        {
                            var val = prop.GetValue(null) as string;
                            if (!string.IsNullOrEmpty(val)) lbl.Text = val;
                        }
                    }
                }
                catch { }
            }

            // Wasteland 3: only Small exists at 256×256
            if (_gameSelected == 'l' && LabelKingSmlHint != null)
            {
                LabelKingSmlHint.Text = "Portrait (256×256) — used for character portraits.\n\nChoose a local image from your computer or select a web image from the internet. You can also drag-and-drop either a local image file or a web image link into this area.";
            }

            var buttons = new Button[] {
                ButtonKingLrgWeb, ButtonKingLrgLocal, ButtonKingLrgZoomIn, ButtonKingLrgZoomOut, ButtonKingLrgZoomReset,
                ButtonKingMedWeb, ButtonKingMedLocal, ButtonKingMedZoomIn, ButtonKingMedZoomOut, ButtonKingMedZoomReset,
                ButtonKingSmlWeb, ButtonKingSmlLocal, ButtonKingSmlZoomIn, ButtonKingSmlZoomOut, ButtonKingSmlZoomReset,
                ButtonKingSml2Web, ButtonKingSml2Local, ButtonKingSml2ZoomIn, ButtonKingSml2ZoomOut, ButtonKingSml2ZoomReset,
                ButtonKingCreateNewPortrait, ButtonKingBackToPathfinder
            };

            foreach (var btn in buttons)
            {
                if (btn == null) continue;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = selFore;
                btn.BackColor = selBack;
                btn.ForeColor = selFore;
                btn.FlatAppearance.MouseOverBackColor = selFore;
                btn.FlatAppearance.MouseDownBackColor = selFore;
                btn.TabStop = false;

                btn.MouseEnter -= PortraitButton_MouseEnter;
                btn.MouseLeave -= PortraitButton_MouseLeave;
                btn.GotFocus -= PortraitButton_GotFocus;
                btn.MouseEnter += PortraitButton_MouseEnter;
                btn.MouseLeave += PortraitButton_MouseLeave;
                btn.GotFocus += PortraitButton_GotFocus;
            }

        }

        private void PortraitButton_GotFocus(object sender, EventArgs e)
        {
            ActiveControl = null;
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

        private void LabelKingCreatePortraitSml2_MouseEnter(object sender, EventArgs e)
        {
            LabelKingCreatePortraitSml2.ForeColor = GameTypes[_gameSelected].ForeColor;
        }

        private void LabelKingCreatePortraitSml2_MouseLeave(object sender, EventArgs e)
        {
            LabelKingCreatePortraitSml2.ForeColor = _activeKingPortraitGroup == KingPortraitGroupSelection.Sml2 ? GameTypes[_gameSelected].ForeColor : Color.White;
        }

    }
}
