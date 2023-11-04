/*    
    Pathfinder Portrait Manager. Desktop application for managing in game
    portraits for Pathfinder: Kingmaker and Pathfinder: Wrath of the Righteous
    Copyright (C) 2023 Artemii "Zeight" Saganenko
    LICENSE terms are written in LICENSE file
    Primal license header is written in Program.cs
*/

using PathfinderPortraitManager.Properties;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathfinderPortraitManager
{
    public partial class MainForm : Form
    {
        public void RestoreFilePageToInit()
        {
            _imageSelectionFlag = 0;
            _isAnyLoadedToPortraitPage = false;
            ButtonNextImageType.Visible = true;
            ButtonNextImageType.Enabled = true;         
            ButtonNextImageType.Text = TextVariables.BUTTON_ADVANCED;
        }
        public void AddClickEventsToMainButtons()
        {
            RootFunctions.AddClickEvent(ButtonToFilePage, ButtonToFilePage_Click);
            RootFunctions.AddClickEvent(ButtonToExtractPage, ButtonToExtract_Click);
            RootFunctions.AddClickEvent(ButtonToGalleryPage, ButtonToGalleryPage_Click);
        }
        public void RemoveClickEventsFromMainButtons()
        {
            RootFunctions.RemoveClickEvent(ButtonToFilePage, ButtonToFilePage_Click);
            RootFunctions.RemoveClickEvent(ButtonToExtractPage, ButtonToExtract_Click);
            RootFunctions.RemoveClickEvent(ButtonToGalleryPage, ButtonToGalleryPage_Click);
        }
        public void AddClickEventsToCustomPortraitsButtons()
        {
            RootFunctions.AddClickEvent(ButtonLoadCustom, ButtonLoadCustom_Click);
            RootFunctions.AddClickEvent(ButtonLoadCustomNPC, ButtonLoadCustomNPC_Click);
            RootFunctions.AddClickEvent(ButtonLoadCustomArmy, ButtonLoadCustomArmy_Click);
        }
        public void RemoveClickEventsFromCustomPortraitsButtons()
        {
            RootFunctions.RemoveClickEvent(ButtonLoadCustom, ButtonLoadCustom_Click);
            RootFunctions.RemoveClickEvent(ButtonLoadCustomNPC, ButtonLoadCustomNPC_Click);
            RootFunctions.RemoveClickEvent(ButtonLoadCustomArmy, ButtonLoadCustomArmy_Click);
        }
        public void ClearPictureBoxImages(Image replacement)
        {
            ImageControl.Utils.Replace(PicPortraitTemp, replacement);
            ImageControl.Utils.Replace(PicPortraitLrg, replacement);
            ImageControl.Utils.Replace(PicPortraitMed, replacement);
            ImageControl.Utils.Replace(PicPortraitSml, replacement);
        }
        public void DisposePrimeImages()
        {
            ImageControl.Utils.Dispose(PicPortraitTemp);
            ImageControl.Utils.Dispose(PicPortraitLrg);
            ImageControl.Utils.Dispose(PicPortraitMed);
            ImageControl.Utils.Dispose(PicPortraitSml);
        }
        public void ResizeImageToParentControl(Control control, Image image, Control parent)
        {
            float aspect = control.Height * 1.0f / control.Width * 1.0f;

            Tuple<int, int> newSize = MapNewSize(parent, aspect);

            if (control is PictureBox pictureBox)
            {
                pictureBox.Image = ImageControl.Direct.Resize(image, newSize.Item1, newSize.Item2);
            }

            DisableAutoScroll(parent, newSize.Item1, newSize.Item2);
        }
        public void ResizeVisibleImagesToWindowSize()
        {
            if (LayoutScalePage.Enabled == true)
            {
                using (Image img = new Bitmap(TEMP_SMALL_APPEND))
                    ResizeImageToParentControl(PicPortraitSml, img, PanelPortraitSml);
                using (Image img = new Bitmap(TEMP_MEDIUM_APPEND))
                    ResizeImageToParentControl(PicPortraitMed, img, PanelPortraitMed);
                using (Image img = new Bitmap(TEMP_LARGE_APPEND))
                    ResizeImageToParentControl(PicPortraitLrg, img, PanelPortraitLrg);
            }

            if (LayoutFilePage.Enabled == true)
            {
                using (Image img = new Bitmap(PicPortraitTemp.Image))
                    ResizeImageToParentControl(PicPortraitTemp, img, PanelPortraitTemp);
            }
        }
        public static Tuple<int, int> MapNewSize(Control parent, float aspect)
        {
            int inWidth = parent.Width, inHeight = parent.Height,
                outWidth, outHeight;

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
            RootFunctions.LayoutDisable(LayoutFilePage);
            RootFunctions.LayoutDisable(LayoutMainPage);
            RootFunctions.LayoutDisable(LayoutScalePage);
            RootFunctions.LayoutDisable(LayoutExtractPage);
            RootFunctions.LayoutDisable(LayoutGallery);
            RootFunctions.LayoutDisable(LayoutSettingsPage);
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
            if (selectionFlag == 0 || selectionFlag == 100)
            {
                using (Image img = new Bitmap(TEMP_LARGE_APPEND))
                    ImageControl.Utils.Replace(PicPortraitTemp, new Bitmap(img));
            }
            else if (selectionFlag == 1)
            {
                using (Image img = new Bitmap(TEMP_MEDIUM_APPEND))
                    ImageControl.Utils.Replace(PicPortraitTemp, new Bitmap(img));
            }
            else if (selectionFlag == 2)
            {
                using (Image img = new Bitmap(TEMP_SMALL_APPEND))
                    ImageControl.Utils.Replace(PicPortraitTemp, new Bitmap(img));
            }
            else if (selectionFlag == 200)
            {
                using (Image img = new Bitmap(TEMP_SMALL_APPEND))
                    ImageControl.Utils.Replace(PicPortraitSml, new Bitmap(img));
                using (Image img = new Bitmap(TEMP_MEDIUM_APPEND))
                    ImageControl.Utils.Replace(PicPortraitMed, new Bitmap(img));
                using (Image img = new Bitmap(TEMP_LARGE_APPEND))
                    ImageControl.Utils.Replace(PicPortraitLrg, new Bitmap(img));
                DisableAutoScroll(PanelPortraitLrg, PicPortraitLrg.Height, PicPortraitLrg.Width);
                DisableAutoScroll(PanelPortraitMed, PicPortraitLrg.Height, PicPortraitLrg.Width);
                DisableAutoScroll(PanelPortraitSml, PicPortraitLrg.Height, PicPortraitLrg.Width);
            }
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
            if (SystemControl.FileControl.Readonly.DirectoryExists(path))

                if (SystemControl.FileControl.Readonly.FileExist(path + LARGE_APPEND) &&
                    SystemControl.FileControl.Readonly.FileExist(path + MEDIUM_APPEND) &&
                    SystemControl.FileControl.Readonly.FileExist(path + SMALL_APPEND))

                    if (SystemControl.FileControl.Readonly.GetFileExtension(path + LARGE_APPEND) == ".png" &&
                        SystemControl.FileControl.Readonly.GetFileExtension(path + MEDIUM_APPEND) == ".png" &&
                        SystemControl.FileControl.Readonly.GetFileExtension(path + SMALL_APPEND) == ".png")
                        return true;

                    else
                        return false;
                else
                    return false;
            else
                return false;
        }
        public static bool CheckPortraitExistenceClipped(string path)
        {
            if (SystemControl.FileControl.Readonly.DirectoryExists(path))

                if (SystemControl.FileControl.Readonly.FileExist(path + MEDIUM_APPEND) &&
                    SystemControl.FileControl.Readonly.FileExist(path + SMALL_APPEND))

                    if (SystemControl.FileControl.Readonly.GetFileExtension(path + MEDIUM_APPEND) == ".png" &&
                        SystemControl.FileControl.Readonly.GetFileExtension(path + SMALL_APPEND) == ".png")
                        return true;

                    else
                        return false;
                else
                    return false;
            else
                return false;
        }
        private void RecursiveParsePortraitsDirectoryAsync(string path, CancellationToken cancelToken)
        {
            if (cancelToken.IsCancellationRequested)
            {
                Invoke((MethodInvoker)delegate
                {
                    ClearImageListsSync(ListExtract, ImgListExtract);
                });

                return;
            }

            if (CheckPortraitExistence(path))
            {
                if (SystemControl.FileControl.Readonly.CheckImagePixeling(path + LARGE_APPEND, 692, 1024) &&
                    SystemControl.FileControl.Readonly.CheckImagePixeling(path + MEDIUM_APPEND, 330, 432) &&
                    SystemControl.FileControl.Readonly.CheckImagePixeling(path + SMALL_APPEND, 185, 242))
                {
                    try
                    {
                        using (Image img = new Bitmap(path + "\\Fulllength.png"))
                        {
                            ListViewItem item = new ListViewItem
                            {
                                Text = path.Split('\\').Last(),
                                ImageIndex = ListExtract.Items.Count,
                                Tag = path
                            };
                            Invoke((MethodInvoker)delegate
                            {
                                ImgListExtract.Images.Add(path, img);
                                ListExtract.Items.Add(item);
                                ButtonExtractAll.Enabled = true;
                                ButtonExtractSelected.Enabled = true;
                                ButtonOpenFolders.Enabled = true;
                            });
                        }
                    }
                    catch
                    {
                        return;
                    }
                }
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
        public void FontsInit(PrivateFontCollection fonts)
        {
            Font bebasNeue20 = new Font(fonts.Families[0], 20), 
                 bebasNeue16 = new Font(fonts.Families[0], 16),
                 bebasNeue13 = new Font(fonts.Families[0], 13);
            ButtonToFilePage.Font = bebasNeue20;
            ButtonToExtractPage.Font = bebasNeue20;
            ButtonToGalleryPage.Font = bebasNeue20;
            ButtonToSettingsPage.Font = bebasNeue20;
            ButtonExit.Font = bebasNeue20;
            ButtonKingmaker.Font = bebasNeue20;
            ButtonWotR.Font = bebasNeue20;
            LabelSelectedPath.Font = bebasNeue16;
            ButtonValidatePath.Font = bebasNeue16;
            ButtonSelectPath.Font = bebasNeue16;
            ButtonToMainPage5.Font = bebasNeue20;
            LabelSettings.Font = bebasNeue16;
            ButtonApplyChange.Font = bebasNeue16;
            ButtonLocalPortraitLoad.Font = bebasNeue20;
            ButtonWebPortraitLoad.Font = bebasNeue20;
            ButtonToMainPage.Font = bebasNeue20;
            ButtonToScalePage.Font = bebasNeue20;
            ButtonNextImageType.Font = bebasNeue20;
            ButtonHintOnFilePage.Font = bebasNeue20;
            ButtonToFilePage2.Font = bebasNeue20;
            ButtonCreatePortrait.Font = bebasNeue20;
            LabelMedImage.Font = bebasNeue20;
            LabelLrgImg.Font = bebasNeue20;
            LabelSmlImg.Font = bebasNeue20;
            ButtonHintOnScalePage.Font = bebasNeue20;
            ButtonDeletePortait.Font = bebasNeue20;
            ButtonToMainPage3.Font = bebasNeue20;
            ButtonOpenFolder.Font = bebasNeue20;
            ButtonChangePortrait.Font = bebasNeue20;
            ButtonHintFolder.Font = bebasNeue20;
            LabelURLInfo.Font = bebasNeue20;
            ButtonDenyWeb.Font = bebasNeue20;
            ButtonLoadWeb.Font = bebasNeue20;
            LabelFinalMesg.Font = bebasNeue20;
            ButtonToFilePage3.Font = bebasNeue20;
            ButtonToMainPage4.Font = bebasNeue20;
            ButtonToMainPageAndFolder.Font = bebasNeue20;
            ButtonChooseFolder.Font = bebasNeue20;
            ButtonExtractAll.Font = bebasNeue20;
            ButtonExtractSelected.Font = bebasNeue20;
            ButtonOpenFolders.Font = bebasNeue20;
            ButtonHintExtract.Font = bebasNeue20;
            ButtonToMainPage2.Font = bebasNeue20;
            ButtonLoadCustom.Font = bebasNeue13;
            ButtonLoadNormal.Font = bebasNeue13;
            ButtonLoadCustomArmy.Font = bebasNeue13;
            ButtonLoadCustomNPC.Font = bebasNeue13;
        }
        public void FontsInitNotEN()
        {
            Font defFont12 = new Font(DefaultFont.FontFamily, 12);
            ButtonToFilePage.Font = defFont12;
            ButtonToExtractPage.Font = defFont12;
            ButtonToGalleryPage.Font = defFont12;
            ButtonToSettingsPage.Font = defFont12;
            ButtonExit.Font = defFont12;
            ButtonKingmaker.Font = defFont12;
            ButtonWotR.Font = defFont12;
            LabelSelectedPath.Font = defFont12;
            ButtonValidatePath.Font = defFont12;
            ButtonSelectPath.Font = defFont12;
            ButtonToMainPage5.Font = defFont12;
            LabelSettings.Font = defFont12;
            ButtonApplyChange.Font = defFont12;
            ButtonLocalPortraitLoad.Font = defFont12;
            ButtonWebPortraitLoad.Font = defFont12;
            ButtonToMainPage.Font = defFont12;
            ButtonToScalePage.Font = defFont12;
            ButtonNextImageType.Font = defFont12;
            ButtonHintOnFilePage.Font = defFont12;
            ButtonToFilePage2.Font = defFont12;
            ButtonCreatePortrait.Font = defFont12;
            LabelMedImage.Font = defFont12;
            LabelLrgImg.Font = defFont12;
            LabelSmlImg.Font = defFont12;
            ButtonHintOnScalePage.Font = defFont12;
            ButtonDeletePortait.Font = defFont12;
            ButtonToMainPage3.Font = defFont12;
            ButtonOpenFolder.Font = defFont12;
            ButtonChangePortrait.Font = defFont12;
            ButtonHintFolder.Font = defFont12;
            LabelURLInfo.Font = defFont12;
            ButtonDenyWeb.Font = defFont12;
            ButtonLoadWeb.Font = defFont12;
            LabelFinalMesg.Font = defFont12;
            ButtonToFilePage3.Font = defFont12;
            ButtonToMainPage4.Font = defFont12;
            ButtonToMainPageAndFolder.Font = defFont12;
            ButtonChooseFolder.Font = defFont12;
            ButtonExtractAll.Font = defFont12;
            ButtonExtractSelected.Font = defFont12;
            ButtonOpenFolders.Font = defFont12;
            ButtonHintExtract.Font = defFont12;
            ButtonToMainPage2.Font = defFont12;
            ButtonLoadCustom.Font = defFont12;
            ButtonLoadNormal.Font = defFont12;
            ButtonLoadCustomArmy.Font = defFont12;
            ButtonLoadCustomNPC.Font = defFont12;
        }
        public void TextsInit()
        {
            ButtonToFilePage.Text = TextVariables.BUTTON_TOFILEPAGE;
            ButtonToExtractPage.Text = TextVariables.BUTTON_TOEXRACTPAGE;
            ButtonToGalleryPage.Text = TextVariables.BUTTON_TOGALLERYPAGE;
            ButtonToSettingsPage.Text = TextVariables.BUTTON_TOSETTINGSPAGE;
            ButtonExit.Text = TextVariables.BUTTON_EXIT;
            ButtonKingmaker.Text = TextVariables.KING;
            ButtonWotR.Text = TextVariables.WOTR;
            LabelSelectedPath.Text = TextVariables.LABEL_PATH;
            ButtonValidatePath.Text = TextVariables.BUTTON_VALIDATE;
            ButtonSelectPath.Text = TextVariables.BUTTON_SELECTPATH;
            ButtonToMainPage5.Text = TextVariables.BUTTON_BACK;
            LabelSettings.Text = TextVariables.LABEL_SETTINGS;
            ButtonApplyChange.Text = TextVariables.BUTTON_APPLY;
            ButtonLocalPortraitLoad.Text = TextVariables.BUTTON_LOADLOCALPORTRAIT;
            ButtonWebPortraitLoad.Text = TextVariables.BUTTON_LOADWEBPORTRAIT;
            ButtonToMainPage.Text = TextVariables.BUTTON_BACK;
            ButtonToScalePage.Text = TextVariables.BUTTON_TOSCALEPAGE;
            ButtonNextImageType.Text = TextVariables.BUTTON_ADVANCED;
            ButtonHintOnFilePage.Text = TextVariables.BUTTON_HINT;
            ButtonToFilePage2.Text = TextVariables.BUTTON_BACK;
            ButtonCreatePortrait.Text = TextVariables.BUTTON_TOCREATE;
            LabelMedImage.Text = TextVariables.LABEL_MEDIUMIMG;
            LabelLrgImg.Text = TextVariables.LABEL_LARGEIMG;
            LabelSmlImg.Text = TextVariables.LABEL_SMALLIMG;
            ButtonHintOnScalePage.Text = TextVariables.BUTTON_HINT;
            ButtonDeletePortait.Text = TextVariables.BUTTON_SELECTEDDELETE;
            ButtonToMainPage3.Text = TextVariables.BUTTON_BACK;
            ButtonOpenFolder.Text = TextVariables.BUTTON_GALLERYOPENFOLDER;
            ButtonChangePortrait.Text = TextVariables.BUTTON_SELECTEDCHANGE;
            ButtonHintFolder.Text = TextVariables.BUTTON_HINT;
            LabelURLInfo.Text = TextVariables.LABEL_URLDIALOG;
            ButtonDenyWeb.Text = TextVariables.BUTTON_CANCEL;
            ButtonLoadWeb.Text = TextVariables.BUTTON_LOAD;
            TextBoxURL.Text = TextVariables.TEXTBOX_URL_INPUT;
            LabelFinalMesg.Text = TextVariables.LABEL_CREATEDOK;
            ButtonToFilePage3.Text = TextVariables.BUTTON_NEW;
            ButtonToMainPage4.Text = TextVariables.BUTTON_MENU;
            ButtonToMainPageAndFolder.Text = TextVariables.BUTTON_FINALOPENFOLDER;
            ButtonChooseFolder.Text = TextVariables.TEXT_TITLEOPENFOLDER;
            ButtonExtractAll.Text = TextVariables.BUTTON_EXTRACTALL;
            ButtonExtractSelected.Text = TextVariables.BUTTON_EXTRACTSELECTED;
            ButtonOpenFolders.Text = TextVariables.BUTTON_EXTRACTOPENFOLDER;
            ButtonHintExtract.Text = TextVariables.BUTTON_HINT;
            ButtonToMainPage2.Text = TextVariables.BUTTON_BACK;
            LabelCopyright.Text = TextVariables.LABEL_COPY;
            ButtonLoadCustom.Text = TextVariables.BUTTON_SHOWCUSTOM;
            ButtonLoadCustomArmy.Text = TextVariables.BUTTON_CUSTOMARMY;
            ButtonLoadCustomNPC.Text = TextVariables.BUTTON_CUSTOMNPC;
            ButtonLoadNormal.Text = TextVariables.BUTTON_SHOWLOCAL;
        }
        public void UpdateObjectColoringInDepth(Control ctrl, Color a, Color b)
        {
            if (ctrl is PictureBox || ctrl.Equals(LayoutURLDialog)
                                   || ctrl.Equals(LayoutFinalPage)
                                   || ctrl.Equals(LayoutSettingsPage)
                                   || ctrl.Equals(LayoutLang))
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
            ctrl.TabStop = false;

            foreach (Control subCtrl in ctrl.Controls)
            {
                UpdateObjectColoringInDepth(subCtrl, a, b);
            }
        }
        public void ReplacePictureBoxImagesToDefault()
        {
            using (Image placeholder = new Bitmap(GAME_TYPES[_gameSelected].PlaceholderImage))
            {
                ClearPictureBoxImages(placeholder);
            }
        }
        public static void CreateAllImagesInTemp(string newImagePath, ushort flag)
        {
            using (Image placeholder = new Bitmap(GAME_TYPES[_gameSelected].PlaceholderImage))
            {
                if (flag == 1)
                {
                    SystemControl.FileControl.DeleteFile(TEMP_MEDIUM_APPEND);
                    SystemControl.FileControl.CreateTempImages(newImagePath, TEMP_APPENDS, placeholder, flag);
                }
                else if (flag == 2)
                {
                    SystemControl.FileControl.DeleteFile(TEMP_SMALL_APPEND);
                    SystemControl.FileControl.CreateTempImages(newImagePath, TEMP_APPENDS, placeholder, flag);
                }
                else if (flag == 100 || flag == 0)
                {
                    SystemControl.FileControl.ClearTempImages();
                    SystemControl.FileControl.CreateTempImages(newImagePath, TEMP_APPENDS, placeholder, flag);
                }
            }
        }
        public void UpdateColorScheme()
        {
            Color foreColor = GAME_TYPES[_gameSelected].ForeColor;
            Color backColor = GAME_TYPES[_gameSelected].BackColor;
            Icon = GAME_TYPES[_gameSelected].GameIcon;
            PictureBoxTitle.BackgroundImage = GAME_TYPES[_gameSelected].TitleImage;
            LayoutMainPage.BackgroundImage = GAME_TYPES[_gameSelected].BackgroundImage;

            foreach (Control ctrl in Controls)
            {
                UpdateObjectColoringInDepth(ctrl, foreColor, backColor);
            }

            Text = GAME_TYPES[_gameSelected].TitleText;
            TextBoxFullPath.Clear();

            if (_gameSelected == 'p')
            {
                ButtonKingmaker.Enabled = false;
                ButtonKingmaker.ForeColor = backColor;
                ButtonKingmaker.BackColor = foreColor;
                ButtonWotR.Enabled = true;
                ButtonWotR.ForeColor = Color.White;
                ButtonWotR.BackColor = Color.Black;
                TextBoxFullPath.Text = CoreSettings.Default.KINGPath;
            }
            else
            {
                ButtonKingmaker.Enabled = true;
                ButtonKingmaker.ForeColor = Color.White;
                ButtonKingmaker.BackColor = Color.Black;
                ButtonWotR.Enabled = false;
                ButtonWotR.ForeColor = backColor;
                ButtonWotR.BackColor = foreColor;
                TextBoxFullPath.Text = CoreSettings.Default.WOTRPath;
            }
        }
        public bool LoadGallery(string path)
        {
            if (!SystemControl.FileControl.Readonly.DirectoryExists(path))
            {
                return false;
            }
            _cancellationTokenSource?.Cancel();
            ClearImageListsSync(ListGallery, ImgListGallery);
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
                        ClearImageListsSync(ListGallery, ImgListGallery);
                    });

                    return;
                }

                if (CheckPortraitExistence(subDir))
                {
                    if (SystemControl.FileControl.Readonly.CheckImagePixeling(subDir + LARGE_APPEND, 692, 1024) &&
                        SystemControl.FileControl.Readonly.CheckImagePixeling(subDir + MEDIUM_APPEND, 330, 432) &&
                        SystemControl.FileControl.Readonly.CheckImagePixeling(subDir + SMALL_APPEND, 185, 242))
                    {
                        try
                        {
                            using (Image img = new Bitmap(subDir + "\\Fulllength.png"))
                            {

                                ListViewItem item = new ListViewItem
                                {
                                    Text = subDir.Split('\\').Last(),
                                    ImageIndex = ImgListGallery.Images.Count,
                                    Tag = subDir+">LOCAL"
                                };
                                Invoke((MethodInvoker)delegate
                                {
                                    ImgListGallery.Images.Add(subDir, img);
                                    ListGallery.Items.Add(item);
                                });

                            }
                        }
                        catch
                        {
                            return;
                        }
                    }
                }
            }
        }
        private void RecursiveParsePortraitsFolderAsync(string fromPath, CancellationToken cancelToken, bool flag)
        {
            if (cancelToken.IsCancellationRequested)
            {
                Invoke((MethodInvoker)delegate
                {
                    ClearImageListsSync(ListGallery, ImgListGallery);
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
                            ImageIndex = ListGallery.Items.Count,
                            Tag = fromPath + ">CUSTOM"
                        };
                        Invoke((MethodInvoker)delegate
                        {
                            ImgListGallery.Images.Add(fromPath, img);
                            ListGallery.Items.Add(item);
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
                        if (_imageSelectionFlag == 1)
                        {
                            SystemControl.FileControl.DeleteFile(TEMP_MEDIUM_APPEND);
                            webImage.Save(TEMP_MEDIUM_APPEND);
                        }
                        else if (_imageSelectionFlag == 2)
                        {
                            SystemControl.FileControl.DeleteFile(TEMP_SMALL_APPEND);
                            webImage.Save(TEMP_SMALL_APPEND);
                        }
                        else if (_imageSelectionFlag == 100 || _imageSelectionFlag == 0)
                        {
                            SystemControl.FileControl.ClearTempImages();
                            SystemControl.FileControl.CreateDirectory("temp_DoNotDeleteWhileRunning/");
                            webImage.Save(TEMP_MEDIUM_APPEND);
                            webImage.Save(TEMP_SMALL_APPEND);
                            webImage.Save(TEMP_LARGE_APPEND);
                        }
                        LoadTempImagesToPicBox(_imageSelectionFlag);
                        ResizeVisibleImagesToWindowSize();
                    }
                }
            }
            catch
            {
                using (forms.MyMessageDialog Message = new forms.MyMessageDialog(TextVariables.MESG_CANNOTLOAD, CoreSettings.Default.SelectedLang))
                {
                    Message.StartPosition = FormStartPosition.CenterParent;
                    Message.ShowDialog();
                }
            }
        }
        public static bool ValidatePortraitPath(string path)
        {
            if (SystemControl.FileControl.Readonly.DirectoryExists(path) &&
                path.Split('\\').Last() == "Portraits")
            {
                return true;
            }
            return false;
        }
        public void GeneratePortraits(string path)
        {
            Directory.CreateDirectory(path);
            ImageControl.Wraps.CropImage(PicPortraitLrg, PanelPortraitLrg, TEMP_LARGE_APPEND,
                                         path + LARGE_APPEND, LARGE_ASPECT, 692, 1024);
            ImageControl.Wraps.CropImage(PicPortraitMed, PanelPortraitMed, TEMP_MEDIUM_APPEND,
                                         path + MEDIUM_APPEND, MEDIUM_ASPECT, 330, 432);
            ImageControl.Wraps.CropImage(PicPortraitSml, PanelPortraitSml, TEMP_SMALL_APPEND,
                                         path + SMALL_APPEND, SMALL_ASPECT, 185, 242);
        }
        public void GenerateImageSelectionFlagString(ushort flag = 0)
        {
            if (flag == 0)
            {
                LabelImageFlag.Text = "◼◼◼";
            }
            else if (flag == 1)
            {
                LabelImageFlag.Text = "◼◧◻";
            }
            else if (flag == 2)
            {
                LabelImageFlag.Text = "◼◼◧";
            }
            else if (flag == 100)
            {
                LabelImageFlag.Text = "◻◻◻";
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
    }
}
