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
    Copyright (C) 2023-2026 Artemii "Zeight" Saganenko.

    GPL-2.0 license terms are listed in LICENSE.md file.
    License header for this project is listed in Program.cs.
*/
using PortraitManager.forms;
using PortraitManager.Properties;
using PortraitManager.sources;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PortraitManager
{
    public partial class MainForm : Form
    {

        private static readonly GameType KING_TYPE = new GameType("Pathfinder: Kingmaker", "Kingmaker", "Zeight Portrait Manager: Owlcat (Kingmaker)",
            Resources.path_title, Resources.path_menu_page, Resources.path_placeholder, Resources.taskbar_icon_path, Color.FromArgb(218, 165, 32), Color.FromArgb(9, 28, 11),
            SystemControl.FileControl.DetectOwlcatInstall("Pathfinder Kingmaker").Replace("/", "\\"),
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

        private static readonly GameType WOTR_TYPE = new GameType("Pathfinder: Wrath of the Righteous", "Wrath of the Righteous", "Zeight Portrait Manager: Owlcat (Wotr)",
            Resources.wotr_title, Resources.wotr_start_page, Resources.wotr_placeholder, Resources.taskbar_icon_wotr, Color.FromArgb(255, 20, 147), Color.FromArgb(20, 6, 30),
            SystemControl.FileControl.DetectOwlcatInstall("Pathfinder Wrath Of The Righteous").Replace("/", "\\"),
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

        private static readonly GameType ROGUE_TYPE = new GameType("Warhammer 40K: Rogue Trader", "Rogue Trader", "Zeight Portrait Manager: Owlcat (RT)",
            Resources.rt_title, Resources.rt_start_page, Resources.rt_placeholder, Resources.taskbar_icon_rt, Color.FromArgb(255, 187, 0), Color.FromArgb(5, 0, 42),
            SystemControl.FileControl.DetectOwlcatInstall("Warhammer 40000 Rogue Trader").Replace("/", "\\"),
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

        private static readonly GameType PILLARS_TYPE = new GameType("Pillars of Eternity", "Pillars of Eternity", "Zeight Portrait Manager: Obsidian (PoE)",
            Resources.poe_title, Resources.poe_start_page, Resources.poe_placeholder, Resources.taskbar_icon_poe, Color.FromArgb(50, 250, 200), Color.FromArgb(7, 33, 27),
            SystemControl.FileControl.DetectPillarsInstall().Replace("/", "\\"),
            new Dictionary<string, float>
            {
                { "SMALL_WIDTH", 76},
                { "SMALL_HEIGHT", 96},
                { "LARGE_WIDTH", 210},
                { "LARGE_HEIGHT", 330},
                { "SMALL_AR", 1.2631f},
                { "LARGE_AR", 1.5714f}
            });

        private static readonly GameType DEADFIRE_TYPE = new GameType("Pillars of Eternity: Deadfire", "Deadfire", "Zeight Portrait Manager: Obsidian (PoED)",
            Resources.poed_title, Resources.poed_start_page, Resources.poed_placeholder, Resources.taskbar_icon_poed, Color.FromArgb(50, 250, 200), Color.FromArgb(7, 33, 27),
            SystemControl.FileControl.DetectDeadfireInstall().Replace("/","\\"),
            new Dictionary<string, float>
            {
                { "SMALL_WIDTH", 76},
                { "SMALL_HEIGHT", 96},
                { "MEDIUM_WIDTH", 90},
                { "MEDIUM_HEIGHT", 141},
                { "LARGE_WIDTH", 210},
                { "LARGE_HEIGHT", 330},
                { "SMALL_AR", 1.2631f},
                { "MEDIUM_AR", 1.5667f},
                { "LARGE_AR", 1.5714f},
                { "SML2_WIDTH", 76},
                { "SML2_HEIGHT", 96},
                { "SML2_AR", 1.2631f}
            });

        private static readonly GameType TYR_TYPE = new GameType("Tyranny", "Tyranny", "Zeight Portrait Manager: Obsidian (Tyranny)",
            Resources.tyr_title, Resources.tyr_start_page, Resources.tyr_placeholder, Resources.taskbar_icon_tyr, Color.FromArgb(248, 34, 34), Color.FromArgb(43, 3, 3),
            SystemControl.FileControl.DetectTyrannyInstall().Replace("/","\\"),
            new Dictionary<string, float>
            {
                { "SMALL_WIDTH", 76},
                { "SMALL_HEIGHT", 96},
                { "LARGE_WIDTH", 210},
                { "LARGE_HEIGHT", 330},
                { "SMALL_AR", 1.2631f},
                { "LARGE_AR", 1.5714f}
            });

        private static readonly GameType WASTE_TYPE = new GameType("Wasteland 3", "Wasteland 3", "Zeight Portrait Manager: inXile (W3)",
            Resources.waste_title, Resources.waste_start_page, Resources.waste_placeholder, Resources.taskbar_icon_waste, Color.FromArgb(176, 200, 210), Color.FromArgb(35, 50, 50),
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