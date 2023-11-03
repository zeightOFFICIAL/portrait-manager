![list1](https://user-images.githubusercontent.com/50341618/227392274-89674a5f-96f7-4113-92f9-152702ebffe4.png)

## <p align="center">Desktop application for managing in-game portraits for Pathfinder: Kingmaker and Pathfinder: Wrath of the Righteous</p>

### Created by Artemii "Zeight" Saganenko
### Nexus mods link: 
https://www.nexusmods.com/pathfinderwrathoftherighteous/mods/466<br>
https://www.nexusmods.com/pathfinderkingmaker/mods/277

### Description

Desktop application, management tool for portraits in the Pathfinder series of games. A lightweight, user-friendly, simple and mostly optimized tool for creating new portraits as well as modifying old ones. Allows the user to manage portraits more conveniently and quickly. Simplifies the process of copying, pasting, scaling and moving images. The application also allows the user to delete or change existing portraits. Supports both Kingmaker and Wrath of the Righteous. Requires nothing, no dependencies at all, apart from .NET Framework 4.7.2, which is 99% likely to be already installed. Supports Custom NPC Portraits to edit NPC's and army's images.


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
|![image](https://github.com/zeightOFFICIAL/portrait-manager-pathfinder/assets/50341618/7ccd5446-b406-4763-ba3f-691d4503d78c)|![image](https://github.com/zeightOFFICIAL/portrait-manager-pathfinder/assets/50341618/8b509422-0399-4e46-b545-354b1b85b918)|

| Settings page | Load web-image page |
| :-----------------: | :-------------: |
|![image](https://github.com/zeightOFFICIAL/portrait-manager-pathfinder/assets/50341618/17ae9a9e-287f-4017-bd57-e2473268e75b)|![image](https://github.com/zeightOFFICIAL/portrait-manager-pathfinder/assets/50341618/914124d3-c4f7-41f0-a3c8-80fbe0e3a270)|

| Russian translation | German translation |
| :-----------------: | :-------------: |
|![image](https://github.com/zeightOFFICIAL/portrait-manager-pathfinder/assets/50341618/d9786dca-6487-4970-a415-bd0db0d36e38)|![image](https://github.com/zeightOFFICIAL/portrait-manager-pathfinder/assets/50341618/022fc44d-2dec-4195-b274-84182e4d23b6)|

### Features

#### Create new portraits
Allows the user to upload any local or web image, scale it as desired, and finally create a portrait in the appropriate game directory. Supports all major image formats: png, jpg, jpeg, bmp, gif. Now allows the user to change the image for each portrait type: small, medium, full length, by uploading a local or web image with the specific portrait type selected. Unsupported files are ignored. The created portraits will be almost exact copies of the images displayed in the frames when scaled. The error is raised by trimming and resizing errors, they are expected and nothing can be done about it. The program automatically crops, resizes the image to the required state, creates a directory and an image file.

#### Extract from external folders
Allows the user to extract images from a local directory directly into the game directory. Select the folder containing the correct portrait package images to process and create the images in game folder. Choose which portraits to move to the game directory. You can extract selected ones to move only certain ones. Or extract every one. The program automatically copies folders to the game portraits' directory. Works only with regular portraits. Custom NPC portraits don't work.

*A valid image package must contain three images: small - 185x242 (factor 1.308), medium - 330x432 (factor 1.309), full size - 692x1024 (factor 1.479). The program performs recursive parsing, so corresponding folders located deeper than one directory will still be processed. Other files will be ignored. Please note that these are the official proportions shown in the game, other sizes may not fit. The failsafe is +2 pixels in width and +3 pixels in height, but this cannot be promised to work in game.

#### Browse gallery and change/delete portraits
Allows the user to view existing/created and in-work game portraits. Allows the user to delete or change any portrait. Select the image(s) from the list and click the button corresponding to the required functionality. When deleting, it asks whether to continue. When editing, it asks whether to make a standalone/copy version or delete the old one and replace it. Manages all processing of folders and files. On-site replacement is now valid. It is no problem to change a specific portrait that may already be used by the game, so the user does not need to use any save-edit.

#### Browse Custom NPC Portraits, change/delete portraits
Allows the user to edit/delete portraits created using Custom NPC Portraits. Any portrait created by the mod can be modified. Viewing is carried out through the “Browse Gallery” page, using the buttons at the top of the corresponding page. You must have custom NPC portraits installed and allow it to create source folders with custom portraits. If you make a copy, the program creates a new directory in the same location as the original one, so it doesn't actually work in game after, since the mod still uses the old image. On the other hand, when replacing, a backup is created in the same location, and it works in the game after replacing the original file. This program does not create new custom portraits, but merely manages existing.

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
Download release, unpack anywhere (verbatim), but I recommend using separate folder and not-protected directory, since it copies and save images abundantly. Launch Pathfinder Portrait Manager.exe, use the app as you see fit. Don't delete or move configuration file away from exe. As well, do not delete temp folder, while program is working. Localization folder should be next to exe, and should not be deleted while app is running.

### Production info and bugs section
All the errors and bugs should be reported to in the according section of nexusmods. I believe (more hope like) that the only bugs left are minor/graphical and non-critical for usability, so most likely there will be no patches. However, if something essential appears, I will try to fix it ASAP. From now on, version >1.2.0.0, there will be no functionality updates.

### Build info
* C#
* .NET Framework 4.7.2, no special DLLs involved
* Visual Studio 2022 17.4.4

---
Compatible with latest Windows OSs, <b>in any case .NET Framework 4.7.2 is required</b><br>
✅ Tested with Windows 11<br>
✅ Tested with Windows 10<br>
✅ Some minor issues detected with Windows 8/8.1<br>
⭕ Untested but it probably works on Windows 7<br>
⭕ Might work with Windows XP/Vista<br>
❌ Highly unlikely with something older<br>
❌ Not working with UNIX-based (Linux/MAC)<br>

#### Development and debugging addendum, concerns
* Code to detect whether the directory is indeed game-created
```c sharp
public static bool ValidatePortraitPath(string path)
{
    if (SystemControl.FileControl.Readonly.DirectoryExists(path) &&
        path.Split('\\').Last() == "Portraits")
    {
        return true;
    }
    return false;
}
```
* There might be problems with folder manipulation
* FolderBrowserDialog is now (1.1.0.0) in work for choosing folder function
* Program localization depends on currently active system language
```c sharp
public MainForm()
{
    Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentUICulture;
    InitializeComponent();
}
```
* 
* The program have not been under heavy and constant testing and debugging, there are a lot of pitfalls

##### Changelog
* 1.2.0.0
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

#### Translation addendum
The program was optimized to use several languages and fonts. In order to create a translation, load TextVariables.resx, copy it. Change its name to TextVariables.{X}.dll, where X - is a short calling for language, fr, ru, en, etc. After that, full value fields to the according translations. However, I still need to integrate it to the program manually.

### Copyrights
1. Program license: GPL-2.0 license, conditions listed in LICENSE (https://github.com/zeightOFFICIAL/portrait-manager-pathfinder/blob/master/LICENSE)
2. All rights for Visual Studio 2022 belongs to Microsoft (https://www.microsoft.com/)
3. All rights for Pathfinder: Kingmaker and Pathfinder: Wrath of the Righteous belongs to Owlcat Games (https://owlcat.games/)
4. All rights for https://www.nexusmods.com/pathfinderkingmaker/mods/92 belongs to Nexus Mods (https://www.nexusmods.com/) and Citrus457 (https://www.nexusmods.com/pathfinderkingmaker/users/60287596)
5. Images and icons used in program belongs to Owlcat Games (https://owlcat.games/)
6. Used font Bebas Neue belongs to its creator (https://fonts.google.com/specimen/Bebas+Neue)
7. All right to Custom Npc Portraits (https://www.nexusmods.com/pathfinderwrathoftherighteous/mods/346, https://www.nexusmods.com/pathfinderkingmaker/mods/100) belongs to edvin76 (https://www.nexusmods.com/pathfinderkingmaker/users/1599293), (https://github.com/edvin76/CustomNpcPortraits)<br>
    7.b. Please note, that I am not using any of Assets of Custom Npc Portraits.

<b>Inform: if your owner rights are violated; if you've encountered any bugs; if you have any suggestions.
Disclaimer: this is not a product of Owlcat Games, it is developed by a third parties. Every image used in this application, and processed by it, does not belong to this program's author. Clients (users) are responsible for selecting the image, and using processed by the program images.</b>
