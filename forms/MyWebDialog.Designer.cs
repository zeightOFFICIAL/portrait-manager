namespace PortraitManager.forms
{
    partial class MyWebDialog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.LabelTitle = new System.Windows.Forms.Label();
            this.LabelHint = new System.Windows.Forms.Label();
            this.PanelTextBorder = new System.Windows.Forms.Panel();
            this.TextBoxURL = new System.Windows.Forms.TextBox();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.PanelTextBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelTitle
            // 
            this.LabelTitle.AutoSize = false;
            this.LabelTitle.BackColor = System.Drawing.Color.Transparent;
            this.LabelTitle.ForeColor = System.Drawing.Color.White;
            this.LabelTitle.Location = new System.Drawing.Point(16, 14);
            this.LabelTitle.Name = "LabelTitle";
            this.LabelTitle.Size = new System.Drawing.Size(718, 30);
            this.LabelTitle.TabIndex = 0;
            this.LabelTitle.Text = "Load image from web";
            this.LabelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelHint  — uses generic system font (applied in code-behind, not Bebas Neue)
            // 
            this.LabelHint.AutoSize = false;
            this.LabelHint.BackColor = System.Drawing.Color.Transparent;
            this.LabelHint.ForeColor = System.Drawing.Color.Silver;
            this.LabelHint.Location = new System.Drawing.Point(16, 48);
            this.LabelHint.Name = "LabelHint";
            this.LabelHint.Size = new System.Drawing.Size(718, 34);
            this.LabelHint.TabIndex = 1;
            this.LabelHint.Text = "Paste or drag a web image address into the box below, then press Load.";
            this.LabelHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PanelTextBorder  — 1px white border wrapper for TextBox
            // 
            this.PanelTextBorder.BackColor = System.Drawing.Color.White;
            this.PanelTextBorder.Location = new System.Drawing.Point(16, 90);
            this.PanelTextBorder.Name = "PanelTextBorder";
            this.PanelTextBorder.Padding = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.PanelTextBorder.Size = new System.Drawing.Size(718, 30);
            this.PanelTextBorder.TabIndex = 2;
            this.PanelTextBorder.Controls.Add(this.TextBoxURL);
            // 
            // TextBoxURL — drag-and-drop enabled, centered text
            // 
            this.TextBoxURL.BackColor = System.Drawing.Color.Black;
            this.TextBoxURL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxURL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxURL.ForeColor = System.Drawing.Color.White;
            this.TextBoxURL.Location = new System.Drawing.Point(1, 1);
            this.TextBoxURL.Name = "TextBoxURL";
            this.TextBoxURL.Size = new System.Drawing.Size(716, 22);
            this.TextBoxURL.TabIndex = 0;
            this.TextBoxURL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxURL.AllowDrop = true;
            this.TextBoxURL.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBoxURL_DragEnter);
            this.TextBoxURL.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBoxURL_DragDrop);
            // 
            // ButtonOK
            // 
            this.ButtonOK.BackColor = System.Drawing.Color.Black;
            this.ButtonOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonOK.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ButtonOK.FlatAppearance.BorderSize = 1;
            this.ButtonOK.ForeColor = System.Drawing.Color.White;
            this.ButtonOK.Location = new System.Drawing.Point(381, 138);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(160, 34);
            this.ButtonOK.TabIndex = 3;
            this.ButtonOK.TabStop = false;
            this.ButtonOK.Text = "Load";
            this.ButtonOK.UseVisualStyleBackColor = false;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            this.ButtonOK.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.ButtonOK.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.BackColor = System.Drawing.Color.Black;
            this.ButtonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonCancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ButtonCancel.FlatAppearance.BorderSize = 1;
            this.ButtonCancel.ForeColor = System.Drawing.Color.White;
            this.ButtonCancel.Location = new System.Drawing.Point(209, 138);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(160, 34);
            this.ButtonCancel.TabIndex = 4;
            this.ButtonCancel.TabStop = false;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = false;
            this.ButtonCancel.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.ButtonCancel.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // MyWebDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.ClientSize = new System.Drawing.Size(750, 190);
            this.ControlBox = false;
            this.Controls.Add(this.LabelTitle);
            this.Controls.Add(this.LabelHint);
            this.Controls.Add(this.PanelTextBorder);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.ButtonCancel);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MyWebDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MyWebDialog_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyWebDialog_KeyDown);
            this.PanelTextBorder.ResumeLayout(false);
            this.PanelTextBorder.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label LabelTitle;
        private System.Windows.Forms.Label LabelHint;
        private System.Windows.Forms.Panel PanelTextBorder;
        private System.Windows.Forms.TextBox TextBoxURL;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonCancel;
    }
}

