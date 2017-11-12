using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.IO;
using System.Drawing;

namespace CV_basics
{
    class Transform : ITransform
    {

        public void ShowInGray(Mat sourceImage, string targetDir)
        {
            Mat gray_image = new Mat();
            CvInvoke.CvtColor(sourceImage, gray_image, ColorConversion.Bgr2Gray);

            CvInvoke.Imwrite(targetDir + "\\Gray_image.jpg", gray_image);

            CvInvoke.NamedWindow("source", NamedWindowType.AutoSize);
            CvInvoke.NamedWindow("gray", NamedWindowType.AutoSize);

            CvInvoke.Imshow("source", sourceImage);
            CvInvoke.Imshow("gray", gray_image);
        }


        public void ShowSplitted(Mat sourceImage)
        {

            var splittedImage = sourceImage.Split();
        
            for (int i = 0; i < splittedImage.Count(); i++)
            {
                CvInvoke.NamedWindow("split" + "bgr"[i], NamedWindowType.AutoSize);
                CvInvoke.Imshow("split" + "bgr"[i], splittedImage[i]);
            }
        }

        public void Blur(Mat sourceImage)
        {
            Matrix<float> kernel = new Matrix<float>(new float[3, 3] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } });
            kernel = kernel / 9;

            var anchor = new Point(-1, -1);
            var dst = sourceImage.Clone();

            CvInvoke.Filter2D(sourceImage, dst, kernel, anchor);

            CvInvoke.NamedWindow("source", NamedWindowType.AutoSize);
            CvInvoke.Imshow("source", sourceImage);

            CvInvoke.NamedWindow("smooth", NamedWindowType.AutoSize);
            CvInvoke.Imshow("smooth", dst);
        }

        public void Sharpen(Mat sourceImage)
        {
            Matrix<float> kernel = new Matrix<float>(new float[3, 3] { { 1, 1, 1 }, { 1, 9, 1 }, { 1, 1, 1 } });
            kernel = kernel / 9;
            var anchor = new Point(-1, -1);
            var dst = sourceImage.Clone();

            CvInvoke.Filter2D(sourceImage, dst, kernel, anchor);

            CvInvoke.NamedWindow("source", NamedWindowType.AutoSize);
            CvInvoke.Imshow("source", sourceImage);

            CvInvoke.NamedWindow("sharp", NamedWindowType.AutoSize);
            CvInvoke.Imshow("sharp", dst);
        }

        public void GaussianBlur(Mat sourceImage, int kernelSize)
        {
            var dst = sourceImage.Clone();

            Size ksize = new Size { Height = kernelSize, Width = kernelSize };
            CvInvoke.GaussianBlur(sourceImage, dst, ksize,5);
            
            CvInvoke.NamedWindow("source", NamedWindowType.AutoSize);
            CvInvoke.Imshow("source", sourceImage);

            CvInvoke.NamedWindow("GaussianBlur", NamedWindowType.AutoSize);
            CvInvoke.Imshow("GaussianBlur", dst);
        }

        public void ZoomIn(Mat sourceImage, int times)
        {
            var dst = sourceImage.Clone();
            var tmp = sourceImage.Clone();

            for (int i = 1; i < times; i++)
            {
                CvInvoke.PyrUp(tmp, dst);
                tmp = dst;
            }            

            CvInvoke.NamedWindow("source", NamedWindowType.AutoSize);
            CvInvoke.Imshow("source", sourceImage);

            CvInvoke.NamedWindow("Zoom in " + times + "x", NamedWindowType.AutoSize);
            CvInvoke.Imshow("Zoom in " + times + "x", dst);
        }
        public void ZoomOut(Mat sourceImage, int times)
        {
            var dst = sourceImage.Clone();
            var tmp = sourceImage.Clone();

            for (int i = 1; i < times; i++)
            {
                CvInvoke.PyrDown(tmp, dst);
                tmp = dst;
            }

            CvInvoke.NamedWindow("source", NamedWindowType.AutoSize);
            CvInvoke.Imshow("source", sourceImage);

            CvInvoke.NamedWindow("Zoom out " + times + "x", NamedWindowType.AutoSize);
            CvInvoke.Imshow("Zoom out " + times + "x", dst);
        }

        public void Threshold(Mat sourceImage, int threshold)
        {
            var hsv = sourceImage.Clone();
            

            Hsv lowerLimit1 = new Hsv(0, 50, 50);
            Hsv upperLimit1 = new Hsv(20, 255, 255);
            Hsv lowerLimit2 = new Hsv(160, 50, 50);
            Hsv upperLimit2 = new Hsv(180, 255, 255);

            CvInvoke.CvtColor(sourceImage, hsv, ColorConversion.Bgr2Hsv);

            Image<Hsv, Byte> imageHSV = hsv.ToImage<Hsv, byte>();
            var mask1 = imageHSV.InRange(lowerLimit1, upperLimit1);
            var mask2 = imageHSV.InRange(lowerLimit2, upperLimit2);
            var mask = mask1 + mask2;
            var imageHSVRed = imageHSV.Clone().Split()[0];
            CvInvoke.BitwiseAnd(mask, imageHSV.Split()[0], imageHSVRed);


            CvInvoke.NamedWindow("red", NamedWindowType.AutoSize);
            CvInvoke.Imshow("red", imageHSVRed);

            CvInvoke.NamedWindow("source", NamedWindowType.AutoSize);
            CvInvoke.Imshow("source", sourceImage);
                      
            var channelH = imageHSVRed.Split()[0];

            var thresholded = channelH.Clone();

            CvInvoke.Threshold(channelH, thresholded, threshold, 255, ThresholdType.Binary);

            CvInvoke.NamedWindow("Threshold", NamedWindowType.AutoSize);
            CvInvoke.Imshow("Threshold", thresholded);

        }

        public void RotateZoomGray(Mat sourceImage, int rotate, int zoom)
        {
            Image<Gray, Byte> srcImage = sourceImage.ToImage<Gray, byte>();
            var rotatedImage = srcImage.Rotate((double)rotate, new Gray(255));

            var dst = rotatedImage.Clone();
            var tmp = rotatedImage.Clone();

            for (int i = 1; i < Math.Abs(zoom); i++)
            {
                if (zoom > 0)
                {
                    CvInvoke.PyrUp(tmp, dst);
                }
                else
                {
                    CvInvoke.PyrDown(tmp, dst);
                }
                tmp = dst;
            }

            CvInvoke.NamedWindow("source", NamedWindowType.AutoSize);
            CvInvoke.NamedWindow("Rotated, zoomed, gray", NamedWindowType.AutoSize);

            CvInvoke.Imshow("source", sourceImage);
            CvInvoke.Imshow("Rotated, zoomed, gray", dst);
        }

    }
}
