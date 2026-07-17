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

using PortraitManager.sources;
using PortraitManager.Properties;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
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

        private PortraitGroupSelection _activeKingPortraitGroup = PortraitGroupSelection.Large;

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
    }
}
