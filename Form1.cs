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
        private void OpenFileAndCopy()
        {
            OpenFileDialog ofd = new OpenFileDialog() {
                Title = "Choose image",
                Multiselect = false,
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "Image files|*.jpg; *.jpeg; *.gif; *.bmp; *.png",
            };
            if (ofd.ShowDialog() == DialogResult.OK) {
                ThisImageClear(PicPortraitTemp);
                Directory.CreateDirectory("temp/");
                string jointpath = "temp/temp_portrait.png";
                File.Copy(ofd.FileName, jointpath, true);
            }
        }

        private void ThisImageClear(PictureBox image)
        {
            image.Image.Dispose();
            image.Image = PicPortraitTemp.Image = PathfinderKINGPortrait.Properties.Resources._default;
        }

        private void TempClear()
        {
            if (Directory.Exists("temp/")) Directory.Delete("temp/", true);
        }

        private void AllToNotEnabled()
        {
            LayCreateForm.Visible = false;
            LayCreateForm.Enabled = false;
            LayMainForm.Visible = false;
            LayMainForm.Enabled = false;
            LayScalingForm.Visible = false;
            LayScalingForm.Enabled = false;
        }

        private void AllToDockFill()
        {
            LayCreateForm.Dock = DockStyle.Fill;
            LayMainForm.Dock = DockStyle.Fill;
            LayScalingForm.Dock = DockStyle.Fill;
        }

        private void ThisToEnabled(TableLayoutPanel table)
        {
            if (table.Visible == false && table.Enabled == false)
            {
                table.Visible = true;
                table.Enabled = true;
            }
        }

        private void LoadAllImages()
        {
            ThisImageClear(PicPortraitTemp);
            ThisImageClear(PicPortraitLrg);
            ThisImageClear(PicPortraitMed);
            ThisImageClear(PicPortraitSml);
            PicPortraitTemp.Image = new Bitmap("temp/temp_portrait.png");
            PicPortraitLrg.Image = new Bitmap("temp/temp_portrait.png");
            PicPortraitMed.Image = new Bitmap("temp/temp_portrait.png");
            PicPortraitSml.Image = new Bitmap("temp/temp_portrait.png");
        }

        //--------------------------------------------------------------------------------------------------------------

        private void PicOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileAndCopy();
            LoadAllImages();
        }

        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileAndCopy();
            LoadAllImages();
        }

        //--------------------------------------------------------------------------------------------------------------

        public MainForm()
        {
            InitializeComponent();
            AllToNotEnabled();
            AllToDockFill();
            ThisToEnabled(LayMainForm);        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TempClear();
            ThisImageClear(PicPortraitTemp);
            ThisImageClear(PicPortraitLrg);
            ThisImageClear(PicPortraitMed);
            ThisImageClear(PicPortraitSml);
        }

        private void BtnToCreateNew_Click(object sender, EventArgs e)
        {
            AllToNotEnabled();
            ThisToEnabled(LayCreateForm);
        }

        private void BtnBackMainForm_Click(object sender, EventArgs e)
        {
            ThisImageClear(PicPortraitTemp);
            ThisImageClear(PicPortraitLrg);
            ThisImageClear(PicPortraitMed);
            ThisImageClear(PicPortraitSml);
            TempClear();

            AllToNotEnabled();
            ThisToEnabled(LayMainForm);
        }

        private void BtnToScaling_Click(object sender, EventArgs e)
        {          
            AllToNotEnabled();
            ThisToEnabled(LayScalingForm);
        }

        private void BtnBackCreateNew_Click(object sender, EventArgs e)
        {
            ThisImageClear(PicPortraitLrg);
            ThisImageClear(PicPortraitMed);
            ThisImageClear(PicPortraitSml);

            AllToNotEnabled();
            ThisToEnabled(LayCreateForm);
        }
    }
}
