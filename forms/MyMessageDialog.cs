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
    public partial class MyMessageDialog : Form
    {
        readonly Font _font1, _font2;
        readonly PrivateFontCollection _fontCollection;
        public MyMessageDialog(string mesg)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Properties.CoreSettings.Default.ActiveLocal);
            string resxFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Thread.CurrentThread.CurrentUICulture.Name, "Pathfinder Portrait Manager.resources.dll");
            if (File.Exists(resxFilePath))
            {
                _font1 = new Font(DefaultFont.FontFamily, 14);
                _font2 = new Font(DefaultFont.FontFamily, 12);
            }
            else
            {
                _fontCollection = SystemControl.FileControl.InitCustomFont(Properties.Resources.BebasNeue_Regular);
                _font1 = new Font(_fontCollection.Families[0], 18);
                _font2 = new Font(_fontCollection.Families[0], 16);
            }

            InitializeComponent();
            ButtonClose.Text = Properties.TextVariables.BUTTON_OK;
            ButtonClose.Font = _font1;
            LabelMesg.Text = mesg;
            LabelMesg.Font = _font2;
        }
        private void MyMessageDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            _font1.Dispose();
            _font2.Dispose();
            Dispose();
        }
        private void ButtonClose_MouseEnter(object sender, System.EventArgs e)
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
        private void ButtonClose_MouseLeave(object sender, System.EventArgs e)
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
