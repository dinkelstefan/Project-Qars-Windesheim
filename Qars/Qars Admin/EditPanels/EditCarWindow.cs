using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Qars;

namespace Qars_Admin.EditPanels
{
    public partial class EditCarWindow : Form
    {
        private DBConnect connect;
        private Car car;
        private List<String> establishmentList;

        public EditCarWindow(Car car, List<Establishment> estList, DBConnect connect) {
            this.connect = connect;
            this.car = car;
            this.establishmentList = new List<String>();


            // fill up the namesource for the combobox
            foreach (Establishment est in estList) {
                this.establishmentList.Add(est.name);
            }

            InitializeComponent();
            try
            {
                // set the car ID
                this.CarIDBox.Text = this.car.carID.ToString();

                this.EsteblishmentComboBox.DataSource = this.establishmentList;
                // search for the esteblishment name and put it in the combobox
                foreach (Establishment est in estList) {
                    if (this.car.establishmentID == est.establishmentID) {
                        this.EsteblishmentComboBox.Text = est.name;
                        break;
                    }
                }

                //fill up more properties
                this.BrandBox.Text = car.brand.ToString();
                this.ModelBox.Text = car.model.ToString();
                this.CategoryBox.Text = car.category.ToString();
                this.ModelyearBox.Text = car.modelyear.ToString();
                this.AutomaticBox.Checked = car.automatic;
                this.KilometersBox.Text = car.kilometres.ToString();
                this.ColourBox.Text = car.colour.ToString();
                this.StereoBox.Checked = car.stereo;
                this.BluetoothBox.Checked = car.bluetooth;
                this.HorsePowerBox.Text = car.horsepower.ToString();
                this.WidthBox.Text = car.width.ToString();
                this.LengthBox.Text = car.length.ToString();
                this.HeightBox.Text = car.height.ToString();
                this.WeightBox.Text = car.weight.ToString();

                this.AvailableBox.Checked = car.available;

                this.NavigationBox.Checked = car.navigation;
                this.CruisecontrolBox.Checked = car.navigation;
                this.ParkingassistBox.Checked = car.parkingAssist;
                this.WheelDriveBox.Checked = car.fourwheeldrive;
                this.CabrioBox.Checked = car.cabrio;
                this.AircoBox.Checked = car.airco;
                this.MOTDate.Text = car.motdate.ToString();
                this.StorageBox.Text = car.storagespace.ToString();
                this.GearsBox.Text = car.gearsamount.ToString();
                this.FuelusageBox.Text = car.motor.ToString();
                this.StartpriceBox.Text = car.startprice.ToString();
                this.RentalpriceBox.Text = car.rentalprice.ToString();
                this.SellingpriceBox.Text = car.sellingprice.ToString();
                this.DoorsBox.Text = car.doors.ToString();
                this.SeatsBox.Text = car.seats.ToString();

                this.DesciptionBox.Text = car.description.ToString();


            }
            catch (Exception e)
            {
                MessageBox.Show("Fout tijdens het laden van de auto" + e);
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //try
            //{
                //Reservation res = new Reservation();
                //res.reservationID = this.reservation.reservationID;
                //res.startdate = CarIDBox.Text;
                ////res.enddate = endDateTextBox.Text;
                ////res.confirmed = confirmedCheckBox.Checked;
                //res.kilometres = Int32.Parse(BrandBox.Text);
                //res.pickupcity = ModelBox.Text;
                //res.pickupstreetname = ModelyearBox.Text;
                ////res.pickupstreetnumber = Int32.Parse(streetnumberTextBox.Text);
                //res.pickupstreetnumbersuffix = KilometersBox.Text;
                //res.paid = AvailableBox.Checked;
                //res.comment = DesciptionBox.Text;
                
                //this.connect.UpdateReservation(res);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Het format van de door u ingevulde tekst klopt niet.");
            //}

            

            this.Close();
        }
    }
}
