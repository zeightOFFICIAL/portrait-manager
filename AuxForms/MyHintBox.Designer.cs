
namespace PathfinderKINGPortrait.AuxForms
{
    partial class MyHintBox
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
            this.LayoutUnnamed1 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.LabelUnnamed1 = new System.Windows.Forms.Label();
            this.LayoutUnnamed1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutUnnamed1
            // 
            this.LayoutUnnamed1.ColumnCount = 1;
            this.LayoutUnnamed1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutUnnamed1.Controls.Add(this.ButtonOK, 0, 2);
            this.LayoutUnnamed1.Controls.Add(this.LabelUnnamed1, 0, 1);
            this.LayoutUnnamed1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutUnnamed1.Location = new System.Drawing.Point(0, 0);
            this.LayoutUnnamed1.Name = "LayoutUnnamed1";
            this.LayoutUnnamed1.RowCount = 4;
            this.LayoutUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.16294F));
            this.LayoutUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.51424F));
            this.LayoutUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.15989F));
            this.LayoutUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.16293F));
            this.LayoutUnnamed1.Size = new System.Drawing.Size(531, 212);
            this.LayoutUnnamed1.TabIndex = 0;
            // 
            // ButtonOK
            // 
            this.ButtonOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonOK.Font = new System.Drawing.Font("Bebas Neue", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonOK.Location = new System.Drawing.Point(170, 147);
            this.ButtonOK.Margin = new System.Windows.Forms.Padding(170, 3, 170, 3);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(191, 34);
            this.ButtonOK.TabIndex = 0;
            this.ButtonOK.Text = "OK";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // LabelUnnamed1
            // 
            this.LabelUnnamed1.AutoSize = true;
            this.LabelUnnamed1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelUnnamed1.Font = new System.Drawing.Font("Bebas Neue", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelUnnamed1.Location = new System.Drawing.Point(3, 25);
            this.LabelUnnamed1.Name = "LabelUnnamed1";
            this.LabelUnnamed1.Size = new System.Drawing.Size(525, 119);
            this.LabelUnnamed1.TabIndex = 1;
            this.LabelUnnamed1.Text = "some text";
            this.LabelUnnamed1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MyHintBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(531, 212);
            this.ControlBox = false;
            this.Controls.Add(this.LayoutUnnamed1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(531, 212);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(531, 212);
            this.Name = "MyHintBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FileHint";
            this.LayoutUnnamed1.ResumeLayout(false);
            this.LayoutUnnamed1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel LayoutUnnamed1;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Label LabelUnnamed1;
    }
}