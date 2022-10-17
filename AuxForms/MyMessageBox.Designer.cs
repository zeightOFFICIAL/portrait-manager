
namespace PathfinderKINGPortrait.AuxForms
{
    partial class MyMessageBox
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
            this.LayoutUnnamed2 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.LabelUnnamed1 = new System.Windows.Forms.Label();
            this.LayoutUnnamed1.SuspendLayout();
            this.LayoutUnnamed2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutUnnamed1
            // 
            this.LayoutUnnamed1.ColumnCount = 1;
            this.LayoutUnnamed1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutUnnamed1.Controls.Add(this.LayoutUnnamed2, 0, 2);
            this.LayoutUnnamed1.Controls.Add(this.LabelUnnamed1, 0, 1);
            this.LayoutUnnamed1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutUnnamed1.Location = new System.Drawing.Point(0, 0);
            this.LayoutUnnamed1.Name = "LayoutUnnamed1";
            this.LayoutUnnamed1.RowCount = 4;
            this.LayoutUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.LayoutUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.42857F));
            this.LayoutUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.42857F));
            this.LayoutUnnamed1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.LayoutUnnamed1.Size = new System.Drawing.Size(400, 140);
            this.LayoutUnnamed1.TabIndex = 0;
            // 
            // LayoutUnnamed2
            // 
            this.LayoutUnnamed2.ColumnCount = 2;
            this.LayoutUnnamed2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutUnnamed2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutUnnamed2.Controls.Add(this.ButtonCancel, 0, 0);
            this.LayoutUnnamed2.Controls.Add(this.ButtonOK, 1, 0);
            this.LayoutUnnamed2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutUnnamed2.Location = new System.Drawing.Point(3, 86);
            this.LayoutUnnamed2.Name = "LayoutUnnamed2";
            this.LayoutUnnamed2.RowCount = 1;
            this.LayoutUnnamed2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutUnnamed2.Size = new System.Drawing.Size(394, 38);
            this.LayoutUnnamed2.TabIndex = 0;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonCancel.Font = new System.Drawing.Font("Bebas Neue", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCancel.Location = new System.Drawing.Point(70, 3);
            this.ButtonCancel.Margin = new System.Windows.Forms.Padding(70, 3, 3, 3);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(124, 32);
            this.ButtonCancel.TabIndex = 0;
            this.ButtonCancel.Text = "No";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonOK
            // 
            this.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonOK.Font = new System.Drawing.Font("Bebas Neue", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonOK.Location = new System.Drawing.Point(200, 3);
            this.ButtonOK.Margin = new System.Windows.Forms.Padding(3, 3, 70, 3);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(124, 32);
            this.ButtonOK.TabIndex = 1;
            this.ButtonOK.Text = "Yes";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // LabelUnnamed1
            // 
            this.LabelUnnamed1.AutoSize = true;
            this.LabelUnnamed1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelUnnamed1.Font = new System.Drawing.Font("Bebas Neue", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelUnnamed1.Location = new System.Drawing.Point(3, 11);
            this.LabelUnnamed1.Name = "LabelUnnamed1";
            this.LabelUnnamed1.Size = new System.Drawing.Size(394, 72);
            this.LabelUnnamed1.TabIndex = 1;
            this.LabelUnnamed1.Text = "some text";
            this.LabelUnnamed1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MyMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(400, 140);
            this.ControlBox = false;
            this.Controls.Add(this.LayoutUnnamed1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 140);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 140);
            this.Name = "MyMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NoImageMessage";
            this.LayoutUnnamed1.ResumeLayout(false);
            this.LayoutUnnamed1.PerformLayout();
            this.LayoutUnnamed2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel LayoutUnnamed1;
        private System.Windows.Forms.TableLayoutPanel LayoutUnnamed2;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Label LabelUnnamed1;
    }
}