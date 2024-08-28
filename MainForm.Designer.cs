/*    
    Portrait Manager: Owlcat. Desktop application for managing in game
    portraits for Owlcat Games products. Including: 1. Pathfinder: Kingmaker,
    2. Pathfinder: Wrath of the Righteous, 3. Warhammer 40000: Rogue Trader
    Copyright (C) 2024 Artemii "Zeight" Saganenko.

    GPL-2.0 license terms are listed in LICENSE file.
    License header for this project is listed in Program.cs.
*/


namespace PortraitManager
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
            this.LblToLoadLocal = new System.Windows.Forms.Label();
            this.LblToLoadWeb = new System.Windows.Forms.Label();
            this.LblToMainPage = new System.Windows.Forms.Label();
            this.LblToScalePage = new System.Windows.Forms.Label();
            this.LblToAdvancedPage = new System.Windows.Forms.Label();
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
            this.LblToFilePage = new System.Windows.Forms.Label();
            this.LblToCreatePortrait = new System.Windows.Forms.Label();
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LayoutUnnamed10 = new System.Windows.Forms.TableLayoutPanel();
            this.ListGallery = new System.Windows.Forms.ListView();
            this.ImgListGallery = new System.Windows.Forms.ImageList(this.components);
            this.LayoutUnnamed11 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonToMainPage3 = new System.Windows.Forms.Button();
            this.ButtonOpenFolder = new System.Windows.Forms.Button();
            this.ButtonDeletePortait = new System.Windows.Forms.Button();
            this.ButtonChangePortrait = new System.Windows.Forms.Button();
            this.ButtonHintFolder = new System.Windows.Forms.Button();
            this.LblToMainPage3 = new System.Windows.Forms.Label();
            this.LblToOpenFolder = new System.Windows.Forms.Label();
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
            this.LblToFilePage3 = new System.Windows.Forms.Label();
            this.LblToLoadToFilePage = new System.Windows.Forms.Label();
            this.LayoutFinalPage = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonToMainPage4 = new System.Windows.Forms.Button();
            this.ButtonToFilePage3 = new System.Windows.Forms.Button();
            this.ButtonToMainPageAndFolder = new System.Windows.Forms.Button();
            this.LabelFinalMesg = new System.Windows.Forms.Label();
            this.LabelDirLoc = new System.Windows.Forms.Label();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.LblToMenuPage = new System.Windows.Forms.Label();
            this.LblToFilePage2 = new System.Windows.Forms.Label();
            this.LblToMenuPageAndOpenFIle = new System.Windows.Forms.Label();
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
            this.LayoutStartMenu = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonStartKing = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonStartWotr = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonStartRt = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonStartPoe = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonStartPoed = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonStartTyr = new System.Windows.Forms.Button();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel19 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonStartWaste = new System.Windows.Forms.Button();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel20 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
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
            this.tableLayoutPanel12.SuspendLayout();
            this.LayoutSettingsPage.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.LayoutUnnamed16.SuspendLayout();
            this.LayoutStartMenu.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tableLayoutPanel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tableLayoutPanel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.tableLayoutPanel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.tableLayoutPanel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.tableLayoutPanel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.tableLayoutPanel20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutFilePage
            // 
            this.LayoutFilePage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(28)))), ((int)(((byte)(11)))));
            this.LayoutFilePage.ColumnCount = 5;
            this.LayoutFilePage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.LayoutFilePage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutFilePage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.LayoutFilePage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.LayoutFilePage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.LayoutFilePage.Controls.Add(this.LayoutUnnamed1, 3, 0);
            this.LayoutFilePage.Controls.Add(this.LayoutUnnamed5, 1, 0);
            this.LayoutFilePage.ForeColor = System.Drawing.Color.White;
            this.LayoutFilePage.Location = new System.Drawing.Point(0, 3);
            this.LayoutFilePage.Name = "LayoutFilePage";
            this.LayoutFilePage.RowCount = 1;
            this.LayoutFilePage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutFilePage.Size = new System.Drawing.Size(221, 279);
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
            this.LayoutUnnamed1.Controls.Add(this.LblToLoadLocal, 0, 1);
            this.LayoutUnnamed1.Controls.Add(this.LblToLoadWeb, 0, 2);
            this.LayoutUnnamed1.Controls.Add(this.LblToMainPage, 0, 6);
            this.LayoutUnnamed1.Controls.Add(this.LblToScalePage, 0, 4);
            this.LayoutUnnamed1.Controls.Add(this.LblToAdvancedPage, 0, 5);
            this.LayoutUnnamed1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutUnnamed1.Location = new System.Drawing.Point(135, 3);
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
            this.LayoutUnnamed1.Size = new System.Drawing.Size(71, 273);
            this.LayoutUnnamed1.TabIndex = 0;
            // 
            // ButtonLocalPortraitLoad
            // 
            this.ButtonLocalPortraitLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonLocalPortraitLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonLocalPortraitLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonLocalPortraitLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonLocalPortraitLoad.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonLocalPortraitLoad.Location = new System.Drawing.Point(48, -40);
            this.ButtonLocalPortraitLoad.Name = "ButtonLocalPortraitLoad";
            this.ButtonLocalPortraitLoad.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ButtonLocalPortraitLoad.Size = new System.Drawing.Size(20, 39);
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
            this.ButtonToScalePage.Location = new System.Drawing.Point(48, 95);
            this.ButtonToScalePage.Name = "ButtonToScalePage";
            this.ButtonToScalePage.Size = new System.Drawing.Size(20, 39);
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
            this.ButtonWebPortraitLoad.Location = new System.Drawing.Point(48, 5);
            this.ButtonWebPortraitLoad.Name = "ButtonWebPortraitLoad";
            this.ButtonWebPortraitLoad.Size = new System.Drawing.Size(20, 39);
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
            this.ButtonHintOnFilePage.Location = new System.Drawing.Point(48, 275);
            this.ButtonHintOnFilePage.Name = "ButtonHintOnFilePage";
            this.ButtonHintOnFilePage.Size = new System.Drawing.Size(20, 39);
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
            this.ButtonNextImageType.Location = new System.Drawing.Point(48, 140);
            this.ButtonNextImageType.Name = "ButtonNextImageType";
            this.ButtonNextImageType.Size = new System.Drawing.Size(20, 39);
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
            this.ButtonToMainPage.Location = new System.Drawing.Point(48, 185);
            this.ButtonToMainPage.Name = "ButtonToMainPage";
            this.ButtonToMainPage.Size = new System.Drawing.Size(20, 39);
            this.ButtonToMainPage.TabIndex = 0;
            this.ButtonToMainPage.Text = "ToMainPage";
            this.ButtonToMainPage.UseVisualStyleBackColor = true;
            this.ButtonToMainPage.Click += new System.EventHandler(this.ButtonToMainPage_Click);
            this.ButtonToMainPage.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonToMainPage.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // LblToLoadLocal
            // 
            this.LblToLoadLocal.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblToLoadLocal.AutoSize = true;
            this.LblToLoadLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblToLoadLocal.ForeColor = System.Drawing.Color.Goldenrod;
            this.LblToLoadLocal.Location = new System.Drawing.Point(25, -28);
            this.LblToLoadLocal.Name = "LblToLoadLocal";
            this.LblToLoadLocal.Size = new System.Drawing.Size(17, 15);
            this.LblToLoadLocal.TabIndex = 8;
            this.LblToLoadLocal.Text = "1.";
            this.LblToLoadLocal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblToLoadWeb
            // 
            this.LblToLoadWeb.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblToLoadWeb.AutoSize = true;
            this.LblToLoadWeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblToLoadWeb.ForeColor = System.Drawing.Color.Goldenrod;
            this.LblToLoadWeb.Location = new System.Drawing.Point(25, 17);
            this.LblToLoadWeb.Name = "LblToLoadWeb";
            this.LblToLoadWeb.Size = new System.Drawing.Size(17, 15);
            this.LblToLoadWeb.TabIndex = 9;
            this.LblToLoadWeb.Text = "2.";
            this.LblToLoadWeb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblToMainPage
            // 
            this.LblToMainPage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblToMainPage.AutoSize = true;
            this.LblToMainPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblToMainPage.ForeColor = System.Drawing.Color.Goldenrod;
            this.LblToMainPage.Location = new System.Drawing.Point(25, 197);
            this.LblToMainPage.Name = "LblToMainPage";
            this.LblToMainPage.Size = new System.Drawing.Size(17, 15);
            this.LblToMainPage.TabIndex = 10;
            this.LblToMainPage.Text = "q.";
            this.LblToMainPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblToScalePage
            // 
            this.LblToScalePage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblToScalePage.AutoSize = true;
            this.LblToScalePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblToScalePage.ForeColor = System.Drawing.Color.Goldenrod;
            this.LblToScalePage.Location = new System.Drawing.Point(28, 107);
            this.LblToScalePage.Name = "LblToScalePage";
            this.LblToScalePage.Size = new System.Drawing.Size(14, 15);
            this.LblToScalePage.TabIndex = 11;
            this.LblToScalePage.Text = "r.";
            this.LblToScalePage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblToAdvancedPage
            // 
            this.LblToAdvancedPage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblToAdvancedPage.AutoSize = true;
            this.LblToAdvancedPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblToAdvancedPage.ForeColor = System.Drawing.Color.Goldenrod;
            this.LblToAdvancedPage.Location = new System.Drawing.Point(25, 152);
            this.LblToAdvancedPage.Name = "LblToAdvancedPage";
            this.LblToAdvancedPage.Size = new System.Drawing.Size(17, 15);
            this.LblToAdvancedPage.TabIndex = 12;
            this.LblToAdvancedPage.Text = "e.";
            this.LblToAdvancedPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LayoutUnnamed5
            // 
            this.LayoutUnnamed5.ColumnCount = 1;
            this.LayoutUnnamed5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutUnnamed5.Controls.Add(this.PanelPortraitTemp, 0, 1);
            this.LayoutUnnamed5.Controls.Add(this.LabelImageFlag, 0, 2);
            this.LayoutUnnamed5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutUnnamed5.Location = new System.Drawing.Point(14, 3);
            this.LayoutUnnamed5.Name = "LayoutUnnamed5";
            this.LayoutUnnamed5.RowCount = 3;
            this.LayoutUnnamed5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.384029F));
            this.LayoutUnnamed5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.8503F));
            this.LayoutUnnamed5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.765676F));
            this.LayoutUnnamed5.Size = new System.Drawing.Size(104, 273);
            this.LayoutUnnamed5.TabIndex = 1;
            // 
            // PanelPortraitTemp
            // 
            this.PanelPortraitTemp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelPortraitTemp.Controls.Add(this.PicPortraitTemp);
            this.PanelPortraitTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelPortraitTemp.Location = new System.Drawing.Point(0, 11);
            this.PanelPortraitTemp.Margin = new System.Windows.Forms.Padding(0);
            this.PanelPortraitTemp.Name = "PanelPortraitTemp";
            this.PanelPortraitTemp.Size = new System.Drawing.Size(104, 237);
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
            this.LabelImageFlag.Location = new System.Drawing.Point(3, 248);
            this.LabelImageFlag.Name = "LabelImageFlag";
            this.LabelImageFlag.Size = new System.Drawing.Size(98, 25);
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
            this.LayoutScalePage.Location = new System.Drawing.Point(0, 0);
            this.LayoutScalePage.Name = "LayoutScalePage";
            this.LayoutScalePage.RowCount = 5;
            this.LayoutScalePage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.92792F));
            this.LayoutScalePage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.73881F));
            this.LayoutScalePage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.LayoutScalePage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.LayoutScalePage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.333276F));
            this.LayoutScalePage.Size = new System.Drawing.Size(206, 255);
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
            this.LayoutUnnamed2.Location = new System.Drawing.Point(3, 19);
            this.LayoutUnnamed2.Name = "LayoutUnnamed2";
            this.LayoutUnnamed2.RowCount = 1;
            this.LayoutUnnamed2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutUnnamed2.Size = new System.Drawing.Size(200, 123);
            this.LayoutUnnamed2.TabIndex = 0;
            // 
            // PanelPortraitLrg
            // 
            this.PanelPortraitLrg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelPortraitLrg.Controls.Add(this.PicPortraitLrg);
            this.PanelPortraitLrg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelPortraitLrg.Location = new System.Drawing.Point(70, 3);
            this.PanelPortraitLrg.Name = "PanelPortraitLrg";
            this.PanelPortraitLrg.Padding = new System.Windows.Forms.Padding(10);
            this.PanelPortraitLrg.Size = new System.Drawing.Size(57, 117);
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
            this.PanelPortraitMed.Location = new System.Drawing.Point(12, 3);
            this.PanelPortraitMed.Name = "PanelPortraitMed";
            this.PanelPortraitMed.Padding = new System.Windows.Forms.Padding(10);
            this.PanelPortraitMed.Size = new System.Drawing.Size(52, 117);
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
            this.PanelPortraitSml.Location = new System.Drawing.Point(133, 3);
            this.PanelPortraitSml.Name = "PanelPortraitSml";
            this.PanelPortraitSml.Padding = new System.Windows.Forms.Padding(10);
            this.PanelPortraitSml.Size = new System.Drawing.Size(52, 117);
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
            this.LayoutUnnamed3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.26437F));
            this.LayoutUnnamed3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.LayoutUnnamed3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.817605F));
            this.LayoutUnnamed3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.LayoutUnnamed3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.543945F));
            this.LayoutUnnamed3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.08789F));
            this.LayoutUnnamed3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.28619F));
            this.LayoutUnnamed3.Controls.Add(this.ButtonHintOnScalePage, 5, 0);
            this.LayoutUnnamed3.Controls.Add(this.ButtonToFilePage2, 1, 0);
            this.LayoutUnnamed3.Controls.Add(this.ButtonCreatePortrait, 3, 0);
            this.LayoutUnnamed3.Controls.Add(this.LblToFilePage, 0, 0);
            this.LayoutUnnamed3.Controls.Add(this.LblToCreatePortrait, 2, 0);
            this.LayoutUnnamed3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutUnnamed3.Location = new System.Drawing.Point(3, 198);
            this.LayoutUnnamed3.Name = "LayoutUnnamed3";
            this.LayoutUnnamed3.RowCount = 1;
            this.LayoutUnnamed3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutUnnamed3.Size = new System.Drawing.Size(200, 44);
            this.LayoutUnnamed3.TabIndex = 1;
            // 
            // ButtonHintOnScalePage
            // 
            this.ButtonHintOnScalePage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonHintOnScalePage.Cursor = System.Windows.Forms.Cursors.Help;
            this.ButtonHintOnScalePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonHintOnScalePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonHintOnScalePage.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonHintOnScalePage.Location = new System.Drawing.Point(260, 3);
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
            this.ButtonToFilePage2.Location = new System.Drawing.Point(-61, 3);
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
            this.ButtonCreatePortrait.Location = new System.Drawing.Point(99, 3);
            this.ButtonCreatePortrait.Name = "ButtonCreatePortrait";
            this.ButtonCreatePortrait.Size = new System.Drawing.Size(164, 38);
            this.ButtonCreatePortrait.TabIndex = 2;
            this.ButtonCreatePortrait.Text = "ToCreatePortrait";
            this.ButtonCreatePortrait.UseVisualStyleBackColor = true;
            this.ButtonCreatePortrait.Click += new System.EventHandler(this.ButtonCreatePortrait_Click);
            this.ButtonCreatePortrait.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonCreatePortrait.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // LblToFilePage
            // 
            this.LblToFilePage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblToFilePage.AutoSize = true;
            this.LblToFilePage.ForeColor = System.Drawing.Color.Goldenrod;
            this.LblToFilePage.Location = new System.Drawing.Point(3, 15);
            this.LblToFilePage.Name = "LblToFilePage";
            this.LblToFilePage.Size = new System.Drawing.Size(1, 13);
            this.LblToFilePage.TabIndex = 3;
            this.LblToFilePage.Text = "q.";
            this.LblToFilePage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblToCreatePortrait
            // 
            this.LblToCreatePortrait.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblToCreatePortrait.AutoSize = true;
            this.LblToCreatePortrait.ForeColor = System.Drawing.Color.Goldenrod;
            this.LblToCreatePortrait.Location = new System.Drawing.Point(109, 15);
            this.LblToCreatePortrait.Name = "LblToCreatePortrait";
            this.LblToCreatePortrait.Size = new System.Drawing.Size(1, 13);
            this.LblToCreatePortrait.TabIndex = 4;
            this.LblToCreatePortrait.Text = "e.";
            this.LblToCreatePortrait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.LayoutUnnamed4.Location = new System.Drawing.Point(3, 148);
            this.LayoutUnnamed4.Name = "LayoutUnnamed4";
            this.LayoutUnnamed4.RowCount = 1;
            this.LayoutUnnamed4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutUnnamed4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.LayoutUnnamed4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.LayoutUnnamed4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.LayoutUnnamed4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.LayoutUnnamed4.Size = new System.Drawing.Size(200, 44);
            this.LayoutUnnamed4.TabIndex = 2;
            // 
            // LabelMedImage
            // 
            this.LabelMedImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelMedImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LabelMedImage.ForeColor = System.Drawing.Color.Goldenrod;
            this.LabelMedImage.Location = new System.Drawing.Point(12, 0);
            this.LabelMedImage.Name = "LabelMedImage";
            this.LabelMedImage.Size = new System.Drawing.Size(52, 44);
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
            this.LabelLrgImg.Location = new System.Drawing.Point(70, 0);
            this.LabelLrgImg.Name = "LabelLrgImg";
            this.LabelLrgImg.Size = new System.Drawing.Size(57, 44);
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
            this.LabelSmlImg.Location = new System.Drawing.Point(133, 0);
            this.LabelSmlImg.Name = "LabelSmlImg";
            this.LabelSmlImg.Size = new System.Drawing.Size(52, 44);
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
            this.LayoutMainPage.Size = new System.Drawing.Size(221, 285);
            this.LayoutMainPage.TabIndex = 0;
            // 
            // ButtonToFilePage
            // 
            this.ButtonToFilePage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonToFilePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonToFilePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonToFilePage.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonToFilePage.Location = new System.Drawing.Point(-51, 116);
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
            this.ButtonToExtractPage.Location = new System.Drawing.Point(-51, 161);
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
            this.ButtonToGalleryPage.Location = new System.Drawing.Point(-51, 206);
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
            this.PictureBoxTitle.Location = new System.Drawing.Point(-51, -49);
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
            this.LabelCopyright.Location = new System.Drawing.Point(68, 338);
            this.LabelCopyright.Name = "LabelCopyright";
            this.LabelCopyright.Size = new System.Drawing.Size(86, 1);
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
            this.ButtonToSettingsPage.Location = new System.Drawing.Point(-51, 251);
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
            this.ButtonExit.Location = new System.Drawing.Point(-51, 296);
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
            this.LayoutLang.Controls.Add(this.PicBoxGer, 2, 0);
            this.LayoutLang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutLang.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LayoutLang.Location = new System.Drawing.Point(3, 3);
            this.LayoutLang.Name = "LayoutLang";
            this.LayoutLang.RowCount = 2;
            this.LayoutLang.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.LayoutLang.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LayoutLang.Size = new System.Drawing.Size(1, 1);
            this.LayoutLang.TabIndex = 8;
            // 
            // PicBoxEng
            // 
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
            this.PicBoxGer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PicBoxGer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicBoxGer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicBoxGer.Location = new System.Drawing.Point(83, 3);
            this.PicBoxGer.Name = "PicBoxGer";
            this.PicBoxGer.Size = new System.Drawing.Size(34, 19);
            this.PicBoxGer.TabIndex = 2;
            this.PicBoxGer.TabStop = false;
            this.PicBoxGer.Click += new System.EventHandler(this.PicBoxGer_Click);
            // 
            // LabelVersion
            // 
            this.LabelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelVersion.AutoSize = true;
            this.LabelVersion.BackColor = System.Drawing.Color.Transparent;
            this.LabelVersion.Cursor = System.Windows.Forms.Cursors.Help;
            this.LabelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelVersion.ForeColor = System.Drawing.Color.Goldenrod;
            this.LabelVersion.Location = new System.Drawing.Point(279, 338);
            this.LabelVersion.Name = "LabelVersion";
            this.LabelVersion.Size = new System.Drawing.Size(1, 1);
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
            this.LblPointerToFilePage.Location = new System.Drawing.Point(3, 128);
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
            this.LblPointerToExtractPage.Location = new System.Drawing.Point(3, 173);
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
            this.LblPointerToGalleryPage.Location = new System.Drawing.Point(3, 218);
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
            this.LayoutExtractPage.Location = new System.Drawing.Point(-5, 0);
            this.LayoutExtractPage.Name = "LayoutExtractPage";
            this.LayoutExtractPage.RowCount = 3;
            this.LayoutExtractPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.641887F));
            this.LayoutExtractPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.71623F));
            this.LayoutExtractPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.641887F));
            this.LayoutExtractPage.Size = new System.Drawing.Size(85, 68);
            this.LayoutExtractPage.TabIndex = 3;
            this.LayoutExtractPage.Visible = false;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 5;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.35F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.63232F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.873536F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 226F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.030001F));
            this.tableLayoutPanel5.Controls.Add(this.ListExtract, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 3, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 8);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(79, 50);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // ListExtract
            // 
            this.ListExtract.BackColor = System.Drawing.Color.Black;
            this.ListExtract.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListExtract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListExtract.HideSelection = false;
            this.ListExtract.LargeImageList = this.ImgListExtract;
            this.ListExtract.Location = new System.Drawing.Point(0, 3);
            this.ListExtract.Name = "ListExtract";
            this.ListExtract.Size = new System.Drawing.Size(1, 44);
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
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.ButtonChooseFolder, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.ButtonExtractAll, 1, 2);
            this.tableLayoutPanel6.Controls.Add(this.ButtonExtractSelected, 1, 3);
            this.tableLayoutPanel6.Controls.Add(this.ButtonOpenFolders, 1, 5);
            this.tableLayoutPanel6.Controls.Add(this.ButtonToMainPage2, 1, 6);
            this.tableLayoutPanel6.Controls.Add(this.ButtonHintExtract, 1, 7);
            this.tableLayoutPanel6.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.label5, 0, 6);
            this.tableLayoutPanel6.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(-135, 3);
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
            this.tableLayoutPanel6.Size = new System.Drawing.Size(220, 44);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // ButtonChooseFolder
            // 
            this.ButtonChooseFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonChooseFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonChooseFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonChooseFolder.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonChooseFolder.Location = new System.Drawing.Point(38, -132);
            this.ButtonChooseFolder.Name = "ButtonChooseFolder";
            this.ButtonChooseFolder.Size = new System.Drawing.Size(179, 39);
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
            this.ButtonExtractAll.Location = new System.Drawing.Point(38, -87);
            this.ButtonExtractAll.Name = "ButtonExtractAll";
            this.ButtonExtractAll.Size = new System.Drawing.Size(179, 39);
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
            this.ButtonExtractSelected.Location = new System.Drawing.Point(38, -42);
            this.ButtonExtractSelected.Name = "ButtonExtractSelected";
            this.ButtonExtractSelected.Size = new System.Drawing.Size(179, 39);
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
            this.ButtonOpenFolders.Location = new System.Drawing.Point(38, 48);
            this.ButtonOpenFolders.Name = "ButtonOpenFolders";
            this.ButtonOpenFolders.Size = new System.Drawing.Size(179, 39);
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
            this.ButtonToMainPage2.Location = new System.Drawing.Point(38, 93);
            this.ButtonToMainPage2.Name = "ButtonToMainPage2";
            this.ButtonToMainPage2.Size = new System.Drawing.Size(179, 39);
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
            this.ButtonHintExtract.Location = new System.Drawing.Point(38, 138);
            this.ButtonHintExtract.Name = "ButtonHintExtract";
            this.ButtonHintExtract.Size = new System.Drawing.Size(179, 39);
            this.ButtonHintExtract.TabIndex = 4;
            this.ButtonHintExtract.Text = "Hint";
            this.ButtonHintExtract.UseVisualStyleBackColor = true;
            this.ButtonHintExtract.Click += new System.EventHandler(this.ButtonHintExtract_Click);
            this.ButtonHintExtract.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonHintExtract.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Goldenrod;
            this.label3.Location = new System.Drawing.Point(16, -119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "e.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Goldenrod;
            this.label4.Location = new System.Drawing.Point(19, -74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "r.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Goldenrod;
            this.label5.Location = new System.Drawing.Point(16, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "q.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Goldenrod;
            this.label6.Location = new System.Drawing.Point(16, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "o.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LayoutUnnamed10
            // 
            this.LayoutUnnamed10.ColumnCount = 5;
            this.LayoutUnnamed10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.349733F));
            this.LayoutUnnamed10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 91.09589F));
            this.LayoutUnnamed10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.369863F));
            this.LayoutUnnamed10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 222F));
            this.LayoutUnnamed10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.029026F));
            this.LayoutUnnamed10.Controls.Add(this.ListGallery, 1, 0);
            this.LayoutUnnamed10.Controls.Add(this.LayoutUnnamed11, 3, 0);
            this.LayoutUnnamed10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutUnnamed10.Location = new System.Drawing.Point(3, 28);
            this.LayoutUnnamed10.Name = "LayoutUnnamed10";
            this.LayoutUnnamed10.RowCount = 1;
            this.LayoutUnnamed10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutUnnamed10.Size = new System.Drawing.Size(200, 218);
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
            this.ListGallery.Location = new System.Drawing.Point(3, 3);
            this.ListGallery.Name = "ListGallery";
            this.ListGallery.Size = new System.Drawing.Size(1, 212);
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
            this.LayoutUnnamed11.ColumnCount = 2;
            this.LayoutUnnamed11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.LayoutUnnamed11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutUnnamed11.Controls.Add(this.ButtonToMainPage3, 1, 6);
            this.LayoutUnnamed11.Controls.Add(this.ButtonOpenFolder, 1, 4);
            this.LayoutUnnamed11.Controls.Add(this.ButtonDeletePortait, 1, 2);
            this.LayoutUnnamed11.Controls.Add(this.ButtonChangePortrait, 1, 1);
            this.LayoutUnnamed11.Controls.Add(this.ButtonHintFolder, 1, 7);
            this.LayoutUnnamed11.Controls.Add(this.LblToMainPage3, 0, 6);
            this.LayoutUnnamed11.Controls.Add(this.LblToOpenFolder, 0, 4);
            this.LayoutUnnamed11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutUnnamed11.Location = new System.Drawing.Point(-17, 3);
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
            this.LayoutUnnamed11.Size = new System.Drawing.Size(216, 212);
            this.LayoutUnnamed11.TabIndex = 0;
            // 
            // ButtonToMainPage3
            // 
            this.ButtonToMainPage3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonToMainPage3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonToMainPage3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonToMainPage3.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonToMainPage3.Location = new System.Drawing.Point(42, 177);
            this.ButtonToMainPage3.Name = "ButtonToMainPage3";
            this.ButtonToMainPage3.Size = new System.Drawing.Size(171, 39);
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
            this.ButtonOpenFolder.Location = new System.Drawing.Point(42, 87);
            this.ButtonOpenFolder.Name = "ButtonOpenFolder";
            this.ButtonOpenFolder.Size = new System.Drawing.Size(171, 39);
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
            this.ButtonDeletePortait.Location = new System.Drawing.Point(42, -3);
            this.ButtonDeletePortait.Name = "ButtonDeletePortait";
            this.ButtonDeletePortait.Size = new System.Drawing.Size(171, 39);
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
            this.ButtonChangePortrait.Location = new System.Drawing.Point(42, -48);
            this.ButtonChangePortrait.Name = "ButtonChangePortrait";
            this.ButtonChangePortrait.Size = new System.Drawing.Size(171, 39);
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
            this.ButtonHintFolder.Location = new System.Drawing.Point(42, 222);
            this.ButtonHintFolder.Name = "ButtonHintFolder";
            this.ButtonHintFolder.Size = new System.Drawing.Size(171, 39);
            this.ButtonHintFolder.TabIndex = 4;
            this.ButtonHintFolder.Text = "Hint";
            this.ButtonHintFolder.UseVisualStyleBackColor = true;
            this.ButtonHintFolder.Click += new System.EventHandler(this.ButtonHintFolder_Click);
            this.ButtonHintFolder.MouseEnter += new System.EventHandler(this.AnyPrimeButton_Enter);
            this.ButtonHintFolder.MouseLeave += new System.EventHandler(this.AnyPrimeButton_Leave);
            // 
            // LblToMainPage3
            // 
            this.LblToMainPage3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblToMainPage3.AutoSize = true;
            this.LblToMainPage3.ForeColor = System.Drawing.Color.Goldenrod;
            this.LblToMainPage3.Location = new System.Drawing.Point(20, 190);
            this.LblToMainPage3.Name = "LblToMainPage3";
            this.LblToMainPage3.Size = new System.Drawing.Size(16, 13);
            this.LblToMainPage3.TabIndex = 5;
            this.LblToMainPage3.Text = "q.";
            this.LblToMainPage3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblToOpenFolder
            // 
            this.LblToOpenFolder.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblToOpenFolder.AutoSize = true;
            this.LblToOpenFolder.ForeColor = System.Drawing.Color.Goldenrod;
            this.LblToOpenFolder.Location = new System.Drawing.Point(20, 100);
            this.LblToOpenFolder.Name = "LblToOpenFolder";
            this.LblToOpenFolder.Size = new System.Drawing.Size(16, 13);
            this.LblToOpenFolder.TabIndex = 6;
            this.LblToOpenFolder.Text = "o.";
            this.LblToOpenFolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LayoutGallery
            // 
            this.LayoutGallery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(28)))), ((int)(((byte)(9)))));
            this.LayoutGallery.ColumnCount = 1;
            this.LayoutGallery.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutGallery.Controls.Add(this.tableLayoutPanel11, 0, 0);
            this.LayoutGallery.Controls.Add(this.LayoutUnnamed10, 0, 1);
            this.LayoutGallery.Location = new System.Drawing.Point(0, 0);
            this.LayoutGallery.Name = "LayoutGallery";
            this.LayoutGallery.RowCount = 3;
            this.LayoutGallery.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.523937F));
            this.LayoutGallery.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.96509F));
            this.LayoutGallery.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.510967F));
            this.LayoutGallery.Size = new System.Drawing.Size(206, 264);
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
            this.tableLayoutPanel11.Size = new System.Drawing.Size(200, 19);
            this.tableLayoutPanel11.TabIndex = 1;
            // 
            // ButtonLoadNormal
            // 
            this.ButtonLoadNormal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonLoadNormal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonLoadNormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonLoadNormal.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonLoadNormal.Location = new System.Drawing.Point(24, -13);
            this.ButtonLoadNormal.Name = "ButtonLoadNormal";
            this.ButtonLoadNormal.Size = new System.Drawing.Size(32, 29);
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
            this.ButtonLoadCustom.Location = new System.Drawing.Point(67, -13);
            this.ButtonLoadCustom.Name = "ButtonLoadCustom";
            this.ButtonLoadCustom.Size = new System.Drawing.Size(32, 29);
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
            this.ButtonLoadCustomNPC.Location = new System.Drawing.Point(105, -13);
            this.ButtonLoadCustomNPC.Name = "ButtonLoadCustomNPC";
            this.ButtonLoadCustomNPC.Size = new System.Drawing.Size(31, 29);
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
            this.ButtonLoadCustomArmy.Location = new System.Drawing.Point(142, -13);
            this.ButtonLoadCustomArmy.Name = "ButtonLoadCustomArmy";
            this.ButtonLoadCustomArmy.Size = new System.Drawing.Size(31, 29);
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
            this.LayoutURLDialog.Location = new System.Drawing.Point(10, 0);
            this.LayoutURLDialog.Name = "LayoutURLDialog";
            this.LayoutURLDialog.RowCount = 3;
            this.LayoutURLDialog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutURLDialog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 282F));
            this.LayoutURLDialog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutURLDialog.Size = new System.Drawing.Size(70, 74);
            this.LayoutURLDialog.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.LabelURLInfo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TextBoxURL, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(-212, -101);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(494, 276);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // LabelURLInfo
            // 
            this.LabelURLInfo.AutoSize = true;
            this.LabelURLInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelURLInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelURLInfo.Location = new System.Drawing.Point(3, 0);
            this.LabelURLInfo.Name = "LabelURLInfo";
            this.LabelURLInfo.Size = new System.Drawing.Size(488, 162);
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
            this.TextBoxURL.Location = new System.Drawing.Point(3, 165);
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
            this.tableLayoutPanel2.Controls.Add(this.ButtonDenyWeb, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.ButtonLoadWeb, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.LblToFilePage3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.LblToLoadToFilePage, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 204);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(488, 69);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // ButtonDenyWeb
            // 
            this.ButtonDenyWeb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDenyWeb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonDenyWeb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonDenyWeb.Location = new System.Drawing.Point(50, 27);
            this.ButtonDenyWeb.Margin = new System.Windows.Forms.Padding(50, 3, 25, 3);
            this.ButtonDenyWeb.Name = "ButtonDenyWeb";
            this.ButtonDenyWeb.Size = new System.Drawing.Size(169, 39);
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
            this.ButtonLoadWeb.Location = new System.Drawing.Point(269, 27);
            this.ButtonLoadWeb.Margin = new System.Windows.Forms.Padding(25, 3, 50, 3);
            this.ButtonLoadWeb.Name = "ButtonLoadWeb";
            this.ButtonLoadWeb.Size = new System.Drawing.Size(169, 39);
            this.ButtonLoadWeb.TabIndex = 1;
            this.ButtonLoadWeb.Text = "TryLoadToFilePage";
            this.ButtonLoadWeb.UseVisualStyleBackColor = true;
            this.ButtonLoadWeb.Click += new System.EventHandler(this.ButtonLoadWeb_Click);
            this.ButtonLoadWeb.MouseEnter += new System.EventHandler(this.AnyButton_Enter);
            this.ButtonLoadWeb.MouseLeave += new System.EventHandler(this.AnyButton_Leave);
            // 
            // LblToFilePage3
            // 
            this.LblToFilePage3.AutoSize = true;
            this.LblToFilePage3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblToFilePage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblToFilePage3.Location = new System.Drawing.Point(50, 9);
            this.LblToFilePage3.Margin = new System.Windows.Forms.Padding(50, 0, 25, 0);
            this.LblToFilePage3.Name = "LblToFilePage3";
            this.LblToFilePage3.Size = new System.Drawing.Size(169, 15);
            this.LblToFilePage3.TabIndex = 2;
            this.LblToFilePage3.Text = "q.";
            this.LblToFilePage3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblToLoadToFilePage
            // 
            this.LblToLoadToFilePage.AutoSize = true;
            this.LblToLoadToFilePage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblToLoadToFilePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblToLoadToFilePage.Location = new System.Drawing.Point(269, 9);
            this.LblToLoadToFilePage.Margin = new System.Windows.Forms.Padding(25, 0, 50, 0);
            this.LblToLoadToFilePage.Name = "LblToLoadToFilePage";
            this.LblToLoadToFilePage.Size = new System.Drawing.Size(169, 15);
            this.LblToLoadToFilePage.TabIndex = 3;
            this.LblToLoadToFilePage.Text = "e.";
            this.LblToLoadToFilePage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LayoutFinalPage
            // 
            this.LayoutFinalPage.BackColor = System.Drawing.Color.Black;
            this.LayoutFinalPage.ColumnCount = 3;
            this.LayoutFinalPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutFinalPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 557F));
            this.LayoutFinalPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutFinalPage.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.LayoutFinalPage.ForeColor = System.Drawing.Color.White;
            this.LayoutFinalPage.Location = new System.Drawing.Point(-5, 0);
            this.LayoutFinalPage.Name = "LayoutFinalPage";
            this.LayoutFinalPage.RowCount = 3;
            this.LayoutFinalPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutFinalPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 290F));
            this.LayoutFinalPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutFinalPage.Size = new System.Drawing.Size(91, 75);
            this.LayoutFinalPage.TabIndex = 6;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.LabelFinalMesg, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.LabelDirLoc, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel12, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(-230, -104);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.72539F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.36787F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.90674F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(551, 284);
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
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 219);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(545, 62);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // ButtonToMainPage4
            // 
            this.ButtonToMainPage4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonToMainPage4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonToMainPage4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonToMainPage4.Location = new System.Drawing.Point(3, 3);
            this.ButtonToMainPage4.Name = "ButtonToMainPage4";
            this.ButtonToMainPage4.Size = new System.Drawing.Size(175, 56);
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
            this.ButtonToFilePage3.Location = new System.Drawing.Point(184, 3);
            this.ButtonToFilePage3.Name = "ButtonToFilePage3";
            this.ButtonToFilePage3.Size = new System.Drawing.Size(175, 56);
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
            this.ButtonToMainPageAndFolder.Location = new System.Drawing.Point(365, 3);
            this.ButtonToMainPageAndFolder.Name = "ButtonToMainPageAndFolder";
            this.ButtonToMainPageAndFolder.Size = new System.Drawing.Size(177, 56);
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
            this.LabelFinalMesg.Location = new System.Drawing.Point(3, 53);
            this.LabelFinalMesg.Name = "LabelFinalMesg";
            this.LabelFinalMesg.Size = new System.Drawing.Size(545, 138);
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
            this.LabelDirLoc.Size = new System.Drawing.Size(545, 53);
            this.LabelDirLoc.TabIndex = 3;
            this.LabelDirLoc.Text = "DirLoc";
            this.LabelDirLoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 3;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel12.Controls.Add(this.LblToMenuPage, 0, 0);
            this.tableLayoutPanel12.Controls.Add(this.LblToFilePage2, 1, 0);
            this.tableLayoutPanel12.Controls.Add(this.LblToMenuPageAndOpenFIle, 2, 0);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(3, 194);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 1;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(545, 19);
            this.tableLayoutPanel12.TabIndex = 4;
            // 
            // LblToMenuPage
            // 
            this.LblToMenuPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LblToMenuPage.AutoSize = true;
            this.LblToMenuPage.Location = new System.Drawing.Point(3, 3);
            this.LblToMenuPage.Name = "LblToMenuPage";
            this.LblToMenuPage.Size = new System.Drawing.Size(175, 13);
            this.LblToMenuPage.TabIndex = 0;
            this.LblToMenuPage.Text = "1.";
            this.LblToMenuPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblToFilePage2
            // 
            this.LblToFilePage2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LblToFilePage2.AutoSize = true;
            this.LblToFilePage2.Location = new System.Drawing.Point(184, 3);
            this.LblToFilePage2.Name = "LblToFilePage2";
            this.LblToFilePage2.Size = new System.Drawing.Size(175, 13);
            this.LblToFilePage2.TabIndex = 1;
            this.LblToFilePage2.Text = "2.";
            this.LblToFilePage2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblToMenuPageAndOpenFIle
            // 
            this.LblToMenuPageAndOpenFIle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LblToMenuPageAndOpenFIle.AutoSize = true;
            this.LblToMenuPageAndOpenFIle.Location = new System.Drawing.Point(365, 3);
            this.LblToMenuPageAndOpenFIle.Name = "LblToMenuPageAndOpenFIle";
            this.LblToMenuPageAndOpenFIle.Size = new System.Drawing.Size(177, 13);
            this.LblToMenuPageAndOpenFIle.TabIndex = 2;
            this.LblToMenuPageAndOpenFIle.Text = "3.";
            this.LblToMenuPageAndOpenFIle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.LayoutSettingsPage.Location = new System.Drawing.Point(-5, 0);
            this.LayoutSettingsPage.Name = "LayoutSettingsPage";
            this.LayoutSettingsPage.RowCount = 3;
            this.LayoutSettingsPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutSettingsPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 450F));
            this.LayoutSettingsPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutSettingsPage.Size = new System.Drawing.Size(76, 65);
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
            this.tableLayoutPanel7.Location = new System.Drawing.Point(-234, -189);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 7;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.21779F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.05769F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.13067F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.05769F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.05769F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.58112F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.89734F));
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
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 92);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(538, 56);
            this.tableLayoutPanel8.TabIndex = 1;
            // 
            // ButtonKingmaker
            // 
            this.ButtonKingmaker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonKingmaker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonKingmaker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonKingmaker.Location = new System.Drawing.Point(10, 5);
            this.ButtonKingmaker.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.ButtonKingmaker.Name = "ButtonKingmaker";
            this.ButtonKingmaker.Size = new System.Drawing.Size(159, 46);
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
            this.ButtonWotR.Location = new System.Drawing.Point(189, 5);
            this.ButtonWotR.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.ButtonWotR.Name = "ButtonWotR";
            this.ButtonWotR.Size = new System.Drawing.Size(159, 46);
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
            this.ButtonRT.Location = new System.Drawing.Point(368, 5);
            this.ButtonRT.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.ButtonRT.Name = "ButtonRT";
            this.ButtonRT.Size = new System.Drawing.Size(160, 46);
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
            this.ButtonToMainPage5.Margin = new System.Windows.Forms.Padding(200, 5, 200, 5);
            this.ButtonToMainPage5.Name = "ButtonToMainPage5";
            this.ButtonToMainPage5.Size = new System.Drawing.Size(144, 55);
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
            this.LabelSelectedPath.Location = new System.Drawing.Point(3, 151);
            this.LabelSelectedPath.Name = "LabelSelectedPath";
            this.LabelSelectedPath.Size = new System.Drawing.Size(538, 53);
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
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 269);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(538, 56);
            this.tableLayoutPanel9.TabIndex = 4;
            // 
            // ButtonValidatePath
            // 
            this.ButtonValidatePath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonValidatePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonValidatePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonValidatePath.Location = new System.Drawing.Point(208, 5);
            this.ButtonValidatePath.Margin = new System.Windows.Forms.Padding(15, 5, 15, 5);
            this.ButtonValidatePath.Name = "ButtonValidatePath";
            this.ButtonValidatePath.Size = new System.Drawing.Size(119, 46);
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
            this.ButtonSelectPath.Location = new System.Drawing.Point(15, 5);
            this.ButtonSelectPath.Margin = new System.Windows.Forms.Padding(15, 5, 15, 5);
            this.ButtonSelectPath.Name = "ButtonSelectPath";
            this.ButtonSelectPath.Size = new System.Drawing.Size(119, 46);
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
            this.label1.Size = new System.Drawing.Size(38, 56);
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
            this.label2.Size = new System.Drawing.Size(38, 56);
            this.label2.TabIndex = 6;
            this.label2.Text = "▶";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonApplyChange
            // 
            this.ButtonApplyChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonApplyChange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonApplyChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonApplyChange.Location = new System.Drawing.Point(401, 5);
            this.ButtonApplyChange.Margin = new System.Windows.Forms.Padding(15, 5, 15, 5);
            this.ButtonApplyChange.Name = "ButtonApplyChange";
            this.ButtonApplyChange.Size = new System.Drawing.Size(122, 46);
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
            this.LabelSettings.Size = new System.Drawing.Size(538, 89);
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
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 207);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(538, 56);
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
            this.ButtonRestorePath.Size = new System.Drawing.Size(48, 48);
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
            this.TextBoxFullPath.Size = new System.Drawing.Size(454, 50);
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
            this.LayoutUnnamed16.Location = new System.Drawing.Point(3, 331);
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
            // LayoutStartMenu
            // 
            this.LayoutStartMenu.BackColor = System.Drawing.Color.Black;
            this.LayoutStartMenu.BackgroundImage = global::PortraitManager.Properties.Resources.start_path;
            this.LayoutStartMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.LayoutStartMenu.ColumnCount = 2;
            this.LayoutStartMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.23433F));
            this.LayoutStartMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.76567F));
            this.LayoutStartMenu.Controls.Add(this.tableLayoutPanel13, 1, 1);
            this.LayoutStartMenu.Controls.Add(this.tableLayoutPanel14, 1, 2);
            this.LayoutStartMenu.Controls.Add(this.tableLayoutPanel15, 1, 3);
            this.LayoutStartMenu.Controls.Add(this.tableLayoutPanel16, 1, 4);
            this.LayoutStartMenu.Controls.Add(this.tableLayoutPanel17, 1, 5);
            this.LayoutStartMenu.Controls.Add(this.tableLayoutPanel18, 1, 6);
            this.LayoutStartMenu.Controls.Add(this.tableLayoutPanel19, 1, 7);
            this.LayoutStartMenu.Controls.Add(this.tableLayoutPanel20, 1, 8);
            this.LayoutStartMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutStartMenu.Location = new System.Drawing.Point(0, 0);
            this.LayoutStartMenu.Name = "LayoutStartMenu";
            this.LayoutStartMenu.RowCount = 9;
            this.LayoutStartMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.LayoutStartMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.LayoutStartMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.LayoutStartMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.LayoutStartMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.LayoutStartMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.LayoutStartMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.LayoutStartMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.LayoutStartMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.LayoutStartMenu.Size = new System.Drawing.Size(734, 481);
            this.LayoutStartMenu.TabIndex = 8;
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.ColumnCount = 2;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.33333F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.66666F));
            this.tableLayoutPanel13.Controls.Add(this.ButtonStartKing, 1, 0);
            this.tableLayoutPanel13.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(439, 43);
            this.tableLayoutPanel13.Margin = new System.Windows.Forms.Padding(130, 3, 3, 3);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 1;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(292, 51);
            this.tableLayoutPanel13.TabIndex = 7;
            // 
            // ButtonStartKing
            // 
            this.ButtonStartKing.BackColor = System.Drawing.Color.Black;
            this.ButtonStartKing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonStartKing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonStartKing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonStartKing.FlatAppearance.BorderSize = 0;
            this.ButtonStartKing.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.ButtonStartKing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonStartKing.ForeColor = System.Drawing.Color.White;
            this.ButtonStartKing.Location = new System.Drawing.Point(56, 3);
            this.ButtonStartKing.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.ButtonStartKing.Name = "ButtonStartKing";
            this.ButtonStartKing.Size = new System.Drawing.Size(233, 45);
            this.ButtonStartKing.TabIndex = 0;
            this.ButtonStartKing.Text = "path:king";
            this.ButtonStartKing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonStartKing.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ButtonStartKing.UseVisualStyleBackColor = false;
            this.ButtonStartKing.MouseEnter += new System.EventHandler(this.ButtonStartKing_MouseEnter);
            this.ButtonStartKing.MouseLeave += new System.EventHandler(this.ButtonStartKing_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::PortraitManager.Properties.Resources.icon_path1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 45);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 2;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.09524F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.90476F));
            this.tableLayoutPanel14.Controls.Add(this.ButtonStartWotr, 1, 0);
            this.tableLayoutPanel14.Controls.Add(this.pictureBox2, 0, 0);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(424, 100);
            this.tableLayoutPanel14.Margin = new System.Windows.Forms.Padding(115, 3, 3, 3);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 1;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(307, 51);
            this.tableLayoutPanel14.TabIndex = 8;
            // 
            // ButtonStartWotr
            // 
            this.ButtonStartWotr.BackColor = System.Drawing.Color.Black;
            this.ButtonStartWotr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonStartWotr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonStartWotr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonStartWotr.FlatAppearance.BorderSize = 0;
            this.ButtonStartWotr.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.ButtonStartWotr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonStartWotr.ForeColor = System.Drawing.Color.White;
            this.ButtonStartWotr.Location = new System.Drawing.Point(55, 3);
            this.ButtonStartWotr.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.ButtonStartWotr.Name = "ButtonStartWotr";
            this.ButtonStartWotr.Size = new System.Drawing.Size(249, 45);
            this.ButtonStartWotr.TabIndex = 1;
            this.ButtonStartWotr.Text = "path:wotr";
            this.ButtonStartWotr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonStartWotr.UseVisualStyleBackColor = false;
            this.ButtonStartWotr.MouseEnter += new System.EventHandler(this.ButtonStartWotr_MouseEnter);
            this.ButtonStartWotr.MouseLeave += new System.EventHandler(this.ButtonStartWotr_MouseLeave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::PortraitManager.Properties.Resources.icon_wotr1;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(52, 45);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.ColumnCount = 2;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.36364F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.63636F));
            this.tableLayoutPanel15.Controls.Add(this.ButtonStartRt, 1, 0);
            this.tableLayoutPanel15.Controls.Add(this.pictureBox3, 0, 0);
            this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel15.Location = new System.Drawing.Point(409, 157);
            this.tableLayoutPanel15.Margin = new System.Windows.Forms.Padding(100, 3, 3, 3);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 1;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(322, 51);
            this.tableLayoutPanel15.TabIndex = 9;
            // 
            // ButtonStartRt
            // 
            this.ButtonStartRt.BackColor = System.Drawing.Color.Black;
            this.ButtonStartRt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonStartRt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonStartRt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonStartRt.FlatAppearance.BorderSize = 0;
            this.ButtonStartRt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.ButtonStartRt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonStartRt.ForeColor = System.Drawing.Color.White;
            this.ButtonStartRt.Location = new System.Drawing.Point(52, 3);
            this.ButtonStartRt.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.ButtonStartRt.Name = "ButtonStartRt";
            this.ButtonStartRt.Size = new System.Drawing.Size(267, 45);
            this.ButtonStartRt.TabIndex = 2;
            this.ButtonStartRt.Text = "wh:rt";
            this.ButtonStartRt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonStartRt.UseVisualStyleBackColor = false;
            this.ButtonStartRt.MouseEnter += new System.EventHandler(this.ButtonStartRt_MouseEnter);
            this.ButtonStartRt.MouseLeave += new System.EventHandler(this.ButtonStartRt_MouseLeave);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::PortraitManager.Properties.Resources.icon_rt1;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Location = new System.Drawing.Point(3, 3);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(49, 45);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.MouseEnter += new System.EventHandler(this.pictureBox3_MouseEnter);
            this.pictureBox3.MouseLeave += new System.EventHandler(this.pictureBox3_MouseLeave);
            // 
            // tableLayoutPanel16
            // 
            this.tableLayoutPanel16.ColumnCount = 2;
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.52174F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.47826F));
            this.tableLayoutPanel16.Controls.Add(this.ButtonStartPoe, 1, 0);
            this.tableLayoutPanel16.Controls.Add(this.pictureBox4, 0, 0);
            this.tableLayoutPanel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel16.Location = new System.Drawing.Point(394, 214);
            this.tableLayoutPanel16.Margin = new System.Windows.Forms.Padding(85, 3, 3, 3);
            this.tableLayoutPanel16.Name = "tableLayoutPanel16";
            this.tableLayoutPanel16.RowCount = 1;
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel16.Size = new System.Drawing.Size(337, 51);
            this.tableLayoutPanel16.TabIndex = 10;
            // 
            // ButtonStartPoe
            // 
            this.ButtonStartPoe.BackColor = System.Drawing.Color.Black;
            this.ButtonStartPoe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonStartPoe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonStartPoe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonStartPoe.FlatAppearance.BorderSize = 0;
            this.ButtonStartPoe.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.ButtonStartPoe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonStartPoe.ForeColor = System.Drawing.Color.White;
            this.ButtonStartPoe.Location = new System.Drawing.Point(55, 3);
            this.ButtonStartPoe.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.ButtonStartPoe.Name = "ButtonStartPoe";
            this.ButtonStartPoe.Size = new System.Drawing.Size(279, 45);
            this.ButtonStartPoe.TabIndex = 3;
            this.ButtonStartPoe.Text = "poe";
            this.ButtonStartPoe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonStartPoe.UseVisualStyleBackColor = false;
            this.ButtonStartPoe.MouseEnter += new System.EventHandler(this.ButtonStartPoe_MouseEnter);
            this.ButtonStartPoe.MouseLeave += new System.EventHandler(this.ButtonStartPoe_MouseLeave);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::PortraitManager.Properties.Resources.icon_poe1;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox4.Location = new System.Drawing.Point(3, 3);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(52, 45);
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.MouseEnter += new System.EventHandler(this.pictureBox4_MouseEnter);
            this.pictureBox4.MouseLeave += new System.EventHandler(this.pictureBox4_MouseLeave);
            // 
            // tableLayoutPanel17
            // 
            this.tableLayoutPanel17.ColumnCount = 2;
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.32033F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.67966F));
            this.tableLayoutPanel17.Controls.Add(this.ButtonStartPoed, 1, 0);
            this.tableLayoutPanel17.Controls.Add(this.pictureBox5, 0, 0);
            this.tableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel17.Location = new System.Drawing.Point(379, 271);
            this.tableLayoutPanel17.Margin = new System.Windows.Forms.Padding(70, 3, 3, 3);
            this.tableLayoutPanel17.Name = "tableLayoutPanel17";
            this.tableLayoutPanel17.RowCount = 1;
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel17.Size = new System.Drawing.Size(352, 51);
            this.tableLayoutPanel17.TabIndex = 11;
            // 
            // ButtonStartPoed
            // 
            this.ButtonStartPoed.BackColor = System.Drawing.Color.Black;
            this.ButtonStartPoed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonStartPoed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonStartPoed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonStartPoed.FlatAppearance.BorderSize = 0;
            this.ButtonStartPoed.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.ButtonStartPoed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonStartPoed.ForeColor = System.Drawing.Color.White;
            this.ButtonStartPoed.Location = new System.Drawing.Point(53, 3);
            this.ButtonStartPoed.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.ButtonStartPoed.Name = "ButtonStartPoed";
            this.ButtonStartPoed.Size = new System.Drawing.Size(296, 45);
            this.ButtonStartPoed.TabIndex = 4;
            this.ButtonStartPoed.Text = "poe:df";
            this.ButtonStartPoed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonStartPoed.UseVisualStyleBackColor = false;
            this.ButtonStartPoed.MouseEnter += new System.EventHandler(this.ButtonStartPoed_MouseEnter);
            this.ButtonStartPoed.MouseLeave += new System.EventHandler(this.ButtonStartPoed_MouseLeave);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::PortraitManager.Properties.Resources.icon_poed1;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox5.Location = new System.Drawing.Point(3, 3);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(50, 45);
            this.pictureBox5.TabIndex = 5;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.MouseEnter += new System.EventHandler(this.pictureBox5_MouseEnter);
            this.pictureBox5.MouseLeave += new System.EventHandler(this.pictureBox5_MouseLeave);
            // 
            // tableLayoutPanel18
            // 
            this.tableLayoutPanel18.ColumnCount = 2;
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.87302F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.12698F));
            this.tableLayoutPanel18.Controls.Add(this.ButtonStartTyr, 1, 0);
            this.tableLayoutPanel18.Controls.Add(this.pictureBox6, 0, 0);
            this.tableLayoutPanel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel18.Location = new System.Drawing.Point(364, 328);
            this.tableLayoutPanel18.Margin = new System.Windows.Forms.Padding(55, 3, 3, 3);
            this.tableLayoutPanel18.Name = "tableLayoutPanel18";
            this.tableLayoutPanel18.RowCount = 1;
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel18.Size = new System.Drawing.Size(367, 51);
            this.tableLayoutPanel18.TabIndex = 12;
            // 
            // ButtonStartTyr
            // 
            this.ButtonStartTyr.BackColor = System.Drawing.Color.Black;
            this.ButtonStartTyr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonStartTyr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonStartTyr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonStartTyr.FlatAppearance.BorderSize = 0;
            this.ButtonStartTyr.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.ButtonStartTyr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonStartTyr.ForeColor = System.Drawing.Color.White;
            this.ButtonStartTyr.Location = new System.Drawing.Point(58, 3);
            this.ButtonStartTyr.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.ButtonStartTyr.Name = "ButtonStartTyr";
            this.ButtonStartTyr.Size = new System.Drawing.Size(306, 45);
            this.ButtonStartTyr.TabIndex = 5;
            this.ButtonStartTyr.Text = "tyr";
            this.ButtonStartTyr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonStartTyr.UseVisualStyleBackColor = false;
            this.ButtonStartTyr.MouseEnter += new System.EventHandler(this.ButtonStartTyr_MouseEnter);
            this.ButtonStartTyr.MouseLeave += new System.EventHandler(this.ButtonStartTyr_MouseLeave);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackgroundImage = global::PortraitManager.Properties.Resources.icon_tyr1;
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox6.Location = new System.Drawing.Point(3, 3);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(55, 45);
            this.pictureBox6.TabIndex = 6;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.MouseEnter += new System.EventHandler(this.pictureBox6_MouseEnter);
            this.pictureBox6.MouseLeave += new System.EventHandler(this.pictureBox6_MouseLeave);
            // 
            // tableLayoutPanel19
            // 
            this.tableLayoutPanel19.ColumnCount = 2;
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.05102F));
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.94898F));
            this.tableLayoutPanel19.Controls.Add(this.ButtonStartWaste, 1, 0);
            this.tableLayoutPanel19.Controls.Add(this.pictureBox7, 0, 0);
            this.tableLayoutPanel19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel19.Location = new System.Drawing.Point(349, 385);
            this.tableLayoutPanel19.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.tableLayoutPanel19.Name = "tableLayoutPanel19";
            this.tableLayoutPanel19.RowCount = 1;
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel19.Size = new System.Drawing.Size(382, 51);
            this.tableLayoutPanel19.TabIndex = 13;
            // 
            // ButtonStartWaste
            // 
            this.ButtonStartWaste.BackColor = System.Drawing.Color.Black;
            this.ButtonStartWaste.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonStartWaste.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonStartWaste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonStartWaste.FlatAppearance.BorderSize = 0;
            this.ButtonStartWaste.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.ButtonStartWaste.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonStartWaste.ForeColor = System.Drawing.Color.White;
            this.ButtonStartWaste.Location = new System.Drawing.Point(57, 3);
            this.ButtonStartWaste.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.ButtonStartWaste.Name = "ButtonStartWaste";
            this.ButtonStartWaste.Size = new System.Drawing.Size(322, 45);
            this.ButtonStartWaste.TabIndex = 6;
            this.ButtonStartWaste.Text = "w3";
            this.ButtonStartWaste.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonStartWaste.UseVisualStyleBackColor = false;
            this.ButtonStartWaste.MouseEnter += new System.EventHandler(this.ButtonStartWaste_MouseEnter);
            this.ButtonStartWaste.MouseLeave += new System.EventHandler(this.ButtonStartWaste_MouseLeave);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackgroundImage = global::PortraitManager.Properties.Resources.icon_waste1;
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox7.Location = new System.Drawing.Point(3, 3);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(54, 45);
            this.pictureBox7.TabIndex = 7;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.MouseEnter += new System.EventHandler(this.pictureBox7_MouseEnter);
            this.pictureBox7.MouseLeave += new System.EventHandler(this.pictureBox7_MouseLeave);
            // 
            // tableLayoutPanel20
            // 
            this.tableLayoutPanel20.ColumnCount = 3;
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel20.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel20.Controls.Add(this.pictureBox8, 1, 0);
            this.tableLayoutPanel20.Controls.Add(this.pictureBox9, 2, 0);
            this.tableLayoutPanel20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel20.Location = new System.Drawing.Point(334, 442);
            this.tableLayoutPanel20.Margin = new System.Windows.Forms.Padding(25, 3, 3, 3);
            this.tableLayoutPanel20.Name = "tableLayoutPanel20";
            this.tableLayoutPanel20.RowCount = 1;
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel20.Size = new System.Drawing.Size(397, 36);
            this.tableLayoutPanel20.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(311, 36);
            this.label7.TabIndex = 0;
            this.label7.Text = "Portrait Manager 1.5\r\nArtemii \"Zeight\" Saganenko© 2024";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackgroundImage = global::PortraitManager.Properties.Resources.nm_logo;
            this.pictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox8.Location = new System.Drawing.Point(320, 3);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(33, 30);
            this.pictureBox8.TabIndex = 1;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.pictureBox8_Click);
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackgroundImage = global::PortraitManager.Properties.Resources.github_logo;
            this.pictureBox9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox9.Location = new System.Drawing.Point(359, 3);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(35, 30);
            this.pictureBox9.TabIndex = 2;
            this.pictureBox9.TabStop = false;
            this.pictureBox9.Click += new System.EventHandler(this.pictureBox9_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(734, 481);
            this.Controls.Add(this.LayoutStartMenu);
            this.Controls.Add(this.LayoutMainPage);
            this.Controls.Add(this.LayoutSettingsPage);
            this.Controls.Add(this.LayoutURLDialog);
            this.Controls.Add(this.LayoutScalePage);
            this.Controls.Add(this.LayoutFinalPage);
            this.Controls.Add(this.LayoutExtractPage);
            this.Controls.Add(this.LayoutGallery);
            this.Controls.Add(this.LayoutFilePage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
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
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
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
            this.LayoutUnnamed3.PerformLayout();
            this.LayoutUnnamed4.ResumeLayout(false);
            this.LayoutMainPage.ResumeLayout(false);
            this.LayoutMainPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxTitle)).EndInit();
            this.LayoutLang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxEng)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxRus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxGer)).EndInit();
            this.LayoutExtractPage.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.LayoutUnnamed10.ResumeLayout(false);
            this.LayoutUnnamed11.ResumeLayout(false);
            this.LayoutUnnamed11.PerformLayout();
            this.LayoutGallery.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.LayoutURLDialog.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.LayoutFinalPage.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
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
            this.LayoutStartMenu.ResumeLayout(false);
            this.tableLayoutPanel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tableLayoutPanel15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tableLayoutPanel16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.tableLayoutPanel17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.tableLayoutPanel18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.tableLayoutPanel19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.tableLayoutPanel20.ResumeLayout(false);
            this.tableLayoutPanel20.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
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
        private System.Windows.Forms.Label LblPointerToFilePage;
        private System.Windows.Forms.Label LblPointerToExtractPage;
        private System.Windows.Forms.Label LblPointerToGalleryPage;
        private System.Windows.Forms.Label LblToLoadLocal;
        private System.Windows.Forms.Label LblToLoadWeb;
        private System.Windows.Forms.Label LblToMainPage;
        private System.Windows.Forms.Label LblToScalePage;
        private System.Windows.Forms.Label LblToAdvancedPage;
        private System.Windows.Forms.Label LblToFilePage;
        private System.Windows.Forms.Label LblToCreatePortrait;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.Label LblToMenuPage;
        private System.Windows.Forms.Label LblToFilePage2;
        private System.Windows.Forms.Label LblToMenuPageAndOpenFIle;
        private System.Windows.Forms.Label LblToMainPage3;
        private System.Windows.Forms.Label LblToOpenFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblToFilePage3;
        private System.Windows.Forms.Label LblToLoadToFilePage;
        private System.Windows.Forms.TableLayoutPanel LayoutStartMenu;
        private System.Windows.Forms.Button ButtonStartKing;
        private System.Windows.Forms.Button ButtonStartWotr;
        private System.Windows.Forms.Button ButtonStartRt;
        private System.Windows.Forms.Button ButtonStartPoe;
        private System.Windows.Forms.Button ButtonStartPoed;
        private System.Windows.Forms.Button ButtonStartTyr;
        private System.Windows.Forms.Button ButtonStartWaste;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel16;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel17;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel18;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel19;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel20;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox9;
    }
}

