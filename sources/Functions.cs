using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PathfinderPortraitManager
{
    public partial class MainForm : Form
    {
        private void ClearImages()
        {
            ImageControl.Utils.Replace(PicPortraitTemp, PathfinderPortraitManager.Properties.Resources.placeholder);
            ImageControl.Utils.Replace(PicPortraitLrg, PathfinderPortraitManager.Properties.Resources.placeholder);
            ImageControl.Utils.Replace(PicPortraitMed, PathfinderPortraitManager.Properties.Resources.placeholder);
            ImageControl.Utils.Replace(PicPortraitSml, PathfinderPortraitManager.Properties.Resources.placeholder);
        }
        private void ResizeImageAsWindow(PictureBox pictureBox, Image image, Panel panel)
        {
            PanelPortraitLrg.VerticalScroll.Visible = false;
            PanelPortraitLrg.HorizontalScroll.Visible = false;
            PanelPortraitMed.VerticalScroll.Visible = false;
            PanelPortraitMed.HorizontalScroll.Visible = false;
            PanelPortraitSml.VerticalScroll.Visible = false;
            PanelPortraitSml.HorizontalScroll.Visible = false;
            float aspectRatio = (pictureBox.Height * 1.0f / pictureBox.Width * 1.0f);
            Tuple<int, int> newSizeTuple = MapNewWidthHeight(panel, aspectRatio);
            pictureBox.Image = ImageControl.Direct.Resize.LowQiality(image, newSizeTuple.Item1, newSizeTuple.Item2);
            ArrangeAutoScroll(panel, newSizeTuple.Item1, newSizeTuple.Item2);
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
        private static Tuple<int, int> MapNewWidthHeight(Panel panel, float aspectRatio)
        {
            int srcWidth = panel.Width,
                srcHeight = panel.Height,
                dstWidth,
                dstHeight;
            dstHeight = srcHeight;
            dstWidth = (int)(srcHeight * 1.0f / aspectRatio * 1.0f);
            if (dstWidth < panel.Width)
            {
                dstWidth = srcWidth;
                dstHeight = (int)(srcWidth * 1.0f / (1.0f / aspectRatio * 1.0f));
            }
            return Tuple.Create(dstWidth, dstHeight);
        }
        private void AllToNotEnabled()
        {
            LayoutFilePage.Visible = false;
            LayoutFilePage.Enabled = false;
            LayoutMainPage.Visible = false;
            LayoutMainPage.Enabled = false;
            LayoutScalePage.Visible = false;
            LayoutScalePage.Enabled = false;
            LayoutExtractPage.Enabled = false;
            LayoutExtractPage.Visible = false;
        }
        private void OverloadDockOnEverything()
        {
            LayoutFilePage.Dock = DockStyle.Fill;
            LayoutMainPage.Dock = DockStyle.Fill;
            LayoutScalePage.Dock = DockStyle.Fill;
            LayoutExtractPage.Dock = DockStyle.Fill;
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
            using (Image imgPoor = new Bitmap(RELATIVEPATH_TO_TEMPPOOR))
            {
                PicPortraitLrg.Image = new Bitmap(imgPoor);
                PicPortraitMed.Image = new Bitmap(imgPoor);
                PicPortraitSml.Image = new Bitmap(imgPoor);
            }
            using (Image imgFull = new Bitmap(RELATIVEPATH_TO_TEMPFULL))
                PicPortraitTemp.Image = new Bitmap(imgFull);
            ArrangeAutoScroll(PanelPortraitLrg, PicPortraitLrg.Height, PicPortraitLrg.Width);
            ArrangeAutoScroll(PanelPortraitMed, PicPortraitLrg.Height, PicPortraitLrg.Width);
            ArrangeAutoScroll(PanelPortraitSml, PicPortraitLrg.Height, PicPortraitLrg.Width);
            ResizeAllImagesAsWindow();
        }
        public static void ArrangeAutoScroll(Panel panel, int xMax, int yMax)
        {
            panel.AutoScroll = false;
            panel.VerticalScroll.Minimum = 0;
            panel.HorizontalScroll.Minimum = 0;
            panel.VerticalScroll.Maximum = xMax;
            panel.HorizontalScroll.Maximum = yMax;
            panel.VerticalScroll.Visible = true;
            panel.HorizontalScroll.Visible = true;
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
        public static bool ExploreDirectory(string path)
        {
            return false;
        }
    }
}
