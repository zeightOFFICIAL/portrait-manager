![list1](https://user-images.githubusercontent.com/50341618/227392274-89674a5f-96f7-4113-92f9-152702ebffe4.png)

## <p align="center">Desktop application for managing in-game portraits for Pathfinder: Kingmaker and Pathfinder: Wrath of the Righteous</p>

### Created by Artemii "Zeight" Saganenko
### Nexus mods link: 
https://www.nexusmods.com/pathfinderwrathoftherighteous/mods/466<br>
https://www.nexusmods.com/pathfinderkingmaker/mods/277

### Description

Desktop application, management tool for portraits in the Pathfinder series of games. A lightweight, user-friendly, simple and mostly optimized tool for creating new portraits as well as modifying old ones. Allows the user to manage portraits more conveniently and quickly. Simplifies the process of copying, pasting, scaling and moving images. The application also allows the user to delete or change existing portraits. Supports both Kingmaker and Wrath of the Righteous. Requires nothing, no dependencies at all, apart from .NET Framework 4.7.2, which is 99% likely to be already installed. 


| Kingmaker | Wrath of the Righteous |
| :-------: | :--------------------: |
|![image](https://user-images.githubusercontent.com/50341618/230695030-8eeca4ce-9a8b-4cb6-adc8-5989805932c1.png)|![image](https://user-images.githubusercontent.com/50341618/230695023-ce0ea4a0-33f1-4ca6-9b8e-bb69b4923b1e.png)|

| Load any image | Scale image to portrait |
| :------------: | :---------------------: |
|![image](https://user-images.githubusercontent.com/50341618/230694986-3885a913-23b1-4cf3-858d-2d3fbbd662a2.png)|![image](https://user-images.githubusercontent.com/50341618/230695012-7bdbd799-4b57-4005-b991-bed54560df1c.png)|

| Extract from folder | Browse existing |
| :-----------------: | :-------------: |
|![image](https://user-images.githubusercontent.com/50341618/230695083-27ed532e-1023-4434-8ecf-2275cfd3e8a5.png)|![image](https://user-images.githubusercontent.com/50341618/230695176-0c213a01-380f-43cd-9ea9-45264954b9ec.png)|

| Settings page | Load web-image page |
| :-----------------: | :-------------: |
|![image](https://user-images.githubusercontent.com/50341618/230695227-ecb3ddf1-5d43-4b57-b4b6-b9d7c8f64e7b.png)|![image](https://user-images.githubusercontent.com/50341618/230695265-b8f126bc-2640-4531-a8ec-7e1547aa67dc.png)|

### Features

#### Create new portraits
Allows user to load any local or web image, to scale it as he sees fit and finally create the portrait in the proper game directory. Supports all prime image formats, which are png, jpg, jpeg, bmp, gif. Now allows the user to change the image for each portrait type by uploading a local or web image with the specific portrait type selected. The created portraits will be almost exact copies of the images set up in frames during scaling. The program automatically crops, resize the image to needed state, creates directory and image file.

#### Extract from external folders
Allows user to extract images from local directory right to their proper place in game directory. Choose which folder to process in order to fetch the images, which should be a proper representation of portrait pack*. Select which portraits to move to the game directory. Press extract selected to move the chosen. In case you want to extract all, press the according button. The program automatically copies the folders to the game portraits' directory.

#### Browse gallery and change/delete old images
Allows user to browse the already existing/loaded and in-work portraits of the game. Makes possible for user to delete or change specific portraits. Select image(s) from the list and press the button which corresponds to needed functionality. Upon deleting, asks whether to proceed. Upon editing, asks whether to make a standalone/copy version or delete the old one and replace. Manages all folder and file processing. Now the in-place replacement is valid. Without any problems, you can change a specific portrait that may already be in use by the game, so the user does not need to use any save-editing. Cannot change in-game NPC portraits! It might come later, however.

#### Settings
An attempt to prevent any problems with the path to portraits folder. Now, the program requires the user to select the correct folder in which all the game portraits are stored.

#### Localization
Now supports translation files. The program language depends on the system language. If next to the exe there is a folder named with the language abbreviation ru/fr/es and so on, loads localization <b>(which is DLL, as has been compiled)</b> file in the folder and applies it in the application.

### Basic use cases
1. Download any portrait pack from any source (for example https://www.nexusmods.com/pathfinderkingmaker/mods/92)
2. Unpack it in any directory, it is recommended to be a non-protected by system or user folder, downloads folder would work just fine
3. Launch the program, press extract, press choose folder, find the folder you just unpacked
4. Select which images to copy, press extract selected or press extract all to copy all the available portraits
5. Launch the game, enjoy!
---
1. Press create new portrait
2. Press choose local and select the image you want to use<br>
  2b. Press choose web<br>
  2b next. Input URL and press load, if the source is available, proceed. Otherwise, try another image, or simply download it and find locally<br>
3. Press next and proceed to scaling page. Use mouse wheel in increase/decrease image. Move the image while holding the left mouse button to adjust it. Double-click restores images
4. Press create to add the portrait to the game portraits folder
5. In case, you messed up scaling, or simply want to change or delete the portrait. Open browse gallery, find your image. Select it. Press according button. Change the portrait (the name will be new whatsoever), or approve deletion 
5. Close app, launch the game, enjoy!

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
* 1.0.0.2e

#### Translation addendum
The program was optimized to use several languages and fonts. In order to create a translation, load TextVariables.resx, copy it. Change its name to TextVariables.{X}.dll, where X - is a short calling for language, fr, ru, en, etc. After that, full value fields to the according translations. However, I still need to integrate it to the program manually.

### Copyrights
1. Program license: GPL-2.0 license, conditions listed in LICENSE (https://github.com/zeightOFFICIAL/portrait-manager-pathfinder/blob/master/LICENSE)
2. All rights for Visual Studio 2022 belongs to Microsoft (https://www.microsoft.com/)
3. All rights for Pathfinder: Kingmaker and Pathfinder: Wrath of the Righteous belongs to Owlcat Games (https://owlcat.games/)
4. All rights for https://www.nexusmods.com/pathfinderkingmaker/mods/92 belongs to Nexus Mods (https://www.nexusmods.com/) and Citrus457 (https://www.nexusmods.com/pathfinderkingmaker/users/60287596)
5. Images and icons used in program belongs to Owlcat Games (https://owlcat.games/)
6. Used font Bebas Neue belongs to its creator (https://fonts.google.com/specimen/Bebas+Neue)<br><br>
7. 
<b>Inform: if your owner rights are violated; if you've encountered any bugs; if you have any suggestions.
Disclaimer: this is not a product of Owlcat Games, it is developed by a third parties. Every image used in this application, and processed by it, does not belong to this program's author. Clients (users) are responsible for selecting the image, and using processed by the program images.</b>
