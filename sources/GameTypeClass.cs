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

using System.Collections.Generic;
using System.Drawing;

namespace PortraitManager.sources
{
    public class GameType
    {
        public string FullGameName;
        public string ShortGameName;

        public string WindowTitleText;
        public Image MenuTitleImage;
        public Image MenuBackgroundImage;
        public Image PlaceholderPortrait;
        public Icon ApplicationIcon;
        public Color ForeColor;
        public Color BackColor;

        private Dictionary<string, float> PortraitSpecifics;
        public string DefaultDirectory;

        public GameType(string newFullGameName, string newShortGameName, string newWindowTitleText,
                         Image newMenuTitleImage, Image newMenuBackgroundImage, Image newPlaceholderPortrait,
                         Icon newApplicationIcon,
                         Color newForeColor, Color newBackColor,
                         string newDefaultDirectory,
                         Dictionary<string, float> newPortraitSpecifics)
        {
            FullGameName = newFullGameName;
            ShortGameName = newShortGameName;

            WindowTitleText = newWindowTitleText;
            MenuTitleImage = newMenuTitleImage;
            MenuBackgroundImage = newMenuBackgroundImage;
            ApplicationIcon = newApplicationIcon;
            PlaceholderPortrait = newPlaceholderPortrait;
            ForeColor = newForeColor;
            BackColor = newBackColor;

            DefaultDirectory = newDefaultDirectory;
            PortraitSpecifics = newPortraitSpecifics;
        }
    }
}
