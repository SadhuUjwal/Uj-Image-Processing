using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignment7;
using System.Drawing.Imaging;

namespace Assignment7
{
    public partial class Form1 : Form
    {
        
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private String _strRefPath;
        private String _strOriginPath;
        private int _originalHeight1;
        private int _originalWidth1;
        private int _originalHeight2;
        private int _originalWidth2;

        private int[][] _referenceImage;
        private int[][] _destinationImage;
        private int[][] _grayReferenceImage;
        private int[][] _grayDestinationImage;
        private double[] _histogramReference;
        private double[] _histogramDestination;
        private double[][] _JointPdf;
        private double[] vector_A;
        private double[] vector_B;
        private double[] vector_C;
        private double[] vector_D;
        private double[] vector_T1;
        private double[] vector_T2;

        private double[] completMI;

        public Form1()
        {
            InitializeComponent();
            initVector();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
        }

        private void initVector()
        {
            Random C = new Random();
            vector_A = new double[7];
            vector_B = new double[7];
            vector_C = new double[7];
            vector_D = new double[7];
            vector_T1 = new double[7];
            vector_T2 = new double[7];
            completMI = new double[7];
            for (int i = 0; i < 7; i++)
            {
                vector_A[i] = C.Next() % 10;
                vector_B[i] = C.Next() % 10;
                vector_C[i] = C.Next() % 10;
                vector_D[i] = C.Next() % 10;
                vector_T1[i] = C.Next() % 20 + 10;
                vector_T2[i] = C.Next() % 20 + 20;
            }
        }

        private void InitFractor()
        {
            Random C = new Random();
            for (int i = 0; i < 7; i++)
            {

                vector_A[i] = (double)(C.Next() % 100) / 200 + 0.8;
                vector_B[i] = (double)(C.Next() % 100) / 1000 - 0.05;
                vector_C[i] = (double)(C.Next() % 100) / 1000 - 0.05;
                vector_D[i] = (double)(C.Next() % 100) / 400 + 0.8;
                vector_T1[i] = (double)(C.Next() % 100) / 20 + 17.0;
                vector_T2[i] = (double)(C.Next() % 100) / 20 + 22.0;

                //vector_A[i] = (double)Math.Cos(C.Next() % 2/10);
                //vector_B[i] = (double)Math.Sin(C.Next() % 2/10);
                //vector_C[i] = (double)Math.Sin(C.Next() % 2/10)*(-1);
                //vector_D[i] = (double)Math.Cos(C.Next() % 2/10);
                //vector_T1[i] = 0;// (double)(C.Next() % 2); //+ 10.0;
                //vector_T2[i] = 0;// (double)(C.Next() % 2); //+ 20.0;

                //double angle_init = C.Next() % 100 / 20;
                //vector_A[i] = (double)Math.Cos(angle_init);
                //vector_B[i] = (double)Math.Sin(angle_init);
                //vector_C[i] = (double)Math.Sin(angle_init) * (-1);
                //vector_D[i] = (double)Math.Cos(angle_init);
                //vector_T1[i] =  (double)(C.Next() % 100)/20+16.0;
                //vector_T2[i] = (double)(C.Next() % 100)/20 +26.0;

                Console.WriteLine("init {0},{1},{2},{3},{4},{5}", vector_A[i], vector_B[i], vector_C[i], vector_D[i], vector_T1[i], vector_T2[i]);
                Console.WriteLine("{0}  : T1  = {1} T2 = {2} ", i, vector_T1[i], vector_T2[i]);
            }
        }

        private static int KroneckerDelata(int a, int b)
        {
            if (a == b)
                return 1;
            else
                return 0;
        }

