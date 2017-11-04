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

        public void Filter1(Mat sourceImage)
        {
            Matrix<float> kernel = new Matrix<float>(new float[3, 3] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } });
            kernel = kernel / 9;

            var anchor = new Point(-1, -1);
            var dst = sourceImage.Clone();

            CvInvoke.Filter2D(sourceImage, dst, kernel, anchor);

            CvInvoke.NamedWindow("source", NamedWindowType.AutoSize);
            CvInvoke.Imshow("source", sourceImage);

            CvInvoke.NamedWindow("dst", NamedWindowType.AutoSize);
            CvInvoke.Imshow("dst", dst);
        }

        public void Filter2(Mat sourceImage)
        {
            Matrix<float> kernel = new Matrix<float>(new float[3, 3] { { 1, 1, 1 }, { 1, 9, 1 }, { 1, 1, 1 } });
            kernel = kernel / 9;
            var anchor = new Point(-1, -1);
            var dst = sourceImage.Clone();

            CvInvoke.Filter2D(sourceImage, dst, kernel, anchor);

            CvInvoke.NamedWindow("source", NamedWindowType.AutoSize);
            CvInvoke.Imshow("source", sourceImage);

            CvInvoke.NamedWindow("dst", NamedWindowType.AutoSize);
            CvInvoke.Imshow("dst", dst);
        }

    }
}
