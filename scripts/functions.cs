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
            ImageControl.Utils.Clear(PicPortraitTemp, PathfinderKINGPortrait.Properties.Resources._default);
            ImageControl.Utils.Clear(PicPortraitLrg, PathfinderKINGPortrait.Properties.Resources._default);
            ImageControl.Utils.Clear(PicPortraitMed, PathfinderKINGPortrait.Properties.Resources._default);
            ImageControl.Utils.Clear(PicPortraitSml, PathfinderKINGPortrait.Properties.Resources._default);
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
            string relativepath_full = "temp\\portrait_full.png",
                   relativepath_poor = "temp\\portrait_poor.png";
            using (Image img_poor = new Bitmap(relativepath_poor))
            {
                PicPortraitLrg.Image = new Bitmap(img_poor);
                PicPortraitMed.Image = new Bitmap(img_poor);
                PicPortraitSml.Image = new Bitmap(img_poor);
            }
            using (Image img_full = new Bitmap(relativepath_full))
                PicPortraitTemp.Image = new Bitmap(img_full);
            ImageControl.Utils.ArrangePanel(PnlPortraitLrg, PicPortraitLrg.Height, PicPortraitLrg.Width);
            ImageControl.Utils.ArrangePanel(PnlPortraitMed, PicPortraitLrg.Height, PicPortraitLrg.Width);
            ImageControl.Utils.ArrangePanel(PnlPortraitSml, PicPortraitLrg.Height, PicPortraitLrg.Width);
        }
    }
}
