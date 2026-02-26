using PortraitManager.Properties;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace PortraitManager.forms
{
    public partial class MyWebDialog : Form
    {
        private readonly Font _font;
        private readonly PrivateFontCollection _fontCollection;
        public Image DownloadedImage { get; private set; }

        public MyWebDialog(string message, string locale)
        {
            _fontCollection = SystemControl.FileControl.InitCustomFont(Resources.BebasNeue_Regular, Resources.BebasNeue_Regular_ru);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(locale);

            if (Thread.CurrentThread.CurrentUICulture == CultureInfo.GetCultureInfo("ru-RU"))
            {
                _font = new Font(_fontCollection.Families[1], 17);
            }
            else
            {
                _font = new Font(_fontCollection.Families[0], 17);
            }

            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.Selectable, false);
            Focus();

            LabelInquiryMesg.Font = _font;
            LabelInquiryMesg.Text = message;
            ButtonOK.Font = _font;
            ButtonCancel.Font = _font;
            TextBoxURL.Font = _font;
        }

        public string URL => TextBoxURL?.Text?.Trim();

        private void MyWebDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            _font.Dispose();
            Dispose();
        }

        private void ButtonOK_Click(object sender, System.EventArgs e)
        {
            string url = TextBoxURL?.Text?.Trim();
            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show(this, "Please enter a URL.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var wc = new System.Net.WebClient())
                {
                    byte[] data = wc.DownloadData(url);
                    using (var ms = new System.IO.MemoryStream(data))
                    {
                        // create a copy of the image so we don't depend on the stream
                        using (var tmp = Image.FromStream(ms))
                        {
                            DownloadedImage = new System.Drawing.Bitmap(tmp);
                        }
                    }
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(this, "Failed to load image from URL: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_MouseEnter(object sender, System.EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.White;
                button.ForeColor = Color.Black;
            }
        }

        private void ButtonCancel_MouseLeave(object sender, System.EventArgs e)
        {
            if (sender is Button button && button.Enabled == true)
            {
                button.BackColor = Color.Black;
                button.ForeColor = Color.White;
            }
        }

        private void MyWebDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.E)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
    }
}
