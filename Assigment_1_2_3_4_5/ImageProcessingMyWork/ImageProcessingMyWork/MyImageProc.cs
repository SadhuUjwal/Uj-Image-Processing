using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingMyWork { 
    public class MyImageProc
    {
        public MyImageProc() { }

        public static bool ConvertToGrey(Bitmap b)
        {
            try
            {
                for(int i=0;i<b.Width;i++)
                    for(int j=0;j<b.Height;j++)
                    {
                        Color c1 = b.GetPixel(i, j);
                        int r1 = c1.R;
                        int g1 = c1.G;
                        int b1 = c1.B;
                        int grey = (byte)(.299 * r1 + .587 * g1 + .114 * b1);
                        r1 = grey;
                        b1 = grey;
                        g1 = grey;
                        b.SetPixel(i, j, Color.FromArgb(r1, b1, g1));
                    }
                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }
        public static Bitmap Brighten(Bitmap use, int nBrightness)
        {
            int Red, Green, Blue;
            if (nBrightness < -255 || nBrightness > 255)
                return use;
            Bitmap Bright = new Bitmap(use.Width, use.Height);
            for (int r = 0; r < use.Height; r++)
            {
                for (int c = 0; c < use.Width; c++)
                {
                    Color cr = use.GetPixel(c, r);
                    Red = nBrightness + Convert.ToInt32(cr.R);
                    Green = nBrightness + Convert.ToInt32(cr.G);
                    Blue = nBrightness + Convert.ToInt32(cr.B);

                    if (Red > 255) Red = 255;
                    if (Red < 0) Red = 0;
                    if (Green > 255) Green = 255;
                    if (Green < 0) Green = 0;
                    if (Blue > 255) Blue = 255;
                    if (Blue < 0) Blue = 0;

                    Bright.SetPixel(c, r, Color.FromArgb(Red, Green, Blue));

                }
            }
            return Bright;
        }

        public static Bitmap Contrast(Bitmap b, sbyte nContrast)
        {
            Bitmap Contrast = new Bitmap(b.Width, b.Height);

            if (nContrast < -100) nContrast = -100;
            if (nContrast > 100) nContrast = 100;

            double pixel = 0, contrast = (100.0 + nContrast) / 100.0;

            contrast *= contrast;

            int red, green, blue;

            for (int y = 0; y < b.Height; ++y)
            {
                for (int x = 0; x < b.Width; ++x)
                {
                    Color cr = b.GetPixel(x, y);

                    red = Convert.ToInt32(cr.R);
                    green = Convert.ToInt32(cr.G);
                    blue = Convert.ToInt32(cr.B);

                    pixel = red / 255.0;
                    pixel -= 0.5;
                    pixel *= contrast;
                    pixel += 0.5;
                    pixel *= 255;
                    if (pixel < 0) pixel = 0;
                    if (pixel > 255) pixel = 255;
                    red = (int)pixel;

                    pixel = green / 255.0;
                    pixel -= 0.5;
                    pixel *= contrast;
                    pixel += 0.5;
                    pixel *= 255;
                    if (pixel < 0) pixel = 0;
                    if (pixel > 255) pixel = 255;
                    green = (int)pixel;

                    pixel = blue / 255.0;
                    pixel -= 0.5;
                    pixel *= contrast;
                    pixel += 0.5;
                    pixel *= 255;
                    if (pixel < 0) pixel = 0;
                    if (pixel > 255) pixel = 255;
                    blue = (int)pixel;

                    Contrast.SetPixel(x, y, Color.FromArgb(red, green, blue));
                }
            }
            return Contrast;
        }

        public static bool RotateClear(Image img, ref Bitmap bm, double Rot)
        {
            if (Rot < -360 || Rot > 360)
                return false;
            bm = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);
            Graphics dc = Graphics.FromImage(bm);
            dc.Clear(Color.White);
            dc.RotateTransform((float)Rot);
            dc.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));

            return true;
        }

        public static bool RotateFill(Image img, ref Bitmap bm, double Rot)
        {
            if (Rot < -360 || Rot > 360)
                return false;
            bm = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);
            Graphics dc = Graphics.FromImage(bm);
            dc.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            dc.RotateTransform((float)Rot);
            double rdegrees = Rot * 3.141516 / 180;
            int shift = (int)(bm.Height / 2 * Math.Tan(rdegrees));
            if (rdegrees > 0)
                //dc.DrawImage(img,new Rectangle((int)shift-(int)(1.2*Rot),(int)-shift,img.Width,img.Height));
                dc.DrawImage(img, new Rectangle((int)shift, (int)-shift, img.Width, img.Height));
            else
                dc.DrawImage(img, new Rectangle((int)shift, (int)-shift / 2, img.Width, img.Height));
            return true;
        }

        public static bool ShiftImageHorizontal(Image img, ref Bitmap bmp, int shiftAmt)
        {
            if (shiftAmt > img.Width)
                return false;
            //bmp = new Bitmap(img.Width + Math.Abs(shiftAmt), img.Height, PixelFormat.Format24bppRgb);
            bmp = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);
            Graphics dc = Graphics.FromImage(bmp);
            dc.Clear(Color.Black);
            dc.TranslateTransform(shiftAmt, 0);
            dc.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            return true;
        }

        public static bool ShiftImageVertical(Image img, ref Bitmap bmp, int shiftAmt)
        {
            if (shiftAmt > img.Width)
                return false;
            bmp = new Bitmap(img.Width, img.Height + Math.Abs(shiftAmt), PixelFormat.Format24bppRgb);
            bmp = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);
            Graphics dc = Graphics.FromImage(bmp);
            dc.Clear(Color.Black);
            dc.TranslateTransform(0, shiftAmt);
            dc.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            return true;
        }

        public static bool ResizeImage(Image img, ref Bitmap bm, Rectangle rect)
        {
            bm = new Bitmap(rect.Width, rect.Height, PixelFormat.Format24bppRgb);
            Graphics dc = Graphics.FromImage(bm);
            dc.DrawImage(img, rect);
            return true;
        }

        public static bool DrawX(Image img, ref Bitmap bm, Point pt)
        {
            bm = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);
            Graphics dc = Graphics.FromImage(bm);
            dc.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            Brush br = new SolidBrush(Color.Red);
            Point p1 = new Point(pt.X - 3, pt.Y - 3);
            Point p2 = new Point(pt.X + 3, pt.Y + 3);
            dc.DrawLine(new Pen(Color.Blue), p1, p2);
            Point p3 = new Point(pt.X + 3, pt.Y - 3);
            Point p4 = new Point(pt.X - 3, pt.Y + 3);
            dc.DrawLine(new Pen(Color.Blue), p3, p4);

            return true;
        }

        public static bool DrawRectangle(Image img, ref Bitmap bm, Rectangle rect)
        {
            bm = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);
            Graphics dc = Graphics.FromImage(bm);
            dc.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            dc.DrawRectangle(new Pen(Color.Red), rect);
            return true;
        }
    }
}
