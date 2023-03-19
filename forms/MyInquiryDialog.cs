using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace PathfinderPortraitManager.forms
{
    public partial class MyInquiryDialog : Form
    {
        public MyInquiryDialog(string mesg)
        {
            InitializeComponent();
            PrivateFontCollection pfc = SystemControl.FileControl.InitCustomFont(Properties.Resources.BebasNeue_Regular);
            Font _bebas_neue16 = new Font(pfc.Families[0], 16);
            LabelInquiryMesg.Text = mesg;
            LabelInquiryMesg.Font = _bebas_neue16;
            ButtonOK.Font = _bebas_neue16;
            ButtonOK.Text = Properties.TextVariables.BUTTON_YES;
            ButtonCancel.Font = _bebas_neue16;
            ButtonCancel.Text = Properties.TextVariables.BUTTON_NO;
        }
    }
}
