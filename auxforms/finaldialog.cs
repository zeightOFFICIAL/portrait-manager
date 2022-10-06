using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathfinderKINGPortrait.scripts
{
    public partial class finaldialog : Form
    {
        public int State { get; set; }
        public finaldialog()
        {
            InitializeComponent();
        }
        private void BtnBackToMenu_Click(object sender, EventArgs e)
        {
            State = 1;
            Close();
        }
        private void BtnBackToCreateNew_Click(object sender, EventArgs e)
        {
            State = 2;
            Close();
        }
        private void BtnOpenFolderBackToMenu_Click(object sender, EventArgs e)
        {
            State = 3;
            Close();
        }
    }
}
