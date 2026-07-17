using PortraitManager.Properties;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace PortraitManager.forms
{
    public partial class MyWebDialog : Form
    {
        private PrivateFontCollection _fontCollection;
        public Image DownloadedImage { get; private set; }

        public MyWebDialog()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.Selectable, false);
            Shown += MyWebDialog_Shown;

            FontInit();
            TextInit();
            TextBoxURL.Select();

            var tipLabel = new Label
            {
                ForeColor = Color.Gray,
                BackColor = Color.Transparent,
                AutoSize = false,
                Size = new Size(ClientSize.Width - 32, 20),
                Location = new Point(16, ClientSize.Height - 26),
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font(FontFamily.GenericSansSerif, 8.5f)
            };
            tipLabel.Text = TextVariables.WEBDIALOG_TIP;
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

        public MyWebDialog(string message) : this() { }

        public string URL => TextBoxURL?.Text?.Trim();

        private void FontInit()
        {
            _fontCollection = SystemControl.FileControl.InitCustomFont(Resources.BebasNeue_Regular);

            try
            {
                var family = _fontCollection.Families[0];

                LabelTitle.Font    = new Font(family, 18f);
                LabelHint.Font     = new Font(FontFamily.GenericSansSerif, 10f);
                TextBoxURL.Font    = new Font(FontFamily.GenericSansSerif, 19.25f);
                ButtonOK.Font      = new Font(family, 14f);
                ButtonCancel.Font  = new Font(family, 14f);
            }
            catch { }
        }

        private void TextInit()
        {
            LabelTitle.Text   = TextVariables.WEBDIALOG_TITLE;
            LabelHint.Text    = TextVariables.WEBDIALOG_HINT;
            ButtonOK.Text     = TextVariables.WEBDIALOG_BUTTON_LOAD;
            ButtonCancel.Text = TextVariables.WEBDIALOG_BUTTON_CANCEL;
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
                ShowError(TextVariables.WEBDIALOG_ERR_EMPTY_URL);
                return;
            }

            if (!IsUrlSafe(url))
            {
                ShowError(TextVariables.WEBDIALOG_ERR_INVALID_URL);
                return;
            }

            try
            {
                var uri = new Uri(url);
                string path = uri.AbsolutePath;
                string ext = System.IO.Path.GetExtension(path).ToLowerInvariant();
                string[] imageExts = { ".png", ".jpg", ".jpeg", ".gif", ".bmp", ".webp" };
                if (ext.Length > 0 && Array.IndexOf(imageExts, ext) < 0)
                {
                    ShowError(TextVariables.WEBDIALOG_ERR_UNSUPPORTED_FORMAT);
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
                            ShowError(TextVariables.WEBDIALOG_ERR_NOT_IMAGE);
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
                    ShowError(TextVariables.WEBDIALOG_ERR_NO_DATA);
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
                ShowError(string.Format(TextVariables.WEBDIALOG_ERR_LOAD_EXCEPTION, ex.Message));
            }
        }

        private void ShowError(string message)
        {
            try
            {
                using (var dlg = new MyMessageDialog(message))
                {
                    dlg.StartPosition = FormStartPosition.CenterParent;
                    dlg.ShowDialog(this);
                }
            }
            catch
            {
                MessageBox.Show(this, message, TextVariables.DIALOG_TITLE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void MyWebDialog_FormClosing(object sender, FormClosingEventArgs e)
        {

            Form root = Owner;
            while (root != null && root.Owner != null)
                root = root.Owner;

            if (root != null)
            {
                if (root.WindowState == FormWindowState.Minimized)
                    root.WindowState = FormWindowState.Normal;
                root.Activate();
            }
        }

        private void MyWebDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }
    }
}
