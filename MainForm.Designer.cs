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
            this.ImgListExtract = new System.Windows.Forms.ImageList(this.components);
            this.ImgListGallery = new System.Windows.Forms.ImageList(this.components);
            this.LayoutStartMenu = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonStartKing = new System.Windows.Forms.Button();
            this.PictureBoxStartKing = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonStartWotr = new System.Windows.Forms.Button();
            this.PictureBoxStartWotr = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonStartRt = new System.Windows.Forms.Button();
            this.PictureBoxStartRt = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonStartPoe = new System.Windows.Forms.Button();
            this.PictureBoxStartPoe = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonStartPoed = new System.Windows.Forms.Button();
            this.PictureBoxStartPoed = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonStartTyr = new System.Windows.Forms.Button();
            this.PictureBoxStartTyr = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel19 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonStartW3 = new System.Windows.Forms.Button();
            this.PictureBoxStartW3 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel20 = new System.Windows.Forms.TableLayoutPanel();
            this.LabelStartAuthor = new System.Windows.Forms.Label();
            this.PictureBoxStartOpenNM = new System.Windows.Forms.PictureBox();
            this.PictureBoxStartOpenGitHub = new System.Windows.Forms.PictureBox();
            this.LayoutPathPage = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel21 = new System.Windows.Forms.TableLayoutPanel();
            this.LabelSelectPathExplain = new System.Windows.Forms.Label();
            this.tableLayoutPanel22 = new System.Windows.Forms.TableLayoutPanel();
            this.LabelSelectPathResetPath = new System.Windows.Forms.Label();
            this.LabelSelectPathChoosePath = new System.Windows.Forms.Label();
            this.LabelSelectPathSelected = new System.Windows.Forms.Label();
            this.LabelSelectPathTitle = new System.Windows.Forms.Label();
            this.LabelSelectPathBackToStart = new System.Windows.Forms.Label();
            this.LabelSelectPathNextToMain = new System.Windows.Forms.Label();
            this.LayoutMainPage = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel23 = new System.Windows.Forms.TableLayoutPanel();
            this.LabelCreatePortrait = new System.Windows.Forms.Label();
            this.LabelExtract = new System.Windows.Forms.Label();
            this.LabelBrowse = new System.Windows.Forms.Label();
            this.LabelSettingsPage = new System.Windows.Forms.Label();
            this.LabelExit = new System.Windows.Forms.Label();
            this.LayoutKingCreatePortrait = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.LabelKingCreatePortraitLarge = new System.Windows.Forms.Label();
            this.LabelKingCreatePortraitMedium = new System.Windows.Forms.Label();
            this.LabelKingCreatePortraitSmall = new System.Windows.Forms.Label();
            this.LabelKingCreatePortraitSml2 = new System.Windows.Forms.Label();
            this.LayoutKingPortraitGroups = new System.Windows.Forms.TableLayoutPanel();
            this.LayoutKingPortraitGroupLarge = new System.Windows.Forms.TableLayoutPanel();
            this.PanelKingLrg = new System.Windows.Forms.Panel();
            this.PicKingLrg = new System.Windows.Forms.PictureBox();
            this.PanelKingLrgButtons = new System.Windows.Forms.TableLayoutPanel();
            this.LabelKingLrgHint = new System.Windows.Forms.Label();
            this.ButtonKingLrgLocal = new System.Windows.Forms.Button();
            this.ButtonKingLrgWeb = new System.Windows.Forms.Button();
            this.ButtonKingLrgZoomIn = new System.Windows.Forms.Button();
            this.ButtonKingLrgZoomOut = new System.Windows.Forms.Button();
            this.ButtonKingLrgZoomReset = new System.Windows.Forms.Button();
            this.LayoutKingPortraitGroupMedium = new System.Windows.Forms.TableLayoutPanel();
            this.PanelKingMed = new System.Windows.Forms.Panel();
            this.PicKingMed = new System.Windows.Forms.PictureBox();
            this.PanelKingMedButtons = new System.Windows.Forms.TableLayoutPanel();
            this.LabelKingMedHint = new System.Windows.Forms.Label();
            this.ButtonKingMedLocal = new System.Windows.Forms.Button();
            this.ButtonKingMedWeb = new System.Windows.Forms.Button();
            this.ButtonKingMedZoomIn = new System.Windows.Forms.Button();
            this.ButtonKingMedZoomOut = new System.Windows.Forms.Button();
            this.ButtonKingMedZoomReset = new System.Windows.Forms.Button();
            this.LayoutKingPortraitGroupSmall = new System.Windows.Forms.TableLayoutPanel();
            this.PanelKingSml = new System.Windows.Forms.Panel();
            this.PicKingSml = new System.Windows.Forms.PictureBox();
            this.PanelKingSmlButtons = new System.Windows.Forms.TableLayoutPanel();
            this.LabelKingSmlHint = new System.Windows.Forms.Label();
            this.ButtonKingSmlLocal = new System.Windows.Forms.Button();
            this.ButtonKingSmlWeb = new System.Windows.Forms.Button();
            this.ButtonKingSmlZoomIn = new System.Windows.Forms.Button();
            this.ButtonKingSmlZoomOut = new System.Windows.Forms.Button();
            this.ButtonKingSmlZoomReset = new System.Windows.Forms.Button();
            this.LayoutKingPortraitGroupSml2 = new System.Windows.Forms.TableLayoutPanel();
            this.PanelKingSml2 = new System.Windows.Forms.Panel();
            this.PicKingSml2 = new System.Windows.Forms.PictureBox();
            this.PanelKingSml2Buttons = new System.Windows.Forms.TableLayoutPanel();
            this.LabelKingSml2Hint = new System.Windows.Forms.Label();
            this.ButtonKingSml2Local = new System.Windows.Forms.Button();
            this.ButtonKingSml2Web = new System.Windows.Forms.Button();
            this.ButtonKingSml2ZoomIn = new System.Windows.Forms.Button();
            this.ButtonKingSml2ZoomOut = new System.Windows.Forms.Button();
            this.ButtonKingSml2ZoomReset = new System.Windows.Forms.Button();
            this.LayoutKingRight = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonKingCreateNewPortrait = new System.Windows.Forms.Button();
            this.ButtonKingBackToPathfinder = new System.Windows.Forms.Button();
            this.LabelKingGroupLargeTitle = new System.Windows.Forms.Label();
            this.LabelKingGroupMediumTitle = new System.Windows.Forms.Label();
            this.LabelKingGroupSmallTitle = new System.Windows.Forms.Label();
            this.LabelKingGroupSml2Title = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.FlowLayoutPanelExtract = new System.Windows.Forms.FlowLayoutPanel();
            this.PanelExtractOverlay = new System.Windows.Forms.Panel();
            this.PanelExtractContainer = new System.Windows.Forms.Panel();

            this.ButtonExtractAll = new System.Windows.Forms.Button();
            this.ButtonExtractSelected = new System.Windows.Forms.Button();
            this.ButtonExtractBack = new System.Windows.Forms.Button();
            this.ButtonExtractShowFolder = new System.Windows.Forms.Button();
            this.LayoutExtractRight = new System.Windows.Forms.TableLayoutPanel();
            this.LayoutExtractPage = new System.Windows.Forms.TableLayoutPanel();
            this.LayoutGalleryPage = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanelGalleryTabs = new System.Windows.Forms.FlowLayoutPanel();
            this.LabelGalleryTab = new System.Windows.Forms.Label();
            this.LabelExtractCounter = new System.Windows.Forms.Label();
            this.FlowLayoutPanelExtractBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.LabelExtractClearSelection = new System.Windows.Forms.Label();
            this.PanelGalleryContainer = new System.Windows.Forms.Panel();
            this.FlowLayoutPanelGallery = new System.Windows.Forms.FlowLayoutPanel();
            this.LayoutGalleryRight = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonGalleryBack = new System.Windows.Forms.Button();
            this.ButtonGalleryClone = new System.Windows.Forms.Button();
            this.ButtonGalleryChange = new System.Windows.Forms.Button();
            this.ButtonGalleryDelete = new System.Windows.Forms.Button();
            this.LayoutStartMenu.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxStartKing)).BeginInit();
            this.tableLayoutPanel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxStartWotr)).BeginInit();
            this.tableLayoutPanel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxStartRt)).BeginInit();
            this.tableLayoutPanel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxStartPoe)).BeginInit();
            this.tableLayoutPanel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxStartPoed)).BeginInit();
            this.tableLayoutPanel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxStartTyr)).BeginInit();
            this.tableLayoutPanel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxStartW3)).BeginInit();
            this.tableLayoutPanel20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxStartOpenNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxStartOpenGitHub)).BeginInit();
            this.LayoutPathPage.SuspendLayout();
            this.tableLayoutPanel21.SuspendLayout();
            this.tableLayoutPanel22.SuspendLayout();
            this.LayoutMainPage.SuspendLayout();
            this.tableLayoutPanel23.SuspendLayout();
            this.LayoutExtractPage.SuspendLayout();
            this.PanelExtractContainer.SuspendLayout();
            this.FlowLayoutPanelExtract.SuspendLayout();
            this.FlowLayoutPanelExtractBottom.SuspendLayout();
            this.PanelExtractOverlay.SuspendLayout();
            this.LayoutKingCreatePortrait.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.LayoutKingPortraitGroups.SuspendLayout();
            this.LayoutKingPortraitGroupLarge.SuspendLayout();
            this.PanelKingLrg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicKingLrg)).BeginInit();
            this.PanelKingLrgButtons.SuspendLayout();
            this.LayoutKingPortraitGroupMedium.SuspendLayout();
            this.PanelKingMed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicKingMed)).BeginInit();
            this.PanelKingMedButtons.SuspendLayout();
            this.LayoutKingPortraitGroupSmall.SuspendLayout();
            this.PanelKingSml.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicKingSml)).BeginInit();
            this.PanelKingSmlButtons.SuspendLayout();
            this.LayoutKingPortraitGroupSml2.SuspendLayout();
            this.PanelKingSml2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicKingSml2)).BeginInit();
            this.PanelKingSml2Buttons.SuspendLayout();
            this.LayoutKingRight.SuspendLayout();
            this.LayoutGalleryPage.SuspendLayout();
            this.flowLayoutPanelGalleryTabs.SuspendLayout();
            this.PanelGalleryContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImgListExtract
            // 
            this.ImgListExtract.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.ImgListExtract.ImageSize = new System.Drawing.Size(100, 148);
            this.ImgListExtract.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ImgListGallery
            // 
            this.ImgListGallery.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.ImgListGallery.ImageSize = new System.Drawing.Size(100, 148);
            this.ImgListGallery.TransparentColor = System.Drawing.Color.Empty;
            // 
            // LayoutStartMenu
            // 
            this.LayoutStartMenu.BackColor = System.Drawing.Color.Black;
            this.LayoutStartMenu.BackgroundImage = global::PortraitManager.Properties.Resources.path_start_page;
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
            this.LayoutStartMenu.Size = new System.Drawing.Size(1207, 766);
            this.LayoutStartMenu.TabIndex = 8;
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.ColumnCount = 2;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.33333F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.66666F));
            this.tableLayoutPanel13.Controls.Add(this.ButtonStartKing, 1, 0);
            this.tableLayoutPanel13.Controls.Add(this.PictureBoxStartKing, 0, 0);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(639, 43);
            this.tableLayoutPanel13.Margin = new System.Windows.Forms.Padding(130, 3, 3, 3);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 1;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(565, 91);
            this.tableLayoutPanel13.TabIndex = 7;
            // 
            // ButtonStartKing
            // 
            this.ButtonStartKing.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonStartKing.BackColor = System.Drawing.Color.Black;
            this.ButtonStartKing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonStartKing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonStartKing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonStartKing.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ButtonStartKing.FlatAppearance.BorderSize = 0;
            this.ButtonStartKing.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.ButtonStartKing.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.ButtonStartKing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonStartKing.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonStartKing.ForeColor = System.Drawing.Color.White;
            this.ButtonStartKing.Location = new System.Drawing.Point(109, 3);
            this.ButtonStartKing.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.ButtonStartKing.Name = "ButtonStartKing";
            this.ButtonStartKing.Size = new System.Drawing.Size(453, 85);
            this.ButtonStartKing.TabIndex = 0;
            this.ButtonStartKing.TabStop = false;
            this.ButtonStartKing.Text = "LABEL_KING";
            this.ButtonStartKing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonStartKing.UseVisualStyleBackColor = false;
            this.ButtonStartKing.Click += new System.EventHandler(this.ButtonStartKing_Click);
            this.ButtonStartKing.MouseEnter += new System.EventHandler(this.ButtonStartKing_MouseEnter);
            this.ButtonStartKing.MouseLeave += new System.EventHandler(this.ButtonStartKing_MouseLeave);
            // 
            // PictureBoxStartKing
            // 
            this.PictureBoxStartKing.BackgroundImage = global::PortraitManager.Properties.Resources.path_icon_png;
            this.PictureBoxStartKing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PictureBoxStartKing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBoxStartKing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBoxStartKing.Location = new System.Drawing.Point(3, 3);
            this.PictureBoxStartKing.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.PictureBoxStartKing.Name = "PictureBoxStartKing";
            this.PictureBoxStartKing.Size = new System.Drawing.Size(106, 85);
            this.PictureBoxStartKing.TabIndex = 1;
            this.PictureBoxStartKing.TabStop = false;
            this.PictureBoxStartKing.Click += new System.EventHandler(this.PictureBoxStartKing_Click);
            this.PictureBoxStartKing.MouseEnter += new System.EventHandler(this.PictureBoxStartKing_MouseEnter);
            this.PictureBoxStartKing.MouseLeave += new System.EventHandler(this.PictureBoxStartKing_MouseLeave);
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 2;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.09524F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.90476F));
            this.tableLayoutPanel14.Controls.Add(this.ButtonStartWotr, 1, 0);
            this.tableLayoutPanel14.Controls.Add(this.PictureBoxStartWotr, 0, 0);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(623, 140);
            this.tableLayoutPanel14.Margin = new System.Windows.Forms.Padding(114, 3, 3, 3);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 1;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(581, 91);
            this.tableLayoutPanel14.TabIndex = 8;
            // 
            // ButtonStartWotr
            // 
            this.ButtonStartWotr.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonStartWotr.BackColor = System.Drawing.Color.Black;
            this.ButtonStartWotr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonStartWotr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonStartWotr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonStartWotr.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ButtonStartWotr.FlatAppearance.BorderSize = 0;
            this.ButtonStartWotr.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.ButtonStartWotr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonStartWotr.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonStartWotr.ForeColor = System.Drawing.Color.White;
            this.ButtonStartWotr.Location = new System.Drawing.Point(105, 3);
            this.ButtonStartWotr.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.ButtonStartWotr.Name = "ButtonStartWotr";
            this.ButtonStartWotr.Size = new System.Drawing.Size(473, 85);
            this.ButtonStartWotr.TabIndex = 1;
            this.ButtonStartWotr.TabStop = false;
            this.ButtonStartWotr.Text = "LABEL_WOTR";
            this.ButtonStartWotr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonStartWotr.UseVisualStyleBackColor = false;
            this.ButtonStartWotr.Click += new System.EventHandler(this.ButtonStartWotr_Click);
            this.ButtonStartWotr.MouseEnter += new System.EventHandler(this.ButtonStartWotr_MouseEnter);
            this.ButtonStartWotr.MouseLeave += new System.EventHandler(this.ButtonStartWotr_MouseLeave);
            // 
            // PictureBoxStartWotr
            // 
            this.PictureBoxStartWotr.BackgroundImage = global::PortraitManager.Properties.Resources.wotr_icon_png;
            this.PictureBoxStartWotr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PictureBoxStartWotr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBoxStartWotr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBoxStartWotr.Location = new System.Drawing.Point(3, 3);
            this.PictureBoxStartWotr.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.PictureBoxStartWotr.Name = "PictureBoxStartWotr";
            this.PictureBoxStartWotr.Size = new System.Drawing.Size(102, 85);
            this.PictureBoxStartWotr.TabIndex = 2;
            this.PictureBoxStartWotr.TabStop = false;
            this.PictureBoxStartWotr.Click += new System.EventHandler(this.PictureBoxStartWotr_Click);
            this.PictureBoxStartWotr.MouseEnter += new System.EventHandler(this.PictureBoxStartWotr_MouseEnter);
            this.PictureBoxStartWotr.MouseLeave += new System.EventHandler(this.PictureBoxStartWotr_MouseLeave);
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.ColumnCount = 2;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.36364F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.63636F));
            this.tableLayoutPanel15.Controls.Add(this.ButtonStartRt, 1, 0);
            this.tableLayoutPanel15.Controls.Add(this.PictureBoxStartRt, 0, 0);
            this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel15.Location = new System.Drawing.Point(607, 237);
            this.tableLayoutPanel15.Margin = new System.Windows.Forms.Padding(98, 3, 3, 3);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 1;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(597, 91);
            this.tableLayoutPanel15.TabIndex = 9;
            // 
            // ButtonStartRt
            // 
            this.ButtonStartRt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonStartRt.BackColor = System.Drawing.Color.Black;
            this.ButtonStartRt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonStartRt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonStartRt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonStartRt.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ButtonStartRt.FlatAppearance.BorderSize = 0;
            this.ButtonStartRt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.ButtonStartRt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonStartRt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonStartRt.ForeColor = System.Drawing.Color.White;
            this.ButtonStartRt.Location = new System.Drawing.Point(97, 3);
            this.ButtonStartRt.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.ButtonStartRt.Name = "ButtonStartRt";
            this.ButtonStartRt.Size = new System.Drawing.Size(497, 85);
            this.ButtonStartRt.TabIndex = 2;
            this.ButtonStartRt.TabStop = false;
            this.ButtonStartRt.Text = "LABEL_RT";
            this.ButtonStartRt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonStartRt.UseVisualStyleBackColor = false;
            this.ButtonStartRt.Click += new System.EventHandler(this.ButtonStartRt_Click);
            this.ButtonStartRt.MouseEnter += new System.EventHandler(this.ButtonStartRt_MouseEnter);
            this.ButtonStartRt.MouseLeave += new System.EventHandler(this.ButtonStartRt_MouseLeave);
            // 
            // PictureBoxStartRt
            // 
            this.PictureBoxStartRt.BackgroundImage = global::PortraitManager.Properties.Resources.rt_icon_png;
            this.PictureBoxStartRt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PictureBoxStartRt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBoxStartRt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBoxStartRt.Location = new System.Drawing.Point(3, 3);
            this.PictureBoxStartRt.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.PictureBoxStartRt.Name = "PictureBoxStartRt";
            this.PictureBoxStartRt.Size = new System.Drawing.Size(94, 85);
            this.PictureBoxStartRt.TabIndex = 3;
            this.PictureBoxStartRt.TabStop = false;
            this.PictureBoxStartRt.Click += new System.EventHandler(this.PictureBoxStartRt_Click);
            this.PictureBoxStartRt.MouseEnter += new System.EventHandler(this.PictureBoxStartRt_MouseEnter);
            this.PictureBoxStartRt.MouseLeave += new System.EventHandler(this.PictureBoxStartRt_MouseLeave);
            // 
            // tableLayoutPanel16
            // 
            this.tableLayoutPanel16.ColumnCount = 2;
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.52174F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.47826F));
            this.tableLayoutPanel16.Controls.Add(this.ButtonStartPoe, 1, 0);
            this.tableLayoutPanel16.Controls.Add(this.PictureBoxStartPoe, 0, 0);
            this.tableLayoutPanel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel16.Location = new System.Drawing.Point(591, 334);
            this.tableLayoutPanel16.Margin = new System.Windows.Forms.Padding(82, 3, 3, 3);
            this.tableLayoutPanel16.Name = "tableLayoutPanel16";
            this.tableLayoutPanel16.RowCount = 1;
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel16.Size = new System.Drawing.Size(613, 91);
            this.tableLayoutPanel16.TabIndex = 10;
            // 
            // ButtonStartPoe
            // 
            this.ButtonStartPoe.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonStartPoe.BackColor = System.Drawing.Color.Black;
            this.ButtonStartPoe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonStartPoe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonStartPoe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonStartPoe.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ButtonStartPoe.FlatAppearance.BorderSize = 0;
            this.ButtonStartPoe.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.ButtonStartPoe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonStartPoe.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonStartPoe.ForeColor = System.Drawing.Color.White;
            this.ButtonStartPoe.Location = new System.Drawing.Point(101, 3);
            this.ButtonStartPoe.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.ButtonStartPoe.Name = "ButtonStartPoe";
            this.ButtonStartPoe.Size = new System.Drawing.Size(509, 85);
            this.ButtonStartPoe.TabIndex = 3;
            this.ButtonStartPoe.TabStop = false;
            this.ButtonStartPoe.Text = "LABEL_POE";
            this.ButtonStartPoe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonStartPoe.UseVisualStyleBackColor = false;
            this.ButtonStartPoe.Click += new System.EventHandler(this.ButtonStartPoe_Click);
            this.ButtonStartPoe.MouseEnter += new System.EventHandler(this.ButtonStartPoe_MouseEnter);
            this.ButtonStartPoe.MouseLeave += new System.EventHandler(this.ButtonStartPoe_MouseLeave);
            // 
            // PictureBoxStartPoe
            // 
            this.PictureBoxStartPoe.BackgroundImage = global::PortraitManager.Properties.Resources.poe_icon_png;
            this.PictureBoxStartPoe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PictureBoxStartPoe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBoxStartPoe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBoxStartPoe.Location = new System.Drawing.Point(3, 3);
            this.PictureBoxStartPoe.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.PictureBoxStartPoe.Name = "PictureBoxStartPoe";
            this.PictureBoxStartPoe.Size = new System.Drawing.Size(98, 85);
            this.PictureBoxStartPoe.TabIndex = 4;
            this.PictureBoxStartPoe.TabStop = false;
            this.PictureBoxStartPoe.Click += new System.EventHandler(this.PictureBoxStartPoe_Click);
            this.PictureBoxStartPoe.MouseEnter += new System.EventHandler(this.PictureBoxStartPoe_MouseEnter);
            this.PictureBoxStartPoe.MouseLeave += new System.EventHandler(this.PictureBoxStartPoe_MouseLeave);
            // 
            // tableLayoutPanel17
            // 
            this.tableLayoutPanel17.ColumnCount = 2;
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.32033F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.67966F));
            this.tableLayoutPanel17.Controls.Add(this.ButtonStartPoed, 1, 0);
            this.tableLayoutPanel17.Controls.Add(this.PictureBoxStartPoed, 0, 0);
            this.tableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel17.Location = new System.Drawing.Point(575, 431);
            this.tableLayoutPanel17.Margin = new System.Windows.Forms.Padding(66, 3, 3, 3);
            this.tableLayoutPanel17.Name = "tableLayoutPanel17";
            this.tableLayoutPanel17.RowCount = 1;
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel17.Size = new System.Drawing.Size(629, 91);
            this.tableLayoutPanel17.TabIndex = 11;
            // 
            // ButtonStartPoed
            // 
            this.ButtonStartPoed.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonStartPoed.BackColor = System.Drawing.Color.Black;
            this.ButtonStartPoed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonStartPoed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonStartPoed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonStartPoed.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ButtonStartPoed.FlatAppearance.BorderSize = 0;
            this.ButtonStartPoed.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.ButtonStartPoed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonStartPoed.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonStartPoed.ForeColor = System.Drawing.Color.White;
            this.ButtonStartPoed.Location = new System.Drawing.Point(96, 3);
            this.ButtonStartPoed.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.ButtonStartPoed.Name = "ButtonStartPoed";
            this.ButtonStartPoed.Size = new System.Drawing.Size(530, 85);
            this.ButtonStartPoed.TabIndex = 4;
            this.ButtonStartPoed.TabStop = false;
            this.ButtonStartPoed.Text = "LABEL_POED";
            this.ButtonStartPoed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonStartPoed.UseVisualStyleBackColor = false;
            this.ButtonStartPoed.Click += new System.EventHandler(this.ButtonStartPoed_Click);
            this.ButtonStartPoed.MouseEnter += new System.EventHandler(this.ButtonStartPoed_MouseEnter);
            this.ButtonStartPoed.MouseLeave += new System.EventHandler(this.ButtonStartPoed_MouseLeave);
            // 
            // PictureBoxStartPoed
            // 
            this.PictureBoxStartPoed.BackgroundImage = global::PortraitManager.Properties.Resources.poed_icon_png;
            this.PictureBoxStartPoed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PictureBoxStartPoed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBoxStartPoed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBoxStartPoed.Location = new System.Drawing.Point(3, 3);
            this.PictureBoxStartPoed.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.PictureBoxStartPoed.Name = "PictureBoxStartPoed";
            this.PictureBoxStartPoed.Size = new System.Drawing.Size(93, 85);
            this.PictureBoxStartPoed.TabIndex = 5;
            this.PictureBoxStartPoed.TabStop = false;
            this.PictureBoxStartPoed.Click += new System.EventHandler(this.PictureBoxStartPoed_Click);
            this.PictureBoxStartPoed.MouseEnter += new System.EventHandler(this.PictureBoxStartPoed_MouseEnter);
            this.PictureBoxStartPoed.MouseLeave += new System.EventHandler(this.PictureBoxStartPoed_MouseLeave);
            // 
            // tableLayoutPanel18
            // 
            this.tableLayoutPanel18.ColumnCount = 2;
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.87302F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.12698F));
            this.tableLayoutPanel18.Controls.Add(this.ButtonStartTyr, 1, 0);
            this.tableLayoutPanel18.Controls.Add(this.PictureBoxStartTyr, 0, 0);
            this.tableLayoutPanel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel18.Location = new System.Drawing.Point(559, 528);
            this.tableLayoutPanel18.Margin = new System.Windows.Forms.Padding(50, 3, 3, 3);
            this.tableLayoutPanel18.Name = "tableLayoutPanel18";
            this.tableLayoutPanel18.RowCount = 1;
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel18.Size = new System.Drawing.Size(645, 91);
            this.tableLayoutPanel18.TabIndex = 12;
            // 
            // ButtonStartTyr
            // 
            this.ButtonStartTyr.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonStartTyr.BackColor = System.Drawing.Color.Black;
            this.ButtonStartTyr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonStartTyr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonStartTyr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonStartTyr.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ButtonStartTyr.FlatAppearance.BorderSize = 0;
            this.ButtonStartTyr.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.ButtonStartTyr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonStartTyr.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonStartTyr.ForeColor = System.Drawing.Color.White;
            this.ButtonStartTyr.Location = new System.Drawing.Point(102, 3);
            this.ButtonStartTyr.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.ButtonStartTyr.Name = "ButtonStartTyr";
            this.ButtonStartTyr.Size = new System.Drawing.Size(540, 85);
            this.ButtonStartTyr.TabIndex = 5;
            this.ButtonStartTyr.TabStop = false;
            this.ButtonStartTyr.Text = "LABEL_TYR";
            this.ButtonStartTyr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonStartTyr.UseVisualStyleBackColor = false;
            this.ButtonStartTyr.Click += new System.EventHandler(this.ButtonStartTyr_Click);
            this.ButtonStartTyr.MouseEnter += new System.EventHandler(this.ButtonStartTyr_MouseEnter);
            this.ButtonStartTyr.MouseLeave += new System.EventHandler(this.ButtonStartTyr_MouseLeave);
            // 
            // PictureBoxStartTyr
            // 
            this.PictureBoxStartTyr.BackgroundImage = global::PortraitManager.Properties.Resources.tyr_icon_png;
            this.PictureBoxStartTyr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PictureBoxStartTyr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBoxStartTyr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBoxStartTyr.Location = new System.Drawing.Point(3, 3);
            this.PictureBoxStartTyr.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.PictureBoxStartTyr.Name = "PictureBoxStartTyr";
            this.PictureBoxStartTyr.Size = new System.Drawing.Size(99, 85);
            this.PictureBoxStartTyr.TabIndex = 6;
            this.PictureBoxStartTyr.TabStop = false;
            this.PictureBoxStartTyr.Click += new System.EventHandler(this.PictureBoxStartTyr_Click);
            this.PictureBoxStartTyr.MouseEnter += new System.EventHandler(this.PictureBoxStartTyr_MouseEnter);
            this.PictureBoxStartTyr.MouseLeave += new System.EventHandler(this.PictureBoxStartTyr_MouseLeave);
            // 
            // tableLayoutPanel19
            // 
            this.tableLayoutPanel19.ColumnCount = 2;
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.05102F));
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.94898F));
            this.tableLayoutPanel19.Controls.Add(this.ButtonStartW3, 1, 0);
            this.tableLayoutPanel19.Controls.Add(this.PictureBoxStartW3, 0, 0);
            this.tableLayoutPanel19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel19.Location = new System.Drawing.Point(543, 625);
            this.tableLayoutPanel19.Margin = new System.Windows.Forms.Padding(34, 3, 3, 3);
            this.tableLayoutPanel19.Name = "tableLayoutPanel19";
            this.tableLayoutPanel19.RowCount = 1;
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel19.Size = new System.Drawing.Size(661, 91);
            this.tableLayoutPanel19.TabIndex = 13;
            // 
            // ButtonStartW3
            // 
            this.ButtonStartW3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonStartW3.BackColor = System.Drawing.Color.Black;
            this.ButtonStartW3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonStartW3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonStartW3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonStartW3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ButtonStartW3.FlatAppearance.BorderSize = 0;
            this.ButtonStartW3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.ButtonStartW3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonStartW3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonStartW3.ForeColor = System.Drawing.Color.White;
            this.ButtonStartW3.Location = new System.Drawing.Point(99, 3);
            this.ButtonStartW3.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.ButtonStartW3.Name = "ButtonStartW3";
            this.ButtonStartW3.Size = new System.Drawing.Size(559, 85);
            this.ButtonStartW3.TabIndex = 6;
            this.ButtonStartW3.TabStop = false;
            this.ButtonStartW3.Text = "LABEL_W3";
            this.ButtonStartW3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonStartW3.UseVisualStyleBackColor = false;
            this.ButtonStartW3.Click += new System.EventHandler(this.ButtonStartWaste_Click);
            this.ButtonStartW3.MouseEnter += new System.EventHandler(this.ButtonStartW3_MouseEnter);
            this.ButtonStartW3.MouseLeave += new System.EventHandler(this.ButtonStartW3_MouseLeave);
            // 
            // PictureBoxStartW3
            // 
            this.PictureBoxStartW3.BackgroundImage = global::PortraitManager.Properties.Resources.waste_icon_png;
            this.PictureBoxStartW3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PictureBoxStartW3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBoxStartW3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBoxStartW3.Location = new System.Drawing.Point(3, 3);
            this.PictureBoxStartW3.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.PictureBoxStartW3.Name = "PictureBoxStartW3";
            this.PictureBoxStartW3.Size = new System.Drawing.Size(96, 85);
            this.PictureBoxStartW3.TabIndex = 7;
            this.PictureBoxStartW3.TabStop = false;
            this.PictureBoxStartW3.Click += new System.EventHandler(this.PictureBoxStartWaste_Click);
            this.PictureBoxStartW3.MouseEnter += new System.EventHandler(this.PictureBoxStartW3_MouseEnter);
            this.PictureBoxStartW3.MouseLeave += new System.EventHandler(this.PictureBoxStartW3_MouseLeave);
            // 
            // tableLayoutPanel20
            // 
            this.tableLayoutPanel20.ColumnCount = 3;
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel20.Controls.Add(this.LabelStartAuthor, 0, 0);
            this.tableLayoutPanel20.Controls.Add(this.PictureBoxStartOpenNM, 1, 0);
            this.tableLayoutPanel20.Controls.Add(this.PictureBoxStartOpenGitHub, 2, 0);
            this.tableLayoutPanel20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel20.Location = new System.Drawing.Point(534, 722);
            this.tableLayoutPanel20.Margin = new System.Windows.Forms.Padding(25, 3, 3, 3);
            this.tableLayoutPanel20.Name = "tableLayoutPanel20";
            this.tableLayoutPanel20.RowCount = 1;
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel20.Size = new System.Drawing.Size(670, 41);
            this.tableLayoutPanel20.TabIndex = 14;
            // 
            // LabelStartAuthor
            // 
            this.LabelStartAuthor.AutoSize = true;
            this.LabelStartAuthor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelStartAuthor.ForeColor = System.Drawing.Color.White;
            this.LabelStartAuthor.Location = new System.Drawing.Point(0, 0);
            this.LabelStartAuthor.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.LabelStartAuthor.Name = "LabelStartAuthor";
            this.LabelStartAuthor.Size = new System.Drawing.Size(533, 41);
            this.LabelStartAuthor.TabIndex = 0;
            this.LabelStartAuthor.Text = "LABEL_AUTHOR";
            this.LabelStartAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PictureBoxStartOpenNM
            // 
            this.PictureBoxStartOpenNM.BackgroundImage = global::PortraitManager.Properties.Resources.nm_logo_png;
            this.PictureBoxStartOpenNM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PictureBoxStartOpenNM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBoxStartOpenNM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBoxStartOpenNM.Location = new System.Drawing.Point(539, 3);
            this.PictureBoxStartOpenNM.Name = "PictureBoxStartOpenNM";
            this.PictureBoxStartOpenNM.Size = new System.Drawing.Size(61, 35);
            this.PictureBoxStartOpenNM.TabIndex = 1;
            this.PictureBoxStartOpenNM.TabStop = false;
            this.PictureBoxStartOpenNM.Click += new System.EventHandler(this.PictureBoxStartOpenNexus_Click);
            // 
            // PictureBoxStartOpenGitHub
            // 
            this.PictureBoxStartOpenGitHub.BackgroundImage = global::PortraitManager.Properties.Resources.github_logo_png;
            this.PictureBoxStartOpenGitHub.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PictureBoxStartOpenGitHub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBoxStartOpenGitHub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBoxStartOpenGitHub.Location = new System.Drawing.Point(606, 3);
            this.PictureBoxStartOpenGitHub.Name = "PictureBoxStartOpenGitHub";
            this.PictureBoxStartOpenGitHub.Size = new System.Drawing.Size(61, 35);
            this.PictureBoxStartOpenGitHub.TabIndex = 2;
            this.PictureBoxStartOpenGitHub.TabStop = false;
            this.PictureBoxStartOpenGitHub.Click += new System.EventHandler(this.PictureBoxStartOpenGithub_Click);
            // 
            // LayoutPathPage
            // 
            this.LayoutPathPage.BackColor = System.Drawing.Color.Black;
            this.LayoutPathPage.BackgroundImage = global::PortraitManager.Properties.Resources.path_folder_page;
            this.LayoutPathPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.LayoutPathPage.ColumnCount = 5;
            this.LayoutPathPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.LayoutPathPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.LayoutPathPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 380F));
            this.LayoutPathPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.LayoutPathPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.LayoutPathPage.Controls.Add(this.tableLayoutPanel21, 2, 1);
            this.LayoutPathPage.Controls.Add(this.LabelSelectPathBackToStart, 1, 1);
            this.LayoutPathPage.Controls.Add(this.LabelSelectPathNextToMain, 3, 1);
            this.LayoutPathPage.Location = new System.Drawing.Point(0, 0);
            this.LayoutPathPage.Name = "LayoutPathPage";
            this.LayoutPathPage.RowCount = 3;
            this.LayoutPathPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.LayoutPathPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPathPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.LayoutPathPage.Size = new System.Drawing.Size(1207, 766);
            this.LayoutPathPage.TabIndex = 9;
            this.LayoutPathPage.Paint += new System.Windows.Forms.PaintEventHandler(this.LayoutPathPage_Paint);
            // 
            // tableLayoutPanel21
            // 
            this.tableLayoutPanel21.ColumnCount = 1;
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel21.Controls.Add(this.LabelSelectPathExplain, 0, 3);
            this.tableLayoutPanel21.Controls.Add(this.tableLayoutPanel22, 0, 2);
            this.tableLayoutPanel21.Controls.Add(this.LabelSelectPathSelected, 0, 1);
            this.tableLayoutPanel21.Controls.Add(this.LabelSelectPathTitle, 0, 0);
            this.tableLayoutPanel21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel21.Location = new System.Drawing.Point(78, 43);
            this.tableLayoutPanel21.Name = "tableLayoutPanel21";
            this.tableLayoutPanel21.RowCount = 4;
            this.tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62F));
            this.tableLayoutPanel21.Size = new System.Drawing.Size(374, 680);
            this.tableLayoutPanel21.TabIndex = 0;
            // 
            // LabelSelectPathExplain
            // 
            this.LabelSelectPathExplain.AutoSize = true;
            this.LabelSelectPathExplain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelSelectPathExplain.ForeColor = System.Drawing.Color.White;
            this.LabelSelectPathExplain.Location = new System.Drawing.Point(3, 311);
            this.LabelSelectPathExplain.Name = "LabelSelectPathExplain";
            this.LabelSelectPathExplain.Size = new System.Drawing.Size(368, 369);
            this.LabelSelectPathExplain.TabIndex = 3;
            this.LabelSelectPathExplain.Text = "LABEL_PATH_EXPLAIN";
            this.LabelSelectPathExplain.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel22
            // 
            this.tableLayoutPanel22.ColumnCount = 2;
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel22.Controls.Add(this.LabelSelectPathResetPath, 0, 0);
            this.tableLayoutPanel22.Controls.Add(this.LabelSelectPathChoosePath, 1, 0);
            this.tableLayoutPanel22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel22.Location = new System.Drawing.Point(3, 274);
            this.tableLayoutPanel22.Name = "tableLayoutPanel22";
            this.tableLayoutPanel22.RowCount = 1;
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel22.Size = new System.Drawing.Size(368, 34);
            this.tableLayoutPanel22.TabIndex = 1;
            // 
            // LabelSelectPathResetPath
            // 
            this.LabelSelectPathResetPath.AutoSize = true;
            this.LabelSelectPathResetPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LabelSelectPathResetPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelSelectPathResetPath.ForeColor = System.Drawing.Color.White;
            this.LabelSelectPathResetPath.Location = new System.Drawing.Point(65, 0);
            this.LabelSelectPathResetPath.Margin = new System.Windows.Forms.Padding(65, 0, 3, 0);
            this.LabelSelectPathResetPath.Name = "LabelSelectPathResetPath";
            this.LabelSelectPathResetPath.Size = new System.Drawing.Size(116, 34);
            this.LabelSelectPathResetPath.TabIndex = 0;
            this.LabelSelectPathResetPath.Text = "LABEL_RESET";
            this.LabelSelectPathResetPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelSelectPathResetPath.Click += new System.EventHandler(this.LabelSelectPathResetPath_Click);
            this.LabelSelectPathResetPath.MouseEnter += new System.EventHandler(this.LabelSelectPathResetPath_MouseEnter);
            this.LabelSelectPathResetPath.MouseLeave += new System.EventHandler(this.LabelSelectPathResetPath_MouseLeave);
            // 
            // LabelSelectPathChoosePath
            // 
            this.LabelSelectPathChoosePath.AutoSize = true;
            this.LabelSelectPathChoosePath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LabelSelectPathChoosePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelSelectPathChoosePath.ForeColor = System.Drawing.Color.White;
            this.LabelSelectPathChoosePath.Location = new System.Drawing.Point(187, 0);
            this.LabelSelectPathChoosePath.Margin = new System.Windows.Forms.Padding(3, 0, 65, 0);
            this.LabelSelectPathChoosePath.Name = "LabelSelectPathChoosePath";
            this.LabelSelectPathChoosePath.Size = new System.Drawing.Size(116, 34);
            this.LabelSelectPathChoosePath.TabIndex = 1;
            this.LabelSelectPathChoosePath.Text = "LABEL_SELECT";
            this.LabelSelectPathChoosePath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelSelectPathChoosePath.Click += new System.EventHandler(this.LabelSelectPathChoosePath_Click);
            this.LabelSelectPathChoosePath.MouseEnter += new System.EventHandler(this.LabelSelectPathChoosePath_MouseEnter);
            this.LabelSelectPathChoosePath.MouseLeave += new System.EventHandler(this.LabelSelectPathChoosePath_MouseLeave);
            // 
            // LabelSelectPathSelected
            // 
            this.LabelSelectPathSelected.AutoSize = true;
            this.LabelSelectPathSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelSelectPathSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelSelectPathSelected.ForeColor = System.Drawing.Color.DarkGray;
            this.LabelSelectPathSelected.Location = new System.Drawing.Point(3, 226);
            this.LabelSelectPathSelected.Name = "LabelSelectPathSelected";
            this.LabelSelectPathSelected.Size = new System.Drawing.Size(368, 45);
            this.LabelSelectPathSelected.TabIndex = 4;
            this.LabelSelectPathSelected.Text = "LABEL_PATH_URL_NORMAL\r\nLABEL_PATH_URL_NORMAL";
            this.LabelSelectPathSelected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelSelectPathSelected.MouseEnter += new System.EventHandler(this.LabelSelectPathSelected_MouseEnter);
            this.LabelSelectPathSelected.MouseLeave += new System.EventHandler(this.LabelSelectPathSelected_MouseLeave);
            // 
            // LabelSelectPathTitle
            // 
            this.LabelSelectPathTitle.AutoSize = true;
            this.LabelSelectPathTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LabelSelectPathTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LabelSelectPathTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelSelectPathTitle.ForeColor = System.Drawing.Color.White;
            this.LabelSelectPathTitle.Location = new System.Drawing.Point(0, 197);
            this.LabelSelectPathTitle.Margin = new System.Windows.Forms.Padding(0);
            this.LabelSelectPathTitle.Name = "LabelSelectPathTitle";
            this.LabelSelectPathTitle.Size = new System.Drawing.Size(374, 29);
            this.LabelSelectPathTitle.TabIndex = 2;
            this.LabelSelectPathTitle.Text = "LABEL_[GAMETITLE_FULL]";
            this.LabelSelectPathTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelSelectPathTitle.MouseEnter += new System.EventHandler(this.LabelSelectPathTitle_MouseEnter);
            this.LabelSelectPathTitle.MouseLeave += new System.EventHandler(this.LabelSelectPathTitle_MouseLeave);
            // 
            // LabelSelectPathBackToStart
            // 
            this.LabelSelectPathBackToStart.AutoSize = true;
            this.LabelSelectPathBackToStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LabelSelectPathBackToStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelSelectPathBackToStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelSelectPathBackToStart.ForeColor = System.Drawing.Color.White;
            this.LabelSelectPathBackToStart.Location = new System.Drawing.Point(15, 180);
            this.LabelSelectPathBackToStart.Margin = new System.Windows.Forms.Padding(5, 140, 5, 190);
            this.LabelSelectPathBackToStart.Name = "LabelSelectPathBackToStart";
            this.LabelSelectPathBackToStart.Size = new System.Drawing.Size(55, 356);
            this.LabelSelectPathBackToStart.TabIndex = 3;
            this.LabelSelectPathBackToStart.Text = "❮";
            this.LabelSelectPathBackToStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelSelectPathBackToStart.Click += new System.EventHandler(this.LabelSelectPathBackToStart_Click);
            this.LabelSelectPathBackToStart.MouseEnter += new System.EventHandler(this.LabelSelectPathBackToStart_MouseEnter);
            this.LabelSelectPathBackToStart.MouseLeave += new System.EventHandler(this.LabelSelectPathBackToStart_MouseLeave);
            // 
            // LabelSelectPathNextToMain
            // 
            this.LabelSelectPathNextToMain.AutoSize = true;
            this.LabelSelectPathNextToMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LabelSelectPathNextToMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelSelectPathNextToMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelSelectPathNextToMain.ForeColor = System.Drawing.Color.White;
            this.LabelSelectPathNextToMain.Location = new System.Drawing.Point(460, 180);
            this.LabelSelectPathNextToMain.Margin = new System.Windows.Forms.Padding(5, 140, 5, 190);
            this.LabelSelectPathNextToMain.Name = "LabelSelectPathNextToMain";
            this.LabelSelectPathNextToMain.Size = new System.Drawing.Size(55, 356);
            this.LabelSelectPathNextToMain.TabIndex = 4;
            this.LabelSelectPathNextToMain.Text = "❯";
            this.LabelSelectPathNextToMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelSelectPathNextToMain.Click += new System.EventHandler(this.LabelSelectPathNextToMain_Click);
            this.LabelSelectPathNextToMain.MouseEnter += new System.EventHandler(this.LabelSelectPathNextToMain_MouseEnter);
            this.LabelSelectPathNextToMain.MouseLeave += new System.EventHandler(this.LabelSelectPathNextToMain_MouseLeave);
            // 
            // LayoutMainPage
            // 
            this.LayoutMainPage.BackgroundImage = global::PortraitManager.Properties.Resources.path_menu_page;
            this.LayoutMainPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LayoutMainPage.ColumnCount = 3;
            this.LayoutMainPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.LayoutMainPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.LayoutMainPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.LayoutMainPage.Controls.Add(this.tableLayoutPanel23, 1, 1);
            this.LayoutMainPage.Location = new System.Drawing.Point(0, 0);
            this.LayoutMainPage.Name = "LayoutMainPage";
            this.LayoutMainPage.RowCount = 3;
            this.LayoutMainPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.LayoutMainPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.LayoutMainPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.LayoutMainPage.Size = new System.Drawing.Size(1207, 766);
            this.LayoutMainPage.TabIndex = 10;
            // 
            // tableLayoutPanel23
            // 
            this.tableLayoutPanel23.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel23.ColumnCount = 1;
            this.tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel23.Controls.Add(this.LabelCreatePortrait, 0, 1);
            this.tableLayoutPanel23.Controls.Add(this.LabelExtract, 0, 2);
            this.tableLayoutPanel23.Controls.Add(this.LabelBrowse, 0, 3);
            this.tableLayoutPanel23.Controls.Add(this.LabelSettingsPage, 0, 4);
            this.tableLayoutPanel23.Controls.Add(this.LabelExit, 0, 5);
            this.tableLayoutPanel23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel23.Location = new System.Drawing.Point(15, 41);
            this.tableLayoutPanel23.Name = "tableLayoutPanel23";
            this.tableLayoutPanel23.RowCount = 7;
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.tableLayoutPanel23.Size = new System.Drawing.Size(657, 683);
            this.tableLayoutPanel23.TabIndex = 0;
            // 
            // LabelCreatePortrait
            // 
            this.LabelCreatePortrait.AutoSize = true;
            this.LabelCreatePortrait.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LabelCreatePortrait.ForeColor = System.Drawing.Color.White;
            this.LabelCreatePortrait.Location = new System.Drawing.Point(3, 239);
            this.LabelCreatePortrait.Name = "LabelCreatePortrait";
            this.LabelCreatePortrait.Size = new System.Drawing.Size(101, 13);
            this.LabelCreatePortrait.TabIndex = 0;
            this.LabelCreatePortrait.Text = "BUTTON_CREATE";
            this.LabelCreatePortrait.Click += new System.EventHandler(this.LabelCreatePortrait_Click);
            this.LabelCreatePortrait.MouseEnter += new System.EventHandler(this.LabelCreatePortrait_MouseEnter);
            this.LabelCreatePortrait.MouseLeave += new System.EventHandler(this.LabelCreatePortrait_MouseLeave);
            // 
            // LabelExtract
            // 
            this.LabelExtract.AutoSize = true;
            this.LabelExtract.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LabelExtract.ForeColor = System.Drawing.Color.White;
            this.LabelExtract.Location = new System.Drawing.Point(3, 334);
            this.LabelExtract.Name = "LabelExtract";
            this.LabelExtract.Size = new System.Drawing.Size(108, 13);
            this.LabelExtract.TabIndex = 1;
            this.LabelExtract.Text = "BUTTON_EXTRACT";
            this.LabelExtract.Click += new System.EventHandler(this.LabelExtract_Click);
            this.LabelExtract.MouseEnter += new System.EventHandler(this.LabelExtract_MouseEnter);
            this.LabelExtract.MouseLeave += new System.EventHandler(this.LabelExtract_MouseLeave);
            // 
            // LabelBrowse
            // 
            this.LabelBrowse.AutoSize = true;
            this.LabelBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LabelBrowse.ForeColor = System.Drawing.Color.White;
            this.LabelBrowse.Location = new System.Drawing.Point(3, 402);
            this.LabelBrowse.Name = "LabelBrowse";
            this.LabelBrowse.Size = new System.Drawing.Size(106, 13);
            this.LabelBrowse.TabIndex = 2;
            this.LabelBrowse.Text = "BUTTON_BROWSE";
            this.LabelBrowse.Click += new System.EventHandler(this.LabelBrowse_Click);
            this.LabelBrowse.MouseEnter += new System.EventHandler(this.LabelBrowse_MouseEnter);
            this.LabelBrowse.MouseLeave += new System.EventHandler(this.LabelBrowse_MouseLeave);
            // 
            // LabelSettingsPage
            // 
            this.LabelSettingsPage.AutoSize = true;
            this.LabelSettingsPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LabelSettingsPage.ForeColor = System.Drawing.Color.White;
            this.LabelSettingsPage.Location = new System.Drawing.Point(3, 470);
            this.LabelSettingsPage.Name = "LabelSettingsPage";
            this.LabelSettingsPage.Size = new System.Drawing.Size(112, 13);
            this.LabelSettingsPage.TabIndex = 3;
            this.LabelSettingsPage.Text = "BUTTON_SETTINGS";
            this.LabelSettingsPage.Click += new System.EventHandler(this.LabelSettingsPage_Click);
            this.LabelSettingsPage.MouseEnter += new System.EventHandler(this.LabelSettingsPage_MouseEnter);
            this.LabelSettingsPage.MouseLeave += new System.EventHandler(this.LabelSettingsPage_MouseLeave);
            // 
            // LabelExit
            // 
            this.LabelExit.AutoSize = true;
            this.LabelExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LabelExit.ForeColor = System.Drawing.Color.White;
            this.LabelExit.Location = new System.Drawing.Point(3, 538);
            this.LabelExit.Name = "LabelExit";
            this.LabelExit.Size = new System.Drawing.Size(82, 13);
            this.LabelExit.TabIndex = 4;
            this.LabelExit.Text = "BUTTON_EXIT";
            this.LabelExit.Click += new System.EventHandler(this.LabelExit_Click);
            this.LabelExit.MouseEnter += new System.EventHandler(this.LabelExit_MouseEnter);
            this.LabelExit.MouseLeave += new System.EventHandler(this.LabelExit_MouseLeave);
            // 
            // LayoutKingCreatePortrait
            // 
            this.LayoutKingCreatePortrait.BackColor = System.Drawing.Color.Black;
            this.LayoutKingCreatePortrait.ColumnCount = 4;
            this.LayoutKingCreatePortrait.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.LayoutKingCreatePortrait.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.LayoutKingCreatePortrait.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.LayoutKingCreatePortrait.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.LayoutKingCreatePortrait.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.LayoutKingCreatePortrait.Controls.Add(this.LayoutKingPortraitGroups, 1, 2);
            this.LayoutKingCreatePortrait.Controls.Add(this.LayoutKingRight, 2, 2);
            this.LayoutKingCreatePortrait.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutKingCreatePortrait.Location = new System.Drawing.Point(0, 0);
            this.LayoutKingCreatePortrait.Name = "LayoutKingCreatePortrait";
            this.LayoutKingCreatePortrait.RowCount = 4;
            this.LayoutKingCreatePortrait.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.LayoutKingCreatePortrait.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.LayoutKingCreatePortrait.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84F));
            this.LayoutKingCreatePortrait.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.LayoutKingCreatePortrait.Size = new System.Drawing.Size(734, 481);
            this.LayoutKingCreatePortrait.TabIndex = 11;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.LabelKingCreatePortraitLarge);
            this.flowLayoutPanel1.Controls.Add(this.LabelKingCreatePortraitMedium);
            this.flowLayoutPanel1.Controls.Add(this.LabelKingCreatePortraitSmall);
            this.flowLayoutPanel1.Controls.Add(this.LabelKingCreatePortraitSml2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(36, 9);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(513, 43);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // LabelKingCreatePortraitLarge
            // 
            this.LabelKingCreatePortraitLarge.AutoSize = true;
            this.LabelKingCreatePortraitLarge.BackColor = System.Drawing.Color.Transparent;
            this.LabelKingCreatePortraitLarge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LabelKingCreatePortraitLarge.ForeColor = System.Drawing.Color.White;
            this.LabelKingCreatePortraitLarge.Location = new System.Drawing.Point(0, 0);
            this.LabelKingCreatePortraitLarge.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.LabelKingCreatePortraitLarge.Name = "LabelKingCreatePortraitLarge";
            this.LabelKingCreatePortraitLarge.Padding = new System.Windows.Forms.Padding(15, 5, 15, 30);
            this.LabelKingCreatePortraitLarge.Size = new System.Drawing.Size(124, 48);
            this.LabelKingCreatePortraitLarge.TabIndex = 0;
            this.LabelKingCreatePortraitLarge.Text = "LABEL_KINGLRG";
            this.LabelKingCreatePortraitLarge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelKingCreatePortraitLarge.Click += new System.EventHandler(this.LabelKingCreatePortraitLarge_Click);
            this.LabelKingCreatePortraitLarge.Paint += new System.Windows.Forms.PaintEventHandler(this.LabelKingCreatePortrait_Paint);
            this.LabelKingCreatePortraitLarge.MouseEnter += new System.EventHandler(this.LabelKingCreatePortraitLarge_MouseEnter);
            this.LabelKingCreatePortraitLarge.MouseLeave += new System.EventHandler(this.LabelKingCreatePortraitLarge_MouseLeave);
            // 
            // LabelKingCreatePortraitMedium
            // 
            this.LabelKingCreatePortraitMedium.AutoSize = true;
            this.LabelKingCreatePortraitMedium.BackColor = System.Drawing.Color.Transparent;
            this.LabelKingCreatePortraitMedium.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LabelKingCreatePortraitMedium.ForeColor = System.Drawing.Color.White;
            this.LabelKingCreatePortraitMedium.Location = new System.Drawing.Point(130, 0);
            this.LabelKingCreatePortraitMedium.Name = "LabelKingCreatePortraitMedium";
            this.LabelKingCreatePortraitMedium.Padding = new System.Windows.Forms.Padding(15, 5, 15, 30);
            this.LabelKingCreatePortraitMedium.Size = new System.Drawing.Size(122, 48);
            this.LabelKingCreatePortraitMedium.TabIndex = 1;
            this.LabelKingCreatePortraitMedium.Text = "LABEL_KINGMID";
            this.LabelKingCreatePortraitMedium.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelKingCreatePortraitMedium.Click += new System.EventHandler(this.LabelKingCreatePortraitMedium_Click);
            this.LabelKingCreatePortraitMedium.Paint += new System.Windows.Forms.PaintEventHandler(this.LabelKingCreatePortrait_Paint);
            this.LabelKingCreatePortraitMedium.MouseEnter += new System.EventHandler(this.LabelKingCreatePortraitMedium_MouseEnter);
            this.LabelKingCreatePortraitMedium.MouseLeave += new System.EventHandler(this.LabelKingCreatePortraitMedium_MouseLeave);
            // 
            // LabelKingCreatePortraitSmall
            // 
            this.LabelKingCreatePortraitSmall.AutoSize = true;
            this.LabelKingCreatePortraitSmall.BackColor = System.Drawing.Color.Transparent;
            this.LabelKingCreatePortraitSmall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LabelKingCreatePortraitSmall.ForeColor = System.Drawing.Color.White;
            this.LabelKingCreatePortraitSmall.Location = new System.Drawing.Point(258, 0);
            this.LabelKingCreatePortraitSmall.Name = "LabelKingCreatePortraitSmall";
            this.LabelKingCreatePortraitSmall.Padding = new System.Windows.Forms.Padding(15, 5, 15, 30);
            this.LabelKingCreatePortraitSmall.Size = new System.Drawing.Size(124, 48);
            this.LabelKingCreatePortraitSmall.TabIndex = 2;
            this.LabelKingCreatePortraitSmall.Text = "LABEL_KINGSML";
            this.LabelKingCreatePortraitSmall.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelKingCreatePortraitSmall.Click += new System.EventHandler(this.LabelKingCreatePortraitSmall_Click);
            this.LabelKingCreatePortraitSmall.Paint += new System.Windows.Forms.PaintEventHandler(this.LabelKingCreatePortrait_Paint);
            this.LabelKingCreatePortraitSmall.MouseEnter += new System.EventHandler(this.LabelKingCreatePortraitSmall_MouseEnter);
            this.LabelKingCreatePortraitSmall.MouseLeave += new System.EventHandler(this.LabelKingCreatePortraitSmall_MouseLeave);
            // 
            // LabelKingCreatePortraitSml2
            // 
            this.LabelKingCreatePortraitSml2.AutoSize = true;
            this.LabelKingCreatePortraitSml2.BackColor = System.Drawing.Color.Transparent;
            this.LabelKingCreatePortraitSml2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LabelKingCreatePortraitSml2.ForeColor = System.Drawing.Color.White;
            this.LabelKingCreatePortraitSml2.Location = new System.Drawing.Point(3, 48);
            this.LabelKingCreatePortraitSml2.Name = "LabelKingCreatePortraitSml2";
            this.LabelKingCreatePortraitSml2.Padding = new System.Windows.Forms.Padding(15, 5, 15, 30);
            this.LabelKingCreatePortraitSml2.Size = new System.Drawing.Size(130, 48);
            this.LabelKingCreatePortraitSml2.TabIndex = 3;
            this.LabelKingCreatePortraitSml2.Text = "LABEL_KINGSML2";
            this.LabelKingCreatePortraitSml2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelKingCreatePortraitSml2.Click += new System.EventHandler(this.LabelKingCreatePortraitSml2_Click);
            this.LabelKingCreatePortraitSml2.Paint += new System.Windows.Forms.PaintEventHandler(this.LabelKingCreatePortrait_Paint);
            this.LabelKingCreatePortraitSml2.MouseEnter += new System.EventHandler(this.LabelKingCreatePortraitSml2_MouseEnter);
            this.LabelKingCreatePortraitSml2.MouseLeave += new System.EventHandler(this.LabelKingCreatePortraitSml2_MouseLeave);
            // 
            // LayoutKingPortraitGroups
            // 
            this.LayoutKingPortraitGroups.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.LayoutKingPortraitGroups.ColumnCount = 1;
            this.LayoutKingPortraitGroups.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutKingPortraitGroups.Controls.Add(this.LayoutKingPortraitGroupLarge, 0, 0);
            this.LayoutKingPortraitGroups.Controls.Add(this.LayoutKingPortraitGroupMedium, 0, 0);
            this.LayoutKingPortraitGroups.Controls.Add(this.LayoutKingPortraitGroupSmall, 0, 0);
            this.LayoutKingPortraitGroups.Controls.Add(this.LayoutKingPortraitGroupSml2, 0, 0);
            this.LayoutKingPortraitGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutKingPortraitGroups.Location = new System.Drawing.Point(36, 52);
            this.LayoutKingPortraitGroups.Margin = new System.Windows.Forms.Padding(0);
            this.LayoutKingPortraitGroups.Name = "LayoutKingPortraitGroups";
            this.LayoutKingPortraitGroups.RowCount = 1;
            this.LayoutKingPortraitGroups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutKingPortraitGroups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LayoutKingPortraitGroups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LayoutKingPortraitGroups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LayoutKingPortraitGroups.Size = new System.Drawing.Size(513, 404);
            this.LayoutKingPortraitGroups.TabIndex = 4;
            // 
            // LayoutKingPortraitGroupLarge
            // 
            this.LayoutKingPortraitGroupLarge.ColumnCount = 2;
            this.LayoutKingPortraitGroupLarge.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.62378F));
            this.LayoutKingPortraitGroupLarge.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.37622F));
            this.LayoutKingPortraitGroupLarge.Controls.Add(this.PanelKingLrg, 0, 0);
            this.LayoutKingPortraitGroupLarge.Controls.Add(this.PanelKingLrgButtons, 1, 0);
            this.LayoutKingPortraitGroupLarge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutKingPortraitGroupLarge.Location = new System.Drawing.Point(0, 364);
            this.LayoutKingPortraitGroupLarge.Margin = new System.Windows.Forms.Padding(0);
            this.LayoutKingPortraitGroupLarge.Name = "LayoutKingPortraitGroupLarge";
            this.LayoutKingPortraitGroupLarge.RowCount = 1;
            this.LayoutKingPortraitGroupLarge.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutKingPortraitGroupLarge.Size = new System.Drawing.Size(513, 20);
            this.LayoutKingPortraitGroupLarge.TabIndex = 0;
            this.LayoutKingPortraitGroupLarge.Visible = false;
            this.LayoutKingPortraitGroupLarge.Paint += new System.Windows.Forms.PaintEventHandler(this.LayoutKingPortraitGroupLarge_Paint);
            // 
            // PanelKingLrg
            // 
            this.PanelKingLrg.Controls.Add(this.PicKingLrg);
            this.PanelKingLrg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelKingLrg.Location = new System.Drawing.Point(25, 25);
            this.PanelKingLrg.Margin = new System.Windows.Forms.Padding(25);
            this.PanelKingLrg.Name = "PanelKingLrg";
            this.PanelKingLrg.Size = new System.Drawing.Size(260, 1);
            this.PanelKingLrg.TabIndex = 0;
            // 
            // PicKingLrg
            // 
            this.PicKingLrg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicKingLrg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicKingLrg.Image = global::PortraitManager.Properties.Resources.path_placeholder;
            this.PicKingLrg.Location = new System.Drawing.Point(0, 0);
            this.PicKingLrg.Name = "PicKingLrg";
            this.PicKingLrg.Size = new System.Drawing.Size(260, 1);
            this.PicKingLrg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicKingLrg.TabIndex = 0;
            this.PicKingLrg.TabStop = false;
            this.PicKingLrg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicPortraitLrg_MouseDown);
            this.PicKingLrg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicPortraitLrg_MouseMove);
            this.PicKingLrg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicPortraitLrg_MouseUp);
            // 
            // PanelKingLrgButtons
            // 
            this.PanelKingLrgButtons.ColumnCount = 3;
            this.PanelKingLrgButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.PanelKingLrgButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.PanelKingLrgButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.PanelKingLrgButtons.Controls.Add(this.LabelKingLrgHint, 0, 0);
            this.PanelKingLrgButtons.Controls.Add(this.ButtonKingLrgLocal, 0, 1);
            this.PanelKingLrgButtons.Controls.Add(this.ButtonKingLrgWeb, 0, 2);
            this.PanelKingLrgButtons.Controls.Add(this.ButtonKingLrgZoomIn, 0, 4);
            this.PanelKingLrgButtons.Controls.Add(this.ButtonKingLrgZoomOut, 1, 4);
            this.PanelKingLrgButtons.Controls.Add(this.ButtonKingLrgZoomReset, 2, 4);
            this.PanelKingLrgButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelKingLrgButtons.Margin = new System.Windows.Forms.Padding(3, 3, 13, 3);
            this.PanelKingLrgButtons.Location = new System.Drawing.Point(313, 3);
            this.PanelKingLrgButtons.Name = "PanelKingLrgButtons";
            this.PanelKingLrgButtons.RowCount = 5;
            this.PanelKingLrgButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.PanelKingLrgButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.PanelKingLrgButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.PanelKingLrgButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.PanelKingLrgButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.PanelKingLrgButtons.Size = new System.Drawing.Size(197, 14);
            this.PanelKingLrgButtons.TabIndex = 1;
            // 
            // LabelKingLrgHint
            // 
            this.PanelKingLrgButtons.SetColumnSpan(this.LabelKingLrgHint, 3);
            this.LabelKingLrgHint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelKingLrgHint.Location = new System.Drawing.Point(3, 0);
            this.LabelKingLrgHint.Name = "LabelKingLrgHint";
            this.LabelKingLrgHint.Padding = new System.Windows.Forms.Padding(4, 22, 4, 0);
            this.LabelKingLrgHint.Size = new System.Drawing.Size(168, 130);
            this.LabelKingLrgHint.TabIndex = 10;
            this.LabelKingLrgHint.Text = "HINT_KING_LRG";
            // 
            // ButtonKingLrgLocal
            // 
            this.PanelKingLrgButtons.SetColumnSpan(this.ButtonKingLrgLocal, 3);
            this.ButtonKingLrgLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonKingLrgLocal.Location = new System.Drawing.Point(3, 113);
            this.ButtonKingLrgLocal.Name = "ButtonKingLrgLocal";
            this.ButtonKingLrgLocal.Size = new System.Drawing.Size(168, 44);
            this.ButtonKingLrgLocal.TabIndex = 1;
            this.ButtonKingLrgLocal.Tag = "PicKingLrg";
            this.ButtonKingLrgLocal.Text = "SELECT_LOCAL";
            this.ButtonKingLrgLocal.Click += new System.EventHandler(this.ButtonKingSelectLocal_Click);
            // 
            // ButtonKingLrgWeb
            // 
            this.PanelKingLrgButtons.SetColumnSpan(this.ButtonKingLrgWeb, 3);
            this.ButtonKingLrgWeb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonKingLrgWeb.Location = new System.Drawing.Point(3, 163);
            this.ButtonKingLrgWeb.Name = "ButtonKingLrgWeb";
            this.ButtonKingLrgWeb.Size = new System.Drawing.Size(168, 44);
            this.ButtonKingLrgWeb.TabIndex = 0;
            this.ButtonKingLrgWeb.Tag = "PicKingLrg";
            this.ButtonKingLrgWeb.Text = "SELECT_WEB";
            this.ButtonKingLrgWeb.Click += new System.EventHandler(this.ButtonKingSelectWebModal_Click);
            // 
            // ButtonKingLrgZoomIn
            // 
            this.ButtonKingLrgZoomIn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonKingLrgZoomIn.Location = new System.Drawing.Point(3, 353);
            this.ButtonKingLrgZoomIn.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.ButtonKingLrgZoomIn.Name = "ButtonKingLrgZoomIn";
            this.ButtonKingLrgZoomIn.Size = new System.Drawing.Size(81, 12);
            this.ButtonKingLrgZoomIn.TabIndex = 2;
            this.ButtonKingLrgZoomIn.Tag = "PicKingLrg";
            this.ButtonKingLrgZoomIn.Text = "+";
            this.ButtonKingLrgZoomIn.Click += new System.EventHandler(this.ButtonKingZoomIn_Click);
            // 
            // ButtonKingLrgZoomOut
            // 
            this.ButtonKingLrgZoomOut.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonKingLrgZoomOut.Location = new System.Drawing.Point(90, 353);
            this.ButtonKingLrgZoomOut.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.ButtonKingLrgZoomOut.Name = "ButtonKingLrgZoomOut";
            this.ButtonKingLrgZoomOut.Size = new System.Drawing.Size(81, 12);
            this.ButtonKingLrgZoomOut.TabIndex = 3;
            this.ButtonKingLrgZoomOut.Tag = "PicKingLrg";
            this.ButtonKingLrgZoomOut.Text = "−";
            this.ButtonKingLrgZoomOut.Click += new System.EventHandler(this.ButtonKingZoomOut_Click);
            // 
            // ButtonKingLrgZoomReset
            // 
            this.ButtonKingLrgZoomReset.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonKingLrgZoomReset.Location = new System.Drawing.Point(177, 353);
            this.ButtonKingLrgZoomReset.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.ButtonKingLrgZoomReset.Name = "ButtonKingLrgZoomReset";
            this.ButtonKingLrgZoomReset.Size = new System.Drawing.Size(81, 12);
            this.ButtonKingLrgZoomReset.TabIndex = 4;
            this.ButtonKingLrgZoomReset.Tag = "PicKingLrg";
            this.ButtonKingLrgZoomReset.Text = "\u21ba";
            this.ButtonKingLrgZoomReset.Click += new System.EventHandler(this.ButtonKingZoomReset_Click);
            // 
            // LayoutKingPortraitGroupMedium
            // 
            this.LayoutKingPortraitGroupMedium.ColumnCount = 2;
            this.LayoutKingPortraitGroupMedium.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.62378F));
            this.LayoutKingPortraitGroupMedium.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.37622F));
            this.LayoutKingPortraitGroupMedium.Controls.Add(this.PanelKingMed, 0, 0);
            this.LayoutKingPortraitGroupMedium.Controls.Add(this.PanelKingMedButtons, 1, 0);
            this.LayoutKingPortraitGroupMedium.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutKingPortraitGroupMedium.Location = new System.Drawing.Point(0, 384);
            this.LayoutKingPortraitGroupMedium.Margin = new System.Windows.Forms.Padding(0);
            this.LayoutKingPortraitGroupMedium.Name = "LayoutKingPortraitGroupMedium";
            this.LayoutKingPortraitGroupMedium.RowCount = 1;
            this.LayoutKingPortraitGroupMedium.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutKingPortraitGroupMedium.Size = new System.Drawing.Size(513, 20);
            this.LayoutKingPortraitGroupMedium.TabIndex = 1;
            this.LayoutKingPortraitGroupMedium.Visible = false;
            this.LayoutKingPortraitGroupMedium.Paint += new System.Windows.Forms.PaintEventHandler(this.LayoutKingPortraitGroupMedium_Paint);
            // 
            // PanelKingMed
            // 
            this.PanelKingMed.Controls.Add(this.PicKingMed);
            this.PanelKingMed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelKingMed.Location = new System.Drawing.Point(25, 25);
            this.PanelKingMed.Margin = new System.Windows.Forms.Padding(25);
            this.PanelKingMed.Name = "PanelKingMed";
            this.PanelKingMed.Size = new System.Drawing.Size(260, 1);
            this.PanelKingMed.TabIndex = 0;
            // 
            // PicKingMed
            // 
            this.PicKingMed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicKingMed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicKingMed.Image = global::PortraitManager.Properties.Resources.path_placeholder;
            this.PicKingMed.Location = new System.Drawing.Point(0, 0);
            this.PicKingMed.Name = "PicKingMed";
            this.PicKingMed.Size = new System.Drawing.Size(260, 1);
            this.PicKingMed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicKingMed.TabIndex = 0;
            this.PicKingMed.TabStop = false;
            this.PicKingMed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicPortraitMed_MouseDown);
            this.PicKingMed.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicPortraitMed_MouseMove);
            this.PicKingMed.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicPortraitMed_MouseUp);
            // 
            // PanelKingMedButtons
            // 
            this.PanelKingMedButtons.ColumnCount = 3;
            this.PanelKingMedButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.PanelKingMedButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.PanelKingMedButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.PanelKingMedButtons.Controls.Add(this.LabelKingMedHint, 0, 0);
            this.PanelKingMedButtons.Controls.Add(this.ButtonKingMedLocal, 0, 1);
            this.PanelKingMedButtons.Controls.Add(this.ButtonKingMedWeb, 0, 2);
            this.PanelKingMedButtons.Controls.Add(this.ButtonKingMedZoomIn, 0, 4);
            this.PanelKingMedButtons.Controls.Add(this.ButtonKingMedZoomOut, 1, 4);
            this.PanelKingMedButtons.Controls.Add(this.ButtonKingMedZoomReset, 2, 4);
            this.PanelKingMedButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelKingMedButtons.Margin = new System.Windows.Forms.Padding(3, 3, 13, 3);
            this.PanelKingMedButtons.Location = new System.Drawing.Point(313, 3);
            this.PanelKingMedButtons.Name = "PanelKingMedButtons";
            this.PanelKingMedButtons.RowCount = 5;
            this.PanelKingMedButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.PanelKingMedButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.PanelKingMedButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.PanelKingMedButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.PanelKingMedButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.PanelKingMedButtons.Size = new System.Drawing.Size(197, 14);
            this.PanelKingMedButtons.TabIndex = 1;
            // 
            // LabelKingMedHint
            // 
            this.PanelKingMedButtons.SetColumnSpan(this.LabelKingMedHint, 3);
            this.LabelKingMedHint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelKingMedHint.Location = new System.Drawing.Point(3, 0);
            this.LabelKingMedHint.Name = "LabelKingMedHint";
            this.LabelKingMedHint.Padding = new System.Windows.Forms.Padding(4, 22, 4, 0);
            this.LabelKingMedHint.Size = new System.Drawing.Size(168, 130);
            this.LabelKingMedHint.TabIndex = 10;
            this.LabelKingMedHint.Text = "HINT_KING_MED";
            // 
            // ButtonKingMedLocal
            // 
            this.PanelKingMedButtons.SetColumnSpan(this.ButtonKingMedLocal, 3);
            this.ButtonKingMedLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonKingMedLocal.Location = new System.Drawing.Point(3, 113);
            this.ButtonKingMedLocal.Name = "ButtonKingMedLocal";
            this.ButtonKingMedLocal.Size = new System.Drawing.Size(168, 44);
            this.ButtonKingMedLocal.TabIndex = 1;
            this.ButtonKingMedLocal.Tag = "PicKingMed";
            this.ButtonKingMedLocal.Text = "SELECT_LOCAL";
            this.ButtonKingMedLocal.Click += new System.EventHandler(this.ButtonKingSelectLocal_Click);
            // 
            // ButtonKingMedWeb
            // 
            this.PanelKingMedButtons.SetColumnSpan(this.ButtonKingMedWeb, 3);
            this.ButtonKingMedWeb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonKingMedWeb.Location = new System.Drawing.Point(3, 163);
            this.ButtonKingMedWeb.Name = "ButtonKingMedWeb";
            this.ButtonKingMedWeb.Size = new System.Drawing.Size(168, 44);
            this.ButtonKingMedWeb.TabIndex = 0;
            this.ButtonKingMedWeb.Tag = "PicKingMed";
            this.ButtonKingMedWeb.Text = "SELECT_WEB";
            this.ButtonKingMedWeb.Click += new System.EventHandler(this.ButtonKingSelectWebModal_Click);
            // 
            // ButtonKingMedZoomIn
            // 
            this.ButtonKingMedZoomIn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonKingMedZoomIn.Location = new System.Drawing.Point(3, 353);
            this.ButtonKingMedZoomIn.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.ButtonKingMedZoomIn.Name = "ButtonKingMedZoomIn";
            this.ButtonKingMedZoomIn.Size = new System.Drawing.Size(81, 12);
            this.ButtonKingMedZoomIn.TabIndex = 2;
            this.ButtonKingMedZoomIn.Tag = "PicKingMed";
            this.ButtonKingMedZoomIn.Text = "+";
            this.ButtonKingMedZoomIn.Click += new System.EventHandler(this.ButtonKingZoomIn_Click);
            // 
            // ButtonKingMedZoomOut
            // 
            this.ButtonKingMedZoomOut.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonKingMedZoomOut.Location = new System.Drawing.Point(90, 353);
            this.ButtonKingMedZoomOut.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.ButtonKingMedZoomOut.Name = "ButtonKingMedZoomOut";
            this.ButtonKingMedZoomOut.Size = new System.Drawing.Size(81, 12);
            this.ButtonKingMedZoomOut.TabIndex = 3;
            this.ButtonKingMedZoomOut.Tag = "PicKingMed";
            this.ButtonKingMedZoomOut.Text = "−";
            this.ButtonKingMedZoomOut.Click += new System.EventHandler(this.ButtonKingZoomOut_Click);
            // 
            // ButtonKingMedZoomReset
            // 
            this.ButtonKingMedZoomReset.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonKingMedZoomReset.Location = new System.Drawing.Point(177, 353);
            this.ButtonKingMedZoomReset.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.ButtonKingMedZoomReset.Name = "ButtonKingMedZoomReset";
            this.ButtonKingMedZoomReset.Size = new System.Drawing.Size(81, 12);
            this.ButtonKingMedZoomReset.TabIndex = 4;
            this.ButtonKingMedZoomReset.Tag = "PicKingMed";
            this.ButtonKingMedZoomReset.Text = "\u21ba";
            this.ButtonKingMedZoomReset.Click += new System.EventHandler(this.ButtonKingZoomReset_Click);
            // 
            // LayoutKingPortraitGroupSmall
            // 
            this.LayoutKingPortraitGroupSmall.ColumnCount = 2;
            this.LayoutKingPortraitGroupSmall.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.62378F));
            this.LayoutKingPortraitGroupSmall.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.37622F));
            this.LayoutKingPortraitGroupSmall.Controls.Add(this.PanelKingSml, 0, 0);
            this.LayoutKingPortraitGroupSmall.Controls.Add(this.PanelKingSmlButtons, 1, 0);
            this.LayoutKingPortraitGroupSmall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutKingPortraitGroupSmall.Location = new System.Drawing.Point(0, 0);
            this.LayoutKingPortraitGroupSmall.Margin = new System.Windows.Forms.Padding(0);
            this.LayoutKingPortraitGroupSmall.Name = "LayoutKingPortraitGroupSmall";
            this.LayoutKingPortraitGroupSmall.RowCount = 1;
            this.LayoutKingPortraitGroupSmall.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutKingPortraitGroupSmall.Size = new System.Drawing.Size(513, 344);
            this.LayoutKingPortraitGroupSmall.TabIndex = 2;
            this.LayoutKingPortraitGroupSmall.Visible = false;
            this.LayoutKingPortraitGroupSmall.Paint += new System.Windows.Forms.PaintEventHandler(this.LayoutKingPortraitGroupSmall_Paint);
            // 
            // PanelKingSml
            // 
            this.PanelKingSml.Controls.Add(this.PicKingSml);
            this.PanelKingSml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelKingSml.Location = new System.Drawing.Point(25, 25);
            this.PanelKingSml.Margin = new System.Windows.Forms.Padding(25);
            this.PanelKingSml.Name = "PanelKingSml";
            this.PanelKingSml.Size = new System.Drawing.Size(260, 294);
            this.PanelKingSml.TabIndex = 0;
            // 
            // PicKingSml
            // 
            this.PicKingSml.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicKingSml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicKingSml.Image = global::PortraitManager.Properties.Resources.path_placeholder;
            this.PicKingSml.Location = new System.Drawing.Point(0, 0);
            this.PicKingSml.Name = "PicKingSml";
            this.PicKingSml.Size = new System.Drawing.Size(260, 294);
            this.PicKingSml.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicKingSml.TabIndex = 0;
            this.PicKingSml.TabStop = false;
            this.PicKingSml.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicPortraitSml_MouseDown);
            this.PicKingSml.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicPortraitSml_MouseMove);
            this.PicKingSml.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicPortraitSml_MouseUp);
            // 
            // PanelKingSmlButtons
            // 
            this.PanelKingSmlButtons.ColumnCount = 3;
            this.PanelKingSmlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.PanelKingSmlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.PanelKingSmlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.PanelKingSmlButtons.Controls.Add(this.LabelKingSmlHint, 0, 0);
            this.PanelKingSmlButtons.Controls.Add(this.ButtonKingSmlLocal, 0, 1);
            this.PanelKingSmlButtons.Controls.Add(this.ButtonKingSmlWeb, 0, 2);
            this.PanelKingSmlButtons.Controls.Add(this.ButtonKingSmlZoomIn, 0, 4);
            this.PanelKingSmlButtons.Controls.Add(this.ButtonKingSmlZoomOut, 1, 4);
            this.PanelKingSmlButtons.Controls.Add(this.ButtonKingSmlZoomReset, 2, 4);
            this.PanelKingSmlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelKingSmlButtons.Margin = new System.Windows.Forms.Padding(3, 3, 13, 3);
            this.PanelKingSmlButtons.Location = new System.Drawing.Point(313, 3);
            this.PanelKingSmlButtons.Name = "PanelKingSmlButtons";
            this.PanelKingSmlButtons.RowCount = 5;
            this.PanelKingSmlButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.PanelKingSmlButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.PanelKingSmlButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.PanelKingSmlButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.PanelKingSmlButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.PanelKingSmlButtons.Size = new System.Drawing.Size(197, 364);
            this.PanelKingSmlButtons.TabIndex = 1;
            // 
            // LabelKingSmlHint
            // 
            this.PanelKingSmlButtons.SetColumnSpan(this.LabelKingSmlHint, 3);
            this.LabelKingSmlHint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelKingSmlHint.Location = new System.Drawing.Point(3, 0);
            this.LabelKingSmlHint.Name = "LabelKingSmlHint";
            this.LabelKingSmlHint.Padding = new System.Windows.Forms.Padding(4, 22, 4, 0);
            this.LabelKingSmlHint.Size = new System.Drawing.Size(168, 210);
            this.LabelKingSmlHint.TabIndex = 10;
            this.LabelKingSmlHint.Text = "HINT_KING_SML";
            // 
            // ButtonKingSmlLocal
            // 
            this.PanelKingSmlButtons.SetColumnSpan(this.ButtonKingSmlLocal, 3);
            this.ButtonKingSmlLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonKingSmlLocal.Location = new System.Drawing.Point(3, 193);
            this.ButtonKingSmlLocal.Name = "ButtonKingSmlLocal";
            this.ButtonKingSmlLocal.Size = new System.Drawing.Size(168, 44);
            this.ButtonKingSmlLocal.TabIndex = 1;
            this.ButtonKingSmlLocal.Tag = "PicKingSml";
            this.ButtonKingSmlLocal.Text = "SELECT_LOCAL";
            this.ButtonKingSmlLocal.Click += new System.EventHandler(this.ButtonKingSelectLocal_Click);
            // 
            // ButtonKingSmlWeb
            // 
            this.PanelKingSmlButtons.SetColumnSpan(this.ButtonKingSmlWeb, 3);
            this.ButtonKingSmlWeb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonKingSmlWeb.Location = new System.Drawing.Point(3, 243);
            this.ButtonKingSmlWeb.Name = "ButtonKingSmlWeb";
            this.ButtonKingSmlWeb.Size = new System.Drawing.Size(168, 44);
            this.ButtonKingSmlWeb.TabIndex = 0;
            this.ButtonKingSmlWeb.Tag = "PicKingSml";
            this.ButtonKingSmlWeb.Text = "SELECT_WEB";
            this.ButtonKingSmlWeb.Click += new System.EventHandler(this.ButtonKingSelectWebModal_Click);
            // 
            // ButtonKingSmlZoomIn
            // 
            this.ButtonKingSmlZoomIn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonKingSmlZoomIn.Location = new System.Drawing.Point(3, 353);
            this.ButtonKingSmlZoomIn.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.ButtonKingSmlZoomIn.Name = "ButtonKingSmlZoomIn";
            this.ButtonKingSmlZoomIn.Size = new System.Drawing.Size(81, 12);
            this.ButtonKingSmlZoomIn.TabIndex = 2;
            this.ButtonKingSmlZoomIn.Tag = "PicKingSml";
            this.ButtonKingSmlZoomIn.Text = "+";
            this.ButtonKingSmlZoomIn.Click += new System.EventHandler(this.ButtonKingZoomIn_Click);
            // 
            // ButtonKingSmlZoomOut
            // 
            this.ButtonKingSmlZoomOut.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonKingSmlZoomOut.Location = new System.Drawing.Point(90, 353);
            this.ButtonKingSmlZoomOut.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.ButtonKingSmlZoomOut.Name = "ButtonKingSmlZoomOut";
            this.ButtonKingSmlZoomOut.Size = new System.Drawing.Size(81, 12);
            this.ButtonKingSmlZoomOut.TabIndex = 3;
            this.ButtonKingSmlZoomOut.Tag = "PicKingSml";
            this.ButtonKingSmlZoomOut.Text = "−";
            this.ButtonKingSmlZoomOut.Click += new System.EventHandler(this.ButtonKingZoomOut_Click);
            // 
            // ButtonKingSmlZoomReset
            // 
            this.ButtonKingSmlZoomReset.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonKingSmlZoomReset.Location = new System.Drawing.Point(177, 353);
            this.ButtonKingSmlZoomReset.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.ButtonKingSmlZoomReset.Name = "ButtonKingSmlZoomReset";
            this.ButtonKingSmlZoomReset.Size = new System.Drawing.Size(81, 12);
            this.ButtonKingSmlZoomReset.TabIndex = 4;
            this.ButtonKingSmlZoomReset.Tag = "PicKingSml";
            this.ButtonKingSmlZoomReset.Text = "\u21ba";
            this.ButtonKingSmlZoomReset.Click += new System.EventHandler(this.ButtonKingZoomReset_Click);
            // 
            // LayoutKingPortraitGroupSml2
            // 
            this.LayoutKingPortraitGroupSml2.ColumnCount = 2;
            this.LayoutKingPortraitGroupSml2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.62378F));
            this.LayoutKingPortraitGroupSml2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.37622F));
            this.LayoutKingPortraitGroupSml2.Controls.Add(this.PanelKingSml2, 0, 0);
            this.LayoutKingPortraitGroupSml2.Controls.Add(this.PanelKingSml2Buttons, 1, 0);
            this.LayoutKingPortraitGroupSml2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutKingPortraitGroupSml2.Location = new System.Drawing.Point(0, 344);
            this.LayoutKingPortraitGroupSml2.Margin = new System.Windows.Forms.Padding(0);
            this.LayoutKingPortraitGroupSml2.Name = "LayoutKingPortraitGroupSml2";
            this.LayoutKingPortraitGroupSml2.RowCount = 1;
            this.LayoutKingPortraitGroupSml2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutKingPortraitGroupSml2.Size = new System.Drawing.Size(513, 20);
            this.LayoutKingPortraitGroupSml2.TabIndex = 3;
            this.LayoutKingPortraitGroupSml2.Visible = false;
            this.LayoutKingPortraitGroupSml2.Paint += new System.Windows.Forms.PaintEventHandler(this.LayoutKingPortraitGroupSml2_Paint);
            // 
            // PanelKingSml2
            // 
            this.PanelKingSml2.Controls.Add(this.PicKingSml2);
            this.PanelKingSml2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelKingSml2.Location = new System.Drawing.Point(25, 25);
            this.PanelKingSml2.Margin = new System.Windows.Forms.Padding(25);
            this.PanelKingSml2.Name = "PanelKingSml2";
            this.PanelKingSml2.Size = new System.Drawing.Size(260, 1);
            this.PanelKingSml2.TabIndex = 0;
            // 
            // PicKingSml2
            // 
            this.PicKingSml2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicKingSml2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicKingSml2.Image = global::PortraitManager.Properties.Resources.path_placeholder;
            this.PicKingSml2.Location = new System.Drawing.Point(0, 0);
            this.PicKingSml2.Name = "PicKingSml2";
            this.PicKingSml2.Size = new System.Drawing.Size(260, 1);
            this.PicKingSml2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicKingSml2.TabIndex = 0;
            this.PicKingSml2.TabStop = false;
            this.PicKingSml2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicPortraitSml2_MouseDown);
            this.PicKingSml2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicPortraitSml2_MouseMove);
            this.PicKingSml2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicPortraitSml2_MouseUp);
            // 
            // PanelKingSml2Buttons
            // 
            this.PanelKingSml2Buttons.ColumnCount = 3;
            this.PanelKingSml2Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.PanelKingSml2Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.PanelKingSml2Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.PanelKingSml2Buttons.Controls.Add(this.LabelKingSml2Hint, 0, 0);
            this.PanelKingSml2Buttons.Controls.Add(this.ButtonKingSml2Local, 0, 1);
            this.PanelKingSml2Buttons.Controls.Add(this.ButtonKingSml2Web, 0, 2);
            this.PanelKingSml2Buttons.Controls.Add(this.ButtonKingSml2ZoomIn, 0, 4);
            this.PanelKingSml2Buttons.Controls.Add(this.ButtonKingSml2ZoomOut, 1, 4);
            this.PanelKingSml2Buttons.Controls.Add(this.ButtonKingSml2ZoomReset, 2, 4);
            this.PanelKingSml2Buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelKingSml2Buttons.Margin = new System.Windows.Forms.Padding(3, 3, 13, 3);
            this.PanelKingSml2Buttons.Location = new System.Drawing.Point(313, 3);
            this.PanelKingSml2Buttons.Name = "PanelKingSml2Buttons";
            this.PanelKingSml2Buttons.RowCount = 5;
            this.PanelKingSml2Buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.PanelKingSml2Buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.PanelKingSml2Buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.PanelKingSml2Buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.PanelKingSml2Buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.PanelKingSml2Buttons.Size = new System.Drawing.Size(197, 14);
            this.PanelKingSml2Buttons.TabIndex = 1;
            // 
            // LabelKingSml2Hint
            // 
            this.PanelKingSml2Buttons.SetColumnSpan(this.LabelKingSml2Hint, 3);
            this.LabelKingSml2Hint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelKingSml2Hint.Location = new System.Drawing.Point(3, 0);
            this.LabelKingSml2Hint.Name = "LabelKingSml2Hint";
            this.LabelKingSml2Hint.Padding = new System.Windows.Forms.Padding(4, 22, 4, 0);
            this.LabelKingSml2Hint.Size = new System.Drawing.Size(168, 210);
            this.LabelKingSml2Hint.TabIndex = 10;
            this.LabelKingSml2Hint.Text = "HINT_KING_SML2";
            // 
            // ButtonKingSml2Local
            // 
            this.PanelKingSml2Buttons.SetColumnSpan(this.ButtonKingSml2Local, 3);
            this.ButtonKingSml2Local.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonKingSml2Local.Location = new System.Drawing.Point(3, 193);
            this.ButtonKingSml2Local.Name = "ButtonKingSml2Local";
            this.ButtonKingSml2Local.Size = new System.Drawing.Size(168, 44);
            this.ButtonKingSml2Local.TabIndex = 1;
            this.ButtonKingSml2Local.Tag = "PicKingSml2";
            this.ButtonKingSml2Local.Text = "SELECT_LOCAL";
            this.ButtonKingSml2Local.Click += new System.EventHandler(this.ButtonKingSelectLocal_Click);
            // 
            // ButtonKingSml2Web
            // 
            this.PanelKingSml2Buttons.SetColumnSpan(this.ButtonKingSml2Web, 3);
            this.ButtonKingSml2Web.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonKingSml2Web.Location = new System.Drawing.Point(3, 243);
            this.ButtonKingSml2Web.Name = "ButtonKingSml2Web";
            this.ButtonKingSml2Web.Size = new System.Drawing.Size(168, 44);
            this.ButtonKingSml2Web.TabIndex = 0;
            this.ButtonKingSml2Web.Tag = "PicKingSml2";
            this.ButtonKingSml2Web.Text = "SELECT_WEB";
            this.ButtonKingSml2Web.Click += new System.EventHandler(this.ButtonKingSelectWebModal_Click);
            // 
            // ButtonKingSml2ZoomIn
            // 
            this.ButtonKingSml2ZoomIn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonKingSml2ZoomIn.Location = new System.Drawing.Point(3, 353);
            this.ButtonKingSml2ZoomIn.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.ButtonKingSml2ZoomIn.Name = "ButtonKingSml2ZoomIn";
            this.ButtonKingSml2ZoomIn.Size = new System.Drawing.Size(81, 12);
            this.ButtonKingSml2ZoomIn.TabIndex = 2;
            this.ButtonKingSml2ZoomIn.Tag = "PicKingSml2";
            this.ButtonKingSml2ZoomIn.Text = "+";
            this.ButtonKingSml2ZoomIn.Click += new System.EventHandler(this.ButtonKingZoomIn_Click);
            // 
            // ButtonKingSml2ZoomOut
            // 
            this.ButtonKingSml2ZoomOut.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonKingSml2ZoomOut.Location = new System.Drawing.Point(90, 353);
            this.ButtonKingSml2ZoomOut.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.ButtonKingSml2ZoomOut.Name = "ButtonKingSml2ZoomOut";
            this.ButtonKingSml2ZoomOut.Size = new System.Drawing.Size(81, 12);
            this.ButtonKingSml2ZoomOut.TabIndex = 3;
            this.ButtonKingSml2ZoomOut.Tag = "PicKingSml2";
            this.ButtonKingSml2ZoomOut.Text = "−";
            this.ButtonKingSml2ZoomOut.Click += new System.EventHandler(this.ButtonKingZoomOut_Click);
            // 
            // ButtonKingSml2ZoomReset
            // 
            this.ButtonKingSml2ZoomReset.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonKingSml2ZoomReset.Location = new System.Drawing.Point(177, 353);
            this.ButtonKingSml2ZoomReset.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.ButtonKingSml2ZoomReset.Name = "ButtonKingSml2ZoomReset";
            this.ButtonKingSml2ZoomReset.Size = new System.Drawing.Size(81, 12);
            this.ButtonKingSml2ZoomReset.TabIndex = 4;
            this.ButtonKingSml2ZoomReset.Tag = "PicKingSml2";
            this.ButtonKingSml2ZoomReset.Text = "\u21ba";
            this.ButtonKingSml2ZoomReset.Click += new System.EventHandler(this.ButtonKingZoomReset_Click);
            // 
            // LayoutKingRight
            // 
            this.LayoutKingRight.ColumnCount = 1;
            this.LayoutKingRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutKingRight.Controls.Add(this.ButtonKingCreateNewPortrait, 0, 0);
            this.LayoutKingRight.Controls.Add(this.ButtonKingBackToPathfinder, 0, 1);
            this.LayoutKingRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutKingRight.Location = new System.Drawing.Point(557, 52);
            this.LayoutKingRight.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.LayoutKingRight.Name = "LayoutKingRight";
            this.LayoutKingRight.RowCount = 2;
            this.LayoutKingRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutKingRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutKingRight.Size = new System.Drawing.Size(138, 404);
            this.LayoutKingRight.TabIndex = 5;
            this.LayoutKingRight.Paint += new System.Windows.Forms.PaintEventHandler(this.LayoutKingRight_Paint);
            // 
            // ButtonKingCreateNewPortrait
            // 
            this.ButtonKingCreateNewPortrait.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonKingCreateNewPortrait.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonKingCreateNewPortrait.Location = new System.Drawing.Point(0, 0);
            this.ButtonKingCreateNewPortrait.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonKingCreateNewPortrait.Name = "ButtonKingCreateNewPortrait";
            this.ButtonKingCreateNewPortrait.Size = new System.Drawing.Size(138, 202);
            this.ButtonKingCreateNewPortrait.TabIndex = 0;
            this.ButtonKingCreateNewPortrait.Click += new System.EventHandler(this.ButtonKingAction_Create_Click);
            // 
            // ButtonKingBackToPathfinder
            // 
            this.ButtonKingBackToPathfinder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonKingBackToPathfinder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonKingBackToPathfinder.Location = new System.Drawing.Point(0, 202);
            this.ButtonKingBackToPathfinder.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonKingBackToPathfinder.Name = "ButtonKingBackToPathfinder";
            this.ButtonKingBackToPathfinder.Size = new System.Drawing.Size(138, 202);
            this.ButtonKingBackToPathfinder.TabIndex = 1;
            this.ButtonKingBackToPathfinder.Click += new System.EventHandler(this.ButtonKingBackToPathfinder_Click);
            // 
            // LabelKingGroupLargeTitle
            // 
            this.LabelKingGroupLargeTitle.Location = new System.Drawing.Point(0, 0);
            this.LabelKingGroupLargeTitle.Name = "LabelKingGroupLargeTitle";
            this.LabelKingGroupLargeTitle.Size = new System.Drawing.Size(100, 23);
            this.LabelKingGroupLargeTitle.TabIndex = 0;
            // 
            // LabelKingGroupMediumTitle
            // 
            this.LabelKingGroupMediumTitle.Location = new System.Drawing.Point(0, 0);
            this.LabelKingGroupMediumTitle.Name = "LabelKingGroupMediumTitle";
            this.LabelKingGroupMediumTitle.Size = new System.Drawing.Size(100, 23);
            this.LabelKingGroupMediumTitle.TabIndex = 0;
            // 
            // LabelKingGroupSmallTitle
            // 
            this.LabelKingGroupSmallTitle.Location = new System.Drawing.Point(0, 0);
            this.LabelKingGroupSmallTitle.Name = "LabelKingGroupSmallTitle";
            this.LabelKingGroupSmallTitle.Size = new System.Drawing.Size(100, 23);
            this.LabelKingGroupSmallTitle.TabIndex = 0;
            // 
            // LabelKingGroupSml2Title
            // 
            this.LabelKingGroupSml2Title.Location = new System.Drawing.Point(0, 0);
            this.LabelKingGroupSml2Title.Name = "LabelKingGroupSml2Title";
            this.LabelKingGroupSml2Title.Size = new System.Drawing.Size(100, 23);
            this.LabelKingGroupSml2Title.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(252, 790);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(492, 790);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel2.TabIndex = 13;
            // 
            // LayoutExtractPage
            // 
            this.LayoutExtractPage.BackColor = System.Drawing.Color.Black;
            this.LayoutExtractPage.ColumnCount = 4;
            this.LayoutExtractPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.LayoutExtractPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68F));
            this.LayoutExtractPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.LayoutExtractPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.LayoutExtractPage.Controls.Add(this.PanelExtractContainer, 1, 1);
            this.LayoutExtractPage.Controls.Add(this.LayoutExtractRight, 2, 1);
            this.LayoutExtractPage.Controls.Add(this.FlowLayoutPanelExtractBottom, 1, 2);
            this.LayoutExtractPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutExtractPage.Location = new System.Drawing.Point(0, 0);
            this.LayoutExtractPage.Name = "LayoutExtractPage";
            this.LayoutExtractPage.RowCount = 3;
            this.LayoutExtractPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.LayoutExtractPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.5F));
            this.LayoutExtractPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.5F));
            this.LayoutExtractPage.Size = new System.Drawing.Size(734, 481);
            this.LayoutExtractPage.TabIndex = 14;
            this.LayoutExtractPage.Visible = false;
            this.LayoutExtractPage.Enabled = false;
            // 
            // PanelExtractContainer
            // 
            this.PanelExtractContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.PanelExtractContainer.Controls.Add(this.FlowLayoutPanelExtract);
            this.PanelExtractContainer.Controls.Add(this.PanelExtractOverlay);
            this.PanelExtractContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelExtractContainer.Location = new System.Drawing.Point(39, 27);
            this.PanelExtractContainer.Margin = new System.Windows.Forms.Padding(0);
            this.PanelExtractContainer.Name = "PanelExtractContainer";
            this.PanelExtractContainer.Padding = new System.Windows.Forms.Padding(10);
            this.PanelExtractContainer.Size = new System.Drawing.Size(499, 427);
            this.PanelExtractContainer.TabIndex = 2;
            this.PanelExtractContainer.AllowDrop = true;
            this.PanelExtractContainer.DragDrop += new System.Windows.Forms.DragEventHandler(this.PanelExtractContainer_DragDrop);
            this.PanelExtractContainer.DragEnter += new System.Windows.Forms.DragEventHandler(this.PanelExtractContainer_DragEnter);
            this.PanelExtractContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelExtractContainer_Paint);
            // 
            // FlowLayoutPanelExtract
            // 
            this.FlowLayoutPanelExtract.AutoScroll = true;
            this.FlowLayoutPanelExtract.BackColor = System.Drawing.Color.Transparent;
            this.FlowLayoutPanelExtract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowLayoutPanelExtract.Location = new System.Drawing.Point(0, 0);
            this.FlowLayoutPanelExtract.Margin = new System.Windows.Forms.Padding(0);
            this.FlowLayoutPanelExtract.Name = "FlowLayoutPanelExtract";
            this.FlowLayoutPanelExtract.Size = new System.Drawing.Size(479, 407);
            this.FlowLayoutPanelExtract.TabIndex = 3;
            // 
            // PanelExtractOverlay
            // 
            this.PanelExtractOverlay.BackColor = System.Drawing.Color.Transparent;
            this.PanelExtractOverlay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelExtractOverlay_MouseClick);
            this.PanelExtractOverlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PanelExtractOverlay.MouseEnter += new System.EventHandler(this.PanelExtractOverlay_MouseEnter);
            this.PanelExtractOverlay.MouseLeave += new System.EventHandler(this.PanelExtractOverlay_MouseLeave);
            this.PanelExtractOverlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelExtractOverlay.Location = new System.Drawing.Point(0, 0);
            this.PanelExtractOverlay.Margin = new System.Windows.Forms.Padding(0);
            this.PanelExtractOverlay.Name = "PanelExtractOverlay";
            this.PanelExtractOverlay.Size = new System.Drawing.Size(499, 427);
            this.PanelExtractOverlay.TabIndex = 5;
            this.PanelExtractOverlay.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelExtractOverlay_Paint);
            // 
            // LayoutExtractRight
            // 
            this.LayoutExtractRight.ColumnCount = 1;
            this.LayoutExtractRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutExtractRight.Controls.Add(this.ButtonExtractAll, 0, 0);
            this.LayoutExtractRight.Controls.Add(this.ButtonExtractSelected, 0, 1);
            this.LayoutExtractRight.Controls.Add(this.ButtonExtractShowFolder, 0, 2);
            this.LayoutExtractRight.Controls.Add(this.ButtonExtractBack, 0, 3);
            this.LayoutExtractRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutExtractRight.Name = "LayoutExtractRight";
            this.LayoutExtractRight.RowCount = 4;
            this.LayoutExtractRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.LayoutExtractRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.LayoutExtractRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.LayoutExtractRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.LayoutExtractRight.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.LayoutExtractRight.Size = new System.Drawing.Size(140, 421);
            this.LayoutExtractRight.TabIndex = 6;
            this.LayoutExtractRight.Paint += new System.Windows.Forms.PaintEventHandler(this.LayoutExtractRight_Paint);
            // 
            // ButtonExtractAll
            // 
            this.ButtonExtractAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonExtractAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonExtractAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonExtractAll.Location = new System.Drawing.Point(0, 0);
            this.ButtonExtractAll.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonExtractAll.Name = "ButtonExtractAll";
            this.ButtonExtractAll.Size = new System.Drawing.Size(140, 140);
            this.ButtonExtractAll.TabIndex = 0;
            this.ButtonExtractAll.Text = "BUTTON_EXTRACT_ALL";
            this.ButtonExtractAll.Click += new System.EventHandler(this.ButtonExtractAll_Click);
            this.ButtonExtractAll.MouseEnter += new System.EventHandler(this.ButtonExtractAll_MouseEnter);
            this.ButtonExtractAll.MouseLeave += new System.EventHandler(this.ButtonExtractAll_MouseLeave);
            // 
            // ButtonExtractSelected
            // 
            this.ButtonExtractSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonExtractSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonExtractSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonExtractSelected.Location = new System.Drawing.Point(0, 140);
            this.ButtonExtractSelected.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonExtractSelected.Name = "ButtonExtractSelected";
            this.ButtonExtractSelected.Size = new System.Drawing.Size(140, 140);
            this.ButtonExtractSelected.TabIndex = 1;
            this.ButtonExtractSelected.Text = "BUTTON_EXTRACT_SELECTED";
            this.ButtonExtractSelected.Click += new System.EventHandler(this.ButtonExtractSelected_Click);
            this.ButtonExtractSelected.MouseEnter += new System.EventHandler(this.ButtonExtractSelected_MouseEnter);
            this.ButtonExtractSelected.MouseLeave += new System.EventHandler(this.ButtonExtractSelected_MouseLeave);
            // 
            // ButtonExtractBack
            // 
            this.ButtonExtractBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonExtractBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonExtractBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonExtractBack.Location = new System.Drawing.Point(0, 280);
            this.ButtonExtractBack.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonExtractBack.Name = "ButtonExtractBack";
            this.ButtonExtractBack.Size = new System.Drawing.Size(140, 140);
            this.ButtonExtractBack.TabIndex = 2;
            this.ButtonExtractBack.Text = "BUTTON_EXTRACT_BACK";
            this.ButtonExtractBack.Click += new System.EventHandler(this.ButtonExtractBack_Click);
            this.ButtonExtractBack.MouseEnter += new System.EventHandler(this.ButtonExtractBack_MouseEnter);
            this.ButtonExtractBack.MouseLeave += new System.EventHandler(this.ButtonExtractBack_MouseLeave);
            // 
            // ButtonExtractShowFolder
            // 
            this.ButtonExtractShowFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonExtractShowFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonExtractShowFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonExtractShowFolder.Location = new System.Drawing.Point(0, 420);
            this.ButtonExtractShowFolder.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonExtractShowFolder.Name = "ButtonExtractShowFolder";
            this.ButtonExtractShowFolder.Size = new System.Drawing.Size(140, 140);
            this.ButtonExtractShowFolder.TabIndex = 8;
            this.ButtonExtractShowFolder.Text = "BUTTON_EXTRACT_OPENFOLDER";
            this.ButtonExtractShowFolder.Click += new System.EventHandler(this.ButtonExtractShowFolder_Click);
            this.ButtonExtractShowFolder.MouseEnter += new System.EventHandler(this.ButtonExtractShowFolder_MouseEnter);
            this.ButtonExtractShowFolder.MouseLeave += new System.EventHandler(this.ButtonExtractShowFolder_MouseLeave);
            // 
            // LabelExtractCounter
            // 
            this.LabelExtractCounter.AutoSize = true;
            this.LabelExtractCounter.BackColor = System.Drawing.Color.Transparent;
            this.LabelExtractCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelExtractCounter.ForeColor = System.Drawing.Color.Gray;
            this.LabelExtractCounter.Margin = new System.Windows.Forms.Padding(0);
            this.LabelExtractCounter.Name = "LabelExtractCounter";
            this.LabelExtractCounter.Size = new System.Drawing.Size(110, 13);
            this.LabelExtractCounter.TabIndex = 7;
            this.LabelExtractCounter.Text = "Total: 0 | Selected: 0";
            this.LabelExtractCounter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FlowLayoutPanelExtractBottom
            // 
            this.FlowLayoutPanelExtractBottom.BackColor = System.Drawing.Color.Transparent;
            this.FlowLayoutPanelExtractBottom.Controls.Add(this.LabelExtractCounter);
            this.FlowLayoutPanelExtractBottom.Controls.Add(this.LabelExtractClearSelection);
            this.FlowLayoutPanelExtractBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowLayoutPanelExtractBottom.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.FlowLayoutPanelExtractBottom.Location = new System.Drawing.Point(39, 459);
            this.FlowLayoutPanelExtractBottom.Margin = new System.Windows.Forms.Padding(0);
            this.FlowLayoutPanelExtractBottom.Name = "FlowLayoutPanelExtractBottom";
            this.FlowLayoutPanelExtractBottom.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.FlowLayoutPanelExtractBottom.Size = new System.Drawing.Size(499, 24);
            this.FlowLayoutPanelExtractBottom.TabIndex = 8;
            this.FlowLayoutPanelExtractBottom.WrapContents = false;
            // 
            // LabelExtractClearSelection
            // 
            this.LabelExtractClearSelection.AutoSize = true;
            this.LabelExtractClearSelection.BackColor = System.Drawing.Color.Transparent;
            this.LabelExtractClearSelection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LabelExtractClearSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelExtractClearSelection.ForeColor = System.Drawing.Color.White;
            this.LabelExtractClearSelection.Margin = new System.Windows.Forms.Padding(0);
            this.LabelExtractClearSelection.Name = "LabelExtractClearSelection";
            this.LabelExtractClearSelection.Size = new System.Drawing.Size(12, 13);
            this.LabelExtractClearSelection.TabIndex = 9;
            this.LabelExtractClearSelection.Text = "Clear";
            this.LabelExtractClearSelection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelExtractClearSelection.Click += new System.EventHandler(this.LabelExtractClearSelection_Click);
            this.LabelExtractClearSelection.MouseEnter += new System.EventHandler(this.LabelExtractClearSelection_MouseEnter);
            this.LabelExtractClearSelection.MouseLeave += new System.EventHandler(this.LabelExtractClearSelection_MouseLeave);
            // 
            // LayoutGalleryPage
            // 
            this.LayoutGalleryPage.BackColor = System.Drawing.Color.Black;
            this.LayoutGalleryPage.ColumnCount = 4;
            this.LayoutGalleryPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.LayoutGalleryPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68F));
            this.LayoutGalleryPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.LayoutGalleryPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.LayoutGalleryPage.Controls.Add(this.flowLayoutPanelGalleryTabs, 1, 1);
            this.LayoutGalleryPage.Controls.Add(this.PanelGalleryContainer, 1, 2);
            this.LayoutGalleryPage.Controls.Add(this.LayoutGalleryRight, 2, 2);
            this.LayoutGalleryPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutGalleryPage.Location = new System.Drawing.Point(0, 0);
            this.LayoutGalleryPage.Name = "LayoutGalleryPage";
            this.LayoutGalleryPage.RowCount = 4;
            this.LayoutGalleryPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.LayoutGalleryPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.LayoutGalleryPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84F));
            this.LayoutGalleryPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.LayoutGalleryPage.Size = new System.Drawing.Size(734, 481);
            this.LayoutGalleryPage.TabIndex = 15;
            this.LayoutGalleryPage.Visible = false;
            this.LayoutGalleryPage.Enabled = false;
            // 
            // flowLayoutPanelGalleryTabs
            // 
            this.flowLayoutPanelGalleryTabs.Controls.Add(this.LabelGalleryTab);
            this.flowLayoutPanelGalleryTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelGalleryTabs.Location = new System.Drawing.Point(36, 9);
            this.flowLayoutPanelGalleryTabs.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelGalleryTabs.Name = "flowLayoutPanelGalleryTabs";
            this.flowLayoutPanelGalleryTabs.Size = new System.Drawing.Size(499, 43);
            this.flowLayoutPanelGalleryTabs.TabIndex = 0;
            // 
            // LabelGalleryTab
            // 
            this.LabelGalleryTab.AutoSize = true;
            this.LabelGalleryTab.BackColor = System.Drawing.Color.Transparent;
            this.LabelGalleryTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LabelGalleryTab.ForeColor = System.Drawing.Color.White;
            this.LabelGalleryTab.Location = new System.Drawing.Point(0, 0);
            this.LabelGalleryTab.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.LabelGalleryTab.Name = "LabelGalleryTab";
            this.LabelGalleryTab.Padding = new System.Windows.Forms.Padding(15, 5, 15, 5);
            this.LabelGalleryTab.Size = new System.Drawing.Size(113, 48);
            this.LabelGalleryTab.TabIndex = 0;
            this.LabelGalleryTab.Text = "LABEL_GALLERY";
            this.LabelGalleryTab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelGalleryTab.Paint += new System.Windows.Forms.PaintEventHandler(this.LabelGalleryTab_Paint);
            this.LabelGalleryTab.MouseEnter += new System.EventHandler(this.LabelGalleryTab_MouseEnter);
            this.LabelGalleryTab.MouseLeave += new System.EventHandler(this.LabelGalleryTab_MouseLeave);
            // 
            // PanelGalleryContainer
            // 
            this.PanelGalleryContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.PanelGalleryContainer.Controls.Add(this.FlowLayoutPanelGallery);
            this.PanelGalleryContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelGalleryContainer.Location = new System.Drawing.Point(39, 55);
            this.PanelGalleryContainer.Margin = new System.Windows.Forms.Padding(0);
            this.PanelGalleryContainer.Name = "PanelGalleryContainer";
            this.PanelGalleryContainer.Padding = new System.Windows.Forms.Padding(10);
            this.PanelGalleryContainer.Size = new System.Drawing.Size(499, 404);
            this.PanelGalleryContainer.TabIndex = 2;
            this.PanelGalleryContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelGalleryContainer_Paint);
            // 
            // FlowLayoutPanelGallery
            // 
            this.FlowLayoutPanelGallery.AutoScroll = true;
            this.FlowLayoutPanelGallery.BackColor = System.Drawing.Color.Transparent;
            this.FlowLayoutPanelGallery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowLayoutPanelGallery.Location = new System.Drawing.Point(0, 0);
            this.FlowLayoutPanelGallery.Margin = new System.Windows.Forms.Padding(0);
            this.FlowLayoutPanelGallery.Name = "FlowLayoutPanelGallery";
            this.FlowLayoutPanelGallery.Size = new System.Drawing.Size(479, 384);
            this.FlowLayoutPanelGallery.TabIndex = 3;
            // 
            // LayoutGalleryRight
            // 
            this.LayoutGalleryRight.ColumnCount = 1;
            this.LayoutGalleryRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutGalleryRight.Controls.Add(this.ButtonGalleryClone, 0, 0);
            this.LayoutGalleryRight.Controls.Add(this.ButtonGalleryChange, 0, 1);
            this.LayoutGalleryRight.Controls.Add(this.ButtonGalleryDelete, 0, 2);
            this.LayoutGalleryRight.Controls.Add(this.ButtonGalleryBack, 0, 3);
            this.LayoutGalleryRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutGalleryRight.Location = new System.Drawing.Point(546, 55);
            this.LayoutGalleryRight.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.LayoutGalleryRight.Name = "LayoutGalleryRight";
            this.LayoutGalleryRight.RowCount = 4;
            this.LayoutGalleryRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.LayoutGalleryRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.LayoutGalleryRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.LayoutGalleryRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.LayoutGalleryRight.Size = new System.Drawing.Size(140, 404);
            this.LayoutGalleryRight.TabIndex = 6;
            this.LayoutGalleryRight.Paint += new System.Windows.Forms.PaintEventHandler(this.LayoutGalleryRight_Paint);
            // 
            // ButtonGalleryBack
            // 
            this.ButtonGalleryBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonGalleryBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonGalleryBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonGalleryBack.Location = new System.Drawing.Point(0, 0);
            this.ButtonGalleryBack.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonGalleryBack.Name = "ButtonGalleryBack";
            this.ButtonGalleryBack.Size = new System.Drawing.Size(140, 134);
            this.ButtonGalleryBack.TabIndex = 0;
            this.ButtonGalleryBack.Text = "BUTTON_GALLERY_BACK";
            this.ButtonGalleryBack.Click += new System.EventHandler(this.ButtonGalleryBack_Click);
            this.ButtonGalleryBack.MouseEnter += new System.EventHandler(this.ButtonGalleryBack_MouseEnter);
            this.ButtonGalleryBack.MouseLeave += new System.EventHandler(this.ButtonGalleryBack_MouseLeave);
            // 
            // ButtonGalleryClone
            // 
            this.ButtonGalleryClone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonGalleryClone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonGalleryClone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonGalleryClone.Location = new System.Drawing.Point(0, 0);
            this.ButtonGalleryClone.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonGalleryClone.Name = "ButtonGalleryClone";
            this.ButtonGalleryClone.Size = new System.Drawing.Size(140, 134);
            this.ButtonGalleryClone.TabIndex = 1;
            this.ButtonGalleryClone.Text = "BUTTON_GALLERY_CLONE";
            this.ButtonGalleryClone.Click += new System.EventHandler(this.ButtonGalleryClone_Click);
            this.ButtonGalleryClone.MouseEnter += new System.EventHandler(this.ButtonGalleryClone_MouseEnter);
            this.ButtonGalleryClone.MouseLeave += new System.EventHandler(this.ButtonGalleryClone_MouseLeave);
            // 
            // ButtonGalleryChange
            // 
            this.ButtonGalleryChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonGalleryChange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonGalleryChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonGalleryChange.Location = new System.Drawing.Point(0, 0);
            this.ButtonGalleryChange.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonGalleryChange.Name = "ButtonGalleryChange";
            this.ButtonGalleryChange.Size = new System.Drawing.Size(140, 134);
            this.ButtonGalleryChange.TabIndex = 2;
            this.ButtonGalleryChange.Text = "BUTTON_GALLERY_CHANGE";
            this.ButtonGalleryChange.Click += new System.EventHandler(this.ButtonGalleryChange_Click);
            this.ButtonGalleryChange.MouseEnter += new System.EventHandler(this.ButtonGalleryChange_MouseEnter);
            this.ButtonGalleryChange.MouseLeave += new System.EventHandler(this.ButtonGalleryChange_MouseLeave);
            // 
            // ButtonGalleryDelete
            // 
            this.ButtonGalleryDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonGalleryDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonGalleryDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonGalleryDelete.Location = new System.Drawing.Point(0, 0);
            this.ButtonGalleryDelete.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonGalleryDelete.Name = "ButtonGalleryDelete";
            this.ButtonGalleryDelete.Size = new System.Drawing.Size(140, 134);
            this.ButtonGalleryDelete.TabIndex = 3;
            this.ButtonGalleryDelete.Text = "BUTTON_GALLERY_DELETE";
            this.ButtonGalleryDelete.Click += new System.EventHandler(this.ButtonGalleryDelete_Click);
            this.ButtonGalleryDelete.MouseEnter += new System.EventHandler(this.ButtonGalleryDelete_MouseEnter);
            this.ButtonGalleryDelete.MouseLeave += new System.EventHandler(this.ButtonGalleryDelete_MouseLeave);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(734, 481);
            this.Controls.Add(this.LayoutGalleryPage);
            this.Controls.Add(this.LayoutExtractPage);
            this.Controls.Add(this.LayoutKingCreatePortrait);
            this.Controls.Add(this.LayoutStartMenu);
            this.Controls.Add(this.LayoutMainPage);
            this.Controls.Add(this.LayoutPathPage);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.ForeColor = System.Drawing.Color.Black;
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
            this.Text = "TITLE_MAIN";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_Closed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.LayoutStartMenu.ResumeLayout(false);
            this.tableLayoutPanel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxStartKing)).EndInit();
            this.tableLayoutPanel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxStartWotr)).EndInit();
            this.tableLayoutPanel15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxStartRt)).EndInit();
            this.tableLayoutPanel16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxStartPoe)).EndInit();
            this.tableLayoutPanel17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxStartPoed)).EndInit();
            this.tableLayoutPanel18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxStartTyr)).EndInit();
            this.tableLayoutPanel19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxStartW3)).EndInit();
            this.tableLayoutPanel20.ResumeLayout(false);
            this.tableLayoutPanel20.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxStartOpenNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxStartOpenGitHub)).EndInit();
            this.LayoutPathPage.ResumeLayout(false);
            this.LayoutPathPage.PerformLayout();
            this.tableLayoutPanel21.ResumeLayout(false);
            this.tableLayoutPanel21.PerformLayout();
            this.tableLayoutPanel22.ResumeLayout(false);
            this.tableLayoutPanel22.PerformLayout();
            this.LayoutMainPage.ResumeLayout(false);
            this.tableLayoutPanel23.ResumeLayout(false);
            this.tableLayoutPanel23.PerformLayout();
            this.PanelExtractOverlay.ResumeLayout(false);
            this.FlowLayoutPanelExtract.ResumeLayout(false);
            this.FlowLayoutPanelExtractBottom.ResumeLayout(false);
            this.PanelExtractContainer.ResumeLayout(false);
            this.LayoutExtractPage.ResumeLayout(false);
            this.LayoutExtractPage.PerformLayout();
            this.LayoutKingCreatePortrait.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.LayoutKingPortraitGroups.ResumeLayout(false);
            this.LayoutKingPortraitGroupLarge.ResumeLayout(false);
            this.PanelKingLrg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicKingLrg)).EndInit();
            this.PanelKingLrgButtons.ResumeLayout(false);
            this.LayoutKingPortraitGroupMedium.ResumeLayout(false);
            this.PanelKingMed.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicKingMed)).EndInit();
            this.PanelKingMedButtons.ResumeLayout(false);
            this.LayoutKingPortraitGroupSmall.ResumeLayout(false);
            this.PanelKingSml.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicKingSml)).EndInit();
            this.PanelKingSmlButtons.ResumeLayout(false);
            this.LayoutKingPortraitGroupSml2.ResumeLayout(false);
            this.PanelKingSml2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicKingSml2)).EndInit();
            this.PanelKingSml2Buttons.ResumeLayout(false);
            this.LayoutKingRight.ResumeLayout(false);
            this.FlowLayoutPanelGallery.ResumeLayout(false);
            this.PanelGalleryContainer.ResumeLayout(false);
            this.flowLayoutPanelGalleryTabs.ResumeLayout(false);
            this.flowLayoutPanelGalleryTabs.PerformLayout();
            this.LayoutGalleryPage.ResumeLayout(false);
            this.LayoutGalleryPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList ImgListGallery;
        private System.Windows.Forms.ImageList ImgListExtract;
        private System.Windows.Forms.TableLayoutPanel LayoutStartMenu;
        private System.Windows.Forms.Button ButtonStartKing;
        private System.Windows.Forms.Button ButtonStartWotr;
        private System.Windows.Forms.Button ButtonStartRt;
        private System.Windows.Forms.Button ButtonStartPoe;
        private System.Windows.Forms.Button ButtonStartPoed;
        private System.Windows.Forms.Button ButtonStartTyr;
        private System.Windows.Forms.Button ButtonStartW3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.PictureBox PictureBoxStartKing;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.PictureBox PictureBoxStartWotr;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.PictureBox PictureBoxStartRt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel16;
        private System.Windows.Forms.PictureBox PictureBoxStartPoe;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel17;
        private System.Windows.Forms.PictureBox PictureBoxStartPoed;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel18;
        private System.Windows.Forms.PictureBox PictureBoxStartTyr;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel19;
        private System.Windows.Forms.PictureBox PictureBoxStartW3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel20;
        private System.Windows.Forms.Label LabelStartAuthor;
        private System.Windows.Forms.PictureBox PictureBoxStartOpenNM;
        private System.Windows.Forms.PictureBox PictureBoxStartOpenGitHub;
        private System.Windows.Forms.TableLayoutPanel LayoutPathPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel21;
        private System.Windows.Forms.Label LabelSelectPathBackToStart;
        private System.Windows.Forms.Label LabelSelectPathNextToMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel22;
        private System.Windows.Forms.Label LabelSelectPathResetPath;
        private System.Windows.Forms.Label LabelSelectPathChoosePath;
        private System.Windows.Forms.Label LabelSelectPathTitle;
        private System.Windows.Forms.Label LabelSelectPathExplain;
        private System.Windows.Forms.Label LabelSelectPathSelected;
        private System.Windows.Forms.TableLayoutPanel LayoutMainPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel23;
        private System.Windows.Forms.Label LabelCreatePortrait;
        private System.Windows.Forms.Label LabelExtract;
        private System.Windows.Forms.Label LabelBrowse;
        private System.Windows.Forms.Label LabelSettingsPage;
        private System.Windows.Forms.Label LabelExit;
        private System.Windows.Forms.TableLayoutPanel LayoutKingCreatePortrait;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label LabelKingCreatePortraitLarge;
        private System.Windows.Forms.Label LabelKingCreatePortraitMedium;
        private System.Windows.Forms.Label LabelKingCreatePortraitSmall;
        private System.Windows.Forms.Label LabelKingCreatePortraitSml2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel LayoutKingPortraitGroups;
        private System.Windows.Forms.TableLayoutPanel LayoutKingPortraitGroupLarge;
        private System.Windows.Forms.TableLayoutPanel LayoutKingPortraitGroupMedium;
        private System.Windows.Forms.TableLayoutPanel LayoutKingPortraitGroupSmall;
        private System.Windows.Forms.TableLayoutPanel LayoutKingPortraitGroupSml2;
        private System.Windows.Forms.TableLayoutPanel LayoutKingRight;
        private System.Windows.Forms.Button ButtonKingCreateNewPortrait;
        private System.Windows.Forms.Button ButtonKingBackToPathfinder;
        private System.Windows.Forms.Label LabelKingGroupLargeTitle;
        private System.Windows.Forms.Label LabelKingGroupMediumTitle;
        private System.Windows.Forms.Label LabelKingGroupSmallTitle;
        private System.Windows.Forms.Label LabelKingGroupSml2Title;
        // private System.Windows.Forms.Label LabelKingCreatePortraitActiveGroup; // removed
        private System.Windows.Forms.Panel PanelKingLrg;
        private System.Windows.Forms.PictureBox PicKingLrg;
        private System.Windows.Forms.TableLayoutPanel PanelKingLrgButtons;
        private System.Windows.Forms.Button ButtonKingLrgWeb;
        private System.Windows.Forms.Button ButtonKingLrgLocal;
        private System.Windows.Forms.Button ButtonKingLrgZoomIn;
        private System.Windows.Forms.Button ButtonKingLrgZoomOut;
        private System.Windows.Forms.Button ButtonKingLrgZoomReset;
        private System.Windows.Forms.Label LabelKingLrgHint;

        private System.Windows.Forms.Panel PanelKingMed;
        private System.Windows.Forms.PictureBox PicKingMed;
        private System.Windows.Forms.TableLayoutPanel PanelKingMedButtons;
        private System.Windows.Forms.Button ButtonKingMedWeb;
        private System.Windows.Forms.Button ButtonKingMedLocal;
        private System.Windows.Forms.Button ButtonKingMedZoomIn;
        private System.Windows.Forms.Button ButtonKingMedZoomOut;
        private System.Windows.Forms.Button ButtonKingMedZoomReset;
        private System.Windows.Forms.Label LabelKingMedHint;

        private System.Windows.Forms.Panel PanelKingSml;
        private System.Windows.Forms.PictureBox PicKingSml;
        private System.Windows.Forms.TableLayoutPanel PanelKingSmlButtons;
        private System.Windows.Forms.Button ButtonKingSmlWeb;
        private System.Windows.Forms.Button ButtonKingSmlLocal;
        private System.Windows.Forms.Button ButtonKingSmlZoomIn;
        private System.Windows.Forms.Button ButtonKingSmlZoomOut;
        private System.Windows.Forms.Button ButtonKingSmlZoomReset;
        private System.Windows.Forms.Label LabelKingSmlHint;

        private System.Windows.Forms.Panel PanelKingSml2;
        private System.Windows.Forms.PictureBox PicKingSml2;
        private System.Windows.Forms.TableLayoutPanel PanelKingSml2Buttons;
        private System.Windows.Forms.Button ButtonKingSml2Web;
        private System.Windows.Forms.Button ButtonKingSml2Local;
        private System.Windows.Forms.Button ButtonKingSml2ZoomIn;
        private System.Windows.Forms.Button ButtonKingSml2ZoomOut;
        private System.Windows.Forms.Button ButtonKingSml2ZoomReset;
        private System.Windows.Forms.Label LabelKingSml2Hint;

        private System.Windows.Forms.TableLayoutPanel LayoutExtractPage;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelExtract;
        private System.Windows.Forms.Panel PanelExtractOverlay;
        private System.Windows.Forms.Panel PanelExtractContainer;
        private System.Windows.Forms.Button ButtonExtractAll;
        private System.Windows.Forms.Button ButtonExtractSelected;
        private System.Windows.Forms.Button ButtonExtractBack;
        private System.Windows.Forms.Button ButtonExtractShowFolder;
        private System.Windows.Forms.TableLayoutPanel LayoutExtractRight;
        private System.Windows.Forms.Label LabelExtractCounter;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelExtractBottom;
        private System.Windows.Forms.Label LabelExtractClearSelection;
        private System.Windows.Forms.TableLayoutPanel LayoutGalleryPage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelGalleryTabs;
        private System.Windows.Forms.Label LabelGalleryTab;
        private System.Windows.Forms.Panel PanelGalleryContainer;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelGallery;
        private System.Windows.Forms.TableLayoutPanel LayoutGalleryRight;
        private System.Windows.Forms.Button ButtonGalleryBack;
        private System.Windows.Forms.Button ButtonGalleryClone;
        private System.Windows.Forms.Button ButtonGalleryChange;
        private System.Windows.Forms.Button ButtonGalleryDelete;
    }
}

