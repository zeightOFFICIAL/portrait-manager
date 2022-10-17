using System;
using System.Windows.Forms;

namespace PathfinderKINGPortrait.AuxForms
{
    public partial class MyMessageBox : Form
    {
        public MyMessageBox(String text)
        {
            InitializeComponent();
            LabelUnnamed1.Text = text;
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
