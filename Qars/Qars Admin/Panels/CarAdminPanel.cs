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

namespace Qars_Admin {
    public partial class CarAdminPanel : UserControl {

        DBConnect databaseConnection;

        public CarAdminPanel(DBConnect dbConnect) {
            InitializeComponent();
            this.databaseConnection = dbConnect;

            this.RefreshList();
        }

        public void RefreshList() {
            List<Establishment> estList = databaseConnection.SelectEstablishment();
            List<Car> carList = databaseConnection.SelectCar();
            List<SimpleCar> simpleCarList = new List<SimpleCar>();


            SimpleCar simpleCar;
            foreach (Car car in carList) {
                string establishment = "";

                foreach (Establishment est in estList) {
                    if (car.establishmentID == est.establishmentID) {
                        establishment = est.name;
                        break;
                    }
                }

                simpleCar = new SimpleCar(car.carID, establishment, car.brand, car.model, car.modelyear, car.colour, car.kilometres);
                simpleCarList.Add(simpleCar);
            }

            this.CarDataGrid.DataSource = simpleCarList;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {

            SimpleCar selectedCar = (SimpleCar)this.CarDataGrid.CurrentRow.DataBoundItem;

            Console.WriteLine(selectedCar.Kilometers);
        }
    }
}
