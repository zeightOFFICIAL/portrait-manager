using System;
using System.Windows.Forms;

namespace PathfinderKINGPortrait.AuxForms
{
    public partial class FileHint : Form
    {
        public FileHint()
        {
            InitializeComponent();
        }
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
