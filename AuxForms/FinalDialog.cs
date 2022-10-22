using System;
using System.Windows.Forms;

namespace PathfinderKingmakerPortraitManager.AuxForms
{
    public partial class FinalDialog : Form
    {
        public int State { get; set; }
        public FinalDialog()
        {
            InitializeComponent();
        }
        private void ButtonMenu_Click(object sender, EventArgs e)
        {
            State = 1;
            Close();
        }
        private void ButtonNew_Click(object sender, EventArgs e)
        {
            State = 2;
            Close();
        }
        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            State = 3;
            Close();
        }
    }
}
