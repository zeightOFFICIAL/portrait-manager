/*    
    Pathfinder Portrait Manager. Desktop application for managing in game
    portraits for Pathfinder: Kingmaker and Pathfinder: Wrath of the Righteous
    Copyright (C) 2023 Artemii "Zeight" Saganenko
    LICENSE terms are written in LICENSE file
    Primal license header is written in Program.cs
*/

using System;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace PathfinderPortraitManager.forms
{
    public partial class MyInquiryDialog : Form
    {
        readonly Font _font;
        readonly PrivateFontCollection _fontCollection;
        public MyInquiryDialog(string mesg)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentUICulture;
            string resxFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Thread.CurrentThread.CurrentUICulture.Name, "Pathfinder Portrait Manager.resources.dll");
            if (File.Exists(resxFilePath))
            {
                _font = new Font(DefaultFont.FontFamily, 14);
            }
            else
            {
                _fontCollection = SystemControl.FileControl.InitCustomFont(Properties.Resources.BebasNeue_Regular);
                _font = new Font(_fontCollection.Families[0], 18);
            }            
            InitializeComponent();
            LabelInquiryMesg.Font = _font;
            LabelInquiryMesg.Text = mesg;
            ButtonOK.Font = _font;
            ButtonOK.Text = Properties.TextVariables.BUTTON_YES;
            ButtonCancel.Font = _font;
            ButtonCancel.Text = Properties.TextVariables.BUTTON_NO;
        }

        private void MyInquiryDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            _font.Dispose();
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
    }
}
