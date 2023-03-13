
using System.Drawing.Text;

namespace PathfinderPortraitManager
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
            this.ButtonToMainPage = new System.Windows.Forms.Button();
            this.ButtonHintOnFilePage = new System.Windows.Forms.Button();
            this.LayoutUnnamed5 = new System.Windows.Forms.TableLayoutPanel();
            this.PanelPortraitTemp = new System.Windows.Forms.Panel();
            this.PicPortraitTemp = new System.Windows.Forms.PictureBox();
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
            this.ButtonBackToFilePage = new System.Windows.Forms.Button();
            this.ButtonCreatePortrait = new System.Windows.Forms.Button();
            this.LayoutUnnamed4 = new System.Windows.Forms.TableLayoutPanel();
            this.LabelUnnamed1 = new System.Windows.Forms.Label();
            this.LabelUnnamed2 = new System.Windows.Forms.Label();
            this.LabelUnnamed3 = new System.Windows.Forms.Label();
            this.LayoutUnnamed6 = new System.Windows.Forms.TableLayoutPanel();
            this.LayoutMainPage = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonToFilePage = new System.Windows.Forms.Button();
            this.ButtonExtract = new System.Windows.Forms.Button();
            this.ButtonToGalleryPage = new System.Windows.Forms.Button();
            this.ButtonExit = new System.Windows.Forms.Button();
            this.PicTitle = new System.Windows.Forms.PictureBox();
            this.LabelCopyright = new System.Windows.Forms.Label();
            this.LayoutExtractPage = new System.Windows.Forms.TableLayoutPanel();
            this.LayoutUnnamed7 = new System.Windows.Forms.TableLayoutPanel();
            this.LayoutUnnamed8 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonToMainPage2 = new System.Windows.Forms.Button();
            this.ButtonFolderExtract = new System.Windows.Forms.Button();
            this.ButtonFolderChoose = new System.Windows.Forms.Button();
            this.TextEditFolderPath = new System.Windows.Forms.TextBox();
            this.PictureUnnamed3 = new System.Windows.Forms.PictureBox();
            this.ButtonHintOnExtractPage = new System.Windows.Forms.Button();
            this.LayoutUnnamed10 = new System.Windows.Forms.TableLayoutPanel();
            this.ListGallery = new System.Windows.Forms.ListView();
            this.ImgListGallery = new System.Windows.Forms.ImageList(this.components);
            this.LayoutUnnamed11 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonToMainPage3 = new System.Windows.Forms.Button();
            this.ButtonOpenFolder = new System.Windows.Forms.Button();
            this.ButtonDeletePortait = new System.Windows.Forms.Button();
            this.ButtonChange = new System.Windows.Forms.Button();
            this.ButtonHintFolder = new System.Windows.Forms.Button();
            this.LayoutGallery = new System.Windows.Forms.TableLayoutPanel();
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
            ((System.ComponentModel.ISupportInitialize)(this.PicTitle)).BeginInit();
            this.LayoutExtractPage.SuspendLayout();
            this.LayoutUnnamed7.SuspendLayout();
            this.LayoutUnnamed8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureUnnamed3)).BeginInit();
            this.LayoutUnnamed10.SuspendLayout();
            this.LayoutUnnamed11.SuspendLayout();
            this.LayoutGallery.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutFilePage
            // 
            this.LayoutFilePage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(28)))), ((int)(((byte)(11)))));
            this.LayoutFilePage.ColumnCount = 3;
            this.LayoutFilePage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.LayoutFilePage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.45454F));
            this.LayoutFilePage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.45454F));
            this.LayoutFilePage.Controls.Add(this.LayoutUnnamed1, 2, 0);
            this.LayoutFilePage.Controls.Add(this.LayoutUnnamed5, 1, 0);
            this.LayoutFilePage.ForeColor = System.Drawing.Color.White;
            this.LayoutFilePage.Location = new System.Drawing.Point(43, 199);
            this.LayoutFilePage.Name = "LayoutFilePage";
            this.LayoutFilePage.RowCount = 1;
            this.LayoutFilePage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutFilePage.Size = new System.Drawing.Size(466, 285);
            this.LayoutFilePage.TabIndex = 1;
            // 
            // LayoutUnnamed1
            // 
            this.LayoutUnnamed1.ColumnCount = 3;
            this.LayoutUnnamed1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutUnnamed1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.LayoutUnnamed1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutUnnamed1.Controls.Add(this.ButtonLocalPortraitLoad, 1, 1);
            this.LayoutUnnamed1.Controls.Add(this.ButtonToScalePage, 1, 4);
            this.LayoutUnnamed1.Controls.Add(this.ButtonWebPortraitLoad, 1, 2);
            this.LayoutUnnamed1.Controls.Add(this.ButtonToMainPage, 1, 5);
            this.LayoutUnnamed1.Controls.Add(this.ButtonHintOnFilePage, 1, 6);
            this.LayoutUnnamed1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutUnnamed1.Location = new System.Drawing.Point(256, 3);
            this.LayoutUnnamed1.Name = "LayoutUnnamed1";
            this.LayoutUnnamed1.RowCount = 8;
            this.LayoutUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.16436F));
            this.LayoutUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.66107F));
            this.LayoutUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.17457F));
            this.LayoutUnnamed1.Size = new System.Drawing.Size(207, 279);
            this.LayoutUnnamed1.TabIndex = 0;
            // 
            // ButtonLocalPortraitLoad
            // 
            this.ButtonLocalPortraitLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonLocalPortraitLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonLocalPortraitLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonLocalPortraitLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonLocalPortraitLoad.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonLocalPortraitLoad.Location = new System.Drawing.Point(19, 25);
            this.ButtonLocalPortraitLoad.Name = "ButtonLocalPortraitLoad";
            this.ButtonLocalPortraitLoad.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ButtonLocalPortraitLoad.Size = new System.Drawing.Size(169, 39);
            this.ButtonLocalPortraitLoad.TabIndex = 2;
            this.ButtonLocalPortraitLoad.Text = "Choose local";
            this.ButtonLocalPortraitLoad.UseVisualStyleBackColor = true;
            this.ButtonLocalPortraitLoad.Click += new System.EventHandler(this.ButtonLocalPortraitLoad_Click);
            // 
            // ButtonToScalePage
            // 
            this.ButtonToScalePage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonToScalePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonToScalePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonToScalePage.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonToScalePage.Location = new System.Drawing.Point(19, 123);
            this.ButtonToScalePage.Name = "ButtonToScalePage";
            this.ButtonToScalePage.Size = new System.Drawing.Size(169, 39);
            this.ButtonToScalePage.TabIndex = 1;
            this.ButtonToScalePage.Text = "Next";
            this.ButtonToScalePage.UseVisualStyleBackColor = true;
            this.ButtonToScalePage.Click += new System.EventHandler(this.ButtonToScalePage_Click);
            // 
            // ButtonWebPortraitLoad
            // 
            this.ButtonWebPortraitLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonWebPortraitLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonWebPortraitLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonWebPortraitLoad.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonWebPortraitLoad.Location = new System.Drawing.Point(19, 70);
            this.ButtonWebPortraitLoad.Name = "ButtonWebPortraitLoad";
            this.ButtonWebPortraitLoad.Size = new System.Drawing.Size(169, 39);
            this.ButtonWebPortraitLoad.TabIndex = 3;
            this.ButtonWebPortraitLoad.Text = "Choose web";
            this.ButtonWebPortraitLoad.UseVisualStyleBackColor = true;
            this.ButtonWebPortraitLoad.Click += new System.EventHandler(this.ButtonWebPortraitLoad_Click);
            // 
            // ButtonToMainPage
            // 
            this.ButtonToMainPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonToMainPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonToMainPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonToMainPage.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonToMainPage.Location = new System.Drawing.Point(19, 168);
            this.ButtonToMainPage.Name = "ButtonToMainPage";
            this.ButtonToMainPage.Size = new System.Drawing.Size(169, 39);
            this.ButtonToMainPage.TabIndex = 0;
            this.ButtonToMainPage.Text = "Back";
            this.ButtonToMainPage.UseVisualStyleBackColor = true;
            this.ButtonToMainPage.Click += new System.EventHandler(this.ButtonToMainPage_Click);
            // 
            // ButtonHintOnFilePage
            // 
            this.ButtonHintOnFilePage.Cursor = System.Windows.Forms.Cursors.Help;
            this.ButtonHintOnFilePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonHintOnFilePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonHintOnFilePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonHintOnFilePage.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonHintOnFilePage.Location = new System.Drawing.Point(19, 213);
            this.ButtonHintOnFilePage.Name = "ButtonHintOnFilePage";
            this.ButtonHintOnFilePage.Size = new System.Drawing.Size(169, 39);
            this.ButtonHintOnFilePage.TabIndex = 6;
            this.ButtonHintOnFilePage.Text = "?";
            this.ButtonHintOnFilePage.UseVisualStyleBackColor = true;
            this.ButtonHintOnFilePage.Click += new System.EventHandler(this.ButtonHintOnFilePage_Click);
            // 
            // LayoutUnnamed5
            // 
            this.LayoutUnnamed5.ColumnCount = 1;
            this.LayoutUnnamed5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutUnnamed5.Controls.Add(this.PanelPortraitTemp, 0, 1);
            this.LayoutUnnamed5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutUnnamed5.Location = new System.Drawing.Point(45, 3);
            this.LayoutUnnamed5.Name = "LayoutUnnamed5";
            this.LayoutUnnamed5.RowCount = 3;
            this.LayoutUnnamed5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.LayoutUnnamed5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.33334F));
            this.LayoutUnnamed5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.LayoutUnnamed5.Size = new System.Drawing.Size(205, 279);
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
            this.PanelPortraitTemp.Size = new System.Drawing.Size(205, 232);
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
            // LayoutScalePage
            // 
            this.LayoutScalePage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(28)))), ((int)(((byte)(11)))));
            this.LayoutScalePage.ColumnCount = 1;
            this.LayoutScalePage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutScalePage.Controls.Add(this.LayoutUnnamed2, 0, 1);
            this.LayoutScalePage.Controls.Add(this.LayoutUnnamed3, 0, 3);
            this.LayoutScalePage.Controls.Add(this.LayoutUnnamed4, 0, 2);
            this.LayoutScalePage.Controls.Add(this.LayoutUnnamed6, 0, 0);
            this.LayoutScalePage.ForeColor = System.Drawing.Color.White;
            this.LayoutScalePage.Location = new System.Drawing.Point(515, 132);
            this.LayoutScalePage.Name = "LayoutScalePage";
            this.LayoutScalePage.RowCount = 5;
            this.LayoutScalePage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.92792F));
            this.LayoutScalePage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.73881F));
            this.LayoutScalePage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.LayoutScalePage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.LayoutScalePage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.333276F));
            this.LayoutScalePage.Size = new System.Drawing.Size(268, 245);
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
            this.LayoutUnnamed2.Location = new System.Drawing.Point(3, 18);
            this.LayoutUnnamed2.Name = "LayoutUnnamed2";
            this.LayoutUnnamed2.RowCount = 1;
            this.LayoutUnnamed2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutUnnamed2.Size = new System.Drawing.Size(262, 115);
            this.LayoutUnnamed2.TabIndex = 0;
            // 
            // PanelPortraitLrg
            // 
            this.PanelPortraitLrg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelPortraitLrg.Controls.Add(this.PicPortraitLrg);
            this.PanelPortraitLrg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelPortraitLrg.Location = new System.Drawing.Point(91, 3);
            this.PanelPortraitLrg.Name = "PanelPortraitLrg";
            this.PanelPortraitLrg.Padding = new System.Windows.Forms.Padding(10);
            this.PanelPortraitLrg.Size = new System.Drawing.Size(77, 109);
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
            this.PanelPortraitMed.Location = new System.Drawing.Point(15, 3);
            this.PanelPortraitMed.Name = "PanelPortraitMed";
            this.PanelPortraitMed.Padding = new System.Windows.Forms.Padding(10);
            this.PanelPortraitMed.Size = new System.Drawing.Size(70, 109);
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
            this.PanelPortraitSml.Location = new System.Drawing.Point(174, 3);
            this.PanelPortraitSml.Name = "PanelPortraitSml";
            this.PanelPortraitSml.Padding = new System.Windows.Forms.Padding(10);
            this.PanelPortraitSml.Size = new System.Drawing.Size(70, 109);
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
            this.LayoutUnnamed3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.08007F));
            this.LayoutUnnamed3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.LayoutUnnamed3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.802885F));
            this.LayoutUnnamed3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.LayoutUnnamed3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.857336F));
            this.LayoutUnnamed3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.71467F));
            this.LayoutUnnamed3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.54503F));
            this.LayoutUnnamed3.Controls.Add(this.ButtonHintOnScalePage, 5, 0);
            this.LayoutUnnamed3.Controls.Add(this.ButtonBackToFilePage, 1, 0);
            this.LayoutUnnamed3.Controls.Add(this.ButtonCreatePortrait, 3, 0);
            this.LayoutUnnamed3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutUnnamed3.Location = new System.Drawing.Point(3, 189);
            this.LayoutUnnamed3.Name = "LayoutUnnamed3";
            this.LayoutUnnamed3.RowCount = 1;
            this.LayoutUnnamed3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutUnnamed3.Size = new System.Drawing.Size(262, 44);
            this.LayoutUnnamed3.TabIndex = 1;
            // 
            // ButtonHintOnScalePage
            // 
            this.ButtonHintOnScalePage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonHintOnScalePage.Cursor = System.Windows.Forms.Cursors.Help;
            this.ButtonHintOnScalePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonHintOnScalePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonHintOnScalePage.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonHintOnScalePage.Location = new System.Drawing.Point(263, 3);
            this.ButtonHintOnScalePage.Name = "ButtonHintOnScalePage";
            this.ButtonHintOnScalePage.Size = new System.Drawing.Size(1, 38);
            this.ButtonHintOnScalePage.TabIndex = 0;
            this.ButtonHintOnScalePage.Text = "?";
            this.ButtonHintOnScalePage.UseVisualStyleBackColor = true;
            this.ButtonHintOnScalePage.Click += new System.EventHandler(this.ButtonHintOnScalePage_Click);
            // 
            // ButtonBackToFilePage
            // 
            this.ButtonBackToFilePage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonBackToFilePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonBackToFilePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonBackToFilePage.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonBackToFilePage.Location = new System.Drawing.Point(3, 3);
            this.ButtonBackToFilePage.Name = "ButtonBackToFilePage";
            this.ButtonBackToFilePage.Size = new System.Drawing.Size(124, 38);
            this.ButtonBackToFilePage.TabIndex = 0;
            this.ButtonBackToFilePage.Text = "Back";
            this.ButtonBackToFilePage.UseVisualStyleBackColor = true;
            this.ButtonBackToFilePage.Click += new System.EventHandler(this.ButtonBackToFilePage_Click);
            // 
            // ButtonCreatePortrait
            // 
            this.ButtonCreatePortrait.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonCreatePortrait.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonCreatePortrait.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonCreatePortrait.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonCreatePortrait.Location = new System.Drawing.Point(133, 3);
            this.ButtonCreatePortrait.Name = "ButtonCreatePortrait";
            this.ButtonCreatePortrait.Size = new System.Drawing.Size(124, 38);
            this.ButtonCreatePortrait.TabIndex = 2;
            this.ButtonCreatePortrait.Text = "Create";
            this.ButtonCreatePortrait.UseVisualStyleBackColor = true;
            this.ButtonCreatePortrait.Click += new System.EventHandler(this.ButtonCreatePortrait_Click);
            // 
            // LayoutUnnamed4
            // 
            this.LayoutUnnamed4.ColumnCount = 5;
            this.LayoutUnnamed4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.627249F));
            this.LayoutUnnamed4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.38005F));
            this.LayoutUnnamed4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.67116F));
            this.LayoutUnnamed4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.11051F));
            this.LayoutUnnamed4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.9922F));
            this.LayoutUnnamed4.Controls.Add(this.LabelUnnamed1, 1, 0);
            this.LayoutUnnamed4.Controls.Add(this.LabelUnnamed2, 2, 0);
            this.LayoutUnnamed4.Controls.Add(this.LabelUnnamed3, 3, 0);
            this.LayoutUnnamed4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutUnnamed4.Location = new System.Drawing.Point(3, 139);
            this.LayoutUnnamed4.Name = "LayoutUnnamed4";
            this.LayoutUnnamed4.RowCount = 1;
            this.LayoutUnnamed4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutUnnamed4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.LayoutUnnamed4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.LayoutUnnamed4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.LayoutUnnamed4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.LayoutUnnamed4.Size = new System.Drawing.Size(262, 44);
            this.LayoutUnnamed4.TabIndex = 2;
            // 
            // LabelUnnamed1
            // 
            this.LabelUnnamed1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelUnnamed1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LabelUnnamed1.ForeColor = System.Drawing.Color.Goldenrod;
            this.LabelUnnamed1.Location = new System.Drawing.Point(15, 0);
            this.LabelUnnamed1.Name = "LabelUnnamed1";
            this.LabelUnnamed1.Size = new System.Drawing.Size(71, 44);
            this.LabelUnnamed1.TabIndex = 0;
            this.LabelUnnamed1.Text = "Medium";
            this.LabelUnnamed1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelUnnamed1.MouseLeave += new System.EventHandler(this.LblUnnamed1_MouseLeave);
            this.LabelUnnamed1.MouseHover += new System.EventHandler(this.LblUnnamed1_MouseHover);
            // 
            // LabelUnnamed2
            // 
            this.LabelUnnamed2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelUnnamed2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LabelUnnamed2.ForeColor = System.Drawing.Color.Goldenrod;
            this.LabelUnnamed2.Location = new System.Drawing.Point(92, 0);
            this.LabelUnnamed2.Name = "LabelUnnamed2";
            this.LabelUnnamed2.Size = new System.Drawing.Size(77, 44);
            this.LabelUnnamed2.TabIndex = 1;
            this.LabelUnnamed2.Text = "Large";
            this.LabelUnnamed2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelUnnamed2.MouseLeave += new System.EventHandler(this.LblUnnamed2_MouseLeave);
            this.LabelUnnamed2.MouseHover += new System.EventHandler(this.LblUnnamed2_MouseHover);
            // 
            // LabelUnnamed3
            // 
            this.LabelUnnamed3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelUnnamed3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LabelUnnamed3.ForeColor = System.Drawing.Color.Goldenrod;
            this.LabelUnnamed3.Location = new System.Drawing.Point(175, 0);
            this.LabelUnnamed3.Name = "LabelUnnamed3";
            this.LabelUnnamed3.Size = new System.Drawing.Size(70, 44);
            this.LabelUnnamed3.TabIndex = 2;
            this.LabelUnnamed3.Text = "Small";
            this.LabelUnnamed3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelUnnamed3.MouseLeave += new System.EventHandler(this.LblUnnamed3_MouseLeave);
            this.LabelUnnamed3.MouseHover += new System.EventHandler(this.LblUnnamed3_MouseHover);
            // 
            // LayoutUnnamed6
            // 
            this.LayoutUnnamed6.ColumnCount = 3;
            this.LayoutUnnamed6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.99669F));
            this.LayoutUnnamed6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.00663F));
            this.LayoutUnnamed6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.16252F));
            this.LayoutUnnamed6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutUnnamed6.Location = new System.Drawing.Point(3, 3);
            this.LayoutUnnamed6.Name = "LayoutUnnamed6";
            this.LayoutUnnamed6.RowCount = 1;
            this.LayoutUnnamed6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutUnnamed6.Size = new System.Drawing.Size(262, 9);
            this.LayoutUnnamed6.TabIndex = 3;
            // 
            // LayoutMainPage
            // 
            this.LayoutMainPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(28)))), ((int)(((byte)(11)))));
            this.LayoutMainPage.BackgroundImage = global::PathfinderPortraitManager.Properties.Resources.bg_path;
            this.LayoutMainPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LayoutMainPage.ColumnCount = 3;
            this.LayoutMainPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutMainPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.LayoutMainPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutMainPage.Controls.Add(this.ButtonToFilePage, 1, 2);
            this.LayoutMainPage.Controls.Add(this.ButtonExtract, 1, 3);
            this.LayoutMainPage.Controls.Add(this.ButtonToGalleryPage, 1, 4);
            this.LayoutMainPage.Controls.Add(this.ButtonExit, 1, 5);
            this.LayoutMainPage.Controls.Add(this.PicTitle, 1, 1);
            this.LayoutMainPage.Controls.Add(this.LabelCopyright, 1, 6);
            this.LayoutMainPage.Location = new System.Drawing.Point(226, 25);
            this.LayoutMainPage.Name = "LayoutMainPage";
            this.LayoutMainPage.RowCount = 7;
            this.LayoutMainPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.LayoutMainPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.LayoutMainPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutMainPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutMainPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutMainPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.LayoutMainPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.LayoutMainPage.Size = new System.Drawing.Size(157, 100);
            this.LayoutMainPage.TabIndex = 0;
            // 
            // ButtonToFilePage
            // 
            this.ButtonToFilePage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonToFilePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonToFilePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonToFilePage.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonToFilePage.Location = new System.Drawing.Point(-68, 39);
            this.ButtonToFilePage.Name = "ButtonToFilePage";
            this.ButtonToFilePage.Size = new System.Drawing.Size(294, 39);
            this.ButtonToFilePage.TabIndex = 0;
            this.ButtonToFilePage.Text = "Create portrait";
            this.ButtonToFilePage.UseVisualStyleBackColor = true;
            this.ButtonToFilePage.Click += new System.EventHandler(this.ButtonToFilePage_Click);
            // 
            // ButtonExtract
            // 
            this.ButtonExtract.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonExtract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonExtract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonExtract.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonExtract.Location = new System.Drawing.Point(-68, 84);
            this.ButtonExtract.Name = "ButtonExtract";
            this.ButtonExtract.Size = new System.Drawing.Size(294, 39);
            this.ButtonExtract.TabIndex = 3;
            this.ButtonExtract.Text = "Extract folder";
            this.ButtonExtract.UseVisualStyleBackColor = true;
            this.ButtonExtract.Click += new System.EventHandler(this.ButtonToExtract_Click);
            // 
            // ButtonToGalleryPage
            // 
            this.ButtonToGalleryPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonToGalleryPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonToGalleryPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonToGalleryPage.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonToGalleryPage.Location = new System.Drawing.Point(-68, 129);
            this.ButtonToGalleryPage.Name = "ButtonToGalleryPage";
            this.ButtonToGalleryPage.Size = new System.Drawing.Size(294, 39);
            this.ButtonToGalleryPage.TabIndex = 2;
            this.ButtonToGalleryPage.Text = "Browse gallery";
            this.ButtonToGalleryPage.UseVisualStyleBackColor = true;
            this.ButtonToGalleryPage.Click += new System.EventHandler(this.ButtonToGalleryPage_Click);
            // 
            // ButtonExit
            // 
            this.ButtonExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonExit.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonExit.Location = new System.Drawing.Point(-68, 174);
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.Size = new System.Drawing.Size(294, 39);
            this.ButtonExit.TabIndex = 1;
            this.ButtonExit.Text = "Exit";
            this.ButtonExit.UseVisualStyleBackColor = true;
            this.ButtonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // PicTitle
            // 
            this.PicTitle.BackColor = System.Drawing.Color.Transparent;
            this.PicTitle.BackgroundImage = global::PathfinderPortraitManager.Properties.Resources.title_path;
            this.PicTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PicTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicTitle.Location = new System.Drawing.Point(-68, -111);
            this.PicTitle.Name = "PicTitle";
            this.PicTitle.Size = new System.Drawing.Size(294, 144);
            this.PicTitle.TabIndex = 4;
            this.PicTitle.TabStop = false;
            this.PicTitle.Click += new System.EventHandler(this.PicTitle_Click);
            // 
            // LabelCopyright
            // 
            this.LabelCopyright.AutoSize = true;
            this.LabelCopyright.BackColor = System.Drawing.Color.Transparent;
            this.LabelCopyright.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LabelCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelCopyright.ForeColor = System.Drawing.Color.Goldenrod;
            this.LabelCopyright.Location = new System.Drawing.Point(-68, 216);
            this.LabelCopyright.Name = "LabelCopyright";
            this.LabelCopyright.Size = new System.Drawing.Size(294, 1);
            this.LabelCopyright.TabIndex = 5;
            this.LabelCopyright.Text = "Artemii \"Zeight\" Saganenko© 2023";
            this.LabelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LayoutExtractPage
            // 
            this.LayoutExtractPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(28)))), ((int)(((byte)(11)))));
            this.LayoutExtractPage.ColumnCount = 1;
            this.LayoutExtractPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutExtractPage.Controls.Add(this.LayoutUnnamed7, 0, 0);
            this.LayoutExtractPage.Enabled = false;
            this.LayoutExtractPage.ForeColor = System.Drawing.Color.White;
            this.LayoutExtractPage.Location = new System.Drawing.Point(12, 12);
            this.LayoutExtractPage.Name = "LayoutExtractPage";
            this.LayoutExtractPage.RowCount = 1;
            this.LayoutExtractPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutExtractPage.Size = new System.Drawing.Size(283, 168);
            this.LayoutExtractPage.TabIndex = 3;
            this.LayoutExtractPage.Visible = false;
            // 
            // LayoutUnnamed7
            // 
            this.LayoutUnnamed7.ColumnCount = 3;
            this.LayoutUnnamed7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.LayoutUnnamed7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.45454F));
            this.LayoutUnnamed7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.45455F));
            this.LayoutUnnamed7.Controls.Add(this.LayoutUnnamed8, 2, 1);
            this.LayoutUnnamed7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutUnnamed7.Location = new System.Drawing.Point(3, 3);
            this.LayoutUnnamed7.Name = "LayoutUnnamed7";
            this.LayoutUnnamed7.RowCount = 3;
            this.LayoutUnnamed7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.LayoutUnnamed7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.33334F));
            this.LayoutUnnamed7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.LayoutUnnamed7.Size = new System.Drawing.Size(277, 162);
            this.LayoutUnnamed7.TabIndex = 0;
            // 
            // LayoutUnnamed8
            // 
            this.LayoutUnnamed8.ColumnCount = 3;
            this.LayoutUnnamed8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.57022F));
            this.LayoutUnnamed8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.01043F));
            this.LayoutUnnamed8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.41935F));
            this.LayoutUnnamed8.Controls.Add(this.ButtonToMainPage2, 1, 6);
            this.LayoutUnnamed8.Controls.Add(this.ButtonFolderExtract, 1, 4);
            this.LayoutUnnamed8.Controls.Add(this.ButtonFolderChoose, 1, 3);
            this.LayoutUnnamed8.Controls.Add(this.TextEditFolderPath, 1, 2);
            this.LayoutUnnamed8.Controls.Add(this.PictureUnnamed3, 1, 1);
            this.LayoutUnnamed8.Controls.Add(this.ButtonHintOnExtractPage, 1, 7);
            this.LayoutUnnamed8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutUnnamed8.Location = new System.Drawing.Point(153, 16);
            this.LayoutUnnamed8.Name = "LayoutUnnamed8";
            this.LayoutUnnamed8.RowCount = 9;
            this.LayoutUnnamed8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.078588F));
            this.LayoutUnnamed8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.LayoutUnnamed8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.585858F));
            this.LayoutUnnamed8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.48323F));
            this.LayoutUnnamed8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.48323F));
            this.LayoutUnnamed8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.942966F));
            this.LayoutUnnamed8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.48289F));
            this.LayoutUnnamed8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.4829F));
            this.LayoutUnnamed8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.078588F));
            this.LayoutUnnamed8.Size = new System.Drawing.Size(121, 129);
            this.LayoutUnnamed8.TabIndex = 0;
            // 
            // ButtonToMainPage2
            // 
            this.ButtonToMainPage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonToMainPage2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonToMainPage2.Font = new System.Drawing.Font("Bebas Neue", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonToMainPage2.Location = new System.Drawing.Point(24, 86);
            this.ButtonToMainPage2.Name = "ButtonToMainPage2";
            this.ButtonToMainPage2.Size = new System.Drawing.Size(70, 11);
            this.ButtonToMainPage2.TabIndex = 2;
            this.ButtonToMainPage2.Text = "Back";
            this.ButtonToMainPage2.UseVisualStyleBackColor = true;
            this.ButtonToMainPage2.Click += new System.EventHandler(this.ButtonToMainPage2_Click);
            // 
            // ButtonFolderExtract
            // 
            this.ButtonFolderExtract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonFolderExtract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonFolderExtract.Font = new System.Drawing.Font("Bebas Neue", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonFolderExtract.Location = new System.Drawing.Point(24, 63);
            this.ButtonFolderExtract.Name = "ButtonFolderExtract";
            this.ButtonFolderExtract.Size = new System.Drawing.Size(70, 11);
            this.ButtonFolderExtract.TabIndex = 1;
            this.ButtonFolderExtract.Text = "Extract";
            this.ButtonFolderExtract.UseVisualStyleBackColor = true;
            this.ButtonFolderExtract.Click += new System.EventHandler(this.ButtonFolderExtract_Click);
            // 
            // ButtonFolderChoose
            // 
            this.ButtonFolderChoose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonFolderChoose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonFolderChoose.Font = new System.Drawing.Font("Bebas Neue", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonFolderChoose.Location = new System.Drawing.Point(24, 46);
            this.ButtonFolderChoose.Name = "ButtonFolderChoose";
            this.ButtonFolderChoose.Size = new System.Drawing.Size(70, 11);
            this.ButtonFolderChoose.TabIndex = 0;
            this.ButtonFolderChoose.Text = "Choose folder";
            this.ButtonFolderChoose.UseVisualStyleBackColor = true;
            this.ButtonFolderChoose.Click += new System.EventHandler(this.ButtonFolderChoose_Click);
            // 
            // TextEditFolderPath
            // 
            this.TextEditFolderPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(28)))), ((int)(((byte)(11)))));
            this.TextEditFolderPath.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TextEditFolderPath.Font = new System.Drawing.Font("Bebas Neue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextEditFolderPath.Location = new System.Drawing.Point(24, 35);
            this.TextEditFolderPath.Name = "TextEditFolderPath";
            this.TextEditFolderPath.Size = new System.Drawing.Size(70, 27);
            this.TextEditFolderPath.TabIndex = 3;
            // 
            // PictureUnnamed3
            // 
            this.PictureUnnamed3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureUnnamed3.Location = new System.Drawing.Point(38, 26);
            this.PictureUnnamed3.Margin = new System.Windows.Forms.Padding(17);
            this.PictureUnnamed3.Name = "PictureUnnamed3";
            this.PictureUnnamed3.Size = new System.Drawing.Size(42, 1);
            this.PictureUnnamed3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureUnnamed3.TabIndex = 5;
            this.PictureUnnamed3.TabStop = false;
            // 
            // ButtonHintOnExtractPage
            // 
            this.ButtonHintOnExtractPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonHintOnExtractPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonHintOnExtractPage.Font = new System.Drawing.Font("Bebas Neue", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonHintOnExtractPage.Location = new System.Drawing.Point(24, 103);
            this.ButtonHintOnExtractPage.Name = "ButtonHintOnExtractPage";
            this.ButtonHintOnExtractPage.Size = new System.Drawing.Size(70, 11);
            this.ButtonHintOnExtractPage.TabIndex = 6;
            this.ButtonHintOnExtractPage.Text = "?";
            this.ButtonHintOnExtractPage.UseVisualStyleBackColor = true;
            this.ButtonHintOnExtractPage.Click += new System.EventHandler(this.ButtonHintOnExtractPage_Click);
            // 
            // LayoutUnnamed10
            // 
            this.LayoutUnnamed10.ColumnCount = 5;
            this.LayoutUnnamed10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.349733F));
            this.LayoutUnnamed10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.59222F));
            this.LayoutUnnamed10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.029025F));
            this.LayoutUnnamed10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.LayoutUnnamed10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.029025F));
            this.LayoutUnnamed10.Controls.Add(this.ListGallery, 1, 0);
            this.LayoutUnnamed10.Controls.Add(this.LayoutUnnamed11, 3, 0);
            this.LayoutUnnamed10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutUnnamed10.Location = new System.Drawing.Point(3, 56);
            this.LayoutUnnamed10.Name = "LayoutUnnamed10";
            this.LayoutUnnamed10.RowCount = 1;
            this.LayoutUnnamed10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutUnnamed10.Size = new System.Drawing.Size(843, 501);
            this.LayoutUnnamed10.TabIndex = 0;
            // 
            // ListGallery
            // 
            this.ListGallery.BackColor = System.Drawing.Color.Black;
            this.ListGallery.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListGallery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListGallery.ForeColor = System.Drawing.SystemColors.Control;
            this.ListGallery.HideSelection = false;
            this.ListGallery.LargeImageList = this.ImgListGallery;
            this.ListGallery.Location = new System.Drawing.Point(18, 3);
            this.ListGallery.Name = "ListGallery";
            this.ListGallery.Size = new System.Drawing.Size(557, 495);
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
            this.LayoutUnnamed11.Controls.Add(this.ButtonChange, 0, 1);
            this.LayoutUnnamed11.Controls.Add(this.ButtonHintFolder, 0, 7);
            this.LayoutUnnamed11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutUnnamed11.Location = new System.Drawing.Point(613, 3);
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
            this.LayoutUnnamed11.Size = new System.Drawing.Size(194, 495);
            this.LayoutUnnamed11.TabIndex = 0;
            // 
            // ButtonToMainPage3
            // 
            this.ButtonToMainPage3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonToMainPage3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonToMainPage3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonToMainPage3.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonToMainPage3.Location = new System.Drawing.Point(3, 318);
            this.ButtonToMainPage3.Name = "ButtonToMainPage3";
            this.ButtonToMainPage3.Size = new System.Drawing.Size(188, 39);
            this.ButtonToMainPage3.TabIndex = 0;
            this.ButtonToMainPage3.Text = "Back";
            this.ButtonToMainPage3.UseVisualStyleBackColor = true;
            this.ButtonToMainPage3.Click += new System.EventHandler(this.ButtonToMainPage3_Click);
            // 
            // ButtonOpenFolder
            // 
            this.ButtonOpenFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonOpenFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonOpenFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonOpenFolder.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonOpenFolder.Location = new System.Drawing.Point(3, 228);
            this.ButtonOpenFolder.Name = "ButtonOpenFolder";
            this.ButtonOpenFolder.Size = new System.Drawing.Size(188, 39);
            this.ButtonOpenFolder.TabIndex = 1;
            this.ButtonOpenFolder.Text = "Open folder";
            this.ButtonOpenFolder.UseVisualStyleBackColor = true;
            this.ButtonOpenFolder.Click += new System.EventHandler(this.ButtonOpenFolder_Click);
            // 
            // ButtonDeletePortait
            // 
            this.ButtonDeletePortait.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDeletePortait.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonDeletePortait.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonDeletePortait.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonDeletePortait.Location = new System.Drawing.Point(3, 138);
            this.ButtonDeletePortait.Name = "ButtonDeletePortait";
            this.ButtonDeletePortait.Size = new System.Drawing.Size(188, 39);
            this.ButtonDeletePortait.TabIndex = 2;
            this.ButtonDeletePortait.Text = "Delete";
            this.ButtonDeletePortait.UseVisualStyleBackColor = true;
            this.ButtonDeletePortait.Click += new System.EventHandler(this.ButtonDeletePortait_Click);
            // 
            // ButtonChange
            // 
            this.ButtonChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonChange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonChange.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonChange.Location = new System.Drawing.Point(3, 93);
            this.ButtonChange.Name = "ButtonChange";
            this.ButtonChange.Size = new System.Drawing.Size(188, 39);
            this.ButtonChange.TabIndex = 3;
            this.ButtonChange.Text = "Change";
            this.ButtonChange.UseVisualStyleBackColor = true;
            this.ButtonChange.Click += new System.EventHandler(this.ButtonChange_Click);
            // 
            // ButtonHintFolder
            // 
            this.ButtonHintFolder.Cursor = System.Windows.Forms.Cursors.Help;
            this.ButtonHintFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonHintFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonHintFolder.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonHintFolder.Location = new System.Drawing.Point(3, 363);
            this.ButtonHintFolder.Name = "ButtonHintFolder";
            this.ButtonHintFolder.Size = new System.Drawing.Size(188, 39);
            this.ButtonHintFolder.TabIndex = 4;
            this.ButtonHintFolder.Text = "?";
            this.ButtonHintFolder.UseVisualStyleBackColor = true;
            this.ButtonHintFolder.Click += new System.EventHandler(this.ButtonHintFolder_Click);
            // 
            // LayoutGallery
            // 
            this.LayoutGallery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(28)))), ((int)(((byte)(9)))));
            this.LayoutGallery.ColumnCount = 1;
            this.LayoutGallery.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutGallery.Controls.Add(this.LayoutUnnamed10, 0, 1);
            this.LayoutGallery.Location = new System.Drawing.Point(116, 537);
            this.LayoutGallery.Name = "LayoutGallery";
            this.LayoutGallery.RowCount = 3;
            this.LayoutGallery.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.640895F));
            this.LayoutGallery.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.71821F));
            this.LayoutGallery.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.640895F));
            this.LayoutGallery.Size = new System.Drawing.Size(849, 614);
            this.LayoutGallery.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.LayoutGallery);
            this.Controls.Add(this.LayoutMainPage);
            this.Controls.Add(this.LayoutScalePage);
            this.Controls.Add(this.LayoutFilePage);
            this.Controls.Add(this.LayoutExtractPage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(6000, 4500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 450);
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pathfinder Portrait Manager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_Closed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.LayoutFilePage.ResumeLayout(false);
            this.LayoutUnnamed1.ResumeLayout(false);
            this.LayoutUnnamed5.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)(this.PicTitle)).EndInit();
            this.LayoutExtractPage.ResumeLayout(false);
            this.LayoutUnnamed7.ResumeLayout(false);
            this.LayoutUnnamed8.ResumeLayout(false);
            this.LayoutUnnamed8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureUnnamed3)).EndInit();
            this.LayoutUnnamed10.ResumeLayout(false);
            this.LayoutUnnamed11.ResumeLayout(false);
            this.LayoutGallery.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // prime layouts
        private System.Windows.Forms.TableLayoutPanel LayoutMainPage;
        private System.Windows.Forms.TableLayoutPanel LayoutFilePage;
        private System.Windows.Forms.TableLayoutPanel LayoutScalePage;
        private System.Windows.Forms.TableLayoutPanel LayoutExtractPage;

        // aux layouts
        private System.Windows.Forms.TableLayoutPanel LayoutUnnamed1;
        private System.Windows.Forms.TableLayoutPanel LayoutUnnamed2;
        private System.Windows.Forms.TableLayoutPanel LayoutUnnamed3;
        private System.Windows.Forms.TableLayoutPanel LayoutUnnamed4;
        private System.Windows.Forms.TableLayoutPanel LayoutUnnamed5;
        private System.Windows.Forms.TableLayoutPanel LayoutUnnamed6;
        private System.Windows.Forms.TableLayoutPanel LayoutUnnamed7;
        private System.Windows.Forms.TableLayoutPanel LayoutUnnamed8;

        // buttons controlling layouts
        private System.Windows.Forms.Button ButtonToFilePage;
        private System.Windows.Forms.Button ButtonToMainPage;
        private System.Windows.Forms.Button ButtonToMainPage2;
        private System.Windows.Forms.Button ButtonToScalePage;
        private System.Windows.Forms.Button ButtonToGalleryPage;
        private System.Windows.Forms.Button ButtonBackToFilePage;

        // function buttons for Create new portrait
        private System.Windows.Forms.Button ButtonCreatePortrait;
        private System.Windows.Forms.Button ButtonLocalPortraitLoad;
        private System.Windows.Forms.Button ButtonWebPortraitLoad;
        private System.Windows.Forms.Button ButtonExit;

        // function buttons for Extract folder
        private System.Windows.Forms.Button ButtonFolderChoose;
        private System.Windows.Forms.Button ButtonFolderExtract;
        private System.Windows.Forms.Button ButtonExtract;

        // hint buttons
        private System.Windows.Forms.Button ButtonHintOnFilePage;
        private System.Windows.Forms.Button ButtonHintOnScalePage;
        private System.Windows.Forms.Button ButtonHintOnExtractPage;

        // image control for Create new portrait
        private System.Windows.Forms.PictureBox PicPortraitTemp;
        private System.Windows.Forms.PictureBox PicPortraitLrg;
        private System.Windows.Forms.PictureBox PicPortraitMed;
        private System.Windows.Forms.PictureBox PicPortraitSml;
        private System.Windows.Forms.Panel PanelPortraitLrg;
        private System.Windows.Forms.Panel PanelPortraitMed;
        private System.Windows.Forms.Panel PanelPortraitSml;
        private System.Windows.Forms.Panel PanelPortraitTemp;
        private System.Windows.Forms.PictureBox PictureUnnamed3;
        private System.Windows.Forms.Label LabelUnnamed1;
        private System.Windows.Forms.Label LabelUnnamed2;
        private System.Windows.Forms.Label LabelUnnamed3;
        private System.Windows.Forms.TextBox TextEditFolderPath;
        private System.Windows.Forms.PictureBox PicTitle;
        private System.Windows.Forms.Label LabelCopyright;
        private System.Windows.Forms.TableLayoutPanel LayoutUnnamed10;
        private System.Windows.Forms.TableLayoutPanel LayoutUnnamed11;
        private System.Windows.Forms.Button ButtonToMainPage3;
        private System.Windows.Forms.Button ButtonOpenFolder;
        private System.Windows.Forms.TableLayoutPanel LayoutGallery;
        private System.Windows.Forms.ImageList ImgListGallery;
        private System.Windows.Forms.ListView ListGallery;
        private System.Windows.Forms.Button ButtonDeletePortait;
        private System.Windows.Forms.Button ButtonChange;
        private System.Windows.Forms.Button ButtonHintFolder;
    }
}

