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
        public String gameName;
        public String titleName;
        public Image titleImage { get; set; }
        public Image backImage { get; set; }
        public Image placeholderImage { get; set; }
        public Color foreColor { get; set; }
        public Color backColor { get; set; }
        public Icon icon { get; set; }
        public string defaultDirectory { get; set; }
        public GameTypeClass(string newGameName, Color newForeColor, Color newBackColor, Icon newIcon,
                             Image newTitleImage, Image newBackImage, Image newPlaceImage,
                             string newDefDirectory, String newTitleName) {
            gameName = newGameName; 
            foreColor = newForeColor;
            backColor = newBackColor;
            icon = newIcon;
            titleImage = newTitleImage;
            backImage = newBackImage;
            placeholderImage = newPlaceImage;
            defaultDirectory = newDefDirectory;
            titleName = newTitleName;
        }
    }
}
