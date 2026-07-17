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

using PortraitManager.forms;
using PortraitManager.Properties;
using PortraitManager.sources;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using SharpCompress.Archives;
using SharpCompress.Common;

namespace PortraitManager
{
    public partial class MainForm : Form
    {
        /// Hides every top-level page layout (main/extract/gallery/start menu/path/create-portrait).
        public void ParentLayoutsDisable()
        {
            RootFunctions.LayoutDisable(LayoutMainPage);
            RootFunctions.LayoutDisable(LayoutExtractPage);
            RootFunctions.LayoutDisable(LayoutGalleryPage);
            RootFunctions.LayoutDisable(LayoutStartMenu);
            RootFunctions.LayoutDisable(LayoutPathPage);
            RootFunctions.LayoutDisable(LayoutKingCreatePortrait);
        }
        
        public void ParentLayoutsSetDockFill()
        {
            foreach (Control control in Controls)
            {
                RootFunctions.LayoutsSetDockFill(control);
            }
        }
        
        /// Shared TableLayoutPanel-based page-navigation helpers used across MainForm.
        class RootFunctions
        {
            static public void LayoutEnable(TableLayoutPanel table)
            {
                if (table.Visible == false && table.Enabled == false)
                {
                    table.Visible = true;
                    table.Enabled = true;
                }
            }
            
            static public void LayoutDisable(TableLayoutPanel table)
            {
                if (table.Visible == true && table.Enabled == true)
                {
                    table.Visible = false;
                    table.Enabled = false;
                }
            }
            
            static public void LayoutsSetDockFill(Control control)
            {
                if (control is TableLayoutPanel)
                {
                    control.Dock = DockStyle.Fill;
                }

                foreach (Control subCtrl in control.Controls)
                {
                    LayoutsSetDockFill(subCtrl);
                }
            }
        }

        /// Fits each portrait editor's currently loaded image to its PictureBox using cover-scaling.
        public void ReplacePictureBoxImagesToDefault()
        {
            // Apply "cover" scaling to portrait picture boxes so one dimension matches the
            // PictureBox and the other is >= PictureBox (can be cropped). This centers the
            // image and allows later zoom/pan logic to operate on the original image.
            try
            {
                // Large
                if (PicKingLrg != null && PicKingLrg.Image != null)
                {
                    // preserve original copy for zoom operations
                    if (_originalImageLrg == null)
                        _originalImageLrg = new Bitmap(PicKingLrg.Image);

                    var scaled = ImageControl.PortraitCrop.ResizeCover(_originalImageLrg, PicKingLrg.Width, PicKingLrg.Height);
                    // use Normal mode and set control size to match rendered image so drag/zoom
                    // logic (which uses PictureBox.Width/Height as image size) stays correct
                    PicKingLrg.Dock = DockStyle.None;
                    PicKingLrg.SizeMode = PictureBoxSizeMode.Normal;
                    PicKingLrg.Size = new Size(scaled.Width, scaled.Height);
                    // dispose previous displayed image if it is not the original reference
                    if (PicKingLrg.Image != null && !object.ReferenceEquals(PicKingLrg.Image, _originalImageLrg))
                    {
                        try { PicKingLrg.Image.Dispose(); } catch { }
                    }
                    PicKingLrg.Image = scaled;
                }

                // Medium
                if (PicKingMed != null && PicKingMed.Image != null)
                {
                    if (_originalImageMed == null)
                        _originalImageMed = new Bitmap(PicKingMed.Image);

                    var scaled = ImageControl.PortraitCrop.ResizeCover(_originalImageMed, PicKingMed.Width, PicKingMed.Height);
                    PicKingMed.Dock = DockStyle.None;
                    PicKingMed.SizeMode = PictureBoxSizeMode.Normal;
                    PicKingMed.Size = new Size(scaled.Width, scaled.Height);
                    if (PicKingMed.Image != null && !object.ReferenceEquals(PicKingMed.Image, _originalImageMed))
                    {
                        try { PicKingMed.Image.Dispose(); } catch { }
                    }
                    PicKingMed.Image = scaled;
                }

                // Small
                if (PicKingSml != null && PicKingSml.Image != null)
                {
                    if (_originalImageSml == null)
                        _originalImageSml = new Bitmap(PicKingSml.Image);

                    var scaled = ImageControl.PortraitCrop.ResizeCover(_originalImageSml, PicKingSml.Width, PicKingSml.Height);
                    PicKingSml.Dock = DockStyle.None;
                    PicKingSml.SizeMode = PictureBoxSizeMode.Normal;
                    PicKingSml.Size = new Size(scaled.Width, scaled.Height);
                    if (PicKingSml.Image != null && !object.ReferenceEquals(PicKingSml.Image, _originalImageSml))
                    {
                        try { PicKingSml.Image.Dispose(); } catch { }
                    }
                    PicKingSml.Image = scaled;
                }

                // Sml2
                if (PicKingSml2 != null && PicKingSml2.Image != null)
                {
                    if (_originalImageSml2 == null)
                        _originalImageSml2 = new Bitmap(PicKingSml2.Image);

                    var scaled = ImageControl.PortraitCrop.ResizeCover(_originalImageSml2, PicKingSml2.Width, PicKingSml2.Height);
                    PicKingSml2.Dock = DockStyle.None;
                    PicKingSml2.SizeMode = PictureBoxSizeMode.Normal;
                    PicKingSml2.Size = new Size(scaled.Width, scaled.Height);
                    if (PicKingSml2.Image != null && !object.ReferenceEquals(PicKingSml2.Image, _originalImageSml2))
                    {
                        try { PicKingSml2.Image.Dispose(); } catch { }
                    }
                    PicKingSml2.Image = scaled;
                }
            }
            catch
            {
                // silently ignore failures during UI default replacement
            }
        }

        /// Navigates to the game-folder selection page for the currently selected game.
        private void OpenPathSelectPage()
        {
            ParentLayoutsDisable();
            LabelSelectPathResetPath_Click(this, new EventArgs());
            RootFunctions.LayoutEnable(LayoutPathPage);
        }

        private Image LoadImageFromBytes(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            using (Image temp = Image.FromStream(ms))
            {
                return new Bitmap(temp);
            }
        }

        private byte[] ReadEntryBytes(ZipArchiveEntry entry)
        {
            using (var stream = entry.Open())
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }

        private bool IsImageFile(string name)
        {
            string ext = Path.GetExtension(name);
            return ext.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
                   ext.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                   ext.Equals(".png", StringComparison.OrdinalIgnoreCase) ||
                   ext.Equals(".bmp", StringComparison.OrdinalIgnoreCase) ||
                   ext.Equals(".gif", StringComparison.OrdinalIgnoreCase) ||
                   ext.Equals(".webp", StringComparison.OrdinalIgnoreCase);
        }

        private static Size FitSize(Size original, int maxSize)
        {
            double ratio = Math.Min((double)maxSize / original.Width, (double)maxSize / original.Height);
            if (ratio >= 1.0) return original;
            return new Size((int)(original.Width * ratio), (int)(original.Height * ratio));
        }

        private void AddArchiveThumbnail(string folderKey, Image image, bool complete = true)
        {
            Bitmap memImage = new Bitmap(image);

            _archiveEntries.Add(Tuple.Create<string, Image>(folderKey, memImage));

            Size thumbSize = FitSize(new Size(memImage.Width, memImage.Height), 140);
            int cbWidth = Math.Max(thumbSize.Width + 20, 145);
            int cbHeight = thumbSize.Height + 50;

            Color gameBack, gameFore;
            try { gameBack = GameTypes[_gameSelected].BackColor; gameFore = GameTypes[_gameSelected].ForeColor; }
            catch { gameBack = Color.FromArgb(12, 12, 12); gameFore = Color.White; }

            string displayText = complete ? Path.GetFileName(folderKey) : Path.GetFileName(folderKey) + " (partial)";
            Color borderColor = complete ? gameBack : Color.FromArgb(230, 180, 40);

            CheckBox cb = new CheckBox
            {
                Text = displayText,
                Tag = folderKey,
                Checked = false,
                ForeColor = Color.White,
                BackColor = gameBack,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(cbWidth, cbHeight),
                TextAlign = ContentAlignment.BottomCenter,
                Padding = new Padding(8, 8, 8, 4),
                ImageAlign = ContentAlignment.TopCenter
            };

            cb.Font = new Font(_fontCollection.Families[0], 13);

            cb.FlatAppearance.BorderSize = 3;
            cb.FlatAppearance.BorderColor = borderColor;
            cb.FlatAppearance.CheckedBackColor = ControlPaint.Light(gameBack, 0.3f);
            cb.FlatAppearance.MouseOverBackColor = ControlPaint.Light(gameBack, 0.15f);

            cb.MouseEnter += (s, args) => { cb.ForeColor = gameFore; };
            cb.MouseLeave += (s, args) => { cb.ForeColor = Color.White; };
            cb.CheckedChanged += (s, args) =>
            {
                cb.FlatAppearance.BorderColor = cb.Checked ? gameFore : borderColor;
                UpdateExtractCounter();
            };

            Image thumb = new Bitmap(memImage, thumbSize);
            cb.Image = thumb;
            cb.Appearance = Appearance.Button;

            FlowLayoutPanelExtract.Controls.Add(cb);
        }

        private bool IsValidPortraitSize(Size imageSize)
        {
            return IsValidPortraitSize(imageSize, _gameSelected);
        }

        private bool IsValidPortraitSize(Size imageSize, char gameSelected)
        {
            if (gameSelected != 'k' && gameSelected != 'w' && gameSelected != 'r' && gameSelected != 't' && gameSelected != 'l' && gameSelected != 'p' && gameSelected != 'd')
                return true;

            try
            {
                var gt = GameTypes[gameSelected];
                var expected = new List<Size>();
                try { expected.Add(new Size((int)gt.GetPortraitSpecific("SMALL_WIDTH"), (int)gt.GetPortraitSpecific("SMALL_HEIGHT"))); } catch { }
                try { expected.Add(new Size((int)gt.GetPortraitSpecific("MEDIUM_WIDTH"), (int)gt.GetPortraitSpecific("MEDIUM_HEIGHT"))); } catch { }
                try { expected.Add(new Size((int)gt.GetPortraitSpecific("LARGE_WIDTH"), (int)gt.GetPortraitSpecific("LARGE_HEIGHT"))); } catch { }
                try { expected.Add(new Size((int)gt.GetPortraitSpecific("SML2_WIDTH"), (int)gt.GetPortraitSpecific("SML2_HEIGHT"))); } catch { }

                foreach (var exp in expected)
                {
                    if (Math.Abs(imageSize.Width - exp.Width) <= 2 &&
                        Math.Abs(imageSize.Height - exp.Height) <= 3)
                        return true;
                }
                return false;
            }
            catch { return true; }
        }

        private void ValidatePortraitSize(string filePath, ref bool hadInvalid)
        {
            try
            {
                using (var bmp = new Bitmap(filePath))
                {
                    if (!IsValidPortraitSize(bmp.Size))
                    {
                        File.Delete(filePath);
                        hadInvalid = true;
                    }
                }
            }
            catch
            {
                hadInvalid = true;
            }
        }

        private void ClearArchiveEntries()
        {
            if (_archiveEntries != null)
            {
                foreach (var entry in _archiveEntries)
                    entry.Item2?.Dispose();
                _archiveEntries = null;
            }
            foreach (Control c in FlowLayoutPanelExtract.Controls)
            {
                if (c is CheckBox cb && cb.Image != null)
                {
                    cb.Image.Dispose();
                    cb.Image = null;
                }
            }
            FlowLayoutPanelExtract.Controls.Clear();
            UpdateExtractCounter();
        }

        private string GetGameDirectory()
        {
            string basePath = CoreSettings.Default.GamePath;
            if (string.IsNullOrEmpty(basePath) || basePath == "0")
                return null;
            basePath = basePath.TrimEnd(Path.DirectorySeparatorChar);

            string path;
            switch (_gameSelected)
            {
                case 'p':
                    path = Path.Combine(basePath, "PillarsOfEternity_Data", "data", "art", "gui", "portraits", "player", "male");
                    break;
                case 'd':
                    path = Path.Combine(basePath, "PillarsOfEternityII_Data", "gui", "portraits", "player", "male");
                    break;
                case 't':
                    path = Path.Combine(basePath, "Data", "data", "art", "gui", "portraits", "player", "male");
                    break;
                case 'l':
                    path = Path.Combine(basePath, "Custom Portraits");
                    break;
                default:
                    path = Path.Combine(basePath, "Portraits");
                    break;
            }

            try { Directory.CreateDirectory(path); } catch { }
            return path;
        }

        private void ClearGalleryEntries()
        {
            _selectedGalleryEntry = null;
            if (_galleryEntries != null)
            {
                foreach (var entry in _galleryEntries)
                    entry.Item2?.Dispose();
                _galleryEntries = null;
            }
            foreach (Control c in FlowLayoutPanelGallery.Controls)
            {
                if (c is CheckBox cb && cb.Image != null)
                {
                    cb.Image.Dispose();
                    cb.Image = null;
                }
            }
            FlowLayoutPanelGallery.Controls.Clear();
        }

        private void AddGalleryThumbnail(string folderKey, Image image, string displayNameOverride = null)
        {
            Bitmap memImage = new Bitmap(image);

            _galleryEntries.Add(Tuple.Create<string, Image>(folderKey, memImage));

            int gridWidth = FlowLayoutPanelGallery.ClientSize.Width;
            if (gridWidth <= 0) gridWidth = 490;
            float targetCols = 3.5f;
            float targetCtrlWidth = gridWidth / targetCols;
            float imageWidth = targetCtrlWidth - 26;
            if (memImage.Width > 0 && memImage.Height > 0)
            {
                float imgAspect = (float)memImage.Height / memImage.Width;
                int maxSize = Math.Max((int)(imageWidth * Math.Max(imgAspect, 1.0f)), 100);
                Size thumbSize = FitSize(new Size(memImage.Width, memImage.Height), maxSize);
                int cbWidth = Math.Max(thumbSize.Width + 20, 145);
                int cbHeight = thumbSize.Height + 60;

                Color gameBack, gameFore;
                try { gameBack = GameTypes[_gameSelected].BackColor; gameFore = GameTypes[_gameSelected].ForeColor; }
                catch { gameBack = Color.FromArgb(12, 12, 12); gameFore = Color.White; }

                RadioButton rb = new RadioButton
                {
                    Text = displayNameOverride ?? DisplayNameForGalleryFolder(Path.GetFileName(folderKey)),
                    Tag = folderKey,
                    Checked = false,
                    ForeColor = Color.White,
                    BackColor = gameBack,
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(cbWidth, cbHeight),
                    TextAlign = ContentAlignment.BottomCenter,
                    Padding = new Padding(8, 8, 8, 4),
                    ImageAlign = ContentAlignment.TopCenter,
                    Appearance = Appearance.Button,
                    Cursor = _isCustomNpcMode ? Cursors.Default : Cursors.Hand,
                };

                rb.Font = new Font(_fontCollection.Families[0], 12);

                rb.FlatAppearance.BorderSize = 3;
                rb.FlatAppearance.BorderColor = gameBack;
                rb.FlatAppearance.CheckedBackColor = ControlPaint.Light(gameBack, 0.3f);
                rb.FlatAppearance.MouseOverBackColor = ControlPaint.Light(gameBack, 0.15f);

                rb.MouseEnter += (s, args) => { rb.ForeColor = gameFore; };
                rb.MouseLeave += (s, args) => { rb.ForeColor = Color.White; };
                rb.CheckedChanged += (s, args) =>
                {
                    if (rb.Checked)
                    {
                        _selectedGalleryEntry = folderKey;
                    }
                    rb.FlatAppearance.BorderColor = rb.Checked ? gameFore : gameBack;
                    UpdateGalleryRightPanel();
                };

                Image thumb = new Bitmap(memImage, thumbSize);
                rb.Image = thumb;

                FlowLayoutPanelGallery.Controls.Add(rb);
            }
        }

        private string FindBestGalleryImage(string folderPath)
        {
            bool isOwlcat = _gameSelected == 'k' || _gameSelected == 'w' || _gameSelected == 'r';

            if (isOwlcat)
            {
                if (!Directory.Exists(folderPath)) return null;
                string[] files = GetPngFilesWithBackupFallback(folderPath);
                if (files.Length == 0) return null;
                string match;
                match = files.FirstOrDefault(f => Path.GetFileName(f).Equals("Fulllength.png", StringComparison.OrdinalIgnoreCase));
                if (match != null) return match;
                match = files.FirstOrDefault(f => Path.GetFileName(f).Equals("Medium.png", StringComparison.OrdinalIgnoreCase));
                if (match != null) return match;
                match = files.FirstOrDefault(f => Path.GetFileName(f).Equals("Small.png", StringComparison.OrdinalIgnoreCase));
                if (match != null) return match;
                return files[0];
            }
            else
            {
                string dir = Path.GetDirectoryName(folderPath);
                string prefix = Path.GetFileName(folderPath);

                if (_gameSelected == 'l')
                {
                    string path = folderPath + ".png";
                    return File.Exists(path) ? path : null;
                }
                else
                {
                    string[] prio = { "_lg", "_med", "_sm", "_convo" };
                    foreach (string suf in prio)
                    {
                        string path = Path.Combine(dir, prefix + suf + ".png");
                        if (File.Exists(path)) return path;
                    }
                    return null;
                }
            }
        }

