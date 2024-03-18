/*    
    Owlcat Portrait Manager. Desktop application for managing in game
    portraits for Owlcat Games products. Including Pathfinder: Kingmaker,
    Pathfinder: Wrath of the Righteous, Warhammer 40000: Rogue Trader
    Copyright (C) 2024 Artemii "Zeight" Saganenko

    GPL-2.0 license terms are listed in LICENSE file
    License header for this project is listed in Program.cs
*/

using System.Collections.Generic;
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
        public Dictionary<string, int> NativePixeling { get; set; } 
        public Dictionary<string, float> NativeAspect { get; set; }
        
        public GameTypeClass(string newGameName, Color newForeColor, Color newBackColor, Icon newIcon,
                             Image newTitleImage, Image newBackgroundImage, Image newPlaceImage,
                             string newDefDirectory, string newTitleText,
                             int newSmallWidth, int newSmallHeight,
                             int newMediumWidth, int newMediumHeight,
                             int newLargeWidth, int newLargeHeight,
                             float newSmallAspect, float newMediumAspect, float newLargeAspect)
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

            NativePixeling = new Dictionary<string, int>()
            {
                { "SMALL WIDTH", newSmallWidth},
                { "SMALL HEIGHT", newSmallHeight},
                { "MEDIUM WIDTH", newMediumWidth},
                { "MEDIUM HEIGHT", newMediumHeight},
                { "LARGE WIDTH", newLargeWidth},
                { "LARGE HEIGHT", newLargeHeight}
            };

            NativeAspect = new Dictionary<string, float>()
            {
                { "SMALL ASPECT", newSmallAspect},
                { "MEDIUM ASPECT", newMediumAspect},
                { "LARGE ASPECT", newLargeAspect},
            };
        }

        public int GetSmallWidth()
        {
            return NativePixeling["SMALL WIDTH"];
        }

        public int GetSmallHeight()
        {
            return NativePixeling["SMALL HEIGHT"];
        }

        public int GetMediumWidth()
        {
            return NativePixeling["MEDIUM WIDTH"];
        }

        public int GetMediumHeight()
        {
            return NativePixeling["MEDIUM HEIGHT"];
        }

        public int GetLargeWidth()
        {
            return NativePixeling["LARGE WIDTH"];
        }

        public int GetLargeHeight()
        {
            return NativePixeling["LARGE HEIGHT"];
        }
    
        public float GetSmallAspect()
        {
            return NativeAspect["SMALL ASPECT"];
        }

        public float GetMediumAspect()
        {
            return NativeAspect["MEDIUM ASPECT"];
        }

        public float GetLargeAspect()
        {
            return NativeAspect["LARGE ASPECT"];
        }
    }
}
