
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnBackToMainForm = new System.Windows.Forms.Button();
            this.MainFormTableLayout.SuspendLayout();
            this.CreateNewTableLayout.SuspendLayout();
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.BtnBackToMainForm, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(346, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.64302F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.35698F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(337, 437);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // BtnBackToMainForm
            // 
            this.BtnBackToMainForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnBackToMainForm.Location = new System.Drawing.Point(3, 386);
            this.BtnBackToMainForm.Name = "BtnBackToMainForm";
            this.BtnBackToMainForm.Size = new System.Drawing.Size(162, 48);
            this.BtnBackToMainForm.TabIndex = 0;
            this.BtnBackToMainForm.Text = "button1";
            this.BtnBackToMainForm.UseVisualStyleBackColor = true;
            this.BtnBackToMainForm.Click += new System.EventHandler(this.BtnBackToMainForm_Click);
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainFormTableLayout;
        private System.Windows.Forms.Button btnCreateNew;
        private System.Windows.Forms.TableLayoutPanel CreateNewTableLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button BtnBackToMainForm;
    }
}

