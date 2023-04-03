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
                    LoadAllTempImages(_imageFlag);
                    return;
                }
                _isAnyLoaded = false;
                return;
            }
            else
            {
                _isAnyLoaded = true;
                SafeCopyAllImages(fullPath, _imageFlag);
                LoadAllTempImages(_imageFlag);
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
                using (forms.MyMessageDialog Message = new forms.MyMessageDialog(Properties.TextVariables.MESG_WRONGFORMAT))
                {
                    Message.ShowDialog();
                }
                if (_isAnyLoaded == true)
                {
                    LoadAllTempImages(_imageFlag);
                    return;
                }
                _isAnyLoaded = false;
                return;
            }
            else
            {
                _isAnyLoaded = true;
                SafeCopyAllImages(fullPath, _imageFlag);
                LoadAllTempImages(_imageFlag);
            }
        }
        private void ButtonLocalPortraitLoad_Click(object sender, EventArgs e)
        {
            PicPortraitTemp_Click(sender, e);
        }
        private void PicPortraitLrg_MouseDown(object sender, MouseEventArgs e)
        {
            RootFunctions.HideScrollBar(PanelPortraitLrg);
            if (e.Button == MouseButtons.Left)
            {
                _mousePosition = e.Location;
                _isDragging = 1;
            }
        }
        private void PicPortraitLrg_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging == 1 && (PicPortraitLrg.Image.Width > PanelPortraitLrg.Width ||
                                  PicPortraitLrg.Image.Height > PanelPortraitLrg.Height))
            {
                PanelPortraitLrg.AutoScrollPosition = new Point(-PanelPortraitLrg.AutoScrollPosition.X + (_mousePosition.X - e.X),
                                                              -PanelPortraitLrg.AutoScrollPosition.Y + (_mousePosition.Y - e.Y));
            }
            RootFunctions.HideScrollBar(PanelPortraitLrg);
        }
        private void PicPortraitLrg_MouseUp(object sender, MouseEventArgs e)
        {
            RootFunctions.HideScrollBar(PanelPortraitLrg);
            _isDragging = 0;
        }
        private void PicPortraitMed_MouseDown(object sender, MouseEventArgs e)
        {
            RootFunctions.HideScrollBar(PanelPortraitMed);
            if (e.Button == MouseButtons.Left)
            {
                _mousePosition = e.Location;
                _isDragging = 2;
            }
        }
        private void PicPortraitMed_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging == 2 && (PicPortraitMed.Image.Width > PanelPortraitMed.Width ||
                                  PicPortraitMed.Image.Height > PanelPortraitMed.Height))
            {
                PanelPortraitMed.AutoScrollPosition = new Point(-PanelPortraitMed.AutoScrollPosition.X + (_mousePosition.X - e.X),
                                                              -PanelPortraitMed.AutoScrollPosition.Y + (_mousePosition.Y - e.Y));
            }
            RootFunctions.HideScrollBar(PanelPortraitMed);
        }
        private void PicPortraitMed_MouseUp(object sender, MouseEventArgs e)
        {
            RootFunctions.HideScrollBar(PanelPortraitMed);
            _isDragging = 0;
        }
        private void PicPortraitSml_MouseDown(object sender, MouseEventArgs e)
        {
            RootFunctions.HideScrollBar(PanelPortraitSml);
            if (e.Button == MouseButtons.Left)
            {
                _mousePosition = e.Location;
                _isDragging = 3;
            }
        }
        private void PicPortraitSml_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging == 3 && (PicPortraitSml.Image.Width > PanelPortraitSml.Width ||
                                  PicPortraitSml.Image.Height > PanelPortraitSml.Height))
            {
                PanelPortraitSml.AutoScrollPosition = new Point(-PanelPortraitSml.AutoScrollPosition.X + (_mousePosition.X - e.X),
                                                              -PanelPortraitSml.AutoScrollPosition.Y + (_mousePosition.Y - e.Y));
            }
            RootFunctions.HideScrollBar(PanelPortraitSml);
        }
        private void PicPortraitSml_MouseUp(object sender, MouseEventArgs e)
        {
            RootFunctions.HideScrollBar(PanelPortraitSml);
            _isDragging = 0;
        }
        private void PicPortraitLrg_MouseWheel(object sender, MouseEventArgs e)
        {
            float aspectRatio = (PicPortraitLrg.Width * 1.0f / PicPortraitLrg.Height * 1.0f),
                  factor;
            if (e.Delta > 0)
            {
                factor = PicPortraitLrg.Width * 1.0f / 8;
                ImageControl.Direct.Zoom(PicPortraitLrg, PanelPortraitLrg, e, TEMP_LARGE_APPEND, aspectRatio, factor);
            }
            else
            {
                factor = -PicPortraitLrg.Width * 1.0f / 8;
                ImageControl.Direct.Zoom(PicPortraitLrg, PanelPortraitLrg, e, TEMP_LARGE_APPEND, aspectRatio, factor);
            }
            RootFunctions.HideScrollBar(PanelPortraitLrg);
        }
        private void PicPortraitMed_MouseWheel(object sender, MouseEventArgs e)
        {
            float aspectRatio = (PicPortraitMed.Width * 1.0f / PicPortraitMed.Height * 1.0f),
                  factor;
            if (e.Delta > 0)
            {
                factor = PicPortraitMed.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitMed, PanelPortraitMed, e, TEMP_MEDIUM_APPEND, aspectRatio, factor);
            }
            else
            {
                factor = -PicPortraitMed.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitMed, PanelPortraitMed, e, TEMP_MEDIUM_APPEND, aspectRatio, factor);
            }
            RootFunctions.HideScrollBar(PanelPortraitMed);
        }
        private void PicPortraitSml_MouseWheel(object sender, MouseEventArgs e)
        {
            float aspectRatio = (PicPortraitSml.Width * 1.0f / PicPortraitSml.Height * 1.0f),
                  factor;
            if (e.Delta > 0)
            {
                factor = PicPortraitSml.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitSml, PanelPortraitSml, e, TEMP_SMALL_APPEND, aspectRatio, factor);
            }
            else
            {
                factor = -PicPortraitSml.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitSml, PanelPortraitSml, e, TEMP_SMALL_APPEND, aspectRatio, factor);
            }
            RootFunctions.HideScrollBar(PanelPortraitSml);
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
            RootFunctions.LayoutDisable(LayoutScalePage);
            string fullPath = "";
            bool placeFound = false;
            uint localName = 1000;
            if (!SystemControl.FileControl.DirectoryExists(GAME_TYPES[_gameSelected].DefaultDirectory))
            {
                RootFunctions.LayoutEnable(LayoutFinalPage);
                LabelFinalMesg.Text = Properties.TextVariables.LABEL_CREATEDERROR;
                LabelDirLoc.Text = GAME_TYPES[_gameSelected].DefaultDirectory;
                ButtonToMainPageAndFolder.Enabled = false;
                return;
            }
            while (!placeFound)
            {
                fullPath = GAME_TYPES[_gameSelected].DefaultDirectory + "\\" + Convert.ToString(localName);
                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                    ImageControl.Wraps.CropImage(PicPortraitLrg, PanelPortraitLrg, TEMP_LARGE_APPEND,
                                                 fullPath + LARGE_APPEND, LARGE_ASPECT, 692, 1024);
                    ImageControl.Wraps.CropImage(PicPortraitMed, PanelPortraitMed, TEMP_MEDIUM_APPEND,
                                                 fullPath + MEDIUM_APPEND, MEDIUM_ASPECT, 330, 432);
                    ImageControl.Wraps.CropImage(PicPortraitSml, PanelPortraitSml, TEMP_SMALL_APPEND,
                                                 fullPath + SMALL_APPEND, SMALL_ASPECT, 185, 242);
                    placeFound = true;
                }
                localName++;
            }
            if (CheckExistence(fullPath))
            {
                RootFunctions.LayoutEnable(LayoutFinalPage);
                LabelFinalMesg.Text = Properties.TextVariables.LABEL_CREATEDOK;
                LabelDirLoc.Text = fullPath;
            }
            else
            {
                RootFunctions.LayoutEnable(LayoutFinalPage);
                LabelFinalMesg.Text = Properties.TextVariables.LABEL_CREATEDERROR;
                LabelDirLoc.Text = fullPath;
                ButtonToMainPageAndFolder.Enabled = false;
            }
        }
        private void PicPortraitMed_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            using (Image img = new Bitmap(TEMP_MEDIUM_APPEND))
                ResizeImageAsWindow(PicPortraitMed, img, PanelPortraitMed);
        }
        private void PicPortraitLrg_MouseDoubleClick(object sedner, MouseEventArgs e)
        {
            using (Image img = new Bitmap(TEMP_LARGE_APPEND))
                ResizeImageAsWindow(PicPortraitLrg, img, PanelPortraitLrg);
        }
        private void PicPortraitSml_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            using (Image img = new Bitmap(TEMP_SMALL_APPEND))
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
            RootFunctions.LayoutDisable(LayoutFilePage);
            RootFunctions.LayoutEnable(LayoutURLDialog);
        }
        private void ButtonHintOnScalePage_Click(object sender, EventArgs e)
        {
            using (forms.MyMessageDialog Hint = new forms.MyMessageDialog(Properties.TextVariables.HINT_SCALEPAGE))
            {
                Hint.ShowDialog();
            }
        }
        private void ButtonHintOnFilePage_Click(object sender, EventArgs e)
        {
            using (forms.MyMessageDialog Hint = new forms.MyMessageDialog(Properties.TextVariables.HINT_FILEPAGE))
            {
                Hint.ShowDialog();
            }
        }
        private void PictureBoxTitle_Click(object sender, EventArgs e)
        {
            if (_gameSelected == 'p')
            {
                _gameSelected = 'w';
            }
            else
            {
                _gameSelected = 'p';
            }
            UpdateColorScheme();
            Properties.CoreSettings.Default.GameType = _gameSelected;
            Properties.CoreSettings.Default.Save();
            if (!ValidatePotraitPath(ACTIVE_PATHS[_gameSelected]))
            {
                using (forms.MyMessageDialog Mesg = new forms.MyMessageDialog(Properties.TextVariables.MESG_GAMEFOLDERNOTFOUND))
                {
                    Mesg.StartPosition = FormStartPosition.CenterParent;
                    Mesg.Width = Width - 15;
                    Mesg.ShowDialog();
                }
                RemoveClickEventsFromMainButtons();
            }
            else
            {
                AddClickEventsFromMainButtons();
            }
        }
        private void ButtonOpenFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(GAME_TYPES[_gameSelected].DefaultDirectory);
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
            string folderPath = GAME_TYPES[_gameSelected].DefaultDirectory + "\\" + item.Text + "\\Fulllength.png";
            DialogResult dr;
            using (forms.MyInquiryDialog Inquiry = new forms.MyInquiryDialog(Properties.TextVariables.INQR_DELETEOLD))
            {
                Inquiry.ShowDialog();
                dr = Inquiry.DialogResult;
            }
            ButtonToMainPage3_Click(sender, e);
            ButtonToFilePage_Click(sender, e);
            _isAnyLoaded = true;
            SafeCopyAllImages(folderPath, _imageFlag);
            LoadAllTempImages(_imageFlag);
            if (dr == DialogResult.OK)
            {
                ListGallery.Items.RemoveByKey(item.Text);
                ImgListGallery.Images.RemoveByKey(item.Text);
                SystemControl.FileControl.DirectoryDeleteRecursive(GAME_TYPES[_gameSelected].DefaultDirectory + "\\" + item.Text);
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
            DialogResult dr;
            using (forms.MyInquiryDialog Message = new forms.MyInquiryDialog(Properties.TextVariables.MESG_DELETE+ListGallery.SelectedItems.Count))
            {
                Message.ShowDialog();
                dr = Message.DialogResult;
            }
            if (dr != DialogResult.OK)
            {
                return;
            }
            foreach (ListViewItem item in ListGallery.SelectedItems)
            {
                string folderPath = GAME_TYPES[_gameSelected].DefaultDirectory + "\\" + item.Text + "\\";
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
            using (forms.MyMessageDialog Hint = new forms.MyMessageDialog(Properties.TextVariables.HINT_GALLERYPAGE))
            {
                Hint.ShowDialog();
            }
        }
        private void ButtonChooseFolder_Click(object sender, EventArgs e)
        {
            if (_extractFolderPath != "!NONE!")
            {
                ClearImageLists(ListExtract, ImgListExtract);
            }
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            string defDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow");
            if (SystemControl.FileControl.DirectoryExists(defDir))
            {
                dialog.SelectedPath = defDir;
            }
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _extractFolderPath = dialog.SelectedPath;
            }
            else
            {
                return;
            }
            if (!SystemControl.FileControl.DirectoryExists(_extractFolderPath))
            {
                return;
            }
            ExploreDirectory(_extractFolderPath);
            if (ListExtract.Items.Count > 0)
            {
                ButtonExtractAll.Enabled = true;
                ButtonExtractSelected.Enabled = true;
                ButtonOpenFolders.Enabled = true;
            }
            else
            {
                _extractFolderPath = "!NONE!";
                ButtonExtractAll.Enabled = false;
                ButtonExtractSelected.Enabled = false;
                ButtonOpenFolders.Enabled = false;
            }
        }
        private void ButtonExtractAll_Click(object sender, EventArgs e)
        {
            bool _isRepeat = false;
            uint imgCount = 0;
            if (ListExtract.Items.Count < 1)
            {
                return;
            }
            foreach (ListViewItem item in ListExtract.Items)
            {
                string normalPath = GAME_TYPES[_gameSelected].DefaultDirectory + "\\" + item.Text;
                string safePath = GAME_TYPES[_gameSelected].DefaultDirectory + "\\" + item.Text + DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
                if (!SystemControl.FileControl.DirectoryExists(normalPath))
                {
                    SystemControl.FileControl.DirectoryCreate(normalPath);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + LARGE_APPEND, normalPath + LARGE_APPEND);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + MEDIUM_APPEND, normalPath + MEDIUM_APPEND);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + SMALL_APPEND, normalPath + SMALL_APPEND);
                    imgCount++;
                }
                else
                {
                    _isRepeat = true;
                    SystemControl.FileControl.DirectoryCreate(safePath);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + LARGE_APPEND, safePath + LARGE_APPEND);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + MEDIUM_APPEND, safePath + MEDIUM_APPEND);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + SMALL_APPEND, safePath + SMALL_APPEND);
                    imgCount++;
                }
            }
            if (_isRepeat)
            {
                using (forms.MyMessageDialog Message = new forms.MyMessageDialog(Properties.TextVariables.MESG_REPEATFOLDER))
                {
                    Message.ShowDialog();
                }
            }
            if (imgCount > 0)
            {
                using (forms.MyMessageDialog Message = new forms.MyMessageDialog(Properties.TextVariables.MESG_SUCCESS + imgCount))
                {
                    Message.ShowDialog();
                }
            }
        }
        private void ButtonExtractSelected_Click(object sender, EventArgs e)
        {
            bool _isRepeat = false;
            uint imgCount = 0;
            if (ListExtract.Items.Count < 1)
            {
                return;
            }
            if (ListExtract.SelectedItems.Count < 1)
            {
                using (forms.MyMessageDialog Message = new forms.MyMessageDialog(Properties.TextVariables.MESG_NONESELECTEDEXTRACT))
                {
                    Message.ShowDialog();
                }
                return;
            }
            foreach (ListViewItem item in ListExtract.SelectedItems)
            {
                string normalPath = GAME_TYPES[_gameSelected].DefaultDirectory + "\\" + item.Text;
                string safePath = GAME_TYPES[_gameSelected].DefaultDirectory + "\\" + item.Text + DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
                if (!SystemControl.FileControl.DirectoryExists(normalPath))
                {
                    SystemControl.FileControl.DirectoryCreate(normalPath);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + LARGE_APPEND, normalPath + LARGE_APPEND);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + MEDIUM_APPEND, normalPath + MEDIUM_APPEND);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + SMALL_APPEND, normalPath + SMALL_APPEND);
                    imgCount++;
                }
                else
                {
                    _isRepeat = true;
                    SystemControl.FileControl.DirectoryCreate(safePath);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + LARGE_APPEND, safePath + LARGE_APPEND);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + MEDIUM_APPEND, safePath + MEDIUM_APPEND);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + SMALL_APPEND, safePath + SMALL_APPEND);
                    imgCount++;
                }
            }
            if (_isRepeat)
            {
                using (forms.MyMessageDialog Message = new forms.MyMessageDialog(Properties.TextVariables.MESG_REPEATFOLDER))
                {
                    Message.ShowDialog();
                }
            }
            if (imgCount > 0)
            {
                using (forms.MyMessageDialog Message = new forms.MyMessageDialog(Properties.TextVariables.MESG_SUCCESS + imgCount))
                {
                    Message.ShowDialog();
                }
            }
        }
        private void ButtonOpenFolders_Click(object sender, EventArgs e)
        {
            if (_extractFolderPath == "!NONE!")
            {
                return;
            }
            System.Diagnostics.Process.Start(GAME_TYPES[_gameSelected].DefaultDirectory);
            System.Diagnostics.Process.Start(_extractFolderPath);
        }
        private void ButtonHintExtract_Click(object sender, EventArgs e)
        {
            using (forms.MyMessageDialog Hint = new forms.MyMessageDialog(Properties.TextVariables.HINT_EXTRACTPAGE))
            {
                Hint.ShowDialog();
            }
        }
        private void LabelCopyright_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/zeightOFFICIAL/portrait-manager-pathfinder");
        }
        private void AnyPrimeButton_Enter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button != null)
                {
                    button.BackColor = GAME_TYPES[_gameSelected].ForeColor;
                    button.ForeColor = GAME_TYPES[_gameSelected].BackColor;
                }
            }
        }
        private void AnyPrimeButton_Leave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button != null)
                {
                    button.BackColor = GAME_TYPES[_gameSelected].BackColor;
                    button.ForeColor = GAME_TYPES[_gameSelected].ForeColor;
                }
            }
        }
        private void AnyButton_Enter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button != null)
                {
                    button.BackColor = Color.White;
                    button.ForeColor = Color.Black;
                }
            }
        }
        private void AnyButton_Leave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button != null && button.Enabled == true)
                {
                    button.BackColor = Color.Black;
                    button.ForeColor = Color.White;
                }
            }
        }
        private void ButtonRestorePath_Click(object sender, EventArgs e)
        {
            TextBoxFullPath.Text = GAME_TYPES[_gameSelected].DefaultDirectory;
        }
        private void TextBoxFullPath_TextChanged(object sender, EventArgs e)
        {
            ButtonValidatePath.Text = Properties.TextVariables.BUTTON_VALIDATE;
            ButtonValidatePath.BackColor = Color.Black;
            ButtonValidatePath.ForeColor = Color.White;
            ButtonValidatePath.Enabled = true;
            ButtonOpenPath.BackColor = Color.Black;
            ButtonOpenPath.ForeColor = Color.White;
            ButtonOpenPath.Text = Properties.TextVariables.BUTTON_OPENPATH;
            ButtonOpenPath.Enabled = true;
        }
        private void ButtonValidatePath_Click(object sender, EventArgs e)
        {
            if (ValidatePotraitPath(TextBoxFullPath.Text)) 
            {
                ButtonValidatePath.Text = Properties.TextVariables.BUTTON_OK;
                ButtonValidatePath.BackColor = Color.LimeGreen;
                ButtonValidatePath.Enabled = false;
            }
            else
            {
                ButtonValidatePath.Text = Properties.TextVariables.BUTTON_NO;
                ButtonValidatePath.BackColor = Color.Red;
                ButtonValidatePath.Enabled = false;
            }
        }
        private void ButtonSelectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            string defDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow");
            if (SystemControl.FileControl.DirectoryExists(defDir))
            {
                dialog.SelectedPath = defDir;
            }
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFolder = dialog.SelectedPath;
                TextBoxFullPath.Text = selectedFolder;
            }
        }
        private void ButtonOpenPath_Click(object sender, EventArgs e)
        {
            ButtonValidatePath_Click(sender, e);
            try
            {
                System.Diagnostics.Process.Start(TextBoxFullPath.Text);
            }
            catch
            {
                ButtonOpenPath.BackColor = Color.Red;
                ButtonOpenPath.Text = Properties.TextVariables.BUTTON_VALIDATE;
                ButtonOpenPath.Enabled = false;
                return;
            }
        }
        private void ButtonGameType_Click(object sender, EventArgs e)
        {
            if (_gameSelected == 'w')
            {
                _gameSelected = 'p';
                UpdateColorScheme();
            }
            else
            {
                _gameSelected = 'w';
                UpdateColorScheme();
            }
            if (!ValidatePotraitPath(ACTIVE_PATHS[_gameSelected]))
            {
                RemoveClickEventsFromMainButtons();
            }
            else
            {
                AddClickEventsFromMainButtons();
            }
            Properties.CoreSettings.Default.GameType = _gameSelected;
            Properties.CoreSettings.Default.Save();
        }
    }
}