        private void DeleteGalleryPortraitSet(string path)
        {
            if (string.IsNullOrEmpty(path)) return;

            try
            {
                if (_gameSelected == 'k' || _gameSelected == 'w' || _gameSelected == 'r')
                {
                    if (Directory.Exists(path))
                        Directory.Delete(path, recursive: true);
                }
                else if (_gameSelected == 'l')
                {
                    string filePath = path + ".png";
                    if (File.Exists(filePath))
                        File.Delete(filePath);
                }
                else
                {
                    string dir = Path.GetDirectoryName(path);
                    string prefix = Path.GetFileName(path);
                    string[] suffixes = { "_lg", "_sm", "_si", "_convo" };
                    foreach (string suf in suffixes)
                    {
                        string filePath = Path.Combine(dir, prefix + suf + ".png");
                        if (File.Exists(filePath))
                            File.Delete(filePath);
                        string backupPath = filePath + ".backup";
                        if (File.Exists(backupPath))
                            File.Delete(backupPath);
                    }
                    string femaleDir = Path.Combine(Path.GetDirectoryName(dir), "female");
                    if (Directory.Exists(femaleDir))
                    {
                        foreach (string suf in suffixes)
                        {
                            string filePath = Path.Combine(femaleDir, prefix + suf + ".png");
                            if (File.Exists(filePath))
                                File.Delete(filePath);
                            string backupPath = filePath + ".backup";
                            if (File.Exists(backupPath))
                                File.Delete(backupPath);
                        }
                    }
                }
            }
            catch { }
        }

        // Vanilla Owlcat's native custom-companion-portrait feature stores its folders directly
        // in Portraits\ under this prefix. Distinct from the CustomNpcPortraits mod's own
        // companion-override folders (ModCompanionPortraitPrefix), which the mod itself creates
        // via GetCompanionPortraitDirPrefix() = "CustomNpcPortraits - ".
        private const string VanillaCompanionPortraitPrefix = "CompanionCustomPortrait - ";
        private const string ModCompanionPortraitPrefix = "CustomNpcPortraits - ";

        // Kingmaker has a native (vanilla, non-mod) companion-custom-portrait feature using its
        // own prefix. WotR has no such vanilla feature - its companions are only available
        // through the CustomNpcPortraits mod's own prefix, sitting directly in Portraits\.
        private string GetCompanionPrefixForCurrentGame()
        {
            return _gameSelected == 'w' ? ModCompanionPortraitPrefix : VanillaCompanionPortraitPrefix;
        }

        // WotR's CustomNpcPortraits mod does not place a replacement image at a companion
        // folder's root until the player actually customizes that companion - until then, the
        // only image available is the untouched default the mod backed up on first run, at
        // "<folder>\Backup of Game Default Portraits\*.png". Fall back to that so an
        // uncustomized WotR companion still shows/loads something instead of being skipped.
        private static string[] GetPngFilesWithBackupFallback(string folderPath)
        {
            string[] files;
            try { files = Directory.GetFiles(folderPath, "*.png"); }
            catch { files = new string[0]; }
            if (files.Length > 0) return files;

            string backupDir = Path.Combine(folderPath, "Backup of Game Default Portraits");
            try { return Directory.Exists(backupDir) ? Directory.GetFiles(backupDir, "*.png") : new string[0]; }
            catch { return new string[0]; }
        }

        private static string DisplayNameForGalleryFolder(string folderName)
        {
            if (folderName.StartsWith(VanillaCompanionPortraitPrefix, StringComparison.OrdinalIgnoreCase))
                return folderName.Substring(VanillaCompanionPortraitPrefix.Length);
            if (folderName.StartsWith(ModCompanionPortraitPrefix, StringComparison.OrdinalIgnoreCase))
                return folderName.Substring(ModCompanionPortraitPrefix.Length);
            return folderName;
        }

        private void LoadGalleryImages()
        {
            ClearGalleryEntries();
            _galleryEntries = new List<Tuple<string, Image>>();
            FlowLayoutPanelGallery.Visible = true;

            string gamePath = CoreSettings.Default.GamePath;
            if (string.IsNullOrEmpty(gamePath) || !Directory.Exists(gamePath))
                return;

            if (_galleryTabSelected == "nonplayer" && (_gameSelected == 't' || _gameSelected == 'p' || _gameSelected == 'd'))
            {
                LoadNonPlayerGalleryImages(gamePath);
                return;
            }

            if (_galleryTabSelected == "customnpc")
            {
                string npcRoot = GetCustomNpcPortraitsDir(gamePath);
                if (string.IsNullOrEmpty(npcRoot) || !Directory.Exists(npcRoot)) return;
                _cancellationTokenSource?.Cancel();
                _cancellationTokenSource = new CancellationTokenSource();
                var npcToken = _cancellationTokenSource.Token;
                string capturedNpcRoot = npcRoot;
                Task.Run(() =>
                {
                    LoadSubfolderGalleryGradual(capturedNpcRoot, _gameSelected, npcToken);
                    BeginInvoke(new Action(() =>
                    {
                        if (_galleryEntries.Count > 0)
                            ShowScrollBar(FlowLayoutPanelGallery.Handle, 3, false);
                        UpdateGalleryRightPanel();
                    }));
                }, npcToken);
                return;
            }

            if (_galleryTabSelected == "characters")
            {
                var charactersRoots = GetCharactersPortraitsRoots(gamePath)
                    .Where(Directory.Exists)
                    .ToList();
                if (charactersRoots.Count == 0) return;
                _cancellationTokenSource?.Cancel();
                _cancellationTokenSource = new CancellationTokenSource();
                var charToken = _cancellationTokenSource.Token;
                Task.Run(() =>
                {
                    foreach (string root in charactersRoots)
                    {
                        if (charToken.IsCancellationRequested) return;
                        LoadCharactersGalleryRecursive(root, charToken);
                    }
                    BeginInvoke(new Action(() =>
                    {
                        if (_galleryEntries.Count > 0)
                            ShowScrollBar(FlowLayoutPanelGallery.Handle, 3, false);
                        UpdateGalleryRightPanel();
                    }));
                }, charToken);
                return;
            }

            string portraitsDir;
            bool flatFile = false;
            Func<string, bool> subfolderFilter = null;

            if (_gameSelected == 'k' || _gameSelected == 'w' || _gameSelected == 'r')
            {
                portraitsDir = Path.Combine(gamePath, "Portraits");

                if (_galleryTabSelected == "companions")
                {
                    string prefix = GetCompanionPrefixForCurrentGame();
                    subfolderFilter = name => name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase);
                }
                else
                    subfolderFilter = name => !name.StartsWith(VanillaCompanionPortraitPrefix, StringComparison.OrdinalIgnoreCase) &&
                                               !name.StartsWith(ModCompanionPortraitPrefix, StringComparison.OrdinalIgnoreCase);
            }
            else if (_gameSelected == 'p')
            {
                portraitsDir = Path.Combine(gamePath, "PillarsOfEternity_Data", "data", "art", "gui", "portraits", "player", "male");
                flatFile = true;
            }
            else if (_gameSelected == 'd')
            {
                portraitsDir = Path.Combine(gamePath, "PillarsOfEternityII_Data", "gui", "portraits", "player", "male");
                flatFile = true;
            }
            else if (_gameSelected == 't')
            {
                portraitsDir = Path.Combine(gamePath, "Data", "data", "art", "gui", "portraits", "player", "male");
                flatFile = true;
            }
            else if (_gameSelected == 'l')
            {
                portraitsDir = Path.Combine(gamePath, "Custom Portraits");
                flatFile = true;
            }
            else
            {
                return;
            }

            if (!Directory.Exists(portraitsDir))
                return;

            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();
            var token = _cancellationTokenSource.Token;

            string capturedPortraitsDir = portraitsDir;
            bool capturedFlatFile = flatFile;
            char capturedGame = _gameSelected;
            Func<string, bool> capturedFilter = subfolderFilter;

            Task.Run(() =>
            {
                if (capturedFlatFile)
                    LoadFlatGalleryGradual(capturedPortraitsDir, capturedGame, token);
                else
                    LoadSubfolderGalleryGradual(capturedPortraitsDir, capturedGame, token, capturedFilter);

                BeginInvoke(new Action(() =>
                {
                    if (_galleryEntries.Count > 0)
                        ShowScrollBar(FlowLayoutPanelGallery.Handle, 3, false);
                    UpdateGalleryRightPanel();
                }));
            }, token);
        }

        private void LoadNonPlayerGalleryImages(string gamePath)
        {
            string portraitsRoot = GetNonPlayerPortraitsRoot(gamePath);
            if (portraitsRoot == null) return;
            // Verified against real installs: Tyranny's ".../portraits/" only has "companion/"
            // (singular, no separate npc sibling). PoE and Deadfire both have "companion/"
            // (singular) and "npcs/" (plural) - neither matches the original "npc"/"companions"
            // guess (Deadfire also has an "animal_companion/" sibling, not portrait-relevant).
            string[] subDirs;
            if (_gameSelected == 't') subDirs = new[] { "companion" };
            else if (_gameSelected == 'p' || _gameSelected == 'd') subDirs = new[] { "companion", "npcs" };
            else subDirs = new[] { "npc", "companions" };

            var allFiles = new List<string>();
            foreach (string sub in subDirs)
            {
                string dir = Path.Combine(portraitsRoot, sub);
                if (!Directory.Exists(dir)) continue;
                try
                {
                    allFiles.AddRange(Directory.GetFiles(dir, "*.png", SearchOption.AllDirectories));
                }
                catch { }
            }

            if (allFiles.Count == 0) return;

            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();
            var token = _cancellationTokenSource.Token;

            string[] sizePriority = { "_convo", "_sm", "_si", "_med", "_lg" };

            var groupBest = new Dictionary<string, string>();
            foreach (string file in allFiles)
            {
                if (token.IsCancellationRequested) return;
                string name = Path.GetFileNameWithoutExtension(file);
                string prefix = name;
                foreach (string suf in sizePriority)
                {
                    if (name.EndsWith(suf, StringComparison.OrdinalIgnoreCase))
                    {
                        prefix = name.Substring(0, name.Length - suf.Length);
                        break;
                    }
                }

                string key = prefix + "|" + Path.GetDirectoryName(file);
                if (!groupBest.ContainsKey(key))
                {
                    groupBest[key] = file;
                }
                else
                {
                    string existingName = Path.GetFileNameWithoutExtension(groupBest[key]);
                    int existingPrio = -1, newPrio = -1;
                    for (int i = 0; i < sizePriority.Length; i++)
                    {
                        if (existingName.EndsWith(sizePriority[i], StringComparison.OrdinalIgnoreCase)) existingPrio = i;
                        if (name.EndsWith(sizePriority[i], StringComparison.OrdinalIgnoreCase)) newPrio = i;
                    }
                    if (newPrio > existingPrio)
                        groupBest[key] = file;
                }
            }

            Task.Run(() =>
            {
                foreach (var kvp in groupBest)
                {
                    if (token.IsCancellationRequested) return;
                    try
                    {
                        using (Image img = Image.FromFile(kvp.Value))
                        {
                            if (token.IsCancellationRequested) return;
                            Bitmap memImage = new Bitmap(img);
                            string dir = Path.GetDirectoryName(kvp.Value);
                            string prefix = Path.GetFileNameWithoutExtension(kvp.Value);
                            foreach (string suf in sizePriority)
                            {
                                if (prefix.EndsWith(suf, StringComparison.OrdinalIgnoreCase))
                                {
                                    prefix = prefix.Substring(0, prefix.Length - suf.Length);
                                    break;
                                }
                            }
                            string capturedKey = Path.Combine(dir, prefix);
                            BeginInvoke(new Action(() =>
                            {
                                if (token.IsCancellationRequested)
                                {
                                    memImage.Dispose();
                                    return;
                                }
                                AddGalleryThumbnail(capturedKey, memImage);
                                memImage.Dispose();
                            }));
                        }
                    }
                    catch { }
                }

                BeginInvoke(new Action(() =>
                {
                    if (_galleryEntries.Count > 0)
                        ShowScrollBar(FlowLayoutPanelGallery.Handle, 3, false);
                }));
            }, token);
        }

        private void LoadSubfolderGalleryGradual(string portraitsDir, char gameSelected, CancellationToken token, Func<string, bool> subfolderFilter = null)
        {
            string[] subDirs;
            try { subDirs = Directory.GetDirectories(portraitsDir); }
            catch { return; }

            foreach (string subDir in subDirs)
            {
                if (token.IsCancellationRequested) return;
                if (!Directory.Exists(subDir)) continue;
                if (subfolderFilter != null && !subfolderFilter(Path.GetFileName(subDir))) continue;
                string[] files = GetPngFilesWithBackupFallback(subDir);
                if (files.Length == 0) continue;

                string bestFile = null;
                if (files.Any(f => Path.GetFileName(f).Equals("Fulllength.png", StringComparison.OrdinalIgnoreCase)))
                    bestFile = files.First(f => Path.GetFileName(f).Equals("Fulllength.png", StringComparison.OrdinalIgnoreCase));
                else if (files.Any(f => Path.GetFileName(f).Equals("Medium.png", StringComparison.OrdinalIgnoreCase)))
                    bestFile = files.First(f => Path.GetFileName(f).Equals("Medium.png", StringComparison.OrdinalIgnoreCase));
                else if (files.Any(f => Path.GetFileName(f).Equals("Small.png", StringComparison.OrdinalIgnoreCase)))
                    bestFile = files.First(f => Path.GetFileName(f).Equals("Small.png", StringComparison.OrdinalIgnoreCase));
                else
                    bestFile = files[0];

                try
                {
                    using (Image img = Image.FromFile(bestFile))
                    {
                        if (token.IsCancellationRequested) return;
                        Bitmap memImage = new Bitmap(img);
                        string capturedKey = subDir;
                        BeginInvoke(new Action(() =>
                        {
                            if (token.IsCancellationRequested)
                            {
                                memImage.Dispose();
                                return;
                            }
                            AddGalleryThumbnail(capturedKey, memImage);
                            memImage.Dispose();
                        }));
                    }
                }
                catch { }
            }
        }

        // "Portraits - All Additions" can hold, per character, either the portrait files directly
        // or one or more nested subfolders representing area/plot-specific portrait versions.
        // Recurse into any folder that has no images of its own so those versions still surface.
        private void LoadCharactersGalleryRecursive(string dir, CancellationToken token, int depth = 0)
        {
            if (token.IsCancellationRequested || depth > 10) return;

            string[] files;
            try { files = Directory.GetFiles(dir, "*.png"); }
            catch { return; }

            if (files.Length > 0)
            {
                string bestFile = files.FirstOrDefault(f => Path.GetFileName(f).Equals("Fulllength.png", StringComparison.OrdinalIgnoreCase))
                    ?? files.FirstOrDefault(f => Path.GetFileName(f).Equals("Medium.png", StringComparison.OrdinalIgnoreCase))
                    ?? files.FirstOrDefault(f => Path.GetFileName(f).Equals("Small.png", StringComparison.OrdinalIgnoreCase))
                    ?? files[0];

                // Direct child of the root ("Portraits - All Additions\Name") -> plain name.
                // Anything deeper is an area/plot-specific version -> "Name (Version)".
                string displayName = depth <= 1
                    ? Path.GetFileName(dir)
                    : Path.GetFileName(Path.GetDirectoryName(dir)) + " (" + Path.GetFileName(dir) + ")";

                try
                {
                    using (Image img = Image.FromFile(bestFile))
                    {
                        if (token.IsCancellationRequested) return;
                        Bitmap memImage = new Bitmap(img);
                        string capturedKey = dir;
                        string capturedDisplayName = displayName;
                        BeginInvoke(new Action(() =>
                        {
                            if (token.IsCancellationRequested)
                            {
                                memImage.Dispose();
                                return;
                            }
                            AddGalleryThumbnail(capturedKey, memImage, capturedDisplayName);
                            memImage.Dispose();
                        }));
                    }
                }
                catch { }
                return;
            }

            string[] subDirs;
            try { subDirs = Directory.GetDirectories(dir); }
            catch { return; }

            var realSubDirs = new List<string>();
            foreach (string subDir in subDirs)
            {
                string subDirName = Path.GetFileName(subDir);
                // The mod's own backup-of-original-portrait folder - not a real character/version,
                // must not be recursed into or it would surface as a fake "version" entry.
                if (subDirName.Equals("Backup of Game Default Portraits", StringComparison.OrdinalIgnoreCase) ||
                    subDirName.Equals("Game Default Portraits", StringComparison.OrdinalIgnoreCase))
                    continue;
                realSubDirs.Add(subDir);
            }

            if (realSubDirs.Count > 0)
            {
                foreach (string subDir in realSubDirs)
                {
                    if (token.IsCancellationRequested) return;
                    LoadCharactersGalleryRecursive(subDir, token, depth + 1);
                }
                return;
            }

            // No images directly and no real version subfolders to recurse into - same rule as
            // WotR companions: this character has never been customized, so the only image
            // available is the one the mod backed up on first run. Show that instead of nothing.
            string[] backupFiles = GetPngFilesWithBackupFallback(dir);
            if (backupFiles.Length == 0) return;

            string bestBackupFile = backupFiles.FirstOrDefault(f => Path.GetFileName(f).Equals("Fulllength.png", StringComparison.OrdinalIgnoreCase))
                ?? backupFiles.FirstOrDefault(f => Path.GetFileName(f).Equals("Medium.png", StringComparison.OrdinalIgnoreCase))
                ?? backupFiles.FirstOrDefault(f => Path.GetFileName(f).Equals("Small.png", StringComparison.OrdinalIgnoreCase))
                ?? backupFiles[0];

            string fallbackDisplayName = depth <= 1
                ? Path.GetFileName(dir)
                : Path.GetFileName(Path.GetDirectoryName(dir)) + " (" + Path.GetFileName(dir) + ")";

            try
            {
                using (Image img = Image.FromFile(bestBackupFile))
                {
                    if (token.IsCancellationRequested) return;
                    Bitmap memImage = new Bitmap(img);
                    string capturedKey = dir;
                    string capturedDisplayName = fallbackDisplayName;
                    BeginInvoke(new Action(() =>
                    {
                        if (token.IsCancellationRequested)
                        {
                            memImage.Dispose();
                            return;
                        }
                        AddGalleryThumbnail(capturedKey, memImage, capturedDisplayName);
                        memImage.Dispose();
                    }));
                }
            }
            catch { }
        }

