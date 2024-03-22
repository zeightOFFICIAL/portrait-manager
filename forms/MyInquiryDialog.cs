/*    
    Owlcat Portrait Manager. Desktop application for managing in game
    portraits for Owlcat Games products. Including Pathfinder: Kingmaker,
    Pathfinder: Wrath of the Righteous, Warhammer 40000: Rogue Trader
    Copyright (C) 2024 Artemii "Zeight" Saganenko.

    GPL-2.0 license terms are listed in LICENSE file
    License header for this project is listed in Program.cs
*/

using OwlcatPortraitManager.Properties;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace OwlcatPortraitManager.forms
{
    public partial class MyInquiryDialog : Form
    {
        private readonly Font _font;
        private readonly PrivateFontCollection _fontCollection;

        public MyInquiryDialog(string message, string locale)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(locale);

            if (Thread.CurrentThread.CurrentUICulture == CultureInfo.GetCultureInfo("ru-RU") ||
                Thread.CurrentThread.CurrentUICulture == CultureInfo.GetCultureInfo("de-DE"))
            {
                _font = new Font(DefaultFont.FontFamily, 12);
            }
            else
            {
                _fontCollection = SystemControl.FileControl.InitCustomFont(Resources.BebasNeue_Regular);
                _font = new Font(_fontCollection.Families[0], 17);
            }

            InitializeComponent();
            LabelInquiryMesg.Font = _font;
            LabelInquiryMesg.Text = message;
            ButtonOK.Font = _font;
            ButtonOK.Text = TextVariables.BUTTON_YES;
            ButtonCancel.Font = _font;
            ButtonCancel.Text = TextVariables.BUTTON_NO;
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
