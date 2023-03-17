using System;
using System.Net;
using System.Windows.Forms;

namespace PathfinderPortraitManager
{
    public partial class MainForm : Form
    {
        private void ButtonLoadWeb_Click(object sender, EventArgs e)
        {
            string urlString = TextBoxURL.Text;
            try
            {
                HttpWebRequest request = WebRequest.Create(urlString) as HttpWebRequest;
                request.Method = "HEAD";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                response.Close();
                LayoutHide(LayoutURLDialog);
                LayoutReveal(LayoutFilePage);
                CheckWebResourceAndLoad(urlString);
                ResizeVisibleImagesToWindow();
                TextBoxURL.Text = Properties.TextVariables.TEXTBOX_URL_INPUT;
            }
            catch
            {
                TextBoxURL.Text = Properties.TextVariables.TEXTBOX_URL_WRONG; 
            }

        }
        private void ButtonDenyWeb_Click(object sender, EventArgs e)
        {
            LayoutHide(LayoutURLDialog);
            LayoutReveal(LayoutFilePage);
            TextBoxURL.Text = Properties.TextVariables.TEXTBOX_URL_INPUT;
        }
        private void TextBoxURL_DragEnter(object sender, DragEventArgs e)
        {
            TextBoxURL.Clear();
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
            TextBoxURL.Clear();
        }
        private void ButtonOK_Click(object sender, EventArgs e)
        {

        }
    }
}
