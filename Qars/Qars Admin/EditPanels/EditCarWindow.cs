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
        private List<Establishment> establishmentList;
        private List<String> establishmentNameList;

        public EditCarWindow(Car car, List<Establishment> estList, DBConnect connect) {
            this.connect = connect;
            this.car = car;
            this.establishmentList = estList;
            this.establishmentNameList = new List<String>();


            // fill up the namesource for the combobox
            foreach (Establishment est in this.establishmentList) {
                this.establishmentNameList.Add(est.name);
            }

            InitializeComponent();
            try
            {
                // set the car ID
                this.CarIDBox.Text = this.car.carID.ToString();

                this.EsteblishmentComboBox.DataSource = this.establishmentNameList;
                // search for the esteblishment name and put it in the combobox
                foreach (Establishment est in this.establishmentList) {
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
                this.CruisecontrolBox.Checked = car.cruisecontrol;
                this.ParkingassistBox.Checked = car.parkingAssist;
                this.WheelDriveBox.Checked = car.fourwheeldrive;
                this.CabrioBox.Checked = car.cabrio;
                this.AircoBox.Checked = car.airco;
                this.MOTDate.Text = car.motdate.ToString();
                this.StorageBox.Text = car.storagespace.ToString();
                this.GearsBox.Text = car.gearsamount.ToString();
                this.MotorBox.Text = car.motor.ToString();
                this.FuelusageBox.Text = car.Fuelusage.ToString();
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

        private void TextBoxAlphabeticalChars_KeyPress(object sender, KeyEventArgs e) {
            if ((e.KeyData >= Keys.A && e.KeyData <= Keys.Z) || e.KeyData == Keys.Back || e.KeyData == Keys.Delete || e.KeyData == Keys.OemMinus) {
                e.Handled = true;
            } else {
                e.Handled = false;
                MessageBox.Show("U mag hier geen getallen invullen.");
            }
        }

        private void TextBoxNumOnly_KeyPress(object sender, KeyEventArgs e) {
            if ((e.KeyData >= Keys.D0 && e.KeyData <= Keys.D9) || (e.KeyData >= Keys.NumPad0 && e.KeyData <= Keys.NumPad9) || e.KeyData == Keys.OemPeriod || e.KeyData == Keys.OemMinus || e.KeyData == Keys.Back || e.KeyData == Keys.Delete) {
                e.Handled = true;
            } else {
                e.Handled = false;
                MessageBox.Show("U mag hier geen letters invullen.");
            }
        }

        private void TextBoxFloatOnly_KeyPress(object sender, KeyEventArgs e) {
            if ((e.KeyData >= Keys.D0 && e.KeyData <= Keys.D9) || (e.KeyData >= Keys.NumPad0 && e.KeyData <= Keys.NumPad9) || e.KeyData == Keys.OemMinus || e.KeyData == Keys.Back || e.KeyData == Keys.Delete) {
                e.Handled = true;
            } else {
                e.Handled = false;
                MessageBox.Show("U mag hier geen letters invullen.");
            }
        }

        private void checkFormat_Leave(object sender, EventArgs e) {
            TextBox textbox = sender as TextBox;
            StringBuilder sb = new StringBuilder(textbox.Text);
            sb.Replace("-", string.Empty);
            try {
                sb.Insert(2, "-");
                sb.Insert(5, "-");
            } catch (Exception ex) {

            }
            textbox.Text = sb.ToString();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Car carToUpdate = this.getCarFromFields();
                this.connect.UpdateCar(carToUpdate);
                this.Close();
            } catch (Exception ex) {
                MessageBox.Show("Het format van de door u ingevulde tekst klopt niet.");
            }
        }

        private void delete_Button_Click(object sender, EventArgs e) {
            try {
                Car car = this.getCarFromFields();

                this.connect.DeleteCar(car);
                MessageBox.Show(string.Format("De reserving met reserveringnummer: {0} is verwijderd.", car.carID));
                this.Close();
            } catch (Exception ex) {
                MessageBox.Show("Het format van de door u ingevulde tekst klopt niet.");
            }
        }

        private Car getCarFromFields() {
            Car newCar = new Car();

            newCar.carID = this.car.carID;
            
        
            // search for the esteblishment if from combobox
            foreach (Establishment est in this.establishmentList) {
                if (EsteblishmentComboBox.Text == est.name) {
                    newCar.establishmentID = est.establishmentID;
                    break;
                }
            }
            
            newCar.brand = this.BrandBox.Text;
            newCar.model = this.ModelBox.Text;
            newCar.category = this.CategoryBox.Text;
            newCar.modelyear = Int32.Parse(this.ModelyearBox.Text);
            newCar.automatic = this.AutomaticBox.Checked;
            newCar.kilometres = Int32.Parse(this.KilometersBox.Text);
            newCar.colour = this.ColourBox.Text;
            newCar.stereo = this.StereoBox.Checked;
            newCar.bluetooth = this.BluetoothBox.Checked;
            newCar.horsepower = Double.Parse(this.HorsePowerBox.Text);
            newCar.width = Int32.Parse(this.WidthBox.Text);
            newCar.length = Int32.Parse(this.LengthBox.Text);
            newCar.height = Int32.Parse(this.HeightBox.Text);
            newCar.weight = Int32.Parse(this.WeightBox.Text);

            newCar.available = this.AvailableBox.Checked;
            
            newCar.navigation = this.NavigationBox.Checked;
            newCar.cruisecontrol = this.CruisecontrolBox.Checked;
            newCar.parkingAssist = this.ParkingassistBox.Checked;
            newCar.fourwheeldrive = this.WheelDriveBox.Checked;
            newCar.cabrio = this.CabrioBox.Checked;
            newCar.airco = this.AircoBox.Checked;
            newCar.motdate = this.MOTDate.Text;
            newCar.storagespace = Double.Parse(this.StorageBox.Text);
            newCar.gearsamount = Int32.Parse(this.StorageBox.Text);
            newCar.motor = this.MotorBox.Text;
            newCar.Fuelusage = Int32.Parse(this.FuelusageBox.Text);
            newCar.startprice = Int32.Parse(this.StartpriceBox.Text);
            newCar.rentalprice = Double.Parse(this.RentalpriceBox.Text);
            newCar.sellingprice = Double.Parse(this.SellingpriceBox.Text);
            newCar.doors = Int32.Parse(this.DoorsBox.Text);
            newCar.seats = Int32.Parse(this.DoorsBox.Text);

            newCar.description = this.DesciptionBox.Text;

            return newCar;
        }
    }
}
