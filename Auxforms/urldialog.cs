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
    }
}
