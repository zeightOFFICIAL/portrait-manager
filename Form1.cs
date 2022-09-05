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
        private bool isloaded = false;

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

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
                ThisPanelSetUpScrolling(PnlPortraitLrg, PicPortraitLrg.Height, PicPortraitLrg.Width);
                ThisPanelSetUpScrolling(PnlPortraitMed, PicPortraitLrg.Height, PicPortraitLrg.Width);
                ThisPanelSetUpScrolling(PnlPortraitSml, PicPortraitLrg.Height, PicPortraitLrg.Width);
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
            AllToDockFill();
            this.PicPortraitLrg.MouseWheel += PicPortraitLrg_MouseWheel;
            this.PicPortraitMed.MouseWheel += PicPortraitMed_MouseWheel;
            this.PicPortraitSml.MouseWheel += PicPortraitSml_MouseWheel;

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
            isloaded = false;
            AllToNotEnabled();
            ThisToEnabled(LayCreateForm);
        }

        private void BtnBackMainForm_Click(object sender, EventArgs e)
        {
            AllImageClear();
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
            float factor = PicPortraitLrg.Width * 1.0f / 10;
            Bitmap img = new Bitmap("temp/temp_portrait.png");
            int ypos = -PnlPortraitLrg.AutoScrollPosition.Y;

            if (e.Delta > 0)
            {
                double Width = PicPortraitLrg.Width + factor * aspect_ratio;
                double Height = PicPortraitLrg.Height + factor;
                if (Width > PnlPortraitLrg.Width && Height > PnlPortraitLrg.Height)
                {
                    PicPortraitLrg.Image = new Bitmap(ResizeImage(img, Convert.ToInt32(Width), Convert.ToInt32(Height)));
                    ThisPanelSetUpScrolling(PnlPortraitLrg, PicPortraitLrg.Height, PicPortraitLrg.Width);
                    PnlPortraitLrg.AutoScrollPosition = new Point((int)(e.X - PnlPortraitLrg.Width / 2), (int)(e.Y - PnlPortraitLrg.Height / 2));
                }
            }
            else
            {
                double Width = PicPortraitLrg.Width - factor * aspect_ratio;
                double Height = PicPortraitLrg.Height - factor;
                if (Width > PnlPortraitLrg.Width && Height > PnlPortraitLrg.Height)
                {
                    PicPortraitLrg.Image = new Bitmap(ResizeImage(img, Convert.ToInt32(Width), Convert.ToInt32(Height)));
                    ThisPanelSetUpScrolling(PnlPortraitLrg, PicPortraitLrg.Height, PicPortraitLrg.Width);
                    PnlPortraitLrg.AutoScrollPosition = new Point((int)(e.X - PnlPortraitLrg.Width / 2), (int)(e.Y - PnlPortraitLrg.Height / 2));
                }
            }
        }

        private void PicPortraitMed_MouseWheel(object sender, MouseEventArgs e)
        {
            float aspect_ratio = (PicPortraitMed.Width * 1.0f / PicPortraitMed.Height * 1.0f);
            if (e.Delta > 0)
            {
                double Width = PicPortraitMed.Width + 100 * aspect_ratio;
                double Height = PicPortraitMed.Height + 100;
                if (Width > PnlPortraitMed.Width && Height > PnlPortraitMed.Height)
                {
                    PicPortraitMed.Image = new Bitmap(ResizeImage(PicPortraitMed.Image, Convert.ToInt32(Width), Convert.ToInt32(Height)));
                    ThisPanelSetUpScrolling(PnlPortraitMed, PicPortraitMed.Height, PicPortraitMed.Width);
                }
            }
            else
            {
                double Width = PicPortraitMed.Width - 100 * aspect_ratio;
                double Height = PicPortraitMed.Height - 100;
                if (Width > PnlPortraitMed.Width && Height > PnlPortraitMed.Height)
                {
                    PicPortraitMed.Image = new Bitmap(ResizeImage(PicPortraitMed.Image, Convert.ToInt32(Width), Convert.ToInt32(Height)));
                    ThisPanelSetUpScrolling(PnlPortraitMed, PicPortraitMed.Height, PicPortraitMed.Width);
                }
            }
        }

        private void PicPortraitSml_MouseWheel(object sender, MouseEventArgs e)
        {
            float aspect_ratio = (PicPortraitSml.Width * 1.0f / PicPortraitSml.Height * 1.0f);
            if (e.Delta > 0)
            {
                double Width = PicPortraitSml.Width + 100 * aspect_ratio;
                double Height = PicPortraitSml.Height + 100;
                if (Width > PnlPortraitSml.Width && Height > PnlPortraitSml.Height)
                {
                    PicPortraitSml.Image = new Bitmap(ResizeImage(PicPortraitSml.Image, Convert.ToInt32(Width), Convert.ToInt32(Height)));
                    ThisPanelSetUpScrolling(PnlPortraitSml, PicPortraitSml.Height, PicPortraitSml.Width);
                }
            }
            else
            {
                double Width = PicPortraitSml.Width - 100 * aspect_ratio;
                double Height = PicPortraitSml.Height - 100;
                if (Width > PnlPortraitSml.Width && Height > PnlPortraitSml.Height)
                {
                    PicPortraitSml.Image = new Bitmap(ResizeImage(PicPortraitSml.Image, Convert.ToInt32(Width), Convert.ToInt32(Height)));
                    ThisPanelSetUpScrolling(PnlPortraitSml, PicPortraitSml.Height, PicPortraitSml.Width);
                }
            }
        }
    }
}
