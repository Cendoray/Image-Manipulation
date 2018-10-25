using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulation
{
    public class Image
    {
        // Propreties
        public string Metadata { get; private set; }
        public int MaxRange { get; private set; }

        private Pixel[,] data;

        public int Height { get { return data.GetLength(0); } private set { } }
        public int Width { get { return data.GetLength(1); } private set { } }

        // Contructor
        public Image(string meta, int max, Pixel[,] img)
        {
            // Input validation
            if (max < 0)
                throw new ArgumentOutOfRangeException("The maximum range cannot be negative");
            if (max > 255)
                throw new ArgumentOutOfRangeException("The maximum range cannot be over 255");
            this.MaxRange = max;
            this.Metadata = meta;

            this.data = deepCopy(img);
        }

        // Indexer
        public Pixel this[int i, int j]
        {
            get
            {
                Pixel copy = data[i, j];
                return copy;
            }
            private set
            {
            }
        }

        public void toGrey()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    this.data[i, j] = new Pixel(this.data[i, j].Grey());
                }
            }
        }
        
        public void Flip(Boolean horizental)
        {
            Pixel[,] flipped = new Pixel[Height, Width];

            if (horizental)
            {
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        flipped[i, (Width - 1) - j] = data[i, j];
                    }
                }
            }

            else
            {
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        flipped[(Height - 1) - i, j] = data[i, j];
                    }
                }
            }

            this.data = flipped;
        }


        public void Crop(int startX, int startY, int endX, int endY)
        {
            if (startX < 0 || startY < 0)
                throw new ArgumentOutOfRangeException("The value of the start variables are too small");
            if (startX > endX || startY > endY)
                throw new ArgumentOutOfRangeException("The value of the start variables are too big");
            if (startX > data.GetLength(0) || startY > data.GetLength(1) || startX > data.GetLength(0) || startY > data.GetLength(1))
                throw new ArgumentOutOfRangeException("You are attempting to crop outside of the image's dimensions");
            int height = endY-startY;
            int width = endX-startX;

            Pixel[,] cropped = new Pixel[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    cropped[i, j] = data[i + startX, j + startY];
                }
            }
            this.data = cropped;
        }

        private Pixel[,] deepCopy(Pixel[,] original)
        {
            Pixel[,] copy = new Pixel[original.GetLength(0), original.GetLength(1)];

            for (int i = 0; i < original.GetLength(0); i++)
            {
                for (int j = 0; j < original.GetLength(1); j++)
                {
                    Pixel p = new Pixel(original[i, j].Red, original[i, j].Green, original[i, j].Blue);
                    copy[i, j] = p;
                }
            }

            return copy;
        }
    } // class end
} // namespace end 
