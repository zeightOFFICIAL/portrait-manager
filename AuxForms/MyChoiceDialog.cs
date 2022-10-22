using System;
using System.Windows.Forms;

namespace PathfinderKingmakerPortraitManager.AuxForms
{
    public partial class MyChoiceDialog : Form
    {
        public MyChoiceDialog(string labelText)
        {
            InitializeComponent();
            LabelMain.Text = labelText;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
