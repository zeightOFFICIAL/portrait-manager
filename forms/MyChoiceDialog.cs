using System;
using System.Windows.Forms;

namespace PathfinderPortraitManager.Forms
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
