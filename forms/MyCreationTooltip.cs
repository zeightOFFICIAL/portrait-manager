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

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PortraitManager.forms
{
    /// Bottom-right, non-modal "portrait created" toast with an "Open folder" link and a
    /// hand-drawn close button. Auto-dismisses after 5s; hovering anywhere on it pauses the
    /// countdown until the mouse leaves.
    public partial class MyCreationTooltip : Form
    {
        private readonly string _outDir;
        private readonly Timer _hideTimer;
        private Color _closeXColor = Color.Silver;

        public MyCreationTooltip(string outDir, string uid = null)
        {
            InitializeComponent();

            _outDir = outDir;
            LabelName.Text = "Name: " + (uid ?? Path.GetFileName(outDir));

            _hideTimer = new Timer { Interval = 5000 };
            _hideTimer.Tick += (s, e) => Dismiss();
            _hideTimer.Start();

            foreach (Control c in new Control[] { this, LabelTitle, LabelName, LabelInfo, LinkLabelOpenFolder, PanelCloseButton })
            {
                c.MouseEnter += PauseTimer;
                c.MouseLeave += ResumeTimer;
            }
        }

        // Non-activating owned window: behaves like the overlay Panel it replaces, not a normal
        // popup - showing it must not steal keyboard focus from the main window.
        protected override bool ShowWithoutActivation => true;

        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_NOACTIVATE = 0x08000000;
                const int WS_EX_TOOLWINDOW = 0x00000080;
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW;
                return cp;
            }
        }

        /// Shows the toast anchored to the bottom-right corner of the owner's client area.
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

        // Drawn by hand rather than relying on a Unicode glyph (e.g. "✕") in a Label - glyph
        // rendering/hit-testing came out glitchy (missing X, only edges of the box
        // clickable). A plain Panel with its own Paint handler sidesteps both problems:
        // what gets drawn and what area is clickable are the exact same rectangle.
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
