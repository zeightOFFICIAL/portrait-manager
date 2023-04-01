/*    
    Pathfinder Portrait Manager. Desktop application for managing in game
    portraits for Pathfinder: Kingmaker and Pathfinder: Wrath of the Righteous
    Copyright (C) 2023 Artemii "Zeight" Saganenko
    LICENSE terms are written in LICENSE file
    Primal license header is written in Program.cs
*/

using System;
using System.Drawing;

namespace PathfinderPortraitManager.sources
{
    public class GameTypeClass
    {
        public string gameName;
        public string titleName;
        public Image TitleImage { get; set; }
        public Image BackImage { get; set; }
        public Image PlaceholderImage { get; set; }
        public Color ForeColor { get; set; }
        public Color BackColor { get; set; }
        public Icon GameIcon { get; set; }
        public string DefaultDirectory { get; set; }
        public GameTypeClass(string newGameName, Color newForeColor, Color newBackColor, Icon newIcon,
                             Image newTitleImage, Image newBackImage, Image newPlaceImage,
                             string newDefDirectory, string newTitleName) {
            gameName = newGameName; 
            ForeColor = newForeColor;
            BackColor = newBackColor;
            GameIcon = newIcon;
            TitleImage = newTitleImage;
            BackImage = newBackImage;
            PlaceholderImage = newPlaceImage;
            DefaultDirectory = newDefDirectory;
            titleName = newTitleName;
        }
    }
}
