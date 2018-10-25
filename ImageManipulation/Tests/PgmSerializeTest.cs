using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageManipulation;

namespace Tests
{
    [TestClass]
    public class PgmSerializeTest
    {
        [TestMethod]
        public void ParseTest()
        {
            //arrange
            String s = "P2\n#Comment\n2 1\n 255\n 100 \n  10";
            PgmSerializer p = new PgmSerializer();
            //act
            Image i = p.Parse(s);
            //assert
            Assert.AreEqual(i[0,0].Red, 100);
            Assert.AreEqual(i.Width, 2);
            Assert.AreEqual(i.Height, 1);
            Assert.AreEqual(i[0,0].Green, 100);
            Assert.AreEqual(i[0,0].Blue, 100);
            Assert.AreEqual(i[0,1].Red, 10);
            Assert.AreEqual(i.Metadata, "#Comment");
        }
        [TestMethod]
        public void SerializeTest()
        {
            //arrange
            Pixel[,] pix = new Pixel[3, 2] { { new Pixel(14), new Pixel(8) }, { new Pixel(9), new Pixel(36) }, { new Pixel(70), new Pixel(74) } };
            Image i = new Image("#Hello", 230, pix);

            PgmSerializer p = new PgmSerializer();
            //act
            String s = p.Serialize(i);
            //assert
            Assert.AreEqual(s.Substring(s.IndexOf('1'), 2), "14"); //color
            Assert.AreEqual(s.Substring(s.IndexOf('3'), 1), "3"); //width
            Assert.AreEqual(s.Substring(s.IndexOf('2'), 1), "2"); //heigth
            Assert.AreEqual(s.Substring(s.IndexOf('#'), 6), "#Hello"); //metadata
            Assert.AreEqual(s, "P2\n#Hello\n2 3\n230\n14\n8\n9\n36\n70\n74\n");
        }
    }
}
