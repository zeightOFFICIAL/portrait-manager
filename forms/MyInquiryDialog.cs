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
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace PortraitManager.forms
{
    public partial class MyInquiryDialog : Form
    {
        private PrivateFontCollection _fontCollection;
        private readonly bool _useYesNo;

        public MyInquiryDialog(string message, bool useYesNo = false)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.Selectable, false);
            Shown += MyInquiryDialog_Shown;

            _useYesNo = useYesNo;
            FontInit();
            TextInit();
            LabelInquiryMesg.Text = message;
            Focus();
        }

        private void FontInit()
        {
            _fontCollection = SystemControl.FileControl.InitCustomFont(Resources.BebasNeue_Regular);
            var family = _fontCollection.Families[0];

            LabelInquiryMesg.Font = new Font(FontFamily.GenericSansSerif, 14.4f);
            ButtonOK.Font = new Font(family, 16f);
            ButtonCancel.Font = new Font(family, 16f);
        }

        private void TextInit()
        {
            ButtonOK.Text = _useYesNo ? TextVariables.DIALOG_BUTTON_YES : TextVariables.DIALOG_BUTTON_OK;
            ButtonCancel.Text = _useYesNo ? TextVariables.DIALOG_BUTTON_NO : TextVariables.DIALOG_BUTTON_CANCEL;
        }

        private void MyInquiryDialog_Shown(object sender, EventArgs e)
        {
            try
            {
                Form anchor = Owner;
                while (anchor != null && anchor.Owner != null)
                    anchor = anchor.Owner;
                if (anchor != null)
                {
                    Width = anchor.ClientSize.Width;
                    Left = anchor.PointToScreen(System.Drawing.Point.Empty).X;
                }
            }
            catch { }
        }

        private void MyInquiryDialog_FormClosing(object sender, FormClosingEventArgs e)
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

        private void MyInquiryDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }

        private void ButtonCancel_MouseEnter(object sender, System.EventArgs e)
        {
            if (sender is Button button)
            {
                if (button != null)
                {
                    button.BackColor = Color.White;
                    button.ForeColor = Color.Black;
                }
            }
        }

        private void ButtonCancel_MouseLeave(object sender, System.EventArgs e)
        {
            if (sender is Button button)
            {
                if (button != null && button.Enabled == true)
                {
                    button.BackColor = Color.Black;
                    button.ForeColor = Color.White;
                }
            }
        }

        private void MyInquiryDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.E)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
    }
}
