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
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ImageControl
{

    public class Direct
    {
        // GDI+'s high-quality interpolation modes sample slightly past the given source
        // rectangle's edge to fill the bicubic kernel; with the default wrap mode that reads
        // whatever's adjacent in the source bitmap (or wraps around it), producing a thin
        // mismatched-color seam at the drawn image's border. TileFlipXY makes it mirror the
        // edge pixels instead, which removes the seam.
        private static readonly ImageAttributes NoBleedAttributes = CreateNoBleedAttributes();

        private static ImageAttributes CreateNoBleedAttributes()
        {
            var attr = new ImageAttributes();
            attr.SetWrapMode(WrapMode.TileFlipXY);
            return attr;
        }

        public static void DrawNoBleed(Graphics g, Image img, Rectangle destRect, float srcX, float srcY, float srcW, float srcH)
        {
            g.DrawImage(img, destRect, srcX, srcY, srcW, srcH, GraphicsUnit.Pixel, NoBleedAttributes);
        }

        public static Bitmap Resize(Image inImage, int newWidth, int newHeight)
        {
            Bitmap outImage = new Bitmap(newWidth, newHeight);
            outImage.SetResolution(inImage.HorizontalResolution, inImage.VerticalResolution);
            using (Graphics newRenderer = Graphics.FromImage(outImage))
            {
                newRenderer.CompositingQuality = CompositingQuality.HighQuality;
                newRenderer.InterpolationMode = InterpolationMode.HighQualityBicubic;
                newRenderer.SmoothingMode = SmoothingMode.HighQuality;
                newRenderer.PixelOffsetMode = PixelOffsetMode.HighQuality;
                Rectangle destRect = new Rectangle(0, 0, newWidth, newHeight);
                DrawNoBleed(newRenderer, inImage, destRect, 0, 0, inImage.Width, inImage.Height);
            }
            return outImage;
        }
    }

    public static class PortraitCrop
    {

        public static Image ResizeCover(Image src, int boxWidth, int boxHeight)
        {
            if (src == null || boxWidth <= 0 || boxHeight <= 0)
                return src == null ? null : new Bitmap(src);

            float scaleX = (float)boxWidth / src.Width;
            float scaleY = (float)boxHeight / src.Height;

            float scale = Math.Max(scaleX, scaleY);

            int newW = Math.Max(1, (int)Math.Ceiling(src.Width * scale));
            int newH = Math.Max(1, (int)Math.Ceiling(src.Height * scale));

            Bitmap dest = new Bitmap(newW, newH);
            dest.SetResolution(src.HorizontalResolution, src.VerticalResolution);

            using (Graphics g = Graphics.FromImage(dest))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                g.Clear(Color.Transparent);
                Direct.DrawNoBleed(g, src, new Rectangle(0, 0, newW, newH), 0, 0, src.Width, src.Height);
            }

            return dest;
        }

        public static void SaveFillCrop(Image original, PictureBox pb, Panel panel, int targetW, int targetH, string outPath, Size? frame = null)
            => SaveCrop(original, pb, panel, targetW, targetH, outPath, true, frame);

        public static void SaveUniformCrop(Image original, PictureBox pb, Panel panel, int targetW, int targetH, string outPath, Size? frame = null)
            => SaveCrop(original, pb, panel, targetW, targetH, outPath, false, frame);

        internal static Rectangle FitInside(Size size, Rectangle bounds)
        {
            float scale = Math.Min((float)bounds.Width / size.Width, (float)bounds.Height / size.Height);
            int w = (int)Math.Round(size.Width * scale);
            int h = (int)Math.Round(size.Height * scale);
            return new Rectangle(bounds.X + (bounds.Width - w) / 2, bounds.Y + (bounds.Height - h) / 2, w, h);
        }

        internal static RectangleF SourceRegion(Image original, PictureBox pb, Panel panel, Size target, bool fill, Size? frame)
        {
            if (pb.ClientSize.Width <= 0 || pb.ClientSize.Height <= 0) return RectangleF.Empty;
            var visible = pb.RectangleToClient(panel.RectangleToScreen(new Rectangle(Point.Empty, frame ?? panel.ClientSize)));
            float sx = (float)original.Width / pb.ClientSize.Width;
            float sy = (float)original.Height / pb.ClientSize.Height;
            var source = new RectangleF(visible.X * sx, visible.Y * sy, visible.Width * sx, visible.Height * sy);
            if (!fill)
                return RectangleF.Intersect(source, new RectangleF(0, 0, original.Width, original.Height));

            int w = (int)Math.Round(source.Width);
            int h = (int)Math.Round(source.Height);
            float aspect = (float)target.Width / target.Height;
            if ((long)w * target.Height > (long)h * target.Width)
                w = (int)Math.Round(h * aspect);
            else if ((long)w * target.Height < (long)h * target.Width)
                h = (int)Math.Round(w / aspect);

            int x = (int)Math.Round((visible.X + visible.Width / 2f) * sx - w / 2f);
            int y = (int)Math.Round((visible.Y + visible.Height / 2f) * sy - h / 2f);
            return new RectangleF(Math.Max(0, Math.Min(original.Width - w, x)),
                                  Math.Max(0, Math.Min(original.Height - h, y)), w, h);
        }

        private static void SaveCrop(Image original, PictureBox pb, Panel panel, int targetW, int targetH, string outPath, bool fill, Size? frame)
        {
            if (original == null) return;
            var source = SourceRegion(original, pb, panel, new Size(targetW, targetH), fill, frame);
            int cropW = (int)Math.Round(source.Width);
            int cropH = (int)Math.Round(source.Height);
            if (cropW <= 0 || cropH <= 0) return;

            using (Bitmap cropped = new Bitmap(cropW, cropH))
            {
                using (Graphics g = Graphics.FromImage(cropped))
                {
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    Direct.DrawNoBleed(g, original, new Rectangle(0, 0, cropW, cropH), source.X, source.Y, source.Width, source.Height);
                }

                using (Bitmap output = new Bitmap(targetW, targetH))
                {
                    using (Graphics g = Graphics.FromImage(output))
                    {
                        g.CompositingQuality = CompositingQuality.HighQuality;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        var destination = new Rectangle(0, 0, targetW, targetH);
                        if (!fill)
                        {
                            g.Clear(Color.Black);
                            destination = FitInside(cropped.Size, destination);
                        }
                        Direct.DrawNoBleed(g, cropped, destination, 0, 0, cropW, cropH);
                    }

                    output.Save(outPath, ImageFormat.Png);
                }
            }
        }
    }
}
