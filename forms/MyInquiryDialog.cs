/*    
    Pathfinder Portrait Manager. Desktop application for managing in game
    portraits for Pathfinder: Kingmaker and Pathfinder: Wrath of the Righteous
    Copyright (C) 2023 Artemii "Zeight" Saganenko
    LICENSE terms are written in LICENSE file
    Primal license header is written in Program.cs
*/

using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace PathfinderPortraitManager.forms
{
    public partial class MyInquiryDialog : Form
    {
        readonly Font _bebas_neue18;
        readonly PrivateFontCollection _fontCollection;
        public MyInquiryDialog(string mesg)
        {
            _fontCollection = SystemControl.FileControl.InitCustomFont(Properties.Resources.BebasNeue_Regular);
            _bebas_neue18 = new Font(_fontCollection.Families[0], 18);
            InitializeComponent();
            LabelInquiryMesg.Font = _bebas_neue18;
            LabelInquiryMesg.Text = mesg;
            ButtonOK.Font = _bebas_neue18;
            ButtonOK.Text = Properties.TextVariables.BUTTON_YES;
            ButtonCancel.Font = _bebas_neue18;
            ButtonCancel.Text = Properties.TextVariables.BUTTON_NO;
        }

        private void MyInquiryDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            _bebas_neue18.Dispose();
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
