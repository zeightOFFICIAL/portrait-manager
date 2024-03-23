/*    
    Owlcat Portrait Manager. Desktop application for managing in game
    portraits for Owlcat Games products. Including Pathfinder: Kingmaker,
    Pathfinder: Wrath of the Righteous, Warhammer 40000: Rogue Trader
    Copyright (C) 2024 Artemii "Zeight" Saganenko.

    GPL-2.0 license terms are listed in LICENSE file.
    License header for this project is listed in Program.cs
*/

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ImageControl
{
    public class Direct
    {
        public static Bitmap Resize(Image inImage, int newWidth, int newHeight)
        {
            using (Bitmap outImage = new Bitmap(newWidth, newHeight))
            {
                outImage.SetResolution(inImage.HorizontalResolution, inImage.VerticalResolution);
                using (Graphics newRenderer = Graphics.FromImage(outImage))
                {
                    newRenderer.CompositingQuality = CompositingQuality.HighQuality;
                    newRenderer.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    newRenderer.SmoothingMode = SmoothingMode.HighQuality;
                    newRenderer.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    newRenderer.DrawImage(inImage, new Rectangle(0, 0, newWidth, newHeight));
                }

                return new Bitmap(outImage);
            }
        }
        
        public static Bitmap Zoom(Image inImage, int newWidth, int newHeight)
        {
            using (Bitmap img = new Bitmap(inImage))
            using (Bitmap outImage = new Bitmap(Resize(img, newWidth, newHeight)))
                return new Bitmap(outImage);
        }
        
        public static Bitmap Crop(Image inImage, int xStart, int yStart, int xEnd, int yEnd)
        {
            Rectangle rect = new Rectangle(xStart, yStart, xEnd - xStart, yEnd - yStart);
            Bitmap outImage = new Bitmap(rect.Width, rect.Height);

            outImage.SetResolution(inImage.HorizontalResolution, inImage.VerticalResolution);
            using (Graphics newRenderer = Graphics.FromImage(outImage))
                newRenderer.DrawImage(inImage, -rect.X, -rect.Y);

            return outImage;
        }
    }
    
    public class Utils
    {
        public static bool Replace(PictureBox pictureBox, Image toImage)
        {
            pictureBox.Image.Dispose();
            pictureBox.Image = toImage;

            return true;
        }
        
        public static bool Dispose(PictureBox pictureBox)
        {
            pictureBox.Image.Dispose();

            return true;
        }
    }
    
    public class Wraps
    {
        public static void ZoomImage(PictureBox pictureBox, Panel panel, MouseEventArgs mouseEvent, string imagePath, float aspect, float factor)
        {
            float newWidth = pictureBox.Width + factor * aspect;
            float newHeight = pictureBox.Height + factor;

            if (newWidth <= panel.Width || newHeight <= panel.Height)
            {
                return;
            }

            using (Bitmap img = new Bitmap(imagePath))
            {
                pictureBox.Image = Direct.Zoom(img, (int)newWidth, (int)newHeight);
                Concomitant.SetPanelScroll(panel, pictureBox.Width, pictureBox.Height);
                panel.AutoScrollPosition = new Point(mouseEvent.X - panel.Width / 2, mouseEvent.Y - panel.Height / 2);
            }
        }
        
        public static void CropImage(PictureBox pictureBox, Panel panel, string imagePath, string saveLocation, float aspect, int newWidth, int newHeight)
        {
            using (Image inImage = new Bitmap(imagePath))
            {
                float factor = inImage.Width * 1.0f / pictureBox.Image.Width * 1.0f;
                Tuple<int, int, int, int> rectanglePoints = CalculateCropRectangle(panel, factor, aspect, inImage.Height, inImage.Width);

                using (Image croppedImage = Direct.Crop(inImage, rectanglePoints.Item1, rectanglePoints.Item2, rectanglePoints.Item3, rectanglePoints.Item4))
                using (Image resizedImage = Direct.Resize(croppedImage, newWidth, newHeight))
                {
                    resizedImage.Save(saveLocation);
                    resizedImage.Dispose();
                }
            }
        }
        
        public static Tuple<int, int, int, int> CalculateCropRectangle(Panel panel, float factor, float aspect, int height, int width)
        {
            int xStart = -(int)(panel.AutoScrollPosition.X * factor),
                yStart = -(int)(panel.AutoScrollPosition.Y * factor),
                xSize = (int)(panel.Width * factor),
                ySize = (int)(xSize * aspect);

            int xEnd = xSize + xStart,
                yEnd = ySize + yStart;

            if (yEnd > height || xEnd > width)
            {
                ySize = (int)(panel.Height * factor);
                xSize = (int)(ySize * 1.0f / aspect * 1.0f);
                xEnd = xSize + xStart;
                yEnd = ySize + yStart;
            }

            return Tuple.Create(xStart, yStart, xEnd, yEnd);
        }
    }
    
    public class Concomitant
    {
        public static void SetPanelScroll(Panel panel, int xMax, int yMax)
        {
            panel.AutoScroll = false;
            panel.VerticalScroll.Minimum = 0;
            panel.HorizontalScroll.Minimum = 0;
            panel.VerticalScroll.Maximum = xMax;
            panel.HorizontalScroll.Maximum = yMax;
            panel.VerticalScroll.Visible = true;
            panel.HorizontalScroll.Visible = true;
        }
    }
}
