using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qars;
using System.Collections.Generic;

namespace Unit_Tests_Qars
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DataBaseCarList()
        {
            DBConnect db = new DBConnect();
            List<Car> Autolijst = db.FillCars();
            Assert.IsNotNull(Autolijst);

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
