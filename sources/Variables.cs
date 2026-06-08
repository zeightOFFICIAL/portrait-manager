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
using PortraitManager.forms;
using PortraitManager.Properties;
using PortraitManager.sources;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PortraitManager
{    
    public partial class MainForm : Form
    {
        private static string DetectTyrannyInstall()
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

        private static string DetectDeadfireInstall()
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

        private static string DetectPillarsInstall()
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
        
        private static string DetectOwlcatInstall(string name)
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
        

        private static readonly GameType KING_TYPE = new GameType("Pathfinder: Kingmaker", "Kingmaker", "Portrait Manager: Owlcat (Kingmaker)",
            Resources.path_title, Resources.path_menu_page, Resources.path_placeholder, Resources.path_icon_ico, Color.FromArgb(218, 165, 32), Color.FromArgb(9, 28, 11),
            DetectOwlcatInstall("Pathfinder Kingmaker").Replace("/", "\\"),
            new Dictionary<string, float>
            {
                { "SMALL_WIDTH", 185},
                { "SMALL_HEIGHT", 242},
                { "MEDIUM_WIDTH", 330},
                { "MEDIUM_HEIGHT", 432},
                { "LARGE_WIDTH", 692},
                { "LARGE_HEIGHT", 1024},
                { "SMALL_AR", 1.3081f},
                { "MEDIUM_AR", 1.3091f},
                { "LARGE_AR", 1.4797f}
            });

        private static readonly GameType WOTR_TYPE = new GameType("Pathfinder: Wrath of the Righteous", "Wrath of the Righteous", "Portrait Manager: Owlcat (Wotr)",
            Resources.wotr_title, Resources.wotr_start_page, Resources.wotr_placeholder, Resources.wotr_icon_ico, Color.FromArgb(255, 20, 147), Color.FromArgb(20, 6, 30),
            DetectOwlcatInstall("Pathfinder Wrath Of The Righteous").Replace("/", "\\"),
            new Dictionary<string, float>
            {
                { "SMALL_WIDTH", 185},
                { "SMALL_HEIGHT", 242},
                { "MEDIUM_WIDTH", 330},
                { "MEDIUM_HEIGHT", 432},
                { "LARGE_WIDTH", 692},
                { "LARGE_HEIGHT", 1024},
                { "SMALL_AR", 1.3081f},
                { "MEDIUM_AR", 1.3091f},
                { "LARGE_AR", 1.4797f}
            });

        private static readonly GameType ROGUE_TYPE = new GameType("Warhammer 40K: Rogue Trader", "Rogue Trader", "Portrait Manager: Owlcat (RT)",
            Resources.rt_title, Resources.rt_start_page, Resources.rt_placeholder, Resources.rt_icon_ico, Color.FromArgb(255, 187, 0), Color.FromArgb(5, 0, 42),
            DetectOwlcatInstall("Warhammer 40000 Rogue Trader").Replace("/", "\\"),
            new Dictionary<string, float>
            {
                { "SMALL_WIDTH", 260},
                { "SMALL_HEIGHT", 336},
                { "MEDIUM_WIDTH", 448},
                { "MEDIUM_HEIGHT", 600},
                { "LARGE_WIDTH", 1080},
                { "LARGE_HEIGHT", 1480},
                { "SMALL_AR", 1.2923f},
                { "MEDIUM_AR", 1.3392f},
                { "LARGE_AR", 1.3703f}
            });

        private static readonly GameType PILLARS_TYPE = new GameType("Pillars of Eternity", "Pillars of Eternity", "Portrait Manager: Obsidian (PoE)",
            Resources.poe_title, Resources.poe_start_page, Resources.poe_placeholder, Resources.poe_icon_ico, Color.FromArgb(50, 250, 200), Color.FromArgb(7, 33, 27),
            DetectPillarsInstall().Replace("/", "\\"),
            new Dictionary<string, float>
            {
                { "SMALL_WIDTH", 76},
                { "SMALL_HEIGHT", 96},
                { "LARGE_WIDTH", 210},
                { "LARGE_HEIGHT", 330},
                { "SMALL_AR", 1.2631f},
                { "LARGE_AR", 1.5714f}
            });

        private static readonly GameType DEADFIRE_TYPE = new GameType("Pillars of Eternity: Deadfire", "Deadfire", "Portrait Manager: Obsidian (PoED)",
            Resources.poed_title, Resources.poed_start_page, Resources.poed_placeholder, Resources.poed_icon_ico, Color.FromArgb(50, 250, 200), Color.FromArgb(7, 33, 27),
            DetectDeadfireInstall().Replace("/","\\"),
            new Dictionary<string, float>
            {
                { "SMALL_WIDTH", 76},
                { "SMALL_HEIGHT", 96},
                { "LARGE_CONVO_WIDTH", 90},
                { "LARGE_CONVO_HEIGHT", 141},
                { "LARGE_WIDTH", 210},
                { "LARGE_HEIGHT", 330},
                { "SMALL_AR", 1.2631f},
                { "LARGE_CONVO_AR", 1.5667f},
                { "LARGE_AR", 1.5714f}
            });

        private static readonly GameType TYR_TYPE = new GameType("Tyranny", "Tyranny", "Portrait Manager: Obsidian (Tyranny)",
            Resources.tyr_title, Resources.tyr_start_page, Resources.tyr_placeholder, Resources.tyr_icon_ico, Color.FromArgb(248, 34, 34), Color.FromArgb(43, 3, 3),
            DetectTyrannyInstall().Replace("/","\\"),
            new Dictionary<string, float>
            {
                { "SMALL_WIDTH", 76},
                { "SMALL_HEIGHT", 96},
                { "LARGE_WIDTH", 210},
                { "LARGE_HEIGHT", 330},
                { "SMALL_AR", 1.2631f},
                { "LARGE_AR", 1.5714f}
            });

        private static readonly GameType WASTE_TYPE = new GameType("Wasteland 3", "Wasteland 3", "Portrait Manager: inXile (W3)",
            Resources.waste_title, Resources.waste_start_page, Resources.waste_placeholder, Resources.waste_icon_ico, Color.FromArgb(176, 200, 210), Color.FromArgb(35, 50, 50),
            (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\My Games\\Wasteland3\\"),
            new Dictionary<string, float>
            {
                { "SMALL_WIDTH", 256},
                { "SMALL_HEIGHT", 256},
                { "SMALL_AR", 1.0f},
            });


        private static readonly Dictionary<char, GameType> GameTypes = new Dictionary<char, GameType>
        {
            { 'k', KING_TYPE },
            { 'w', WOTR_TYPE },
            { 'r', ROGUE_TYPE },
            { 't', TYR_TYPE },
            { 'p', PILLARS_TYPE },
            { 'd', DEADFIRE_TYPE },
            { 'l', WASTE_TYPE }
        };
    }
}