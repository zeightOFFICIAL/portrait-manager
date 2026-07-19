namespace PortraitManager.forms
{
    partial class MyNameDialog
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
            this.TextBoxName = new System.Windows.Forms.TextBox();
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
            this.LabelTitle.Text = "Name this portrait";
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
            this.LabelHint.Text = "Type a name for the portrait\'s folder or file, or leave it blank to use an automatic one.";
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
            this.PanelTextBorder.Controls.Add(this.TextBoxName);
            //
            // TextBoxName — drag-and-drop enabled, centered text
            //
            this.TextBoxName.BackColor = System.Drawing.Color.Black;
            this.TextBoxName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxName.ForeColor = System.Drawing.Color.White;
            this.TextBoxName.Location = new System.Drawing.Point(1, 1);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.Size = new System.Drawing.Size(716, 22);
            this.TextBoxName.TabIndex = 0;
            this.TextBoxName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxName.AllowDrop = true;
            this.TextBoxName.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBoxName_DragEnter);
            this.TextBoxName.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBoxName_DragDrop);
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
            this.ButtonOK.Text = "Use name";
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
            // MyNameDialog
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.ClientSize = new System.Drawing.Size(750, 210);
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
            this.Name = "MyNameDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MyNameDialog_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MyNameDialog_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyNameDialog_KeyDown);
            this.PanelTextBorder.ResumeLayout(false);
            this.PanelTextBorder.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label LabelTitle;
        private System.Windows.Forms.Label LabelHint;
        private System.Windows.Forms.Panel PanelTextBorder;
        private System.Windows.Forms.TextBox TextBoxName;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonCancel;
    }
}
