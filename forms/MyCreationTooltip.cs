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
using PortraitManager.Properties;

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PortraitManager.forms
{

    public partial class MyCreationTooltip : Form
    {
        private readonly string _outDir;
        private readonly Timer _hideTimer;
        private Color _closeXColor = Color.Silver;

        public MyCreationTooltip(string outDir, string uid = null)
        {
            InitializeComponent();

            _outDir = outDir;
            TextInit(uid ?? Path.GetFileName(outDir));

            _hideTimer = new Timer { Interval = 5000 };
            _hideTimer.Tick += (s, e) => Dismiss();
            _hideTimer.Start();

            foreach (Control c in new Control[] { this, LabelTitle, LabelName, LabelInfo, LinkLabelOpenFolder, PanelCloseButton })
            {
                c.MouseEnter += PauseTimer;
                c.MouseLeave += ResumeTimer;
            }
        }

        protected override bool ShowWithoutActivation => true;

        protected override CreateParams CreateParams
        {
            get
            {

                const int WS_EX_NOACTIVATE = 0x08000000;
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_NOACTIVATE;
                return cp;
            }
        }

        private void TextInit(string displayName)
        {
            LabelTitle.Text = TextVariables.TOAST_TITLE;
            LabelInfo.Text = TextVariables.TOAST_INFO;
            LinkLabelOpenFolder.Text = TextVariables.TOAST_OPEN_FOLDER;
            LabelName.Text = string.Format(TextVariables.TOAST_NAME_PREFIX, displayName);
        }

        public void ShowAnchoredTo(Form owner)
        {
            Point ownerClientOrigin = owner.PointToScreen(Point.Empty);
            Location = new Point(
                ownerClientOrigin.X + owner.ClientSize.Width - Width - 12,
                ownerClientOrigin.Y + owner.ClientSize.Height - Height - 12);
            Show(owner);
        }

        private void Dismiss()
        {
            _hideTimer.Stop();
            if (!IsDisposed)
                Close();
        }

        private void PauseTimer(object sender, EventArgs e) => _hideTimer.Stop();

        private void ResumeTimer(object sender, EventArgs e)
        {
            _hideTimer.Stop();
            _hideTimer.Start();
        }

        private void LinkLabelOpenFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = _outDir,
                    UseShellExecute = true
                });
            }
            catch { }
        }

        private void PanelCloseButton_Paint(object sender, PaintEventArgs e)
        {
            int pad = 9;
            using (var pen = new Pen(_closeXColor, 2f))
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.DrawLine(pen, pad, pad, PanelCloseButton.Width - pad, PanelCloseButton.Height - pad);
                e.Graphics.DrawLine(pen, PanelCloseButton.Width - pad, pad, pad, PanelCloseButton.Height - pad);
            }
        }

        private void PanelCloseButton_MouseEnter(object sender, EventArgs e)
        {
            _closeXColor = Color.White;
            PanelCloseButton.BackColor = Color.FromArgb(60, 60, 60);
            PanelCloseButton.Invalidate();
        }

        private void PanelCloseButton_MouseLeave(object sender, EventArgs e)
        {
            _closeXColor = Color.Silver;
            PanelCloseButton.BackColor = Color.FromArgb(24, 24, 24);
            PanelCloseButton.Invalidate();
        }

        private void PanelCloseButton_Click(object sender, EventArgs e) => Dismiss();

        private void MyCreationTooltip_FormClosed(object sender, FormClosedEventArgs e) => Dispose();
    }
}
