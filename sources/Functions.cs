using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace PathfinderPortraitManager
{
    public partial class MainForm : Form
    {
        private void ClearImages(Image replaceTo)
        {
            ImageControl.Utils.Replace(PicPortraitTemp, replaceTo);
            ImageControl.Utils.Replace(PicPortraitLrg, replaceTo);
            ImageControl.Utils.Replace(PicPortraitMed, replaceTo);
            ImageControl.Utils.Replace(PicPortraitSml, replaceTo);
        }
        private void DisposeAllImages()
        {
            ImageControl.Utils.Dispose(PicPortraitTemp);
            ImageControl.Utils.Dispose(PicPortraitLrg);
            ImageControl.Utils.Dispose(PicPortraitMed);
            ImageControl.Utils.Dispose(PicPortraitSml);
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
        private void ResizeAllImagesToWindow()
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
        private static Tuple<int, int> MapNewWidthHeight(Control parent, float aspectRatio)
        {
            int srcWidth = parent.Width,
                srcHeight = parent.Height,
                dstWidth,
                dstHeight;
            dstHeight = srcHeight;
            dstWidth = (int)(srcHeight * 1.0f / aspectRatio * 1.0f);
            if (dstWidth < parent.Width)
            {
                dstWidth = srcWidth;
                dstHeight = (int)(srcWidth * 1.0f / (1.0f / aspectRatio * 1.0f));
            }
            return Tuple.Create(dstWidth, dstHeight);
        }
        private void LayoutsDisable()
        {
            LayoutFilePage.Visible = false;
            LayoutFilePage.Enabled = false;
            LayoutMainPage.Visible = false;
            LayoutMainPage.Enabled = false;
            LayoutScalePage.Visible = false;
            LayoutScalePage.Enabled = false;
            LayoutExtractPage.Enabled = false;
            LayoutExtractPage.Visible = false;
            LayoutGallery.Visible = false;
            LayoutGallery.Enabled = false;
        }
        private void LayoutsSetDockFill()
        {
            LayoutFilePage.Dock = DockStyle.Fill;
            LayoutMainPage.Dock = DockStyle.Fill;
            LayoutScalePage.Dock = DockStyle.Fill;
            LayoutExtractPage.Dock = DockStyle.Fill;
        }
        private void LayoutEnable(TableLayoutPanel table)
        {
            if (table.Visible == false && table.Enabled == false)
            {
                table.Visible = true;
                table.Enabled = true;
            }
        }
        private void LoadAllTempImages()
        {
            ClearToAccordingDefault(_gameSelected);
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
            ResizeAllImagesToWindow();
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
                if (SystemControl.FileControl.FileExist(path, LARGE_EXTENSION) &&
                    SystemControl.FileControl.FileExist(path, MEDIUM_EXTENSION) &&
                    SystemControl.FileControl.FileExist(path, SMALL_EXTENSION))
                    if (SystemControl.FileControl.GetFileExtension(path, LARGE_EXTENSION) == ".png" &&
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
        public void FontsLoad(PrivateFontCollection fonts)
        {
            Font _bebas_neue16 = new Font(fonts.Families[0], 16);

            ButtonToFilePage.Font = _bebas_neue16;
            ButtonExtract.Font = _bebas_neue16;
            ButtonToGalleryPage.Font = _bebas_neue16;
            ButtonExit.Font = _bebas_neue16;

            ButtonLocalPortraitLoad.Font = _bebas_neue16;
            ButtonWebPortraitLoad.Font = _bebas_neue16;
            ButtonToMainPage.Font = _bebas_neue16;
            ButtonToScalePage.Font = _bebas_neue16;
            ButtonHintOnFilePage.Font = _bebas_neue16;

            ButtonBackToFilePage.Font = _bebas_neue16;
            ButtonCreatePortrait.Font = _bebas_neue16;
            LabelUnnamed1.Font = _bebas_neue16;
            LabelUnnamed2.Font = _bebas_neue16;
            LabelUnnamed3.Font = _bebas_neue16;
            ButtonHintOnScalePage.Font = _bebas_neue16;

            ButtonDeletePortait.Font = _bebas_neue16;
            ButtonToMainPage3.Font = _bebas_neue16;
            ButtonOpenFolder.Font = _bebas_neue16;
        }
        public void UpdateColorSchemeOnForm(Control ctrl, Color a, Color b)
        {
            if (ctrl is PictureBox)
            {
                return;
            }
            if (ctrl.Equals(LabelCopyright))
            {
                ctrl.ForeColor = a;
                return;
            }
            ctrl.ForeColor = a;
            ctrl.BackColor = b;
            foreach (Control subCtrl in ctrl.Controls)
            {
                UpdateColorSchemeOnForm(subCtrl, a, b);
            }
        }
        public void ClearToAccordingDefault(char whichGame = 'p')
        {
            if (whichGame == 'p')
                using (Image placeholder = new Bitmap(PathfinderPortraitManager.Properties.Resources.placeholder_path))
                    ClearImages(placeholder);
            else
                using (Image placeholder = new Bitmap(PathfinderPortraitManager.Properties.Resources.placeholder_wotr))
                    ClearImages(placeholder);
        }
        public void ClearAndLoadToAccordingDefault(string fullPath, char whichGame = 'p')
        {
            if (whichGame == 'p')
                using (Image placeholder = new Bitmap(PathfinderPortraitManager.Properties.Resources.placeholder_path))
                {
                    ClearImages(placeholder);
                    SystemControl.FileControl.TempImagesClear();
                    SystemControl.FileControl.TempImagesCreate(fullPath, RELATIVEPATH_TO_TEMPFULL, RELATIVEPATH_TO_TEMPPOOR, placeholder);
                }
            else
                using (Image placeholder = new Bitmap(PathfinderPortraitManager.Properties.Resources.placeholder_wotr))
                {
                    ClearImages(placeholder);
                    SystemControl.FileControl.TempImagesClear();
                    SystemControl.FileControl.TempImagesCreate(fullPath, RELATIVEPATH_TO_TEMPFULL, RELATIVEPATH_TO_TEMPPOOR, placeholder);
                }
        }
        public void InitColorScheme(char whichGame = 'p')
        {
            if (whichGame == 'w')
            {
                Color fcolor = Color.DeepPink;
                Color bcolor = Color.FromArgb(20, 6, 30);
                PicTitle.BackgroundImage.Dispose();
                PicTitle.BackgroundImage = PathfinderPortraitManager.Properties.Resources.title_wotr;
                this.Icon = PathfinderPortraitManager.Properties.Resources.icon_wotr;
                this.LayoutMainPage.BackgroundImage = PathfinderPortraitManager.Properties.Resources.bg_wotr;
                foreach (Control ctrl in this.Controls)
                {
                    UpdateColorSchemeOnForm(ctrl, fcolor, bcolor);
                }
            }
            else
            {
                Color fcolor = Color.Goldenrod;
                Color bcolor = Color.FromArgb(9, 28, 11);
                PicTitle.BackgroundImage.Dispose();
                PicTitle.BackgroundImage = PathfinderPortraitManager.Properties.Resources.title_path;
                this.Icon = PathfinderPortraitManager.Properties.Resources.icon_path;
                this.LayoutMainPage.BackgroundImage = PathfinderPortraitManager.Properties.Resources.bg_path;
                foreach (Control ctrl in this.Controls)
                {
                    UpdateColorSchemeOnForm(ctrl, fcolor, bcolor);
                }
            }
        }
        public bool LoadGallery(string fromPath)
        {
            if(!SystemControl.FileControl.DirExists(fromPath))
            {
                return false;
            }
            ListGallery.View = View.LargeIcon;
            ListGallery.LargeImageList = ImgListGallery;
            List<string> nameList = new List<string>();
            foreach (string directory in Directory.GetDirectories(fromPath)) {
                this.ImgListGallery.Images.Add(Image.FromFile(directory + "\\Fulllength.png"));
                int nameLen = directory.Split('\\').Length;
                nameList.Add(directory.Split('\\')[nameLen-1]);
            }
            for (int count = 0; count < ImgListGallery.Images.Count; count++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = nameList[count];
                item.ImageIndex = count;
                ListGallery.Items.Add(item);
            }
            return true;
        }
        public void ClearGallery()
        {

        }
    }
}