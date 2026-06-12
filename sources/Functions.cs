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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortraitManager
{
    public partial class MainForm : Form
    {
        public void RestoreFilePageToInit()
        {
            _imageSelectionFlag = 0;
            _isAnyLoadedToPortraitPage = false;
            //ButtonNextImageType.Visible = true;
            //ButtonNextImageType.Enabled = true;       
            ////ButtonNextImageType.Text = TextVariables.BUTTON_ADVANCED;
            //LblToAdvancedPage.Visible = true;
        }

        public void AddClickEventsToMainButtons()
        {
            //RootFunctions.AddClickEvent(ButtonToFilePage, ButtonToFilePage_Click);
            //RootFunctions.AddClickEvent(ButtonToExtractPage, ButtonToExtract_Click);
            //RootFunctions.AddClickEvent(ButtonToGalleryPage, ButtonToGalleryPage_Click);
        }

        public void RemoveClickEventsFromMainButtons()
        {
            //RootFunctions.RemoveClickEvent(ButtonToFilePage, ButtonToFilePage_Click);
            //RootFunctions.RemoveClickEvent(ButtonToExtractPage, ButtonToExtract_Click);
            //RootFunctions.RemoveClickEvent(ButtonToGalleryPage, ButtonToGalleryPage_Click);
        }

        public void AddClickEventsToCustomPortraitsButtons()
        {
            //RootFunctions.AddClickEvent(ButtonLoadCustom, ButtonLoadCustom_Click);
            //RootFunctions.AddClickEvent(ButtonLoadCustomNPC, ButtonLoadCustomNPC_Click);
            //RootFunctions.AddClickEvent(ButtonLoadCustomArmy, ButtonLoadCustomArmy_Click);
        }

        public void RemoveClickEventsFromCustomPortraitsButtons()
        {
            //RootFunctions.RemoveClickEvent(ButtonLoadCustom, ButtonLoadCustom_Click);
            //RootFunctions.RemoveClickEvent(ButtonLoadCustomNPC, ButtonLoadCustomNPC_Click);
            //RootFunctions.RemoveClickEvent(ButtonLoadCustomArmy, ButtonLoadCustomArmy_Click);
        }
        
        public void ClearPictureBoxImages(Image replacement)
        {
            //ImageControl.Utils.Replace(PicPortraitTemp, replacement);
            //ImageControl.Utils.Replace(PicPortraitLrg, replacement);
            //ImageControl.Utils.Replace(PicPortraitMed, replacement);
            //ImageControl.Utils.Replace(PicPortraitSml, replacement);
        }
        
        public void DisposePrimeImages()
        {
            //ImageControl.Utils.Dispose(PicPortraitTemp);
            //ImageControl.Utils.Dispose(PicPortraitLrg);
            //ImageControl.Utils.Dispose(PicPortraitMed);
            //ImageControl.Utils.Dispose(PicPortraitSml);
        }
       
        public void ResizeImageToParentControl(Control control, Image image, Control parent)
        {
            // Only allow automatic resizing when explicitly enabled (to avoid resizing on group changes)
            if (!_allowAutoResize)
            {
                return;
            }
            float aspect = control.Height * 1.0f / control.Width * 1.0f;
            Tuple<int, int> newSize = CalculateNewSize(parent, aspect);

            if (control is PictureBox pictureBox)
            {
                pictureBox.Image = ImageControl.Direct.Resize(image, newSize.Item1, newSize.Item2);
            }

            DisableAutoScroll(parent, newSize.Item1, newSize.Item2);
        }
        
        public void ResizeVisibleImagesToWindowSize()
        {
            //if (LayoutScalePage.Enabled == true)
            //{
            //    //using (Image img = new Bitmap(TEMP_SMALL_APPEND))
            //    //    ResizeImageToParentControl(PicPortraitSml, img, PanelPortraitSml);
            //    //using (Image img = new Bitmap(TEMP_MEDIUM_APPEND))
            //    //    ResizeImageToParentControl(PicPortraitMed, img, PanelPortraitMed);
            //    //using (Image img = new Bitmap(TEMP_LARGE_APPEND))
            //    //    ResizeImageToParentControl(PicPortraitLrg, img, PanelPortraitLrg);
            //}

            //if (LayoutFilePage.Enabled == true)
            {
                //using (Image img = new Bitmap(PicPortraitTemp.Image))
                    //ResizeImageToParentControl(PicPortraitTemp, img, PanelPortraitTemp);
            }
        }

        public static Tuple<int, int> CalculateNewSize(Control parent, float aspect)
        {
            int inWidth = parent.Width, inHeight = parent.Height;
            int outWidth, outHeight;

            outHeight = inHeight;
            outWidth = (int)(inHeight * 1.0f / aspect * 1.0f);

            if (outWidth < parent.Width)
            {
                outWidth = inWidth;
                outHeight = (int)(inWidth * 1.0f / (1.0f / aspect * 1.0f));
            }

            return Tuple.Create(outWidth, outHeight);
        }
        
        public void ParentLayoutsDisable()
        {
            //RootFunctions.LayoutDisable(LayoutFilePage);
            RootFunctions.LayoutDisable(LayoutMainPage);
            //RootFunctions.LayoutDisable(LayoutScalePage);
            RootFunctions.LayoutDisable(LayoutExtractPage);
            //RootFunctions.LayoutDisable(LayoutGallery);
            //RootFunctions.LayoutDisable(LayoutSettingsPage);
            RootFunctions.LayoutDisable(LayoutStartMenu);
            RootFunctions.LayoutDisable(LayoutPathPage);
            RootFunctions.LayoutDisable(LayoutKingCreatePortrait);
            //RootFunctions.LayoutDisable(LayoutURLDialog);
            //RootFunctions.LayoutDisable(LayoutFinalPage);
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
                        ResizeVisibleImagesToWindowSize();
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
        
        public static bool ValidatePortraitPath(string path)
        {
            if (SystemControl.FileControl.Readonly.DirectoryExists(path) &&
                (path.Split('\\').Last() == "Portraits" || SystemControl.FileControl.Readonly.DirectoryExists(path + "Portraits")))
            {
                return true;
            }
            return false;
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
        
        public void GenerateImageSelectionFlagString(ushort flag = 0)
        {
            if (flag == 0)
            {
                //LabelImageFlag.Text = "◼◼◼";
            }
            else if (flag == 1)
            {
                //LabelImageFlag.Text = "◼◧◻";
            }
            else if (flag == 2)
            {
                //LabelImageFlag.Text = "◼◼◧";
            }
            else if (flag == 100)
            {
                //LabelImageFlag.Text = "◻◻◻";
            }
        }
        
        public bool ValidateCustomPath(string path)
        {
            if (SystemControl.FileControl.Readonly.DirectoryExists(Path.Combine(path, "..", "Portraits - Army")) &&
                SystemControl.FileControl.Readonly.DirectoryExists(Path.Combine(path, "..", "Portraits - Npc")))
                {
                return true;
            }
            return false;
        }
        
        public void FixPicBoxAspectRatio(Panel parent, float aspect)
        {
            int width = parent.Width;
            int height = parent.Height;

            if (width * aspect <= height)
            {
                int diff = (height - (int)(width * aspect * 1.0f)) / 2;
                parent.Margin = new Padding(3, diff, 3, diff);
            }
            else if (width * aspect > height) {
                int diff = (width - (int)(height / aspect * 1.0f)) / 2;
                parent.Margin = new Padding(diff, 3, diff, 3);
            }
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
                   ext.Equals(".gif", StringComparison.OrdinalIgnoreCase);
        }

        private static Size FitSize(Size original, int maxSize)
        {
            double ratio = Math.Min((double)maxSize / original.Width, (double)maxSize / original.Height);
            if (ratio >= 1.0) return original;
            return new Size((int)(original.Width * ratio), (int)(original.Height * ratio));
        }

        private void AddArchiveThumbnail(string folderKey, Image image)
        {
            Bitmap memImage = new Bitmap(image);

            _archiveEntries.Add(Tuple.Create<string, Image>(folderKey, memImage));

            Size thumbSize = FitSize(new Size(memImage.Width, memImage.Height), 140);
            int cbWidth = Math.Max(thumbSize.Width + 20, 145);
            int cbHeight = thumbSize.Height + 50;

            Color gameBack, gameFore;
            try { gameBack = GameTypes[_gameSelected].BackColor; gameFore = GameTypes[_gameSelected].ForeColor; }
            catch { gameBack = Color.FromArgb(12, 12, 12); gameFore = Color.White; }

            CheckBox cb = new CheckBox
            {
                Text = Path.GetFileName(folderKey),
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

            cb.Font = new Font(_fontCollection.Families[0], 13);

            cb.FlatAppearance.BorderColor = gameFore;
            cb.FlatAppearance.CheckedBackColor = ControlPaint.Light(gameBack, 0.3f);
            cb.FlatAppearance.MouseOverBackColor = ControlPaint.Light(gameBack, 0.15f);

            cb.MouseEnter += (s, args) => { cb.ForeColor = gameFore; };
            cb.MouseLeave += (s, args) => { cb.ForeColor = Color.White; };

            Image thumb = new Bitmap(memImage, thumbSize);
            cb.Image = thumb;
            cb.Appearance = Appearance.Normal;
            cb.CheckAlign = ContentAlignment.TopRight;

            FlowLayoutPanelExtract.Controls.Add(cb);
        }

        private void LoadArchiveThumbnails(string archivePath)
        {
            _selectedArchivePath = archivePath;
            _archiveEntries = new List<Tuple<string, Image>>();

            FlowLayoutPanelExtract.Controls.Clear();
            FlowLayoutPanelExtract.Visible = false;
            PanelExtractOverlay.Visible = true;

            CleanupShellTempDir();

            try
            {
                string ext = Path.GetExtension(archivePath).ToLowerInvariant();

                if (ext == ".zip")
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

                            var firstImg = imgFiles.First();
                            try
                            {
                                byte[] data = ReadEntryBytes(firstImg);
                                Image img = LoadImageFromBytes(data);
                                AddArchiveThumbnail(group.Key, img);
                                img.Dispose();
                            }
                            catch { }
                        }
                    }
                }
                else if (ext == ".7z" || ext == ".rar")
                {
                    _shellTempDir = Path.Combine(Path.GetTempPath(), "PortraitManager_Extract_" + Guid.NewGuid().ToString("N"));
                    Directory.CreateDirectory(_shellTempDir);
                    ExtractArchiveViaShell(archivePath, _shellTempDir);
                    LoadFolderThumbnails(_shellTempDir);
                }
                else
                {
                    LoadFolderThumbnails(archivePath);
                }

                if (_archiveEntries.Count > 0)
                {
                    PanelExtractOverlay.Visible = false;
                    FlowLayoutPanelExtract.Visible = true;
                    ButtonExtractAll.Visible = true;
                    ButtonExtractSelected.Visible = true;
                    LayoutExtractRight.RowStyles[0].Height = 33.33F;
                    LayoutExtractRight.RowStyles[1].Height = 33.33F;
                    LayoutExtractRight.RowStyles[2].Height = 33.34F;
                    BeginInvoke(new Action(() =>
                    {
                        ShowScrollBar(FlowLayoutPanelExtract.Handle, 3, false);
                    }));
                }
            }
            catch (Exception ex)
            {
                using (var msg = new MyMessageDialog("Failed to load archive: " + ex.Message))
                {
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog();
                }
            }
        }

        private void ExtractArchiveViaShell(string archivePath, string destDir)
        {
            Type shellAppType = Type.GetTypeFromProgID("Shell.Application");
            dynamic shell = Activator.CreateInstance(shellAppType);
            dynamic src = shell.NameSpace(archivePath);
            dynamic dest = shell.NameSpace(destDir);
            dest.CopyHere(src.Items(), 20);
        }

        private void LoadFolderThumbnails(string folderPath)
        {
            foreach (var subDir in Directory.GetDirectories(folderPath))
            {
                var imgFiles = Directory.GetFiles(subDir)
                    .Where(f => IsImageFile(f))
                    .ToList();
                if (imgFiles.Count == 0) continue;

                try
                {
                    Image img = Image.FromFile(imgFiles[0]);
                    AddArchiveThumbnail(subDir, img);
                    img.Dispose();
                }
                catch { }
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

            string extractDir = Path.Combine(portraitsDir, "Portraits");
            Directory.CreateDirectory(extractDir);

            int count = 0;
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
                            string folderName = Path.GetFileName(folder.Key);
                            if (selectedKeys != null && !selectedKeys.Contains(folder.Key))
                                continue;

                            string targetFolder = Path.Combine(extractDir, folderName);
                            Directory.CreateDirectory(targetFolder);

                            foreach (var entry in folder)
                            {
                                string fileName = Path.GetFileName(entry.Name);
                                if (!string.IsNullOrEmpty(fileName))
                                {
                                    string destPath = Path.Combine(targetFolder, fileName);
                                    entry.ExtractToFile(destPath, overwrite: true);
                                }
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

                    foreach (var folder in Directory.GetDirectories(_shellTempDir))
                    {
                        string folderName = Path.GetFileName(folder);
                        if (selectedKeys != null && !selectedKeys.Contains(folder))
                            continue;

                        string targetFolder = Path.Combine(extractDir, folderName);
                        Directory.CreateDirectory(targetFolder);

                        foreach (var file in Directory.GetFiles(folder))
                        {
                            string destPath = Path.Combine(targetFolder, Path.GetFileName(file));
                            File.Copy(file, destPath, overwrite: true);
                        }
                        count++;
                    }
                }
                else
                {
                    foreach (var folder in Directory.GetDirectories(_selectedArchivePath))
                    {
                        string folderName = Path.GetFileName(folder);
                        if (selectedKeys != null && !selectedKeys.Contains(folder))
                            continue;

                        string targetFolder = Path.Combine(extractDir, folderName);
                        Directory.CreateDirectory(targetFolder);

                        foreach (var file in Directory.GetFiles(folder).Where(f => IsImageFile(f)))
                        {
                            string destPath = Path.Combine(targetFolder, Path.GetFileName(file));
                            File.Copy(file, destPath, overwrite: true);
                        }
                        count++;
                    }
                }

                string msgText = string.Format(TextVariables.MESG_EXTRACT_SUCCESS, count);
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
    }
}
