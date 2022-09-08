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
            public static Bitmap HighQialityResize(Image src_image, int width, int height)
            {
                Rectangle dst_rect = new Rectangle(0, 0, width, height);
                Bitmap dst_imge = new Bitmap(width, height);

                dst_imge.SetResolution(src_image.HorizontalResolution, src_image.VerticalResolution);
                using (Graphics graphics = Graphics.FromImage(dst_imge))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    using (var wrapmode = new ImageAttributes())
                    {
                        wrapmode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(src_image, dst_rect, 0, 0, src_image.Width, src_image.Height, GraphicsUnit.Pixel, wrapmode);
                    }
                }

                return dst_imge;
            }
            public static Bitmap LowQialityResize(Image src_image, int width, int height)
            {
                Rectangle dst_rect = new Rectangle(0, 0, width, height);
                Bitmap dst_imge = new Bitmap(width, height);

                dst_imge.SetResolution(src_image.HorizontalResolution, src_image.VerticalResolution);
                using (Graphics graphics = Graphics.FromImage(dst_imge))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighSpeed;
                    graphics.InterpolationMode = InterpolationMode.Default;
                    graphics.SmoothingMode = SmoothingMode.None;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                    using (var wrapmode = new ImageAttributes())
                    {
                        wrapmode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(src_image, dst_rect, 0, 0, src_image.Width, src_image.Height, GraphicsUnit.Pixel, wrapmode);
                    }
                }

                return dst_imge;
            }
            public static Bitmap CropImage(Image src_image, int x0, int y0, int x1, int y1)
            {
                Rectangle dst_rect = new Rectangle(x0, y0, x1-x0, y1-y0);
                Bitmap dst_imge = new Bitmap(dst_rect.Width, dst_rect.Height);

                dst_imge.SetResolution(src_image.HorizontalResolution, src_image.VerticalResolution);
                using (Graphics graphics = Graphics.FromImage(dst_imge))
                {
                    graphics.DrawImage(src_image, -dst_rect.X, -dst_rect.Y);
                }

                return dst_imge;
            }
        }
        public static void Zoom(PictureBox pic, Panel pnl, MouseEventArgs mse, float aspect_ratio, float factor)
        {
            double Width = pic.Width + factor * aspect_ratio,
                   Height = pic.Height + factor;
            Bitmap img = new Bitmap("temp\\portrait_poor.png");

            if (Width > pnl.Width && Height > pnl.Height)
            {
                pic.Image = new Bitmap(Resize.HighQialityResize(img, Convert.ToInt32(Width), Convert.ToInt32(Height)));
                Utils.ArrangePanel(pnl, pic.Height, pic.Width);
                pnl.AutoScrollPosition = new Point((int)(mse.X - pnl.Width / 2), (int)(mse.Y - pnl.Height / 2));
            }
            img.Dispose();
        }
    }

    public class Utils
    {
        public static void Clear(PictureBox img, Image img_default)
        {
            img.Image.Dispose();
            img.Image = img_default;
        }
        public static void ArrangePanel(Panel pnl, int vermax, int hormax)
        {
            pnl.AutoScroll = false;
            pnl.VerticalScroll.Minimum = 0;
            pnl.HorizontalScroll.Minimum = 0;
            pnl.VerticalScroll.Maximum = vermax;
            pnl.HorizontalScroll.Maximum = hormax;
            pnl.VerticalScroll.Visible = true;
            pnl.HorizontalScroll.Visible = true;
        }
    }

    public class Wraps
    {
        public static Image CropImage(PictureBox pic, Panel pnl, float aspect_ratio, int to_x, int to_y)
        {
            Image original_image = new Bitmap("temp/portrait_full.png");
            float factor = original_image.Width * 1.0f / pic.Image.Width * 1.0f;
            int x = -(int)(pnl.AutoScrollPosition.X * factor),
                y = -(int)(pnl.AutoScrollPosition.Y * factor),
                x_2 = (int)((x + pnl.Width * factor)),
                y_2 = (int)((x_2 - x) * aspect_ratio);
            original_image = Direct.Resize.CropImage(original_image, x, y, x_2, y_2);
            //original_image = Direct.Resize.HighQialityResize(original_image, to_x, to_y);
            return original_image;
        }
    }
}
