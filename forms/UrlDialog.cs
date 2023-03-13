using System;
using System.Drawing;
using System.Drawing.Text;
using System.Net;
using System.Windows.Forms;

namespace PathfinderPortraitManager.Forms
{
    public partial class URLDialog : Form
    {
        public string URL { get; set; }
        public URLDialog()
        {
            InitializeComponent();
            PrivateFontCollection pfc = SystemControl.FileControl.InitCustomFont(Properties.Resources.BebasNeue_Regular);
            FontsTextLoad(pfc);
        }
        public void FontsTextLoad(PrivateFontCollection fonts)
        {
            Font _bebas_neue16 = new Font(fonts.Families[0], 16);
            lblMainText.Font = _bebas_neue16;
            btnCancel.Font = _bebas_neue16;
            btnLoad.Font = _bebas_neue16;

            lblMainText.Text = Properties.TextVariables.dialURL;
            txtbxURL.Text = Properties.TextVariables.txtbxCopy;
            btnCancel.Text = Properties.TextVariables.btnCancel;
            btnLoad.Text = Properties.TextVariables.btnLoad;
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            string urlString = txtbxURL.Text;
            try
            {
                HttpWebRequest request = WebRequest.Create(urlString) as HttpWebRequest;
                request.Method = "HEAD";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                response.Close();
                URL = urlString;
                Close();
            }
            catch
            {
                txtbxURL.Text = Properties.TextVariables.txtbxIncorrect;
                URL = "-1";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            URL = "-2";
            Close();
        }

        private void txtbxURL_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void txtbxURL_DragDrop(object sender, DragEventArgs e)
        {
            TextBox senderTextBox = (TextBox)sender;
            senderTextBox.Text = (string)e.Data.GetData(DataFormats.Text);
        }
    }
}
