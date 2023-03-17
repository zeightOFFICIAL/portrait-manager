using System.Drawing;
using System.Windows.Forms;

namespace PathfinderPortraitManager.forms
{
    public partial class MyMessageDialog : Form
    {
        public MyMessageDialog(string mesg, Font font, Font font2)
        {
            InitializeComponent();
            LabelMesg.Text = mesg;
            LabelMesg.Font = font2;
            ButtonClose.Font = font;
            ButtonClose.Text = Properties.TextVariables.BUTTON_OK;
        }

        private void ButtonClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
