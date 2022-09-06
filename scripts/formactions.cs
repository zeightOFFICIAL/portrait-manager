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
        bool isloaded = false;
        private void PicPortraitTemp_DragDrop(object sender, DragEventArgs e)
        {

        }
        private void PicPortraitTemp_DropEnter(object sender, DragEventArgs e)
        {

        }
        private void PicPortraitTemp_Click(object sender, EventArgs e)
        {
            string fullpath = SystemControl.FileControl.OpenFileImage();
            if (fullpath == "-1")
            {
                if (isloaded == true)
                {
                    LoadAllImages();
                    return;
                }
                isloaded = false;
            }
            else
                isloaded = true;
            AllImageClear();
            SystemControl.FileControl.CreateTemp(fullpath);
            LoadAllImages();
        }
        private void BtnLoadPortrait_Click(object sender, EventArgs e)
        {
            string fullpath = SystemControl.FileControl.OpenFileImage();
            if (fullpath == "-1")
            {
                if (isloaded == true)
                {
                    LoadAllImages();
                    return;
                }
                isloaded = false;
            }
            else
                isloaded = true;
            AllImageClear();
            SystemControl.FileControl.CreateTemp(fullpath);
            LoadAllImages();
        }
    }
}