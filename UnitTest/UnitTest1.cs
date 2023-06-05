using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;



using PenDB;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_1()
        {
            Pen p1 = new Pen("Berligo", "Черный", 0.8, "Да", 45);
            Assert.AreEqual("Berligo", p1.Brend);
            Assert.AreEqual("Черный", p1.Color); 
            Assert.AreEqual(0.8, p1.Thickness);
            Assert.AreEqual("Да", p1.Automatic);
            Assert.AreEqual(45, p1.Price);
            Assert.AreEqual("Berligo|Черный|0,8|Да|45", p1.ToString());

            Pen p2 = new Pen("Pilot", "Красный", 1, "Нет", 38);
            Assert.AreEqual("Pilot", p2.Brend);
            Assert.AreEqual("Красный", p2.Color);
            Assert.AreEqual(1, p2.Thickness);
            Assert.AreEqual("Нет", p2.Automatic);
            Assert.AreEqual(38, p2.Price);
            Assert.AreEqual("Pilot|Красный|1|Нет|38", p2.ToString());

            Pen p3 = new Pen("Bic", "Синий", 0.5, "Нет", 26);
            Assert.AreEqual("Bic", p3.Brend);
            Assert.AreEqual("Синий", p3.Color);
            Assert.AreEqual(0.5, p3.Thickness);
            Assert.AreEqual("Нет", p3.Automatic);
            Assert.AreEqual(26, p3.Price);
            Assert.AreEqual("Bic|Синий|0,5|Нет|26", p3.ToString());
        }
    }
}
