using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulation
{
    public class ImageUtilities
    {

        public static Image[] LoadFolder(String path) {

            //C:\Users\Thomas\Documents\School Stuff\4th semester\c#\assignments\assignment 1\ImageManipulation\ImageManipulation\Tests\bin\Debug
            //System.Diagnostics.Debug.WriteLine(output)
            string[] files = Directory.GetFiles(path);

            List<Image> images = new List<Image>();
            for (int i = 0; i < files.Length; i++)
            {
                string fileExtension = files[i].Substring(files[i].LastIndexOf('.'));
                if (fileExtension == ".pgm")
                {
                    // Takes all data out of the file
                    string input = File.ReadAllText(files[i]);
                    // Uses serializer class to make a new image from the file and add it to the list
                    PgmSerializer serializer = new PgmSerializer();
                    images.Add(serializer.Parse(input));
                } else if (fileExtension == ".pnm")
                {
                    // Takes all data out of the file
                    string input = File.ReadAllText(files[i]);
                    // Uses serializer class to make a new image from the file and add it to the list
                    PnmSerializer serializer = new PnmSerializer();
                    images.Add(serializer.Parse(input));
                }
            }

            return images.ToArray();
        }

        public static void saveFolder(String path, Image[] img, String format) {

            for(int i = 0; i < img.Length; i++)
            {
                string imageData;
                string file = path + ("\\img" + i);
                if (format == "pgm")
                {
                    file += ".pgm";
                    PgmSerializer serializer = new PgmSerializer();
                    imageData = serializer.Serialize(img[i]);
                    File.Create(file);
                    File.WriteAllText(file, imageData);
                }
                else if (format == "pnm")
                {

                    file += ".pnm";
                    PnmSerializer serializer = new PnmSerializer();
                    imageData = serializer.Serialize(img[i]);
                    File.Create(file);
                    File.WriteAllText(file, imageData);
                }

            }
        }

    }
}