        private void LoadFlatGalleryGradual(string portraitsDir, char gameSelected, CancellationToken token)
        {
            string[] files;
            try { files = Directory.GetFiles(portraitsDir, "*.png"); }
            catch { return; }

            var groupBest = new Dictionary<string, string>();
            string[] sizePriority = { "_convo", "_sm", "_si", "_med", "_lg" };

            foreach (string file in files)
            {
                if (token.IsCancellationRequested) return;
                string name = Path.GetFileNameWithoutExtension(file);
                string prefix = name;

                foreach (string suf in sizePriority)
                {
                    if (name.EndsWith(suf, StringComparison.OrdinalIgnoreCase))
                    {
                        prefix = name.Substring(0, name.Length - suf.Length);
                        break;
                    }
                }

                if (!groupBest.ContainsKey(prefix))
                {
                    groupBest[prefix] = file;
                }
                else
                {
                    string existingName = Path.GetFileNameWithoutExtension(groupBest[prefix]);
                    int existingPrio = -1, newPrio = -1;
                    for (int i = 0; i < sizePriority.Length; i++)
                    {
                        if (existingName.EndsWith(sizePriority[i], StringComparison.OrdinalIgnoreCase)) existingPrio = i;
                        if (name.EndsWith(sizePriority[i], StringComparison.OrdinalIgnoreCase)) newPrio = i;
                    }
                    if (newPrio > existingPrio)
                        groupBest[prefix] = file;
                }
            }

            foreach (var kvp in groupBest)
            {
                if (token.IsCancellationRequested) return;
                try
                {
                    using (Image img = Image.FromFile(kvp.Value))
                    {
                        if (token.IsCancellationRequested) return;
                        Bitmap memImage = new Bitmap(img);
                        string capturedKey = Path.Combine(portraitsDir, kvp.Key);
                        BeginInvoke(new Action(() =>
                        {
                            if (token.IsCancellationRequested)
                            {
                                memImage.Dispose();
                                return;
                            }
                            AddGalleryThumbnail(capturedKey, memImage);
                            memImage.Dispose();
                        }));
                    }
                }
                catch { }
            }
        }

