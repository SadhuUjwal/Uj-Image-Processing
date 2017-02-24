using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingMyWork
{
    class ConvolutionFilter
    {
        public Bitmap Convolution(Bitmap Original_Image, double[,] Mask_Matrix)
        {

            double[] pixelArray = ReadPixels(Original_Image);

            double[] resultArray = new double[(Original_Image.Width * 3) * Original_Image.Height];

            for (int ImgY = 1; ImgY < Original_Image.Height - 1; ImgY++)
            {
                for (int ImgX = 1; ImgX < Original_Image.Width - 1; ImgX++)
                {
                    double B = 0;
                    double G = 0;
                    double R = 0;

                    int imgCo = ImgY * (Original_Image.Width * 3) + ImgX * 3;

                    for (int Msk_Y = -1; Msk_Y <= 1; Msk_Y++)
                    {
                        for (int Msk_X = -1; Msk_X <= 1; Msk_X++)
                        {
                            int MskC = imgCo + (Msk_X * 3) + (Msk_Y * (Original_Image.Width * 3));

                            R += (double)(pixelArray[MskC]) * Mask_Matrix[Msk_Y + 1, Msk_X + 1];
                            G += (double)(pixelArray[MskC + 1]) * Mask_Matrix[Msk_Y + 1, Msk_X + 1];
                            B += (double)(pixelArray[MskC + 2]) * Mask_Matrix[Msk_Y + 1, Msk_X + 1];
                        }
                    }

                    if (R > 255)
                        R = 255;
                    else if (R < 0)
                        R = 0;
                    if (B > 255)
                        B = 255;
                    else if (B < 0)
                        B = 0;
                    if (G > 255)
                        G = 255;
                    else if (G < 0)
                        G = 0;

                    resultArray[imgCo] = (byte)(R);
                    resultArray[imgCo + 1] = (byte)(G);
                    resultArray[imgCo + 2] = (byte)(B);
                }
            }


            Bitmap resultImage = new Bitmap(Original_Image.Width, Original_Image.Height);

            int Size = 0;
            for (int y = 0; y < Original_Image.Height; y++)
            {
                for (int x = 0; x < Original_Image.Width; x++)
                {
                    resultImage.SetPixel(x, y, Color.FromArgb(Convert.ToInt32(resultArray[Size]), Convert.ToInt32(resultArray[Size + 1]), Convert.ToInt32(resultArray[Size + 2])));
                    Size = Size + 3;
                }
            }
            return resultImage;
        }

        double[] ReadPixels(Bitmap Original_Image)
        {
            Color c;
            double[] xx = new double[Original_Image.Width * Original_Image.Height * 3];
            int i = 0;

            for (int y = 0; y < Original_Image.Height; y++)
            {
                for (int x = 0; x < Original_Image.Width; x++)
                {
                    c = Original_Image.GetPixel(x, y);
                    xx[i] = (double)(c.R);
                    xx[i + 1] = (double)(c.G);
                    xx[i + 2] = (double)(c.B);
                    i = i + 3;
                }
            }
            return xx;
        }
    }
}
