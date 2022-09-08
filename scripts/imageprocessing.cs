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
            public static Bitmap HighQiality(Image img, int width, int height)
            {
                var new_rect = new Rectangle(0, 0, width, height);
                var new_imge = new Bitmap(width, height);
                new_imge.SetResolution(img.HorizontalResolution, img.VerticalResolution);

                using (var graphics = Graphics.FromImage(new_imge))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    using (var wrapmode = new ImageAttributes())
                    {
                        wrapmode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(img, new_rect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, wrapmode);
                    }
                }
                return new_imge;
            }
            public static Bitmap LowQiality(Image img, int width, int height)
            {
                var new_rect = new Rectangle(0, 0, width, height);
                var new_imge = new Bitmap(width, height);
                new_imge.SetResolution(img.HorizontalResolution, img.VerticalResolution);

                using (var graphics = Graphics.FromImage(new_imge))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighSpeed;
                    graphics.InterpolationMode = InterpolationMode.Default;
                    graphics.SmoothingMode = SmoothingMode.None;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                    using (var wrapmode = new ImageAttributes())
                    {
                        wrapmode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(img, new_rect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, wrapmode);
                    }
                }
                return new_imge;
            }
            public static Bitmap Crop(Image img, int x, int y, int x2, int y2)
            {
                Rectangle crop_dim = new Rectangle(x, y, x2-x, y2-y);
                Bitmap new_img = new Bitmap(crop_dim.Width, crop_dim.Height);
                new_img.SetResolution(img.HorizontalResolution, img.VerticalResolution);
                using (Graphics g = Graphics.FromImage(new_img))
                {
                    g.DrawImage(img, -crop_dim.X, -crop_dim.Y);
                    return new_img;
                }
            }
        }

        public static void Zoom(PictureBox pic, Panel pnl, MouseEventArgs mse, float aspect_ratio, float factor)
        {
            double Width = pic.Width + factor * aspect_ratio;
            double Height = pic.Height + factor;
            Bitmap img = new Bitmap("temp/portrait_poor.png");

            if (Width > pnl.Width && Height > pnl.Height)
            {
                pic.Image = new Bitmap(Resize.HighQiality(img, Convert.ToInt32(Width), Convert.ToInt32(Height)));
                Utils.ArrangePanel(pnl, pic.Height, pic.Width);
                pnl.AutoScrollPosition = new Point((int)(mse.X - pnl.Width / 2), (int)(mse.Y - pnl.Height / 2));
                //Console.WriteLine("------");
                //Console.WriteLine(pnl.AutoScrollPosition);
                //Console.WriteLine(pnl.Width);
                //Console.WriteLine(pnl.Height);
                //Console.WriteLine(mse.X + " " + mse.Y);
            }
            img.Dispose();
        }
    }

    public class Utils
    {
        public static void Clear(PictureBox img)
        {
            img.Image.Dispose();
            img.Image = PathfinderKINGPortrait.Properties.Resources._default;
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
}
