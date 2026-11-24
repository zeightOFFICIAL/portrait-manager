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
        // Docked left in its cell: compact, aligned with the right column, clear of the language flags.
        private readonly ViewSwitch _viewSwitch = new ViewSwitch { Name = "SwitchCropView", Dock = DockStyle.Left };
        private readonly ToolTip _viewSwitchTips = new ToolTip { InitialDelay = 300, ReshowDelay = 100 };
        private ComparisonRow _comparisonRow;

        private void InitializeSideBySideEditor()
        {
            LayoutKingCreatePortrait.Controls.Remove(LayoutKingPortraitGroups);
            LayoutKingCreatePortrait.Controls.Add(_cropHost, 1, 2);
            _cropHost.Controls.Add(LayoutKingPortraitGroups);
            // Line up with the right column and sit on the panel like the slot tabs.
            _viewSwitch.Margin = new Padding(LayoutKingRight.Margin.Left, 0, LayoutKingRight.Margin.Right, 6);
            LayoutKingCreatePortrait.Controls.Add(_viewSwitch, 2, 1);
            _viewSwitch.ModeRequested += SetSideBySide;
            _viewSwitch.HoverChanged += segment => _viewSwitchTips.SetToolTip(_viewSwitch,
                segment < 0 ? null : segment == 0 ? TextVariables.SINGLE_VIEW : TextVariables.SIDE_BY_SIDE);
            Disposed += (s, e) => _viewSwitchTips.Dispose();
            LayoutKingCreatePortrait.VisibleChanged += (s, e) =>
            {
                if (!LayoutKingCreatePortrait.Visible) CloseComparison();
            };
        }

        private void SetSideBySide(bool sideBySide)
        {
            if (sideBySide == (_comparisonRow != null)) return;
            if (sideBySide) OpenComparison();
            else CloseComparison();
        }

        private void OpenComparison()
        {
            if (!GameTypes.TryGetValue(_gameSelected, out GameType game) || _gameSelected == 'l') return;
            var selected = _activeKingPortraitGroup;
            _comparisonRow = new ComparisonRow(this) { Name = "ComparisonRow", Dock = DockStyle.Fill, Margin = Padding.Empty, BackColor = game.BackColor };
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
                var size = new Size((int)game.GetPortraitSpecific(key + "_WIDTH"), (int)game.GetPortraitSpecific(key + "_HEIGHT"));
                _comparisonRow.Controls.Add(new ComparisonPane(this, picture, tab, size));
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
            _viewSwitch.Visible = GameTypes.TryGetValue(_gameSelected, out GameType game) && _gameSelected != 'l';
            if (game == null) return;
            _viewSwitch.Apply(game.BackColor, game.ForeColor, _comparisonRow != null);
            _viewSwitch.AccessibleName = _comparisonRow == null ? TextVariables.SIDE_BY_SIDE : TextVariables.SINGLE_VIEW;
            LayoutKingPortraitGroups.Invalidate(true);   // single-view frame legends follow language and scale
            if (_comparisonRow == null) return;
            _comparisonRow.BackColor = game.BackColor;
            _comparisonRow.ForeColor = game.ForeColor;
            _comparisonRow.Font = LegendSizeFont;   // also keeps the font alive for painting
            foreach (ComparisonPane pane in _comparisonRow.Controls) pane.RefreshAppearance(game);
            LayoutComparison();
            _comparisonRow.Invalidate();
        }

        // All previews share one scale, so they keep the size relation of the files Create
        // writes (Fulllength is drawn as many times larger than Portrait as it really is).
        // The scale is the largest that fits the panel, found by bisection; it may exceed 100%.
        private void LayoutComparison()
        {
            if (_comparisonRow == null || _comparisonRow.Controls.Count == 0) return;
            var panes = new ComparisonPane[_comparisonRow.Controls.Count];
            _comparisonRow.Controls.CopyTo(panes, 0);

            int pad = UiPixels(10), minGap = UiPixels(10);
            Rectangle area = Rectangle.Inflate(_comparisonRow.ClientRectangle, -pad, -pad);
            area.Height -= _comparisonRow.ScaleLineHeight;
            if (area.Width <= 0 || area.Height <= 0) return;

            int RowWidth(double scale)
            {
                int total = minGap * (panes.Length - 1);
                foreach (var pane in panes) total += pane.MeasureWidth(pane.DisplaySize(scale), scale);
                return total;
            }
            int RowHeight(double scale)
            {
                int height = 0;
                foreach (var pane in panes) height = Math.Max(height, pane.ChromeHeight + pane.DisplaySize(scale).Height);
                return height;
            }
            bool Fits(double scale) => RowWidth(scale) <= area.Width && RowHeight(scale) <= area.Height;

            double low = 0.01, high = 4.0;
            if (Fits(high)) low = high;
            else
                for (int i = 0; i < 40; i++)
                {
                    double mid = (low + high) / 2;
                    if (Fits(mid)) low = mid; else high = mid;
                }

            // Spread the spare width evenly around the panes (it is left over when the height
            // limits the scale), and center the row vertically when the width limits it.
            // Portraits stand on one baseline so their buttons form one row.
            int spare = Math.Max(0, area.Width - RowWidth(low));
            int gap = minGap + spare / (panes.Length + 1);
            int x = area.X + spare / (panes.Length + 1) + (spare % (panes.Length + 1)) / 2;
            int rowHeight = RowHeight(low);
            int bottom = area.Y + (area.Height - rowHeight) / 2 + rowHeight;
            foreach (var pane in panes)
            {
                Size display = pane.DisplaySize(low);
                var size = new Size(pane.MeasureWidth(display, low), pane.ChromeHeight + display.Height);
                pane.Arrange(display, low, new Rectangle(new Point(x, bottom - size.Height), size));
                x += size.Width + gap;
            }
            _comparisonRow.Scale = low;
        }

        // The export size, with the display scale when the preview is not 1:1.
        private static string SizeLegend(Size output, double scale)
        {
            string size = $"{output.Width} × {output.Height}";
            int percent = (int)Math.Round(scale * 100);
            return percent == 100 ? size : $"{size} · {Math.Max(1, percent)}%";
        }

        // A frame whose top line is broken by a title and whose bottom line is broken by a
        // second legend, like a group box. Shared by the single and side-by-side views.
        private void DrawLegendFrame(Graphics g, Rectangle frame, string top, Font topFont, string bottom, Font bottomFont, Color color)
        {
            int legendPad = UiPixels(6);
            Size topSize = TextRenderer.MeasureText(top, topFont);
            Size bottomSize = TextRenderer.MeasureText(bottom, bottomFont);
            int topLeft = frame.Left + (frame.Width - topSize.Width) / 2;
            int bottomLeft = frame.Left + (frame.Width - bottomSize.Width) / 2;
            using (var pen = new Pen(color))
            {
                g.DrawLine(pen, frame.Left, frame.Top, Math.Max(frame.Left, topLeft - legendPad), frame.Top);
                g.DrawLine(pen, Math.Min(frame.Right, topLeft + topSize.Width + legendPad), frame.Top, frame.Right, frame.Top);
                g.DrawLine(pen, frame.Left, frame.Top, frame.Left, frame.Bottom);
                g.DrawLine(pen, frame.Right, frame.Top, frame.Right, frame.Bottom);
                g.DrawLine(pen, frame.Left, frame.Bottom, Math.Max(frame.Left, bottomLeft - legendPad), frame.Bottom);
                g.DrawLine(pen, Math.Min(frame.Right, bottomLeft + bottomSize.Width + legendPad), frame.Bottom, frame.Right, frame.Bottom);
            }
            const TextFormatFlags flags = TextFormatFlags.NoPadding | TextFormatFlags.SingleLine;
            TextRenderer.DrawText(g, top, topFont, new Point(topLeft, frame.Top - topSize.Height / 2), color, flags);
            TextRenderer.DrawText(g, bottom, bottomFont, new Point(bottomLeft, frame.Bottom - bottomSize.Height / 2), color, flags);
        }

        // Legend fonts. Single-view controls already use both sizes (Select buttons, hints),
        // so ReleaseUnusedUiFonts keeps them alive for painting.
        private Font LegendTitleFont => ThemeFont(16f);
        private Font LegendSizeFont => ThemeFont(10f);
        private int LegendGap => UiPixels(2);
        private int FrameInset => UiPixels(7);

        // Single view: the same frame around the crop panel, titled like its tab, with the
        // export size and the scale the frame shows it at.
        private void DrawCropFrame(Control group, PaintEventArgs e, Panel panel, Label tab, string key)
        {
            if (group == null || panel == null || !panel.Visible || panel.Parent != group) return;
            if (!GameTypes.TryGetValue(_gameSelected, out GameType game) || !HasPortraitSpecific(game, key + "_WIDTH")) return;
            var output = new Size((int)game.GetPortraitSpecific(key + "_WIDTH"), (int)game.GetPortraitSpecific(key + "_HEIGHT"));
            Rectangle crop = panel.Bounds;
            if (crop.Height < 16) return;
            Font titleFont = LegendTitleFont, sizeFont = LegendSizeFont;
            int titleHeight = TextRenderer.MeasureText("Ag", titleFont).Height;
            int sizeHeight = TextRenderer.MeasureText("0", sizeFont).Height;
            int top = crop.Top - titleHeight / 2 - LegendGap;
            int bottom = crop.Bottom + sizeHeight / 2 + LegendGap;
            var frame = Rectangle.FromLTRB(crop.Left - FrameInset, top, crop.Right + FrameInset, bottom);
            string title = tab.Text.TrimStart('⍞', '⌻', '⌼', '▣', ' ');
            DrawLegendFrame(e.Graphics, frame, title, titleFont, SizeLegend(output, (double)crop.Height / output.Height), sizeFont, game.ForeColor);
        }

        private Font ThemeFont(float points) => UiFont(
            (_currentLanguage == 'r' ? _fontCollectionCyrillic : _fontCollection).Families[0], points, cyrillic: _currentLanguage == 'r');

        // Same look as the single view's buttons (UpdatePortraitButtonsStyle), including the hover inversion.
        private void StylePortraitButton(Button button, GameType game)
        {
            bool hovered = button.Visible && button.ClientRectangle.Contains(button.PointToClient(Cursor.Position));
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

        private sealed class ComparisonRow : Panel
        {
            private readonly MainForm _editor;

            public ComparisonRow(MainForm editor)
            {
                _editor = editor;
                DoubleBuffered = true;
                ResizeRedraw = true;
            }

            private double _scale = 1;

            // The scale every preview shares, shown on the bottom border.
            public new double Scale
            {
                get => _scale;
                set { if (Math.Abs(_scale - value) > 1e-9) { _scale = value; Invalidate(); } }
            }

            public string ScaleText => $"{Math.Max(1, (int)Math.Round(_scale * 100))}%";

            // Room kept free at the bottom of the frame for the scale line.
            public int ScaleLineHeight => TextRenderer.MeasureText("0", Font).Height + _editor.UiPixels(4);

            // The group border, and the shared scale centered just inside its bottom edge.
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                _editor.DrawGroupBorder(this, e, null);
                Size text = TextRenderer.MeasureText(ScaleText, Font);
                int icon = text.Height, spacing = _editor.UiPixels(3);
                var at = new Point((Width - text.Width - icon - spacing) / 2 + icon + spacing, Height - _editor.UiPixels(6) - text.Height);
                UiIcons.Draw(e.Graphics, UiIcon.Magnify, new Rectangle(at.X - icon - spacing, at.Y, icon, icon), ForeColor, 0.9f);
                TextRenderer.DrawText(e.Graphics, ScaleText, Font, at, ForeColor, TextFormatFlags.NoPadding | TextFormatFlags.SingleLine);
            }

            protected override void OnSizeChanged(EventArgs e)
            {
                base.OnSizeChanged(e);
                _editor.LayoutComparison();
            }
        }

        // One portrait: its title on the frame's top border, the export size on the bottom
        // border, the preview inside at real size (or scaled down to fit), and zoom buttons.
        // Each pane edits the original editor's picture bounds. Switching views and
        // exporting therefore use the same crop, including when slots use different images.
        private sealed class ComparisonPane : Panel
        {
            private readonly MainForm _editor;
            private readonly PictureBox _picture;
            private readonly Panel _viewport;
            private readonly Size _output;
            private readonly Label _tab;
            private readonly PictureBox _canvas = new PictureBox { Name = "Preview", Cursor = Cursors.SizeAll };
            private readonly Button[] _buttons;
            private string _title = string.Empty, _dimensions = string.Empty;
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
                DoubleBuffered = true;
                Controls.Add(_canvas);
                _canvas.Paint += PaintCrop;
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
                _buttons = new[]
                {
                    MakeButton("ZoomIn", UiIcon.ZoomIn, () => Zoom(120, Center)),
                    MakeButton("ZoomOut", UiIcon.ZoomOut, () => Zoom(-120, Center)),
                    MakeButton("ZoomReset", UiIcon.ZoomReset, () => { editor.FitImageToPanel(picture); _canvas.Invalidate(); }),
                };
            }

            public Size Output => _output;

            private Button MakeButton(string name, UiIcon icon, Action action)
            {
                var button = new Button { Name = name, Cursor = Cursors.Hand };
                button.Click += (s, e) => action();
                UiIcons.Attach(button, icon);
                Controls.Add(button);
                return button;
            }

            private int TitleHeight => TextRenderer.MeasureText("Ag", Font).Height;
            private int DimensionsHeight => TextRenderer.MeasureText("0", _canvas.Font).Height;
            private int ButtonsGap => _editor.UiPixels(10);
            private int ButtonsHeight => _editor.UiPixels(34);
            // The preview starts below the title's lower half and ends above the size legend's upper half
            // (the same geometry DrawCropFrame uses in the single view).
            private int PreviewTop => TitleHeight + _editor.LegendGap;
            private int FrameBottom => _canvas.Bottom + DimensionsHeight / 2 + _editor.LegendGap;

            // Everything in the pane's height except the preview itself.
            public int ChromeHeight => PreviewTop + DimensionsHeight / 2 + _editor.LegendGap + (DimensionsHeight - DimensionsHeight / 2) + ButtonsGap + ButtonsHeight;

            public Size DisplaySize(double scale) =>
                new Size(Math.Max(1, (int)Math.Round(_output.Width * scale)), Math.Max(1, (int)Math.Round(_output.Height * scale)));

            public int MeasureWidth(Size display, double scale)
            {
                int legendPad = _editor.UiPixels(9);
                int title = TextRenderer.MeasureText(_title, Font).Width + 2 * legendPad;
                int dims = TextRenderer.MeasureText(SizeLegend(_output, 1), _canvas.Font).Width + 2 * legendPad;
                int buttons = 3 * _editor.UiPixels(26) + 2 * _editor.UiPixels(4);
                return Math.Max(Math.Max(display.Width + 2 * _editor.FrameInset, buttons), Math.Max(title, dims));
            }

            public void Arrange(Size display, double scale, Rectangle bounds)
            {
                // The shared scale is shown once, on the row's frame (ComparisonRow).
                _dimensions = SizeLegend(_output, 1);
                Bounds = bounds;
                _canvas.Bounds = new Rectangle((bounds.Width - display.Width) / 2, PreviewTop, display.Width, display.Height);
                int y = FrameBottom + DimensionsHeight - DimensionsHeight / 2 + ButtonsGap;
                int gap = _editor.UiPixels(4);
                int width = (bounds.Width - 2 * gap) / 3;
                for (int i = 0; i < _buttons.Length; i++)
                {
                    int x = i * (width + gap);
                    int w = i == _buttons.Length - 1 ? bounds.Width - x : width;
                    _buttons[i].Bounds = new Rectangle(x, y, w, ButtonsHeight);
                }
                Invalidate();
                _canvas.Invalidate();
            }

            public void RefreshAppearance(GameType game)
            {
                BackColor = game.BackColor;
                ForeColor = game.ForeColor;
                _title = _tab.Text.TrimStart('⍞', '⌻', '⌼', '▣', ' ');
                // Fonts are assigned to controls so ReleaseUnusedUiFonts keeps them alive for OnPaint.
                Font = _editor.LegendTitleFont;
                _canvas.Font = _editor.LegendSizeFont;
                _canvas.BackColor = Color.Black;
                foreach (Button button in _buttons) _editor.StylePortraitButton(button, game);
                Invalidate();
                _canvas.Invalidate();
            }

            // The frame spans the pane; the title breaks its top line and the export size its bottom line.
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                int titleMid = TitleHeight / 2;
                var frame = new Rectangle(0, titleMid, Width - 1, FrameBottom - titleMid);
                _editor.DrawLegendFrame(e.Graphics, frame, _title, Font, _dimensions, _canvas.Font, ForeColor);
            }

            private Point Center => new Point(_viewport.Width / 2 - _picture.Left, _viewport.Height / 2 - _picture.Top);

            private Rectangle Frame => _canvas.ClientRectangle;

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
                e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
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

        // Two-segment switch: one portrait card (single view) and a row of cards (side by side).
        // The current view is filled; hovering the other segment inverts it like the portrait buttons.
        private sealed class ViewSwitch : Control
        {
            private Color _back = Color.Black, _fore = Color.White;
            private bool _sideBySide;
            private int _hover = -1;

            public event Action<bool> ModeRequested;
            public event Action<int> HoverChanged;

            public ViewSwitch()
            {
                SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
                Cursor = Cursors.Hand;
                TabStop = false;
                AccessibleRole = AccessibleRole.PushButton;
            }

            public bool SideBySide => _sideBySide;

            // Two segments a little wider than tall, whatever height the layout row gives.
            protected override void OnSizeChanged(EventArgs e)
            {
                base.OnSizeChanged(e);
                int width = (int)Math.Round(Height * 2.4);
                if (Height > 0 && Width != width) Width = width;
            }

            public void Apply(Color back, Color fore, bool sideBySide)
            {
                _back = back;
                _fore = fore;
                _sideBySide = sideBySide;
                Invalidate();
            }

            private Rectangle Segment(int index)
            {
                int half = Width / 2;
                return index == 0 ? new Rectangle(0, 0, half, Height) : new Rectangle(half, 0, Width - half, Height);
            }

            private int SegmentAt(Point p) => !ClientRectangle.Contains(p) ? -1 : p.X < Width / 2 ? 0 : 1;

            protected override void OnPaint(PaintEventArgs e)
            {
                e.Graphics.Clear(_back);
                for (int i = 0; i < 2; i++)
                {
                    bool filled = (i == 1) == _sideBySide || i == _hover;
                    Rectangle r = Segment(i);
                    if (filled) using (var b = new SolidBrush(_fore)) e.Graphics.FillRectangle(b, r);
                    UiIcons.Draw(e.Graphics, i == 0 ? UiIcon.SingleView : UiIcon.SideBySide, r, filled ? _back : _fore);
                }
                using (var pen = new Pen(_fore))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
                    e.Graphics.DrawLine(pen, Width / 2, 0, Width / 2, Height - 1);
                }
            }

            protected override void OnMouseMove(MouseEventArgs e)
            {
                base.OnMouseMove(e);
                SetHover(SegmentAt(e.Location));
            }

            protected override void OnMouseLeave(EventArgs e)
            {
                base.OnMouseLeave(e);
                SetHover(-1);
            }

            private void SetHover(int segment)
            {
                if (segment == _hover) return;
                _hover = segment;
                Invalidate();
                HoverChanged?.Invoke(segment);
            }

            protected override void OnMouseClick(MouseEventArgs e)
            {
                base.OnMouseClick(e);
                int segment = SegmentAt(e.Location);
                if (e.Button == MouseButtons.Left && segment >= 0) ModeRequested?.Invoke(segment == 1);
            }

            // Toggles between the views, for keyboard/accessibility and scripted use.
            public void PerformClick() => ModeRequested?.Invoke(!_sideBySide);
        }
    }
}
