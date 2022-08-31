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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CreateNewTableLayout.Visible = false;
            CreateNewTableLayout.Enabled = false;
            CreateNewTableLayout.Dock = DockStyle.Fill;
            MainFormTableLayout.Visible = true;
            MainFormTableLayout.Enabled = true;
            MainFormTableLayout.Dock = DockStyle.Fill;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnCreateNew_Click(object sender, EventArgs e)
        {
            MainFormTableLayout.Visible = false;
            MainFormTableLayout.Enabled = false;
            CreateNewTableLayout.Visible = true;
            CreateNewTableLayout.Enabled = true;
        }

        private void BtnBackToMainForm_Click(object sender, EventArgs e)
        {
            CreateNewTableLayout.Visible = false;
            CreateNewTableLayout.Enabled = false;
            MainFormTableLayout.Visible = true;
            MainFormTableLayout.Enabled = true;
        }
    }
}
