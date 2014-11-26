using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Tests_Qars
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int result = 5 + 5;
            Assert.IsTrue(result == 10);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string naam = "";
            naam = "Kat";
            Assert.IsTrue(naam == "Kat");
        }
    }
}
