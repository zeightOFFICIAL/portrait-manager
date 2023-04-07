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
    public partial class MyMessageDialog : Form
    {
        readonly Font _bebas_neue18, _bebas_neue16;
        readonly PrivateFontCollection _fontCollection;
        public MyMessageDialog(string mesg)
        {
            _fontCollection = SystemControl.FileControl.InitCustomFont(Properties.Resources.BebasNeue_Regular);
            _bebas_neue18 = new Font(_fontCollection.Families[0], 18);
            _bebas_neue16 = new Font(_fontCollection.Families[0], 16);

            InitializeComponent();

            ButtonClose.Text = Properties.TextVariables.BUTTON_OK;
            ButtonClose.Font = _bebas_neue18;
            LabelMesg.Text = mesg;
            LabelMesg.Font = _bebas_neue16;
        }
        private void MyMessageDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            _bebas_neue18.Dispose();
            _bebas_neue16.Dispose();
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
