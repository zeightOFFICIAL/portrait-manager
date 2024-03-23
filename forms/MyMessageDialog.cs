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
    public partial class MyMessageDialog : Form
    {
        private readonly Font _fontLarge, _fontMedium;
        private readonly PrivateFontCollection _fontCollection;

        public MyMessageDialog(string message, string locale)
        {
            _fontCollection = SystemControl.FileControl.InitCustomFont(Resources.BebasNeue_Regular, Resources.BebasNeue_Regular_ru);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(locale);

            if (Thread.CurrentThread.CurrentUICulture == CultureInfo.GetCultureInfo("ru-RU"))
            {
                _fontLarge = new Font(_fontCollection.Families[1], 17);
                _fontMedium = new Font(_fontCollection.Families[1], 15);
            }
            else
            {
                _fontLarge = new Font(_fontCollection.Families[0], 17);
                _fontMedium = new Font(_fontCollection.Families[0], 15);
            }

            InitializeComponent();
            ButtonClose.Text = TextVariables.BUTTON_OK;
            ButtonClose.Font = _fontLarge;
            LabelMesg.Text = message;
            LabelMesg.Font = _fontMedium;
        }
        private void MyMessageDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            _fontLarge.Dispose();
            _fontMedium.Dispose();
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
