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
    /// Basic whole-image bitmap operations (high-quality resize).
    public class Direct
    {
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
                Rectangle srcRect = new Rectangle(0, 0, inImage.Width, inImage.Height);
                newRenderer.DrawImage(inImage, destRect, srcRect, GraphicsUnit.Pixel);
            }
            return outImage;
        }
    }

    /// Crops the portion of a portrait image currently visible in its editor viewport and saves it at a target size.
    public static class PortraitCrop
    {
        /// Uniform-scale a source image so it fills the target box, cropping the overflow (used for portrait editor picture boxes).
        public static Image ResizeCover(Image src, int boxWidth, int boxHeight)
        {
            if (src == null || boxWidth <= 0 || boxHeight <= 0)
                return src == null ? null : new Bitmap(src);

            float scaleX = (float)boxWidth / src.Width;
            float scaleY = (float)boxHeight / src.Height;
            // cover: pick the larger scale so the image fills the box and overflows one axis
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
                g.DrawImage(src, 0, 0, newW, newH);
            }

            return dest;
        }

        /// Crops the panel's visible area from the original image and saves it stretched to exactly fill the target size (no letterboxing) - used for Owlcat games (Kingmaker/WotR/Rogue Trader).
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

            // Center of the visible area in original image coordinates
            float centerX = (visible.X + visible.Width / 2f) * scaleX;
            float centerY = (visible.Y + visible.Height / 2f) * scaleY;

            // Initial crop from the visible area
            int cropW = (int)Math.Round(visible.Width * scaleX);
            int cropH = (int)Math.Round(visible.Height * scaleY);
            if (cropW <= 0 || cropH <= 0) return;

            // Force the crop rectangle to have exactly the target aspect ratio
            // so the final resize is a pure uniform scale with no distortion
            float targetAR = (float)targetW / targetH;
            if (cropW * targetH > cropH * targetW)
                cropW = (int)Math.Round(cropH * targetAR);
            else if (cropW * targetH < cropH * targetW)
                cropH = (int)Math.Round(cropW / targetAR);

            // Center the crop on the user's view, clamped to image bounds
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
                    g.DrawImage(original,
                        new Rectangle(0, 0, cropW, cropH),
                        new RectangleF(cropX, cropY, cropW, cropH),
                        GraphicsUnit.Pixel);
                }

                // Pure uniform resize — AR already matches exactly
                using (Bitmap output = new Bitmap(targetW, targetH))
                {
                    using (Graphics g = Graphics.FromImage(output))
                    {
                        g.CompositingQuality = CompositingQuality.HighQuality;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                        g.DrawImage(cropped,
                            new Rectangle(0, 0, targetW, targetH),
                            new Rectangle(0, 0, cropW, cropH),
                            GraphicsUnit.Pixel);
                    }

                    output.Save(outPath, ImageFormat.Png);
                }
            }
        }

        /// Crops the panel's visible area from the original image and saves it uniformly scaled to fit within the target size, letterboxed in black - used for non-Owlcat games (PoE/Deadfire/Tyranny/Wasteland 3).
        public static void SaveUniformCrop(
            Image original,
            PictureBox pb,
            Panel panel,
            int targetW,
            int targetH,
            string outPath,
            char gameSelected)
        {
            if (original == null) return;

            int imgW = original.Width;
            int imgH = original.Height;

            // The panel viewport, mapped into picture-box coordinates.
            Rectangle visible = pb.RectangleToClient(
                panel.RectangleToScreen(panel.ClientRectangle));

            if (visible.Width <= 0 || visible.Height <= 0) return;

            // Map from displayed pixels back to original image pixels.
            float scaleX = (float)imgW / pb.ClientSize.Width;
            float scaleY = (float)imgH / pb.ClientSize.Height;

            float srcX = visible.X * scaleX;
            float srcY = visible.Y * scaleY;
            float srcW = visible.Width * scaleX;
            float srcH = visible.Height * scaleY;

            // Clamp to image bounds
            if (srcX < 0) { srcW += srcX; srcX = 0; }
            if (srcY < 0) { srcH += srcY; srcY = 0; }
            if (srcX + srcW > imgW) srcW = imgW - srcX;
            if (srcY + srcH > imgH) srcH = imgH - srcY;

            if (srcW <= 0 || srcH <= 0) return;

            int cropW = (int)Math.Round(srcW);
            int cropH = (int)Math.Round(srcH);
            if (cropW <= 0 || cropH <= 0) return;

            // Step 1 — crop the visible area from the original
            using (Bitmap cropped = new Bitmap(cropW, cropH))
            {
                using (Graphics g = Graphics.FromImage(cropped))
                {
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.DrawImage(original,
                        new Rectangle(0, 0, cropW, cropH),
                        new RectangleF(srcX, srcY, srcW, srcH),
                        GraphicsUnit.Pixel);
                }

                // Step 2 — uniform-resize to target dimensions (no stretching)
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

                        if (gameSelected == 't' && targetW == 76 && targetH == 96)
                        {
                            try
                            {
                                string log =
                                    $"[{DateTime.Now:HH:mm:ss}] Tyranny SMALL diagnostic{Environment.NewLine}" +
                                    $"  img: {imgW}x{imgH}  aspect={(float)imgW / imgH:F5}{Environment.NewLine}" +
                                    $"  panel.ClientSize: {panel.ClientSize.Width}x{panel.ClientSize.Height}{Environment.NewLine}" +
                                    $"  pb.ClientSize: {pb.ClientSize.Width}x{pb.ClientSize.Height}  pb.Size: {pb.Size.Width}x{pb.Size.Height}  pb.Location: {pb.Location}{Environment.NewLine}" +
                                    $"  panel.Visible(chain): {panel.Visible}  pb.Visible: {pb.Visible}{Environment.NewLine}" +
                                    $"  visible rect (pb-local): {visible}{Environment.NewLine}" +
                                    $"  scaleX/scaleY: {scaleX:F5}/{scaleY:F5}{Environment.NewLine}" +
                                    $"  src rect: X={srcX:F2} Y={srcY:F2} W={srcW:F2} H={srcH:F2}{Environment.NewLine}" +
                                    $"  crop: {cropW}x{cropH}{Environment.NewLine}" +
                                    $"  target: {targetW}x{targetH}  scale={scale:F5}  dest: {destW}x{destH} at ({destX},{destY}){Environment.NewLine}{Environment.NewLine}";
                                File.AppendAllText(Path.Combine(Path.GetTempPath(), "zpm_tyranny_debug.log"), log);
                            }
                            catch { }
                        }

                        g.DrawImage(cropped,
                            new Rectangle(destX, destY, destW, destH),
                            new Rectangle(0, 0, cropW, cropH),
                            GraphicsUnit.Pixel);
                    }

                    output.Save(outPath, ImageFormat.Png);
                }
            }
        }
    }
}
