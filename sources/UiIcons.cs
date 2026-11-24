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
    internal enum UiIcon { ZoomIn, ZoomOut, ZoomReset, SingleView, SideBySide }

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
                        Magnifier(g, pen, box, icon == UiIcon.ZoomIn);
                        break;
                    case UiIcon.ZoomReset:
                        Reset(g, pen, brush, box);
                        break;
                    case UiIcon.SingleView:
                        Portraits(g, brush, box, new[] { 1f });
                        break;
                    case UiIcon.SideBySide:
                        Portraits(g, brush, box, new[] { 1f, 0.72f, 0.5f });
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
            button.Tag = button.Tag; // keep existing tags (single-view buttons store their picture name)
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

        private static void Magnifier(Graphics g, Pen pen, RectangleF box, bool plus)
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

            float arm = r * 0.5f;
            g.DrawLine(pen, c.X - arm, c.Y, c.X + arm, c.Y);
            if (plus) g.DrawLine(pen, c.X, c.Y - arm, c.X, c.Y + arm);
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

        // Portrait cards standing on one baseline, tallest first.
        private static void Portraits(Graphics g, Brush brush, RectangleF box, float[] heights)
        {
            float s = box.Width;
            float gap = s * 0.08f;
            float unit = s * 0.62f;                 // width : height of a card = 0.62
            float total = 0;
            foreach (float h in heights) total += unit * h * 0.62f;
            total += gap * (heights.Length - 1);
            float scale = Math.Min(1f, s / total);
            float x = box.X + (s - total * scale) / 2f;
            float baseline = box.Y + s * 0.5f + unit * scale * 0.5f / 0.62f * 0.62f;
            baseline = box.Y + (s + s * scale) / 2f;
            foreach (float h in heights)
            {
                float height = s * h * scale;
                float width = height * 0.72f;
                using (var path = Rounded(new RectangleF(x, baseline - height, width, height), Math.Max(1f, s * 0.05f)))
                    g.FillPath(brush, path);
                x += width + gap * scale;
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
