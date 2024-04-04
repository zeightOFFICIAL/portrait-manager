/*    
    Portrait Manager: Owlcat. Desktop application for managing in game
    portraits for Owlcat Games products. Including: 1. Pathfinder: Kingmaker,
    2. Pathfinder: Wrath of the Righteous, 3. Warhammer 40000: Rogue Trader
    Copyright (C) 2024 Artemii "Zeight" Saganenko.

    GPL-2.0 license terms are listed in LICENSE file.
    License header for this project is listed in Program.cs.
*/


namespace OwlcatPortraitManager
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.LayoutFilePage = new System.Windows.Forms.TableLayoutPanel();
            this.LayoutUnnamed1 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonLocalPortraitLoad = new System.Windows.Forms.Button();
            this.ButtonToScalePage = new System.Windows.Forms.Button();
            this.ButtonWebPortraitLoad = new System.Windows.Forms.Button();
            this.ButtonHintOnFilePage = new System.Windows.Forms.Button();
            this.ButtonNextImageType = new System.Windows.Forms.Button();
            this.ButtonToMainPage = new System.Windows.Forms.Button();
            this.LayoutUnnamed5 = new System.Windows.Forms.TableLayoutPanel();
            this.PanelPortraitTemp = new System.Windows.Forms.Panel();
            this.PicPortraitTemp = new System.Windows.Forms.PictureBox();
            this.LabelImageFlag = new System.Windows.Forms.Label();
            this.LayoutScalePage = new System.Windows.Forms.TableLayoutPanel();
            this.LayoutUnnamed2 = new System.Windows.Forms.TableLayoutPanel();
            this.PanelPortraitLrg = new System.Windows.Forms.Panel();
            this.PicPortraitLrg = new System.Windows.Forms.PictureBox();
            this.PanelPortraitMed = new System.Windows.Forms.Panel();
            this.PicPortraitMed = new System.Windows.Forms.PictureBox();
            this.PanelPortraitSml = new System.Windows.Forms.Panel();
            this.PicPortraitSml = new System.Windows.Forms.PictureBox();
            this.LayoutUnnamed3 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonHintOnScalePage = new System.Windows.Forms.Button();
            this.ButtonToFilePage2 = new System.Windows.Forms.Button();
            this.ButtonCreatePortrait = new System.Windows.Forms.Button();
            this.LayoutUnnamed4 = new System.Windows.Forms.TableLayoutPanel();
            this.LabelMedImage = new System.Windows.Forms.Label();
            this.LabelLrgImg = new System.Windows.Forms.Label();
            this.LabelSmlImg = new System.Windows.Forms.Label();
            this.LayoutMainPage = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonToFilePage = new System.Windows.Forms.Button();
            this.ButtonToExtractPage = new System.Windows.Forms.Button();
            this.ButtonToGalleryPage = new System.Windows.Forms.Button();
            this.PictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.LabelCopyright = new System.Windows.Forms.Label();
            this.ButtonToSettingsPage = new System.Windows.Forms.Button();
            this.ButtonExit = new System.Windows.Forms.Button();
            this.LayoutLang = new System.Windows.Forms.TableLayoutPanel();
            this.PicBoxEng = new System.Windows.Forms.PictureBox();
            this.PicBoxRus = new System.Windows.Forms.PictureBox();
            this.PicBoxGer = new System.Windows.Forms.PictureBox();
            this.PicBoxFra = new System.Windows.Forms.PictureBox();
            this.LabelVersion = new System.Windows.Forms.Label();
            this.LblPointerToFilePage = new System.Windows.Forms.Label();
            this.LblPointerToExtractPage = new System.Windows.Forms.Label();
            this.LblPointerToGalleryPage = new System.Windows.Forms.Label();
            this.LayoutExtractPage = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.ListExtract = new System.Windows.Forms.ListView();
            this.ImgListExtract = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonChooseFolder = new System.Windows.Forms.Button();
            this.ButtonExtractAll = new System.Windows.Forms.Button();
            this.ButtonExtractSelected = new System.Windows.Forms.Button();
            this.ButtonOpenFolders = new System.Windows.Forms.Button();
            this.ButtonToMainPage2 = new System.Windows.Forms.Button();
            this.ButtonHintExtract = new System.Windows.Forms.Button();
            this.LayoutUnnamed10 = new System.Windows.Forms.TableLayoutPanel();
            this.ListGallery = new System.Windows.Forms.ListView();
            this.ImgListGallery = new System.Windows.Forms.ImageList(this.components);
            this.LayoutUnnamed11 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonToMainPage3 = new System.Windows.Forms.Button();
            this.ButtonOpenFolder = new System.Windows.Forms.Button();
            this.ButtonDeletePortait = new System.Windows.Forms.Button();
            this.ButtonChangePortrait = new System.Windows.Forms.Button();
            this.ButtonHintFolder = new System.Windows.Forms.Button();
            this.LayoutGallery = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonLoadNormal = new System.Windows.Forms.Button();
            this.ButtonLoadCustom = new System.Windows.Forms.Button();
            this.ButtonLoadCustomNPC = new System.Windows.Forms.Button();
            this.ButtonLoadCustomArmy = new System.Windows.Forms.Button();
            this.LayoutURLDialog = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LabelURLInfo = new System.Windows.Forms.Label();
            this.TextBoxURL = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonDenyWeb = new System.Windows.Forms.Button();
            this.ButtonLoadWeb = new System.Windows.Forms.Button();
            this.LayoutFinalPage = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonToMainPage4 = new System.Windows.Forms.Button();
            this.ButtonToFilePage3 = new System.Windows.Forms.Button();
            this.ButtonToMainPageAndFolder = new System.Windows.Forms.Button();
            this.LabelFinalMesg = new System.Windows.Forms.Label();
            this.LabelDirLoc = new System.Windows.Forms.Label();
            this.LayoutSettingsPage = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonKingmaker = new System.Windows.Forms.Button();
            this.ButtonWotR = new System.Windows.Forms.Button();
            this.ButtonRT = new System.Windows.Forms.Button();
            this.ButtonToMainPage5 = new System.Windows.Forms.Button();
            this.LabelSelectedPath = new System.Windows.Forms.Label();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonValidatePath = new System.Windows.Forms.Button();
            this.ButtonSelectPath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonApplyChange = new System.Windows.Forms.Button();
            this.LabelSettings = new System.Windows.Forms.Label();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonRestorePath = new System.Windows.Forms.Button();
            this.TextBoxFullPath = new System.Windows.Forms.TextBox();
            this.LayoutUnnamed16 = new System.Windows.Forms.TableLayoutPanel();
            this.CheckBoxVerified = new System.Windows.Forms.CheckBox();
            this.LabelLang = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LayoutFilePage.SuspendLayout();
            this.LayoutUnnamed1.SuspendLayout();
            this.LayoutUnnamed5.SuspendLayout();
            this.PanelPortraitTemp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPortraitTemp)).BeginInit();
            this.LayoutScalePage.SuspendLayout();
            this.LayoutUnnamed2.SuspendLayout();
            this.PanelPortraitLrg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPortraitLrg)).BeginInit();
            this.PanelPortraitMed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPortraitMed)).BeginInit();
            this.PanelPortraitSml.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPortraitSml)).BeginInit();
            this.LayoutUnnamed3.SuspendLayout();
            this.LayoutUnnamed4.SuspendLayout();
            this.LayoutMainPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxTitle)).BeginInit();
            this.LayoutLang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxEng)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxRus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxGer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxFra)).BeginInit();
            this.LayoutExtractPage.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.LayoutUnnamed10.SuspendLayout();
            this.LayoutUnnamed11.SuspendLayout();
            this.LayoutGallery.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.LayoutURLDialog.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.LayoutFinalPage.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.LayoutSettingsPage.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.LayoutUnnamed16.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutFilePage
            // 
            this.LayoutFilePage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(28)))), ((int)(((byte)(11)))));
            this.LayoutFilePage.ColumnCount = 5;
            this.LayoutFilePage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.693529F));
            this.LayoutFilePage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.82011F));
            this.LayoutFilePage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.34627F));
            this.LayoutFilePage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.44656F));
            this.LayoutFilePage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.693529F));
            this.LayoutFilePage.Controls.Add(this.LayoutUnnamed1, 3, 0);
            this.LayoutFilePage.Controls.Add(this.LayoutUnnamed5, 1, 0);
            this.LayoutFilePage.ForeColor = System.Drawing.Color.White;
            this.LayoutFilePage.Location = new System.Drawing.Point(3, 0);
            this.LayoutFilePage.Name = "LayoutFilePage";
            this.LayoutFilePage.RowCount = 1;
            this.LayoutFilePage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutFilePage.Size = new System.Drawing.Size(805, 539);
            this.LayoutFilePage.TabIndex = 1;
            // 
            // LayoutUnnamed1
            // 
            this.LayoutUnnamed1.ColumnCount = 2;
            this.LayoutUnnamed1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutUnnamed1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutUnnamed1.Controls.Add(this.ButtonLocalPortraitLoad, 1, 1);
            this.LayoutUnnamed1.Controls.Add(this.ButtonToScalePage, 1, 4);
            this.LayoutUnnamed1.Controls.Add(this.ButtonWebPortraitLoad, 1, 2);
            this.LayoutUnnamed1.Controls.Add(this.ButtonHintOnFilePage, 1, 8);
            this.LayoutUnnamed1.Controls.Add(this.ButtonNextImageType, 1, 5);
            this.LayoutUnnamed1.Controls.Add(this.ButtonToMainPage, 1, 6);
            this.LayoutUnnamed1.Controls.Add(this.label3, 0, 1);
            this.LayoutUnnamed1.Controls.Add(this.label4, 0, 2);
            this.LayoutUnnamed1.Controls.Add(this.label5, 0, 6);
            this.LayoutUnnamed1.Controls.Add(this.label6, 0, 4);
            this.LayoutUnnamed1.Controls.Add(this.label7, 0, 5);
            this.LayoutUnnamed1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutUnnamed1.Location = new System.Drawing.Point(467, 3);
            this.LayoutUnnamed1.Name = "LayoutUnnamed1";
            this.LayoutUnnamed1.RowCount = 10;
            this.LayoutUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutUnnamed1.Size = new System.Drawing.Size(271, 533);
            this.LayoutUnnamed1.TabIndex = 0;
            // 
            // ButtonLocalPortraitLoad
            // 
            this.ButtonLocalPortraitLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonLocalPortraitLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonLocalPortraitLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonLocalPortraitLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonLocalPortraitLoad.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonLocalPortraitLoad.Location = new System.Drawing.Point(48, 89);
            this.ButtonLocalPortraitLoad.Name = "ButtonLocalPortraitLoad";
            this.ButtonLocalPortraitLoad.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ButtonLocalPortraitLoad.Size = new System.Drawing.Size(220, 39);
            this.ButtonLocalPortraitLoad.TabIndex = 2;
            this.ButtonLocalPortraitLoad.Text = "LoadLocal";
            this.ButtonLocalPortraitLoad.UseVisualStyleBackColor = true;
            this.ButtonLocalPortraitLoad.Click += new System.EventHandler(this.ButtonLocalPortraitLoad_Click);
            this.ButtonLocalPortraitLoad.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonLocalPortraitLoad.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // ButtonToScalePage
            // 
            this.ButtonToScalePage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonToScalePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonToScalePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonToScalePage.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonToScalePage.Location = new System.Drawing.Point(48, 224);
            this.ButtonToScalePage.Name = "ButtonToScalePage";
            this.ButtonToScalePage.Size = new System.Drawing.Size(220, 39);
            this.ButtonToScalePage.TabIndex = 1;
            this.ButtonToScalePage.Text = "ToScalePage";
            this.ButtonToScalePage.UseVisualStyleBackColor = true;
            this.ButtonToScalePage.Click += new System.EventHandler(this.ButtonToScalePage_Click);
            this.ButtonToScalePage.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonToScalePage.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // ButtonWebPortraitLoad
            // 
            this.ButtonWebPortraitLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonWebPortraitLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonWebPortraitLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonWebPortraitLoad.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonWebPortraitLoad.Location = new System.Drawing.Point(48, 134);
            this.ButtonWebPortraitLoad.Name = "ButtonWebPortraitLoad";
            this.ButtonWebPortraitLoad.Size = new System.Drawing.Size(220, 39);
            this.ButtonWebPortraitLoad.TabIndex = 3;
            this.ButtonWebPortraitLoad.Text = "LoadWeb";
            this.ButtonWebPortraitLoad.UseVisualStyleBackColor = true;
            this.ButtonWebPortraitLoad.Click += new System.EventHandler(this.ButtonWebPortraitLoad_Click);
            this.ButtonWebPortraitLoad.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonWebPortraitLoad.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // ButtonHintOnFilePage
            // 
            this.ButtonHintOnFilePage.Cursor = System.Windows.Forms.Cursors.Help;
            this.ButtonHintOnFilePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonHintOnFilePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonHintOnFilePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonHintOnFilePage.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonHintOnFilePage.Location = new System.Drawing.Point(48, 404);
            this.ButtonHintOnFilePage.Name = "ButtonHintOnFilePage";
            this.ButtonHintOnFilePage.Size = new System.Drawing.Size(220, 39);
            this.ButtonHintOnFilePage.TabIndex = 6;
            this.ButtonHintOnFilePage.Text = "Hint";
            this.ButtonHintOnFilePage.UseVisualStyleBackColor = true;
            this.ButtonHintOnFilePage.Click += new System.EventHandler(this.ButtonHintOnFilePage_Click);
            this.ButtonHintOnFilePage.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonHintOnFilePage.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // ButtonNextImageType
            // 
            this.ButtonNextImageType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonNextImageType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonNextImageType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonNextImageType.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonNextImageType.Location = new System.Drawing.Point(48, 269);
            this.ButtonNextImageType.Name = "ButtonNextImageType";
            this.ButtonNextImageType.Size = new System.Drawing.Size(220, 39);
            this.ButtonNextImageType.TabIndex = 7;
            this.ButtonNextImageType.Text = "ToAdvancedPage";
            this.ButtonNextImageType.UseVisualStyleBackColor = true;
            this.ButtonNextImageType.Click += new System.EventHandler(this.ButtonNextImageType_Click);
            this.ButtonNextImageType.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonNextImageType.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // ButtonToMainPage
            // 
            this.ButtonToMainPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonToMainPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonToMainPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonToMainPage.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonToMainPage.Location = new System.Drawing.Point(48, 314);
            this.ButtonToMainPage.Name = "ButtonToMainPage";
            this.ButtonToMainPage.Size = new System.Drawing.Size(220, 39);
            this.ButtonToMainPage.TabIndex = 0;
            this.ButtonToMainPage.Text = "ToMainPage";
            this.ButtonToMainPage.UseVisualStyleBackColor = true;
            this.ButtonToMainPage.Click += new System.EventHandler(this.ButtonToMainPage_Click);
            this.ButtonToMainPage.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonToMainPage.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // LayoutUnnamed5
            // 
            this.LayoutUnnamed5.ColumnCount = 1;
            this.LayoutUnnamed5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutUnnamed5.Controls.Add(this.PanelPortraitTemp, 0, 1);
            this.LayoutUnnamed5.Controls.Add(this.LabelImageFlag, 0, 2);
            this.LayoutUnnamed5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutUnnamed5.Location = new System.Drawing.Point(64, 3);
            this.LayoutUnnamed5.Name = "LayoutUnnamed5";
            this.LayoutUnnamed5.RowCount = 3;
            this.LayoutUnnamed5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.384029F));
            this.LayoutUnnamed5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.8503F));
            this.LayoutUnnamed5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.765676F));
            this.LayoutUnnamed5.Size = new System.Drawing.Size(346, 533);
            this.LayoutUnnamed5.TabIndex = 1;
            // 
            // PanelPortraitTemp
            // 
            this.PanelPortraitTemp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelPortraitTemp.Controls.Add(this.PicPortraitTemp);
            this.PanelPortraitTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelPortraitTemp.Location = new System.Drawing.Point(0, 23);
            this.PanelPortraitTemp.Margin = new System.Windows.Forms.Padding(0);
            this.PanelPortraitTemp.Name = "PanelPortraitTemp";
            this.PanelPortraitTemp.Size = new System.Drawing.Size(346, 462);
            this.PanelPortraitTemp.TabIndex = 1;
            // 
            // PicPortraitTemp
            // 
            this.PicPortraitTemp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicPortraitTemp.ErrorImage = ((System.Drawing.Image)(resources.GetObject("PicPortraitTemp.ErrorImage")));
            this.PicPortraitTemp.Image = ((System.Drawing.Image)(resources.GetObject("PicPortraitTemp.Image")));
            this.PicPortraitTemp.InitialImage = ((System.Drawing.Image)(resources.GetObject("PicPortraitTemp.InitialImage")));
            this.PicPortraitTemp.Location = new System.Drawing.Point(0, 0);
            this.PicPortraitTemp.Margin = new System.Windows.Forms.Padding(0);
            this.PicPortraitTemp.Name = "PicPortraitTemp";
            this.PicPortraitTemp.Size = new System.Drawing.Size(664, 1007);
            this.PicPortraitTemp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicPortraitTemp.TabIndex = 1;
            this.PicPortraitTemp.TabStop = false;
            this.PicPortraitTemp.Click += new System.EventHandler(this.PicPortraitTemp_Click);
            this.PicPortraitTemp.DragDrop += new System.Windows.Forms.DragEventHandler(this.PicPortraitTemp_DragDrop);
            this.PicPortraitTemp.DragEnter += new System.Windows.Forms.DragEventHandler(this.PicPortraitTemp_DragEnter);
            // 
            // LabelImageFlag
            // 
            this.LabelImageFlag.AutoSize = true;
            this.LabelImageFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelImageFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelImageFlag.ForeColor = System.Drawing.Color.Goldenrod;
            this.LabelImageFlag.Location = new System.Drawing.Point(3, 485);
            this.LabelImageFlag.Name = "LabelImageFlag";
            this.LabelImageFlag.Size = new System.Drawing.Size(340, 48);
            this.LabelImageFlag.TabIndex = 2;
            this.LabelImageFlag.Text = "ImageFlag";
            this.LabelImageFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LayoutScalePage
            // 
            this.LayoutScalePage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(28)))), ((int)(((byte)(11)))));
            this.LayoutScalePage.ColumnCount = 1;
            this.LayoutScalePage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutScalePage.Controls.Add(this.LayoutUnnamed2, 0, 1);
            this.LayoutScalePage.Controls.Add(this.LayoutUnnamed3, 0, 3);
            this.LayoutScalePage.Controls.Add(this.LayoutUnnamed4, 0, 2);
            this.LayoutScalePage.ForeColor = System.Drawing.Color.White;
            this.LayoutScalePage.Location = new System.Drawing.Point(29, 0);
            this.LayoutScalePage.Name = "LayoutScalePage";
            this.LayoutScalePage.RowCount = 5;
            this.LayoutScalePage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.92792F));
            this.LayoutScalePage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.73881F));
            this.LayoutScalePage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.LayoutScalePage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.LayoutScalePage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.333276F));
            this.LayoutScalePage.Size = new System.Drawing.Size(26, 481);
            this.LayoutScalePage.TabIndex = 2;
            // 
            // LayoutUnnamed2
            // 
            this.LayoutUnnamed2.ColumnCount = 5;
            this.LayoutUnnamed2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.731966F));
            this.LayoutUnnamed2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.36763F));
            this.LayoutUnnamed2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.79687F));
            this.LayoutUnnamed2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.37157F));
            this.LayoutUnnamed2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.731966F));
            this.LayoutUnnamed2.Controls.Add(this.PanelPortraitLrg, 2, 0);
            this.LayoutUnnamed2.Controls.Add(this.PanelPortraitMed, 1, 0);
            this.LayoutUnnamed2.Controls.Add(this.PanelPortraitSml, 3, 0);
            this.LayoutUnnamed2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutUnnamed2.Location = new System.Drawing.Point(3, 44);
            this.LayoutUnnamed2.Name = "LayoutUnnamed2";
            this.LayoutUnnamed2.RowCount = 1;
            this.LayoutUnnamed2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutUnnamed2.Size = new System.Drawing.Size(20, 313);
            this.LayoutUnnamed2.TabIndex = 0;
            // 
            // PanelPortraitLrg
            // 
            this.PanelPortraitLrg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelPortraitLrg.Controls.Add(this.PicPortraitLrg);
            this.PanelPortraitLrg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelPortraitLrg.Location = new System.Drawing.Point(8, 3);
            this.PanelPortraitLrg.Name = "PanelPortraitLrg";
            this.PanelPortraitLrg.Padding = new System.Windows.Forms.Padding(10);
            this.PanelPortraitLrg.Size = new System.Drawing.Size(1, 307);
            this.PanelPortraitLrg.TabIndex = 3;
            // 
            // PicPortraitLrg
            // 
            this.PicPortraitLrg.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PicPortraitLrg.Image = ((System.Drawing.Image)(resources.GetObject("PicPortraitLrg.Image")));
            this.PicPortraitLrg.Location = new System.Drawing.Point(0, 0);
            this.PicPortraitLrg.Name = "PicPortraitLrg";
            this.PicPortraitLrg.Size = new System.Drawing.Size(664, 1007);
            this.PicPortraitLrg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicPortraitLrg.TabIndex = 0;
            this.PicPortraitLrg.TabStop = false;
            this.PicPortraitLrg.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PicPortraitLrg_MouseDoubleClick);
            this.PicPortraitLrg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicPortraitLrg_MouseDown);
            this.PicPortraitLrg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicPortraitLrg_MouseMove);
            this.PicPortraitLrg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicPortraitLrg_MouseUp);
            // 
            // PanelPortraitMed
            // 
            this.PanelPortraitMed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelPortraitMed.Controls.Add(this.PicPortraitMed);
            this.PanelPortraitMed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelPortraitMed.Location = new System.Drawing.Point(3, 3);
            this.PanelPortraitMed.Name = "PanelPortraitMed";
            this.PanelPortraitMed.Padding = new System.Windows.Forms.Padding(10);
            this.PanelPortraitMed.Size = new System.Drawing.Size(1, 307);
            this.PanelPortraitMed.TabIndex = 4;
            // 
            // PicPortraitMed
            // 
            this.PicPortraitMed.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PicPortraitMed.Image = ((System.Drawing.Image)(resources.GetObject("PicPortraitMed.Image")));
            this.PicPortraitMed.Location = new System.Drawing.Point(0, 0);
            this.PicPortraitMed.Name = "PicPortraitMed";
            this.PicPortraitMed.Size = new System.Drawing.Size(664, 1007);
            this.PicPortraitMed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicPortraitMed.TabIndex = 1;
            this.PicPortraitMed.TabStop = false;
            this.PicPortraitMed.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PicPortraitMed_MouseDoubleClick);
            this.PicPortraitMed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicPortraitMed_MouseDown);
            this.PicPortraitMed.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicPortraitMed_MouseMove);
            this.PicPortraitMed.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicPortraitMed_MouseUp);
            // 
            // PanelPortraitSml
            // 
            this.PanelPortraitSml.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelPortraitSml.Controls.Add(this.PicPortraitSml);
            this.PanelPortraitSml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelPortraitSml.Location = new System.Drawing.Point(14, 3);
            this.PanelPortraitSml.Name = "PanelPortraitSml";
            this.PanelPortraitSml.Padding = new System.Windows.Forms.Padding(10);
            this.PanelPortraitSml.Size = new System.Drawing.Size(1, 307);
            this.PanelPortraitSml.TabIndex = 5;
            // 
            // PicPortraitSml
            // 
            this.PicPortraitSml.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PicPortraitSml.Image = ((System.Drawing.Image)(resources.GetObject("PicPortraitSml.Image")));
            this.PicPortraitSml.Location = new System.Drawing.Point(0, 0);
            this.PicPortraitSml.Name = "PicPortraitSml";
            this.PicPortraitSml.Size = new System.Drawing.Size(664, 1007);
            this.PicPortraitSml.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicPortraitSml.TabIndex = 2;
            this.PicPortraitSml.TabStop = false;
            this.PicPortraitSml.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PicPortraitSml_MouseDoubleClick);
            this.PicPortraitSml.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicPortraitSml_MouseDown);
            this.PicPortraitSml.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicPortraitSml_MouseMove);
            this.PicPortraitSml.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicPortraitSml_MouseUp);
            // 
            // LayoutUnnamed3
            // 
            this.LayoutUnnamed3.ColumnCount = 7;
            this.LayoutUnnamed3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.34377F));
            this.LayoutUnnamed3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.LayoutUnnamed3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.666885F));
            this.LayoutUnnamed3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.LayoutUnnamed3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.696623F));
            this.LayoutUnnamed3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.39325F));
            this.LayoutUnnamed3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.89948F));
            this.LayoutUnnamed3.Controls.Add(this.ButtonHintOnScalePage, 5, 0);
            this.LayoutUnnamed3.Controls.Add(this.ButtonToFilePage2, 1, 0);
            this.LayoutUnnamed3.Controls.Add(this.ButtonCreatePortrait, 3, 0);
            this.LayoutUnnamed3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutUnnamed3.Location = new System.Drawing.Point(3, 413);
            this.LayoutUnnamed3.Name = "LayoutUnnamed3";
            this.LayoutUnnamed3.RowCount = 1;
            this.LayoutUnnamed3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutUnnamed3.Size = new System.Drawing.Size(20, 44);
            this.LayoutUnnamed3.TabIndex = 1;
            // 
            // ButtonHintOnScalePage
            // 
            this.ButtonHintOnScalePage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonHintOnScalePage.Cursor = System.Windows.Forms.Cursors.Help;
            this.ButtonHintOnScalePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonHintOnScalePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonHintOnScalePage.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonHintOnScalePage.Location = new System.Drawing.Point(153, 3);
            this.ButtonHintOnScalePage.Name = "ButtonHintOnScalePage";
            this.ButtonHintOnScalePage.Size = new System.Drawing.Size(1, 38);
            this.ButtonHintOnScalePage.TabIndex = 0;
            this.ButtonHintOnScalePage.Text = "Hint";
            this.ButtonHintOnScalePage.UseVisualStyleBackColor = true;
            this.ButtonHintOnScalePage.Click += new System.EventHandler(this.ButtonHintOnScalePage_Click);
            this.ButtonHintOnScalePage.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonHintOnScalePage.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // ButtonToFilePage2
            // 
            this.ButtonToFilePage2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonToFilePage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonToFilePage2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonToFilePage2.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonToFilePage2.Location = new System.Drawing.Point(-148, 3);
            this.ButtonToFilePage2.Name = "ButtonToFilePage2";
            this.ButtonToFilePage2.Size = new System.Drawing.Size(164, 38);
            this.ButtonToFilePage2.TabIndex = 0;
            this.ButtonToFilePage2.Text = "ToFilePage";
            this.ButtonToFilePage2.UseVisualStyleBackColor = true;
            this.ButtonToFilePage2.Click += new System.EventHandler(this.ButtonToFilePage2_Click);
            this.ButtonToFilePage2.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonToFilePage2.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // ButtonCreatePortrait
            // 
            this.ButtonCreatePortrait.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonCreatePortrait.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonCreatePortrait.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonCreatePortrait.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonCreatePortrait.Location = new System.Drawing.Point(4, 3);
            this.ButtonCreatePortrait.Name = "ButtonCreatePortrait";
            this.ButtonCreatePortrait.Size = new System.Drawing.Size(164, 38);
            this.ButtonCreatePortrait.TabIndex = 2;
            this.ButtonCreatePortrait.Text = "ToCreatePortrait";
            this.ButtonCreatePortrait.UseVisualStyleBackColor = true;
            this.ButtonCreatePortrait.Click += new System.EventHandler(this.ButtonCreatePortrait_Click);
            this.ButtonCreatePortrait.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonCreatePortrait.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // LayoutUnnamed4
            // 
            this.LayoutUnnamed4.ColumnCount = 5;
            this.LayoutUnnamed4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.627249F));
            this.LayoutUnnamed4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.38005F));
            this.LayoutUnnamed4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.67116F));
            this.LayoutUnnamed4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.11051F));
            this.LayoutUnnamed4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.9922F));
            this.LayoutUnnamed4.Controls.Add(this.LabelMedImage, 1, 0);
            this.LayoutUnnamed4.Controls.Add(this.LabelLrgImg, 2, 0);
            this.LayoutUnnamed4.Controls.Add(this.LabelSmlImg, 3, 0);
            this.LayoutUnnamed4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutUnnamed4.Location = new System.Drawing.Point(3, 363);
            this.LayoutUnnamed4.Name = "LayoutUnnamed4";
            this.LayoutUnnamed4.RowCount = 1;
            this.LayoutUnnamed4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutUnnamed4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.LayoutUnnamed4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.LayoutUnnamed4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.LayoutUnnamed4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.LayoutUnnamed4.Size = new System.Drawing.Size(20, 44);
            this.LayoutUnnamed4.TabIndex = 2;
            // 
            // LabelMedImage
            // 
            this.LabelMedImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelMedImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LabelMedImage.ForeColor = System.Drawing.Color.Goldenrod;
            this.LabelMedImage.Location = new System.Drawing.Point(3, 0);
            this.LabelMedImage.Name = "LabelMedImage";
            this.LabelMedImage.Size = new System.Drawing.Size(1, 44);
            this.LabelMedImage.TabIndex = 0;
            this.LabelMedImage.Text = "ForMedImage";
            this.LabelMedImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelMedImage.MouseLeave += new System.EventHandler(this.LabelMedImg_MouseLeave);
            this.LabelMedImage.MouseHover += new System.EventHandler(this.LabelMedImg_MouseHover);
            // 
            // LabelLrgImg
            // 
            this.LabelLrgImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelLrgImg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LabelLrgImg.ForeColor = System.Drawing.Color.Goldenrod;
            this.LabelLrgImg.Location = new System.Drawing.Point(8, 0);
            this.LabelLrgImg.Name = "LabelLrgImg";
            this.LabelLrgImg.Size = new System.Drawing.Size(1, 44);
            this.LabelLrgImg.TabIndex = 1;
            this.LabelLrgImg.Text = "ForLrgImage";
            this.LabelLrgImg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelLrgImg.MouseLeave += new System.EventHandler(this.LabelLrgImg_MouseLeave);
            this.LabelLrgImg.MouseHover += new System.EventHandler(this.LabelLrgImg_MouseHover);
            // 
            // LabelSmlImg
            // 
            this.LabelSmlImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelSmlImg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LabelSmlImg.ForeColor = System.Drawing.Color.Goldenrod;
            this.LabelSmlImg.Location = new System.Drawing.Point(14, 0);
            this.LabelSmlImg.Name = "LabelSmlImg";
            this.LabelSmlImg.Size = new System.Drawing.Size(1, 44);
            this.LabelSmlImg.TabIndex = 2;
            this.LabelSmlImg.Text = "ForSmlImage";
            this.LabelSmlImg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelSmlImg.MouseLeave += new System.EventHandler(this.LabelSmlImg_MouseLeave);
            this.LabelSmlImg.MouseHover += new System.EventHandler(this.LabelSmlImg_MouseHover);
            // 
            // LayoutMainPage
            // 
            this.LayoutMainPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(28)))), ((int)(((byte)(11)))));
            this.LayoutMainPage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LayoutMainPage.BackgroundImage")));
            this.LayoutMainPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LayoutMainPage.ColumnCount = 3;
            this.LayoutMainPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutMainPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 330F));
            this.LayoutMainPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutMainPage.Controls.Add(this.ButtonToFilePage, 1, 2);
            this.LayoutMainPage.Controls.Add(this.ButtonToExtractPage, 1, 3);
            this.LayoutMainPage.Controls.Add(this.ButtonToGalleryPage, 1, 4);
            this.LayoutMainPage.Controls.Add(this.PictureBoxTitle, 1, 1);
            this.LayoutMainPage.Controls.Add(this.LabelCopyright, 1, 7);
            this.LayoutMainPage.Controls.Add(this.ButtonToSettingsPage, 1, 5);
            this.LayoutMainPage.Controls.Add(this.ButtonExit, 1, 6);
            this.LayoutMainPage.Controls.Add(this.LayoutLang, 0, 0);
            this.LayoutMainPage.Controls.Add(this.LabelVersion, 2, 7);
            this.LayoutMainPage.Controls.Add(this.LblPointerToFilePage, 0, 2);
            this.LayoutMainPage.Controls.Add(this.LblPointerToExtractPage, 0, 3);
            this.LayoutMainPage.Controls.Add(this.LblPointerToGalleryPage, 0, 4);
            this.LayoutMainPage.Location = new System.Drawing.Point(0, 0);
            this.LayoutMainPage.Name = "LayoutMainPage";
            this.LayoutMainPage.RowCount = 8;
            this.LayoutMainPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.LayoutMainPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this.LayoutMainPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutMainPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutMainPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutMainPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutMainPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutMainPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.LayoutMainPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LayoutMainPage.Size = new System.Drawing.Size(23, 558);
            this.LayoutMainPage.TabIndex = 0;
            // 
            // ButtonToFilePage
            // 
            this.ButtonToFilePage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonToFilePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonToFilePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonToFilePage.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonToFilePage.Location = new System.Drawing.Point(-150, 251);
            this.ButtonToFilePage.Name = "ButtonToFilePage";
            this.ButtonToFilePage.Size = new System.Drawing.Size(324, 39);
            this.ButtonToFilePage.TabIndex = 0;
            this.ButtonToFilePage.Text = "ToFilePage";
            this.ButtonToFilePage.UseVisualStyleBackColor = true;
            this.ButtonToFilePage.Click += new System.EventHandler(this.ButtonToFilePage_Click);
            this.ButtonToFilePage.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonToFilePage.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // ButtonToExtractPage
            // 
            this.ButtonToExtractPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonToExtractPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonToExtractPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonToExtractPage.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonToExtractPage.Location = new System.Drawing.Point(-150, 296);
            this.ButtonToExtractPage.Name = "ButtonToExtractPage";
            this.ButtonToExtractPage.Size = new System.Drawing.Size(324, 39);
            this.ButtonToExtractPage.TabIndex = 3;
            this.ButtonToExtractPage.Text = "ToExtractPage";
            this.ButtonToExtractPage.UseVisualStyleBackColor = true;
            this.ButtonToExtractPage.Click += new System.EventHandler(this.ButtonToExtract_Click);
            this.ButtonToExtractPage.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonToExtractPage.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // ButtonToGalleryPage
            // 
            this.ButtonToGalleryPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonToGalleryPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonToGalleryPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonToGalleryPage.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonToGalleryPage.Location = new System.Drawing.Point(-150, 341);
            this.ButtonToGalleryPage.Name = "ButtonToGalleryPage";
            this.ButtonToGalleryPage.Size = new System.Drawing.Size(324, 39);
            this.ButtonToGalleryPage.TabIndex = 2;
            this.ButtonToGalleryPage.Text = "ToGalleryPage";
            this.ButtonToGalleryPage.UseVisualStyleBackColor = true;
            this.ButtonToGalleryPage.Click += new System.EventHandler(this.ButtonToGalleryPage_Click);
            this.ButtonToGalleryPage.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonToGalleryPage.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // PictureBoxTitle
            // 
            this.PictureBoxTitle.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxTitle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PictureBoxTitle.BackgroundImage")));
            this.PictureBoxTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PictureBoxTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBoxTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBoxTitle.Location = new System.Drawing.Point(-150, 86);
            this.PictureBoxTitle.Name = "PictureBoxTitle";
            this.PictureBoxTitle.Size = new System.Drawing.Size(324, 159);
            this.PictureBoxTitle.TabIndex = 4;
            this.PictureBoxTitle.TabStop = false;
            this.PictureBoxTitle.Click += new System.EventHandler(this.PictureBoxTitle_Click);
            // 
            // LabelCopyright
            // 
            this.LabelCopyright.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LabelCopyright.AutoSize = true;
            this.LabelCopyright.BackColor = System.Drawing.Color.Transparent;
            this.LabelCopyright.Cursor = System.Windows.Forms.Cursors.Help;
            this.LabelCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelCopyright.ForeColor = System.Drawing.Color.Goldenrod;
            this.LabelCopyright.Location = new System.Drawing.Point(-31, 542);
            this.LabelCopyright.Name = "LabelCopyright";
            this.LabelCopyright.Size = new System.Drawing.Size(86, 16);
            this.LabelCopyright.TabIndex = 5;
            this.LabelCopyright.Text = "COPYRIGHT";
            this.LabelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelCopyright.Click += new System.EventHandler(this.LabelCopyright_Click);
            // 
            // ButtonToSettingsPage
            // 
            this.ButtonToSettingsPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonToSettingsPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonToSettingsPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonToSettingsPage.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonToSettingsPage.Location = new System.Drawing.Point(-150, 386);
            this.ButtonToSettingsPage.Name = "ButtonToSettingsPage";
            this.ButtonToSettingsPage.Size = new System.Drawing.Size(324, 39);
            this.ButtonToSettingsPage.TabIndex = 6;
            this.ButtonToSettingsPage.Text = "ToSettingsPage";
            this.ButtonToSettingsPage.UseVisualStyleBackColor = true;
            this.ButtonToSettingsPage.Click += new System.EventHandler(this.ButtonToSettingsPage_Click);
            this.ButtonToSettingsPage.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonToSettingsPage.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // ButtonExit
            // 
            this.ButtonExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonExit.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonExit.Location = new System.Drawing.Point(-150, 431);
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.Size = new System.Drawing.Size(324, 39);
            this.ButtonExit.TabIndex = 1;
            this.ButtonExit.Text = "ToExit";
            this.ButtonExit.UseVisualStyleBackColor = true;
            this.ButtonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            this.ButtonExit.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonExit.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // LayoutLang
            // 
            this.LayoutLang.BackColor = System.Drawing.Color.Transparent;
            this.LayoutLang.ColumnCount = 5;
            this.LayoutLang.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.LayoutLang.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.LayoutLang.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.LayoutLang.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.LayoutLang.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.LayoutLang.Controls.Add(this.PicBoxEng, 0, 0);
            this.LayoutLang.Controls.Add(this.PicBoxRus, 1, 0);
            this.LayoutLang.Controls.Add(this.PicBoxGer, 3, 0);
            this.LayoutLang.Controls.Add(this.PicBoxFra, 2, 0);
            this.LayoutLang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutLang.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LayoutLang.Location = new System.Drawing.Point(3, 3);
            this.LayoutLang.Name = "LayoutLang";
            this.LayoutLang.RowCount = 2;
            this.LayoutLang.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.LayoutLang.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LayoutLang.Size = new System.Drawing.Size(1, 77);
            this.LayoutLang.TabIndex = 8;
            // 
            // PicBoxEng
            // 
            this.PicBoxEng.BackgroundImage = global::OwlcatPortraitManager.Properties.Resources.eng;
            this.PicBoxEng.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PicBoxEng.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicBoxEng.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicBoxEng.Location = new System.Drawing.Point(3, 3);
            this.PicBoxEng.Name = "PicBoxEng";
            this.PicBoxEng.Size = new System.Drawing.Size(34, 19);
            this.PicBoxEng.TabIndex = 0;
            this.PicBoxEng.TabStop = false;
            this.PicBoxEng.Click += new System.EventHandler(this.PicBoxEng_Click);
            // 
            // PicBoxRus
            // 
            this.PicBoxRus.BackgroundImage = global::OwlcatPortraitManager.Properties.Resources.rus;
            this.PicBoxRus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PicBoxRus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicBoxRus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicBoxRus.Location = new System.Drawing.Point(43, 3);
            this.PicBoxRus.Name = "PicBoxRus";
            this.PicBoxRus.Size = new System.Drawing.Size(34, 19);
            this.PicBoxRus.TabIndex = 1;
            this.PicBoxRus.TabStop = false;
            this.PicBoxRus.Click += new System.EventHandler(this.PicBoxRus_Click);
            // 
            // PicBoxGer
            // 
            this.PicBoxGer.BackgroundImage = global::OwlcatPortraitManager.Properties.Resources.ger;
            this.PicBoxGer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PicBoxGer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicBoxGer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicBoxGer.Location = new System.Drawing.Point(123, 3);
            this.PicBoxGer.Name = "PicBoxGer";
            this.PicBoxGer.Size = new System.Drawing.Size(34, 19);
            this.PicBoxGer.TabIndex = 2;
            this.PicBoxGer.TabStop = false;
            this.PicBoxGer.Click += new System.EventHandler(this.PicBoxGer_Click);
            // 
            // PicBoxFra
            // 
            this.PicBoxFra.BackgroundImage = global::OwlcatPortraitManager.Properties.Resources.fra;
            this.PicBoxFra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PicBoxFra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicBoxFra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicBoxFra.Location = new System.Drawing.Point(83, 3);
            this.PicBoxFra.Name = "PicBoxFra";
            this.PicBoxFra.Size = new System.Drawing.Size(34, 19);
            this.PicBoxFra.TabIndex = 3;
            this.PicBoxFra.TabStop = false;
            this.PicBoxFra.Click += new System.EventHandler(this.PicBoxFra_Click);
            // 
            // LabelVersion
            // 
            this.LabelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelVersion.AutoSize = true;
            this.LabelVersion.BackColor = System.Drawing.Color.Transparent;
            this.LabelVersion.Cursor = System.Windows.Forms.Cursors.Help;
            this.LabelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelVersion.ForeColor = System.Drawing.Color.Goldenrod;
            this.LabelVersion.Location = new System.Drawing.Point(180, 542);
            this.LabelVersion.Name = "LabelVersion";
            this.LabelVersion.Size = new System.Drawing.Size(1, 16);
            this.LabelVersion.TabIndex = 7;
            this.LabelVersion.Text = "1.3.5.0";
            this.LabelVersion.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.LabelVersion.Click += new System.EventHandler(this.LabelVersion_Click);
            // 
            // LblPointerToFilePage
            // 
            this.LblPointerToFilePage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblPointerToFilePage.AutoSize = true;
            this.LblPointerToFilePage.BackColor = System.Drawing.Color.Transparent;
            this.LblPointerToFilePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblPointerToFilePage.ForeColor = System.Drawing.Color.Goldenrod;
            this.LblPointerToFilePage.Location = new System.Drawing.Point(3, 263);
            this.LblPointerToFilePage.Name = "LblPointerToFilePage";
            this.LblPointerToFilePage.Size = new System.Drawing.Size(1, 15);
            this.LblPointerToFilePage.TabIndex = 9;
            this.LblPointerToFilePage.Text = "1.";
            this.LblPointerToFilePage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblPointerToExtractPage
            // 
            this.LblPointerToExtractPage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblPointerToExtractPage.AutoSize = true;
            this.LblPointerToExtractPage.BackColor = System.Drawing.Color.Transparent;
            this.LblPointerToExtractPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblPointerToExtractPage.ForeColor = System.Drawing.Color.Goldenrod;
            this.LblPointerToExtractPage.Location = new System.Drawing.Point(3, 308);
            this.LblPointerToExtractPage.Name = "LblPointerToExtractPage";
            this.LblPointerToExtractPage.Size = new System.Drawing.Size(1, 15);
            this.LblPointerToExtractPage.TabIndex = 10;
            this.LblPointerToExtractPage.Text = "2.";
            this.LblPointerToExtractPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblPointerToGalleryPage
            // 
            this.LblPointerToGalleryPage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblPointerToGalleryPage.AutoSize = true;
            this.LblPointerToGalleryPage.BackColor = System.Drawing.Color.Transparent;
            this.LblPointerToGalleryPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblPointerToGalleryPage.ForeColor = System.Drawing.Color.Goldenrod;
            this.LblPointerToGalleryPage.Location = new System.Drawing.Point(3, 353);
            this.LblPointerToGalleryPage.Name = "LblPointerToGalleryPage";
            this.LblPointerToGalleryPage.Size = new System.Drawing.Size(1, 15);
            this.LblPointerToGalleryPage.TabIndex = 11;
            this.LblPointerToGalleryPage.Text = "3.";
            this.LblPointerToGalleryPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LayoutExtractPage
            // 
            this.LayoutExtractPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(28)))), ((int)(((byte)(11)))));
            this.LayoutExtractPage.ColumnCount = 1;
            this.LayoutExtractPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutExtractPage.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.LayoutExtractPage.Enabled = false;
            this.LayoutExtractPage.ForeColor = System.Drawing.Color.White;
            this.LayoutExtractPage.Location = new System.Drawing.Point(481, 0);
            this.LayoutExtractPage.Name = "LayoutExtractPage";
            this.LayoutExtractPage.RowCount = 3;
            this.LayoutExtractPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.641887F));
            this.LayoutExtractPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.71623F));
            this.LayoutExtractPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.641887F));
            this.LayoutExtractPage.Size = new System.Drawing.Size(236, 481);
            this.LayoutExtractPage.TabIndex = 3;
            this.LayoutExtractPage.Visible = false;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 5;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.35F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.59F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.030001F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.030001F));
            this.tableLayoutPanel5.Controls.Add(this.ListExtract, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 3, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 44);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(230, 391);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // ListExtract
            // 
            this.ListExtract.BackColor = System.Drawing.Color.Black;
            this.ListExtract.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListExtract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListExtract.HideSelection = false;
            this.ListExtract.LargeImageList = this.ImgListExtract;
            this.ListExtract.Location = new System.Drawing.Point(3, 3);
            this.ListExtract.Name = "ListExtract";
            this.ListExtract.Size = new System.Drawing.Size(20, 385);
            this.ListExtract.TabIndex = 0;
            this.ListExtract.UseCompatibleStateImageBehavior = false;
            // 
            // ImgListExtract
            // 
            this.ImgListExtract.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.ImgListExtract.ImageSize = new System.Drawing.Size(100, 148);
            this.ImgListExtract.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.ButtonChooseFolder, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.ButtonExtractAll, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.ButtonExtractSelected, 0, 3);
            this.tableLayoutPanel6.Controls.Add(this.ButtonOpenFolders, 0, 5);
            this.tableLayoutPanel6.Controls.Add(this.ButtonToMainPage2, 0, 6);
            this.tableLayoutPanel6.Controls.Add(this.ButtonHintExtract, 0, 7);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(30, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 9;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(194, 385);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // ButtonChooseFolder
            // 
            this.ButtonChooseFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonChooseFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonChooseFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonChooseFolder.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonChooseFolder.Location = new System.Drawing.Point(3, 38);
            this.ButtonChooseFolder.Name = "ButtonChooseFolder";
            this.ButtonChooseFolder.Size = new System.Drawing.Size(188, 39);
            this.ButtonChooseFolder.TabIndex = 0;
            this.ButtonChooseFolder.Text = "ChooseFolder";
            this.ButtonChooseFolder.UseVisualStyleBackColor = true;
            this.ButtonChooseFolder.Click += new System.EventHandler(this.ButtonChooseFolder_Click);
            this.ButtonChooseFolder.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonChooseFolder.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // ButtonExtractAll
            // 
            this.ButtonExtractAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonExtractAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonExtractAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonExtractAll.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonExtractAll.Location = new System.Drawing.Point(3, 83);
            this.ButtonExtractAll.Name = "ButtonExtractAll";
            this.ButtonExtractAll.Size = new System.Drawing.Size(188, 39);
            this.ButtonExtractAll.TabIndex = 1;
            this.ButtonExtractAll.Text = "ExtrcAll";
            this.ButtonExtractAll.UseVisualStyleBackColor = true;
            this.ButtonExtractAll.Click += new System.EventHandler(this.ButtonExtractAll_Click);
            this.ButtonExtractAll.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonExtractAll.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // ButtonExtractSelected
            // 
            this.ButtonExtractSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonExtractSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonExtractSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonExtractSelected.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonExtractSelected.Location = new System.Drawing.Point(3, 128);
            this.ButtonExtractSelected.Name = "ButtonExtractSelected";
            this.ButtonExtractSelected.Size = new System.Drawing.Size(188, 39);
            this.ButtonExtractSelected.TabIndex = 2;
            this.ButtonExtractSelected.Text = "ExtrcSelected";
            this.ButtonExtractSelected.UseVisualStyleBackColor = true;
            this.ButtonExtractSelected.Click += new System.EventHandler(this.ButtonExtractSelected_Click);
            this.ButtonExtractSelected.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonExtractSelected.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // ButtonOpenFolders
            // 
            this.ButtonOpenFolders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonOpenFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonOpenFolders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonOpenFolders.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonOpenFolders.Location = new System.Drawing.Point(3, 218);
            this.ButtonOpenFolders.Name = "ButtonOpenFolders";
            this.ButtonOpenFolders.Size = new System.Drawing.Size(188, 39);
            this.ButtonOpenFolders.TabIndex = 5;
            this.ButtonOpenFolders.Text = "Open2F";
            this.ButtonOpenFolders.UseVisualStyleBackColor = true;
            this.ButtonOpenFolders.Click += new System.EventHandler(this.ButtonOpenFolders_Click);
            this.ButtonOpenFolders.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonOpenFolders.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // ButtonToMainPage2
            // 
            this.ButtonToMainPage2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonToMainPage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonToMainPage2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonToMainPage2.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonToMainPage2.Location = new System.Drawing.Point(3, 263);
            this.ButtonToMainPage2.Name = "ButtonToMainPage2";
            this.ButtonToMainPage2.Size = new System.Drawing.Size(188, 39);
            this.ButtonToMainPage2.TabIndex = 3;
            this.ButtonToMainPage2.Text = "ToMainPage";
            this.ButtonToMainPage2.UseVisualStyleBackColor = true;
            this.ButtonToMainPage2.Click += new System.EventHandler(this.ButtonToMainPage2_Click);
            this.ButtonToMainPage2.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonToMainPage2.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // ButtonHintExtract
            // 
            this.ButtonHintExtract.Cursor = System.Windows.Forms.Cursors.Help;
            this.ButtonHintExtract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonHintExtract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonHintExtract.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonHintExtract.Location = new System.Drawing.Point(3, 308);
            this.ButtonHintExtract.Name = "ButtonHintExtract";
            this.ButtonHintExtract.Size = new System.Drawing.Size(188, 39);
            this.ButtonHintExtract.TabIndex = 4;
            this.ButtonHintExtract.Text = "Hint";
            this.ButtonHintExtract.UseVisualStyleBackColor = true;
            this.ButtonHintExtract.Click += new System.EventHandler(this.ButtonHintExtract_Click);
            this.ButtonHintExtract.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonHintExtract.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // LayoutUnnamed10
            // 
            this.LayoutUnnamed10.ColumnCount = 5;
            this.LayoutUnnamed10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.349733F));
            this.LayoutUnnamed10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.59222F));
            this.LayoutUnnamed10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.029026F));
            this.LayoutUnnamed10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.LayoutUnnamed10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.029026F));
            this.LayoutUnnamed10.Controls.Add(this.ListGallery, 1, 0);
            this.LayoutUnnamed10.Controls.Add(this.LayoutUnnamed11, 3, 0);
            this.LayoutUnnamed10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutUnnamed10.Location = new System.Drawing.Point(3, 48);
            this.LayoutUnnamed10.Name = "LayoutUnnamed10";
            this.LayoutUnnamed10.RowCount = 1;
            this.LayoutUnnamed10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutUnnamed10.Size = new System.Drawing.Size(62, 402);
            this.LayoutUnnamed10.TabIndex = 0;
            // 
            // ListGallery
            // 
            this.ListGallery.BackColor = System.Drawing.Color.Black;
            this.ListGallery.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListGallery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ListGallery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListGallery.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ListGallery.HideSelection = false;
            this.ListGallery.LargeImageList = this.ImgListGallery;
            this.ListGallery.Location = new System.Drawing.Point(0, 3);
            this.ListGallery.Name = "ListGallery";
            this.ListGallery.Size = new System.Drawing.Size(1, 396);
            this.ListGallery.TabIndex = 1;
            this.ListGallery.UseCompatibleStateImageBehavior = false;
            // 
            // ImgListGallery
            // 
            this.ImgListGallery.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.ImgListGallery.ImageSize = new System.Drawing.Size(100, 148);
            this.ImgListGallery.TransparentColor = System.Drawing.Color.Empty;
            // 
            // LayoutUnnamed11
            // 
            this.LayoutUnnamed11.ColumnCount = 1;
            this.LayoutUnnamed11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutUnnamed11.Controls.Add(this.ButtonToMainPage3, 0, 6);
            this.LayoutUnnamed11.Controls.Add(this.ButtonOpenFolder, 0, 4);
            this.LayoutUnnamed11.Controls.Add(this.ButtonDeletePortait, 0, 2);
            this.LayoutUnnamed11.Controls.Add(this.ButtonChangePortrait, 0, 1);
            this.LayoutUnnamed11.Controls.Add(this.ButtonHintFolder, 0, 7);
            this.LayoutUnnamed11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutUnnamed11.Location = new System.Drawing.Point(-126, 3);
            this.LayoutUnnamed11.Name = "LayoutUnnamed11";
            this.LayoutUnnamed11.RowCount = 9;
            this.LayoutUnnamed11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutUnnamed11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutUnnamed11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutUnnamed11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutUnnamed11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutUnnamed11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutUnnamed11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutUnnamed11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutUnnamed11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutUnnamed11.Size = new System.Drawing.Size(194, 396);
            this.LayoutUnnamed11.TabIndex = 0;
            // 
            // ButtonToMainPage3
            // 
            this.ButtonToMainPage3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonToMainPage3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonToMainPage3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonToMainPage3.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonToMainPage3.Location = new System.Drawing.Point(3, 268);
            this.ButtonToMainPage3.Name = "ButtonToMainPage3";
            this.ButtonToMainPage3.Size = new System.Drawing.Size(188, 39);
            this.ButtonToMainPage3.TabIndex = 0;
            this.ButtonToMainPage3.Text = "ToMainPage";
            this.ButtonToMainPage3.UseVisualStyleBackColor = true;
            this.ButtonToMainPage3.Click += new System.EventHandler(this.ButtonToMainPage3_Click);
            this.ButtonToMainPage3.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonToMainPage3.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // ButtonOpenFolder
            // 
            this.ButtonOpenFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonOpenFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonOpenFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonOpenFolder.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonOpenFolder.Location = new System.Drawing.Point(3, 178);
            this.ButtonOpenFolder.Name = "ButtonOpenFolder";
            this.ButtonOpenFolder.Size = new System.Drawing.Size(188, 39);
            this.ButtonOpenFolder.TabIndex = 1;
            this.ButtonOpenFolder.Text = "OpenFolder";
            this.ButtonOpenFolder.UseVisualStyleBackColor = true;
            this.ButtonOpenFolder.Click += new System.EventHandler(this.ButtonOpenFolder_Click);
            this.ButtonOpenFolder.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonOpenFolder.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // ButtonDeletePortait
            // 
            this.ButtonDeletePortait.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDeletePortait.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonDeletePortait.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonDeletePortait.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonDeletePortait.Location = new System.Drawing.Point(3, 88);
            this.ButtonDeletePortait.Name = "ButtonDeletePortait";
            this.ButtonDeletePortait.Size = new System.Drawing.Size(188, 39);
            this.ButtonDeletePortait.TabIndex = 2;
            this.ButtonDeletePortait.Text = "DeletePortrait";
            this.ButtonDeletePortait.UseVisualStyleBackColor = true;
            this.ButtonDeletePortait.Click += new System.EventHandler(this.ButtonDeletePortait_Click);
            this.ButtonDeletePortait.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonDeletePortait.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // ButtonChangePortrait
            // 
            this.ButtonChangePortrait.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonChangePortrait.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonChangePortrait.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonChangePortrait.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonChangePortrait.Location = new System.Drawing.Point(3, 43);
            this.ButtonChangePortrait.Name = "ButtonChangePortrait";
            this.ButtonChangePortrait.Size = new System.Drawing.Size(188, 39);
            this.ButtonChangePortrait.TabIndex = 3;
            this.ButtonChangePortrait.Text = "ChangePortrait";
            this.ButtonChangePortrait.UseVisualStyleBackColor = true;
            this.ButtonChangePortrait.Click += new System.EventHandler(this.ButtonChangePortrait_Click);
            this.ButtonChangePortrait.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonChangePortrait.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // ButtonHintFolder
            // 
            this.ButtonHintFolder.Cursor = System.Windows.Forms.Cursors.Help;
            this.ButtonHintFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonHintFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonHintFolder.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonHintFolder.Location = new System.Drawing.Point(3, 313);
            this.ButtonHintFolder.Name = "ButtonHintFolder";
            this.ButtonHintFolder.Size = new System.Drawing.Size(188, 39);
            this.ButtonHintFolder.TabIndex = 4;
            this.ButtonHintFolder.Text = "Hint";
            this.ButtonHintFolder.UseVisualStyleBackColor = true;
            this.ButtonHintFolder.Click += new System.EventHandler(this.ButtonHintFolder_Click);
            this.ButtonHintFolder.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonHintFolder.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // LayoutGallery
            // 
            this.LayoutGallery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(28)))), ((int)(((byte)(9)))));
            this.LayoutGallery.ColumnCount = 1;
            this.LayoutGallery.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutGallery.Controls.Add(this.LayoutUnnamed10, 0, 1);
            this.LayoutGallery.Controls.Add(this.tableLayoutPanel11, 0, 0);
            this.LayoutGallery.Location = new System.Drawing.Point(410, 0);
            this.LayoutGallery.Name = "LayoutGallery";
            this.LayoutGallery.RowCount = 3;
            this.LayoutGallery.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.523937F));
            this.LayoutGallery.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.96509F));
            this.LayoutGallery.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.510967F));
            this.LayoutGallery.Size = new System.Drawing.Size(68, 481);
            this.LayoutGallery.TabIndex = 4;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 7;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.64242F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.34984F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.55418F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.34984F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.73065F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.73065F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.64242F));
            this.tableLayoutPanel11.Controls.Add(this.ButtonLoadNormal, 1, 1);
            this.tableLayoutPanel11.Controls.Add(this.ButtonLoadCustom, 3, 1);
            this.tableLayoutPanel11.Controls.Add(this.ButtonLoadCustomNPC, 4, 1);
            this.tableLayoutPanel11.Controls.Add(this.ButtonLoadCustomArmy, 5, 1);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 2;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(62, 39);
            this.tableLayoutPanel11.TabIndex = 1;
            // 
            // ButtonLoadNormal
            // 
            this.ButtonLoadNormal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonLoadNormal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonLoadNormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonLoadNormal.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonLoadNormal.Location = new System.Drawing.Point(9, 7);
            this.ButtonLoadNormal.Name = "ButtonLoadNormal";
            this.ButtonLoadNormal.Size = new System.Drawing.Size(5, 29);
            this.ButtonLoadNormal.TabIndex = 0;
            this.ButtonLoadNormal.TabStop = false;
            this.ButtonLoadNormal.Text = "LoadNormal";
            this.ButtonLoadNormal.UseVisualStyleBackColor = true;
            this.ButtonLoadNormal.Click += new System.EventHandler(this.ButtonLoadNormal_Click);
            this.ButtonLoadNormal.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonLoadNormal.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // ButtonLoadCustom
            // 
            this.ButtonLoadCustom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonLoadCustom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonLoadCustom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonLoadCustom.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonLoadCustom.Location = new System.Drawing.Point(21, 7);
            this.ButtonLoadCustom.Name = "ButtonLoadCustom";
            this.ButtonLoadCustom.Size = new System.Drawing.Size(5, 29);
            this.ButtonLoadCustom.TabIndex = 1;
            this.ButtonLoadCustom.TabStop = false;
            this.ButtonLoadCustom.Text = "LoadCustom";
            this.ButtonLoadCustom.UseVisualStyleBackColor = true;
            this.ButtonLoadCustom.Click += new System.EventHandler(this.ButtonLoadCustom_Click);
            this.ButtonLoadCustom.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonLoadCustom.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // ButtonLoadCustomNPC
            // 
            this.ButtonLoadCustomNPC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonLoadCustomNPC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonLoadCustomNPC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonLoadCustomNPC.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonLoadCustomNPC.Location = new System.Drawing.Point(32, 7);
            this.ButtonLoadCustomNPC.Name = "ButtonLoadCustomNPC";
            this.ButtonLoadCustomNPC.Size = new System.Drawing.Size(5, 29);
            this.ButtonLoadCustomNPC.TabIndex = 2;
            this.ButtonLoadCustomNPC.TabStop = false;
            this.ButtonLoadCustomNPC.Text = "LoadNPC";
            this.ButtonLoadCustomNPC.UseVisualStyleBackColor = true;
            this.ButtonLoadCustomNPC.Click += new System.EventHandler(this.ButtonLoadCustomNPC_Click);
            this.ButtonLoadCustomNPC.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonLoadCustomNPC.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // ButtonLoadCustomArmy
            // 
            this.ButtonLoadCustomArmy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonLoadCustomArmy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonLoadCustomArmy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonLoadCustomArmy.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonLoadCustomArmy.Location = new System.Drawing.Point(43, 7);
            this.ButtonLoadCustomArmy.Name = "ButtonLoadCustomArmy";
            this.ButtonLoadCustomArmy.Size = new System.Drawing.Size(5, 29);
            this.ButtonLoadCustomArmy.TabIndex = 3;
            this.ButtonLoadCustomArmy.TabStop = false;
            this.ButtonLoadCustomArmy.Text = "LoadArmy";
            this.ButtonLoadCustomArmy.UseVisualStyleBackColor = true;
            this.ButtonLoadCustomArmy.Click += new System.EventHandler(this.ButtonLoadCustomArmy_Click);
            this.ButtonLoadCustomArmy.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonLoadCustomArmy.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // LayoutURLDialog
            // 
            this.LayoutURLDialog.BackColor = System.Drawing.Color.Black;
            this.LayoutURLDialog.ColumnCount = 3;
            this.LayoutURLDialog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutURLDialog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 500F));
            this.LayoutURLDialog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutURLDialog.Controls.Add(this.tableLayoutPanel1, 1, 1);
            this.LayoutURLDialog.ForeColor = System.Drawing.Color.White;
            this.LayoutURLDialog.Location = new System.Drawing.Point(306, 0);
            this.LayoutURLDialog.Name = "LayoutURLDialog";
            this.LayoutURLDialog.RowCount = 3;
            this.LayoutURLDialog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutURLDialog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.LayoutURLDialog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutURLDialog.Size = new System.Drawing.Size(82, 481);
            this.LayoutURLDialog.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.LabelURLInfo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TextBoxURL, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(-206, 143);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(494, 194);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // LabelURLInfo
            // 
            this.LabelURLInfo.AutoSize = true;
            this.LabelURLInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelURLInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelURLInfo.Location = new System.Drawing.Point(3, 0);
            this.LabelURLInfo.Name = "LabelURLInfo";
            this.LabelURLInfo.Size = new System.Drawing.Size(488, 102);
            this.LabelURLInfo.TabIndex = 0;
            this.LabelURLInfo.Text = "LabelURLMessage";
            this.LabelURLInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextBoxURL
            // 
            this.TextBoxURL.AllowDrop = true;
            this.TextBoxURL.BackColor = System.Drawing.Color.Black;
            this.TextBoxURL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBoxURL.ForeColor = System.Drawing.Color.Gray;
            this.TextBoxURL.Location = new System.Drawing.Point(3, 105);
            this.TextBoxURL.Name = "TextBoxURL";
            this.TextBoxURL.Size = new System.Drawing.Size(488, 26);
            this.TextBoxURL.TabIndex = 1;
            this.TextBoxURL.Text = "InputURL";
            this.TextBoxURL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxURL.WordWrap = false;
            this.TextBoxURL.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBoxURL_DragDrop);
            this.TextBoxURL.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBoxURL_DragEnter);
            this.TextBoxURL.Enter += new System.EventHandler(this.TextBoxURL_Enter);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.ButtonDenyWeb, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ButtonLoadWeb, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 144);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(488, 47);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // ButtonDenyWeb
            // 
            this.ButtonDenyWeb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDenyWeb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonDenyWeb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonDenyWeb.Location = new System.Drawing.Point(50, 3);
            this.ButtonDenyWeb.Margin = new System.Windows.Forms.Padding(50, 3, 25, 3);
            this.ButtonDenyWeb.Name = "ButtonDenyWeb";
            this.ButtonDenyWeb.Size = new System.Drawing.Size(169, 41);
            this.ButtonDenyWeb.TabIndex = 0;
            this.ButtonDenyWeb.Text = "ToFilePage";
            this.ButtonDenyWeb.UseVisualStyleBackColor = true;
            this.ButtonDenyWeb.Click += new System.EventHandler(this.ButtonDenyWeb_Click);
            this.ButtonDenyWeb.MouseEnter += new System.EventHandler(this.AnyButton_Enter);
            this.ButtonDenyWeb.MouseLeave += new System.EventHandler(this.AnyButton_Leave);
            // 
            // ButtonLoadWeb
            // 
            this.ButtonLoadWeb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonLoadWeb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonLoadWeb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonLoadWeb.Location = new System.Drawing.Point(269, 3);
            this.ButtonLoadWeb.Margin = new System.Windows.Forms.Padding(25, 3, 50, 3);
            this.ButtonLoadWeb.Name = "ButtonLoadWeb";
            this.ButtonLoadWeb.Size = new System.Drawing.Size(169, 41);
            this.ButtonLoadWeb.TabIndex = 1;
            this.ButtonLoadWeb.Text = "TryLoadToFilePage";
            this.ButtonLoadWeb.UseVisualStyleBackColor = true;
            this.ButtonLoadWeb.Click += new System.EventHandler(this.ButtonLoadWeb_Click);
            this.ButtonLoadWeb.MouseEnter += new System.EventHandler(this.AnyButton_Enter);
            this.ButtonLoadWeb.MouseLeave += new System.EventHandler(this.AnyButton_Leave);
            // 
            // LayoutFinalPage
            // 
            this.LayoutFinalPage.BackColor = System.Drawing.Color.Black;
            this.LayoutFinalPage.ColumnCount = 3;
            this.LayoutFinalPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutFinalPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 500F));
            this.LayoutFinalPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutFinalPage.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.LayoutFinalPage.ForeColor = System.Drawing.Color.White;
            this.LayoutFinalPage.Location = new System.Drawing.Point(193, 0);
            this.LayoutFinalPage.Name = "LayoutFinalPage";
            this.LayoutFinalPage.RowCount = 3;
            this.LayoutFinalPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutFinalPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.LayoutFinalPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutFinalPage.Size = new System.Drawing.Size(89, 481);
            this.LayoutFinalPage.TabIndex = 6;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.LabelFinalMesg, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.LabelDirLoc, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(-202, 118);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.61856F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.09278F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.7732F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(494, 244);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Controls.Add(this.ButtonToMainPage4, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.ButtonToFilePage3, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.ButtonToMainPageAndFolder, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 183);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(488, 58);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // ButtonToMainPage4
            // 
            this.ButtonToMainPage4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonToMainPage4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonToMainPage4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonToMainPage4.Location = new System.Drawing.Point(3, 3);
            this.ButtonToMainPage4.Name = "ButtonToMainPage4";
            this.ButtonToMainPage4.Size = new System.Drawing.Size(156, 52);
            this.ButtonToMainPage4.TabIndex = 0;
            this.ButtonToMainPage4.Text = "ToMenuPage";
            this.ButtonToMainPage4.UseVisualStyleBackColor = true;
            this.ButtonToMainPage4.Click += new System.EventHandler(this.ButtonToMainPage4_Click);
            this.ButtonToMainPage4.MouseEnter += new System.EventHandler(this.AnyButton_Enter);
            this.ButtonToMainPage4.MouseLeave += new System.EventHandler(this.AnyButton_Leave);
            // 
            // ButtonToFilePage3
            // 
            this.ButtonToFilePage3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonToFilePage3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonToFilePage3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonToFilePage3.Location = new System.Drawing.Point(165, 3);
            this.ButtonToFilePage3.Name = "ButtonToFilePage3";
            this.ButtonToFilePage3.Size = new System.Drawing.Size(156, 52);
            this.ButtonToFilePage3.TabIndex = 1;
            this.ButtonToFilePage3.Text = "ToFilePage";
            this.ButtonToFilePage3.UseVisualStyleBackColor = true;
            this.ButtonToFilePage3.Click += new System.EventHandler(this.ButtonToFilePage3_Click);
            this.ButtonToFilePage3.MouseEnter += new System.EventHandler(this.AnyButton_Enter);
            this.ButtonToFilePage3.MouseLeave += new System.EventHandler(this.AnyButton_Leave);
            // 
            // ButtonToMainPageAndFolder
            // 
            this.ButtonToMainPageAndFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonToMainPageAndFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonToMainPageAndFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonToMainPageAndFolder.Location = new System.Drawing.Point(327, 3);
            this.ButtonToMainPageAndFolder.Name = "ButtonToMainPageAndFolder";
            this.ButtonToMainPageAndFolder.Size = new System.Drawing.Size(158, 52);
            this.ButtonToMainPageAndFolder.TabIndex = 2;
            this.ButtonToMainPageAndFolder.Text = "ToMenuPageAndOpenFile";
            this.ButtonToMainPageAndFolder.UseVisualStyleBackColor = true;
            this.ButtonToMainPageAndFolder.Click += new System.EventHandler(this.ButtonToMainPageAndFolder_Click);
            this.ButtonToMainPageAndFolder.MouseEnter += new System.EventHandler(this.AnyButton_Enter);
            this.ButtonToMainPageAndFolder.MouseLeave += new System.EventHandler(this.AnyButton_Leave);
            // 
            // LabelFinalMesg
            // 
            this.LabelFinalMesg.AutoSize = true;
            this.LabelFinalMesg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelFinalMesg.Location = new System.Drawing.Point(3, 50);
            this.LabelFinalMesg.Name = "LabelFinalMesg";
            this.LabelFinalMesg.Size = new System.Drawing.Size(488, 130);
            this.LabelFinalMesg.TabIndex = 2;
            this.LabelFinalMesg.Text = "FinalPageText";
            this.LabelFinalMesg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelDirLoc
            // 
            this.LabelDirLoc.AutoSize = true;
            this.LabelDirLoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelDirLoc.Location = new System.Drawing.Point(3, 0);
            this.LabelDirLoc.Name = "LabelDirLoc";
            this.LabelDirLoc.Size = new System.Drawing.Size(488, 50);
            this.LabelDirLoc.TabIndex = 3;
            this.LabelDirLoc.Text = "DirLoc";
            this.LabelDirLoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LayoutSettingsPage
            // 
            this.LayoutSettingsPage.BackColor = System.Drawing.Color.Black;
            this.LayoutSettingsPage.ColumnCount = 3;
            this.LayoutSettingsPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutSettingsPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 550F));
            this.LayoutSettingsPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutSettingsPage.Controls.Add(this.tableLayoutPanel7, 1, 1);
            this.LayoutSettingsPage.ForeColor = System.Drawing.Color.White;
            this.LayoutSettingsPage.Location = new System.Drawing.Point(70, 0);
            this.LayoutSettingsPage.Name = "LayoutSettingsPage";
            this.LayoutSettingsPage.RowCount = 3;
            this.LayoutSettingsPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutSettingsPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 450F));
            this.LayoutSettingsPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutSettingsPage.Size = new System.Drawing.Size(23, 481);
            this.LayoutSettingsPage.TabIndex = 7;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel8, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.ButtonToMainPage5, 0, 6);
            this.tableLayoutPanel7.Controls.Add(this.LabelSelectedPath, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel9, 0, 4);
            this.tableLayoutPanel7.Controls.Add(this.LabelSettings, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel10, 0, 3);
            this.tableLayoutPanel7.Controls.Add(this.LayoutUnnamed16, 0, 5);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(-260, 18);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 7;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.95415F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.08538F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.99327F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.64146F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.49158F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.64146F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.19269F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(544, 444);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 3;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.Controls.Add(this.ButtonKingmaker, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.ButtonWotR, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.ButtonRT, 2, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 60);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(538, 65);
            this.tableLayoutPanel8.TabIndex = 1;
            // 
            // ButtonKingmaker
            // 
            this.ButtonKingmaker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonKingmaker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonKingmaker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonKingmaker.Location = new System.Drawing.Point(10, 10);
            this.ButtonKingmaker.Margin = new System.Windows.Forms.Padding(10);
            this.ButtonKingmaker.Name = "ButtonKingmaker";
            this.ButtonKingmaker.Size = new System.Drawing.Size(159, 45);
            this.ButtonKingmaker.TabIndex = 0;
            this.ButtonKingmaker.Text = "ButtonKingmaker";
            this.ButtonKingmaker.UseVisualStyleBackColor = true;
            this.ButtonKingmaker.Click += new System.EventHandler(this.ButtonKingmaker_Click);
            this.ButtonKingmaker.MouseEnter += new System.EventHandler(this.AnyButton_Enter);
            this.ButtonKingmaker.MouseLeave += new System.EventHandler(this.AnyButton_Leave);
            // 
            // ButtonWotR
            // 
            this.ButtonWotR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonWotR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonWotR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonWotR.Location = new System.Drawing.Point(189, 10);
            this.ButtonWotR.Margin = new System.Windows.Forms.Padding(10);
            this.ButtonWotR.Name = "ButtonWotR";
            this.ButtonWotR.Size = new System.Drawing.Size(159, 45);
            this.ButtonWotR.TabIndex = 1;
            this.ButtonWotR.Text = "ButtonWotR";
            this.ButtonWotR.UseVisualStyleBackColor = true;
            this.ButtonWotR.Click += new System.EventHandler(this.ButtonWotR_Click);
            this.ButtonWotR.MouseEnter += new System.EventHandler(this.AnyButton_Enter);
            this.ButtonWotR.MouseLeave += new System.EventHandler(this.AnyButton_Leave);
            // 
            // ButtonRT
            // 
            this.ButtonRT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonRT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonRT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonRT.Location = new System.Drawing.Point(368, 10);
            this.ButtonRT.Margin = new System.Windows.Forms.Padding(10);
            this.ButtonRT.Name = "ButtonRT";
            this.ButtonRT.Size = new System.Drawing.Size(160, 45);
            this.ButtonRT.TabIndex = 2;
            this.ButtonRT.Text = "ButtonRT";
            this.ButtonRT.UseVisualStyleBackColor = true;
            this.ButtonRT.Click += new System.EventHandler(this.ButtonRT_Click);
            this.ButtonRT.MouseEnter += new System.EventHandler(this.AnyButton_Enter);
            this.ButtonRT.MouseLeave += new System.EventHandler(this.AnyButton_Leave);
            // 
            // ButtonToMainPage5
            // 
            this.ButtonToMainPage5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonToMainPage5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonToMainPage5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonToMainPage5.Location = new System.Drawing.Point(200, 384);
            this.ButtonToMainPage5.Margin = new System.Windows.Forms.Padding(200, 15, 200, 15);
            this.ButtonToMainPage5.Name = "ButtonToMainPage5";
            this.ButtonToMainPage5.Size = new System.Drawing.Size(144, 45);
            this.ButtonToMainPage5.TabIndex = 5;
            this.ButtonToMainPage5.Text = "ButtonToMainPage";
            this.ButtonToMainPage5.UseVisualStyleBackColor = true;
            this.ButtonToMainPage5.Click += new System.EventHandler(this.ButtonToMainPage5_Click);
            this.ButtonToMainPage5.MouseEnter += new System.EventHandler(this.AnyButton_Enter);
            this.ButtonToMainPage5.MouseLeave += new System.EventHandler(this.AnyButton_Leave);
            // 
            // LabelSelectedPath
            // 
            this.LabelSelectedPath.AutoSize = true;
            this.LabelSelectedPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelSelectedPath.Location = new System.Drawing.Point(3, 128);
            this.LabelSelectedPath.Name = "LabelSelectedPath";
            this.LabelSelectedPath.Size = new System.Drawing.Size(538, 62);
            this.LabelSelectedPath.TabIndex = 2;
            this.LabelSelectedPath.Text = "SelectedPath";
            this.LabelSelectedPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 5;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.77778F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333334F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.77778F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333334F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.77778F));
            this.tableLayoutPanel9.Controls.Add(this.ButtonValidatePath, 2, 0);
            this.tableLayoutPanel9.Controls.Add(this.ButtonSelectPath, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.label1, 3, 0);
            this.tableLayoutPanel9.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.ButtonApplyChange, 4, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 244);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(538, 71);
            this.tableLayoutPanel9.TabIndex = 4;
            // 
            // ButtonValidatePath
            // 
            this.ButtonValidatePath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonValidatePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonValidatePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonValidatePath.Location = new System.Drawing.Point(208, 15);
            this.ButtonValidatePath.Margin = new System.Windows.Forms.Padding(15);
            this.ButtonValidatePath.Name = "ButtonValidatePath";
            this.ButtonValidatePath.Size = new System.Drawing.Size(119, 41);
            this.ButtonValidatePath.TabIndex = 0;
            this.ButtonValidatePath.Text = "ButtonValidate";
            this.ButtonValidatePath.UseVisualStyleBackColor = true;
            this.ButtonValidatePath.Click += new System.EventHandler(this.ButtonValidatePath_Click);
            this.ButtonValidatePath.MouseEnter += new System.EventHandler(this.AnyButton_Enter);
            this.ButtonValidatePath.MouseLeave += new System.EventHandler(this.AnyButton_Leave);
            // 
            // ButtonSelectPath
            // 
            this.ButtonSelectPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonSelectPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonSelectPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonSelectPath.Location = new System.Drawing.Point(15, 15);
            this.ButtonSelectPath.Margin = new System.Windows.Forms.Padding(15);
            this.ButtonSelectPath.Name = "ButtonSelectPath";
            this.ButtonSelectPath.Size = new System.Drawing.Size(119, 41);
            this.ButtonSelectPath.TabIndex = 4;
            this.ButtonSelectPath.Text = "ButtonChange";
            this.ButtonSelectPath.UseVisualStyleBackColor = true;
            this.ButtonSelectPath.Click += new System.EventHandler(this.ButtonSelectPath_Click);
            this.ButtonSelectPath.MouseEnter += new System.EventHandler(this.AnyButton_Enter);
            this.ButtonSelectPath.MouseLeave += new System.EventHandler(this.AnyButton_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(345, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 71);
            this.label1.TabIndex = 5;
            this.label1.Text = "▶";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(152, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 71);
            this.label2.TabIndex = 6;
            this.label2.Text = "▶";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonApplyChange
            // 
            this.ButtonApplyChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonApplyChange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonApplyChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonApplyChange.Location = new System.Drawing.Point(401, 15);
            this.ButtonApplyChange.Margin = new System.Windows.Forms.Padding(15);
            this.ButtonApplyChange.Name = "ButtonApplyChange";
            this.ButtonApplyChange.Size = new System.Drawing.Size(122, 41);
            this.ButtonApplyChange.TabIndex = 7;
            this.ButtonApplyChange.Text = "ButtonApply";
            this.ButtonApplyChange.UseVisualStyleBackColor = true;
            this.ButtonApplyChange.Click += new System.EventHandler(this.ButtonApplyChange_Click);
            this.ButtonApplyChange.MouseEnter += new System.EventHandler(this.AnyButton_Enter);
            this.ButtonApplyChange.MouseLeave += new System.EventHandler(this.AnyButton_Leave);
            // 
            // LabelSettings
            // 
            this.LabelSettings.AutoSize = true;
            this.LabelSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelSettings.Location = new System.Drawing.Point(3, 0);
            this.LabelSettings.Name = "LabelSettings";
            this.LabelSettings.Size = new System.Drawing.Size(538, 57);
            this.LabelSettings.TabIndex = 6;
            this.LabelSettings.Text = "SettingsLabel";
            this.LabelSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.50185F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.49814F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel10.Controls.Add(this.ButtonRestorePath, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.TextBoxFullPath, 0, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 193);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(538, 45);
            this.tableLayoutPanel10.TabIndex = 7;
            // 
            // ButtonRestorePath
            // 
            this.ButtonRestorePath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonRestorePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonRestorePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonRestorePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonRestorePath.Location = new System.Drawing.Point(475, 4);
            this.ButtonRestorePath.Margin = new System.Windows.Forms.Padding(15, 4, 15, 4);
            this.ButtonRestorePath.Name = "ButtonRestorePath";
            this.ButtonRestorePath.Size = new System.Drawing.Size(48, 37);
            this.ButtonRestorePath.TabIndex = 3;
            this.ButtonRestorePath.Text = "⭯";
            this.ButtonRestorePath.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ButtonRestorePath.UseVisualStyleBackColor = false;
            this.ButtonRestorePath.Click += new System.EventHandler(this.ButtonRestorePath_Click);
            this.ButtonRestorePath.MouseEnter += new System.EventHandler(this.AnyButton_Enter);
            this.ButtonRestorePath.MouseLeave += new System.EventHandler(this.AnyButton_Leave);
            // 
            // TextBoxFullPath
            // 
            this.TextBoxFullPath.BackColor = System.Drawing.Color.Black;
            this.TextBoxFullPath.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TextBoxFullPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxFullPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBoxFullPath.ForeColor = System.Drawing.Color.White;
            this.TextBoxFullPath.Location = new System.Drawing.Point(3, 3);
            this.TextBoxFullPath.Multiline = true;
            this.TextBoxFullPath.Name = "TextBoxFullPath";
            this.TextBoxFullPath.Size = new System.Drawing.Size(454, 39);
            this.TextBoxFullPath.TabIndex = 3;
            this.TextBoxFullPath.TabStop = false;
            this.TextBoxFullPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxFullPath.TextChanged += new System.EventHandler(this.TextBoxFullPath_TextChanged);
            // 
            // LayoutUnnamed16
            // 
            this.LayoutUnnamed16.ColumnCount = 2;
            this.LayoutUnnamed16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutUnnamed16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutUnnamed16.Controls.Add(this.CheckBoxVerified, 0, 0);
            this.LayoutUnnamed16.Controls.Add(this.LabelLang, 1, 0);
            this.LayoutUnnamed16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutUnnamed16.Location = new System.Drawing.Point(3, 321);
            this.LayoutUnnamed16.Name = "LayoutUnnamed16";
            this.LayoutUnnamed16.RowCount = 1;
            this.LayoutUnnamed16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutUnnamed16.Size = new System.Drawing.Size(538, 45);
            this.LayoutUnnamed16.TabIndex = 8;
            // 
            // CheckBoxVerified
            // 
            this.CheckBoxVerified.AutoSize = true;
            this.CheckBoxVerified.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckBoxVerified.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckBoxVerified.Location = new System.Drawing.Point(50, 3);
            this.CheckBoxVerified.Margin = new System.Windows.Forms.Padding(50, 3, 50, 3);
            this.CheckBoxVerified.Name = "CheckBoxVerified";
            this.CheckBoxVerified.Size = new System.Drawing.Size(169, 39);
            this.CheckBoxVerified.TabIndex = 8;
            this.CheckBoxVerified.Text = "CustomNPC?";
            this.CheckBoxVerified.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBoxVerified.UseVisualStyleBackColor = true;
            // 
            // LabelLang
            // 
            this.LabelLang.AutoSize = true;
            this.LabelLang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelLang.Location = new System.Drawing.Point(272, 0);
            this.LabelLang.Name = "LabelLang";
            this.LabelLang.Size = new System.Drawing.Size(263, 45);
            this.LabelLang.TabIndex = 9;
            this.LabelLang.Text = "LangLabel";
            this.LabelLang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Goldenrod;
            this.label3.Location = new System.Drawing.Point(25, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "1.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Goldenrod;
            this.label4.Location = new System.Drawing.Point(25, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "2.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Goldenrod;
            this.label5.Location = new System.Drawing.Point(5, 326);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Bcsp.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.Goldenrod;
            this.label6.Location = new System.Drawing.Point(3, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Enter.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.Goldenrod;
            this.label7.Location = new System.Drawing.Point(3, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Right.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(853, 570);
            this.Controls.Add(this.LayoutFilePage);
            this.Controls.Add(this.LayoutMainPage);
            this.Controls.Add(this.LayoutScalePage);
            this.Controls.Add(this.LayoutSettingsPage);
            this.Controls.Add(this.LayoutGallery);
            this.Controls.Add(this.LayoutFinalPage);
            this.Controls.Add(this.LayoutExtractPage);
            this.Controls.Add(this.LayoutURLDialog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(6700, 5200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(750, 520);
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pathfinder Portrait Manager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_Closed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.LayoutFilePage.ResumeLayout(false);
            this.LayoutUnnamed1.ResumeLayout(false);
            this.LayoutUnnamed1.PerformLayout();
            this.LayoutUnnamed5.ResumeLayout(false);
            this.LayoutUnnamed5.PerformLayout();
            this.PanelPortraitTemp.ResumeLayout(false);
            this.PanelPortraitTemp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPortraitTemp)).EndInit();
            this.LayoutScalePage.ResumeLayout(false);
            this.LayoutUnnamed2.ResumeLayout(false);
            this.PanelPortraitLrg.ResumeLayout(false);
            this.PanelPortraitLrg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPortraitLrg)).EndInit();
            this.PanelPortraitMed.ResumeLayout(false);
            this.PanelPortraitMed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPortraitMed)).EndInit();
            this.PanelPortraitSml.ResumeLayout(false);
            this.PanelPortraitSml.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPortraitSml)).EndInit();
            this.LayoutUnnamed3.ResumeLayout(false);
            this.LayoutUnnamed4.ResumeLayout(false);
            this.LayoutMainPage.ResumeLayout(false);
            this.LayoutMainPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxTitle)).EndInit();
            this.LayoutLang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxEng)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxRus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxGer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxFra)).EndInit();
            this.LayoutExtractPage.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.LayoutUnnamed10.ResumeLayout(false);
            this.LayoutUnnamed11.ResumeLayout(false);
            this.LayoutGallery.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.LayoutURLDialog.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.LayoutFinalPage.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.LayoutSettingsPage.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.LayoutUnnamed16.ResumeLayout(false);
            this.LayoutUnnamed16.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel LayoutMainPage;
        private System.Windows.Forms.TableLayoutPanel LayoutFilePage;
        private System.Windows.Forms.TableLayoutPanel LayoutScalePage;
        private System.Windows.Forms.TableLayoutPanel LayoutExtractPage;
        private System.Windows.Forms.TableLayoutPanel LayoutUnnamed1;
        private System.Windows.Forms.TableLayoutPanel LayoutUnnamed2;
        private System.Windows.Forms.TableLayoutPanel LayoutUnnamed3;
        private System.Windows.Forms.TableLayoutPanel LayoutUnnamed4;
        private System.Windows.Forms.TableLayoutPanel LayoutUnnamed5;
        private System.Windows.Forms.Button ButtonToFilePage;
        private System.Windows.Forms.Button ButtonToMainPage;
        private System.Windows.Forms.Button ButtonToScalePage;
        private System.Windows.Forms.Button ButtonToGalleryPage;
        private System.Windows.Forms.Button ButtonToFilePage2;
        private System.Windows.Forms.Button ButtonCreatePortrait;
        private System.Windows.Forms.Button ButtonLocalPortraitLoad;
        private System.Windows.Forms.Button ButtonWebPortraitLoad;
        private System.Windows.Forms.Button ButtonExit;
        private System.Windows.Forms.Button ButtonToExtractPage;
        private System.Windows.Forms.Button ButtonHintOnFilePage;
        private System.Windows.Forms.Button ButtonHintOnScalePage;
        private System.Windows.Forms.PictureBox PicPortraitTemp;
        private System.Windows.Forms.PictureBox PicPortraitLrg;
        private System.Windows.Forms.PictureBox PicPortraitMed;
        private System.Windows.Forms.PictureBox PicPortraitSml;
        private System.Windows.Forms.Panel PanelPortraitLrg;
        private System.Windows.Forms.Panel PanelPortraitMed;
        private System.Windows.Forms.Panel PanelPortraitSml;
        private System.Windows.Forms.Panel PanelPortraitTemp;
        private System.Windows.Forms.Label LabelMedImage;
        private System.Windows.Forms.Label LabelLrgImg;
        private System.Windows.Forms.Label LabelSmlImg;
        private System.Windows.Forms.Label LabelCopyright;
        private System.Windows.Forms.TableLayoutPanel LayoutUnnamed10;
        private System.Windows.Forms.TableLayoutPanel LayoutUnnamed11;
        private System.Windows.Forms.Button ButtonToMainPage3;
        private System.Windows.Forms.Button ButtonOpenFolder;
        private System.Windows.Forms.TableLayoutPanel LayoutGallery;
        private System.Windows.Forms.ImageList ImgListGallery;
        private System.Windows.Forms.ListView ListGallery;
        private System.Windows.Forms.Button ButtonDeletePortait;
        private System.Windows.Forms.Button ButtonChangePortrait;
        private System.Windows.Forms.Button ButtonHintFolder;
        private System.Windows.Forms.PictureBox PictureBoxTitle;
        private System.Windows.Forms.TableLayoutPanel LayoutURLDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label LabelURLInfo;
        private System.Windows.Forms.TextBox TextBoxURL;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button ButtonDenyWeb;
        private System.Windows.Forms.Button ButtonLoadWeb;
        private System.Windows.Forms.TableLayoutPanel LayoutFinalPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button ButtonToMainPage4;
        private System.Windows.Forms.Button ButtonToFilePage3;
        private System.Windows.Forms.Button ButtonToMainPageAndFolder;
        private System.Windows.Forms.Label LabelFinalMesg;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.ListView ListExtract;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button ButtonChooseFolder;
        private System.Windows.Forms.Button ButtonExtractAll;
        private System.Windows.Forms.Button ButtonExtractSelected;
        private System.Windows.Forms.Button ButtonToMainPage2;
        private System.Windows.Forms.Button ButtonHintExtract;
        private System.Windows.Forms.Button ButtonOpenFolders;
        private System.Windows.Forms.ImageList ImgListExtract;
        private System.Windows.Forms.Button ButtonToSettingsPage;
        private System.Windows.Forms.TableLayoutPanel LayoutSettingsPage;
        private System.Windows.Forms.Label LabelVersion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Button ButtonKingmaker;
        private System.Windows.Forms.Button ButtonWotR;
        private System.Windows.Forms.Label LabelSelectedPath;
        private System.Windows.Forms.TextBox TextBoxFullPath;
        private System.Windows.Forms.Button ButtonToMainPage5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Button ButtonValidatePath;
        private System.Windows.Forms.Button ButtonRestorePath;
        private System.Windows.Forms.Button ButtonSelectPath;
        private System.Windows.Forms.Label LabelSettings;
        private System.Windows.Forms.Button ButtonNextImageType;
        private System.Windows.Forms.Label LabelDirLoc;
        private System.Windows.Forms.Label LabelImageFlag;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ButtonApplyChange;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.Button ButtonLoadNormal;
        private System.Windows.Forms.Button ButtonLoadCustom;
        private System.Windows.Forms.Button ButtonLoadCustomNPC;
        private System.Windows.Forms.Button ButtonLoadCustomArmy;
        private System.Windows.Forms.TableLayoutPanel LayoutLang;
        private System.Windows.Forms.PictureBox PicBoxEng;
        private System.Windows.Forms.PictureBox PicBoxRus;
        private System.Windows.Forms.PictureBox PicBoxGer;
        private System.Windows.Forms.CheckBox CheckBoxVerified;
        private System.Windows.Forms.TableLayoutPanel LayoutUnnamed16;
        private System.Windows.Forms.Label LabelLang;
        private System.Windows.Forms.Button ButtonRT;
        private System.Windows.Forms.PictureBox PicBoxFra;
        private System.Windows.Forms.Label LblPointerToFilePage;
        private System.Windows.Forms.Label LblPointerToExtractPage;
        private System.Windows.Forms.Label LblPointerToGalleryPage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

