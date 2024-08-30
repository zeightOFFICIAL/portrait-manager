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
        public Icon ApplicationIcon;
        public Color ForeColor;
        public Color BackColor;

        private Dictionary<string, float> PortraitSpecifics;

        public string DefaultDirectory;

        public GameType(string newFullGameName, string newShortGameName, string newWindowTitleText,
                         Image newMenuTitleImage, Image newMenuBackgroundImage, Icon newApplicationIcon,
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
            ForeColor = newForeColor;
            BackColor = newBackColor;
            DefaultDirectory = newDefaultDirectory;
            PortraitSpecifics = newPortraitSpecifics;
        }
    }


    public class GameTypeClass
    {
        public string FullGameName;
        public string WindowTitleText;
        public Image MenuTitleImage { get; set; }
        public Image MenuBackgroundImage { get; set; }
        public Image PortraitPlaceholderImage { get; set; }
        public Color ControlForeColor { get; set; }
        public Color ControlBackColor { get; set; }
        public Icon ApplicationIcon { get; set; }
        public string NormalDefaultDirectory { get; set; }
        public Dictionary<string, int> PortraitNativePixeling { get; set; } 
        public Dictionary<string, float> PortraitNativeAspect { get; set; }
        
        public GameTypeClass(string newGameName, Color newForeColor, Color newBackColor, Icon newIcon,
                             Image newTitleImage, Image newBackgroundImage, Image newPlaceImage,
                             string newDefDirectory, string newTitleText,
                             int newSmallWidth, int newSmallHeight,
                             int newMediumWidth, int newMediumHeight,
                             int newLargeWidth, int newLargeHeight,
                             float newSmallAspect, float newMediumAspect, float newLargeAspect)
        {
            FullGameName = newGameName;
            WindowTitleText = newTitleText;

            ControlForeColor = newForeColor;
            ControlBackColor = newBackColor;
            ApplicationIcon = newIcon;
            MenuTitleImage = newTitleImage;
            MenuBackgroundImage = newBackgroundImage;
            PortraitPlaceholderImage = newPlaceImage;            

            NormalDefaultDirectory = newDefDirectory;
            

            PortraitNativePixeling = new Dictionary<string, int>()
            {
                { "SMALL WIDTH", newSmallWidth},
                { "SMALL HEIGHT", newSmallHeight},
                { "MEDIUM WIDTH", newMediumWidth},
                { "MEDIUM HEIGHT", newMediumHeight},
                { "LARGE WIDTH", newLargeWidth},
                { "LARGE HEIGHT", newLargeHeight}
            };

            PortraitNativeAspect = new Dictionary<string, float>()
            {
                { "SMALL ASPECT", newSmallAspect},
                { "MEDIUM ASPECT", newMediumAspect},
                { "LARGE ASPECT", newLargeAspect},
            };
        }

        public int GetSmallWidth()
        {
            return PortraitNativePixeling["SMALL WIDTH"];
        }

        public int GetSmallHeight()
        {
            return PortraitNativePixeling["SMALL HEIGHT"];
        }

        public int GetMediumWidth()
        {
            return PortraitNativePixeling["MEDIUM WIDTH"];
        }

        public int GetMediumHeight()
        {
            return PortraitNativePixeling["MEDIUM HEIGHT"];
        }

        public int GetLargeWidth()
        {
            return PortraitNativePixeling["LARGE WIDTH"];
        }

        public int GetLargeHeight()
        {
            return PortraitNativePixeling["LARGE HEIGHT"];
        }
    
        public float GetSmallAspect()
        {
            return PortraitNativeAspect["SMALL ASPECT"];
        }

        public float GetMediumAspect()
        {
            return PortraitNativeAspect["MEDIUM ASPECT"];
        }

        public float GetLargeAspect()
        {
            return PortraitNativeAspect["LARGE ASPECT"];
        }
    }
}
