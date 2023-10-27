/*    
    Pathfinder Portrait Manager. Desktop application for managing in game
    portraits for Pathfinder: Kingmaker and Pathfinder: Wrath of the Righteous
    Copyright (C) 2023 Artemii "Zeight" Saganenko
    LICENSE terms are written in LICENSE file
    Primal license header is written in Program.cs
*/

using PathfinderPortraitManager.forms;
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PathfinderPortraitManager
{
    public partial class MainForm : Form
    {
        private string _extractFolderPath = "!NONE!";
        private string _tunneledName = "!NONE!";
        private void PicPortraitTemp_DragDrop(object sender, DragEventArgs e)
        {
            string path = ParseDragDropFile(e);
            if (path == "!NONE!")
            {
                using (MyMessageDialog Message = new MyMessageDialog(Properties.TextVariables.MESG_WRONGFORMAT))
                {
                    Message.StartPosition = FormStartPosition.CenterScreen;
                    Message.ShowDialog();
                }

                if (_isAnyLoaded == true)
                {
                    LoadTempImages(_imageFlag);
                    ResizeVisibleImagesToWindow();
                    return;
                }
                _isAnyLoaded = false;
                LoadTempImages(_imageFlag);
                ResizeVisibleImagesToWindow();                
                return;
            }
            else
            {
                _isAnyLoaded = true;
                GenerateImageFlagString(_imageFlag);
                SafeCopyAllImages(path, _imageFlag);
                LoadTempImages(_imageFlag);
                ResizeVisibleImagesToWindow();
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
            string path = SystemControl.FileControl.OpenFileLocation();
            if (path == "!NONE!")
            {
                using (MyMessageDialog Message = new MyMessageDialog(Properties.TextVariables.MESG_WRONGFORMAT))
                {
                    Message.StartPosition = FormStartPosition.CenterParent;
                    Message.ShowDialog();
                }

                if (_isAnyLoaded == true)
                {
                    LoadTempImages(_imageFlag);
                    ResizeVisibleImagesToWindow();
                    return;
                }
                _isAnyLoaded = false;
                LoadTempImages(_imageFlag);
                ResizeVisibleImagesToWindow();
                return;
            }
            else
            {
                GenerateImageFlagString(_imageFlag);
                _isAnyLoaded = true;
                SafeCopyAllImages(path, _imageFlag);
                LoadTempImages(_imageFlag);
                ResizeVisibleImagesToWindow();
            }
        }
        private void ButtonLocalPortraitLoad_Click(object sender, EventArgs e)
        {
            PicPortraitTemp_Click(sender, e);
        }
        private void PicPortraitLrg_MouseDown(object sender, MouseEventArgs e)
        {
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
        }
        private void PicPortraitLrg_MouseUp(object sender, MouseEventArgs e)
        {
            RootFunctions.HideScrollBar(PanelPortraitLrg);
            _isDragging = 0;
        }
        private void PicPortraitMed_MouseDown(object sender, MouseEventArgs e)
        {
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
        }
        private void PicPortraitMed_MouseUp(object sender, MouseEventArgs e)
        {
            RootFunctions.HideScrollBar(PanelPortraitMed);
            _isDragging = 0;
        }
        private void PicPortraitSml_MouseDown(object sender, MouseEventArgs e)
        {
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
        }
        private void PicPortraitSml_MouseUp(object sender, MouseEventArgs e)
        {
            RootFunctions.HideScrollBar(PanelPortraitSml);
            _isDragging = 0;
        }
        private void PicPortraitLrg_MouseWheel(object sender, MouseEventArgs e)
        {
            RootFunctions.HideScrollBar(PanelPortraitLrg);
            float aspectRatio = (PicPortraitLrg.Width * 1.0f / PicPortraitLrg.Height * 1.0f),
                  factor;
            if (e.Delta > 0)
            {
                factor = PicPortraitLrg.Width * 1.0f / 8;
                ImageControl.Wraps.ZoomImage(PicPortraitLrg, PanelPortraitLrg, e, TEMP_LARGE_APPEND, aspectRatio, factor);
            }
            else
            {
                factor = -PicPortraitLrg.Width * 1.0f / 8;
                ImageControl.Wraps.ZoomImage(PicPortraitLrg, PanelPortraitLrg, e, TEMP_LARGE_APPEND, aspectRatio, factor);
            }
            RootFunctions.HideScrollBar(PanelPortraitLrg);
        }
        private void PicPortraitMed_MouseWheel(object sender, MouseEventArgs e)
        {
            RootFunctions.HideScrollBar(PanelPortraitMed);
            float aspectRatio = (PicPortraitMed.Width * 1.0f / PicPortraitMed.Height * 1.0f),
                  factor;
            if (e.Delta > 0)
            {
                factor = PicPortraitMed.Width * 1.0f / 10;
                ImageControl.Wraps.ZoomImage(PicPortraitMed, PanelPortraitMed, e, TEMP_MEDIUM_APPEND, aspectRatio, factor);
            }
            else
            {
                factor = -PicPortraitMed.Width * 1.0f / 10;
                ImageControl.Wraps.ZoomImage(PicPortraitMed, PanelPortraitMed, e, TEMP_MEDIUM_APPEND, aspectRatio, factor);
            }
            RootFunctions.HideScrollBar(PanelPortraitMed);
        }
        private void PicPortraitSml_MouseWheel(object sender, MouseEventArgs e)
        {
            RootFunctions.HideScrollBar(PanelPortraitSml);
            float aspectRatio = (PicPortraitSml.Width * 1.0f / PicPortraitSml.Height * 1.0f),
                  factor;
            if (e.Delta > 0)
            {
                factor = PicPortraitSml.Width * 1.0f / 10;
                ImageControl.Wraps.ZoomImage(PicPortraitSml, PanelPortraitSml, e, TEMP_SMALL_APPEND, aspectRatio, factor);
            }
            else
            {
                factor = -PicPortraitSml.Width * 1.0f / 10;
                ImageControl.Wraps.ZoomImage(PicPortraitSml, PanelPortraitSml, e, TEMP_SMALL_APPEND, aspectRatio, factor);
            }
            RootFunctions.HideScrollBar(PanelPortraitSml);
        }
        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            ResizeVisibleImagesToWindow();
        }
        private void ButtonCreatePortrait_Click(object sender, EventArgs e)
        {
            ButtonToMainPageAndFolder.Enabled = true;
            RootFunctions.LayoutDisable(LayoutScalePage);
            string path = "";
            bool placeable = false;
            uint calling = 0;
            if (!SystemControl.FileControl.Readonly.DirectoryExists(ACTIVE_PATHS[_gameSelected]))
            {
                RootFunctions.LayoutEnable(LayoutFinalPage);
                LabelFinalMesg.Text = Properties.TextVariables.LABEL_CREATEDERROR;
                LabelDirLoc.Text = ACTIVE_PATHS[_gameSelected];
                ButtonToMainPageAndFolder.Enabled = false;
                return;
            }
            if (_tunneledName != "!NONE!")
            {
                path = ACTIVE_PATHS[_gameSelected] + "\\" + _tunneledName;
                _tunneledName = "!NONE!";
                GeneratePortraits(path);
                placeable = true;
            }
            while (!placeable)
            {
                path = ACTIVE_PATHS[_gameSelected] + "\\" + Convert.ToString(calling);
                if (!Directory.Exists(path))
                {
                    GeneratePortraits(path);
                    placeable = true;
                }
                calling++;
            }
            if (CheckPortraitExistence(path))
            {
                RootFunctions.LayoutEnable(LayoutFinalPage);
                LabelFinalMesg.Text = Properties.TextVariables.LABEL_CREATEDOK;
                LabelDirLoc.Text = path;
            }
            else
            {
                RootFunctions.LayoutEnable(LayoutFinalPage);
                LabelFinalMesg.Text = Properties.TextVariables.LABEL_CREATEDERROR;
                LabelDirLoc.Text = path;
                ButtonToMainPageAndFolder.Enabled = false;
            }
        }
        private void PicPortraitMed_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            using (Image img = new Bitmap(TEMP_MEDIUM_APPEND))
                ResizeImageToParent(PicPortraitMed, img, PanelPortraitMed);
        }
        private void PicPortraitLrg_MouseDoubleClick(object sedner, MouseEventArgs e)
        {
            using (Image img = new Bitmap(TEMP_LARGE_APPEND))
                ResizeImageToParent(PicPortraitLrg, img, PanelPortraitLrg);
        }
        private void PicPortraitSml_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            using (Image img = new Bitmap(TEMP_SMALL_APPEND))
                ResizeImageToParent(PicPortraitSml, img, PanelPortraitSml);
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
            using (MyMessageDialog Hint = new MyMessageDialog(Properties.TextVariables.HINT_SCALEPAGE))
            {
                Hint.StartPosition = FormStartPosition.CenterParent;
                Hint.ShowDialog();
            }
        }
        private void ButtonHintOnFilePage_Click(object sender, EventArgs e)
        {
            using (MyMessageDialog Hint = new MyMessageDialog(Properties.TextVariables.HINT_FILEPAGE))
            {
                Hint.StartPosition = FormStartPosition.CenterParent;
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
            Properties.CoreSettings.Default.GameType = _gameSelected;
            Properties.CoreSettings.Default.Save();
            UpdateColorScheme();
            if (!ValidatePortraitPath(ACTIVE_PATHS[_gameSelected]))
            {
                using (MyMessageDialog Message = new MyMessageDialog(Properties.TextVariables.MESG_GAMEFOLDERNOTFOUND))
                {
                    Message.StartPosition = FormStartPosition.CenterParent;
                    Message.ShowDialog();
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
            System.Diagnostics.Process.Start(ACTIVE_PATHS[_gameSelected]);
        }
        private void ButtonChangePortrait_Click(object sender, EventArgs e)
        {
            if (ListGallery.Items.Count < 1)
            {
                return;
            }
            if (ListGallery.SelectedItems.Count < 1)
            {
                using (MyMessageDialog Message = new MyMessageDialog(Properties.TextVariables.MESG_NONESELECTED))
                {
                    Message.StartPosition= FormStartPosition.CenterParent;
                    Message.ShowDialog();
                }

                return;
            }
            else if (ListGallery.SelectedItems.Count > 1)
            {
                using (MyMessageDialog Message = new MyMessageDialog(Properties.TextVariables.MESG_SELECTEDMORE))
                {
                    Message.StartPosition = FormStartPosition.CenterParent;
                    Message.ShowDialog();
                }
            }

            ListViewItem item = ListGallery.SelectedItems[0];
            using (Image img = new Bitmap(GAME_TYPES[_gameSelected].PlaceholderImage))
                ClearPrimeImages(img);
            SystemControl.FileControl.ClearTempImages();
            SystemControl.FileControl.CreateDirectory("temp_DoNotDeleteWhileRunning\\");
            string path = ACTIVE_PATHS[_gameSelected] + "\\" + item.Text;
            using (Image img = new Bitmap(path + LARGE_APPEND))
                img.Save(TEMP_LARGE_APPEND);
            using (Image img = new Bitmap(path + MEDIUM_APPEND))
                img.Save(TEMP_MEDIUM_APPEND);
            using (Image img = new Bitmap(path + SMALL_APPEND))
                img.Save(TEMP_SMALL_APPEND);
            LoadTempImages(100);
            GenerateImageFlagString(0);
            _tunneledName = "!NONE!";            

            using (MyInquiryDialog Inquiry = new MyInquiryDialog(Properties.TextVariables.INQR_DELETEOLD))
            {
                Inquiry.StartPosition = FormStartPosition.CenterParent;
                if (Inquiry.ShowDialog() == DialogResult.OK)
                {
                    ListGallery.Items.RemoveByKey(item.Text);
                    ImgListGallery.Images.RemoveByKey(item.Text);
                    SystemControl.FileControl.DeleteDirectoryRecursive(ACTIVE_PATHS[_gameSelected] + "\\" + item.Text);
                    _tunneledName = item.Text;
                    item.Remove();
                }
            }

            ButtonToMainPage3_Click(sender, e);
            RootFunctions.LayoutDisable(LayoutMainPage);
            RootFunctions.LayoutEnable(LayoutFilePage);
            RestoreFilePage();
            _isAnyLoaded = true;
            ResizeVisibleImagesToWindow();
        }
        private void ButtonDeletePortait_Click(object sender, EventArgs e)
        {
            if (ListGallery.Items.Count < 1)
            {
                return;
            }
            if (ListGallery.SelectedItems.Count < 1)
            {
                using (MyMessageDialog Message = new MyMessageDialog(Properties.TextVariables.MESG_NONESELECTED))
                {
                    Message.StartPosition = FormStartPosition.CenterParent;
                    Message.ShowDialog();
                }
                return;
            }

            using (MyInquiryDialog Message = new MyInquiryDialog(Properties.TextVariables.MESG_DELETE + ListGallery.SelectedItems.Count))
            {
                Message.StartPosition = FormStartPosition.CenterParent;
                if (Message.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }
            foreach (ListViewItem item in ListGallery.SelectedItems)
            {
                string path = ACTIVE_PATHS[_gameSelected] + "\\" + item.Text + "\\";
                ImgListGallery.Images.RemoveByKey(item.Text);
                item.Remove();
                SystemControl.FileControl.DeleteDirectoryRecursive(path);
            }
            _cancellationTokenSource.Cancel();
            ImgListGallery.Images.Clear();
            ListGallery.Clear();
            if (!LoadGallery(ACTIVE_PATHS[_gameSelected]))
            {
                ButtonToMainPage3_Click(sender, e);
                return;
            }
        }
        private void ButtonHintFolder_Click(object sender, EventArgs e)
        {
            using (MyMessageDialog Hint = new MyMessageDialog(Properties.TextVariables.HINT_GALLERYPAGE))
            {
                Hint.StartPosition = FormStartPosition.CenterParent;
                Hint.ShowDialog();
            }
        }
        private async void ButtonChooseFolder_Click(object sender, EventArgs e)
        {
            if (_extractFolderPath != "!NONE!")
            {
                ClearImageLists(ListExtract, ImgListExtract);
            }

            string defaultDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            if (!SystemControl.FileControl.Readonly.DirectoryExists(defaultDir))
            {
                defaultDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            using (FolderBrowserDialog FolderChoose = new FolderBrowserDialog()
            {
                SelectedPath = defaultDir,
                Description = Properties.TextVariables.TEXT_FOLDEROPEN,
                ShowNewFolderButton = false,
                
            })
            {
                if (FolderChoose.ShowDialog() == DialogResult.OK)
                {
                    _extractFolderPath = FolderChoose.SelectedPath;
                }
                else
                {
                    FolderChoose.Dispose();
                    _extractFolderPath = "!NONE!";
                    return;
                }
            }
            if (!SystemControl.FileControl.Readonly.DirectoryExists(_extractFolderPath))
            {
                _extractFolderPath = "!NONE!";
                return;
            }
            _cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = _cancellationTokenSource.Token;
            await ExploreDirectory(_extractFolderPath, cancellationToken);
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
                string normalPath = ACTIVE_PATHS[_gameSelected] + "\\" + item.Text;
                string safePath = ACTIVE_PATHS[_gameSelected] + "\\" + item.Text + DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
                if (!SystemControl.FileControl.Readonly.DirectoryExists(normalPath))
                {
                    SystemControl.FileControl.CreateDirectory(normalPath);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + LARGE_APPEND, normalPath + LARGE_APPEND);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + MEDIUM_APPEND, normalPath + MEDIUM_APPEND);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + SMALL_APPEND, normalPath + SMALL_APPEND);
                    imgCount++;
                }
                else
                {
                    _isRepeat = true;
                    SystemControl.FileControl.CreateDirectory(safePath);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + LARGE_APPEND, safePath + LARGE_APPEND);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + MEDIUM_APPEND, safePath + MEDIUM_APPEND);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + SMALL_APPEND, safePath + SMALL_APPEND);
                    imgCount++;
                }
            }

            if (_isRepeat)
            {
                using (MyMessageDialog Message = new MyMessageDialog(Properties.TextVariables.MESG_REPEATFOLDER))
                {
                    Message.StartPosition = FormStartPosition.CenterParent;
                    Message.ShowDialog();
                }
            }

            if (imgCount > 0)
            {
                using (MyMessageDialog Message = new MyMessageDialog(Properties.TextVariables.MESG_SUCCESS + imgCount))
                {
                    Message.StartPosition = FormStartPosition.CenterParent;
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
                using (MyMessageDialog Message = new MyMessageDialog(Properties.TextVariables.MESG_NONESELECTEDEXTRACT))
                {
                    Message.StartPosition = FormStartPosition.CenterParent;
                    Message.ShowDialog();
                }
                return;
            }

            foreach (ListViewItem item in ListExtract.SelectedItems)
            {
                string normalPath = ACTIVE_PATHS[_gameSelected] + "\\" + item.Text;
                string safePath = ACTIVE_PATHS[_gameSelected] + "\\" + item.Text + DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
                if (!SystemControl.FileControl.Readonly.DirectoryExists(normalPath))
                {
                    SystemControl.FileControl.CreateDirectory(normalPath);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + LARGE_APPEND, normalPath + LARGE_APPEND);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + MEDIUM_APPEND, normalPath + MEDIUM_APPEND);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + SMALL_APPEND, normalPath + SMALL_APPEND);
                    imgCount++;
                }
                else
                {
                    _isRepeat = true;
                    SystemControl.FileControl.CreateDirectory(safePath);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + LARGE_APPEND, safePath + LARGE_APPEND);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + MEDIUM_APPEND, safePath + MEDIUM_APPEND);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + SMALL_APPEND, safePath + SMALL_APPEND);
                    imgCount++;
                }
            }

            if (_isRepeat)
            {
                using (MyMessageDialog Message = new MyMessageDialog(Properties.TextVariables.MESG_REPEATFOLDER))
                {
                    Message.StartPosition = FormStartPosition.CenterParent;
                    Message.ShowDialog();
                }
            }

            if (imgCount > 0)
            {
                using (MyMessageDialog Message = new MyMessageDialog(Properties.TextVariables.MESG_SUCCESS + imgCount))
                {
                    Message.StartPosition = FormStartPosition.CenterParent;
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
            System.Diagnostics.Process.Start(ACTIVE_PATHS[_gameSelected]);
            System.Diagnostics.Process.Start(_extractFolderPath);
            ButtonToMainPage2_Click(sender, e);            
        }
        private void ButtonHintExtract_Click(object sender, EventArgs e)
        {
            using (MyMessageDialog Hint = new MyMessageDialog(Properties.TextVariables.HINT_EXTRACTPAGE))
            {
                Hint.StartPosition = FormStartPosition.CenterParent;
                Hint.ShowDialog();
            }
        }
        private void LabelCopyright_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/zeightOFFICIAL/portrait-manager-pathfinder");
            }
            catch
            {
                return;
            }
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
            ButtonApplyChange.Text = Properties.TextVariables.BUTTON_APPLY;
            ButtonApplyChange.BackColor = Color.Black;
            ButtonApplyChange.ForeColor = Color.White;
            ButtonApplyChange.Enabled = true;
        }
        private void ButtonValidatePath_Click(object sender, EventArgs e)
        {
            if (ValidatePortraitPath(TextBoxFullPath.Text)) 
            {
                ButtonValidatePath.Text = Properties.TextVariables.BUTTON_OK;
                ButtonValidatePath.ForeColor = Color.White;
                ButtonValidatePath.BackColor = Color.LimeGreen;
                ButtonValidatePath.Enabled = false;
            }
            else
            {
                ButtonValidatePath.Text = Properties.TextVariables.BUTTON_NO;
                ButtonValidatePath.ForeColor = Color.White;
                ButtonValidatePath.BackColor = Color.Red;
                ButtonValidatePath.Enabled = false;
            }
        }
        private void ButtonSelectPath_Click(object sender, EventArgs e)
        {
            string defaultDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow");
            if (!SystemControl.FileControl.Readonly.DirectoryExists(defaultDir))
            {
                defaultDir = "";
            }

            using (FolderBrowserDialog FolderChoose = new FolderBrowserDialog()
            {
                SelectedPath = defaultDir,
                Description = Properties.TextVariables.TEXT_PATHOPEN,
                ShowNewFolderButton = false,
            })
            {
                if (FolderChoose.ShowDialog() == DialogResult.OK)
                {
                    TextBoxFullPath.Text = FolderChoose.SelectedPath;
                }
                else
                {
                    return;
                }
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
            if (!ValidatePortraitPath(ACTIVE_PATHS[_gameSelected]))
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
        private void ButtonLoadWeb_Click(object sender, EventArgs e)
        {
            string url = TextBoxURL.Text;
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "HEAD";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                response.Close();
                RootFunctions.LayoutDisable(LayoutURLDialog);
                RootFunctions.LayoutEnable(LayoutFilePage);
                CheckWebResourceAndLoad(url);
                ResizeVisibleImagesToWindow();
                TextBoxURL.Text = Properties.TextVariables.TEXTBOX_URL_INPUT;
                GenerateImageFlagString(_imageFlag);
            }
            catch
            {
                TextBoxURL.Text = Properties.TextVariables.TEXTBOX_URL_WRONG;
            }

        }
        private void ButtonDenyWeb_Click(object sender, EventArgs e)
        {
            RootFunctions.LayoutDisable(LayoutURLDialog);
            RootFunctions.LayoutEnable(LayoutFilePage);
            TextBoxURL.Text = Properties.TextVariables.TEXTBOX_URL_INPUT;
            ResizeVisibleImagesToWindow();
        }
        private void TextBoxURL_DragEnter(object sender, DragEventArgs e)
        {
            TextBoxURL.Clear();
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void TextBoxURL_DragDrop(object sender, DragEventArgs e)
        {
            TextBox senderTextBox = (TextBox)sender;
            senderTextBox.Text = (string)e.Data.GetData(DataFormats.Text);
            if (!senderTextBox.Text.Contains("http"))
            {
                senderTextBox.Text = "http://" + senderTextBox.Text;
            }
        }
        private void TextBoxURL_Enter(object sender, EventArgs e)
        {
            TextBoxURL.Clear();
        }
        private void ButtonToMainPageAndFolder_Click(object sender, EventArgs e)
        {
            ButtonToMainPageAndFolder.BackColor = Color.Black;
            ButtonToMainPageAndFolder.ForeColor = Color.White;
            RootFunctions.LayoutDisable(LayoutFinalPage);
            ReplacePrimeImagesToDefault();
            _isAnyLoaded = false;
            ParentLayoutsDisable();
            System.Diagnostics.Process.Start(LabelDirLoc.Text);
            RootFunctions.LayoutEnable(LayoutMainPage);
            ButtonToMainPageAndFolder.Enabled = true;
        }
        private void ButtonNextImageType_Click(object sender, EventArgs e)
        {
            _imageFlag++;
            if (_imageFlag == 1)
            {
                ButtonNextImageType.Text = Properties.TextVariables.BUTTON_ADVANCED2;
            }
            else
            {
                ButtonNextImageType.Visible = false;
                ButtonNextImageType.Enabled = false;
            }
            GenerateImageFlagString(_imageFlag);
            LoadTempImages(_imageFlag);
            ResizeVisibleImagesToWindow();
        }
        private void ButtonApplyChange_Click(object sender, EventArgs e)
        {
            if (ButtonValidatePath.Text == Properties.TextVariables.BUTTON_OK)
            {
                if (_gameSelected == 'p')
                {
                    Properties.CoreSettings.Default.KINGPath = TextBoxFullPath.Text;
                }
                else
                {
                    Properties.CoreSettings.Default.WOTRPath = TextBoxFullPath.Text;
                }
                AnyButton_Leave(sender, e);
                ButtonApplyChange.BackColor = Color.LimeGreen;
                ButtonApplyChange.ForeColor = Color.White;
                ButtonApplyChange.Enabled = false;
                ButtonApplyChange.Text = Properties.TextVariables.BUTTON_SUCESS;
                Properties.CoreSettings.Default.Save();
                AddClickEventsFromMainButtons();
                ACTIVE_PATHS[_gameSelected] = TextBoxFullPath.Text;
            }
        }
    }
}