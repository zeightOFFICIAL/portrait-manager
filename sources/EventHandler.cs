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
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PortraitManager
{
    public partial class MainForm : Form
    {
        private static bool HasPortraitSpecific(GameType gameType, string key)
        {
            try
            {
                gameType.GetPortraitSpecific(key);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void ButtonKingAction_Create_Click(object sender, EventArgs e)
        {
            bool keepOnLayout = false;

            string basePath = CoreSettings.Default.GamePath;

            if (string.IsNullOrWhiteSpace(basePath) || !Directory.Exists(basePath))
            {
                using (var dlg = new forms.MyMessageDialog(TextVariables.MESG_GAMEPATH_NOT_SET))
                {
                    dlg.StartPosition = FormStartPosition.CenterParent;
                    dlg.ShowDialog(this);
                }

                return;
            }

            if (!GameTypes.TryGetValue(CoreSettings.Default.GameType, out GameType gameType))
            {
                using (var dlg = new forms.MyMessageDialog(TextVariables.MESG_UNSUPPORTED_GAMETYPE))
                {
                    dlg.StartPosition = FormStartPosition.CenterParent;
                    dlg.ShowDialog(this);
                }

                return;
            }

            bool isObsidian = _gameSelected == 'p' || _gameSelected == 'd' || _gameSelected == 't';
            bool isWasteland = _gameSelected == 'l';
            bool useUid = _gameSelected == 'p' || _gameSelected == 'd' || _gameSelected == 't' || _gameSelected == 'l';
            string uid = useUid ? (_gameSelected == 'l' || _gameSelected == 't' || _gameSelected == 'p' || _gameSelected == 'd' ? "PortraitManager - " : "portraitmanager_") + DateTime.Now.ToString("ssmmhh'_'ddMM", CultureInfo.InvariantCulture) : null;
            string femaleDir = null;

            string outDir = null;

            if (_isCustomNpcMode && string.IsNullOrEmpty(_overrideGallerySaveDir))
            {

                string customNpcDir = GetCustomNpcPortraitsDir(basePath);
                if (string.IsNullOrEmpty(customNpcDir)) return;
                try { Directory.CreateDirectory(customNpcDir); }
                catch (Exception ex)
                {
                    using (var dlg = new forms.MyMessageDialog(string.Format(TextVariables.MESG_FAILED_CREATE_CUSTOMNPC_ROOT, ex.Message)))
                    {
                        dlg.StartPosition = FormStartPosition.CenterParent;
                        dlg.ShowDialog(this);
                    }
                    return;
                }

                string baseName = "NPC_" + DateTime.Now.ToString("ssmmhh'_'ddMM", CultureInfo.InvariantCulture);
                string uniqueName = baseName;
                int suffix = 1;
                outDir = Path.Combine(customNpcDir, uniqueName);
                while (Directory.Exists(outDir))
                {
                    suffix++;
                    uniqueName = baseName + "_" + suffix.ToString(CultureInfo.InvariantCulture);
                    outDir = Path.Combine(customNpcDir, uniqueName);
                }

                try { Directory.CreateDirectory(outDir); }
                catch (Exception ex)
                {
                    using (var dlg = new forms.MyMessageDialog(string.Format(TextVariables.MESG_FAILED_CREATE_CUSTOMNPC_FOLDER, ex.Message)))
                    {
                        dlg.StartPosition = FormStartPosition.CenterParent;
                        dlg.ShowDialog(this);
                    }
                    return;
                }

                uid = null;
                femaleDir = null;
            }
            else if (isObsidian)
            {

                if (_gameSelected == 'p')
                    outDir = Path.Combine(basePath, "PillarsOfEternity_Data", "data", "art", "gui", "portraits", "player", "male");
                else if (_gameSelected == 'd')
                    outDir = Path.Combine(basePath, "PillarsOfEternityII_Data", "gui", "portraits", "player", "male");
                else
                    outDir = Path.Combine(basePath, "Data", "data", "art", "gui", "portraits", "player", "male");

                try { Directory.CreateDirectory(outDir); }
                catch (Exception ex)
                {
                    using (var dlg = new forms.MyMessageDialog(string.Format(TextVariables.MESG_FAILED_CREATE_PORTRAIT_FOLDER, ex.Message)))
                    {
                        dlg.StartPosition = FormStartPosition.CenterParent;
                        dlg.ShowDialog(this);
                    }
                    return;
                }

                if (useUid && !isWasteland)
                {
                    femaleDir = Path.Combine(Path.GetDirectoryName(outDir), "female");
                    try { Directory.CreateDirectory(femaleDir); }
                    catch (Exception ex)
                    {
                        using (var dlg = new forms.MyMessageDialog(string.Format(TextVariables.MESG_FAILED_CREATE_PORTRAIT_FOLDER, ex.Message)))
                        {
                            dlg.StartPosition = FormStartPosition.CenterParent;
                            dlg.ShowDialog(this);
                        }
                        return;
                    }
                }
            }
            else if (isWasteland)
            {

                outDir = Path.Combine(basePath, "Custom Portraits");
                try { Directory.CreateDirectory(outDir); }
                catch (Exception ex)
                {
                    using (var dlg = new forms.MyMessageDialog(string.Format(TextVariables.MESG_FAILED_CREATE_PORTRAIT_FOLDER, ex.Message)))
                    {
                        dlg.StartPosition = FormStartPosition.CenterParent;
                        dlg.ShowDialog(this);
                    }
                    return;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(_overrideGallerySaveDir))
                {

                    string portraitsRoot = basePath;
                    try
                    {
                        string last = new DirectoryInfo(basePath).Name;
                        if (!last.Equals("Portraits", StringComparison.OrdinalIgnoreCase))
                            portraitsRoot = Path.Combine(basePath, "Portraits");
                        Directory.CreateDirectory(portraitsRoot);
                    }
                    catch (Exception ex)
                    {
                        using (var dlg = new forms.MyMessageDialog(string.Format(TextVariables.MESG_FAILED_CREATE_PORTRAITS_ROOT, ex.Message)))
                        {
                            dlg.StartPosition = FormStartPosition.CenterParent;
                            dlg.ShowDialog(this);
                        }
                        return;
                    }

                    string baseName = (_gameSelected == 'k' || _gameSelected == 'w' || _gameSelected == 'r' ? "PortraitManager - " : "portraitmanager_") + DateTime.Now.ToString("ssmmhh'_'ddMM", CultureInfo.InvariantCulture);
                    string uniqueName = baseName;
                    int suffix = 1;
                    outDir = Path.Combine(portraitsRoot, uniqueName);
                    while (Directory.Exists(outDir))
                    {
                        uniqueName = baseName + "_" + suffix.ToString(CultureInfo.InvariantCulture);
                        outDir = Path.Combine(portraitsRoot, uniqueName);
                        suffix++;
                    }

                    try { Directory.CreateDirectory(outDir); }
                    catch (Exception ex)
                    {
                        using (var dlg = new forms.MyMessageDialog(string.Format(TextVariables.MESG_FAILED_CREATE_PORTRAIT_FOLDER, ex.Message)))
                        {
                            dlg.StartPosition = FormStartPosition.CenterParent;
                            dlg.ShowDialog(this);
                        }
                        return;
                    }
                }
            }

            if (!string.IsNullOrEmpty(_overrideGallerySaveDir))
            {
                if (_isCustomNpcMode)
                {
                    outDir = _overrideGallerySaveDir;
                    Directory.CreateDirectory(outDir);
                    uid = null;
                    femaleDir = null;
                }
                else if (isObsidian || isWasteland)
                {
                    uid = Path.GetFileName(_overrideGallerySaveDir);
                    if (_galleryTabSelected == "nonplayer")
                    {
                        outDir = Path.GetDirectoryName(_overrideGallerySaveDir);
                        Directory.CreateDirectory(outDir);
                        if (outDir.EndsWith("\\male", StringComparison.OrdinalIgnoreCase))
                        {
                            femaleDir = Path.Combine(Path.GetDirectoryName(outDir), "female");
                            Directory.CreateDirectory(femaleDir);
                        }
                        else
                        {
                            femaleDir = null;
                        }
                    }
                }
                else
                {
                    outDir = _overrideGallerySaveDir;
                }
                _overrideGallerySaveDir = null;
            }

            try
            {
                bool isObsidianOrWaste = isObsidian || isWasteland;

                string FileName(string sizeSuffix)
                {
                    if (uid != null)
                    {
                        if (isWasteland) return uid + ".png";
                        return uid + "_" + sizeSuffix + ".png";
                    }
                    if (isObsidianOrWaste) return "player_male_" + sizeSuffix + ".png";
                    if (sizeSuffix == "med") return "Medium.png";
                    if (sizeSuffix == "sm" || sizeSuffix == "sml") return "Small.png";
                    if (sizeSuffix == "si") return "Small.png";
                    return "Fulllength.png";
                }

                void SaveAndCopy(Image orig, PictureBox pb, Panel panel, int w, int h, string sizeSuffix)
                {
                    if (orig == null) return;
                    string fileName = FileName(sizeSuffix);
                    string savePath = Path.Combine(outDir, fileName);
                    if (_gameSelected == 'k' || _gameSelected == 'w' || _gameSelected == 'r')
                        ImageControl.PortraitCrop.SaveFillCrop(orig, pb, panel, w, h, savePath);
                    else
                        ImageControl.PortraitCrop.SaveUniformCrop(orig, pb, panel, w, h, savePath);
                    if (femaleDir != null)
                        File.Copy(savePath, Path.Combine(femaleDir, fileName), overwrite: true);
                }

                if (HasPortraitSpecific(gameType, "LARGE_WIDTH") &&
                    HasPortraitSpecific(gameType, "LARGE_HEIGHT"))
                {
                    SaveAndCopy(
                        _originalImageLrg ?? PicKingLrg.Image,
                        PicKingLrg, PanelKingLrg,
                        (int)gameType.GetPortraitSpecific("LARGE_WIDTH"),
                        (int)gameType.GetPortraitSpecific("LARGE_HEIGHT"),
                        "lg");
                }

                if (HasPortraitSpecific(gameType, "MEDIUM_WIDTH") &&
                    HasPortraitSpecific(gameType, "MEDIUM_HEIGHT"))
                {
                    string medSuffix = (_gameSelected == 'd') ? "convo" : "med";
                    SaveAndCopy(
                        _originalImageMed ?? PicKingMed.Image,
                        PicKingMed, PanelKingMed,
                        (int)gameType.GetPortraitSpecific("MEDIUM_WIDTH"),
                        (int)gameType.GetPortraitSpecific("MEDIUM_HEIGHT"),
                        medSuffix);
                }

                if (HasPortraitSpecific(gameType, "SMALL_WIDTH") &&
                    HasPortraitSpecific(gameType, "SMALL_HEIGHT"))
                {
                    SaveAndCopy(
                        _originalImageSml ?? PicKingSml.Image,
                        PicKingSml, PanelKingSml,
                        (int)gameType.GetPortraitSpecific("SMALL_WIDTH"),
                        (int)gameType.GetPortraitSpecific("SMALL_HEIGHT"),
                        "sm");
                }

                if (HasPortraitSpecific(gameType, "SML2_WIDTH") &&
                    HasPortraitSpecific(gameType, "SML2_HEIGHT"))
                {
                    SaveAndCopy(
                        _originalImageSml2 ?? PicKingSml2.Image,
                        PicKingSml2, PanelKingSml2,
                        (int)gameType.GetPortraitSpecific("SML2_WIDTH"),
                        (int)gameType.GetPortraitSpecific("SML2_HEIGHT"),
                        "si");
                }

                if (ValidateCreatedPortrait(outDir, uid, femaleDir))
                {
                    if (!string.IsNullOrWhiteSpace(outDir) && Directory.Exists(outDir))
                        new forms.MyCreationTooltip(outDir, uid).ShowAnchoredTo(this);

                    if (keepOnLayout)
                    {
                        RestoreKingPortraitEditorsToPlaceholder();
                    }
                    else
                    {
                        _activeMenuIndex = GetMainMenuIndexForCurrentGame();

                        ParentLayoutsDisable();
                        RootFunctions.LayoutEnable(LayoutMainPage);

                        PrepareKingCreatePortraitStyleState();

                        Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                using (var dlg = new forms.MyMessageDialog(string.Format(TextVariables.MESG_PORTRAIT_CREATION_ERROR, ex.Message)))
                {
                    dlg.StartPosition = FormStartPosition.CenterParent;
                    dlg.ShowDialog(this);
                }
            }
        }

        private void PicKing_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = e.Data.GetData(DataFormats.FileDrop) as string[];
                if (files != null && files.Length > 0)
                {
                    string ext = Path.GetExtension(files[0]).ToLowerInvariant();
                    if (ext == ".png" || ext == ".jpg" || ext == ".jpeg" ||
                        ext == ".bmp" || ext == ".gif" || ext == ".webp")
                    {
                        e.Effect = DragDropEffects.Copy;
                        ApplyDropTargetTint(sender as Control);
                        return;
                    }
                }
            }
            if (e.Data.GetDataPresent(DataFormats.Text) ||
                e.Data.GetDataPresent(DataFormats.UnicodeText))
            {
                e.Effect = DragDropEffects.Copy;
                ApplyDropTargetTint(sender as Control);
                return;
            }
            e.Effect = DragDropEffects.None;
        }

        private void PicKing_DragLeave(object sender, EventArgs e)
        {
            if (sender is Control ctrl && ctrl.ClientRectangle.Contains(ctrl.PointToClient(Cursor.Position)))
                return;
            RemoveDropTargetTint(sender as Control);
        }

        private void ApplyDropTargetTint(Control source)
        {
            var pic = GetPortraitPictureBox(source);
            if (pic == null) return;
            var panel = GetPortraitPanel(pic);
            if (panel == null) return;
            const string overlayTag = "_drop_overlay";

            var overlay = panel.Controls.OfType<Panel>()
                .FirstOrDefault(p => p.Tag is string t && t == overlayTag);

            if (overlay == null)
            {
                overlay = new Panel
                {
                    BackColor = Color.FromArgb(140, 0, 0, 0),
                    Dock = DockStyle.Fill,
                    Tag = overlayTag
                };

                var icon = new Label
                {
                    Text = "⬇",
                    Font = new Font(Font.FontFamily, 42, FontStyle.Bold),
                    ForeColor = Color.White,
                    BackColor = Color.Transparent,
                    AutoSize = true
                };
                overlay.Controls.Add(icon);
                overlay.Layout += (s, le) =>
                {
                    icon.Location = new Point(
                        (overlay.Width - icon.Width) / 2,
                        (overlay.Height - icon.Height) / 2);
                };

                overlay.AllowDrop = true;
                overlay.DragEnter += PicKing_DragEnter;
                overlay.DragLeave += PicKing_DragLeave;
                overlay.DragDrop += PicKing_DragDrop;

                panel.Controls.Add(overlay);
            }

            overlay.Visible = true;
            overlay.BringToFront();
        }

        private void RemoveDropTargetTint(Control source)
        {
            var pic = GetPortraitPictureBox(source);
            if (pic == null) return;
            var panel = GetPortraitPanel(pic);
            if (panel == null) return;
            const string overlayTag = "_drop_overlay";
            var overlay = panel.Controls.OfType<Panel>()
                .FirstOrDefault(p => p.Tag is string t && t == overlayTag);
            if (overlay != null)
                overlay.Visible = false;
        }

        private void PicKing_DragDrop(object sender, DragEventArgs e)
        {
            var pic = GetPortraitPictureBox(sender);
            if (pic == null) return;
            RemoveDropTargetTint(sender as Control);

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = e.Data.GetData(DataFormats.FileDrop) as string[];
                if (files != null && files.Length > 0 && File.Exists(files[0]))
                {
                    try
                    {
                        using (Image fileImg = Image.FromFile(files[0]))
                        {
                            StoreOriginalImage(pic, new Bitmap(fileImg));
                        }
                        FitImageToPanel(pic);
                        MarkGroupInitialized(pic);
                    }
                    catch { }
                }
                return;
            }

            string url = e.Data.GetData(DataFormats.UnicodeText) as string
                      ?? e.Data.GetData(DataFormats.Text) as string;
            if (string.IsNullOrWhiteSpace(url)) return;
            url = url.Trim();

            if ((!url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                 !url.StartsWith("https://", StringComparison.OrdinalIgnoreCase)) ||
                url.Length > 2048)
                return;
            foreach (char c in url)
                if (char.IsControl(c) || char.IsWhiteSpace(c)) return;

            try
            {
                var uri = new Uri(url);
                string path = uri.AbsolutePath;
                string ext = System.IO.Path.GetExtension(path).ToLowerInvariant();
                string[] imageExts = { ".png", ".jpg", ".jpeg", ".gif", ".bmp", ".webp" };
                if (!ext.Contains("") && Array.IndexOf(imageExts, ext) < 0)
                {
                    using (var dlg = new forms.MyMessageDialog(TextVariables.MESG_UNSUPPORTED_IMAGE_LINK))
                    {
                        dlg.StartPosition = FormStartPosition.CenterParent;
                        dlg.ShowDialog(this);
                    }
                    return;
                }
            }
            catch { }

            try
            {
                Image downloaded = null;
                string currentUrl = url;
                int redirects = 0;
                byte[] imageData = null;

                while (redirects < 10)
                {
                    var request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(currentUrl);
                    request.Timeout = 5000;
                    request.ReadWriteTimeout = 5000;
                    request.AllowAutoRedirect = false;
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36";

                    using (var response = (System.Net.HttpWebResponse)request.GetResponse())
                    {
                        int code = (int)response.StatusCode;

                        if (code >= 300 && code < 400 && code != 304)
                        {
                            string location = response.Headers["Location"];
                            if (string.IsNullOrWhiteSpace(location)) break;

                            currentUrl = new Uri(new Uri(currentUrl), location).AbsoluteUri;
                            redirects++;
                            continue;
                        }

                        string contentType = response.ContentType ?? "";
                        if (!contentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase) &&
                            !contentType.StartsWith("application/octet-stream", StringComparison.OrdinalIgnoreCase) &&
                            !string.IsNullOrEmpty(contentType) && !contentType.Contains("binary"))
                        {
                            return;
                        }

                        using (var stream = response.GetResponseStream())
                        using (var ms = new System.IO.MemoryStream())
                        {
                            stream.CopyTo(ms);
                            imageData = ms.ToArray();
                        }
                        break;
                    }
                }

                if (imageData == null || imageData.Length == 0) return;

                using (var ms = new System.IO.MemoryStream(imageData))
                using (var tmp = Image.FromStream(ms))
                {
                    downloaded = new Bitmap(tmp);
                }

                if (downloaded == null) return;

                StoreOriginalImage(pic, downloaded);
                FitImageToPanel(pic);
                MarkGroupInitialized(pic);
            }
            catch (Exception ex)
            {
                try
                {
                    using (var dlg = new forms.MyMessageDialog(string.Format(TextVariables.MESG_IMAGE_LOAD_FAILED, ex.Message)))
                    {
                        dlg.StartPosition = FormStartPosition.CenterParent;
                        dlg.ShowDialog(this);
                    }
                }
                catch { }
            }
        }

        private void MarkGroupInitialized(PictureBox pic)
        {
            if (pic == null) return;
            if (pic.Name == "PicKingLrg") _groupLrgInitialized = true;
            else if (pic.Name == "PicKingMed") _groupMedInitialized = true;
            else if (pic.Name == "PicKingSml") _groupSmlInitialized = true;
            else if (pic.Name == "PicKingSml2") _groupSml2Initialized = true;
        }

        private bool ValidateCreatedPortrait(string outDir, string uid = null, string femaleDir = null)
        {
            if (string.IsNullOrWhiteSpace(outDir) || !Directory.Exists(outDir))
                return false;

            if (!GameTypes.TryGetValue(CoreSettings.Default.GameType, out var gameType))
                return false;

            bool isObsidian = _gameSelected == 'p' || _gameSelected == 'd' || _gameSelected == 't';
            bool isWasteland = _gameSelected == 'l';
            bool obsidianNaming = isObsidian || isWasteland;

            string FileName(string sizeSuffix)
            {
                if (uid != null)
                {
                    if (isWasteland) return uid + ".png";
                    return uid + "_" + sizeSuffix + ".png";
                }
                if (obsidianNaming) return "player_male_" + sizeSuffix + ".png";
                if (sizeSuffix == "med") return "Medium.png";
                if (sizeSuffix == "sm" || sizeSuffix == "sml") return "Small.png";
                if (sizeSuffix == "si") return "Small.png";
                return "Fulllength.png";
            }

            string MedSuffix()
            {
                return (_gameSelected == 'd') ? "convo" : "med";
            }

            bool valid = true;

            if (HasPortraitSpecific(gameType, "LARGE_WIDTH") &&
                HasPortraitSpecific(gameType, "LARGE_HEIGHT"))
            {
                string name = FileName("lg");
                valid &= File.Exists(Path.Combine(outDir, name));
                if (femaleDir != null)
                    valid &= File.Exists(Path.Combine(femaleDir, name));
            }

            if (HasPortraitSpecific(gameType, "MEDIUM_WIDTH") &&
                HasPortraitSpecific(gameType, "MEDIUM_HEIGHT"))
            {
                string name = FileName(MedSuffix());
                valid &= File.Exists(Path.Combine(outDir, name));
                if (femaleDir != null)
                    valid &= File.Exists(Path.Combine(femaleDir, name));
            }

            if (HasPortraitSpecific(gameType, "SMALL_WIDTH") &&
                HasPortraitSpecific(gameType, "SMALL_HEIGHT"))
            {
                string name = FileName("sm");
                valid &= File.Exists(Path.Combine(outDir, name));
                if (femaleDir != null)
                    valid &= File.Exists(Path.Combine(femaleDir, name));
            }

            if (HasPortraitSpecific(gameType, "SML2_WIDTH") &&
                HasPortraitSpecific(gameType, "SML2_HEIGHT"))
            {
                string name = FileName("si");
                valid &= File.Exists(Path.Combine(outDir, name));
                if (femaleDir != null)
                    valid &= File.Exists(Path.Combine(femaleDir, name));
            }

            return valid;
        }

        private void RestoreKingPortraitEditorsToPlaceholder()
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gameType) || gameType.PlaceholderPortrait == null)
                return;

            try
            {
            StoreOriginalImage(PicKingLrg, new Bitmap(gameType.PlaceholderPortrait));
            StoreOriginalImage(PicKingSml, new Bitmap(gameType.PlaceholderPortrait));
            StoreOriginalImage(PicKingSml2, new Bitmap(gameType.PlaceholderPortrait));

            try { AdjustActivePortraitPanelAspect(PortraitGroupSelection.Large); } catch { }
            try { AdjustActivePortraitPanelAspect(PortraitGroupSelection.Small); } catch { }
            try { AdjustActivePortraitPanelAspect(PortraitGroupSelection.Sml2); } catch { }

            FitImageToPanel(PicKingLrg);
            FitImageToPanel(PicKingSml);
            FitImageToPanel(PicKingSml2);

            if (HasPortraitSpecific(gameType, "MEDIUM_WIDTH") &&
                HasPortraitSpecific(gameType, "MEDIUM_HEIGHT"))
            {
                StoreOriginalImage(PicKingMed, new Bitmap(gameType.PlaceholderPortrait));
                try { AdjustActivePortraitPanelAspect(PortraitGroupSelection.Medium); } catch { }
                FitImageToPanel(PicKingMed);
            }

                Focus();
            }
            catch
            {
            }
        }

        private void PicPortraitLrg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var pb = sender as PictureBox;
                if (pb == null) return;
                _mousePosition = e.Location;
                _pictureDragStart = pb.Location;
                _isDraggingMouse = 1;
            }
        }

        private void PicPortraitLrg_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDraggingMouse == 1)
            {
                var pb = sender as PictureBox;
                if (pb == null) return;
                var panel = GetPortraitPanel(pb);
                if (panel == null) return;

                int deltaX = e.X - _mousePosition.X;
                int deltaY = e.Y - _mousePosition.Y;
                var desired = new Point(pb.Location.X + deltaX, pb.Location.Y + deltaY);
                pb.Location = ClampPictureLocation(pb, panel, desired);
            }
        }

        private void PicPortraitLrg_MouseUp(object sender, MouseEventArgs e)
        {

            _isDraggingMouse = 0;
        }

        private void PicPortraitMed_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var pb = sender as PictureBox;
                if (pb == null) return;
                _mousePosition = e.Location;
                _pictureDragStart = pb.Location;
                _isDraggingMouse = 2;
            }
        }

        private void PicPortraitMed_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDraggingMouse == 2)
            {
                var pb = sender as PictureBox;
                if (pb == null) return;
                var panel = GetPortraitPanel(pb);
                if (panel == null) return;

                int deltaX = e.X - _mousePosition.X;
                int deltaY = e.Y - _mousePosition.Y;
                var desired = new Point(pb.Location.X + deltaX, pb.Location.Y + deltaY);
                pb.Location = ClampPictureLocation(pb, panel, desired);
            }
        }

        private void PicPortraitMed_MouseUp(object sender, MouseEventArgs e)
        {

            _isDraggingMouse = 0;
        }

        private void PicPortraitSml2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var pb = sender as PictureBox;
                if (pb == null) return;
                _mousePosition = e.Location;
                _pictureDragStart = pb.Location;
                _isDraggingMouse = 4;
            }
        }

        private void PicPortraitSml2_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDraggingMouse == 4)
            {
                var pb = sender as PictureBox;
                if (pb == null) return;
                var panel = GetPortraitPanel(pb);
                if (panel == null) return;

                int deltaX = e.X - _mousePosition.X;
                int deltaY = e.Y - _mousePosition.Y;
                var desired = new Point(pb.Location.X + deltaX, pb.Location.Y + deltaY);
                pb.Location = ClampPictureLocation(pb, panel, desired);
            }
        }

        private void PicPortraitSml2_MouseUp(object sender, MouseEventArgs e)
        {
            _isDraggingMouse = 0;
        }

        private void PicPortraitSml_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var pb = sender as PictureBox;
                if (pb == null) return;
                _mousePosition = e.Location;
                _pictureDragStart = pb.Location;
                _isDraggingMouse = 3;
            }
        }

        private void PicPortraitSml_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDraggingMouse == 3)
            {
                var pb = sender as PictureBox;
                if (pb == null) return;
                var panel = GetPortraitPanel(pb);
                if (panel == null) return;

                int deltaX = e.X - _mousePosition.X;
                int deltaY = e.Y - _mousePosition.Y;
                var desired = new Point(pb.Location.X + deltaX, pb.Location.Y + deltaY);
                pb.Location = ClampPictureLocation(pb, panel, desired);
            }
        }

        private void PicPortraitSml_MouseUp(object sender, MouseEventArgs e)
        {

            _isDraggingMouse = 0;
        }

        private Panel GetPortraitPanel(PictureBox pictureBox)
        {
            Control current = pictureBox?.Parent;
            while (current != null && !(current is Panel))
            {
                current = current.Parent;
            }

            return current as Panel;
        }

        private PictureBox GetPortraitPictureBox(object sender)
        {
            if (sender is PictureBox pictureBox)
                return pictureBox;

            if (sender is Panel panel)
            {
                var fromPanel = panel.Controls.OfType<PictureBox>().FirstOrDefault();
                if (fromPanel != null)
                    return fromPanel;

                if (panel.Parent is Panel parentPanel)
                    return parentPanel.Controls.OfType<PictureBox>().FirstOrDefault();
            }

            return null;
        }

        private Point ClampPictureLocation(PictureBox pictureBox, Panel panel, Point desired)
        {
            Rectangle bounds = panel.DisplayRectangle;

            int newX;
            if (pictureBox.Width <= bounds.Width)
            {
                newX = bounds.Left + (bounds.Width - pictureBox.Width) / 2;
            }
            else
            {
                int minX = bounds.Left + (bounds.Width - pictureBox.Width);
                newX = Math.Max(minX, Math.Min(bounds.Left, desired.X));
            }

            int newY;
            if (pictureBox.Height <= bounds.Height)
            {
                newY = bounds.Top + (bounds.Height - pictureBox.Height) / 2;
            }
            else
            {
                int minY = bounds.Top + (bounds.Height - pictureBox.Height);
                newY = Math.Max(minY, Math.Min(bounds.Top, desired.Y));
            }

            return new Point(newX, newY);
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            try { AdjustActivePortraitPanelAspect(_activeKingPortraitGroup); } catch { }
        }

        private void ButtonStartKing_MouseEnter(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.path_start_page;
            ButtonStartKing.ForeColor = Color.LimeGreen;
        }

        private void ButtonStartWotr_MouseEnter(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.wotr_start_page;
            ButtonStartWotr.ForeColor = Color.Magenta;
        }

        private void ButtonStartRt_MouseEnter(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.rt_start_page;
            ButtonStartRt.ForeColor = Color.DodgerBlue;
        }

        private void ButtonStartPoe_MouseEnter(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.poe_start_page;
            ButtonStartPoe.ForeColor = Color.Aqua;
        }

        private void ButtonStartPoed_MouseEnter(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.poed_start_page;
            ButtonStartPoed.ForeColor = Color.MediumSpringGreen;
        }

        private void ButtonStartTyr_MouseEnter(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.tyr_start_page;
            ButtonStartTyr.ForeColor = Color.Tomato;
        }

        private void ButtonStartW3_MouseEnter(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.waste_start_page;
            ButtonStartW3.ForeColor = Color.SteelBlue;
        }

        private void PictureBoxStartKing_MouseEnter(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.path_start_page;
            ButtonStartKing.ForeColor = Color.LimeGreen;
        }

        private void PictureBoxStartWotr_MouseEnter(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.wotr_start_page;
            ButtonStartWotr.ForeColor = Color.Magenta;
        }

        private void PictureBoxStartRt_MouseEnter(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.rt_start_page;
            ButtonStartRt.ForeColor = Color.DodgerBlue;
        }

        private void PictureBoxStartPoe_MouseEnter(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.poe_start_page;
            ButtonStartPoe.ForeColor = Color.Aqua;
        }

        private void PictureBoxStartPoed_MouseEnter(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.poed_start_page;
            ButtonStartPoed.ForeColor = Color.MediumSpringGreen;
        }

        private void PictureBoxStartTyr_MouseEnter(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.tyr_start_page;
            ButtonStartTyr.ForeColor = Color.Tomato;
        }

        private void PictureBoxStartW3_MouseEnter(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.waste_start_page;
            ButtonStartW3.ForeColor = Color.SteelBlue;
        }

        private void ButtonStartKing_MouseLeave(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.path_start_page;
            ButtonStartKing.ForeColor = Color.White;
        }

        private void ButtonStartWotr_MouseLeave(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.wotr_start_page;
            ButtonStartWotr.ForeColor = Color.White;
        }

        private void ButtonStartRt_MouseLeave(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.rt_start_page;
            ButtonStartRt.ForeColor = Color.White;
        }

        private void ButtonStartPoe_MouseLeave(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.poed_start_page;
            ButtonStartPoe.ForeColor = Color.White;
        }

        private void ButtonStartPoed_MouseLeave(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.poed_start_page;
            ButtonStartPoed.ForeColor = Color.White;
        }

        private void ButtonStartTyr_MouseLeave(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.tyr_start_page;
            ButtonStartTyr.ForeColor = Color.White;
        }

        private void ButtonStartW3_MouseLeave(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.waste_start_page;
            ButtonStartW3.ForeColor = Color.White;
        }

        private void PictureBoxStartKing_MouseLeave(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.path_start_page;
            ButtonStartKing.ForeColor = Color.White;
        }

        private void PictureBoxStartWotr_MouseLeave(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.wotr_start_page;
            ButtonStartWotr.ForeColor = Color.White;
        }

        private void PictureBoxStartRt_MouseLeave(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.rt_start_page;
            ButtonStartRt.ForeColor = Color.White;
        }

        private void PictureBoxStartPoe_MouseLeave(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.poed_start_page;
            ButtonStartPoe.ForeColor = Color.White;
        }

        private void PictureBoxStartPoed_MouseLeave(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.poed_start_page;
            ButtonStartPoed.ForeColor = Color.White;
        }

        private void PictureBoxStartTyr_MouseLeave(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.tyr_start_page;
            ButtonStartTyr.ForeColor = Color.White;
        }

        private void PictureBoxStartW3_MouseLeave(object sender, EventArgs e)
        {
            LayoutStartMenu.BackgroundImage = Resources.waste_start_page;
            ButtonStartW3.ForeColor = Color.White;
        }

        private void ButtonStartKing_Click(object sender, EventArgs e)
        {
            var font = LabelSelectPathTitle.Font;

            _gameSelected = 'k';
            LayoutPathPage.BackgroundImage = Resources.path_folder_page;
            LabelSelectPathTitle.Text = TextVariables.NAME_KING;
            LabelSelectPathExplain.Text = TextVariables.TEXT_EXPLAIN_PATH_KING;
            LabelSelectPathTitle.ForeColor = Color.LimeGreen;
            LabelSelectPathTitle.Font = new Font(font.FontFamily, 34, FontStyle.Regular);
            _activeMenuIndex = 150;

            OpenPathSelectPage();
        }

        private void PictureBoxStartKing_Click(object sender, EventArgs e)
        {
            var font = LabelSelectPathTitle.Font;

            _gameSelected = 'k';
            LayoutPathPage.BackgroundImage = Resources.path_folder_page;
            LabelSelectPathTitle.Text = TextVariables.NAME_KING;
            LabelSelectPathExplain.Text = TextVariables.TEXT_EXPLAIN_PATH_KING;
            LabelSelectPathTitle.ForeColor = Color.LimeGreen;
            LabelSelectPathTitle.Font = new Font(font.FontFamily, 34, FontStyle.Regular);
            _activeMenuIndex = 150;
            OpenPathSelectPage();
        }

        private void PictureBoxStartWotr_Click(object sender, EventArgs e)
        {
            var font = LabelSelectPathTitle.Font;

            _gameSelected = 'w';
            LayoutPathPage.BackgroundImage = Resources.wotr_folder_page;
            LabelSelectPathTitle.Text = TextVariables.NAME_WOTR;
            LabelSelectPathExplain.Text = TextVariables.TEXT_EXPLAIN_PATH_WOTR;
            LabelSelectPathTitle.ForeColor = Color.Magenta;
            LabelSelectPathTitle.Font = new Font(font.FontFamily, 22, FontStyle.Regular);
            _activeMenuIndex = 150;
            OpenPathSelectPage();
        }

        private void ButtonStartWotr_Click(object sender, EventArgs e)
        {
            var font = LabelSelectPathTitle.Font;

            _gameSelected = 'w';
            LayoutPathPage.BackgroundImage = Resources.wotr_folder_page;
            LabelSelectPathTitle.Text = TextVariables.NAME_WOTR;
            LabelSelectPathExplain.Text = TextVariables.TEXT_EXPLAIN_PATH_WOTR;
            LabelSelectPathTitle.ForeColor = Color.Magenta;
            LabelSelectPathTitle.Font = new Font(font.FontFamily, 22, FontStyle.Regular);
            _activeMenuIndex = 150;
            OpenPathSelectPage();
        }

        private void PictureBoxStartRt_Click(object sender, EventArgs e)
        {
            var font = LabelSelectPathTitle.Font;

            _gameSelected = 'r';
            LayoutPathPage.BackgroundImage = Resources.rt_folder_page;
            LabelSelectPathTitle.Text = TextVariables.NAME_ROGUE;
            LabelSelectPathExplain.Text = TextVariables.TEXT_EXPLAIN_PATH_ROGUE;
            LabelSelectPathTitle.ForeColor = Color.DodgerBlue;
            LabelSelectPathTitle.Font = new Font(font.FontFamily, 25, FontStyle.Regular);
            _activeMenuIndex = 150;
            OpenPathSelectPage();
        }

        private void ButtonStartRt_Click(object sender, EventArgs e)
        {
            var font = LabelSelectPathTitle.Font;

            _gameSelected = 'r';
            LayoutPathPage.BackgroundImage = Resources.rt_folder_page;
            LabelSelectPathTitle.Text = TextVariables.NAME_ROGUE;
            LabelSelectPathExplain.Text = TextVariables.TEXT_EXPLAIN_PATH_ROGUE;
            LabelSelectPathTitle.ForeColor = Color.DodgerBlue;
            LabelSelectPathTitle.Font = new Font(font.FontFamily, 25, FontStyle.Regular);
            _activeMenuIndex = 150;
            OpenPathSelectPage();
        }

        private void PictureBoxStartPoe_Click(object sender, EventArgs e)
        {
            var font = LabelSelectPathTitle.Font;

            _gameSelected = 'p';
            LayoutPathPage.BackgroundImage = Resources.poe_folder_page;
            LabelSelectPathTitle.Text = TextVariables.NAME_PILLARS;
            LabelSelectPathExplain.Text = TextVariables.TEXT_EXPLAIN_PATH_POE;
            LabelSelectPathTitle.ForeColor = Color.Aqua;
            LabelSelectPathTitle.Font = new Font(font.FontFamily, 34, FontStyle.Regular);
            _activeMenuIndex = 150;
            OpenPathSelectPage();
        }

        private void ButtonStartPoe_Click(object sender, EventArgs e)
        {
            var font = LabelSelectPathTitle.Font;

            _gameSelected = 'p';
            LayoutPathPage.BackgroundImage = Resources.poe_folder_page;
            LabelSelectPathTitle.Text = TextVariables.NAME_PILLARS;
            LabelSelectPathExplain.Text = TextVariables.TEXT_EXPLAIN_PATH_POE;
            LabelSelectPathTitle.ForeColor = Color.Aqua;
            LabelSelectPathTitle.Font = new Font(font.FontFamily, 34, FontStyle.Regular);
            _activeMenuIndex = 150;
            OpenPathSelectPage();
        }

        private void PictureBoxStartPoed_Click(object sender, EventArgs e)
        {
            var font = LabelSelectPathTitle.Font;

            _gameSelected = 'd';
            LayoutPathPage.BackgroundImage = Resources.poed_folder_page;
            LabelSelectPathTitle.Text = TextVariables.NAME_DEADFIRE;
            LabelSelectPathExplain.Text = TextVariables.TEXT_EXPLAIN_PATH_POED;
            LabelSelectPathTitle.ForeColor = Color.MediumSpringGreen;
            LabelSelectPathTitle.Font = new Font(font.FontFamily, 27, FontStyle.Regular);
            _activeMenuIndex = 150;
            OpenPathSelectPage();
        }

        private void ButtonStartPoed_Click(object sender, EventArgs e)
        {
            var font = LabelSelectPathTitle.Font;

            _gameSelected = 'd';
            LayoutPathPage.BackgroundImage = Resources.poed_folder_page;
            LabelSelectPathTitle.Text = TextVariables.NAME_DEADFIRE;
            LabelSelectPathExplain.Text = TextVariables.TEXT_EXPLAIN_PATH_POED;
            LabelSelectPathTitle.ForeColor = Color.MediumSpringGreen;
            LabelSelectPathTitle.Font = new Font(font.FontFamily, 27, FontStyle.Regular);
            _activeMenuIndex = 150;
            OpenPathSelectPage();
        }

        private void PictureBoxStartTyr_Click(object sender, EventArgs e)
        {
            var font = LabelSelectPathTitle.Font;

            _gameSelected = 't';
            LayoutPathPage.BackgroundImage = Resources.tyr_folder_page;
            LabelSelectPathTitle.Text = TextVariables.NAME_TYR;
            LabelSelectPathExplain.Text = TextVariables.TEXT_EXPLAIN_PATH_TYR;
            LabelSelectPathTitle.ForeColor = Color.Tomato;
            LabelSelectPathTitle.Font = new Font(font.FontFamily, 34, FontStyle.Regular);
            _activeMenuIndex = 150;
            OpenPathSelectPage();
        }

        private void ButtonStartTyr_Click(object sender, EventArgs e)
        {
            var font = LabelSelectPathTitle.Font;

            _gameSelected = 't';
            LayoutPathPage.BackgroundImage = Resources.tyr_folder_page;
            LabelSelectPathTitle.Text = TextVariables.NAME_TYR;
            LabelSelectPathExplain.Text = TextVariables.TEXT_EXPLAIN_PATH_TYR;
            LabelSelectPathTitle.ForeColor = Color.Tomato;
            LabelSelectPathTitle.Font = new Font(font.FontFamily, 34, FontStyle.Regular);
            _activeMenuIndex = 150;
            OpenPathSelectPage();
        }

        private void PictureBoxStartWaste_Click(object sender, EventArgs e)
        {
            var font = LabelSelectPathTitle.Font;

            _gameSelected = 'l';
            LayoutPathPage.BackgroundImage = Resources.waste_folder_page;
            LabelSelectPathTitle.Text = TextVariables.NAME_WASTE;
            LabelSelectPathExplain.Text = TextVariables.TEXT_EXPLAIN_PATH_WASTE;
            LabelSelectPathTitle.ForeColor = Color.SteelBlue;
            LabelSelectPathTitle.Font = new Font(font.FontFamily, 34, FontStyle.Regular);
            _activeMenuIndex = 150;
            OpenPathSelectPage();
        }

        private void ButtonStartWaste_Click(object sender, EventArgs e)
        {
            var font = LabelSelectPathTitle.Font;

            _gameSelected = 'l';
            LayoutPathPage.BackgroundImage = Resources.waste_folder_page;
            LabelSelectPathTitle.Text = TextVariables.NAME_WASTE;
            LabelSelectPathExplain.Text = TextVariables.TEXT_EXPLAIN_PATH_WASTE;
            LabelSelectPathTitle.ForeColor = Color.SteelBlue;
            LabelSelectPathTitle.Font = new Font(font.FontFamily, 34, FontStyle.Regular);
            _activeMenuIndex = 150;
            OpenPathSelectPage();
        }

        private void LabelSelectPathResetPath_MouseEnter(object sender, EventArgs e)
        {
            LabelSelectPathResetPath.ForeColor = LabelSelectPathTitle.ForeColor;
        }

        private void LabelSelectPathResetPath_MouseLeave(object sender, EventArgs e)
        {
            LabelSelectPathResetPath.ForeColor = Color.White;
        }

        private void LabelSelectPathChoosePath_MouseEnter(object sender, EventArgs e)
        {
            LabelSelectPathChoosePath.ForeColor = LabelSelectPathTitle.ForeColor;
        }

        private void LabelSelectPathChoosePath_MouseLeave(object sender, EventArgs e)
        {
            LabelSelectPathChoosePath.ForeColor = Color.White;
        }

        private void LabelSelectPathTitle_MouseEnter(object sender, EventArgs e)
        {

        }

        private void LabelSelectPathTitle_MouseLeave(object sender, EventArgs e)
        {

        }

        private void LabelSelectPathBackToStart_MouseEnter(object sender, EventArgs e)
        {
            LabelSelectPathBackToStart.ForeColor = LabelSelectPathTitle.ForeColor;
        }

        private void LabelSelectPathBackToStart_MouseLeave(object sender, EventArgs e)
        {
            LabelSelectPathBackToStart.ForeColor = Color.White;
        }

        private void LabelSelectPathNextToMain_MouseEnter(object sender, EventArgs e)
        {
            LabelSelectPathNextToMain.ForeColor = LabelSelectPathTitle.ForeColor;
        }

        private void LabelSelectPathNextToMain_MouseLeave(object sender, EventArgs e)
        {
            LabelSelectPathNextToMain.ForeColor = Color.White;
        }

        private void LabelSelectPathResetPath_Click(object sender, EventArgs e)
        {
            LabelSelectPathSelected.Text = GameTypes[_gameSelected].DefaultDirectory.ToLower();
            if (LabelSelectPathSelected.Text == "")
            {
                LabelSelectPathSelected.Text = TextVariables.TEXT_PATH_PLACEHOLDER;
            }
        }

        private void LabelSelectPathSelected_MouseEnter(object sender, EventArgs e)
        {
            LabelSelectPathSelected.ForeColor = Color.White;
        }

        private void LabelSelectPathSelected_MouseLeave(object sender, EventArgs e)
        {
            LabelSelectPathSelected.ForeColor = Color.DarkGray;
        }

        private void LabelSelectPathBackToStart_Click(object sender, EventArgs e)
        {
            _gameSelected = '-';
            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutStartMenu);
            _activeMenuIndex = 0;
        }

        private void PictureBoxStartOpenNexus_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://next.nexusmods.com/profile/zeightOFFICIAL/mods", UseShellExecute = true });
        }

        private void PictureBoxStartOpenGithub_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://github.com/zeightOFFICIAL/portrait-manager/", UseShellExecute = true });
        }

        private void LabelCreatePortrait_MouseEnter(object sender, EventArgs e)
        {
            LabelCreatePortrait.Text = TextVariables.MENU_HOVER_MARKER + LabelCreatePortrait.Text;
            LabelCreatePortrait.ForeColor = GameTypes[_gameSelected].ForeColor;
        }

        private void LabelCreatePortrait_MouseLeave(object sender, EventArgs e)
        {
            LabelCreatePortrait.Text = LabelCreatePortrait.Text.Replace(TextVariables.MENU_HOVER_MARKER, "");
            LabelCreatePortrait.ForeColor = Color.White;
        }

        private void LabelExtract_MouseEnter(object sender, EventArgs e)
        {
            LabelExtract.Text = TextVariables.MENU_HOVER_MARKER + LabelExtract.Text;
            LabelExtract.ForeColor = GameTypes[_gameSelected].ForeColor;
        }

        private void LabelExtract_MouseLeave(object sender, EventArgs e)
        {
            LabelExtract.Text = LabelExtract.Text.Replace(TextVariables.MENU_HOVER_MARKER, "");
            LabelExtract.ForeColor = Color.White;
        }

        private void LabelBrowse_MouseEnter(object sender, EventArgs e)
        {
            LabelBrowse.Text = TextVariables.MENU_HOVER_MARKER + LabelBrowse.Text;
            LabelBrowse.ForeColor = GameTypes[_gameSelected].ForeColor;
        }

        private void LabelBrowse_MouseLeave(object sender, EventArgs e)
        {
            LabelBrowse.Text = LabelBrowse.Text.Replace(TextVariables.MENU_HOVER_MARKER, "");
            LabelBrowse.ForeColor = Color.White;
        }

        private void LabelSettingsPage_Click(object sender, EventArgs e)
        {
            _gameSelected = '-';
            CoreSettings.Default.GameType = '-';
            CoreSettings.Default.Save();
            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutStartMenu);
            _activeMenuIndex = 0;
        }

        private void LabelSettingsPage_MouseEnter(object sender, EventArgs e)
        {
            LabelSettingsPage.Text = TextVariables.MENU_HOVER_MARKER + LabelSettingsPage.Text;
            LabelSettingsPage.ForeColor = GameTypes[_gameSelected].ForeColor;
        }

        private void LabelSettingsPage_MouseLeave(object sender, EventArgs e)
        {
            LabelSettingsPage.Text = LabelSettingsPage.Text.Replace(TextVariables.MENU_HOVER_MARKER, "");
            LabelSettingsPage.ForeColor = Color.White;
        }

        private void LabelExit_MouseEnter(object sender, EventArgs e)
        {
            LabelExit.Text = TextVariables.MENU_HOVER_MARKER + LabelExit.Text;
            LabelExit.ForeColor = GameTypes[_gameSelected].ForeColor;
        }

        private void LabelExit_MouseLeave(object sender, EventArgs e)
        {
            LabelExit.Text = LabelExit.Text.Replace(TextVariables.MENU_HOVER_MARKER, "");
            LabelExit.ForeColor = Color.White;
        }

        private void LabelExit_Click(object sender, EventArgs e)
        {
            SystemControl.FileControl.ClearTempImages();
            Dispose();
            Application.Exit();
        }

        private void ButtonExtractBack_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = GetMainMenuIndexForCurrentGame();
            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutMainPage);
            Focus();
        }

        private void ButtonExtractAll_MouseEnter(object sender, EventArgs e)
        {
            Color back;
            try { back = GameTypes[_gameSelected].BackColor; } catch { back = Color.Black; }
            ButtonExtractAll.ForeColor = back;
        }

        private void ButtonExtractAll_MouseLeave(object sender, EventArgs e)
        {
            Color fore;
            try { fore = GameTypes[_gameSelected].ForeColor; } catch { fore = Color.White; }
            ButtonExtractAll.ForeColor = fore;
        }

        private void ButtonExtractSelected_MouseEnter(object sender, EventArgs e)
        {
            Color back;
            try { back = GameTypes[_gameSelected].BackColor; } catch { back = Color.Black; }
            ButtonExtractSelected.ForeColor = back;
        }

        private void ButtonExtractSelected_MouseLeave(object sender, EventArgs e)
        {
            Color fore;
            try { fore = GameTypes[_gameSelected].ForeColor; } catch { fore = Color.White; }
            ButtonExtractSelected.ForeColor = fore;
        }

        private void ButtonExtractBack_MouseEnter(object sender, EventArgs e)
        {
            Color back;
            try { back = GameTypes[_gameSelected].BackColor; } catch { back = Color.Black; }
            ButtonExtractBack.ForeColor = back;
        }

        private void ButtonExtractBack_MouseLeave(object sender, EventArgs e)
        {
            Color fore;
            try { fore = GameTypes[_gameSelected].ForeColor; } catch { fore = Color.White; }
            ButtonExtractBack.ForeColor = fore;
        }

        private void ButtonExtractShowFolder_Click(object sender, EventArgs e)
        {
            string gameDir = GetGameDirectory();

            if (_archiveEntries != null && _archiveEntries.Count > 0)
            {
                string archiveDir = Path.GetDirectoryName(_selectedArchivePath);
                bool any = false;

                if (!string.IsNullOrEmpty(archiveDir))
                {
                    try { Directory.CreateDirectory(archiveDir); } catch { }
                    Process.Start("explorer.exe", archiveDir);
                    any = true;
                }

                if (!string.IsNullOrEmpty(gameDir))
                {
                    Process.Start("explorer.exe", gameDir);
                    any = true;
                }

                if (!any)
                {
                    using (var msg = new MyMessageDialog(TextVariables.MESG_FOLDER_LOCATION_UNKNOWN))
                    {
                        msg.StartPosition = FormStartPosition.CenterParent;
                        msg.ShowDialog(this);
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(gameDir))
                {
                    using (var msg = new MyMessageDialog(TextVariables.MESG_GAME_DIRECTORY_UNKNOWN))
                    {
                        msg.StartPosition = FormStartPosition.CenterParent;
                        msg.ShowDialog(this);
                    }
                    return;
                }

                Process.Start("explorer.exe", gameDir);
            }
        }

        private void ButtonExtractShowFolder_MouseEnter(object sender, EventArgs e)
        {
            Color back;
            try { back = GameTypes[_gameSelected].BackColor; } catch { back = Color.Black; }
            ButtonExtractShowFolder.ForeColor = back;
        }

        private void ButtonExtractShowFolder_MouseLeave(object sender, EventArgs e)
        {
            Color fore;
            try { fore = GameTypes[_gameSelected].ForeColor; } catch { fore = Color.White; }
            ButtonExtractShowFolder.ForeColor = fore;
        }

        private void PanelExtractOverlay_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    fbd.Description = "Select portrait pack folder";
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        LoadArchiveThumbnails(fbd.SelectedPath);
                    }
                }
            }
            else
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Title = "Select portrait archive";
                    ofd.Filter = "Archive files (*.zip;*.7z;*.rar)|*.zip;*.7z;*.rar|All files (*.*)|*.*";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        LoadArchiveThumbnails(ofd.FileName);
                    }
                }
            }
        }

        private void ButtonExtractAll_Click(object sender, EventArgs e)
        {
            if (_archiveEntries == null || _archiveEntries.Count == 0) return;
            if (ExtractPortraitsFromArchive(null))
                NavigateToMainPage();
        }

        private void ButtonExtractSelected_Click(object sender, EventArgs e)
        {
            var selected = FlowLayoutPanelExtract.Controls.OfType<CheckBox>()
                .Where(cb => cb.Checked)
                .Select(cb => cb.Tag as string)
                .Where(t => t != null)
                .ToList();

            if (selected.Count == 0)
            {
                using (var msg = new MyMessageDialog(TextVariables.MESG_EXTRACT_NOSELECTION))
                {
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog(this);
                }
                return;
            }

            if (ExtractPortraitsFromArchive(selected))
                NavigateToMainPage();
        }

        private void LabelExtractClearSelection_Click(object sender, EventArgs e)
        {
            foreach (Control c in FlowLayoutPanelExtract.Controls)
            {
                if (c is CheckBox cb)
                    cb.Checked = false;
            }
        }

        private void LabelExtractClearSelection_MouseEnter(object sender, EventArgs e)
        {
            try { LabelExtractClearSelection.ForeColor = GameTypes[_gameSelected].ForeColor; }
            catch { LabelExtractClearSelection.ForeColor = Color.White; }
        }

        private void LabelExtractClearSelection_MouseLeave(object sender, EventArgs e)
        {
            LabelExtractClearSelection.ForeColor = Color.White;
        }

        private void LabelExtractClose_Click(object sender, EventArgs e)
        {
            _selectedArchivePath = null;
            ClearArchiveEntries();
            CleanupShellTempDir();
            FlowLayoutPanelExtract.Visible = false;
            PanelExtractOverlay.Visible = true;
            FlowLayoutPanelExtractBottom.Visible = false;
            ButtonExtractAll.Visible = false;
            ButtonExtractSelected.Visible = false;
            ButtonExtractShowFolder.Visible = true;
            ButtonExtractShowFolder.Text = TextVariables.BUTTON_EXTRACT_OPENFOLDER;
            ButtonExtractBack.Visible = true;
            LayoutExtractRight.RowStyles[0].Height = 0;
            LayoutExtractRight.RowStyles[1].Height = 0;
            LayoutExtractRight.RowStyles[2].Height = 70;
            LayoutExtractRight.RowStyles[3].Height = 30;
            _overlayHovered = false;
            Focus();
        }

        private void LabelExtractClose_MouseEnter(object sender, EventArgs e)
        {
            try { LabelExtractClose.ForeColor = GameTypes[_gameSelected].ForeColor; }
            catch { LabelExtractClose.ForeColor = Color.White; }
        }

        private void LabelExtractClose_MouseLeave(object sender, EventArgs e)
        {
            LabelExtractClose.ForeColor = Color.White;
        }

        private void LabelMainPageFooter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string target = e.Link.LinkData as string;
            if (target == "github")
                System.Diagnostics.Process.Start("https://github.com/zeightOFFICIAL/portrait-manager");
            else if (target == "nexus")
                System.Diagnostics.Process.Start("https://next.nexusmods.com/profile/zeightOFFICIAL/mods");
        }

        private void ButtonKingSelectWebModal_Click(object sender, EventArgs e)
        {
            if (!(sender is System.Windows.Forms.Button btn)) return;

            using (forms.MyWebDialog dlg = new forms.MyWebDialog())
            {
                dlg.StartPosition = FormStartPosition.CenterParent;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    var img = dlg.DownloadedImage;
                    if (img == null) return;

                    string tag = btn.Tag as string;
                    if (tag == "PicKingLrg")
                    {
                        StoreOriginalImage(PicKingLrg, new Bitmap(img));
                        FitImageToPanel(PicKingLrg);
                        _groupLrgInitialized = true;
                    }
                    else if (tag == "PicKingMed")
                    {
                        StoreOriginalImage(PicKingMed, new Bitmap(img));
                        FitImageToPanel(PicKingMed);
                        _groupMedInitialized = true;
                    }
                    else if (tag == "PicKingSml")
                    {
                        StoreOriginalImage(PicKingSml, new Bitmap(img));
                        FitImageToPanel(PicKingSml);
                        _groupSmlInitialized = true;
                    }
                    else if (tag == "PicKingSml2")
                    {
                        StoreOriginalImage(PicKingSml2, new Bitmap(img));
                        FitImageToPanel(PicKingSml2);
                        _groupSml2Initialized = true;
                    }
                    img.Dispose();
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FontInit();
            TextInit();
            _activeMenuIndex = 65535;
            SetClientSizeCore(750, 520);
            CenterToScreen();
            ParentLayoutsSetDockFill();
            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutStartMenu);
            LabelSelectPathSelected.Text = CoreSettings.Default.GamePath;

            if (CoreSettings.Default.GameType == '-')
            {
                _gameSelected = '-';
                RootFunctions.LayoutEnable(LayoutStartMenu);
                _activeMenuIndex = 100;
            }
            else if (CoreSettings.Default.GameType == 'w')
            {
                _gameSelected = 'w';
                _activeMenuIndex = 202;
                LabelSelectPathNextToMain_Click(sender, e);

            }
            else if (CoreSettings.Default.GameType == 'r')
            {
                _gameSelected = 'r';
                _activeMenuIndex = 203;
                LabelSelectPathNextToMain_Click(sender, e);
            }
            else if (CoreSettings.Default.GameType == 'p')
            {
                _gameSelected = 'p';
                _activeMenuIndex = 204;
                LabelSelectPathNextToMain_Click(sender, e);
            }
            else if (CoreSettings.Default.GameType == 'd')
            {
                _gameSelected = 'd';
                _activeMenuIndex = 205;
                LabelSelectPathNextToMain_Click(sender, e);
            }
            else if (CoreSettings.Default.GameType == 't')
            {
                _gameSelected = 't';
                _activeMenuIndex = 206;
                LabelSelectPathNextToMain_Click(sender, e);
            }
            else if (CoreSettings.Default.GameType == 'l')
            {
                _gameSelected = 'l';
                _activeMenuIndex = 207;
                LabelSelectPathNextToMain_Click(sender, e);
            }
            else
            {
                _gameSelected = 'k';
                _activeMenuIndex = 201;
                LabelSelectPathNextToMain_Click(sender, e);
            }

            Focus();
            SetKingPortraitGroup(PortraitGroupSelection.Large);
            _allowAutoResize = true;
            ReplacePictureBoxImagesToDefault();
            _allowAutoResize = false;

            Focus();
            ApplyGameWindowStyle();
        }

        private void LabelKingCreatePortrait_Paint(object sender, PaintEventArgs e)
        {
            if (!(sender is Label lbl)) return;
            bool isSelected = false;
            if (lbl.Name == "LabelKingCreatePortraitLarge") isSelected = _activeKingPortraitGroup == PortraitGroupSelection.Large;
            else if (lbl.Name == "LabelKingCreatePortraitMedium") isSelected = _activeKingPortraitGroup == PortraitGroupSelection.Medium;
            else if (lbl.Name == "LabelKingCreatePortraitSmall") isSelected = _activeKingPortraitGroup == PortraitGroupSelection.Small;
            else if (lbl.Name == "LabelKingCreatePortraitSml2") isSelected = _activeKingPortraitGroup == PortraitGroupSelection.Sml2;
            if (!isSelected) return;

            Color penColor = Color.White;
            try { penColor = GameTypes[_gameSelected].ForeColor; } catch { penColor = lbl.ForeColor; }
            using (var pen = new Pen(penColor))
            {
                int w = lbl.ClientSize.Width;
                int h = lbl.ClientSize.Height;
                e.Graphics.DrawLine(pen, 0, 0, w - 1, 0);
                e.Graphics.DrawLine(pen, 0, 0, 0, h - 1);
                e.Graphics.DrawLine(pen, w - 1, 0, w - 1, h - 1);
            }
        }

        private void LayoutKingPortraitGroupLarge_Paint(object sender, PaintEventArgs e)
        {
            DrawGroupBorder(sender as Control, e, LabelKingCreatePortraitLarge);
        }

        private void LayoutKingPortraitGroupMedium_Paint(object sender, PaintEventArgs e)
        {
            DrawGroupBorder(sender as Control, e, LabelKingCreatePortraitMedium);
        }

        private void LayoutKingPortraitGroupSmall_Paint(object sender, PaintEventArgs e)
        {
            DrawGroupBorder(sender as Control, e, LabelKingCreatePortraitSmall);
        }

        private void LayoutKingPortraitGroupSml2_Paint(object sender, PaintEventArgs e)
        {
            DrawGroupBorder(sender as Control, e, LabelKingCreatePortraitSml2);
        }

        private void LayoutKingRight_Paint(object sender, PaintEventArgs e)
        {
            DrawGroupBorder(sender as Control, e, null);
        }

        private void LabelExtract_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 5;

            Color gameBack, gameFore;
            try { gameBack = GameTypes[_gameSelected].BackColor; gameFore = GameTypes[_gameSelected].ForeColor; }
            catch { gameBack = Color.FromArgb(12, 12, 12); gameFore = Color.White; }

            PanelExtractContainer.BackColor = gameBack;
            PanelExtractOverlay.BackColor = gameBack;
            LayoutExtractRight.BackColor = gameBack;
            LayoutExtractRight.ForeColor = gameFore;
            _overlayHovered = false;

            foreach (var btn in new[] { ButtonExtractAll, ButtonExtractSelected, ButtonExtractShowFolder, ButtonExtractBack })
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = gameFore;
                btn.BackColor = gameBack;
                btn.ForeColor = gameFore;
                btn.FlatAppearance.MouseOverBackColor = gameFore;
                btn.FlatAppearance.MouseDownBackColor = gameFore;
                btn.TabStop = false;
            }

            ButtonExtractAll.Visible = false;
            ButtonExtractSelected.Visible = false;
            ButtonExtractShowFolder.Visible = true;
            ButtonExtractShowFolder.Text = TextVariables.BUTTON_EXTRACT_OPENFOLDER;
            ButtonExtractBack.Visible = true;
            LayoutExtractRight.RowStyles[0].Height = 0;
            LayoutExtractRight.RowStyles[1].Height = 0;
            LayoutExtractRight.RowStyles[2].Height = 70;
            LayoutExtractRight.RowStyles[3].Height = 30;

            _selectedArchivePath = null;
            ClearArchiveEntries();
            CleanupShellTempDir();
            FlowLayoutPanelExtract.Visible = false;
            PanelExtractOverlay.Visible = true;
            FlowLayoutPanelExtractBottom.Visible = false;

            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutExtractPage);
            Focus();
        }

        private void LabelBrowse_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 6;
            _selectedGalleryEntry = null;
            _galleryTabSelected = "player";
            _isCustomNpcMode = false;

            Color gameBack, gameFore;
            try { gameBack = GameTypes[_gameSelected].BackColor; gameFore = GameTypes[_gameSelected].ForeColor; }
            catch { gameBack = Color.FromArgb(12, 12, 12); gameFore = Color.White; }

            LabelGalleryNonPlayerTab.Visible = _gameSelected == 't' || _gameSelected == 'p' || _gameSelected == 'd';

            LabelGalleryNonPlayerTab.Text = _gameSelected == 't' || _gameSelected == 'p' || _gameSelected == 'd'
                ? TextVariables.LABEL_GALLERY_COMPANIONS
                : TextVariables.LABEL_GALLERY_NONPLAYER;

            // Retired: fully superseded by the Characters tab (which now covers everything this
            // tab used to show for Kingmaker/WotR) and never applicable to any other game.
            LabelGalleryCustomNpcTab.Visible = false;

            bool hasCustomNpc = _gameSelected == 'k' || _gameSelected == 'w';
            LabelGalleryCompanionsTab.Visible = hasCustomNpc;
            LabelGalleryCharactersTab.Visible = hasCustomNpc;
            UpdateGalleryTabVisuals();
            PanelGalleryContainer.BackColor = gameBack;
            FlowLayoutPanelGallery.BackColor = gameBack;

            ButtonGalleryBack.FlatStyle = FlatStyle.Flat;
            ButtonGalleryBack.FlatAppearance.BorderSize = 1;
            ButtonGalleryBack.FlatAppearance.BorderColor = gameFore;
            ButtonGalleryBack.BackColor = gameBack;
            ButtonGalleryBack.ForeColor = gameFore;
            ButtonGalleryBack.FlatAppearance.MouseOverBackColor = gameFore;
            ButtonGalleryBack.FlatAppearance.MouseDownBackColor = gameFore;
            ButtonGalleryBack.TabStop = false;

            ButtonGalleryClone.FlatStyle = FlatStyle.Flat;
            ButtonGalleryClone.FlatAppearance.BorderSize = 1;
            ButtonGalleryClone.FlatAppearance.BorderColor = gameFore;
            ButtonGalleryClone.BackColor = gameBack;
            ButtonGalleryClone.ForeColor = gameFore;
            ButtonGalleryClone.FlatAppearance.MouseOverBackColor = gameFore;
            ButtonGalleryClone.FlatAppearance.MouseDownBackColor = gameFore;
            ButtonGalleryClone.TabStop = false;

            ButtonGalleryChange.FlatStyle = FlatStyle.Flat;
            ButtonGalleryChange.FlatAppearance.BorderSize = 1;
            ButtonGalleryChange.FlatAppearance.BorderColor = gameFore;
            ButtonGalleryChange.BackColor = gameBack;
            ButtonGalleryChange.ForeColor = gameFore;
            ButtonGalleryChange.FlatAppearance.MouseOverBackColor = gameFore;
            ButtonGalleryChange.FlatAppearance.MouseDownBackColor = gameFore;
            ButtonGalleryChange.TabStop = false;

            ButtonGalleryDelete.FlatStyle = FlatStyle.Flat;
            ButtonGalleryDelete.FlatAppearance.BorderSize = 1;
            ButtonGalleryDelete.FlatAppearance.BorderColor = gameFore;
            ButtonGalleryDelete.BackColor = gameBack;
            ButtonGalleryDelete.ForeColor = gameFore;
            ButtonGalleryDelete.FlatAppearance.MouseOverBackColor = gameFore;
            ButtonGalleryDelete.FlatAppearance.MouseDownBackColor = gameFore;
            ButtonGalleryDelete.TabStop = false;

            ButtonGalleryShowFolder.FlatStyle = FlatStyle.Flat;
            ButtonGalleryShowFolder.FlatAppearance.BorderSize = 1;
            ButtonGalleryShowFolder.FlatAppearance.BorderColor = gameFore;
            ButtonGalleryShowFolder.BackColor = gameBack;
            ButtonGalleryShowFolder.ForeColor = gameFore;
            ButtonGalleryShowFolder.FlatAppearance.MouseOverBackColor = gameFore;
            ButtonGalleryShowFolder.FlatAppearance.MouseDownBackColor = gameFore;
            ButtonGalleryShowFolder.TabStop = false;

            _cancellationTokenSource?.Cancel();
            ClearGalleryEntries();
            LoadGalleryImages();
            UpdateGalleryRightPanel();

            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutGalleryPage);
            Focus();
        }

        private void ButtonGalleryClone_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedGalleryEntry)) return;
            _overrideGallerySaveDir = null;
            _isCustomNpcMode = _galleryTabSelected == "customnpc";
            LabelCreatePortrait_Click(sender, e);
            LoadGalleryImageIntoCreatePage(_selectedGalleryEntry);
        }

        private void ButtonGalleryChange_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedGalleryEntry)) return;

            bool restoreBackup = false;
            bool restoreOwnBackup = false;
            bool isNonPlayer = _galleryTabSelected == "nonplayer" && (_gameSelected == 't' || _gameSelected == 'p' || _gameSelected == 'd');
            bool isCompanionOrCharacter = _galleryTabSelected == "companions" || _galleryTabSelected == "characters";

            if (isNonPlayer)
            {
                bool hadExistingBackup = BackupNonPlayerPortraitSet(_selectedGalleryEntry);
                if (hadExistingBackup)
                {
                    using (var dlg = new forms.MyInquiryDialog(TextVariables.MESG_RESTORE_BACKUP_PROMPT, useYesNo: true))
                    {
                        if (dlg.ShowDialog(this) == DialogResult.OK)
                            restoreBackup = true;
                    }
                }
            }
            else if (isCompanionOrCharacter)
            {
                // Our own backup (the portrait as it was just before this change) takes priority
                // over the mod's default-portrait backup once one exists, since it's the more
                // useful revert target; the mod's original-default backup remains the fallback
                // for a portrait's very first customization, when we have no backup of our own yet.
                bool hadExistingBackup = BackupCompanionPortraitSet(_selectedGalleryEntry);
                if (hadExistingBackup)
                {
                    using (var dlg = new forms.MyInquiryDialog(TextVariables.MESG_RESTORE_BACKUP_PROMPT, useYesNo: true))
                    {
                        if (dlg.ShowDialog(this) == DialogResult.OK)
                        {
                            restoreBackup = true;
                            restoreOwnBackup = true;
                        }
                    }
                }
                else if (HasModDefaultBackup(_selectedGalleryEntry))
                {
                    using (var dlg = new forms.MyInquiryDialog(TextVariables.MESG_RESTORE_BACKUP_PROMPT, useYesNo: true))
                    {
                        if (dlg.ShowDialog(this) == DialogResult.OK)
                            restoreBackup = true;
                    }
                }
            }
            else if (HasModDefaultBackup(_selectedGalleryEntry))
            {
                using (var dlg = new forms.MyInquiryDialog(TextVariables.MESG_RESTORE_BACKUP_PROMPT, useYesNo: true))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                        restoreBackup = true;
                }
            }

            _overrideGallerySaveDir = _selectedGalleryEntry;
            _isCustomNpcMode = _galleryTabSelected == "customnpc";
            LabelCreatePortrait_Click(sender, e);

            if (restoreBackup && isNonPlayer)
                LoadNonPlayerBackupIntoCreatePage(_selectedGalleryEntry);
            else if (restoreBackup && restoreOwnBackup)
                LoadCompanionBackupIntoCreatePage(_selectedGalleryEntry);
            else if (restoreBackup)
                LoadBackupImageIntoCreatePage(_selectedGalleryEntry);
            else
                LoadGalleryImageIntoCreatePage(_selectedGalleryEntry);
        }

        private void ButtonGalleryBack_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource?.Cancel();
            _activeMenuIndex = GetMainMenuIndexForCurrentGame();

            ParentLayoutsDisable();
            RootFunctions.LayoutEnable(LayoutMainPage);
            Focus();
        }

        private void LabelGalleryTab_Paint(object sender, PaintEventArgs e)
        {
            if (_galleryTabSelected != "player") return;
            Color penColor = Color.White;
            try { penColor = GameTypes[_gameSelected].ForeColor; } catch { }
            using (var pen = new Pen(penColor))
            {
                int w = LabelGalleryTab.ClientSize.Width;
                int h = LabelGalleryTab.ClientSize.Height;
                e.Graphics.DrawLine(pen, 0, 0, w - 1, 0);
                e.Graphics.DrawLine(pen, 0, 0, 0, h - 1);
                e.Graphics.DrawLine(pen, w - 1, 0, w - 1, h - 1);
            }
        }

        private void LabelGalleryTab_MouseEnter(object sender, EventArgs e)
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gt)) return;
            LabelGalleryTab.ForeColor = gt.ForeColor;
        }

        private void LabelGalleryTab_MouseLeave(object sender, EventArgs e)
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gt)) return;
            LabelGalleryTab.ForeColor = _galleryTabSelected == "player" ? gt.ForeColor : Color.White;
        }

        private void LabelGalleryTab_Click(object sender, EventArgs e)
        {
            if (_galleryTabSelected == "player") return;
            _galleryTabSelected = "player";
            _isCustomNpcMode = false;
            UpdateGalleryTabVisuals();
            _cancellationTokenSource?.Cancel();
            ClearGalleryEntries();
            LoadGalleryImages();
            UpdateGalleryRightPanel();
        }

        private void LabelGalleryNonPlayerTab_Paint(object sender, PaintEventArgs e)
        {
            if (_galleryTabSelected != "nonplayer") return;
            Color penColor = Color.White;
            try { penColor = GameTypes[_gameSelected].ForeColor; } catch { }
            using (var pen = new Pen(penColor))
            {
                int w = LabelGalleryNonPlayerTab.ClientSize.Width;
                int h = LabelGalleryNonPlayerTab.ClientSize.Height;
                e.Graphics.DrawLine(pen, 0, 0, w - 1, 0);
                e.Graphics.DrawLine(pen, 0, 0, 0, h - 1);
                e.Graphics.DrawLine(pen, w - 1, 0, w - 1, h - 1);
            }
        }

        private void LabelGalleryNonPlayerTab_MouseEnter(object sender, EventArgs e)
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gt)) return;
            LabelGalleryNonPlayerTab.ForeColor = gt.ForeColor;
        }

        private void LabelGalleryNonPlayerTab_MouseLeave(object sender, EventArgs e)
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gt)) return;
            LabelGalleryNonPlayerTab.ForeColor = _galleryTabSelected == "nonplayer" ? gt.ForeColor : Color.White;
        }

        private void LabelGalleryNonPlayerTab_Click(object sender, EventArgs e)
        {
            if (_galleryTabSelected == "nonplayer") return;
            _galleryTabSelected = "nonplayer";
            _isCustomNpcMode = false;
            UpdateGalleryTabVisuals();
            _cancellationTokenSource?.Cancel();
            ClearGalleryEntries();
            LoadGalleryImages();
            UpdateGalleryRightPanel();
        }

        private void LabelGalleryCustomNpcTab_Paint(object sender, PaintEventArgs e)
        {
            if (_galleryTabSelected != "customnpc") return;
            Color penColor = Color.White;
            try { penColor = GameTypes[_gameSelected].ForeColor; } catch { }
            using (var pen = new Pen(penColor))
            {
                int w = LabelGalleryCustomNpcTab.ClientSize.Width;
                int h = LabelGalleryCustomNpcTab.ClientSize.Height;
                e.Graphics.DrawLine(pen, 0, 0, w - 1, 0);
                e.Graphics.DrawLine(pen, 0, 0, 0, h - 1);
                e.Graphics.DrawLine(pen, w - 1, 0, w - 1, h - 1);
            }
        }

        private void LabelGalleryCustomNpcTab_MouseEnter(object sender, EventArgs e)
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gt)) return;
            LabelGalleryCustomNpcTab.ForeColor = gt.ForeColor;
        }

        private void LabelGalleryCustomNpcTab_MouseLeave(object sender, EventArgs e)
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gt)) return;
            LabelGalleryCustomNpcTab.ForeColor = _galleryTabSelected == "customnpc" ? gt.ForeColor : Color.White;
        }

        private void LabelGalleryCustomNpcTab_Click(object sender, EventArgs e)
        {
            if (_gameSelected == 'r') return;
            if (_galleryTabSelected == "customnpc") return;
            _galleryTabSelected = "customnpc";
            _isCustomNpcMode = true;
            UpdateGalleryTabVisuals();
            _cancellationTokenSource?.Cancel();
            ClearGalleryEntries();
            LoadGalleryImages();
            UpdateGalleryRightPanel();
        }

        private void LabelGalleryCompanionsTab_Paint(object sender, PaintEventArgs e)
        {
            if (_galleryTabSelected != "companions") return;
            Color penColor = Color.White;
            try { penColor = GameTypes[_gameSelected].ForeColor; } catch { }
            using (var pen = new Pen(penColor))
            {
                int w = LabelGalleryCompanionsTab.ClientSize.Width;
                int h = LabelGalleryCompanionsTab.ClientSize.Height;
                e.Graphics.DrawLine(pen, 0, 0, w - 1, 0);
                e.Graphics.DrawLine(pen, 0, 0, 0, h - 1);
                e.Graphics.DrawLine(pen, w - 1, 0, w - 1, h - 1);
            }
        }

        private void LabelGalleryCompanionsTab_MouseEnter(object sender, EventArgs e)
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gt)) return;
            LabelGalleryCompanionsTab.ForeColor = gt.ForeColor;
        }

        private void LabelGalleryCompanionsTab_MouseLeave(object sender, EventArgs e)
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gt)) return;
            LabelGalleryCompanionsTab.ForeColor = _galleryTabSelected == "companions" ? gt.ForeColor : Color.White;
        }

        private void LabelGalleryCompanionsTab_Click(object sender, EventArgs e)
        {
            if (_galleryTabSelected == "companions") return;
            _galleryTabSelected = "companions";
            _isCustomNpcMode = false;
            UpdateGalleryTabVisuals();
            _cancellationTokenSource?.Cancel();
            ClearGalleryEntries();
            LoadGalleryImages();
            UpdateGalleryRightPanel();
        }

        private void LabelGalleryCharactersTab_Paint(object sender, PaintEventArgs e)
        {
            if (_galleryTabSelected != "characters") return;
            Color penColor = Color.White;
            try { penColor = GameTypes[_gameSelected].ForeColor; } catch { }
            using (var pen = new Pen(penColor))
            {
                int w = LabelGalleryCharactersTab.ClientSize.Width;
                int h = LabelGalleryCharactersTab.ClientSize.Height;
                e.Graphics.DrawLine(pen, 0, 0, w - 1, 0);
                e.Graphics.DrawLine(pen, 0, 0, 0, h - 1);
                e.Graphics.DrawLine(pen, w - 1, 0, w - 1, h - 1);
            }
        }

        private void LabelGalleryCharactersTab_MouseEnter(object sender, EventArgs e)
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gt)) return;
            LabelGalleryCharactersTab.ForeColor = gt.ForeColor;
        }

        private void LabelGalleryCharactersTab_MouseLeave(object sender, EventArgs e)
        {
            if (!GameTypes.TryGetValue(_gameSelected, out var gt)) return;
            LabelGalleryCharactersTab.ForeColor = _galleryTabSelected == "characters" ? gt.ForeColor : Color.White;
        }

        private void LabelGalleryCharactersTab_Click(object sender, EventArgs e)
        {
            if (_galleryTabSelected == "characters") return;
            _galleryTabSelected = "characters";
            _isCustomNpcMode = false;
            UpdateGalleryTabVisuals();
            _cancellationTokenSource?.Cancel();
            ClearGalleryEntries();
            LoadGalleryImages();
            UpdateGalleryRightPanel();
        }

        private void PanelGalleryContainer_Paint(object sender, PaintEventArgs e)
        {
            Color col = Color.White;
            try { col = GameTypes[_gameSelected].ForeColor; } catch { }
            Panel group = (Panel)sender;
            using (var pen = new Pen(col))
            {
                int w = group.ClientSize.Width;
                int h = group.ClientSize.Height;
                e.Graphics.DrawLine(pen, 0, 0, 0, h - 1);
                e.Graphics.DrawLine(pen, w - 1, 0, w - 1, h - 1);
                e.Graphics.DrawLine(pen, 0, h - 1, w - 1, h - 1);

                int gapStart = -1, gapEnd = -1;
                Label activeTab;
                if (_galleryTabSelected == "nonplayer")
                    activeTab = LabelGalleryNonPlayerTab;
                else if (_galleryTabSelected == "customnpc")
                    activeTab = LabelGalleryCustomNpcTab;
                else if (_galleryTabSelected == "companions")
                    activeTab = LabelGalleryCompanionsTab;
                else if (_galleryTabSelected == "characters")
                    activeTab = LabelGalleryCharactersTab;
                else
                    activeTab = LabelGalleryTab;
                if (activeTab.Visible)
                {
                    try
                    {
                        var lblScreen = activeTab.PointToScreen(Point.Empty);
                        var lblInGroup = group.PointToClient(lblScreen);
                        gapStart = lblInGroup.X;
                        gapEnd = lblInGroup.X + activeTab.Width;
                    }
                    catch { }
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

        private void LayoutGalleryRight_Paint(object sender, PaintEventArgs e)
        {
            Color foreColor;
            try { foreColor = GameTypes[_gameSelected].ForeColor; } catch { foreColor = Color.FromArgb(60, 60, 60); }
            ControlPaint.DrawBorder(e.Graphics, ((TableLayoutPanel)sender).ClientRectangle,
                foreColor, ButtonBorderStyle.Solid);
        }

        private void PanelGalleryOverlay_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            Rectangle rect = panel.ClientRectangle;

            if (_galleryTabSelected == "player")
            {
                using (Font emptyFont = new Font(_fontCollection.Families[0], 22))
                {
                    TextFormatFlags tfEmpty = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
                    TextRenderer.DrawText(e.Graphics, TextVariables.GALLERY_EMPTY_TEXT, emptyFont, rect, Color.White, tfEmpty);
                }
                return;
            }

            string title = _galleryTabSelected == "characters" ? TextVariables.LABEL_GALLERY_CHARACTERS
                : _galleryTabSelected == "companions" ? TextVariables.LABEL_GALLERY_COMPANIONS
                : TextVariables.LABEL_GALLERY_CUSTOMNPC;
            string[] hints =
            {
                TextVariables.GALLERY_HINT_REQUIRES_MOD,
                TextVariables.GALLERY_HINT_NPC_MET,
                TextVariables.GALLERY_HINT_OPEN_FOLDER,
                TextVariables.GALLERY_HINT_LOCALE_NOTE,
            };
            const int titleGap = 20;
            const int hintGap = 6;

            using (Font titleFont = new Font(_fontCollection.Families[0], 22))
            using (Font hintFont = new Font(_fontCollection.Families[0], 12))
            {
                TextFormatFlags tf = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;

                Size titleSize = TextRenderer.MeasureText(e.Graphics, title, titleFont, new Size(rect.Width, 0), tf);
                Size[] hintSizes = Array.ConvertAll(hints, h =>
                    TextRenderer.MeasureText(e.Graphics, h, hintFont, new Size(rect.Width, 0), tf));

                int totalHeight = titleSize.Height + titleGap;
                foreach (Size s in hintSizes) totalHeight += s.Height + hintGap;

                int y = (rect.Height - totalHeight) / 2;
                TextRenderer.DrawText(e.Graphics, title, titleFont, new Rectangle(0, y, rect.Width, titleSize.Height), Color.White, tf);
                y += titleSize.Height + titleGap;

                for (int i = 0; i < hints.Length; i++)
                {
                    TextRenderer.DrawText(e.Graphics, hints[i], hintFont, new Rectangle(0, y, rect.Width, hintSizes[i].Height), Color.Gray, tf);
                    y += hintSizes[i].Height + hintGap;
                }
            }
        }

        private void ButtonGalleryBack_MouseEnter(object sender, EventArgs e)
        {
            Color selBack = Color.Black, selFore = Color.White;
            try { selBack = GameTypes[_gameSelected].BackColor; selFore = GameTypes[_gameSelected].ForeColor; } catch { }
            ButtonGalleryBack.BackColor = selFore;
            ButtonGalleryBack.ForeColor = selBack;
        }

        private void ButtonGalleryBack_MouseLeave(object sender, EventArgs e)
        {
            Color selBack = Color.Black, selFore = Color.White;
            try { selBack = GameTypes[_gameSelected].BackColor; selFore = GameTypes[_gameSelected].ForeColor; } catch { }
            ButtonGalleryBack.BackColor = selBack;
            ButtonGalleryBack.ForeColor = selFore;
        }

        private void ButtonGalleryClone_MouseEnter(object sender, EventArgs e)
        {
            Color selBack = Color.Black, selFore = Color.White;
            try { selBack = GameTypes[_gameSelected].BackColor; selFore = GameTypes[_gameSelected].ForeColor; } catch { }
            ButtonGalleryClone.BackColor = selFore;
            ButtonGalleryClone.ForeColor = selBack;
        }

        private void ButtonGalleryClone_MouseLeave(object sender, EventArgs e)
        {
            Color selBack = Color.Black, selFore = Color.White;
            try { selBack = GameTypes[_gameSelected].BackColor; selFore = GameTypes[_gameSelected].ForeColor; } catch { }
            ButtonGalleryClone.BackColor = selBack;
            ButtonGalleryClone.ForeColor = selFore;
        }

        private void ButtonGalleryChange_MouseEnter(object sender, EventArgs e)
        {
            Color selBack = Color.Black, selFore = Color.White;
            try { selBack = GameTypes[_gameSelected].BackColor; selFore = GameTypes[_gameSelected].ForeColor; } catch { }
            ButtonGalleryChange.BackColor = selFore;
            ButtonGalleryChange.ForeColor = selBack;
        }

        private void ButtonGalleryChange_MouseLeave(object sender, EventArgs e)
        {
            Color selBack = Color.Black, selFore = Color.White;
            try { selBack = GameTypes[_gameSelected].BackColor; selFore = GameTypes[_gameSelected].ForeColor; } catch { }
            ButtonGalleryChange.BackColor = selBack;
            ButtonGalleryChange.ForeColor = selFore;
        }

        private void ButtonGalleryDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedGalleryEntry)) return;
            if (_isCustomNpcMode) return;
            using (var dlg = new forms.MyInquiryDialog(TextVariables.INQR_DELETE_PORTRAIT_SET, useYesNo: true))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    _cancellationTokenSource?.Cancel();
                    DeleteGalleryPortraitSet(_selectedGalleryEntry);
                    _selectedGalleryEntry = null;
                    UpdateGalleryRightPanel();
                    LoadGalleryImages();
                }
            }
        }

        private void ButtonGalleryDelete_MouseEnter(object sender, EventArgs e)
        {
            Color selBack = Color.Black, selFore = Color.White;
            try { selBack = GameTypes[_gameSelected].BackColor; selFore = GameTypes[_gameSelected].ForeColor; } catch { }
            ButtonGalleryDelete.BackColor = selFore;
            ButtonGalleryDelete.ForeColor = selBack;
        }

        private void ButtonGalleryDelete_MouseLeave(object sender, EventArgs e)
        {
            Color selBack = Color.Black, selFore = Color.White;
            try { selBack = GameTypes[_gameSelected].BackColor; selFore = GameTypes[_gameSelected].ForeColor; } catch { }
            ButtonGalleryDelete.BackColor = selBack;
            ButtonGalleryDelete.ForeColor = selFore;
        }

        private void ButtonGalleryShowFolder_Click(object sender, EventArgs e)
        {
            string gameDir;
            if (_galleryTabSelected == "nonplayer" && (_gameSelected == 't' || _gameSelected == 'p' || _gameSelected == 'd'))
            {
                string basePath = CoreSettings.Default.GamePath;
                if (!string.IsNullOrEmpty(basePath))
                    gameDir = GetNonPlayerPortraitsRoot(basePath);
                else
                    gameDir = null;
            }
            else if (_isCustomNpcMode)
            {
                string basePath = CoreSettings.Default.GamePath;
                if (!string.IsNullOrEmpty(basePath))
                    gameDir = GetCustomNpcPortraitsDir(basePath);
                else
                    gameDir = null;
            }
            else if (_galleryTabSelected == "characters")
            {
                string basePath = CoreSettings.Default.GamePath;
                var charactersRoots = !string.IsNullOrEmpty(basePath) ? GetCharactersPortraitsRoots(basePath) : null;
                gameDir = charactersRoots?.FirstOrDefault(Directory.Exists) ?? charactersRoots?.FirstOrDefault();
            }
            else
            {
                gameDir = GetGameDirectory();
            }

            if (string.IsNullOrEmpty(gameDir) || !Directory.Exists(gameDir))
            {
                using (var msg = new forms.MyMessageDialog(TextVariables.MESG_GAME_DIRECTORY_UNKNOWN))
                {
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog(this);
                }
                return;
            }
            Process.Start("explorer.exe", gameDir);
        }

        private void ButtonGalleryShowFolder_MouseEnter(object sender, EventArgs e)
        {
            Color selBack = Color.Black, selFore = Color.White;
            try { selBack = GameTypes[_gameSelected].BackColor; selFore = GameTypes[_gameSelected].ForeColor; } catch { }
            ButtonGalleryShowFolder.BackColor = selFore;
            ButtonGalleryShowFolder.ForeColor = selBack;
        }

        private void ButtonGalleryShowFolder_MouseLeave(object sender, EventArgs e)
        {
            Color selBack = Color.Black, selFore = Color.White;
            try { selBack = GameTypes[_gameSelected].BackColor; selFore = GameTypes[_gameSelected].ForeColor; } catch { }
            ButtonGalleryShowFolder.BackColor = selBack;
            ButtonGalleryShowFolder.ForeColor = selFore;
        }

        private void MainForm_Closed(object sender, FormClosedEventArgs e)
        {
            SystemControl.FileControl.ClearTempImages();
            Dispose();
            Application.Exit();
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        }
        private void LabelSelectPathNextToMain_Click(object sender, EventArgs e)
        {
            string selectedPath = LabelSelectPathSelected.Text;
            if (string.IsNullOrEmpty(selectedPath) || selectedPath == "-" || selectedPath == " - ")
            {
                return;
            }
            if (_gameSelected == 'k')
            {
                try
                {
                    if (!Directory.Exists(selectedPath) || string.IsNullOrWhiteSpace(selectedPath))
                    {
                        using (var dlg = new forms.MyMessageDialog(TextVariables.MESG_PATH_NOT_FOUND))
                        {
                            dlg.StartPosition = FormStartPosition.CenterParent;
                            dlg.ShowDialog(this);
                        }
                        return;
                    }

                    selectedPath = selectedPath.Replace('/', '\\');

                    var dir = new DirectoryInfo(selectedPath);
                    while (dir != null &&
                            !dir.Name.Equals("Pathfinder Kingmaker", StringComparison.OrdinalIgnoreCase))
                        dir = dir.Parent;

                    if (dir == null || dir.Parent == null ||
                        !dir.Parent.Name.Equals("Owlcat Games", StringComparison.OrdinalIgnoreCase))
                    {

                        using (var dlg = new forms.MyMessageDialog(string.Format(TextVariables.MESG_PATH_WRONG_ROOT, "Pathfinder Kingmaker")))
                        {
                            dlg.StartPosition = FormStartPosition.CenterParent;
                            dlg.ShowDialog(this);
                        }
                        return;
                    }

                    string rootPath = dir.FullName + Path.DirectorySeparatorChar;
                    string portraitsDir = Path.Combine(rootPath, "Portraits");
                    if (!Directory.Exists(portraitsDir))
                        Directory.CreateDirectory(portraitsDir);

                    CoreSettings.Default.GamePath = "0";
                    CoreSettings.Default.GameType = '-';
                    CoreSettings.Default.Save();
                    LabelSelectPathSelected.Text = rootPath;
                    CoreSettings.Default.GamePath = rootPath;
                    CoreSettings.Default.GameType = 'k';
                    CoreSettings.Default.Save();
                    LayoutMainPage.BackgroundImage = Resources.path_menu_page;
                    _activeMenuIndex = 201;
                    ParentLayoutsDisable();
                    RootFunctions.LayoutEnable(LayoutMainPage);
                    PrepareKingCreatePortraitStyleState();
                    Focus();
                }
                catch (Exception)
                {
                    return;
                }
            }
            else if (_gameSelected == 'w')
            {
                try
                {
                    if (!Directory.Exists(selectedPath) || string.IsNullOrWhiteSpace(selectedPath))
                    {
                        using (var dlg = new forms.MyMessageDialog(TextVariables.MESG_PATH_NOT_FOUND))
                        {
                            dlg.StartPosition = FormStartPosition.CenterParent;
                            dlg.ShowDialog();
                        }
                        return;
                    }

                    selectedPath = selectedPath.Replace('/', '\\');

                    var dir = new DirectoryInfo(selectedPath);
                    while (dir != null &&
                            !dir.Name.Equals("Pathfinder Wrath Of The Righteous", StringComparison.OrdinalIgnoreCase))
                        dir = dir.Parent;

                    if (dir == null || dir.Parent == null ||
                        !dir.Parent.Name.Equals("Owlcat Games", StringComparison.OrdinalIgnoreCase))
                    {

                        using (var dlg = new forms.MyMessageDialog(string.Format(TextVariables.MESG_PATH_WRONG_ROOT, "Pathfinder Wrath Of The Righteous")))
                        {
                            dlg.StartPosition = FormStartPosition.CenterParent;
                            dlg.ShowDialog(this);
                        }
                        return;
                    }

                    string rootPath = dir.FullName + Path.DirectorySeparatorChar;
                    string portraitsDir = Path.Combine(rootPath, "Portraits");
                    if (!Directory.Exists(portraitsDir))
                        Directory.CreateDirectory(portraitsDir);

                    CoreSettings.Default.GamePath = "0";
                    CoreSettings.Default.GameType = '-';
                    CoreSettings.Default.Save();
                    LabelSelectPathSelected.Text = rootPath;
                    CoreSettings.Default.GamePath = rootPath;
                    CoreSettings.Default.GameType = 'w';
                    CoreSettings.Default.Save();
                    LayoutMainPage.BackgroundImage = Resources.wotr_menu_page;
                    _activeMenuIndex = 202;
                    ParentLayoutsDisable();
                    RootFunctions.LayoutEnable(LayoutMainPage);
                    PrepareKingCreatePortraitStyleState();
                    Focus();
                }
                catch (Exception)
                {
                    return;
                }
            }
            else if (_gameSelected == 'r')
            {
                try
                {
                    if (!Directory.Exists(selectedPath) || string.IsNullOrWhiteSpace(selectedPath))
                    {
                        using (var dlg = new forms.MyMessageDialog(TextVariables.MESG_PATH_NOT_FOUND))
                        {
                            dlg.StartPosition = FormStartPosition.CenterParent;
                            dlg.ShowDialog(this);
                        }
                        return;
                    }

                    selectedPath = selectedPath.Replace('/', '\\');

                    var dir = new DirectoryInfo(selectedPath);
                    while (dir != null &&
                            !dir.Name.Equals("Warhammer 40000 Rogue Trader", StringComparison.OrdinalIgnoreCase))
                        dir = dir.Parent;

                    if (dir == null || dir.Parent == null ||
                        !dir.Parent.Name.Equals("Owlcat Games", StringComparison.OrdinalIgnoreCase))
                    {

                        using (var dlg = new forms.MyMessageDialog(string.Format(TextVariables.MESG_PATH_WRONG_ROOT, "Warhammer 40000 Rogue Trader")))
                        {
                            dlg.StartPosition = FormStartPosition.CenterParent;
                            dlg.ShowDialog(this);
                        }
                        return;
                    }

                    string rootPath = dir.FullName + Path.DirectorySeparatorChar;
                    string portraitsDir = Path.Combine(rootPath, "Portraits");
                    if (!Directory.Exists(portraitsDir))
                        Directory.CreateDirectory(portraitsDir);

                    CoreSettings.Default.GamePath = "0";
                    CoreSettings.Default.GameType = '-';
                    CoreSettings.Default.Save();
                    LabelSelectPathSelected.Text = rootPath;
                    CoreSettings.Default.GamePath = rootPath;
                    CoreSettings.Default.GameType = 'r';
                    CoreSettings.Default.Save();
                    LayoutMainPage.BackgroundImage = Resources.rt_menu_page;
                    _activeMenuIndex = 203;
                    ParentLayoutsDisable();
                    RootFunctions.LayoutEnable(LayoutMainPage);
                    PrepareKingCreatePortraitStyleState();
                    Focus();
                }
                catch (Exception)
                {
                    return;
                }
            }
            else if (_gameSelected == 'p')
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(selectedPath) || !Directory.Exists(selectedPath))
                    {
                        using (var dlg = new forms.MyMessageDialog(TextVariables.MESG_PATH_NOT_FOUND))
                        {
                            dlg.StartPosition = FormStartPosition.CenterParent;
                            dlg.ShowDialog(this);
                        }
                        return;
                    }

                    selectedPath = selectedPath.Replace('/', '\\');

                    var dir = new DirectoryInfo(selectedPath);
                    while (dir != null &&
                           !dir.Name.Equals("PillarsOfEternity_Data", StringComparison.OrdinalIgnoreCase))
                    {
                        dir = dir.Parent;
                    }

                    string rootPath;
                    if (dir != null)
                    {
                        rootPath = dir.Parent.FullName + Path.DirectorySeparatorChar;
                    }
                    else
                    {

                        rootPath = selectedPath.TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
                    }

                    string portraitsRoot = Path.Combine(rootPath, "PillarsOfEternity_Data", "data", "art", "gui", "portraits");
                    if (!Directory.Exists(portraitsRoot))
                    {
                        using (var dlg = new forms.MyMessageDialog(TextVariables.MESG_PATH_NOT_FOUND))
                        {
                            dlg.StartPosition = FormStartPosition.CenterParent;
                            dlg.ShowDialog(this);
                        }
                        return;
                    }

                    string maleDir = Path.Combine(portraitsRoot, "player", "male");
                    string femaleDir = Path.Combine(portraitsRoot, "player", "female");
                    Directory.CreateDirectory(maleDir);
                    Directory.CreateDirectory(femaleDir);

                    CoreSettings.Default.GamePath = "0";
                    CoreSettings.Default.GameType = '-';
                    CoreSettings.Default.Save();
                    LabelSelectPathSelected.Text = rootPath;
                    CoreSettings.Default.GamePath = rootPath;
                    CoreSettings.Default.GameType = 'p';
                    CoreSettings.Default.Save();
                    LayoutMainPage.BackgroundImage = Resources.poe_menu_page;
                    _activeMenuIndex = 204;
                    ParentLayoutsDisable();
                    RootFunctions.LayoutEnable(LayoutMainPage);
                    PrepareKingCreatePortraitStyleState();
                    Focus();
                }
                catch (Exception)
                {
                    return;
                }
            }
            else if (_gameSelected == 'd')
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(selectedPath) || !Directory.Exists(selectedPath))
                    {
                        using (var dlg = new forms.MyMessageDialog(TextVariables.MESG_PATH_NOT_FOUND))
                        {
                            dlg.StartPosition = FormStartPosition.CenterParent;
                            dlg.ShowDialog(this);
                        }
                        return;
                    }

                    selectedPath = selectedPath.Replace('/', '\\');

                    var dir = new DirectoryInfo(selectedPath);
                    while (dir != null &&
                           !dir.Name.Equals("PillarsOfEternityII_Data", StringComparison.OrdinalIgnoreCase))
                    {
                        dir = dir.Parent;
                    }

                    string rootPath;
                    if (dir != null)
                    {
                        rootPath = dir.Parent.FullName + Path.DirectorySeparatorChar;
                    }
                    else
                    {

                        rootPath = selectedPath.TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
                    }

                    string portraitsRoot = Path.Combine(rootPath, "PillarsOfEternityII_Data", "gui", "portraits");
                    if (!Directory.Exists(portraitsRoot))
                    {
                        using (var dlg = new forms.MyMessageDialog(TextVariables.MESG_PATH_NOT_FOUND))
                        {
                            dlg.StartPosition = FormStartPosition.CenterParent;
                            dlg.ShowDialog(this);
                        }
                        return;
                    }
                    string maleDir = Path.Combine(portraitsRoot, "player", "male");
                    string femaleDir = Path.Combine(portraitsRoot, "player", "female");
                    Directory.CreateDirectory(maleDir);
                    Directory.CreateDirectory(femaleDir);

                    CoreSettings.Default.GamePath = "0";
                    CoreSettings.Default.GameType = '-';
                    CoreSettings.Default.Save();
                    LabelSelectPathSelected.Text = rootPath;
                    CoreSettings.Default.GamePath = rootPath;
                    CoreSettings.Default.GameType = 'd';
                    CoreSettings.Default.Save();
                    LayoutMainPage.BackgroundImage = Resources.poed_menu_page;
                    _activeMenuIndex = 205;
                    ParentLayoutsDisable();
                    RootFunctions.LayoutEnable(LayoutMainPage);
                    PrepareKingCreatePortraitStyleState();
                    Focus();
                }
                catch (Exception)
                {
                    return;
                }
            }
            else if (_gameSelected == 't')
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(selectedPath) || !Directory.Exists(selectedPath))
                    {
                        using (var dlg = new forms.MyMessageDialog(TextVariables.MESG_PATH_NOT_FOUND))
                        {
                            dlg.StartPosition = FormStartPosition.CenterParent;
                            dlg.ShowDialog(this);
                        }
                        return;
                    }

                    var dir = new DirectoryInfo(selectedPath);
                    while (dir != null && !dir.Name.Equals("Tyranny", StringComparison.OrdinalIgnoreCase))
                        dir = dir.Parent;
                    if (dir == null)
                    {
                        using (var dlg = new forms.MyMessageDialog(TextVariables.MESG_PATH_NOT_FOUND))
                        {
                            dlg.StartPosition = FormStartPosition.CenterParent;
                            dlg.ShowDialog(this);
                        }
                        return;
                    }

                    string rootPath = dir.FullName + Path.DirectorySeparatorChar;

                    string checkPath = Path.Combine(rootPath, "Data", "data", "art", "gui", "icons", "abilities");

                    if (!Directory.Exists(checkPath))
                    {
                        using (var dlg = new forms.MyMessageDialog(TextVariables.MESG_PATH_NOT_FOUND))
                        {
                            dlg.StartPosition = FormStartPosition.CenterParent;
                            dlg.ShowDialog(this);
                        }
                        return;
                    }

                    string maleDir = Path.Combine(rootPath, "Data", "data", "art", "gui", "portraits", "player", "male");
                    string femaleDir = Path.Combine(rootPath, "Data", "data", "art", "gui", "portraits", "player", "female");
                    Directory.CreateDirectory(maleDir);
                    Directory.CreateDirectory(femaleDir);

                    CoreSettings.Default.GamePath = "0";
                    CoreSettings.Default.GameType = '-';
                    CoreSettings.Default.Save();
                    LabelSelectPathSelected.Text = rootPath.ToLower();
                    CoreSettings.Default.GamePath = rootPath;
                    CoreSettings.Default.GameType = 't';
                    CoreSettings.Default.Save();
                    LayoutMainPage.BackgroundImage = Resources.tyr_menu_page;
                    _activeMenuIndex = 206;
                    ParentLayoutsDisable();
                    RootFunctions.LayoutEnable(LayoutMainPage);
                    PrepareKingCreatePortraitStyleState();
                    Focus();
                }
                catch (Exception)
                {
                    return;
                }
            }
            else if (_gameSelected == 'l')
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(selectedPath) || !Directory.Exists(selectedPath))
                    {
                        using (var dlg = new forms.MyMessageDialog(TextVariables.MESG_PATH_NOT_FOUND))
                        {
                            dlg.StartPosition = FormStartPosition.CenterParent;
                            dlg.ShowDialog(this);
                        }
                        return;
                    }

                    var dir = new DirectoryInfo(selectedPath);
                    while (dir != null && !dir.Name.Equals("Wasteland3", StringComparison.OrdinalIgnoreCase))
                        dir = dir.Parent;

                    if (dir == null || dir.Parent == null ||
                        !dir.Parent.Name.Equals("My Games", StringComparison.OrdinalIgnoreCase))
                    {

                        using (var dlg = new forms.MyMessageDialog(string.Format(TextVariables.MESG_PATH_WRONG_ROOT_DOCUMENTS, "Wasteland3")))
                        {
                            dlg.StartPosition = FormStartPosition.CenterParent;
                            dlg.ShowDialog(this);
                        }
                        return;
                    }

                    string rootPath = dir.FullName + Path.DirectorySeparatorChar;

                    string customPortraits = Path.Combine(rootPath, "Custom Portraits");
                    Directory.CreateDirectory(customPortraits);

                    CoreSettings.Default.GamePath = "0";
                    CoreSettings.Default.GameType = '-';
                    CoreSettings.Default.Save();
                    LabelSelectPathSelected.Text = rootPath.ToLower();
                    CoreSettings.Default.GamePath = rootPath;
                    CoreSettings.Default.GameType = 'l';
                    CoreSettings.Default.Save();
                    LayoutMainPage.BackgroundImage = Resources.waste_menu_page;
                    _activeMenuIndex = 207;
                    ParentLayoutsDisable();
                    RootFunctions.LayoutEnable(LayoutMainPage);
                    PrepareKingCreatePortraitStyleState();
                    Focus();
                }
                catch (Exception)
                {
                    return;
                }
            }
            LabelBrowse.Visible = true;
            ApplyGameWindowStyle();
        }

        private void LayoutPathPage_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelExtractContainer_Paint(object sender, PaintEventArgs e)
        {
            Color foreColor;
            try { foreColor = GameTypes[_gameSelected].ForeColor; } catch { foreColor = Color.FromArgb(60, 60, 60); }
            ControlPaint.DrawBorder(e.Graphics, ((Panel)sender).ClientRectangle,
                foreColor, ButtonBorderStyle.Solid);
        }

        private void PanelExtractOverlay_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            Rectangle rect = panel.ClientRectangle;

            Color gameFore, gameBack;
            try { gameFore = GameTypes[_gameSelected].ForeColor; gameBack = GameTypes[_gameSelected].BackColor; }
            catch { gameFore = Color.White; gameBack = Color.FromArgb(12, 12, 12); }

            string title = TextVariables.BUTTON_SELECT_ARCHIVE;
            string folderIcon = "\U0001F4C1";
            string hint = TextVariables.EXTRACT_HINT_OVERLAY;
            string hintSub = TextVariables.EXTRACT_HINT_SUB;

            using (Font titleFont = new Font(_fontCollection.Families[0], 22))
            using (Font hintFont = new Font(_fontCollection.Families[0], 12))
            using (Font hintSubFont = new Font(_fontCollection.Families[0], 9))
            {
                string titleLine = title + "\n" + folderIcon;
                TextFormatFlags tf = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;

                Size titleSize = TextRenderer.MeasureText(e.Graphics, titleLine, titleFont,
                    new Size(rect.Width, 0), tf);
                Size hintSize = TextRenderer.MeasureText(e.Graphics, hint, hintFont,
                    new Size(rect.Width, 0), tf);
                Size hintSubSize = TextRenderer.MeasureText(e.Graphics, hintSub, hintSubFont,
                    new Size(rect.Width, 0), tf);

                int totalHeight = titleSize.Height + 16 + hintSize.Height + 6 + hintSubSize.Height;
                int yStart = (rect.Height - totalHeight) / 2;

                Color titleColor = _overlayHovered ? gameFore : Color.White;

                Rectangle titleRect = new Rectangle(0, yStart, rect.Width, titleSize.Height);
                TextRenderer.DrawText(e.Graphics, titleLine, titleFont, titleRect, titleColor, tf);

                Rectangle hintRect = new Rectangle(0, yStart + titleSize.Height + 16, rect.Width, hintSize.Height);
                TextRenderer.DrawText(e.Graphics, hint, hintFont, hintRect, Color.Gray, tf);

                Rectangle hintSubRect = new Rectangle(0, yStart + titleSize.Height + 16 + hintSize.Height + 6,
                    rect.Width, hintSubSize.Height);
                TextRenderer.DrawText(e.Graphics, hintSub, hintSubFont, hintSubRect, Color.Gray, tf);
            }
        }

        private void PanelExtractOverlay_MouseEnter(object sender, EventArgs e)
        {
            _overlayHovered = true;
            ((Panel)sender).Invalidate();
        }

        private void PanelExtractOverlay_MouseLeave(object sender, EventArgs e)
        {
            _overlayHovered = false;
            ((Panel)sender).Invalidate();
        }

        private void PanelExtractContainer_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void PanelExtractContainer_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (files == null || files.Length == 0) return;

            string path = files[0];
            if (Directory.Exists(path))
            {
                LoadArchiveThumbnails(path);
            }
            else
            {
                string ext = Path.GetExtension(path).ToLowerInvariant();
                if (ext == ".zip" || ext == ".7z" || ext == ".rar")
                    LoadArchiveThumbnails(path);
            }
        }

        private void LayoutExtractRight_Paint(object sender, PaintEventArgs e)
        {
            Color foreColor;
            try { foreColor = GameTypes[_gameSelected].ForeColor; } catch { foreColor = Color.FromArgb(60, 60, 60); }
            ControlPaint.DrawBorder(e.Graphics, ((TableLayoutPanel)sender).ClientRectangle,
                foreColor, ButtonBorderStyle.Solid);
        }

        private void LabelSelectPathChoosePath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog FolderChoose = new FolderBrowserDialog()
            {
                SelectedPath = GameTypes[_gameSelected].DefaultDirectory,

                ShowNewFolderButton = false,
            })
            {
                if (FolderChoose.ShowDialog() == DialogResult.OK)
                {
                    LabelSelectPathSelected.Text = FolderChoose.SelectedPath;
                }
                else
                {
                    FolderChoose.Dispose();
                    return;
                }
            }
        }

        private void LabelCreatePortrait_Click(object sender, EventArgs e)
        {
            if (_gameSelected == 'k' || _gameSelected == 'w' || _gameSelected == 'r' ||
                _gameSelected == 'p' || _gameSelected == 't' || _gameSelected == 'd' || _gameSelected == 'l')
            {
                ParentLayoutsDisable();
                RootFunctions.LayoutEnable(LayoutKingCreatePortrait);
                _activeMenuIndex = GetCreatePortraitMenuIndexForCurrentGame();

                PrepareKingCreatePortraitView();
                PrepareKingCreatePortraitStyleState();
                TextInit();
                Focus();
            }
        }

        private void LabelKingCreatePortraitLarge_Click(object sender, EventArgs e)
        {
            SetKingPortraitGroup(PortraitGroupSelection.Large);
        }

        private void LabelKingCreatePortraitMedium_Click(object sender, EventArgs e)
        {
            SetKingPortraitGroup(PortraitGroupSelection.Medium);
        }

        private void LabelKingCreatePortraitSmall_Click(object sender, EventArgs e)
        {
            SetKingPortraitGroup(PortraitGroupSelection.Small);
        }

        private void LabelKingCreatePortraitSml2_Click(object sender, EventArgs e)
        {
            SetKingPortraitGroup(PortraitGroupSelection.Sml2);
        }

        private void ButtonKingBackToPathfinder_Click(object sender, EventArgs e)
        {

            try
            {
                _overrideGallerySaveDir = null;
                _activeMenuIndex = GetMainMenuIndexForCurrentGame();
                ParentLayoutsDisable();
                RootFunctions.LayoutEnable(LayoutMainPage);
                PrepareKingCreatePortraitStyleState();
                Focus();
            }
            catch { }
        }

        private void ButtonKingSelectWeb_Click(object sender, EventArgs e)
        {

        }

        private void ButtonKingSelectLocal_Click(object sender, EventArgs e)
        {

            if (sender is Button btn && btn.Tag is string picName)
            {
                PictureBox pic = this.Controls.Find(picName, true).FirstOrDefault() as PictureBox;
                if (pic == null) return;

                using (OpenFileDialog ofd = new OpenFileDialog()
                {
                    Filter = "Image files|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.webp",
                    Multiselect = false
                })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (Image fileImg = Image.FromFile(ofd.FileName))
                            {
                                Bitmap copy = ImageControl.Direct.Resize(fileImg, fileImg.Width, fileImg.Height);
                                StoreOriginalImage(pic, copy);
                            }
                            FitImageToPanel(pic);
                            MarkGroupInitialized(pic);
                        }
                        catch
                        {
                            return;
                        }
                    }
                }
            }
        }

        private void ButtonKingZoomIn_Click(object sender, EventArgs e)
        {
            ZoomFromButton(sender, 120);
        }

        private void ButtonKingZoomOut_Click(object sender, EventArgs e)
        {
            ZoomFromButton(sender, -120);
        }

        private void ButtonKingZoomReset_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;
            string picName = button.Tag as string;
            if (string.IsNullOrEmpty(picName)) return;

            PictureBox pb = null;
            if (picName == "PicKingLrg") pb = PicKingLrg;
            else if (picName == "PicKingMed") pb = PicKingMed;
            else if (picName == "PicKingSml") pb = PicKingSml;
            else if (picName == "PicKingSml2") pb = PicKingSml2;

            if (pb == null || pb.Image == null) return;
            FitImageToPanel(pb);
        }

        private void PortraitButton_GotFocus(object sender, EventArgs e)
        {
            ActiveControl = null;
        }

        private void PortraitButton_MouseEnter(object sender, EventArgs e)
        {
            if (!(sender is Button btn)) return;
            Color selBack = Color.Black;
            Color selFore = Color.White;
            try { selBack = GameTypes[_gameSelected].BackColor; selFore = GameTypes[_gameSelected].ForeColor; } catch { }

            btn.BackColor = selFore;
            btn.ForeColor = selBack;
            btn.FlatAppearance.BorderColor = selFore;
        }

        private void PortraitButton_MouseLeave(object sender, EventArgs e)
        {
            if (!(sender is Button btn)) return;
            Color selBack = Color.Black;
            Color selFore = Color.White;
            try { selBack = GameTypes[_gameSelected].BackColor; selFore = GameTypes[_gameSelected].ForeColor; } catch { }

            btn.BackColor = selBack;
            btn.ForeColor = selFore;
            btn.FlatAppearance.BorderColor = selFore;
        }

        private void LabelKingCreatePortraitLarge_MouseEnter(object sender, EventArgs e)
        {
            LabelKingCreatePortraitLarge.ForeColor = GameTypes[_gameSelected].ForeColor;
        }

        private void LabelKingCreatePortraitLarge_MouseLeave(object sender, EventArgs e)
        {
            LabelKingCreatePortraitLarge.ForeColor = _activeKingPortraitGroup == PortraitGroupSelection.Large ? GameTypes[_gameSelected].ForeColor : Color.White;
        }

        private void LabelKingCreatePortraitMedium_MouseEnter(object sender, EventArgs e)
        {
            LabelKingCreatePortraitMedium.ForeColor = GameTypes[_gameSelected].ForeColor;
        }

        private void LabelKingCreatePortraitMedium_MouseLeave(object sender, EventArgs e)
        {
            LabelKingCreatePortraitMedium.ForeColor = _activeKingPortraitGroup == PortraitGroupSelection.Medium ? GameTypes[_gameSelected].ForeColor : Color.White;
        }

        private void LabelKingCreatePortraitSmall_MouseEnter(object sender, EventArgs e)
        {
            LabelKingCreatePortraitSmall.ForeColor = GameTypes[_gameSelected].ForeColor;
        }

        private void LabelKingCreatePortraitSmall_MouseLeave(object sender, EventArgs e)
        {
            LabelKingCreatePortraitSmall.ForeColor = _activeKingPortraitGroup == PortraitGroupSelection.Small ? GameTypes[_gameSelected].ForeColor : Color.White;
        }

        private void LabelKingCreatePortraitSml2_MouseEnter(object sender, EventArgs e)
        {
            LabelKingCreatePortraitSml2.ForeColor = GameTypes[_gameSelected].ForeColor;
        }

        private void LabelKingCreatePortraitSml2_MouseLeave(object sender, EventArgs e)
        {
            LabelKingCreatePortraitSml2.ForeColor = _activeKingPortraitGroup == PortraitGroupSelection.Sml2 ? GameTypes[_gameSelected].ForeColor : Color.White;
        }
    }
}
