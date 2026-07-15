/*    
    Zeight Portrait Manager
    Desktop application for managing in-game portraits for games from Owlcat Games, 
    Obsidian Entertainment and inXile Entertainment. 
    Including: 
        1. Pathfinder: Kingmaker,
        2. Pathfinder: Wrath of the Righteous, 
        3. Warhammer 40000: Rogue Trader,
        4. Pillars of Eternity, 
        5. Pillars of Eternity: Deadfire, 
        6. Tyranny,
        7. Wasteland 3.
    Copyright (C) 2024 Artemii "Zeight" Saganenko.

    GPL-2.0 license terms are listed in LICENSE.md file.
    License header for this project is listed in Program.cs.
*/

using PortraitManager.forms;
using PortraitManager.Properties;

using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using SharpCompress.Archives;
using SharpCompress.Common;

namespace PortraitManager
{
    public partial class MainForm : Form
    {
        public void RestoreFilePageToInit()
        {
            _imageSelectionFlag = 0;
            _isAnyLoadedToPortraitPage = false;
        }


        public void ParentLayoutsDisable()
        {
            RootFunctions.LayoutDisable(LayoutMainPage);
            RootFunctions.LayoutDisable(LayoutExtractPage);
            RootFunctions.LayoutDisable(LayoutGalleryPage);
            RootFunctions.LayoutDisable(LayoutStartMenu);
            RootFunctions.LayoutDisable(LayoutPathPage);
            RootFunctions.LayoutDisable(LayoutKingCreatePortrait);
        }
        
        public void ParentLayoutsSetDockFill()
        {
            foreach (Control control in Controls)
            {
                RootFunctions.LayoutsSetDockFill(control);
            }
        }
        
        class RootFunctions
        {
            static public void AddClickEvent(object sender, EventHandler handler)
            {
                if (sender is Button button)
                {

                    if (button != null)
                    {
                        button.Click -= handler;
                        button.Click += handler;
                    }

                }
            }
            
            static public void RemoveClickEvent(object sender, EventHandler handler)
            {
                if (sender is Button button)
                {

                    if (button != null)
                    {
                        button.Click -= handler;
                    }

                }
            }

            static public void LayoutEnable(TableLayoutPanel table)
            {
                if (table.Visible == false && table.Enabled == false)
                {
                    table.Visible = true;
                    table.Enabled = true;
                }
            }
            
            static public void LayoutDisable(TableLayoutPanel table)
            {
                if (table.Visible == true && table.Enabled == true)
                {
                    table.Visible = false;
                    table.Enabled = false;
                }
            }
            
            static public void LayoutsSetDockFill(Control control)
            {
                if (control is TableLayoutPanel)
                {
                    control.Dock = DockStyle.Fill;
                }

                foreach (Control subCtrl in control.Controls)
                {
                    LayoutsSetDockFill(subCtrl);
                }
            }
            
            static public void HideScrollBar(Control control)
            {
                if (control is Panel panel)
                {

                    if (panel != null)
                    {
                        panel.VerticalScroll.Visible = false;
                        panel.HorizontalScroll.Visible = false;
                        panel.AutoScroll = false;
                    }

                }
            }
        }
        
        public void LoadAllTempImagesToPicBox()
        {
            LoadTempImagesToPicBox(200);
        }
        
        public void LoadTempImagesToPicBox(ushort selectionFlag)
        {
            //if (selectionFlag == 0 || selectionFlag == 100)
            //{
            //    using (Image img = new Bitmap(TEMP_LARGE_APPEND))
            //        ImageControl.Utils.Replace(PicPortraitTemp, new Bitmap(img));
            //}
            //else if (selectionFlag == 1)
            //{
            //    using (Image img = new Bitmap(TEMP_MEDIUM_APPEND))
            //        ImageControl.Utils.Replace(PicPortraitTemp, new Bitmap(img));
            //}
            //else if (selectionFlag == 2)
            //{
            //    using (Image img = new Bitmap(TEMP_SMALL_APPEND))
            //        ImageControl.Utils.Replace(PicPortraitTemp, new Bitmap(img));
            //}
            //else if (selectionFlag == 200)
            //{
            //    using (Image img = new Bitmap(TEMP_SMALL_APPEND))
            //        ImageControl.Utils.Replace(PicPortraitSml, new Bitmap(img));
            //    using (Image img = new Bitmap(TEMP_MEDIUM_APPEND))
            //        ImageControl.Utils.Replace(PicPortraitMed, new Bitmap(img));
            //    using (Image img = new Bitmap(TEMP_LARGE_APPEND))
            //        ImageControl.Utils.Replace(PicPortraitLrg, new Bitmap(img));
            //    DisableAutoScroll(PanelPortraitLrg, PicPortraitLrg.Height, PicPortraitLrg.Width);
            //    DisableAutoScroll(PanelPortraitMed, PicPortraitLrg.Height, PicPortraitLrg.Width);
            //    DisableAutoScroll(PanelPortraitSml, PicPortraitLrg.Height, PicPortraitLrg.Width);
            //}
        }
        
        public static void DisableAutoScroll(Control control, int xMax, int yMax)
        {
            if (control is Panel panel)
            {
                panel.AutoScroll = false;
                panel.VerticalScroll.Minimum = 0;
                panel.HorizontalScroll.Minimum = 0;
                panel.VerticalScroll.Maximum = xMax;
                panel.HorizontalScroll.Maximum = yMax;
                panel.VerticalScroll.Visible = true;
                panel.HorizontalScroll.Visible = true;
            }
        }
        
        public static bool CheckPortraitExistence(string path)
        {
            //if (SystemControl.FileControl.Readonly.DirectoryExists(path))

            //    if (SystemControl.FileControl.Readonly.FileExist(path + LARGE_APPEND) &&
            //        SystemControl.FileControl.Readonly.FileExist(path + MEDIUM_APPEND) &&
            //        SystemControl.FileControl.Readonly.FileExist(path + SMALL_APPEND))

            //        if (SystemControl.FileControl.Readonly.GetFileExtension(path + LARGE_APPEND) == ".png" &&
            //            SystemControl.FileControl.Readonly.GetFileExtension(path + MEDIUM_APPEND) == ".png" &&
            //            SystemControl.FileControl.Readonly.GetFileExtension(path + SMALL_APPEND) == ".png")
            //            return true;

            //        else
            //            return false;
            //    else
            //        return false;
            //else
            //    return false;
            return false;
        }
        
        public static bool CheckPortraitExistenceClipped(string path)
        {
            //if (SystemControl.FileControl.Readonly.DirectoryExists(path))

            //    if (SystemControl.FileControl.Readonly.FileExist(path + MEDIUM_APPEND) &&
            //        SystemControl.FileControl.Readonly.FileExist(path + SMALL_APPEND))

            //        if (SystemControl.FileControl.Readonly.GetFileExtension(path + MEDIUM_APPEND) == ".png" &&
            //            SystemControl.FileControl.Readonly.GetFileExtension(path + SMALL_APPEND) == ".png")
            //            return true;

            //        else
            //            return false;
            //    else
            //        return false;
            //else
            //    return false;
            return false;
        }
        
        private void RecursiveParsePortraitsDirectoryAsync(string path, CancellationToken cancelToken)
        {
            if (cancelToken.IsCancellationRequested)
            {
                Invoke((MethodInvoker)delegate
                {
                    //ClearImageListsSync(ListExtract, ImgListExtract);
                });

                return;
            }

            if (CheckPortraitExistence(path))
            {
                //if (SystemControl.FileControl.Readonly.CheckImagePixeling(path + LARGE_APPEND, 
                //    GAME_TYPES[_gameSelected].GetLargeWidth(), GAME_TYPES[_gameSelected].GetLargeHeight()) &&
                //    SystemControl.FileControl.Readonly.CheckImagePixeling(path + MEDIUM_APPEND, 
                //    GAME_TYPES[_gameSelected].GetMediumWidth(), GAME_TYPES[_gameSelected].GetMediumHeight()) &&
                //    SystemControl.FileControl.Readonly.CheckImagePixeling(path + SMALL_APPEND, 
                //    GAME_TYPES[_gameSelected].GetSmallWidth(), GAME_TYPES[_gameSelected].GetSmallHeight()))
                //{
                //    try
                //    {
                //        using (Image img = new Bitmap(path + "\\Fulllength.png"))
                //        {
                //            ListViewItem item = new ListViewItem
                //            {
                //                Text = path.Split('\\').Last(),
                //                ImageIndex = ListExtract.Items.Count,
                //                Tag = path
                //            };
                //            Invoke((MethodInvoker)delegate
                //            {
                //                ImgListExtract.Images.Add(path, img);
                //                ListExtract.Items.Add(item);
                //                ButtonExtractAll.Enabled = true;
                //                ButtonExtractSelected.Enabled = true;
                //                ButtonOpenFolders.Enabled = true;
                //            });
                //        }
                //    }
                //    catch
                //    {
                //        return;
                //    }
                //}
            }

            string[] subDirs = Directory.GetDirectories(path);
            foreach (string subDir in subDirs)
            {
                RecursiveParsePortraitsDirectoryAsync(subDir, cancelToken);
            }
        }
        
        public void ExploreDirectory(string path, CancellationToken cancelToken)
        {                
            Task.Factory.StartNew(() =>
            {
                RecursiveParsePortraitsDirectoryAsync(path, cancelToken);
            }, cancelToken);
        }
        

        
        public void UpdateObjectColoringInDepth(Control ctrl, Color a, Color b)
        {
            //if (ctrl is PictureBox || ctrl.Equals(LayoutURLDialog)
                                   //|| ctrl.Equals(LayoutFinalPage)
                                   //|| ctrl.Equals(LayoutSettingsPage)
                                   //|| ctrl.Equals(LayoutLang)
                                   //|| ctrl.Equals(LayoutStartMenu))
            {
                return;
            }

            //if (ctrl.Equals(LabelCopyright) || ctrl.Equals(LabelVersion) ||
            //    ctrl.Equals(LblPointerToFilePage) ||
            //    ctrl.Equals(LblPointerToGalleryPage))
            //{
            //    ctrl.ForeColor = a;
            //    return;
            //}

            ctrl.ForeColor = a;
            ctrl.BackColor = b;
            ctrl.TabStop = false;
            ctrl.TabIndex = 1;
            ctrl.PreviewKeyDown += new PreviewKeyDownEventHandler(Ctrl_PreviewKeyDown);

            foreach (Control subCtrl in ctrl.Controls)
            {
                UpdateObjectColoringInDepth(subCtrl, a, b);
            }
        }
        
        public void ReplacePictureBoxImagesToDefault()
        {
            // Apply "cover" scaling to portrait picture boxes so one dimension matches the
            // PictureBox and the other is >= PictureBox (can be cropped). This centers the
            // image and allows later zoom/pan logic to operate on the original image.
            try
            {
                // Large
                if (PicKingLrg != null && PicKingLrg.Image != null)
                {
                    // preserve original copy for zoom operations
                    if (_originalImageLrg == null)
                        _originalImageLrg = new Bitmap(PicKingLrg.Image);

                    var scaled = ResizeImageCover(_originalImageLrg, PicKingLrg.Width, PicKingLrg.Height);
                    // use Normal mode and set control size to match rendered image so drag/zoom
                    // logic (which uses PictureBox.Width/Height as image size) stays correct
                    PicKingLrg.Dock = DockStyle.None;
                    PicKingLrg.SizeMode = PictureBoxSizeMode.Normal;
                    PicKingLrg.Size = new Size(scaled.Width, scaled.Height);
                    // dispose previous displayed image if it is not the original reference
                    if (PicKingLrg.Image != null && !object.ReferenceEquals(PicKingLrg.Image, _originalImageLrg))
                    {
                        try { PicKingLrg.Image.Dispose(); } catch { }
                    }
                    PicKingLrg.Image = scaled;
                }

                // Medium
                if (PicKingMed != null && PicKingMed.Image != null)
                {
                    if (_originalImageMed == null)
                        _originalImageMed = new Bitmap(PicKingMed.Image);

                    var scaled = ResizeImageCover(_originalImageMed, PicKingMed.Width, PicKingMed.Height);
                    PicKingMed.Dock = DockStyle.None;
                    PicKingMed.SizeMode = PictureBoxSizeMode.Normal;
                    PicKingMed.Size = new Size(scaled.Width, scaled.Height);
                    if (PicKingMed.Image != null && !object.ReferenceEquals(PicKingMed.Image, _originalImageMed))
                    {
                        try { PicKingMed.Image.Dispose(); } catch { }
                    }
                    PicKingMed.Image = scaled;
                }

                // Small
                if (PicKingSml != null && PicKingSml.Image != null)
                {
                    if (_originalImageSml == null)
                        _originalImageSml = new Bitmap(PicKingSml.Image);

                    var scaled = ResizeImageCover(_originalImageSml, PicKingSml.Width, PicKingSml.Height);
                    PicKingSml.Dock = DockStyle.None;
                    PicKingSml.SizeMode = PictureBoxSizeMode.Normal;
                    PicKingSml.Size = new Size(scaled.Width, scaled.Height);
                    if (PicKingSml.Image != null && !object.ReferenceEquals(PicKingSml.Image, _originalImageSml))
                    {
                        try { PicKingSml.Image.Dispose(); } catch { }
                    }
                    PicKingSml.Image = scaled;
                }

                // Sml2
                if (PicKingSml2 != null && PicKingSml2.Image != null)
                {
                    if (_originalImageSml2 == null)
                        _originalImageSml2 = new Bitmap(PicKingSml2.Image);

                    var scaled = ResizeImageCover(_originalImageSml2, PicKingSml2.Width, PicKingSml2.Height);
                    PicKingSml2.Dock = DockStyle.None;
                    PicKingSml2.SizeMode = PictureBoxSizeMode.Normal;
                    PicKingSml2.Size = new Size(scaled.Width, scaled.Height);
                    if (PicKingSml2.Image != null && !object.ReferenceEquals(PicKingSml2.Image, _originalImageSml2))
                    {
                        try { PicKingSml2.Image.Dispose(); } catch { }
                    }
                    PicKingSml2.Image = scaled;
                }
            }
            catch
            {
                // silently ignore failures during UI default replacement
            }
        }

