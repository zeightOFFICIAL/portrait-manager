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
        private void ClearPrimeImages(Image replaceTo)
        {
            ImageControl.Utils.Replace(PicPortraitTemp, replaceTo);
            ImageControl.Utils.Replace(PicPortraitLrg, replaceTo);
            ImageControl.Utils.Replace(PicPortraitMed, replaceTo);
            ImageControl.Utils.Replace(PicPortraitSml, replaceTo);
        }
        private void DisposePrimeImages()
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
        private void ResizeVisibleImagesToWindow()
        {
            if (LayoutScalePage.Enabled == true)
                using (Image img = new Bitmap(RELATIVEPATH_TEMPPOOR))
                {
                    ResizeImageAsWindow(PicPortraitLrg, img, PanelPortraitLrg);
                    ResizeImageAsWindow(PicPortraitMed, img, PanelPortraitMed);
                    ResizeImageAsWindow(PicPortraitSml, img, PanelPortraitSml);
                }
            if (LayoutFilePage.Enabled == true)
            {
                using (Image img = new Bitmap(RELATIVEPATH_TEMPFULL))
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
        private void ParentLayoutsHide()
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
        private void ParentLayoutsSetDockFill()
        {
            foreach (Control ctrl in Controls)
            {
                LayoutsSetDockFill(ctrl);
            }
        }
        private void LayoutReveal(TableLayoutPanel table)
        {
            if (table.Visible == false && table.Enabled == false)
            {
                table.Visible = true;
                table.Enabled = true;
            }
        }
        private void LayoutHide(TableLayoutPanel table)
        {
            if (table.Visible == true && table.Enabled == true)
            {
                table.Visible = false;
                table.Enabled = false;
            }
        }
        private void LoadAllTempImages()
        {
            ClearTempImages();
            using (Image imgPoor = new Bitmap(RELATIVEPATH_TEMPPOOR))
            {
                PicPortraitLrg.Image = new Bitmap(imgPoor);
                PicPortraitMed.Image = new Bitmap(imgPoor);
                PicPortraitSml.Image = new Bitmap(imgPoor);
            }
            using (Image imgFull = new Bitmap(RELATIVEPATH_TEMPFULL))
                PicPortraitTemp.Image = new Bitmap(imgFull);
            ArrangeAutoScroll(PanelPortraitLrg, PicPortraitLrg.Height, PicPortraitLrg.Width);
            ArrangeAutoScroll(PanelPortraitMed, PicPortraitLrg.Height, PicPortraitLrg.Width);
            ArrangeAutoScroll(PanelPortraitSml, PicPortraitLrg.Height, PicPortraitLrg.Width);
            ResizeVisibleImagesToWindow();
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
            if (SystemControl.FileControl.DirectoryExists(path))
                if (SystemControl.FileControl.FileExist(path, LRG_APPEND) &&
                    SystemControl.FileControl.FileExist(path, MED_APPEND) &&
                    SystemControl.FileControl.FileExist(path, SML_APPEND))
                    if (SystemControl.FileControl.GetFileExtension(path, LRG_APPEND) == ".png" &&
                        SystemControl.FileControl.GetFileExtension(path, MED_APPEND) == ".png" &&
                        SystemControl.FileControl.GetFileExtension(path, SML_APPEND) == ".png")
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
        public void FontsTextLoad(PrivateFontCollection fonts)
        {
            Font _bebas_neue16 = new Font(fonts.Families[0], 16);

            ButtonToFilePage.Font = _bebas_neue16;
            ButtonToFilePage.Text = Properties.TextVariables.BUTTON_TOFILEPAGE;
            ButtonToExtractPage.Font = _bebas_neue16;
            ButtonToExtractPage.Text = Properties.TextVariables.BUTTON_TOEXRACT;
            ButtonToGalleryPage.Font = _bebas_neue16;
            ButtonToGalleryPage.Text = Properties.TextVariables.BUTTON_TOGALLERY;
            ButtonExit.Font = _bebas_neue16;
            ButtonExit.Text = Properties.TextVariables.BUTTON_EXIT;

            ButtonLocalPortraitLoad.Font = _bebas_neue16;
            ButtonLocalPortraitLoad.Text = Properties.TextVariables.BUTTON_LOCALPORTRAIT;
            ButtonWebPortraitLoad.Font = _bebas_neue16;
            ButtonWebPortraitLoad.Text = Properties.TextVariables.BUTTON_WEBPORTRAIT;
            ButtonToMainPage.Font = _bebas_neue16;
            ButtonToMainPage.Text = Properties.TextVariables.BUTTON_TOMAINPAGE;
            ButtonToScalePage.Font = _bebas_neue16;
            ButtonToScalePage.Text = Properties.TextVariables.BUTTON_TOSCALEPAGE;
            ButtonHintOnFilePage.Font = _bebas_neue16;
            ButtonHintOnFilePage.Text = Properties.TextVariables.BUTTON_HINT;

            ButtonBackToFilePage.Font = _bebas_neue16;
            ButtonBackToFilePage.Text = Properties.TextVariables.BUTTON_BACKTOFILE;
            ButtonCreatePortrait.Font = _bebas_neue16;
            ButtonCreatePortrait.Text = Properties.TextVariables.BUTTON_CREATEPORTRAIT;
            LabelMediumImage.Font = _bebas_neue16;
            LabelMediumImage.Text = Properties.TextVariables.LABEL_MEDIUMIMG;
            LabelLrgImg.Font = _bebas_neue16;
            LabelLrgImg.Text = Properties.TextVariables.LABEL_LARGEIMG;
            LabelSmlImg.Font = _bebas_neue16;
            LabelSmlImg.Text = Properties.TextVariables.LABEL_SMALLIMG;
            ButtonHintOnScalePage.Font = _bebas_neue16;
            ButtonHintOnScalePage.Text = Properties.TextVariables.BUTTON_HINT;

            ButtonDeletePortait.Font = _bebas_neue16;
            ButtonDeletePortait.Text = Properties.TextVariables.BUTTON_DELETESELECTED;
            ButtonToMainPage3.Font = _bebas_neue16;
            ButtonToMainPage3.Text = Properties.TextVariables.BUTTON_TOMAINPAGE;
            ButtonOpenFolder.Font = _bebas_neue16;
            ButtonOpenFolder.Text = Properties.TextVariables.BUTTON_TOFILEPAGE;
            ButtonChange.Font = _bebas_neue16;
            ButtonChange.Text = Properties.TextVariables.BUTTON_CHANGESELECTED;
            ButtonHintFolder.Font = _bebas_neue16;
            ButtonHintFolder.Text = Properties.TextVariables.BUTTON_HINT;

            LabelURLInfo.Font = _bebas_neue16;
            LabelURLInfo.Text = Properties.TextVariables.LABEL_URLDIALOG;
            ButtonDenyWeb.Font = _bebas_neue16;
            ButtonDenyWeb.Text = Properties.TextVariables.BUTTON_CANCEL;
            ButtonLoadWeb.Font = _bebas_neue16;
            ButtonLoadWeb.Text = Properties.TextVariables.BUTTON_LOAD;
            TextBoxURL.Text = Properties.TextVariables.TEXTBOX_URL_INPUT;

            LabelFinalMesg.Font = _bebas_neue16;
            LabelFinalMesg.Text = Properties.TextVariables.LABEL_CREATEDOK;
            ButtonNewPortrait.Font = _bebas_neue16;
            ButtonNewPortrait.Text = Properties.TextVariables.BUTTON_CREATENEW;
            ButtonToMainPage4.Font = _bebas_neue16;
            ButtonToMainPage4.Text = Properties.TextVariables.BUTTON_TOMAINPAGE;
            ButtonOpenFileFolder.Font = _bebas_neue16;
            ButtonOpenFileFolder.Text = Properties.TextVariables.BUTTON_OPEN;

            LabelCopyright.Text = Properties.TextVariables.LABEL_COPY;
        }
        public void UpdateColorSchemeOnForm(Control ctrl, Color a, Color b)
        {
            if (ctrl is PictureBox || ctrl.Equals(LayoutURLDialog) 
                || ctrl.Equals(LayoutFinalPage))
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
        public void LayoutsSetDockFill(Control ctrl)
        {
            if (ctrl is TableLayoutPanel)
            {
                ctrl.Dock = DockStyle.Fill;
            }
            foreach (Control subCtrl in ctrl.Controls)
            {
                LayoutsSetDockFill(subCtrl);
            }
        }
        public void ClearTempImages()
        {
            using (Image placeholder = new Bitmap(DEFAULT_DICT[_gameSelected]))
            {
                ClearPrimeImages(placeholder);
            }
        }
        public void SafeCopyAllImages(string fullPath)
        {
            using (Image placeholder = new Bitmap(DEFAULT_DICT[_gameSelected]))
            {
                ClearPrimeImages(placeholder);
                SystemControl.FileControl.TempImagesClear();
                SystemControl.FileControl.TempImagesCreate(fullPath, RELATIVEPATH_TEMPFULL, RELATIVEPATH_TEMPPOOR, placeholder);
            }
        }
        public void InitColorScheme(char whichGame = 'p')
        {
            if (whichGame == 'w')
            {
                Color fcolor = Color.DeepPink;
                Color bcolor = Color.FromArgb(20, 6, 30);
                PicTitle.BackgroundImage.Dispose();
                PicTitle.BackgroundImage = Properties.Resources.title_wotr;
                Icon = Properties.Resources.icon_wotr;
                LayoutMainPage.BackgroundImage = Properties.Resources.bg_wotr;
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
                PicTitle.BackgroundImage = Properties.Resources.title_path;
                Icon = Properties.Resources.icon_path;
                LayoutMainPage.BackgroundImage = Properties.Resources.bg_path;
                foreach (Control ctrl in this.Controls)
                {
                    UpdateColorSchemeOnForm(ctrl, fcolor, bcolor);
                }
            }
        }
        public bool LoadGallery(string fromPath)
        {
            if(!SystemControl.FileControl.DirectoryExists(fromPath))
            {
                return false;
            }
            List<string> nameList = new List<string>();
            foreach (string directory in Directory.GetDirectories(fromPath)) {
                int nameLen = directory.Split('\\').Length;
                nameList.Add(directory.Split('\\')[nameLen - 1]);
                using (Image img = new Bitmap(directory + "\\Fulllength.png"))
                {
                    ImgListGallery.Images.Add(directory.Split('\\')[nameLen - 1], img);
                }
            }
            for (int count = 0; count < ImgListGallery.Images.Count; count++)
            {
                ListViewItem item = new ListViewItem
                {
                    Text = nameList[count],
                    ImageIndex = count
                };
                ListGallery.Items.Add(item);
            }
            return true;
        }
        public void ClearGallery()
        {
            ListGallery.Clear();
            ImgListGallery.Images.Clear();
        }
        private static string CheckDragDropFile(DragEventArgs e)
        {
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string fullPath = "-1";
            if (fileList[0] != null && File.Exists(fileList[0]) &&
                (Path.GetExtension(fileList[0]) == ".png") ||
                (Path.GetExtension(fileList[0]) == ".jpg") ||
                (Path.GetExtension(fileList[0]) == ".jpeg") ||
                (Path.GetExtension(fileList[0]) == ".bmp") ||
                (Path.GetExtension(fileList[0]) == ".gif"))
            {
                fullPath = fileList[0];
            }
            return fullPath;
        }
        private void CheckWebResourceAndLoad(string URL)
        {
            try
            {
                var request = System.Net.WebRequest.Create(URL);
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    using (Image webImage = Image.FromStream(stream))
                    {
                        if (!SystemControl.FileControl.DirectoryExists("temp/"))
                            SystemControl.FileControl.DirectoryCreate("temp/");
                        webImage.Save(RELATIVEPATH_TEMPFULL);
                        ImageControl.Wraps.CreatePoorImage(webImage, RELATIVEPATH_TEMPPOOR);
                        _isNewLoaded = true;
                        ClearTempImages();
                        LoadAllTempImages();
                    }
                }
            }
            catch
            {
                using (forms.MyMessageDialog MesgCannotLoad = new forms.MyMessageDialog(Properties.TextVariables.MESG_WEBNOTLOADED))
                {
                    MesgCannotLoad.ShowDialog();
                }
            }
        }
    }
}