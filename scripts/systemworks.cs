using System.Drawing;
using System.Windows.Forms;
using System.IO;

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
            if (!Directory.Exists("temp/")) Directory.CreateDirectory("temp/");
            if (fullpath == "-1")
            {
                using (Image img = new Bitmap(PathfinderKINGPortrait.Properties.Resources._default))
                {
                    img.Save(relativepath_full);
                    img.Save(relativepath_poor);
                }
            }
            else
            {
                using (Image img = new Bitmap(fullpath))
                {
                    img.Save(relativepath_full);
                    ImageControl.Wraps.CreatePoorImage(img, relativepath_poor);
                }
            }
        }
        public static void TempClear()
        {
            if (Directory.Exists("temp/")) Directory.Delete("temp/", true);
        }
    }
}