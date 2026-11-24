using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using PortraitManager.Properties;
using PortraitManager.sources;

namespace PortraitManager
{
    public partial class MainForm
    {
        private readonly Panel _cropHost = new Panel { Dock = DockStyle.Fill, Margin = Padding.Empty };
        private readonly Button _comparisonToggle = new Button
        {
            Name = "ButtonCompareCrops", Dock = DockStyle.Fill, Cursor = Cursors.Hand,
            FlatStyle = FlatStyle.Flat, BackColor = Color.Black, ForeColor = Color.White, TabStop = false
        };
        private TableLayoutPanel _comparisonRow;

        private void InitializeSideBySideEditor()
        {
            LayoutKingCreatePortrait.Controls.Remove(LayoutKingPortraitGroups);
            LayoutKingCreatePortrait.Controls.Add(_cropHost, 1, 2);
            _cropHost.Controls.Add(LayoutKingPortraitGroups);
            // Line up with the right column and sit on the panel like the slot tabs.
            _comparisonToggle.Margin = new Padding(LayoutKingRight.Margin.Left, 0, LayoutKingRight.Margin.Right, 6);
            LayoutKingCreatePortrait.Controls.Add(_comparisonToggle, 2, 1);
            _comparisonToggle.Click += (s, e) =>
            {
                if (_comparisonRow == null) OpenComparison();
                else CloseComparison();
            };
            LayoutKingCreatePortrait.VisibleChanged += (s, e) =>
            {
                if (!LayoutKingCreatePortrait.Visible) CloseComparison();
            };
        }

