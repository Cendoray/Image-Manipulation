using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageManipulation;

namespace Tests
{
    [TestClass]
    public class ImageTest
    {

        [TestMethod]
        public void ImageTests()
        {
            //act
            Image img = new Image("hi", 245, createPixel());
            Image img2 = new Image("hi", 245, createPixel());
            //assert
            Assert.AreEqual(img.Width, img2.Width);
            Assert.AreEqual(img.Height, img2.Height);
            Assert.AreEqual(img.Metadata, img2.Metadata);
            Assert.AreEqual(img.MaxRange, img2.MaxRange);

        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void ImageFailMax()
        {
            //act
            Image img = new Image("hi", 500, createPixel());
            Image img2 = new Image("hi", 500, createPixel());
            //assert
            Assert.AreEqual(img.Width, img2.Width);
            Assert.AreEqual(img.Height, img2.Height);
            Assert.AreEqual(img.Metadata, img2.Metadata);
            Assert.AreEqual(img.MaxRange, img2.MaxRange);

        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void ImageFailNegative()
        {
            //act
            Image img = new Image("hi", -500, createPixel());
            Image img2 = new Image("hi", -500, createPixel());
            //assert
            Assert.AreEqual(img.Width, img2.Width);
            Assert.AreEqual(img.Height, img2.Height);
            Assert.AreEqual(img.Metadata, img2.Metadata);
            Assert.AreEqual(img.MaxRange, img2.MaxRange);
        }
        [TestMethod]
        public void ToGreyTest()
        {
            //act
            Image img = new Image("hi", 200, createPixel());
            img.toGrey();
            Pixel[,] pix2 = new Pixel[1, 1] {{ new Pixel(52, 52, 52) }};
            //assert
            Image img2 = new Image("hi", 200, pix2);
            Assert.AreEqual(img[0,0].Red, img2[0,0].Red);
            Assert.AreEqual(img[0, 0].Green, img2[0, 0].Green);
            Assert.AreEqual(img[0, 0].Blue, img2[0, 0].Blue);

        }

        [TestMethod]
        public void FlipTestHorizontal()
        {
            //act
            Image img = new Image("hi", 200, createPixel());
            img.Flip(true);
            Image img2 = new Image("hi", 200, createPixel());
            //assert
            Assert.AreEqual(img[0, 1].Red, img2[0, 0].Red);
            Assert.AreEqual(img[0, 1].Green, img2[0, 0].Green);
            Assert.AreEqual(img[0, 1].Blue, img2[0, 0].Blue);
        }

        [TestMethod]
        public void FlipTestVertical()
        {
            //act
            Image img = new Image("hi", 200, createPixel());
            img.Flip(false);
            Image img2 = new Image("hi", 200, createPixel());
            //assert
            Assert.AreEqual(img[0, 0].Red, img2[2, 0].Red);
            Assert.AreEqual(img[0, 0].Green, img2[2, 0].Green);
            Assert.AreEqual(img[0, 0].Blue, img2[2, 0].Blue);
        }

        [TestMethod]
        public void CropTest()
        {
            //act
            Image img = new Image("hi", 200, createPixel());
            img.Crop(1, 0, 2, 1);
            Pixel[,] pix2 = new Pixel[1, 1] { { new Pixel(44, 78, 230) } };
            Image img2 = new Image("hi", 200, pix2);
            //assert
            Assert.AreEqual(img[0, 0].Red, img2[0, 0].Red);
            Assert.AreEqual(img[0, 0].Green, img2[0, 0].Green);
            Assert.AreEqual(img[0, 0].Blue, img2[0, 0].Blue);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void CropFailSmall()
        {
            //act
            Image img = new Image("hi", 200, createPixel());
            img.Crop(-1, -1, -5, -5);
            Pixel[,] pix2 = new Pixel[1, 1] { { new Pixel(51, 52, 53) } };
            Image img2 = new Image("hi", 200, pix2);
            //assert
            Assert.AreEqual(img[0, 0].Red, img2[0, 0].Red);
            Assert.AreEqual(img[0, 0].Green, img2[0, 0].Green);
            Assert.AreEqual(img[0, 0].Blue, img2[0, 0].Blue);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void CropFailBig()
        {
            //act
            Image img = new Image("hi", 200, createPixel());
            img.Crop(1, 1, 0, 0);
            Pixel[,] pix2 = new Pixel[1, 1] { { new Pixel(51, 52, 53) } };
            Image img2 = new Image("hi", 200, pix2);
            //assert
            Assert.AreEqual(img[0, 0].Red, img2[0, 0].Red);
            Assert.AreEqual(img[0, 0].Green, img2[0, 0].Green);
            Assert.AreEqual(img[0, 0].Blue, img2[0, 0].Blue);
        }


        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void CropFailDimensions()
        {
            //act
            Image img = new Image("hi", 200, createPixel());
            img.Crop(4, 4, 5, 5);
            Pixel[,] pix2 = new Pixel[1, 1] { { new Pixel(51, 52, 53) } };
            Image img2 = new Image("hi", 200, pix2);
            //assert
            Assert.AreEqual(img[0, 0].Red, img2[0, 0].Red);
            Assert.AreEqual(img[0, 0].Green, img2[0, 0].Green);
            Assert.AreEqual(img[0, 0].Blue, img2[0, 0].Blue);
        }

        private Pixel[,] createPixel() {
            //arrange
            Pixel[,] pix = new Pixel[3, 2] { { new Pixel(51, 52, 53), new Pixel(101, 202, 204) }, { new Pixel(44, 78, 230), new Pixel(77, 88, 99) }, { new Pixel(1, 2, 3), new Pixel(84, 31, 47) } };
            return pix;
        }
    }
}
