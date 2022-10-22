using System;
using System.Windows.Forms;

namespace PathfinderKingmakerPortraitManager.AuxForms
{
    public partial class MyHintDialog : Form
    {
        public MyHintDialog(string labelText)
        {
            InitializeComponent();
            LabelMain.Text = labelText;
        }
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
