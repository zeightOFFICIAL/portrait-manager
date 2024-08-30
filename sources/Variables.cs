


using PortraitManager.forms;
using PortraitManager.sources;
using PortraitManager.Properties;

using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;

namespace PortraitManager
{
    public partial class MainForm : Form
    {
        private static readonly Dictionary<char, GameType> GameTypes = new Dictionary<char, GameType>
        {
            { 'k', KingType },
            { 'w', WotrType },
            { 'r', RtType },
            { 't', TyrType },
            { 'p', PoeType },
            { 'd', PoedType },
            { 'l', W3Type }
        };

        private static readonly GameType KingType = new GameType("Pathfinder: Kingmaker", "Kingmaker", "Portrait Manager: Owlcat (Kingmaker)",
            Resources.title_path, Resources.bg_path, Resources.icon_path, Color.FromArgb(255, 20, 147), Color.FromArgb(20, 6, 30),
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow")
            + "\\Owlcat Games\\Pathfinder Wrath Of The Righteous\\Portraits",
            new System.Collections.Generic.Dictionary<string, float> 
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

        private static readonly GameType WotrType = new GameType("Pathfinder: Wrath of the Righteous", "Wrath of the Righteous", "Portrait Manager: Owlcat (Wotr)",
            Resources.title_wotr, Resources.bg_wotr, Resources.icon_wotr, Color.FromArgb(255, 20, 147), Color.FromArgb(20, 6, 30),
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow")
            + "\\Owlcat Games\\Pathfinder Wrath Of The Righteous\\Portraits",
            new System.Collections.Generic.Dictionary<string, float>
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

        private static readonly GameType RtType = new GameType("Warhammer 40K: Rogue Trader", "Rogue Trader", "Portrait Manager: Owlcat (RT)",
            Resources.title_rt, Resources.bg_rt, Resources.icon_rt, Color.FromArgb(255, 187, 0), Color.FromArgb(5, 0, 42),
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow")
            + "\\Owlcat Games\\Warhammer 40000 Rogue Trader\\Portraits",
            new System.Collections.Generic.Dictionary<string, float>
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

        private static readonly GameType PoeType = new GameType("Pillars of Eternity", "Pillars of Eternity", "Portrait Manager: Obsidian (PoE)",
            Resources.title_poe, Resources.bg_poe, Resources.icon_poe, Color.FromArgb(50, 250, 200), Color.FromArgb(7, 33, 27),
            " ",
            new System.Collections.Generic.Dictionary<string, float>
            {
                { "SMALL_WIDTH", 76},
                { "SMALL_HEIGHT", 96},
                { "LARGE_WIDTH", 210},
                { "LARGE_HEIGHT", 330},
                { "SMALL_AR", 1.2631f},
                { "LARGE_AR", 1.5714f}
            });

        private static readonly GameType PoedType = new GameType("Pillars of Eternity: Deadfire", "Deadfire", "Portrait Manager: Obsidian (PoED)",
            Resources.title_poed, Resources.bg_poed, Resources.icon_poed, Color.FromArgb(50, 250, 200), Color.FromArgb(7, 33, 27),
            " ",
            new System.Collections.Generic.Dictionary<string, float>
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

        private static readonly GameType TyrType = new GameType("Tyranny", "Tyranny", "Portrait Manager: Obsidian (Tyranny)",
            Resources.title_tyr, Resources.bg_tyr, Resources.icon_tyr, Color.FromArgb(248, 34, 34), Color.FromArgb(43, 3, 3),
            " ",
            new System.Collections.Generic.Dictionary<string, float>
            {
                { "SMALL_WIDTH", 76},
                { "SMALL_HEIGHT", 96},
                { "LARGE_WIDTH", 210},
                { "LARGE_HEIGHT", 330},
                { "SMALL_AR", 1.2631f},
                { "LARGE_AR", 1.5714f}
            });

        private static readonly GameType W3Type = new GameType("Wasteland 3", "Wasteland 3", "Portrait Manager: inXile (W3)",
            Resources.title_waste, Resources.bg_waste, Resources.icon_waste, Color.FromArgb(176, 200, 210), Color.FromArgb(35, 50, 50),
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            + "\\My Games\\Wasteland3",
            new System.Collections.Generic.Dictionary<string, float>
            {
                { "SMALL_WIDTH", 256},
                { "SMALL_HEIGHT", 256},
                { "SMALL_AR", 1.0f},
            });
    }
}