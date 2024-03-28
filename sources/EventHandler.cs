/*    
    Owlcat Portrait Manager. Desktop application for managing in game
    portraits for Owlcat Games products. Including: 1. Pathfinder: Kingmaker,
    2. Pathfinder: Wrath of the Righteous, 3. Warhammer 40000: Rogue Trader
    Copyright (C) 2024 Artemii "Zeight" Saganenko.

    GPL-2.0 license terms are listed in LICENSE file.
    License header for this project is listed in Program.cs.
*/

using OwlcatPortraitManager.forms;
using OwlcatPortraitManager.Properties;

using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OwlcatPortraitManager
{
    public partial class MainForm : Form
    {
        private string _extractFolderPath = "!NONE!";
        private string _tunneledNameToPortraitPage = "!NONE!";

        private void PicPortraitTemp_DragDrop(object sender, DragEventArgs e)
        {
            string path = ParseDragDropFile(e);

            if (path == "!NONE!")
            {
                using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_WRONGFORMAT, CoreSettings.Default.SelectedLang))
                {
                    Message.StartPosition = FormStartPosition.CenterParent;
                    Message.ShowDialog();
                }

                if (_isAnyLoadedToPortraitPage == true)
                {
                    LoadTempImagesToPicBox(_imageSelectionFlag);
                    ResizeVisibleImagesToWindowSize();
                    return;
                }

                _isAnyLoadedToPortraitPage = false;
                LoadTempImagesToPicBox(_imageSelectionFlag);
                ResizeVisibleImagesToWindowSize();
                return;
            }
            else
            {
                _isAnyLoadedToPortraitPage = true;
                GenerateImageSelectionFlagString(_imageSelectionFlag);
                CreateAllImagesInTemp(path, _imageSelectionFlag);
                LoadTempImagesToPicBox(_imageSelectionFlag);
                ResizeVisibleImagesToWindowSize();
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
                using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_WRONGFORMAT, CoreSettings.Default.SelectedLang))
                {
                    Message.StartPosition = FormStartPosition.CenterParent;
                    Message.ShowDialog();
                }

                if (_isAnyLoadedToPortraitPage == true)
                {
                    LoadTempImagesToPicBox(_imageSelectionFlag);
                    ResizeVisibleImagesToWindowSize();
                    return;
                }

                _isAnyLoadedToPortraitPage = false;
                LoadTempImagesToPicBox(_imageSelectionFlag);
                ResizeVisibleImagesToWindowSize();
                return;
            }
            else
            {
                _isAnyLoadedToPortraitPage = true;
                GenerateImageSelectionFlagString(_imageSelectionFlag);
                CreateAllImagesInTemp(path, _imageSelectionFlag);
                LoadTempImagesToPicBox(_imageSelectionFlag);
                ResizeVisibleImagesToWindowSize();
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
                _isDraggingMouse = 1;
            }
        }

        private void PicPortraitLrg_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDraggingMouse == 1 && (PicPortraitLrg.Image.Width > PanelPortraitLrg.Width ||
                                  PicPortraitLrg.Image.Height > PanelPortraitLrg.Height))
            {
                PanelPortraitLrg.AutoScrollPosition = new Point(-PanelPortraitLrg.AutoScrollPosition.X + (_mousePosition.X - e.X),
                                                              -PanelPortraitLrg.AutoScrollPosition.Y + (_mousePosition.Y - e.Y));
            }
        }
        
        private void PicPortraitLrg_MouseUp(object sender, MouseEventArgs e)
        {
            RootFunctions.HideScrollBar(PanelPortraitLrg);
            _isDraggingMouse = 0;
        }
        
        private void PicPortraitMed_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mousePosition = e.Location;
                _isDraggingMouse = 2;
            }
        }
        
        private void PicPortraitMed_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDraggingMouse == 2 && (PicPortraitMed.Image.Width > PanelPortraitMed.Width ||
                                  PicPortraitMed.Image.Height > PanelPortraitMed.Height))
            {
                PanelPortraitMed.AutoScrollPosition = new Point(-PanelPortraitMed.AutoScrollPosition.X + (_mousePosition.X - e.X),
                                                              -PanelPortraitMed.AutoScrollPosition.Y + (_mousePosition.Y - e.Y));
            }
        }

        private void PicPortraitMed_MouseUp(object sender, MouseEventArgs e)
        {
            RootFunctions.HideScrollBar(PanelPortraitMed);
            _isDraggingMouse = 0;
        }

        private void PicPortraitSml_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mousePosition = e.Location;
                _isDraggingMouse = 3;
            }
        }

        private void PicPortraitSml_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDraggingMouse == 3 && (PicPortraitSml.Image.Width > PanelPortraitSml.Width ||
                                  PicPortraitSml.Image.Height > PanelPortraitSml.Height))
            {
                PanelPortraitSml.AutoScrollPosition = new Point(-PanelPortraitSml.AutoScrollPosition.X + (_mousePosition.X - e.X),
                                                              -PanelPortraitSml.AutoScrollPosition.Y + (_mousePosition.Y - e.Y));
            }
        }

        private void PicPortraitSml_MouseUp(object sender, MouseEventArgs e)
        {
            RootFunctions.HideScrollBar(PanelPortraitSml);
            _isDraggingMouse = 0;
        }
        
        private void PicPortraitLrg_MouseWheel(object sender, MouseEventArgs e)
        {
            RootFunctions.HideScrollBar(PanelPortraitLrg);
            float aspectRatio = (PicPortraitLrg.Width * 1.0f / PicPortraitLrg.Height * 1.0f);
            float zoomFactor = PicPortraitLrg.Width * 1.0f / 14;

            if (e.Delta > 0)
            {
                ImageControl.Wraps.ZoomImage(PicPortraitLrg, PanelPortraitLrg, e, TEMP_LARGE_APPEND, aspectRatio, zoomFactor);
            }
            else
            {
                zoomFactor = -zoomFactor;
                ImageControl.Wraps.ZoomImage(PicPortraitLrg, PanelPortraitLrg, e, TEMP_LARGE_APPEND, aspectRatio, zoomFactor);
            }

            RootFunctions.HideScrollBar(PanelPortraitLrg);
        }

        private void PicPortraitMed_MouseWheel(object sender, MouseEventArgs e)
        {
            RootFunctions.HideScrollBar(PanelPortraitMed);
            float aspectRatio = (PicPortraitLrg.Width * 1.0f / PicPortraitLrg.Height * 1.0f);
            float zoomFactor = PicPortraitLrg.Width * 1.0f / 10;

            if (e.Delta > 0)
            {
                ImageControl.Wraps.ZoomImage(PicPortraitMed, PanelPortraitMed, e, TEMP_MEDIUM_APPEND, aspectRatio, zoomFactor);
            }
            else
            {
                zoomFactor = -zoomFactor;
                ImageControl.Wraps.ZoomImage(PicPortraitMed, PanelPortraitMed, e, TEMP_MEDIUM_APPEND, aspectRatio, zoomFactor);
            }

            RootFunctions.HideScrollBar(PanelPortraitMed);
        }

        private void PicPortraitSml_MouseWheel(object sender, MouseEventArgs e)
        {
            RootFunctions.HideScrollBar(PanelPortraitSml);
            float aspectRatio = (PicPortraitLrg.Width * 1.0f / PicPortraitLrg.Height * 1.0f);
            float zoomFactor = PicPortraitLrg.Width * 1.0f / 6;

            if (e.Delta > 0)
            {
                ImageControl.Wraps.ZoomImage(PicPortraitSml, PanelPortraitSml, e, TEMP_SMALL_APPEND, aspectRatio, zoomFactor);
            }
            else
            {
                zoomFactor = -zoomFactor;
                ImageControl.Wraps.ZoomImage(PicPortraitSml, PanelPortraitSml, e, TEMP_SMALL_APPEND, aspectRatio, zoomFactor);
            }

            RootFunctions.HideScrollBar(PanelPortraitSml);
        }
        
        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            ResizeVisibleImagesToWindowSize();
        }

        private void ButtonCreatePortrait_Click(object sender, EventArgs e)
        {
            ButtonToMainPageAndFolder.Enabled = true;
            RootFunctions.LayoutDisable(LayoutScalePage);

            string path = "";
            bool placeableFilepath = false;
            uint pseudoUniqueName = 0;

            if (!SystemControl.FileControl.Readonly.DirectoryExists(ACTIVE_PATHS[_gameSelected]))
            {
                RootFunctions.LayoutEnable(LayoutFinalPage);
                LabelFinalMesg.Text = TextVariables.LABEL_CREATEDERROR;
                LabelDirLoc.Text = ACTIVE_PATHS[_gameSelected];
                ButtonToMainPageAndFolder.Enabled = false;
                return;
            }

            if (_tunneledNameToPortraitPage != "!NONE!")
            {
                path = _tunneledNameToPortraitPage;
                _tunneledNameToPortraitPage = "!NONE!";
                GeneratePortraits(path);
                placeableFilepath = true;
            }

            while (!placeableFilepath)
            {
                path = ACTIVE_PATHS[_gameSelected] + "\\" + Convert.ToString(pseudoUniqueName);
                if (!Directory.Exists(path))
                {
                    GeneratePortraits(path);
                    placeableFilepath = true;
                }
                pseudoUniqueName++;
            }

            if (CheckPortraitExistence(path))
            {
                RootFunctions.LayoutEnable(LayoutFinalPage);
                LabelFinalMesg.Text = TextVariables.LABEL_CREATEDOK;
                LabelDirLoc.Text = path;
            }
            else
            {
                RootFunctions.LayoutEnable(LayoutFinalPage);
                LabelFinalMesg.Text = TextVariables.LABEL_CREATEDERROR;
                LabelDirLoc.Text = path;
                ButtonToMainPageAndFolder.Enabled = false;
            }
        }
        
        private void PicPortraitMed_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            using (Image img = new Bitmap(TEMP_MEDIUM_APPEND))
                ResizeImageToParentControl(PicPortraitMed, img, PanelPortraitMed);
        }
        
        private void PicPortraitLrg_MouseDoubleClick(object sedner, MouseEventArgs e)
        {
            using (Image img = new Bitmap(TEMP_LARGE_APPEND))
                ResizeImageToParentControl(PicPortraitLrg, img, PanelPortraitLrg);
        }
        
        private void PicPortraitSml_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            using (Image img = new Bitmap(TEMP_SMALL_APPEND))
                ResizeImageToParentControl(PicPortraitSml, img, PanelPortraitSml);
        }
        
        private void LabelMedImg_MouseHover(object sender, EventArgs e)
        {
            LabelMedImage.Text = TextVariables.LABEL_MEDIUMIMG2;
        }
        
        private void LabelLrgImg_MouseHover(object sender, EventArgs e)
        {
            LabelLrgImg.Text = TextVariables.LABEL_LARGEIMG2;
        }
        
        private void LabelSmlImg_MouseHover(object sender, EventArgs e)
        {
            LabelSmlImg.Text = TextVariables.LABEL_SMALLIMG2;
        }
        
        private void LabelMedImg_MouseLeave(object sender, EventArgs e)
        {
            LabelMedImage.Text = TextVariables.LABEL_MEDIUMIMG;
        }
        
        private void LabelLrgImg_MouseLeave(object sender, EventArgs e)
        {
            LabelLrgImg.Text = TextVariables.LABEL_LARGEIMG;
        }
        
        private void LabelSmlImg_MouseLeave(object sender, EventArgs e)
        {
            LabelSmlImg.Text = TextVariables.LABEL_SMALLIMG;
        }
        
        private void ButtonWebPortraitLoad_Click(object sender, EventArgs e)
        {
            RootFunctions.LayoutDisable(LayoutFilePage);            
            RootFunctions.LayoutEnable(LayoutURLDialog); 
            AnyButton_Leave(ButtonDenyWeb, e);
            AnyButton_Leave(ButtonLoadWeb, e);
        }
        
        private void ButtonHintOnScalePage_Click(object sender, EventArgs e)
        {
            using (MyMessageDialog Hint = new MyMessageDialog(TextVariables.HINT_SCALEPAGE, CoreSettings.Default.SelectedLang))
            {
                Hint.StartPosition = FormStartPosition.CenterParent;
                Hint.ShowDialog();
            }
        }

        private void ButtonHintOnFilePage_Click(object sender, EventArgs e)
        {
            using (MyMessageDialog Hint = new MyMessageDialog(TextVariables.HINT_FILEPAGE, CoreSettings.Default.SelectedLang))
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
            else if (_gameSelected == 'r')
            {
                _gameSelected = 'p';
            }
            else
            {
                _gameSelected = 'r';
            }

            CoreSettings.Default.GameType = _gameSelected;
            CoreSettings.Default.Save();
            UpdateColorScheme();

            if (!ValidatePortraitPath(ACTIVE_PATHS[_gameSelected]))
            {
                using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_GAMEFOLDERNOTFOUND, CoreSettings.Default.SelectedLang))
                {
                    Message.StartPosition = FormStartPosition.CenterParent;
                    Message.ShowDialog();
                }
                RemoveClickEventsFromMainButtons();
            }
            else
            {
                AddClickEventsToMainButtons();
            }

            if (_gameSelected == 'r')
            {
                RemoveClickEventsFromCustomPortraitsButtons();
                CheckBoxVerified.Checked = false;
                UseStamps.Default.isAwareNPC = "NotRevealed";
                UseStamps.Default.Save();
                ButtonLoadCustom.Visible = false;
                ButtonLoadCustomNPC.Visible = false;
                ButtonLoadCustomArmy.Visible = false;
                return;
            }

            if (!ValidateCustomPath(ACTIVE_PATHS[_gameSelected]) && 
                (UseStamps.Default.isAwareNPC == "NotRevealed" || UseStamps.Default.isAwareNPC == "WorkRevealed"))
            {
                using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_CUSTOMNOTFOUND, CoreSettings.Default.SelectedLang))
                {
                    Message.StartPosition = FormStartPosition.CenterParent;
                    Message.ShowDialog();
                }
                RemoveClickEventsFromCustomPortraitsButtons();
                CheckBoxVerified.Checked = false;
                UseStamps.Default.isAwareNPC = "NotWorkRevealed";
                UseStamps.Default.Save();
                ButtonLoadCustom.Visible = false;
                ButtonLoadCustomNPC.Visible = false;
                ButtonLoadCustomArmy.Visible = false;

            }
            else if (ValidateCustomPath(ACTIVE_PATHS[_gameSelected]) 
                && (UseStamps.Default.isAwareNPC == "NotRevealed" || UseStamps.Default.isAwareNPC == "NotWorkRevealed"))
            {
                using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_CUSTOMFOUND, CoreSettings.Default.SelectedLang))
                {
                    Message.StartPosition = FormStartPosition.CenterParent;
                    Message.ShowDialog();
                }
                AddClickEventsToCustomPortraitsButtons();
                CheckBoxVerified.Checked = true;
                UseStamps.Default.isAwareNPC = "WorkRevealed";
                UseStamps.Default.Save();
                ButtonLoadCustom.Visible = true;
                ButtonLoadCustomNPC.Visible = true;
                ButtonLoadCustomArmy.Visible = true;
            }

            if (UseStamps.Default.isAwareNPC == "WorkRevealed")
            {
                CheckBoxVerified.Checked = true;
            }
            else
            {
                CheckBoxVerified.Checked = false;
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
                using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_NONESELECTED, CoreSettings.Default.SelectedLang))
                {
                    Message.StartPosition = FormStartPosition.CenterParent;
                    Message.ShowDialog();
                }

                return;
            }
            else if (ListGallery.SelectedItems.Count > 1)
            {
                using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_SELECTEDMORE, CoreSettings.Default.SelectedLang))
                {
                    Message.StartPosition = FormStartPosition.CenterParent;
                    Message.ShowDialog();
                }
            }

            ListViewItem item = ListGallery.SelectedItems[0];
            using (Image img = new Bitmap(GAME_TYPES[_gameSelected].PlaceholderImage))
                ClearPictureBoxImages(img);
            SystemControl.FileControl.ClearTempImages();
            SystemControl.FileControl.CreateDirectory("temp_DoNotDeleteWhileRunning\\");

            string path = item.Tag.ToString().Split('>')[0];
            string type = item.Tag.ToString().Split('>')[1];

            try
            {
                using (Image img = new Bitmap(path + LARGE_APPEND))
                    img.Save(TEMP_LARGE_APPEND);
            }
            catch
            {
                using (Image img = new Bitmap(path + MEDIUM_APPEND))
                {
                    Bitmap newImg = ImageControl.Direct.Resize(img, 692, 1024);
                    newImg.Save(TEMP_LARGE_APPEND);
                }
            }

            using (Image img = new Bitmap(path + MEDIUM_APPEND))
                img.Save(TEMP_MEDIUM_APPEND);
            using (Image img = new Bitmap(path + SMALL_APPEND))
                img.Save(TEMP_SMALL_APPEND);

            LoadTempImagesToPicBox(100);
            GenerateImageSelectionFlagString(0);
            _tunneledNameToPortraitPage = "!NONE!";

            using (MyInquiryDialog Inquiry = new MyInquiryDialog(TextVariables.INQR_DELETEOLD, CoreSettings.Default.SelectedLang))
            {
                Inquiry.StartPosition = FormStartPosition.CenterParent;

                if (Inquiry.ShowDialog() == DialogResult.OK)
                {
                    ListGallery.Items.RemoveByKey(item.Text);
                    ImgListGallery.Images.RemoveByKey(item.Text);

                    if (type == "LOCAL")
                    {
                        SystemControl.FileControl.DeleteDirectoryRecursive(ACTIVE_PATHS[_gameSelected] + "\\" + item.Text);
                    }
                    else
                    {
                        SystemControl.FileControl.DeleteDirectoryRecursive(path + "\\BACKUP");
                        SystemControl.FileControl.CreateDirectory(path + "\\BACKUP");
                        SystemControl.FileControl.CopyFile(path + LARGE_APPEND, path + "\\BACKUP" + LARGE_APPEND);
                        SystemControl.FileControl.CopyFile(path + MEDIUM_APPEND, path + "\\BACKUP" + MEDIUM_APPEND);
                        SystemControl.FileControl.CopyFile(path + SMALL_APPEND, path + "\\BACKUP" + SMALL_APPEND);
                    }
                    _tunneledNameToPortraitPage = path;
                    item.Remove();
                }
                else
                {
                    if (type == "CUSTOM")
                    {
                        _tunneledNameToPortraitPage = Path.Combine(path, path.Split('\\').Last().Split('-').Last() + DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString());
                    }
                }
            }

            ButtonToMainPage3_Click(sender, e);
            RootFunctions.LayoutDisable(LayoutMainPage);
            RootFunctions.LayoutEnable(LayoutFilePage);
            RestoreFilePageToInit();
            _isAnyLoadedToPortraitPage = true;
            ResizeVisibleImagesToWindowSize();
        }

        private void ButtonDeletePortait_Click(object sender, EventArgs e)
        {
            if (ListGallery.Items.Count < 1)
            {
                return;
            }

            if (ListGallery.SelectedItems.Count < 1)
            {
                using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_NONESELECTED, CoreSettings.Default.SelectedLang))
                {
                    Message.StartPosition = FormStartPosition.CenterParent;
                    Message.ShowDialog();
                }
                return;
            }

            using (MyInquiryDialog Message = new MyInquiryDialog(TextVariables.MESG_DELETE + ListGallery.SelectedItems.Count, CoreSettings.Default.SelectedLang))
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
            ClearImageListsSync(ListGallery, ImgListGallery);

            if (!LoadGallery(ACTIVE_PATHS[_gameSelected]))
            {
                ButtonToMainPage3_Click(sender, e);
                return;
            }
        }

        private void ButtonHintFolder_Click(object sender, EventArgs e)
        {
            using (MyMessageDialog Hint = new MyMessageDialog(TextVariables.HINT_GALLERYPAGE, CoreSettings.Default.SelectedLang))
            {
                Hint.StartPosition = FormStartPosition.CenterParent;
                Hint.ShowDialog();
            }
        }

        private void ButtonChooseFolder_Click(object sender, EventArgs e)
        {
            if (_extractFolderPath != "!NONE!")
            {
                ClearImageListsSync(ListExtract, ImgListExtract);
            }

            _cancellationTokenSource?.Cancel();
            string defaultDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            if (!SystemControl.FileControl.Readonly.DirectoryExists(defaultDir))
            {
                defaultDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            using (FolderBrowserDialog FolderChoose = new FolderBrowserDialog()
            {
                SelectedPath = defaultDir,
                Description = TextVariables.TEXT_FOLDEROPEN,
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

            ClearImageListsSync(ListExtract, ImgListExtract);
            _cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = _cancellationTokenSource.Token;
            ExploreDirectory(_extractFolderPath, cancellationToken);
        }
        
        private void ButtonExtractAll_Click(object sender, EventArgs e)
        {
            bool isRepeat = false;
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
                    isRepeat = true;
                    SystemControl.FileControl.CreateDirectory(safePath);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + LARGE_APPEND, safePath + LARGE_APPEND);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + MEDIUM_APPEND, safePath + MEDIUM_APPEND);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + SMALL_APPEND, safePath + SMALL_APPEND);
                    imgCount++;
                }
            }

            if (isRepeat)
            {
                using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_REPEATFOLDER, CoreSettings.Default.SelectedLang))
                {
                    Message.StartPosition = FormStartPosition.CenterParent;
                    Message.ShowDialog();
                }
            }

            if (imgCount > 0)
            {
                using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_SUCCESS + imgCount, CoreSettings.Default.SelectedLang))
                {
                    Message.StartPosition = FormStartPosition.CenterParent;
                    Message.ShowDialog();
                }
            }
        }
        
        private void ButtonExtractSelected_Click(object sender, EventArgs e)
        {
            bool isRepeat = false;
            uint imgCount = 0;

            if (ListExtract.Items.Count < 1)
            {
                return;
            }

            if (ListExtract.SelectedItems.Count < 1)
            {
                using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_NONESELECTEDEXTRACT, CoreSettings.Default.SelectedLang))
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
                    isRepeat = true;
                    SystemControl.FileControl.CreateDirectory(safePath);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + LARGE_APPEND, safePath + LARGE_APPEND);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + MEDIUM_APPEND, safePath + MEDIUM_APPEND);
                    SystemControl.FileControl.CopyFile(ImgListExtract.Images.Keys[item.Index] + SMALL_APPEND, safePath + SMALL_APPEND);
                    imgCount++;
                }
            }

            if (isRepeat)
            {
                using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_REPEATFOLDER, CoreSettings.Default.SelectedLang))
                {
                    Message.StartPosition = FormStartPosition.CenterParent;
                    Message.ShowDialog();
                }
            }

            if (imgCount > 0)
            {
                using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_SUCCESS + imgCount, CoreSettings.Default.SelectedLang))
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
            using (MyMessageDialog Hint = new MyMessageDialog(TextVariables.HINT_EXTRACTPAGE, CoreSettings.Default.SelectedLang))
            {
                Hint.StartPosition = FormStartPosition.CenterParent;
                Hint.ShowDialog();
            }
        }
        
        private void LabelCopyright_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/zeightOFFICIAL/portrait-manager-owlcat");
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
            ButtonValidatePath.Text = TextVariables.BUTTON_VALIDATE;
            ButtonValidatePath.BackColor = Color.Black;
            ButtonValidatePath.ForeColor = Color.White;
            ButtonValidatePath.Enabled = true;
            ButtonApplyChange.Text = TextVariables.BUTTON_APPLY;
            ButtonApplyChange.BackColor = Color.Black;
            ButtonApplyChange.ForeColor = Color.White;
            ButtonApplyChange.Enabled = true;
        }

        private void ButtonValidatePath_Click(object sender, EventArgs e)
        {
            if (ValidatePortraitPath(TextBoxFullPath.Text))
            {
                ButtonValidatePath.Text = TextVariables.BUTTON_OK;
                ButtonValidatePath.ForeColor = Color.White;
                ButtonValidatePath.BackColor = Color.LimeGreen;
                ButtonValidatePath.Enabled = false;
            }
            else
            {
                ButtonValidatePath.Text = TextVariables.BUTTON_NO;
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
                Description = TextVariables.TEXT_PATHOPEN,
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
                ResizeVisibleImagesToWindowSize();
                TextBoxURL.Text = TextVariables.TEXTBOX_URL_INPUT;
                GenerateImageSelectionFlagString(_imageSelectionFlag);
            }
            catch
            {
                TextBoxURL.Text = TextVariables.TEXTBOX_URL_WRONG;
            }

        }
        
        private void ButtonDenyWeb_Click(object sender, EventArgs e)
        {
            RootFunctions.LayoutDisable(LayoutURLDialog);
            RootFunctions.LayoutEnable(LayoutFilePage);
            TextBoxURL.Text = TextVariables.TEXTBOX_URL_INPUT;
            ResizeVisibleImagesToWindowSize();
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
            ReplacePictureBoxImagesToDefault();
            _isAnyLoadedToPortraitPage = false;
            ParentLayoutsDisable();
            System.Diagnostics.Process.Start(LabelDirLoc.Text);
            RootFunctions.LayoutEnable(LayoutMainPage);
            ButtonToMainPageAndFolder.Enabled = true;
        }
        
        private void ButtonNextImageType_Click(object sender, EventArgs e)
        {
            _imageSelectionFlag++;

            if (_imageSelectionFlag == 1)
            {
                ButtonNextImageType.Text = TextVariables.BUTTON_ADVANCED2;
            }
            else
            {
                ButtonNextImageType.Visible = false;
                ButtonNextImageType.Enabled = false;
            }

            GenerateImageSelectionFlagString(_imageSelectionFlag);
            LoadTempImagesToPicBox(_imageSelectionFlag);
            ResizeVisibleImagesToWindowSize();
        }
        
        private void ButtonApplyChange_Click(object sender, EventArgs e)
        {
            if (ButtonValidatePath.Text == TextVariables.BUTTON_OK)
            {
                if (_gameSelected == 'p')
                {
                    CoreSettings.Default.KINGPath = TextBoxFullPath.Text;
                }
                else if (_gameSelected == 'w')
                {
                    CoreSettings.Default.WOTRPath = TextBoxFullPath.Text;
                }
                else if (_gameSelected == 'r')
                {
                    CoreSettings.Default.ROGUEPath = TextBoxFullPath.Text;
                }

                AnyButton_Leave(sender, e);
                ButtonApplyChange.BackColor = Color.LimeGreen;
                ButtonApplyChange.ForeColor = Color.White;
                ButtonApplyChange.Enabled = false;
                ButtonApplyChange.Text = TextVariables.BUTTON_SUCESS;
                CoreSettings.Default.Save();
                AddClickEventsToMainButtons();
                ACTIVE_PATHS[_gameSelected] = TextBoxFullPath.Text;
            }
        }
        
        private void ButtonLoadNormal_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource?.Cancel();
            ClearImageListsSync(ListGallery, ImgListGallery);
            if (!LoadGallery(ACTIVE_PATHS[_gameSelected]))
            {
                ButtonToMainPage3_Click(sender, e);
                return;
            }
        }
        
        private void ButtonLoadCustom_Click(object sender, EventArgs e)
        {
            string fromPath, fromPath2;

            fromPath = Path.Combine(ACTIVE_PATHS[_gameSelected], "..", "Portraits - Npc");
            fromPath2 = Path.Combine(ACTIVE_PATHS[_gameSelected], "..", "Portraits - Army"); 
            _cancellationTokenSource?.Cancel();
            ClearImageListsSync(ListGallery, ImgListGallery);

            if (!LoadGalleryCustom(ACTIVE_PATHS[_gameSelected], true) ||
                !LoadGalleryCustom(fromPath, false) ||
                !LoadGalleryCustom(fromPath2, false))
            {
                ButtonToMainPage3_Click(sender, e);
                return;
            }
        }

        private bool LoadGalleryCustom(string fromRootPath, bool flag = false)
        {
            if (!SystemControl.FileControl.Readonly.DirectoryExists(fromRootPath))
            {
                return false;
            }

            _cancellationTokenSource?.Cancel();
            ClearImageListsSync(ListGallery, ImgListGallery);
            _cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancelToken = _cancellationTokenSource.Token;

            Task.Factory.StartNew(() =>
            {
                RecursiveParsePortraitsFolderAsync(fromRootPath, cancelToken, flag);
            }, cancelToken);

            return true;
        }
        
        private void ButtonLoadCustomNPC_Click(object sender, EventArgs e)
        {
            string fromPath;

            fromPath = Path.Combine(ACTIVE_PATHS[_gameSelected], "..", "Portraits - Npc");
            _cancellationTokenSource?.Cancel();
            ClearImageListsSync(ListGallery, ImgListGallery);
            if (!LoadGalleryCustom(fromPath, false))
            {
                ButtonToMainPage3_Click(sender, e);
                return;
            }
        }
        
        private void ButtonLoadCustomArmy_Click(object sender, EventArgs e)
        {
            string fromPath;

            fromPath = Path.Combine(ACTIVE_PATHS[_gameSelected], "..", "Portraits - Army");
            _cancellationTokenSource?.Cancel();
            ClearImageListsSync(ListGallery, ImgListGallery);
            if (!LoadGalleryCustom(fromPath, false))
            {
                ButtonToMainPage3_Click(sender, e);
                return;
            }
        }
        
        private void PicBoxEng_Click(object sender, EventArgs e)
        {
            FontsInit(_fontCollection);

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-EN");
            CoreSettings.Default.SelectedLang = "en-EN";
            CoreSettings.Default.Save();
            LabelLang.Text = TextVariables.LABEL_LANG + " " + Thread.CurrentThread.CurrentUICulture.ToString();            
            TextsInit();

            PicBoxEng.Enabled = false;
            PicBoxFra.Enabled = true;
            PicBoxGer.Enabled = true;
            PicBoxRus.Enabled = true;
        }
        
        private void PicBoxRus_Click(object sender, EventArgs e)
        {
            FontsInit(_fontCollection, 1);

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ru-RU");
            CoreSettings.Default.SelectedLang = "ru-RU";
            CoreSettings.Default.Save();
            LabelLang.Text = TextVariables.LABEL_LANG + " " + Thread.CurrentThread.CurrentUICulture.ToString();            
            TextsInit();

            PicBoxEng.Enabled = true;
            PicBoxFra.Enabled = true;
            PicBoxGer.Enabled = true;
            PicBoxRus.Enabled = false;
        }
        
        private void PicBoxGer_Click(object sender, EventArgs e)
        {
            FontsInit(_fontCollection);

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
            CoreSettings.Default.SelectedLang = "de-DE";
            CoreSettings.Default.Save();
            LabelLang.Text = TextVariables.LABEL_LANG + " " + Thread.CurrentThread.CurrentUICulture.ToString();            
            TextsInit();

            PicBoxEng.Enabled = true;
            PicBoxFra.Enabled = true;
            PicBoxGer.Enabled = false;
            PicBoxRus.Enabled = true;
        }

        private void PicBoxFra_Click(object sender, EventArgs e)
        {
            FontsInit(_fontCollection);

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("fr-FR");
            CoreSettings.Default.SelectedLang = "fr-FR";
            CoreSettings.Default.Save();
            LabelLang.Text = TextVariables.LABEL_LANG + " " + Thread.CurrentThread.CurrentUICulture.ToString();
            TextsInit();

            PicBoxEng.Enabled = true;
            PicBoxFra.Enabled = false;
            PicBoxGer.Enabled = true;
            PicBoxRus.Enabled = true;
        }

        private void ButtonRT_Click(object sender, EventArgs e)
        {
            _gameSelected = 'r';
            UpdateColorScheme();
            RemoveClickEventsFromCustomPortraitsButtons();

            if (!ValidatePortraitPath(ACTIVE_PATHS[_gameSelected]))
            {
                RemoveClickEventsFromMainButtons();
            }
            else
            {
                AddClickEventsToMainButtons();
            }

            ButtonLoadCustom.Visible = false;
            ButtonLoadCustomNPC.Visible = false;
            ButtonLoadCustomArmy.Visible = false;
            CheckBoxVerified.Checked = false;

            CoreSettings.Default.GameType = _gameSelected;
            CoreSettings.Default.Save();
        }

        private void ButtonKingmaker_Click(object sender, EventArgs e)
        {
            _gameSelected = 'p';
            UpdateColorScheme();

            if (!ValidatePortraitPath(ACTIVE_PATHS[_gameSelected]))
            {
                RemoveClickEventsFromMainButtons();
            }
            else
            {
                AddClickEventsToMainButtons();
            }

            if (!ValidateCustomPath(ACTIVE_PATHS[_gameSelected]) && (UseStamps.Default.isAwareNPC == "NotRevealed" || UseStamps.Default.isAwareNPC == "WorkRevealed"))
            {
                using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_CUSTOMNOTFOUND, CoreSettings.Default.SelectedLang))
                {
                    Message.StartPosition = FormStartPosition.CenterParent;
                    Message.ShowDialog();
                }
                RemoveClickEventsFromCustomPortraitsButtons();
                CheckBoxVerified.Checked = false;
                UseStamps.Default.isAwareNPC = "NotWorkRevealed";
                UseStamps.Default.Save();
                ButtonLoadCustom.Visible = false;
                ButtonLoadCustomNPC.Visible = false;
                ButtonLoadCustomArmy.Visible = false;
            }
            else if (ValidateCustomPath(ACTIVE_PATHS[_gameSelected]) && (UseStamps.Default.isAwareNPC == "NotRevealed" || UseStamps.Default.isAwareNPC == "NotWorkRevealed"))
            {
                using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_CUSTOMFOUND, CoreSettings.Default.SelectedLang))
                {
                    Message.StartPosition = FormStartPosition.CenterParent;
                    Message.ShowDialog();
                }
                AddClickEventsToCustomPortraitsButtons();
                CheckBoxVerified.Checked = true;
                UseStamps.Default.isAwareNPC = "WorkRevealed";
                UseStamps.Default.Save();
                ButtonLoadCustom.Visible = true;
                ButtonLoadCustomNPC.Visible = true;
                ButtonLoadCustomArmy.Visible = true;
            }

            if (UseStamps.Default.isAwareNPC == "WorkRevealed")
            {
                CheckBoxVerified.Checked = true;
            }
            else
            {
                CheckBoxVerified.Checked = false;
            }

            CoreSettings.Default.GameType = _gameSelected;
            CoreSettings.Default.Save();
        }

        private void ButtonWotR_Click(object sender, EventArgs e)
        {
            _gameSelected = 'w';
            UpdateColorScheme();

            if (!ValidatePortraitPath(ACTIVE_PATHS[_gameSelected]))
            {
                RemoveClickEventsFromMainButtons();
            }
            else
            {
                AddClickEventsToMainButtons();
            }

            if (!ValidateCustomPath(ACTIVE_PATHS[_gameSelected]) && (UseStamps.Default.isAwareNPC == "NotRevealed" || UseStamps.Default.isAwareNPC == "WorkRevealed"))
            {
                using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_CUSTOMNOTFOUND, CoreSettings.Default.SelectedLang))
                {
                    Message.StartPosition = FormStartPosition.CenterParent;
                    Message.ShowDialog();
                }
                RemoveClickEventsFromCustomPortraitsButtons();
                CheckBoxVerified.Checked = false;
                UseStamps.Default.isAwareNPC = "NotWorkRevealed";
                UseStamps.Default.Save();
                ButtonLoadCustom.Visible = false;
                ButtonLoadCustomNPC.Visible = false;
                ButtonLoadCustomArmy.Visible = false;
            }
            else if (ValidateCustomPath(ACTIVE_PATHS[_gameSelected]) && (UseStamps.Default.isAwareNPC == "NotRevealed" || UseStamps.Default.isAwareNPC == "NotWorkRevealed"))
            {
                using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_CUSTOMFOUND, CoreSettings.Default.SelectedLang))
                {
                    Message.StartPosition = FormStartPosition.CenterParent;
                    Message.ShowDialog();
                }
                AddClickEventsToCustomPortraitsButtons();
                CheckBoxVerified.Checked = true;
                UseStamps.Default.isAwareNPC = "WorkRevealed";
                UseStamps.Default.Save();
                ButtonLoadCustom.Visible = true;
                ButtonLoadCustomNPC.Visible = true;
                ButtonLoadCustomArmy.Visible = true;
            }

            if (UseStamps.Default.isAwareNPC == "WorkRevealed")
            {
                CheckBoxVerified.Checked = true;
            }
            else
            {
                CheckBoxVerified.Checked = false;
            }
        }
    
    }
}