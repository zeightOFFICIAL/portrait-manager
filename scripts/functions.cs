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
        private void ClearImages()
        {
            ImageControl.Utils.Replace(PicPortraitTemp, PathfinderKINGPortrait.Properties.Resources._default);
            ImageControl.Utils.Replace(PicPortraitLrg, PathfinderKINGPortrait.Properties.Resources._default);
            ImageControl.Utils.Replace(PicPortraitMed, PathfinderKINGPortrait.Properties.Resources._default);
            ImageControl.Utils.Replace(PicPortraitSml, PathfinderKINGPortrait.Properties.Resources._default);
        }
        private void ResizeImagesAsWindow()
        {
            if (LayScalingForm.Enabled == true)
                using (Image img = new Bitmap(RELATIVEPATH_TO_TEMPPOOR))
                {
                    float aspect_ratio;
                    aspect_ratio = (PicPortraitLrg.Height * 1.0f / PicPortraitLrg.Width * 1.0f);
                    Tuple<int, int> tuple = MapNewWidthHeight(PnlPortraitLrg, aspect_ratio);
                    PicPortraitLrg.Image = ImageControl.Direct.Resize.LowQiality(img, tuple.Item1, tuple.Item2);
                    ArrangeAutoScroll(PnlPortraitLrg, tuple.Item1, tuple.Item2);

                    aspect_ratio = (PicPortraitMed.Height * 1.0f / PicPortraitMed.Width * 1.0f);
                    tuple = MapNewWidthHeight(PnlPortraitMed, aspect_ratio);
                    PicPortraitMed.Image = ImageControl.Direct.Resize.LowQiality(img, tuple.Item1, tuple.Item2);
                    ArrangeAutoScroll(PnlPortraitMed, tuple.Item1, tuple.Item2);

                    aspect_ratio = (PicPortraitSml.Height * 1.0f / PicPortraitSml.Width * 1.0f);
                    tuple = MapNewWidthHeight(PnlPortraitSml, aspect_ratio);
                    PicPortraitSml.Image = ImageControl.Direct.Resize.LowQiality(img, tuple.Item1, tuple.Item2);
                    ArrangeAutoScroll(PnlPortraitSml, tuple.Item1, tuple.Item2);
                }
        } 
        private static Tuple<int, int> MapNewWidthHeight(Panel pnl, float aspect_ratio)
        {
            int width = pnl.Width,
                height = pnl.Height,
                dst_width,
                dst_height;

            dst_height = height;
            dst_width = (int)(height * 1.0f / aspect_ratio * 1.0f);
            if (dst_width < pnl.Width)
            {
                dst_width = width;
                dst_height = (int)(width * 1.0f / (1.0f / aspect_ratio * 1.0f));
            }

            return Tuple.Create(dst_width, dst_height);
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
        private void OverloadDockOnEverything()
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
            ClearImages();
            using (Image img_poor = new Bitmap(RELATIVEPATH_TO_TEMPPOOR))
            {
                PicPortraitLrg.Image = new Bitmap(img_poor);
                PicPortraitMed.Image = new Bitmap(img_poor);
                PicPortraitSml.Image = new Bitmap(img_poor);
            }
            using (Image img_full = new Bitmap(RELATIVEPATH_TO_TEMPFULL))
                PicPortraitTemp.Image = new Bitmap(img_full);
            ArrangeAutoScroll(PnlPortraitLrg, PicPortraitLrg.Height, PicPortraitLrg.Width);
            ArrangeAutoScroll(PnlPortraitMed, PicPortraitLrg.Height, PicPortraitLrg.Width);
            ArrangeAutoScroll(PnlPortraitSml, PicPortraitLrg.Height, PicPortraitLrg.Width);
        }
        public static void ArrangeAutoScroll(Panel pnl, int x_max, int y_max)
        {
            pnl.AutoScroll = false;
            pnl.VerticalScroll.Minimum = 0;
            pnl.HorizontalScroll.Minimum = 0;
            pnl.VerticalScroll.Maximum = x_max;
            pnl.HorizontalScroll.Maximum = y_max;
            pnl.VerticalScroll.Visible = true;
            pnl.HorizontalScroll.Visible = true;
        }
    }
}
