<p align="center">
<img src="https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/55c84625-2b73-48a3-b279-bbee1240dd17" width="100%"/>
</p>

# <p align="center"> Portrait Manager by zeight </p>
### <p align="center">Desktop application for managing in-game portraits for Owlcat Games, inXile Entertainment and Obsidian Entertainment games</p>
###### <p align="center"><img src="https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/a316db5e-a269-48cf-81b4-4c54f13ff2e6" width="45%"/>&#160;&#160;&#160;&#160;<img src="https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/3bf58f3f-1260-4faa-852f-03408cc6f21c" width="45%"/><br> Supported games: Pathfinder: Kingmaker, Pathfinder: Wrath of the Righteous, Warhammer 40000: Rogue Trader, Pillars of Eternity, Pillars of Eternity: Deadfire, Tyranny, Wasteland 3</p>
#### <p align="center">Nexus mods link:<br>Pathfinder Kingmaker - https://www.nexusmods.com/pathfinderkingmaker/mods/277<br>Pathfinder: Wrath of the Righteous - https://www.nexusmods.com/pathfinderwrathoftherighteous/mods/466<br>Warhammer 40000: Rogue Trader - https://www.nexusmods.com/warhammer40kroguetrader/mods/120<br>Pillars of Eternity - <br>Pillars of Eternity: Deadfire - <br>Tyranny - <br>Wasteland 3 - </p> 
#### <p align="center">Created and designed by Artemii "Zeight" Saganenko<br>Copyright Artemii Saganenko ©2023-2024</p><hr>

### Description
Desktop application, management tool for portraits in Owlcat Games products. Currently, including Pathfinder and Warhammer series. A lightweight, user-friendly, simple and mostly optimized tool for creating new portraits and browsing, modifying existing ones. Allows the user to manage portraits more conveniently and quickly. Simplifies the process of copying, pasting, scaling and moving images. The application also allows the user to delete or change existing portraits. Supports Kingmaker and Wrath of the Righteous and Rogue Trader. Requires nothing additional. No dependencies at all, apart from .NET Framework 4.8, which is 99% likely to be already installed. Supports Custom NPC Portraits to edit NPC's and army's images for Pathfinder series. Can be easily expanded to work with future Owlcat Games' projects.

|![path_main](https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/fe1a9371-9879-4c84-97bc-8cc25c22f8ee)|![wotr_main](https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/806f1114-ea79-411a-91c7-4369e1e22d07)|![rt_main](https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/7a188b87-5148-4d67-b61f-d56e3d264f18)|
|---|---|---|

### Features

#### Create new portraits
Allows the user to upload any local or web image, scale it as desired, and finally create a portrait in the appropriate game directory. Supports all major image formats: PNG, JPG, JPEG, BMP, GIF. Allows the user to change the image for each portrait type: small, medium, full length, by uploading a local or web image with the specific portrait type selected. Unsupported files are ignored. The created portraits will be almost exact copies of the images displayed in the frames when scaled. The minor deviation is due to trimming and resizing errors, they are expected and nothing can be done about it. The program automatically crops, resizes the image to the required state, creates a directory and an image file. User must simply click the button. Now panels for each portrait type represent proper aspect ratio of needed portrait and game type, which makes cropping more accurate as the user see the portrait to be created more precise.

|![path_file](https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/77384f78-c5dd-4e87-af34-a867a978672c)|![wotr_file-1](https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/6b01bb4d-8e81-48f6-a915-963d37be77a4)|![rt_file](https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/bf8bc07a-7e3a-409c-8f38-245fdabcbf83)|
|---|---|---|

|![wotr_web](https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/1eb4f9c6-7bc5-4b9d-ad53-44712b3563cc)|![wotr_chooselocal](https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/3c0eabd9-3084-4f05-9265-66600e9629e3)|![wotr_scale](https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/4f3a271d-c264-41a6-9f18-f0506a9aa6a0)|
|---|---|---|

|![path_final](https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/6b37d143-5b4f-48a0-9535-c8ad8674a99d)|![wotr_final](https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/c362cd2e-281a-4a50-926b-69ed97dea311)|![rt_final](https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/60b25e8c-c27f-40ff-b3fe-2895e34e30fc)|
|---|---|---|

