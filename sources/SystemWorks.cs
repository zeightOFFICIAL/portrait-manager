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
using System;

namespace SystemControl
{
    public class FileControl
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        private static readonly string[] EXTENSIONS_ALLOWED = { ".jpg", ".jpeg", ".gif", ".bmp", ".png"};
        public static string OpenFileLocation()
        {
            string fullPath;
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = PathfinderPortraitManager.Properties.TextVariables.TEXT_TITLEOPENFILE,
                Multiselect = false,
                CheckFileExists = true,
                CheckPathExists = true,
                SupportMultiDottedExtensions = false,
                Filter = PathfinderPortraitManager.Properties.TextVariables.TEXT_IMAGEFILTER + "|*.jpg; *.jpeg; *.gif; *.bmp; *.png;| |*.*",
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (EXTENSIONS_ALLOWED.Contains(Path.GetExtension(openFileDialog.FileName))) 
                {
                    fullPath = openFileDialog.FileName;
                }
                else
                {
                    fullPath = "!NONE!";
                }
            }
            else
            {
                fullPath = "!NONE!";
            }
            openFileDialog.Dispose();
            return fullPath;
        }
        public static void TempImagesCreate(string newPath, string[] tempPaths, Image defaultImg, ushort flag = 0)
        {
            DirectoryCreate("temp/");
            if (newPath == "!DEFAULT!" || newPath == "!NONESELECTED!" || newPath == "!NONE!")
            {
                using (Image img = new Bitmap(defaultImg))
                {
                    if (flag == 1)
                    {
                        img.Save(tempPaths[1]);
                    }
                    else if (flag == 2)
                    {
                        img.Save(tempPaths[2]);
                    }
                    else
                    {
                        img.Save(tempPaths[0]);
                        img.Save(tempPaths[1]);
                        img.Save(tempPaths[2]);
                    }
                }
            }
            else
            {
                using (Image img = new Bitmap(newPath))
                {
                    if (flag == 1)
                    {
                        img.Save(tempPaths[1]);
                    }
                    else if (flag == 2)
                    {
                        img.Save(tempPaths[2]);
                    }
                    else
                    {
                        img.Save(tempPaths[0]);
                        img.Save(tempPaths[1]);
                        img.Save(tempPaths[2]);
                    }
                }
            }
        }
        public static void TempImagesClear()
        {
            DirectoryDeleteRecursive("temp/");
        }
        public static void FileDelete(string path, string filename)
        {
            try
            {
                if (FileExist(path, filename))
                {
                    File.Delete(path + filename);
                }
            }
            catch
            {
                return;
            }
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
            byte[] fontData = font;
            IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
            Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            pfc.AddMemoryFont(fontPtr, font.Length);
            AddFontMemResourceEx(fontPtr, (uint)font.Length, IntPtr.Zero, ref dummy);
            Marshal.FreeCoTaskMem(fontPtr);
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