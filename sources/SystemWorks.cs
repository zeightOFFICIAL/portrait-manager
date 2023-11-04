/*    
    Pathfinder Portrait Manager. Desktop application for managing in game
    portraits for Pathfinder: Kingmaker and Pathfinder: Wrath of the Righteous
    Copyright (C) 2023 Artemii "Zeight" Saganenko
    LICENSE terms are written in LICENSE file
    Primal license header is written in Program.cs
*/

using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SystemControl
{
    public class FileControl
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        private static readonly string[] EXTENSIONS_ALLOWED = { ".jpg", ".jpeg", ".gif", ".bmp", ".png" };
        private const string TYPE_FILTER = "|*.jpg; *.jpeg; *.gif; *.bmp; *.png;| |*.*";
        public class Readonly
        {
            public static bool DirectoryExists(string path)
            {
                return Directory.Exists(path);
            }
            public static bool FileExist(string path)
            {
                return File.Exists(path);
            }
            public static bool CheckImagePixeling(string path, int expectedWidth, int expectedHeight)
            {
                using (Bitmap img = new Bitmap(path))
                {
                    if (img.Width <= expectedWidth + 2 && img.Height <= expectedHeight + 3 &&
                        img.Width >= expectedWidth - 2 && img.Height >= expectedHeight - 3)
                    {
                        img.Dispose();
                        return true;
                    }
                }

                return false;
            }
            public static string GetFileExtension(string path)
            {
                return Path.GetExtension(path);
            }
        }
        public static string OpenFileLocation()
        {
            string filter = PathfinderPortraitManager.Properties.TextVariables.TEXT_IMAGEFILTER + TYPE_FILTER;

            using (OpenFileDialog Dialog = new OpenFileDialog()
            {
                Title = PathfinderPortraitManager.Properties.TextVariables.TEXT_TITLEOPENFILE,
                Multiselect = false,
                CheckFileExists = true,
                CheckPathExists = true,
                SupportMultiDottedExtensions = false,
                Filter = filter,
            })
            {
                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    string extension = Readonly.GetFileExtension(Dialog.FileName);

                    if (EXTENSIONS_ALLOWED.Contains(extension))
                    {
                        return Dialog.FileName;
                    }
                    else
                    {
                        return "!NONE!";
                    }
                }
                else
                {
                    return "!NONE!";
                }
            }
        }
        public static void CreateTempImages(string newPath, string[] tempAppends, Image defaultImg, ushort flag = 0)
        {
            if (!CreateDirectory("temp_DoNotDeleteWhileRunning/"))
            {
                return;
            }

            if (newPath == "!DEFAULT!" || newPath == "!NONESELECTED!" || newPath == "!NONE!")
            {
                using (Image img = new Bitmap(defaultImg))
                {
                    if (flag == 1)
                    {
                        img.Save(tempAppends[1]);
                    }
                    else if (flag == 2)
                    {
                        img.Save(tempAppends[2]);
                    }
                    else if (flag == 100 || flag == 0)
                    {
                        img.Save(tempAppends[0]);
                        img.Save(tempAppends[1]);
                        img.Save(tempAppends[2]);
                    }
                }
            }
            else
            {
                using (Image img = new Bitmap(newPath))
                {
                    if (flag == 1)
                    {
                        img.Save(tempAppends[1]);
                    }
                    else if (flag == 2)
                    {
                        img.Save(tempAppends[2]);
                    }
                    else if (flag == 100 || flag == 0)
                    {
                        img.Save(tempAppends[0]);
                        img.Save(tempAppends[1]);
                        img.Save(tempAppends[2]);
                    }
                }
            }
        }
        public static void ClearTempImages()
        {
            DeleteDirectoryRecursive("temp_DoNotDeleteWhileRunning/");
        }
        public static bool DeleteFile(string path)
        {
            try
            {
                if (Readonly.FileExist(path))
                {
                    File.Delete(path);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public static bool DeleteDirectoryRecursive(string path)
        {
            try
            {
                if (Readonly.DirectoryExists(path))
                {
                    Directory.Delete(path, true);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public static bool CreateDirectory(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static PrivateFontCollection InitCustomFont(byte[] font)
        {
            PrivateFontCollection fontCollection = new PrivateFontCollection();
            byte[] fontData = font;
            uint dummy = 0;

            IntPtr fontPointer = Marshal.AllocCoTaskMem(fontData.Length);
            Marshal.Copy(fontData, 0, fontPointer, fontData.Length);
            fontCollection.AddMemoryFont(fontPointer, font.Length);
            AddFontMemResourceEx(fontPointer, (uint)font.Length, IntPtr.Zero, ref dummy);
            Marshal.FreeCoTaskMem(fontPointer);
            return fontCollection;
        }
        public static bool CopyFile(string fromPath, string toPath)
        {
            try
            {
                File.Copy(fromPath, toPath, true);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}