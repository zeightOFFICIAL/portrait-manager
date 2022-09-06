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
            return fullpath;
        }
        public static void CreateTemp(string fullpath)
        {
            string relativepath_full = "temp/portrait_full.png",
                   relativepath_poor = "temp/portrait_poor.png";
            float aspect_ratio;

            if (!Directory.Exists("temp/")) Directory.CreateDirectory("temp/");
            if (fullpath != "-1")
            {
                Image img = new Bitmap(fullpath);
                aspect_ratio = img.Width * 1.0f / img.Height * 1.0f;
                Image img_poor = ImageControl.Direct.Resize.HighQiality(img, (int)(760 * aspect_ratio), (int)(760));
                img.Save(relativepath_full);
                img_poor.Save(relativepath_poor);
                img.Dispose();
                img_poor.Dispose();
            }
            else
            {
                Image img = new Bitmap(PathfinderKINGPortrait.Properties.Resources._default);
                img.Save(relativepath_full);
                img.Save(relativepath_poor);
                img.Dispose();
            }
        }
        public static void TempClear()
        {
            if (Directory.Exists("temp/")) Directory.Delete("temp/", true);
        }
    }
}