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
                ShowError("The address you entered does not look like a valid web link.\n\n" +
                          "Make sure it starts with http:// or https:// and contains no spaces.");
                return;
            }

            // quick check: look at the path segment for image extensions
            try
            {
                var uri = new Uri(url);
                string path = uri.AbsolutePath;
                string ext = System.IO.Path.GetExtension(path).ToLowerInvariant();
                string[] imageExts = { ".png", ".jpg", ".jpeg", ".gif", ".bmp", ".webp" };
                if (!ext.Contains("") && Array.IndexOf(imageExts, ext) < 0)
                {
                    ShowError("That link does not point to a supported image file.\n\n" +
                              "Supported formats: PNG, JPG, GIF, BMP, WebP.");
                    return;
                }
            }
            catch { }

            try
            {
                var request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                request.Timeout = 5000;
                request.ReadWriteTimeout = 5000;
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                using (var ms = new System.IO.MemoryStream())
                {
                    stream.CopyTo(ms);
                    ms.Position = 0;
                    using (var tmp = Image.FromStream(ms))
                    {
                        DownloadedImage = new Bitmap(tmp);
                    }
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                string reason = ex.Message;
                if (ex is System.Net.WebException we && we.Response == null)
                    reason = "The server could not be reached. Check your internet connection or the link.";

                ShowError("The image could not be loaded.\n\n" + reason);
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

