
namespace PathfinderPortraitManager.Forms
{
    partial class FinalDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.LabelMain = new System.Windows.Forms.Label();
            this.LayoutButtons = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonOpen = new System.Windows.Forms.Button();
            this.ButtonNew = new System.Windows.Forms.Button();
            this.ButtonMenu = new System.Windows.Forms.Button();
            this.LayoutMain.SuspendLayout();
            this.LayoutButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayFinalDialog
            // 
            this.LayoutMain.BackColor = System.Drawing.Color.Black;
            this.LayoutMain.ColumnCount = 1;
            this.LayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutMain.Controls.Add(this.LabelMain, 0, 1);
            this.LayoutMain.Controls.Add(this.LayoutButtons, 0, 2);
            this.LayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutMain.Location = new System.Drawing.Point(0, 0);
            this.LayoutMain.Name = "LayFinalDialog";
            this.LayoutMain.RowCount = 4;
            this.LayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.53846F));
            this.LayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.78761F));
            this.LayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.76106F));
            this.LayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.53846F));
            this.LayoutMain.Size = new System.Drawing.Size(531, 212);
            this.LayoutMain.TabIndex = 0;
            // 
            // LabelUnnamed1
            // 
            this.LabelMain.AutoSize = true;
            this.LabelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelMain.Font = new System.Drawing.Font("Bebas Neue", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMain.ForeColor = System.Drawing.Color.White;
            this.LabelMain.Location = new System.Drawing.Point(20, 24);
            this.LabelMain.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.LabelMain.Name = "LabelUnnamed1";
            this.LabelMain.Size = new System.Drawing.Size(491, 101);
            this.LabelMain.TabIndex = 0;
            this.LabelMain.Text = "The new portrait has been successfully created and placed at the proper location." +
    " Press \"new\" to create another one. \"Menu\" to return to main page. \"Open\" to ope" +
    "n the folder with portrait.";
            this.LabelMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LayUnnamed1
            // 
            this.LayoutButtons.ColumnCount = 5;
            this.LayoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.LayoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.LayoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.LayoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.LayoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.LayoutButtons.Controls.Add(this.ButtonOpen, 3, 0);
            this.LayoutButtons.Controls.Add(this.ButtonNew, 1, 0);
            this.LayoutButtons.Controls.Add(this.ButtonMenu, 2, 0);
            this.LayoutButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutButtons.Location = new System.Drawing.Point(3, 128);
            this.LayoutButtons.Name = "LayUnnamed1";
            this.LayoutButtons.RowCount = 1;
            this.LayoutButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutButtons.Size = new System.Drawing.Size(525, 55);
            this.LayoutButtons.TabIndex = 1;
            // 
            // ButtonOpen
            // 
            this.ButtonOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonOpen.Font = new System.Drawing.Font("Bebas Neue", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonOpen.ForeColor = System.Drawing.Color.White;
            this.ButtonOpen.Location = new System.Drawing.Point(330, 3);
            this.ButtonOpen.Name = "ButtonOpen";
            this.ButtonOpen.Size = new System.Drawing.Size(125, 49);
            this.ButtonOpen.TabIndex = 2;
            this.ButtonOpen.Text = "Open";
            this.ButtonOpen.UseVisualStyleBackColor = true;
            this.ButtonOpen.Click += new System.EventHandler(this.ButtonOpen_Click);
            // 
            // ButtonNew
            // 
            this.ButtonNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonNew.Font = new System.Drawing.Font("Bebas Neue", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonNew.ForeColor = System.Drawing.Color.White;
            this.ButtonNew.Location = new System.Drawing.Point(68, 3);
            this.ButtonNew.Name = "ButtonNew";
            this.ButtonNew.Size = new System.Drawing.Size(125, 49);
            this.ButtonNew.TabIndex = 1;
            this.ButtonNew.Text = "New";
            this.ButtonNew.UseVisualStyleBackColor = true;
            this.ButtonNew.Click += new System.EventHandler(this.ButtonNew_Click);
            // 
            // ButtonMenu
            // 
            this.ButtonMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonMenu.Font = new System.Drawing.Font("Bebas Neue", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonMenu.ForeColor = System.Drawing.Color.White;
            this.ButtonMenu.Location = new System.Drawing.Point(199, 3);
            this.ButtonMenu.Name = "ButtonMenu";
            this.ButtonMenu.Size = new System.Drawing.Size(125, 49);
            this.ButtonMenu.TabIndex = 0;
            this.ButtonMenu.Text = "Menu";
            this.ButtonMenu.UseVisualStyleBackColor = true;
            this.ButtonMenu.Click += new System.EventHandler(this.ButtonMenu_Click);
            // 
            // FinalDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(531, 212);
            this.ControlBox = false;
            this.Controls.Add(this.LayoutMain);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(531, 212);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(531, 212);
            this.Name = "FinalDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FinalDialog";
            this.LayoutMain.ResumeLayout(false);
            this.LayoutMain.PerformLayout();
            this.LayoutButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel LayoutMain;
        private System.Windows.Forms.TableLayoutPanel LayoutButtons;
        private System.Windows.Forms.Label LabelMain;
        private System.Windows.Forms.Button ButtonNew;
        private System.Windows.Forms.Button ButtonOpen;
        private System.Windows.Forms.Button ButtonMenu;
    }
}