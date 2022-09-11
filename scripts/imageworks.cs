using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ImageControl
{
    public class Direct
    {
        public class Resize
        {
            public static Bitmap HighQuality(Image src_img, int width, int height)
            {
                Rectangle dst_rect = new Rectangle(0, 0, width, height);
                Bitmap dst_img = new Bitmap(width, height);

                dst_img.SetResolution(src_img.HorizontalResolution, src_img.VerticalResolution);
                using (Graphics grphcs = Graphics.FromImage(dst_img))
                {
                    grphcs.CompositingMode = CompositingMode.SourceCopy;
                    grphcs.CompositingQuality = CompositingQuality.HighQuality;
                    grphcs.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    grphcs.SmoothingMode = SmoothingMode.HighQuality;
                    grphcs.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    using (var wrpmd = new ImageAttributes())
                    {
                        wrpmd.SetWrapMode(WrapMode.TileFlipXY);
                        grphcs.DrawImage(src_img, dst_rect, 0, 0, src_img.Width, src_img.Height, GraphicsUnit.Pixel, wrpmd);
                    }
                }

                return dst_img;
            }
            public static Bitmap LowQiality(Image src_img, int width, int height)
            {
                Rectangle dst_rect = new Rectangle(0, 0, width, height);
                Bitmap dst_img = new Bitmap(width, height);

                dst_img.SetResolution(src_img.HorizontalResolution, src_img.VerticalResolution);
                using (Graphics grphcs = Graphics.FromImage(dst_img))
                {
                    grphcs.CompositingMode = CompositingMode.SourceCopy;
                    grphcs.CompositingQuality = CompositingQuality.HighSpeed;
                    grphcs.InterpolationMode = InterpolationMode.Default;
                    grphcs.SmoothingMode = SmoothingMode.None;
                    grphcs.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                    using (var wrpmd = new ImageAttributes())
                    {
                        wrpmd.SetWrapMode(WrapMode.TileFlipXY);
                        grphcs.DrawImage(src_img, dst_rect, 0, 0, src_img.Width, src_img.Height, GraphicsUnit.Pixel, wrpmd);
                    }
                }

                return dst_img;
            }
            public static Bitmap Crop(Image src_img, int x0, int y0, int x1, int y1)
            {
                Rectangle dst_rect = new Rectangle(x0, y0, x1 - x0, y1 - y0);
                Bitmap dst_img = new Bitmap(dst_rect.Width, dst_rect.Height);

                dst_img.SetResolution(src_img.HorizontalResolution, src_img.VerticalResolution);
                using (Graphics grphcs = Graphics.FromImage(dst_img))
                    grphcs.DrawImage(src_img, -dst_rect.X, -dst_rect.Y);

                return dst_img;
            }
        }
        public static void Zoom(PictureBox pic, Panel pnl, MouseEventArgs msvnt, float aspect_ratio, float factor)
        {
            float width = pic.Width + factor * aspect_ratio,
                  height = pic.Height + factor;

            using (Bitmap img = new Bitmap("temp\\portrait_poor.png"))
            {
                if (width > pnl.Width && height > pnl.Height)
                {
                    pic.Image = new Bitmap(Resize.LowQiality(img, Convert.ToInt32(width), Convert.ToInt32(height)));
                    Utils.ArrangePnlAroundPic(pnl, pic.Height, pic.Width);
                    pnl.AutoScrollPosition = new Point((msvnt.X - pnl.Width / 2), (msvnt.Y - pnl.Height / 2));
                }
            }
        }
        public static void WorsenQuality(Image src_img, string fullpath) 
        { 
            using (Bitmap img = new Bitmap(src_img))
            {
                ImageCodecInfo png_encdr = GetEncoder(ImageFormat.Png);
                System.Drawing.Imaging.Encoder custom_encdr = System.Drawing.Imaging.Encoder.Quality; 
                EncoderParameters custom_encdr_params = new EncoderParameters(1);
                EncoderParameter custom_encdr_param = new EncoderParameter(custom_encdr, 20L);

                custom_encdr_params.Param[0] = custom_encdr_param;
                img.Save(fullpath, png_encdr, custom_encdr_params);
                custom_encdr_param.Dispose();
                custom_encdr_params.Dispose();
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
        public static void Clear(PictureBox img, Image img_default)
        {
            img.Image.Dispose();
            img.Image = img_default;
        }
        public static void ArrangePnlAroundPic(Panel pnl, int x_max, int y_max)
        {
            pnl.AutoScroll = false;
            pnl.VerticalScroll.Minimum = 0;
            pnl.HorizontalScroll.Minimum = 0;
            pnl.VerticalScroll.Maximum = x_max;
            pnl.HorizontalScroll.Maximum = y_max;
            pnl.VerticalScroll.Visible = true;
            pnl.HorizontalScroll.Visible = true;
        }
    }
    public class Wraps
    {
        public static Image CropImage(PictureBox pic, Panel pnl, float aspect_ratio, int to_x, int to_y)
        {
            Image original_image = new Bitmap("temp\\portrait_full.png");
            float factor = original_image.Width * 1.0f / pic.Image.Width * 1.0f;
            int x = -(int)(pnl.AutoScrollPosition.X * factor),
                y = -(int)(pnl.AutoScrollPosition.Y * factor),                
                x_w = (int)(pnl.Width * factor),
                y_w = (int)(x_w * aspect_ratio),
                x2 = x_w + x,
                y2 = y_w + y;
            original_image = Direct.Resize.Crop(original_image, x, y, x2, y2);
            original_image = Direct.Resize.HighQuality(original_image, to_x, to_y);
            return original_image;
        }
        public static void CreatePoorImage(Image src_img, string fullpath)
        {
            float aspect_ratio, decrease_power;
            aspect_ratio = src_img.Width * 1.0f / src_img.Height * 1.0f;
            decrease_power = src_img.Width * 1.0f / 100 * 50;

            src_img = Direct.Resize.LowQiality(src_img, (int)(decrease_power * aspect_ratio), (int)(decrease_power));
            using (Image img = new Bitmap(src_img))
                Direct.WorsenQuality(img, fullpath);
            src_img.Dispose();
        }
    }
}
