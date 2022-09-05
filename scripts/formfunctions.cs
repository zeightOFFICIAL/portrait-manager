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
            PicPortraitTemp.Image = new Bitmap("temp/temp_portrait.png");
            PicPortraitLrg.Image = new Bitmap("temp/temp_portrait.png");
            PicPortraitMed.Image = new Bitmap("temp/temp_portrait.png");
            PicPortraitSml.Image = new Bitmap("temp/temp_portrait.png");
            ImageControl.Utils.ArrangePanel(PnlPortraitLrg, PicPortraitLrg.Height, PicPortraitLrg.Width);
            ImageControl.Utils.ArrangePanel(PnlPortraitMed, PicPortraitLrg.Height, PicPortraitLrg.Width);
            ImageControl.Utils.ArrangePanel(PnlPortraitSml, PicPortraitLrg.Height, PicPortraitLrg.Width);
        }
    }
}
