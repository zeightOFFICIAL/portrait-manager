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
            ImageControl.Utils.Replace(PicPortraitTemp, PathfinderKINGPortrait.Properties.Resources._default);
            ImageControl.Utils.Replace(PicPortraitLrg, PathfinderKINGPortrait.Properties.Resources._default);
            ImageControl.Utils.Replace(PicPortraitMed, PathfinderKINGPortrait.Properties.Resources._default);
            ImageControl.Utils.Replace(PicPortraitSml, PathfinderKINGPortrait.Properties.Resources._default);
        }
        private void AllImageResizeAsWindow()
        {
            if (LayScalingForm.Enabled == true)
                using (Image img = new Bitmap("temp\\portrait_poor.png"))
                {
                    float aspect_ratio;
                    aspect_ratio = (PicPortraitLrg.Height * 1.0f / PicPortraitLrg.Width * 1.0f);
                    Tuple<int, int> tuple = CalculateNewWH(PnlPortraitLrg, img, aspect_ratio);
                    PicPortraitLrg.Image = ImageControl.Direct.Resize.LowQiality(img, (int)tuple.Item1, (int)tuple.Item2);
                    ImageControl.Utils.ArrangeAutoScroll(PnlPortraitLrg, (int)tuple.Item1, (int)tuple.Item2);

                    aspect_ratio = (PicPortraitMed.Height * 1.0f / PicPortraitMed.Width * 1.0f);
                    tuple = CalculateNewWH(PnlPortraitMed, img, aspect_ratio);
                    PicPortraitMed.Image = ImageControl.Direct.Resize.LowQiality(img, (int)tuple.Item1, (int)tuple.Item2);
                    ImageControl.Utils.ArrangeAutoScroll(PnlPortraitMed, (int)tuple.Item1, (int)tuple.Item2);

                    aspect_ratio = (PicPortraitSml.Height * 1.0f / PicPortraitSml.Width * 1.0f);
                    tuple = CalculateNewWH(PnlPortraitSml, img, aspect_ratio);
                    PicPortraitSml.Image = ImageControl.Direct.Resize.LowQiality(img, (int)tuple.Item1, (int)tuple.Item2);
                    ImageControl.Utils.ArrangeAutoScroll(PnlPortraitSml, (int)tuple.Item1, (int)tuple.Item2);
                }
        } 
        private static Tuple<int, int> CalculateNewWH(Panel pnl, Image src_img, float aspect_ratio)
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
            Console.WriteLine(dst_height);
            Console.WriteLine(dst_width);
            Console.WriteLine("--------");
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
            ImageControl.Utils.ArrangeAutoScroll(PnlPortraitLrg, PicPortraitLrg.Height, PicPortraitLrg.Width);
            ImageControl.Utils.ArrangeAutoScroll(PnlPortraitMed, PicPortraitLrg.Height, PicPortraitLrg.Width);
            ImageControl.Utils.ArrangeAutoScroll(PnlPortraitSml, PicPortraitLrg.Height, PicPortraitLrg.Width);
        }
    }
}