        private void ConvertImage(int[][] aImg, int[][] bImg, int width, int height, double a, double b, double c, double d, double t1, double t2)
        {
            Bitmap bm = new Bitmap(width, height);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    double xPriemC = a * j + b * i + t1;
                    double yPriemC = c * j + d * i + t2;



                    int xPriem = (int)xPriemC;
                    int yPriem = (int)yPriemC;
                    if ((xPriem < width) && (xPriem >= 0) && (yPriem < height) && (yPriem >= 0))
                    {

                        Color coColor = Color.FromArgb(bImg[j][i]);
                        bm.SetPixel(xPriem, yPriem, coColor);

                    }
                }
            }

            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|PNG Image|*.png";
            saveFileDialog1.Title = "Save";
            saveFileDialog1.FileName = string.Empty;
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                   (System.IO.FileStream)saveFileDialog1.OpenFile();

                //bm.Save("C:\\Test.jpg", ImageFormat.Jpeg);
                bm.Save(fs, ImageFormat.Jpeg);
                fs.Close();

                Image image = Image.FromFile(saveFileDialog1.FileName, true);
                pictureBox3.Size = image.Size;
                pictureBox3.Image = image;

                bm = new Bitmap(_originalWidth1 + _originalWidth2, height);
                Graphics g = Graphics.FromImage(bm);
                g.DrawImage(pictureBox1.Image, new Point(0, 0));
                g.DrawImage(Image.FromFile(_strOriginPath, true), new Point(_originalWidth1, 0));
                //picRelation.Size = bm.Size;
                //picRelation.Image = bm;
            }

        }

        private double ComputeMI(double[] aPDF, double[] bPDF, double[][] jPDF, int width, int height)
        {
            double CurrentMI = 0;
            for (int i = 200; i < 256; i++)
            {
                for (int j = 200; j < 256; j++)
                {
                    if (aPDF[i] != 0 && bPDF[j] != 0 && jPDF[i][j] != 0)
                    {
                        CurrentMI = CurrentMI + jPDF[i][j] * Math.Log10(jPDF[i][j] / (aPDF[i] * bPDF[j]));
                    }
                }
            }
            return CurrentMI * (-1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void SortMI(double[] vectorA, double[] vectorB, double[] vectorC, double[] vectorD, double[] vectorT1, double[] vectorT2, double[] MI)
        {
            for (int i = 0; i < 7; i++)
            {
                double temp = MI[i];
                for (int j = i + 1; j < 7; j++)
                {
                    if (temp > MI[j])
                    {
                        double tempValue = vectorA[i];
                        vectorA[i] = vectorA[j];
                        vectorA[j] = tempValue;

                        tempValue = vectorB[i];
                        vectorB[i] = vectorB[j];
                        vectorB[j] = tempValue;

                        tempValue = vectorC[i];
                        vectorC[i] = vectorC[j];
                        vectorC[j] = tempValue;

                        tempValue = vectorD[i];
                        vectorD[i] = vectorD[j];
                        vectorD[j] = tempValue;

                        tempValue = vectorT1[i];
                        vectorT1[i] = vectorT1[j];
                        vectorT1[j] = tempValue;

                        tempValue = vectorT2[i];
                        vectorT2[i] = vectorT2[j];
                        vectorT2[j] = tempValue;

                        tempValue = MI[i];
                        MI[i] = MI[j];
                        MI[j] = tempValue;
                    }
                }
            }
            //System.Console.WriteLine("{0},{1},{2},{3},{4},{5},{6}", MI[0], MI[1], MI[2], MI[3], MI[4], MI[5], MI[6]);
        }

        private static double[] GetHistogram(int[][] img, int width, int height, double a, double b, double c, double d, double t1, double t2)
        {
            double[] nonNormalizedPDF = new double[256];
            int[][] tempImage = new int[width][];
            int xMax = width;
            int yMax = height;

            for (int i = 0; i < 256; i++)
            {
                nonNormalizedPDF[i] = 0.0;
            }

            for (int k = 0; k < width; k++)
            {
                tempImage[k] = new int[height];
                Array.Clear(tempImage[k], 0, height);
            }

            for (int index = 0; index < height; index++)
            {
                for (int kIndex = 0; kIndex < width; kIndex++)
                {
                    double xPriemC = a * kIndex + b * index + t1;
                    double yPriemC = c * kIndex + d * index + t2;
                    int xPriem = (int)xPriemC;
                    int yPriem = (int)yPriemC;

                    if ((xPriem < xMax) && (xPriem >= 0) && (yPriem < yMax) && (yPriem >= 0))
                    {
                        tempImage[xPriem][yPriem] = img[kIndex][index];
                    }
                }
            }

            for (int y = 0; y < yMax; y++)
            {
                for (int x = 0; x < xMax; x++)
                {
                    Color col = Color.FromArgb(tempImage[x][y]);
                    int tempValue = col.B;
                    nonNormalizedPDF[tempValue] += 1.0;
                }
            }

            double normalizationFactor = xMax * yMax;

            for (int g = 0; g < 256; g++)
            {
                nonNormalizedPDF[g] = nonNormalizedPDF[g] / normalizationFactor;
            }
            return nonNormalizedPDF;
        }

        private void I1Image_Click(object sender, EventArgs e)
        {

            int[][] pixelImage;
            openFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|PNG Image|*.png|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FileName = string.Empty;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String fileName = openFileDialog1.FileName;
                _strRefPath = fileName;

            }
            else
                return;

            Image image = Image.FromFile(_strRefPath, true);
            pictureBox1.Size = image.Size;
            pictureBox1.Image = image;

            Bitmap bmp = new Bitmap(image);
            _originalHeight1 = image.Height;
            _originalWidth1 = image.Width;
            pixelImage = ImagePixelData(bmp);
            _referenceImage = pixelImage;
            GetBitmapToGray(bmp, ref _grayReferenceImage, _originalWidth1, _originalHeight1);
            pictureBox3.Image = null;

        }

        private void I2Image_Click(object sender, EventArgs e)
        {
            int[][] pixelImage;
            openFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|PNG Image|*.png|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FileName = string.Empty;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String fileName = openFileDialog1.FileName;
                _strOriginPath = fileName;
            }
            else
                return;

            Image image = Image.FromFile(_strOriginPath, true);
            pictureBox2.Size = image.Size;
            pictureBox2.Image = image;
            Bitmap bmp = new Bitmap(image);
            _originalHeight2 = image.Height;
            _originalWidth2 = image.Width;
            pixelImage = ImagePixelData(bmp);
            _destinationImage = pixelImage;
            GetBitmapToGray(bmp, ref _grayDestinationImage, _originalWidth2, _originalHeight2);
            pictureBox3.Image = null;

        }

        private void GetResult_Click(object sender, EventArgs e)
        {
            int Counter = 0;

            InitFractor();

            _histogramReference = GetImagePdf(_grayReferenceImage, _originalWidth1, _originalHeight1);
            _histogramDestination = GetImagePdf(_grayDestinationImage, _originalWidth2, _originalHeight2);

            double B_a;
            double B_b;
            double B_c;
            double B_d;
            double B_T1;
            double B_T2;

            double W_a;
            double W_b;
            double W_c;
            double W_d;
            double W_T1;
            double W_T2;

            double A_a;
            double A_b;
            double A_c;
            double A_d;
            double A_T1;
            double A_T2;

            double R_a;
            double R_b;
            double R_c;
            double R_d;
            double R_T1;
            double R_T2;

            double E_a;
            double E_b;
            double E_c;
            double E_d;
            double E_T1;
            double E_T2;

            double C_a;
            double C_b;
            double C_c;
            double C_d;
            double C_T1;
            double C_T2;

            double Con_a;
            double Con_b;
            double Con_c;
            double Con_d;
            double Con_T1;
            double Con_T2;

            double f_R;
            double f_E;
            double f_Con;


            while (Counter < 150)
            {
                Counter++;
                Console.Write("{0}\r\n", completMI[0]);
                Console.Write("{0},{1},{2},{3},{4},{5}\r\n", vector_A[0], vector_B[0], vector_C[0], vector_D[0], vector_T1[0], vector_T2[0]);
                for (int i = 0; i < 7; i++)
                {
                    _JointPdf = GetJointPDF(_grayDestinationImage, _grayReferenceImage, _originalWidth1, _originalHeight1, vector_A[i], vector_B[i], vector_C[i], vector_D[i], vector_T1[i], vector_T2[i]);
                    _histogramDestination = GetHistogram(_grayDestinationImage, _originalWidth1, _originalHeight1, vector_A[i], vector_B[i], vector_C[i], vector_D[i], vector_T1[i], vector_T2[i]);

                    completMI[i] = ComputeMI(_histogramReference, _histogramDestination, _JointPdf, _originalWidth2, _originalHeight2);
                }

                SortMI(vector_A, vector_B, vector_C, vector_D, vector_T1, vector_T2, completMI);

                B_a = vector_A[0];
                B_b = vector_B[0];
                B_c = vector_C[0];
                B_d = vector_D[0];
                B_T1 = vector_T1[0];
                B_T2 = vector_T2[0];

                W_a = vector_A[6];
                W_b = vector_B[6];
                W_c = vector_C[6];
                W_d = vector_D[6];
                W_T1 = vector_T1[6];
                W_T2 = vector_T2[6];

                A_a = vector_A[5];
                A_b = vector_B[5];
                A_c = vector_C[5];
                A_d = vector_D[5];
                A_T1 = vector_T1[5];
                A_T2 = vector_T2[5];

                C_a = (vector_A[0] + vector_A[1] + vector_A[2] + vector_A[3] + vector_A[4] + vector_A[5]) / 6;
                C_b = (vector_B[0] + vector_B[1] + vector_B[2] + vector_B[3] + vector_B[4] + vector_B[5]) / 6;
                C_c = (vector_C[0] + vector_C[1] + vector_C[2] + vector_C[3] + vector_C[4] + vector_C[5]) / 6;
                C_d = (vector_D[0] + vector_D[1] + vector_D[2] + vector_D[3] + vector_D[4] + vector_D[5]) / 6;
                C_T1 = (vector_T1[0] + vector_T1[1] + vector_T1[2] + vector_T1[3] + vector_T1[4] + vector_T1[5]) / 6;
                C_T2 = (vector_T2[0] + vector_T2[1] + vector_T2[2] + vector_T2[3] + vector_T2[4] + vector_T2[5]) / 6;

                R_a = C_a + (C_a - W_a);
                R_b = C_b + (C_b - W_b);
                R_c = C_c + (C_c - W_c);
                R_d = C_d + (C_d - W_d);
                R_T1 = C_T1 + (C_T1 - W_T1);
                R_T2 = C_T2 + (C_T2 - W_T2);


                _JointPdf = GetJointPDF(_grayDestinationImage, _grayReferenceImage, _originalWidth1, _originalHeight1, R_a, R_b, R_c, R_d, R_T1, R_T2);
                _histogramDestination = GetHistogram(_grayDestinationImage, _originalWidth1, _originalHeight1, R_a, R_b, R_c, R_d, R_T1, R_T2);
                f_R = ComputeMI(_histogramReference, _histogramDestination, _JointPdf, _originalWidth2, _originalHeight2);

                if (f_R < completMI[5] && f_R > completMI[0])
                {
                    vector_A[6] = R_a;
                    vector_B[6] = R_b;
                    vector_C[6] = R_c;
                    vector_D[6] = R_d;
                    vector_T1[6] = R_T1;
                    vector_T2[6] = R_T2;
                    continue;
                }

                if (f_R < completMI[0])
                {
                    E_a = C_a + (C_a - W_a) * 2;
                    E_b = C_b + (C_b - W_b) * 2;
                    E_c = C_c + (C_c - W_c) * 2;
                    E_d = C_d + (C_d - W_d) * 2;
                    E_T1 = C_T1 + (C_T1 - W_T1) * 2;
                    E_T2 = C_T2 + (C_T2 - W_T2) * 2;

                    _JointPdf = GetJointPDF(_grayDestinationImage, _grayReferenceImage, _originalWidth1, _originalHeight1, E_a, E_b, E_c, E_d, E_T1, E_T2);
                    _histogramDestination = GetHistogram(_grayDestinationImage, _originalWidth1, _originalHeight1, E_a, E_b, E_c, E_d, E_T1, E_T2);
                    f_E = ComputeMI(_histogramReference, _histogramDestination, _JointPdf, _originalWidth2, _originalHeight2);

                    if (f_E < f_R)
                    {
                        vector_A[6] = E_a;
                        vector_B[6] = E_b;
                        vector_C[6] = E_c;
                        vector_D[6] = E_d;
                        vector_T1[6] = E_T1;
                        vector_T2[6] = E_T2;

                        continue;
                    }
                    else
                    {
                        vector_A[6] = R_a;
                        vector_B[6] = R_b;
                        vector_C[6] = R_c;
                        vector_D[6] = R_d;
                        vector_T1[6] = R_T1;
                        vector_T2[6] = R_T2;

                        continue;
                    }
                }
                else if (f_R < completMI[5])
                {
                    vector_A[6] = R_a;
                    vector_B[6] = R_b;
                    vector_C[6] = R_c;
                    vector_D[6] = R_d;
                    vector_T1[6] = R_T1;
                    vector_T2[6] = R_T2;

                    continue;
                }
                else if (f_R < completMI[6])
                {
                    Con_a = C_a + (C_a - W_a) / 2;
                    Con_b = C_b + (C_b - W_b) / 2;
                    Con_c = C_c + (C_c - W_c) / 2;
                    Con_d = C_d + (C_d - W_d) / 2;
                    Con_T1 = C_T1 + (C_T1 - W_T1) / 2;
                    Con_T2 = C_T2 + (C_T2 - W_T2) / 2;

                    _JointPdf = GetJointPDF(_grayDestinationImage, _grayReferenceImage, _originalWidth1, _originalHeight1, Con_a, Con_b, Con_c, Con_d, Con_T1, Con_T2);
                    _histogramDestination = GetHistogram(_grayDestinationImage, _originalWidth1, _originalHeight1, Con_a, Con_b, Con_c, Con_d, Con_T1, Con_T2);
                    f_Con = ComputeMI(_histogramReference, _histogramDestination, _JointPdf, _originalWidth2, _originalHeight2);

                    if (f_Con < completMI[5])
                    {
                        vector_A[6] = Con_a;
                        vector_B[6] = Con_b;
                        vector_C[6] = Con_c;
                        vector_D[6] = Con_d;
                        vector_T1[6] = Con_T1;
                        vector_T2[6] = Con_T2;

                        continue;
                    }
                    else
                    {
                        for (int k = 1; k < 7; k++)
                        {
                            vector_A[k] = vector_A[0] + (vector_A[k] - vector_A[0]) * 0.5;
                            vector_B[k] = vector_B[0] + (vector_B[k] - vector_B[0]) * 0.5;
                            vector_C[k] = vector_C[0] + (vector_C[k] - vector_C[0]) * 0.5;
                            vector_D[k] = vector_D[0] + (vector_D[k] - vector_D[0]) * 0.5;
                            vector_T1[k] = vector_T1[0] + (vector_T1[k] - vector_T1[0]) * 0.5;
                            vector_T2[k] = vector_T2[0] + (vector_T2[k] - vector_T2[0]) * 0.5;
                        }
                    }
                }
                else
                {
                    for (int k = 1; k < 7; k++)
                    {
                        vector_A[k] = vector_A[0] + (vector_A[k] - vector_A[0]) * 0.5;
                        vector_B[k] = vector_B[0] + (vector_B[k] - vector_B[0]) * 0.5;
                        vector_C[k] = vector_C[0] + (vector_C[k] - vector_C[0]) * 0.5;
                        vector_D[k] = vector_D[0] + (vector_D[k] - vector_D[0]) * 0.5;
                        vector_T1[k] = vector_T1[0] + (vector_T1[k] - vector_T1[0]) * 0.5;
                        vector_T2[k] = vector_T2[0] + (vector_T2[k] - vector_T2[0]) * 0.5;
                    }
                }
            }
            int maxW = _originalWidth1;
            int maxH = _originalHeight1;
            maxW = Math.Max(_originalWidth1, _originalWidth2);
            maxH = Math.Max(_originalHeight1, _originalHeight2);
            ConvertImage(_referenceImage, _destinationImage, maxW, maxH, vector_A[0], vector_B[0], vector_C[0], vector_D[0], vector_T1[0], vector_T2[0]);
        }

        private void GetBitmapToGray(Bitmap bmBitmap, ref int[][] img, int width, int height)
        {
            Bitmap grayBMP = new Bitmap(width, height);
            int xMax = width;
            int yMax = height;

            for (int i = 0; i < yMax; i++)
            {
                for (int j = 0; j < xMax; j++)
                {
                    Color c = bmBitmap.GetPixel(j, i);
                    int rd = c.R;
                    int gr = c.G;
                    int bl = c.B;

                    double dl = 0.2989 * (double)rd + 0.5870 * (double)gr + 0.1140 * (double)bl;
                    int c1 = (int)Math.Round(dl);
                    Color c2 = Color.FromArgb(c1, c1, c1);
                    grayBMP.SetPixel(j, i, c2);
                }
            }

            img = ImagePixelData(grayBMP);
        }

        private int[][] ImagePixelData(Bitmap imgData)
        {
            int width = imgData.Width;
            int height = imgData.Height;
            int[][] intImage = new int[width][];
            for (int i = 0; i < width; i++)
            {
                intImage[i] = new int[height];
            }
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    intImage[x][y] = imgData.GetPixel(x, y).ToArgb();
                }
            }

            return intImage;
        }

        private static double[] GetImagePdf(int[][] img, int width, int height)
        {
            double[] nonNormalizedPDF = new double[256];
            int xMax = width;
            int yMax = height;

            for (int i = 0; i < 256; i++)
            {
                nonNormalizedPDF[i] = 0.0;
            }

            for (int y = 0; y < yMax; y++)
            {
                for (int x = 0; x < xMax; x++)
                {
                    Color c = Color.FromArgb(img[x][y]);
                    int tempValue = c.B;
                    nonNormalizedPDF[tempValue] += 1.0;
                }
            }

            double normalizationFactor = xMax * yMax;

            for (int g = 0; g < 256; g++)
            {
                nonNormalizedPDF[g] = nonNormalizedPDF[g] / normalizationFactor;
            }
            return nonNormalizedPDF;
        }

        private static double[][] GetJointPDF(int[][] aImg, int[][] bImg, int width, int height, double a, double b, double c, double d, double t1, double t2)
        {
            double[][] jPDF = new double[256][];

            int xMax = width;
            int yMax = height;

            for (int i = 0; i < 256; i++)
            {
                jPDF[i] = new double[256];
            }

            for (int y = 0; y < yMax; y++)
            {
                for (int x = 0; x < xMax; x++)
                {
                    int tempValue1 = Color.FromArgb(aImg[x][y]).B;

                    double xPriemC = a * x + b * y + t1;
                    double yPriemC = c * x + d * y + t2;
                    int xPriem = (int)xPriemC;
                    int yPriem = (int)yPriemC;

                    if ((xPriem < xMax) && (xPriem >= 0) && (yPriem < yMax) && (yPriem >= 0))
                    {
                        int tempValue2 = Color.FromArgb(bImg[xPriem][yPriem]).B;
                        jPDF[tempValue1][tempValue2] = jPDF[tempValue1][tempValue2] + 1;
                    }
                }
            }

            double factor = 1.0 / (xMax * yMax);// *Math.Min(1.0, Math.Min((a * a + b * b), (c * c + d * d)));
            double s = 0;
            for (int j = 0; j < 256; j++)
            {
                for (int k = 0; k < 256; k++)
                {
                    jPDF[j][k] = factor * jPDF[j][k];
                    s = s + jPDF[j][k];
                }
            }
            return jPDF;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

    }
}

