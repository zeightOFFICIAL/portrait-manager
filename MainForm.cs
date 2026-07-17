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
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace PortraitManager
{
    public partial class MainForm : Form, IMessageFilter
    {
        private const int WM_MOUSEWHEEL = 0x020A;
        private static char _gameSelected;
        private static ushort _activeMenuIndex = 0;

        private enum PortraitGroupSelection
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
                        _groupLrgInitialized = true;
                    }
                    else if (tag == "PicKingMed")
                    {
                        StoreOriginalImage(PicKingMed, new Bitmap(img));
                        FitImageToPanel(PicKingMed);
                        _groupMedInitialized = true;
                    }
                    else if (tag == "PicKingSml")
                    {
                        StoreOriginalImage(PicKingSml, new Bitmap(img));
                        FitImageToPanel(PicKingSml);
                        _groupSmlInitialized = true;
                    }
                    else if (tag == "PicKingSml2")
                    {
                        StoreOriginalImage(PicKingSml2, new Bitmap(img));
                        FitImageToPanel(PicKingSml2);
                        _groupSml2Initialized = true;
                    }
                    img.Dispose();
                }
            }
        }

        private PortraitGroupSelection _activeKingPortraitGroup = PortraitGroupSelection.Large;

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
        private bool _groupLrgInitialized;
        private bool _groupMedInitialized;
        private bool _groupSmlInitialized;
        private bool _groupSml2Initialized;

        // Loaded from BebasNeue-Regular-ru.ttf, which is confirmed (checked its GDI Unicode
        // range table) to cover both Latin and Cyrillic glyphs - so this single collection
        // covers every BebasNeue usage app-wide, English or Russian-localized folder names alike.
        private static PrivateFontCollection _fontCollection;
        private static CancellationTokenSource _cancellationTokenSource;

        private string _selectedArchivePath;
        private List<Tuple<string, Image>> _archiveEntries;
        private bool _overlayHovered;
        private string _shellTempDir;
        private List<Tuple<string, Image>> _galleryEntries;
        private string _selectedGalleryEntry;
        private string _overrideGallerySaveDir;
        private bool _suppressGalleryCheckEvents;
        private string _galleryTabSelected = "player";
        private bool _isCustomNpcMode = false;
        private Panel _panelGalleryOverlay;

        private void FontInit()
        {
            _fontCollection = SystemControl.FileControl.InitCustomFont(Resources.BebasNeue_Regular_RU);

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
            LabelGalleryNonPlayerTab.Font = bebasNeueHead;
            LabelGalleryCustomNpcTab.Font = bebasNeueHead;
            LabelGalleryCompanionsTab.Font = bebasNeueHead;
            LabelGalleryCharactersTab.Font = bebasNeueHead;
            ButtonGalleryBack.Font = bebasNeueHead;
            ButtonGalleryClone.Font = bebasNeueHead;
            ButtonGalleryChange.Font = bebasNeueHead;
            ButtonGalleryDelete.Font = bebasNeueHead;
            ButtonGalleryShowFolder.Font = bebasNeueHead;

            // Body/explanatory/exact-value text: plain sans-serif, not the stylised BebasNeue, so
            // it stays exactly legible (paths, counts, credits, footer). Explicitly assigned here
            // rather than left at whatever the Designer.cs default happens to be.
            Font arialSmall = new Font(FontFamily.GenericSansSerif, 8f);
            Font arialSmallUnderline = new Font(FontFamily.GenericSansSerif, 8f, FontStyle.Underline);

            // Path page: game info (explain) label shrunk to 0.8x (12 -> 9.6), selected-path
            // label enlarged to 1.5x (8 -> 12) so the actual path stands out more than the
            // static blurb around it. The path label's row is AutoSize (see Designer.cs
            // tableLayoutPanel21 row 1) so it can wrap to two or more lines and grow instead of
            // clipping a long path.
            LabelSelectPathExplain.Font = new Font(FontFamily.GenericSansSerif, 12f * 0.8f);
            LabelSelectPathSelected.Font = new Font(FontFamily.GenericSansSerif, 8f * 1.5f);
            LabelMainPageFooter.Font = new Font(FontFamily.GenericSansSerif, 10f, FontStyle.Italic);
            LabelExtractCounter.Font = arialSmall;
            LabelGalleryCredit.Font = arialSmall;
            LabelExtractClearSelection.Font = arialSmallUnderline;
            LabelExtractClose.Font = arialSmallUnderline;

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

            ButtonKingCreateNewPortrait.Text = "Create +";
            ButtonKingBackToPathfinder.Text = "< Back";
            ButtonExtractAll.Text = TextVariables.BUTTON_EXTRACT_ALL;
            ButtonExtractSelected.Text = TextVariables.BUTTON_EXTRACT_SELECTED;
            ButtonExtractBack.Text = TextVariables.BUTTON_EXTRACT_BACK;
            ButtonExtractShowFolder.Text = TextVariables.BUTTON_EXTRACT_OPENFOLDER;
            LabelGalleryTab.Text = TextVariables.BUTTON_GALLERY;
            LabelGalleryNonPlayerTab.Text = TextVariables.LABEL_GALLERY_NONPLAYER;
            LabelGalleryCustomNpcTab.Text = TextVariables.LABEL_GALLERY_CUSTOMNPC;
            LabelGalleryCompanionsTab.Text = TextVariables.LABEL_GALLERY_COMPANIONS;
            LabelGalleryCharactersTab.Text = TextVariables.LABEL_GALLERY_CHARACTERS;
            ButtonGalleryBack.Text = TextVariables.BUTTON_GALLERY_BACK;
            ButtonGalleryClone.Text = TextVariables.BUTTON_GALLERY_CLONE;
            ButtonGalleryChange.Text = TextVariables.BUTTON_GALLERY_CHANGE;
            ButtonGalleryDelete.Text = TextVariables.BUTTON_GALLERY_DELETE;
            ButtonGalleryShowFolder.Text = "FOLDER \U0001F4C1";

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
            SetKingPortraitGroup(PortraitGroupSelection.Large);
            _allowAutoResize = true;
            ReplacePictureBoxImagesToDefault();
            _allowAutoResize = false;

            Focus();
            ApplyGameWindowStyle();
        }

        private void LabelKingCreatePortrait_Paint(object sender, PaintEventArgs e)
        {
            if (!(sender is Label lbl)) return;
            bool isSelected = false;
            if (lbl.Name == "LabelKingCreatePortraitLarge") isSelected = _activeKingPortraitGroup == PortraitGroupSelection.Large;
            else if (lbl.Name == "LabelKingCreatePortraitMedium") isSelected = _activeKingPortraitGroup == PortraitGroupSelection.Medium;
            else if (lbl.Name == "LabelKingCreatePortraitSmall") isSelected = _activeKingPortraitGroup == PortraitGroupSelection.Small;
            else if (lbl.Name == "LabelKingCreatePortraitSml2") isSelected = _activeKingPortraitGroup == PortraitGroupSelection.Sml2;
            if (!isSelected) return;

            Color penColor = Color.White;
            try { penColor = GameTypes[_gameSelected].ForeColor; } catch { penColor = lbl.ForeColor; }
            using (var pen = new Pen(penColor))
            {
                int w = lbl.ClientSize.Width;
                int h = lbl.ClientSize.Height;
                e.Graphics.DrawLine(pen, 0, 0, w - 1, 0);
                e.Graphics.DrawLine(pen, 0, 0, 0, h - 1);
                e.Graphics.DrawLine(pen, w - 1, 0, w - 1, h - 1);
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
            LayoutExtractRight.RowStyles[2].Height = 70;
            LayoutExtractRight.RowStyles[3].Height = 30;

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
            _galleryTabSelected = "player";
            _isCustomNpcMode = false;

            Color gameBack, gameFore;
            try { gameBack = GameTypes[_gameSelected].BackColor; gameFore = GameTypes[_gameSelected].ForeColor; }
            catch { gameBack = Color.FromArgb(12, 12, 12); gameFore = Color.White; }

            LabelGalleryNonPlayerTab.Visible = _gameSelected == 't' || _gameSelected == 'p' || _gameSelected == 'd';
            // Tyranny is unique among these three in that its "non-player" folder actually is
            // companions/close-NPCs stored as loose files in the game's own data folder - call
            // it what it is there. PoE/Deadfire keep the more generic "Non-player" label until
            // their own pass confirms whether the same framing applies.
            LabelGalleryNonPlayerTab.Text = _gameSelected == 't'
                ? TextVariables.LABEL_GALLERY_COMPANIONS
                : TextVariables.LABEL_GALLERY_NONPLAYER;
            // Retired for Kingmaker/WotR: "Characters" now covers everything this tab used to
            // (Portraits - Npc), plus Army/Tactical for WotR - showing both would just duplicate
            // the same NPC folders under two tabs. Never applicable to Tyranny either: it has no
            // "Portraits - Npc"-style mod folder at all - its companions/NPCs are the game's own
            // shipped asset files, already covered by the Companions ("nonplayer") tab instead.
            LabelGalleryCustomNpcTab.Visible = _gameSelected != 'r' && _gameSelected != 'k' &&
                                                _gameSelected != 'w' && _gameSelected != 't';
            // Rogue Trader has no CustomNPC support at all (no vanilla companion-custom-portrait
            // feature, no CustomNpcPortraits mod release) - Companions/Characters would just be
            // permanently empty dead ends there, so only offer them for Kingmaker/WotR.
            bool hasCustomNpc = _gameSelected == 'k' || _gameSelected == 'w';
            LabelGalleryCompanionsTab.Visible = hasCustomNpc;
            LabelGalleryCharactersTab.Visible = hasCustomNpc;
            UpdateGalleryTabVisuals();
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

            ButtonGalleryShowFolder.FlatStyle = FlatStyle.Flat;
            ButtonGalleryShowFolder.FlatAppearance.BorderSize = 1;
            ButtonGalleryShowFolder.FlatAppearance.BorderColor = gameFore;
            ButtonGalleryShowFolder.BackColor = gameBack;
            ButtonGalleryShowFolder.ForeColor = gameFore;
            ButtonGalleryShowFolder.FlatAppearance.MouseOverBackColor = gameFore;
            ButtonGalleryShowFolder.FlatAppearance.MouseDownBackColor = gameFore;
            ButtonGalleryShowFolder.TabStop = false;

            _cancellationTokenSource?.Cancel();
            ClearGalleryEntries();
            LoadGalleryImages();
            UpdateGalleryRightPanel();

            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutGalleryPage);
            Focus();
        }

        // SetKingPortraitGroup only ever makes ONE group's layout/panel visible at a time
        // (LayoutKingPortraitGroupMedium/Small/Sml2.Visible = false while inactive) - so calling
        // FitImageToPanel immediately for an inactive group runs against a panel that isn't
        // necessarily laid out to its real size yet, producing a wrong crop/fit (this is the
        // black-bars-until-you-switch-tabs bug: switching tabs happens to trigger a correct,
        // lazy re-fit via EnsureKingGroupInitialized, which only runs for a group that hasn't
        // already been marked initialized). So: only fit+mark-initialized the group that's
        // actually active right now (Large, in every caller of this - Change/Clone always open
        // on the Large tab); for every other group, just store the image and leave it
        // un-initialized so the existing, correct lazy-fit runs whenever the user switches to it.
        private void LoadImageIntoPortraitBox(PictureBox pic, Image img, PortraitGroupSelection group)
        {
            StoreOriginalImage(pic, img);
            if (group == _activeKingPortraitGroup)
            {
                FitImageToPanel(pic);
                MarkGroupInitialized(pic);
            }
            else
            {
                // EnsureKingGroupInitialized's lazy fit (FitPictureToPanel) bails out early if
                // pic.Image is still null - which it can be for a box that has never been shown
                // in this app session. Assign the raw image directly (not fitted - just a
                // placeholder that gets replaced the moment this group actually becomes active)
                // so that null-check never blocks the real, correctly-timed fit later.
                if (pic.Image == null)
                    pic.Image = img;

                if (pic.Name == "PicKingLrg") _groupLrgInitialized = false;
                else if (pic.Name == "PicKingMed") _groupMedInitialized = false;
                else if (pic.Name == "PicKingSml") _groupSmlInitialized = false;
                else if (pic.Name == "PicKingSml2") _groupSml2Initialized = false;
            }
        }

        private void LoadGalleryImageIntoCreatePage(string folderPath)
        {
            if (_gameSelected == 'd')
            {
                LoadDeadfireGalleryIntoCreatePage(folderPath);
                return;
            }

            if (_gameSelected == 't')
            {
                LoadTyrannyGalleryIntoCreatePage(folderPath, fromBackup: false);
                return;
            }

            string bestFile = FindBestGalleryImage(folderPath);
            if (bestFile == null) return;

            try
            {
                using (Image fileImg = Image.FromFile(bestFile))
                {
                    Bitmap copy = ImageControl.Direct.Resize(fileImg, fileImg.Width, fileImg.Height);

                    LoadImageIntoPortraitBox(PicKingLrg, new Bitmap(copy), PortraitGroupSelection.Large);

                    if (GameTypes.TryGetValue(_gameSelected, out var gt) &&
                        HasPortraitSpecific(gt, "MEDIUM_WIDTH") &&
                        HasPortraitSpecific(gt, "MEDIUM_HEIGHT"))
                    {
                        LoadImageIntoPortraitBox(PicKingMed, new Bitmap(copy), PortraitGroupSelection.Medium);
                    }

                    LoadImageIntoPortraitBox(PicKingSml, new Bitmap(copy), PortraitGroupSelection.Small);
                    LoadImageIntoPortraitBox(PicKingSml2, new Bitmap(copy), PortraitGroupSelection.Sml2);

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
                        LoadImageIntoPortraitBox(PicKingMed, convoCopy, PortraitGroupSelection.Medium);
                    }
                }

                string lgPath = Path.Combine(dir, prefix + "_lg.png");
                string bestFile = File.Exists(lgPath) ? lgPath : FindBestGalleryImage(folderPath);
                if (bestFile == null || !File.Exists(bestFile)) return;

                using (Image lgImg = Image.FromFile(bestFile))
                {
                    Bitmap lgCopy = ImageControl.Direct.Resize(lgImg, lgImg.Width, lgImg.Height);

                    LoadImageIntoPortraitBox(PicKingLrg, new Bitmap(lgCopy), PortraitGroupSelection.Large);
                    LoadImageIntoPortraitBox(PicKingSml, new Bitmap(lgCopy), PortraitGroupSelection.Small);
                    LoadImageIntoPortraitBox(PicKingSml2, new Bitmap(lgCopy), PortraitGroupSelection.Sml2);

                    lgCopy.Dispose();
                }
            }
            catch { }
        }

        private void ButtonGalleryClone_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedGalleryEntry)) return;
            _overrideGallerySaveDir = null;
            _isCustomNpcMode = _galleryTabSelected == "customnpc";
            LabelCreatePortrait_Click(sender, e);
            LoadGalleryImageIntoCreatePage(_selectedGalleryEntry);
        }

        private void ButtonGalleryChange_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedGalleryEntry)) return;

            bool restoreBackup = false;
            bool isNonPlayer = _galleryTabSelected == "nonplayer" && (_gameSelected == 't' || _gameSelected == 'p' || _gameSelected == 'd');

            if (isNonPlayer)
            {
                // Unlike CustomNpcPortraits, there's no mod keeping an original copy for us here -
                // these are the game's own shipped asset files, replaced in place. So this app
                // has to make its own backup, but only ever once (BackupNonPlayerPortraitSet
                // no-ops if one already exists), and then always offer to load it instead of the
                // present (already-replaced-at-least-once) portrait.
                BackupNonPlayerPortraitSet(_selectedGalleryEntry);
                using (var dlg = new forms.MyInquiryDialog(TextVariables.MESG_RESTORE_BACKUP_PROMPT))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                        restoreBackup = true;
                }
            }
            else if (HasModDefaultBackup(_selectedGalleryEntry))
            {
                // This app never creates its own backup - it just asks whether to start from the
                // mod's own "Backup of Game Default Portraits" (the original) or the present
                // portrait currently at this folder's root, whenever the mod actually has one on
                // file. Nothing is written here either way; the choice only affects what gets
                // loaded into Create Portrait below.
                using (var dlg = new forms.MyInquiryDialog(TextVariables.MESG_RESTORE_BACKUP_PROMPT))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                        restoreBackup = true;
                }
            }

            _overrideGallerySaveDir = _selectedGalleryEntry;
            _isCustomNpcMode = _galleryTabSelected == "customnpc";
            LabelCreatePortrait_Click(sender, e);

            if (restoreBackup && isNonPlayer)
                LoadNonPlayerBackupIntoCreatePage(_selectedGalleryEntry);
            else if (restoreBackup)
                LoadBackupImageIntoCreatePage(_selectedGalleryEntry);
            else
                LoadGalleryImageIntoCreatePage(_selectedGalleryEntry);
        }

        private string GetNonPlayerPortraitsRoot(string basePath)
        {
            if (_gameSelected == 'p')
                return Path.Combine(basePath, "PillarsOfEternity_Data", "data", "art", "gui", "portraits");
            if (_gameSelected == 'd')
                return Path.Combine(basePath, "PillarsOfEternityII_Data", "gui", "portraits");
            if (_gameSelected == 't')
                return Path.Combine(basePath, "Data", "data", "art", "gui", "portraits");
            return null;
        }

        private string GetCustomNpcPortraitsDir(string basePath)
        {
            if (_gameSelected == 'r') return null;
            return Path.Combine(basePath, "Portraits - Npc");
        }

        // The "Characters" tab merges everything that isn't a companion into one view:
        // - Kingmaker: "Portraits - All Additions", a sibling of Portraits\ populated by a
        //   separate NPC portrait pack (not edvin76's mod - its output format doesn't match any
        //   of that mod's own directory-naming methods), confirmed to display in-game.
        // - WotR: the mod's own "Portraits - Npc" (regular NPCs; portraits sit one level deeper
        //   per-NPC, same recursive shape as Kingmaker's "All Additions"), "Portraits - Army"
        //   (army leaders) and "Portraits - Tactical" (army units), all folded into one tab per
        //   the user's direction rather than given their own tabs.
        // Rogue Trader has no CustomNPC support at all, so this returns nothing there.
        //
        // "Portraits - Npc" itself is the mod's own live NPC folder (created as the player meets
        // NPCs in-game), and the mod is available for both Kingmaker and WotR - so it belongs in
        // both games' Characters roots, alongside whatever else each game also has.
        private List<string> GetCharactersPortraitsRoots(string basePath)
        {
            var roots = new List<string>();
            if (_gameSelected == 'k')
            {
                roots.Add(Path.Combine(basePath, "Portraits - All Additions"));
                roots.Add(Path.Combine(basePath, "Portraits - Npc"));
            }
            else if (_gameSelected == 'w')
            {
                roots.Add(Path.Combine(basePath, "Portraits - Npc"));
                roots.Add(Path.Combine(basePath, "Portraits - Army"));
                roots.Add(Path.Combine(basePath, "Portraits - Tactical"));
            }
            return roots;
        }

        private void BackupNonPlayerPortraitSet(string entryPath)
        {
            string dir = Path.GetDirectoryName(entryPath);
            string prefix = Path.GetFileName(entryPath);
            string[] suffixes = { "_lg", "_sm", "_si", "_convo" };
            foreach (string suf in suffixes)
            {
                string srcPath = Path.Combine(dir, prefix + suf + ".png");
                string backupPath = srcPath + ".backup";
                if (File.Exists(srcPath) && !File.Exists(backupPath))
                {
                    try { File.Copy(srcPath, backupPath, overwrite: false); }
                    catch { }
                }
            }
        }

        // These games have no mod keeping a separate original copy, so BackupNonPlayerPortraitSet
        // makes our own ".backup" of the game's shipped asset the first time it's about to be
        // replaced (and only that once). This looks up whichever one exists, same priority order.
        private string FindBestNonPlayerBackupImage(string entryPath)
        {
            string dir = Path.GetDirectoryName(entryPath);
            string prefix = Path.GetFileName(entryPath);
            string[] priority = { "_lg", "_sm", "_si", "_convo" };
            foreach (string suf in priority)
            {
                string path = Path.Combine(dir, prefix + suf + ".png.backup");
                if (File.Exists(path)) return path;
            }
            return null;
        }

        // Tyranny's "_lg" and "_sm" files are genuinely different native images (not just
        // different crops of one source) with visibly different aspect ratios - "_lg" is
        // 210x330, "_sm" is 76x96. Stretching one of them across every size box (the generic
        // approach every other non-player game still uses below) makes whichever box the
        // aspect actually mismatches show black bars once saved (and, worse, once the preview
        // itself started reflecting the true crop). Load each box from its own matching file
        // instead, same fix already applied to Deadfire's "_convo" vs "_lg" split above.
        private void LoadTyrannyGalleryIntoCreatePage(string folderPath, bool fromBackup)
        {
            string dir = Path.GetDirectoryName(folderPath);
            string prefix = Path.GetFileName(folderPath);
            string suffix = fromBackup ? ".png.backup" : ".png";

            try
            {
                string lgPath = Path.Combine(dir, prefix + "_lg" + suffix);
                if (File.Exists(lgPath))
                {
                    using (Image lgImg = Image.FromFile(lgPath))
                    {
                        Bitmap lgCopy = ImageControl.Direct.Resize(lgImg, lgImg.Width, lgImg.Height);
                        LoadImageIntoPortraitBox(PicKingLrg, lgCopy, PortraitGroupSelection.Large);
                    }
                }

                string smPath = Path.Combine(dir, prefix + "_sm" + suffix);
                bool smFallback = !File.Exists(smPath);
                if (smFallback) smPath = lgPath; // no dedicated small file - fall back rather than show nothing
                try
                {
                    string log =
                        $"[{DateTime.Now:HH:mm:ss.fff}] LoadTyrannyGalleryIntoCreatePage{Environment.NewLine}" +
                        $"  folderPath arg: {folderPath}{Environment.NewLine}" +
                        $"  dir={dir}  prefix={prefix}  fromBackup={fromBackup}{Environment.NewLine}" +
                        $"  smPath (final)={smPath}  smFallbackToLarge={smFallback}{Environment.NewLine}{Environment.NewLine}";
                    File.AppendAllText(Path.Combine(Path.GetTempPath(), "zpm_tyranny_debug.log"), log);
                }
                catch { }
                if (File.Exists(smPath))
                {
                    using (Image smImg = Image.FromFile(smPath))
                    {
                        Bitmap smCopy = ImageControl.Direct.Resize(smImg, smImg.Width, smImg.Height);
                        LoadImageIntoPortraitBox(PicKingSml, new Bitmap(smCopy), PortraitGroupSelection.Small);
                        LoadImageIntoPortraitBox(PicKingSml2, smCopy, PortraitGroupSelection.Sml2);
                    }
                }
            }
            catch { }
        }

        private void LoadNonPlayerBackupIntoCreatePage(string entryPath)
        {
            if (_gameSelected == 't')
            {
                LoadTyrannyGalleryIntoCreatePage(entryPath, fromBackup: true);
                return;
            }

            string bestFile = FindBestNonPlayerBackupImage(entryPath);
            if (bestFile == null) return;

            try
            {
                using (Image fileImg = Image.FromFile(bestFile))
                {
                    Bitmap copy = ImageControl.Direct.Resize(fileImg, fileImg.Width, fileImg.Height);

                    LoadImageIntoPortraitBox(PicKingLrg, new Bitmap(copy), PortraitGroupSelection.Large);

                    if (GameTypes.TryGetValue(_gameSelected, out var gt) &&
                        HasPortraitSpecific(gt, "MEDIUM_WIDTH") &&
                        HasPortraitSpecific(gt, "MEDIUM_HEIGHT"))
                    {
                        LoadImageIntoPortraitBox(PicKingMed, new Bitmap(copy), PortraitGroupSelection.Medium);
                    }

                    LoadImageIntoPortraitBox(PicKingSml, new Bitmap(copy), PortraitGroupSelection.Small);
                    LoadImageIntoPortraitBox(PicKingSml2, new Bitmap(copy), PortraitGroupSelection.Sml2);

                    copy.Dispose();
                }
            }
            catch { }
        }

        private void ButtonGalleryBack_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource?.Cancel();
            _activeMenuIndex = GetMainMenuIndexForCurrentGame();

            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutMainPage);
            Focus();
        }

        private void LabelGalleryTab_Paint(object sender, PaintEventArgs e)
        {
            if (_galleryTabSelected != "player") return;
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
            LabelGalleryTab.ForeColor = _galleryTabSelected == "player" ? gt.ForeColor : Color.White;
        }

        private void LabelGalleryTab_Click(object sender, EventArgs e)
        {
            if (_galleryTabSelected == "player") return;
            _galleryTabSelected = "player";
            _isCustomNpcMode = false;
            UpdateGalleryTabVisuals();
            _cancellationTokenSource?.Cancel();
            ClearGalleryEntries();
            LoadGalleryImages();
            UpdateGalleryRightPanel();
        }

        private void LabelGalleryNonPlayerTab_Paint(object sender, PaintEventArgs e)
        {
            if (_galleryTabSelected != "nonplayer") return;
            Color penColor = Color.White;
            try { penColor = GameTypes[_gameSelected].ForeColor; } catch { }
            using (var pen = new Pen(penColor))
            {
                int w = LabelGalleryNonPlayerTab.ClientSize.Width;
                int h = LabelGalleryNonPlayerTab.ClientSize.Height;
                e.Graphics.DrawLine(pen, 0, 0, w - 1, 0);
                e.Graphics.DrawLine(pen, 0, 0, 0, h - 1);
                e.Graphics.DrawLine(pen, w - 1, 0, w - 1, h - 1);
            }
        }

        private void LabelGalleryNonPlayerTab_MouseEnter(object sender, EventArgs e)
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gt)) return;
            LabelGalleryNonPlayerTab.ForeColor = gt.ForeColor;
        }

        private void LabelGalleryNonPlayerTab_MouseLeave(object sender, EventArgs e)
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gt)) return;
            LabelGalleryNonPlayerTab.ForeColor = _galleryTabSelected == "nonplayer" ? gt.ForeColor : Color.White;
        }

        private void LabelGalleryNonPlayerTab_Click(object sender, EventArgs e)
        {
            if (_galleryTabSelected == "nonplayer") return;
            _galleryTabSelected = "nonplayer";
            _isCustomNpcMode = false;
            UpdateGalleryTabVisuals();
            _cancellationTokenSource?.Cancel();
            ClearGalleryEntries();
            LoadGalleryImages();
            UpdateGalleryRightPanel();
        }

        private void LabelGalleryCustomNpcTab_Paint(object sender, PaintEventArgs e)
        {
            if (_galleryTabSelected != "customnpc") return;
            Color penColor = Color.White;
            try { penColor = GameTypes[_gameSelected].ForeColor; } catch { }
            using (var pen = new Pen(penColor))
            {
                int w = LabelGalleryCustomNpcTab.ClientSize.Width;
                int h = LabelGalleryCustomNpcTab.ClientSize.Height;
                e.Graphics.DrawLine(pen, 0, 0, w - 1, 0);
                e.Graphics.DrawLine(pen, 0, 0, 0, h - 1);
                e.Graphics.DrawLine(pen, w - 1, 0, w - 1, h - 1);
            }
        }

        private void LabelGalleryCustomNpcTab_MouseEnter(object sender, EventArgs e)
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gt)) return;
            LabelGalleryCustomNpcTab.ForeColor = gt.ForeColor;
        }

        private void LabelGalleryCustomNpcTab_MouseLeave(object sender, EventArgs e)
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gt)) return;
            LabelGalleryCustomNpcTab.ForeColor = _galleryTabSelected == "customnpc" ? gt.ForeColor : Color.White;
        }

        private void LabelGalleryCustomNpcTab_Click(object sender, EventArgs e)
        {
            if (_gameSelected == 'r') return;
            if (_galleryTabSelected == "customnpc") return;
            _galleryTabSelected = "customnpc";
            _isCustomNpcMode = true;
            UpdateGalleryTabVisuals();
            _cancellationTokenSource?.Cancel();
            ClearGalleryEntries();
            LoadGalleryImages();
            UpdateGalleryRightPanel();
        }

        private void LabelGalleryCompanionsTab_Paint(object sender, PaintEventArgs e)
        {
            if (_galleryTabSelected != "companions") return;
            Color penColor = Color.White;
            try { penColor = GameTypes[_gameSelected].ForeColor; } catch { }
            using (var pen = new Pen(penColor))
            {
                int w = LabelGalleryCompanionsTab.ClientSize.Width;
                int h = LabelGalleryCompanionsTab.ClientSize.Height;
                e.Graphics.DrawLine(pen, 0, 0, w - 1, 0);
                e.Graphics.DrawLine(pen, 0, 0, 0, h - 1);
                e.Graphics.DrawLine(pen, w - 1, 0, w - 1, h - 1);
            }
        }

        private void LabelGalleryCompanionsTab_MouseEnter(object sender, EventArgs e)
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gt)) return;
            LabelGalleryCompanionsTab.ForeColor = gt.ForeColor;
        }

        private void LabelGalleryCompanionsTab_MouseLeave(object sender, EventArgs e)
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gt)) return;
            LabelGalleryCompanionsTab.ForeColor = _galleryTabSelected == "companions" ? gt.ForeColor : Color.White;
        }

        private void LabelGalleryCompanionsTab_Click(object sender, EventArgs e)
        {
            if (_galleryTabSelected == "companions") return;
            _galleryTabSelected = "companions";
            _isCustomNpcMode = false;
            UpdateGalleryTabVisuals();
            _cancellationTokenSource?.Cancel();
            ClearGalleryEntries();
            LoadGalleryImages();
            UpdateGalleryRightPanel();
        }

        private void LabelGalleryCharactersTab_Paint(object sender, PaintEventArgs e)
        {
            if (_galleryTabSelected != "characters") return;
            Color penColor = Color.White;
            try { penColor = GameTypes[_gameSelected].ForeColor; } catch { }
            using (var pen = new Pen(penColor))
            {
                int w = LabelGalleryCharactersTab.ClientSize.Width;
                int h = LabelGalleryCharactersTab.ClientSize.Height;
                e.Graphics.DrawLine(pen, 0, 0, w - 1, 0);
                e.Graphics.DrawLine(pen, 0, 0, 0, h - 1);
                e.Graphics.DrawLine(pen, w - 1, 0, w - 1, h - 1);
            }
        }

        private void LabelGalleryCharactersTab_MouseEnter(object sender, EventArgs e)
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gt)) return;
            LabelGalleryCharactersTab.ForeColor = gt.ForeColor;
        }

        private void LabelGalleryCharactersTab_MouseLeave(object sender, EventArgs e)
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gt)) return;
            LabelGalleryCharactersTab.ForeColor = _galleryTabSelected == "characters" ? gt.ForeColor : Color.White;
        }

        private void LabelGalleryCharactersTab_Click(object sender, EventArgs e)
        {
            if (_galleryTabSelected == "characters") return;
            _galleryTabSelected = "characters";
            _isCustomNpcMode = false;
            UpdateGalleryTabVisuals();
            _cancellationTokenSource?.Cancel();
            ClearGalleryEntries();
            LoadGalleryImages();
            UpdateGalleryRightPanel();
        }

        private void UpdateGalleryTabVisuals()
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gt)) return;
            Color gameBack = gt.BackColor;
            Color gameFore = gt.ForeColor;

            LabelGalleryTab.BackColor = _galleryTabSelected == "player" ? gameBack : Color.Transparent;
            LabelGalleryTab.ForeColor = _galleryTabSelected == "player" ? gameFore : Color.White;
            LabelGalleryTab.Invalidate();

            LabelGalleryNonPlayerTab.BackColor = _galleryTabSelected == "nonplayer" ? gameBack : Color.Transparent;
            LabelGalleryNonPlayerTab.ForeColor = _galleryTabSelected == "nonplayer" ? gameFore : Color.White;
            LabelGalleryNonPlayerTab.Invalidate();

            LabelGalleryCustomNpcTab.BackColor = _galleryTabSelected == "customnpc" ? gameBack : Color.Transparent;
            LabelGalleryCustomNpcTab.ForeColor = _galleryTabSelected == "customnpc" ? gameFore : Color.White;
            LabelGalleryCustomNpcTab.Invalidate();

            LabelGalleryCompanionsTab.BackColor = _galleryTabSelected == "companions" ? gameBack : Color.Transparent;
            LabelGalleryCompanionsTab.ForeColor = _galleryTabSelected == "companions" ? gameFore : Color.White;
            LabelGalleryCompanionsTab.Invalidate();

            LabelGalleryCharactersTab.BackColor = _galleryTabSelected == "characters" ? gameBack : Color.Transparent;
            LabelGalleryCharactersTab.ForeColor = _galleryTabSelected == "characters" ? gameFore : Color.White;
            LabelGalleryCharactersTab.Invalidate();

            if (_galleryTabSelected == "companions" || _galleryTabSelected == "characters")
            {
                LabelGalleryCredit.Text = TextVariables.MESG_GALLERY_CUSTOMNPC_CREDIT;
                LabelGalleryCredit.Visible = true;
            }
            else
            {
                LabelGalleryCredit.Visible = false;
            }
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
                Label activeTab;
                if (_galleryTabSelected == "nonplayer")
                    activeTab = LabelGalleryNonPlayerTab;
                else if (_galleryTabSelected == "customnpc")
                    activeTab = LabelGalleryCustomNpcTab;
                else if (_galleryTabSelected == "companions")
                    activeTab = LabelGalleryCompanionsTab;
                else if (_galleryTabSelected == "characters")
                    activeTab = LabelGalleryCharactersTab;
                else
                    activeTab = LabelGalleryTab;
                if (activeTab.Visible)
                {
                    try
                    {
                        var lblScreen = activeTab.PointToScreen(Point.Empty);
                        var lblInGroup = group.PointToClient(lblScreen);
                        gapStart = lblInGroup.X;
                        gapEnd = lblInGroup.X + activeTab.Width;
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
            bool hasEntries = _galleryEntries != null && _galleryEntries.Count > 0;

            if (string.IsNullOrEmpty(_selectedGalleryEntry))
            {
                ButtonGalleryDelete.Visible = false;
                ButtonGalleryClone.Visible = false;
                ButtonGalleryChange.Visible = false;
                ButtonGalleryShowFolder.Visible = true;
                ButtonGalleryBack.Visible = true;
                // NOTE: every row here is a Percent-type RowStyle (see Designer.cs) and must
                // stay that way - only ever adjust .Height, never replace the RowStyle objects
                // (that previously mutated SizeType to AutoSize/Absolute and broke every other
                // tab's layout afterward, since they all assume Percent sizing persists).
                LayoutGalleryRight.RowStyles[0].Height = 0;
                LayoutGalleryRight.RowStyles[1].Height = 0;
                LayoutGalleryRight.RowStyles[2].Height = 0;
                LayoutGalleryRight.RowStyles[3].Height = 0;
                LayoutGalleryRight.RowStyles[4].Height = 50;
                LayoutGalleryRight.RowStyles[5].Height = 50;
            }
            else
            {
                // "nonplayer" (Tyranny's Companions/close-NPCs) is the game's own shipped asset
                // file, not something this app created - same reasoning as Companions/Characters
                // for Kingmaker/WotR: no casual permanent-delete button for content that isn't
                // ours, especially since deleting here would also remove its one-time backup.
                bool showDelete = !_isCustomNpcMode && _galleryTabSelected != "companions" &&
                                   _galleryTabSelected != "characters" && _galleryTabSelected != "nonplayer";
                ButtonGalleryDelete.Visible = showDelete;
                ButtonGalleryClone.Visible = hasEntries;
                ButtonGalleryChange.Visible = hasEntries;
                ButtonGalleryShowFolder.Visible = false;
                ButtonGalleryBack.Visible = true;
                LayoutGalleryRight.RowStyles[0].Height = 0;
                if (showDelete)
                {
                    LayoutGalleryRight.RowStyles[1].Height = 29;
                    LayoutGalleryRight.RowStyles[2].Height = 29;
                    LayoutGalleryRight.RowStyles[3].Height = 28;
                }
                else
                {
                    // Delete's row is hidden here (Companions/Characters) - give its share to
                    // Clone and Change instead of leaving an empty gap.
                    LayoutGalleryRight.RowStyles[1].Height = 43;
                    LayoutGalleryRight.RowStyles[2].Height = 43;
                    LayoutGalleryRight.RowStyles[3].Height = 0;
                }
                LayoutGalleryRight.RowStyles[4].Height = 0;
                LayoutGalleryRight.RowStyles[5].Height = 14;
            }

            UpdateGalleryOverlay();
        }

        private void UpdateGalleryOverlay()
        {
            if (_galleryTabSelected != "customnpc" && _galleryTabSelected != "characters")
            {
                if (_panelGalleryOverlay != null)
                    _panelGalleryOverlay.Visible = false;
                return;
            }

            bool hasEntries = _galleryEntries != null && _galleryEntries.Count > 0;
            if (hasEntries)
            {
                if (_panelGalleryOverlay != null)
                    _panelGalleryOverlay.Visible = false;
                return;
            }

            if (_panelGalleryOverlay == null)
            {
                _panelGalleryOverlay = new Panel
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.Transparent
                };
                _panelGalleryOverlay.Paint += PanelGalleryOverlay_Paint;
                PanelGalleryContainer.Controls.Add(_panelGalleryOverlay);
                _panelGalleryOverlay.BringToFront();
            }

            _panelGalleryOverlay.Visible = true;
        }

        private void PanelGalleryOverlay_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            Rectangle rect = panel.ClientRectangle;

            string title = _galleryTabSelected == "characters" ? "Characters" : "CustomNPC";
            string hint1 = "NPC must be met in-game first. Folder name = exact NPC dialog name.";
            string hint2 = "Use the folder button below to open Portraits - Npc directly.";

            using (Font titleFont = new Font(_fontCollection.Families[0], 22))
            using (Font hintFont = new Font(_fontCollection.Families[0], 12))
            {
                TextFormatFlags tf = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;

                Size titleSize = TextRenderer.MeasureText(e.Graphics, title, titleFont,
                    new Size(rect.Width, 0), tf);
                Size hint1Size = TextRenderer.MeasureText(e.Graphics, hint1, hintFont,
                    new Size(rect.Width, 0), tf);
                Size hint2Size = TextRenderer.MeasureText(e.Graphics, hint2, hintFont,
                    new Size(rect.Width, 0), tf);

                int totalHeight = titleSize.Height + 20 + hint1Size.Height + 6 + hint2Size.Height;
                int yStart = (rect.Height - totalHeight) / 2;

                Rectangle titleRect = new Rectangle(0, yStart, rect.Width, titleSize.Height);
                TextRenderer.DrawText(e.Graphics, title, titleFont, titleRect, Color.White, tf);

                Rectangle hint1Rect = new Rectangle(0, yStart + titleSize.Height + 20, rect.Width, hint1Size.Height);
                TextRenderer.DrawText(e.Graphics, hint1, hintFont, hint1Rect, Color.Gray, tf);

                Rectangle hint2Rect = new Rectangle(0, yStart + titleSize.Height + 20 + hint1Size.Height + 6,
                    rect.Width, hint2Size.Height);
                TextRenderer.DrawText(e.Graphics, hint2, hintFont, hint2Rect, Color.Gray, tf);
            }
        }

        // This app never creates its own backup copies of a CustomNpcPortraits-mod-managed
        // folder (Companions or Characters/Portraits - Npc) - the mod already keeps one, at
        // "<folder>\Backup of Game Default Portraits\*.png", so there's no need for a second,
        // parallel one. This just looks up the mod's own backup image.
        private string FindModDefaultBackupImage(string folderPath)
        {
            if (string.IsNullOrEmpty(folderPath)) return null;
            string backupDir = Path.Combine(folderPath, "Backup of Game Default Portraits");
            if (!Directory.Exists(backupDir)) return null;

            string[] files;
            try { files = Directory.GetFiles(backupDir, "*.png"); }
            catch { return null; }

            return files.FirstOrDefault(f => Path.GetFileName(f).Equals("Fulllength.png", StringComparison.OrdinalIgnoreCase))
                ?? files.FirstOrDefault(f => Path.GetFileName(f).Equals("Medium.png", StringComparison.OrdinalIgnoreCase))
                ?? files.FirstOrDefault(f => Path.GetFileName(f).Equals("Small.png", StringComparison.OrdinalIgnoreCase))
                ?? files.FirstOrDefault();
        }

        private bool HasModDefaultBackup(string folderPath)
        {
            return FindModDefaultBackupImage(folderPath) != null;
        }

        private void LoadBackupImageIntoCreatePage(string folderPath)
        {
            string bestFile = FindModDefaultBackupImage(folderPath);
            if (bestFile == null) return;

            try
            {
                using (Image fileImg = Image.FromFile(bestFile))
                {
                    Bitmap copy = ImageControl.Direct.Resize(fileImg, fileImg.Width, fileImg.Height);

                    LoadImageIntoPortraitBox(PicKingLrg, new Bitmap(copy), PortraitGroupSelection.Large);

                    if (GameTypes.TryGetValue(_gameSelected, out var gt) &&
                        HasPortraitSpecific(gt, "MEDIUM_WIDTH") &&
                        HasPortraitSpecific(gt, "MEDIUM_HEIGHT"))
                    {
                        LoadImageIntoPortraitBox(PicKingMed, new Bitmap(copy), PortraitGroupSelection.Medium);
                    }

                    LoadImageIntoPortraitBox(PicKingSml, new Bitmap(copy), PortraitGroupSelection.Small);
                    LoadImageIntoPortraitBox(PicKingSml2, new Bitmap(copy), PortraitGroupSelection.Sml2);

                    copy.Dispose();
                }
            }
            catch { }
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
            if (_isCustomNpcMode) return;
            using (var dlg = new forms.MyInquiryDialog("Delete this portrait set?"))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    _cancellationTokenSource?.Cancel();
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

        private void ButtonGalleryShowFolder_Click(object sender, EventArgs e)
        {
            string gameDir;
            if (_galleryTabSelected == "nonplayer" && (_gameSelected == 't' || _gameSelected == 'p' || _gameSelected == 'd'))
            {
                string basePath = CoreSettings.Default.GamePath;
                if (!string.IsNullOrEmpty(basePath))
                    gameDir = GetNonPlayerPortraitsRoot(basePath);
                else
                    gameDir = null;
            }
            else if (_isCustomNpcMode)
            {
                string basePath = CoreSettings.Default.GamePath;
                if (!string.IsNullOrEmpty(basePath))
                    gameDir = GetCustomNpcPortraitsDir(basePath);
                else
                    gameDir = null;
            }
            else if (_galleryTabSelected == "characters")
            {
                // With "New NPC +" removed, this is now the only way to reach Portraits - Npc
                // from the Characters tab (e.g. to manually create/inspect an NPC folder before
                // meeting them in-game triggers the mod to do it).
                string basePath = CoreSettings.Default.GamePath;
                gameDir = !string.IsNullOrEmpty(basePath) ? GetCustomNpcPortraitsDir(basePath) : null;
            }
            else
            {
                gameDir = GetGameDirectory();
            }

            if (string.IsNullOrEmpty(gameDir))
            {
                using (var msg = new forms.MyMessageDialog("Could not determine the game directory."))
                {
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog(this);
                }
                return;
            }
            Process.Start("explorer.exe", gameDir);
        }

        private void ButtonGalleryShowFolder_MouseEnter(object sender, EventArgs e)
        {
            Color selBack = Color.Black, selFore = Color.White;
            try { selBack = GameTypes[_gameSelected].BackColor; selFore = GameTypes[_gameSelected].ForeColor; } catch { }
            ButtonGalleryShowFolder.BackColor = selFore;
            ButtonGalleryShowFolder.ForeColor = selBack;
        }

        private void ButtonGalleryShowFolder_MouseLeave(object sender, EventArgs e)
        {
            Color selBack = Color.Black, selFore = Color.White;
            try { selBack = GameTypes[_gameSelected].BackColor; selFore = GameTypes[_gameSelected].ForeColor; } catch { }
            ButtonGalleryShowFolder.BackColor = selBack;
            ButtonGalleryShowFolder.ForeColor = selFore;
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
            //ClearImageListsSync(ListGallery, ImgListGallery);
            //ClearImageListsSync(ListExtract, ImgListExtract);
            SystemControl.FileControl.ClearTempImages();
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
                        using (var dlg = new forms.MyMessageDialog(TextVariables.MESG_PATH_NOT_FOUND))
                        {
                            dlg.StartPosition = FormStartPosition.CenterParent;
                            dlg.ShowDialog(this);
                        }
                        return;
                    }

                    selectedPath = selectedPath.Replace('/', '\\');

                    var dir = new DirectoryInfo(selectedPath);
                    while (dir != null &&
                            !dir.Name.Equals("Pathfinder Kingmaker", StringComparison.OrdinalIgnoreCase))
                        dir = dir.Parent;

                    if (dir == null || dir.Parent == null ||
                        !dir.Parent.Name.Equals("Owlcat Games", StringComparison.OrdinalIgnoreCase))
                    {
                        // A game install directory (e.g. the Steam/GOG copy) commonly shares the exact
                        // same folder name "Pathfinder Kingmaker" as the real LocalLow save-data root.
                        // Only the latter sits directly under "...\LocalLow\Owlcat Games\", so require
                        // that parentage to avoid silently managing a folder the game never reads.
                        using (var dlg = new forms.MyMessageDialog(string.Format(TextVariables.MESG_PATH_WRONG_ROOT, "Pathfinder Kingmaker")))
                        {
                            dlg.StartPosition = FormStartPosition.CenterParent;
                            dlg.ShowDialog(this);
                        }
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
                        using (var dlg = new forms.MyMessageDialog(TextVariables.MESG_PATH_NOT_FOUND))
                        {
                            dlg.StartPosition = FormStartPosition.CenterParent;
                            dlg.ShowDialog();
                        }
                        return;
                    }

                    selectedPath = selectedPath.Replace('/', '\\');

                    var dir = new DirectoryInfo(selectedPath);
                    while (dir != null &&
                            !dir.Name.Equals("Pathfinder Wrath Of The Righteous", StringComparison.OrdinalIgnoreCase))
                        dir = dir.Parent;

                    if (dir == null || dir.Parent == null ||
                        !dir.Parent.Name.Equals("Owlcat Games", StringComparison.OrdinalIgnoreCase))
                    {
                        // Same reasoning as Kingmaker: the game's Steam/GOG install directory
                        // commonly shares the exact folder name "Pathfinder Wrath Of The
                        // Righteous" with the real LocalLow save-data root. Only the latter sits
                        // directly under "...\LocalLow\Owlcat Games\".
                        using (var dlg = new forms.MyMessageDialog(string.Format(TextVariables.MESG_PATH_WRONG_ROOT, "Pathfinder Wrath Of The Righteous")))
                        {
                            dlg.StartPosition = FormStartPosition.CenterParent;
                            dlg.ShowDialog(this);
                        }
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
                        using (var dlg = new forms.MyMessageDialog(TextVariables.MESG_PATH_NOT_FOUND))
                        {
                            dlg.StartPosition = FormStartPosition.CenterParent;
                            dlg.ShowDialog(this);
                        }
                        return;
                    }

                    selectedPath = selectedPath.Replace('/', '\\');

                    var dir = new DirectoryInfo(selectedPath);
                    while (dir != null &&
                            !dir.Name.Equals("Warhammer 40000 Rogue Trader", StringComparison.OrdinalIgnoreCase))
                        dir = dir.Parent;

                    if (dir == null || dir.Parent == null ||
                        !dir.Parent.Name.Equals("Owlcat Games", StringComparison.OrdinalIgnoreCase))
                    {
                        // Same reasoning as Kingmaker/WotR: the game's Steam/GOG install directory
                        // commonly shares the exact folder name "Warhammer 40000 Rogue Trader" with
                        // the real LocalLow save-data root. Only the latter sits directly under
                        // "...\LocalLow\Owlcat Games\".
                        using (var dlg = new forms.MyMessageDialog(string.Format(TextVariables.MESG_PATH_WRONG_ROOT, "Warhammer 40000 Rogue Trader")))
                        {
                            dlg.StartPosition = FormStartPosition.CenterParent;
                            dlg.ShowDialog(this);
                        }
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
                        using (var dlg = new forms.MyMessageDialog(TextVariables.MESG_PATH_NOT_FOUND))
                        {
                            dlg.StartPosition = FormStartPosition.CenterParent;
                            dlg.ShowDialog(this);
                        }
                        return;
                    }

                    var dir = new DirectoryInfo(selectedPath);
                    while (dir != null && !dir.Name.Equals("Tyranny", StringComparison.OrdinalIgnoreCase))
                        dir = dir.Parent;
                    if (dir == null)
                    {
                        using (var dlg = new forms.MyMessageDialog(TextVariables.MESG_PATH_NOT_FOUND))
                        {
                            dlg.StartPosition = FormStartPosition.CenterParent;
                            dlg.ShowDialog(this);
                        }
                        return;
                    }

                    string rootPath = dir.FullName + Path.DirectorySeparatorChar;
                    // Tyranny has no separate "install dir vs. save-data dir" split like the
                    // Owlcat/Wasteland games - Data lives directly inside whatever folder
                    // the player installed the game into, so there's no LocalLow/Documents
                    // sibling to confuse it with. Verifying real game content (an actual data
                    // folder with real assets) instead of just a folder name is the correct
                    // check here, and was already in place.
                    string checkPath = Path.Combine(rootPath, "Data", "data", "art", "gui", "icons", "abilities");

                    if (!Directory.Exists(checkPath))
                    {
                        using (var dlg = new forms.MyMessageDialog(TextVariables.MESG_PATH_NOT_FOUND))
                        {
                            dlg.StartPosition = FormStartPosition.CenterParent;
                            dlg.ShowDialog(this);
                        }
                        return;
                    }

                    string maleDir = Path.Combine(rootPath, "Data", "data", "art", "gui", "portraits", "player", "male");
                    string femaleDir = Path.Combine(rootPath, "Data", "data", "art", "gui", "portraits", "player", "female");
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
                        using (var dlg = new forms.MyMessageDialog(TextVariables.MESG_PATH_NOT_FOUND))
                        {
                            dlg.StartPosition = FormStartPosition.CenterParent;
                            dlg.ShowDialog(this);
                        }
                        return;
                    }

                    var dir = new DirectoryInfo(selectedPath);
                    while (dir != null && !dir.Name.Equals("Wasteland3", StringComparison.OrdinalIgnoreCase))
                        dir = dir.Parent;

                    if (dir == null || dir.Parent == null ||
                        !dir.Parent.Name.Equals("My Games", StringComparison.OrdinalIgnoreCase))
                    {
                        // Same reasoning as the Owlcat games: Wasteland 3's Steam/GOG install
                        // directory is also commonly named "Wasteland3", same as the real
                        // Documents\My Games\Wasteland3 save-data root. Only the latter sits
                        // directly under "...\Documents\My Games\".
                        using (var dlg = new forms.MyMessageDialog(string.Format(TextVariables.MESG_PATH_WRONG_ROOT_DOCUMENTS, "Wasteland3")))
                        {
                            dlg.StartPosition = FormStartPosition.CenterParent;
                            dlg.ShowDialog(this);
                        }
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
            SetKingPortraitGroup(PortraitGroupSelection.Large);
            AdjustActivePortraitPanelAspect(PortraitGroupSelection.Medium);
            AdjustActivePortraitPanelAspect(PortraitGroupSelection.Small);
            AdjustActivePortraitPanelAspect(PortraitGroupSelection.Sml2);
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

            _groupLrgInitialized = false;
            _groupSmlInitialized = false;
            _groupSml2Initialized = false;

            bool hasMed = HasPortraitSpecific(gameType, "MEDIUM_WIDTH") &&
                          HasPortraitSpecific(gameType, "MEDIUM_HEIGHT");

            if (hasMed)
            {
                StoreOriginalImage(PicKingMed, new Bitmap(gameType.PlaceholderPortrait));
                _groupMedInitialized = false;
            }
            else
            {
                _groupMedInitialized = true; // mark as initialized so EnsureKingGroup skips it
            }

            // Enable drag-and-drop onto each portrait PictureBox (file or URL text)
            WirePortraitDragDrop(PicKingLrg);
            WirePortraitDragDrop(PicKingSml);
            WirePortraitDragDrop(PicKingSml2);
            if (hasMed)
                WirePortraitDragDrop(PicKingMed);

            AdjustActivePortraitPanelAspect(PortraitGroupSelection.Large);
            EnsureKingGroupInitialized(PortraitGroupSelection.Large);
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
                int newHeight = (int)staticHeight;

                // PanelKingSml's cell in LayoutKingPortraitGroupSmall uses a Percent column,
                // which clamps the panel's width to whatever fraction of the row's current
                // total width that percentage computes to, regardless of Anchor/Dock -
                // requesting a wider Size than the cell allows just gets silently shrunk back
                // down, and Tyranny's Small portrait (76x96) needs more width relative to its
                // height than that percent column happens to allow at this container size, so
                // the panel ended up shorter/wider than 76:96 and produced a crop/target
                // aspect mismatch (visible as black bars). Rather than fight the column
                // (widening it squeezes the sibling button panel), shrink to fit within
                // whatever width the cell already provides, keeping the same 76:96 ratio -
                // i.e. maximize inside the available cell instead of overflowing it.
                if (_gameSelected == 't' && panel.Name == "PanelKingSml")
                {
                    int availableWidth = panel.Width;
                    if (availableWidth > 0 && newWidth > availableWidth)
                    {
                        newWidth = availableWidth;
                        newHeight = (int)Math.Round(availableWidth * ar);
                    }
                }

                panel.Size = new Size(newWidth, newHeight);

                if (_gameSelected == 't' && panel.Name == "PanelKingSml")
                {
                    try
                    {
                        string log =
                            $"[{DateTime.Now:HH:mm:ss.fff}] AdjustPortraitPanelAspect(PanelKingSml){Environment.NewLine}" +
                            $"  ar={ar:F5} staticHeight={staticHeight}  ->  newWidth={newWidth}  panel.Size after set={panel.Size}  panel.ClientSize after set={panel.ClientSize}{Environment.NewLine}{Environment.NewLine}";
                        File.AppendAllText(Path.Combine(Path.GetTempPath(), "zpm_tyranny_debug.log"), log);
                    }
                    catch { }
                }
            }
            finally
            {
                panel.ResumeLayout();
            }
        }

        private void AdjustActivePortraitPanelAspect(PortraitGroupSelection selection)
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gameType)) return;

            if (selection == PortraitGroupSelection.Large)
            {
                if (!HasPortraitSpecific(gameType, "LARGE_WIDTH")) return;
                AdjustPortraitPanelAspect(
                    PanelKingLrg,
                    GetPortraitSpecificOrDefault(gameType, "LARGE_AR", 1.3f),
                    360f);
            }
            else if (selection == PortraitGroupSelection.Medium)
            {
                if (HasPortraitSpecific(gameType, "MEDIUM_WIDTH"))
                {
                    AdjustPortraitPanelAspect(
                        PanelKingMed,
                        GetPortraitSpecificOrDefault(gameType, "MEDIUM_AR", 1.3f),
                        360f);
                }
            }
            else if (selection == PortraitGroupSelection.Small)
            {
                if (!HasPortraitSpecific(gameType, "SMALL_WIDTH")) return;
                float smlHeight = (_gameSelected == 'l') ? 256f : 360f;
                AdjustPortraitPanelAspect(
                    PanelKingSml,
                    GetPortraitSpecificOrDefault(gameType, "SMALL_AR", 1.4f),
                    smlHeight);
            }
            else if (selection == PortraitGroupSelection.Sml2)
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

        private void EnsureKingGroupInitialized(PortraitGroupSelection selection)
        {
            if (selection == PortraitGroupSelection.Large)
            {
                if (_groupLrgInitialized) return;
                FitPictureToPanel(PicKingLrg, PanelKingLrg);
                _groupLrgInitialized = true;
            }
            else if (selection == PortraitGroupSelection.Medium)
            {
                if (_groupMedInitialized) return;
                FitPictureToPanel(PicKingMed, PanelKingMed);
                _groupMedInitialized = true;
            }
            else if (selection == PortraitGroupSelection.Small)
            {
                if (_groupSmlInitialized) return;
                FitPictureToPanel(PicKingSml, PanelKingSml);
                _groupSmlInitialized = true;
            }
            else if (selection == PortraitGroupSelection.Sml2)
            {
                if (_groupSml2Initialized) return;
                FitPictureToPanel(PicKingSml2, PanelKingSml2);
                _groupSml2Initialized = true;
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
            SetKingPortraitGroup(PortraitGroupSelection.Large);
        }

        private void LabelKingCreatePortraitMedium_Click(object sender, EventArgs e)
        {
            SetKingPortraitGroup(PortraitGroupSelection.Medium);
        }

        private void LabelKingCreatePortraitSmall_Click(object sender, EventArgs e)
        {
            SetKingPortraitGroup(PortraitGroupSelection.Small);
        }

        private void LabelKingCreatePortraitSml2_Click(object sender, EventArgs e)
        {
            SetKingPortraitGroup(PortraitGroupSelection.Sml2);
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

        private void SetKingPortraitGroup(PortraitGroupSelection selection)
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
                LayoutKingPortraitGroupLarge.Visible = selection == PortraitGroupSelection.Large;
                LayoutKingPortraitGroupMedium.Visible = selection == PortraitGroupSelection.Medium;
                LayoutKingPortraitGroupSmall.Visible = selection == PortraitGroupSelection.Small;
                LayoutKingPortraitGroupSml2.Visible = selection == PortraitGroupSelection.Sml2;
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
                (selection == PortraitGroupSelection.Large && hasLarge) ||
                (selection == PortraitGroupSelection.Medium && hasMedium) ||
                (selection == PortraitGroupSelection.Small && hasSmall) ||
                (selection == PortraitGroupSelection.Sml2 && hasSml2);

            if (!selectionAvailable)
            {
                if (hasSmall) selection = PortraitGroupSelection.Small;
                else if (hasSml2) selection = PortraitGroupSelection.Sml2;
                else if (hasMedium) selection = PortraitGroupSelection.Medium;
                else if (hasLarge) selection = PortraitGroupSelection.Large;
            }

            _activeKingPortraitGroup = selection;

            LayoutKingPortraitGroupLarge.Visible = hasLarge && selection == PortraitGroupSelection.Large;
            LayoutKingPortraitGroupMedium.Visible = hasMedium && selection == PortraitGroupSelection.Medium;
            LayoutKingPortraitGroupSmall.Visible = hasSmall && selection == PortraitGroupSelection.Small;
            LayoutKingPortraitGroupSml2.Visible = hasSml2 && selection == PortraitGroupSelection.Sml2;

            LayoutKingPortraitGroupLarge.BackColor = selection == PortraitGroupSelection.Large ? gameType.BackColor : Color.Transparent;
            LayoutKingPortraitGroupMedium.BackColor = selection == PortraitGroupSelection.Medium ? gameType.BackColor : Color.Transparent;
            LayoutKingPortraitGroupSmall.BackColor = selection == PortraitGroupSelection.Small ? gameType.BackColor : Color.Transparent;
            LayoutKingPortraitGroupSml2.BackColor = selection == PortraitGroupSelection.Sml2 ? gameType.BackColor : Color.Transparent;
            LayoutKingRight.BackColor = gameType.BackColor;
            LayoutKingRight.ForeColor = gameType.ForeColor;

            Color selBack = gameType.BackColor;
            Color selFore = gameType.ForeColor;

            LabelKingCreatePortraitLarge.Visible = hasLarge;
            LabelKingCreatePortraitLarge.BackColor = hasLarge && selection == PortraitGroupSelection.Large ? selBack : Color.Transparent;
            LabelKingCreatePortraitLarge.ForeColor = hasLarge && selection == PortraitGroupSelection.Large ? selFore : Color.White;
            LabelKingCreatePortraitMedium.Visible = hasMedium;
            LabelKingCreatePortraitMedium.BackColor = hasMedium && selection == PortraitGroupSelection.Medium ? selBack : Color.Transparent;
            LabelKingCreatePortraitMedium.ForeColor = hasMedium && selection == PortraitGroupSelection.Medium ? selFore : Color.White;
            LabelKingCreatePortraitSmall.Visible = hasSmall;
            LabelKingCreatePortraitSmall.BackColor = hasSmall && selection == PortraitGroupSelection.Small ? selBack : Color.Transparent;
            LabelKingCreatePortraitSmall.ForeColor = hasSmall && selection == PortraitGroupSelection.Small ? selFore : Color.White;
            LabelKingCreatePortraitSml2.Visible = hasSml2;
            LabelKingCreatePortraitSml2.BackColor = hasSml2 && selection == PortraitGroupSelection.Sml2 ? selBack : Color.Transparent;
            LabelKingCreatePortraitSml2.ForeColor = hasSml2 && selection == PortraitGroupSelection.Sml2 ? selFore : Color.White;
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
                    if (selection == PortraitGroupSelection.Medium)
                    {
                        FitPictureToPanel(PicKingMed, PanelKingMed);
                    }
                    else if (selection == PortraitGroupSelection.Small)
                    {
                        FitPictureToPanel(PicKingSml, PanelKingSml);
                    }
                    else if (selection == PortraitGroupSelection.Sml2)
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
            LabelKingCreatePortraitLarge.ForeColor = _activeKingPortraitGroup == PortraitGroupSelection.Large ? GameTypes[_gameSelected].ForeColor : Color.White;
        }

        private void LabelKingCreatePortraitMedium_MouseEnter(object sender, EventArgs e)
        {
            LabelKingCreatePortraitMedium.ForeColor = GameTypes[_gameSelected].ForeColor;
        }

        private void LabelKingCreatePortraitMedium_MouseLeave(object sender, EventArgs e)
        {
            LabelKingCreatePortraitMedium.ForeColor = _activeKingPortraitGroup == PortraitGroupSelection.Medium ? GameTypes[_gameSelected].ForeColor : Color.White;
        }

        private void LabelKingCreatePortraitSmall_MouseEnter(object sender, EventArgs e)
        {
            LabelKingCreatePortraitSmall.ForeColor = GameTypes[_gameSelected].ForeColor;
        }

        private void LabelKingCreatePortraitSmall_MouseLeave(object sender, EventArgs e)
        {
            LabelKingCreatePortraitSmall.ForeColor = _activeKingPortraitGroup == PortraitGroupSelection.Small ? GameTypes[_gameSelected].ForeColor : Color.White;
        }

        private void LabelKingCreatePortraitSml2_MouseEnter(object sender, EventArgs e)
        {
            LabelKingCreatePortraitSml2.ForeColor = GameTypes[_gameSelected].ForeColor;
        }

        private void LabelKingCreatePortraitSml2_MouseLeave(object sender, EventArgs e)
        {
            LabelKingCreatePortraitSml2.ForeColor = _activeKingPortraitGroup == PortraitGroupSelection.Sml2 ? GameTypes[_gameSelected].ForeColor : Color.White;
        }

    }
}