#### Extract from external folders
Allows the user to extract images that are to be portraits from a local directory into the game portraits' directory. Select the folder containing the correct portrait packages in order for the program to process and create all the portraits in game folder. Choose which images to move to the game directory. You can extract selected ones to move only certain images. Or extract each of them, all of which are the correct portrait pack. The program automatically copies folders to the game portraits' directory. Works only with regular portraits. Custom NPC portraits don't work. The latter functionality will not be implemented, since it is rather irrelevant.

* A valid image package must contain three images: small: 185×242 (factor 1.308), medium: 330×432 (factor 1.309), full size: 692×1024 (factor 1.479) for Pathfinder: Kingmaker and Pathfinder: Wrath of the Righteous. Small: 260×336 (factor 1.292), medium: 448×600 (factor 1.339), full size: 1080×1480 (factor 1.370) for Warhammer 40000: Rogue Trader. The program performs recursive parsing, so corresponding folders located deeper than one directory will still be processed. Other files will be ignored. Please note that these are the official proportions shown in the game, other sizes may not fit. The failsafe is +/- 2 pixels in width and +/- 3 pixels in height, but this cannot be promised to work in game. Seemingly, Warhammer 40k: Rogue Trader shrinks and expands the image to fit the portrait (stretches), but it looses A/R of image in this case. Most likely, Pathfinders' games have the same manner. In any case, the failsafe stands. So to ensure some quality assurance on deployed image packages. If you are very frustrated by this thing, just press open folders and do it manually.

|![path_extract](https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/9beaa789-dec1-4dd2-b0ca-05ecbf097ffc)|![wotr_extract](https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/c4612359-5bdc-44db-98dd-cdeec88ca9f1)|![rt_extract](https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/0006bc0c-5a1d-4161-b3d6-5f0110148867)|
|---|---|---|

#### Browse gallery and change/delete portraits
Allows the user to view existing/created and in-work game portraits. Allows the user to delete or change any portrait. Select the image(s) from the list and click the button corresponding to the required functionality. When deleting, it asks whether to continue. When editing, it asks whether to make a standalone/copy version, meaning to delete the old one/replace it. Manages all processing of folders and files. On-site replacement is now valid. It is no problem to change a specific portrait that may already be used by the game, so the user does not need to use any save-edit. It literally recreates the portrait based on new specifics.

|![path_browse](https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/f4b8da9f-602f-470d-b1d7-4d3a3504b782)|![wotr_browse1](https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/ec8111d5-588f-44ca-9f1b-d22e18872620)|![rt_browse](https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/223c4247-45a9-4840-8eae-d5a20b18ee0b)|
|---|---|---|

#### Browse Custom NPC Portraits, change/delete portraits (only for Pathfinder)
Allows the user to edit/delete portraits created using Custom NPC Portraits. Any portrait created by the mod can be modified. Viewing is implemented through the “Browse Gallery” page, using the buttons at the top of the corresponding page. You must have custom NPC portraits installed and allow it to create source folders with custom portraits. I cannot do anything about it but Custom NPC creates folders with portraits for characters only after the player character, PC meets NPC in the game itself. So, it is either you find a mod which contains pre-made folders (there are such mods), or make do with first encounter being with default portrait (which is not too scary, IMO). I would like to help you, but parsing through all the possible characters in all games is a bit frustrating and time-devouring task, so yes, my bad, sorry. Now, if you make a copy of custom portrait, the program creates a new directory in the same location as the original one, so it doesn't actually work in game after, since the mod still uses the old image, to put simply I cannot change how Custom NPC works, and would not do it anyway. On the other hand, when replacing, a backup is created in the same location, and it works in the game after replacing the original file, since the Custom NPC still uses this updated old portrait. This program does not create new custom portraits, but merely manages existing!

|![wotr_browse2](https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/1ec758b8-6d82-4016-941b-70609c4140e1)|![wotr_browse3](https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/2dfad59e-ab89-426c-80ac-19435e8f7bfe)|![wotr_browse4](https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/0a1eda51-6ad9-4b70-94c1-07ce365ecedb)|
|---|---|---|

Considering Warhammer 40000: Rogue Trader. Once Custom NPC portraits mod is implemented, I will make some changes, so Owlcat Portrait Manager can work with custom NPC portraits in Rogue Trader. Until then, there is a game check that blocks Custom NPC for Rogue Trader.

