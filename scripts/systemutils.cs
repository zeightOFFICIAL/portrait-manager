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
        public static void OpenFileAndCopy()
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
                Directory.CreateDirectory("temp/");
                string jointpath = "temp/temp_portrait.png";
                File.Copy(ofd.FileName, jointpath, true);
            }
            else
            {
                Directory.CreateDirectory("temp/");
                string jointpath = "temp/temp_portrait.png";
                PathfinderKINGPortrait.Properties.Resources._default.Save(jointpath);
            }
        }

        public static void TempClear()
        {
            if (Directory.Exists("temp/")) Directory.Delete("temp/", true);
        }
    }
}