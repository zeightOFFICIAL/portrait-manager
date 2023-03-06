using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.Win32;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace PathfinderPortraitManager
{
    public partial class MainForm : Form
    {
        private void PicPortraitTemp_DragDrop(object sender, DragEventArgs e)
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
            if (fullPath == "-1")
            {
                if (_isLoaded == true)
                {
                    LoadAllImages();
                    return;
                }
                _isLoaded = false;
            }
            else
            {
                _isLoaded = true;
            }
            ClearImages(PathfinderPortraitManager.Properties.Resources.placeholder_wotr);
            SystemControl.FileControl.CreateTemp(fullPath, RELATIVEPATH_TO_TEMPFULL, RELATIVEPATH_TO_TEMPPOOR);
            LoadAllImages();
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
            string fullPath = SystemControl.FileControl.OpenFile();
            if (fullPath == "-1")
            {
                if (_isLoaded == true)
                {
                    LoadAllImages();
                    return;
                }
                _isLoaded = false;
            }
            else
            {
                _isLoaded = true;
            }
            ClearImages(PathfinderPortraitManager.Properties.Resources.placeholder_wotr);
            SystemControl.FileControl.CreateTemp(fullPath, RELATIVEPATH_TO_TEMPFULL, RELATIVEPATH_TO_TEMPPOOR);
            LoadAllImages();
        }
        private void ButtonLocalPortraitLoad_Click(object sender, EventArgs e)
        {
            string fullPath = SystemControl.FileControl.OpenFile();
            if (fullPath == "-1")
            {
                if (_isLoaded == true)
                {
                    LoadAllImages();
                    return;
                }
                _isLoaded = false;
            }
            else
            {
                _isLoaded = true;
            }
            ClearImages(PathfinderPortraitManager.Properties.Resources.placeholder_wotr);
            SystemControl.FileControl.CreateTemp(fullPath, RELATIVEPATH_TO_TEMPFULL, RELATIVEPATH_TO_TEMPPOOR);
            LoadAllImages();
        }
        private void PicPortraitLrg_MouseDown(object sender, MouseEventArgs e)
        {
            PanelPortraitLrg.VerticalScroll.Visible = false;
            PanelPortraitLrg.HorizontalScroll.Visible = false;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
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
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
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
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
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
                ImageControl.Direct.Zoom(PicPortraitLrg, PanelPortraitLrg, e, RELATIVEPATH_TO_TEMPPOOR, aspectRatio, factor);
            }
            else
            {
                factor = -PicPortraitLrg.Width * 1.0f / 8;
                ImageControl.Direct.Zoom(PicPortraitLrg, PanelPortraitLrg, e, RELATIVEPATH_TO_TEMPPOOR, aspectRatio, factor);
            }
        }
        private void PicPortraitMed_MouseWheel(object sender, MouseEventArgs e)
        {
            float aspectRatio = (PicPortraitMed.Width * 1.0f / PicPortraitMed.Height * 1.0f),
                  factor;
            if (e.Delta > 0)
            {
                factor = PicPortraitMed.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitMed, PanelPortraitMed, e, RELATIVEPATH_TO_TEMPPOOR, aspectRatio, factor);
            }
            else
            {
                factor = -PicPortraitMed.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitMed, PanelPortraitMed, e, RELATIVEPATH_TO_TEMPPOOR, aspectRatio, factor);
            }
        }
        private void PicPortraitSml_MouseWheel(object sender, MouseEventArgs e)
        {
            float aspectRatio = (PicPortraitSml.Width * 1.0f / PicPortraitSml.Height * 1.0f),
                  factor;
            if (e.Delta > 0)
            {
                factor = PicPortraitSml.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitSml, PanelPortraitSml, e, RELATIVEPATH_TO_TEMPPOOR, aspectRatio, factor);
            }
            else
            {
                factor = -PicPortraitSml.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitSml, PanelPortraitSml, e, RELATIVEPATH_TO_TEMPPOOR, aspectRatio, factor);
            }
        }
        private void MainForm_Closed(object sender, FormClosedEventArgs e)
        {
            DisposeImages();
            SystemControl.FileControl.TempClear();
            Application.Exit();
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
            ResizeAllImagesAsWindow();
        }
        private void ButtonCreatePortrait_Click(object sender, EventArgs e)
        {
            string exodusPath, fullExodusPath;
            exodusPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow") +
                         "\\Owlcat Games\\Pathfinder Kingmaker\\Portraits";
            fullExodusPath = "";
            if (!SystemControl.FileControl.DirExists(exodusPath))
            {
                using (Forms.MyMessageDialog MyMessageDialog = new Forms.MyMessageDialog("Pathfinder: Kingmaker portraits folder was not found!"))
                {
                    MyMessageDialog.ShowDialog();
                }
                return;
            }
            bool placeFound = false;
            uint localName = 1000;
            while (placeFound == false)
            {
                fullExodusPath = exodusPath + "\\" + Convert.ToString(localName);
                if (!Directory.Exists(fullExodusPath))
                {
                    Directory.CreateDirectory(fullExodusPath);
                    ImageControl.Wraps.CropImage(PicPortraitLrg, PanelPortraitLrg, RELATIVEPATH_TO_TEMPFULL,
                                                 fullExodusPath + LARGE_EXTENRSION,
                                                 ASPECT_RATIO_LARGE, 692, 1024);
                    ImageControl.Wraps.CropImage(PicPortraitMed, PanelPortraitMed, RELATIVEPATH_TO_TEMPFULL,
                                                 fullExodusPath + MEDIUM_EXTENSION,
                                                 ASPECT_RATIO_MED, 330, 432);
                    ImageControl.Wraps.CropImage(PicPortraitSml, PanelPortraitSml, RELATIVEPATH_TO_TEMPFULL,
                                                 fullExodusPath + SMALL_EXTENSION,
                                                 ASPECT_RATIO_SMALL, 185, 242);
                    placeFound = true;
                }
                localName++;
            }
            if (CheckExistence(fullExodusPath))
            {
                using (Forms.FinalDialog FinalDialog = new Forms.FinalDialog())
                {
                    FinalDialog.ShowDialog();
                    if (FinalDialog.State == 1)
                    {
                        ClearImages(PathfinderPortraitManager.Properties.Resources.placeholder_wotr);
                        _isLoaded = false;
                        AllToNotEnabled();
                        ThisToEnabled(LayoutMainPage);
                    }
                    else if (FinalDialog.State == 2)
                    {
                        ClearImages(PathfinderPortraitManager.Properties.Resources.placeholder_wotr);
                        _isLoaded = false;
                        SystemControl.FileControl.CreateTemp("-1", RELATIVEPATH_TO_TEMPFULL, RELATIVEPATH_TO_TEMPPOOR);
                        LoadAllImages();
                        AllToNotEnabled();
                        ThisToEnabled(LayoutFilePage);
                        ResizeAllImagesAsWindow();
                    }
                    else if (FinalDialog.State == 3)
                    {
                        ClearImages(PathfinderPortraitManager.Properties.Resources.placeholder_wotr);
                        _isLoaded = false;
                        AllToNotEnabled();
                        System.Diagnostics.Process.Start(fullExodusPath);
                        ThisToEnabled(LayoutMainPage);
                    }
                }
            }
            else
            {
                using (Forms.MyMessageDialog MyMessageDialog = new Forms.MyMessageDialog("Program was unable to load any images into portraits folder!"))
                {
                    MyMessageDialog.ShowDialog();
                }
                return;
            }
        }
        private void PicPortraitMed_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            using (Image img = new Bitmap(RELATIVEPATH_TO_TEMPPOOR))
                ResizeImageAsWindow(PicPortraitMed, img, PanelPortraitMed);
        }
        private void PicPortraitLrg_MouseDoubleClick(object sedner, MouseEventArgs e)
        {
            using (Image img = new Bitmap(RELATIVEPATH_TO_TEMPPOOR))
                ResizeImageAsWindow(PicPortraitLrg, img, PanelPortraitLrg);
        }
        private void PicPortraitSml_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            using (Image img = new Bitmap(RELATIVEPATH_TO_TEMPPOOR))
                ResizeImageAsWindow(PicPortraitSml, img, PanelPortraitSml);
        }
        private void LblUnnamed1_MouseHover(object sender, EventArgs e)
        {
            LabelUnnamed1.Text = "Stats portrait";
            //LabelUnnamed1.Font = _smlFont;
        }
        private void LblUnnamed2_MouseHover(object sender, EventArgs e)
        {
            LabelUnnamed2.Text = "Character portrait";
            //LabelUnnamed2.Font = _smlFont;
        }
        private void LblUnnamed3_MouseHover(object sender, EventArgs e)
        {
            LabelUnnamed3.Text = "Gameplay portrait";
            //LabelUnnamed3.Font = _smlFont;
        }
        private void LblUnnamed1_MouseLeave(object sender, EventArgs e)
        {
            LabelUnnamed1.Text = "Medium";
            //LabelUnnamed1.Font = _lrgFont;
        }
        private void LblUnnamed2_MouseLeave(object sender, EventArgs e)
        {
            LabelUnnamed2.Text = "Large";
            //LabelUnnamed2.Font = _lrgFont;
        }
        private void LblUnnamed3_MouseLeave(object sender, EventArgs e)
        {
            LabelUnnamed3.Text = "Small";
            //LabelUnnamed3.Font = _lrgFont;
        }
        private void ButtonWebPortraitLoad_Click(object sender, EventArgs e)
        {
            using (Forms.UrlDialog UrlDialog = new Forms.UrlDialog())
            {
                UrlDialog.ShowDialog();
                if (UrlDialog.URL != "-1" && UrlDialog.URL != "-2")
                {
                    try
                    {
                        var request = System.Net.WebRequest.Create(UrlDialog.URL);
                        using (var response = request.GetResponse())
                        using (var stream = response.GetResponseStream())
                        {
                            using (Image webImage = Bitmap.FromStream(stream))
                            {
                                if (!Directory.Exists("temp/"))
                                    Directory.CreateDirectory("temp/");
                                webImage.Save(RELATIVEPATH_TO_TEMPFULL);
                                ImageControl.Wraps.CreatePoorImage(webImage, RELATIVEPATH_TO_TEMPPOOR);
                                _isLoaded = true;
                                ClearImages(PathfinderPortraitManager.Properties.Resources.placeholder_wotr);
                                LoadAllImages();
                            }
                        }
                    }
                    catch
                    {
                        using (Forms.MyMessageDialog MyMessageDialog = new Forms.MyMessageDialog("Error during fetching image!"))
                        {
                            MyMessageDialog.ShowDialog();
                        }
                        UrlDialog.URL = "-1";
                    }
                }
            }
        }
        private void ButtonHintOnScalePage_Click(object sender, EventArgs e)
        {
            using (Forms.MyHintDialog ScalingHint = new Forms.MyHintDialog("This is a scaling page. Here you can adjust the " +
                         "portrait as you see fit. Click and drag to move cropping rectangle. " +
                         "Use mouse wheel to zoom in and out. Double-click on portrait to " +
                         "restore it to original state. Use \"Create\" button to generate " +
                         "portrait and \"Back\" to return to image page."))
            {
                ScalingHint.ShowDialog();
            }
        }
        private void ButtonHintOnFilePage_Click(object sender, EventArgs e)
        {
            using (Forms.MyHintDialog FileHint = new Forms.MyHintDialog("This is an image page. Here you can choose " +
                    "whatever picture you want for your portrait. Local and web-stored images can be loaded. Press " +
                    "\"local image\", click on portrait, or simply drag and drop to load local image. Press " +
                    "\"web image\" to fetch image from web. Then press \"next\" to begin scaling or \"back\" " +
                    "to return to main page."))
            {
                FileHint.ShowDialog();
            }
        }
        private void ButtonFolderChoose_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog CommonOpenFileDialog = new CommonOpenFileDialog();
            CommonOpenFileDialog.InitialDirectory = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "{374DE290-123F-4565-9164-39C4925E467B}", String.Empty).ToString();
            CommonOpenFileDialog.IsFolderPicker = true;
            if (CommonOpenFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                MessageBox.Show("You selected " + ExploreDirectory(CommonOpenFileDialog.FileName));
            }
        }
        private void ButtonFolderExtract_Click(object sender, EventArgs e)
        {

        }
        private void ButtonToMainPage2_Click(object sender, EventArgs e)
        {
            AllToNotEnabled();
            ThisToEnabled(LayoutMainPage);
        }
        private void ButtonHintOnExtractPage_Click(object sender, EventArgs e)
        {
            using (Forms.MyHintDialog FileHint = new Forms.MyHintDialog("This is an image page. Here you can choose " +
                    "whatever picture you want for your portrait. Local and web-stored images can be loaded. Press " +
                    "\"local image\", click on portrait, or simply drag and drop to load local image. Press " +
                    "\"web image\" to fetch image from web. Then press \"next\" to begin scaling or \"back\" " +
                    "to return to main page."))
            {
                FileHint.ShowDialog();
            }
        }

        private void PicTitle_Click(object sender, EventArgs e)
        {
            if (_gameSelected == true)
            {
                _gameSelected = false;
                Color fcolor = Color.DeepPink;
                Color bcolor = Color.FromArgb(20, 6, 30);
                PicTitle.BackgroundImage.Dispose();
                PicTitle.BackgroundImage = PathfinderPortraitManager.Properties.Resources.title_wotr;
                this.Icon = PathfinderPortraitManager.Properties.Resources.icon_wotr;

                foreach (Control ctrl in this.Controls)
                {
                    UpdateColorSchemeOnForm(ctrl, fcolor, bcolor);
                }

                using (Bitmap placeholder = new Bitmap(PathfinderPortraitManager.Properties.Resources.placeholder_wotr))
                {
                    ImageControl.Utils.Replace(PicPortraitTemp, placeholder);
                }
            }
            else
            {
                _gameSelected = true;
                Color fcolor = Color.Goldenrod;
                Color bcolor = Color.FromArgb(9, 28, 11);
                PicTitle.BackgroundImage.Dispose();
                PicTitle.BackgroundImage = PathfinderPortraitManager.Properties.Resources.title_path;
                this.Icon = PathfinderPortraitManager.Properties.Resources.icon_path;

                foreach (Control ctrl in this.Controls)
                {
                    UpdateColorSchemeOnForm(ctrl, fcolor, bcolor);
                }
                using (Bitmap placeholder = new Bitmap(PathfinderPortraitManager.Properties.Resources.placeholder_path))
                {
                    ImageControl.Utils.Replace(PicPortraitTemp, placeholder);
                }
            }
        }
    }
}