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
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PortraitManager
{
    public partial class MainForm : Form
    {
        private string _extractFolderPath = "!NONE!";
        private string _tunneledNameToPortraitPage = "!NONE!";

        private void PicPortraitTemp_DragDrop(object sender, DragEventArgs e)
        {
            string path = ParseDragDropFile(e);

            if (path == "!NONE!")
            {
                //using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_WRONGFORMAT, CoreSettings.Default.SelectedLang))
                //{
                //    Message.StartPosition = FormStartPosition.CenterParent;
                //    Message.ShowDialog();
                //}

                if (_isAnyLoadedToPortraitPage == true)
                {
                    LoadTempImagesToPicBox(_imageSelectionFlag);
                    ResizeVisibleImagesToWindowSize();
                    return;
                }

                _isAnyLoadedToPortraitPage = false;
                LoadTempImagesToPicBox(_imageSelectionFlag);
                ResizeVisibleImagesToWindowSize();
                return;
            }
            else
            {
                _isAnyLoadedToPortraitPage = true;
                GenerateImageSelectionFlagString(_imageSelectionFlag);
                CreateAllImagesInTemp(path, _imageSelectionFlag);
                LoadTempImagesToPicBox(_imageSelectionFlag);
                ResizeVisibleImagesToWindowSize();
            }

        }

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
                MessageBox.Show(
                    "Game portraits path is not set or does not exist.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (!GameTypes.TryGetValue(CoreSettings.Default.GameType, out GameType gameType))
            {
                MessageBox.Show(
                    "Unsupported game type.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            bool isObsidian = _gameSelected == 'p' || _gameSelected == 'd' || _gameSelected == 't';
            bool isWasteland = _gameSelected == 'l';
            bool useUid = _gameSelected == 'p' || _gameSelected == 'd' || _gameSelected == 't' || _gameSelected == 'l'; // UID naming for PoE, Deadfire, Tyranny, Wasteland 3
            string uid = useUid ? "portraitmanager" + DateTime.Now.ToString("ssddMM", CultureInfo.InvariantCulture) : null;
            string femaleDir = null;

            string outDir;

            if (isObsidian)
            {
                // Obsidian games: fixed game-expected path — write directly to player/male
                if (_gameSelected == 'p')
                    outDir = Path.Combine(basePath, "PillarsOfEternity_Data", "data", "art", "gui", "portraits", "player", "male");
                else if (_gameSelected == 'd')
                    outDir = Path.Combine(basePath, "PillarsOfEternityII_Data", "gui", "portraits", "player", "male");
                else
                    outDir = Path.Combine(basePath, "Tyranny_Data", "data", "art", "gui", "portraits", "player", "male");

                try { Directory.CreateDirectory(outDir); }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to create portraits folder: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // For PoE, Tyranny, and Deadfire, also create the female directory for copies
                if (useUid && !isWasteland)
                {
                    femaleDir = Path.Combine(Path.GetDirectoryName(outDir), "female");
                    try { Directory.CreateDirectory(femaleDir); }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to create female portraits folder: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else if (isWasteland)
            {
                // Wasteland 3: fixed path — write directly to Custom Portraits
                outDir = Path.Combine(basePath, "Custom Portraits");
                try { Directory.CreateDirectory(outDir); }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to create portraits folder: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(_overrideGallerySaveDir))
                {
                    outDir = _overrideGallerySaveDir;
                    _overrideGallerySaveDir = null;
                }
                else
                {
                    // Owlcat games: timestamp-named subfolder under Portraits
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
                        MessageBox.Show("Failed to create portraits root folder: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string baseName = "portraitmanager_" + DateTime.Now.ToString("ss_dd_MM", CultureInfo.InvariantCulture);
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
                        MessageBox.Show("Failed to create portrait folder: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
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
                    return "Fulllength.png";
                }

                void SaveAndCopy(Image orig, PictureBox pb, Panel panel, int w, int h, string sizeSuffix)
                {
                    if (orig == null) return;
                    string fileName = FileName(sizeSuffix);
                    string savePath = Path.Combine(outDir, fileName);
                    if (_gameSelected == 'k' || _gameSelected == 'w' || _gameSelected == 'r' || _gameSelected == 't' || _gameSelected == 'p' || _gameSelected == 'd' || _gameSelected == 'l')
                        CropAndSaveDirectFill(orig, pb, panel, w, h, savePath);
                    else
                        CropAndSaveDirectUniform(orig, pb, panel, w, h, savePath);
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
                    ShowCreatePortraitToast(outDir, uid);

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
                MessageBox.Show(
                    ex.Message,
                    "Portrait Creation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ── Portrait page drag-and-drop ──────────────────────────────────────

        // Shared DragEnter: accept image files and plain-text URLs
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

        // Shared DragLeave: remove drop-target visual
        private void PicKing_DragLeave(object sender, EventArgs e)
        {
            if (sender is Control ctrl && ctrl.ClientRectangle.Contains(ctrl.PointToClient(Cursor.Position)))
                return;
            RemoveDropTargetTint(sender as Control);
        }

        // Overlay a semi-transparent highlight on the parent panel while dragging
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

        // Shared DragDrop: load from file path or web URL
        private void PicKing_DragDrop(object sender, DragEventArgs e)
        {
            var pic = GetPortraitPictureBox(sender);
            if (pic == null) return;
            RemoveDropTargetTint(sender as Control);

            // ── file drop ────────────────────────────────────────────────────
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

            // ── URL text drop ─────────────────────────────────────────────────
            string url = e.Data.GetData(DataFormats.UnicodeText) as string
                      ?? e.Data.GetData(DataFormats.Text) as string;
            if (string.IsNullOrWhiteSpace(url)) return;
            url = url.Trim();

            // injection guard: http/https only, no whitespace/control chars
            if ((!url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                 !url.StartsWith("https://", StringComparison.OrdinalIgnoreCase)) ||
                url.Length > 2048)
                return;
            foreach (char c in url)
                if (char.IsControl(c) || char.IsWhiteSpace(c)) return;

            // quick check: look at the path segment for image extensions
            try
            {
                var uri = new Uri(url);
                string path = uri.AbsolutePath;
                string ext = System.IO.Path.GetExtension(path).ToLowerInvariant();
                string[] imageExts = { ".png", ".jpg", ".jpeg", ".gif", ".bmp", ".webp" };
                if (!ext.Contains("") && Array.IndexOf(imageExts, ext) < 0)
                {
                    using (var dlg = new forms.MyMessageDialog(
                        "That link does not point to a supported image file.\n\n" +
                        "Supported formats: PNG, JPG, GIF, BMP, WebP."))
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
                    using (var dlg = new forms.MyMessageDialog(
                        "Could not load the image from that address. " + ex.Message))
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
            if (pic.Name == "PicKingLrg") _kingGroupLrgInitialized = true;
            else if (pic.Name == "PicKingMed") _kingGroupMedInitialized = true;
            else if (pic.Name == "PicKingSml") _kingGroupSmlInitialized = true;
            else if (pic.Name == "PicKingSml2") _kingGroupSml2Initialized = true;
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

        private void ShowCreatePortraitToast(string outDir, string uid = null)
        {
            if (string.IsNullOrWhiteSpace(outDir) || !Directory.Exists(outDir))
                return;

            string portraitName = uid ?? Path.GetFileName(outDir);

            var toast = new Panel
            {
                BackColor = Color.FromArgb(24, 24, 24),
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(360, 94),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right
            };

            var title = new Label
            {
                AutoSize = false,
                Size = new Size(346, 20),
                Location = new Point(8, 6),
                ForeColor = Color.FromArgb(130, 230, 130),
                Font = new Font(Font, FontStyle.Bold),
                Text = "✓ Portrait created"
            };

            var name = new Label
            {
                AutoSize = false,
                Size = new Size(346, 18),
                Location = new Point(8, 30),
                ForeColor = Color.Gainsboro,
                Text = "Name: " + portraitName
            };

            var info = new Label
            {
                AutoSize = false,
                Size = new Size(346, 16),
                Location = new Point(8, 50),
                ForeColor = Color.Silver,
                Text = "Saved to game portraits folder"
            };

            var link = new LinkLabel
            {
                AutoSize = true,
                Location = new Point(8, 68),
                LinkColor = Color.DeepSkyBlue,
                ActiveLinkColor = Color.White,
                VisitedLinkColor = Color.DeepSkyBlue,
                Text = "Open folder"
            };
            link.LinkClicked += (s, e) =>
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = outDir,
                        UseShellExecute = true
                    });
                }
                catch { }
            };

            toast.Controls.Add(title);
            toast.Controls.Add(name);
            toast.Controls.Add(info);
            toast.Controls.Add(link);
            toast.Location = new Point(ClientSize.Width - toast.Width - 12, ClientSize.Height - toast.Height - 12);

            Controls.Add(toast);
            toast.BringToFront();

            var hideTimer = new System.Windows.Forms.Timer { Interval = 5000 };
            hideTimer.Tick += (s, e) =>
            {
                hideTimer.Stop();
                hideTimer.Dispose();
                if (!toast.IsDisposed)
                {
                    Controls.Remove(toast);
                    toast.Dispose();
                }
            };
            hideTimer.Start();
        }

        private string CompactPathForToast(string fullPath)
        {
            if (string.IsNullOrWhiteSpace(fullPath)) return fullPath;

            string normalized = fullPath.Replace('\\', '/');
            string[] anchors = {
                "/LocalLow/Owlcat",
                "/My Games/",
                "/Portraits/",
                "/PillarsOfEternity",
                "/Data/data/art/gui/portraits"
            };

            foreach (var anchor in anchors)
            {
                int idx = normalized.IndexOf(anchor, StringComparison.OrdinalIgnoreCase);
                if (idx >= 0)
                {
                    return normalized.Substring(idx);
                }
            }

            if (normalized.Length > 56)
                return "..." + normalized.Substring(normalized.Length - 56);

            return normalized;
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

            try { AdjustActivePortraitPanelAspect(KingPortraitGroupSelection.Large); } catch { }
            try { AdjustActivePortraitPanelAspect(KingPortraitGroupSelection.Small); } catch { }
            try { AdjustActivePortraitPanelAspect(KingPortraitGroupSelection.Sml2); } catch { }

            FitImageToPanel(PicKingLrg);
            FitImageToPanel(PicKingSml);
            FitImageToPanel(PicKingSml2);

            if (HasPortraitSpecific(gameType, "MEDIUM_WIDTH") &&
                HasPortraitSpecific(gameType, "MEDIUM_HEIGHT"))
            {
                StoreOriginalImage(PicKingMed, new Bitmap(gameType.PlaceholderPortrait));
                try { AdjustActivePortraitPanelAspect(KingPortraitGroupSelection.Medium); } catch { }
                FitImageToPanel(PicKingMed);
            }

                Focus();
            }
            catch
            {
            }
        }

        private void CropAndSaveDirectFill(
            Image original,
            PictureBox pb,
            Panel panel,
            int targetW,
            int targetH,
            string outPath)
        {
            if (original == null) return;

            int imgW = original.Width;
            int imgH = original.Height;

            Rectangle visible = pb.RectangleToClient(
                panel.RectangleToScreen(panel.ClientRectangle));

            if (visible.Width <= 0 || visible.Height <= 0) return;

            float scaleX = (float)imgW / pb.ClientSize.Width;
            float scaleY = (float)imgH / pb.ClientSize.Height;

            // Center of the visible area in original image coordinates
            float centerX = (visible.X + visible.Width / 2f) * scaleX;
            float centerY = (visible.Y + visible.Height / 2f) * scaleY;

            // Initial crop from the visible area
            int cropW = (int)Math.Round(visible.Width * scaleX);
            int cropH = (int)Math.Round(visible.Height * scaleY);
            if (cropW <= 0 || cropH <= 0) return;

            // Force the crop rectangle to have exactly the target aspect ratio
            // so the final resize is a pure uniform scale with no distortion
            float targetAR = (float)targetW / targetH;
            if (cropW * targetH > cropH * targetW)
                cropW = (int)Math.Round(cropH * targetAR);
            else if (cropW * targetH < cropH * targetW)
                cropH = (int)Math.Round(cropW / targetAR);

            // Center the crop on the user's view, clamped to image bounds
            int cropX = Math.Max(0, Math.Min(imgW - cropW,
                (int)Math.Round(centerX - cropW / 2f)));
            int cropY = Math.Max(0, Math.Min(imgH - cropH,
                (int)Math.Round(centerY - cropH / 2f)));

            using (Bitmap cropped = new Bitmap(cropW, cropH))
            {
                using (Graphics g = Graphics.FromImage(cropped))
                {
                    g.CompositingQuality =
                        System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.InterpolationMode =
                        System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode =
                        System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.PixelOffsetMode =
                        System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    g.DrawImage(original,
                        new Rectangle(0, 0, cropW, cropH),
                        new RectangleF(cropX, cropY, cropW, cropH),
                        GraphicsUnit.Pixel);
                }

                // Pure uniform resize — AR already matches exactly
                using (Bitmap output = new Bitmap(targetW, targetH))
                {
                    using (Graphics g = Graphics.FromImage(output))
                    {
                        g.CompositingQuality =
                            System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        g.InterpolationMode =
                            System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.SmoothingMode =
                            System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        g.PixelOffsetMode =
                            System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                        g.DrawImage(cropped,
                            new Rectangle(0, 0, targetW, targetH),
                            new Rectangle(0, 0, cropW, cropH),
                            GraphicsUnit.Pixel);
                    }

                    output.Save(
                        outPath,
                        System.Drawing.Imaging.ImageFormat.Png);
                }
            }
        }

        private void CropAndSaveDirectUniform(
            Image original,
            PictureBox pb,
            Panel panel,
            int targetW,
            int targetH,
            string outPath)
        {
            if (original == null) return;

            int imgW = original.Width;
            int imgH = original.Height;

            // The panel viewport, mapped into picture-box coordinates.
            Rectangle visible = pb.RectangleToClient(
                panel.RectangleToScreen(panel.ClientRectangle));

            if (visible.Width <= 0 || visible.Height <= 0) return;

            // Map from displayed pixels back to original image pixels.
            float scaleX = (float)imgW / pb.ClientSize.Width;
            float scaleY = (float)imgH / pb.ClientSize.Height;

            float srcX = visible.X * scaleX;
            float srcY = visible.Y * scaleY;
            float srcW = visible.Width * scaleX;
            float srcH = visible.Height * scaleY;

            // Clamp to image bounds
            if (srcX < 0) { srcW += srcX; srcX = 0; }
            if (srcY < 0) { srcH += srcY; srcY = 0; }
            if (srcX + srcW > imgW) srcW = imgW - srcX;
            if (srcY + srcH > imgH) srcH = imgH - srcY;

            if (srcW <= 0 || srcH <= 0) return;

            int cropW = (int)Math.Round(srcW);
            int cropH = (int)Math.Round(srcH);
            if (cropW <= 0 || cropH <= 0) return;

            // Step 1 — crop the visible area from the original
            using (Bitmap cropped = new Bitmap(cropW, cropH))
            {
                using (Graphics g = Graphics.FromImage(cropped))
                {
                    g.CompositingQuality =
                        System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.InterpolationMode =
                        System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode =
                        System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.PixelOffsetMode =
                        System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    g.DrawImage(original,
                        new Rectangle(0, 0, cropW, cropH),
                        new RectangleF(srcX, srcY, srcW, srcH),
                        GraphicsUnit.Pixel);
                }

                // Step 2 — uniform-resize to target dimensions (no stretching)
                using (Bitmap output = new Bitmap(targetW, targetH))
                {
                    using (Graphics g = Graphics.FromImage(output))
                    {
                        g.CompositingQuality =
                            System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        g.InterpolationMode =
                            System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.SmoothingMode =
                            System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        g.PixelOffsetMode =
                            System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                        g.Clear(Color.Black);

                        float scale = Math.Min(
                            (float)targetW / cropW,
                            (float)targetH / cropH);
                        int destW = (int)Math.Round(cropW * scale);
                        int destH = (int)Math.Round(cropH * scale);
                        int destX = (targetW - destW) / 2;
                        int destY = (targetH - destH) / 2;

                        g.DrawImage(cropped,
                            new Rectangle(destX, destY, destW, destH),
                            new Rectangle(0, 0, cropW, cropH),
                            GraphicsUnit.Pixel);
                    }

                    output.Save(
                        outPath,
                        System.Drawing.Imaging.ImageFormat.Png);
                }
            }
        }

        private void PicPortraitTemp_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        
        private void PicPortraitTemp_Click(object sender, EventArgs e)
        {
            //string path = SystemControl.FileControl.OpenFileLocation(TextVariables.TEXT_IMAGEFILTER, TextVariables.TEXT_TITLEOPENFILE);

            //if (path == "!NONE!")
            //{
            //    //using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_WRONGFORMAT, CoreSettings.Default.SelectedLang))
            //    //{
            //    //    Message.StartPosition = FormStartPosition.CenterParent;
            //    //    Message.ShowDialog();
            //    //}

            //    if (_isAnyLoadedToPortraitPage == true)
            //    {
            //        LoadTempImagesToPicBox(_imageSelectionFlag);
            //        ResizeVisibleImagesToWindowSize();
            //        return;
            //    }

            //    _isAnyLoadedToPortraitPage = false;
            //    LoadTempImagesToPicBox(_imageSelectionFlag);
            //    ResizeVisibleImagesToWindowSize();
            //    return;
            //}
            //else
            //{
            //    _isAnyLoadedToPortraitPage = true;
            //    GenerateImageSelectionFlagString(_imageSelectionFlag);
            //    CreateAllImagesInTemp(path, _imageSelectionFlag);
            //    LoadTempImagesToPicBox(_imageSelectionFlag);
            //    ResizeVisibleImagesToWindowSize();
            //}
            //Focus();
        }

        private void ButtonLocalPortraitLoad_Click(object sender, EventArgs e)
        {
            PicPortraitTemp_Click(sender, e);
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
            //RootFunctions.HideScrollBar(PanelPortraitLrg);
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
            //RootFunctions.HideScrollBar(PanelPortraitMed);
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
                _isDraggingMouse = 3;
            }
        }

        private void PicPortraitSml2_MouseMove(object sender, MouseEventArgs e)
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
            //RootFunctions.HideScrollBar(PanelPortraitSml);
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
            ResizeVisibleImagesToWindowSize();
        }

        private void ButtonCreatePortrait_Click(object sender, EventArgs e)
        {
            //ButtonToMainPageAndFolder.Enabled = true;
            //RootFunctions.LayoutDisable(LayoutScalePage);
            _activeMenuIndex = 100;

            string path = "";
            bool placeableFilepath = false;
            uint pseudoUniqueName = 0;

            //if (!SystemControl.FileControl.Readonly.DirectoryExists(ACTIVE_PATHS[_gameSelected]))
            //{
            //    RootFunctions.LayoutEnable(LayoutFinalPage);
            //    Focus();
            //    LabelFinalMesg.Text = TextVariables.LABEL_CREATEDERROR;
            //    LabelDirLoc.Text = ACTIVE_PATHS[_gameSelected];
            //    ButtonToMainPageAndFolder.Enabled = false;
            //    return;
            //}

            if (_tunneledNameToPortraitPage != "!NONE!")
            {
                path = _tunneledNameToPortraitPage;
                _tunneledNameToPortraitPage = "!NONE!";
                GeneratePortraits(path);
                placeableFilepath = true;
            }

            //while (!placeableFilepath)
            //{
            //    path = ACTIVE_PATHS[_gameSelected] + "\\" + Convert.ToString(pseudoUniqueName);
            //    if (!Directory.Exists(path))
            //    {
            //        GeneratePortraits(path);
            //        placeableFilepath = true;
            //    }
            //    pseudoUniqueName++;
            //}

            //if (CheckPortraitExistence(path))
            //{
            //    RootFunctions.LayoutEnable(LayoutFinalPage);
            //    Focus();
            //    LabelFinalMesg.Text = TextVariables.LABEL_CREATEDOK;
            //    LabelDirLoc.Text = path;
            //}
            //else
            //{
            //    RootFunctions.LayoutEnable(LayoutFinalPage);
            //    Focus();
            //    LabelFinalMesg.Text = TextVariables.LABEL_CREATEDERROR;
            //    LabelDirLoc.Text = path;
            //    ButtonToMainPageAndFolder.Enabled = false;
            //}
        }
        
        private void PicPortraitMed_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //using (Image img = new Bitmap(TEMP_MEDIUM_APPEND))
            //    ResizeImageToParentControl(PicPortraitMed, img, PanelPortraitMed);
        }
        
        private void PicPortraitLrg_MouseDoubleClick(object sedner, MouseEventArgs e)
        {
            //using (Image img = new Bitmap(TEMP_LARGE_APPEND))
            //    ResizeImageToParentControl(PicPortraitLrg, img, PanelPortraitLrg);
        }
        
        private void PicPortraitSml_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //using (Image img = new Bitmap(TEMP_SMALL_APPEND))
            //    ResizeImageToParentControl(PicPortraitSml, img, PanelPortraitSml);
        }
        
        private void LabelMedImg_MouseHover(object sender, EventArgs e)
        {
            //LabelMedImage.Text = TextVariables.LABEL_MEDIUMIMG2;
        }
        
        private void LabelLrgImg_MouseHover(object sender, EventArgs e)
        {
            //LabelLrgImg.Text = TextVariables.LABEL_LARGEIMG2;
        }
        
        private void LabelSmlImg_MouseHover(object sender, EventArgs e)
        {
            //LabelSmlImg.Text = TextVariables.LABEL_SMALLIMG2;
        }
        
        private void LabelMedImg_MouseLeave(object sender, EventArgs e)
        {
            //LabelMedImage.Text = TextVariables.LABEL_MEDIUMIMG;
        }
        
        private void LabelLrgImg_MouseLeave(object sender, EventArgs e)
        {
            //LabelLrgImg.Text = TextVariables.LABEL_LARGEIMG;
        }
        
        private void LabelSmlImg_MouseLeave(object sender, EventArgs e)
        {
            //LabelSmlImg.Text = TextVariables.LABEL_SMALLIMG;
        }
        
        private void ButtonWebPortraitLoad_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 200;
            //RootFunctions.LayoutDisable(LayoutFilePage);            
            //RootFunctions.LayoutEnable(LayoutURLDialog);
            Focus();
            //AnyButton_Leave(ButtonDenyWeb, e);
            //AnyButton_Leave(ButtonLoadWeb, e);
        }
        
        private void ButtonHintOnScalePage_Click(object sender, EventArgs e)
        {
            //using (MyMessageDialog Hint = new MyMessageDialog(TextVariables.HINT_SCALEPAGE, CoreSettings.Default.SelectedLang))
            //{
            //    Hint.StartPosition = FormStartPosition.CenterParent;
            //    Hint.ShowDialog();
            //}
        }

        private void ButtonHintOnFilePage_Click(object sender, EventArgs e)
        {
            //using (MyMessageDialog Hint = new MyMessageDialog(TextVariables.HINT_FILEPAGE, CoreSettings.Default.SelectedLang))
            //{
            //    Hint.StartPosition = FormStartPosition.CenterParent;
            //    Hint.ShowDialog();
            //}
        }

        private void PictureBoxTitle_Click(object sender, EventArgs e)
        {
            if (_gameSelected == 'p')
            {
                _gameSelected = 'w';
            }
            else if (_gameSelected == 'r')
            {
                _gameSelected = 'p';
            }
            else
            {
                _gameSelected = 'r';
            }

            CoreSettings.Default.GameType = _gameSelected;
            CoreSettings.Default.Save();
            UpdateColorScheme();

            //if (!ValidatePortraitPath(ACTIVE_PATHS[_gameSelected]))
            //{
            //    using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_GAMEFOLDERNOTFOUND, CoreSettings.Default.SelectedLang))
            //    {
            //        Message.StartPosition = FormStartPosition.CenterParent;
            //        Message.ShowDialog();
            //    }
            //    RemoveClickEventsFromMainButtons();
            //}
            //else
            //{
            //    AddClickEventsToMainButtons();
            //}

            if (_gameSelected == 'r')
            {
                RemoveClickEventsFromCustomPortraitsButtons();
                //CheckBoxVerified.Checked = false;
                //ButtonLoadCustom.Visible = false;
                //ButtonLoadCustomNPC.Visible = false;
                //ButtonLoadCustomArmy.Visible = false;
                return;
            }

            //if (!ValidateCustomPath(ACTIVE_PATHS[_gameSelected]) && 
            //    (UseStamps.Default.isAwareNPC == "NotRevealed" || UseStamps.Default.isAwareNPC == "WorkRevealed"))
            //{
            //    using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_CUSTOMNOTFOUND, CoreSettings.Default.SelectedLang))
            //    {
            //        Message.StartPosition = FormStartPosition.CenterParent;
            //        Message.ShowDialog();
            //    }
            //    RemoveClickEventsFromCustomPortraitsButtons();
            //    CheckBoxVerified.Checked = false;
            //    UseStamps.Default.isAwareNPC = "NotWorkRevealed";
            //    UseStamps.Default.Save();
            //    ButtonLoadCustom.Visible = false;
            //    ButtonLoadCustomNPC.Visible = false;
            //    ButtonLoadCustomArmy.Visible = false;

            //}
            //else if (ValidateCustomPath(ACTIVE_PATHS[_gameSelected]) 
            //    && (UseStamps.Default.isAwareNPC == "NotRevealed" || UseStamps.Default.isAwareNPC == "NotWorkRevealed"))
            //{
            //    using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_CUSTOMFOUND, CoreSettings.Default.SelectedLang))
            //    {
            //        Message.StartPosition = FormStartPosition.CenterParent;
            //        Message.ShowDialog();
            //    }
            //    AddClickEventsToCustomPortraitsButtons();
            //    CheckBoxVerified.Checked = true;
            //    UseStamps.Default.isAwareNPC = "WorkRevealed";
            //    UseStamps.Default.Save();
            //    ButtonLoadCustom.Visible = true;
            //    ButtonLoadCustomNPC.Visible = true;
            //    ButtonLoadCustomArmy.Visible = true;
            //}

        }
        
        private void ButtonOpenFolder_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(ACTIVE_PATHS[_gameSelected]);
        }
        
        private void ButtonChangePortrait_Click(object sender, EventArgs e)
        {
            //if (ListGallery.Items.Count < 1)
            {
                return;
            }

            //if (ListGallery.SelectedItems.Count < 1)
            {
                //using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_NONESELECTED, CoreSettings.Default.SelectedLang))
                //{
                //    Message.StartPosition = FormStartPosition.CenterParent;
                //    Message.ShowDialog();
                //}

                return;
            }
            //else if (ListGallery.SelectedItems.Count > 1)
            {
                //using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_SELECTEDMORE, CoreSettings.Default.SelectedLang))
                //{
                //    Message.StartPosition = FormStartPosition.CenterParent;
                //    Message.ShowDialog();
                //}
            }

            //ListViewItem item = ListGallery.SelectedItems[0];
            //using (Image img = new Bitmap(GAME_TYPES[_gameSelected].PortraitPlaceholderImage))
            //    ClearPictureBoxImages(img);
            SystemControl.FileControl.ClearTempImages();
            SystemControl.FileControl.CreateDirectory("temp_DoNotDeleteWhileRunning\\");

            //string path = item.Tag.ToString().Split('>')[0];
            //string type = item.Tag.ToString().Split('>')[1];

            //try
            //{
            //    using (Image img = new Bitmap(path + LARGE_APPEND))
            //        img.Save(TEMP_LARGE_APPEND);
            //}
            //catch
            //{
            //    using (Image img = new Bitmap(path + MEDIUM_APPEND))
            //    {
            //        Bitmap newImg = ImageControl.Direct.Resize(img, 692, 1024);
            //        newImg.Save(TEMP_LARGE_APPEND);
            //    }
            //}

            //using (Image img = new Bitmap(path + MEDIUM_APPEND))
            //    img.Save(TEMP_MEDIUM_APPEND);
            //using (Image img = new Bitmap(path + SMALL_APPEND))
            //    img.Save(TEMP_SMALL_APPEND);

            LoadTempImagesToPicBox(100);
            GenerateImageSelectionFlagString(0);
            _tunneledNameToPortraitPage = "!NONE!";

            //using (MyInquiryDialog Inquiry = new MyInquiryDialog(TextVariables.INQR_DELETEOLD, CoreSettings.Default.SelectedLang))
            //{
            //    Inquiry.StartPosition = FormStartPosition.CenterParent;

            //    if (Inquiry.ShowDialog() == DialogResult.OK)
            //    {
            //        ListGallery.Items.RemoveByKey(item.Text);
            //        ImgListGallery.Images.RemoveByKey(item.Text);

            //        //if (type == "LOCAL")
            //        //{
            //        //    SystemControl.FileControl.DeleteDirectoryRecursive(ACTIVE_PATHS[_gameSelected] + "\\" + item.Text);
            //        //}
            //        //else
            //        //{
            //        //    SystemControl.FileControl.DeleteDirectoryRecursive(path + "\\BACKUP");
            //        //    SystemControl.FileControl.CreateDirectory(path + "\\BACKUP");
            //        //    SystemControl.FileControl.CopyFile(path + LARGE_APPEND, path + "\\BACKUP" + LARGE_APPEND);
            //        //    SystemControl.FileControl.CopyFile(path + MEDIUM_APPEND, path + "\\BACKUP" + MEDIUM_APPEND);
            //        //    SystemControl.FileControl.CopyFile(path + SMALL_APPEND, path + "\\BACKUP" + SMALL_APPEND);
            //        //}
            //        _tunneledNameToPortraitPage = path;
            //        item.Remove();
            //    }
            //    else
            //    {
            //        if (type == "CUSTOM")
            //        {
            //            _tunneledNameToPortraitPage = Path.Combine(path, path.Split('\\').Last().Split('-').Last() + DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString());
            //        }
            //    }
            //}

            ButtonToMainPage3_Click(sender, e);
            //RootFunctions.LayoutDisable(LayoutMainPage);
            //RootFunctions.LayoutEnable(LayoutFilePage);
            Focus();
            RestoreFilePageToInit();
            _isAnyLoadedToPortraitPage = true;
            ResizeVisibleImagesToWindowSize();
        }

        private void ButtonDeletePortait_Click(object sender, EventArgs e)
        {
            //if (ListGallery.Items.Count < 1)
            {
                return;
            }

            //if (ListGallery.SelectedItems.Count < 1)
            {
                //using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_NONESELECTED, CoreSettings.Default.SelectedLang))
                //{
                //    Message.StartPosition = FormStartPosition.CenterParent;
                //    Message.ShowDialog();
                //}
                return;
            }

            //using (MyInquiryDialog Message = new MyInquiryDialog(TextVariables.MESG_DELETE + ListGallery.SelectedItems.Count, CoreSettings.Default.SelectedLang))
            //{
            //    Message.StartPosition = FormStartPosition.CenterParent;
            //    if (Message.ShowDialog() != DialogResult.OK)
            //    {
            //        return;
            //    }
            //}

            //foreach (ListViewItem item in ListGallery.SelectedItems)
            //{
            //    string path = ACTIVE_PATHS[_gameSelected] + "\\" + item.Text + "\\";
            //    ImgListGallery.Images.RemoveByKey(item.Text);
            //    item.Remove();
            //    SystemControl.FileControl.DeleteDirectoryRecursive(path);
            //}
            _cancellationTokenSource.Cancel();
            //ClearImageListsSync(ListGallery, ImgListGallery);

            //if (!LoadGallery(ACTIVE_PATHS[_gameSelected]))
            //{
            //    ButtonToMainPage3_Click(sender, e);
            //    return;
            //}
        }

        private void ButtonHintFolder_Click(object sender, EventArgs e)
        {
            //using (MyMessageDialog Hint = new MyMessageDialog(TextVariables.HINT_GALLERYPAGE, CoreSettings.Default.SelectedLang))
            //{
            //    Hint.StartPosition = FormStartPosition.CenterParent;
            //    Hint.ShowDialog();
            //}
        }

        private void ButtonChooseFolder_Click(object sender, EventArgs e)
        {
            if (_extractFolderPath != "!NONE!")
            {
                //ClearImageListsSync(ListExtract, ImgListExtract);
            }

            _cancellationTokenSource?.Cancel();
            string defaultDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            if (!SystemControl.FileControl.Readonly.DirectoryExists(defaultDir))
            {
                defaultDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            using (FolderBrowserDialog FolderChoose = new FolderBrowserDialog()
            {
                SelectedPath = defaultDir,
                //Description = TextVariables.TEXT_FOLDEROPEN,
                ShowNewFolderButton = false,

            })
            {
                if (FolderChoose.ShowDialog() == DialogResult.OK)
                {
                    _extractFolderPath = FolderChoose.SelectedPath;
                }
                else
                {
                    FolderChoose.Dispose();
                    _extractFolderPath = "!NONE!";
                    return;
                }
            }

            if (!SystemControl.FileControl.Readonly.DirectoryExists(_extractFolderPath))
            {
                _extractFolderPath = "!NONE!";
                return;
            }

            //ClearImageListsSync(ListExtract, ImgListExtract);
            _cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = _cancellationTokenSource.Token;
            ExploreDirectory(_extractFolderPath, cancellationToken);
        }
        
        private void ButtonOpenFolders_Click(object sender, EventArgs e)
        {
            if (_extractFolderPath == "!NONE!")
            {
                return;
            }

            //System.Diagnostics.Process.Start(ACTIVE_PATHS[_gameSelected]);
            System.Diagnostics.Process.Start(_extractFolderPath);
            ButtonToMainPage2_Click(sender, e);
        }
        
        private void ButtonHintExtract_Click(object sender, EventArgs e)
        {
            //using (MyMessageDialog Hint = new MyMessageDialog(TextVariables.HINT_EXTRACTPAGE, CoreSettings.Default.SelectedLang))
            //{
            //    Hint.StartPosition = FormStartPosition.CenterParent;
            //    Hint.ShowDialog();
            //}
        }
        
        private void LabelCopyright_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/zeightOFFICIAL/portrait-manager-owlcat");
            }
            catch
            {
                return;
            }
        }

        private void LabelVersion_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/zeightOFFICIAL/portrait-manager-owlcat/releases/tag/1.3.5.0c");
            }
            catch
            {
                return;
            }
        }

        private void AnyPrimeButton_Enter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button != null)
                {
                    //button.BackColor = GAME_TYPES[_gameSelected].ControlForeColor;
                    //button.ForeColor = GAME_TYPES[_gameSelected].ControlBackColor;
                }
            }
        }
        
        private void AnyPrimeButton_Leave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button != null)
                {
                    //button.BackColor = GAME_TYPES[_gameSelected].ControlBackColor;
                    //button.ForeColor = GAME_TYPES[_gameSelected].ControlForeColor;
                }
            }
        }

        private void AnyButton_Enter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button != null)
                {
                    button.BackColor = Color.White;
                    button.ForeColor = Color.Black;
                }
            }
        }

        private void AnyButton_Leave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button != null && button.Enabled == true)
                {
                    button.BackColor = Color.Black;
                    button.ForeColor = Color.White;
                }
            }
        }

        private void ButtonRestorePath_Click(object sender, EventArgs e)
        {
            //TextBoxFullPath.Text = GAME_TYPES[_gameSelected].NormalDefaultDirectory;
        }

        private void TextBoxFullPath_TextChanged(object sender, EventArgs e)
        {
            //ButtonValidatePath.Text = TextVariables.BUTTON_VALIDATE;
            //ButtonValidatePath.BackColor = Color.Black;
            //ButtonValidatePath.ForeColor = Color.White;
            //ButtonValidatePath.Enabled = true;
            //ButtonApplyChange.Text = TextVariables.BUTTON_APPLY;
            //ButtonApplyChange.BackColor = Color.Black;
            //ButtonApplyChange.ForeColor = Color.White;
            //ButtonApplyChange.Enabled = true;
        }

        private void ButtonValidatePath_Click(object sender, EventArgs e)
        {
            //if (ValidatePortraitPath(TextBoxFullPath.Text))
            //{
            //    ButtonValidatePath.Text = TextVariables.BUTTON_OK;
            //    ButtonValidatePath.ForeColor = Color.White;
            //    ButtonValidatePath.BackColor = Color.LimeGreen;
            //    ButtonValidatePath.Enabled = false;
            //}
            //else
            //{
            //    ButtonValidatePath.Text = TextVariables.BUTTON_NO;
            //    ButtonValidatePath.ForeColor = Color.White;
            //    ButtonValidatePath.BackColor = Color.Red;
            //    ButtonValidatePath.Enabled = false;
            //}
        }

        private void ButtonSelectPath_Click(object sender, EventArgs e)
        {
            string defaultDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow");
            
            if (!SystemControl.FileControl.Readonly.DirectoryExists(defaultDir))
            {
                defaultDir = "";
            }

            using (FolderBrowserDialog FolderChoose = new FolderBrowserDialog()
            {
                SelectedPath = defaultDir,
                //Description = TextVariables.TEXT_PATHOPEN,
                ShowNewFolderButton = false,
            })
            {
                if (FolderChoose.ShowDialog() == DialogResult.OK)
                {
                    //TextBoxFullPath.Text = FolderChoose.SelectedPath;
                }
                else
                {
                    return;
                }
            }
        }
        
        private void ButtonLoadWeb_Click(object sender, EventArgs e)
        {
            //string url = TextBoxURL.Text;

            try
            {
                //HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //request.Method = "HEAD";
                //HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //response.Close();
                //RootFunctions.LayoutDisable(LayoutURLDialog);
                //RootFunctions.LayoutEnable(LayoutFilePage);
                _activeMenuIndex = 1;
                Focus();
                //CheckWebResourceAndLoad(url);
                ResizeVisibleImagesToWindowSize();
                //TextBoxURL.Text = TextVariables.TEXTBOX_URL_INPUT;
                GenerateImageSelectionFlagString(_imageSelectionFlag);
            }
            catch
            {
                Focus();
                //TextBoxURL.Text = TextVariables.TEXTBOX_URL_WRONG;
            }
            Focus();
        }
        
        private void ButtonDenyWeb_Click(object sender, EventArgs e)
        {
            //RootFunctions.LayoutDisable(LayoutURLDialog);
            //RootFunctions.LayoutEnable(LayoutFilePage);
            //TextBoxURL.Text = TextVariables.TEXTBOX_URL_INPUT;
            ResizeVisibleImagesToWindowSize();
            _activeMenuIndex = 1;

            Focus();
        }
        
        private void TextBoxURL_DragEnter(object sender, DragEventArgs e)
        {
            //TextBoxURL.Clear();
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        
        private void TextBoxURL_DragDrop(object sender, DragEventArgs e)
        {
            TextBox senderTextBox = (TextBox)sender;

            senderTextBox.Text = (string)e.Data.GetData(DataFormats.Text);
            if (!senderTextBox.Text.Contains("http"))
            {
                senderTextBox.Text = "http://" + senderTextBox.Text;
            }
        }
        
        private void TextBoxURL_Enter(object sender, EventArgs e)
        {
            //TextBoxURL.Clear();
        }
        
        private void ButtonToMainPageAndFolder_Click(object sender, EventArgs e)
        {
            _activeMenuIndex = 0;
            //ButtonToMainPageAndFolder.BackColor = Color.Black;
            //ButtonToMainPageAndFolder.ForeColor = Color.White;
            //RootFunctions.LayoutDisable(LayoutFinalPage);
            ReplacePictureBoxImagesToDefault();
            _isAnyLoadedToPortraitPage = false;
            ParentLayoutsDisable();
            //System.Diagnostics.Process.Start(LabelDirLoc.Text);
            //RootFunctions.LayoutEnable(LayoutMainPage);
            Focus();
            //ButtonToMainPageAndFolder.Enabled = true;
        }
        
        private void ButtonNextImageType_Click(object sender, EventArgs e)
        {
            _imageSelectionFlag++;

            if (_imageSelectionFlag == 1)
            {
                //ButtonNextImageType.Text = TextVariables.BUTTON_ADVANCED2;
            }
            else
            {
                //ButtonNextImageType.Visible = false;
                //ButtonNextImageType.Enabled = false;
                //LblToAdvancedPage.Visible = false;
            }

            GenerateImageSelectionFlagString(_imageSelectionFlag);
            LoadTempImagesToPicBox(_imageSelectionFlag);
            ResizeVisibleImagesToWindowSize();
        }
        
        private void ButtonApplyChange_Click(object sender, EventArgs e)
        {
            //if (ButtonValidatePath.Text == TextVariables.BUTTON_OK)
            //{
            //    if (_gameSelected == 'p')
            //    {
            //        CoreSettings.Default.KINGPath = TextBoxFullPath.Text;
            //    }
            //    else if (_gameSelected == 'w')
            //    {
            //        CoreSettings.Default.WOTRPath = TextBoxFullPath.Text;
            //    }
            //    else if (_gameSelected == 'r')
            //    {
            //        CoreSettings.Default.ROGUEPath = TextBoxFullPath.Text;
            //    }

            //    AnyButton_Leave(sender, e);
            //    ButtonApplyChange.BackColor = Color.LimeGreen;
            //    ButtonApplyChange.ForeColor = Color.White;
            //    ButtonApplyChange.Enabled = false;
            //    ButtonApplyChange.Text = TextVariables.BUTTON_SUCESS;
            //    CoreSettings.Default.Save();
            //    AddClickEventsToMainButtons();
            //    //ACTIVE_PATHS[_gameSelected] = TextBoxFullPath.Text;
            //}
        }
        
        private void ButtonLoadNormal_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource?.Cancel();
            //ClearImageListsSync(ListGallery, ImgListGallery);
            //if (!LoadGallery(ACTIVE_PATHS[_gameSelected]))
            //{
            //    ButtonToMainPage3_Click(sender, e);
            //    return;
            //}
        }
        
        private void ButtonLoadCustom_Click(object sender, EventArgs e)
        {
            string fromPath, fromPath2;

            //fromPath = Path.Combine(ACTIVE_PATHS[_gameSelected], "..", "Portraits - Npc");
            //fromPath2 = Path.Combine(ACTIVE_PATHS[_gameSelected], "..", "Portraits - Army"); 
            _cancellationTokenSource?.Cancel();
            //ClearImageListsSync(ListGallery, ImgListGallery);

            //if (!LoadGalleryCustom(ACTIVE_PATHS[_gameSelected], true) ||
            //    !LoadGalleryCustom(fromPath, false) ||
            //    !LoadGalleryCustom(fromPath2, false))
            //{
            //    ButtonToMainPage3_Click(sender, e);
            //    return;
            //}
        }

        private bool LoadGalleryCustom(string fromRootPath, bool flag = false)
        {
            if (!SystemControl.FileControl.Readonly.DirectoryExists(fromRootPath))
            {
                return false;
            }

            _cancellationTokenSource?.Cancel();
            //ClearImageListsSync(ListGallery, ImgListGallery);
            _cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancelToken = _cancellationTokenSource.Token;

            Task.Factory.StartNew(() =>
            {
                RecursiveParsePortraitsFolderAsync(fromRootPath, cancelToken, flag);
            }, cancelToken);

            return true;
        }
        
        private void ButtonLoadCustomNPC_Click(object sender, EventArgs e)
        {
            string fromPath;

            //fromPath = Path.Combine(ACTIVE_PATHS[_gameSelected], "..", "Portraits - Npc");
            _cancellationTokenSource?.Cancel();
            //ClearImageListsSync(ListGallery, ImgListGallery);
            //if (!LoadGalleryCustom(fromPath, false))
            //{
            //    ButtonToMainPage3_Click(sender, e);
            //    return;
            //}
        }
        
        private void ButtonLoadCustomArmy_Click(object sender, EventArgs e)
        {
            string fromPath;

            //fromPath = Path.Combine(ACTIVE_PATHS[_gameSelected], "..", "Portraits - Army");
            //_cancellationTokenSource?.Cancel();
            //ClearImageListsSync(ListGallery, ImgListGallery);
            //if (!LoadGalleryCustom(fromPath, false))
            //{
            //    ButtonToMainPage3_Click(sender, e);
            //    return;
            //}
        }
        


        private void ButtonRT_Click(object sender, EventArgs e)
        {
            _gameSelected = 'r';
            UpdateColorScheme();
            RemoveClickEventsFromCustomPortraitsButtons();

            //if (!ValidatePortraitPath(ACTIVE_PATHS[_gameSelected]))
            //{
            //    RemoveClickEventsFromMainButtons();
            //}
            //else
            //{
            //    AddClickEventsToMainButtons();
            //}

            //ButtonLoadCustom.Visible = false;
            //ButtonLoadCustomNPC.Visible = false;
            //ButtonLoadCustomArmy.Visible = false;
            //CheckBoxVerified.Checked = false;

            CoreSettings.Default.GameType = _gameSelected;
            CoreSettings.Default.Save();
        }

        private void ButtonKingmaker_Click(object sender, EventArgs e)
        {
            _gameSelected = 'p';
            UpdateColorScheme();

            //if (!ValidatePortraitPath(ACTIVE_PATHS[_gameSelected]))
            //{
            //    RemoveClickEventsFromMainButtons();
            //}
            //else
            //{
            //    AddClickEventsToMainButtons();
            //}

            //if (!ValidateCustomPath(ACTIVE_PATHS[_gameSelected]) && (UseStamps.Default.isAwareNPC == "NotRevealed" || UseStamps.Default.isAwareNPC == "WorkRevealed"))
            //{
            //    using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_CUSTOMNOTFOUND, CoreSettings.Default.SelectedLang))
            //    {
            //        Message.StartPosition = FormStartPosition.CenterParent;
            //        Message.ShowDialog();
            //    }
            //    RemoveClickEventsFromCustomPortraitsButtons();
            //    CheckBoxVerified.Checked = false;
            //    UseStamps.Default.isAwareNPC = "NotWorkRevealed";
            //    UseStamps.Default.Save();
            //    ButtonLoadCustom.Visible = false;
            //    ButtonLoadCustomNPC.Visible = false;
            //    ButtonLoadCustomArmy.Visible = false;
            //}
            //else if (ValidateCustomPath(ACTIVE_PATHS[_gameSelected]) && (UseStamps.Default.isAwareNPC == "NotRevealed" || UseStamps.Default.isAwareNPC == "NotWorkRevealed"))
            //{
            //    using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_CUSTOMFOUND, CoreSettings.Default.SelectedLang))
            //    {
            //        Message.StartPosition = FormStartPosition.CenterParent;
            //        Message.ShowDialog();
            //    }
            //    AddClickEventsToCustomPortraitsButtons();
            //    CheckBoxVerified.Checked = true;
            //    UseStamps.Default.isAwareNPC = "WorkRevealed";
            //    UseStamps.Default.Save();
            //    ButtonLoadCustom.Visible = true;
            //    ButtonLoadCustomNPC.Visible = true;
            //    ButtonLoadCustomArmy.Visible = true;
            //}

            CoreSettings.Default.GameType = _gameSelected;
            CoreSettings.Default.Save();
        }

        private void ButtonWotR_Click(object sender, EventArgs e)
        {
            _gameSelected = 'w';
            UpdateColorScheme();

            //if (!ValidatePortraitPath(ACTIVE_PATHS[_gameSelected]))
            //{
            //    RemoveClickEventsFromMainButtons();
            //}
            //else
            //{
            //    AddClickEventsToMainButtons();
            //}

            //if (!ValidateCustomPath(ACTIVE_PATHS[_gameSelected]) && (UseStamps.Default.isAwareNPC == "NotRevealed" || UseStamps.Default.isAwareNPC == "WorkRevealed"))
            //{
            //    using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_CUSTOMNOTFOUND, CoreSettings.Default.SelectedLang))
            //    {
            //        Message.StartPosition = FormStartPosition.CenterParent;
            //        Message.ShowDialog();
            //    }
            //    RemoveClickEventsFromCustomPortraitsButtons();
            //    CheckBoxVerified.Checked = false;
            //    UseStamps.Default.isAwareNPC = "NotWorkRevealed";
            //    UseStamps.Default.Save();
            //    ButtonLoadCustom.Visible = false;
            //    ButtonLoadCustomNPC.Visible = false;
            //    ButtonLoadCustomArmy.Visible = false;
            //}
            //else if (ValidateCustomPath(ACTIVE_PATHS[_gameSelected]) && (UseStamps.Default.isAwareNPC == "NotRevealed" || UseStamps.Default.isAwareNPC == "NotWorkRevealed"))
            //{
            //    using (MyMessageDialog Message = new MyMessageDialog(TextVariables.MESG_CUSTOMFOUND, CoreSettings.Default.SelectedLang))
            //    {
            //        Message.StartPosition = FormStartPosition.CenterParent;
            //        Message.ShowDialog();
            //    }
            //    AddClickEventsToCustomPortraitsButtons();
            //    CheckBoxVerified.Checked = true;
            //    UseStamps.Default.isAwareNPC = "WorkRevealed";
            //    UseStamps.Default.Save();
            //    ButtonLoadCustom.Visible = true;
            //    ButtonLoadCustomNPC.Visible = true;
            //    ButtonLoadCustomArmy.Visible = true;
            //}

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
                LabelSelectPathSelected.Text = " - ";
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
            LabelCreatePortrait.Text = "◈" + LabelCreatePortrait.Text;
            LabelCreatePortrait.ForeColor = GameTypes[_gameSelected].ForeColor;
        }

        private void LabelCreatePortrait_MouseLeave(object sender, EventArgs e)
        {
            LabelCreatePortrait.Text = LabelCreatePortrait.Text.Replace("◈", "");
            LabelCreatePortrait.ForeColor = Color.White;
        }

        private void LabelExtract_MouseEnter(object sender, EventArgs e)
        {
            LabelExtract.Text = "◈" + LabelExtract.Text;
            LabelExtract.ForeColor = GameTypes[_gameSelected].ForeColor;
        }

        private void LabelExtract_MouseLeave(object sender, EventArgs e)
        {
            LabelExtract.Text = LabelExtract.Text.Replace("◈", "");
            LabelExtract.ForeColor = Color.White;
        }

        private void LabelBrowse_MouseEnter(object sender, EventArgs e)
        {
            LabelBrowse.Text = "◈" + LabelBrowse.Text;
            LabelBrowse.ForeColor = GameTypes[_gameSelected].ForeColor;
        }

        private void LabelBrowse_MouseLeave(object sender, EventArgs e)
        {
            LabelBrowse.Text = LabelBrowse.Text.Replace("◈", "");
            LabelBrowse.ForeColor = Color.White;
        }

        private void LabelSettingsPage_MouseEnter(object sender, EventArgs e)
        {
            LabelSettingsPage.Text = "◈" + LabelSettingsPage.Text;
            LabelSettingsPage.ForeColor = GameTypes[_gameSelected].ForeColor;
        }

        private void LabelSettingsPage_MouseLeave(object sender, EventArgs e)
        {
            LabelSettingsPage.Text = LabelSettingsPage.Text.Replace("◈", "");
            LabelSettingsPage.ForeColor = Color.White;
        }

        private void LabelExit_MouseEnter(object sender, EventArgs e)
        {
            LabelExit.Text = "◈" + LabelExit.Text;
            LabelExit.ForeColor = GameTypes[_gameSelected].ForeColor;
        }

        private void LabelExit_MouseLeave(object sender, EventArgs e)
        {
            LabelExit.Text = LabelExit.Text.Replace("◈", "");
            LabelExit.ForeColor = Color.White;
        }

        private void LabelExit_Click(object sender, EventArgs e)
        {
            DisposePrimeImages();
            //ClearImageListsSync(ListGallery, ImgListGallery);
            //ClearImageListsSync(ListExtract, ImgListExtract);
            SystemControl.FileControl.ClearTempImages();
            CoreSettings.Default.GamePath = "0";
            CoreSettings.Default.GameType = '-';
            CoreSettings.Default.Save();
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
                    msg.ShowDialog();
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
    }
}