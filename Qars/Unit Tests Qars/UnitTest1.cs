using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qars;
using Qars.Views;
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
            List<Car> Autolijst = db.SelectCar();
            Assert.IsNotNull(Autolijst);

        }

        [TestMethod]
        public void TestMethod2()
        {
            string naam = "";
            naam = "Kat";
            Assert.IsTrue(naam == "Kat");
        }

        [TestMethod]
        public void TestMethod3()
        {
            //VisualDemo demo = new VisualDemo();
            //searchWizard wizard = new searchWizard(demo);
            //List<Car> carList = new List<Car>();
            //Car car1 = new Car();
            //car1.establishmentID = 1;
            //Car car2 = new Car();
            //car2.establishmentID = 3;
            //Car car3 = new Car();
            //car3.establishmentID = 1;

            //List<Car> sortList = wizard.filterLocation(carList);
            //Assert
        }
    }
}
