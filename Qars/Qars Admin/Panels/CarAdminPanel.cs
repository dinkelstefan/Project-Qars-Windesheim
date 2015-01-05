using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Qars;
using Qars_Admin.EditPanels;

namespace Qars_Admin {
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

        public void RefreshList() {
            this.establishmentList = databaseConnection.SelectEstablishment();
            this.carList = databaseConnection.SelectCar();
            this.simpleCarList = new List<SimpleCar>();


            SimpleCar simpleCar;
            foreach (Car car in carList) {
                string establishment = "";

                foreach (Establishment est in this.establishmentList) {
                    if (car.establishmentID == est.establishmentID) {
                        establishment = est.name;
                        break;
                    }
                }

                simpleCar = new SimpleCar(car.carID, establishment, car.brand, car.model, car.modelyear, car.colour, car.kilometres);
                simpleCarList.Add(simpleCar);
            }

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
            EditCarWindow window = new EditCarWindow(selectedCar, this.establishmentList, databaseConnection);
            window.ShowDialog();

            this.RefreshList();
            dataGridView1.Rows[rowIndex].Selected = true;
        }
    }
}