        private void LoadArchiveThumbnails(string archivePath)
        {
            _selectedArchivePath = archivePath;
            ClearArchiveEntries();
            _archiveEntries = new List<Tuple<string, Image>>();

            FlowLayoutPanelExtract.Visible = false;
            PanelExtractOverlay.Visible = true;

            CleanupShellTempDir();

            Task.Run(() =>
            {
                try
                {
                    string ext = Path.GetExtension(archivePath).ToLowerInvariant();

                    if (ext == ".zip")
                    {
                        if (_gameSelected == 't')
                        {
                            using (ZipArchive archive = ZipFile.OpenRead(archivePath))
                            {
                                var lgEntries = archive.Entries
                                    .Where(e => e.Name.EndsWith("_lg.png", StringComparison.OrdinalIgnoreCase))
                                    .ToList();

                                foreach (var entry in lgEntries)
                                {
                                    try
                                    {
                                        string baseName = Path.GetFileNameWithoutExtension(entry.Name);
                                        string key = baseName.EndsWith("_lg", StringComparison.OrdinalIgnoreCase)
                                            ? baseName.Substring(0, baseName.Length - 3)
                                            : baseName;
                                        byte[] data = ReadEntryBytes(entry);
                                        Image img = LoadImageFromBytes(data);
                                        if (IsValidPortraitSize(img.Size))
                                        {
                                            BeginInvoke(new Action(() =>
                                            {
                                                AddArchiveThumbnail(key, img);
                                                img.Dispose();
                                            }));
                                        }
                                        else
                                        {
                                            img.Dispose();
                                        }
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (_gameSelected == 'l')
                        {
                            using (ZipArchive archive = ZipFile.OpenRead(archivePath))
                            {
                                var imgEntries = archive.Entries
                                    .Where(e => !e.FullName.EndsWith("/") && IsImageFile(e.Name))
                                    .ToList();

                                foreach (var entry in imgEntries)
                                {
                                    try
                                    {
                                        string key = Path.GetFileNameWithoutExtension(entry.Name);
                                        byte[] data = ReadEntryBytes(entry);
                                        Image img = LoadImageFromBytes(data);
                                        if (IsValidPortraitSize(img.Size))
                                        {
                                            BeginInvoke(new Action(() =>
                                            {
                                                AddArchiveThumbnail(key, img);
                                                img.Dispose();
                                            }));
                                        }
                                        else
                                        {
                                            img.Dispose();
                                        }
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (_gameSelected == 'p' || _gameSelected == 'd')
                        {
                            using (ZipArchive archive = ZipFile.OpenRead(archivePath))
                            {
                                var allEntries = archive.Entries.ToList();
                                var lgEntries = allEntries
                                    .Where(e => e.Name.EndsWith("_lg.png", StringComparison.OrdinalIgnoreCase))
                                    .ToList();

                                foreach (var entry in lgEntries)
                                {
                                    try
                                    {
                                        string baseName = Path.GetFileNameWithoutExtension(entry.Name);
                                        string key = baseName.EndsWith("_lg", StringComparison.OrdinalIgnoreCase)
                                            ? baseName.Substring(0, baseName.Length - 3)
                                            : baseName;
                                        bool hasAllCompanions;
                                        if (_gameSelected == 'd')
                                            hasAllCompanions = allEntries.Any(e => e.Name.Equals(key + "_sm.png", StringComparison.OrdinalIgnoreCase)) &&
                                                               allEntries.Any(e => e.Name.Equals(key + "_si.png", StringComparison.OrdinalIgnoreCase)) &&
                                                               allEntries.Any(e => e.Name.Equals(key + "_convo.png", StringComparison.OrdinalIgnoreCase));
                                        else
                                            hasAllCompanions = allEntries.Any(e => e.Name.Equals(key + "_sm.png", StringComparison.OrdinalIgnoreCase));

                                        byte[] data = ReadEntryBytes(entry);
                                        Image img = LoadImageFromBytes(data);
                                        if (IsValidPortraitSize(img.Size))
                                        {
                                            BeginInvoke(new Action(() =>
                                            {
                                                AddArchiveThumbnail(key, img, hasAllCompanions);
                                                img.Dispose();
                                            }));
                                        }
                                        else
                                        {
                                            img.Dispose();
                                        }
                                    }
                                    catch { }
                                }
                            }
                        }
                        else
                        {
                            using (ZipArchive archive = ZipFile.OpenRead(archivePath))
                            {
                                var imageEntries = archive.Entries
                                    .Where(e => !e.FullName.EndsWith("/"))
                                    .GroupBy(e => Path.GetDirectoryName(e.FullName).Replace("\\", "/"))
                                    .ToList();

                                foreach (var group in imageEntries)
                                {
                                    var imgFiles = group.Where(e => IsImageFile(e.Name)).ToList();
                                    if (imgFiles.Count == 0) continue;

                                    var fileNames = imgFiles
                                        .Select(e => Path.GetFileName(e.Name))
                                        .ToHashSet(StringComparer.OrdinalIgnoreCase);
                                    if (!fileNames.Contains("Fulllength.png") ||
                                        !fileNames.Contains("Medium.png") ||
                                        !fileNames.Contains("Small.png"))
                                        continue;

                                    var firstImg = imgFiles.FirstOrDefault(f =>
                                        Path.GetFileName(f.Name).Equals("Fulllength.png", StringComparison.OrdinalIgnoreCase))
                                        ?? imgFiles.First();
                                    try
                                    {
                                        byte[] data = ReadEntryBytes(firstImg);
                                        Image img = LoadImageFromBytes(data);
                                        if (IsValidPortraitSize(img.Size))
                                        {
                                            string key = string.IsNullOrEmpty(group.Key)
                                                ? Path.GetFileNameWithoutExtension(archivePath) + "_flat"
                                                : group.Key;
                                            BeginInvoke(new Action(() =>
                                            {
                                                AddArchiveThumbnail(key, img);
                                                img.Dispose();
                                            }));
                                        }
                                        else
                                        {
                                            img.Dispose();
                                        }
                                    }
                                    catch { }
                                }
                            }
                        }

                        BeginInvoke(new Action(CompleteExtractLoad));
                    }
                    else if (ext == ".7z" || ext == ".rar")
                    {
                        string tempDir = Path.Combine(Path.GetTempPath(), "PortraitManager_Extract_" + Guid.NewGuid().ToString("N"));
                        Directory.CreateDirectory(tempDir);
                        ExtractArchive(archivePath, tempDir);
                        BeginInvoke(new Action(() =>
                        {
                            _shellTempDir = tempDir;
                            LoadFolderThumbnails(tempDir);
                            CompleteExtractLoad();
                        }));
                    }
                    else
                    {
                        BeginInvoke(new Action(() =>
                        {
                            LoadFolderThumbnails(archivePath);
                            CompleteExtractLoad();
                        }));
                    }
                }
                catch (Exception ex)
                {
                    BeginInvoke(new Action(() =>
                    {
                        using (var msg = new MyMessageDialog("Failed to load archive: " + ex.Message))
                        {
                            msg.StartPosition = FormStartPosition.CenterParent;
                            msg.ShowDialog(this);
                        }
                    }));
                }
            });
        }

        private void CompleteExtractLoad()
        {
            UpdateExtractCounter();

            if (_archiveEntries.Count > 0)
            {
                PanelExtractOverlay.Visible = false;
                FlowLayoutPanelExtract.Visible = true;
                FlowLayoutPanelExtractBottom.Visible = true;
                ButtonExtractAll.Visible = true;
                ButtonExtractSelected.Visible = true;
                ButtonExtractShowFolder.Visible = true;
                ButtonExtractShowFolder.Text = TextVariables.BUTTON_EXTRACT_OPENFOLDERS;
                LayoutExtractRight.RowStyles[0].Height = 28.57F;
                LayoutExtractRight.RowStyles[1].Height = 28.57F;
                LayoutExtractRight.RowStyles[2].Height = 28.57F;
                LayoutExtractRight.RowStyles[3].Height = 14.29F;
                ShowScrollBar(FlowLayoutPanelExtract.Handle, 3, false);
            }
            else
            {
                using (var msg = new MyMessageDialog("No portraits matching the expected dimensions for the selected game were found in the archive.\nMake sure you have the correct game selected."))
                {
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog(this);
                }
            }
        }

        // SharpCompress's managed .7z decoder is noticeably slower and, on some archives,
        // unreliable (non-deterministic load time, occasional crashes). A real 7-Zip install
        // (native, battle-tested) is both faster and more robust, so prefer it when present and
        // only fall back to the managed decoder if 7-Zip isn't installed. .rar keeps using
        // SharpCompress unconditionally since it's fine there.
        private static bool TryExtractWithNative7Zip(string archivePath, string destDir)
        {
            string exe = SystemControl.FileControl.FindNative7ZipExecutable();
            if (exe == null) return false;

            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = exe,
                    Arguments = "x \"" + archivePath + "\" -o\"" + destDir + "\" -y -bd -bso0 -bse0",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                };

                using (var proc = Process.Start(psi))
                {
                    bool exited = proc.WaitForExit(120000);
                    if (!exited)
                    {
                        try { proc.Kill(); } catch { }
                        return false;
                    }
                    return proc.ExitCode == 0;
                }
            }
            catch
            {
                return false;
            }
        }

        private void ExtractArchive(string archivePath, string destDir)
        {
            string ext = Path.GetExtension(archivePath).ToLowerInvariant();
            if (ext == ".7z" && TryExtractWithNative7Zip(archivePath, destDir))
                return;

            using (var archive = ArchiveFactory.Open(archivePath))
            {
                foreach (var entry in archive.Entries.Where(e => !e.IsDirectory))
                    entry.WriteToDirectory(destDir, new ExtractionOptions
                    {
                        ExtractFullPath = true,
                        Overwrite = true
                    });
            }
        }

        private void LoadFolderThumbnails(string folderPath, int depth = 0)
        {
            if (depth > 50) return;

            if (_gameSelected == 't')
            {
                foreach (var file in Directory.GetFiles(folderPath, "*_lg.png"))
                {
                    try
                    {
                        string baseName = Path.GetFileNameWithoutExtension(file);
                        string key = baseName.EndsWith("_lg", StringComparison.OrdinalIgnoreCase)
                            ? baseName.Substring(0, baseName.Length - 3)
                            : baseName;
                        Image img = Image.FromFile(file);
                        if (IsValidPortraitSize(img.Size))
                        {
                            AddArchiveThumbnail(key, img);
                        }
                        img.Dispose();
                    }
                    catch { }
                }

                foreach (var subDir in Directory.GetDirectories(folderPath))
                    LoadFolderThumbnails(subDir, depth + 1);
            }
            else if (_gameSelected == 'l')
            {
                foreach (var file in Directory.GetFiles(folderPath).Where(f => IsImageFile(f)))
                {
                    try
                    {
                        string key = Path.GetFileNameWithoutExtension(file);
                        Image img = Image.FromFile(file);
                        if (IsValidPortraitSize(img.Size))
                        {
                            AddArchiveThumbnail(key, img);
                        }
                        img.Dispose();
                    }
                    catch { }
                }

                foreach (var subDir in Directory.GetDirectories(folderPath))
                    LoadFolderThumbnails(subDir, depth + 1);
            }
            else if (_gameSelected == 'p' || _gameSelected == 'd')
            {
                foreach (var file in Directory.GetFiles(folderPath, "*_lg.png"))
                {
                    try
                    {
                        string baseName = Path.GetFileNameWithoutExtension(file);
                        string key = baseName.EndsWith("_lg", StringComparison.OrdinalIgnoreCase)
                            ? baseName.Substring(0, baseName.Length - 3)
                            : baseName;
                        string dir = Path.GetDirectoryName(file);
                        bool hasAllCompanions;
                        if (_gameSelected == 'd')
                            hasAllCompanions = File.Exists(Path.Combine(dir, key + "_sm.png")) &&
                                               File.Exists(Path.Combine(dir, key + "_si.png")) &&
                                               File.Exists(Path.Combine(dir, key + "_convo.png"));
                        else
                            hasAllCompanions = File.Exists(Path.Combine(dir, key + "_sm.png"));

                        Image img = Image.FromFile(file);
                        if (IsValidPortraitSize(img.Size))
                        {
                            AddArchiveThumbnail(key, img, hasAllCompanions);
                        }
                        img.Dispose();
                    }
                    catch { }
                }

                foreach (var subDir in Directory.GetDirectories(folderPath))
                    LoadFolderThumbnails(subDir, depth + 1);
            }
            else
            {
                bool HasRequiredFiles(string dir)
                {
                    var names = Directory.GetFiles(dir)
                        .Select(Path.GetFileName)
                        .ToHashSet(StringComparer.OrdinalIgnoreCase);
                    return names.Contains("Fulllength.png") &&
                           names.Contains("Medium.png") &&
                           names.Contains("Small.png");
                }

                void TryAddPack(string dir)
                {
                    var imgFiles = Directory.GetFiles(dir).Where(f => IsImageFile(f)).ToList();
                    if (imgFiles.Count == 0) return;
                    string bestFile = imgFiles.FirstOrDefault(f =>
                        Path.GetFileName(f).Equals("Fulllength.png", StringComparison.OrdinalIgnoreCase))
                        ?? imgFiles[0];
                    try
                    {
                        Image img = Image.FromFile(bestFile);
                        if (IsValidPortraitSize(img.Size))
                            AddArchiveThumbnail(dir, img);
                        img.Dispose();
                    }
                    catch { }
                }

                if (HasRequiredFiles(folderPath))
                    TryAddPack(folderPath);

                foreach (var subDir in Directory.GetDirectories(folderPath))
                {
                    if (HasRequiredFiles(subDir))
                    {
                        TryAddPack(subDir);
                    }
                    else
                    {
                        LoadFolderThumbnails(subDir, depth + 1);
                    }
                }
            }
        }

        private void CleanupShellTempDir()
        {
            if (!string.IsNullOrEmpty(_shellTempDir))
            {
                try { Directory.Delete(_shellTempDir, true); } catch { }
                _shellTempDir = null;
            }
        }

        private string GetUniqueFolderPath(string baseDir, string folderName, out bool conflicted)
        {
            string path = Path.Combine(baseDir, folderName);
            if (!Directory.Exists(path))
            {
                conflicted = false;
                return path;
            }
            conflicted = true;
            string timestamp = DateTime.Now.ToString("\\_ssddMM");
            path = Path.Combine(baseDir, folderName + timestamp);
            int counter = 1;
            while (Directory.Exists(path))
            {
                path = Path.Combine(baseDir, folderName + timestamp + "_" + counter);
                counter++;
            }
            return path;
        }

        private bool ExtractTyrannyPortraits(List<string> selectedKeys, string gamePath)
        {
            string maleDir = Path.Combine(gamePath, "Data", "data", "art", "gui", "portraits", "player", "male");
            string femaleDir = Path.Combine(gamePath, "Data", "data", "art", "gui", "portraits", "player", "female");
            Directory.CreateDirectory(maleDir);
            Directory.CreateDirectory(femaleDir);

            int count = 0;
            int conflictCount = 0;
            int sizeInvalidCount = 0;
            string ext = Path.GetExtension(_selectedArchivePath).ToLowerInvariant();

            try
            {
                HashSet<string> keys = selectedKeys == null ? null : new HashSet<string>(selectedKeys);

                if (ext == ".zip")
                {
                    using (ZipArchive archive = ZipFile.OpenRead(_selectedArchivePath))
                    {
                        var entries = archive.Entries.Where(e => !e.FullName.EndsWith("/")).ToList();
                        var lgEntries = entries.Where(e => e.Name.EndsWith("_lg.png", StringComparison.OrdinalIgnoreCase)).ToList();

                        foreach (var lgEntry in lgEntries)
                        {
                            string baseName = Path.GetFileNameWithoutExtension(lgEntry.Name);
                            string key = baseName.EndsWith("_lg", StringComparison.OrdinalIgnoreCase)
                                ? baseName.Substring(0, baseName.Length - 3)
                                : baseName;

                            if (keys != null && !keys.Contains(key))
                                continue;

                            string suffix = File.Exists(Path.Combine(maleDir, lgEntry.Name))
                                ? DateTime.Now.ToString("_ssddMM") : "";
                            if (!string.IsNullOrEmpty(suffix)) conflictCount++;
                            string lgName = key + suffix + "_lg.png";
                            string smName = key + suffix + "_sm.png";

                            var smEntry = entries.FirstOrDefault(e =>
                                e.Name.Equals(key + "_sm.png", StringComparison.OrdinalIgnoreCase));

                            string lgDest = Path.Combine(maleDir, lgName);
                            lgEntry.ExtractToFile(lgDest, overwrite: true);
                            bool hadInvalid = false;
                            ValidatePortraitSize(lgDest, ref hadInvalid);

                            string smDest = null;
                            if (smEntry != null)
                            {
                                smDest = Path.Combine(maleDir, smName);
                                smEntry.ExtractToFile(smDest, overwrite: true);
                                ValidatePortraitSize(smDest, ref hadInvalid);
                            }

                            if (hadInvalid)
                            {
                                try { File.Delete(lgDest); } catch { }
                                if (smDest != null) try { File.Delete(smDest); } catch { }
                                sizeInvalidCount++;
                                continue;
                            }

                            File.Copy(lgDest, Path.Combine(femaleDir, lgName), overwrite: true);
                            if (smDest != null)
                                File.Copy(smDest, Path.Combine(femaleDir, smName), overwrite: true);
                            count++;
                        }
                    }
                }
                else if (ext == ".7z" || ext == ".rar")
                {
                    if (string.IsNullOrEmpty(_shellTempDir) || !Directory.Exists(_shellTempDir))
                    {
                        using (var msg = new MyMessageDialog("Archive contents not found. Please reload the archive."))
                        {
                            msg.StartPosition = FormStartPosition.CenterParent;
                            msg.ShowDialog(this);
                        }
                        return false;
                    }

                    var lgFiles = Directory.GetFiles(_shellTempDir, "*_lg.png", SearchOption.AllDirectories);
                    foreach (var lgFile in lgFiles)
                    {
                        string baseName = Path.GetFileNameWithoutExtension(lgFile);
                        string key = baseName.EndsWith("_lg", StringComparison.OrdinalIgnoreCase)
                            ? baseName.Substring(0, baseName.Length - 3)
                            : baseName;

                        if (keys != null && !keys.Contains(key))
                            continue;

                        string suffix = File.Exists(Path.Combine(maleDir, key + "_lg.png"))
                            ? DateTime.Now.ToString("_ssddMM") : "";
                        if (!string.IsNullOrEmpty(suffix)) conflictCount++;
                        string lgName = key + suffix + "_lg.png";
                        string smName = key + suffix + "_sm.png";

                        string dir = Path.GetDirectoryName(lgFile);
                        string smFile = Path.Combine(dir, key + "_sm.png");

                        string lgDest = Path.Combine(maleDir, lgName);
                        File.Copy(lgFile, lgDest, overwrite: true);
                        bool hadInvalid = false;
                        ValidatePortraitSize(lgDest, ref hadInvalid);

                        string smDest = null;
                        if (File.Exists(smFile))
                        {
                            smDest = Path.Combine(maleDir, smName);
                            File.Copy(smFile, smDest, overwrite: true);
                            ValidatePortraitSize(smDest, ref hadInvalid);
                        }

                        if (hadInvalid)
                        {
                            try { File.Delete(lgDest); } catch { }
                            if (smDest != null) try { File.Delete(smDest); } catch { }
                            sizeInvalidCount++;
                            continue;
                        }

                        File.Copy(lgDest, Path.Combine(femaleDir, lgName), overwrite: true);
                        if (smDest != null)
                            File.Copy(smDest, Path.Combine(femaleDir, smName), overwrite: true);
                        count++;
                    }
                }
                else
                {
                    var lgFiles = Directory.GetFiles(_selectedArchivePath, "*_lg.png", SearchOption.AllDirectories);
                    foreach (var lgFile in lgFiles)
                    {
                        string baseName = Path.GetFileNameWithoutExtension(lgFile);
                        string key = baseName.EndsWith("_lg", StringComparison.OrdinalIgnoreCase)
                            ? baseName.Substring(0, baseName.Length - 3)
                            : baseName;

                        if (keys != null && !keys.Contains(key))
                            continue;

                        string suffix = File.Exists(Path.Combine(maleDir, key + "_lg.png"))
                            ? DateTime.Now.ToString("_ssddMM") : "";
                        if (!string.IsNullOrEmpty(suffix)) conflictCount++;
                        string lgName = key + suffix + "_lg.png";
                        string smName = key + suffix + "_sm.png";

                        string dir = Path.GetDirectoryName(lgFile);
                        string smFile = Path.Combine(dir, key + "_sm.png");

                        string lgDest = Path.Combine(maleDir, lgName);
                        File.Copy(lgFile, lgDest, overwrite: true);
                        bool hadInvalid = false;
                        ValidatePortraitSize(lgDest, ref hadInvalid);

                        string smDest = null;
                        if (File.Exists(smFile))
                        {
                            smDest = Path.Combine(maleDir, smName);
                            File.Copy(smFile, smDest, overwrite: true);
                            ValidatePortraitSize(smDest, ref hadInvalid);
                        }

                        if (hadInvalid)
                        {
                            try { File.Delete(lgDest); } catch { }
                            if (smDest != null) try { File.Delete(smDest); } catch { }
                            sizeInvalidCount++;
                            continue;
                        }

                        File.Copy(lgDest, Path.Combine(femaleDir, lgName), overwrite: true);
                        if (smDest != null)
                            File.Copy(smDest, Path.Combine(femaleDir, smName), overwrite: true);
                        count++;
                    }
                }

                string msgText;
                if (conflictCount > 0)
                    msgText = string.Format(TextVariables.MESG_EXTRACT_CONFLICT, count, conflictCount);
                else if (sizeInvalidCount > 0)
                    msgText = string.Format(TextVariables.MESG_EXTRACT_SUCCESS, count) + $"\nSkipped {sizeInvalidCount} set(s) with invalid portrait dimensions.";
                else
                    msgText = string.Format(TextVariables.MESG_EXTRACT_SUCCESS, count);
                using (var msg = new MyMessageDialog(msgText))
                {
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog(this);
                }
                return count > 0;
            }
            catch (Exception ex)
            {
                using (var msg = new MyMessageDialog("Extraction failed: " + ex.Message))
                {
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog(this);
                }
                return false;
            }
        }

        private bool ExtractWastelandPortraits(List<string> selectedKeys, string gamePath)
        {
            string outDir = Path.Combine(gamePath, "Custom Portraits");
            Directory.CreateDirectory(outDir);

            int count = 0;
            int conflictCount = 0;
            int sizeInvalidCount = 0;
            string ext = Path.GetExtension(_selectedArchivePath).ToLowerInvariant();

            try
            {
                HashSet<string> keys = selectedKeys == null ? null : new HashSet<string>(selectedKeys);

                if (ext == ".zip")
                {
                    using (ZipArchive archive = ZipFile.OpenRead(_selectedArchivePath))
                    {
                        var imgEntries = archive.Entries
                            .Where(e => !e.FullName.EndsWith("/") && e.Name.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                            .ToList();

                        foreach (var entry in imgEntries)
                        {
                            string key = Path.GetFileNameWithoutExtension(entry.Name);

                            if (keys != null && !keys.Contains(key))
                                continue;

                            string destFile = Path.Combine(outDir, entry.Name);
                            string suffix = File.Exists(destFile)
                                ? DateTime.Now.ToString("_ssddMM") : "";
                            if (!string.IsNullOrEmpty(suffix)) conflictCount++;

                            string finalName = key + suffix + ".png";
                            string finalPath = Path.Combine(outDir, finalName);
                            entry.ExtractToFile(finalPath, overwrite: true);
                            bool hadInvalid = false;
                            ValidatePortraitSize(finalPath, ref hadInvalid);
                            if (hadInvalid)
                            {
                                sizeInvalidCount++;
                                continue;
                            }
                            count++;
                        }
                    }
                }
                else if (ext == ".7z" || ext == ".rar")
                {
                    if (string.IsNullOrEmpty(_shellTempDir) || !Directory.Exists(_shellTempDir))
                    {
                        using (var msg = new MyMessageDialog("Archive contents not found. Please reload the archive."))
                        {
                            msg.StartPosition = FormStartPosition.CenterParent;
                            msg.ShowDialog(this);
                        }
                        return false;
                    }

                    var imgFiles = Directory.GetFiles(_shellTempDir, "*", SearchOption.AllDirectories)
                        .Where(f => f.EndsWith(".png", StringComparison.OrdinalIgnoreCase)).ToList();
                    foreach (var file in imgFiles)
                    {
                        string key = Path.GetFileNameWithoutExtension(file);

                        if (keys != null && !keys.Contains(key))
                            continue;

                        string destFile = Path.Combine(outDir, key + ".png");
                        string suffix = File.Exists(destFile)
                            ? DateTime.Now.ToString("_ssddMM") : "";
                        if (!string.IsNullOrEmpty(suffix)) conflictCount++;

                        string finalName = key + suffix + ".png";
                        string finalPath = Path.Combine(outDir, finalName);
                        File.Copy(file, finalPath, overwrite: true);
                        bool hadInvalid = false;
                        ValidatePortraitSize(finalPath, ref hadInvalid);
                        if (hadInvalid)
                        {
                            sizeInvalidCount++;
                            continue;
                        }
                        count++;
                    }
                }
                else
                {
                    var imgFiles = Directory.GetFiles(_selectedArchivePath, "*", SearchOption.AllDirectories)
                        .Where(f => f.EndsWith(".png", StringComparison.OrdinalIgnoreCase)).ToList();
                    foreach (var file in imgFiles)
                    {
                        string key = Path.GetFileNameWithoutExtension(file);

                        if (keys != null && !keys.Contains(key))
                            continue;

                        string destFile = Path.Combine(outDir, key + ".png");
                        string suffix = File.Exists(destFile)
                            ? DateTime.Now.ToString("_ssddMM") : "";
                        if (!string.IsNullOrEmpty(suffix)) conflictCount++;

                        string finalName = key + suffix + ".png";
                        string finalPath = Path.Combine(outDir, finalName);
                        File.Copy(file, finalPath, overwrite: true);
                        bool hadInvalid = false;
                        ValidatePortraitSize(finalPath, ref hadInvalid);
                        if (hadInvalid)
                        {
                            sizeInvalidCount++;
                            continue;
                        }
                        count++;
                    }
                }

                string msgText;
                if (conflictCount > 0)
                    msgText = string.Format(TextVariables.MESG_EXTRACT_CONFLICT, count, conflictCount);
                else if (sizeInvalidCount > 0)
                    msgText = string.Format(TextVariables.MESG_EXTRACT_SUCCESS, count) + $"\nSkipped {sizeInvalidCount} file(s) with invalid portrait dimensions.";
                else
                    msgText = string.Format(TextVariables.MESG_EXTRACT_SUCCESS, count);
                using (var msg = new MyMessageDialog(msgText))
                {
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog(this);
                }
                return count > 0;
            }
            catch (Exception ex)
            {
                using (var msg = new MyMessageDialog("Extraction failed: " + ex.Message))
                {
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog(this);
                }
                return false;
            }
        }

        private bool ExtractObsidianPortraits(List<string> selectedKeys, string gamePath, string dataSubPath, string[] sizeSuffixes)
        {
            string maleDir = Path.Combine(gamePath, dataSubPath, "male");
            string femaleDir = Path.Combine(gamePath, dataSubPath, "female");
            Directory.CreateDirectory(maleDir);
            Directory.CreateDirectory(femaleDir);

            int count = 0;
            int conflictCount = 0;
            int partialCount = 0;
            int sizeInvalidCount = 0;
            string ext = Path.GetExtension(_selectedArchivePath).ToLowerInvariant();

            try
            {
                HashSet<string> keys = selectedKeys == null ? null : new HashSet<string>(selectedKeys);

                if (ext == ".zip")
                {
                    using (ZipArchive archive = ZipFile.OpenRead(_selectedArchivePath))
                    {
                        var lgEntries = archive.Entries
                            .Where(e => e.Name.EndsWith("_lg.png", StringComparison.OrdinalIgnoreCase)).ToList();

                        foreach (var lgEntry in lgEntries)
                        {
                            string baseName = Path.GetFileNameWithoutExtension(lgEntry.Name);
                            string key = baseName.EndsWith("_lg", StringComparison.OrdinalIgnoreCase)
                                ? baseName.Substring(0, baseName.Length - 3)
                                : baseName;

                            if (keys != null && !keys.Contains(key))
                                continue;

                            string suffix = File.Exists(Path.Combine(maleDir, key + "_lg.png"))
                                ? DateTime.Now.ToString("_ssddMM") : "";
                            if (!string.IsNullOrEmpty(suffix)) conflictCount++;

                            bool wroteAny = false;
                            int foundCount = 0;
                            bool hadInvalid = false;
                            var writtenFiles = new List<string>();
                            foreach (var sz in sizeSuffixes)
                            {
                                var entry = archive.Entries.FirstOrDefault(e =>
                                    e.Name.Equals(key + "_" + sz + ".png", StringComparison.OrdinalIgnoreCase) &&
                                    !e.FullName.EndsWith("/"));
                                if (entry == null) continue;

                                string finalName = key + suffix + "_" + sz + ".png";
                                string malePath = Path.Combine(maleDir, finalName);
                                entry.ExtractToFile(malePath, overwrite: true);
                                ValidatePortraitSize(malePath, ref hadInvalid);
                                writtenFiles.Add(malePath);
                                wroteAny = true;
                                foundCount++;
                            }

                            if (hadInvalid)
                            {
                                foreach (var f in writtenFiles)
                                    try { File.Delete(f); } catch { }
                                sizeInvalidCount++;
                                continue;
                            }

                            foreach (var maleFile in writtenFiles)
                            {
                                string femalePath = Path.Combine(femaleDir, Path.GetFileName(maleFile));
                                File.Copy(maleFile, femalePath, overwrite: true);
                            }

                            if (wroteAny)
                            {
                                count++;
                                if (foundCount < sizeSuffixes.Length) partialCount++;
                            }
                        }
                    }
                }
                else if (ext == ".7z" || ext == ".rar")
                {
                    if (string.IsNullOrEmpty(_shellTempDir) || !Directory.Exists(_shellTempDir))
                    {
                        using (var msg = new MyMessageDialog("Archive contents not found. Please reload the archive."))
                        {
                            msg.StartPosition = FormStartPosition.CenterParent;
                            msg.ShowDialog(this);
                        }
                        return false;
                    }

                    var lgFiles = Directory.GetFiles(_shellTempDir, "*_lg.png", SearchOption.AllDirectories);
                    foreach (var lgFile in lgFiles)
                    {
                        string baseName = Path.GetFileNameWithoutExtension(lgFile);
                        string key = baseName.EndsWith("_lg", StringComparison.OrdinalIgnoreCase)
                            ? baseName.Substring(0, baseName.Length - 3)
                            : baseName;

                        if (keys != null && !keys.Contains(key))
                            continue;

                        string suffix = File.Exists(Path.Combine(maleDir, key + "_lg.png"))
                            ? DateTime.Now.ToString("_ssddMM") : "";
                        if (!string.IsNullOrEmpty(suffix)) conflictCount++;

                        string dir = Path.GetDirectoryName(lgFile);
                        bool wroteAny = false;
                        int foundCount = 0;
                        bool hadInvalid = false;
                        var writtenFiles = new List<string>();
                        foreach (var sz in sizeSuffixes)
                        {
                            string srcFile = Path.Combine(dir, key + "_" + sz + ".png");
                            if (!File.Exists(srcFile)) continue;

                            string finalName = key + suffix + "_" + sz + ".png";
                            string malePath = Path.Combine(maleDir, finalName);
                            File.Copy(srcFile, malePath, overwrite: true);
                            ValidatePortraitSize(malePath, ref hadInvalid);
                            writtenFiles.Add(malePath);
                            wroteAny = true;
                            foundCount++;
                        }

                        if (hadInvalid)
                        {
                            foreach (var f in writtenFiles)
                                try { File.Delete(f); } catch { }
                            sizeInvalidCount++;
                            continue;
                        }

                        foreach (var maleFile in writtenFiles)
                        {
                            string femalePath = Path.Combine(femaleDir, Path.GetFileName(maleFile));
                            File.Copy(maleFile, femalePath, overwrite: true);
                        }

                        if (wroteAny)
                        {
                            count++;
                            if (foundCount < sizeSuffixes.Length) partialCount++;
                        }
                    }
                }
                else
                {
                    var lgFiles = Directory.GetFiles(_selectedArchivePath, "*_lg.png", SearchOption.AllDirectories);
                    foreach (var lgFile in lgFiles)
                    {
                        string baseName = Path.GetFileNameWithoutExtension(lgFile);
                        string key = baseName.EndsWith("_lg", StringComparison.OrdinalIgnoreCase)
                            ? baseName.Substring(0, baseName.Length - 3)
                            : baseName;

                        if (keys != null && !keys.Contains(key))
                            continue;

                        string suffix = File.Exists(Path.Combine(maleDir, key + "_lg.png"))
                            ? DateTime.Now.ToString("_ssddMM") : "";
                        if (!string.IsNullOrEmpty(suffix)) conflictCount++;

                        string dir = Path.GetDirectoryName(lgFile);
                        bool wroteAny = false;
                        int foundCount = 0;
                        bool hadInvalid = false;
                        var writtenFiles = new List<string>();
                        foreach (var sz in sizeSuffixes)
                        {
                            string srcFile = Path.Combine(dir, key + "_" + sz + ".png");
                            if (!File.Exists(srcFile)) continue;

                            string finalName = key + suffix + "_" + sz + ".png";
                            string malePath = Path.Combine(maleDir, finalName);
                            File.Copy(srcFile, malePath, overwrite: true);
                            ValidatePortraitSize(malePath, ref hadInvalid);
                            writtenFiles.Add(malePath);
                            wroteAny = true;
                            foundCount++;
                        }

                        if (hadInvalid)
                        {
                            foreach (var f in writtenFiles)
                                try { File.Delete(f); } catch { }
                            sizeInvalidCount++;
                            continue;
                        }

                        foreach (var maleFile in writtenFiles)
                        {
                            string femalePath = Path.Combine(femaleDir, Path.GetFileName(maleFile));
                            File.Copy(maleFile, femalePath, overwrite: true);
                        }

                        if (wroteAny)
                        {
                            count++;
                            if (foundCount < sizeSuffixes.Length) partialCount++;
                        }
                    }
                }

                string msgText;
                if (conflictCount > 0)
                    msgText = string.Format(TextVariables.MESG_EXTRACT_CONFLICT, count, conflictCount);
                else if (sizeInvalidCount > 0)
                    msgText = string.Format(TextVariables.MESG_EXTRACT_SUCCESS, count) + $"\nSkipped {sizeInvalidCount} set(s) with invalid portrait dimensions.";
                else if (partialCount > 0)
                    msgText = string.Format(TextVariables.MESG_EXTRACT_PARTIAL, count, partialCount);
                else
                    msgText = string.Format(TextVariables.MESG_EXTRACT_SUCCESS, count);
                using (var msg = new MyMessageDialog(msgText))
                {
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog(this);
                }
                return count > 0;
            }
            catch (Exception ex)
            {
                using (var msg = new MyMessageDialog("Extraction failed: " + ex.Message))
                {
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog(this);
                }
                return false;
            }
        }

        private bool ExtractPortraitsFromArchive(List<string> selectedKeys)
        {
            if (string.IsNullOrEmpty(_selectedArchivePath) || _archiveEntries == null)
                return false;

            string portraitsDir = CoreSettings.Default.GamePath;
            if (string.IsNullOrEmpty(portraitsDir) || portraitsDir == "0")
            {
                using (var msg = new MyMessageDialog("Game path not set. Please configure the game path first."))
                {
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog(this);
                }
                return false;
            }

            if (_gameSelected == 't')
            {
                bool result = ExtractTyrannyPortraits(selectedKeys, portraitsDir);
                CleanupShellTempDir();
                return result;
            }

            if (_gameSelected == 'l')
            {
                bool result = ExtractWastelandPortraits(selectedKeys, portraitsDir);
                CleanupShellTempDir();
                return result;
            }

            if (_gameSelected == 'p')
            {
                bool result = ExtractObsidianPortraits(selectedKeys, portraitsDir,
                    @"PillarsOfEternity_Data\data\art\gui\portraits\player", new[] { "lg", "sm" });
                CleanupShellTempDir();
                return result;
            }

            if (_gameSelected == 'd')
            {
                bool result = ExtractObsidianPortraits(selectedKeys, portraitsDir,
                    @"PillarsOfEternityII_Data\gui\portraits\player", new[] { "lg", "sm", "si", "convo" });
                CleanupShellTempDir();
                return result;
            }

            string extractDir = Path.Combine(portraitsDir, "Portraits");
            Directory.CreateDirectory(extractDir);

            int count = 0;
            int conflictCount = 0;
            int skippedCount = 0;
            int sizeInvalidCount = 0;
            string ext = Path.GetExtension(_selectedArchivePath).ToLowerInvariant();

            try
            {
                if (ext == ".zip")
                {
                    using (ZipArchive archive = ZipFile.OpenRead(_selectedArchivePath))
                    {
                        var folders = archive.Entries
                            .Where(e => !e.FullName.EndsWith("/"))
                            .GroupBy(e => Path.GetDirectoryName(e.FullName).Replace("\\", "/"))
                            .ToList();

                        foreach (var folder in folders)
                        {
                            string rawKey = string.IsNullOrEmpty(folder.Key)
                                ? Path.GetFileNameWithoutExtension(_selectedArchivePath) + "_flat"
                                : folder.Key;
                            string folderName = Path.GetFileName(rawKey);
                            if (selectedKeys != null && !selectedKeys.Contains(rawKey))
                                continue;

                            string targetFolder = GetUniqueFolderPath(extractDir, folderName, out bool conflicted);
                            Directory.CreateDirectory(targetFolder);
                            if (conflicted) conflictCount++;

                            var fileNames = folder
                                .Select(e => Path.GetFileName(e.Name))
                                .Where(n => !string.IsNullOrEmpty(n))
                                .ToHashSet(StringComparer.OrdinalIgnoreCase);
                            if (!fileNames.Contains("Fulllength.png") ||
                                !fileNames.Contains("Medium.png") ||
                                !fileNames.Contains("Small.png"))
                            {
                                skippedCount++;
                                continue;
                            }

                            bool hadInvalid = false;
                            foreach (var entry in folder.Where(e => !string.IsNullOrEmpty(Path.GetFileName(e.Name)) && IsImageFile(e.Name)))
                            {
                                string fileName = Path.GetFileName(entry.Name);
                                string destPath = Path.Combine(targetFolder, fileName);
                                entry.ExtractToFile(destPath, overwrite: true);
                                ValidatePortraitSize(destPath, ref hadInvalid);
                            }
                            if (hadInvalid)
                            {
                                try { Directory.Delete(targetFolder, true); } catch { }
                                sizeInvalidCount++;
                                continue;
                            }
                            count++;
                        }
                    }
                }
                else if (ext == ".7z" || ext == ".rar")
                {
                    if (string.IsNullOrEmpty(_shellTempDir) || !Directory.Exists(_shellTempDir))
                    {
                        using (var msg = new MyMessageDialog("Archive contents not found. Please reload the archive."))
                        {
                            msg.StartPosition = FormStartPosition.CenterParent;
                            msg.ShowDialog(this);
                        }
                        return false;
                    }

                    void RecursiveExtractOwlcatDir(string dir)
                    {
                        var fileNames = Directory.GetFiles(dir)
                            .Select(Path.GetFileName)
                            .ToHashSet(StringComparer.OrdinalIgnoreCase);
                        bool hasAllFiles = fileNames.Contains("Fulllength.png") &&
                                           fileNames.Contains("Medium.png") &&
                                           fileNames.Contains("Small.png");

                        if (hasAllFiles)
                        {
                            string folderName = Path.GetFileName(dir);
                            if (selectedKeys == null || selectedKeys.Contains(dir))
                            {
                                string targetFolder = GetUniqueFolderPath(extractDir, folderName, out bool conflicted);
                                Directory.CreateDirectory(targetFolder);
                                if (conflicted) conflictCount++;

                                bool hadInvalid = false;
                                foreach (var file in Directory.GetFiles(dir))
                                {
                                    string destPath = Path.Combine(targetFolder, Path.GetFileName(file));
                                    File.Copy(file, destPath, overwrite: true);
                                    ValidatePortraitSize(destPath, ref hadInvalid);
                                }
                                if (hadInvalid)
                                {
                                    try { Directory.Delete(targetFolder, true); } catch { }
                                    sizeInvalidCount++;
                                    return;
                                }
                                count++;
                            }
                            return;
                        }

                        foreach (var subDir in Directory.GetDirectories(dir))
                            RecursiveExtractOwlcatDir(subDir);
                    }

                    RecursiveExtractOwlcatDir(_shellTempDir);
                }
                else
                {
                    void RecursiveExtractFolder(string folder)
                    {
                        bool hasRequired;
                        try
                        {
                            var files = Directory.GetFiles(folder).Select(Path.GetFileName).ToHashSet(StringComparer.OrdinalIgnoreCase);
                            hasRequired = files.Contains("Fulllength.png") &&
                                          files.Contains("Medium.png") &&
                                          files.Contains("Small.png");
                        }
                        catch
                        {
                            hasRequired = false;
                        }

                        if (hasRequired)
                        {
                            if (selectedKeys != null && !selectedKeys.Contains(folder))
                                return;

                            string folderName = Path.GetFileName(folder);
                            string targetFolder = GetUniqueFolderPath(extractDir, folderName, out bool conflicted);
                            Directory.CreateDirectory(targetFolder);
                            if (conflicted) conflictCount++;

                            bool hadInvalid = false;
                            foreach (var file in Directory.GetFiles(folder).Where(f => IsImageFile(f)))
                            {
                                string destPath = Path.Combine(targetFolder, Path.GetFileName(file));
                                File.Copy(file, destPath, overwrite: true);
                                ValidatePortraitSize(destPath, ref hadInvalid);
                            }
                            if (hadInvalid)
                            {
                                try { Directory.Delete(targetFolder, true); } catch { }
                                sizeInvalidCount++;
                                return;
                            }
                            count++;
                            return;
                        }

                        foreach (var subDir in Directory.GetDirectories(folder))
                            RecursiveExtractFolder(subDir);
                    }

                    RecursiveExtractFolder(_selectedArchivePath);
                }

                string conflictMsg = conflictCount > 0
                    ? string.Format(TextVariables.MESG_EXTRACT_CONFLICT, count, conflictCount)
                    : string.Format(TextVariables.MESG_EXTRACT_SUCCESS, count);
                string msgText = conflictMsg;
                if (skippedCount > 0)
                    msgText += $"\nSkipped {skippedCount} incomplete set(s) (missing Fulllength.png, Medium.png, or Small.png).";
                if (sizeInvalidCount > 0)
                    msgText += $"\nSkipped {sizeInvalidCount} set(s) with invalid portrait dimensions.";
                using (var msg = new MyMessageDialog(msgText))
                {
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog(this);
                }
                return count > 0;
            }
            catch (Exception ex)
            {
                using (var msg = new MyMessageDialog("Extraction failed: " + ex.Message))
                {
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog(this);
                }
                return false;
            }
            finally
            {
                CleanupShellTempDir();
            }
        }

        private void DrawGroupBorder(Control group, PaintEventArgs e, Label label)
        {
            if (group == null) return;
            Color col = Color.White;
            try { col = GameTypes[_gameSelected].ForeColor; } catch { if (label != null) col = label.ForeColor; }
            using (var pen = new Pen(col))
            {
                int w = group.ClientSize.Width;
                int h = group.ClientSize.Height;
                e.Graphics.DrawLine(pen, 0, 0, 0, h - 1);
                e.Graphics.DrawLine(pen, w - 1, 0, w - 1, h - 1);
                e.Graphics.DrawLine(pen, 0, h - 1, w - 1, h - 1);

                int gapStart = -1, gapEnd = -1;
                if (label != null && label.Visible)
                {
                    try
                    {
                        var lblScreen = label.PointToScreen(Point.Empty);
                        var lblInGroup = group.PointToClient(lblScreen);
                        gapStart = lblInGroup.X;
                        gapEnd = lblInGroup.X + label.Width;
                    }
                    catch { gapStart = -1; gapEnd = -1; }
                }

                if (gapStart < 0 || gapEnd <= 0 || gapStart >= w || gapEnd <= 0)
                {
                    e.Graphics.DrawLine(pen, 0, 0, w - 1, 0);
                }
                else
                {
                    int leftSegEnd = Math.Max(0, gapStart - 1);
                    if (leftSegEnd > 0)
                        e.Graphics.DrawLine(pen, 0, 0, leftSegEnd, 0);

                    int rightSegStart = Math.Min(w - 1, gapEnd + 1);
                    if (rightSegStart < w - 1)
                        e.Graphics.DrawLine(pen, rightSegStart, 0, w - 1, 0);
                }
            }
        }

        // SetKingPortraitGroup only ever makes ONE group's layout/panel visible at a time
        // (LayoutKingPortraitGroupMedium/Small/Sml2.Visible = false while inactive) - so calling
        // FitImageToPanel immediately for an inactive group runs against a panel that isn't
        // necessarily laid out to its real size yet, producing a wrong crop/fit (this is the
        // black-bars-until-you-switch-tabs bug: switching tabs happens to trigger a correct,
        // lazy re-fit via EnsureKingGroupInitialized, which only runs for a group that hasn't
        // already been marked initialized). So: only fit+mark-initialized the group that's
        // actually active right now (Large, in every caller of this - Change/Clone always open
        // on the Large tab); for every other group, just store the image and leave it
        // un-initialized so the existing, correct lazy-fit runs whenever the user switches to it.
        private void LoadImageIntoPortraitBox(PictureBox pic, Image img, PortraitGroupSelection group)
        {
            StoreOriginalImage(pic, img);
            if (group == _activeKingPortraitGroup)
            {
                FitImageToPanel(pic);
                MarkGroupInitialized(pic);
            }
            else
            {
                // EnsureKingGroupInitialized's lazy fit (FitPictureToPanel) bails out early if
                // pic.Image is still null - which it can be for a box that has never been shown
                // in this app session. Assign the raw image directly (not fitted - just a
                // placeholder that gets replaced the moment this group actually becomes active)
                // so that null-check never blocks the real, correctly-timed fit later.
                if (pic.Image == null)
                    pic.Image = img;

                if (pic.Name == "PicKingLrg") _groupLrgInitialized = false;
                else if (pic.Name == "PicKingMed") _groupMedInitialized = false;
                else if (pic.Name == "PicKingSml") _groupSmlInitialized = false;
                else if (pic.Name == "PicKingSml2") _groupSml2Initialized = false;
            }
        }

        private void LoadGalleryImageIntoCreatePage(string folderPath)
        {
            if (_gameSelected == 'd')
            {
                LoadDeadfireGalleryIntoCreatePage(folderPath);
                return;
            }

            if (_gameSelected == 't')
            {
                LoadTyrannyGalleryIntoCreatePage(folderPath, fromBackup: false);
                return;
            }

            if (_gameSelected == 'p')
            {
                LoadPillarsGalleryIntoCreatePage(folderPath, fromBackup: false);
                return;
            }

            string bestFile = FindBestGalleryImage(folderPath);
            if (bestFile == null) return;

            try
            {
                using (Image fileImg = Image.FromFile(bestFile))
                {
                    Bitmap copy = ImageControl.Direct.Resize(fileImg, fileImg.Width, fileImg.Height);

                    LoadImageIntoPortraitBox(PicKingLrg, new Bitmap(copy), PortraitGroupSelection.Large);

                    if (GameTypes.TryGetValue(_gameSelected, out var gt) &&
                        HasPortraitSpecific(gt, "MEDIUM_WIDTH") &&
                        HasPortraitSpecific(gt, "MEDIUM_HEIGHT"))
                    {
                        LoadImageIntoPortraitBox(PicKingMed, new Bitmap(copy), PortraitGroupSelection.Medium);
                    }

                    LoadImageIntoPortraitBox(PicKingSml, new Bitmap(copy), PortraitGroupSelection.Small);
                    LoadImageIntoPortraitBox(PicKingSml2, new Bitmap(copy), PortraitGroupSelection.Sml2);

                    copy.Dispose();
                }
            }
            catch { }
        }

        // Deadfire's companion archives ship "_lg" (210x330), "_convo" (90x141), "_sm" (76x96)
        // and "_si" (76x96) as genuinely separate files per companion (confirmed by the
        // extraction code's own completeness check, which requires all four to exist) - the
        // real game data does the same. Loading a single found file into every box (the old
        // behavior here for Large/Small/Sml2) is exactly the bug that produced black bars on
        // Tyranny's and PoE's Small portraits; give each box its own matching file instead,
        // same fix already applied there. fromBackup mirrors the Tyranny/Pillars loaders so
        // this same function can serve both the present-load and backup-restore paths.
        private void LoadDeadfireGalleryIntoCreatePage(string folderPath, bool fromBackup = false)
        {
            string dir = Path.GetDirectoryName(folderPath);
            string prefix = Path.GetFileName(folderPath);
            string suffix = fromBackup ? ".png.backup" : ".png";

            try
            {
                string lgPath = Path.Combine(dir, prefix + "_lg" + suffix);
                if (!fromBackup && !File.Exists(lgPath))
                {
                    string fallback = FindBestGalleryImage(folderPath);
                    if (fallback != null) lgPath = fallback;
                }
                if (File.Exists(lgPath))
                {
                    using (Image lgImg = Image.FromFile(lgPath))
                    {
                        Bitmap lgCopy = ImageControl.Direct.Resize(lgImg, lgImg.Width, lgImg.Height);
                        LoadImageIntoPortraitBox(PicKingLrg, lgCopy, PortraitGroupSelection.Large);
                    }
                }

                string convoPath = Path.Combine(dir, prefix + "_convo" + suffix);
                if (!File.Exists(convoPath)) convoPath = lgPath;
                if (File.Exists(convoPath))
                {
                    using (Image convoImg = Image.FromFile(convoPath))
                    {
                        Bitmap convoCopy = ImageControl.Direct.Resize(convoImg, convoImg.Width, convoImg.Height);
                        LoadImageIntoPortraitBox(PicKingMed, convoCopy, PortraitGroupSelection.Medium);
                    }
                }

                string smPath = Path.Combine(dir, prefix + "_sm" + suffix);
                if (!File.Exists(smPath)) smPath = lgPath;
                if (File.Exists(smPath))
                {
                    using (Image smImg = Image.FromFile(smPath))
                    {
                        Bitmap smCopy = ImageControl.Direct.Resize(smImg, smImg.Width, smImg.Height);
                        LoadImageIntoPortraitBox(PicKingSml, smCopy, PortraitGroupSelection.Small);
                    }
                }

                string siPath = Path.Combine(dir, prefix + "_si" + suffix);
                if (!File.Exists(siPath)) siPath = File.Exists(smPath) ? smPath : lgPath;
                if (File.Exists(siPath))
                {
                    using (Image siImg = Image.FromFile(siPath))
                    {
                        Bitmap siCopy = ImageControl.Direct.Resize(siImg, siImg.Width, siImg.Height);
                        LoadImageIntoPortraitBox(PicKingSml2, siCopy, PortraitGroupSelection.Sml2);
                    }
                }
            }
            catch { }
        }

        private string GetNonPlayerPortraitsRoot(string basePath)
        {
            if (_gameSelected == 'p')
                return Path.Combine(basePath, "PillarsOfEternity_Data", "data", "art", "gui", "portraits");
            if (_gameSelected == 'd')
                return Path.Combine(basePath, "PillarsOfEternityII_Data", "gui", "portraits");
            if (_gameSelected == 't')
                return Path.Combine(basePath, "Data", "data", "art", "gui", "portraits");
            return null;
        }

        private string GetCustomNpcPortraitsDir(string basePath)
        {
            if (_gameSelected == 'r') return null;
            return Path.Combine(basePath, "Portraits - Npc");
        }

        // The "Characters" tab merges everything that isn't a companion into one view:
        // - Kingmaker: "Portraits - All Additions", a sibling of Portraits\ populated by a
        //   separate NPC portrait pack (not edvin76's mod - its output format doesn't match any
        //   of that mod's own directory-naming methods), confirmed to display in-game.
        // - WotR: the mod's own "Portraits - Npc" (regular NPCs; portraits sit one level deeper
        //   per-NPC, same recursive shape as Kingmaker's "All Additions"), "Portraits - Army"
        //   (army leaders) and "Portraits - Tactical" (army units), all folded into one tab per
        //   the user's direction rather than given their own tabs.
        // Rogue Trader has no CustomNPC support at all, so this returns nothing there.
        //
        // "Portraits - Npc" itself is the mod's own live NPC folder (created as the player meets
        // NPCs in-game), and the mod is available for both Kingmaker and WotR - so it belongs in
        // both games' Characters roots, alongside whatever else each game also has.
        private List<string> GetCharactersPortraitsRoots(string basePath)
        {
            var roots = new List<string>();
            if (_gameSelected == 'k')
            {
                roots.Add(Path.Combine(basePath, "Portraits - All Additions"));
                roots.Add(Path.Combine(basePath, "Portraits - Npc"));
            }
            else if (_gameSelected == 'w')
            {
                roots.Add(Path.Combine(basePath, "Portraits - Npc"));
                roots.Add(Path.Combine(basePath, "Portraits - Army"));
                roots.Add(Path.Combine(basePath, "Portraits - Tactical"));
            }
            return roots;
        }

        // Returns true if a backup already existed for this entry before this call (i.e. this
        // is at least the second time it's been changed) - on the very first change, the
        // backup this creates is byte-identical to the present portrait, so there's nothing
        // meaningful for the caller to offer a choice between.
        private bool BackupNonPlayerPortraitSet(string entryPath)
        {
            string dir = Path.GetDirectoryName(entryPath);
            string prefix = Path.GetFileName(entryPath);
            string[] suffixes = { "_lg", "_sm", "_si", "_convo" };
            bool hadExistingBackup = suffixes.Any(suf => File.Exists(Path.Combine(dir, prefix + suf + ".png.backup")));
            foreach (string suf in suffixes)
            {
                string srcPath = Path.Combine(dir, prefix + suf + ".png");
                string backupPath = srcPath + ".backup";
                if (File.Exists(srcPath) && !File.Exists(backupPath))
                {
                    try { File.Copy(srcPath, backupPath, overwrite: false); }
                    catch { }
                }
            }
            return hadExistingBackup;
        }

        // These games have no mod keeping a separate original copy, so BackupNonPlayerPortraitSet
        // makes our own ".backup" of the game's shipped asset the first time it's about to be
        // replaced (and only that once). This looks up whichever one exists, same priority order.
        private string FindBestNonPlayerBackupImage(string entryPath)
        {
            string dir = Path.GetDirectoryName(entryPath);
            string prefix = Path.GetFileName(entryPath);
            string[] priority = { "_lg", "_sm", "_si", "_convo" };
            foreach (string suf in priority)
            {
                string path = Path.Combine(dir, prefix + suf + ".png.backup");
                if (File.Exists(path)) return path;
            }
            return null;
        }

        // Tyranny's "_lg" and "_sm" files are genuinely different native images (not just
        // different crops of one source) with visibly different aspect ratios - "_lg" is
        // 210x330, "_sm" is 76x96. Stretching one of them across every size box (the generic
        // approach every other non-player game still uses below) makes whichever box the
        // aspect actually mismatches show black bars once saved (and, worse, once the preview
        // itself started reflecting the true crop). Load each box from its own matching file
        // instead, same fix already applied to Deadfire's "_convo" vs "_lg" split above.
        private void LoadTyrannyGalleryIntoCreatePage(string folderPath, bool fromBackup)
        {
            string dir = Path.GetDirectoryName(folderPath);
            string prefix = Path.GetFileName(folderPath);
            string suffix = fromBackup ? ".png.backup" : ".png";

            try
            {
                string lgPath = Path.Combine(dir, prefix + "_lg" + suffix);
                if (File.Exists(lgPath))
                {
                    using (Image lgImg = Image.FromFile(lgPath))
                    {
                        Bitmap lgCopy = ImageControl.Direct.Resize(lgImg, lgImg.Width, lgImg.Height);
                        LoadImageIntoPortraitBox(PicKingLrg, lgCopy, PortraitGroupSelection.Large);
                    }
                }

                string smPath = Path.Combine(dir, prefix + "_sm" + suffix);
                bool smFallback = !File.Exists(smPath);
                if (smFallback) smPath = lgPath; // no dedicated small file - fall back rather than show nothing
                try
                {
                    string log =
                        $"[{DateTime.Now:HH:mm:ss.fff}] LoadTyrannyGalleryIntoCreatePage{Environment.NewLine}" +
                        $"  folderPath arg: {folderPath}{Environment.NewLine}" +
                        $"  dir={dir}  prefix={prefix}  fromBackup={fromBackup}{Environment.NewLine}" +
                        $"  smPath (final)={smPath}  smFallbackToLarge={smFallback}{Environment.NewLine}{Environment.NewLine}";
                    File.AppendAllText(Path.Combine(Path.GetTempPath(), "zpm_tyranny_debug.log"), log);
                }
                catch { }
                if (File.Exists(smPath))
                {
                    using (Image smImg = Image.FromFile(smPath))
                    {
                        Bitmap smCopy = ImageControl.Direct.Resize(smImg, smImg.Width, smImg.Height);
                        LoadImageIntoPortraitBox(PicKingSml, new Bitmap(smCopy), PortraitGroupSelection.Small);
                        LoadImageIntoPortraitBox(PicKingSml2, smCopy, PortraitGroupSelection.Sml2);
                    }
                }
            }
            catch { }
        }

        // PoE's companion files use the exact same "_lg" (210x330) / "_sm" (76x96) split as
        // Tyranny's (verified against a real install) - same reasoning as
        // LoadTyrannyGalleryIntoCreatePage above applies here, so give it the same per-size
        // loader instead of falling through to the generic "one file into every box" path.
        private void LoadPillarsGalleryIntoCreatePage(string folderPath, bool fromBackup)
        {
            string dir = Path.GetDirectoryName(folderPath);
            string prefix = Path.GetFileName(folderPath);
            string suffix = fromBackup ? ".png.backup" : ".png";

            try
            {
                string lgPath = Path.Combine(dir, prefix + "_lg" + suffix);
                if (File.Exists(lgPath))
                {
                    using (Image lgImg = Image.FromFile(lgPath))
                    {
                        Bitmap lgCopy = ImageControl.Direct.Resize(lgImg, lgImg.Width, lgImg.Height);
                        LoadImageIntoPortraitBox(PicKingLrg, lgCopy, PortraitGroupSelection.Large);
                    }
                }

                string smPath = Path.Combine(dir, prefix + "_sm" + suffix);
                if (!File.Exists(smPath)) smPath = lgPath;
                if (File.Exists(smPath))
                {
                    using (Image smImg = Image.FromFile(smPath))
                    {
                        Bitmap smCopy = ImageControl.Direct.Resize(smImg, smImg.Width, smImg.Height);
                        LoadImageIntoPortraitBox(PicKingSml, new Bitmap(smCopy), PortraitGroupSelection.Small);
                        LoadImageIntoPortraitBox(PicKingSml2, smCopy, PortraitGroupSelection.Sml2);
                    }
                }
            }
            catch { }
        }

        private void LoadNonPlayerBackupIntoCreatePage(string entryPath)
        {
            if (_gameSelected == 't')
            {
                LoadTyrannyGalleryIntoCreatePage(entryPath, fromBackup: true);
                return;
            }

            if (_gameSelected == 'p')
            {
                LoadPillarsGalleryIntoCreatePage(entryPath, fromBackup: true);
                return;
            }

            if (_gameSelected == 'd')
            {
                LoadDeadfireGalleryIntoCreatePage(entryPath, fromBackup: true);
                return;
            }

            string bestFile = FindBestNonPlayerBackupImage(entryPath);
            if (bestFile == null) return;

            try
            {
                using (Image fileImg = Image.FromFile(bestFile))
                {
                    Bitmap copy = ImageControl.Direct.Resize(fileImg, fileImg.Width, fileImg.Height);

                    LoadImageIntoPortraitBox(PicKingLrg, new Bitmap(copy), PortraitGroupSelection.Large);

                    if (GameTypes.TryGetValue(_gameSelected, out var gt) &&
                        HasPortraitSpecific(gt, "MEDIUM_WIDTH") &&
                        HasPortraitSpecific(gt, "MEDIUM_HEIGHT"))
                    {
                        LoadImageIntoPortraitBox(PicKingMed, new Bitmap(copy), PortraitGroupSelection.Medium);
                    }

                    LoadImageIntoPortraitBox(PicKingSml, new Bitmap(copy), PortraitGroupSelection.Small);
                    LoadImageIntoPortraitBox(PicKingSml2, new Bitmap(copy), PortraitGroupSelection.Sml2);

                    copy.Dispose();
                }
            }
            catch { }
        }

        private void UpdateGalleryTabVisuals()
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gt)) return;
            Color gameBack = gt.BackColor;
            Color gameFore = gt.ForeColor;

            LabelGalleryTab.BackColor = _galleryTabSelected == "player" ? gameBack : Color.Transparent;
            LabelGalleryTab.ForeColor = _galleryTabSelected == "player" ? gameFore : Color.White;
            LabelGalleryTab.Invalidate();

            LabelGalleryNonPlayerTab.BackColor = _galleryTabSelected == "nonplayer" ? gameBack : Color.Transparent;
            LabelGalleryNonPlayerTab.ForeColor = _galleryTabSelected == "nonplayer" ? gameFore : Color.White;
            LabelGalleryNonPlayerTab.Invalidate();

            LabelGalleryCustomNpcTab.BackColor = _galleryTabSelected == "customnpc" ? gameBack : Color.Transparent;
            LabelGalleryCustomNpcTab.ForeColor = _galleryTabSelected == "customnpc" ? gameFore : Color.White;
            LabelGalleryCustomNpcTab.Invalidate();

            LabelGalleryCompanionsTab.BackColor = _galleryTabSelected == "companions" ? gameBack : Color.Transparent;
            LabelGalleryCompanionsTab.ForeColor = _galleryTabSelected == "companions" ? gameFore : Color.White;
            LabelGalleryCompanionsTab.Invalidate();

            LabelGalleryCharactersTab.BackColor = _galleryTabSelected == "characters" ? gameBack : Color.Transparent;
            LabelGalleryCharactersTab.ForeColor = _galleryTabSelected == "characters" ? gameFore : Color.White;
            LabelGalleryCharactersTab.Invalidate();

            if (_galleryTabSelected == "companions" || _galleryTabSelected == "characters")
            {
                LabelGalleryCredit.Text = TextVariables.MESG_GALLERY_CUSTOMNPC_CREDIT;
                LabelGalleryCredit.Visible = true;
            }
            else
            {
                LabelGalleryCredit.Visible = false;
            }
        }

        private void UpdateGalleryRightPanel()
        {
            bool hasEntries = _galleryEntries != null && _galleryEntries.Count > 0;

            if (string.IsNullOrEmpty(_selectedGalleryEntry))
            {
                ButtonGalleryDelete.Visible = false;
                ButtonGalleryClone.Visible = false;
                ButtonGalleryChange.Visible = false;
                ButtonGalleryShowFolder.Visible = true;
                ButtonGalleryBack.Visible = true;
                // NOTE: every row here is a Percent-type RowStyle (see Designer.cs) and must
                // stay that way - only ever adjust .Height, never replace the RowStyle objects
                // (that previously mutated SizeType to AutoSize/Absolute and broke every other
                // tab's layout afterward, since they all assume Percent sizing persists).
                LayoutGalleryRight.RowStyles[0].Height = 0;
                LayoutGalleryRight.RowStyles[1].Height = 0;
                LayoutGalleryRight.RowStyles[2].Height = 0;
                LayoutGalleryRight.RowStyles[3].Height = 0;
                LayoutGalleryRight.RowStyles[4].Height = 50;
                LayoutGalleryRight.RowStyles[5].Height = 50;
            }
            else
            {
                // "nonplayer" (Tyranny's Companions/close-NPCs) is the game's own shipped asset
                // file, not something this app created - same reasoning as Companions/Characters
                // for Kingmaker/WotR: no casual permanent-delete button for content that isn't
                // ours, especially since deleting here would also remove its one-time backup.
                bool showDelete = !_isCustomNpcMode && _galleryTabSelected != "companions" &&
                                   _galleryTabSelected != "characters" && _galleryTabSelected != "nonplayer";
                ButtonGalleryDelete.Visible = showDelete;
                ButtonGalleryClone.Visible = hasEntries;
                ButtonGalleryChange.Visible = hasEntries;
                ButtonGalleryShowFolder.Visible = false;
                ButtonGalleryBack.Visible = true;
                LayoutGalleryRight.RowStyles[0].Height = 0;
                if (showDelete)
                {
                    LayoutGalleryRight.RowStyles[1].Height = 29;
                    LayoutGalleryRight.RowStyles[2].Height = 29;
                    LayoutGalleryRight.RowStyles[3].Height = 28;
                }
                else
                {
                    // Delete's row is hidden here (Companions/Characters) - give its share to
                    // Clone and Change instead of leaving an empty gap.
                    LayoutGalleryRight.RowStyles[1].Height = 43;
                    LayoutGalleryRight.RowStyles[2].Height = 43;
                    LayoutGalleryRight.RowStyles[3].Height = 0;
                }
                LayoutGalleryRight.RowStyles[4].Height = 0;
                LayoutGalleryRight.RowStyles[5].Height = 14;
            }

            UpdateGalleryOverlay();
        }

        private void UpdateGalleryOverlay()
        {
            if (_galleryTabSelected != "customnpc" && _galleryTabSelected != "characters")
            {
                if (_panelGalleryOverlay != null)
                    _panelGalleryOverlay.Visible = false;
                return;
            }

            bool hasEntries = _galleryEntries != null && _galleryEntries.Count > 0;
            if (hasEntries)
            {
                if (_panelGalleryOverlay != null)
                    _panelGalleryOverlay.Visible = false;
                return;
            }

            if (_panelGalleryOverlay == null)
            {
                _panelGalleryOverlay = new Panel
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.Transparent
                };
                _panelGalleryOverlay.Paint += PanelGalleryOverlay_Paint;
                PanelGalleryContainer.Controls.Add(_panelGalleryOverlay);
                _panelGalleryOverlay.BringToFront();
            }

            _panelGalleryOverlay.Visible = true;
        }

        // This app never creates its own backup copies of a CustomNpcPortraits-mod-managed
        // folder (Companions or Characters/Portraits - Npc) - the mod already keeps one, at
        // "<folder>\Backup of Game Default Portraits\*.png", so there's no need for a second,
        // parallel one. This just looks up the mod's own backup image.
        private string FindModDefaultBackupImage(string folderPath)
        {
            if (string.IsNullOrEmpty(folderPath)) return null;
            string backupDir = Path.Combine(folderPath, "Backup of Game Default Portraits");
            if (!Directory.Exists(backupDir)) return null;

            string[] files;
            try { files = Directory.GetFiles(backupDir, "*.png"); }
            catch { return null; }

            return files.FirstOrDefault(f => Path.GetFileName(f).Equals("Fulllength.png", StringComparison.OrdinalIgnoreCase))
                ?? files.FirstOrDefault(f => Path.GetFileName(f).Equals("Medium.png", StringComparison.OrdinalIgnoreCase))
                ?? files.FirstOrDefault(f => Path.GetFileName(f).Equals("Small.png", StringComparison.OrdinalIgnoreCase))
                ?? files.FirstOrDefault();
        }

        private bool HasModDefaultBackup(string folderPath)
        {
            return FindModDefaultBackupImage(folderPath) != null;
        }

        private void LoadBackupImageIntoCreatePage(string folderPath)
        {
            string bestFile = FindModDefaultBackupImage(folderPath);
            if (bestFile == null) return;

            try
            {
                using (Image fileImg = Image.FromFile(bestFile))
                {
                    Bitmap copy = ImageControl.Direct.Resize(fileImg, fileImg.Width, fileImg.Height);

                    LoadImageIntoPortraitBox(PicKingLrg, new Bitmap(copy), PortraitGroupSelection.Large);

                    if (GameTypes.TryGetValue(_gameSelected, out var gt) &&
                        HasPortraitSpecific(gt, "MEDIUM_WIDTH") &&
                        HasPortraitSpecific(gt, "MEDIUM_HEIGHT"))
                    {
                        LoadImageIntoPortraitBox(PicKingMed, new Bitmap(copy), PortraitGroupSelection.Medium);
                    }

                    LoadImageIntoPortraitBox(PicKingSml, new Bitmap(copy), PortraitGroupSelection.Small);
                    LoadImageIntoPortraitBox(PicKingSml2, new Bitmap(copy), PortraitGroupSelection.Sml2);

                    copy.Dispose();
                }
            }
            catch { }
        }

        private void UpdateExtractCounter()
        {
            int total = 0;
            int selected = 0;
            if (_archiveEntries != null)
            {
                total = _archiveEntries.Count;
                selected = FlowLayoutPanelExtract.Controls.OfType<CheckBox>().Count(cb => cb.Checked);
            }
            LabelExtractCounter.Text = "Total: " + total + " | Selected: " + selected;
        }

        private ushort GetMainMenuIndexForCurrentGame()
        {
            if (_gameSelected == 'w') return 202;
            if (_gameSelected == 'r') return 203;
            if (_gameSelected == 'p') return 204;
            if (_gameSelected == 'd') return 205;
            if (_gameSelected == 't') return 206;
            if (_gameSelected == 'l') return 207;
            return 201;
        }

        private ushort GetCreatePortraitMenuIndexForCurrentGame()
        {
            if (_gameSelected == 'w') return 302;
            if (_gameSelected == 'r') return 303;
            if (_gameSelected == 'p') return 304;
            if (_gameSelected == 'd') return 305;
            if (_gameSelected == 't') return 306;
            if (_gameSelected == 'l') return 307;
            return 301;
        }

        private void PrepareKingCreatePortraitStyleState()
        {
            SetKingPortraitGroup(PortraitGroupSelection.Large);
            AdjustActivePortraitPanelAspect(PortraitGroupSelection.Medium);
            AdjustActivePortraitPanelAspect(PortraitGroupSelection.Small);
            AdjustActivePortraitPanelAspect(PortraitGroupSelection.Sml2);
            LayoutKingPortraitGroupLarge.Invalidate();
            LayoutKingPortraitGroupMedium.Invalidate();
            LayoutKingPortraitGroupSmall.Invalidate();
            LayoutKingPortraitGroupSml2.Invalidate();
            LayoutKingRight.Invalidate();
        }

        private void PrepareKingCreatePortraitView()
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gameType) || gameType.PlaceholderPortrait == null)
                return;

            StoreOriginalImage(PicKingLrg, new Bitmap(gameType.PlaceholderPortrait));
            StoreOriginalImage(PicKingSml, new Bitmap(gameType.PlaceholderPortrait));
            StoreOriginalImage(PicKingSml2, new Bitmap(gameType.PlaceholderPortrait));

            _groupLrgInitialized = false;
            _groupSmlInitialized = false;
            _groupSml2Initialized = false;

            bool hasMed = HasPortraitSpecific(gameType, "MEDIUM_WIDTH") &&
                          HasPortraitSpecific(gameType, "MEDIUM_HEIGHT");

            if (hasMed)
            {
                StoreOriginalImage(PicKingMed, new Bitmap(gameType.PlaceholderPortrait));
                _groupMedInitialized = false;
            }
            else
            {
                _groupMedInitialized = true; // mark as initialized so EnsureKingGroup skips it
            }

            // Enable drag-and-drop onto each portrait PictureBox (file or URL text)
            WirePortraitDragDrop(PicKingLrg);
            WirePortraitDragDrop(PicKingSml);
            WirePortraitDragDrop(PicKingSml2);
            if (hasMed)
                WirePortraitDragDrop(PicKingMed);

            AdjustActivePortraitPanelAspect(PortraitGroupSelection.Large);
            EnsureKingGroupInitialized(PortraitGroupSelection.Large);
        }

