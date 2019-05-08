using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace test_pic_control
{
    public partial class MyPic : UserControl
    {
        public MyPic()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
              OpenFileDialog ofdPic = new OpenFileDialog();
            ofdPic.Filter = "JPG(*.JPG;*.JPEG);gif文件(*.GIF);PNG(*.PNG)|*.jpg;*.jpeg;*.gif;*.png";
            ofdPic.FilterIndex = 1;
            ofdPic.RestoreDirectory = true;
            ofdPic.FileName = "";
            if (ofdPic.ShowDialog() == DialogResult.OK)
            {
                string sPicPaht = ofdPic.FileName.ToString();
                FileInfo fiPicInfo = new FileInfo(sPicPaht);
                long lPicLong = fiPicInfo.Length / 1024;
                string sPicName = fiPicInfo.Name;
                string sPicDirectory = fiPicInfo.Directory.ToString();
                string sPicDirectoryPath = fiPicInfo.DirectoryName;
                Bitmap bmPic = new Bitmap(sPicPaht);
                if (lPicLong > 400)
                {
                    MessageBox.Show("此文件大小為" + lPicLong + "K；已超過最大限制的K范圍！");
                }
                else
                {
                    Point ptLoction = new Point(bmPic.Size);
                    if (ptLoction.X > picBox.Size.Width || ptLoction.Y > picBox.Size.Height)
                    {
                        picBox.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        picBox.SizeMode = PictureBoxSizeMode.CenterImage;
                    }
                }
                picBox.LoadAsync(sPicPaht);
                lblName.Text = sPicName;
                lblLength.Text = lPicLong.ToString() + " KB";
                lblSize.Text = bmPic.Size.Width.ToString() + "×" + bmPic.Size.Height.ToString();
            }
//--------------------- 
//作者：chen15271802122 
//来源：CSDN 
//原文：https://blog.csdn.net/chen18221987993/article/details/81943438 
//版权声明：本文为博主原创文章，转载请附上博文链接！
        }
    }
}
