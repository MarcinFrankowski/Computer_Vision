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
           


            int userInput = 0;
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
                            Transform.Filter1(image);
                            break;
                        }
                    case 4:
                        {
                            Transform.Filter2(image);
                            break;
                        }
                    default:
                        break;
                }
                Console.WriteLine("Press any key to close images");
                CvInvoke.WaitKey(0);
            } while (userInput != 5);

        }
        static public int DisplayMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine();
            Console.WriteLine("1. BGR to Gray");
            Console.WriteLine("2. Split");
            Console.WriteLine("3. Filter 1");
            Console.WriteLine("4. Filter 2");
            Console.WriteLine("5. Quit");
            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }
    }
}
