/*    
    Pathfinder Portrait Manager. Desktop application for managing in game
    portraits for Pathfinder: Kingmaker and Pathfinder: Wrath of the Righteous
    Copyright (C) 2023 Artemii "Zeight" Saganenko
    LICENSE terms are written in LICENSE file
    Primal license header is written in Program.cs
*/

using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SystemControl
{
    public class FileControl
    {
        private static readonly string[] EXTENSIONS_ALLOWED = { ".jpg", ".jpeg", ".gif", ".bmp", ".png"};
        public static string OpenFileLocation()
        {
            string fullPath;
            OpenFileDialog OpenFileDialog = new OpenFileDialog()
            {
                Title = PathfinderPortraitManager.Properties.TextVariables.TEXT_TITLEOPENFILE,
                Multiselect = false,
                CheckFileExists = true,
                CheckPathExists = true,
                SupportMultiDottedExtensions = false,
                Filter = PathfinderPortraitManager.Properties.TextVariables.TEXT_IMAGEFILTER + "|*.jpg; *.jpeg; *.gif; *.bmp; *.png;| |*.*",
            };
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (EXTENSIONS_ALLOWED.Contains(Path.GetExtension(OpenFileDialog.FileName))) {
                    fullPath = OpenFileDialog.FileName;
                }
                else
                {
                    fullPath = "!NONESELECTED!";
                }
            }
            else
            {
                fullPath = "!NONESELECTED!";
            }
            OpenFileDialog.Dispose();
            return fullPath;
        }
        public static void TempImagesCreate(string newImagePath, string tempPathFull, string tempPathPoor, Image defaultImg)
        {
            if (!DirectoryExists("temp/"))
                DirectoryCreate("temp/");
            if (newImagePath == "!DEFAULT!" || newImagePath == "!NONESELECTED!")
            {
                using (Image img = new Bitmap(defaultImg))
                {
                    img.Save(tempPathFull);
                    img.Save(tempPathPoor);
                }
            }
            else
            {
                using (Image img = new Bitmap(newImagePath))
                {
                    img.Save(tempPathFull);
                    ImageControl.Wraps.CreatePoorImage(img, tempPathPoor);
                }
            }
        }
        public static void TempImagesClear()
        {
            DirectoryDeleteRecursive("temp/");
        }
        public static void DirectoryDeleteRecursive(string path)
        {
            try
            {
                if (DirectoryExists(path))
                    Directory.Delete(path, true);
            }
            catch (IOException)
            {
                return;
            }
        }
        public static bool DirectoryExists(string path)
        {
            if (Directory.Exists(path))
                return true;
            else
                return false;
        }
        public static bool DirectoryCreate(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (IOException)
            {
                return false;
            }
            return true;
        }
        public static bool FileExist(string path, string filename)
        {
            if (File.Exists(path + filename))
                return true;
            else
                return false;
        }
        public static string GetFileExtension(string path, string filename)
        {
            return Path.GetExtension(path + filename);
        }
        public static PrivateFontCollection InitCustomFont(byte[] font)
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            int fontLength = font.Length;
            byte[] fontData = font;
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontData, 0, data, fontLength);
            pfc.AddMemoryFont(data, fontLength);
            return pfc;
        }
        public static bool CheckImagePixeling(string path, int width, int height)
        {
            using (Bitmap img = new Bitmap(path))
            {
                if (img.Width == width && img.Height == height)
                {
                    return true;
                }
            }
            return false;
        }
        public static void CopyFile(string formPath, string toPath)
        {
            try
            {
                File.Copy(formPath, toPath, true);
            }
            catch (IOException)
            {
                return;
            }
        }
    }
}