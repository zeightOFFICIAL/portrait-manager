/*
    Zeight Portrait Manager
    Desktop application for managing in-game portraits for games from Owlcat Games,
    Obsidian Entertainment and inXile Entertainment.
    Including:
        1. Pathfinder: Kingmaker,
        2. Pathfinder: Wrath of the Righteous,
        3. Warhammer 40000: Rogue Trader,
        4. Pillars of Eternity,
        5. Pillars of Eternity: Deadfire,
        6. Tyranny,
        7. Wasteland 3.
    Copyright (C) 2023-2026 Artemii "Zeight" Saganenko.

    GPL-2.0 license terms are listed in LICENSE file.
    License header for this project is listed in Program.cs.
*/

namespace PortraitManager.forms
{
    partial class MyInquiryDialog
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
            this.LayoutRoot = new System.Windows.Forms.TableLayoutPanel();
            this.LabelInquiryMesg = new System.Windows.Forms.Label();
            this.ButtonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.LayoutRoot.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutRoot
            // 
            this.LayoutRoot.ColumnCount = 3;
            this.LayoutRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.LayoutRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutRoot.Controls.Add(this.LabelInquiryMesg, 1, 0);
            this.LayoutRoot.Controls.Add(this.ButtonPanel, 1, 1);
            this.LayoutRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutRoot.Location = new System.Drawing.Point(0, 0);
            this.LayoutRoot.Name = "LayoutRoot";
            this.LayoutRoot.Padding = new System.Windows.Forms.Padding(20);
            this.LayoutRoot.RowCount = 2;
            this.LayoutRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.LayoutRoot.Size = new System.Drawing.Size(734, 200);
            this.LayoutRoot.TabIndex = 0;
            // 
            // LabelInquiryMesg
            // 
            this.LabelInquiryMesg.BackColor = System.Drawing.Color.Transparent;
            this.LabelInquiryMesg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelInquiryMesg.ForeColor = System.Drawing.Color.White;
            this.LabelInquiryMesg.Location = new System.Drawing.Point(23, 20);
            this.LabelInquiryMesg.Name = "LabelInquiryMesg";
            this.LabelInquiryMesg.Size = new System.Drawing.Size(688, 121);
            this.LabelInquiryMesg.TabIndex = 0;
            this.LabelInquiryMesg.Text = "Inquiry";
            this.LabelInquiryMesg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelInquiryMesg.UseCompatibleTextRendering = true;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ButtonPanel.AutoSize = true;
            this.ButtonPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonPanel.Controls.Add(this.ButtonCancel);
            this.ButtonPanel.Controls.Add(this.ButtonOK);
            this.ButtonPanel.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.ButtonPanel.Location = new System.Drawing.Point(23, 144);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(0, 0);
            this.ButtonPanel.TabIndex = 1;
            // 
            // ButtonOK
            // 
            this.ButtonOK.BackColor = System.Drawing.Color.Black;
            this.ButtonOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOK.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ButtonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonOK.ForeColor = System.Drawing.Color.White;
            this.ButtonOK.Location = new System.Drawing.Point(83, 3);
            this.ButtonOK.Margin = new System.Windows.Forms.Padding(3);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(120, 34);
            this.ButtonOK.TabIndex = 1;
            this.ButtonOK.TabStop = false;
            this.ButtonOK.Text = "OK";
            this.ButtonOK.UseVisualStyleBackColor = false;
            this.ButtonOK.MouseEnter += new System.EventHandler(this.ButtonCancel_MouseEnter);
            this.ButtonOK.MouseLeave += new System.EventHandler(this.ButtonCancel_MouseLeave);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.BackColor = System.Drawing.Color.Black;
            this.ButtonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonCancel.ForeColor = System.Drawing.Color.White;
            this.ButtonCancel.Location = new System.Drawing.Point(3, 3);
            this.ButtonCancel.Margin = new System.Windows.Forms.Padding(3);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(120, 34);
            this.ButtonCancel.TabIndex = 0;
            this.ButtonCancel.TabStop = false;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = false;
            this.ButtonCancel.MouseEnter += new System.EventHandler(this.ButtonCancel_MouseEnter);
            this.ButtonCancel.MouseLeave += new System.EventHandler(this.ButtonCancel_MouseLeave);
            // 
            // MyInquiryDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.ClientSize = new System.Drawing.Size(734, 200);
            this.ControlBox = false;
            this.Controls.Add(this.LayoutRoot);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MyInquiryDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MyInquiryDialog_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MyInquiryDialog_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyInquiryDialog_KeyDown);
            this.LayoutRoot.ResumeLayout(false);
            this.LayoutRoot.PerformLayout();
            this.ButtonPanel.ResumeLayout(false);
            this.ButtonPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel LayoutRoot;
        private System.Windows.Forms.FlowLayoutPanel ButtonPanel;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Label LabelInquiryMesg;
    }
}