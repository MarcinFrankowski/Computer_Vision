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

        /// <summary>
        /// Displays splitted BGR channels
        /// </summary>
        /// <param name="sourceImage">Source image</param>
        void ShowSplitted(Mat sourceImage);

        /// <summary>
        /// Displays blurred image
        /// </summary>
        /// <param name="sourceImage">Source image</param>
        void Blur(Mat sourceImage);

        /// <summary>
        /// Displays sharpen image
        /// </summary>
        /// <param name="sourceImage">Source image</param>
        void Sharpen(Mat sourceImage);

        /// <summary>
        /// Displays blurred image using Gaussian blur
        /// </summary>
        /// <param name="sourceImage">Source image</param>
        /// <param name="kernelSize">Gaussian blur kernel size</param>
        void GaussianBlur(Mat sourceImage, int kernelSize);

        /// <summary>
        /// Displays zoomed in image
        /// </summary>
        /// <param name="sourceImage">Source image</param>
        /// <param name="times">Zoom in value</param>
        void ZoomIn(Mat sourceImage, int times);

        /// <summary>
        /// Displays zoomed out image
        /// </summary>
        /// <param name="sourceImage">Source image</param>
        /// <param name="times">Zoom out value</param>
        void ZoomOut(Mat sourceImage, int times);

        /// <summary>
        /// Displays thresholded image 
        /// </summary>
        /// <param name="sourceImage">Source image</param>
        /// <param name="threshold">Threshold value</param>
        void Threshold(Mat sourceImage, int threshold);

        /// <summary>
        /// Displays rotated, zoomed image, in gray
        /// </summary>
        /// <param name="sourceImage">Source image</param>
        /// <param name="rotate">Angles to rotate</param>
        /// <param name="zoom">Zoom value (positive zoom in, negative zoom out)</param>
        void RotateZoomGray(Mat sourceImage, int rotate, int zoom);

        /// <summary>
        /// Displays example of erosion operation
        /// </summary>
        /// <param name="sourceImage">Source image</param>
        void Erosion(Image<Bgr, Byte> sourceImage);

        /// <summary>
        /// Displays example of dilation operation
        /// </summary>
        /// <param name="sourceImage">Source image</param>
        void Dilation(Image<Bgr, Byte> sourceImage);

        /// <summary>
        /// Displays example of histogram equalization
        /// </summary>
        /// <param name="sourceImage">Source image</param>
        void NormHist(Image<Bgr, Byte> sourceImage);
    }
}
