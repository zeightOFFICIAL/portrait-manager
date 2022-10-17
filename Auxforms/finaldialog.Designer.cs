
namespace PathfinderKINGPortrait.AuxForms
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
            this.LayFinalDialog = new System.Windows.Forms.TableLayoutPanel();
            this.LabelUnnamed1 = new System.Windows.Forms.Label();
            this.LayUnnamed1 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonOpen = new System.Windows.Forms.Button();
            this.ButtonNew = new System.Windows.Forms.Button();
            this.ButtonMenu = new System.Windows.Forms.Button();
            this.LayFinalDialog.SuspendLayout();
            this.LayUnnamed1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayFinalDialog
            // 
            this.LayFinalDialog.BackColor = System.Drawing.Color.Black;
            this.LayFinalDialog.ColumnCount = 1;
            this.LayFinalDialog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayFinalDialog.Controls.Add(this.LabelUnnamed1, 0, 1);
            this.LayFinalDialog.Controls.Add(this.LayUnnamed1, 0, 2);
            this.LayFinalDialog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayFinalDialog.Location = new System.Drawing.Point(0, 0);
            this.LayFinalDialog.Name = "LayFinalDialog";
            this.LayFinalDialog.RowCount = 4;
            this.LayFinalDialog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.53846F));
            this.LayFinalDialog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.78761F));
            this.LayFinalDialog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.76106F));
            this.LayFinalDialog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.53846F));
            this.LayFinalDialog.Size = new System.Drawing.Size(531, 212);
            this.LayFinalDialog.TabIndex = 0;
            // 
            // LabelUnnamed1
            // 
            this.LabelUnnamed1.AutoSize = true;
            this.LabelUnnamed1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelUnnamed1.Font = new System.Drawing.Font("Bebas Neue", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelUnnamed1.ForeColor = System.Drawing.Color.White;
            this.LabelUnnamed1.Location = new System.Drawing.Point(20, 24);
            this.LabelUnnamed1.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.LabelUnnamed1.Name = "LabelUnnamed1";
            this.LabelUnnamed1.Size = new System.Drawing.Size(491, 101);
            this.LabelUnnamed1.TabIndex = 0;
            this.LabelUnnamed1.Text = "The new portrait has been successfully created and placed at the proper location." +
    " Press \"new\" to create another one. \"Menu\" to return to main page. \"Open\" to ope" +
    "n the folder with portrait.";
            this.LabelUnnamed1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LayUnnamed1
            // 
            this.LayUnnamed1.ColumnCount = 5;
            this.LayUnnamed1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.LayUnnamed1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.LayUnnamed1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.LayUnnamed1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.LayUnnamed1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.LayUnnamed1.Controls.Add(this.ButtonOpen, 3, 0);
            this.LayUnnamed1.Controls.Add(this.ButtonNew, 1, 0);
            this.LayUnnamed1.Controls.Add(this.ButtonMenu, 2, 0);
            this.LayUnnamed1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayUnnamed1.Location = new System.Drawing.Point(3, 128);
            this.LayUnnamed1.Name = "LayUnnamed1";
            this.LayUnnamed1.RowCount = 1;
            this.LayUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayUnnamed1.Size = new System.Drawing.Size(525, 55);
            this.LayUnnamed1.TabIndex = 1;
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
            this.Controls.Add(this.LayFinalDialog);
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
            this.LayFinalDialog.ResumeLayout(false);
            this.LayFinalDialog.PerformLayout();
            this.LayUnnamed1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel LayFinalDialog;
        private System.Windows.Forms.TableLayoutPanel LayUnnamed1;
        private System.Windows.Forms.Label LabelUnnamed1;
        private System.Windows.Forms.Button ButtonNew;
        private System.Windows.Forms.Button ButtonOpen;
        private System.Windows.Forms.Button ButtonMenu;
    }
}