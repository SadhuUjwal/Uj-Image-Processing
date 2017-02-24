using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingMyWork

{
    class Kernel
    {
        double[,] LaplacianMaskA = new double[3, 3]
        {
            {0,-1,0 },
            {-1,4,-1 },
            {0,-1,0 },
        };

        double[,] LaplacianMaskB = new double[3, 3]
        {
            {0,1,0 },
            {1,-4,1 },
            {0,1,0 },
        };

        double[,] LaplacianMaskC = new double[3, 3]
        {
            {-1,-1,-1 },
            {-1,8,-1 },
            {-1,-1,-1 },
        };

        double[,] SharpenMask = new double[3, 3]
        {
            {0,-1,0 },
            {-1,5,-1 },
            {0,-1,0 },
        };

        double[,] Blur = new double[3, 3]
        {
            {1/9f,1/9f,1/9f },
            {1/9f,1/9f,1/9f },
            {1/9f,1/9f,1/9f },
        };

        double[,] Guassian = new double[3, 3]
        {
            {1/16f,2/16f,1/16f },
            {2/16f,1/16f,2/16f },
            {1/16f,2/16f,1/16f },
        };

        public double[,] LaplacianMask_A
        {
            get { return LaplacianMaskA; }
        }

        public double[,] LaplacianMask_B
        {
            get { return LaplacianMaskB; }
        }

        public double[,] LaplacianMask_C
        {
            get { return LaplacianMaskC; }
        }

        public double[,] Sharpen_Mask
        {
            get { return SharpenMask; }
        }

        public double[,] Blur_Image
        {
            get { return Blur; }
        }

        public double[,] Guassian_Image
        {
            get { return Guassian; }
        }
    }
}
