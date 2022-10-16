
namespace PathfinderKINGPortrait
{
    partial class scalinghint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(scalinghint));
            this.LayScaleHint = new System.Windows.Forms.TableLayoutPanel();
            this.BtnBackToScale = new System.Windows.Forms.Button();
            this.LblScaleHint = new System.Windows.Forms.Label();
            this.LayScaleHint.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayScaleHint
            // 
            this.LayScaleHint.ColumnCount = 1;
            this.LayScaleHint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayScaleHint.Controls.Add(this.BtnBackToScale, 0, 2);
            this.LayScaleHint.Controls.Add(this.LblScaleHint, 0, 1);
            this.LayScaleHint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayScaleHint.Location = new System.Drawing.Point(0, 0);
            this.LayScaleHint.Name = "LayScaleHint";
            this.LayScaleHint.RowCount = 4;
            this.LayScaleHint.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.75251F));
            this.LayScaleHint.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.07547F));
            this.LayScaleHint.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.86792F));
            this.LayScaleHint.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.75251F));
            this.LayScaleHint.Size = new System.Drawing.Size(531, 212);
            this.LayScaleHint.TabIndex = 0;
            // 
            // BtnBackToScale
            // 
            this.BtnBackToScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnBackToScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBackToScale.Font = new System.Drawing.Font("Bebas Neue", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBackToScale.Location = new System.Drawing.Point(170, 149);
            this.BtnBackToScale.Margin = new System.Windows.Forms.Padding(170, 3, 170, 3);
            this.BtnBackToScale.Name = "BtnBackToScale";
            this.BtnBackToScale.Size = new System.Drawing.Size(191, 34);
            this.BtnBackToScale.TabIndex = 0;
            this.BtnBackToScale.Text = "OK";
            this.BtnBackToScale.UseVisualStyleBackColor = true;
            this.BtnBackToScale.Click += new System.EventHandler(this.BtnBackToScale_Click);
            // 
            // LblScaleHint
            // 
            this.LblScaleHint.AutoSize = true;
            this.LblScaleHint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblScaleHint.Font = new System.Drawing.Font("Bebas Neue", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblScaleHint.Location = new System.Drawing.Point(35, 35);
            this.LblScaleHint.Margin = new System.Windows.Forms.Padding(35, 10, 35, 10);
            this.LblScaleHint.Name = "LblScaleHint";
            this.LblScaleHint.Size = new System.Drawing.Size(461, 101);
            this.LblScaleHint.TabIndex = 1;
            this.LblScaleHint.Text = resources.GetString("LblScaleHint.Text");
            this.LblScaleHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scalinghint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(531, 212);
            this.ControlBox = false;
            this.Controls.Add(this.LayScaleHint);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(531, 212);
            this.MinimumSize = new System.Drawing.Size(531, 212);
            this.Name = "scalinghint";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "scalinghint";
            this.LayScaleHint.ResumeLayout(false);
            this.LayScaleHint.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel LayScaleHint;
        private System.Windows.Forms.Button BtnBackToScale;
        private System.Windows.Forms.Label LblScaleHint;
    }
}