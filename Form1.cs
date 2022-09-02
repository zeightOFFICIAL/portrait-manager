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
        private Point mousept = new Point();
        private int dragging = 0;
        private bool isloaded = false;

        private void OpenFileAndCopy()
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "Choose image",
                Multiselect = false,
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "Image files|*.jpg; *.jpeg; *.gif; *.bmp; *.png",
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                AllImageClear();
                Directory.CreateDirectory("temp/");
                string jointpath = "temp/temp_portrait.png";
                File.Copy(ofd.FileName, jointpath, true);
                isloaded = true;
            }
        }

        private void ThisImageClear(PictureBox image)
        {
            image.Image.Dispose();
            image.Image = PicPortraitTemp.Image = PathfinderKINGPortrait.Properties.Resources._default;
        }

        private void AllImageClear()
        {
            ThisImageClear(PicPortraitTemp);
            ThisImageClear(PicPortraitLrg);
            ThisImageClear(PicPortraitMed);
            ThisImageClear(PicPortraitSml);
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

        private void ThisPanelSetUpScrolling(Panel panel, int verticalmax, int horizontalmax)
        {
            panel.AutoScroll = false;
            panel.VerticalScroll.Minimum = 0;
            panel.HorizontalScroll.Minimum = 0;
            panel.VerticalScroll.Maximum = verticalmax;
            panel.HorizontalScroll.Maximum = horizontalmax;
            panel.VerticalScroll.Visible = true;
            panel.HorizontalScroll.Visible = true;
        }

        private void LoadAllImages()
        {
            if (isloaded == false)
            {
                Directory.CreateDirectory("temp/");
                string jointpath = "temp/temp_portrait.png";
                PicPortraitTemp.Image.Save(jointpath, System.Drawing.Imaging.ImageFormat.Png);

            }
            else if (isloaded == true)
            {
                AllImageClear();
                PicPortraitTemp.Image = new Bitmap("temp/temp_portrait.png");
                PicPortraitLrg.Image = new Bitmap("temp/temp_portrait.png");
                PicPortraitMed.Image = new Bitmap("temp/temp_portrait.png");
                PicPortraitSml.Image = new Bitmap("temp/temp_portrait.png");
                ThisPanelSetUpScrolling(PnlPortraitLrg, PicPortraitLrg.Width, PicPortraitLrg.Width);
                ThisPanelSetUpScrolling(PnlPortraitMed, PicPortraitLrg.Width, PicPortraitLrg.Width);
                ThisPanelSetUpScrolling(PnlPortraitSml, PicPortraitLrg.Width, PicPortraitLrg.Width);
            }
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
            //ScalingImagesInvertSizeMode();
            AllToDockFill();

            AllToNotEnabled();
            ThisToEnabled(LayMainForm);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TempClear();
            AllImageClear();
        }

        private void BtnToCreateNew_Click(object sender, EventArgs e)
        {
            AllToNotEnabled();
            ThisToEnabled(LayCreateForm);
        }

        private void BtnBackMainForm_Click(object sender, EventArgs e)
        {
            AllImageClear();
            isloaded = false;
            TempClear();

            AllToNotEnabled();
            ThisToEnabled(LayMainForm);
        }

        private void BtnToScaling_Click(object sender, EventArgs e)
        {
            if (isloaded == false)
            {
                DialogResult dr = MessageBox.Show("You did not load any images. Continue?", "", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    AllToNotEnabled();
                    ThisToEnabled(LayScalingForm);
                }
            }
            else if (isloaded == true)
            {
                AllToNotEnabled();
                ThisToEnabled(LayScalingForm);
            }
        }

        private void BtnBackCreateNew_Click(object sender, EventArgs e)
        {
            LoadAllImages();

            AllToNotEnabled();
            ThisToEnabled(LayCreateForm);
        }

        private void PicPortraitLrg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                mousept = e.Location;
                dragging = 1;
            }
        }

        private void PicPortraitLrg_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging == 1 && (PicPortraitLrg.Image.Width > this.ClientSize.Width ||
                                  PicPortraitLrg.Image.Height > this.ClientSize.Height))
            {
                PnlPortraitLrg.AutoScrollPosition = new Point(-PnlPortraitLrg.AutoScrollPosition.X + (mousept.X - e.X),
                                                              -PnlPortraitLrg.AutoScrollPosition.Y + (mousept.Y - e.Y));
            }
        }

        private void PicPortraitLrg_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = 0;
        }

        private void PicPortraitMed_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                mousept = e.Location;
                dragging = 2;
            }
        }

        private void PicPortraitMed_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging == 2 && (PicPortraitMed.Image.Width > this.ClientSize.Width ||
                                  PicPortraitMed.Image.Height > this.ClientSize.Height))
            {
                PnlPortraitMed.AutoScrollPosition = new Point(-PnlPortraitMed.AutoScrollPosition.X + (mousept.X - e.X),
                                                              -PnlPortraitMed.AutoScrollPosition.Y + (mousept.Y - e.Y));
            }
        }

        private void PicPortraitMed_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = 0;
        }

        private void PicPortraitSml_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                mousept = e.Location;
                dragging = 3;
            }
        }

        private void PicPortraitSml_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging == 3 && (PicPortraitSml.Image.Width > this.ClientSize.Width ||
                                  PicPortraitSml.Image.Height > this.ClientSize.Height))
            {
                PnlPortraitSml.AutoScrollPosition = new Point(-PnlPortraitSml.AutoScrollPosition.X + (mousept.X - e.X),
                                                              -PnlPortraitSml.AutoScrollPosition.Y + (mousept.Y - e.Y));
            }
        }

        private void PicPortraitSml_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = 0;
        }
    }
}
