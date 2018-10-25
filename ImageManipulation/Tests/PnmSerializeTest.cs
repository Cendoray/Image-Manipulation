using System;

using System.IO;
using ImageManipulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class PnmSerializeTest
    {
        [TestMethod]
        public void ParseTest()
        {
            //arrange
            String s = "P3\n#Comment\n2 1\n 255\n100\n50\n20\n10\n7\n4";
            PnmSerializer p = new PnmSerializer();
            //act
            Image i = p.Parse(s);
            //assert
            Assert.AreEqual(i[0, 0].Red, 100);
            Assert.AreEqual(i.Width, 2);
            Assert.AreEqual(i.Height, 1);
            Assert.AreEqual(i[0, 0].Green, 50);
            Assert.AreEqual(i[0, 0].Blue, 20);
            Assert.AreEqual(i[0, 1].Red, 10);
            Assert.AreEqual(i.Metadata, "#Comment");
        }
        [TestMethod]
        public void SerializeTest()
        {
            //arrange
            Pixel[,] pix = new Pixel[3, 2] { { new Pixel(14, 15, 16), new Pixel(98, 7, 4) }, { new Pixel(44, 78, 40), new Pixel(77, 88, 99) }, { new Pixel(6, 7, 8), new Pixel(84, 37, 47) } };
            Image i = new Image("#Hello", 230, pix);
            PnmSerializer p = new PnmSerializer();
            //act
            String s = p.Serialize(i);
            //assert
            Assert.AreEqual(s.Substring(s.IndexOf('1'), 9), "14\n15\n16\n"); //color
            Assert.AreEqual(s.Substring(s.IndexOf('3'), 1), "3"); //width
            Assert.AreEqual(s.Substring(s.IndexOf('2'), 1), "2"); //heigth
            Assert.AreEqual(s.Substring(s.IndexOf('#'), 6), "#Hello"); //metadata
            Assert.AreEqual(s, "P3\n#Hello\n2 3\n230\n14\n15\n16\n98\n7\n4\n44\n78\n40\n77\n88\n99\n6\n7\n8\n84\n37\n47\n"); //metadata
        }
    }
}