        private float GetPortraitSpecificOrDefault(GameType gameType, string key, float fallback)
        {
            if (gameType == null) return fallback;
            try { return gameType.GetPortraitSpecific(key); }
            catch { return fallback; }
        }

        private void AdjustPortraitPanelAspect(Panel panel, float ar, float staticHeight)
        {
            if (panel == null) return;

            panel.SuspendLayout();
            try
            {
                panel.AutoSize = false;
                panel.Dock = DockStyle.None;
                panel.Anchor = AnchorStyles.None;
                int newWidth = (int)Math.Round(staticHeight / ar);
                int newHeight = (int)staticHeight;

                // PanelKingSml's cell in LayoutKingPortraitGroupSmall uses a Percent column,
                // which clamps the panel's width to whatever fraction of the row's current
                // total width that percentage computes to, regardless of Anchor/Dock -
                // requesting a wider Size than the cell allows just gets silently shrunk back
                // down. Tyranny and PoE's Small portrait (both 76x96, SMALL_AR=1.2631) need
                // more width relative to their height than that percent column happens to
                // allow at this container size, so the panel ended up shorter/wider than
                // 76:96 and produced a crop/target aspect mismatch (visible as black bars).
                // Rather than fight the column (widening it squeezes the sibling button
                // panel), shrink to fit within whatever width the cell already provides,
                // keeping the same 76:96 ratio - i.e. maximize inside the available cell
                // instead of overflowing it.
                if ((_gameSelected == 't' || _gameSelected == 'p') && panel.Name == "PanelKingSml")
                {
                    int availableWidth = panel.Width;
                    if (availableWidth > 0 && newWidth > availableWidth)
                    {
                        newWidth = availableWidth;
                        newHeight = (int)Math.Round(availableWidth * ar);
                    }
                }

                panel.Size = new Size(newWidth, newHeight);

                if (_gameSelected == 't' && panel.Name == "PanelKingSml")
                {
                    try
                    {
                        string log =
                            $"[{DateTime.Now:HH:mm:ss.fff}] AdjustPortraitPanelAspect(PanelKingSml){Environment.NewLine}" +
                            $"  ar={ar:F5} staticHeight={staticHeight}  ->  newWidth={newWidth}  panel.Size after set={panel.Size}  panel.ClientSize after set={panel.ClientSize}{Environment.NewLine}{Environment.NewLine}";
                        File.AppendAllText(Path.Combine(Path.GetTempPath(), "zpm_tyranny_debug.log"), log);
                    }
                    catch { }
                }
            }
            finally
            {
                panel.ResumeLayout();
            }
        }

