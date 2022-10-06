using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;

namespace PathfinderKINGPortrait.auxforms
{
    public partial class Urldialog : Form
    {
        public string URL { get; set; }
        public Urldialog()
        {
            InitializeComponent();
        }
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            string url = TxtEdit.Text;
            try {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "HEAD";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                response.Close();
                URL = url;
                Close();
            }
            catch {
                TxtEdit.Clear();
                URL = "-1";             
            }
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void TxtEdit_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void TxtEdit_DragDrop(object sender, DragEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = (string)e.Data.GetData(DataFormats.Text);
        }
    }
}