        private Image ResizeImageCover(Image src, int boxWidth, int boxHeight)
        {
            if (src == null || boxWidth <= 0 || boxHeight <= 0)
                return src == null ? null : new Bitmap(src);

            float scaleX = (float)boxWidth / src.Width;
            float scaleY = (float)boxHeight / src.Height;
            // cover: pick the larger scale so the image fills the box and overflows one axis
            float scale = Math.Max(scaleX, scaleY);

            int newW = Math.Max(1, (int)Math.Ceiling(src.Width * scale));
            int newH = Math.Max(1, (int)Math.Ceiling(src.Height * scale));

            Bitmap dest = new Bitmap(newW, newH);
            dest.SetResolution(src.HorizontalResolution, src.VerticalResolution);

            using (Graphics g = Graphics.FromImage(dest))
            {
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                g.Clear(Color.Transparent);
                g.DrawImage(src, 0, 0, newW, newH);
            }

            return dest;
        }
        
        public static void CreateAllImagesInTemp(string newImagePath, ushort flag)
        {
            //using (Image placeholder = new Bitmap(GAME_TYPES[_gameSelected].PortraitPlaceholderImage))
            //{
            //    if (flag == 1)
            //    {
            //        SystemControl.FileControl.DeleteFile(TEMP_MEDIUM_APPEND);
            //        SystemControl.FileControl.CreateTempImages(newImagePath, TEMP_APPENDS, placeholder, flag);
            //    }
            //    else if (flag == 2)
            //    {
            //        SystemControl.FileControl.DeleteFile(TEMP_SMALL_APPEND);
            //        SystemControl.FileControl.CreateTempImages(newImagePath, TEMP_APPENDS, placeholder, flag);
            //    }
            //    else if (flag == 100 || flag == 0)
            //    {
            //        SystemControl.FileControl.ClearTempImages();
            //        SystemControl.FileControl.CreateTempImages(newImagePath, TEMP_APPENDS, placeholder, flag);
            //    }
            //}
        }
        
        public void UpdateColorScheme()
        {
            //Color foreColor = GAME_TYPES[_gameSelected].ControlForeColor;
            //Color backColor = GAME_TYPES[_gameSelected].ControlBackColor;

            //Icon = GAME_TYPES[_gameSelected].ApplicationIcon;
            //PictureBoxTitle.BackgroundImage = GAME_TYPES[_gameSelected].MenuTitleImage;
            //LayoutMainPage.BackgroundImage = GAME_TYPES[_gameSelected].MenuBackgroundImage;

            //foreach (Control ctrl in Controls)
            //{
            //    UpdateObjectColoringInDepth(ctrl, foreColor, backColor);
            //}

            //Text = GAME_TYPES[_gameSelected].WindowTitleText;
            //TextBoxFullPath.Clear();

            //if (_gameSelected == 'p')
            //{
            //    ButtonLoadNormal.Visible = true;

            //    ButtonKingmaker.Enabled = false;
            //    ButtonKingmaker.ForeColor = backColor;
            //    ButtonKingmaker.BackColor = foreColor;

            //    ButtonWotR.Enabled = true;
            //    ButtonWotR.ForeColor = Color.White;
            //    ButtonWotR.BackColor = Color.Black;

            //    ButtonRT.Enabled = true;
            //    ButtonRT.ForeColor = Color.White;
            //    ButtonRT.BackColor = Color.Black;

            //    TextBoxFullPath.Text = CoreSettings.Default.KINGPath;
            //}
            //else if (_gameSelected == 'w')
            //{
            //    ButtonLoadNormal.Visible = true;

            //    ButtonKingmaker.Enabled = true;
            //    ButtonKingmaker.ForeColor = Color.White;
            //    ButtonKingmaker.BackColor = Color.Black;   
                
            //    ButtonWotR.Enabled = false;
            //    ButtonWotR.ForeColor = backColor;
            //    ButtonWotR.BackColor = foreColor;

            //    ButtonRT.Enabled = true;
            //    ButtonRT.ForeColor = Color.White;
            //    ButtonRT.BackColor = Color.Black;

            //    TextBoxFullPath.Text = CoreSettings.Default.WOTRPath;
            //}
            //else if (_gameSelected == 'r')
            //{
            //    ButtonLoadNormal.Visible = false;

            //    ButtonKingmaker.Enabled = true;
            //    ButtonKingmaker.ForeColor = Color.White;
            //    ButtonKingmaker.BackColor = Color.Black;

            //    ButtonWotR.Enabled = true;
            //    ButtonWotR.ForeColor = Color.White;
            //    ButtonWotR.BackColor = Color.Black;

            //    ButtonRT.Enabled = false;
            //    ButtonRT.ForeColor = backColor;
            //    ButtonRT.BackColor = foreColor;
                
            //    TextBoxFullPath.Text = CoreSettings.Default.ROGUEPath;
            //}
        }

        public bool LoadGallery(string path)
        {
            if (!SystemControl.FileControl.Readonly.DirectoryExists(path))
            {
                return false;
            }

            _cancellationTokenSource?.Cancel();
            //ClearImageListsSync(ListGallery, ImgListGallery);
            _cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancelToken = _cancellationTokenSource.Token;

            Task.Factory.StartNew(() =>
            {
                IterativeParsePortraitsFolderAsync(path, cancelToken);
            }, cancelToken);

            return true;
        }

        private void IterativeParsePortraitsFolderAsync(string fromPath, CancellationToken cancelToken)
        {
            string[] subDirs = Directory.GetDirectories(fromPath);

            foreach (string subDir in subDirs)
            {
                if (cancelToken.IsCancellationRequested)
                {
                    BeginInvoke((MethodInvoker)delegate
                    {
                        //ClearImageListsSync(ListGallery, ImgListGallery);
                    });

                    return;
                }

                if (CheckPortraitExistence(subDir))
                {
                    //if (SystemControl.FileControl.Readonly.CheckImagePixeling(subDir + LARGE_APPEND,
                    //    GAME_TYPES[_gameSelected].GetLargeWidth(), GAME_TYPES[_gameSelected].GetLargeHeight()) &&
                    //    SystemControl.FileControl.Readonly.CheckImagePixeling(subDir + MEDIUM_APPEND,
                    //    GAME_TYPES[_gameSelected].GetMediumWidth(), GAME_TYPES[_gameSelected].GetMediumHeight()) &&
                    //    SystemControl.FileControl.Readonly.CheckImagePixeling(subDir + SMALL_APPEND,
                    //    GAME_TYPES[_gameSelected].GetSmallWidth(), GAME_TYPES[_gameSelected].GetSmallHeight()))
                    //{
                    //    try
                    //    {
                    //        using (Image img = new Bitmap(subDir + "\\Fulllength.png"))
                    //        {

                    //            ListViewItem item = new ListViewItem
                    //            {
                    //                Text = subDir.Split('\\').Last(),
                    //                ImageIndex = ImgListGallery.Images.Count,
                    //                Tag = subDir+">LOCAL"
                    //            };
                    //            Invoke((MethodInvoker)delegate
                    //            {
                    //                ImgListGallery.Images.Add(subDir, img);
                    //                ListGallery.Items.Add(item);
                    //            });

                    //        }
                    //    }
                    //    catch
                    //    {
                    //        return;
                    //    }
                    //}
                }
            }
        }
        
        private void RecursiveParsePortraitsFolderAsync(string fromPath, CancellationToken cancelToken, bool flag)
        {
            if (cancelToken.IsCancellationRequested)
            {
                Invoke((MethodInvoker)delegate
                {
                    //ClearImageListsSync(ListGallery, ImgListGallery);
                });

                return;
            }

            if (CheckPortraitExistenceClipped(fromPath))
            {

                try
                {
                    string fromPathFilePath = fromPath + "\\Fulllength.png";
                    string name;

                    if (!SystemControl.FileControl.Readonly.FileExist(fromPathFilePath))
                    {
                        fromPathFilePath = fromPath + "\\Medium.png";
                    }

                    if (fromPath.Split('\\').Last() == "Game Default Portraits")
                    {
                        string[] parts = fromPath.Split('\\');
                        name = parts[parts.Length - 2] + " DEFAULT";
                    }
                    else
                    {
                        name = fromPath.Split('\\').Last();
                    }

                    if (flag)
                    {
                        if (!fromPath.Contains("CustomNpcPortraits - "))
                        {
                            return;
                        }
                    }

                    if (fromPath.Contains("BACKUP"))
                    {
                        return;
                    }

                    using (Image img = new Bitmap(fromPathFilePath))
                    {
                        ListViewItem item = new ListViewItem
                        {
                            Text = name,
                            //ImageIndex = ListGallery.Items.Count,
                            Tag = fromPath + ">CUSTOM"
                        };
                        Invoke((MethodInvoker)delegate
                        {
                            ImgListGallery.Images.Add(fromPath, img);
                            //ListGallery.Items.Add(item);
                        });
                    }
                }
                catch
                {
                    return;
                }
            }
            string[] subDirs = Directory.GetDirectories(fromPath);
            foreach (string subDir in subDirs)
            {
                RecursiveParsePortraitsFolderAsync(subDir, cancelToken, flag);
            }
        }
        
        public static void ClearImageListsSync(ListView listView, ImageList imageList)
        {
            listView.Items.Clear();
            listView.Clear();
            imageList.Images.Clear();
        }

        public string ParseDragDropFile(DragEventArgs e)
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

            return filePath;
        }