#### Settings
An attempt to prevent any problems with the path to portraits folder. Originally, the program automatically finds the correct game portrait folder, and it narrows down to about 99.9% cases. In a situation, where you are 'lucky', settings page allows you to find game portraits folder yourself. I, personally, have no idea how you came to this situation, but this is the solution of yours. The settings page also allows changing window size, so you can use the application in any resolution, and see portraits more clearly. Allows to change game type, observe which localization is in use and see whether Custom NPC Portraits mod is active.

|![path_settings](https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/eeb7027b-7bb8-4cb9-b0a6-9b9eee09454a)|![wotr_settings](https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/1ada41ba-cb06-4e11-a142-d4cf1e2d174f)|![rt_settings](https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/68ef5ff6-7402-4fb5-bfc4-4b0370680792)|
|---|---|---|

#### Localization
Now supports localization. The concept has changed. Now there is no need to add RESX/DLL localization files. They are initially built into the program. At first startup, the program language is the system language. After this, you can change the localization on the main page. Russian/English is written and checked manually, German is translated by machine artificial intelligence using DeepL. Some minor semantic, lexical mistakes might be implemented.

|![path_main](https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/d8fd38d9-cd58-480a-9109-bb4018ba12f4)|![wotr_rus](https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/a09eaf5d-debc-47d1-8f12-2413d29d228a)|![rt_ger](https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/98c84d20-364e-4e1f-bf1f-eba08dfeaca6)|
|---|---|---|

