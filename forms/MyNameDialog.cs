using PortraitManager.Properties;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace PortraitManager.forms
{
    public partial class MyNameDialog : Form
    {
        private PrivateFontCollection _fontCollection;
        private readonly Func<string, bool> _isNameTaken;

        public string ChosenName { get; private set; }

        public MyNameDialog(string initialName, Func<string, bool> isNameTaken)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.Selectable, false);
            Shown += MyNameDialog_Shown;

            _isNameTaken = isNameTaken;

            FontInit();
            TextInit();

            if (!string.IsNullOrEmpty(initialName))
                TextBoxName.Text = initialName;
            TextBoxName.Select();
            TextBoxName.SelectAll();
        }

        private void MyNameDialog_Shown(object sender, EventArgs e)
        {
            try
            {
                Form anchor = Owner;
                while (anchor != null && anchor.Owner != null)
                    anchor = anchor.Owner;
                if (anchor != null)
                {
                    Width = anchor.ClientSize.Width;
                    Left = anchor.PointToScreen(Point.Empty).X;
                }
            }
            catch { }
        }

        private void FontInit()
        {
            _fontCollection = SystemControl.FileControl.InitCustomFont(Resources.BebasNeue_Regular);

            try
            {
                var family = _fontCollection.Families[0];

                LabelTitle.Font   = new Font(family, 18f);
                LabelHint.Font    = new Font(FontFamily.GenericSansSerif, 10f);
                TextBoxName.Font  = new Font(FontFamily.GenericSansSerif, 19.25f);
                ButtonOK.Font     = new Font(family, 14f);
                ButtonCancel.Font = new Font(family, 14f);
            }
            catch { }
        }

        private void TextInit()
        {
            LabelTitle.Text   = TextVariables.NAMEDIALOG_TITLE;
            LabelHint.Text    = TextVariables.NAMEDIALOG_HINT;
            ButtonOK.Text     = TextVariables.NAMEDIALOG_BUTTON_OK;
            ButtonCancel.Text = TextVariables.NAMEDIALOG_BUTTON_CANCEL;
        }

        private void TextBoxName_DragEnter(object sender, DragEventArgs e)
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

        private void TextBoxName_DragDrop(object sender, DragEventArgs e)
        {
            string text = e.Data.GetData(DataFormats.UnicodeText) as string
                       ?? e.Data.GetData(DataFormats.Text) as string;
            if (!string.IsNullOrWhiteSpace(text))
            {
                TextBoxName.Text = text.Trim();
                TextBoxName.SelectAll();
            }
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            string name = TextBoxName?.Text?.Trim();

            if (string.IsNullOrEmpty(name))
            {
                // Blank input clears a previously chosen custom name and falls back to automatic naming.
                ChosenName = null;
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            if (name.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                ShowError(TextVariables.NAMEDIALOG_ERR_INVALID_CHARS);
                return;
            }

            if (_isNameTaken != null && _isNameTaken(name))
            {
                ShowError(TextVariables.NAMEDIALOG_ERR_DUPLICATE);
                return;
            }

            ChosenName = name;
            DialogResult = DialogResult.OK;
            Close();
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

        private void MyNameDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)  { e.Handled = true; ButtonOK_Click(sender, e); }
            else if (e.KeyCode == Keys.Escape) { DialogResult = DialogResult.Cancel; Close(); }
        }

        private void MyNameDialog_FormClosing(object sender, FormClosingEventArgs e)
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

        private void MyNameDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }
    }
}