        public void CheckWebResourceAndLoad(string URL)
        {
            try
            {
                WebRequest request = WebRequest.Create(URL);

                using (WebResponse response = request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                {
                    using (Image webImage = Image.FromStream(stream))
                    {

                        _isAnyLoadedToPortraitPage = true;

                        //if (_imageSelectionFlag == 1)
                        //{
                        //    SystemControl.FileControl.DeleteFile(TEMP_MEDIUM_APPEND);
                        //    webImage.Save(TEMP_MEDIUM_APPEND);
                        //}
                        //else if (_imageSelectionFlag == 2)
                        //{
                        //    SystemControl.FileControl.DeleteFile(TEMP_SMALL_APPEND);
                        //    webImage.Save(TEMP_SMALL_APPEND);
                        //}
                        //else if (_imageSelectionFlag == 100 || _imageSelectionFlag == 0)
                        //{
                        //    SystemControl.FileControl.ClearTempImages();
                        //    SystemControl.FileControl.CreateDirectory("temp_DoNotDeleteWhileRunning/");
                        //    webImage.Save(TEMP_MEDIUM_APPEND);
                        //    webImage.Save(TEMP_SMALL_APPEND);
                        //    webImage.Save(TEMP_LARGE_APPEND);
                        //}

                        LoadTempImagesToPicBox(_imageSelectionFlag);
                    }
                }
            }
            catch
            {
                //using (forms.MyMessageDialog Message = new forms.MyMessageDialog(TextVariables.MESG_CANNOTLOAD, CoreSettings.Default.SelectedLang))
                //{
                //    Message.StartPosition = FormStartPosition.CenterParent;
                //    Message.ShowDialog();
                //    Focus();
                //}
            }
        }
        
        public void GeneratePortraits(string path)
        {
            //Directory.CreateDirectory(path);
            //ImageControl.Wraps.CropImage(PicPortraitLrg, PanelPortraitLrg, TEMP_LARGE_APPEND,
            //                             path + LARGE_APPEND, GAME_TYPES[_gameSelected].GetLargeAspect(),
            //                             GAME_TYPES[_gameSelected].GetLargeWidth(), GAME_TYPES[_gameSelected].GetLargeHeight());
            //ImageControl.Wraps.CropImage(PicPortraitMed, PanelPortraitMed, TEMP_MEDIUM_APPEND,
            //                             path + MEDIUM_APPEND, GAME_TYPES[_gameSelected].GetMediumAspect(),
            //                             GAME_TYPES[_gameSelected].GetMediumWidth(), GAME_TYPES[_gameSelected].GetMediumHeight());
            //ImageControl.Wraps.CropImage(PicPortraitSml, PanelPortraitSml, TEMP_SMALL_APPEND,
            //                             path + SMALL_APPEND, GAME_TYPES[_gameSelected].GetSmallAspect(),
            //                             GAME_TYPES[_gameSelected].GetSmallWidth(), GAME_TYPES[_gameSelected].GetSmallHeight());
        }


        public void Ctrl_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
            }
        }
    


        private void OpenPathSelectPage()
        {
            ParentLayoutsDisable();
            LabelSelectPathResetPath_Click(this, new EventArgs());
            RootFunctions.LayoutEnable(LayoutPathPage);
        }

        private Image LoadImageFromBytes(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            using (Image temp = Image.FromStream(ms))
            {
                return new Bitmap(temp);
            }
        }

        private byte[] ReadEntryBytes(ZipArchiveEntry entry)
        {
            using (var stream = entry.Open())
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }

        private bool IsImageFile(string name)
        {
            string ext = Path.GetExtension(name);
            return ext.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
                   ext.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                   ext.Equals(".png", StringComparison.OrdinalIgnoreCase) ||
                   ext.Equals(".bmp", StringComparison.OrdinalIgnoreCase) ||
                   ext.Equals(".gif", StringComparison.OrdinalIgnoreCase) ||
                   ext.Equals(".webp", StringComparison.OrdinalIgnoreCase);
        }

        private static Size FitSize(Size original, int maxSize)
        {
            double ratio = Math.Min((double)maxSize / original.Width, (double)maxSize / original.Height);
            if (ratio >= 1.0) return original;
            return new Size((int)(original.Width * ratio), (int)(original.Height * ratio));
        }

        private void AddArchiveThumbnail(string folderKey, Image image, bool complete = true)
        {
            Bitmap memImage = new Bitmap(image);

            _archiveEntries.Add(Tuple.Create<string, Image>(folderKey, memImage));

            Size thumbSize = FitSize(new Size(memImage.Width, memImage.Height), 140);
            int cbWidth = Math.Max(thumbSize.Width + 20, 145);
            int cbHeight = thumbSize.Height + 50;

            Color gameBack, gameFore;
            try { gameBack = GameTypes[_gameSelected].BackColor; gameFore = GameTypes[_gameSelected].ForeColor; }
            catch { gameBack = Color.FromArgb(12, 12, 12); gameFore = Color.White; }

            string displayText = complete ? Path.GetFileName(folderKey) : Path.GetFileName(folderKey) + " (partial)";
            Color borderColor = complete ? gameBack : Color.FromArgb(230, 180, 40);

            CheckBox cb = new CheckBox
            {
                Text = displayText,
                Tag = folderKey,
                Checked = false,
                ForeColor = Color.White,
                BackColor = gameBack,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(cbWidth, cbHeight),
                TextAlign = ContentAlignment.BottomCenter,
                Padding = new Padding(8, 8, 8, 4),
                ImageAlign = ContentAlignment.TopCenter
            };

            cb.Font = new Font(_fontCollectionRu.Families[0], 13);

            cb.FlatAppearance.BorderSize = 3;
            cb.FlatAppearance.BorderColor = borderColor;
            cb.FlatAppearance.CheckedBackColor = ControlPaint.Light(gameBack, 0.3f);
            cb.FlatAppearance.MouseOverBackColor = ControlPaint.Light(gameBack, 0.15f);

            cb.MouseEnter += (s, args) => { cb.ForeColor = gameFore; };
            cb.MouseLeave += (s, args) => { cb.ForeColor = Color.White; };
            cb.CheckedChanged += (s, args) =>
            {
                cb.FlatAppearance.BorderColor = cb.Checked ? gameFore : borderColor;
                UpdateExtractCounter();
            };

            Image thumb = new Bitmap(memImage, thumbSize);
            cb.Image = thumb;
            cb.Appearance = Appearance.Button;

            FlowLayoutPanelExtract.Controls.Add(cb);
        }

        private bool IsValidPortraitSize(Size imageSize)
        {
            return IsValidPortraitSize(imageSize, _gameSelected);
        }

        private bool IsValidPortraitSize(Size imageSize, char gameSelected)
        {
            if (gameSelected != 'k' && gameSelected != 'w' && gameSelected != 'r' && gameSelected != 't' && gameSelected != 'l' && gameSelected != 'p' && gameSelected != 'd')
                return true;

            try
            {
                var gt = GameTypes[gameSelected];
                var expected = new List<Size>();
                try { expected.Add(new Size((int)gt.GetPortraitSpecific("SMALL_WIDTH"), (int)gt.GetPortraitSpecific("SMALL_HEIGHT"))); } catch { }
                try { expected.Add(new Size((int)gt.GetPortraitSpecific("MEDIUM_WIDTH"), (int)gt.GetPortraitSpecific("MEDIUM_HEIGHT"))); } catch { }
                try { expected.Add(new Size((int)gt.GetPortraitSpecific("LARGE_WIDTH"), (int)gt.GetPortraitSpecific("LARGE_HEIGHT"))); } catch { }
                try { expected.Add(new Size((int)gt.GetPortraitSpecific("SML2_WIDTH"), (int)gt.GetPortraitSpecific("SML2_HEIGHT"))); } catch { }

                foreach (var exp in expected)
                {
                    if (Math.Abs(imageSize.Width - exp.Width) <= 2 &&
                        Math.Abs(imageSize.Height - exp.Height) <= 3)
                        return true;
                }
                return false;
            }
            catch { return true; }
        }

        private void ValidatePortraitSize(string filePath, ref bool hadInvalid)
        {
            try
            {
                using (var bmp = new Bitmap(filePath))
                {
                    if (!IsValidPortraitSize(bmp.Size))
                    {
                        File.Delete(filePath);
                        hadInvalid = true;
                    }
                }
            }
            catch
            {
                hadInvalid = true;
            }
        }

        private void ClearArchiveEntries()
        {
            if (_archiveEntries != null)
            {
                foreach (var entry in _archiveEntries)
                    entry.Item2?.Dispose();
                _archiveEntries = null;
            }
            foreach (Control c in FlowLayoutPanelExtract.Controls)
            {
                if (c is CheckBox cb && cb.Image != null)
                {
                    cb.Image.Dispose();
                    cb.Image = null;
                }
            }
            FlowLayoutPanelExtract.Controls.Clear();
            UpdateExtractCounter();
        }

        private string GetGameDirectory()
        {
            string basePath = CoreSettings.Default.GamePath;
            if (string.IsNullOrEmpty(basePath) || basePath == "0")
                return null;
            basePath = basePath.TrimEnd(Path.DirectorySeparatorChar);

            string path;
            switch (_gameSelected)
            {
                case 'p':
                    path = Path.Combine(basePath, "PillarsOfEternity_Data", "data", "art", "gui", "portraits", "player", "male");
                    break;
                case 'd':
                    path = Path.Combine(basePath, "PillarsOfEternityII_Data", "gui", "portraits", "player", "male");
                    break;
                case 't':
                    path = Path.Combine(basePath, "Tyranny_Data", "data", "art", "gui", "portraits", "player", "male");
                    break;
                case 'l':
                    path = Path.Combine(basePath, "Custom Portraits");
                    break;
                default:
                    path = Path.Combine(basePath, "Portraits");
                    break;
            }

            try { Directory.CreateDirectory(path); } catch { }
            return path;
        }

        private void ClearGalleryEntries()
        {
            _selectedGalleryEntry = null;
            if (_galleryEntries != null)
            {
                foreach (var entry in _galleryEntries)
                    entry.Item2?.Dispose();
                _galleryEntries = null;
            }
            foreach (Control c in FlowLayoutPanelGallery.Controls)
            {
                if (c is CheckBox cb && cb.Image != null)
                {
                    cb.Image.Dispose();
                    cb.Image = null;
                }
            }
            FlowLayoutPanelGallery.Controls.Clear();
        }

        private void AddGalleryThumbnail(string folderKey, Image image, string displayNameOverride = null)
        {
            Bitmap memImage = new Bitmap(image);

            _galleryEntries.Add(Tuple.Create<string, Image>(folderKey, memImage));

            int gridWidth = FlowLayoutPanelGallery.ClientSize.Width;
            if (gridWidth <= 0) gridWidth = 490;
            float targetCols = 3.5f;
            float targetCtrlWidth = gridWidth / targetCols;
            float imageWidth = targetCtrlWidth - 26;
            if (memImage.Width > 0 && memImage.Height > 0)
            {
                float imgAspect = (float)memImage.Height / memImage.Width;
                int maxSize = Math.Max((int)(imageWidth * Math.Max(imgAspect, 1.0f)), 100);
                Size thumbSize = FitSize(new Size(memImage.Width, memImage.Height), maxSize);
                int cbWidth = Math.Max(thumbSize.Width + 20, 145);
                int cbHeight = thumbSize.Height + 60;

                Color gameBack, gameFore;
                try { gameBack = GameTypes[_gameSelected].BackColor; gameFore = GameTypes[_gameSelected].ForeColor; }
                catch { gameBack = Color.FromArgb(12, 12, 12); gameFore = Color.White; }

                RadioButton rb = new RadioButton
                {
                    Text = displayNameOverride ?? DisplayNameForGalleryFolder(Path.GetFileName(folderKey)),
                    Tag = folderKey,
                    Checked = false,
                    ForeColor = Color.White,
                    BackColor = gameBack,
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(cbWidth, cbHeight),
                    TextAlign = ContentAlignment.BottomCenter,
                    Padding = new Padding(8, 8, 8, 4),
                    ImageAlign = ContentAlignment.TopCenter,
                    Appearance = Appearance.Button,
                    Cursor = _isCustomNpcMode ? Cursors.Default : Cursors.Hand,
                };

                rb.Font = new Font(_fontCollectionRu.Families[0], 12);

                rb.FlatAppearance.BorderSize = 3;
                rb.FlatAppearance.BorderColor = gameBack;
                rb.FlatAppearance.CheckedBackColor = ControlPaint.Light(gameBack, 0.3f);
                rb.FlatAppearance.MouseOverBackColor = ControlPaint.Light(gameBack, 0.15f);

                rb.MouseEnter += (s, args) => { rb.ForeColor = gameFore; };
                rb.MouseLeave += (s, args) => { rb.ForeColor = Color.White; };
                rb.CheckedChanged += (s, args) =>
                {
                    if (rb.Checked)
                    {
                        _selectedGalleryEntry = folderKey;
                    }
                    rb.FlatAppearance.BorderColor = rb.Checked ? gameFore : gameBack;
                    UpdateGalleryRightPanel();
                };

                Image thumb = new Bitmap(memImage, thumbSize);
                rb.Image = thumb;

                FlowLayoutPanelGallery.Controls.Add(rb);
            }
        }

        private string FindBestGalleryImage(string folderPath)
        {
            bool isOwlcat = _gameSelected == 'k' || _gameSelected == 'w' || _gameSelected == 'r';

            if (isOwlcat)
            {
                if (!Directory.Exists(folderPath)) return null;
                string[] files;
                try { files = Directory.GetFiles(folderPath, "*.png"); }
                catch { return null; }
                if (files.Length == 0) return null;
                string match;
                match = files.FirstOrDefault(f => Path.GetFileName(f).Equals("Fulllength.png", StringComparison.OrdinalIgnoreCase));
                if (match != null) return match;
                match = files.FirstOrDefault(f => Path.GetFileName(f).Equals("Medium.png", StringComparison.OrdinalIgnoreCase));
                if (match != null) return match;
                match = files.FirstOrDefault(f => Path.GetFileName(f).Equals("Small.png", StringComparison.OrdinalIgnoreCase));
                if (match != null) return match;
                return files[0];
            }
            else
            {
                string dir = Path.GetDirectoryName(folderPath);
                string prefix = Path.GetFileName(folderPath);

                if (_gameSelected == 'l')
                {
                    string path = folderPath + ".png";
                    return File.Exists(path) ? path : null;
                }
                else
                {
                    string[] prio = { "_lg", "_med", "_sm", "_convo" };
                    foreach (string suf in prio)
                    {
                        string path = Path.Combine(dir, prefix + suf + ".png");
                        if (File.Exists(path)) return path;
                    }
                    return null;
                }
            }
        }

        private void DeleteGalleryPortraitSet(string path)
        {
            if (string.IsNullOrEmpty(path)) return;

            try
            {
                if (_gameSelected == 'k' || _gameSelected == 'w' || _gameSelected == 'r')
                {
                    if (Directory.Exists(path))
                        Directory.Delete(path, recursive: true);
                }
                else if (_gameSelected == 'l')
                {
                    string filePath = path + ".png";
                    if (File.Exists(filePath))
                        File.Delete(filePath);
                }
                else
                {
                    string dir = Path.GetDirectoryName(path);
                    string prefix = Path.GetFileName(path);
                    string[] suffixes = { "_lg", "_sm", "_si", "_convo" };
                    foreach (string suf in suffixes)
                    {
                        string filePath = Path.Combine(dir, prefix + suf + ".png");
                        if (File.Exists(filePath))
                            File.Delete(filePath);
                        string backupPath = filePath + ".backup";
                        if (File.Exists(backupPath))
                            File.Delete(backupPath);
                    }
                    string femaleDir = Path.Combine(Path.GetDirectoryName(dir), "female");
                    if (Directory.Exists(femaleDir))
                    {
                        foreach (string suf in suffixes)
                        {
                            string filePath = Path.Combine(femaleDir, prefix + suf + ".png");
                            if (File.Exists(filePath))
                                File.Delete(filePath);
                            string backupPath = filePath + ".backup";
                            if (File.Exists(backupPath))
                                File.Delete(backupPath);
                        }
                    }
                }
            }
            catch { }
        }

        // Vanilla Owlcat's native custom-companion-portrait feature stores its folders directly
        // in Portraits\ under this prefix. Distinct from the CustomNpcPortraits mod's own
        // companion-override folders (ModCompanionPortraitPrefix), which the mod itself creates
        // via GetCompanionPortraitDirPrefix() = "CustomNpcPortraits - ".
        private const string VanillaCompanionPortraitPrefix = "CompanionCustomPortrait - ";
        private const string ModCompanionPortraitPrefix = "CustomNpcPortraits - ";

        private static string DisplayNameForGalleryFolder(string folderName)
        {
            if (folderName.StartsWith(VanillaCompanionPortraitPrefix, StringComparison.OrdinalIgnoreCase))
                return folderName.Substring(VanillaCompanionPortraitPrefix.Length);
            if (folderName.StartsWith(ModCompanionPortraitPrefix, StringComparison.OrdinalIgnoreCase))
                return folderName.Substring(ModCompanionPortraitPrefix.Length);
            return folderName;
        }

        private void LoadGalleryImages()
        {
            ClearGalleryEntries();
            _galleryEntries = new List<Tuple<string, Image>>();
            FlowLayoutPanelGallery.Visible = true;

            string gamePath = CoreSettings.Default.GamePath;
            if (string.IsNullOrEmpty(gamePath) || !Directory.Exists(gamePath))
                return;

            if (_galleryTabSelected == "nonplayer" && (_gameSelected == 't' || _gameSelected == 'p' || _gameSelected == 'd'))
            {
                LoadNonPlayerGalleryImages(gamePath);
                return;
            }

            if (_galleryTabSelected == "customnpc")
            {
                string npcRoot = GetCustomNpcPortraitsDir(gamePath);
                if (string.IsNullOrEmpty(npcRoot) || !Directory.Exists(npcRoot)) return;
                _cancellationTokenSource?.Cancel();
                _cancellationTokenSource = new CancellationTokenSource();
                var npcToken = _cancellationTokenSource.Token;
                string capturedNpcRoot = npcRoot;
                Task.Run(() =>
                {
                    LoadSubfolderGalleryGradual(capturedNpcRoot, _gameSelected, npcToken);
                    BeginInvoke(new Action(() =>
                    {
                        if (_galleryEntries.Count > 0)
                            ShowScrollBar(FlowLayoutPanelGallery.Handle, 3, false);
                        UpdateGalleryRightPanel();
                    }));
                }, npcToken);
                return;
            }

            if (_galleryTabSelected == "characters")
            {
                string charactersRoot = GetCharactersPortraitsDir(gamePath);
                if (string.IsNullOrEmpty(charactersRoot) || !Directory.Exists(charactersRoot)) return;
                _cancellationTokenSource?.Cancel();
                _cancellationTokenSource = new CancellationTokenSource();
                var charToken = _cancellationTokenSource.Token;
                string capturedCharactersRoot = charactersRoot;
                Task.Run(() =>
                {
                    LoadCharactersGalleryRecursive(capturedCharactersRoot, charToken);
                    BeginInvoke(new Action(() =>
                    {
                        if (_galleryEntries.Count > 0)
                            ShowScrollBar(FlowLayoutPanelGallery.Handle, 3, false);
                        UpdateGalleryRightPanel();
                    }));
                }, charToken);
                return;
            }

            string portraitsDir;
            bool flatFile = false;
            Func<string, bool> subfolderFilter = null;

            if (_gameSelected == 'k' || _gameSelected == 'w' || _gameSelected == 'r')
            {
                portraitsDir = Path.Combine(gamePath, "Portraits");

                if (_galleryTabSelected == "companions")
                    subfolderFilter = name => name.StartsWith(VanillaCompanionPortraitPrefix, StringComparison.OrdinalIgnoreCase);
                else
                    subfolderFilter = name => !name.StartsWith(VanillaCompanionPortraitPrefix, StringComparison.OrdinalIgnoreCase) &&
                                               !name.StartsWith(ModCompanionPortraitPrefix, StringComparison.OrdinalIgnoreCase);
            }
            else if (_gameSelected == 'p')
            {
                portraitsDir = Path.Combine(gamePath, "PillarsOfEternity_Data", "data", "art", "gui", "portraits", "player", "male");
                flatFile = true;
            }
            else if (_gameSelected == 'd')
            {
                portraitsDir = Path.Combine(gamePath, "PillarsOfEternityII_Data", "gui", "portraits", "player", "male");
                flatFile = true;
            }
            else if (_gameSelected == 't')
            {
                portraitsDir = Path.Combine(gamePath, "Tyranny_Data", "data", "art", "gui", "portraits", "player", "male");
                flatFile = true;
            }
            else if (_gameSelected == 'l')
            {
                portraitsDir = Path.Combine(gamePath, "Custom Portraits");
                flatFile = true;
            }
            else
            {
                return;
            }

            if (!Directory.Exists(portraitsDir))
                return;

            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();
            var token = _cancellationTokenSource.Token;

            string capturedPortraitsDir = portraitsDir;
            bool capturedFlatFile = flatFile;
            char capturedGame = _gameSelected;
            Func<string, bool> capturedFilter = subfolderFilter;

            Task.Run(() =>
            {
                if (capturedFlatFile)
                    LoadFlatGalleryGradual(capturedPortraitsDir, capturedGame, token);
                else
                    LoadSubfolderGalleryGradual(capturedPortraitsDir, capturedGame, token, capturedFilter);

                BeginInvoke(new Action(() =>
                {
                    if (_galleryEntries.Count > 0)
                        ShowScrollBar(FlowLayoutPanelGallery.Handle, 3, false);
                    UpdateGalleryRightPanel();
                }));
            }, token);
        }

        private void LoadNonPlayerGalleryImages(string gamePath)
        {
            string portraitsRoot = GetNonPlayerPortraitsRoot(gamePath);
            if (portraitsRoot == null) return;
            string[] subDirs = { "npc", "companions" };

            var allFiles = new List<string>();
            foreach (string sub in subDirs)
            {
                string dir = Path.Combine(portraitsRoot, sub);
                if (!Directory.Exists(dir)) continue;
                try
                {
                    allFiles.AddRange(Directory.GetFiles(dir, "*.png", SearchOption.AllDirectories));
                }
                catch { }
            }

            if (allFiles.Count == 0) return;

            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();
            var token = _cancellationTokenSource.Token;

            string[] sizePriority = { "_convo", "_sm", "_si", "_med", "_lg" };

            var groupBest = new Dictionary<string, string>();
            foreach (string file in allFiles)
            {
                if (token.IsCancellationRequested) return;
                string name = Path.GetFileNameWithoutExtension(file);
                string prefix = name;
                foreach (string suf in sizePriority)
                {
                    if (name.EndsWith(suf, StringComparison.OrdinalIgnoreCase))
                    {
                        prefix = name.Substring(0, name.Length - suf.Length);
                        break;
                    }
                }

                string key = prefix + "|" + Path.GetDirectoryName(file);
                if (!groupBest.ContainsKey(key))
                {
                    groupBest[key] = file;
                }
                else
                {
                    string existingName = Path.GetFileNameWithoutExtension(groupBest[key]);
                    int existingPrio = -1, newPrio = -1;
                    for (int i = 0; i < sizePriority.Length; i++)
                    {
                        if (existingName.EndsWith(sizePriority[i], StringComparison.OrdinalIgnoreCase)) existingPrio = i;
                        if (name.EndsWith(sizePriority[i], StringComparison.OrdinalIgnoreCase)) newPrio = i;
                    }
                    if (newPrio > existingPrio)
                        groupBest[key] = file;
                }
            }

            Task.Run(() =>
            {
                foreach (var kvp in groupBest)
                {
                    if (token.IsCancellationRequested) return;
                    try
                    {
                        using (Image img = Image.FromFile(kvp.Value))
                        {
                            if (token.IsCancellationRequested) return;
                            Bitmap memImage = new Bitmap(img);
                            string dir = Path.GetDirectoryName(kvp.Value);
                            string prefix = Path.GetFileNameWithoutExtension(kvp.Value);
                            foreach (string suf in sizePriority)
                            {
                                if (prefix.EndsWith(suf, StringComparison.OrdinalIgnoreCase))
                                {
                                    prefix = prefix.Substring(0, prefix.Length - suf.Length);
                                    break;
                                }
                            }
                            string capturedKey = Path.Combine(dir, prefix);
                            BeginInvoke(new Action(() =>
                            {
                                if (token.IsCancellationRequested)
                                {
                                    memImage.Dispose();
                                    return;
                                }
                                AddGalleryThumbnail(capturedKey, memImage);
                                memImage.Dispose();
                            }));
                        }
                    }
                    catch { }
                }

                BeginInvoke(new Action(() =>
                {
                    if (_galleryEntries.Count > 0)
                        ShowScrollBar(FlowLayoutPanelGallery.Handle, 3, false);
                }));
            }, token);
        }

        private void LoadSubfolderGalleryGradual(string portraitsDir, char gameSelected, CancellationToken token, Func<string, bool> subfolderFilter = null)
        {
            string[] subDirs;
            try { subDirs = Directory.GetDirectories(portraitsDir); }
            catch { return; }

            foreach (string subDir in subDirs)
            {
                if (token.IsCancellationRequested) return;
                if (!Directory.Exists(subDir)) continue;
                if (subfolderFilter != null && !subfolderFilter(Path.GetFileName(subDir))) continue;
                string[] files;
                try { files = Directory.GetFiles(subDir, "*.png"); }
                catch { continue; }
                if (files.Length == 0) continue;

                string bestFile = null;
                if (files.Any(f => Path.GetFileName(f).Equals("Fulllength.png", StringComparison.OrdinalIgnoreCase)))
                    bestFile = files.First(f => Path.GetFileName(f).Equals("Fulllength.png", StringComparison.OrdinalIgnoreCase));
                else if (files.Any(f => Path.GetFileName(f).Equals("Medium.png", StringComparison.OrdinalIgnoreCase)))
                    bestFile = files.First(f => Path.GetFileName(f).Equals("Medium.png", StringComparison.OrdinalIgnoreCase));
                else if (files.Any(f => Path.GetFileName(f).Equals("Small.png", StringComparison.OrdinalIgnoreCase)))
                    bestFile = files.First(f => Path.GetFileName(f).Equals("Small.png", StringComparison.OrdinalIgnoreCase));
                else
                    bestFile = files[0];

                try
                {
                    using (Image img = Image.FromFile(bestFile))
                    {
                        if (token.IsCancellationRequested) return;
                        Bitmap memImage = new Bitmap(img);
                        string capturedKey = subDir;
                        BeginInvoke(new Action(() =>
                        {
                            if (token.IsCancellationRequested)
                            {
                                memImage.Dispose();
                                return;
                            }
                            AddGalleryThumbnail(capturedKey, memImage);
                            memImage.Dispose();
                        }));
                    }
                }
                catch { }
            }
        }

        // "Portraits - All Additions" can hold, per character, either the portrait files directly
        // or one or more nested subfolders representing area/plot-specific portrait versions.
        // Recurse into any folder that has no images of its own so those versions still surface.
        private void LoadCharactersGalleryRecursive(string dir, CancellationToken token, int depth = 0)
        {
            if (token.IsCancellationRequested || depth > 10) return;

            string[] files;
            try { files = Directory.GetFiles(dir, "*.png"); }
            catch { return; }

            if (files.Length > 0)
            {
                string bestFile = files.FirstOrDefault(f => Path.GetFileName(f).Equals("Fulllength.png", StringComparison.OrdinalIgnoreCase))
                    ?? files.FirstOrDefault(f => Path.GetFileName(f).Equals("Medium.png", StringComparison.OrdinalIgnoreCase))
                    ?? files.FirstOrDefault(f => Path.GetFileName(f).Equals("Small.png", StringComparison.OrdinalIgnoreCase))
                    ?? files[0];

                // Direct child of the root ("Portraits - All Additions\Name") -> plain name.
                // Anything deeper is an area/plot-specific version -> "Name (Version)".
                string displayName = depth <= 1
                    ? Path.GetFileName(dir)
                    : Path.GetFileName(Path.GetDirectoryName(dir)) + " (" + Path.GetFileName(dir) + ")";

                try
                {
                    using (Image img = Image.FromFile(bestFile))
                    {
                        if (token.IsCancellationRequested) return;
                        Bitmap memImage = new Bitmap(img);
                        string capturedKey = dir;
                        string capturedDisplayName = displayName;
                        BeginInvoke(new Action(() =>
                        {
                            if (token.IsCancellationRequested)
                            {
                                memImage.Dispose();
                                return;
                            }
                            AddGalleryThumbnail(capturedKey, memImage, capturedDisplayName);
                            memImage.Dispose();
                        }));
                    }
                }
                catch { }
                return;
            }

            string[] subDirs;
            try { subDirs = Directory.GetDirectories(dir); }
            catch { return; }

            foreach (string subDir in subDirs)
            {
                if (token.IsCancellationRequested) return;
                LoadCharactersGalleryRecursive(subDir, token, depth + 1);
            }
        }

        private void LoadFlatGalleryGradual(string portraitsDir, char gameSelected, CancellationToken token)
        {
            string[] files;
            try { files = Directory.GetFiles(portraitsDir, "*.png"); }
            catch { return; }

            var groupBest = new Dictionary<string, string>();
            string[] sizePriority = { "_convo", "_sm", "_si", "_med", "_lg" };

            foreach (string file in files)
            {
                if (token.IsCancellationRequested) return;
                string name = Path.GetFileNameWithoutExtension(file);
                string prefix = name;

                foreach (string suf in sizePriority)
                {
                    if (name.EndsWith(suf, StringComparison.OrdinalIgnoreCase))
                    {
                        prefix = name.Substring(0, name.Length - suf.Length);
                        break;
                    }
                }

                if (!groupBest.ContainsKey(prefix))
                {
                    groupBest[prefix] = file;
                }
                else
                {
                    string existingName = Path.GetFileNameWithoutExtension(groupBest[prefix]);
                    int existingPrio = -1, newPrio = -1;
                    for (int i = 0; i < sizePriority.Length; i++)
                    {
                        if (existingName.EndsWith(sizePriority[i], StringComparison.OrdinalIgnoreCase)) existingPrio = i;
                        if (name.EndsWith(sizePriority[i], StringComparison.OrdinalIgnoreCase)) newPrio = i;
                    }
                    if (newPrio > existingPrio)
                        groupBest[prefix] = file;
                }
            }

            foreach (var kvp in groupBest)
            {
                if (token.IsCancellationRequested) return;
                try
                {
                    using (Image img = Image.FromFile(kvp.Value))
                    {
                        if (token.IsCancellationRequested) return;
                        Bitmap memImage = new Bitmap(img);
                        string capturedKey = Path.Combine(portraitsDir, kvp.Key);
                        BeginInvoke(new Action(() =>
                        {
                            if (token.IsCancellationRequested)
                            {
                                memImage.Dispose();
                                return;
                            }
                            AddGalleryThumbnail(capturedKey, memImage);
                            memImage.Dispose();
                        }));
                    }
                }
                catch { }
            }
        }

        private void LoadArchiveThumbnails(string archivePath)
        {
            _selectedArchivePath = archivePath;
            ClearArchiveEntries();
            _archiveEntries = new List<Tuple<string, Image>>();

            FlowLayoutPanelExtract.Visible = false;
            PanelExtractOverlay.Visible = true;

            CleanupShellTempDir();

            Task.Run(() =>
            {
                try
                {
                    string ext = Path.GetExtension(archivePath).ToLowerInvariant();

                    if (ext == ".zip")
                    {
                        if (_gameSelected == 't')
                        {
                            using (ZipArchive archive = ZipFile.OpenRead(archivePath))
                            {
                                var lgEntries = archive.Entries
                                    .Where(e => e.Name.EndsWith("_lg.png", StringComparison.OrdinalIgnoreCase))
                                    .ToList();

                                foreach (var entry in lgEntries)
                                {
                                    try
                                    {
                                        string baseName = Path.GetFileNameWithoutExtension(entry.Name);
                                        string key = baseName.EndsWith("_lg", StringComparison.OrdinalIgnoreCase)
                                            ? baseName.Substring(0, baseName.Length - 3)
                                            : baseName;
                                        byte[] data = ReadEntryBytes(entry);
                                        Image img = LoadImageFromBytes(data);
                                        if (IsValidPortraitSize(img.Size))
                                        {
                                            BeginInvoke(new Action(() =>
                                            {
                                                AddArchiveThumbnail(key, img);
                                                img.Dispose();
                                            }));
                                        }
                                        else
                                        {
                                            img.Dispose();
                                        }
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (_gameSelected == 'l')
                        {
                            using (ZipArchive archive = ZipFile.OpenRead(archivePath))
                            {
                                var imgEntries = archive.Entries
                                    .Where(e => !e.FullName.EndsWith("/") && IsImageFile(e.Name))
                                    .ToList();

                                foreach (var entry in imgEntries)
                                {
                                    try
                                    {
                                        string key = Path.GetFileNameWithoutExtension(entry.Name);
                                        byte[] data = ReadEntryBytes(entry);
                                        Image img = LoadImageFromBytes(data);
                                        if (IsValidPortraitSize(img.Size))
                                        {
                                            BeginInvoke(new Action(() =>
                                            {
                                                AddArchiveThumbnail(key, img);
                                                img.Dispose();
                                            }));
                                        }
                                        else
                                        {
                                            img.Dispose();
                                        }
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (_gameSelected == 'p' || _gameSelected == 'd')
                        {
                            using (ZipArchive archive = ZipFile.OpenRead(archivePath))
                            {
                                var allEntries = archive.Entries.ToList();
                                var lgEntries = allEntries
                                    .Where(e => e.Name.EndsWith("_lg.png", StringComparison.OrdinalIgnoreCase))
                                    .ToList();

                                foreach (var entry in lgEntries)
                                {
                                    try
                                    {
                                        string baseName = Path.GetFileNameWithoutExtension(entry.Name);
                                        string key = baseName.EndsWith("_lg", StringComparison.OrdinalIgnoreCase)
                                            ? baseName.Substring(0, baseName.Length - 3)
                                            : baseName;
                                        bool hasAllCompanions;
                                        if (_gameSelected == 'd')
                                            hasAllCompanions = allEntries.Any(e => e.Name.Equals(key + "_sm.png", StringComparison.OrdinalIgnoreCase)) &&
                                                               allEntries.Any(e => e.Name.Equals(key + "_si.png", StringComparison.OrdinalIgnoreCase)) &&
                                                               allEntries.Any(e => e.Name.Equals(key + "_convo.png", StringComparison.OrdinalIgnoreCase));
                                        else
                                            hasAllCompanions = allEntries.Any(e => e.Name.Equals(key + "_sm.png", StringComparison.OrdinalIgnoreCase));

                                        byte[] data = ReadEntryBytes(entry);
                                        Image img = LoadImageFromBytes(data);
                                        if (IsValidPortraitSize(img.Size))
                                        {
                                            BeginInvoke(new Action(() =>
                                            {
                                                AddArchiveThumbnail(key, img, hasAllCompanions);
                                                img.Dispose();
                                            }));
                                        }
                                        else
                                        {
                                            img.Dispose();
                                        }
                                    }
                                    catch { }
                                }
                            }
                        }
                        else
                        {
                            using (ZipArchive archive = ZipFile.OpenRead(archivePath))
                            {
                                var imageEntries = archive.Entries
                                    .Where(e => !e.FullName.EndsWith("/"))
                                    .GroupBy(e => Path.GetDirectoryName(e.FullName).Replace("\\", "/"))
                                    .ToList();

                                foreach (var group in imageEntries)
                                {
                                    var imgFiles = group.Where(e => IsImageFile(e.Name)).ToList();
                                    if (imgFiles.Count == 0) continue;

                                    var fileNames = imgFiles
                                        .Select(e => Path.GetFileName(e.Name))
                                        .ToHashSet(StringComparer.OrdinalIgnoreCase);
                                    if (!fileNames.Contains("Fulllength.png") ||
                                        !fileNames.Contains("Medium.png") ||
                                        !fileNames.Contains("Small.png"))
                                        continue;

                                    var firstImg = imgFiles.FirstOrDefault(f =>
                                        Path.GetFileName(f.Name).Equals("Fulllength.png", StringComparison.OrdinalIgnoreCase))
                                        ?? imgFiles.First();
                                    try
                                    {
                                        byte[] data = ReadEntryBytes(firstImg);
                                        Image img = LoadImageFromBytes(data);
                                        if (IsValidPortraitSize(img.Size))
                                        {
                                            string key = string.IsNullOrEmpty(group.Key)
                                                ? Path.GetFileNameWithoutExtension(archivePath) + "_flat"
                                                : group.Key;
                                            BeginInvoke(new Action(() =>
                                            {
                                                AddArchiveThumbnail(key, img);
                                                img.Dispose();
                                            }));
                                        }
                                        else
                                        {
                                            img.Dispose();
                                        }
                                    }
                                    catch { }
                                }
                            }
                        }

                        BeginInvoke(new Action(CompleteExtractLoad));
                    }
                    else if (ext == ".7z" || ext == ".rar")
                    {
                        string tempDir = Path.Combine(Path.GetTempPath(), "PortraitManager_Extract_" + Guid.NewGuid().ToString("N"));
                        Directory.CreateDirectory(tempDir);
                        ExtractArchive(archivePath, tempDir);
                        BeginInvoke(new Action(() =>
                        {
                            _shellTempDir = tempDir;
                            LoadFolderThumbnails(tempDir);
                            CompleteExtractLoad();
                        }));
                    }
                    else
                    {
                        BeginInvoke(new Action(() =>
                        {
                            LoadFolderThumbnails(archivePath);
                            CompleteExtractLoad();
                        }));
                    }
                }
                catch (Exception ex)
                {
                    BeginInvoke(new Action(() =>
                    {
                        using (var msg = new MyMessageDialog("Failed to load archive: " + ex.Message))
                        {
                            msg.StartPosition = FormStartPosition.CenterParent;
                            msg.ShowDialog();
                        }
                    }));
                }
            });
        }

        private void CompleteExtractLoad()
        {
            UpdateExtractCounter();

            if (_archiveEntries.Count > 0)
            {
                PanelExtractOverlay.Visible = false;
                FlowLayoutPanelExtract.Visible = true;
                FlowLayoutPanelExtractBottom.Visible = true;
                ButtonExtractAll.Visible = true;
                ButtonExtractSelected.Visible = true;
                ButtonExtractShowFolder.Visible = true;
                ButtonExtractShowFolder.Text = TextVariables.BUTTON_EXTRACT_OPENFOLDERS;
                LayoutExtractRight.RowStyles[0].Height = 28.57F;
                LayoutExtractRight.RowStyles[1].Height = 28.57F;
                LayoutExtractRight.RowStyles[2].Height = 28.57F;
                LayoutExtractRight.RowStyles[3].Height = 14.29F;
                ShowScrollBar(FlowLayoutPanelExtract.Handle, 3, false);
            }
            else
            {
                using (var msg = new MyMessageDialog("No portraits matching the expected dimensions for the selected game were found in the archive.\nMake sure you have the correct game selected."))
                {
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog();
                }
            }
        }

        // SharpCompress's managed .7z decoder is noticeably slower and, on some archives,
        // unreliable (non-deterministic load time, occasional crashes). A real 7-Zip install
        // (native, battle-tested) is both faster and more robust, so prefer it when present and
        // only fall back to the managed decoder if 7-Zip isn't installed. .rar keeps using
        // SharpCompress unconditionally since it's fine there.
        private static string FindNative7ZipExecutable()
        {
            try
            {
                using (var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\7-Zip") ??
                                  Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\7-Zip"))
                {
                    var path = key?.GetValue("Path") as string;
                    if (!string.IsNullOrEmpty(path))
                    {
                        string exe = Path.Combine(path, "7z.exe");
                        if (File.Exists(exe)) return exe;
                    }
                }
            }
            catch { }

            string[] candidates =
            {
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "7-Zip", "7z.exe"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "7-Zip", "7z.exe"),
            };
            foreach (var candidate in candidates)
                if (File.Exists(candidate)) return candidate;

            return null;
        }

        private static bool TryExtractWithNative7Zip(string archivePath, string destDir)
        {
            string exe = FindNative7ZipExecutable();
            if (exe == null) return false;

            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = exe,
                    Arguments = "x \"" + archivePath + "\" -o\"" + destDir + "\" -y -bd -bso0 -bse0",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                };

                using (var proc = Process.Start(psi))
                {
                    bool exited = proc.WaitForExit(120000);
                    if (!exited)
                    {
                        try { proc.Kill(); } catch { }
                        return false;
                    }
                    return proc.ExitCode == 0;
                }
            }
            catch
            {
                return false;
            }
        }

        private void ExtractArchive(string archivePath, string destDir)
        {
            string ext = Path.GetExtension(archivePath).ToLowerInvariant();
            if (ext == ".7z" && TryExtractWithNative7Zip(archivePath, destDir))
                return;

            using (var archive = ArchiveFactory.Open(archivePath))
            {
                foreach (var entry in archive.Entries.Where(e => !e.IsDirectory))
                    entry.WriteToDirectory(destDir, new ExtractionOptions
                    {
                        ExtractFullPath = true,
                        Overwrite = true
                    });
            }
        }

        private void LoadFolderThumbnails(string folderPath, int depth = 0)
        {
            if (depth > 50) return;

            if (_gameSelected == 't')
            {
                foreach (var file in Directory.GetFiles(folderPath, "*_lg.png"))
                {
                    try
                    {
                        string baseName = Path.GetFileNameWithoutExtension(file);
                        string key = baseName.EndsWith("_lg", StringComparison.OrdinalIgnoreCase)
                            ? baseName.Substring(0, baseName.Length - 3)
                            : baseName;
                        Image img = Image.FromFile(file);
                        if (IsValidPortraitSize(img.Size))
                        {
                            AddArchiveThumbnail(key, img);
                        }
                        img.Dispose();
                    }
                    catch { }
                }

                foreach (var subDir in Directory.GetDirectories(folderPath))
                    LoadFolderThumbnails(subDir, depth + 1);
            }
            else if (_gameSelected == 'l')
            {
                foreach (var file in Directory.GetFiles(folderPath).Where(f => IsImageFile(f)))
                {
                    try
                    {
                        string key = Path.GetFileNameWithoutExtension(file);
                        Image img = Image.FromFile(file);
                        if (IsValidPortraitSize(img.Size))
                        {
                            AddArchiveThumbnail(key, img);
                        }
                        img.Dispose();
                    }
                    catch { }
                }

                foreach (var subDir in Directory.GetDirectories(folderPath))
                    LoadFolderThumbnails(subDir, depth + 1);
            }
            else if (_gameSelected == 'p' || _gameSelected == 'd')
            {
                foreach (var file in Directory.GetFiles(folderPath, "*_lg.png"))
                {
                    try
                    {
                        string baseName = Path.GetFileNameWithoutExtension(file);
                        string key = baseName.EndsWith("_lg", StringComparison.OrdinalIgnoreCase)
                            ? baseName.Substring(0, baseName.Length - 3)
                            : baseName;
                        string dir = Path.GetDirectoryName(file);
                        bool hasAllCompanions;
                        if (_gameSelected == 'd')
                            hasAllCompanions = File.Exists(Path.Combine(dir, key + "_sm.png")) &&
                                               File.Exists(Path.Combine(dir, key + "_si.png")) &&
                                               File.Exists(Path.Combine(dir, key + "_convo.png"));
                        else
                            hasAllCompanions = File.Exists(Path.Combine(dir, key + "_sm.png"));

                        Image img = Image.FromFile(file);
                        if (IsValidPortraitSize(img.Size))
                        {
                            AddArchiveThumbnail(key, img, hasAllCompanions);
                        }
                        img.Dispose();
                    }
                    catch { }
                }

                foreach (var subDir in Directory.GetDirectories(folderPath))
                    LoadFolderThumbnails(subDir, depth + 1);
            }
            else
            {
                bool HasRequiredFiles(string dir)
                {
                    var names = Directory.GetFiles(dir)
                        .Select(Path.GetFileName)
                        .ToHashSet(StringComparer.OrdinalIgnoreCase);
                    return names.Contains("Fulllength.png") &&
                           names.Contains("Medium.png") &&
                           names.Contains("Small.png");
                }

                void TryAddPack(string dir)
                {
                    var imgFiles = Directory.GetFiles(dir).Where(f => IsImageFile(f)).ToList();
                    if (imgFiles.Count == 0) return;
                    string bestFile = imgFiles.FirstOrDefault(f =>
                        Path.GetFileName(f).Equals("Fulllength.png", StringComparison.OrdinalIgnoreCase))
                        ?? imgFiles[0];
                    try
                    {
                        Image img = Image.FromFile(bestFile);
                        if (IsValidPortraitSize(img.Size))
                            AddArchiveThumbnail(dir, img);
                        img.Dispose();
                    }
                    catch { }
                }

                if (HasRequiredFiles(folderPath))
                    TryAddPack(folderPath);

                foreach (var subDir in Directory.GetDirectories(folderPath))
                {
                    if (HasRequiredFiles(subDir))
                    {
                        TryAddPack(subDir);
                    }
                    else
                    {
                        LoadFolderThumbnails(subDir, depth + 1);
                    }
                }
            }
        }

        private void CleanupShellTempDir()
        {
            if (!string.IsNullOrEmpty(_shellTempDir))
            {
                try { Directory.Delete(_shellTempDir, true); } catch { }
                _shellTempDir = null;
            }
        }

        private string GetUniqueFolderPath(string baseDir, string folderName, out bool conflicted)
        {
            string path = Path.Combine(baseDir, folderName);
            if (!Directory.Exists(path))
            {
                conflicted = false;
                return path;
            }
            conflicted = true;
            string timestamp = DateTime.Now.ToString("\\_ssddMM");
            path = Path.Combine(baseDir, folderName + timestamp);
            int counter = 1;
            while (Directory.Exists(path))
            {
                path = Path.Combine(baseDir, folderName + timestamp + "_" + counter);
                counter++;
            }
            return path;
        }

        private bool ExtractTyrannyPortraits(List<string> selectedKeys, string gamePath)
        {
            string maleDir = Path.Combine(gamePath, "Tyranny_Data", "data", "art", "gui", "portraits", "player", "male");
            string femaleDir = Path.Combine(gamePath, "Tyranny_Data", "data", "art", "gui", "portraits", "player", "female");
            Directory.CreateDirectory(maleDir);
            Directory.CreateDirectory(femaleDir);

            int count = 0;
            int conflictCount = 0;
            int sizeInvalidCount = 0;
            string ext = Path.GetExtension(_selectedArchivePath).ToLowerInvariant();

            try
            {
                HashSet<string> keys = selectedKeys == null ? null : new HashSet<string>(selectedKeys);

                if (ext == ".zip")
                {
                    using (ZipArchive archive = ZipFile.OpenRead(_selectedArchivePath))
                    {
                        var entries = archive.Entries.Where(e => !e.FullName.EndsWith("/")).ToList();
                        var lgEntries = entries.Where(e => e.Name.EndsWith("_lg.png", StringComparison.OrdinalIgnoreCase)).ToList();

                        foreach (var lgEntry in lgEntries)
                        {
                            string baseName = Path.GetFileNameWithoutExtension(lgEntry.Name);
                            string key = baseName.EndsWith("_lg", StringComparison.OrdinalIgnoreCase)
                                ? baseName.Substring(0, baseName.Length - 3)
                                : baseName;

                            if (keys != null && !keys.Contains(key))
                                continue;

                            string suffix = File.Exists(Path.Combine(maleDir, lgEntry.Name))
                                ? DateTime.Now.ToString("_ssddMM") : "";
                            if (!string.IsNullOrEmpty(suffix)) conflictCount++;
                            string lgName = key + suffix + "_lg.png";
                            string smName = key + suffix + "_sm.png";

                            var smEntry = entries.FirstOrDefault(e =>
                                e.Name.Equals(key + "_sm.png", StringComparison.OrdinalIgnoreCase));

                            string lgDest = Path.Combine(maleDir, lgName);
                            lgEntry.ExtractToFile(lgDest, overwrite: true);
                            bool hadInvalid = false;
                            ValidatePortraitSize(lgDest, ref hadInvalid);

                            string smDest = null;
                            if (smEntry != null)
                            {
                                smDest = Path.Combine(maleDir, smName);
                                smEntry.ExtractToFile(smDest, overwrite: true);
                                ValidatePortraitSize(smDest, ref hadInvalid);
                            }

                            if (hadInvalid)
                            {
                                try { File.Delete(lgDest); } catch { }
                                if (smDest != null) try { File.Delete(smDest); } catch { }
                                sizeInvalidCount++;
                                continue;
                            }

                            File.Copy(lgDest, Path.Combine(femaleDir, lgName), overwrite: true);
                            if (smDest != null)
                                File.Copy(smDest, Path.Combine(femaleDir, smName), overwrite: true);
                            count++;
                        }
                    }
                }
                else if (ext == ".7z" || ext == ".rar")
                {
                    if (string.IsNullOrEmpty(_shellTempDir) || !Directory.Exists(_shellTempDir))
                    {
                        using (var msg = new MyMessageDialog("Archive contents not found. Please reload the archive."))
                        {
                            msg.StartPosition = FormStartPosition.CenterParent;
                            msg.ShowDialog();
                        }
                        return false;
                    }

                    var lgFiles = Directory.GetFiles(_shellTempDir, "*_lg.png", SearchOption.AllDirectories);
                    foreach (var lgFile in lgFiles)
                    {
                        string baseName = Path.GetFileNameWithoutExtension(lgFile);
                        string key = baseName.EndsWith("_lg", StringComparison.OrdinalIgnoreCase)
                            ? baseName.Substring(0, baseName.Length - 3)
                            : baseName;

                        if (keys != null && !keys.Contains(key))
                            continue;

                        string suffix = File.Exists(Path.Combine(maleDir, key + "_lg.png"))
                            ? DateTime.Now.ToString("_ssddMM") : "";
                        if (!string.IsNullOrEmpty(suffix)) conflictCount++;
                        string lgName = key + suffix + "_lg.png";
                        string smName = key + suffix + "_sm.png";

                        string dir = Path.GetDirectoryName(lgFile);
                        string smFile = Path.Combine(dir, key + "_sm.png");

                        string lgDest = Path.Combine(maleDir, lgName);
                        File.Copy(lgFile, lgDest, overwrite: true);
                        bool hadInvalid = false;
                        ValidatePortraitSize(lgDest, ref hadInvalid);

                        string smDest = null;
                        if (File.Exists(smFile))
                        {
                            smDest = Path.Combine(maleDir, smName);
                            File.Copy(smFile, smDest, overwrite: true);
                            ValidatePortraitSize(smDest, ref hadInvalid);
                        }

                        if (hadInvalid)
                        {
                            try { File.Delete(lgDest); } catch { }
                            if (smDest != null) try { File.Delete(smDest); } catch { }
                            sizeInvalidCount++;
                            continue;
                        }

                        File.Copy(lgDest, Path.Combine(femaleDir, lgName), overwrite: true);
                        if (smDest != null)
                            File.Copy(smDest, Path.Combine(femaleDir, smName), overwrite: true);
                        count++;
                    }
                }
                else
                {
                    var lgFiles = Directory.GetFiles(_selectedArchivePath, "*_lg.png", SearchOption.AllDirectories);
                    foreach (var lgFile in lgFiles)
                    {
                        string baseName = Path.GetFileNameWithoutExtension(lgFile);
                        string key = baseName.EndsWith("_lg", StringComparison.OrdinalIgnoreCase)
                            ? baseName.Substring(0, baseName.Length - 3)
                            : baseName;

                        if (keys != null && !keys.Contains(key))
                            continue;

                        string suffix = File.Exists(Path.Combine(maleDir, key + "_lg.png"))
                            ? DateTime.Now.ToString("_ssddMM") : "";
                        if (!string.IsNullOrEmpty(suffix)) conflictCount++;
                        string lgName = key + suffix + "_lg.png";
                        string smName = key + suffix + "_sm.png";

                        string dir = Path.GetDirectoryName(lgFile);
                        string smFile = Path.Combine(dir, key + "_sm.png");

                        string lgDest = Path.Combine(maleDir, lgName);
                        File.Copy(lgFile, lgDest, overwrite: true);
                        bool hadInvalid = false;
                        ValidatePortraitSize(lgDest, ref hadInvalid);

                        string smDest = null;
                        if (File.Exists(smFile))
                        {
                            smDest = Path.Combine(maleDir, smName);
                            File.Copy(smFile, smDest, overwrite: true);
                            ValidatePortraitSize(smDest, ref hadInvalid);
                        }

                        if (hadInvalid)
                        {
                            try { File.Delete(lgDest); } catch { }
                            if (smDest != null) try { File.Delete(smDest); } catch { }
                            sizeInvalidCount++;
                            continue;
                        }

                        File.Copy(lgDest, Path.Combine(femaleDir, lgName), overwrite: true);
                        if (smDest != null)
                            File.Copy(smDest, Path.Combine(femaleDir, smName), overwrite: true);
                        count++;
                    }
                }

                string msgText;
                if (conflictCount > 0)
                    msgText = string.Format(TextVariables.MESG_EXTRACT_CONFLICT, count, conflictCount);
                else if (sizeInvalidCount > 0)
                    msgText = string.Format(TextVariables.MESG_EXTRACT_SUCCESS, count) + $"\nSkipped {sizeInvalidCount} set(s) with invalid portrait dimensions.";
                else
                    msgText = string.Format(TextVariables.MESG_EXTRACT_SUCCESS, count);
                using (var msg = new MyMessageDialog(msgText))
                {
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog();
                }
                return count > 0;
            }
            catch (Exception ex)
            {
                using (var msg = new MyMessageDialog("Extraction failed: " + ex.Message))
                {
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog();
                }
                return false;
            }
        }

        private bool ExtractWastelandPortraits(List<string> selectedKeys, string gamePath)
        {
            string outDir = Path.Combine(gamePath, "Custom Portraits");
            Directory.CreateDirectory(outDir);

            int count = 0;
            int conflictCount = 0;
            int sizeInvalidCount = 0;
            string ext = Path.GetExtension(_selectedArchivePath).ToLowerInvariant();

            try
            {
                HashSet<string> keys = selectedKeys == null ? null : new HashSet<string>(selectedKeys);

                if (ext == ".zip")
                {
                    using (ZipArchive archive = ZipFile.OpenRead(_selectedArchivePath))
                    {
                        var imgEntries = archive.Entries
                            .Where(e => !e.FullName.EndsWith("/") && e.Name.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                            .ToList();

                        foreach (var entry in imgEntries)
                        {
                            string key = Path.GetFileNameWithoutExtension(entry.Name);

                            if (keys != null && !keys.Contains(key))
                                continue;

                            string destFile = Path.Combine(outDir, entry.Name);
                            string suffix = File.Exists(destFile)
                                ? DateTime.Now.ToString("_ssddMM") : "";
                            if (!string.IsNullOrEmpty(suffix)) conflictCount++;

                            string finalName = key + suffix + ".png";
                            string finalPath = Path.Combine(outDir, finalName);
                            entry.ExtractToFile(finalPath, overwrite: true);
                            bool hadInvalid = false;
                            ValidatePortraitSize(finalPath, ref hadInvalid);
                            if (hadInvalid)
                            {
                                sizeInvalidCount++;
                                continue;
                            }
                            count++;
                        }
                    }
                }
                else if (ext == ".7z" || ext == ".rar")
                {
                    if (string.IsNullOrEmpty(_shellTempDir) || !Directory.Exists(_shellTempDir))
                    {
                        using (var msg = new MyMessageDialog("Archive contents not found. Please reload the archive."))
                        {
                            msg.StartPosition = FormStartPosition.CenterParent;
                            msg.ShowDialog();
                        }
                        return false;
                    }

                    var imgFiles = Directory.GetFiles(_shellTempDir, "*", SearchOption.AllDirectories)
                        .Where(f => f.EndsWith(".png", StringComparison.OrdinalIgnoreCase)).ToList();
                    foreach (var file in imgFiles)
                    {
                        string key = Path.GetFileNameWithoutExtension(file);

                        if (keys != null && !keys.Contains(key))
                            continue;

                        string destFile = Path.Combine(outDir, key + ".png");
                        string suffix = File.Exists(destFile)
                            ? DateTime.Now.ToString("_ssddMM") : "";
                        if (!string.IsNullOrEmpty(suffix)) conflictCount++;

                        string finalName = key + suffix + ".png";
                        string finalPath = Path.Combine(outDir, finalName);
                        File.Copy(file, finalPath, overwrite: true);
                        bool hadInvalid = false;
                        ValidatePortraitSize(finalPath, ref hadInvalid);
                        if (hadInvalid)
                        {
                            sizeInvalidCount++;
                            continue;
                        }
                        count++;
                    }
                }
                else
                {
                    var imgFiles = Directory.GetFiles(_selectedArchivePath, "*", SearchOption.AllDirectories)
                        .Where(f => f.EndsWith(".png", StringComparison.OrdinalIgnoreCase)).ToList();
                    foreach (var file in imgFiles)
                    {
                        string key = Path.GetFileNameWithoutExtension(file);

                        if (keys != null && !keys.Contains(key))
                            continue;

                        string destFile = Path.Combine(outDir, key + ".png");
                        string suffix = File.Exists(destFile)
                            ? DateTime.Now.ToString("_ssddMM") : "";
                        if (!string.IsNullOrEmpty(suffix)) conflictCount++;

                        string finalName = key + suffix + ".png";
                        string finalPath = Path.Combine(outDir, finalName);
                        File.Copy(file, finalPath, overwrite: true);
                        bool hadInvalid = false;
                        ValidatePortraitSize(finalPath, ref hadInvalid);
                        if (hadInvalid)
                        {
                            sizeInvalidCount++;
                            continue;
                        }
                        count++;
                    }
                }

                string msgText;
                if (conflictCount > 0)
                    msgText = string.Format(TextVariables.MESG_EXTRACT_CONFLICT, count, conflictCount);
                else if (sizeInvalidCount > 0)
                    msgText = string.Format(TextVariables.MESG_EXTRACT_SUCCESS, count) + $"\nSkipped {sizeInvalidCount} file(s) with invalid portrait dimensions.";
                else
                    msgText = string.Format(TextVariables.MESG_EXTRACT_SUCCESS, count);
                using (var msg = new MyMessageDialog(msgText))
                {
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog();
                }
                return count > 0;
            }
            catch (Exception ex)
            {
                using (var msg = new MyMessageDialog("Extraction failed: " + ex.Message))
                {
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog();
                }
                return false;
            }
        }

        private bool ExtractObsidianPortraits(List<string> selectedKeys, string gamePath, string dataSubPath, string[] sizeSuffixes)
        {
            string maleDir = Path.Combine(gamePath, dataSubPath, "male");
            string femaleDir = Path.Combine(gamePath, dataSubPath, "female");
            Directory.CreateDirectory(maleDir);
            Directory.CreateDirectory(femaleDir);

            int count = 0;
            int conflictCount = 0;
            int partialCount = 0;
            int sizeInvalidCount = 0;
            string ext = Path.GetExtension(_selectedArchivePath).ToLowerInvariant();

            try
            {
                HashSet<string> keys = selectedKeys == null ? null : new HashSet<string>(selectedKeys);

                if (ext == ".zip")
                {
                    using (ZipArchive archive = ZipFile.OpenRead(_selectedArchivePath))
                    {
                        var lgEntries = archive.Entries
                            .Where(e => e.Name.EndsWith("_lg.png", StringComparison.OrdinalIgnoreCase)).ToList();

                        foreach (var lgEntry in lgEntries)
                        {
                            string baseName = Path.GetFileNameWithoutExtension(lgEntry.Name);
                            string key = baseName.EndsWith("_lg", StringComparison.OrdinalIgnoreCase)
                                ? baseName.Substring(0, baseName.Length - 3)
                                : baseName;

                            if (keys != null && !keys.Contains(key))
                                continue;

                            string suffix = File.Exists(Path.Combine(maleDir, key + "_lg.png"))
                                ? DateTime.Now.ToString("_ssddMM") : "";
                            if (!string.IsNullOrEmpty(suffix)) conflictCount++;

                            bool wroteAny = false;
                            int foundCount = 0;
                            bool hadInvalid = false;
                            var writtenFiles = new List<string>();
                            foreach (var sz in sizeSuffixes)
                            {
                                var entry = archive.Entries.FirstOrDefault(e =>
                                    e.Name.Equals(key + "_" + sz + ".png", StringComparison.OrdinalIgnoreCase) &&
                                    !e.FullName.EndsWith("/"));
                                if (entry == null) continue;

                                string finalName = key + suffix + "_" + sz + ".png";
                                string malePath = Path.Combine(maleDir, finalName);
                                entry.ExtractToFile(malePath, overwrite: true);
                                ValidatePortraitSize(malePath, ref hadInvalid);
                                writtenFiles.Add(malePath);
                                wroteAny = true;
                                foundCount++;
                            }

                            if (hadInvalid)
                            {
                                foreach (var f in writtenFiles)
                                    try { File.Delete(f); } catch { }
                                sizeInvalidCount++;
                                continue;
                            }

                            foreach (var maleFile in writtenFiles)
                            {
                                string femalePath = Path.Combine(femaleDir, Path.GetFileName(maleFile));
                                File.Copy(maleFile, femalePath, overwrite: true);
                            }

                            if (wroteAny)
                            {
                                count++;
                                if (foundCount < sizeSuffixes.Length) partialCount++;
                            }
                        }
                    }
                }
                else if (ext == ".7z" || ext == ".rar")
                {
                    if (string.IsNullOrEmpty(_shellTempDir) || !Directory.Exists(_shellTempDir))
                    {
                        using (var msg = new MyMessageDialog("Archive contents not found. Please reload the archive."))
                        {
                            msg.StartPosition = FormStartPosition.CenterParent;
                            msg.ShowDialog();
                        }
                        return false;
                    }

                    var lgFiles = Directory.GetFiles(_shellTempDir, "*_lg.png", SearchOption.AllDirectories);
                    foreach (var lgFile in lgFiles)
                    {
                        string baseName = Path.GetFileNameWithoutExtension(lgFile);
                        string key = baseName.EndsWith("_lg", StringComparison.OrdinalIgnoreCase)
                            ? baseName.Substring(0, baseName.Length - 3)
                            : baseName;

                        if (keys != null && !keys.Contains(key))
                            continue;

                        string suffix = File.Exists(Path.Combine(maleDir, key + "_lg.png"))
                            ? DateTime.Now.ToString("_ssddMM") : "";
                        if (!string.IsNullOrEmpty(suffix)) conflictCount++;

                        string dir = Path.GetDirectoryName(lgFile);
                        bool wroteAny = false;
                        int foundCount = 0;
                        bool hadInvalid = false;
                        var writtenFiles = new List<string>();
                        foreach (var sz in sizeSuffixes)
                        {
                            string srcFile = Path.Combine(dir, key + "_" + sz + ".png");
                            if (!File.Exists(srcFile)) continue;

                            string finalName = key + suffix + "_" + sz + ".png";
                            string malePath = Path.Combine(maleDir, finalName);
                            File.Copy(srcFile, malePath, overwrite: true);
                            ValidatePortraitSize(malePath, ref hadInvalid);
                            writtenFiles.Add(malePath);
                            wroteAny = true;
                            foundCount++;
                        }

                        if (hadInvalid)
                        {
                            foreach (var f in writtenFiles)
                                try { File.Delete(f); } catch { }
                            sizeInvalidCount++;
                            continue;
                        }

                        foreach (var maleFile in writtenFiles)
                        {
                            string femalePath = Path.Combine(femaleDir, Path.GetFileName(maleFile));
                            File.Copy(maleFile, femalePath, overwrite: true);
                        }

                        if (wroteAny)
                        {
                            count++;
                            if (foundCount < sizeSuffixes.Length) partialCount++;
                        }
                    }
                }
                else
                {
                    var lgFiles = Directory.GetFiles(_selectedArchivePath, "*_lg.png", SearchOption.AllDirectories);
                    foreach (var lgFile in lgFiles)
                    {
                        string baseName = Path.GetFileNameWithoutExtension(lgFile);
                        string key = baseName.EndsWith("_lg", StringComparison.OrdinalIgnoreCase)
                            ? baseName.Substring(0, baseName.Length - 3)
                            : baseName;

                        if (keys != null && !keys.Contains(key))
                            continue;

                        string suffix = File.Exists(Path.Combine(maleDir, key + "_lg.png"))
                            ? DateTime.Now.ToString("_ssddMM") : "";
                        if (!string.IsNullOrEmpty(suffix)) conflictCount++;

                        string dir = Path.GetDirectoryName(lgFile);
                        bool wroteAny = false;
                        int foundCount = 0;
                        bool hadInvalid = false;
                        var writtenFiles = new List<string>();
                        foreach (var sz in sizeSuffixes)
                        {
                            string srcFile = Path.Combine(dir, key + "_" + sz + ".png");
                            if (!File.Exists(srcFile)) continue;

                            string finalName = key + suffix + "_" + sz + ".png";
                            string malePath = Path.Combine(maleDir, finalName);
                            File.Copy(srcFile, malePath, overwrite: true);
                            ValidatePortraitSize(malePath, ref hadInvalid);
                            writtenFiles.Add(malePath);
                            wroteAny = true;
                            foundCount++;
                        }

                        if (hadInvalid)
                        {
                            foreach (var f in writtenFiles)
                                try { File.Delete(f); } catch { }
                            sizeInvalidCount++;
                            continue;
                        }

                        foreach (var maleFile in writtenFiles)
                        {
                            string femalePath = Path.Combine(femaleDir, Path.GetFileName(maleFile));
                            File.Copy(maleFile, femalePath, overwrite: true);
                        }

                        if (wroteAny)
                        {
                            count++;
                            if (foundCount < sizeSuffixes.Length) partialCount++;
                        }
                    }
                }

                string msgText;
                if (conflictCount > 0)
                    msgText = string.Format(TextVariables.MESG_EXTRACT_CONFLICT, count, conflictCount);
                else if (sizeInvalidCount > 0)
                    msgText = string.Format(TextVariables.MESG_EXTRACT_SUCCESS, count) + $"\nSkipped {sizeInvalidCount} set(s) with invalid portrait dimensions.";
                else if (partialCount > 0)
                    msgText = string.Format(TextVariables.MESG_EXTRACT_PARTIAL, count, partialCount);
                else
                    msgText = string.Format(TextVariables.MESG_EXTRACT_SUCCESS, count);
                using (var msg = new MyMessageDialog(msgText))
                {
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog();
                }
                return count > 0;
            }
            catch (Exception ex)
            {
                using (var msg = new MyMessageDialog("Extraction failed: " + ex.Message))
                {
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog();
                }
                return false;
            }
        }

        private bool ExtractPortraitsFromArchive(List<string> selectedKeys)
        {
            if (string.IsNullOrEmpty(_selectedArchivePath) || _archiveEntries == null)
                return false;

            string portraitsDir = CoreSettings.Default.GamePath;
            if (string.IsNullOrEmpty(portraitsDir) || portraitsDir == "0")
            {
                using (var msg = new MyMessageDialog("Game path not set. Please configure the game path first."))
                {
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog();
                }
                return false;
            }

            if (_gameSelected == 't')
            {
                bool result = ExtractTyrannyPortraits(selectedKeys, portraitsDir);
                CleanupShellTempDir();
                return result;
            }

            if (_gameSelected == 'l')
            {
                bool result = ExtractWastelandPortraits(selectedKeys, portraitsDir);
                CleanupShellTempDir();
                return result;
            }

            if (_gameSelected == 'p')
            {
                bool result = ExtractObsidianPortraits(selectedKeys, portraitsDir,
                    @"PillarsOfEternity_Data\data\art\gui\portraits\player", new[] { "lg", "sm" });
                CleanupShellTempDir();
                return result;
            }

            if (_gameSelected == 'd')
            {
                bool result = ExtractObsidianPortraits(selectedKeys, portraitsDir,
                    @"PillarsOfEternityII_Data\gui\portraits\player", new[] { "lg", "sm", "si", "convo" });
                CleanupShellTempDir();
                return result;
            }

            string extractDir = Path.Combine(portraitsDir, "Portraits");
            Directory.CreateDirectory(extractDir);

            int count = 0;
            int conflictCount = 0;
            int skippedCount = 0;
            int sizeInvalidCount = 0;
            string ext = Path.GetExtension(_selectedArchivePath).ToLowerInvariant();

            try
            {
                if (ext == ".zip")
                {
                    using (ZipArchive archive = ZipFile.OpenRead(_selectedArchivePath))
                    {
                        var folders = archive.Entries
                            .Where(e => !e.FullName.EndsWith("/"))
                            .GroupBy(e => Path.GetDirectoryName(e.FullName).Replace("\\", "/"))
                            .ToList();

                        foreach (var folder in folders)
                        {
                            string rawKey = string.IsNullOrEmpty(folder.Key)
                                ? Path.GetFileNameWithoutExtension(_selectedArchivePath) + "_flat"
                                : folder.Key;
                            string folderName = Path.GetFileName(rawKey);
                            if (selectedKeys != null && !selectedKeys.Contains(rawKey))
                                continue;

                            string targetFolder = GetUniqueFolderPath(extractDir, folderName, out bool conflicted);
                            Directory.CreateDirectory(targetFolder);
                            if (conflicted) conflictCount++;

                            var fileNames = folder
                                .Select(e => Path.GetFileName(e.Name))
                                .Where(n => !string.IsNullOrEmpty(n))
                                .ToHashSet(StringComparer.OrdinalIgnoreCase);
                            if (!fileNames.Contains("Fulllength.png") ||
                                !fileNames.Contains("Medium.png") ||
                                !fileNames.Contains("Small.png"))
                            {
                                skippedCount++;
                                continue;
                            }

                            bool hadInvalid = false;
                            foreach (var entry in folder.Where(e => !string.IsNullOrEmpty(Path.GetFileName(e.Name)) && IsImageFile(e.Name)))
                            {
                                string fileName = Path.GetFileName(entry.Name);
                                string destPath = Path.Combine(targetFolder, fileName);
                                entry.ExtractToFile(destPath, overwrite: true);
                                ValidatePortraitSize(destPath, ref hadInvalid);
                            }
                            if (hadInvalid)
                            {
                                try { Directory.Delete(targetFolder, true); } catch { }
                                sizeInvalidCount++;
                                continue;
                            }
                            count++;
                        }
                    }
                }
                else if (ext == ".7z" || ext == ".rar")
                {
                    if (string.IsNullOrEmpty(_shellTempDir) || !Directory.Exists(_shellTempDir))
                    {
                        using (var msg = new MyMessageDialog("Archive contents not found. Please reload the archive."))
                        {
                            msg.StartPosition = FormStartPosition.CenterParent;
                            msg.ShowDialog();
                        }
                        return false;
                    }

                    void RecursiveExtractOwlcatDir(string dir)
                    {
                        var fileNames = Directory.GetFiles(dir)
                            .Select(Path.GetFileName)
                            .ToHashSet(StringComparer.OrdinalIgnoreCase);
                        bool hasAllFiles = fileNames.Contains("Fulllength.png") &&
                                           fileNames.Contains("Medium.png") &&
                                           fileNames.Contains("Small.png");

                        if (hasAllFiles)
                        {
                            string folderName = Path.GetFileName(dir);
                            if (selectedKeys == null || selectedKeys.Contains(dir))
                            {
                                string targetFolder = GetUniqueFolderPath(extractDir, folderName, out bool conflicted);
                                Directory.CreateDirectory(targetFolder);
                                if (conflicted) conflictCount++;

                                bool hadInvalid = false;
                                foreach (var file in Directory.GetFiles(dir))
                                {
                                    string destPath = Path.Combine(targetFolder, Path.GetFileName(file));
                                    File.Copy(file, destPath, overwrite: true);
                                    ValidatePortraitSize(destPath, ref hadInvalid);
                                }
                                if (hadInvalid)
                                {
                                    try { Directory.Delete(targetFolder, true); } catch { }
                                    sizeInvalidCount++;
                                    return;
                                }
                                count++;
                            }
                            return;
                        }

                        foreach (var subDir in Directory.GetDirectories(dir))
                            RecursiveExtractOwlcatDir(subDir);
                    }

                    RecursiveExtractOwlcatDir(_shellTempDir);
                }
                else
                {
                    void RecursiveExtractFolder(string folder)
                    {
                        bool hasRequired;
                        try
                        {
                            var files = Directory.GetFiles(folder).Select(Path.GetFileName).ToHashSet(StringComparer.OrdinalIgnoreCase);
                            hasRequired = files.Contains("Fulllength.png") &&
                                          files.Contains("Medium.png") &&
                                          files.Contains("Small.png");
                        }
                        catch
                        {
                            hasRequired = false;
                        }

                        if (hasRequired)
                        {
                            if (selectedKeys != null && !selectedKeys.Contains(folder))
                                return;

                            string folderName = Path.GetFileName(folder);
                            string targetFolder = GetUniqueFolderPath(extractDir, folderName, out bool conflicted);
                            Directory.CreateDirectory(targetFolder);
                            if (conflicted) conflictCount++;

                            bool hadInvalid = false;
                            foreach (var file in Directory.GetFiles(folder).Where(f => IsImageFile(f)))
                            {
                                string destPath = Path.Combine(targetFolder, Path.GetFileName(file));
                                File.Copy(file, destPath, overwrite: true);
                                ValidatePortraitSize(destPath, ref hadInvalid);
                            }
                            if (hadInvalid)
                            {
                                try { Directory.Delete(targetFolder, true); } catch { }
                                sizeInvalidCount++;
                                return;
                            }
                            count++;
                            return;
                        }

                        foreach (var subDir in Directory.GetDirectories(folder))
                            RecursiveExtractFolder(subDir);
                    }

                    RecursiveExtractFolder(_selectedArchivePath);
                }

                string conflictMsg = conflictCount > 0
                    ? string.Format(TextVariables.MESG_EXTRACT_CONFLICT, count, conflictCount)
                    : string.Format(TextVariables.MESG_EXTRACT_SUCCESS, count);
                string msgText = conflictMsg;
                if (skippedCount > 0)
                    msgText += $"\nSkipped {skippedCount} incomplete set(s) (missing Fulllength.png, Medium.png, or Small.png).";
                if (sizeInvalidCount > 0)
                    msgText += $"\nSkipped {sizeInvalidCount} set(s) with invalid portrait dimensions.";
                using (var msg = new MyMessageDialog(msgText))
                {
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog();
                }
                return count > 0;
            }
            catch (Exception ex)
            {
                using (var msg = new MyMessageDialog("Extraction failed: " + ex.Message))
                {
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog();
                }
                return false;
            }
            finally
            {
                CleanupShellTempDir();
            }
        }
    }
}
