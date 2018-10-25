using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulation
{
    //P3 FORMAT -- COLOR
    public class PnmSerializer : IImageSerializer
    {
        public Image Parse(string imageData)
        {
            string[] array = imageData.Split('\n');
            string metadata = "";
            int pixelStart = 1; // Start at 1 bcs 1st entry is necessarily format specifier
            int width = -1;
            int height = -1;
            int max = -1;

            // Sets value of metadata and maxValue, determines where pixels start
            foreach (string i in array)
            {
                // If it's a comment
                if (i.StartsWith("#"))
                {
                    metadata = metadata + i;
                    pixelStart++; // Increament here bcs # of comments in file can vary
                }
                // If it isn't a comment and not the format specifier
                else if (!(i.StartsWith("P")))
                {
                    // If height & width haven't been set yet
                    if (width == -1 && height == -1)
                    {
                        // height & width unknown
                        string[] dimensions = i.Split(' ');
                        width = Convert.ToInt32(dimensions[0]);
                        height = Convert.ToInt32(dimensions[1]);
                        pixelStart++;
                    }
                    // If maxValue isn't set yet
                    else if (max == -1)
                    {
                        max = Convert.ToInt32(i);
                        pixelStart++;
                    }
                    // This should only be reach if everything is set and we're therefore at the pixel values
                    else
                    {
                        break; // Exit foreach loop
                    }
                }
            } // end of foreach

            Pixel[,] pixels = new Pixel[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    pixels[i, j] = new Pixel(Convert.ToInt32(array[pixelStart]), Convert.ToInt32(array[pixelStart+1]), Convert.ToInt32(array[pixelStart+2]));
                    pixelStart += 3; // Jumps to red (first) value of the next pixel
                }
            }

            return new Image(metadata, max, pixels);
        } // end of method

        public string Serialize(Image i)
        {
            StringBuilder sb = new StringBuilder("P3\n");

            string[] comments = i.Metadata.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);

            for (int x = 0; x < comments.Length; x++)
            {
                sb.Append("#" + comments[x] + "\n");
            }

            sb.Append(i.Width + " " + i.Height + "\n");
            sb.Append(i.MaxRange + "\n");

            for (int h = 0; h < i.Height; h++)
            {
                for (int w = 0; w < i.Width; w++)
                {
                    sb.Append(i[h,w].Red + "\n");
                    sb.Append(i[h, w].Green + "\n");
                    sb.Append(i[h, w].Blue + "\n");
                }
            }

            return sb.ToString();
        }
    }
}
