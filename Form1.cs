using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;


namespace PathfinderKINGPortrait
{
    public partial class MainForm : Form
    {
        private Point mousept = new Point();
        private int dragging = 0;

        public MainForm()
        {
            InitializeComponent();
            PicPortraitLrg.MouseWheel += PicPortraitLrg_MouseWheel;
            PicPortraitMed.MouseWheel += PicPortraitMed_MouseWheel;
            PicPortraitSml.MouseWheel += PicPortraitSml_MouseWheel;
            AllToDockFill();

            AllToNotEnabled();
            ThisToEnabled(LayMainForm);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SystemControl.FileControl.TempClear();
            AllImageClear();
        }

        private void Btn_ToCreateNew_Click(object sender, EventArgs e)
        {
            AllToNotEnabled();
            ThisToEnabled(LayCreateForm);
        }

        private void BtnBackMainForm_Click(object sender, EventArgs e)
        {
            AllImageClear();
            SystemControl.FileControl.TempClear();

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
                    isloaded = true;
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
            PnlPortraitLrg.VerticalScroll.Visible = false;
            PnlPortraitLrg.HorizontalScroll.Visible = false;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                mousept = e.Location;
                dragging = 1;
            }
        }

        private void PicPortraitLrg_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging == 1 && (PicPortraitLrg.Image.Width > PnlPortraitLrg.Width ||
                                  PicPortraitLrg.Image.Height > PnlPortraitLrg.Height))
            {
                PnlPortraitLrg.AutoScrollPosition = new Point(-PnlPortraitLrg.AutoScrollPosition.X + (mousept.X - e.X),
                                                              -PnlPortraitLrg.AutoScrollPosition.Y + (mousept.Y - e.Y));
            }
        }

        private void PicPortraitLrg_MouseUp(object sender, MouseEventArgs e)
        {
            PnlPortraitLrg.VerticalScroll.Visible = false;
            PnlPortraitLrg.HorizontalScroll.Visible = false;
            dragging = 0;
        }

        private void PicPortraitMed_MouseDown(object sender, MouseEventArgs e)
        {
            PnlPortraitMed.VerticalScroll.Visible = false;
            PnlPortraitMed.HorizontalScroll.Visible = false;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                mousept = e.Location;
                dragging = 2;
            }
        }

        private void PicPortraitMed_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging == 2 && (PicPortraitMed.Image.Width > PnlPortraitMed.Width ||
                                  PicPortraitMed.Image.Height > PnlPortraitMed.Height))
            {
                PnlPortraitMed.AutoScrollPosition = new Point(-PnlPortraitMed.AutoScrollPosition.X + (mousept.X - e.X),
                                                              -PnlPortraitMed.AutoScrollPosition.Y + (mousept.Y - e.Y));
            }
        }

        private void PicPortraitMed_MouseUp(object sender, MouseEventArgs e)
        {
            PnlPortraitMed.VerticalScroll.Visible = false;
            PnlPortraitMed.HorizontalScroll.Visible = false;
            dragging = 0;
        }

        private void PicPortraitSml_MouseDown(object sender, MouseEventArgs e)
        {
            PnlPortraitSml.VerticalScroll.Visible = false;
            PnlPortraitSml.HorizontalScroll.Visible = false;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                mousept = e.Location;
                dragging = 3;
            }
        }

        private void PicPortraitSml_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging == 3 && (PicPortraitSml.Image.Width > PnlPortraitSml.Width ||
                                  PicPortraitSml.Image.Height > PnlPortraitSml.Height))
            {
                PnlPortraitSml.AutoScrollPosition = new Point(-PnlPortraitSml.AutoScrollPosition.X + (mousept.X - e.X),
                                                              -PnlPortraitSml.AutoScrollPosition.Y + (mousept.Y - e.Y));
            }
        }

        private void PicPortraitSml_MouseUp(object sender, MouseEventArgs e)
        {
            PnlPortraitSml.VerticalScroll.Visible = false;
            PnlPortraitSml.HorizontalScroll.Visible = false;
            dragging = 0;
        }
        




        private void PicPortraitLrg_MouseWheel(object sender, MouseEventArgs e)
        {
            float aspect_ratio = (PicPortraitLrg.Width * 1.0f / PicPortraitLrg.Height * 1.0f);
            float factor;
            Bitmap img = new Bitmap("temp/temp_portrait.png");

            if (e.Delta > 0)
            {
                factor = PicPortraitLrg.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitLrg, PnlPortraitLrg, e, aspect_ratio, factor);
            }
            else
            {
                factor = -PicPortraitLrg.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitLrg, PnlPortraitLrg, e, aspect_ratio, factor);
            }
        }

        private void PicPortraitMed_MouseWheel(object sender, MouseEventArgs e)
        {
            float aspect_ratio = (PicPortraitMed.Width * 1.0f / PicPortraitMed.Height * 1.0f);
            float factor;
            Bitmap img = new Bitmap("temp/temp_portrait.png");

            if (e.Delta > 0)
            {
                factor = PicPortraitMed.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitMed, PnlPortraitMed, e, aspect_ratio, factor);
            }
            else
            {
                factor = -PicPortraitMed.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitMed, PnlPortraitMed, e, aspect_ratio, factor);
            }
        }

        private void PicPortraitSml_MouseWheel(object sender, MouseEventArgs e)
        {
            float aspect_ratio = (PicPortraitSml.Width * 1.0f / PicPortraitSml.Height * 1.0f);
            float factor;
            Bitmap img = new Bitmap("temp/temp_portrait.png");

            if (e.Delta > 0)
            {
                factor = PicPortraitSml.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitSml, PnlPortraitSml, e, aspect_ratio, factor);
            }
            else
            {
                factor = -PicPortraitSml.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitSml, PnlPortraitSml, e, aspect_ratio, factor);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Closed(object sender, FormClosedEventArgs e)
        {
            SystemControl.FileControl.TempClear();
        }
    }
}
