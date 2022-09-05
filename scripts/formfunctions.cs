using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PathfinderKINGPortrait
{
    public partial class MainForm : Form
    {
        private void AllImageClear()
        {
            ImageControl.Utils.Clear(PicPortraitTemp);
            ImageControl.Utils.Clear(PicPortraitLrg);
            ImageControl.Utils.Clear(PicPortraitMed);
            ImageControl.Utils.Clear(PicPortraitSml);
        }
        private void AllToNotEnabled()
        {
            LayMainForm.Visible = false;
            LayMainForm.Enabled = false;

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
            AllImageClear();
            string relativepath_full = "temp/portrait_full.png",
                   relativepath_poor = "temp/portrait_poor.png",
                   relativepath_half = "temp/portrait_half.png";
            Image img_poor = new Bitmap(relativepath_poor),
                  img_half = new Bitmap(relativepath_half),
                  img_full = new Bitmap(relativepath_full);
            PicPortraitTemp.Image = new Bitmap(img_full);
            PicPortraitLrg.Image = new Bitmap(img_half);
            PicPortraitMed.Image = new Bitmap(img_poor);
            PicPortraitSml.Image = new Bitmap(img_half);
            ImageControl.Utils.ArrangePanel(PnlPortraitLrg, PicPortraitLrg.Height, PicPortraitLrg.Width);
            ImageControl.Utils.ArrangePanel(PnlPortraitMed, PicPortraitLrg.Height, PicPortraitLrg.Width);
            ImageControl.Utils.ArrangePanel(PnlPortraitSml, PicPortraitLrg.Height, PicPortraitLrg.Width);
        }
    }
}
