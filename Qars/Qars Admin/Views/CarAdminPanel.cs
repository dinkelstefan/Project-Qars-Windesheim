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
using Qars_Admin.Views.EditPanels;
using Qars.Models;
using Qars.Models.DBObjects;
using Qars_Admin.Models.SimpleClasses;

namespace Qars_Admin.Views {
    public partial class CarAdminPanel : UserControl {

        private DBConnect databaseConnection;
        private List<Establishment> establishmentList;
        private List<Car> carList;
        private List<SimpleCar> simpleCarList;

        public CarAdminPanel(DBConnect dbConnect) {
            InitializeComponent();
            this.databaseConnection = dbConnect;

            this.RefreshList();
        }

        // refresh the contents of the car list
        public void RefreshList() {
            // get a list of establishments and cars
            this.establishmentList = databaseConnection.SelectEstablishment();
            this.carList = databaseConnection.SelectCar();

            // generate a simple cars with fewer properties to show on the list
            this.simpleCarList = new List<SimpleCar>();
            SimpleCar simpleCar;
            foreach (Car car in carList) {

                // search for a name of the establishment to display instead of an establishment ID
                string establishment = "";
                foreach (Establishment est in this.establishmentList) {
                    if (car.establishmentID == est.establishmentID) {
                        establishment = est.name;
                        break;
                    }
                }

                //add a few properties of the car class to the simple car
                simpleCar = new SimpleCar(car.carID, establishment, car.brand, car.model, car.modelyear, car.colour, car.kilometres);
                simpleCarList.Add(simpleCar);
            }

            // add the simple car list as a datasource
            this.dataGridView1.DataSource = simpleCarList;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
            List<SimpleCar> carList = this.dataGridView1.DataSource as List<SimpleCar>;
            int simpleCarID = carList[rowIndex].AutoID;

            var query = from car in this.carList
                        where car.carID == simpleCarID
                        select car;

            Car selectedCar = query.First();

            //Open window for editing of the reservation
            EditCarWindow window = new EditCarWindow(selectedCar, this.establishmentList, databaseConnection, false);
            window.ShowDialog();

            this.RefreshList();
            dataGridView1.Rows[rowIndex].Selected = true;
        }

        private void addCar_Button_Click(object sender, EventArgs e)
        {
            List<Establishment> estList = databaseConnection.SelectEstablishment();
            Car car = new Car();
            EditCarWindow carWindow = new EditCarWindow(car, estList, databaseConnection, true);
            carWindow.ShowDialog();
            this.RefreshList();
        }
    }
}
