using PenDB;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_Constructor()
        {
            Pen f1 = new Pen("Anton", "Samaev", "89963112857", "anton@mail.ru");
            Assert.AreEqual("Anton", f1.name_get());
            Assert.AreEqual("Samaev", f1.surname_get());
            Assert.AreEqual("89963112857", f1.phone_get());
            Assert.AreEqual("anton@mail.ru", f1.email_get());

            Contact f2 = new Contact("Ivan", "Ivanov", "123456789", "ivanov@mail.ru");
            Assert.AreEqual("Ivan", f2.name_get());
            Assert.AreEqual("Ivanov", f2.surname_get());
            Assert.AreEqual("123456789", f2.phone_get());
            Assert.AreEqual("ivanov@mail.ru", f2.email_get());

            Contact f3 = new Contact("Sasha", "Petrov", "0987654321", "sasha@mail.ru");
            Assert.AreEqual("Sasha", f3.name_get());
            Assert.AreEqual("Petrov", f3.surname_get());
            Assert.AreEqual("0987654321", f3.phone_get());
            Assert.AreEqual("sasha@mail.ru", f3.email_get());
        }
    }
}
