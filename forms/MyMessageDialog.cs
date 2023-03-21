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
        public MyMessageDialog(string mesg)
        {
            PrivateFontCollection pfc = SystemControl.FileControl.InitCustomFont(Properties.Resources.BebasNeue_Regular);
            Font _bebas_neue16 = new Font(pfc.Families[0], 16);
            InitializeComponent();
            ButtonClose.Text = Properties.TextVariables.BUTTON_OK;
            ButtonClose.Font = _bebas_neue16;
            LabelMesg.Text = mesg;
            LabelMesg.Font = _bebas_neue16;
        }
    }
}
