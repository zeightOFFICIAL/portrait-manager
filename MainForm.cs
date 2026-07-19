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
    Copyright (C) 2023-2026 Artemii "Zeight" Saganenko.

    GPL-2.0 license terms are listed in LICENSE.md file.
    License header for this project is listed in Program.cs.
*/
using PortraitManager.sources;
using PortraitManager.Properties;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
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

        private static PrivateFontCollection _fontCollection;
        private static PrivateFontCollection _fontCollectionCyrillic;
        private static CancellationTokenSource _cancellationTokenSource;
        private Icon _defaultAppIcon;

        private static char _currentLanguage = 'e';
        private PictureBox _flagEng;
        private PictureBox _flagDe;
        private PictureBox _flagRus;
        private Button _galleryHelpButton;
        private string _customPortraitName;

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
            // English and German both use the Latin BebasNeue face; only Russian needs the Cyrillic-hinted variant.
            // Both are loaded once at startup — the gallery also renders Cyrillic folder names via _fontCollectionCyrillic
            // regardless of the currently selected UI language.
            if (_fontCollection == null)
                _fontCollection = SystemControl.FileControl.InitCustomFont(Resources.BebasNeue_Regular);
            if (_fontCollectionCyrillic == null)
                _fontCollectionCyrillic = SystemControl.FileControl.InitCustomFont(Resources.BebasNeue_Regular_RU);

            PrivateFontCollection activeFontCollection = (_currentLanguage == 'r') ? _fontCollectionCyrillic : _fontCollection;

            Font bebasNeueMainPage = new Font(activeFontCollection.Families[0], 44),
                 bebasNeueMainPage2 = new Font(activeFontCollection.Families[0], 30),
                 bebasNeueFullHeader = new Font(activeFontCollection.Families[0], 25),
                 bebasNeue22 = new Font(activeFontCollection.Families[0], 22),
                 bebasNeueHead = new Font(activeFontCollection.Families[0], 21),
                 bebasNeueUnder = new Font(activeFontCollection.Families[0], 17),
                 bebasNeueButton16 = new Font(activeFontCollection.Families[0], 16f),
                 bebasNeueZoom = new Font(activeFontCollection.Families[0], 14.85f),
                 bebasNeueMedium = new Font(activeFontCollection.Families[0], 13),
                 bebasNeue12 = new Font(activeFontCollection.Families[0], 12),
                 bebasNeue10 = new Font(activeFontCollection.Families[0], 10f),
                 bebasNeueSmall = new Font(activeFontCollection.Families[0], 9);

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
            ButtonKingCustomName.Font = new Font(activeFontCollection.Families[0], bebasNeueHead.Size * 0.7f);
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

            Font arialSmall = new Font(FontFamily.GenericSansSerif, 8f);
            Font arialSmallUnderline = new Font(FontFamily.GenericSansSerif, 8f, FontStyle.Underline);

            LabelSelectPathExplain.Font = new Font(FontFamily.GenericSansSerif, 12f * 0.8f);
            LabelSelectPathSelected.Font = new Font(FontFamily.GenericSansSerif, 8f * 1.5f);
            LabelMainPageFooter.Font = new Font(FontFamily.GenericSansSerif, 8f, FontStyle.Italic);
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
                LabelKingCreatePortraitLarge.Text = TextVariables.BUTTON_KINGCREATEPAGELRG_D;
                LabelKingCreatePortraitMedium.Text = TextVariables.BUTTON_KINGCREATEPAGEMID_D;
                LabelKingCreatePortraitSmall.Text = TextVariables.BUTTON_KINGCREATEPAGESML_D;
                LabelKingCreatePortraitSml2.Text = TextVariables.BUTTON_KINGCREATEPAGESML2_D;
            }
            else
            {
                LabelKingCreatePortraitLarge.Text = TextVariables.BUTTON_KINGCREATEPAGELRG;
                LabelKingCreatePortraitMedium.Text = TextVariables.BUTTON_KINGCREATEPAGEMID;
                LabelKingCreatePortraitSmall.Text = TextVariables.BUTTON_KINGCREATEPAGESML;
                LabelKingCreatePortraitSml2.Text = TextVariables.BUTTON_KINGCREATEPAGESML2;
            }

            ButtonKingCreateNewPortrait.Text = TextVariables.BUTTON_CREATE_NEW;
            RefreshCustomNameButtonText();
            ButtonKingBackToPathfinder.Text = TextVariables.BUTTON_BACK_TO_PATHFINDER;
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
            ButtonGalleryShowFolder.Text = TextVariables.BUTTON_GALLERY_SHOWFOLDER;

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
                zb.Text = TextVariables.ICON_ZOOM_IN;
            }
            var zoomOutButtons = new Button[] { ButtonKingLrgZoomOut, ButtonKingMedZoomOut, ButtonKingSmlZoomOut, ButtonKingSml2ZoomOut };
            foreach (var zb in zoomOutButtons)
            {
                if (zb == null) continue;
                zb.Text = TextVariables.ICON_ZOOM_OUT;
            }
            var zoomResetButtons = new Button[] { ButtonKingLrgZoomReset, ButtonKingMedZoomReset, ButtonKingSmlZoomReset, ButtonKingSml2ZoomReset };
            foreach (var zb in zoomResetButtons)
            {
                if (zb == null) continue;
                zb.Text = TextVariables.ICON_ZOOM_RESET;
            }
        }

        private void LanguageFlagsInit()
        {
            const int flagWidth = 20;
            const int flagHeight = 13;
            const int flagGap = 3;

            // Each flag is a fully opaque rectangular bitmap sized exactly to its PictureBox, so there is
            // no background chip behind them — they sit flush against the top-right corner of the Form,
            // directly on top of whichever Dock=Fill page panel is currently showing.
            _flagEng = new PictureBox
            {
                Size = new Size(flagWidth, flagHeight),
                Location = new Point(ClientSize.Width - flagWidth * 3 - flagGap * 2, 0),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Image = Resources.eng_flag,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Cursor = Cursors.Hand,
                Tag = 'e'
            };
            _flagDe = new PictureBox
            {
                Size = new Size(flagWidth, flagHeight),
                Location = new Point(ClientSize.Width - flagWidth * 2 - flagGap, 0),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Image = Resources.de_flag,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Cursor = Cursors.Hand,
                Tag = 'd'
            };
            _flagRus = new PictureBox
            {
                Size = new Size(flagWidth, flagHeight),
                Location = new Point(ClientSize.Width - flagWidth, 0),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Image = Resources.rus_flag,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Cursor = Cursors.Hand,
                Tag = 'r'
            };

            foreach (var flag in new[] { _flagEng, _flagDe, _flagRus })
            {
                flag.Click += FlagPictureBox_Click;
                flag.Paint += FlagPictureBox_Paint;
                Controls.Add(flag);
                flag.BringToFront();
            }

            RefreshFlagHighlight();
        }

        private void FlagPictureBox_Click(object sender, EventArgs e)
        {
            if (!(sender is PictureBox flag) || !(flag.Tag is char lang)) return;
            SetLanguage(lang);
        }

        private void FlagPictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (!(sender is PictureBox flag) || !(flag.Tag is char lang)) return;
            if (lang == _currentLanguage)
            {
                using (var pen = new Pen(Color.White, 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, flag.Width - 1, flag.Height - 1);
                }
            }
        }

        private void RefreshFlagHighlight()
        {
            foreach (var flag in new[] { _flagEng, _flagDe, _flagRus })
                flag?.Invalidate();
        }

        private static string GetPathExplainText(char gameSelected)
        {
            switch (gameSelected)
            {
                case 'w': return TextVariables.TEXT_EXPLAIN_PATH_WOTR;
                case 'r': return TextVariables.TEXT_EXPLAIN_PATH_ROGUE;
                case 'p': return TextVariables.TEXT_EXPLAIN_PATH_POE;
                case 'd': return TextVariables.TEXT_EXPLAIN_PATH_POED;
                case 't': return TextVariables.TEXT_EXPLAIN_PATH_TYR;
                case 'l': return TextVariables.TEXT_EXPLAIN_PATH_WASTE;
                default: return TextVariables.TEXT_EXPLAIN_PATH_KING;
            }
        }

        private static string GetGameDisplayName(char gameSelected)
        {
            switch (gameSelected)
            {
                case 'w': return TextVariables.NAME_WOTR;
                case 'r': return TextVariables.NAME_ROGUE;
                case 'p': return TextVariables.NAME_PILLARS;
                case 'd': return TextVariables.NAME_DEADFIRE;
                case 't': return TextVariables.NAME_TYR;
                case 'l': return TextVariables.NAME_WASTE;
                default: return TextVariables.NAME_KING;
            }
        }

        // Matches the per-game font size each LabelStartXXX_Click / LabelSelectPathNextToMain_Click handler
        // applies to LabelSelectPathTitle (longer names get a smaller size so they still fit the title area).
        private static float GetGameTitleFontSize(char gameSelected)
        {
            switch (gameSelected)
            {
                case 'w': return 22f;
                case 'r': return 25f;
                case 'd': return 27f;
                default: return 34f;
            }
        }

        private static string GetGalleryHelpText(char gameSelected)
        {
            switch (gameSelected)
            {
                case 'w': return TextVariables.GALLERY_HELP_WOTR;
                case 'r': return TextVariables.GALLERY_HELP_ROGUE;
                case 'p': return TextVariables.GALLERY_HELP_POE;
                case 'd': return TextVariables.GALLERY_HELP_POED;
                case 't': return TextVariables.GALLERY_HELP_TYR;
                case 'l': return TextVariables.GALLERY_HELP_WASTE;
                default: return TextVariables.GALLERY_HELP_KING;
            }
        }

        private void RefreshCustomNameButtonText()
        {
            ButtonKingCustomName.Text = string.IsNullOrEmpty(_customPortraitName)
                ? TextVariables.BUTTON_CUSTOM_NAME
                : _customPortraitName;
        }

        // Behaves exactly like ButtonKingCreateNewPortrait's own click, except it asks for a name first.
        // If the name is denied (cancelled, invalid, or a duplicate caught on re-check during creation),
        // ButtonKingAction_Create_Click's own early-return paths already show a MyMessageDialog and leave
        // the user on the Create Portrait page - nothing extra is needed here for that case.
        private void ButtonKingCustomName_Click(object sender, EventArgs e)
        {
            using (var dlg = new forms.MyNameDialog(_customPortraitName, IsCustomPortraitNameTaken))
            {
                dlg.StartPosition = FormStartPosition.CenterParent;
                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return;

                _customPortraitName = dlg.ChosenName;
                RefreshCustomNameButtonText();
            }

            ButtonKingAction_Create_Click(sender, e);
        }

        // Floats directly on the Form (not inside LayoutGalleryPage) so it isn't subject to the page's
        // TableLayoutPanel cell grid; visibility is tied to the page itself via VisibleChanged so it
        // shows and hides in step with Browse Gallery without touching every navigation handler.
        private void GalleryHelpButtonInit()
        {
            _galleryHelpButton = new Button
            {
                Size = new Size(24, 24),
                Location = new Point(8, 8),
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Text = "?",
                Font = new Font(_fontCollection.Families[0], 10f),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                TabStop = false,
                Visible = false
            };
            _galleryHelpButton.FlatAppearance.BorderSize = 1;
            _galleryHelpButton.Click += GalleryHelpButton_Click;

            Controls.Add(_galleryHelpButton);
            _galleryHelpButton.BringToFront();

            LayoutGalleryPage.VisibleChanged += (s, e) => _galleryHelpButton.Visible = LayoutGalleryPage.Visible;
        }

        private void GalleryHelpButton_Click(object sender, EventArgs e)
        {
            using (var dlg = new forms.MyMessageDialog(GetGalleryHelpText(_gameSelected)))
            {
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.ShowDialog(this);
            }
        }

        /// <summary>
        /// Switches the active UI language. Not auto-detected: the user always picks it explicitly by
        /// clicking a flag, or it is restored from the previously chosen value in CoreSettings.
        /// Resolving the culture's satellite resource assembly (and, for Russian, the Cyrillic font)
        /// touches disk on first use, so that lookup happens on a background thread; only the resulting
        /// property assignments run back on the UI thread via Invoke.
        /// </summary>
        private void SetLanguage(char lang, bool persist = true)
        {
            if (lang == _currentLanguage) return;

            foreach (var flag in new[] { _flagEng, _flagDe, _flagRus })
                if (flag != null) flag.Enabled = false;
            Cursor priorCursor = Cursor;
            Cursor = Cursors.WaitCursor;

            var thread = new Thread(() =>
            {
                CultureInfo culture = lang == 'd' ? new CultureInfo("de")
                                     : lang == 'r' ? new CultureInfo("ru")
                                     : CultureInfo.InvariantCulture;

                // Forces the satellite resource assembly for this culture to load off the UI thread.
                TextVariables.ResourceManager.GetResourceSet(culture, true, true);

                void ApplyLanguage()
                {
                    _currentLanguage = lang;
                    TextVariables.Culture = culture;

                    FontInit();
                    TextInit();
                    LabelSelectPathTitle.Text = GetGameDisplayName(_gameSelected);
                    LabelSelectPathTitle.Font = new Font(LabelSelectPathTitle.Font.FontFamily, GetGameTitleFontSize(_gameSelected), FontStyle.Regular);
                    LabelSelectPathExplain.Text = GetPathExplainText(_gameSelected);
                    UpdatePortraitButtonsStyle();
                    RefreshFlagHighlight();

                    if (persist)
                    {
                        CoreSettings.Default.Language = lang;
                        CoreSettings.Default.Save();
                    }

                    Cursor = priorCursor;
                    foreach (var flag in new[] { _flagEng, _flagDe, _flagRus })
                        if (flag != null) flag.Enabled = true;
                }

                if (IsHandleCreated)
                    Invoke((MethodInvoker)ApplyLanguage);
            })
            { IsBackground = true };
            thread.Start();
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
            _defaultAppIcon = Icon;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.Selectable, false);
            Application.AddMessageFilter(this);
        }
    }
}
