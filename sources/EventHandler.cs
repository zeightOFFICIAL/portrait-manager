/*    
    Pathfinder Portrait Manager. Desktop application for managing in game
    portraits for Pathfinder: Kingmaker and Pathfinder: Wrath of the Righteous
    Copyright (C) 2023 Artemii "Zeight" Saganenko
    LICENSE terms are written in LICENSE file
    Primal license header is written in Program.cs
*/

using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.Win32;

namespace PathfinderPortraitManager
{
    public partial class MainForm : Form
    {
        private string _extractFolderPath = "!NONE!";
        private void PicPortraitTemp_DragDrop(object sender, DragEventArgs e)
        {
            string fullPath = ParseDragDropFile(e);
            if (fullPath == "!NONE!")
            {
                if (_isAnyLoaded == true)
                {
                    LoadAllTempImages();
                    return;
                }
                _isAnyLoaded = false;
                return;
            }
            else
            {
                _isAnyLoaded = true;
                SafeCopyAllImages(fullPath);
                LoadAllTempImages();
            }
        }
        private void PicPortraitTemp_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void PicPortraitTemp_Click(object sender, EventArgs e)
        {
            string fullPath = SystemControl.FileControl.OpenFileLocation();
            if (fullPath == "!NONE!")
            {
                using (forms.MyMessageDialog Mesg = new forms.MyMessageDialog(Properties.TextVariables.MESG_WRONGFORMAT))
                {
                    Mesg.ShowDialog();
                }
                if (_isAnyLoaded == true)
                {
                    LoadAllTempImages();
                    return;
                }
                _isAnyLoaded = false;
                return;
            }
            else
            {
                _isAnyLoaded = true;
                SafeCopyAllImages(fullPath);
                LoadAllTempImages();
            }
        }
        private void ButtonLocalPortraitLoad_Click(object sender, EventArgs e)
        {
            PicPortraitTemp_Click(sender, e);
        }
        private void PicPortraitLrg_MouseDown(object sender, MouseEventArgs e)
        {
            HideScrollBar(PanelPortraitLrg);
            if (e.Button == MouseButtons.Left)
            {
                _mousePos = e.Location;
                _isDragging = 1;
            }
        }
        private void PicPortraitLrg_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging == 1 && (PicPortraitLrg.Image.Width > PanelPortraitLrg.Width ||
                                  PicPortraitLrg.Image.Height > PanelPortraitLrg.Height))
            {
                PanelPortraitLrg.AutoScrollPosition = new Point(-PanelPortraitLrg.AutoScrollPosition.X + (_mousePos.X - e.X),
                                                              -PanelPortraitLrg.AutoScrollPosition.Y + (_mousePos.Y - e.Y));
            }
            HideScrollBar(PanelPortraitLrg);
        }
        private void PicPortraitLrg_MouseUp(object sender, MouseEventArgs e)
        {
            HideScrollBar(PanelPortraitLrg);
            _isDragging = 0;
        }
        private void PicPortraitMed_MouseDown(object sender, MouseEventArgs e)
        {
            HideScrollBar(PanelPortraitMed);
            if (e.Button == MouseButtons.Left)
            {
                _mousePos = e.Location;
                _isDragging = 2;
            }
        }
        private void PicPortraitMed_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging == 2 && (PicPortraitMed.Image.Width > PanelPortraitMed.Width ||
                                  PicPortraitMed.Image.Height > PanelPortraitMed.Height))
            {
                PanelPortraitMed.AutoScrollPosition = new Point(-PanelPortraitMed.AutoScrollPosition.X + (_mousePos.X - e.X),
                                                              -PanelPortraitMed.AutoScrollPosition.Y + (_mousePos.Y - e.Y));
            }
            HideScrollBar(PanelPortraitMed);
        }
        private void PicPortraitMed_MouseUp(object sender, MouseEventArgs e)
        {
            HideScrollBar(PanelPortraitMed);
            _isDragging = 0;
        }
        private void PicPortraitSml_MouseDown(object sender, MouseEventArgs e)
        {
            HideScrollBar(PanelPortraitSml);
            if (e.Button == MouseButtons.Left)
            {
                _mousePos = e.Location;
                _isDragging = 3;
            }
        }
        private void PicPortraitSml_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging == 3 && (PicPortraitSml.Image.Width > PanelPortraitSml.Width ||
                                  PicPortraitSml.Image.Height > PanelPortraitSml.Height))
            {
                PanelPortraitSml.AutoScrollPosition = new Point(-PanelPortraitSml.AutoScrollPosition.X + (_mousePos.X - e.X),
                                                              -PanelPortraitSml.AutoScrollPosition.Y + (_mousePos.Y - e.Y));
            }
            HideScrollBar(PanelPortraitSml);
        }
        private void PicPortraitSml_MouseUp(object sender, MouseEventArgs e)
        {
            HideScrollBar(PanelPortraitSml);
            _isDragging = 0;
        }
        private void PicPortraitLrg_MouseWheel(object sender, MouseEventArgs e)
        {
            float aspectRatio = (PicPortraitLrg.Width * 1.0f / PicPortraitLrg.Height * 1.0f),
                  factor;
            if (e.Delta > 0)
            {
                factor = PicPortraitLrg.Width * 1.0f / 8;
                ImageControl.Direct.Zoom(PicPortraitLrg, PanelPortraitLrg, e, RELATIVEPATH_TEMPPOOR, aspectRatio, factor);
            }
            else
            {
                factor = -PicPortraitLrg.Width * 1.0f / 8;
                ImageControl.Direct.Zoom(PicPortraitLrg, PanelPortraitLrg, e, RELATIVEPATH_TEMPPOOR, aspectRatio, factor);
            }
            HideScrollBar(PanelPortraitLrg);
        }
        private void PicPortraitMed_MouseWheel(object sender, MouseEventArgs e)
        {
            float aspectRatio = (PicPortraitMed.Width * 1.0f / PicPortraitMed.Height * 1.0f),
                  factor;
            if (e.Delta > 0)
            {
                factor = PicPortraitMed.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitMed, PanelPortraitMed, e, RELATIVEPATH_TEMPPOOR, aspectRatio, factor);
            }
            else
            {
                factor = -PicPortraitMed.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitMed, PanelPortraitMed, e, RELATIVEPATH_TEMPPOOR, aspectRatio, factor);
            }
            HideScrollBar(PanelPortraitMed);
        }
        private void PicPortraitSml_MouseWheel(object sender, MouseEventArgs e)
        {
            float aspectRatio = (PicPortraitSml.Width * 1.0f / PicPortraitSml.Height * 1.0f),
                  factor;
            if (e.Delta > 0)
            {
                factor = PicPortraitSml.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitSml, PanelPortraitSml, e, RELATIVEPATH_TEMPPOOR, aspectRatio, factor);
            }
            else
            {
                factor = -PicPortraitSml.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitSml, PanelPortraitSml, e, RELATIVEPATH_TEMPPOOR, aspectRatio, factor);
            }
            HideScrollBar(PanelPortraitSml);
        }
        private void MainForm_Closed(object sender, FormClosedEventArgs e)
        {
            DisposePrimeImages();
            ClearImageLists(ListGallery, ImgListGallery);
            ClearImageLists(ListExtract, ImgListExtract);
            SystemControl.FileControl.TempImagesClear();
            Dispose();
            Application.Exit();
        }
        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            ResizeVisibleImagesToWindow();
        }
        private void ButtonCreatePortrait_Click(object sender, EventArgs e)
        {
            ButtonToMainPageAndFolder.Enabled = true;
            LayoutHide(LayoutScalePage);
            string fullPath = "";
            bool placeFound = false;
            uint localName = 1000;
            if (!SystemControl.FileControl.DirectoryExists(DIRECTORIES_DICT[_gameSelected]))
            {
                LayoutReveal(LayoutFinalPage);
                LabelFinalMesg.Text = Properties.TextVariables.LABEL_CREATEDERROR;
                LabelDirLoc.Text = DIRECTORIES_DICT[_gameSelected];
                ButtonToMainPageAndFolder.Enabled = false;
                return;
            }
            while (!placeFound)
            {
                fullPath = DIRECTORIES_DICT[_gameSelected] + "\\" + Convert.ToString(localName);
                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                    ImageControl.Wraps.CropImage(PicPortraitLrg, PanelPortraitLrg, RELATIVEPATH_TEMPFULL,
                                                 fullPath + LRG_APPEND, LRG_ASPECT, 692, 1024);
                    ImageControl.Wraps.CropImage(PicPortraitMed, PanelPortraitMed, RELATIVEPATH_TEMPFULL,
                                                 fullPath + MED_APPEND, MED_ASPECT, 330, 432);
                    ImageControl.Wraps.CropImage(PicPortraitSml, PanelPortraitSml, RELATIVEPATH_TEMPFULL,
                                                 fullPath + SML_APPEND, SML_ASPECT, 185, 242);
                    placeFound = true;
                }
                localName++;
            }
            if (CheckExistence(fullPath))
            {
                LayoutReveal(LayoutFinalPage);
                LabelFinalMesg.Text = Properties.TextVariables.LABEL_CREATEDOK;
                LabelDirLoc.Text = fullPath;
            }
            else
            {
                LayoutReveal(LayoutFinalPage);
                LabelFinalMesg.Text = Properties.TextVariables.LABEL_CREATEDERROR;
                LabelDirLoc.Text = fullPath;
                ButtonToMainPageAndFolder.Enabled = false;
            }
        }
        private void PicPortraitMed_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            using (Image img = new Bitmap(RELATIVEPATH_TEMPPOOR))
                ResizeImageAsWindow(PicPortraitMed, img, PanelPortraitMed);
        }
        private void PicPortraitLrg_MouseDoubleClick(object sedner, MouseEventArgs e)
        {
            using (Image img = new Bitmap(RELATIVEPATH_TEMPPOOR))
                ResizeImageAsWindow(PicPortraitLrg, img, PanelPortraitLrg);
        }
        private void PicPortraitSml_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            using (Image img = new Bitmap(RELATIVEPATH_TEMPPOOR))
                ResizeImageAsWindow(PicPortraitSml, img, PanelPortraitSml);
        }
        private void LabelMedImg_MouseHover(object sender, EventArgs e)
        {
            LabelMedImage.Text = Properties.TextVariables.LABEL_MEDIUMIMG2;
        }
        private void LabelLrgImg_MouseHover(object sender, EventArgs e)
        {
            LabelLrgImg.Text = Properties.TextVariables.LABEL_LARGEIMG2;
        }
        private void LabelSmlImg_MouseHover(object sender, EventArgs e)
        {
            LabelSmlImg.Text = Properties.TextVariables.LABEL_SMALLIMG2;
        }
        private void LabelMedImg_MouseLeave(object sender, EventArgs e)
        {
            LabelMedImage.Text = Properties.TextVariables.LABEL_MEDIUMIMG;
        }
        private void LabelLrgImg_MouseLeave(object sender, EventArgs e)
        {
            LabelLrgImg.Text = Properties.TextVariables.LABEL_LARGEIMG;
        }
        private void LabelSmlImg_MouseLeave(object sender, EventArgs e)
        {
            LabelSmlImg.Text = Properties.TextVariables.LABEL_SMALLIMG;
        }
        private void ButtonWebPortraitLoad_Click(object sender, EventArgs e)
        {
            LayoutHide(LayoutFilePage);
            LayoutReveal(LayoutURLDialog);
        }
        private void ButtonHintOnScalePage_Click(object sender, EventArgs e)
        {
            using (forms.MyMessageDialog HintMessage = new forms.MyMessageDialog(Properties.TextVariables.HINT_SCALEPAGE))
            {
                HintMessage.ShowDialog();
            }
        }
        private void ButtonHintOnFilePage_Click(object sender, EventArgs e)
        {
            using (forms.MyMessageDialog HintMessage = new forms.MyMessageDialog(Properties.TextVariables.HINT_FILEPAGE))
            {
                HintMessage.ShowDialog();
            }
        }
        private void PictureBoxTitle_Click(object sender, EventArgs e)
        {
            if (_gameSelected == 'p')
            {
                _gameSelected = 'w';
                Color fcolor = Color.DeepPink;
                Color bcolor = Color.FromArgb(20, 6, 30);
                PictureBoxTitle.BackgroundImage.Dispose();
                PictureBoxTitle.BackgroundImage = Properties.Resources.title_wotr;
                Icon = Properties.Resources.icon_wotr;
                LayoutMainPage.BackgroundImage = Properties.Resources.bg_wotr;
                foreach (Control ctrl in Controls)
                {
                    UpdateColorSchemeOnForm(ctrl, fcolor, bcolor);
                }
                Properties.Settings.Default.defaultgametype = 'w';
                Properties.Settings.Default.Save();
                Text = "Pathfinder Portrait Manager (WoTR)";
            }
            else
            {
                _gameSelected = 'p';
                Color fcolor = Color.Goldenrod;
                Color bcolor = Color.FromArgb(9, 28, 11);
                PictureBoxTitle.BackgroundImage.Dispose();
                PictureBoxTitle.BackgroundImage = Properties.Resources.title_path;
                Icon = Properties.Resources.icon_path;
                LayoutMainPage.BackgroundImage = Properties.Resources.bg_path;
                foreach (Control ctrl in Controls)
                {
                    UpdateColorSchemeOnForm(ctrl, fcolor, bcolor);
                }
                Properties.Settings.Default.defaultgametype = 'p';
                Properties.Settings.Default.Save();
                Text = "Pathfinder Portrait Manager (Kingmaker)";
            }
        }
        private void ButtonOpenFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(DIRECTORIES_DICT[_gameSelected]);
        }
        private void ButtonChangePortrait_Click(object sender, EventArgs e)
        {
            if (ListGallery.Items.Count < 1)
            {
                return;
            }
            if (ListGallery.SelectedItems.Count < 1)
            {
                using (forms.MyMessageDialog Message = new forms.MyMessageDialog(Properties.TextVariables.MESG_NONESELECTED))
                {
                    Message.ShowDialog();
                }
                return;
            }
            else if (ListGallery.SelectedItems.Count > 1)
            {
                using (forms.MyMessageDialog Message = new forms.MyMessageDialog(Properties.TextVariables.MESG_SELECTEDMORE))
                {
                    Message.ShowDialog();
                }
            }
            ListViewItem item = ListGallery.SelectedItems[0];
            string folderPath = DIRECTORIES_DICT[_gameSelected] + "\\" + item.Text + "\\Fulllength.png";
            DialogResult dr;
            using (forms.MyInquiryDialog Inquiry = new forms.MyInquiryDialog(Properties.TextVariables.INQR_DELETEOLD))
            {
                Inquiry.ShowDialog();
                dr = Inquiry.DialogResult;
            }
            ButtonToMainPage3_Click(sender, e);
            ButtonToFilePage_Click(sender, e);
            _isAnyLoaded = true;
            SafeCopyAllImages(folderPath);
            LoadAllTempImages();
            if (dr == DialogResult.OK)
            {
                ListGallery.Items.RemoveByKey(item.Text);
                ImgListGallery.Images.RemoveByKey(item.Text);
                SystemControl.FileControl.DirectoryDeleteRecursive(DIRECTORIES_DICT[_gameSelected] + "\\" + item.Text);
                item.Remove();
            }
        }
        private void ButtonDeletePortait_Click(object sender, EventArgs e)
        {
            if (ListGallery.Items.Count < 1)
            {
                return;
            }
            if (ListGallery.SelectedItems.Count < 1)
            {
                using (forms.MyMessageDialog Message = new forms.MyMessageDialog(Properties.TextVariables.MESG_NONESELECTED))
                {
                    Message.ShowDialog();
                }
                return;
            }
            foreach (ListViewItem item in ListGallery.SelectedItems)
            {
                string folderPath = DIRECTORIES_DICT[_gameSelected] + "\\" + item.Text + "\\";
                ImgListGallery.Images.RemoveByKey(item.Text);
                item.Remove();
                SystemControl.FileControl.DirectoryDeleteRecursive(folderPath);
            }
            ListGallery.Clear();
            for (int count = 0; count < ImgListGallery.Images.Count; count++)
            {
                ListViewItem item = new ListViewItem
                {
                    Text = ImgListGallery.Images.Keys[count],
                    ImageIndex = count
                };
                ListGallery.Items.Add(item);
            }
        }
        private void ButtonHintFolder_Click(object sender, EventArgs e)
        {
            using (forms.MyMessageDialog HintMessage = new forms.MyMessageDialog(Properties.TextVariables.HINT_GALLERYPAGE))
            {
                HintMessage.ShowDialog();
            }
        }
        private void ButtonChooseFolder_Click(object sender, EventArgs e)
        {
            if (_extractFolderPath != "!NONE!")
            {
                ClearImageLists(ListExtract, ImgListExtract);
            }
            CommonOpenFileDialog CommonOpenFileDialog = new CommonOpenFileDialog
            {
                Title = Properties.TextVariables.TEXT_COMMONOPENFILE,
                Multiselect = false,
                InitialDirectory = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "{374DE290-123F-4565-9164-39C4925E467B}", String.Empty).ToString(),
                IsFolderPicker = true
            };
            CommonOpenFileDialog.ShowDialog();
            _extractFolderPath = CommonOpenFileDialog.FileName;
            if (!SystemControl.FileControl.DirectoryExists(_extractFolderPath))
            {
                return;
            }
            ExploreDirectory(_extractFolderPath);
        }
        private void ButtonExtractAll_Click(object sender, EventArgs e)
        {
            if (ListExtract.Items.Count < 1)
            {
                return;
            }
            foreach (ListViewItem item in ListExtract.Items)
            {
                if (!SystemControl.FileControl.DirectoryExists(DIRECTORIES_DICT[_gameSelected] + "\\" + item.Text))
                {
                    using (forms.MyMessageDialog HintMessage = new forms.MyMessageDialog(DIRECTORIES_DICT[_gameSelected] + "\\" + item.Text))
                    {
                        HintMessage.ShowDialog();
                    }
                    SystemControl.FileControl.DirectoryCreate(DIRECTORIES_DICT[_gameSelected] + "\\" + item.Text);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + LRG_APPEND, DIRECTORIES_DICT[_gameSelected] + "\\" + item.Text + LRG_APPEND);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + MED_APPEND, DIRECTORIES_DICT[_gameSelected] + "\\" + item.Text + MED_APPEND);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + SML_APPEND, DIRECTORIES_DICT[_gameSelected] + "\\" + item.Text + SML_APPEND);
                }
                else
                {
                    string newPath = DateTime.Now.Millisecond.ToString();
                    using (forms.MyMessageDialog HintMessage = new forms.MyMessageDialog(DIRECTORIES_DICT[_gameSelected] + "\\" + item.Text + newPath))
                    {
                        HintMessage.ShowDialog();
                    }
                    SystemControl.FileControl.DirectoryCreate(DIRECTORIES_DICT[_gameSelected] + "\\" + item.Text + newPath);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + LRG_APPEND, DIRECTORIES_DICT[_gameSelected] + "\\" + item.Text + newPath + LRG_APPEND);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + MED_APPEND, DIRECTORIES_DICT[_gameSelected] + "\\" + item.Text + newPath + MED_APPEND);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + SML_APPEND, DIRECTORIES_DICT[_gameSelected] + "\\" + item.Text + newPath + SML_APPEND);
                }
            }
        }
        private void ButtonExtractSelected_Click(object sender, EventArgs e)
        {
            if (ListExtract.Items.Count < 1)
            {
                return;
            }
            if (ListExtract.SelectedItems.Count < 1)
            {
                using (forms.MyMessageDialog Message = new forms.MyMessageDialog(" "))
                {
                    Message.ShowDialog();
                }
                return;
            }
            foreach (ListViewItem item in ListExtract.SelectedItems)
            {
                if (!SystemControl.FileControl.DirectoryExists(DIRECTORIES_DICT[_gameSelected] + "\\" + item.Text))
                {
                    using (forms.MyMessageDialog HintMessage = new forms.MyMessageDialog(DIRECTORIES_DICT[_gameSelected] + "\\" + item.Text))
                    {
                        HintMessage.ShowDialog();
                    }
                    SystemControl.FileControl.DirectoryCreate(DIRECTORIES_DICT[_gameSelected] + "\\" + item.Text);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + LRG_APPEND, DIRECTORIES_DICT[_gameSelected] + "\\" + item.Text + LRG_APPEND);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + MED_APPEND, DIRECTORIES_DICT[_gameSelected] + "\\" + item.Text + MED_APPEND);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + SML_APPEND, DIRECTORIES_DICT[_gameSelected] + "\\" + item.Text + SML_APPEND);
                }
                else
                {
                    string newPath = DateTime.Now.Millisecond.ToString();
                    using (forms.MyMessageDialog HintMessage = new forms.MyMessageDialog(DIRECTORIES_DICT[_gameSelected] + "\\" + item.Text + newPath))
                    {
                        HintMessage.ShowDialog();
                    }
                    SystemControl.FileControl.DirectoryCreate(DIRECTORIES_DICT[_gameSelected] + "\\" + item.Text + newPath);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + LRG_APPEND, DIRECTORIES_DICT[_gameSelected] + "\\" + item.Text + newPath + LRG_APPEND);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + MED_APPEND, DIRECTORIES_DICT[_gameSelected] + "\\" + item.Text + newPath + MED_APPEND);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + SML_APPEND, DIRECTORIES_DICT[_gameSelected] + "\\" + item.Text + newPath + SML_APPEND);
                }
            }
        }
        private void ButtonOpenFolders_Click(object sender, EventArgs e)
        {
            if (_extractFolderPath == "!NOTSET!")
            {
                return;
            }
            System.Diagnostics.Process.Start(DIRECTORIES_DICT[_gameSelected]);
            System.Diagnostics.Process.Start(_extractFolderPath);
        }
        private void ButtonHintExtract_Click(object sender, EventArgs e)
        {
            using (forms.MyMessageDialog HintMessage = new forms.MyMessageDialog(Properties.TextVariables.HINT_EXTRACTPAGE))
            {
                HintMessage.ShowDialog();
            }
        }
        private void LabelCopyright_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/zeightOFFICIAL/portrait-manager-pathfinder");
        }
    }
}