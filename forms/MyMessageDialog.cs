using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace PathfinderPortraitManager.forms
{
    public partial class MyMessageDialog : Form
    {
        public MyMessageDialog(string mesg)
        {
            InitializeComponent();
            PrivateFontCollection pfc = SystemControl.FileControl.InitCustomFont(Properties.Resources.BebasNeue_Regular);
            Font _bebas_neue16 = new Font(pfc.Families[0], 16);
            Font _bebas_neue14 = new Font(pfc.Families[0], 14);
            LabelMesg.Text = mesg;
            LabelMesg.Font = _bebas_neue14;
            ButtonClose.Font = _bebas_neue16;
            ButtonClose.Text = Properties.TextVariables.BUTTON_OK;
        }

        private void ButtonClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
