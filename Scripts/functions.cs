using System;
using System.Drawing;
using System.Windows.Forms;

namespace PathfinderKINGPortrait
{
    public partial class MainForm : Form
    {
        private void ClearImages()
        {
            ImageControl.Utils.Replace(PicPortraitTemp, PathfinderKINGPortrait.Properties.Resources.fulldefault);
            ImageControl.Utils.Replace(PicPortraitLrg, PathfinderKINGPortrait.Properties.Resources.fulldefault);
            ImageControl.Utils.Replace(PicPortraitMed, PathfinderKINGPortrait.Properties.Resources.fulldefault);
            ImageControl.Utils.Replace(PicPortraitSml, PathfinderKINGPortrait.Properties.Resources.fulldefault);
        }
        private void ResizeImageAsWindow(PictureBox pic, Image img, Panel pnl)
        {
            float aspect_ratio = (pic.Height * 1.0f / pic.Width * 1.0f);
            Tuple<int, int> tuple = MapNewWidthHeight(pnl, aspect_ratio);
            pic.Image = ImageControl.Direct.Resize.LowQiality(img, tuple.Item1, tuple.Item2);
            ArrangeAutoScroll(pnl, tuple.Item1, tuple.Item2);
        }
        private void ResizeAllImagesAsWindow()
        {
            if (LayoutScalePage.Enabled == true)
                using (Image img = new Bitmap(RELATIVEPATH_TO_TEMPPOOR))
                {
                    ResizeImageAsWindow(PicPortraitLrg, img, PanelPortraitLrg);
                    ResizeImageAsWindow(PicPortraitMed, img, PanelPortraitMed);
                    ResizeImageAsWindow(PicPortraitSml, img, PanelPortraitSml);
                }
            if (LayoutFilePage.Enabled == true)
            {
                using (Image img = new Bitmap(RELATIVEPATH_TO_TEMPFULL))
                {
                    ResizeImageAsWindow(PicPortraitTemp, img, PanelPortraitTemp);
                    ArrangeAutoScroll(PanelPortraitTemp, 0, 0);
                }
            }
        } 
        private static Tuple<int, int> MapNewWidthHeight(Panel pnl, float aspect_ratio)
        {
            int width = pnl.Width,
                height = pnl.Height,
                dst_width,
                dst_height;

            dst_height = height;
            dst_width = (int)(height * 1.0f / aspect_ratio * 1.0f);
            if (dst_width < pnl.Width)
            {
                dst_width = width;
                dst_height = (int)(width * 1.0f / (1.0f / aspect_ratio * 1.0f));
            }

            return Tuple.Create(dst_width, dst_height);
        }
        private void AllToNotEnabled()
        {
            LayoutMainPage.Visible = false;
            LayoutMainPage.Enabled = false;

            LayoutFilePage.Visible = false;
            LayoutFilePage.Enabled = false;
            LayoutMainPage.Visible = false;
            LayoutMainPage.Enabled = false;
            LayoutScalePage.Visible = false;
            LayoutScalePage.Enabled = false;
        }
        private void OverloadDockOnEverything()
        {
            LayoutFilePage.Dock = DockStyle.Fill;
            LayoutMainPage.Dock = DockStyle.Fill;
            LayoutScalePage.Dock = DockStyle.Fill;
        }
        private void ThisToEnabled(TableLayoutPanel table)
        {
            if (table.Visible == false && table.Enabled == false)
            {
                table.Visible = true;
                table.Enabled = true;
            }
        }
        private void LoadAllImages()
        {
            ClearImages();
            using (Image img_poor = new Bitmap(RELATIVEPATH_TO_TEMPPOOR))
            {
                PicPortraitLrg.Image = new Bitmap(img_poor);
                PicPortraitMed.Image = new Bitmap(img_poor);
                PicPortraitSml.Image = new Bitmap(img_poor);
            }
            using (Image img_full = new Bitmap(RELATIVEPATH_TO_TEMPFULL))
                PicPortraitTemp.Image = new Bitmap(img_full);
            ArrangeAutoScroll(PanelPortraitLrg, PicPortraitLrg.Height, PicPortraitLrg.Width);
            ArrangeAutoScroll(PanelPortraitMed, PicPortraitLrg.Height, PicPortraitLrg.Width);
            ArrangeAutoScroll(PanelPortraitSml, PicPortraitLrg.Height, PicPortraitLrg.Width);
            ResizeAllImagesAsWindow();
        }
        public static void ArrangeAutoScroll(Panel pnl, int x_max, int y_max)
        {
            pnl.AutoScroll = false;
            pnl.VerticalScroll.Minimum = 0;
            pnl.HorizontalScroll.Minimum = 0;
            pnl.VerticalScroll.Maximum = x_max;
            pnl.HorizontalScroll.Maximum = y_max;
            pnl.VerticalScroll.Visible = true;
            pnl.HorizontalScroll.Visible = true;
        }
        public static bool CheckExistence(string path)
        {
            if (SystemControl.FileControl.DirExists(path))
                if (SystemControl.FileControl.FileExist(path, LARGE_EXTENRSION) &&
                    SystemControl.FileControl.FileExist(path, MEDIUM_EXTENSION) &&
                    SystemControl.FileControl.FileExist(path, SMALL_EXTENSION))
                    if (SystemControl.FileControl.GetFileExtension(path, LARGE_EXTENRSION) == ".png" &&
                        SystemControl.FileControl.GetFileExtension(path, MEDIUM_EXTENSION) == ".png" &&
                        SystemControl.FileControl.GetFileExtension(path, SMALL_EXTENSION) == ".png")
                        return true;
                    else
                        return false;
                else
                    return false;
            else
                return false;
        }
    }
}
