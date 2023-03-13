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
        private void PicPortraitTemp_DragDrop(object sender, DragEventArgs e)
        {
            string fullPath = CheckDragDropFile(e);
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
            ClearGallery();
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
                using (Forms.MyMessageDialog MesgNotFound = new Forms.MyMessageDialog(Properties.TextVariables.mesgNotFound))
                {
                    MesgNotFound.ShowDialog();
                }
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
                using (Forms.FinalDialog finalDialog = new Forms.FinalDialog())
                {
                    finalDialog.ShowDialog();
                    if (finalDialog.State == 1)
                    {
                        ClearTempImages();
                        _isNewLoaded = false;
                        ParentLayoutsHide();
                        LayoutReveal(LayoutMainPage);
                    }
                    else if (finalDialog.State == 2)
                    {
                        ClearTempImages();
                        _isNewLoaded = false;
                        SystemControl.FileControl.TempImagesCreate("-1", RELATIVEPATH_TEMPFULL, RELATIVEPATH_TEMPPOOR, DEFAULT_DICT[_gameSelected]);
                        LoadAllTempImages();
                        ParentLayoutsHide();
                        LayoutReveal(LayoutFilePage);
                        ResizeVisibleImagesToWindow();
                    }
                    else if (finalDialog.State == 3)
                    {
                        ClearTempImages();
                        _isNewLoaded = false;
                        ParentLayoutsHide();
                        System.Diagnostics.Process.Start(fullPath);
                        LayoutReveal(LayoutMainPage);
                    }
                }
            }
            else
            {
                using (Forms.MyMessageDialog MesgNotLoaded = new Forms.MyMessageDialog(Properties.TextVariables.mesgNotLoaded))
                {
                    MesgNotLoaded.ShowDialog();
                }
                return;
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
        private void LblUnnamed1_MouseHover(object sender, EventArgs e)
        {
            LabelUnnamed1.Text = Properties.TextVariables.statsPortrait;
        }
        private void LblUnnamed2_MouseHover(object sender, EventArgs e)
        {
            LabelUnnamed2.Text = Properties.TextVariables.charPortrait;
        }
        private void LblUnnamed3_MouseHover(object sender, EventArgs e)
        {
            LabelUnnamed3.Text = Properties.TextVariables.gamePortrait;
        }
        private void LblUnnamed1_MouseLeave(object sender, EventArgs e)
        {
            LabelUnnamed1.Text = Properties.TextVariables.medPortrait;
        }
        private void LblUnnamed2_MouseLeave(object sender, EventArgs e)
        {
            LabelUnnamed2.Text = Properties.TextVariables.lrgPortrait;
        }
        private void LblUnnamed3_MouseLeave(object sender, EventArgs e)
        {
            LabelUnnamed3.Text = Properties.TextVariables.smlPortrait;
        }
        private void ButtonWebPortraitLoad_Click(object sender, EventArgs e)
        {
            using (Forms.URLDialog DialUrl = new Forms.URLDialog())
            {
                ParentLayoutsHide();
                Color prevColor = ActiveForm.BackColor;
                BackColor = Color.Black;
                DialUrl.ShowDialog();
                if (DialUrl.URL != "-1" && DialUrl.URL != "-2")
                {
                    try
                    {
                        var request = System.Net.WebRequest.Create(DialUrl.URL);
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
                        using (Forms.MyMessageDialog MesgCannotLoad = new Forms.MyMessageDialog(Properties.TextVariables.mesgCannotLoad))
                        {
                            MesgCannotLoad.ShowDialog();
                        }
                        DialUrl.URL = "-1";
                    }
                }
                BackColor = prevColor;
                LayoutReveal(LayoutFilePage);
                ResizeVisibleImagesToWindow();
            }
        }
        private void ButtonHintOnScalePage_Click(object sender, EventArgs e)
        {
            using (Forms.MyHintDialog HintScalingPage = new Forms.MyHintDialog(Properties.TextVariables.hintScalingPage))
            {
                HintScalingPage.ShowDialog();
            }
        }
        private void ButtonHintOnFilePage_Click(object sender, EventArgs e)
        {
            using (Forms.MyHintDialog HintFilePage = new Forms.MyHintDialog(Properties.TextVariables.hintFilePage))
            {
                HintFilePage.ShowDialog();
            }
        }
        private void ButtonFolderChoose_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog CommonOpenFileDialog = new CommonOpenFileDialog();
            CommonOpenFileDialog.InitialDirectory = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "{374DE290-123F-4565-9164-39C4925E467B}", String.Empty).ToString();
            CommonOpenFileDialog.IsFolderPicker = true;
            if (CommonOpenFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                MessageBox.Show("DEBUG " + ExploreDirectory(CommonOpenFileDialog.FileName));
            }
        }
        private void ButtonFolderExtract_Click(object sender, EventArgs e)
        {

        }
        private void ButtonHintOnExtractPage_Click(object sender, EventArgs e)
        {
            using (Forms.MyHintDialog HintExtractPage = new Forms.MyHintDialog(Properties.TextVariables.hintExtractPage))
            {
                HintExtractPage.ShowDialog();
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
            }
        }
        private void ButtonOpenFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(DIR_DICT[_gameSelected]);
        }
        private void ButtonChange_Click(object sender, EventArgs e)
        {
            if (ListGallery.Items.Count < 1)
            {
                return;
            }
            ListViewItem item = ListGallery.SelectedItems[0];
            string folderPath = DIR_DICT[_gameSelected] + "\\" + item.Text + "\\Fulllength.png";
            using (Forms.MyHintDialog FileHint = new Forms.MyHintDialog(folderPath))
            {
                FileHint.ShowDialog();
            }
            ListGallery.Items.RemoveByKey(item.Text);
            ImgListGallery.Images.RemoveByKey(item.Text);
            ButtonToMainPage3_Click(sender, e);
            ButtonToFilePage_Click(sender, e);
            _isNewLoaded = true;
            SafeCopyAllImages(folderPath);
            LoadAllTempImages();
            SystemControl.FileControl.DirectoryDeleteRecursive(DIR_DICT[_gameSelected] + "\\" + item.Text);
            item.Remove();
        }
        private void ButtonDeletePortait_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in ListGallery.SelectedItems)
            {
                string folderPath = DIR_DICT[_gameSelected] + "\\" + item.Text + "\\";
                using (Forms.MyHintDialog ScalingHint = new Forms.MyHintDialog(folderPath + " " + item.Text))
                {
                    ScalingHint.ShowDialog();
                }
                ListGallery.Items.RemoveByKey(item.Text);
                ImgListGallery.Images.RemoveByKey(item.Text);
                item.Remove();
                SystemControl.FileControl.DirectoryDeleteRecursive(folderPath);
            }
        }
        private void ButtonHintFolder_Click(object sender, EventArgs e)
        {
            using (Forms.MyHintDialog HintFolderPage = new Forms.MyHintDialog(Properties.TextVariables.hintFolderPage))
            {
                HintFolderPage.ShowDialog();
            }
        }
    }
}