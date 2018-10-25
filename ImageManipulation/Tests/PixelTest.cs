using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageManipulation;

namespace Tests
{
    [TestClass]
    public class PixelTest
    {
        [TestMethod]
        public void IntensityTest()
        {
            Pixel pixel = new Pixel(200);
            Pixel pixel2 = new Pixel(200,200,200);
            Assert.AreEqual(pixel.Red, pixel2.Red);
            Assert.AreEqual(pixel.Green, pixel2.Green);
            Assert.AreEqual(pixel.Blue, pixel2.Blue);
        }

        [TestMethod]
        public void GreyTest()
        {
            Pixel pixelUsedForGrey = new Pixel(50,75,100);
            int grey = pixelUsedForGrey.Grey();
            Pixel pixel = new Pixel(75, 75, 75);
            Pixel pixel2 = new Pixel(grey);
            Assert.AreEqual(pixel.Red, pixel2.Red);
            Assert.AreEqual(pixel.Green, pixel2.Green);
            Assert.AreEqual(pixel.Blue, pixel2.Blue);
        }

        [TestMethod]
        public void PixelTests()
        {
            Pixel pixel = new Pixel(200, 100, 50);
            Pixel pixel2 = new Pixel(200, 100, 50);
            Assert.AreEqual(pixel.Red, pixel2.Red);
            Assert.AreEqual(pixel.Green, pixel2.Green);
            Assert.AreEqual(pixel.Blue, pixel2.Blue);
        }
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void IntensityFail()
        {
            Pixel pixel = new Pixel(280);
            Pixel pixel2 = new Pixel(280, 280, 280);
            Assert.AreEqual(pixel.Red, pixel2.Red);
            Assert.AreEqual(pixel.Green, pixel2.Green);
            Assert.AreEqual(pixel.Blue, pixel2.Blue);
        }
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void PixelFailRed()
        {
            Pixel pixel = new Pixel(220, 100, 50);
            Pixel pixel2 = new Pixel(280, 100, 50);
            Assert.AreEqual(pixel.Red, pixel2.Red);
            Assert.AreEqual(pixel.Green, pixel2.Green);
            Assert.AreEqual(pixel.Blue, pixel2.Blue);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void PixelFailGreen()
        {
            Pixel pixel = new Pixel(220, 100, 50);
            Pixel pixel2 = new Pixel(220, 280, 50);
            Assert.AreEqual(pixel.Red, pixel2.Red);
            Assert.AreEqual(pixel.Green, pixel2.Green);
            Assert.AreEqual(pixel.Blue, pixel2.Blue);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void PixelFailBlue()
        {
            Pixel pixel = new Pixel(220, 100, 50);
            Pixel pixel2 = new Pixel(220, 100, 500);
            Assert.AreEqual(pixel.Red, pixel2.Red);
            Assert.AreEqual(pixel.Green, pixel2.Green);
            Assert.AreEqual(pixel.Blue, pixel2.Blue);
        }
    }
}
