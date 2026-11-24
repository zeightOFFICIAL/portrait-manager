/*
    Zeight Portrait Manager
    Vector icons drawn at the control's current size, so they stay sharp at every window
    scale and follow the theme colors. The theme font (BebasNeue) has no emoji, and GDI
    does not fall back to an emoji font for it, so glyph icons like 🔍 render as boxes.
*/
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PortraitManager
{
    internal enum UiIcon { ZoomIn, ZoomOut, ZoomReset, SingleView, SideBySide, Magnify }

    internal static class UiIcons
    {
        // Icon edge as a share of the smaller side of the bounds.
        private const float Fill = 0.62f;

        public static void Draw(Graphics g, UiIcon icon, Rectangle bounds, Color color, float fill = Fill)
        {
            float size = Math.Min(bounds.Width, bounds.Height) * fill;
            if (size < 4) return;
            var box = new RectangleF(bounds.X + (bounds.Width - size) / 2f, bounds.Y + (bounds.Height - size) / 2f, size, size);
            var state = g.Save();
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            float stroke = Math.Max(1.4f, size * 0.09f);
            using (var pen = new Pen(color, stroke) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round })
            using (var brush = new SolidBrush(color))
            {
                switch (icon)
                {
                    case UiIcon.ZoomIn:
                    case UiIcon.ZoomOut:
                        Magnifier(g, pen, box, icon == UiIcon.ZoomIn ? true : (bool?)false);
                        break;
                    case UiIcon.Magnify:
                        Magnifier(g, pen, box, null);
                        break;
                    case UiIcon.ZoomReset:
                        Reset(g, pen, brush, box);
                        break;
                    case UiIcon.SingleView:
                        Portraits(g, brush, bounds, new[] { 1f });
                        break;
                    case UiIcon.SideBySide:
                        Portraits(g, brush, bounds, new[] { 1f, 0.72f, 0.5f });
                        break;
                }
            }
            g.Restore(state);
        }

        // Paints the icon over a flat button whose Text is empty. Colors follow
        // ForeColor, so the hover inversion of the portrait buttons applies.
        public static void Attach(Button button, UiIcon icon, string accessibleName = null)
        {
            button.Text = string.Empty;
            if (accessibleName != null) button.AccessibleName = accessibleName;
            button.Paint -= PaintAttached;
            button.Paint += PaintAttached;
            Icons[button] = icon;
            button.Disposed -= Forget;
            button.Disposed += Forget;
            button.Invalidate();
        }

        private static readonly System.Collections.Generic.Dictionary<Control, UiIcon> Icons =
            new System.Collections.Generic.Dictionary<Control, UiIcon>();

        private static void Forget(object sender, EventArgs e) => Icons.Remove((Control)sender);

        private static void PaintAttached(object sender, PaintEventArgs e)
        {
            var button = (Button)sender;
            if (!Icons.TryGetValue(button, out UiIcon icon)) return;
            Draw(e.Graphics, icon, button.ClientRectangle, button.ForeColor);
        }

        // plus: true draws +, false draws −, null draws a plain lens.
        private static void Magnifier(Graphics g, Pen pen, RectangleF box, bool? plus)
        {
            float s = box.Width;
            float r = s * 0.31f;
            var c = new PointF(box.X + s * 0.42f, box.Y + s * 0.42f);
            g.DrawEllipse(pen, c.X - r, c.Y - r, 2 * r, 2 * r);

            float d = (float)(r / Math.Sqrt(2));
            using (var handle = (Pen)pen.Clone())
            {
                handle.Width = pen.Width * 1.5f;
                g.DrawLine(handle, c.X + d + pen.Width * 0.3f, c.Y + d + pen.Width * 0.3f, box.Right - s * 0.06f, box.Bottom - s * 0.06f);
            }

            if (plus == null) return;
            float arm = r * 0.5f;
            g.DrawLine(pen, c.X - arm, c.Y, c.X + arm, c.Y);
            if (plus == true) g.DrawLine(pen, c.X, c.Y - arm, c.X, c.Y + arm);
        }

        // An open circle with an arrowhead at the top pointing counter-clockwise (↺).
        private static void Reset(Graphics g, Pen pen, Brush brush, RectangleF box)
        {
            float s = box.Width;
            float r = s * 0.36f;
            var c = new PointF(box.X + s / 2f, box.Y + s / 2f + s * 0.03f);
            const float start = -70f, sweep = 285f;
            g.DrawArc(pen, c.X - r, c.Y - r, 2 * r, 2 * r, start, sweep);

            double a = start * Math.PI / 180;
            var tip = new PointF(c.X + r * (float)Math.Cos(a), c.Y + r * (float)Math.Sin(a));
            // Counter-clockwise tangent on screen (y grows downwards).
            var dir = new PointF((float)Math.Sin(a), -(float)Math.Cos(a));
            var normal = new PointF(-dir.Y, dir.X);
            float h = s * 0.26f;
            var head = new[]
            {
                new PointF(tip.X + dir.X * h * 0.55f, tip.Y + dir.Y * h * 0.55f),
                new PointF(tip.X - dir.X * h * 0.45f + normal.X * h * 0.5f, tip.Y - dir.Y * h * 0.45f + normal.Y * h * 0.5f),
                new PointF(tip.X - dir.X * h * 0.45f - normal.X * h * 0.5f, tip.Y - dir.Y * h * 0.45f - normal.Y * h * 0.5f),
            };
            g.FillPolygon(brush, head);
        }

        // Portrait cards (width : height = 0.72) standing on one baseline, tallest first.
        // Uses the whole bounds, not a square, so a row of cards stays legible in a wide segment.
        private static void Portraits(Graphics g, Brush brush, Rectangle bounds, float[] heights)
        {
            const float aspect = 0.72f, gapShare = 0.14f;
            float sum = 0;
            foreach (float h in heights) sum += h;
            float span = aspect * sum + gapShare * (heights.Length - 1);   // row width per unit of card height
            float tallest = Math.Min(bounds.Height * 0.62f, bounds.Width * 0.7f / span);
            if (tallest < 4) return;
            float x = bounds.X + (bounds.Width - tallest * span) / 2f;
            float baseline = bounds.Y + (bounds.Height + tallest) / 2f;
            float radius = Math.Max(1f, tallest * 0.08f);
            foreach (float h in heights)
            {
                float height = tallest * h, width = tallest * h * aspect;
                using (var path = Rounded(new RectangleF(x, baseline - height, width, height), radius))
                    g.FillPath(brush, path);
                x += width + tallest * gapShare;
            }
        }

        private static GraphicsPath Rounded(RectangleF r, float radius)
        {
            var path = new GraphicsPath();
            float d = radius * 2;
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
