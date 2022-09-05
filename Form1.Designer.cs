
namespace PathfinderKINGPortrait
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
            this.LayMainForm = new System.Windows.Forms.TableLayoutPanel();
            this.btnCreateNew = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.LayCreateForm = new System.Windows.Forms.TableLayoutPanel();
            this.PicPortraitTemp = new System.Windows.Forms.PictureBox();
            this.LayUnnamed1 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnBackToMainForm = new System.Windows.Forms.Button();
            this.BtnNextToScaling = new System.Windows.Forms.Button();
            this.BtnCreateNewTemplate = new System.Windows.Forms.Button();
            this.LayScalingForm = new System.Windows.Forms.TableLayoutPanel();
            this.LayUnnamed2 = new System.Windows.Forms.TableLayoutPanel();
            this.PnlPortraitLrg = new System.Windows.Forms.Panel();
            this.PicPortraitLrg = new System.Windows.Forms.PictureBox();
            this.PnlPortraitMed = new System.Windows.Forms.Panel();
            this.PicPortraitMed = new System.Windows.Forms.PictureBox();
            this.PnlPortraitSml = new System.Windows.Forms.Panel();
            this.PicPortraitSml = new System.Windows.Forms.PictureBox();
            this.LayUnnamed3 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnBackToCreateNew = new System.Windows.Forms.Button();
            this.BtnView = new System.Windows.Forms.Button();
            this.BtnLoadPortrait = new System.Windows.Forms.Button();
            this.LayUnnamed4 = new System.Windows.Forms.TableLayoutPanel();
            this.LblUnnamed1 = new System.Windows.Forms.Label();
            this.LblUnnamed2 = new System.Windows.Forms.Label();
            this.LblUnnamed3 = new System.Windows.Forms.Label();
            this.LayLoadNewForm = new System.Windows.Forms.TableLayoutPanel();
            this.LayMainForm.SuspendLayout();
            this.LayCreateForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPortraitTemp)).BeginInit();
            this.LayUnnamed1.SuspendLayout();
            this.LayScalingForm.SuspendLayout();
            this.LayUnnamed2.SuspendLayout();
            this.PnlPortraitLrg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPortraitLrg)).BeginInit();
            this.PnlPortraitMed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPortraitMed)).BeginInit();
            this.PnlPortraitSml.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPortraitSml)).BeginInit();
            this.LayUnnamed3.SuspendLayout();
            this.LayUnnamed4.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayMainForm
            // 
            this.LayMainForm.ColumnCount = 3;
            this.LayMainForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.LayMainForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayMainForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.LayMainForm.Controls.Add(this.btnCreateNew, 1, 1);
            this.LayMainForm.Controls.Add(this.btnExit, 1, 3);
            this.LayMainForm.Location = new System.Drawing.Point(0, 0);
            this.LayMainForm.Name = "LayMainForm";
            this.LayMainForm.RowCount = 5;
            this.LayMainForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.LayMainForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.LayMainForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.LayMainForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.LayMainForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.LayMainForm.Size = new System.Drawing.Size(313, 176);
            this.LayMainForm.TabIndex = 0;
            // 
            // btnCreateNew
            // 
            this.btnCreateNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCreateNew.Location = new System.Drawing.Point(81, 38);
            this.btnCreateNew.Name = "btnCreateNew";
            this.btnCreateNew.Size = new System.Drawing.Size(150, 29);
            this.btnCreateNew.TabIndex = 0;
            this.btnCreateNew.Text = "Create new portrait";
            this.btnCreateNew.UseVisualStyleBackColor = true;
            this.btnCreateNew.Click += new System.EventHandler(this.Btn_ToCreateNew_Click);
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Location = new System.Drawing.Point(81, 108);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(150, 29);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // LayCreateForm
            // 
            this.LayCreateForm.ColumnCount = 2;
            this.LayCreateForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayCreateForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayCreateForm.Controls.Add(this.PicPortraitTemp, 0, 0);
            this.LayCreateForm.Controls.Add(this.LayUnnamed1, 1, 0);
            this.LayCreateForm.Location = new System.Drawing.Point(0, 182);
            this.LayCreateForm.Name = "LayCreateForm";
            this.LayCreateForm.RowCount = 1;
            this.LayCreateForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayCreateForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 191F));
            this.LayCreateForm.Size = new System.Drawing.Size(313, 191);
            this.LayCreateForm.TabIndex = 1;
            // 
            // PicPortraitTemp
            // 
            this.PicPortraitTemp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicPortraitTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicPortraitTemp.ErrorImage = global::PathfinderKINGPortrait.Properties.Resources._default;
            this.PicPortraitTemp.Image = global::PathfinderKINGPortrait.Properties.Resources._default;
            this.PicPortraitTemp.InitialImage = global::PathfinderKINGPortrait.Properties.Resources._default;
            this.PicPortraitTemp.Location = new System.Drawing.Point(3, 3);
            this.PicPortraitTemp.Name = "PicPortraitTemp";
            this.PicPortraitTemp.Size = new System.Drawing.Size(150, 185);
            this.PicPortraitTemp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicPortraitTemp.TabIndex = 1;
            this.PicPortraitTemp.TabStop = false;
            this.PicPortraitTemp.Click += new System.EventHandler(this.Pic_ToOpenFile_Click);
            this.PicPortraitTemp.DragDrop += new System.Windows.Forms.DragEventHandler(this.Pic_ToOpenFile_Drop);
            this.PicPortraitTemp.DragEnter += new System.Windows.Forms.DragEventHandler(this.Pic_ToOpenFile_DropEnter);
            // 
            // LayUnnamed1
            // 
            this.LayUnnamed1.ColumnCount = 3;
            this.LayUnnamed1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.LayUnnamed1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64F));
            this.LayUnnamed1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.LayUnnamed1.Controls.Add(this.BtnBackToMainForm, 1, 4);
            this.LayUnnamed1.Controls.Add(this.BtnNextToScaling, 1, 3);
            this.LayUnnamed1.Controls.Add(this.BtnCreateNewTemplate, 1, 2);
            this.LayUnnamed1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayUnnamed1.Location = new System.Drawing.Point(159, 3);
            this.LayUnnamed1.Name = "LayUnnamed1";
            this.LayUnnamed1.RowCount = 6;
            this.LayUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.933329F));
            this.LayUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.04F));
            this.LayUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.04F));
            this.LayUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.02667F));
            this.LayUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.02667F));
            this.LayUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.933329F));
            this.LayUnnamed1.Size = new System.Drawing.Size(151, 185);
            this.LayUnnamed1.TabIndex = 0;
            // 
            // BtnBackToMainForm
            // 
            this.BtnBackToMainForm.Location = new System.Drawing.Point(30, 138);
            this.BtnBackToMainForm.Name = "BtnBackToMainForm";
            this.BtnBackToMainForm.Size = new System.Drawing.Size(90, 23);
            this.BtnBackToMainForm.TabIndex = 0;
            this.BtnBackToMainForm.Text = "Back";
            this.BtnBackToMainForm.UseVisualStyleBackColor = true;
            this.BtnBackToMainForm.Click += new System.EventHandler(this.BtnBackMainForm_Click);
            // 
            // BtnNextToScaling
            // 
            this.BtnNextToScaling.Location = new System.Drawing.Point(30, 109);
            this.BtnNextToScaling.Name = "BtnNextToScaling";
            this.BtnNextToScaling.Size = new System.Drawing.Size(90, 23);
            this.BtnNextToScaling.TabIndex = 1;
            this.BtnNextToScaling.Text = "Next";
            this.BtnNextToScaling.UseVisualStyleBackColor = true;
            this.BtnNextToScaling.Click += new System.EventHandler(this.BtnToScaling_Click);
            // 
            // BtnCreateNewTemplate
            // 
            this.BtnCreateNewTemplate.Location = new System.Drawing.Point(30, 65);
            this.BtnCreateNewTemplate.Name = "BtnCreateNewTemplate";
            this.BtnCreateNewTemplate.Size = new System.Drawing.Size(90, 35);
            this.BtnCreateNewTemplate.TabIndex = 2;
            this.BtnCreateNewTemplate.Text = "Choose image";
            this.BtnCreateNewTemplate.UseVisualStyleBackColor = true;
            this.BtnCreateNewTemplate.Click += new System.EventHandler(this.Btn_ToOpenFile_Click);
            // 
            // LayScalingForm
            // 
            this.LayScalingForm.ColumnCount = 1;
            this.LayScalingForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayScalingForm.Controls.Add(this.LayUnnamed2, 0, 2);
            this.LayScalingForm.Controls.Add(this.LayUnnamed3, 0, 4);
            this.LayScalingForm.Controls.Add(this.LayUnnamed4, 0, 3);
            this.LayScalingForm.Location = new System.Drawing.Point(319, 182);
            this.LayScalingForm.Name = "LayScalingForm";
            this.LayScalingForm.RowCount = 6;
            this.LayScalingForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.590174F));
            this.LayScalingForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.389313F));
            this.LayScalingForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.80153F));
            this.LayScalingForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.013893F));
            this.LayScalingForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.453564F));
            this.LayScalingForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.590172F));
            this.LayScalingForm.Size = new System.Drawing.Size(314, 191);
            this.LayScalingForm.TabIndex = 2;
            // 
            // LayUnnamed2
            // 
            this.LayUnnamed2.ColumnCount = 5;
            this.LayUnnamed2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.228729F));
            this.LayUnnamed2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.57397F));
            this.LayUnnamed2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.39212F));
            this.LayUnnamed2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.57819F));
            this.LayUnnamed2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.226988F));
            this.LayUnnamed2.Controls.Add(this.PnlPortraitLrg, 2, 0);
            this.LayUnnamed2.Controls.Add(this.PnlPortraitMed, 1, 0);
            this.LayUnnamed2.Controls.Add(this.PnlPortraitSml, 3, 0);
            this.LayUnnamed2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayUnnamed2.Location = new System.Drawing.Point(3, 21);
            this.LayUnnamed2.Name = "LayUnnamed2";
            this.LayUnnamed2.RowCount = 1;
            this.LayUnnamed2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayUnnamed2.Size = new System.Drawing.Size(308, 129);
            this.LayUnnamed2.TabIndex = 0;
            // 
            // PnlPortraitLrg
            // 
            this.PnlPortraitLrg.Controls.Add(this.PicPortraitLrg);
            this.PnlPortraitLrg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlPortraitLrg.Location = new System.Drawing.Point(113, 3);
            this.PnlPortraitLrg.Name = "PnlPortraitLrg";
            this.PnlPortraitLrg.Size = new System.Drawing.Size(81, 123);
            this.PnlPortraitLrg.TabIndex = 3;
            // 
            // PicPortraitLrg
            // 
            this.PicPortraitLrg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicPortraitLrg.ErrorImage = global::PathfinderKINGPortrait.Properties.Resources.Fulllength;
            this.PicPortraitLrg.Image = global::PathfinderKINGPortrait.Properties.Resources.Fulllength;
            this.PicPortraitLrg.InitialImage = global::PathfinderKINGPortrait.Properties.Resources.Fulllength;
            this.PicPortraitLrg.Location = new System.Drawing.Point(3, 3);
            this.PicPortraitLrg.Name = "PicPortraitLrg";
            this.PicPortraitLrg.Size = new System.Drawing.Size(692, 1024);
            this.PicPortraitLrg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicPortraitLrg.TabIndex = 0;
            this.PicPortraitLrg.TabStop = false;
            this.PicPortraitLrg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicPortraitLrg_MouseDown);
            this.PicPortraitLrg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicPortraitLrg_MouseMove);
            this.PicPortraitLrg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicPortraitLrg_MouseUp);
            // 
            // PnlPortraitMed
            // 
            this.PnlPortraitMed.Controls.Add(this.PicPortraitMed);
            this.PnlPortraitMed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlPortraitMed.Location = new System.Drawing.Point(16, 3);
            this.PnlPortraitMed.Name = "PnlPortraitMed";
            this.PnlPortraitMed.Size = new System.Drawing.Size(91, 123);
            this.PnlPortraitMed.TabIndex = 4;
            // 
            // PicPortraitMed
            // 
            this.PicPortraitMed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicPortraitMed.ErrorImage = global::PathfinderKINGPortrait.Properties.Resources.Medium;
            this.PicPortraitMed.Image = global::PathfinderKINGPortrait.Properties.Resources.Medium;
            this.PicPortraitMed.InitialImage = global::PathfinderKINGPortrait.Properties.Resources.Medium;
            this.PicPortraitMed.Location = new System.Drawing.Point(0, 0);
            this.PicPortraitMed.Name = "PicPortraitMed";
            this.PicPortraitMed.Size = new System.Drawing.Size(330, 432);
            this.PicPortraitMed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicPortraitMed.TabIndex = 1;
            this.PicPortraitMed.TabStop = false;
            this.PicPortraitMed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicPortraitMed_MouseDown);
            this.PicPortraitMed.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicPortraitMed_MouseMove);
            this.PicPortraitMed.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicPortraitMed_MouseUp);
            // 
            // PnlPortraitSml
            // 
            this.PnlPortraitSml.Controls.Add(this.PicPortraitSml);
            this.PnlPortraitSml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlPortraitSml.Location = new System.Drawing.Point(200, 3);
            this.PnlPortraitSml.Name = "PnlPortraitSml";
            this.PnlPortraitSml.Size = new System.Drawing.Size(91, 123);
            this.PnlPortraitSml.TabIndex = 5;
            // 
            // PicPortraitSml
            // 
            this.PicPortraitSml.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicPortraitSml.ErrorImage = global::PathfinderKINGPortrait.Properties.Resources.Small;
            this.PicPortraitSml.Image = global::PathfinderKINGPortrait.Properties.Resources.Small;
            this.PicPortraitSml.InitialImage = global::PathfinderKINGPortrait.Properties.Resources.Small;
            this.PicPortraitSml.Location = new System.Drawing.Point(0, 0);
            this.PicPortraitSml.Name = "PicPortraitSml";
            this.PicPortraitSml.Size = new System.Drawing.Size(185, 242);
            this.PicPortraitSml.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicPortraitSml.TabIndex = 2;
            this.PicPortraitSml.TabStop = false;
            this.PicPortraitSml.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicPortraitSml_MouseDown);
            this.PicPortraitSml.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicPortraitSml_MouseMove);
            this.PicPortraitSml.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicPortraitSml_MouseUp);
            // 
            // LayUnnamed3
            // 
            this.LayUnnamed3.ColumnCount = 5;
            this.LayUnnamed3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.93302F));
            this.LayUnnamed3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.37611F));
            this.LayUnnamed3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.37893F));
            this.LayUnnamed3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.37893F));
            this.LayUnnamed3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.93302F));
            this.LayUnnamed3.Controls.Add(this.BtnBackToCreateNew, 1, 0);
            this.LayUnnamed3.Controls.Add(this.BtnView, 2, 0);
            this.LayUnnamed3.Controls.Add(this.BtnLoadPortrait, 3, 0);
            this.LayUnnamed3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayUnnamed3.Location = new System.Drawing.Point(3, 167);
            this.LayUnnamed3.Name = "LayUnnamed3";
            this.LayUnnamed3.RowCount = 1;
            this.LayUnnamed3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayUnnamed3.Size = new System.Drawing.Size(308, 8);
            this.LayUnnamed3.TabIndex = 1;
            // 
            // BtnBackToCreateNew
            // 
            this.BtnBackToCreateNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnBackToCreateNew.Location = new System.Drawing.Point(58, 3);
            this.BtnBackToCreateNew.Name = "BtnBackToCreateNew";
            this.BtnBackToCreateNew.Size = new System.Drawing.Size(59, 2);
            this.BtnBackToCreateNew.TabIndex = 0;
            this.BtnBackToCreateNew.Text = "Back";
            this.BtnBackToCreateNew.UseVisualStyleBackColor = true;
            this.BtnBackToCreateNew.Click += new System.EventHandler(this.BtnBackCreateNew_Click);
            // 
            // BtnView
            // 
            this.BtnView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnView.Location = new System.Drawing.Point(123, 3);
            this.BtnView.Name = "BtnView";
            this.BtnView.Size = new System.Drawing.Size(59, 2);
            this.BtnView.TabIndex = 1;
            this.BtnView.Text = "View";
            this.BtnView.UseVisualStyleBackColor = true;
            // 
            // BtnLoadPortrait
            // 
            this.BtnLoadPortrait.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnLoadPortrait.Location = new System.Drawing.Point(188, 3);
            this.BtnLoadPortrait.Name = "BtnLoadPortrait";
            this.BtnLoadPortrait.Size = new System.Drawing.Size(59, 2);
            this.BtnLoadPortrait.TabIndex = 2;
            this.BtnLoadPortrait.Text = "Load";
            this.BtnLoadPortrait.UseVisualStyleBackColor = true;
            // 
            // LayUnnamed4
            // 
            this.LayUnnamed4.ColumnCount = 5;
            this.LayUnnamed4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.161712F));
            this.LayUnnamed4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.51011F));
            this.LayUnnamed4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.29964F));
            this.LayUnnamed4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.51011F));
            this.LayUnnamed4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.399524F));
            this.LayUnnamed4.Controls.Add(this.LblUnnamed1, 1, 0);
            this.LayUnnamed4.Controls.Add(this.LblUnnamed2, 2, 0);
            this.LayUnnamed4.Controls.Add(this.LblUnnamed3, 3, 0);
            this.LayUnnamed4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayUnnamed4.Location = new System.Drawing.Point(3, 156);
            this.LayUnnamed4.Name = "LayUnnamed4";
            this.LayUnnamed4.RowCount = 1;
            this.LayUnnamed4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayUnnamed4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.LayUnnamed4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.LayUnnamed4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.LayUnnamed4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.LayUnnamed4.Size = new System.Drawing.Size(308, 5);
            this.LayUnnamed4.TabIndex = 2;
            // 
            // LblUnnamed1
            // 
            this.LblUnnamed1.AutoSize = true;
            this.LblUnnamed1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblUnnamed1.Location = new System.Drawing.Point(15, 0);
            this.LblUnnamed1.Name = "LblUnnamed1";
            this.LblUnnamed1.Size = new System.Drawing.Size(91, 5);
            this.LblUnnamed1.TabIndex = 0;
            this.LblUnnamed1.Text = "label1";
            this.LblUnnamed1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblUnnamed2
            // 
            this.LblUnnamed2.AutoSize = true;
            this.LblUnnamed2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblUnnamed2.Location = new System.Drawing.Point(112, 0);
            this.LblUnnamed2.Name = "LblUnnamed2";
            this.LblUnnamed2.Size = new System.Drawing.Size(81, 5);
            this.LblUnnamed2.TabIndex = 1;
            this.LblUnnamed2.Text = "label2";
            this.LblUnnamed2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblUnnamed3
            // 
            this.LblUnnamed3.AutoSize = true;
            this.LblUnnamed3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblUnnamed3.Location = new System.Drawing.Point(199, 0);
            this.LblUnnamed3.Name = "LblUnnamed3";
            this.LblUnnamed3.Size = new System.Drawing.Size(91, 5);
            this.LblUnnamed3.TabIndex = 2;
            this.LblUnnamed3.Text = "label3";
            this.LblUnnamed3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LayLoadNewForm
            // 
            this.LayLoadNewForm.ColumnCount = 2;
            this.LayLoadNewForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayLoadNewForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayLoadNewForm.Location = new System.Drawing.Point(3, 376);
            this.LayLoadNewForm.Name = "LayLoadNewForm";
            this.LayLoadNewForm.RowCount = 2;
            this.LayLoadNewForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayLoadNewForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayLoadNewForm.Size = new System.Drawing.Size(307, 128);
            this.LayLoadNewForm.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 504);
            this.Controls.Add(this.LayLoadNewForm);
            this.Controls.Add(this.LayScalingForm);
            this.Controls.Add(this.LayCreateForm);
            this.Controls.Add(this.LayMainForm);
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pathfinder: Kingmaker Portrait";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_Closed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.LayMainForm.ResumeLayout(false);
            this.LayCreateForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicPortraitTemp)).EndInit();
            this.LayUnnamed1.ResumeLayout(false);
            this.LayScalingForm.ResumeLayout(false);
            this.LayUnnamed2.ResumeLayout(false);
            this.PnlPortraitLrg.ResumeLayout(false);
            this.PnlPortraitLrg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPortraitLrg)).EndInit();
            this.PnlPortraitMed.ResumeLayout(false);
            this.PnlPortraitMed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPortraitMed)).EndInit();
            this.PnlPortraitSml.ResumeLayout(false);
            this.PnlPortraitSml.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPortraitSml)).EndInit();
            this.LayUnnamed3.ResumeLayout(false);
            this.LayUnnamed4.ResumeLayout(false);
            this.LayUnnamed4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel LayMainForm;
        private System.Windows.Forms.Button btnCreateNew;
        private System.Windows.Forms.TableLayoutPanel LayCreateForm;
        private System.Windows.Forms.TableLayoutPanel LayUnnamed1;
        private System.Windows.Forms.Button BtnBackToMainForm;
        private System.Windows.Forms.Button BtnNextToScaling;
        private System.Windows.Forms.PictureBox PicPortraitTemp;
        private System.Windows.Forms.Button BtnCreateNewTemplate;
        private System.Windows.Forms.TableLayoutPanel LayScalingForm;
        private System.Windows.Forms.TableLayoutPanel LayUnnamed2;
        private System.Windows.Forms.TableLayoutPanel LayUnnamed3;
        private System.Windows.Forms.Button BtnBackToCreateNew;
        private System.Windows.Forms.Button BtnView;
        private System.Windows.Forms.Button BtnLoadPortrait;
        private System.Windows.Forms.TableLayoutPanel LayUnnamed4;
        private System.Windows.Forms.Label LblUnnamed1;
        private System.Windows.Forms.Label LblUnnamed2;
        private System.Windows.Forms.Label LblUnnamed3;
        private System.Windows.Forms.PictureBox PicPortraitLrg;
        private System.Windows.Forms.PictureBox PicPortraitMed;
        private System.Windows.Forms.PictureBox PicPortraitSml;
        private System.Windows.Forms.Panel PnlPortraitLrg;
        private System.Windows.Forms.Panel PnlPortraitMed;
        private System.Windows.Forms.Panel PnlPortraitSml;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TableLayoutPanel LayLoadNewForm;
    }
}

