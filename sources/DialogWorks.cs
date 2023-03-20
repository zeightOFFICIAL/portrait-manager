/*    
    Pathfinder Portrait Manager. Desktop application for managing in game
    portraits for Pathfinder: Kingmaker and Pathfinder: Wrath of the Righteous
    Copyright (C) 2023 Artemii "Zeight" Saganenko
    LICENSE terms are written in LICENSE file
    Primal license header is written in Program.cs
*/

using System;
using System.IO;
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
            ResizeVisibleImagesToWindow();
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
        private void ButtonToMainPage4_Click(object sender, EventArgs e)
        {
            LayoutHide(LayoutFinalPage);
            ClearTempImages();
            _isNewLoaded = false;
            ParentLayoutsHide();
            LayoutReveal(LayoutMainPage);
            ButtonOpenFileFolder.Enabled = true;
        }
        private void ButtonNewPortrait_Click(object sender, EventArgs e)
        {
            LayoutHide(LayoutFinalPage);
            ClearTempImages();
            _isNewLoaded = false;
            SystemControl.FileControl.TempImagesCreate("!DEFAULT!", RELATIVEPATH_TEMPFULL, RELATIVEPATH_TEMPPOOR, DEFAULT_DICT[_gameSelected]);
            LoadAllTempImages();
            ParentLayoutsHide();
            LayoutReveal(LayoutFilePage);
            ResizeVisibleImagesToWindow();
            ButtonOpenFileFolder.Enabled = true;
        }
        private void ButtonOpenFileFolder_Click(object sender, EventArgs e)
        {
            LayoutHide(LayoutFinalPage);
            ClearTempImages();
            _isNewLoaded = false;
            ParentLayoutsHide();
            try
            {
                System.Diagnostics.Process.Start(LabelDirLoc.Text);
            }
            catch (IOException)
            {
                using (forms.MyMessageDialog MesgNotFound = new forms.MyMessageDialog(Properties.TextVariables.MESG_FOLDERNOTFOUND))
                {
                    MesgNotFound.ShowDialog();
                }
            }
            LayoutReveal(LayoutMainPage);
            ButtonOpenFileFolder.Enabled = true;
        }
    }
}
