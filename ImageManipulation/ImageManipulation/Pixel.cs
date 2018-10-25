using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulation
{
    public class Pixel
    {
        public int Red { get; private set; }
        public int Green { get; private set; }
        public int Blue { get; private set; }

        public Pixel(int red, int green, int blue)
        {
            this.Red = (!(red < 0 || red > 255)) ? red: throw new ArgumentOutOfRangeException("Parameter value outside of expected range (0-255): red = " + red);
            this.Green = (!(green < 0 || green > 255)) ? green : throw new ArgumentOutOfRangeException("Parameter value outside of expected range (0-255): green = " + green);
            this.Blue = (!(blue < 0 || blue > 255)) ? blue : throw new ArgumentOutOfRangeException("Parameter value outside of expected range (0-255): blue = " + blue);
        }

        public Pixel(int intensity)
        {
            if(intensity < 0 || intensity > 255)
            {
                throw new ArgumentOutOfRangeException("Parameter value outside of expected range (0-255): intensity = " + intensity);
            }

            this.Red = intensity;
            this.Green = intensity;
            this.Blue = intensity;
        }

        public int Grey() {
            int average;
            return average = (Blue + Red + Green) / 3;
        }
    }
}