### Basic use cases
1. Choose your poison. Pathfinder, Warhammer?
2. Download any portrait pack from any source (for example https://www.nexusmods.com/pathfinderkingmaker/mods/92, https://www.nexusmods.com/warhammer40kroguetrader/mods/21). Make sure you're downloading the right package for the right game
3. Unpack it in any directory, it is recommended to be a non-protected by system and not a user folder, downloads folder would work just fine
4. Launch the program, choose the game, press extract, press choose folder, find the folder you just unpacked
5. Select which images to copy, press extract selected or press extract all to copy all the available portraits
6. Close app, launch the game, enjoy!
---
1. Choose your poison. Pathfinder, Warhammer?
2. Press create new portrait
3. If you want to use local image jump to step 4, if web image go to step 5
4. Press choose local and select the image you want to use, jump to step 7
5. Press choose web 
6. Input URL and press load, if the source is available, proceed. Otherwise, try another image, or simply download it and find locally
7. Press next and proceed to scaling page. Use mouse wheel in increase/decrease image. Move the image while holding the left mouse button to adjust it. Double-click restores images
8. Press create to add the portrait to the game portraits folder
9. In case, you messed up scaling, or simply want to change or delete the portrait. Open browse gallery, find your image. Select it. Press according button. Change the portrait (the name will be new whatsoever), or approve deletion 
10. Close app, launch the game, enjoy!
---
1. Download and install Custom NPC Portraits (https://www.nexusmods.com/pathfinderwrathoftherighteous/mods/346, https://www.nexusmods.com/pathfinderkingmaker/mods/100) using Unity Mod Manager (https://www.nexusmods.com/site/mods/21) 
2. If you are ready to cope with default portrait of NPC for the first meeting. Launch the game and play. Find the character whose portrait you would like to change, remember it. Go to step 4.
3. If you are not ready for step 2. Download any portrait package that is compatible with Custom NPC Portraits, extract it manually (unfortunately, this program does not support such an operation, since there are not many such compatible portrait packages) into the game portraits' folder.
4. Launch the program, go to 'Browse Gallery', click 'Show Custom' or 'Army', 'NPC', find the character.
5. Click edit, when asked whether to replace the original or not, click 'yes', a backup copy will be created in the same folder.
6. Adjust it as desired (see steps 4,5 of previous use case).
7. Close the app, launch the game and enjoy!

### Installation
Download the release, unpack it anywhere (literally), but I recommend using a separate folder and an unprotected directory, as it copies and saves images a lot. Launch Pathfinder Portrait Manager.exe and use the application as you wish. Do not delete or move the configuration file from the EXE. Also, do not delete the temporary folder while the program is running. Localization folders (ru, de) must be located next to the EXE. Do not delete anything that comes within 7z package

<img src="https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/292d9cb6-436d-48c8-aff4-f36bc263e74b" width="100%"/>

### Production info and bugs section
All bugs and errors should be reported in the corresponding Nexusmods section. I believe (hope) that there are only minor/graphical bugs left that are not critical for usability, so most likely there will be no patches. However, if something critical happens, I will try to fix it as soon as possible. From now on, there will be no functionality updates in version >1.2.0.0. I deceived you, from now on, there will be no functional updates, versions >1.3.5.0. Please note that the Pathfinder/Warhammer game's portraits folder is statically created, and the functionality is simple, so there is very little chance of a bug occurring in the program. Please check dependencies, launch and start the game at least once, reinstall the game (if you performed all of these steps, and it still does not work, I wholeheartedly admit my mistake >_<), report to bug section.

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

<p align="center"><img src="https://github.com/zeightOFFICIAL/portrait-manager-owlcat/assets/50341618/06bfadea-0877-413f-a239-e1f49710f6e8" width="450px" margin="auto"></img><br>This table should cover whether you can install .NET Framework on your PC. If the plus mark is placed on counter section then you can install the required version (which is 4.8), otherwise, your OS does not support this tool.</p><br>


#### Development and debugging addendum, concerns
* Pathfinder portrait's game folder is created statically, so it is the same no matter what device you are using (bound to Windows' file system). The directory detection code uses system paths to locate the AppData/LocalLow/Owlcat/Pathfinder || Warhammer/Portraits folder.
* Custom NPC Portraits uses previously mentioned system paths to navigate required folders. So if the first point fails, it fails too.
* If you are using Custom NPC Portraits, be sure to START the game at least once. <b>THE PROGRAM DOES NOT CREATE NEW PORTRAITS!</b>, it only modifies existing ones. So, to actually change someone's portrait, you need to meet them in the game and let the Custom NPC Portraits create his/her folder in the appropriate directory.
* Also keep in mind that some Custom NPC Portraits do not use the fulllength.png (largest) portrait as it is not utilized in the game, this program allows you to change it, but it does not use by the game itself.
* Each user has his own configuration. It is stored in an XML file in the AppData folder. It stores basic information about the window size, folder paths, selected language, and so on. The file is open for navigation and observation if there are any questions. I advise you not to change it.
* FolderBrowserDialog now (1.1.0.0) works for folder feature selection.
* The localization of the program initially depends on the current active system language, but later you can change the localization using the buttons on the main page. If the former does not work, try changing the language via buttons.
* Asynchronous image loading now (1.2.0.0) works for loading images into the Browse Gallery and Extract Folder pages.
* The program has not been subjected to thorough and constant testing and debugging, there are many pitfalls
* Most important topics: asynchronous loading, folder/file manipulation, folder discovery, image cropping/resizing.
* From the latter version (1.3.5.0) the program reads pressed keys, so the user can navigate the tool more conveniently. I was forced to use focus() method, since after each mouse clicking event the main window lose its focus, disabling any key pressing events. This is a quick fix, but nothing more elegant I come up with works
* From now on (1.3.5.0), user can see the proportion ratio on scaling page more clearly, allowing more accuracy during cropping and scaling, the proportions are imitated by all four paddings, because in the end, program resizes/crops/stretches as required by game. The only short back: window resize on settings page now restarts the application, which is not severe.
* If any of this doesn't help you find the bug, please let me know personally via Nexusmods.

##### Changelog
* 1.5 (current)
    * Added Pillars of Eternity, Pillars of Eternity: Deadfire, Tyranny, Wasteland 3 full support
    * Major graphics overhaul. Completely changed visual representation of the application
    * Major code refactoring
    * Major .exe size changes. (~13mb)
    * Major performance changes
* 1.3.5.0 (active)
    * Added Warhammer 40000: Rogue Trader full support. It does not support CustomNPC
    * Re-verified all translations and typings. No linguist is involved, so minor mistakes can be found. I consider nothing crucial, but expect no flawlessness in the matter
    * Minor refactoring, nothing of interest for users. Plus tiny optimization tweaks
    * Minor graphical changes, now all languages support Bebas Neue font, some margins, paddings adjusted, fixed buttons' and labels' text from being hidden from sight
    * Added keyboard events and legends for them. Now users are able to navigate the tool using keyboard, including dialogs/modal forms and main form, except settings page
    * Settings page back button, now restarts application
    * Transferred from .NET Framework 4.7.2 to .NET Framework 4.8. Nothing changed for users
    * Increased program size. (~7.5 Mb)
* 1.2.0.0 (working)
    * Added asynchronous loading of Browse Gallery and Extract Folder. Loading of images on these pages is faster and I/O-free, allowing more smooth and convenient experience
    * Added Custom NPC Portraits support. Added support for portraits created by edvin76's mod. Portraits of both the army and NPCs can be altered using this application
    * Major code refactoring
    * Optimization changes
    * The concept of localization has been changed. Now you can change the localization using the buttons on the main page. Initial localization depends on the system language
    * Currently available localizations: en-US, ru-RU, de-DE, the latter one is translated by AI, so it is flawed
    * Changes in the settings page
    * Added fault tolerance for Extract Folder, so partially incorrect portraits are still processed by a program
* 1.1.0.0b (deprecated)
    * Minor graphical changes
    * Optimization changes
    * Code refactored
    * Added localization support, now includes translation file for Russian language
    * Removed unnecessary if/else on image zooming
    * Removed dependency on outdated folder chose dialog, swapped to new FolderBrowserDialog
    * Added settings page to set up portrait folder path for each game type and to resize window
    * Added features that allow user to change every portrait separately
* 1.0.0.2e (deprecated)
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
6. All rights for Pillars of Eternity belongs to Obsidian Entertainment (https://www.obsidian.net/)
7. All rights for Pillars of Eternity: Deadfire belongs to Obsidian Entertainment (https://www.obsidian.net/)
8. All rights for Tyranny belongs to Obsidian Entertainment (https://www.obsidian.net/)
9. All rights for Wasteland 3 belongs to inXile Entertainment (https://www.inxile-entertainment.com/)
10. Images and icons used in program belongs to Owlcat Games, Obsidian Entertainment, inXile Entertainment
11. Used font Bebas Neue belongs to its creator Ryoichi Tsunekawa (https://fonts.google.com/specimen/Bebas+Neue, http://dharmatype.com)
12. Used font Bebas Neue for cyrillic belongs to its creator Ryoichi Tsunekawa and AA (https://fonts-online.ru/fonts/bebas-neue-cyrillic, http://dharmatype.com)
13. All rights for https://www.nexusmods.com/pathfinderkingmaker/mods/92 belongs to Nexus Mods (https://www.nexusmods.com/) and Citrus457 (https://www.nexusmods.com/pathfinderkingmaker/users/60287596)
14. All rights for https://www.nexusmods.com/warhammer40kroguetrader/mods/21 belongs to Nexus Mods (https://www.nexusmods.com/) and wonszlol (https://www.nexusmods.com/warhammer40kroguetrader/users/1105885)
15. All rights for https://www.nexusmods.com/pathfinderwrathoftherighteous/mods/346 and https://www.nexusmods.com/pathfinderkingmaker/mods/100 (Custom Npc Portraits) belongs to Nexus Mods (https://www.nexusmods.com/) and edvin76 (https://www.nexusmods.com/pathfinderkingmaker/users/1599293), (https://github.com/edvin76/CustomNpcPortraits). Please note, that none of the Assets of Custom Npc Portraits is used, just its result. I am not in cooperation with edvin76, but respect the work. 

<b>Inform: if your owner's rights have been violated; if you encounter any errors; if you have suggestions for improving functionality/optimization. I am open to any ideas.
Disclaimer: This is not a product of Owlcat Games, Obsidian Entertainment or inXile Entertainment, it is developed by a third party which has nothing to do with these listed studios. I am not responsible for any bugs and issues in games caused by software (no warranty). Every/Any image which is used in/processed by this software does not belong to me and does not imply anything. Clients (users) of this software are responsible for selecting a specific image and subsequent use of the processed image. Any image uploaded to this software is not biased, its content is not analyzed aside from its size, no actions are taken to change the image aside from  resizing. This software only allows users to modify images more easily whether they are protected or not, contains mature content or not, used against the copyright (or any other) law or not. Selecting an image and its use is entirely at the discretion of the user. Custom NPC Portrait does not belong to me, but to edvin76, I do not utilize any of the assets.</b>
