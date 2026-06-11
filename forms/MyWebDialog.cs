using PortraitManager.Properties;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace PortraitManager.forms
{
    public partial class MyWebDialog : Form
    {
        private readonly PrivateFontCollection _fontCollection;
        public Image DownloadedImage { get; private set; }

        public MyWebDialog(string locale)
        {
            _fontCollection = SystemControl.FileControl.InitCustomFont(
                Resources.BebasNeue_Regular, Resources.BebasNeue_Regular_ru);

            try { Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(locale); }
            catch { }

            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.Selectable, false);
            Shown += MyWebDialog_Shown;

            ApplyFont();
            ApplyTexts();
            TextBoxURL.Select();

            // add a subtle drag-drop hint below the buttons
            var tipLabel = new Label
            {
                Text = "Tip: you can also drop an image file directly onto the portrait panel.",
                ForeColor = Color.Gray,
                BackColor = Color.Transparent,
                AutoSize = false,
                Size = new Size(ClientSize.Width - 32, 20),
                Location = new Point(16, ClientSize.Height - 26),
                TextAlign = ContentAlignment.MiddleLeft,
                Font = SystemFonts.MessageBoxFont
            };
            Controls.Add(tipLabel);
        }

        private void MyWebDialog_Shown(object sender, EventArgs e)
        {
            try
            {
                Form anchor = Owner;
                while (anchor != null && anchor.Owner != null)
                    anchor = anchor.Owner;
                if (anchor != null)
                {
                    Width = anchor.ClientSize.Width;
                    Left = anchor.PointToScreen(System.Drawing.Point.Empty).X;
                }
            }
            catch { }
        }

        public MyWebDialog(string message, string locale) : this(locale) { }

        public string URL => TextBoxURL?.Text?.Trim();

        private void ApplyFont()
        {
            try
            {
                bool ru = Thread.CurrentThread.CurrentUICulture.Equals(
                    CultureInfo.GetCultureInfo("ru-RU"));
                var family = ru ? _fontCollection.Families[1] : _fontCollection.Families[0];
                LabelTitle.Font    = new Font(family, 18f);
                LabelHint.Font     = new Font(family, 12f);
                TextBoxURL.Font    = new Font(family, 14f);
                ButtonOK.Font      = new Font(family, 14f);
                ButtonCancel.Font  = new Font(family, 14f);
            }
            catch { }
        }

        private void ApplyTexts()
        {
            try { LabelTitle.Text   = TextVariables.WEBDIALOG_TITLE;         } catch { }
            try { LabelHint.Text    = TextVariables.WEBDIALOG_HINT;          } catch { }
            try { ButtonOK.Text     = TextVariables.WEBDIALOG_BUTTON_LOAD;   } catch { }
            try { ButtonCancel.Text = TextVariables.WEBDIALOG_BUTTON_CANCEL; } catch { }
        }

        private static bool IsUrlSafe(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) return false;
            if (url.Length > 2048) return false;
            if (!url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                !url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                return false;
            foreach (char c in url)
            {
                if (char.IsControl(c) || char.IsWhiteSpace(c)) return false;
            }
            return true;
        }

        private void TextBoxURL_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text) ||
                e.Data.GetDataPresent(DataFormats.UnicodeText))
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
            string text = e.Data.GetData(DataFormats.UnicodeText) as string
                       ?? e.Data.GetData(DataFormats.Text) as string;
            if (!string.IsNullOrWhiteSpace(text))
            {
                TextBoxURL.Text = text.Trim();
                TextBoxURL.SelectAll();
            }
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            string url = TextBoxURL?.Text?.Trim();

            if (string.IsNullOrWhiteSpace(url))
            {
                ShowError("Please enter a web address before pressing Load.");
                return;
            }

            if (!IsUrlSafe(url))
            {
                ShowError("The address you entered does not look like a valid web link. Make sure it starts with http:// or https:// and contains no spaces.");
                return;
            }

            // quick check: look at the path segment for image extensions
            try
            {
                var uri = new Uri(url);
                string path = uri.AbsolutePath;
                string ext = System.IO.Path.GetExtension(path).ToLowerInvariant();
                string[] imageExts = { ".png", ".jpg", ".jpeg", ".gif", ".bmp", ".webp" };
                if (ext.Length > 0 && Array.IndexOf(imageExts, ext) < 0)
                {
                    ShowError("That link does not point to a supported image file. Supported formats: PNG, JPG, GIF, BMP, WebP.");
                    return;
                }
            }
            catch { }

            try
            {
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
                            ShowError("The server did not return an image. Make sure the link points directly to an image file.\nTry dragging the image from your browser onto a portrait slot instead.");
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

                if (imageData == null || imageData.Length == 0)
                {
                    ShowError("The image could not be loaded. The server did not return any data.\nTry dragging the image from your browser onto a portrait slot instead.");
                    return;
                }

                using (var ms = new System.IO.MemoryStream(imageData))
                using (var tmp = Image.FromStream(ms))
                {
                    DownloadedImage = new Bitmap(tmp);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                ShowError("The image could not be loaded. " + ex.Message + "\nTry dragging the image from your browser onto a portrait slot instead.");
            }
        }

        private void ShowError(string message)
        {
            try
            {
                using (var dlg = new MyMessageDialog(message, Thread.CurrentThread.CurrentUICulture.ToString()))
                {
                    dlg.StartPosition = FormStartPosition.CenterParent;
                    dlg.ShowDialog(this);
                }
            }
            catch
            {
                MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button btn) { btn.BackColor = Color.White; btn.ForeColor = Color.Black; }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Enabled) { btn.BackColor = Color.Black; btn.ForeColor = Color.White; }
        }

        private void MyWebDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)  { e.Handled = true; ButtonOK_Click(sender, e); }
            else if (e.KeyCode == Keys.Escape) { DialogResult = DialogResult.Cancel; Close(); }
        }

        private void MyWebDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }
    }
}