        private void OpenComparison()
        {
            if (!GameTypes.TryGetValue(_gameSelected, out GameType game) || _gameSelected == 'l') return;
            var selected = _activeKingPortraitGroup;
            _comparisonRow = new TableLayoutPanel
            {
                Name = "ComparisonRow", Dock = DockStyle.Fill, Margin = Padding.Empty,
                BackColor = game.BackColor, RowCount = 1, GrowStyle = TableLayoutPanelGrowStyle.AddColumns
            };
            _comparisonRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            _comparisonRow.Paint += (s, e) => DrawGroupBorder(_comparisonRow, e, null);
            _comparisonRow.SizeChanged += (s, e) => LayoutComparison();
            AddSlot(PortraitGroupSelection.Large, "LARGE", PicKingLrg, LabelKingCreatePortraitLarge);
            AddSlot(PortraitGroupSelection.Medium, "MEDIUM", PicKingMed, LabelKingCreatePortraitMedium);
            AddSlot(PortraitGroupSelection.Small, "SMALL", PicKingSml, LabelKingCreatePortraitSmall);
            AddSlot(PortraitGroupSelection.Sml2, "SML2", PicKingSml2, LabelKingCreatePortraitSml2);
            SetKingPortraitGroup(selected);

            _cropHost.Controls.Add(_comparisonRow);
            _comparisonRow.BringToFront();
            LayoutKingPortraitGroups.Visible = false;
            flowLayoutPanel1.Visible = false;
            RefreshComparisonAppearance();

            void AddSlot(PortraitGroupSelection selection, string key, PictureBox picture, Label tab)
            {
                if (!HasPortraitSpecific(game, key + "_WIDTH")) return;
                // A never-opened tab still has its designer bounds until WinForms
                // lays it out. Initialize it at the actual single-view size.
                SetKingPortraitGroup(selection);
                int column = _comparisonRow.Controls.Count;
                _comparisonRow.ColumnCount = column + 1;
                _comparisonRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1));
                var size = new Size((int)game.GetPortraitSpecific(key + "_WIDTH"), (int)game.GetPortraitSpecific(key + "_HEIGHT"));
                _comparisonRow.Controls.Add(new ComparisonPane(this, picture, tab, size), column, 0);
            }
        }

        private void CloseComparison()
        {
            if (_comparisonRow == null) return;
            var row = _comparisonRow;
            _comparisonRow = null;
            row.Dispose();
            LayoutKingPortraitGroups.Visible = true;
            flowLayoutPanel1.Visible = true;
            RefreshComparisonAppearance();
        }

        private void RefreshComparisonAppearance()
        {
            _comparisonToggle.Visible = GameTypes.TryGetValue(_gameSelected, out GameType game) && _gameSelected != 'l';
            if (game == null) return;
            StylePortraitButton(_comparisonToggle, game);
            _comparisonToggle.Font = ThemeFont(16);
            _comparisonToggle.Text = _comparisonRow == null ? TextVariables.SIDE_BY_SIDE : TextVariables.SINGLE_VIEW;
            if (_comparisonRow == null) return;
            _comparisonRow.BackColor = game.BackColor;
            int inset = UiPixels(6);
            _comparisonRow.Padding = new Padding(inset, inset, inset, inset);
            foreach (ComparisonPane pane in _comparisonRow.Controls) pane.RefreshAppearance(game);
            LayoutComparison();
            _comparisonRow.Invalidate();
        }

        // Size the preview row to the tallest frame the panes need, so short frames
        // (Deadfire's small slots) don't leave a gap above the buttons.
        private void LayoutComparison()
        {
            if (_comparisonRow == null || _comparisonRow.Controls.Count == 0) return;
            int title = UiPixels(34), dimensions = UiPixels(24), buttons = UiPixels(48);
            Size inner = _comparisonRow.DisplayRectangle.Size;
            int available = Math.Max(0, inner.Height - title - dimensions - buttons);
            int paneWidth = inner.Width / _comparisonRow.Controls.Count;
            int preview = 0;
            foreach (ComparisonPane pane in _comparisonRow.Controls)
            {
                int width = paneWidth - pane.Margin.Horizontal;
                preview = Math.Max(preview, (int)Math.Ceiling((double)width * pane.Output.Height / pane.Output.Width));
            }
            preview = Math.Min(preview, available);
            foreach (ComparisonPane pane in _comparisonRow.Controls)
                pane.SetRowHeights(title, dimensions, preview, buttons);
        }

        private Font ThemeFont(float points) => UiFont(
            (_currentLanguage == 'r' ? _fontCollectionCyrillic : _fontCollection).Families[0], points, cyrillic: _currentLanguage == 'r');

        // Same look as the single view's buttons (UpdatePortraitButtonsStyle), including the hover inversion.
        private void StylePortraitButton(Button button, GameType game)
        {
            bool hovered = button.ClientRectangle.Contains(button.PointToClient(Cursor.Position)) && button.Visible;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = game.ForeColor;
            button.FlatAppearance.MouseOverBackColor = game.ForeColor;
            button.FlatAppearance.MouseDownBackColor = game.ForeColor;
            button.BackColor = hovered ? game.ForeColor : game.BackColor;
            button.ForeColor = hovered ? game.BackColor : game.ForeColor;
            button.UseVisualStyleBackColor = false;
            button.TabStop = false;
            button.MouseEnter -= PortraitButton_MouseEnter;
            button.MouseLeave -= PortraitButton_MouseLeave;
            button.MouseEnter += PortraitButton_MouseEnter;
            button.MouseLeave += PortraitButton_MouseLeave;
        }

        // Each pane edits the original editor's picture bounds. Switching views and
        // exporting therefore use the same crop, including when slots use different images.
        private sealed class ComparisonPane : TableLayoutPanel
        {
            private readonly MainForm _editor;
            private readonly PictureBox _picture;
            private readonly Panel _viewport;
            private readonly Size _output;
            private readonly Label _tab;
            private readonly Label _title = new Label();
            private readonly Label _dimensions = new Label();
            private readonly PictureBox _canvas = new PictureBox();
            private Point _dragStart, _pictureStart;
            private SizeF _dragScale;
            private bool _dragging;

            public ComparisonPane(MainForm editor, PictureBox picture, Label tab, Size output)
            {
                _editor = editor;
                _picture = picture;
                _viewport = (Panel)picture.Parent;
                _tab = tab;
                _output = output;
                Name = "Compare" + picture.Name;
                Dock = DockStyle.Fill;
                ColumnCount = 1;
                // Spacer, title, dimensions, preview, buttons, spacer. LayoutComparison sets the
                // fixed rows so the content block is centered and lines up across panes.
                RowCount = 6;
                ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                RowStyles.Add(new RowStyle(SizeType.Percent, 50));
                for (int i = 0; i < 4; i++) RowStyles.Add(new RowStyle(SizeType.Absolute, 0));
                RowStyles.Add(new RowStyle(SizeType.Percent, 50));
                _title.TextAlign = ContentAlignment.BottomCenter;
                _dimensions.TextAlign = ContentAlignment.MiddleCenter;
                _dimensions.Text = $"{output.Width} × {output.Height}";
                _title.Dock = _dimensions.Dock = _canvas.Dock = DockStyle.Fill;
                Controls.Add(_title, 0, 1);
                Controls.Add(_dimensions, 0, 2);
                Controls.Add(_canvas, 0, 3);
                _canvas.Cursor = Cursors.SizeAll;
                _canvas.Paint += PaintCrop;
                _canvas.Resize += (s, e) => _canvas.Invalidate();
                _canvas.MouseDown += (s, e) =>
                {
                    if (e.Button != MouseButtons.Left || !GetPreviewGeometry(out Image image, out RectangleF source, out Rectangle destination)
                        || !destination.Contains(e.Location)) return;
                    _dragStart = e.Location;
                    _pictureStart = picture.Location;
                    _dragScale = new SizeF(source.Width * picture.ClientSize.Width / image.Width / destination.Width,
                                           source.Height * picture.ClientSize.Height / image.Height / destination.Height);
                    _canvas.Capture = true;
                    _dragging = true;
                };
                _canvas.MouseMove += (s, e) =>
                {
                    if (e.Button != MouseButtons.Left || !_dragging) return;
                    MoveTo(_pictureStart.X + (int)Math.Round((e.X - _dragStart.X) * _dragScale.Width),
                           _pictureStart.Y + (int)Math.Round((e.Y - _dragStart.Y) * _dragScale.Height));
                };
                _canvas.MouseCaptureChanged += (s, e) => _dragging = false;
                _canvas.MouseUp += (s, e) => _canvas.Capture = false;

                // Same buttons, order and icons as the single view's zoom row.
                _buttons.ColumnCount = 3;
                _buttons.RowCount = 1;
                _buttons.Dock = DockStyle.Fill;
                _buttons.Margin = Padding.Empty;
                for (int i = 0; i < 3; i++) _buttons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1));
                _buttons.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                Controls.Add(_buttons, 0, 4);
                AddButton("ZoomIn", () => Zoom(120, Center));
                AddButton("ZoomOut", () => Zoom(-120, Center));
                AddButton("ZoomReset", () => { editor.FitImageToPanel(picture); _canvas.Invalidate(); });
            }

            private readonly TableLayoutPanel _buttons = new TableLayoutPanel();

            public Size Output => _output;

            public void SetRowHeights(int title, int dimensions, int preview, int buttons)
            {
                RowStyles[1].Height = title;
                RowStyles[2].Height = dimensions;
                RowStyles[3].Height = preview;
                RowStyles[4].Height = buttons;
            }

            private Point Center => new Point(_viewport.Width / 2 - _picture.Left, _viewport.Height / 2 - _picture.Top);

            private void AddButton(string name, Action action)
            {
                var button = new Button { Name = name, Dock = DockStyle.Fill, Cursor = Cursors.Hand };
                button.Click += (s, e) => action();
                _buttons.Controls.Add(button, _buttons.Controls.Count, 0);
            }

            public void RefreshAppearance(GameType game)
            {
                BackColor = game.BackColor;
                ForeColor = game.ForeColor;
                _title.Text = _tab.Text.TrimStart('⍞', '⌻', '⌼', '▣', ' ');
                _title.Font = _editor.ThemeFont(18);
                _dimensions.Font = _editor.ThemeFont(12);
                // Four slots (Deadfire) leave narrow panes: tighten the gaps and the icon size so icons don't wrap.
                bool narrow = Parent != null && Parent.Controls.Count > 3;
                int gap = _editor.UiPixels(narrow ? 2 : 3);
                Margin = new Padding(gap, 0, gap, 0);
                _canvas.BackColor = game.BackColor;
                _buttons.Margin = new Padding(0, gap, 0, 0);
                foreach (Button button in _buttons.Controls)
                {
                    _editor.StylePortraitButton(button, game);
                    button.Font = _editor.ThemeFont(narrow ? 11f : 14.85f);
                    button.Margin = new Padding(gap, 0, gap, 0);
                    button.Padding = Padding.Empty;
                    button.Text = button.Name == "ZoomIn" ? TextVariables.ICON_ZOOM_IN
                                : button.Name == "ZoomOut" ? TextVariables.ICON_ZOOM_OUT : TextVariables.ICON_ZOOM_RESET;
                }
                _canvas.Invalidate();
            }

            // Top-aligned, so every frame in the row starts on the same line under its title.
            private Rectangle Frame
            {
                get
                {
                    var frame = ImageControl.PortraitCrop.FitInside(_output, _canvas.ClientRectangle);
                    frame.Y = 0;
                    return frame;
                }
            }

            private bool GetPreviewGeometry(out Image image, out RectangleF source, out Rectangle destination)
            {
                image = _editor.GetOriginalImage(_picture) ?? _picture.Image;
                bool fill = _gameSelected == 'k' || _gameSelected == 'w' || _gameSelected == 'r';
                source = image == null ? RectangleF.Empty : ImageControl.PortraitCrop.SourceRegion(image, _picture, _viewport, _output, fill, _editor.IntendedFrame(_viewport));
                destination = Frame;
                var size = Size.Round(source.Size);
                if (size.Width <= 0 || size.Height <= 0) return false;
                if (!fill) destination = ImageControl.PortraitCrop.FitInside(size, destination);
                return destination.Width > 0 && destination.Height > 0;
            }

            private void PaintCrop(object sender, PaintEventArgs e)
            {
                e.Graphics.FillRectangle(Brushes.Black, Frame);
                if (!GetPreviewGeometry(out Image image, out RectangleF source, out Rectangle destination)) return;
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                ImageControl.Direct.DrawNoBleed(e.Graphics, image, destination, source.X, source.Y, source.Width, source.Height);
            }

            private void MoveTo(int x, int y)
            {
                _picture.Location = _editor.ClampPictureLocation(_picture, _viewport, new Point(x, y));
                _canvas.Invalidate();
            }

            private void Zoom(int delta, Point anchor)
            {
                _editor.ZoomPortrait(_picture, _viewport, delta, anchor);
                _canvas.Invalidate();
            }

            public bool ZoomAtScreenPoint(Point screen, int delta)
            {
                var point = _canvas.PointToClient(screen);
                if (!GetPreviewGeometry(out Image image, out RectangleF source, out Rectangle destination)
                    || !destination.Contains(point)) return false;
                float x = source.X + (point.X - destination.X) * source.Width / destination.Width;
                float y = source.Y + (point.Y - destination.Y) * source.Height / destination.Height;
                Zoom(delta, new Point((int)Math.Round(x * _picture.ClientSize.Width / image.Width),
                                      (int)Math.Round(y * _picture.ClientSize.Height / image.Height)));
                return true;
            }
        }
    }
}
