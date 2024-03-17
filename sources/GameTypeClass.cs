/*    
    Owlcat Portrait Manager. Desktop application for managing in game
    portraits for Owlcat Games products. Including Pathfinder: Kingmaker,
    Pathfinder: Wrath of the Righteous, Warhammer 40000: Rogue Trader
    Copyright (C) 2024 Artemii "Zeight" Saganenko

    GPL-2.0 license terms are written in LICENSE file
    License header for this project is written in Program.cs
*/

using System.Drawing;

namespace OwlcatPortraitManager.sources
{
    public class GameTypeClass
    {
        public string GameName;
        public string TitleText;
        public Image TitleImage { get; set; }
        public Image BackgroundImage { get; set; }
        public Image PlaceholderImage { get; set; }
        public Color ForeColor { get; set; }
        public Color BackColor { get; set; }
        public Icon GameIcon { get; set; }
        public string DefaultDirectory { get; set; }
        public GameTypeClass(string newGameName, Color newForeColor, Color newBackColor, Icon newIcon,
                             Image newTitleImage, Image newBackgroundImage, Image newPlaceImage,
                             string newDefDirectory, string newTitleText)
        {
            GameName = newGameName;
            ForeColor = newForeColor;
            BackColor = newBackColor;
            GameIcon = newIcon;
            TitleImage = newTitleImage;
            BackgroundImage = newBackgroundImage;
            PlaceholderImage = newPlaceImage;
            DefaultDirectory = newDefDirectory;
            TitleText = newTitleText;
        }
    }
}
