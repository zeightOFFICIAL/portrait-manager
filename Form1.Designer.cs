
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
            this.MainFormTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.btnCreateNew = new System.Windows.Forms.Button();
            this.CreateNewTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.PicCreateNewTemplate = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnBackToMainForm = new System.Windows.Forms.Button();
            this.BtnNextToScaling = new System.Windows.Forms.Button();
            this.BtnCreateNewTemplate = new System.Windows.Forms.Button();
            this.MainFormTableLayout.SuspendLayout();
            this.CreateNewTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicCreateNewTemplate)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainFormTableLayout
            // 
            this.MainFormTableLayout.ColumnCount = 3;
            this.MainFormTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.MainFormTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainFormTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.MainFormTableLayout.Controls.Add(this.btnCreateNew, 1, 1);
            this.MainFormTableLayout.Location = new System.Drawing.Point(0, 0);
            this.MainFormTableLayout.Name = "MainFormTableLayout";
            this.MainFormTableLayout.RowCount = 5;
            this.MainFormTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.MainFormTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.MainFormTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.MainFormTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.MainFormTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.MainFormTableLayout.Size = new System.Drawing.Size(313, 176);
            this.MainFormTableLayout.TabIndex = 0;
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
            this.btnCreateNew.Click += new System.EventHandler(this.BtnCreateNew_Click);
            // 
            // CreateNewTableLayout
            // 
            this.CreateNewTableLayout.ColumnCount = 2;
            this.CreateNewTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CreateNewTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CreateNewTableLayout.Controls.Add(this.PicCreateNewTemplate, 0, 0);
            this.CreateNewTableLayout.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.CreateNewTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CreateNewTableLayout.Location = new System.Drawing.Point(0, 0);
            this.CreateNewTableLayout.Name = "CreateNewTableLayout";
            this.CreateNewTableLayout.RowCount = 1;
            this.CreateNewTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CreateNewTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.CreateNewTableLayout.Size = new System.Drawing.Size(686, 443);
            this.CreateNewTableLayout.TabIndex = 1;
            // 
            // PicCreateNewTemplate
            // 
            this.PicCreateNewTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicCreateNewTemplate.ErrorImage = global::PathfinderKINGPortrait.Properties.Resources._default;
            this.PicCreateNewTemplate.Image = global::PathfinderKINGPortrait.Properties.Resources._default;
            this.PicCreateNewTemplate.InitialImage = global::PathfinderKINGPortrait.Properties.Resources._default;
            this.PicCreateNewTemplate.Location = new System.Drawing.Point(3, 3);
            this.PicCreateNewTemplate.Name = "PicCreateNewTemplate";
            this.PicCreateNewTemplate.Size = new System.Drawing.Size(337, 437);
            this.PicCreateNewTemplate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicCreateNewTemplate.TabIndex = 1;
            this.PicCreateNewTemplate.TabStop = false;
            this.PicCreateNewTemplate.Click += new System.EventHandler(this.PicCreateNewTemplate_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.Controls.Add(this.BtnBackToMainForm, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.BtnNextToScaling, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.BtnCreateNewTemplate, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(346, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.933329F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.04F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.04F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.02667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.02667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.933329F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(337, 437);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // BtnBackToMainForm
            // 
            this.BtnBackToMainForm.Location = new System.Drawing.Point(63, 326);
            this.BtnBackToMainForm.Name = "BtnBackToMainForm";
            this.BtnBackToMainForm.Size = new System.Drawing.Size(209, 32);
            this.BtnBackToMainForm.TabIndex = 0;
            this.BtnBackToMainForm.Text = "Back";
            this.BtnBackToMainForm.UseVisualStyleBackColor = true;
            this.BtnBackToMainForm.Click += new System.EventHandler(this.BtnBackToMainForm_Click);
            // 
            // BtnNextToScaling
            // 
            this.BtnNextToScaling.Location = new System.Drawing.Point(63, 256);
            this.BtnNextToScaling.Name = "BtnNextToScaling";
            this.BtnNextToScaling.Size = new System.Drawing.Size(209, 32);
            this.BtnNextToScaling.TabIndex = 1;
            this.BtnNextToScaling.Text = "Next";
            this.BtnNextToScaling.UseVisualStyleBackColor = true;
            this.BtnNextToScaling.Click += new System.EventHandler(this.BtnNextToScaling_Click);
            // 
            // BtnCreateNewTemplate
            // 
            this.BtnCreateNewTemplate.Location = new System.Drawing.Point(63, 151);
            this.BtnCreateNewTemplate.Name = "BtnCreateNewTemplate";
            this.BtnCreateNewTemplate.Size = new System.Drawing.Size(209, 35);
            this.BtnCreateNewTemplate.TabIndex = 2;
            this.BtnCreateNewTemplate.Text = "Choose image";
            this.BtnCreateNewTemplate.UseVisualStyleBackColor = true;
            this.BtnCreateNewTemplate.Click += new System.EventHandler(this.BtnCreateNewTemplate_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 443);
            this.Controls.Add(this.CreateNewTableLayout);
            this.Controls.Add(this.MainFormTableLayout);
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pathfinder: Kingmaker Portrait";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainFormTableLayout.ResumeLayout(false);
            this.CreateNewTableLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicCreateNewTemplate)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainFormTableLayout;
        private System.Windows.Forms.Button btnCreateNew;
        private System.Windows.Forms.TableLayoutPanel CreateNewTableLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button BtnBackToMainForm;
        private System.Windows.Forms.Button BtnNextToScaling;
        private System.Windows.Forms.PictureBox PicCreateNewTemplate;
        private System.Windows.Forms.Button BtnCreateNewTemplate;
    }
}

