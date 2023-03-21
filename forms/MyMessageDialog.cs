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
        //Font _bebas_neue16;
        public MyMessageDialog(string mesg, Font font)
        {
            //PrivateFontCollection pfc = SystemControl.FileControl.InitCustomFont(Properties.Resources.BebasNeue_Regular);
            //_bebas_neue16 = new Font(pfc.Families[0], 16);
            InitializeComponent();
            ButtonClose.Text = Properties.TextVariables.BUTTON_OK;
            ButtonClose.Font = font;
            LabelMesg.Text = mesg;
            LabelMesg.Font = font;
        }

        private void MyMessageDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            //_bebas_neue16.Dispose();
            Dispose();
        }
    }
}
