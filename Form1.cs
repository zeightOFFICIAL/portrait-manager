using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PathfinderKINGPortrait
{
    public partial class MainForm : Form
    { 
        private string OpenFile()
        {
            string fullpath = "-1";
            OpenFileDialog ofd = new OpenFileDialog() {
                Title = "Choose image",
                Multiselect = false,
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "Image files|*.jpg; *.jpeg; *.gif; *.bmp; *.png",
            };
            if (ofd.ShowDialog() == DialogResult.OK) {
                ClearImage(PicCreateNewTemplate);
                fullpath = ofd.FileName;
            }
            return fullpath;
        }

        private void ClearImage(PictureBox image)
        {
            image.Image = PicCreateNewTemplate.Image = PathfinderKINGPortrait.Properties.Resources._default;
        }

        private void ClearTemp()
        {

        }

        private void AllNotEnabled()
        {
            CreateNewTableLayout.Visible = false;
            CreateNewTableLayout.Enabled = false;
            MainFormTableLayout.Visible = false;
            MainFormTableLayout.Enabled = false;
            ScalingTableLayout.Visible = false;
            ScalingTableLayout.Enabled = false;
        }

        private void AllToDockFill()
        {
            CreateNewTableLayout.Dock = DockStyle.Fill;
            MainFormTableLayout.Dock = DockStyle.Fill;
            ScalingTableLayout.Dock = DockStyle.Fill;
        }

        private void ActivateThis(TableLayoutPanel table)
        {
            table.Visible = true;
            table.Enabled = true;
        }

        //--------------------------------------------------------------------------------------------------------------

        public MainForm()
        {
            InitializeComponent();
            AllNotEnabled();
            AllToDockFill();
            ActivateThis(MainFormTableLayout);        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClearImage(PicCreateNewTemplate);
        }

        private void BtnCreateNew_Click(object sender, EventArgs e)
        {
            AllNotEnabled();
            ActivateThis(CreateNewTableLayout);
        }

        private void BtnBackToMainForm_Click(object sender, EventArgs e)
        {
            AllNotEnabled();
            ActivateThis(MainFormTableLayout);
            ClearImage(PicCreateNewTemplate);
        }

        private void PicCreateNewTemplate_Click(object sender, EventArgs e)
        {
            string fullpath = OpenFile();
            if (fullpath != "-1")
                PicCreateNewTemplate.Image = new Bitmap(fullpath);
        }

        private void BtnCreateNewTemplate_Click(object sender, EventArgs e)
        {
            string fullpath = OpenFile();
            if (fullpath != "-1")
                PicCreateNewTemplate.Image = new Bitmap(fullpath);
        }

        private void BtnNextToScaling_Click(object sender, EventArgs e)
        {
            PicCreateNewTemplate.Image.Save("../../resources/temp/temp_portrait.png", System.Drawing.Imaging.ImageFormat.Png);
            AllNotEnabled();
            ActivateThis(ScalingTableLayout);
            ClearImage(PicCreateNewTemplate);
        }

        private void BtnBackToCreateNew_Click(object sender, EventArgs e)
        {
            AllNotEnabled();
            ActivateThis(CreateNewTableLayout);
        }
    }
}
