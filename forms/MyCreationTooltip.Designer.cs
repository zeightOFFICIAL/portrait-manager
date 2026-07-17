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
    Copyright (C) 2024 Artemii "Zeight" Saganenko.

    GPL-2.0 license terms are listed in LICENSE.md file.
    License header for this project is listed in Program.cs.
*/

namespace PortraitManager.forms
{
    partial class MyCreationTooltip
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _hideTimer?.Dispose();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.LabelTitle = new System.Windows.Forms.Label();
            this.LabelName = new System.Windows.Forms.Label();
            this.LabelInfo = new System.Windows.Forms.Label();
            this.LinkLabelOpenFolder = new System.Windows.Forms.LinkLabel();
            this.PanelCloseButton = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            //
            // LabelTitle
            //
            this.LabelTitle.AutoSize = false;
            this.LabelTitle.BackColor = System.Drawing.Color.Transparent;
            this.LabelTitle.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Bold);
            this.LabelTitle.ForeColor = System.Drawing.Color.FromArgb(130, 230, 130);
            this.LabelTitle.Location = new System.Drawing.Point(8, 6);
            this.LabelTitle.Name = "LabelTitle";
            this.LabelTitle.Size = new System.Drawing.Size(310, 20);
            this.LabelTitle.TabIndex = 0;
            //
            // LabelName
            //
            this.LabelName.AutoSize = false;
            this.LabelName.BackColor = System.Drawing.Color.Transparent;
            this.LabelName.ForeColor = System.Drawing.Color.Gainsboro;
            this.LabelName.Location = new System.Drawing.Point(8, 30);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(310, 18);
            this.LabelName.TabIndex = 1;
            //
            // LabelInfo
            //
            this.LabelInfo.AutoSize = false;
            this.LabelInfo.BackColor = System.Drawing.Color.Transparent;
            this.LabelInfo.ForeColor = System.Drawing.Color.Silver;
            this.LabelInfo.Location = new System.Drawing.Point(8, 50);
            this.LabelInfo.Name = "LabelInfo";
            this.LabelInfo.Size = new System.Drawing.Size(310, 16);
            this.LabelInfo.TabIndex = 2;
            //
            // LinkLabelOpenFolder
            //
            this.LinkLabelOpenFolder.ActiveLinkColor = System.Drawing.Color.White;
            this.LinkLabelOpenFolder.AutoSize = true;
            this.LinkLabelOpenFolder.BackColor = System.Drawing.Color.Transparent;
            this.LinkLabelOpenFolder.LinkColor = System.Drawing.Color.DeepSkyBlue;
            this.LinkLabelOpenFolder.Location = new System.Drawing.Point(8, 68);
            this.LinkLabelOpenFolder.Name = "LinkLabelOpenFolder";
            this.LinkLabelOpenFolder.TabIndex = 3;
            this.LinkLabelOpenFolder.TabStop = true;
            this.LinkLabelOpenFolder.VisitedLinkColor = System.Drawing.Color.DeepSkyBlue;
            this.LinkLabelOpenFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelOpenFolder_LinkClicked);
            //
            // PanelCloseButton
            //
            this.PanelCloseButton.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.PanelCloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PanelCloseButton.Location = new System.Drawing.Point(326, 4);
            this.PanelCloseButton.Name = "PanelCloseButton";
            this.PanelCloseButton.Size = new System.Drawing.Size(28, 28);
            this.PanelCloseButton.TabIndex = 4;
            this.PanelCloseButton.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelCloseButton_Paint);
            this.PanelCloseButton.MouseEnter += new System.EventHandler(this.PanelCloseButton_MouseEnter);
            this.PanelCloseButton.MouseLeave += new System.EventHandler(this.PanelCloseButton_MouseLeave);
            this.PanelCloseButton.Click += new System.EventHandler(this.PanelCloseButton_Click);
            //
            // MyCreationTooltip
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.ClientSize = new System.Drawing.Size(360, 94);
            this.ControlBox = false;
            this.Controls.Add(this.PanelCloseButton);
            this.Controls.Add(this.LinkLabelOpenFolder);
            this.Controls.Add(this.LabelInfo);
            this.Controls.Add(this.LabelName);
            this.Controls.Add(this.LabelTitle);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MyCreationTooltip";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MyCreationTooltip_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LabelTitle;
        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.Label LabelInfo;
        private System.Windows.Forms.LinkLabel LinkLabelOpenFolder;
        private System.Windows.Forms.Panel PanelCloseButton;
    }
}
