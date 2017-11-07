using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace CV_basics
{

    interface ITransform
    {
        /// <summary>
        /// Displays given image in gray, saves in given directory
        /// </summary>
        /// <param name="sourceImage">Source image</param>
        /// <param name="targetDir">Target directory for gray image</param>
        void ShowInGray(Mat sourceImage, string targetDir);

        void ShowSplitted(Mat sourceImage);

        void Blur(Mat sourceImage);
        void Sharpen(Mat sourceImage);
        void GaussianBlur(Mat sourceImage, int kernelSize);
        void ZoomIn(Mat sourceImage, int times);
        void ZoomOut(Mat sourceImage, int times);
    }
}
