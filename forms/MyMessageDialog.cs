/*    
    Pathfinder Portrait Manager. Desktop application for managing in game
    portraits for Pathfinder: Kingmaker and Pathfinder: Wrath of the Righteous
    Copyright (C) 2023 Artemii "Zeight" Saganenko
    LICENSE terms are written in LICENSE file
    Primal license header is written in Program.cs
*/

using PathfinderPortraitManager.Properties;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace PathfinderPortraitManager.forms
{
    public partial class MyMessageDialog : Form
    {
        readonly Font _font1, _font2;
        readonly PrivateFontCollection _fontCollection;
        public MyMessageDialog(string mesg, string locale)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(locale);

            if (Thread.CurrentThread.CurrentUICulture == CultureInfo.GetCultureInfo("ru-RU") ||
                Thread.CurrentThread.CurrentUICulture == CultureInfo.GetCultureInfo("de-DE"))
            {
                _font1 = new Font(DefaultFont.FontFamily, 13);
                _font2 = new Font(DefaultFont.FontFamily, 11);
            }
            else
            {
                _fontCollection = SystemControl.FileControl.InitCustomFont(Resources.BebasNeue_Regular);
                _font1 = new Font(_fontCollection.Families[0], 17);
                _font2 = new Font(_fontCollection.Families[0], 15);
            }

            InitializeComponent();
            ButtonClose.Text = TextVariables.BUTTON_OK;
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
