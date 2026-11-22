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
        private readonly Dictionary<PictureBox, (Rectangle LastBounds, int LastFrameHeight, RectangleF FrameBounds)> _cropFrames =
            new Dictionary<PictureBox, (Rectangle, int, RectangleF)>();
        private bool _windowSizeInitialized;
        private bool _inSizeMoveLoop, _applyingWindowScale, _keepingCrop;

        // The size AdjustPortraitPanelAspect last gave each crop frame. A hidden tab's table keeps stale
        // cell sizes and clamps its frame, so the frame's own ClientSize can be distorted; pictures are
        // placed for, and portraits are saved from, this intended size.
        private readonly Dictionary<Panel, Size> _intendedFrames = new Dictionary<Panel, Size>();

        private Size IntendedFrame(Panel panel)
        {
            // A docked (reset) picture fills whatever the frame is, so only a placed picture uses it.
            foreach (Control child in panel.Controls)
                if (child is PictureBox pic)
                    return pic.Dock == DockStyle.None && _intendedFrames.TryGetValue(panel, out Size size)
                        ? size : panel.ClientSize;
            return panel.ClientSize;
        }
        private Dictionary<PictureBox, int> _frameHeightsBeforeResize;

        private Dictionary<PictureBox, int> CurrentFrameHeights()
        {
            var heights = new Dictionary<PictureBox, int>();
            foreach (var pic in new[] { PicKingLrg, PicKingMed, PicKingSml, PicKingSml2 })
                heights[pic] = (pic.Parent as Panel)?.ClientSize.Height ?? 0;
            return heights;
        }

        private void InitializeWindowSize()
        {
            foreach (Control page in Controls)
                RememberDesignLayout(page);
            TrackCropFrames();

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
            const int WmEnterSizeMove = 0x0231, WmExitSizeMove = 0x0232;
            // Inside the modal move/size loop crops are only stretched; ResizeEnd re-renders them.
            if (message.Msg == WmEnterSizeMove) _inSizeMoveLoop = true;
            else if (message.Msg == WmExitSizeMove) _inSizeMoveLoop = false;
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
                    // Last moment the crop frames still have the size the pictures were placed in:
                    // WM_SIZE re-lays out the tables (shrinking cell-capped frames) before OnClientSizeChanged.
                    // Only for a real size change: a no-op one never reaches OnClientSizeChanged, and its
                    // snapshot would go stale and be used by a later resize.
                    if (pos.Width != Width || pos.Height != Height)
                        _frameHeightsBeforeResize = CurrentFrameHeights();
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
            var snapshot = _frameHeightsBeforeResize;
            _frameHeightsBeforeResize = null;
            if (!_windowSizeInitialized || WindowState != FormWindowState.Normal) return;
            int steps = ClientSize.Width / 75;
            if (steps < CompactSizeSteps || steps == _sizeSteps) return;
            _sizeSteps = steps;
            var frameHeights = snapshot ?? CurrentFrameHeights();
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
                _applyingWindowScale = true;
                ResizeCrop(PortraitGroupSelection.Large, frameHeights[PicKingLrg]);
                ResizeCrop(PortraitGroupSelection.Medium, frameHeights[PicKingMed]);
                ResizeCrop(PortraitGroupSelection.Small, frameHeights[PicKingSml]);
                ResizeCrop(PortraitGroupSelection.Sml2, frameHeights[PicKingSml2]);
                ApplySmallLayoutReference();
            }
            finally
            {
                _applyingWindowScale = false;
                ResumeLayout(true);
            }
            ResizeThumbnailCards();
            // Snap, keyboard and programmatic resizes never raise ResizeEnd, so render sharp now.
            if (!_inSizeMoveLoop) SharpenResizedCrops();
            ReleaseUnusedUiFonts();
            Invalidate(true);
        }

        // Every window size gets its own cached fonts; dispose the ones no control uses any more.
        private void ReleaseUnusedUiFonts()
        {
            var inUse = new HashSet<Font> { _galleryCardFont, _archiveCardFont };
            void Collect(Control control)
            {
                inUse.Add(control.Font);
                foreach (Control child in control.Controls) Collect(child);
            }
            Collect(this);
            foreach (Form owned in OwnedForms) Collect(owned);

            var unused = new List<(string, bool, float, FontStyle)>();
            foreach (var entry in _uiFonts)
                if (!inUse.Contains(entry.Value)) unused.Add(entry.Key);
            foreach (var key in unused)
            {
                _uiFonts[key].Dispose();
                _uiFonts.Remove(key);
            }
        }

        // Rescales the window: the frame is resized and KeepCrop (called from
        // AdjustPortraitPanelAspect) keeps the zoomed picture's crop.
        private void ResizeCrop(PortraitGroupSelection slot, int previousFrameHeight) =>
            AdjustActivePortraitPanelAspect(slot, previousFrameHeight);

        // Keeps what a zoomed portrait shows when its frame changes size, whatever the cause: a window
        // resize, a tab switch that re-measures a frame sized while hidden, or a layout change.
        // The crop is kept in units of the frame height, not the window scale. Frames always have the
        // portrait's shape, so this preserves the visible crop exactly even when a frame does not grow
        // exactly with UiScale. Rebase after a pan, a zoom, or a frame change made elsewhere; repeated
        // border drags then always project the same crop instead of accumulating pixel rounding.
        //
        // `now` is the frame size AdjustPortraitPanelAspect intends, not panel.ClientSize: a hidden tab's
        // table keeps stale cell sizes and its layout passes clamp the frame temporarily. For the same
        // reason the frame height recorded with the picture is trusted over the frame's current height;
        // only a pan or zoom (the picture moved) makes the current frame the reference again.
        private void KeepCrop(PictureBox pic, Rectangle previous, int previousFrameHeight, Size now)
        {
            if (pic.Image == null || pic.Dock != DockStyle.None) return;
            // Frames are 1px tall until a game is chosen and laid out; there is no crop to keep yet.
            const int MinimumFrame = 16;
            if (now.Height < MinimumFrame || now.Width < MinimumFrame)
            {
                _cropFrames.Remove(pic);
                return;
            }
            if (!_cropFrames.TryGetValue(pic, out var frame) || frame.LastBounds != previous)
            {
                if (previousFrameHeight < MinimumFrame)
                {
                    _cropFrames.Remove(pic);
                    return;
                }
                frame.FrameBounds = new RectangleF(previous.X / (float)previousFrameHeight, previous.Y / (float)previousFrameHeight,
                    previous.Width / (float)previousFrameHeight, previous.Height / (float)previousFrameHeight);
            }
            RectangleF relative = frame.FrameBounds;
            float width = relative.Width * now.Height, height = relative.Height * now.Height;
            // The frame's width can differ from its height ratio by a pixel; never leave a gap.
            float cover = Math.Max(1f, Math.Max(now.Width / width, now.Height / height));
            width *= cover;
            height *= cover;
            float x = Math.Max(now.Width - width, Math.Min(0, relative.X * now.Height));
            float y = Math.Max(now.Height - height, Math.Min(0, relative.Y * now.Height));
            var bounds = new Rectangle((int)Math.Round(x), (int)Math.Round(y),
                Math.Max(1, (int)Math.Ceiling(width)), Math.Max(1, (int)Math.Ceiling(height)));
            if (bounds != pic.Bounds)
            {
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                _keepingCrop = true;
                try { pic.Bounds = bounds; }
                finally { _keepingCrop = false; }
                // During a window drag ResizeEnd re-renders; on a window resize OnClientSizeChanged does.
                if (!_inSizeMoveLoop && !_applyingWindowScale) SharpenCrop(pic);
            }
            _cropFrames[pic] = (pic.Bounds, now.Height, relative);
        }

        // Records the frame a picture is placed in whenever the picture moves or resizes for any reason
        // other than KeepCrop (zoom, pan, fit, a new image). The frame is visible and laid out then, so
        // this is the crop the user framed, even if a hidden tab's layout later distorts the frame.
        private void TrackCropFrames()
        {
            foreach (var pic in new[] { PicKingLrg, PicKingMed, PicKingSml, PicKingSml2 })
            {
                EventHandler track = (sender, args) =>
                {
                    if (_keepingCrop) return;
                    var panel = pic.Parent as Panel;
                    int frameHeight = panel?.ClientSize.Height ?? 0;
                    if (pic.Dock != DockStyle.None || frameHeight < 16)
                    {
                        _cropFrames.Remove(pic);
                        return;
                    }
                    Rectangle b = pic.Bounds;
                    _cropFrames[pic] = (b, frameHeight, new RectangleF(b.X / (float)frameHeight, b.Y / (float)frameHeight,
                        b.Width / (float)frameHeight, b.Height / (float)frameHeight));
                };
                pic.LocationChanged += track;
                pic.SizeChanged += track;
                pic.DockChanged += track;
            }
        }

        private void SharpenResizedCrops()
        {
            foreach (var pic in new[] { PicKingLrg, PicKingMed, PicKingSml, PicKingSml2 })
                SharpenCrop(pic);
        }

        private void SharpenCrop(PictureBox pic)
        {
            if (pic.SizeMode != PictureBoxSizeMode.StretchImage || pic.Image == null) return;
            Image original = GetOriginalImage(pic);
            if (original == null) return;
            Image old = pic.Image;
            pic.Image = ImageControl.Direct.Resize(original, pic.Width, pic.Height);
            pic.SizeMode = PictureBoxSizeMode.Normal;
            if (old != original) old.Dispose();
        }
    }
}
