using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;


namespace imgproc_MI_NelderMead
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Begin");
            ImageRegistration.FeatureVector result = ImageRegistration.NelderMeadImageRegistration();
            Console.WriteLine("A: {0}  B: {1}  T1: {2}  T2: {3}", result.A, result.B, result.T1, result.T2);
            Console.ReadKey();
        }
    }



    class ImageRegistration
    {
        
       public class FeatureVector
        {
            public double A,   B;
            public double C,   D;
            public int T1, T2;

            public void clear() { A = 0; B = 0; C = 0; D = 0; T1 = 0; T2 = 0; }
            public void copy(FeatureVector v1) { A = v1.A; B = v1.B; C = v1.C; D = v1.D; T1 = v1.T1; T2 = v1.T2; }
            public static FeatureVector operator +(FeatureVector v1, FeatureVector v2)
            {
                FeatureVector retval = new FeatureVector();
                retval.A  = v1.A  + v2.A;
                retval.B  = v1.B  + v2.B;
                retval.C  = v1.C  + v2.C;
                retval.D  = v1.D  + v2.D;
                retval.T1 = v1.T1 + v2.T1;
                retval.T2 = v1.T2 + v2.T2;
                return retval;
            }

            public static FeatureVector operator -(FeatureVector v1, FeatureVector v2)
            {
                FeatureVector retval = new FeatureVector();
                retval.A  = v1.A  - v2.A;
                retval.B  = v1.B  - v2.B;
                retval.C  = v1.C  - v2.C;
                retval.D  = v1.D  - v2.D;
                retval.T1 = v1.T1 - v2.T1;
                retval.T2 = v1.T2 - v2.T2;
                return retval;
            }

            public static FeatureVector operator /(FeatureVector v1, int v2)
            {
                FeatureVector retval = new FeatureVector();
                retval.A  = v1.A  / v2;
                retval.B  = v1.B  / v2;
                retval.C  = v1.C  / v2;
                retval.D  = v1.D  / v2;
                retval.T1 = v1.T1 / v2;
                retval.T2 = v1.T2 / v2;
                return retval;
            }

            public static FeatureVector operator *(int v1, FeatureVector v2)
            {
                FeatureVector retval = new FeatureVector();
                retval.A  = v1 * v2.A;
                retval.B  = v1 * v2.B;
                retval.C  = v1 * v2.C;
                retval.D  = v1 * v2.D;
                retval.T1 = v1 * v2.T1;
                retval.T2 = v1 * v2.T2;
                return retval;
            }

        }

        public const int NUMOFDIMS = 4; //Number of dimensions
        public const int NUMOFVERT = NUMOFDIMS + 1; //Number of vertices

        public const int Max_Iterations = 400;

        //Strings to be safe against typos in the code
        public const string Worst = "Worst";
        public const string Best = "Best";
        public const string AlmostWorst = "AlmostWorst";

        //store the two images
        public static Bitmap loadedimage1;
        public static Bitmap loadedimage2;
        public static int[,] aimage;
        public static int[,] bimage;
        public static byte[] saveimage;

        public static double[] aimgpdf;
        public static double[] bimgpdf;
        public static double[][,] jointimgpdf = new double[NUMOFVERT][,];
        public static double[] mutualinformation = new double[NUMOFVERT];

        public static FeatureVector[] startFeatureVector;
        public static FeatureVector Ccentroid = new FeatureVector();
        public static FeatureVector Rreflection = new FeatureVector();
        public static FeatureVector Eexpansion = new FeatureVector();
        public static FeatureVector Concontraction = new FeatureVector();
     //   public static FeatureVector Concontraction2 = new FeatureVector();


        public static double mutualinforeflection;
        public static double mutualinfoexpansion;
        public static double mutualinfocontraction;


        public static SortedDictionary<double, int> scoretofeaturevector = new SortedDictionary<double, int>();
        public static Dictionary<string, int>   nametoplaceinvectorarray = new Dictionary<string, int>();
        public static Dictionary<string, double>            nametoscore  = new Dictionary<string, double>();
        public static Dictionary<string, FeatureVector>     nametovertex = new Dictionary<string, FeatureVector>();



        public static FeatureVector NelderMeadImageRegistration()
        {
            bool initsuccessful = initialization();
            if(!initsuccessful)
            {
                Console.WriteLine("Could not initialize");
            }
            computeMutualInformation();

            filldictionaries();

            //Begin iteration
            for (int iter = 0; iter < Max_Iterations; iter++)
            {
                //Console.WriteLine("Iteration #{0}", iter);
                computeCentroid(); //Compute the centroid C of vertices without considering W

                //Try reflection
                Rreflection = Ccentroid + (Ccentroid - nametovertex[Worst]); //Calculate Reflection R

                mutualinforeflection = getMIForFeatureVector(Rreflection); //Calculate f(R)

                if ((mutualinforeflection < nametoscore[AlmostWorst]) && (mutualinforeflection >= nametoscore[Best])) //f(R) < f(A) && f(R) > f(B)
                {
                    //Replace W with R and goto next iteration
                    if (changeWorsetoNew(Rreflection, mutualinforeflection))
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Could not delete old score value");
                        break;
                    }
                }
                else if (mutualinforeflection < nametoscore[Best]) //Try expansion
                {
                    Eexpansion = Ccentroid + 2 * (Ccentroid - nametovertex[Worst]); //Calculate Expansion //NOTE: in the handout and on the internet it's not calculated like this, I followed the pseudocode
                    mutualinfoexpansion = getMIForFeatureVector(Eexpansion); //Calculate f(E)

                    if (mutualinfoexpansion < mutualinforeflection) // f(E) < f(R)
                    {
                        //Replace W with E and goto next iteration
                        if (changeWorsetoNew(Eexpansion, mutualinfoexpansion))
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Could not delete old score value");
                            break;
                        }
                    }
                    else
                    {
                        //Replace W with R and goto next iteration
                        if (changeWorsetoNew(Rreflection, mutualinforeflection))
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Could not delete old score value");
                            break;
                        }
                    }
                }
                //NOTE: There is an Else if(f(R) < f(A)) in the handout that does not make sense, at this point it is not possible
                else if (mutualinforeflection < nametoscore[Worst]) //f(R) < f(W) (not better than the second worse but better than the worst)
                {
                    //Try Contraction
                    Concontraction = Ccentroid + (Ccentroid - nametovertex[Worst]) / 2; //Calculate Contraction
                    mutualinfocontraction = getMIForFeatureVector(Concontraction); //Calculate f(Con)

                 //   Concontraction2 = Ccentroid - (Ccentroid - nametovertex[Worst]) / 2; //Calculate Contraction
                 //   double mutualinfocontraction2 = getMIForFeatureVector(Concontraction2); //Calculate f(Con)
                 //   if (mutualinfocontraction2 < mutualinfocontraction) { Concontraction.copy(Concontraction2); mutualinfocontraction = mutualinfocontraction2; }

                    if (mutualinfocontraction < nametoscore[Worst]) //Contraction better than worst ( f(Con) < f(W) ) NOTE: in pseudocode f(A), everywhere else f(W) so I use f(W)
                    {
                        //Replace W with Con and goto next iteration
                        if (changeWorsetoNew(Concontraction, mutualinfocontraction))
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Could not delete old score value");
                            break;
                        }
                    }
                    else
                    {
                        //Do contraction of entire simplex
                        shrinking();
                        continue;
                    }
                }
                else //Reflected point does not improve things, contract the entire simplex
                {
                    shrinking();
                    continue;
                }
            }

            return nametovertex[Best];
        }

        public static void shrinking()
        {
            FeatureVector currentbest = new FeatureVector();
            currentbest.copy(nametovertex[Best]);

            for (int k = 0; k < NUMOFVERT; k++)
            {
                startFeatureVector[k] = currentbest + (startFeatureVector[k] - currentbest) / 2; //Zk = B + (Zk - B) / 2
            }
            startFeatureVector[nametoplaceinvectorarray[Best]].copy(currentbest); //Do not include best

            computeMutualInformation();
            filldictionaries();
        }

        public static bool changeWorsetoNew(FeatureVector inputvector, double scoretostore)
        {
            //Remove and insert into SortedDictionary
            while (scoretofeaturevector.ContainsKey(scoretostore))
            { //In case mutual information not unique, change it
                if(scoretostore == 0)
                {
                    scoretostore = 0.001;
                }
                scoretostore = scoretostore - scoretostore / 10000;
                //Console.WriteLine("not unique mutual information values found: {0}", scoretostore); //For debug purposes
            }
            bool succesfullyremoved = scoretofeaturevector.Remove(nametoscore[Worst]);
            scoretofeaturevector.Add(scoretostore, nametoplaceinvectorarray[Worst]); //It's place is going to be where the Worst was

            startFeatureVector[nametoplaceinvectorarray[Worst]].copy(inputvector); //Change vertex in featurevector

            filldictionaries();
            return succesfullyremoved;
        }
        //Gets the mutual information of the two images using the vertex in inputvector
        public static double getMIForFeatureVector(FeatureVector inputvector)
        {
            double[,] tempjointpdf = GetJointPDF(aimage, bimage, inputvector);
            return -computeMI(aimgpdf, bimgpdf, tempjointpdf); //NEGATIVE Mutual Information
        }

        //Helper function to fill the dictionarys with key-value pairs
        public static void filldictionaries()
        {
            nametoplaceinvectorarray.Clear();
            nametoplaceinvectorarray.Add(Best, scoretofeaturevector.ElementAt(0).Value);
            nametoplaceinvectorarray.Add(Worst, scoretofeaturevector.ElementAt(NUMOFVERT - 1).Value);
            nametoplaceinvectorarray.Add(AlmostWorst, scoretofeaturevector.ElementAt(NUMOFVERT - 2).Value);

            nametovertex.Clear();
            nametovertex.Add(Best       , startFeatureVector[nametoplaceinvectorarray[Best]]);
            nametovertex.Add(Worst      , startFeatureVector[nametoplaceinvectorarray[Worst]]);
            nametovertex.Add(AlmostWorst, startFeatureVector[nametoplaceinvectorarray[AlmostWorst]]);

            nametoscore.Clear();
            nametoscore.Add(Best, scoretofeaturevector.ElementAt(0).Key);
            nametoscore.Add(Worst, scoretofeaturevector.ElementAt(NUMOFVERT - 1).Key);
            nametoscore.Add(AlmostWorst, scoretofeaturevector.ElementAt(NUMOFVERT - 2).Key);

        }

        public static void computeCentroid()
        {
            Ccentroid.clear();
            foreach(FeatureVector element in startFeatureVector)
            {
                Ccentroid = Ccentroid + element; //Sum of every vertex
            }
            Ccentroid = Ccentroid - nametovertex[Worst]; //Subtract the worst point

            Ccentroid = Ccentroid / (NUMOFVERT - 1); //Divide by the number of vertices used in the summation
        }

        //Computes Joint PDF, then Mutual Information, and stores them
        public static void computeMutualInformation()
        {
            //Get Joint PDF using the NUMOFDIMS vertices 
            for (int i = 0; i < NUMOFVERT; i++)
            {
                jointimgpdf[i] = GetJointPDF(aimage, bimage, startFeatureVector[i]);
            }

            //Get the Mutual Information calculated with the NUMOFDIMS vertices
            scoretofeaturevector.Clear();
            for (int i = 0; i < NUMOFVERT; i++)
            {
                mutualinformation[i] = -computeMI(aimgpdf, bimgpdf, jointimgpdf[i]); //The NEGATIVE of Mutual Information
                while (scoretofeaturevector.ContainsKey(mutualinformation[i]))
                { //In case mutual information not unique, change it
                    if (mutualinformation[i] == 0)
                    {
                        mutualinformation[i] = 0.001;
                    }
                    mutualinformation[i] = mutualinformation[i] - mutualinformation[i] / 10000;
                    //Console.WriteLine("Not unique mutual information values found: {0}", mutualinformation[i]); //For debug purposes
                }
                scoretofeaturevector.Add(mutualinformation[i], i);
            }
        }
   
        public static void convertImagestoarrays()
        {
                  
            for (int m = 0; m < loadedimage1.Width; m++)
            {
                for (int n = 0; n < loadedimage1.Height; n++)
                {
                    Color pixelColor = loadedimage1.GetPixel(m, n);
                    int intensity = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    aimage[n, m] = intensity;
                }
            }

            for (int m = 0; m < loadedimage2.Width; m++)
            {
                for (int n = 0; n < loadedimage2.Height; n++)
                {
                    Color pixelColor = loadedimage2.GetPixel(m, n);
                    int intensity = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    bimage[n, m] = intensity;

                }

            }
        }

        public static void loadimage()
        {
            string currdir = System.IO.Directory.GetCurrentDirectory();
            string grandparent = System.IO.Path.Combine(currdir, @"..\..\");
            loadedimage1 = new Bitmap(Image.FromFile(grandparent + "soccerimage1.jpg"));
            loadedimage2 = new Bitmap(Image.FromFile(grandparent + "SoccerImageRotBy5_SHRBy20_SHVBy30.jpg"));
            aimage = new int[loadedimage1.Height, loadedimage1.Width];
            bimage = new int[loadedimage2.Height, loadedimage2.Width];
            convertImagestoarrays();
        }
        //Initializes the vertices, calculates PDF for the two images
        public static bool initialization()
        {
            //Initialize vertices to random values
            startFeatureVector = initializeFeatureVector();

            //This or just load predefined image
            
                loadimage();
                if ((aimage.GetLength(0) == 0) || (bimage.GetLength(0) == 0))
                {
                    return false;
                }
            
            //Get PDF of both images
            aimgpdf = GetImagePDF(aimage);
            bimgpdf = GetImagePDF(bimage);

            return true;
        }

        //Initialize simplex vertices to random values
        public static FeatureVector[] initializeFeatureVector()
        {
            FeatureVector[] newFeatureVector = new FeatureVector[NUMOFVERT]; // 4 dimension 5 vertices
            Random randomgenerator = new Random();

            for(int i = 0; i < NUMOFVERT; i++)
            {
                newFeatureVector[i] = new FeatureVector();
                newFeatureVector[i].A = 0.5 + randomgenerator.NextDouble() * 1.5;
                newFeatureVector[i].B = 0.25 + randomgenerator.NextDouble() * 1;
                newFeatureVector[i].C = -newFeatureVector[i].B;
                newFeatureVector[i].D = newFeatureVector[i].A;

                newFeatureVector[i].T1 = randomgenerator.Next(-25, -15);
                newFeatureVector[i].T2 = randomgenerator.Next(-35, -25);
            }

            return newFeatureVector;
        }

        /******************** Code from the handout below ********************/

        // Computes normalized image histogram (pdf) of the grayscale image 
        // assumes the image has been converted to a 2-D array of pixel intensity values
        public static double[] GetImagePDF(int[,] img)
        {
            int xMax = img.GetLength(0);
            int yMax = img.GetLength(1);
            double[] nonNormalizedPDF = new double[256]; //ranges 0 to 255
            for (int x = 0; x < xMax; x++)
            {
                for (int y = 0; y < yMax; y++)
                {
                    int tempValue = img[x, y];
                    nonNormalizedPDF[tempValue]++;
                }
            }
            double normalizationFactor = xMax * yMax;
            for (int g = 0; g < 256; g++)
            {
                nonNormalizedPDF[g] = nonNormalizedPDF[g] / normalizationFactor;
            }
            return nonNormalizedPDF;
        }
        
        public static double[,] GetJointPDF(int[,] aImgInt, int[,] bImgInt, FeatureVector f1) // f1 contains A,B,C,D,T1 and T2 values for a vertex 
        {
            double[,] jPDF = new double[256, 256];
            int xMax = aImgInt.GetLength(0);
            int yMax = aImgInt.GetLength(1);
            for (int x = 0; x < xMax; x++)
            {
                for (int y = 0; y < yMax; y++)
                {
                    double xPrimeC = f1.A * x + f1.B * y + f1.T1;
                    double yPrimeC = f1.C * x + f1.D * y + f1.T2;
                    int xPrime = (int)xPrimeC;
                    int yPrime = (int)yPrimeC;
                    if (((xPrime) < xMax) && ((xPrime) >= 0) && ((yPrime) < yMax) && ((yPrime) >= 0))
                    {
                        jPDF[aImgInt[x, y], bImgInt[xPrime, yPrime]] = jPDF[aImgInt[x, y], bImgInt[xPrime, yPrime]] + 1;
                    }
                }
            }
            double factor = 1.0 / (xMax * yMax);
            for (int a = 0; a < 256; a++)
            {
                for (int b = 0; b < 256; b++)
                {
                    jPDF[a, b] = factor * jPDF[a, b];
                }
            }
            return jPDF;
        }

        public static double computeMI(double[] aPDF, double[] bPDF, double[,] jPDF)
        {
            double currentMI = 0;
            for (int a = 0; a < 256; a++)
            {
                for (int b = 0; b < 256; b++)
                {
                    if ((aPDF[a] != 0) && (bPDF[b] != 0) && (jPDF[a, b] != 0))
                    {
                        currentMI = currentMI + jPDF[a, b] * Math.Log(jPDF[a, b] / (aPDF[a] * bPDF[b]));
                    }
                }
            }
            return currentMI;
        }
    }
    }
