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

namespace SystemControl
{
    public class FileControl
    {
        public static string OpenFileImage()
        {
            string fullpath;
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "Choose image",
                Multiselect = false,
                CheckFileExists = true,
                CheckPathExists = true,
                SupportMultiDottedExtensions = false,
                Filter = "Image files|*.jpg; *.jpeg; *.gif; *.bmp; *.png",
            };
            if (ofd.ShowDialog() == DialogResult.OK)
                fullpath = ofd.FileName;
            else
                fullpath = "-1";
            ofd.Dispose();
            return fullpath;
        }
        public static void CreateTemp(string fullpath)
        {
            string relativepath_full = "temp/portrait_full.png",
                   relativepath_poor = "temp/portrait_poor.png";
            float aspect_ratio, decrease_power;

            if (!Directory.Exists("temp/")) Directory.CreateDirectory("temp/");
            if (fullpath == "-1")
            {
                Image img = new Bitmap(PathfinderKINGPortrait.Properties.Resources._default);
                img.Save(relativepath_full);
                img.Save(relativepath_poor);
                img.Dispose();
            }
            else
            {
                Image img = new Bitmap(fullpath);
                aspect_ratio = img.Width * 1.0f / img.Height * 1.0f;
                decrease_power = img.Width * 1.0f / 100 * 50;
                Image img_poor = ImageControl.Direct.Resize.LowQialityResize(img, (int)(decrease_power * aspect_ratio), (int)(decrease_power));
                img.Save(relativepath_full);
                img_poor.Save(relativepath_poor);
                img.Dispose();
                img_poor.Dispose();
            }
            
        }
        public static void TempClear()
        {
            if (Directory.Exists("temp/")) Directory.Delete("temp/", true);
        }
    }
}