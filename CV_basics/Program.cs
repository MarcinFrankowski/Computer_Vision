using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.IO;

namespace CV_basics
{
    class Program
    {
        static void Main(string[] args)
        {
            ITransform Transform = new Transform();
        
            string imagesDir, dir;

            dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            imagesDir = Path.Combine(dir, "images");

            Mat image = CvInvoke.Imread(imagesDir + "\\lena.jpg", LoadImageType.AnyColor);
            
            if (image.IsEmpty)
            {
                Console.WriteLine("Failed to get image data");
                Console.ReadKey();
            }
           


            int userInput;
            do
            {
                Console.Clear();
                CvInvoke.DestroyAllWindows();
                userInput = DisplayMenu();
                switch (userInput)
                {
                            
                    case 1:
                        {
                            Transform.ShowInGray(image, imagesDir);
                            break;
                        }
                    case 2:
                        {
                            Transform.ShowSplitted(image);
                            break;
                        }
                    case 3:
                        {
                            Transform.Blur(image);
                            break;
                        }
                    case 4:
                        {
                            Transform.Sharpen(image);
                            break;
                        }
                    case 5:
                        {
                            int ksize = 1;
                            Console.Clear();
                            Console.WriteLine(" Enter kernel size (must be positive and odd) \n kernel size = 1 or 3 gives best result for noise filtering \n");
                            ksize = int.Parse(Console.ReadLine());

                            if ((ksize < 1) || (ksize % 2 == 0))
                            {
                                Console.WriteLine("Invalid kernel size");
                                Console.WriteLine("Press any key to continue ...");
                                Console.ReadKey();
                                break;
                            }

                            Transform.GaussianBlur(image, ksize);
                            break;
                        }
                    case 6:
                        {
                            int times = 1;
                            Console.Clear();
                            Console.WriteLine("Enter zoomIn (int value) \n");
                            times = int.Parse(Console.ReadLine());

                            Transform.ZoomIn(image,times);
                            break;
                        }
                    case 7:
                        {
                            int times = 1;
                            Console.Clear();
                            Console.WriteLine("Enter zoomOut (int value) \n");
                            times = int.Parse(Console.ReadLine());

                            Transform.ZoomOut(image, times);
                            break;
                        }
                    case 8:
                        {
                            int threshold;
                            Console.Clear();
                            Console.WriteLine("Enter threshold value (int) \n");
                            threshold = int.Parse(Console.ReadLine());


                            Transform.Threshold(image, threshold);
                            break;
                        }
                    case 9:
                        {
                            int rotate, zoom;
                            Console.Clear();
                            Console.WriteLine("Enter rotate value (int, angles, clockwise rotation) \n");
                            rotate = int.Parse(Console.ReadLine());
                            Console.Clear();
                            Console.WriteLine("Enter zoom value (positive for zoom in, negative for zoom out) \n");
                            zoom = int.Parse(Console.ReadLine());


                            Transform.RotateZoomGray(image, rotate, zoom);
                            break;
                        }
                    default:
                        break;
                }
                Console.WriteLine("Press any key to close images");
                CvInvoke.WaitKey(0);
            } while (userInput != 0);

        }
        static public int DisplayMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine();
            Console.WriteLine("1. BGR to Gray");
            Console.WriteLine("2. Split");
            Console.WriteLine("3. Blur");
            Console.WriteLine("4. Sharpen");
            Console.WriteLine("5. Gaussian Blur");
            Console.WriteLine("6. Zoom In");
            Console.WriteLine("7. Zoom Out");
            Console.WriteLine("8. Threshold");
            Console.WriteLine("9. Rotate, zoom, to gray");
            Console.WriteLine("0. Quit");
            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }
    }
}
