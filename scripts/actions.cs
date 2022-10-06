using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace PathfinderKINGPortrait
{
    public partial class MainForm : Form
    {
        private void PicPortraitTemp_DragDrop(object sender, DragEventArgs e)
        {
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
                if (is_loaded == true)
                {
                    LoadAllImages();
                    return;
                }
                is_loaded = false;
            }
            else
                is_loaded = true;
            ClearImages();
            SystemControl.FileControl.CreateTemp(fullpath, RELATIVEPATH_TO_TEMPFULL, RELATIVEPATH_TO_TEMPPOOR);
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
            string fullpath = SystemControl.FileControl.OpenFile();
            if (fullpath == "-1")
            {
                if (is_loaded == true)
                {
                    LoadAllImages();
                    return;
                }
                is_loaded = false;
            }
            else
                is_loaded = true;
            ClearImages();
            SystemControl.FileControl.CreateTemp(fullpath, RELATIVEPATH_TO_TEMPFULL, RELATIVEPATH_TO_TEMPPOOR);
            LoadAllImages();
        }
        private void BtnLoadPortrait_Click(object sender, EventArgs e)
        {
            string fullpath = SystemControl.FileControl.OpenFile();
            if (fullpath == "-1")
            {
                if (is_loaded == true)
                {
                    LoadAllImages();
                    return;
                }
                is_loaded = false;
            }
            else
                is_loaded = true;
            ClearImages();
            SystemControl.FileControl.CreateTemp(fullpath, RELATIVEPATH_TO_TEMPFULL, RELATIVEPATH_TO_TEMPPOOR);
            LoadAllImages();
        }
        private void PicPortraitLrg_MouseDown(object sender, MouseEventArgs e)
        {
            PnlPortraitLrg.VerticalScroll.Visible = false;
            PnlPortraitLrg.HorizontalScroll.Visible = false;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                mouse_pos = e.Location;
                is_dragging = 1;
            }
        }
        private void PicPortraitLrg_MouseMove(object sender, MouseEventArgs e)
        {
            if (is_dragging == 1 && (PicPortraitLrg.Image.Width > PnlPortraitLrg.Width ||
                                  PicPortraitLrg.Image.Height > PnlPortraitLrg.Height))
            {
                PnlPortraitLrg.AutoScrollPosition = new Point(-PnlPortraitLrg.AutoScrollPosition.X + (mouse_pos.X - e.X),
                                                              -PnlPortraitLrg.AutoScrollPosition.Y + (mouse_pos.Y - e.Y));
            }
        }
        private void PicPortraitLrg_MouseUp(object sender, MouseEventArgs e)
        {
            PnlPortraitLrg.VerticalScroll.Visible = false;
            PnlPortraitLrg.HorizontalScroll.Visible = false;
            is_dragging = 0;
        }
        private void PicPortraitMed_MouseDown(object sender, MouseEventArgs e)
        {
            PnlPortraitMed.VerticalScroll.Visible = false;
            PnlPortraitMed.HorizontalScroll.Visible = false;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                mouse_pos = e.Location;
                is_dragging = 2;
            }
        }
        private void PicPortraitMed_MouseMove(object sender, MouseEventArgs e)
        {
            if (is_dragging == 2 && (PicPortraitMed.Image.Width > PnlPortraitMed.Width ||
                                  PicPortraitMed.Image.Height > PnlPortraitMed.Height))
            {
                PnlPortraitMed.AutoScrollPosition = new Point(-PnlPortraitMed.AutoScrollPosition.X + (mouse_pos.X - e.X),
                                                              -PnlPortraitMed.AutoScrollPosition.Y + (mouse_pos.Y - e.Y));
            }
        }
        private void PicPortraitMed_MouseUp(object sender, MouseEventArgs e)
        {
            PnlPortraitMed.VerticalScroll.Visible = false;
            PnlPortraitMed.HorizontalScroll.Visible = false;
            is_dragging = 0;
        }
        private void PicPortraitSml_MouseDown(object sender, MouseEventArgs e)
        {
            PnlPortraitSml.VerticalScroll.Visible = false;
            PnlPortraitSml.HorizontalScroll.Visible = false;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                mouse_pos = e.Location;
                is_dragging = 3;
            }
        }
        private void PicPortraitSml_MouseMove(object sender, MouseEventArgs e)
        {
            if (is_dragging == 3 && (PicPortraitSml.Image.Width > PnlPortraitSml.Width ||
                                  PicPortraitSml.Image.Height > PnlPortraitSml.Height))
            {
                PnlPortraitSml.AutoScrollPosition = new Point(-PnlPortraitSml.AutoScrollPosition.X + (mouse_pos.X - e.X),
                                                              -PnlPortraitSml.AutoScrollPosition.Y + (mouse_pos.Y - e.Y));
            }
        }
        private void PicPortraitSml_MouseUp(object sender, MouseEventArgs e)
        {
            PnlPortraitSml.VerticalScroll.Visible = false;
            PnlPortraitSml.HorizontalScroll.Visible = false;
            is_dragging = 0;
        }
        private void PicPortraitLrg_MouseWheel(object sender, MouseEventArgs e)
        {
            float aspect_ratio = (PicPortraitLrg.Width * 1.0f / PicPortraitLrg.Height * 1.0f),
                  factor;
            if (e.Delta > 0)
            {
                factor = PicPortraitLrg.Width * 1.0f / 8;
                ImageControl.Direct.Zoom(PicPortraitLrg, PnlPortraitLrg, e, RELATIVEPATH_TO_TEMPPOOR, aspect_ratio, factor);
            }
            else
            {
                factor = -PicPortraitLrg.Width * 1.0f / 8;
                ImageControl.Direct.Zoom(PicPortraitLrg, PnlPortraitLrg, e, RELATIVEPATH_TO_TEMPPOOR, aspect_ratio, factor);
            }
        }
        private void PicPortraitMed_MouseWheel(object sender, MouseEventArgs e)
        {
            float aspect_ratio = (PicPortraitMed.Width * 1.0f / PicPortraitMed.Height * 1.0f),
                  factor;
            if (e.Delta > 0)
            {
                factor = PicPortraitMed.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitMed, PnlPortraitMed, e, RELATIVEPATH_TO_TEMPPOOR, aspect_ratio, factor);
            }
            else
            {
                factor = -PicPortraitMed.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitMed, PnlPortraitMed, e, RELATIVEPATH_TO_TEMPPOOR, aspect_ratio, factor);
            }
        }
        private void PicPortraitSml_MouseWheel(object sender, MouseEventArgs e)
        {
            float aspect_ratio = (PicPortraitSml.Width * 1.0f / PicPortraitSml.Height * 1.0f),
                  factor;
            if (e.Delta > 0)
            {
                factor = PicPortraitSml.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitSml, PnlPortraitSml, e, RELATIVEPATH_TO_TEMPPOOR, aspect_ratio, factor);
            }
            else
            {
                factor = -PicPortraitSml.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitSml, PnlPortraitSml, e, RELATIVEPATH_TO_TEMPPOOR, aspect_ratio, factor);
            }
        }
        private void MainForm_Closed(object sender, FormClosedEventArgs e)
        {
            ClearImages();
            SystemControl.FileControl.TempClear();
            Application.Exit();
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
            ResizeAllImagesAsWindow();
        }
        private void BtnCreatePortrait_Click(object sender, EventArgs e)
        {
            string exoduspath,
                   fullexoduspath;
            exoduspath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow") +
                         "\\Owlcat Games\\Pathfinder Kingmaker\\Portraits";
            fullexoduspath = "";
            if(!SystemControl.FileControl.DirExists(exoduspath))
            {
                DialogResult dr = MessageBox.Show("Pathfinder: Kingmaker portraits folder was not found.", "Directory not found!", MessageBoxButtons.OK);
                return;
            }
            bool findplace = false;
            uint localname = 1000;
            while (findplace == false)
            {
                fullexoduspath = exoduspath + "\\" + Convert.ToString(localname);
                if (!Directory.Exists(fullexoduspath))
                {
                    Directory.CreateDirectory(fullexoduspath);
                    ImageControl.Wraps.CropImage(PicPortraitLrg, PnlPortraitLrg, RELATIVEPATH_TO_TEMPFULL, 
                                                 fullexoduspath + LARGE_EXTENRSION, 
                                                 ASPECT_RATIO_LARGE, 692, 1024);
                    ImageControl.Wraps.CropImage(PicPortraitMed, PnlPortraitMed, RELATIVEPATH_TO_TEMPFULL, 
                                                 fullexoduspath + MEDIUM_EXTENSION, 
                                                 ASPECT_RATIO_MED, 330, 432);
                    ImageControl.Wraps.CropImage(PicPortraitSml, PnlPortraitSml, RELATIVEPATH_TO_TEMPFULL, 
                                                 fullexoduspath + SMALL_EXTENSION, 
                                                 ASPECT_RATIO_SMALL, 185, 242);
                    findplace = true;
                }
                localname++;
            }
            if (CheckExistence(fullexoduspath))
            {
                using (scripts.finaldialog fd = new scripts.finaldialog())
                {
                    fd.ShowDialog();
                    if (fd.return_state == 1)
                    {
                        ClearImages();
                        is_loaded = false;
                        AllToNotEnabled();
                        ThisToEnabled(LayMainForm);
                    }
                    else if (fd.return_state == 2)
                    {
                        ClearImages();
                        is_loaded = false;
                        SystemControl.FileControl.CreateTemp("-1", RELATIVEPATH_TO_TEMPFULL, RELATIVEPATH_TO_TEMPPOOR);
                        LoadAllImages();
                        AllToNotEnabled();
                        ThisToEnabled(LayCreateForm);
                        ResizeAllImagesAsWindow();
                    }
                    else if (fd.return_state == 3)
                    {
                        ClearImages();
                        is_loaded = false;
                        AllToNotEnabled();
                        System.Diagnostics.Process.Start(fullexoduspath);
                        ThisToEnabled(LayMainForm);
                    }
                }
            }
            else 
            {
                DialogResult dr = MessageBox.Show("Program was unable to load any images into portraits folder.", "No images load!", MessageBoxButtons.OK);
                return;
            }
        }
        private void PicPortraitMed_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            using (Image img = new Bitmap(RELATIVEPATH_TO_TEMPPOOR))
                ResizeImageAsWindow(PicPortraitMed, img, PnlPortraitMed);
        }
        private void PicPortraitLrg_MouseDoubleClick(object sedner, MouseEventArgs e)
        {
            using (Image img = new Bitmap(RELATIVEPATH_TO_TEMPPOOR))
                ResizeImageAsWindow(PicPortraitLrg, img, PnlPortraitLrg);
        }
        private void PicPortraitSml_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            using (Image img = new Bitmap(RELATIVEPATH_TO_TEMPPOOR))
                ResizeImageAsWindow(PicPortraitSml, img, PnlPortraitSml);
        }
    }
}