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
            public static Bitmap HighQuality(Image src_image, int w, int h)
            {
                Rectangle dst_rectangle = new Rectangle(0, 0, w, h);
                Bitmap dst_image = new Bitmap(w, h);
                dst_image.SetResolution(src_image.HorizontalResolution, src_image.VerticalResolution);
                using (Graphics grphcs = Graphics.FromImage(dst_image))
                {
                    grphcs.CompositingMode = CompositingMode.SourceCopy;
                    grphcs.CompositingQuality = CompositingQuality.HighQuality;
                    grphcs.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    grphcs.SmoothingMode = SmoothingMode.HighQuality;
                    grphcs.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    using (var wrpmd = new ImageAttributes())
                    {
                        wrpmd.SetWrapMode(WrapMode.TileFlipXY);
                        grphcs.DrawImage(src_image, dst_rectangle, 0, 0, src_image.Width, src_image.Height, GraphicsUnit.Pixel, wrpmd);
                    }
                }
                return dst_image;
            }
            public static Bitmap LowQiality(Image src_image, int w, int h)
            {
                Rectangle dst_rectangle = new Rectangle(0, 0, w, h);
                Bitmap dst_image = new Bitmap(w, h);
                dst_image.SetResolution(src_image.HorizontalResolution, src_image.VerticalResolution);
                using (Graphics grphcs = Graphics.FromImage(dst_image))
                {
                    grphcs.CompositingMode = CompositingMode.SourceCopy;
                    grphcs.CompositingQuality = CompositingQuality.HighSpeed;
                    grphcs.InterpolationMode = InterpolationMode.Default;
                    grphcs.SmoothingMode = SmoothingMode.None;
                    grphcs.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                    using (var wrpmd = new ImageAttributes())
                    {
                        wrpmd.SetWrapMode(WrapMode.TileFlipXY);
                        grphcs.DrawImage(src_image, dst_rectangle, 0, 0, src_image.Width, src_image.Height, GraphicsUnit.Pixel, wrpmd);
                    }
                }
                return dst_image;
            }
            public static Bitmap Crop(Image src_image, int x0, int y0, int x1, int y1)
            {
                Rectangle dst_rect = new Rectangle(x0, y0, x1 - x0, y1 - y0);
                Bitmap dst_imge = new Bitmap(dst_rect.Width, dst_rect.Height);
                dst_imge.SetResolution(src_image.HorizontalResolution, src_image.VerticalResolution);
                using (Graphics grphcs = Graphics.FromImage(dst_imge))
                    grphcs.DrawImage(src_image, -dst_rect.X, -dst_rect.Y);
                return dst_imge;
            }
        }
        public static void Zoom(PictureBox pic, Panel pnl, MouseEventArgs msvnt, float aspect_ratio, float factor)
        {
            float w = pic.Width + factor * aspect_ratio,
                  h = pic.Height + factor;
            using (Bitmap img = new Bitmap("temp\\portrait_poor.png"))
            {
                if (w > pnl.Width && h > pnl.Height)
                {
                    pic.Image = new Bitmap(Resize.LowQiality(img, Convert.ToInt32(w), Convert.ToInt32(h)));
                    Utils.ArrangePanel(pnl, pic.Height, pic.Width);
                    pnl.AutoScrollPosition = new Point((msvnt.X - pnl.Width / 2), (msvnt.Y - pnl.Height / 2));
                }
            }
        }
        public static void WorsenQuality(Image origin_img, string fullpath) 
        { 
            using (Bitmap img = new Bitmap(origin_img))
            {
                ImageCodecInfo png_encdr = GetEncoder(ImageFormat.Png);
                System.Drawing.Imaging.Encoder custom_encdr = System.Drawing.Imaging.Encoder.Quality; 
                EncoderParameters custom_encdr_params = new EncoderParameters(1);
                EncoderParameter custmo_encdr_param = new EncoderParameter(custom_encdr, 20L);
                custom_encdr_params.Param[0] = custmo_encdr_param;
                img.Save(fullpath, png_encdr, custom_encdr_params);
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
        public static void ArrangePanel(Panel pnl, int x_max, int y_max)
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
        public static void CreatePoorImage(Image origin_img, string fullpath)
        {
            float aspect_ratio, decrease_power;
            aspect_ratio = origin_img.Width * 1.0f / origin_img.Height * 1.0f;
            decrease_power = origin_img.Width * 1.0f / 100 * 50;
            origin_img = Direct.Resize.LowQiality(origin_img, (int)(decrease_power * aspect_ratio), (int)(decrease_power));
            using (Image img = new Bitmap(origin_img))
                Direct.WorsenQuality(img, fullpath);
            origin_img.Dispose();
        }
    }
}
