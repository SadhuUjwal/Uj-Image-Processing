using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace LBPFaceRecognition
{
    class ImageProcessor
    {
        private Dictionary<string, double[]> dict = null;
        private const string fileName = "trained.csv";

        /// <summary>
        /// Initializes new instance of Image processor with the trianed path
        /// </summary>
        /// <param name="path">path which contains trained images</param>
        public ImageProcessor(string path)
        {
            if (string.IsNullOrEmpty(path))
                return;
            string filePath = Path.Combine(path, fileName);
            if (this.dict == null && File.Exists(filePath))
                this.dict = this.Deserailize(filePath);
        }

        /// <summary>
        /// gets whether the face recognizer is trained or not
        /// </summary>
        public bool IsTrained
        {
            get
            {
                return this.dict != null;
            }
        }

        /// <summary>
        /// train the Face recognizer with the images in the path
        /// </summary>
        /// <param name="path">path in which training images</param>
        public void Train(string path)
        {
            if (string.IsNullOrEmpty(path))
                return;

            string filePath = Path.Combine(path, fileName);
            if (this.dict == null && File.Exists(filePath))
            {
                this.dict = this.Deserailize(filePath);
                return;
            }

            Dictionary<string, string> filesNormalized = new Dictionary<string, string>();
            this.dict = new Dictionary<string, double[]>();
            string mostMatchFile = string.Empty;
            string[] files = Directory.GetFiles(path);

            foreach (var item in files)
            {
                if (Path.GetExtension(item).ToLower() != ".csv")
                {
                    var testBmp = new Bitmap(Bitmap.FromFile(item));
                    double[] normalizedLBP = this.NormalizedLBP(testBmp, 1);
                    string str = this.MatrixToString(normalizedLBP);
                    filesNormalized.Add(item, str);
                    this.dict.Add(item, normalizedLBP);
                }
            }

            String csv = String.Join(Environment.NewLine, filesNormalized.Select(d => d.Key + "," + d.Value));
            File.WriteAllText(filePath, csv);
        }

        /// <summary>
        /// Converts the provided image to gray image
        /// </summary>
        /// <param name="srcBmp">image which needs to be converted as gray image</param>
        /// <returns>gray image</returns>
        public Bitmap GrayConversion(Bitmap srcBmp)
        {
            int NumRow = srcBmp.Height;
            int numCol = srcBmp.Width;
            Bitmap gray = new Bitmap(srcBmp.Width, srcBmp.Height); 

            for (int i = 0; i < NumRow; i++)
                for (int j = 0; j < numCol; j++)
                {
                    // Extract the color of a pixel
                    Color c = srcBmp.GetPixel(j, i);
                    // extract the red,green, blue components from the color.
                    int rd = c.R; int gr = c.G; int bl = c.B;
                    double d1 = 0.2989 * (double)rd + 0.5870 * (double)gr + 0.1140 * (double)bl;
                    int c1 = (int)Math.Round(d1);
                    Color c2 = Color.FromArgb(c1, c1, c1);
                    gray.SetPixel(j, i, c2);
                }
            return gray;
        }

        /// <summary>
        /// Finds the matching image with the provided
        /// this matching will be based on LBP algorithm
        /// </summary>
        /// <param name="testBmp">source image which needs to be compared</param>
        /// <returns>matched image</returns>
        public Image GetMatchedImage(Bitmap testBmp)
        {
            double min = double.MaxValue;
            string mostMatchFile = string.Empty;

            double[] destVal = this.NormalizedLBP(testBmp, 1);
            double val;

            foreach (var item in dict)
            {
                val = this.ComputeDistance(destVal, item.Value);
                if (val < min)
                {
                    min = val;
                    mostMatchFile = item.Key;
                }
            }
            return Bitmap.FromFile(mostMatchFile);
        }

        /// <summary>
        /// Computes LBP matrix of the image with radius r
        /// </summary>
        /// <param name="srcBmp">source image for which LBP needs to be computed</param>
        /// <param name="r">radius of LBP</param>
        /// <param name="max">max value of the LBP matrix will be returned</param>
        /// <returns>Computed LBP matrix</returns>
        private double[] LBPMatrix(Bitmap srcBmp, int r, out double max)
        {
            max = 0.0;
            //1. Extract rows and columns from srcImage. Note Source image is Gray scale Converted Image
            int NumRow = srcBmp.Height;
            int numCol = srcBmp.Width;
            List<double> histMat = new List<double>();
            //2. Loop through Pixels
            for (int i = 0; i < NumRow; i++)
                for (int j = 0; j < numCol; j++)
                    //define boundary condition, other wise say if you are looking at pixel (0,0), 
                    //it does not have any suitable neighbors
                    if ((i > r) && (j > r) && (i < (NumRow - r)) && (j < (numCol - r)))
                    {
                        // we want to store binary values in a List
                        List<int> vals = new List<int>();
                        try
                        {
                            for (int i1 = i - r; i1 < (i + r); i1++)
                                for (int j1 = j - r; j1 < (j + r); j1++)
                                {
                                    int acPixel = srcBmp.GetPixel(j, i).R;
                                    int nbrPixel = srcBmp.GetPixel(j1, i1).R;
                                    // 3. This is the main Logic of LBP
                                    if (nbrPixel > acPixel)
                                        vals.Add(1);
                                    else
                                        vals.Add(0);
                                }
                        }
                        catch (Exception ex)
                        {
                        }
                        //4. Once we have a list of 1's and 0's , convert the list to decimal
                        // Also for normalization purpose calculate Max value
                        double dec = this.ToBinary(vals);
                        histMat.Add(dec);
                        if (dec > max)
                            max = dec;
                    }
            return histMat.ToArray();
        }

        /// <summary>
        /// Convertes list of binary digits to a decimal value
        /// </summary>
        /// <param name="binary">list of binary digits</param>
        /// <returns>decimal value of the list</returns>
        private double ToBinary(List<int> binary)
        {
            double d = 0;

            for (int i = 0; i < binary.Count; i++)
                d += binary[i] * Math.Pow(2, i);
            return d;
        }

        /// <summary>
        /// computes normalized array of a double array 
        /// </summary>
        /// <param name="Mat">double array which is to be normalized</param>
        /// <param name="max">max value of that array</param>
        /// <returns>normalized array values</returns>
        private double[] NormalizeLbpMatrix(double[] Mat, double max)
        {
            for (int i = 0; i < Mat.Length; i++)
                Mat[i] = Mat[i] / max;
            return Mat;
        }

        /// <summary>
        /// Provides normalized LBP array of an image
        /// </summary>
        /// <param name="src">source image for which LBP need to e calculated</param>
        /// <param name="r">radius of LBP</param>
        /// <returns></returns>
        private double[] NormalizedLBP(Bitmap src, int r)
        {
            double max = 0.0;

            var testGray = this.GrayConversion(src);
            double[] srcMat = this.NormalizeLbpMatrix(this.LBPMatrix(src, r, out max), max);
            return srcMat;
        }

        /// <summary>
        /// Computes chi-squared distance to compare among images
        /// </summary>
        /// <param name="srcMat">LBP array to be matched</param>
        /// <param name="destMat">LBP array from database</param>
        /// <returns>value calculated as per chi-squared distance method</returns>
        private double ComputeDistance(double[] srcMat, double[] destMat)
        {
            //this method uses chi-square method of computing distance value
            double dist = 0.0;

            for (int i = 0; i < srcMat.Length; i++)
                if (srcMat[i] != 0)
                    dist += (Math.Pow((srcMat[i] - destMat[i]), 2) / srcMat[i]);

            return dist;
        }

        /// <summary>
        /// Converts string(array as string) to matrix
        /// </summary>
        /// <param name="value">string which needs to converted to array, 
        /// values should be seperated by a whitespace</param>
        /// <returns>double array converted</returns>
        private double[] StringToMatrix(string value)
        {
            List<double> list = new List<double>();
            double temp = 0.0;
            string[] splitted = value.Split(' ');
            foreach (var item in splitted)
            {
                Double.TryParse(item, out temp);
                list.Add(temp);
                temp = 0;
            }
            return list.ToArray();
        }

        /// <summary>
        /// Converts array to string concatenated with a whitespace
        /// </summary>
        /// <param name="value">array which needs to converted</param>
        /// <returns>string formed from array</returns>
        private string MatrixToString(double[] value)
        {
            string str = string.Empty;

            for (int i = 0; i < value.Length; i++)
                str += value[i] + " ";
            str.Remove(str.Length - 1);
            return str;
        }

        /// <summary>
        /// deserializes/reads LBP data from the file and loads into dictionary
        /// </summary>
        /// <param name="path">path of trained data</param>
        /// <returns>dictionary of image file name and corresponding LBP matrix</returns>
        private Dictionary<string, double[]> Deserailize(string path)
        {
            Dictionary<string, double[]> data = new Dictionary<string, double[]>();

            string[] lines = File.ReadAllLines(path);

            foreach (var item in lines)
            {
                string[] keys = item.Split(',');
                data.Add(keys[0], this.StringToMatrix(keys[1]));
            }

            return data;
        }
    }
}
