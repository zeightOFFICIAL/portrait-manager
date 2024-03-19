# <p align="center">Owlcat Portrait Manager</p>

### <p align="center">including:</p>
![pathfinder title](https://user-images.githubusercontent.com/50341618/227392274-89674a5f-96f7-4113-92f9-152702ebffe4.png)
![w40k_title](https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/ff408a64-1347-4b1d-b66a-477ddc715857)

## <p align="center">Desktop application for managing in-game portraits for Owlcat Games' works</p>
### <p align="center">Pathfinder: Kingmaker, Pathfinder: Wrath of the Righteous, Warhammer 40000: Rogue Trader</p><hr>

### Created by Artemii "Zeight" Saganenko
### Nexus mods link: 
https://www.nexusmods.com/pathfinderwrathoftherighteous/mods/466<br>
https://www.nexusmods.com/pathfinderkingmaker/mods/277<br>
https://www.nexusmods.com/warhammer40kroguetrader/mods/(ADD URL ONCE PUBLISHED)

### Description
Desktop application, management tool for portraits in Owlcat Games products, currently including Pathfinder and Warhammer series. A lightweight, user-friendly, simple and mostly optimized tool for creating new portraits as well as modifying old ones. Allows the user to manage portraits more conveniently and quickly. Simplifies the process of copying, pasting, scaling and moving images. The application also allows the user to delete or change existing portraits. Supports Kingmaker and Wrath of the Righteous and Rogue Trader. Requires nothing, no dependencies at all, apart from .NET Framework 4.8, which is 99% likely to be already installed. Supports Custom NPC Portraits to edit NPC's and army's images for Pathfinder series. Can be easily expanded to work with future Owlcat Games' projects.

| Kingmaker | Wrath of the Righteous |
| :-------: | :--------------------: |
|![image](https://github.com/zeightOFFICIAL/portrait-manager-pathfinder/assets/50341618/5ffd3ba8-8375-4a94-97ee-aa6b7fe2762b)|![image](https://github.com/zeightOFFICIAL/portrait-manager-pathfinder/assets/50341618/c57f06c9-6a6d-4a2c-bfe5-b6265744b799)|

| Load any image | Scale image to portrait |
| :------------: | :---------------------: |
|![image](https://github.com/zeightOFFICIAL/portrait-manager-pathfinder/assets/50341618/84fe93f0-8020-4d60-888e-c642ac6a4fab)|![image](https://github.com/zeightOFFICIAL/portrait-manager-pathfinder/assets/50341618/9bb6daec-0cf7-45e2-a748-d7cf5ff819aa)|

| Extract from folder | Browse existing Custom Army |
| :-----------------: | :-------------: |
|![image](https://github.com/zeightOFFICIAL/portrait-manager-pathfinder/assets/50341618/6d62a1b4-a603-46ce-bade-234883930924)|![image](https://github.com/zeightOFFICIAL/portrait-manager-pathfinder/assets/50341618/97f51e75-6c77-4657-8dfb-f1757e887af4)|

| Browse existing portraits | Browse existing Custom NPC |
| :-----------------: | :-------------: |
|![image](https://github.com/zeightOFFICIAL/portrait-manager-pathfinder/assets/50341618/20bd3800-6a52-425d-a2c5-478403be7c39)|![image](https://github.com/zeightOFFICIAL/portrait-manager-pathfinder/assets/50341618/8b509422-0399-4e46-b545-354b1b85b918)|

| Settings page | Load web-image page |
| :-----------------: | :-------------: |
|![image](https://github.com/zeightOFFICIAL/portrait-manager-pathfinder/assets/50341618/17ae9a9e-287f-4017-bd57-e2473268e75b)|![image](https://github.com/zeightOFFICIAL/portrait-manager-pathfinder/assets/50341618/914124d3-c4f7-41f0-a3c8-80fbe0e3a270)|

| Russian translation | German translation |
| :-----------------: | :-------------: |
|![image](https://github.com/zeightOFFICIAL/portrait-manager-pathfinder/assets/50341618/d9786dca-6487-4970-a415-bd0db0d36e38)|![image](https://github.com/zeightOFFICIAL/portrait-manager-pathfinder/assets/50341618/022fc44d-2dec-4195-b274-84182e4d23b6)|

### Features

#### Create new portraits
Allows the user to upload any local or web image, scale it as desired, and finally create a portrait in the appropriate game directory. Supports all major image formats: png, jpg, jpeg, bmp, gif. Now allows the user to change the image for each portrait type: small, medium, full length, by uploading a local or web image with the specific portrait type selected. Unsupported files are ignored. The created portraits will be almost exact copies of the images displayed in the frames when scaled. The minor diviation is due to trimming and resizing errors, they are expected and nothing can be done about it. The program automatically crops, resizes the image to the required state, creates a directory and an image file. User must simply click the button.

#### Extract from external folders
Allows the user to extract images that are to be portraits from a local directory directly into the game directory. Select the folder containing the correct portrait package images to process and create the portrait in game folder. Choose which images to move to the game directory. You can extract selected ones to move only certain images. Or extract every one of them. The program automatically copies folders to the game portraits' directory. Works only with regular portraits. Custom NPC portraits don't work. The latter functionality will not be implemented, since it is rather irrelevant and senseless.

* A valid image package must contain three images: small - 185x242 (factor 1.308), medium - 330x432 (factor 1.309), full size - 692x1024 (factor 1.479) for Pathfinder: Kingmaker and Pathfinder: Wrath of the Righteous. Small - 260x336 (factor 1.292), medium - 448x600 (factor 1.339), full size - 1080x1480 (factor 1.370) for Warhammer 40000: Rogue Trader. The program performs recursive parsing, so corresponding folders located deeper than one directory will still be processed. Other files will be ignored. Please note that these are the official proportions shown in the game, other sizes may not fit. The failsafe is +/- 2 pixels in width and +/- 3 pixels in height, but this cannot be promised to work in game. (ADD REMARK CONSIDERING BEHAVIOUR)

#### Browse gallery and change/delete portraits
Allows the user to view existing/created and in-work game portraits. Allows the user to delete or change any portrait. Select the image(s) from the list and click the button corresponding to the required functionality. When deleting, it asks whether to continue. When editing, it asks whether to make a standalone/copy version, meaning to delete the old one/replace it. Manages all processing of folders and files. On-site replacement is now valid. It is no problem to change a specific portrait that may already be used by the game, so the user does not need to use any save-edit. It literally recreates portrait based on new specifics.

#### Browse Custom NPC Portraits, change/delete portraits (only for Pathfinder)
Allows the user to edit/delete portraits created using Custom NPC Portraits. Any portrait created by the mod can be modified. Viewing is implemented through the “Browse Gallery” page, using the buttons at the top of the corresponding page. You must have custom NPC portraits installed and allow it to create source folders with custom portraits. I cannot do anything about it but Custom NPC creates folders with portraits for characters only after the player character meets it in the game itself. So, it is either you find mod which contains pre-made folders, or make do with first encounter being with default portrait. Now, if you make a copy of custom portrait, the program creates a new directory in the same location as the original one, so it doesn't actually work in game after, since the mod still uses the old image, to put simply I cannot change how Custom NPC works, and would not do it anyway. On the other hand, when replacing, a backup is created in the same location, and it works in the game after replacing the original file, since Custom NPC still uses this updated old portrait. This program does not create new custom portraits, but merely manages existing!

Considering Warhammer 40000: Rogue Trader. Once Custom NPC portraits mod is implemented, I will make some changes so Owlcat Portrait Manager can work with custom npc portraits in Rogue Trader. Until then there is a game check that blocks Custom NPC for Rogue Trader.

#### Settings
An attempt to prevent any problems with the path to portraits folder. Now, the program requires the user to select the correct folder in which all the game portraits are stored. Allows to observe whether Custom NPC Portraits mod is enabled and which localization is currently in use.

#### Localization
Now supports localization. The concept has changed. Now there is no need to add resx/dll localization files. They are initially built into the program. At first startup, the system language is the program language. After this, you can change the localization on the main page. Russian/English is written and checked manually, German is translated by machine artificial intelligence using DeepL. Some minor semantic, lexical mistakes might be implemented.

### Basic use cases
1. Download any portrait pack from any source (for example https://www.nexusmods.com/pathfinderkingmaker/mods/92)
2. Unpack it in any directory, it is recommended to be a non-protected by system or user folder, downloads folder would work just fine
3. Launch the program, press extract, press choose folder, find the folder you just unpacked
4. Select which images to copy, press extract selected or press extract all to copy all the available portraits
5. Close app, launch the game, enjoy!
---
1. Press create new portrait
2. Press choose local and select the image you want to use<br>
    2b. Press choose web<br>
    2b next. Input URL and press load, if the source is available, proceed. Otherwise, try another image, or simply download it and find locally<br>
3. Press next and proceed to scaling page. Use mouse wheel in increase/decrease image. Move the image while holding the left mouse button to adjust it. Double-click restores images
4. Press create to add the portrait to the game portraits folder
5. In case, you messed up scaling, or simply want to change or delete the portrait. Open browse gallery, find your image. Select it. Press according button. Change the portrait (the name will be new whatsoever), or approve deletion 
6. Close app, launch the game, enjoy!
---
1. Download and install Custom NPC Portraits (https://www.nexusmods.com/pathfinderwrathoftherighteous/mods/346, https://www.nexusmods.com/pathfinderkingmaker/mods/100) using Unity Mod Manager.
2. Launch the game and play. Find the character whose portrait you would like to change, remember it.
       2b. Download any portrait package that is compatible with Custom NPC Portraits, extract it manually (unfortunately, this program does not support such an operation, since there are not many such compatible portrait packages) into the game portraits' folder.
4. Launch the program, go to 'Browse Gallery', click 'Show Custom' or 'Army', 'NPC', find the character.
5. Click edit, when asked whether to replace the original or not, click 'yes', a backup copy will be created in the same folder.
6. Adjust as desired.
7. Close the application, launch the game and enjoy!

### Installation
Download the release, unpack it anywhere (literally), but I recommend using a separate folder and an unprotected directory, as it copies and saves images a lot. Launch Pathfinder Portrait Manager.exe and use the application as you wish. Do not delete or move the configuration file from the EXE. Also, do not delete the temporary folder while the program is running. Localization folders (ru, de) must be located next to the EXE. Do not delete anything that comes within 7z package

### Production info and bugs section
All bugs and errors should be reported in the corresponding Nexusmods section. I believe (hope) that there are only minor/graphical bugs left that are not critical for usability, so most likely there will be no patches. However, if something critical happens, I will try to fix it as soon as possible. From now on, there will be no functionality updates in version >1.2.0.0. Please note that the Pathfinder game's portraits folder is statically created, and the functionality is simple, so there is very little chance of a bug occurring in the program. Please check dependencies, launch and start the game at least once, reinstall the game.

### Build info
* C#
* .NET Framework 4.8, no special DLLs involved, translations' .dll comes with release.
* Visual Studio 2022 17.4.4

---
Compatible with latest Windows OSs, <b>in any case .NET Framework 4.8 is required!</b> If you used previous mod version (1.2.0.0) with 4.7.2 .NET Framework, most likely nothing has changed for you.<br>
✅✅ Works with Windows 11. Tested.<br>
✅✅ Works with Windows 10, use at least build 1607. Tested.<br>
⭕❌ Probably works with Windows 8.1. Not tested. Install .NET Framework 4.8 manually.<br>
❌❌ Not working with Windows 8. Not tested. Cannot install .NET Framework 4.8.<br> 
⭕❌ Probably works with Windows 7. Not tested. Install SP1 update and .NET Framework 4.8 manually.<br>
❌❌ Not working with Windows Vista. Not tested. Not enough users to adapt for .NET Framework 4.6.<br>
❌❌ Not working with Windows XP. Not tested. Not enough users to adapt for .NET Framework 4.0<br>
❌❌ Not working with anything older.<br>
❌❌ Not working with UNIX-based, including Linux, MAC, BSD, Solaris. Since .NET Framework is exclusively for Windows<br>

<p align="center"><img src="https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/06bfadea-0877-413f-a239-e1f49710f6e8" width="450px" margin="auto"></img><br>This table should cover whether you need to install .NET Framework on your PC. If the plus mark is placed on counter section then you can install the required version (which is 4.8), otherwise, your OS is not supported for this tool.</p><br>


#### Development and debugging addendum, concerns
* Pathfinder portrait's game folder is created statically, so it is the same no matter what device you are using (bound to Windows' file system). The directory detection code uses system paths to locate the AppData/LocalLow/Owlcat/Pathfinder/Portraits folder.
* Custom NPC Portraits uses previously mentioned system paths to navigate required folders. So if the first point fails, it fails too.
* If you are using Custom NPC Portraits, be sure to START the game at least once. <b>THE PROGRAM DOES NOT CREATE NEW PORTRAITS!</b>, it only modifies existing ones. So, to actually change someone's portrait, you need to meet them in the game and let the Custom NPC Portraits create his/her folder in the appropriate directory.
* Also keep in mind that some Custom NPC Portraits do not use the fulllength.png (largest) portrait as it is not utilized in the game, this program allows you to change it, but it does not work in the game itself.
* Each user has his own configuration. It is stored in an XML file in the AppData folder. It stores basic information about the window size, folder paths, selected language, and so on. The file is open for navigation and observation if there are any problems. We advise you not to change it.
* FolderBrowserDialog now (1.1.0.0) works for folder feature selection.
* The localization of the program initially depends on the current active system language, but later you can change the localization using the buttons on the main page. If the former does not work, try changing the language via buttons.
* Asynchronous image loading now (1.2.0.0) works for loading images into the Browse Gallery and Extract Folder pages.
* The program has not been subjected to thorough and constant testing and debugging, there are many pitfalls
* Most important topics: asynchronous loading, folder/file manipulation, folder discovery, image cropping/resizing.
* If any of this doesn't help you find the bug, please let me know personally via Nexusmods.

##### Changelog
* 1.3.0.0 (current)
* 1.2.0.0
    * Added asynchronous loading of Browse Gallery and Extract Folder. Loading of images on these pages is faster and I/O-free, you can select any image as quickly as it appears on the page. Allowing more smooth and convenient experience
    * Added Custom NPC Portraits support. Added support for portraits created by edvin76's mod. Portraits of both the army and NPCs can be altered using this application
    * Major code refactoring
    * Optimization changes
    * The concept of localization has been changed. Now you can change the localization using the buttons on the main page, no need to download any locale files, it is built into the program. Initial localization still depends on the system language. Current available localizations: en-US, ru-RU, de-DE (the latter one is translated by AI, so it is flawed)
    * Changes in the settings page.
    * Added fault tolerance for Extract Folder, so partially incorrect portraits are still processed by a program. Yet, it cannot be promised that it will work in the game.
    * Nothing is broken... I think. This cannot be promised >_<
* 1.1.0.0b
    * Minor graphical changes
    * Optimization changes
    * Code refactored
    * Added localization support, now includes translation file for Russian language
    * Removed unnecessary if/else on image zooming
    * Removed dependency on outdated folder chose dialog, swapped to new FolderBrowserDialog
    * Added settings page to set up portrait folder path and form size for each game type
    * Added features that allow user to change every portrait separately
* 1.0.0.2e
    * Create new portrait from image
    * Scale image as you see them fit as portraits
    * Change existing portrait(s)
    * Delete existing portrait(s)
    * Browse existing portrait(s)
    * Extract image(s) from another folder

### Copyrights
1. Program license: GPL-2.0 license, conditions listed in LICENSE (https://github.com/zeightOFFICIAL/portrait-manager-pathfinder/blob/master/LICENSE)
2. All rights for Visual Studio 2022 belongs to Microsoft (https://www.microsoft.com/)
3. All rights for Pathfinder: Kingmaker belongs to Owlcat Games (https://owlcat.games/)
4. All rights for Pathfinder: Wrath of the Righteous belongs to Owlcat Games (https://owlcat.games/)
5. All rights for Warhammer 40000: Rogue Trader belongs to Owlcat Games (https://owlcat.games/)
6. All rights for https://www.nexusmods.com/pathfinderkingmaker/mods/92 belongs to Nexus Mods (https://www.nexusmods.com/) and Citrus457 (https://www.nexusmods.com/pathfinderkingmaker/users/60287596)
7. Images and icons used in program belongs to Owlcat Games (https://owlcat.games/)
8. Used font Bebas Neue belongs to its creator Ryoichi Tsunekawa (https://fonts.google.com/specimen/Bebas+Neue, http://dharmatype.com)
9. Used font Bebas Neue for cyrillics belons to its creator Ryoichi Tsunekawa and AA (https://fonts-online.ru/fonts/bebas-neue-cyrillic, http://dharmatype.com)
10. All rights to Custom Npc Portraits (https://www.nexusmods.com/pathfinderwrathoftherighteous/mods/346, https://www.nexusmods.com/pathfinderkingmaker/mods/100) belongs to edvin76 (https://www.nexusmods.com/pathfinderkingmaker/users/1599293), (https://github.com/edvin76/CustomNpcPortraits). Please note, that none of the Assets of Custom Npc Portraits is used, just its result<br>

<b>Inform: if your owner's rights have been violated; if you encounter any errors; if you have suggestions for improving functionality/optimization.
Disclaimer: This is not a product of Owlcat Games, it is developed by a third party. Every image used and processed in this application does not belong to me. Clients (users) of this application are responsible for selecting a specific image and subsequent use of the processed image. This program only allows users to modify images more easily. Whether they are protected or not, selecting an image and its use is entirely at the discretion of the user. Custom NPC Portrait does not belong to me, but to edvin76, I do not utilize any of the assets.</b>
