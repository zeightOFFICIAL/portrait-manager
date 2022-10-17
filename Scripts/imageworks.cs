using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;

namespace ImageControl
{
    public class Direct
    {
        public class Resize
        {
            public static Bitmap HighQuality(Image srcImg, int toWidth, int toHeight)
            {
                Rectangle dstRect = new Rectangle(0, 0, toWidth, toHeight);
                Bitmap dstImg = new Bitmap(toWidth, toHeight);

                dstImg.SetResolution(srcImg.HorizontalResolution, srcImg.VerticalResolution);
                using (Graphics newRenderer = Graphics.FromImage(dstImg))
                {
                    newRenderer.CompositingMode = CompositingMode.SourceCopy;
                    newRenderer.CompositingQuality = CompositingQuality.HighQuality;
                    newRenderer.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    newRenderer.SmoothingMode = SmoothingMode.HighQuality;
                    newRenderer.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    using (ImageAttributes wrapMode = new ImageAttributes())
                    {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        newRenderer.DrawImage(srcImg, dstRect, 0, 0, srcImg.Width, srcImg.Height, GraphicsUnit.Pixel, wrapMode);
                    }
                }

                return dstImg;
            }
            public static Bitmap LowQiality(Image srcImg, int toWidth, int toHeight)
            {
                Rectangle dstRect = new Rectangle(0, 0, toWidth, toHeight);
                Bitmap dstImg = new Bitmap(toWidth, toHeight);

                dstImg.SetResolution(srcImg.HorizontalResolution, srcImg.VerticalResolution);
                using (Graphics newRenderer = Graphics.FromImage(dstImg))
                {
                    newRenderer.CompositingMode = CompositingMode.SourceCopy;
                    newRenderer.CompositingQuality = CompositingQuality.HighSpeed;
                    newRenderer.InterpolationMode = InterpolationMode.Low;
                    newRenderer.SmoothingMode = SmoothingMode.None;
                    newRenderer.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                    using (ImageAttributes warpmode = new ImageAttributes())
                    {
                        warpmode.SetWrapMode(WrapMode.TileFlipXY);
                        newRenderer.DrawImage(srcImg, dstRect, 0, 0, srcImg.Width, srcImg.Height, GraphicsUnit.Pixel, warpmode);
                    }
                }

                return dstImg;
            }
        }
        public static void Zoom(PictureBox pictureBox, Panel panel, MouseEventArgs mouseEvents, string fullPath, float aspectRatio, float factor)
        {
            void ArrangePanel(int xMax, int yMax)
            {
                panel.AutoScroll = false;
                panel.VerticalScroll.Minimum = 0;
                panel.HorizontalScroll.Minimum = 0;
                panel.VerticalScroll.Maximum = xMax;
                panel.HorizontalScroll.Maximum = yMax;
                panel.VerticalScroll.Visible = true;
                panel.HorizontalScroll.Visible = true;
            }

            float newWidth = pictureBox.Width + factor * aspectRatio,
                  newHeight = pictureBox.Height + factor;

            using (Bitmap newImg = new Bitmap(fullPath))
            {
                if (newWidth > panel.Width && newHeight > panel.Height)
                {
                    pictureBox.Image = new Bitmap(Resize.LowQiality(newImg, Convert.ToInt32(newWidth), Convert.ToInt32(newHeight)));
                    ArrangePanel(pictureBox.Width, pictureBox.Height);
                    panel.AutoScrollPosition = new Point((mouseEvents.X - panel.Width / 2), (mouseEvents.Y - panel.Height / 2));
                }
            }
        }
        public static Bitmap Crop(Image srcImg, int xStart, int yStart, int xEnd, int yEnd)
        {
            Rectangle dstRect = new Rectangle(xStart, yStart, xEnd - xStart, yEnd - yStart);
            Bitmap dstImg = new Bitmap(dstRect.Width, dstRect.Height);

            dstImg.SetResolution(srcImg.HorizontalResolution, srcImg.VerticalResolution);
            using (Graphics newRenderer = Graphics.FromImage(dstImg))
                newRenderer.DrawImage(srcImg, -dstRect.X, -dstRect.Y);

            return dstImg;
        }
        public static void SaveWorstVersion(Image srcImg, string fullPath)
        {
            using (Bitmap newImg = new Bitmap(srcImg))
            {
                ImageCodecInfo pngEncoder = GetEncoder(ImageFormat.Png);
                Encoder customEncoder = Encoder.Quality;
                EncoderParameters customEncoderParams = new EncoderParameters(1);
                EncoderParameter customEncoderParam = new EncoderParameter(customEncoder, 80L);

                customEncoderParams.Param[0] = customEncoderParam;
                newImg.Save(fullPath, pngEncoder, customEncoderParams);
                customEncoderParam.Dispose();
                customEncoderParams.Dispose();
            }
        }
        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            foreach (ImageCodecInfo codec in codecs)
                if (codec.FormatID == format.Guid)
                    return codec;
            return null;
        }
    }
    public class Utils
    {
        public static void Replace(PictureBox pictureBox, Image toImage)
        {
            pictureBox.Image.Dispose();
            pictureBox.Image = toImage;
        }
        public static void Dispose(PictureBox pictureBox)
        {
            pictureBox.Image.Dispose();
        }
    }
    public class Wraps
    {
        public static void CropImage(PictureBox pictureBox, Panel panel, string fullPath, string saveLocation, float aspectRatio, int toX, int toY)
        {
            using (Image srcImg = new Bitmap(fullPath))
            {
                Image newImg = new Bitmap(srcImg);
                float factor = srcImg.Width * 1.0f / pictureBox.Image.Width * 1.0f;
                Tuple<int, int, int, int> tuple = MapNewRectangle(panel, factor, aspectRatio, srcImg.Height, srcImg.Width);
                newImg = Direct.Crop(newImg, tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
                newImg = Direct.Resize.HighQuality(newImg, toX, toY);
                newImg.Save(saveLocation);
                newImg.Dispose();
            }
        }
        private static Tuple<int, int, int, int> MapNewRectangle(Panel panel, float factor, float aspectRatio, int height, int width)
        {
            int xStart = -(int)(panel.AutoScrollPosition.X * factor),
                yStart = -(int)(panel.AutoScrollPosition.Y * factor),
                xSize = (int)(panel.Width * factor),
                ySize = (int)(xSize * aspectRatio);

            int xEnd = xSize + xStart,
                yEnd = ySize + yStart;
            if (yEnd > height || xEnd > width)
            {
                ySize = (int)(panel.Height * factor);
                xSize = (int)(ySize * 1.0f / aspectRatio * 1.0f);
                xEnd = xSize + xStart;
                yEnd = ySize + yStart;
            }
            return Tuple.Create<int, int, int, int>(xStart, yStart, xEnd, yEnd);
        }
        public static void CreatePoorImage(Image srcImg, string fullPath)
        {
            float aspectRatio = srcImg.Width * 1.0f / srcImg.Height * 1.0f,
                  decreasePower = srcImg.Width * 1.0f / 100 * 50;

            srcImg = Direct.Resize.LowQiality(srcImg, (int)(decreasePower * aspectRatio), (int)(decreasePower));
            using (Image img = new Bitmap(srcImg))
                Direct.SaveWorstVersion(img, fullPath);
            srcImg.Dispose();
        }
    }
}
