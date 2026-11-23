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
            FlatStyle = FlatStyle.Flat, BackColor = Color.Black, ForeColor = Color.White
        };
        private TableLayoutPanel _comparisonRow;

        private void InitializeSideBySideEditor()
        {
            LayoutKingCreatePortrait.Controls.Remove(LayoutKingPortraitGroups);
            LayoutKingCreatePortrait.Controls.Add(_cropHost, 1, 2);
            _cropHost.Controls.Add(LayoutKingPortraitGroups);
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
                BackColor = Color.Black, RowCount = 1, GrowStyle = TableLayoutPanelGrowStyle.AddColumns
            };
            _comparisonRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
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
            _comparisonToggle.ForeColor = game.ForeColor;
            _comparisonToggle.Font = UiFont(FontFamily.GenericSansSerif, 9);
            _comparisonToggle.Text = _comparisonRow == null ? TextVariables.SIDE_BY_SIDE : TextVariables.SINGLE_VIEW;
            if (_comparisonRow != null)
                foreach (ComparisonPane pane in _comparisonRow.Controls) pane.RefreshAppearance(game);
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
                RowCount = 5;
                ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                foreach (int height in new[] { 11, 6, 63, 10, 10 })
                    RowStyles.Add(new RowStyle(SizeType.Percent, height));
                _title.TextAlign = ContentAlignment.BottomCenter;
                _dimensions.TextAlign = ContentAlignment.MiddleCenter;
                _dimensions.Text = $"{output.Width} × {output.Height}";
                _title.Dock = _dimensions.Dock = _canvas.Dock = DockStyle.Fill;
                Controls.Add(_title, 0, 0);
                Controls.Add(_dimensions, 0, 1);
                Controls.Add(_canvas, 0, 2);
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

                var moves = ButtonRow(4, 3);
                AddButton(moves, "←", () => Nudge(-1, 0));
                AddButton(moves, "↑", () => Nudge(0, -1));
                AddButton(moves, "↓", () => Nudge(0, 1));
                AddButton(moves, "→", () => Nudge(1, 0));
                var zoom = ButtonRow(3, 4);
                AddButton(zoom, "−", () => Zoom(-120, Center));
                AddButton(zoom, "↺", () => { editor.FitImageToPanel(picture); _canvas.Invalidate(); });
                AddButton(zoom, "+", () => Zoom(120, Center));
            }

            private Point Center => new Point(_viewport.Width / 2 - _picture.Left, _viewport.Height / 2 - _picture.Top);

            private TableLayoutPanel ButtonRow(int columns, int row)
            {
                var table = new TableLayoutPanel { ColumnCount = columns, RowCount = 1, Dock = DockStyle.Fill, Margin = Padding.Empty };
                for (int i = 0; i < columns; i++) table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1));
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                Controls.Add(table, 0, row);
                return table;
            }

            private static void AddButton(TableLayoutPanel row, string text, Action action)
            {
                var button = new Button { Text = text, Dock = DockStyle.Fill, Margin = new Padding(1),
                    Cursor = Cursors.Hand, FlatStyle = FlatStyle.Flat, UseVisualStyleBackColor = false };
                button.Click += (s, e) => action();
                row.Controls.Add(button, row.Controls.Count, 0);
            }

            public void RefreshAppearance(GameType game)
            {
                BackColor = game.BackColor;
                ForeColor = game.ForeColor;
                _title.Text = _tab.Text.TrimStart('⍞', '⌻', '⌼', '▣', ' ');
                _title.Font = _editor.UiFont(_tab.Font.FontFamily, 14, cyrillic: _currentLanguage == 'r');
                _dimensions.Font = _editor.UiFont(FontFamily.GenericSansSerif, 8);
                Font = _editor.UiFont(FontFamily.GenericSansSerif, 11);
                Margin = new Padding(_editor.UiPixels(2), 0, _editor.UiPixels(2), 0);
                _canvas.Invalidate();
            }

            private Rectangle Frame => ImageControl.PortraitCrop.FitInside(_output, _canvas.ClientRectangle);

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

            private void Nudge(int dx, int dy) => MoveTo(_picture.Left + dx * Math.Max(1, _viewport.Width / 25),
                                                        _picture.Top + dy * Math.Max(1, _viewport.Height / 25));
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
