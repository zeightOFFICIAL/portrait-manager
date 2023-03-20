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
        private string _extractFolderPath = "!NOTSET!";
        private void PicPortraitTemp_DragDrop(object sender, DragEventArgs e)
        {
            string fullPath = ParseDragDropFile(e);
            if (fullPath == "-1")
            {
                if (_isNewLoaded == true)
                {
                    LoadAllTempImages();
                    return;
                }
                _isNewLoaded = false;
            }
            else
            {
                _isNewLoaded = true;
            }
            SafeCopyAllImages(fullPath);
            LoadAllTempImages();
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
            if (fullPath == "-1")
            {
                if (_isNewLoaded == true)
                {
                    LoadAllTempImages();
                    return;
                }
                _isNewLoaded = false;
            }
            else
            {
                _isNewLoaded = true;
            }
            SafeCopyAllImages(fullPath);
            LoadAllTempImages();
        }
        private void ButtonLocalPortraitLoad_Click(object sender, EventArgs e)
        {
            string fullPath = SystemControl.FileControl.OpenFileLocation();
            if (fullPath == "-1")
            {
                if (_isNewLoaded == true)
                {
                    LoadAllTempImages();
                    return;
                }
                _isNewLoaded = false;
            }
            else
            {
                _isNewLoaded = true;
            }
            SafeCopyAllImages(fullPath);
            LoadAllTempImages();
        }
        private void PicPortraitLrg_MouseDown(object sender, MouseEventArgs e)
        {
            PanelPortraitLrg.VerticalScroll.Visible = false;
            PanelPortraitLrg.HorizontalScroll.Visible = false;
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
        }
        private void PicPortraitLrg_MouseUp(object sender, MouseEventArgs e)
        {
            PanelPortraitLrg.VerticalScroll.Visible = false;
            PanelPortraitLrg.HorizontalScroll.Visible = false;
            _isDragging = 0;
        }
        private void PicPortraitMed_MouseDown(object sender, MouseEventArgs e)
        {
            PanelPortraitMed.VerticalScroll.Visible = false;
            PanelPortraitMed.HorizontalScroll.Visible = false;
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
        }
        private void PicPortraitMed_MouseUp(object sender, MouseEventArgs e)
        {
            PanelPortraitMed.VerticalScroll.Visible = false;
            PanelPortraitMed.HorizontalScroll.Visible = false;
            _isDragging = 0;
        }
        private void PicPortraitSml_MouseDown(object sender, MouseEventArgs e)
        {
            PanelPortraitSml.VerticalScroll.Visible = false;
            PanelPortraitSml.HorizontalScroll.Visible = false;
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
        }
        private void PicPortraitSml_MouseUp(object sender, MouseEventArgs e)
        {
            PanelPortraitSml.VerticalScroll.Visible = false;
            PanelPortraitSml.HorizontalScroll.Visible = false;
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
        }
        private void MainForm_Closed(object sender, FormClosedEventArgs e)
        {
            DisposePrimeImages();
            ClearImageLists(ListGallery, ImgListGallery);
            ClearImageLists(ListExtract, ImgListExtract);
            SystemControl.FileControl.TempImagesClear();
            Application.Exit();
        }
        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            ResizeVisibleImagesToWindow();
        }
        private void ButtonCreatePortrait_Click(object sender, EventArgs e)
        {
            string fullPath = "";
            bool placeFound = false;
            uint localName = 1000;
            if (!SystemControl.FileControl.DirectoryExists(DIR_DICT[_gameSelected]))
            {
                LayoutReveal(LayoutFinalPage);
                LabelFinalMesg.Text = Properties.TextVariables.LABEL_CREATEDERROR;
                LabelDirLoc.Text = "Game folder: " + DIR_DICT[_gameSelected];
                ButtonOpenFileFolder.Enabled = false;
                return;
            }
            while (!placeFound)
            {
                fullPath = DIR_DICT[_gameSelected] + "\\" + Convert.ToString(localName);
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
                LabelDirLoc.Text = "Image loc: " + fullPath;
                ButtonOpenFileFolder.Enabled = false;
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
            LabelMediumImage.Text = Properties.TextVariables.LABEL_MEDIUMIMG2;
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
            LabelMediumImage.Text = Properties.TextVariables.LABEL_MEDIUMIMG;
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
        private void PicTitle_Click(object sender, EventArgs e)
        {
            if (_gameSelected == 'p')
            {
                _gameSelected = 'w';
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
                Properties.Settings.Default.defaultgametype = 'w';
                Properties.Settings.Default.Save();
            }
            else
            {
                _gameSelected = 'p';
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
                Properties.Settings.Default.defaultgametype = 'p';
                Properties.Settings.Default.Save();
            }
        }
        private void ButtonOpenFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(DIR_DICT[_gameSelected]);
        }
        private void ButtonChangePortrait_Click(object sender, EventArgs e)
        {
            if (ListGallery.Items.Count < 1)
            {
                return;
            }
            if (ListGallery.SelectedItems.Count < 1)
            {
                using (forms.MyMessageDialog Message = new forms.MyMessageDialog(Properties.TextVariables.HINT_NONSELECTED))
                {
                    Message.ShowDialog();
                }
                return;
            }
            else if (ListGallery.SelectedItems.Count > 1)
            {
                using (forms.MyMessageDialog Message = new forms.MyMessageDialog(Properties.TextVariables.HINT_SELECTEDMORE))
                {
                    Message.ShowDialog();
                }
            }
            ListViewItem item = ListGallery.SelectedItems[0];
            string folderPath = DIR_DICT[_gameSelected] + "\\" + item.Text + "\\Fulllength.png";
            DialogResult dialogResult;
            using (forms.MyInquiryDialog Inquiry = new forms.MyInquiryDialog(Properties.TextVariables.HINT_DELETEOLD))
            {
                Inquiry.ShowDialog();
                dialogResult = Inquiry.DialogResult;
            }
            ButtonToMainPage3_Click(sender, e);
            ButtonToFilePage_Click(sender, e);
            _isNewLoaded = true;
            SafeCopyAllImages(folderPath);
            LoadAllTempImages();
            if (dialogResult == DialogResult.OK)
            {
                ListGallery.Items.RemoveByKey(item.Text);
                ImgListGallery.Images.RemoveByKey(item.Text);
                SystemControl.FileControl.DirectoryDeleteRecursive(DIR_DICT[_gameSelected] + "\\" + item.Text);
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
                using (forms.MyMessageDialog Message = new forms.MyMessageDialog(Properties.TextVariables.HINT_NONSELECTEDDELETE))
                {
                    Message.ShowDialog();
                }
                return;
            }
            foreach (ListViewItem item in ListGallery.SelectedItems)
            {
                string folderPath = DIR_DICT[_gameSelected] + "\\" + item.Text + "\\";
                
                ListGallery.Items.RemoveByKey(item.Text);
                ImgListGallery.Images.RemoveByKey(item.Text);
                item.Remove();
                SystemControl.FileControl.DirectoryDeleteRecursive(folderPath);
            }
        }
        private void ButtonHintFolder_Click(object sender, EventArgs e)
        {
            return;
        }
        private void ButtonChooseFolder_Click(object sender, EventArgs e)
        {
            if (_extractFolderPath != "!NOTSET!")
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

        }
        private void ButtonExtractSelected_Click(object sender, EventArgs e)
        {

        }
        private void ButtonOpenFolders_Click(object sender, EventArgs e)
        {
            if (_extractFolderPath == "!NOTSET!")
            {
                return;
            }
            System.Diagnostics.Process.Start(DIR_DICT[_gameSelected]);
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