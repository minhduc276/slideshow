using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace slide_show
{
    public partial class Form1 : Form
    {
        Image image;
        Image[] arrImage;
        string[] files;  //mảng chưa các files trong folder
        int imgShow = 0;    //số vị trí của ảnh trong mảng arrImage

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            if (imgShow <= arrImage.Length - 1)
            {
                changeImage(imgShow);
                imgShow++;
            }
            else
            {
                imgShow = 0;
                changeImage(imgShow);
            }
        }

        private void changeImage(int imgChoosed)
        {
            //change main image
            picShow.Image = arrImage[imgChoosed];

            //change list image
            if (imgChoosed >= arrImage.Length)
                imgChoosed = 0;
            pic1.Image = arrImage[imgChoosed++];
            if (imgChoosed >= arrImage.Length)
                imgChoosed = 0;
            pic2.Image = arrImage[imgChoosed++];
            if (imgChoosed >= arrImage.Length)
                imgChoosed = 0;
            pic3.Image = arrImage[imgChoosed++];
            if (imgChoosed >= arrImage.Length)
                imgChoosed = 0;
            pic4.Image = arrImage[imgChoosed++];
            if (imgChoosed >= arrImage.Length)
                imgChoosed = 0;
            pic5.Image = arrImage[imgChoosed++];
        }

        private void linkChooseImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog folderdialog = new FolderBrowserDialog();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh đại diện";

            if (folderdialog.ShowDialog() == DialogResult.OK)
            {
                files = System.IO.Directory.GetFiles(folderdialog.SelectedPath, "*.jpg", System.IO.SearchOption.TopDirectoryOnly);
            }

            if (files.Length > 0)
            {
                timer1.Enabled = true;
                arrImage = new Image[files.Length];
                for (int i = 0; i < files.Length; i++)
                {
                    image = Image.FromFile(files[i]);
                    arrImage[i] = image;
                }
            }
            else
            {
                MessageBox.Show("File ảnh không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }       
        }
    }
}
