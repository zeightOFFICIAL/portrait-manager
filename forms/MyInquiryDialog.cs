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
        public MyInquiryDialog(string mesg)
        {
            PrivateFontCollection pfc = SystemControl.FileControl.InitCustomFont(Properties.Resources.BebasNeue_Regular);
            Font _bebas_neue18 = new Font(pfc.Families[0], 18);
            InitializeComponent();
            LabelInquiryMesg.Font = _bebas_neue18;
            LabelInquiryMesg.Text = mesg;
            ButtonOK.Font = _bebas_neue18;
            ButtonOK.Text = Properties.TextVariables.BUTTON_YES;
            ButtonCancel.Font = _bebas_neue18;
            ButtonCancel.Text = Properties.TextVariables.BUTTON_NO;
        }
    }
}
