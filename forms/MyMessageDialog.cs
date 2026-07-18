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

    GPL-2.0 license terms are listed in LICENSE.md file.
    License header for this project is listed in Program.cs.
*/
using PortraitManager.Properties;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace PortraitManager.forms
{
    public partial class MyMessageDialog : Form
    {
        private PrivateFontCollection _fontCollection;

        public MyMessageDialog(string message)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.Selectable, false);
            Shown += MyMessageDialog_Shown;

            FontInit();
            TextInit();
            LabelMesg.Text = message;

            Focus();
        }

        private void FontInit()
        {
            _fontCollection = SystemControl.FileControl.InitCustomFont(Resources.BebasNeue_Regular);
            var family = _fontCollection.Families[0];

            LabelMesg.Font = new Font(FontFamily.GenericSansSerif, 14.4f);
            ButtonClose.Font = new Font(family, 16f);
        }

        private void TextInit()
        {
            ButtonClose.Text = TextVariables.DIALOG_BUTTON_CLOSE;
        }

        private void MyMessageDialog_FormClosing(object sender, FormClosingEventArgs e)
        {

            Form root = Owner;
            while (root != null && root.Owner != null)
                root = root.Owner;

            if (root != null)
            {
                if (root.WindowState == FormWindowState.Minimized)
                    root.WindowState = FormWindowState.Normal;
                root.Activate();
            }
        }

        private void MyMessageDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }

        private void ButtonClose_MouseEnter(object sender, System.EventArgs e)
        {
            if (sender is Button btn) { btn.BackColor = Color.White; btn.ForeColor = Color.Black; }
        }

        private void ButtonClose_MouseLeave(object sender, System.EventArgs e)
        {
            if (sender is Button btn && btn.Enabled) { btn.BackColor = Color.Black; btn.ForeColor = Color.White; }
        }

        private void MyMessageDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
                Close();
        }

        private void MyMessageDialog_Shown(object sender, EventArgs e)
        {
            try
            {
                Form anchor = Owner;
                while (anchor != null && anchor.Owner != null)
                    anchor = anchor.Owner;

                if (anchor == null)
                {
                    foreach (Form f in Application.OpenForms)
                    {
                        anchor = f;
                        break;
                    }
                }

                if (anchor != null)
                {
                    Width = anchor.ClientSize.Width;
                    Left = anchor.PointToScreen(Point.Empty).X;
                }
            }
            catch { }
        }
    }
}
