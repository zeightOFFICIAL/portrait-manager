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

        public static void SaveFillCrop(
            Image original,
            PictureBox pb,
            Panel panel,
            int targetW,
            int targetH,
            string outPath)
        {
            if (original == null) return;

            int imgW = original.Width;
            int imgH = original.Height;

            Rectangle visible = pb.RectangleToClient(
                panel.RectangleToScreen(panel.ClientRectangle));

            if (visible.Width <= 0 || visible.Height <= 0) return;

            float scaleX = (float)imgW / pb.ClientSize.Width;
            float scaleY = (float)imgH / pb.ClientSize.Height;

            float centerX = (visible.X + visible.Width / 2f) * scaleX;
            float centerY = (visible.Y + visible.Height / 2f) * scaleY;

            int cropW = (int)Math.Round(visible.Width * scaleX);
            int cropH = (int)Math.Round(visible.Height * scaleY);
            if (cropW <= 0 || cropH <= 0) return;

            float targetAR = (float)targetW / targetH;
            if (cropW * targetH > cropH * targetW)
                cropW = (int)Math.Round(cropH * targetAR);
            else if (cropW * targetH < cropH * targetW)
                cropH = (int)Math.Round(cropW / targetAR);

            int cropX = Math.Max(0, Math.Min(imgW - cropW,
                (int)Math.Round(centerX - cropW / 2f)));
            int cropY = Math.Max(0, Math.Min(imgH - cropH,
                (int)Math.Round(centerY - cropH / 2f)));

            using (Bitmap cropped = new Bitmap(cropW, cropH))
            {
                using (Graphics g = Graphics.FromImage(cropped))
                {
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    Direct.DrawNoBleed(g, original, new Rectangle(0, 0, cropW, cropH), cropX, cropY, cropW, cropH);
                }

                using (Bitmap output = new Bitmap(targetW, targetH))
                {
                    using (Graphics g = Graphics.FromImage(output))
                    {
                        g.CompositingQuality = CompositingQuality.HighQuality;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                        Direct.DrawNoBleed(g, cropped, new Rectangle(0, 0, targetW, targetH), 0, 0, cropW, cropH);
                    }

                    output.Save(outPath, ImageFormat.Png);
                }
            }
        }

        public static void SaveUniformCrop(
            Image original,
            PictureBox pb,
            Panel panel,
            int targetW,
            int targetH,
            string outPath)
        {
            if (original == null) return;

            int imgW = original.Width;
            int imgH = original.Height;

            Rectangle visible = pb.RectangleToClient(
                panel.RectangleToScreen(panel.ClientRectangle));

            if (visible.Width <= 0 || visible.Height <= 0) return;

            float scaleX = (float)imgW / pb.ClientSize.Width;
            float scaleY = (float)imgH / pb.ClientSize.Height;

            float srcX = visible.X * scaleX;
            float srcY = visible.Y * scaleY;
            float srcW = visible.Width * scaleX;
            float srcH = visible.Height * scaleY;

            if (srcX < 0) { srcW += srcX; srcX = 0; }
            if (srcY < 0) { srcH += srcY; srcY = 0; }
            if (srcX + srcW > imgW) srcW = imgW - srcX;
            if (srcY + srcH > imgH) srcH = imgH - srcY;

            if (srcW <= 0 || srcH <= 0) return;

            int cropW = (int)Math.Round(srcW);
            int cropH = (int)Math.Round(srcH);
            if (cropW <= 0 || cropH <= 0) return;

            using (Bitmap cropped = new Bitmap(cropW, cropH))
            {
                using (Graphics g = Graphics.FromImage(cropped))
                {
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    Direct.DrawNoBleed(g, original, new Rectangle(0, 0, cropW, cropH), srcX, srcY, srcW, srcH);
                }

                using (Bitmap output = new Bitmap(targetW, targetH))
                {
                    using (Graphics g = Graphics.FromImage(output))
                    {
                        g.CompositingQuality = CompositingQuality.HighQuality;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        g.Clear(Color.Black);

                        float scale = Math.Min(
                            (float)targetW / cropW,
                            (float)targetH / cropH);
                        int destW = (int)Math.Round(cropW * scale);
                        int destH = (int)Math.Round(cropH * scale);
                        int destX = (targetW - destW) / 2;
                        int destY = (targetH - destH) / 2;

                        Direct.DrawNoBleed(g, cropped, new Rectangle(destX, destY, destW, destH), 0, 0, cropW, cropH);
                    }

                    output.Save(outPath, ImageFormat.Png);
                }
            }
        }
    }
}
