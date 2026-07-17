/*
    Zeight Portrait Manager
    Desktop application for managing in-game portraits for games from Owlcat Games,
    Obsidian Entertainment and inXile Entertainment.
    Including:
        1. Pathfinder: Kingmaker,
        2. Pathfinder: Wrath of the Righteous,
        3. Warhammer 40000: Rogue Trader,
        4. Pillars of Eternity,
        5. Pillars of Eternity: Deadfire,
        6. Tyranny,
        7. Wasteland 3.
    Copyright (C) 2024 Artemii "Zeight" Saganenko.

    GPL-2.0 license terms are listed in LICENSE.md file.
    License header for this project is listed in Program.cs.
*/
using Microsoft.Win32;

using System;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace SystemControl
{
    public class FileControl
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

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
        }

        public static void ClearTempImages()
        {
            DeleteDirectoryRecursive("temp_DoNotDeleteWhileRunning/");
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

        public static string FindNative7ZipExecutable()
        {
            try
            {
                using (var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\7-Zip") ??
                                  Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\7-Zip"))
                {
                    var path = key?.GetValue("Path") as string;
                    if (!string.IsNullOrEmpty(path))
                    {
                        string exe = Path.Combine(path, "7z.exe");
                        if (File.Exists(exe)) return exe;
                    }
                }
            }
            catch { }

            string[] candidates =
            {
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "7-Zip", "7z.exe"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "7-Zip", "7z.exe"),
            };
            foreach (var candidate in candidates)
                if (File.Exists(candidate)) return candidate;

            return null;
        }

        public static string DetectTyrannyInstall()
        {
            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam"))
                {
                    var steamPath = key?.GetValue("SteamPath") as string;
                    if (!string.IsNullOrEmpty(steamPath))
                    {
                        var steamLibs = new[]
                        {
                            Path.Combine(steamPath, "steamapps", "common", "Tyranny"),
                            Path.Combine(steamPath, "steamapps", "common", "Tyranny - Bastard’s Wound")
                        };

                        foreach (var path in steamLibs)
                        {
                            if (Directory.Exists(Path.Combine(path, "Data", "data", "art", "gui", "icons", "abilities")))
                                return new DirectoryInfo(path).FullName;
                        }

                        var vdf = Path.Combine(steamPath, "steamapps", "libraryfolders.vdf");
                        if (File.Exists(vdf))
                        {
                            foreach (var line in File.ReadAllLines(vdf))
                            {
                                if (!line.Contains(":\\") && !line.Contains("/")) continue;
                                var clean = line.Split('"', (char)StringSplitOptions.RemoveEmptyEntries);
                                foreach (var s in clean)
                                {
                                    if (Directory.Exists(Path.Combine(s, "steamapps", "common", "Tyranny")))
                                    {
                                        var candidate = Path.Combine(s, "steamapps", "common", "Tyranny");
                                        if (Directory.Exists(Path.Combine(candidate, "Data", "data", "art", "gui", "icons", "abilities")))
                                            return new DirectoryInfo(candidate).FullName;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch { }

            try
            {
                using (var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\GOG.com\Games") ??
                                 Registry.LocalMachine.OpenSubKey(@"SOFTWARE\GOG.com\Games"))
                {
                    if (key != null)
                    {
                        foreach (var subKeyName in key.GetSubKeyNames())
                        {
                            using (var subKey = key.OpenSubKey(subKeyName))
                            {
                                var path = subKey?.GetValue("path") as string;
                                if (!string.IsNullOrEmpty(path) &&
                                    Directory.Exists(Path.Combine(path, "Data", "data", "art", "gui", "icons", "abilities")))
                                    return new DirectoryInfo(path).FullName;
                            }
                        }
                    }
                }
            }
            catch { }

            try
            {
                var epicPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                    "Epic Games",
                    "Tyranny"
                );
                if (Directory.Exists(Path.Combine(epicPath, "Data", "data", "art", "gui", "icons", "abilities")))
                    return new DirectoryInfo(epicPath).FullName;
            }
            catch { }

            return "";
        }

        public static string DetectDeadfireInstall()
        {
            string Validate(string path)
            {
                if (Directory.Exists(Path.Combine(path, "PillarsOfEternityII_Data", "gui", "portraits")))
                    return new DirectoryInfo(path).FullName;
                return null;
            }

            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam"))
                {
                    var steamPath = key?.GetValue("SteamPath") as string;
                    if (!string.IsNullOrEmpty(steamPath))
                    {
                        var main = Path.Combine(steamPath, "steamapps", "common", "Pillars of Eternity II");
                        var valid = Validate(main);
                        if (valid != null)
                            return valid;

                        var vdf = Path.Combine(steamPath, "steamapps", "libraryfolders.vdf");
                        if (File.Exists(vdf))
                        {
                            foreach (var line in File.ReadAllLines(vdf))
                            {
                                if (!line.Contains(":\\") && !line.Contains("/")) continue;
                                var clean = line.Split('"', (char)StringSplitOptions.RemoveEmptyEntries);
                                foreach (var s in clean)
                                {
                                    if (Directory.Exists(Path.Combine(s, "steamapps", "common", "Pillars of Eternity II")))
                                    {
                                        valid = Validate(Path.Combine(s, "steamapps", "common", "Pillars of Eternity II"));
                                        if (valid != null)
                                            return valid;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch { }

            try
            {
                using (var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\GOG.com\Games") ??
                                 Registry.LocalMachine.OpenSubKey(@"SOFTWARE\GOG.com\Games"))
                {
                    if (key != null)
                    {
                        foreach (var sub in key.GetSubKeyNames())
                        {
                            using (var subKey = key.OpenSubKey(sub))
                            {
                                var path = subKey?.GetValue("path") as string;
                                if (!string.IsNullOrEmpty(path))
                                {
                                    var valid = Validate(path);
                                    if (valid != null)
                                        return valid;
                                }
                            }
                        }
                    }
                }
            }
            catch { }

            try
            {
                var epicPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                    "Epic Games",
                    "PillarsOfEternityII"
                );
                var valid = Validate(epicPath);
                if (valid != null)
                    return valid;
            }
            catch { }

            return "";
        }

        public static string DetectPillarsInstall()
        {

            string Validate(string path)
            {
                if (Directory.Exists(Path.Combine(path, "PillarsOfEternity_Data", "data", "art", "gui", "portraits")))
                    return new DirectoryInfo(path).FullName;
                return null;
            }

            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam"))
                {
                    var steamPath = key?.GetValue("SteamPath") as string;
                    if (!string.IsNullOrEmpty(steamPath))
                    {
                        var main = Path.Combine(steamPath, "steamapps", "common", "Pillars of Eternity");
                        var valid = Validate(main);
                        if (valid != null)
                            return valid;

                        var vdf = Path.Combine(steamPath, "steamapps", "libraryfolders.vdf");
                        if (File.Exists(vdf))
                        {
                            foreach (var line in File.ReadAllLines(vdf))
                            {
                                if (!line.Contains(":\\") && !line.Contains("/")) continue;
                                var clean = line.Split('"', (char)StringSplitOptions.RemoveEmptyEntries);
                                foreach (var s in clean)
                                {
                                    var candidate = Path.Combine(s, "steamapps", "common", "Pillars of Eternity");
                                    valid = Validate(candidate);
                                    if (valid != null)
                                        return valid;
                                }
                            }
                        }
                    }
                }
            }
            catch { }

            try
            {
                using (var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\GOG.com\Games") ??
                                 Registry.LocalMachine.OpenSubKey(@"SOFTWARE\GOG.com\Games"))
                {
                    if (key != null)
                    {
                        foreach (var sub in key.GetSubKeyNames())
                        {
                            using (var subKey = key.OpenSubKey(sub))
                            {
                                var path = subKey?.GetValue("path") as string;
                                if (!string.IsNullOrEmpty(path))
                                {
                                    var valid = Validate(path);
                                    if (valid != null)
                                        return valid;
                                }
                            }
                        }
                    }
                }
            }
            catch { }

            try
            {
                var epicPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                    "Epic Games",
                    "PillarsOfEternity"
                );
                var valid = Validate(epicPath);
                if (valid != null)
                    return valid;
            }
            catch { }

            return "";
        }

        public static string DetectOwlcatInstall(string name)
        {
            string localLow = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "..",
                "LocalLow"
            );
            localLow = Path.GetFullPath(localLow);

            string path = Path.Combine(
                localLow,
                "Owlcat Games",
                name
            );

            return path;
        }
    }
}
