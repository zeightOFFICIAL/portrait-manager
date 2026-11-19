using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using PortraitManager.Properties;

namespace PortraitManager
{
    public partial class MainForm
    {
        // 750 x 520 is the design size. Whole 75 x 52 units give an exact
        // pixel aspect ratio at every size, independently of the Windows frame.
        private const int CompactSizeSteps = 10;
        private int _sizeSteps = CompactSizeSteps;
        private float UiScale => _sizeSteps / (float)CompactSizeSteps;
        private int UiPixels(int pixels) => (int)Math.Round(pixels * UiScale);
        private readonly List<Action> _scaleLayout = new List<Action>();
        private readonly Dictionary<PictureBox, (Rectangle LastBounds, RectangleF DesignBounds)> _cropFrames =
            new Dictionary<PictureBox, (Rectangle, RectangleF)>();
        private bool _windowSizeInitialized;

        private void InitializeWindowSize()
        {
            foreach (Control page in Controls)
                RememberDesignLayout(page);

            var work = Screen.FromControl(this).WorkingArea;
            MinimumSize = SizeFromClientSize(new Size(750, 520));
            int width = CoreSettings.Default.WindowWidth;
            if (width <= 0) width = CoreSettings.Default.LargeInterface ? 1050 : 750;
            int steps = ConstrainSize(width / 75.0, work);
            _windowSizeInitialized = true;
            ClientSize = new Size(75 * steps, 52 * steps);
            Location = new Point(work.Left + Math.Max(0, (work.Width - Width) / 2),
                                 work.Top + Math.Max(0, (work.Height - Height) / 2));
        }

