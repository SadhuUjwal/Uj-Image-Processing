using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingMyWork
{
    public partial class Form1 : Form
    {
        private Point startPoint, endPoint, startRPoint;
        bool modeRectangle = false;
        Kernel Operator = new Kernel();
        ConvolutionFilter convolution = new ConvolutionFilter();
        public Form1()
        {
            InitializeComponent();
        }

       

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void converyToGreyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap copy = new Bitmap((Bitmap)this.picOrigImage.Image);
                MyImageProc.ConvertToGrey(copy);
                picProcImage.Image = null;
                picProcImage.Image = copy;
                txtWidthProcImage.Text = picProcImage.Image.Width.ToString();
                txtHeightImage.Text = picProcImage.Image.Height.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpeg files(*.jpg)|*.jpg|(*.gif)|gif||";
            if (DialogResult.OK == dialog.ShowDialog())
            {
                this.picOrigImage.Image = new Bitmap(dialog.FileName);
                FileInfo fInfo = new FileInfo(dialog.FileName);
                lbImageUnderTest.Text = "Image Under Test\n" + fInfo.Name;
                txtWidthOrig.Text = picOrigImage.Image.Width.ToString();
                txtHeightOrig.Text = picOrigImage.Image.Height.ToString();
            }
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "jpeg files (*.jpg)|*.jpg";
            if (DialogResult.OK == dlg.ShowDialog())
                this.picProcImage.Image.Save(dlg.FileName, ImageFormat.Jpeg);
        }

        private void brightenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormBrightness dlg = new FormBrightness();
                dlg.Brightness = 30;

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    Bitmap copy = new Bitmap((Bitmap)this.picOrigImage.Image);
                    copy = MyImageProc.Brighten(copy, dlg.Brightness);
                    picProcImage.Image = null;
                    picProcImage.Image = copy;
                    txtWidthProcImage.Text = picProcImage.Image.Width.ToString();
                    txtHeightImage.Text = picProcImage.Image.Height.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void contrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormContrast dlg = new FormContrast();
                dlg.Contrast = 0;
                if (DialogResult.OK == dlg.ShowDialog())
                {
                    Bitmap copy = new Bitmap((Bitmap)this.picOrigImage.Image);
                    copy = MyImageProc.Brighten(copy, dlg.Contrast);
                    picProcImage.Image = null;
                    picProcImage.Image = copy;
                    txtWidthProcImage.Text = picProcImage.Image.Width.ToString();
                    txtHeightImage.Text = picProcImage.Image.Height.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRoatate FRotate = new FormRoatate();
            FRotate.Rotate = 0;
            Image Origing = picOrigImage.Image;
            Bitmap bmp = new Bitmap(Origing);
            if (DialogResult.OK == FRotate.ShowDialog())
            {
                if (MyImageProc.RotateClear(Origing, ref bmp, FRotate.Rotate))
                {
                    picProcImage.Image = null;
                    picProcImage.Image = bmp;
                    txtWidthProcImage.Text = picProcImage.Image.Width.ToString();
                    txtHeightImage.Text = picProcImage.Image.Height.ToString();
                }
            }
        }

        private void fillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRoatate dlg = new FormRoatate();
            dlg.Rotate = 0;
            Image origimg = picOrigImage.Image;
            Bitmap bmp = new Bitmap(origimg);
            if (DialogResult.OK == dlg.ShowDialog())
            {
                if (MyImageProc.RotateFill(origimg, ref bmp, dlg.Rotate))
                {
                    picProcImage.Image = null;
                    picProcImage.Image = bmp;
                    txtWidthProcImage.Text = picProcImage.Image.Width.ToString();
                    txtHeightImage.Text = picProcImage.Image.Height.ToString();
                }
            }
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShift dlg = new FormShift();
            dlg.ShiftAmount = 0;

            Image origing = picOrigImage.Image;
            Bitmap bmp = new Bitmap(origing);
            if (DialogResult.OK == dlg.ShowDialog())
            {
                if (MyImageProc.ShiftImageHorizontal(origing, ref bmp, dlg.ShiftAmount))
                {
                    picProcImage.Image = null;
                    picProcImage.Image = bmp;
                    txtWidthProcImage.Text = picProcImage.Image.Width.ToString();
                    txtHeightImage.Text = picProcImage.Image.Height.ToString();
                }
            }
        }

        private void virticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShift dlg = new FormShift();
            dlg.ShiftAmount = 0;

            Image origing = picOrigImage.Image;
            Bitmap bmp = new Bitmap(origing);
            if (DialogResult.OK == dlg.ShowDialog())
            {
                if (MyImageProc.ShiftImageVertical(origing, ref bmp, dlg.ShiftAmount))
                {
                    picProcImage.Image = null;
                    picProcImage.Image = bmp;
                    txtWidthProcImage.Text = picProcImage.Image.Width.ToString();
                    txtHeightImage.Text = picProcImage.Image.Height.ToString();
                }
            }
        }

        private void resizeImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (modeRectangle == true)
            {
                modeRectangle = false;
                Rectangle rect = new Rectangle(new Point(0, 0), new Size(endPoint.X, endPoint.Y));
                Image img = this.picOrigImage.Image;
                Bitmap bmp = new Bitmap(img);
                MyImageProc.ResizeImage(img, ref bmp, rect);
                picProcImage.Image = bmp;
                txtWidthProcImage.Text = picProcImage.Image.Width.ToString();
                txtHeightImage.Text = picProcImage.Image.Height.ToString();
            }
            else
            {
                MessageBox.Show("You must click mouse to select bottom of rectangle");
            }
        }

        private void rotateResizeImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormRoatate dlg = new FormRoatate();
                dlg.Rotate = 0;
                Image origimg = picOrigImage.Image;
                Bitmap bmp = new Bitmap(origimg);
                if (DialogResult.OK == dlg.ShowDialog())
                {
                    if (MyImageProc.RotateFill(origimg, ref bmp, dlg.Rotate))
                    {
                        picProcImage.Image = null;
                        picProcImage.Image = bmp;
                        txtWidthProcImage.Text = picProcImage.Image.Width.ToString();
                        txtHeightImage.Text = picProcImage.Image.Height.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void drawXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image origimg = picOrigImage.Image;
            Bitmap bmp = new Bitmap(origimg);
            if (MyImageProc.DrawX(origimg, ref bmp, startPoint))
            {
                picProcImage.Image = null;
                picProcImage.Image = bmp;
            }
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (modeRectangle == true)
            {
                modeRectangle = false;
                Rectangle rect = new Rectangle(startPoint, new Size(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y));
                Image img = this.picOrigImage.Image;
                Bitmap bmp = new Bitmap(img);

                MyImageProc.DrawRectangle(img, ref bmp, rect);
                picProcImage.Image = bmp;
                txtWidthProcImage.Text = picProcImage.Image.Width.ToString();
                txtHeightImage.Text = picProcImage.Image.Height.ToString();
            }
            else
                MessageBox.Show("you must drag mouse to select rectangle");
        }

        private void applyFiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            FormMatrix mat = new FormMatrix();
            if (DialogResult.OK == mat.ShowDialog())
            {
                double[,] MyMask = new double[3, 3];
                MyMask[0, 0] = Convert.ToDouble(mat.Tb11);
                MyMask[0, 1] = Convert.ToDouble(mat.Tb12);
                MyMask[0, 2] = Convert.ToDouble(mat.Tb13);
                MyMask[1, 0] = Convert.ToDouble(mat.Tb21);
                MyMask[1, 1] = Convert.ToDouble(mat.Tb22);
                MyMask[1, 2] = Convert.ToDouble(mat.Tb23);
                MyMask[2, 0] = Convert.ToDouble(mat.Tb31);
                MyMask[2, 1] = Convert.ToDouble(mat.Tb32);
                MyMask[2, 2] = Convert.ToDouble(mat.Tb33);
                Image origimg = picOrigImage.Image;
                Bitmap bmpimg = new Bitmap(origimg);
                picProcImage.Image = convolution.Convolution(bmpimg, MyMask);
               

                
            }
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image origimg = picOrigImage.Image;
            Bitmap bmpimg = new Bitmap(origimg);
            picProcImage.Image = convolution.Convolution(bmpimg, Operator.LaplacianMask_A);
            
        }

        private void bToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image origimg = picOrigImage.Image;
            Bitmap bmpimg = new Bitmap(origimg);
            picProcImage.Image = convolution.Convolution(bmpimg, Operator.LaplacianMask_B);
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image origimg = picOrigImage.Image;
            Bitmap bmpimg = new Bitmap(origimg);
            picProcImage.Image = convolution.Convolution(bmpimg, Operator.LaplacianMask_C);
        }

        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image origimg = picOrigImage.Image;
            Bitmap bmpimg = new Bitmap(origimg);
            picProcImage.Image = convolution.Convolution(bmpimg, Operator.Sharpen_Mask);
        }

        private void avgMaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image origimg = picOrigImage.Image;
            Bitmap bmpimg = new Bitmap(origimg);
            picProcImage.Image = convolution.Convolution(bmpimg, Operator.Blur_Image);
        }

        private void gaussianMaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image origimg = picOrigImage.Image;
            Bitmap bmpimg = new Bitmap(origimg);
            picProcImage.Image = convolution.Convolution(bmpimg, Operator.Guassian_Image);
        }

        private void picOrigImage_MouseDown(object sender, MouseEventArgs e)
        {
            modeRectangle = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void picOrigImage_MouseUp(object sender, MouseEventArgs e)
        {
            endPoint = new Point(e.X, e.Y);
        }
    }
}
