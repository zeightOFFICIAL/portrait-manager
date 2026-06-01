/*    
    Portrait Manager: Owlcat. Desktop application for managing in game
    portraits for Owlcat Games products. Including: 1. Pathfinder: Kingmaker,
    2. Pathfinder: Wrath of the Righteous, 3. Warhammer 40000: Rogue Trader
    Copyright (C) 2024 Artemii "Zeight" Saganenko.

    GPL-2.0 license terms are listed in LICENSE file.
    License header for this project is listed in Program.cs.
*/

namespace PortraitManager.forms
{
    partial class MyMessageDialog
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
            this.LabelMesg = new System.Windows.Forms.Label();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelMesg
            // 
            this.LabelMesg.AutoSize = false;
            this.LabelMesg.BackColor = System.Drawing.Color.Transparent;
            this.LabelMesg.ForeColor = System.Drawing.Color.White;
            this.LabelMesg.Location = new System.Drawing.Point(20, 16);
            this.LabelMesg.Name = "LabelMesg";
            this.LabelMesg.Size = new System.Drawing.Size(448, 84);
            this.LabelMesg.TabIndex = 0;
            this.LabelMesg.Text = "Message";
            this.LabelMesg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelMesg.UseCompatibleTextRendering = true;
            // 
            // ButtonClose
            // 
            this.ButtonClose.BackColor = System.Drawing.Color.Black;
            this.ButtonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ButtonClose.FlatAppearance.BorderSize = 1;
            this.ButtonClose.ForeColor = System.Drawing.Color.White;
            this.ButtonClose.Location = new System.Drawing.Point(164, 116);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(160, 34);
            this.ButtonClose.TabIndex = 1;
            this.ButtonClose.TabStop = false;
            this.ButtonClose.Text = "OK";
            this.ButtonClose.UseVisualStyleBackColor = false;
            this.ButtonClose.MouseEnter += new System.EventHandler(this.ButtonClose_MouseEnter);
            this.ButtonClose.MouseLeave += new System.EventHandler(this.ButtonClose_MouseLeave);
            // 
            // MyMessageDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            // Keep designer defaults; runtime sizing is adjusted to match owner width.
            this.ClientSize = new System.Drawing.Size(488, 168);
            this.ControlBox = false;
            this.Controls.Add(this.LabelMesg);
            this.Controls.Add(this.ButtonClose);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MyMessageDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MyMessageDialog_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyMessageDialog_KeyDown);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label LabelMesg;
        private System.Windows.Forms.Button ButtonClose;
    }
}
