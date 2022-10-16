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
            public static Bitmap HighQuality(Image src_img, int to_width, int to_height)
            {
                Rectangle dst_rect = new Rectangle(0, 0, to_width, to_height);
                Bitmap dst_img = new Bitmap(to_width, to_height);

                dst_img.SetResolution(src_img.HorizontalResolution, src_img.VerticalResolution);
                using (Graphics graphics = Graphics.FromImage(dst_img))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    using (ImageAttributes wrapmode = new ImageAttributes())
                    {
                        wrapmode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(src_img, dst_rect, 0, 0, src_img.Width, src_img.Height, GraphicsUnit.Pixel, wrapmode);
                    }
                }

                return dst_img;
            }
            public static Bitmap LowQiality(Image src_img, int to_width, int to_height)
            {
                Rectangle dst_rect = new Rectangle(0, 0, to_width, to_height);
                Bitmap dst_img = new Bitmap(to_width, to_height);

                dst_img.SetResolution(src_img.HorizontalResolution, src_img.VerticalResolution);
                using (Graphics graphics = Graphics.FromImage(dst_img))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighSpeed;
                    graphics.InterpolationMode = InterpolationMode.Low;
                    graphics.SmoothingMode = SmoothingMode.None;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                    using (ImageAttributes warpmode = new ImageAttributes())
                    {
                        warpmode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(src_img, dst_rect, 0, 0, src_img.Width, src_img.Height, GraphicsUnit.Pixel, warpmode);
                    }
                }

                return dst_img;
            }
        }
        public static void Zoom(PictureBox picbox, Panel pnl, MouseEventArgs msvnt, string fullpath, float aspect_ratio, float factor)
        {
            void ArrangePanel(int x_max, int y_max)
            {
                pnl.AutoScroll = false;
                pnl.VerticalScroll.Minimum = 0;
                pnl.HorizontalScroll.Minimum = 0;
                pnl.VerticalScroll.Maximum = x_max;
                pnl.HorizontalScroll.Maximum = y_max;
                pnl.VerticalScroll.Visible = true;
                pnl.HorizontalScroll.Visible = true;
            }

            float new_width = picbox.Width + factor * aspect_ratio,
                  new_height = picbox.Height + factor;

            using (Bitmap img = new Bitmap(fullpath))
            {
                if (new_width > pnl.Width && new_height > pnl.Height)
                {
                    picbox.Image = new Bitmap(Resize.LowQiality(img, Convert.ToInt32(new_width), Convert.ToInt32(new_height)));
                    ArrangePanel(picbox.Width, picbox.Height);
                    pnl.AutoScrollPosition = new Point((msvnt.X - pnl.Width / 2), (msvnt.Y - pnl.Height / 2));
                }
            }
        }
        public static Bitmap Crop(Image src_img, int x_start, int y_start, int x_end, int y_end)
        {
            Rectangle dst_rect = new Rectangle(x_start, y_start, x_end - x_start, y_end - y_start);
            Bitmap dst_img = new Bitmap(dst_rect.Width, dst_rect.Height);

            dst_img.SetResolution(src_img.HorizontalResolution, src_img.VerticalResolution);
            using (Graphics graphics = Graphics.FromImage(dst_img))
                graphics.DrawImage(src_img, -dst_rect.X, -dst_rect.Y);

            return dst_img;
        }
        public static void SaveWorstVersion(Image src_img, string fullpath) 
        { 
            using (Bitmap img = new Bitmap(src_img))
            {
                ImageCodecInfo png_encoder = GetEncoder(ImageFormat.Png);
                Encoder custom_encoder = Encoder.Quality; 
                EncoderParameters custom_encoder_params = new EncoderParameters(1);
                EncoderParameter custom_encoder_param = new EncoderParameter(custom_encoder, 80L);

                custom_encoder_params.Param[0] = custom_encoder_param;
                img.Save(fullpath, png_encoder, custom_encoder_params);
                custom_encoder_param.Dispose();
                custom_encoder_params.Dispose();
            }
        }
        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] cdcs = ImageCodecInfo.GetImageEncoders();

            foreach (ImageCodecInfo cdc in cdcs)
                if (cdc.FormatID == format.Guid)
                    return cdc;
            return null;
        }
    }
    public class Utils
    {
        public static void Replace(PictureBox picbox, Image to_image)
        {
            picbox.Image.Dispose();
            picbox.Image = to_image;
        }
        public static void Dispose(PictureBox picbox)
        {
            picbox.Image.Dispose();
        }
    }
    public class Wraps
    {
        public static void CropImage(PictureBox picbox, Panel pnl, string fullpath, string savelocation, float aspect_ratio, int to_x, int to_y)
        {
            using (Image original_image = new Bitmap(fullpath))
            {
                Image new_img = new Bitmap(original_image);
                float factor = original_image.Width * 1.0f / picbox.Image.Width * 1.0f;
                Tuple<int, int, int, int> tuple = MapNewRectangle(pnl, factor, aspect_ratio, original_image.Height, original_image.Width);
                new_img = Direct.Crop(new_img, tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
                new_img = Direct.Resize.HighQuality(new_img, to_x, to_y);
                new_img.Save(savelocation);
                new_img.Dispose();
            }       
        }
        private static Tuple<int, int, int, int> MapNewRectangle(Panel pnl, float factor, float aspect_ratio, int height, int width)
        {
            int x_start = -(int)(pnl.AutoScrollPosition.X * factor),
                y_start = -(int)(pnl.AutoScrollPosition.Y * factor),
                x_size = (int)(pnl.Width * factor),
                y_size = (int)(x_size * aspect_ratio);

            int x_end = x_size + x_start,
                y_end = y_size + y_start;
            if (y_end > height || x_end > width)
            {
                y_size = (int)(pnl.Height * factor);
                x_size = (int)(y_size * 1.0f / aspect_ratio * 1.0f);
                x_end = x_size + x_start;
                y_end = y_size + y_start;
            }
            return Tuple.Create<int, int, int, int>(x_start, y_start, x_end, y_end);
        }
        public static void CreatePoorImage(Image src_img, string fullpath)
        {
            float aspect_ratio = src_img.Width * 1.0f / src_img.Height * 1.0f,
                  decrease_power = src_img.Width * 1.0f / 100 * 50;

            src_img = Direct.Resize.LowQiality(src_img, (int)(decrease_power * aspect_ratio), (int)(decrease_power));
            using (Image img = new Bitmap(src_img))
                Direct.SaveWorstVersion(img, fullpath);
            src_img.Dispose();
        }
    }
}
