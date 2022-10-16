using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathfinderKINGPortrait
{
    public partial class scalinghint : Form
    {
        public scalinghint()
        {
            InitializeComponent();
        }

        private void BtnBackToScale_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
