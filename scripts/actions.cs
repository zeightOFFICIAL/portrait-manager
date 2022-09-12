using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace PathfinderKINGPortrait
{
    public partial class MainForm : Form
    {
        bool isloaded = false;
        private void PicPortraitTemp_DragDrop(object sender, DragEventArgs e)
        {
            Console.WriteLine("+");
            string[] filelist = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string fullpath = "-1";
            if (filelist[0] != null && File.Exists(filelist[0]) &&
                (Path.GetExtension(filelist[0]) == ".png") ||
                (Path.GetExtension(filelist[0]) == ".jpg") ||
                (Path.GetExtension(filelist[0]) == ".jpeg")||
                (Path.GetExtension(filelist[0]) == ".bmp") ||
                (Path.GetExtension(filelist[0]) == ".gif"))
                fullpath = filelist[0];
            if (fullpath == "-1")
            {
                if (isloaded == true)
                {
                    LoadAllImages();
                    return;
                }
                isloaded = false;
            }
            else
                isloaded = true;
            AllImageClear();
            SystemControl.FileControl.CreateTemp(fullpath);
            LoadAllImages();

        }
        private void PicPortraitTemp_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void PicPortraitTemp_Click(object sender, EventArgs e)
        {
            string fullpath = SystemControl.FileControl.OpenFileImage();
            if (fullpath == "-1")
            {
                if (isloaded == true)
                {
                    LoadAllImages();
                    return;
                }
                isloaded = false;
            }
            else
                isloaded = true;
            AllImageClear();
            SystemControl.FileControl.CreateTemp(fullpath);
            LoadAllImages();
        }
        private void BtnLoadPortrait_Click(object sender, EventArgs e)
        {
            string fullpath = SystemControl.FileControl.OpenFileImage();
            if (fullpath == "-1")
            {
                if (isloaded == true)
                {
                    LoadAllImages();
                    return;
                }
                isloaded = false;
            }
            else
                isloaded = true;
            AllImageClear();
            SystemControl.FileControl.CreateTemp(fullpath);
            LoadAllImages();
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

            if (e.Delta > 0)
            {
                factor = PicPortraitLrg.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitLrg, PnlPortraitLrg, e, "temp\\portrait_poor.png", aspect_ratio, factor);
            }
            else
            {
                factor = -PicPortraitLrg.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitLrg, PnlPortraitLrg, e, "temp\\portrait_poor.png", aspect_ratio, factor);
            }
        }
        private void PicPortraitMed_MouseWheel(object sender, MouseEventArgs e)
        {
            float aspect_ratio = (PicPortraitMed.Width * 1.0f / PicPortraitMed.Height * 1.0f);
            float factor;

            if (e.Delta > 0)
            {
                factor = PicPortraitMed.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitMed, PnlPortraitMed, e, "temp\\portrait_poor.png", aspect_ratio, factor);
            }
            else
            {
                factor = -PicPortraitMed.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitMed, PnlPortraitMed, e, "temp\\portrait_poor.png", aspect_ratio, factor);
            }
        }
        private void PicPortraitSml_MouseWheel(object sender, MouseEventArgs e)
        {
            float aspect_ratio = (PicPortraitSml.Width * 1.0f / PicPortraitSml.Height * 1.0f);
            float factor;

            if (e.Delta > 0)
            {
                factor = PicPortraitSml.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitSml, PnlPortraitSml, e, "temp\\portrait_poor.png", aspect_ratio, factor);
            }
            else
            {
                factor = -PicPortraitSml.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitSml, PnlPortraitSml, e, "temp\\portrait_poor.png", aspect_ratio, factor);
            }
        }
    }
}