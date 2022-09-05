using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PathfinderKINGPortrait
{
    public partial class MainForm : Form
    {
        private void Pic_ToOpenFile_Drop(object sender, DragEventArgs e)
        {

        }
        private void Pic_ToOpenFile_DropEnter(object sender, DragEventArgs e)
        {

        }
        private void Pic_ToOpenFile_Click(object sender, EventArgs e)
        {
            string fullpath = SystemControl.FileControl.OpenFileImage();
            SystemControl.FileControl.CreateTemp(fullpath);
            LoadAllImages();
        }
        private void Btn_ToOpenFile_Click(object sender, EventArgs e)
        {
            string fullpath = SystemControl.FileControl.OpenFileImage();
            SystemControl.FileControl.CreateTemp(fullpath);
            LoadAllImages();
        }
    }
}