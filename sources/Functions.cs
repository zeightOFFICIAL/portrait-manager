/*    
    Pathfinder Portrait Manager. Desktop application for managing in game
    portraits for Pathfinder: Kingmaker and Pathfinder: Wrath of the Righteous
    Copyright (C) 2023 Artemii "Zeight" Saganenko
    LICENSE terms are written in LICENSE file
    Primal license header is written in Program.cs
*/

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
                    HideScrollBar(PanelPortraitLrg);
                    HideScrollBar(PanelPortraitMed);
                    HideScrollBar(PanelPortraitSml);
                }
            if (LayoutFilePage.Enabled == true)
            {
                using (Image img = new Bitmap(RELATIVEPATH_TEMPFULL))
                {
                    ResizeImageAsWindow(PicPortraitTemp, img, PanelPortraitTemp);
                    ArrangeAutoScroll(PanelPortraitTemp, 0, 0);
                    HideScrollBar(PanelPortraitTemp);
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
            LayoutSettingsPage.Visible = false;
            LayoutSettingsPage.Enabled = false;
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
            {
                PicPortraitTemp.Image = new Bitmap(imgFull);
            }
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
        public void ExploreDirectory(string path)
        {
            string nameList;
            if (CheckExistence(path))
            {
                if (SystemControl.FileControl.CheckImagePixeling(path + LRG_APPEND, 692, 1024) &&
                    SystemControl.FileControl.CheckImagePixeling(path + MED_APPEND, 330, 432) &&
                    SystemControl.FileControl.CheckImagePixeling(path + SML_APPEND, 185, 242))
                {
                    int nameLen = path.Split('\\').Length;
                    nameList = path.Split('\\')[nameLen - 1];
                    using (Image img = new Bitmap(path + "\\Fulllength.png"))
                    {
                        ImgListExtract.Images.Add(path, img);
                    }
                    ListViewItem item = new ListViewItem
                    {
                        Text = nameList,
                        ImageIndex = ListExtract.Items.Count
                    };
                    ListExtract.Items.Add(item);
                }
            }
            string[] subDirs = Directory.GetDirectories(path);
            foreach(string subDir in subDirs)
            {
                ExploreDirectory(subDir);
            }
        }
        public void FontsAndTextLoad(PrivateFontCollection fonts)
        {
            Font _bebas_neue20 = new Font(fonts.Families[0], 20),
                 _bebas_neue16 = new Font(fonts.Families[0], 16);

            ButtonToFilePage.Font = _bebas_neue20;
            ButtonToFilePage.Text = Properties.TextVariables.BUTTON_TOFILEPAGE;
            ButtonToExtractPage.Font = _bebas_neue20;
            ButtonToExtractPage.Text = Properties.TextVariables.BUTTON_TOEXRACTPAGE;
            ButtonToGalleryPage.Font = _bebas_neue20;
            ButtonToGalleryPage.Text = Properties.TextVariables.BUTTON_TOGALLERYPAGE;
            ButtonToSettingsPage.Font = _bebas_neue20;
            ButtonToSettingsPage.Text = Properties.TextVariables.BUTTON_TOSETTINGSPAGE;
            ButtonExit.Font = _bebas_neue20;
            ButtonExit.Text = Properties.TextVariables.BUTTON_EXIT;

            LabelGameSelected.Font = _bebas_neue20;
            LabelGameSelected.Text = Properties.TextVariables.LABEL_GAMESELECTED;
            ButtonKingmaker.Font = _bebas_neue20;
            ButtonKingmaker.Text = Properties.TextVariables.KING;
            ButtonWotR.Font = _bebas_neue20;
            ButtonWotR.Text = Properties.TextVariables.WOTR;
            LabelSelectedPath.Font = _bebas_neue16;
            LabelSelectedPath.Text = Properties.TextVariables.LABEL_PATH;

            ButtonLocalPortraitLoad.Font = _bebas_neue20;
            ButtonLocalPortraitLoad.Text = Properties.TextVariables.BUTTON_LOADLOCALPORTRAIT;
            ButtonWebPortraitLoad.Font = _bebas_neue20;
            ButtonWebPortraitLoad.Text = Properties.TextVariables.BUTTON_LOADWEBPORTRAIT;
            ButtonToMainPage.Font = _bebas_neue20;
            ButtonToMainPage.Text = Properties.TextVariables.BUTTON_BACK;
            ButtonToScalePage.Font = _bebas_neue20;
            ButtonToScalePage.Text = Properties.TextVariables.BUTTON_NEXT;
            ButtonHintOnFilePage.Font = _bebas_neue20;
            ButtonHintOnFilePage.Text = Properties.TextVariables.BUTTON_HINT;

            ButtonToFilePage2.Font = _bebas_neue20;
            ButtonToFilePage2.Text = Properties.TextVariables.BUTTON_BACK;
            ButtonCreatePortrait.Font = _bebas_neue20;
            ButtonCreatePortrait.Text = Properties.TextVariables.BUTTON_TOCREATE;
            LabelMedImage.Font = _bebas_neue20;
            LabelMedImage.Text = Properties.TextVariables.LABEL_MEDIUMIMG;
            LabelLrgImg.Font = _bebas_neue20;
            LabelLrgImg.Text = Properties.TextVariables.LABEL_LARGEIMG;
            LabelSmlImg.Font = _bebas_neue20;
            LabelSmlImg.Text = Properties.TextVariables.LABEL_SMALLIMG;
            ButtonHintOnScalePage.Font = _bebas_neue20;
            ButtonHintOnScalePage.Text = Properties.TextVariables.BUTTON_HINT;

            ButtonDeletePortait.Font = _bebas_neue20;
            ButtonDeletePortait.Text = Properties.TextVariables.BUTTON_SELECTEDDELETE;
            ButtonToMainPage3.Font = _bebas_neue20;
            ButtonToMainPage3.Text = Properties.TextVariables.BUTTON_BACK;
            ButtonOpenFolder.Font = _bebas_neue20;
            ButtonOpenFolder.Text = Properties.TextVariables.BUTTON_GALLERYOPENFOLDER;
            ButtonChangePortrait.Font = _bebas_neue20;
            ButtonChangePortrait.Text = Properties.TextVariables.BUTTON_SELECTEDCHANGE;
            ButtonHintFolder.Font = _bebas_neue20;
            ButtonHintFolder.Text = Properties.TextVariables.BUTTON_HINT;

            LabelURLInfo.Font = _bebas_neue20;
            LabelURLInfo.Text = Properties.TextVariables.LABEL_URLDIALOG;
            ButtonDenyWeb.Font = _bebas_neue20;
            ButtonDenyWeb.Text = Properties.TextVariables.BUTTON_CANCEL;
            ButtonLoadWeb.Font = _bebas_neue20;
            ButtonLoadWeb.Text = Properties.TextVariables.BUTTON_LOAD;
            TextBoxURL.Text = Properties.TextVariables.TEXTBOX_URL_INPUT;

            LabelFinalMesg.Font = _bebas_neue20;
            LabelFinalMesg.Text = Properties.TextVariables.LABEL_CREATEDOK;
            ButtonToFilePage3.Font = _bebas_neue20;
            ButtonToFilePage3.Text = Properties.TextVariables.BUTTON_NEW;
            ButtonToMainPage4.Font = _bebas_neue20;
            ButtonToMainPage4.Text = Properties.TextVariables.BUTTON_MENU;
            ButtonToMainPageAndFolder.Font = _bebas_neue20;
            ButtonToMainPageAndFolder.Text = Properties.TextVariables.BUTTON_FINALOPENFOLDER;

            ButtonChooseFolder.Font = _bebas_neue20;
            ButtonChooseFolder.Text = Properties.TextVariables.TEXT_TITLEOPENFOLDER;
            ButtonExtractAll.Font = _bebas_neue20;
            ButtonExtractAll.Text = Properties.TextVariables.BUTTON_EXTRACTALL;
            ButtonExtractSelected.Font = _bebas_neue20;
            ButtonExtractSelected.Text = Properties.TextVariables.BUTTON_EXTRACTSELECTED;
            ButtonOpenFolders.Font = _bebas_neue20;
            ButtonOpenFolders.Text = Properties.TextVariables.BUTTON_EXTRACTOPENFOLDER;
            ButtonHintExtract.Font = _bebas_neue20;
            ButtonHintExtract.Text = Properties.TextVariables.BUTTON_HINT;
            ButtonToMain2.Font = _bebas_neue20;
            ButtonToMain2.Text = Properties.TextVariables.BUTTON_BACK;

            LabelCopyright.Text = Properties.TextVariables.LABEL_COPY;
        }
        public void UpdateObjectColoring(Control ctrl, Color a, Color b)
        {
            if (ctrl is PictureBox || ctrl.Equals(LayoutURLDialog) 
                                   || ctrl.Equals(LayoutFinalPage)
                                   || ctrl.Equals(LayoutSettingsPage))
            {
                return;
            }
            if (ctrl.Equals(LabelCopyright) || ctrl.Equals(LabelVersion))
            {
                ctrl.ForeColor = a;
                return;
            }
            ctrl.ForeColor = a;
            ctrl.BackColor = b;
            foreach (Control subCtrl in ctrl.Controls)
            {
                UpdateObjectColoring(subCtrl, a, b);
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
            using (Image placeholder = new Bitmap(GAME_TYPES[_gameSelected].PlaceholderImage))
            {
                ClearPrimeImages(placeholder);
            }
        }
        public void SafeCopyAllImages(string fullPath)
        {
            using (Image placeholder = new Bitmap(GAME_TYPES[_gameSelected].PlaceholderImage))
            {
                ClearPrimeImages(placeholder);
                SystemControl.FileControl.TempImagesClear();
                SystemControl.FileControl.TempImagesCreate(fullPath, RELATIVEPATH_TEMPFULL, RELATIVEPATH_TEMPPOOR, placeholder);
            }
        }
        public void UpdateColorScheme()
        {
            Color foreColor = GAME_TYPES[_gameSelected].ForeColor;
            Color backColor = GAME_TYPES[_gameSelected].BackColor;
            Icon = GAME_TYPES[_gameSelected].GameIcon;
            PictureBoxTitle.BackgroundImage = GAME_TYPES[_gameSelected].TitleImage;
            LayoutMainPage.BackgroundImage = GAME_TYPES[_gameSelected].BackImage;
            foreach (Control ctrl in Controls)
            {
                UpdateObjectColoring(ctrl, foreColor, backColor);
            }
            Text = GAME_TYPES[_gameSelected].TitleName;
            if (_gameSelected == 'p')
            {
                ButtonKingmaker.Enabled = false;
                ButtonKingmaker.ForeColor = backColor;
                ButtonKingmaker.BackColor = foreColor;
                ButtonWotR.Enabled = true;
                ButtonWotR.ForeColor = Color.White;
                ButtonWotR.BackColor = Color.Black;
            }
            else
            {
                ButtonKingmaker.Enabled = true;
                ButtonKingmaker.ForeColor = Color.White;
                ButtonKingmaker.BackColor = Color.Black;
                ButtonWotR.Enabled = false;
                ButtonWotR.ForeColor = backColor;
                ButtonWotR.BackColor = foreColor;
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
        public void ClearImageLists(ListView lv, ImageList il)
        {
            lv.Clear();
            il.Images.Clear();
        }
        private string ParseDragDropFile(DragEventArgs e)
        {
            string[] filesList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string filePath = "!NONE!";
            if (filesList[0] != null && File.Exists(filesList[0]) &&
                (Path.GetExtension(filesList[0]) == ".png") ||
                (Path.GetExtension(filesList[0]) == ".jpg") ||
                (Path.GetExtension(filesList[0]) == ".jpeg") ||
                (Path.GetExtension(filesList[0]) == ".bmp") ||
                (Path.GetExtension(filesList[0]) == ".gif"))
            {
                filePath = filesList[0];
            }
            else
            {
                using (forms.MyMessageDialog Mesg = new forms.MyMessageDialog(Properties.TextVariables.MESG_WRONGFORMAT))
                {
                    Mesg.ShowDialog();
                }
            }
            return filePath;
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
                        _isAnyLoaded = true;
                        ClearTempImages();
                        LoadAllTempImages();
                    }
                }
            }
            catch
            {
                using (forms.MyMessageDialog MesgCannotLoad = new forms.MyMessageDialog(Properties.TextVariables.MESG_CANNOTLOAD))
                {
                    MesgCannotLoad.ShowDialog();
                }
            }
        }
        private void HideScrollBar(Panel panel)
        {
            panel.VerticalScroll.Visible = false;
            panel.HorizontalScroll.Visible = false;
        }
    }
}