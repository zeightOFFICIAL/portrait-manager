/*    
    Portrait Manager: Owlcat. Desktop application for managing in game
    portraits for Owlcat Games products. Including: 1. Pathfinder: Kingmaker,
    2. Pathfinder: Wrath of the Righteous, 3. Warhammer 40000: Rogue Trader
    Copyright (C) 2024 Artemii "Zeight" Saganenko.

    GPL-2.0 license terms are listed in LICENSE file.
    License header for this project is listed in Program.cs.
*/

using PortraitManager.Properties;

using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
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
            ButtonNextImageType.Visible = true;
            ButtonNextImageType.Enabled = true;       
            ////ButtonNextImageType.Text = TextVariables.BUTTON_ADVANCED;
            LblToAdvancedPage.Visible = true;
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
            Tuple<int, int> newSize = CalculateNewSize(parent, aspect);

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
                //using (Image img = new Bitmap(TEMP_SMALL_APPEND))
                //    ResizeImageToParentControl(PicPortraitSml, img, PanelPortraitSml);
                //using (Image img = new Bitmap(TEMP_MEDIUM_APPEND))
                //    ResizeImageToParentControl(PicPortraitMed, img, PanelPortraitMed);
                //using (Image img = new Bitmap(TEMP_LARGE_APPEND))
                //    ResizeImageToParentControl(PicPortraitLrg, img, PanelPortraitLrg);
            }

            if (LayoutFilePage.Enabled == true)
            {
                using (Image img = new Bitmap(PicPortraitTemp.Image))
                    ResizeImageToParentControl(PicPortraitTemp, img, PanelPortraitTemp);
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
            RootFunctions.LayoutDisable(LayoutFilePage);
            RootFunctions.LayoutDisable(LayoutMainPage);
            RootFunctions.LayoutDisable(LayoutScalePage);
            RootFunctions.LayoutDisable(LayoutExtractPage);
            RootFunctions.LayoutDisable(LayoutGallery);
            RootFunctions.LayoutDisable(LayoutSettingsPage);
            RootFunctions.LayoutDisable(LayoutStartMenu);
            RootFunctions.LayoutDisable(LayoutPathPage);
            RootFunctions.LayoutDisable(LayoutURLDialog);
            RootFunctions.LayoutDisable(LayoutFinalPage);
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
                    ClearImageListsSync(ListExtract, ImgListExtract);
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
        
        public void StartMenuFontsInit(PrivateFontCollection fonts)
        {
            Font font = new Font(fonts.Families[0], 13);

            ButtonStartKing.Font = font;
            ButtonStartPoe.Font = font;
            ButtonStartPoed.Font = font;
            ButtonStartWotr.Font = font;
            ButtonStartTyr.Font = font;
            ButtonStartW3.Font = font;
            ButtonStartRt.Font = font;
        }

        public void PathMenuFontsInit(PrivateFontCollection fonts)
        {
            Font font = new Font(fonts.Families[0], 13),
                font2 = new Font(fonts.Families[0], 20);

            LabelStartResetPath.Font = font;
            LabelStartSelectPath.Font = font;
            LabelPathExplain.Font = font;
            LabelSelectPathTitle.Font = font2;
        }

        public void PathMenuTextInit()
        {
            //LabelStartResetPath.Text = TextVariables.LABEL_RESET;
            //LabelStartSelectPath.Text = TextVariables.LABEL_CHOOSE;
            //LabelPathTitle.Text = TextVariables.TEXT_KINGMAKER;
            //LabelPathExplain.Text = TextVariables.LABEL_PATH_EXPLAIN;
        }

        public void StartMenuTextInit()
        {
            //ButtonStartKing.Text = TextVariables.TEXT_KINGMAKER;
            //ButtonStartPoe.Text = TextVariables.TEXT_PILLARS;
            //ButtonStartPoed.Text = TextVariables.TEXT_DEADFIRE;
            //ButtonStartWotr.Text = TextVariables.TEXT_WOTR;
            //ButtonStartTyr.Text = TextVariables.TEXT_TYR;
            //ButtonStartW3.Text = TextVariables.TEXT_WASTE;
            //ButtonStartRt.Text = TextVariables.TEXT_ROGUE;
        }

        public void FontsInit(PrivateFontCollection fonts, ushort family = 0, int headSize = 19, int underSize = 16, int smallSize = 13)
        {
            Font bebasNeueHead = new Font(fonts.Families[family], headSize), 
                 bebasNeueUnder = new Font(fonts.Families[family], underSize),
                 bebasNeueSmall = new Font(fonts.Families[family], smallSize);

            ButtonToFilePage.Font = bebasNeueHead;
            ButtonToExtractPage.Font = bebasNeueHead;
            ButtonToGalleryPage.Font = bebasNeueHead;
            ButtonToSettingsPage.Font = bebasNeueHead;
            ButtonExit.Font = bebasNeueHead;
            ButtonKingmaker.Font = bebasNeueHead;
            ButtonWotR.Font = bebasNeueHead;
            LabelSelectedPath23.Font = bebasNeueUnder;
            ButtonValidatePath.Font = bebasNeueUnder;
            ButtonSelectPath.Font = bebasNeueUnder;
            ButtonToMainPage5.Font = bebasNeueHead;
            LabelSettings.Font = bebasNeueUnder;
            ButtonApplyChange.Font = bebasNeueUnder;
            ButtonLocalPortraitLoad.Font = bebasNeueHead;
            ButtonWebPortraitLoad.Font = bebasNeueHead;
            ButtonToMainPage.Font = bebasNeueHead;
            ButtonToScalePage.Font = bebasNeueHead;
            ButtonNextImageType.Font = bebasNeueHead;
            ButtonHintOnFilePage.Font = bebasNeueHead;
            ButtonToFilePage2.Font = bebasNeueHead;
            ButtonCreatePortrait.Font = bebasNeueHead;
            LabelMedImage.Font = bebasNeueHead;
            LabelLrgImg.Font = bebasNeueHead;
            LabelSmlImg.Font = bebasNeueHead;
            ButtonHintOnScalePage.Font = bebasNeueHead;
            ButtonDeletePortait.Font = bebasNeueHead;
            ButtonToMainPage3.Font = bebasNeueHead;
            ButtonOpenFolder.Font = bebasNeueHead;
            ButtonChangePortrait.Font = bebasNeueHead;
            ButtonHintFolder.Font = bebasNeueHead;
            LabelURLInfo.Font = bebasNeueHead;
            ButtonDenyWeb.Font = bebasNeueHead;
            ButtonLoadWeb.Font = bebasNeueHead;
            LabelFinalMesg.Font = bebasNeueHead;
            ButtonToFilePage3.Font = bebasNeueHead;
            ButtonToMainPage4.Font = bebasNeueHead;
            ButtonToMainPageAndFolder.Font = bebasNeueHead;
            ButtonChooseFolder.Font = bebasNeueHead;
            ButtonExtractAll.Font = bebasNeueHead;
            ButtonExtractSelected.Font = bebasNeueHead;
            ButtonOpenFolders.Font = bebasNeueHead;
            ButtonHintExtract.Font = bebasNeueHead;
            ButtonToMainPage2.Font = bebasNeueHead;
            ButtonLoadCustom.Font = bebasNeueSmall;
            ButtonLoadNormal.Font = bebasNeueSmall;
            ButtonLoadCustomArmy.Font = bebasNeueSmall;
            ButtonLoadCustomNPC.Font = bebasNeueSmall;
            ButtonRT.Font = bebasNeueHead;
            
        }
        
        public void FontsInitNotEN(int defSize = 12)
        {
            Font defFont12 = new Font(DefaultFont.FontFamily, defSize);

            ButtonToFilePage.Font = defFont12;
            ButtonToExtractPage.Font = defFont12;
            ButtonToGalleryPage.Font = defFont12;
            ButtonToSettingsPage.Font = defFont12;
            ButtonExit.Font = defFont12;
            ButtonKingmaker.Font = defFont12;
            ButtonWotR.Font = defFont12;
            LabelSelectedPath23.Font = defFont12;
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
            ButtonStartKing.Font = defFont12;
            ButtonStartPoe.Font = defFont12;
            ButtonStartPoed.Font = defFont12;
            ButtonStartWotr.Font = defFont12;
            ButtonStartTyr.Font = defFont12;
            ButtonStartW3.Font = defFont12;
            ButtonStartRt.Font = defFont12;
        }
        
        public void TextsInit()
        {
            //ButtonToFilePage.Text = TextVariables.BUTTON_TOFILEPAGE;
            //ButtonToExtractPage.Text = TextVariables.BUTTON_TOEXRACTPAGE;
            //ButtonToGalleryPage.Text = TextVariables.BUTTON_TOGALLERYPAGE;
            //ButtonToSettingsPage.Text = TextVariables.BUTTON_TOSETTINGSPAGE;
            //ButtonExit.Text = TextVariables.BUTTON_EXIT;
            //ButtonKingmaker.Text = TextVariables.KING;
            //ButtonWotR.Text = TextVariables.WOTR;
            //LabelSelectedPath.Text = TextVariables.LABEL_PATH;
            //ButtonValidatePath.Text = TextVariables.BUTTON_VALIDATE;
            //ButtonSelectPath.Text = TextVariables.BUTTON_SELECTPATH;
            //ButtonToMainPage5.Text = TextVariables.BUTTON_BACK;
            //LabelSettings.Text = TextVariables.LABEL_SETTINGS;
            //ButtonApplyChange.Text = TextVariables.BUTTON_APPLY;
            //ButtonLocalPortraitLoad.Text = TextVariables.BUTTON_LOADLOCALPORTRAIT;
            //ButtonWebPortraitLoad.Text = TextVariables.BUTTON_LOADWEBPORTRAIT;
            //ButtonToMainPage.Text = TextVariables.BUTTON_BACK;
            //ButtonToScalePage.Text = TextVariables.BUTTON_TOSCALEPAGE;
            //ButtonNextImageType.Text = TextVariables.BUTTON_ADVANCED;
            //ButtonHintOnFilePage.Text = TextVariables.BUTTON_HINT;
            //ButtonToFilePage2.Text = TextVariables.BUTTON_BACK;
            //ButtonCreatePortrait.Text = TextVariables.BUTTON_TOCREATE;
            //LabelMedImage.Text = TextVariables.LABEL_MEDIUMIMG;
            //LabelLrgImg.Text = TextVariables.LABEL_LARGEIMG;
            //LabelSmlImg.Text = TextVariables.LABEL_SMALLIMG;
            //ButtonHintOnScalePage.Text = TextVariables.BUTTON_HINT;
            //ButtonDeletePortait.Text = TextVariables.BUTTON_SELECTEDDELETE;
            //ButtonToMainPage3.Text = TextVariables.BUTTON_BACK;
            //ButtonOpenFolder.Text = TextVariables.BUTTON_GALLERYOPENFOLDER;
            //ButtonChangePortrait.Text = TextVariables.BUTTON_SELECTEDCHANGE;
            //ButtonHintFolder.Text = TextVariables.BUTTON_HINT;
            //LabelURLInfo.Text = TextVariables.LABEL_URLDIALOG;
            //ButtonDenyWeb.Text = TextVariables.BUTTON_CANCEL;
            //ButtonLoadWeb.Text = TextVariables.BUTTON_LOAD;
            //TextBoxURL.Text = TextVariables.TEXTBOX_URL_INPUT;
            //LabelFinalMesg.Text = TextVariables.LABEL_CREATEDOK;
            //ButtonToFilePage3.Text = TextVariables.BUTTON_NEW;
            //ButtonToMainPage4.Text = TextVariables.BUTTON_MENU;
            //ButtonToMainPageAndFolder.Text = TextVariables.BUTTON_FINALOPENFOLDER;
            //ButtonChooseFolder.Text = TextVariables.TEXT_TITLEOPENFOLDER;
            //ButtonExtractAll.Text = TextVariables.BUTTON_EXTRACTALL;
            //ButtonExtractSelected.Text = TextVariables.BUTTON_EXTRACTSELECTED;
            //ButtonOpenFolders.Text = TextVariables.BUTTON_EXTRACTOPENFOLDER;
            //ButtonHintExtract.Text = TextVariables.BUTTON_HINT;
            //ButtonToMainPage2.Text = TextVariables.BUTTON_BACK;
            //LabelCopyright.Text = TextVariables.LABEL_COPY;
            //ButtonLoadCustom.Text = TextVariables.BUTTON_SHOWCUSTOM;
            //ButtonLoadCustomArmy.Text = TextVariables.BUTTON_CUSTOMARMY;
            //ButtonLoadCustomNPC.Text = TextVariables.BUTTON_CUSTOMNPC;
            //ButtonLoadNormal.Text = TextVariables.BUTTON_SHOWLOCAL;
            //ButtonRT.Text = TextVariables.ROGUE;
            
        }
        
        public void UpdateObjectColoringInDepth(Control ctrl, Color a, Color b)
        {
            if (ctrl is PictureBox || ctrl.Equals(LayoutURLDialog)
                                   || ctrl.Equals(LayoutFinalPage)
                                   || ctrl.Equals(LayoutSettingsPage)
                                   || ctrl.Equals(LayoutLang)
                                   || ctrl.Equals(LayoutStartMenu))
            {
                return;
            }

            if (ctrl.Equals(LabelCopyright) || ctrl.Equals(LabelVersion) ||
                ctrl.Equals(LblPointerToFilePage) ||
                ctrl.Equals(LblPointerToGalleryPage))
            {
                ctrl.ForeColor = a;
                return;
            }

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
            //using (Image placeholder = new Bitmap(GAME_TYPES[_gameSelected].PortraitPlaceholderImage))
            //{
            //    ClearPictureBoxImages(placeholder);
            //}
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
                path.Split('\\').Last() == "Portraits")
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
    
        public void LoadText()
        {
            Text = TextVariables.MAIN_MENU_TITLE;
            ButtonStartKing.Text = TextVariables.NAME_KING;
            ButtonStartWotr.Text = TextVariables.NAME_WOTR;
            ButtonStartRt.Text = TextVariables.NAME_ROGUE;
            ButtonStartPoe.Text = TextVariables.NAME_PILLARS;
            ButtonStartPoed.Text = TextVariables.NAME_DEADFIRE;
            ButtonStartTyr.Text = TextVariables.NAME_TYR;
            ButtonStartW3.Text = TextVariables.NAME_WASTE;
            LabelAuthor.Text = TextVariables.MAIN_MENU_AUTHOR;
            LabelSelectPathTitle.Text = TextVariables.NAME_KING;
            LabelStartSelectPath.Text = TextVariables.BUTTON_CHOOSE;
            LabelStartResetPath.Text = TextVariables.BUTTON_RESET;
        }

        public void LoadFont(PrivateFontCollection fonts, ushort familyLang = 0, int initSize = 9)
        {
            Font bebasNeueFullHeader = new Font(fonts.Families[familyLang], initSize + 16),
                 bebasNeueHead = new Font(fonts.Families[familyLang], initSize + 12),
                 bebasNeueUnder = new Font(fonts.Families[familyLang], initSize + 8),
                 bebasNeueMedium = new Font(fonts.Families[familyLang], initSize + 4),
                 bebasNeueSmall = new Font(fonts.Families[familyLang], initSize);

            ButtonStartKing.Font = bebasNeueMedium;
            ButtonStartWotr.Font = bebasNeueMedium;
            ButtonStartRt.Font = bebasNeueMedium;
            ButtonStartPoe.Font = bebasNeueMedium;
            ButtonStartPoed.Font = bebasNeueMedium;
            ButtonStartTyr.Font = bebasNeueMedium;
            ButtonStartW3.Font = bebasNeueMedium;
            LabelSelectPathTitle.Font = bebasNeueFullHeader;
            LabelStartSelectPath.Font = bebasNeueUnder;
            LabelStartResetPath.Font = bebasNeueUnder;
        }

        private void OpenPathSelectPage()
        {
            _activeMenuIndex = 1;
            ParentLayoutsDisable();
            LabelStartResetPath_Click(this, new EventArgs());
            RootFunctions.LayoutEnable(LayoutPathPage);
        }
    }
}
