using System;
using System.Windows.Forms;

namespace PathfinderKINGPortrait.AuxForms
{
    public partial class MyHintBox : Form
    {
        public MyHintBox(String text)
        {
            InitializeComponent();
            LabelUnnamed1.Text = text;
        }
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
