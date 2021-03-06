﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Qars;
using Qars_Admin.Models.SimpleClasses;
using Qars.Models;
using Qars.Models.DBObjects;

namespace Qars_Admin.Views
{
    public partial class ForecastAdminPanel : UserControl
    {
        private DBConnect databaseConnection;
        public ForecastAdminPanel(DBConnect connection)
        {
            this.databaseConnection = connection;
            InitializeComponent();

            this.refreshList();
        }

        public void refreshList()
        {
            List<simpleForecast> simpleForecastList = new List<simpleForecast>();

            List<Reservation> resList = this.databaseConnection.SelectReservation();
            List<Car> carList = this.databaseConnection.SelectCar();
            List<User> userList = this.databaseConnection.SelectUsers();


            foreach (Reservation res in resList)
            {
                try
                {
                    DateTime pickUpTime = Convert.ToDateTime(res.startdate);
                    if (pickUpTime == DateTime.Today)
                    {
                        simpleForecastList.Add(new simpleForecast(res.reservationID, res.carID, userList[res.UserID].firstname, userList[res.UserID].lastname, carList[res.carID].brand, carList[res.carID].model, res.paid, res.confirmed));
                    }
                }
                catch (Exception)
                {

                }
            }
            this.ForecastDataGridView.DataSource = simpleForecastList;
        }

        private void update_Button_Click(object sender, EventArgs e)
        {
            this.refreshList();
        }
    }
}
