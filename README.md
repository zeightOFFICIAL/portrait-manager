![list1](https://user-images.githubusercontent.com/50341618/227392274-89674a5f-96f7-4113-92f9-152702ebffe4.png)

## Desktop application for managing in-game portraits for Pathfinder: Kingmaker and Wrath of the Righteous

### Author: Artemii "Zeight" Saganenko

### Description

Desktop application, portrait management tool for the Pathfinder series of games. A lightweight, user-friendly, simple and mostly optimized tool for creating new portraits as well as modifying and deleting old ones. Allows the user to manage portraits more conveniently and quickly. Simplifies the process of copying, pasting, scaling and moving images. The application also allows the user to delete or change existing portraits. Supports both Kingmaker and Wrath of the Righteous.

Create new portrait | Browse gallery | Extract folder | Scaling page |
:-------------------------:|:-------------------------:|:-------------------------:|:-------------------------:|
![image](https://user-images.githubusercontent.com/50341618/226739430-c9141706-017f-4fd7-a512-7f3afe9226a1.png)  |  ![image](https://user-images.githubusercontent.com/50341618/226739512-737b856a-f588-4bdf-a225-1986efb47a92.png)  | ![image](https://user-images.githubusercontent.com/50341618/226743585-7fc2b068-5f05-4bb9-aab9-a42c77b98c64.png) | ![image](https://user-images.githubusercontent.com/50341618/226740609-fbd0d89a-c4b9-4c70-8493-eef0def0f7b5.png) |

### Features

#### Create new portraits
Allows user to load any local or web image, to scale it as he sees fit and finally create the portrait in the proper game directory. Supports all prime image formats, which are png, jpg, jpeg, bmp, gif. The created portraits will be almost exact copies of the images set up in frames during scaling.

#### Extract from external folders
Allows user to extract images from local directory right to their proper place in game directory. Choose which folder to process in order to fetch the images, which should be a proper representation of portrait pack. Select which portraits to create in game directory. Press extract selected. In case you want to extract all, press the according button.

#### Browse gallery and change/delete old images
Allows user to browse the already existing/loaded and in-work portraits of the game. Makes possible for user to delete or change specific portraits. Upon deleting, asks whether to proceed. Upon editing, asks whether to make a standalone/copy version or delete the old one and replace. 

### Using pipeline
1. Download any portrait pack from any source (for example https://www.nexusmods.com/pathfinderkingmaker/mods/92)
2. Unpack it in any directory
3. Launch the program, press extract, press choose folder, find the folder you just unpacked
4. Select which images to create, press extract selected
  4b. Press extract all to create all the available portraits
5. Open browse gallery, find which one you want to change/fix, press change
6. Change it in scaling mod
7. Launch the game, enjoy!
---
1. Press create new portrait
2. Press choose local and select the image you want to use
  2b. Press choose web
  2b next. Input URL and press load if the source is available, proceed, otherwise try another, or simply download it and find locally
3. Press next and proceed to scaling page. Use mouse wheel in increase/decrease image. Move image while holding left mouse button to adjust it
4. Press create to add the portrait to the game portraits folder
5. Close app, launch the game, enjoy!

### Installation info
Download release, unpack anywhere, launch exe. Don't delete or move configuration file away from exe.

### Production info and bugs section
All the errors and bugs should be reported to in the according section of nexusmods

### Build info
* Visual Studio 2022 (17.4.4)
* .NET Framework 4.7.2
* C#
---
Compatible with latest Windows OSs
* Untested but it should be working on Windows 11
* Tested with Windows 10
* Untested but it should be working on Windows 7 as well
* Most likely working with Windows XP/Vista
* Very unlikely with anything older

### Translation addendum
The program was optimized to use several languages and fonts. In order to create a translation, load TextVariables.resx, copy it. Change its name to TextVariables.{LANGUAGE SHORT CALLING}.resx. Then fill value fields to the according translations.

### Copyrights
1. Program license: GPL-2.0 license, conditions listed in LICENSE
2. All rights for Visual Studio 2022 belongs to Microsoft https://www.microsoft.com/
3. All rights for Pathfinder: Kingmaker and Pathfinder: Wrath of the Righteous belongs to Owlcat Games https://owlcat.games/
4. All rights for https://www.nexusmods.com/pathfinderkingmaker/mods/92 belongs to Nexus Mods and Citrus457
5. Images and icons used in program belongs to Owlcat Games
6. Used font Bebas Neue belongs to its creator https://fonts.google.com/specimen/Bebas+Neue
##### Disclaimer: this is not a product of Owlcat Games, it is developed by a third-party.
##### Inform: if your owner rights are violated
