using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Mapack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageRegistrationBySURF
{
    public partial class Form1 : Form
    {
        Bitmap bmp1 = null;
        Bitmap bmp2 = null;
        List<Point> Image1Points = new List<Point>();
        List<Point> Image2Points = new List<Point>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadImages_Click(object sender, EventArgs e)
        {
            //----------------load first image------------------
            OpenFileDialog Openfile = new OpenFileDialog();
            if (Openfile.ShowDialog() == DialogResult.OK)
            {
                Image<Bgr, Byte> image1 = new Image<Bgr, Byte>(Openfile.FileName);
                bmp1 = image1.ToBitmap();
                pic1.Image = image1.ToBitmap();
            }

            //----------------load second image------------------
            MessageBox.Show("Now choose second image..");
            if (Openfile.ShowDialog() == DialogResult.OK)
            {
                Image<Bgr, Byte> image2 = new Image<Bgr, Byte>(Openfile.FileName);
                bmp2 = image2.ToBitmap();
                pic2.Image = image2.ToBitmap();
            }
        }

        private void btnSurfRansacMatch2_Click(object sender, EventArgs e)
        {
            SurfRansacMatcher rbm = new SurfRansacMatcher();
            Image<Gray, Byte> modImg = new Image<Gray, Byte>(bmp1);
            Image<Gray, byte> secondImg = new Image<Gray, byte>(bmp2);
            VectorOfKeyPoint modelKeyPoints = null;
            VectorOfKeyPoint observedKeyPoints = null;
            bool computeModelFeatures = true;

            //---------------modified code for zero matches----------------------
            Image<Bgr, byte> res = null;
            //var res = rbm.Match(modImg, secondImg,ref modelKeyPoints, ref observedKeyPoints, computeModelFeatures);
            for (int i = 0; i < 5; i++)  // try 5 times
            {
                res = rbm.Match(modImg, secondImg, ref modelKeyPoints, ref observedKeyPoints, computeModelFeatures);
                if (rbm.selPoints1 != null)
                {
                    if (rbm.selPoints1.Size.Height > 0)
                    {
                        break;
                    }
                }
            }
            if (rbm.selPoints1 == null)
            {
                MessageBox.Show("Did not succeed in finding matches..");
                return;
            }
            //-----------------------end of modified code--------------------------

            Image1Points.Clear();
            Image2Points.Clear();

            for (int i = 0; i < rbm.selPoints1.Rows; i++)
            {
                Point startPt = new Point((int)rbm.selPoints1[i, 0], (int)rbm.selPoints1[i, 1]);
                Point endPt = new Point((int)rbm.selPoints2[i, 0], (int)rbm.selPoints2[i, 1]);
                Image1Points.Add(startPt);
                Image2Points.Add(endPt);
            }
            picOut.Width = pic1.Width * 2;
            Bitmap combined = MyImageProc.DrawCorrespondencesBetweenTwoImages(bmp1, bmp2, Image1Points, Image2Points);
            picOut.Image = combined;
        }

        private void btnRegisterTwoImages_Click(object sender, EventArgs e)
        {
            //Bitmap bmpreg = GetRegisteredImage(bmp2);  // You have to write the code for this
            //picReg.Image = bmpreg;
        }


    }
}