        private void AdjustActivePortraitPanelAspect(PortraitGroupSelection selection)
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gameType)) return;

            if (selection == PortraitGroupSelection.Large)
            {
                if (!HasPortraitSpecific(gameType, "LARGE_WIDTH")) return;
                AdjustPortraitPanelAspect(
                    PanelKingLrg,
                    GetPortraitSpecificOrDefault(gameType, "LARGE_AR", 1.3f),
                    360f);
            }
            else if (selection == PortraitGroupSelection.Medium)
            {
                if (HasPortraitSpecific(gameType, "MEDIUM_WIDTH"))
                {
                    AdjustPortraitPanelAspect(
                        PanelKingMed,
                        GetPortraitSpecificOrDefault(gameType, "MEDIUM_AR", 1.3f),
                        360f);
                }
            }
            else if (selection == PortraitGroupSelection.Small)
            {
                if (!HasPortraitSpecific(gameType, "SMALL_WIDTH")) return;
                // PoE's and Deadfire's Small panels need slightly less height than the other
                // 76:96 games (same AR, but the surrounding layout cell clamps their width
                // tighter here) - without this the panel ends up wider than 76:96, producing
                // left/right black bars on save. Confirmed by testing; scoped to each game.
                float smlHeight = (_gameSelected == 'l') ? 256f
                    : (_gameSelected == 'p') ? 345f
                    : (_gameSelected == 'd') ? 340f
                    : 360f;
                AdjustPortraitPanelAspect(
                    PanelKingSml,
                    GetPortraitSpecificOrDefault(gameType, "SMALL_AR", 1.4f),
                    smlHeight);
            }
            else if (selection == PortraitGroupSelection.Sml2)
            {
                if (!HasPortraitSpecific(gameType, "SML2_WIDTH")) return;
                // Same reasoning as Small above - Deadfire's Sml2 ("_si") shares the same 76:96
                // AR and the same panel-clamp behavior, needing the same reduction.
                float sml2Height = (_gameSelected == 'd') ? 340f : 360f;
                AdjustPortraitPanelAspect(
                    PanelKingSml2,
                    GetPortraitSpecificOrDefault(gameType, "SML2_AR", 1.4f),
                    sml2Height);
            }
        }

        private void WirePortraitDragDrop(PictureBox pic)
        {
            if (pic == null) return;
            pic.AllowDrop = true;
            pic.DragEnter -= PicKing_DragEnter;
            pic.DragDrop  -= PicKing_DragDrop;
            pic.DragLeave -= PicKing_DragLeave;
            pic.DragEnter += PicKing_DragEnter;
            pic.DragDrop  += PicKing_DragDrop;
            pic.DragLeave += PicKing_DragLeave;
        }

        private void EnsureKingGroupInitialized(PortraitGroupSelection selection)
        {
            if (selection == PortraitGroupSelection.Large)
            {
                if (_groupLrgInitialized) return;
                FitPictureToPanel(PicKingLrg, PanelKingLrg);
                _groupLrgInitialized = true;
            }
            else if (selection == PortraitGroupSelection.Medium)
            {
                if (_groupMedInitialized) return;
                FitPictureToPanel(PicKingMed, PanelKingMed);
                _groupMedInitialized = true;
            }
            else if (selection == PortraitGroupSelection.Small)
            {
                if (_groupSmlInitialized) return;
                FitPictureToPanel(PicKingSml, PanelKingSml);
                _groupSmlInitialized = true;
            }
            else if (selection == PortraitGroupSelection.Sml2)
            {
                if (_groupSml2Initialized) return;
                FitPictureToPanel(PicKingSml2, PanelKingSml2);
                _groupSml2Initialized = true;
            }
        }

        private void ResetPortraitToOriginalDisplay(PictureBox pic)
        {
            if (pic == null) return;

            Image original = GetOriginalImage(pic);
            if (original == null) return;

            try
            {
                if (pic.Image != null && !object.ReferenceEquals(pic.Image, original))
                    pic.Image.Dispose();
            }
            catch { }

            pic.Dock = DockStyle.Fill;
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Location = new Point(0, 0);
            pic.Image = new Bitmap(original);
            SetZoomLevel(pic, 1.0f);
        }

        private void NavigateToMainPage()
        {
            try
            {
                _activeMenuIndex = GetMainMenuIndexForCurrentGame();
                ParentLayoutsDisable();
                RootFunctions.LayoutEnable(LayoutMainPage);
                Focus();
            }
            catch { }
        }

        private void StoreOriginalImage(PictureBox pic, Image img)
        {
            if (pic.Name == "PicKingLrg")
            {
                _originalImageLrg?.Dispose();
                _originalImageLrg = img;
                _zoomLevelLrg = 1.0f;
            }
            else if (pic.Name == "PicKingMed")
            {
                _originalImageMed?.Dispose();
                _originalImageMed = img;
                _zoomLevelMed = 1.0f;
            }
            else if (pic.Name == "PicKingSml")
            {
                _originalImageSml?.Dispose();
                _originalImageSml = img;
                _zoomLevelSml = 1.0f;
            }
            else if (pic.Name == "PicKingSml2")
            {
                _originalImageSml2?.Dispose();
                _originalImageSml2 = img;
                _zoomLevelSml2 = 1.0f;
            }
        }

        private Image GetOriginalImage(PictureBox pic)
        {
            if (pic.Name == "PicKingLrg") return _originalImageLrg;
            if (pic.Name == "PicKingMed") return _originalImageMed;
            if (pic.Name == "PicKingSml") return _originalImageSml;
            if (pic.Name == "PicKingSml2") return _originalImageSml2;
            return null;
        }

        private float GetZoomLevel(PictureBox pic)
        {
            if (pic.Name == "PicKingLrg") return _zoomLevelLrg;
            if (pic.Name == "PicKingMed") return _zoomLevelMed;
            if (pic.Name == "PicKingSml") return _zoomLevelSml;
            if (pic.Name == "PicKingSml2") return _zoomLevelSml2;
            return 1.0f;
        }

        private void SetZoomLevel(PictureBox pic, float zoom)
        {
            if (pic.Name == "PicKingLrg") _zoomLevelLrg = zoom;
            else if (pic.Name == "PicKingMed") _zoomLevelMed = zoom;
            else if (pic.Name == "PicKingSml") _zoomLevelSml = zoom;
            else if (pic.Name == "PicKingSml2") _zoomLevelSml2 = zoom;
        }

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("user32.dll")]
        private static extern int ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        private const int DWMWA_BORDER_COLOR = 34;
        private const int DWMWA_CAPTION_COLOR = 35;
        private const int DWMWA_TEXT_COLOR = 36;

        /// Applies the dark-mode titlebar, border, caption, and text colors (DWM composition attributes) to match the current game's theme; no-ops on Windows versions without DWM support.
        private void ApplyGameWindowStyle()
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gameType)) return;

            try
            {
                int useDark = 1;
                DwmSetWindowAttribute(Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref useDark, sizeof(int));

                int borderColor = System.Drawing.ColorTranslator.ToWin32(gameType.ForeColor);
                DwmSetWindowAttribute(Handle, DWMWA_BORDER_COLOR, ref borderColor, sizeof(int));

                int captionColor = System.Drawing.ColorTranslator.ToWin32(gameType.BackColor);
                DwmSetWindowAttribute(Handle, DWMWA_CAPTION_COLOR, ref captionColor, sizeof(int));

                int textColor = System.Drawing.ColorTranslator.ToWin32(gameType.ForeColor);
                DwmSetWindowAttribute(Handle, DWMWA_TEXT_COLOR, ref textColor, sizeof(int));
            }
            catch { }
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg != WM_MOUSEWHEEL) return false;

            Point cursor = Cursor.Position;
            Panel targetPanel = null;
            PictureBox targetPic = null;

            Panel[] panels = { PanelKingLrg, PanelKingMed, PanelKingSml, PanelKingSml2 };
            PictureBox[] pics = { PicKingLrg, PicKingMed, PicKingSml, PicKingSml2 };

            for (int i = 0; i < panels.Length; i++)
            {
                if (panels[i] == null || !panels[i].Visible) continue;
                if (panels[i].RectangleToScreen(panels[i].ClientRectangle).Contains(cursor))
                {
                    targetPanel = panels[i];
                    targetPic = pics[i];
                    break;
                }
            }

            if (targetPanel == null || targetPic == null) return false;
            if (targetPic.Image == null) return false;

            int delta = (short)((m.WParam.ToInt64() >> 16) & 0xFFFF);
            Point localPos = targetPic.PointToClient(cursor);
            ZoomPortrait(targetPic, targetPanel, delta, localPos);
            return true;
        }

        private void ZoomPortrait(PictureBox pb, Panel panel, int wheelDelta, Point localPos)
        {
            Image original = GetOriginalImage(pb);
            // If no stored original exists, fall back to using the currently displayed image
            // and store a deep copy as the original so subsequent resizes stay high-quality.
            if (original == null && pb.Image != null)
            {
                try
                {
                    var copy = new Bitmap(pb.Image);
                    StoreOriginalImage(pb, copy);
                    original = copy;
                }
                catch
                {
                    return;
                }
            }
            if (original == null || pb.Image == null) return;

            // Determine current zoom: prefer tracked zoom level, but compute from displayed
            // image size when possible so cover-mode images (which may be larger than the
            // picturebox control) behave correctly.
            float currentZoom = GetZoomLevel(pb);
            try
            {
                if (pb.Image != null && original.Width > 0)
                {
                    currentZoom = (float)pb.Image.Width / original.Width;
                }
            }
            catch { }

            float zoomStep = 0.08f;
            float newZoom = wheelDelta > 0 ? currentZoom + zoomStep : currentZoom - zoomStep;

            int panelW = panel.ClientSize.Width;
            int panelH = panel.ClientSize.Height;
            if (panelW <= 0 || panelH <= 0) return;

            float imgAspect = (float)original.Width / original.Height;
            float panelAspect = (float)panelW / panelH;
            float minZoom = imgAspect > panelAspect
                ? (float)panelH / original.Height
                : (float)panelW / original.Width;

            if (newZoom < minZoom) newZoom = minZoom;
            if (newZoom > 4.0f) newZoom = 4.0f;

            int newW = Math.Max(1, (int)(original.Width * newZoom));
            int newH = Math.Max(1, (int)(original.Height * newZoom));

            if (newW == pb.Width && newH == pb.Height)
                return;

            int oldW = pb.Width;
            int oldH = pb.Height;
            float relX = oldW <= 0 ? 0.5f : (float)localPos.X / oldW;
            float relY = oldH <= 0 ? 0.5f : (float)localPos.Y / oldH;

            Bitmap zoomed = ImageControl.Direct.Resize(original, newW, newH);
            Image old = pb.Image;
            pb.Image = zoomed;
            // disable docking so we can reposition/resize the PictureBox freely
            pb.Dock = DockStyle.None;
            // update control size to reflect new image dimensions so ClampPictureLocation
            // and other logic that relies on PictureBox.Width/Height behave correctly
            pb.SizeMode = PictureBoxSizeMode.Normal;
            pb.Size = new Size(newW, newH);
            if (old != null && old != original)
                old.Dispose();
            SetZoomLevel(pb, newZoom);

            if ((pb == PicKingLrg || pb == PicKingSml2) && wheelDelta < 0 && Math.Abs(newZoom - minZoom) < 0.0001f)
            {
                pb.Location = new Point((panelW - newW) / 2, (panelH - newH) / 2);
                return;
            }

            var desired = new Point(
                pb.Location.X - (int)(relX * newW - localPos.X),
                pb.Location.Y - (int)(relY * newH - localPos.Y));
            pb.Location = ClampPictureLocation(pb, panel, desired);
        }

        private void ZoomFromButton(object sender, int wheelDelta)
        {
            var button = sender as Button;
            if (button == null) return;

            string picName = button.Tag as string;
            if (string.IsNullOrEmpty(picName)) return;

            PictureBox pb = null;
            Panel panel = null;

            if (picName == "PicKingLrg") { pb = PicKingLrg; panel = PanelKingLrg; }
            else if (picName == "PicKingMed") { pb = PicKingMed; panel = PanelKingMed; }
            else if (picName == "PicKingSml") { pb = PicKingSml; panel = PanelKingSml; }
            else if (picName == "PicKingSml2") { pb = PicKingSml2; panel = PanelKingSml2; }

            if (pb == null || panel == null || pb.Image == null) return;

            Point center = new Point(pb.Width / 2, pb.Height / 2);
            ZoomPortrait(pb, panel, wheelDelta, center);
        }

        private void FitImageToPanel(PictureBox pic)
        {
            Image original = GetOriginalImage(pic);
            if (original == null) return;

            Panel panel = pic.Parent as Panel;
            if (panel == null) return;

            int panelW = panel.ClientSize.Width;
            int panelH = panel.ClientSize.Height;
            if (panelW <= 0 || panelH <= 0) return;

            float imgAspect = (float)original.Width / original.Height;
            float panelAspect = (float)panelW / panelH;

            int newW, newH;
            if (imgAspect > panelAspect)
            {
                newH = panelH;
                newW = Math.Max(1, (int)(panelH * imgAspect));
            }
            else
            {
                newW = panelW;
                newH = Math.Max(1, (int)(panelW / imgAspect));
            }

            float zoom = (float)newW / original.Width;
            SetZoomLevel(pic, zoom);

            Bitmap resized = ImageControl.Direct.Resize(original, newW, newH);
            Image oldImg = pic.Image;
            pic.Image = resized;
            // disable docking so location/size updates take effect and dragging works
            pic.Dock = DockStyle.None;
            pic.SizeMode = PictureBoxSizeMode.Normal;
            pic.Size = new Size(newW, newH);
            if (oldImg != null && oldImg != original)
                oldImg.Dispose();

            int x = (panelW - newW) / 2;
            int y = (panelH - newH) / 2;
            pic.Location = new Point(x, y);
        }

        private void SetKingPortraitGroup(PortraitGroupSelection selection)
        {
            if (LayoutKingPortraitGroupLarge == null ||
                LayoutKingPortraitGroupMedium == null ||
                LayoutKingPortraitGroupSmall == null ||
                LayoutKingPortraitGroupSml2 == null)
            {
                return;
            }

            if (!GameTypes.TryGetValue(_gameSelected, out var gameType))
            {
                // No valid game selected (e.g. sentinel '-'), skip styling updates.
                _activeKingPortraitGroup = selection;
                LayoutKingPortraitGroupLarge.Visible = selection == PortraitGroupSelection.Large;
                LayoutKingPortraitGroupMedium.Visible = selection == PortraitGroupSelection.Medium;
                LayoutKingPortraitGroupSmall.Visible = selection == PortraitGroupSelection.Small;
                LayoutKingPortraitGroupSml2.Visible = selection == PortraitGroupSelection.Sml2;
                LabelKingCreatePortraitLarge.Visible = true;
                LabelKingCreatePortraitMedium.Visible = true;
                LabelKingCreatePortraitSmall.Visible = true;
                LabelKingCreatePortraitSml2.Visible = true;
                return;
            }

            bool hasMedium = HasPortraitSpecific(gameType, "MEDIUM_WIDTH") &&
                             HasPortraitSpecific(gameType, "MEDIUM_HEIGHT");
            bool hasLarge = HasPortraitSpecific(gameType, "LARGE_WIDTH") &&
                            HasPortraitSpecific(gameType, "LARGE_HEIGHT");
            bool hasSmall = HasPortraitSpecific(gameType, "SMALL_WIDTH") &&
                            HasPortraitSpecific(gameType, "SMALL_HEIGHT");
            bool hasSml2 = HasPortraitSpecific(gameType, "SML2_WIDTH") &&
                           HasPortraitSpecific(gameType, "SML2_HEIGHT");

            // Fall back to first available group if requested selection has no dimensions
            bool selectionAvailable =
                (selection == PortraitGroupSelection.Large && hasLarge) ||
                (selection == PortraitGroupSelection.Medium && hasMedium) ||
                (selection == PortraitGroupSelection.Small && hasSmall) ||
                (selection == PortraitGroupSelection.Sml2 && hasSml2);

            if (!selectionAvailable)
            {
                if (hasSmall) selection = PortraitGroupSelection.Small;
                else if (hasSml2) selection = PortraitGroupSelection.Sml2;
                else if (hasMedium) selection = PortraitGroupSelection.Medium;
                else if (hasLarge) selection = PortraitGroupSelection.Large;
            }

            _activeKingPortraitGroup = selection;

            LayoutKingPortraitGroupLarge.Visible = hasLarge && selection == PortraitGroupSelection.Large;
            LayoutKingPortraitGroupMedium.Visible = hasMedium && selection == PortraitGroupSelection.Medium;
            LayoutKingPortraitGroupSmall.Visible = hasSmall && selection == PortraitGroupSelection.Small;
            LayoutKingPortraitGroupSml2.Visible = hasSml2 && selection == PortraitGroupSelection.Sml2;

            LayoutKingPortraitGroupLarge.BackColor = selection == PortraitGroupSelection.Large ? gameType.BackColor : Color.Transparent;
            LayoutKingPortraitGroupMedium.BackColor = selection == PortraitGroupSelection.Medium ? gameType.BackColor : Color.Transparent;
            LayoutKingPortraitGroupSmall.BackColor = selection == PortraitGroupSelection.Small ? gameType.BackColor : Color.Transparent;
            LayoutKingPortraitGroupSml2.BackColor = selection == PortraitGroupSelection.Sml2 ? gameType.BackColor : Color.Transparent;
            LayoutKingRight.BackColor = gameType.BackColor;
            LayoutKingRight.ForeColor = gameType.ForeColor;

            Color selBack = gameType.BackColor;
            Color selFore = gameType.ForeColor;

            LabelKingCreatePortraitLarge.Visible = hasLarge;
            LabelKingCreatePortraitLarge.BackColor = hasLarge && selection == PortraitGroupSelection.Large ? selBack : Color.Transparent;
            LabelKingCreatePortraitLarge.ForeColor = hasLarge && selection == PortraitGroupSelection.Large ? selFore : Color.White;
            LabelKingCreatePortraitMedium.Visible = hasMedium;
            LabelKingCreatePortraitMedium.BackColor = hasMedium && selection == PortraitGroupSelection.Medium ? selBack : Color.Transparent;
            LabelKingCreatePortraitMedium.ForeColor = hasMedium && selection == PortraitGroupSelection.Medium ? selFore : Color.White;
            LabelKingCreatePortraitSmall.Visible = hasSmall;
            LabelKingCreatePortraitSmall.BackColor = hasSmall && selection == PortraitGroupSelection.Small ? selBack : Color.Transparent;
            LabelKingCreatePortraitSmall.ForeColor = hasSmall && selection == PortraitGroupSelection.Small ? selFore : Color.White;
            LabelKingCreatePortraitSml2.Visible = hasSml2;
            LabelKingCreatePortraitSml2.BackColor = hasSml2 && selection == PortraitGroupSelection.Sml2 ? selBack : Color.Transparent;
            LabelKingCreatePortraitSml2.ForeColor = hasSml2 && selection == PortraitGroupSelection.Sml2 ? selFore : Color.White;
            // force repaint to update borders
            LabelKingCreatePortraitLarge?.Invalidate();
            LabelKingCreatePortraitMedium?.Invalidate();
            LabelKingCreatePortraitSmall?.Invalidate();
            LabelKingCreatePortraitSml2?.Invalidate();
            AdjustActivePortraitPanelAspect(selection);
            EnsureKingGroupInitialized(selection);
            // Update portrait buttons styles to match selected game colors
            UpdatePortraitButtonsStyle();

            // Reset Small label margin to default left alignment
            LabelKingCreatePortraitSmall.Margin = new Padding(0, 0, 3, 0);

            // Ensure large/medium layouts use small group as reference for size/row styles
            ApplySmallLayoutReference();
            // Reset displayed images into default cover state and fit-to-panel only
            // when automatic resize is explicitly allowed. This prevents group
            // changes (label clicks) from forcing a zoom-out. Callers that intend
            // to perform a reset (placeholder load, loading a new image) should
            // set `_allowAutoResize = true` before calling SetKingPortraitGroup
            // or calling the resize helpers directly.
            if (_allowAutoResize)
            {
                try
                {
                    ReplacePictureBoxImagesToDefault();
                    if (selection == PortraitGroupSelection.Medium)
                    {
                        FitPictureToPanel(PicKingMed, PanelKingMed);
                    }
                    else if (selection == PortraitGroupSelection.Small)
                    {
                        FitPictureToPanel(PicKingSml, PanelKingSml);
                    }
                    else if (selection == PortraitGroupSelection.Sml2)
                    {
                        FitPictureToPanel(PicKingSml2, PanelKingSml2);
                    }
                    else
                    {
                        // also ensure large has consistent zoom state
                        FitPictureToPanel(PicKingLrg, PanelKingLrg);
                    }
                }
                catch { }
            }
        }

        private void FitPictureToPanel(PictureBox pb, Panel panel)
        {
            if (pb == null || panel == null || pb.Image == null) return;

            // Determine original image stored or use current image as fallback
            Image original = GetOriginalImage(pb);
            if (original == null)
            {
                try { original = new Bitmap(pb.Image); }
                catch { return; }
            }

            int panelW = panel.ClientSize.Width;
            int panelH = panel.ClientSize.Height;
            if (panelW <= 0 || panelH <= 0) return;

            float imgAspect = (float)original.Width / original.Height;
            float panelAspect = (float)panelW / panelH;
            float minZoom = imgAspect > panelAspect
                ? (float)panelH / original.Height
                : (float)panelW / original.Width;

            int newW = Math.Max(1, (int)(original.Width * minZoom));
            int newH = Math.Max(1, (int)(original.Height * minZoom));

            Bitmap fitted = ImageControl.Direct.Resize(original, newW, newH);
            // dispose previous displayed image if it is not the original reference
            try { if (pb.Image != null && !object.ReferenceEquals(pb.Image, original)) pb.Image.Dispose(); } catch { }
            pb.Image = fitted;
            pb.Dock = DockStyle.None;
            pb.SizeMode = PictureBoxSizeMode.Normal;
            pb.Size = new Size(newW, newH);
            SetZoomLevel(pb, minZoom);
            // center the picture inside the panel
            pb.Location = new Point((panelW - pb.Width) / 2, (panelH - pb.Height) / 2);
        }

        private void ApplySmallLayoutReference()
        {
            if (LayoutKingPortraitGroupSmall == null) return;
            try
            {
                // Copy overall size so other groups align to small group area
                var refSize = LayoutKingPortraitGroupSmall.Size;
                LayoutKingPortraitGroupLarge.Size = refSize;
                if (LayoutKingPortraitGroupMedium != null)
                    LayoutKingPortraitGroupMedium.Size = refSize;
                if (LayoutKingPortraitGroupSml2 != null)
                    LayoutKingPortraitGroupSml2.Size = refSize;

                // Copy row styles (counts and heights)
                CopyRowStyles(LayoutKingPortraitGroupSmall, LayoutKingPortraitGroupLarge);
                if (LayoutKingPortraitGroupMedium != null)
                    CopyRowStyles(LayoutKingPortraitGroupSmall, LayoutKingPortraitGroupMedium);
                if (LayoutKingPortraitGroupSml2 != null)
                    CopyRowStyles(LayoutKingPortraitGroupSmall, LayoutKingPortraitGroupSml2);

                // Ensure button panels (which are table layout panels) have the same row styles
                CopyRowStyles(PanelKingSmlButtons, PanelKingLrgButtons);
                if (PanelKingMedButtons != null)
                    CopyRowStyles(PanelKingSmlButtons, PanelKingMedButtons);
                if (PanelKingSml2Buttons != null)
                    CopyRowStyles(PanelKingSmlButtons, PanelKingSml2Buttons);

                // Determine bottom row height in pixels if absolute
                int bottomHeight = 40; // fallback
                if (LayoutKingPortraitGroupSmall.RowCount > 0)
                {
                    var last = LayoutKingPortraitGroupSmall.RowStyles[LayoutKingPortraitGroupSmall.RowCount - 1];
                    if (last.SizeType == SizeType.Absolute)
                        bottomHeight = (int)Math.Max(1, last.Height);
                }

                // Apply bottom button heights and ensure consistent minimums
                var zoomButtons = new Button[] {
                    ButtonKingLrgZoomIn, ButtonKingLrgZoomOut, ButtonKingLrgZoomReset,
                    ButtonKingMedZoomIn, ButtonKingMedZoomOut, ButtonKingMedZoomReset,
                    ButtonKingSmlZoomIn, ButtonKingSmlZoomOut, ButtonKingSmlZoomReset,
                    ButtonKingSml2ZoomIn, ButtonKingSml2ZoomOut, ButtonKingSml2ZoomReset
                };
                foreach (var zb in zoomButtons)
                {
                    if (zb == null) continue;
                    zb.MinimumSize = new Size(0, bottomHeight);
                    zb.Height = bottomHeight;
                    zb.Dock = DockStyle.Fill;
                }

                var handCursorButtons = new Button[] {
                    ButtonKingLrgWeb, ButtonKingLrgLocal, ButtonKingLrgZoomIn, ButtonKingLrgZoomOut, ButtonKingLrgZoomReset,
                    ButtonKingMedWeb, ButtonKingMedLocal, ButtonKingMedZoomIn, ButtonKingMedZoomOut, ButtonKingMedZoomReset,
                    ButtonKingSmlWeb, ButtonKingSmlLocal, ButtonKingSmlZoomIn, ButtonKingSmlZoomOut, ButtonKingSmlZoomReset,
                    ButtonKingSml2Web, ButtonKingSml2Local, ButtonKingSml2ZoomIn, ButtonKingSml2ZoomOut, ButtonKingSml2ZoomReset
                };
                foreach (var b in handCursorButtons)
                {
                    if (b == null) continue;
                    b.Cursor = Cursors.Hand;
                }
            }
            catch { }
        }

        private void CopyRowStyles(TableLayoutPanel from, TableLayoutPanel to)
        {
            if (from == null || to == null) return;
            try
            {
                to.SuspendLayout();
                to.RowStyles.Clear();
                to.RowCount = from.RowCount;
                for (int i = 0; i < from.RowStyles.Count; i++)
                {
                    var rs = from.RowStyles[i];
                    var ns = new RowStyle(rs.SizeType, rs.Height);
                    to.RowStyles.Add(ns);
                }
            }
            catch { }
            finally { try { to.ResumeLayout(); } catch { } }
        }

        private void UpdatePortraitButtonsStyle()
        {
            Color selBack = Color.Black;
            Color selFore = Color.White;
            try { selBack = GameTypes[_gameSelected].BackColor; selFore = GameTypes[_gameSelected].ForeColor; } catch { }

            // Style hint labels above the Local/Web buttons — pick resource keys per game
            string lrgKey, medKey, smlKey, sml2Key;
            if (_gameSelected == 'r')
            {
                lrgKey = "HINT_RT_LRG";
                medKey = "HINT_RT_MED";
                smlKey = "HINT_RT_SML";
                sml2Key = null;
            }
            else if (_gameSelected == 'p' || _gameSelected == 't')
            {
                lrgKey = "HINT_PILLARS_LRG";
                medKey = null; // no medium for these games
                smlKey = "HINT_PILLARS_SML";
                sml2Key = null;
            }
            else if (_gameSelected == 'd')
            {
                lrgKey = "HINT_PILLARS_LRG";
                medKey = "HINT_PILLARS_MED";
                smlKey = "HINT_PILLARS_SML";
                sml2Key = "HINT_PILLARS_SML2";
            }
            else if (_gameSelected == 'l')
            {
                lrgKey = null; // no large for Wasteland 3
                medKey = null;
                smlKey = null; // set directly below
                sml2Key = null;
            }
            else
            {
                lrgKey = "HINT_KING_LRG";
                medKey = "HINT_KING_MED";
                smlKey = "HINT_KING_SML";
                sml2Key = null;
            }

            var hintLabels = new (System.Windows.Forms.Label lbl, string key)[]
            {
                (LabelKingLrgHint, lrgKey),
                (LabelKingMedHint, medKey),
                (LabelKingSmlHint, smlKey),
                (LabelKingSml2Hint, sml2Key),
            };
            foreach (var (lbl, key) in hintLabels)
            {
                if (lbl == null) continue;
                lbl.BackColor = selBack;
                lbl.ForeColor = selFore;
                lbl.TextAlign = ContentAlignment.TopLeft;
                try
                {
                    if (!string.IsNullOrEmpty(key))
                    {
                        var prop = typeof(TextVariables).GetProperty(key,
                            System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static |
                            System.Reflection.BindingFlags.NonPublic);
                        if (prop != null)
                        {
                            var val = prop.GetValue(null) as string;
                            if (!string.IsNullOrEmpty(val)) lbl.Text = val;
                        }
                    }
                }
                catch { }
            }

            // Wasteland 3: only Small exists at 256×256
            if (_gameSelected == 'l' && LabelKingSmlHint != null)
            {
                LabelKingSmlHint.Text = "Portrait (256×256) — used for character portraits.\n\nChoose a local image from your computer or select a web image from the internet. You can also drag-and-drop either a local image file or a web image link into this area.";
            }

            var buttons = new Button[] {
                ButtonKingLrgWeb, ButtonKingLrgLocal, ButtonKingLrgZoomIn, ButtonKingLrgZoomOut, ButtonKingLrgZoomReset,
                ButtonKingMedWeb, ButtonKingMedLocal, ButtonKingMedZoomIn, ButtonKingMedZoomOut, ButtonKingMedZoomReset,
                ButtonKingSmlWeb, ButtonKingSmlLocal, ButtonKingSmlZoomIn, ButtonKingSmlZoomOut, ButtonKingSmlZoomReset,
                ButtonKingSml2Web, ButtonKingSml2Local, ButtonKingSml2ZoomIn, ButtonKingSml2ZoomOut, ButtonKingSml2ZoomReset,
                ButtonKingCreateNewPortrait, ButtonKingBackToPathfinder
            };

            foreach (var btn in buttons)
            {
                if (btn == null) continue;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = selFore;
                btn.BackColor = selBack;
                btn.ForeColor = selFore;
                btn.FlatAppearance.MouseOverBackColor = selFore;
                btn.FlatAppearance.MouseDownBackColor = selFore;
                btn.TabStop = false;

                btn.MouseEnter -= PortraitButton_MouseEnter;
                btn.MouseLeave -= PortraitButton_MouseLeave;
                btn.GotFocus -= PortraitButton_GotFocus;
                btn.MouseEnter += PortraitButton_MouseEnter;
                btn.MouseLeave += PortraitButton_MouseLeave;
                btn.GotFocus += PortraitButton_GotFocus;
            }

        }
    }
}