        private int ConstrainSize(double requestedSteps, Rectangle work)
        {
            Size frame = SizeFromClientSize(Size.Empty);
            int limit = Math.Min((work.Width - frame.Width) / 75, (work.Height - frame.Height) / 52);
            return Math.Max(CompactSizeSteps, Math.Min(limit, (int)Math.Round(requestedSteps)));
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct WindowPosition
        {
            public IntPtr Handle, InsertAfter;
            public int X, Y, Width, Height;
            public uint Flags;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SizingRectangle
        {
            public int Left, Top, Right, Bottom;
        }

        protected override void WndProc(ref Message message)
        {
            const int WmSizing = 0x0214;
            const int WmWindowPosChanging = 0x0046;
            if (message.Msg == WmWindowPosChanging && _windowSizeInitialized && WindowState == FormWindowState.Normal)
            {
                // Keyboard positioning and shell-initiated changes can bypass WM_SIZING.
                var pos = Marshal.PtrToStructure<WindowPosition>(message.LParam);
                const int SwpNoSize = 1;
                if ((pos.Flags & SwpNoSize) == 0 && pos.Width > 0 && pos.Height > 0)
                {
                    Size border = SizeFromClientSize(Size.Empty);
                    double units = pos.Width == Width ? (pos.Height - border.Height) / 52.0 :
                                                        (pos.Width - border.Width) / 75.0;
                    int unitsToUse = ConstrainSize(units, Screen.FromControl(this).WorkingArea);
                    pos.Width = unitsToUse * 75 + border.Width;
                    pos.Height = unitsToUse * 52 + border.Height;
                    Marshal.StructureToPtr(pos, message.LParam, false);
                }
            }
            if (message.Msg != WmSizing || !_windowSizeInitialized)
            {
                base.WndProc(ref message);
                return;
            }

            var rect = Marshal.PtrToStructure<SizingRectangle>(message.LParam);
            int edge = message.WParam.ToInt32();
            Size frame = SizeFromClientSize(Size.Empty);
            int width = rect.Right - rect.Left - frame.Width;
            int height = rect.Bottom - rect.Top - frame.Height;
            // WMSZ_LEFT/RIGHT change width, TOP/BOTTOM change height. Project a
            // corner drag onto the aspect-ratio diagonal so either axis works.
            double requested = edge == 1 || edge == 2 ? width / 75.0 :
                               edge == 3 || edge == 6 ? height / 52.0 :
                               (75.0 * width + 52.0 * height) / (75 * 75 + 52 * 52);
            int steps = ConstrainSize(requested, Screen.FromControl(this).WorkingArea);
            width = steps * 75 + frame.Width;
            height = steps * 52 + frame.Height;
            if (edge == 1 || edge == 4 || edge == 7) rect.Left = rect.Right - width;
            else rect.Right = rect.Left + width;
            if (edge == 3 || edge == 4 || edge == 5) rect.Top = rect.Bottom - height;
            else rect.Bottom = rect.Top + height;
            Marshal.StructureToPtr(rect, message.LParam, false);
            message.Result = new IntPtr(1);
        }

        private Padding ScaledPadding(Padding p) =>
            new Padding(UiPixels(p.Left), UiPixels(p.Top), UiPixels(p.Right), UiPixels(p.Bottom));

        private void RememberDesignLayout(Control c)
        {
            Padding margin = c.Margin, padding = c.Padding;
            Size size = c.Size;
            bool fixedSize = c.Dock == DockStyle.None && !c.AutoSize &&
                             !(c.Parent == PanelKingLrg || c.Parent == PanelKingMed ||
                               c.Parent == PanelKingSml || c.Parent == PanelKingSml2) &&
                             c != PanelKingLrg && c != PanelKingMed && c != PanelKingSml && c != PanelKingSml2;
            _scaleLayout.Add(() =>
            {
                c.Margin = ScaledPadding(margin);
                c.Padding = ScaledPadding(padding);
                if (fixedSize) c.Size = new Size(UiPixels(size.Width), UiPixels(size.Height));
            });
            if (c is TableLayoutPanel table)
            {
                foreach (ColumnStyle column in table.ColumnStyles)
                {
                    if (column.SizeType != SizeType.Absolute) continue;
                    float width = column.Width;
                    _scaleLayout.Add(() => column.Width = width * UiScale);
                }
                foreach (RowStyle row in table.RowStyles)
                {
                    if (row.SizeType != SizeType.Absolute) continue;
                    float height = row.Height;
                    _scaleLayout.Add(() => row.Height = height * UiScale);
                }
            }
            foreach (Control child in c.Controls) RememberDesignLayout(child);
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            if (!_windowSizeInitialized || WindowState != FormWindowState.Normal) return;
            int steps = ClientSize.Width / 75;
            if (steps < CompactSizeSteps || steps == _sizeSteps) return;
            float previousScale = UiScale;
            _sizeSteps = steps;
            SuspendLayout();
            try
            {
                foreach (var apply in _scaleLayout) apply();
                FontInit();
                LabelSelectPathTitle.Font = UiFont(LabelSelectPathTitle.Font.FontFamily,
                    GetGameTitleFontSize(_gameSelected), cyrillic: _currentLanguage == 'r');
                _flagRus.Left = ClientSize.Width - UiPixels(20);
                _flagDe.Left = ClientSize.Width - UiPixels(43);
                _flagEng.Left = ClientSize.Width - UiPixels(66);
                _galleryHelpButton.Location = new Point(UiPixels(8), UiPixels(8));
                ResizeCrop(PicKingLrg, PortraitGroupSelection.Large, previousScale);
                ResizeCrop(PicKingMed, PortraitGroupSelection.Medium, previousScale);
                ResizeCrop(PicKingSml, PortraitGroupSelection.Small, previousScale);
                ResizeCrop(PicKingSml2, PortraitGroupSelection.Sml2, previousScale);
                ApplySmallLayoutReference();
            }
            finally { ResumeLayout(true); }
            ResizeThumbnailCards();
            Invalidate(true);
        }

        private void ResizeCrop(PictureBox pic, PortraitGroupSelection slot, float previousScale)
        {
            Rectangle previous = pic.Bounds;
            AdjustActivePortraitPanelAspect(slot);
            if (pic.Image == null || pic.Dock != DockStyle.None) return;
            // Rebase after a pan or zoom. Repeated border drags then always
            // project the same crop instead of accumulating pixel rounding.
            if (!_cropFrames.TryGetValue(pic, out var frame) || frame.LastBounds != previous)
                frame.DesignBounds = new RectangleF(previous.X / previousScale, previous.Y / previousScale,
                    previous.Width / previousScale, previous.Height / previousScale);
            RectangleF design = frame.DesignBounds;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Bounds = Rectangle.Round(new RectangleF(design.X * UiScale, design.Y * UiScale,
                Math.Max(1, design.Width * UiScale), Math.Max(1, design.Height * UiScale)));
            _cropFrames[pic] = (pic.Bounds, design);
        }

        private void SharpenResizedCrops()
        {
            foreach (var pic in new[] { PicKingLrg, PicKingMed, PicKingSml, PicKingSml2 })
            {
                if (pic.SizeMode != PictureBoxSizeMode.StretchImage || pic.Image == null) continue;
                Image original = GetOriginalImage(pic);
                if (original == null) continue;
                Image old = pic.Image;
                pic.Image = ImageControl.Direct.Resize(original, pic.Width, pic.Height);
                pic.SizeMode = PictureBoxSizeMode.Normal;
                if (old != original) old.Dispose();
            }
        }
    }
}
