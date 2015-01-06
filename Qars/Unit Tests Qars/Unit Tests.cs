using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qars;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;     //nieuw toegevoegd
using System.Threading.Tasks;


namespace Unit_Tests_Qars
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DataBaseCarList()
        {
            DBConnect db = new DBConnect();
            List<Car> carList = db.SelectCar();
            Assert.IsNotNull(carList);
        }

        [TestMethod]
        public void DataBaseReservationList()
        {
            DBConnect db = new DBConnect();
            List<Reservation> reservationList = db.SelectReservation();
            Assert.IsNotNull(reservationList);
        }
        [TestMethod]
        public void DataBaseUsersList()
        {
            DBConnect db = new DBConnect();
            List<User> usersList = db.SelectUsers();
            Assert.IsNotNull(usersList);
        }
        [TestMethod]
        public void DataBaseDamageList()
        {
            DBConnect db = new DBConnect();
            List<Damage> damageList = db.SelectDamage();
            Assert.IsNotNull(damageList);
        }
        [TestMethod]
        public void DataBaseEstablishmentList()
        {
            DBConnect db = new DBConnect();
            List<Establishment> EstablishmentList = db.SelectEstablishment();
            Assert.IsNotNull(EstablishmentList);
        }
        [TestMethod]
        public void ValidateEmail()
        {
            RentCarPanel panel = new RentCarPanel(0, 7, new VisualDemo());
            Assert.IsTrue(panel.IsValidEmail("sander.ten.brinke@xs4all.nl"));
        }


    }
}
