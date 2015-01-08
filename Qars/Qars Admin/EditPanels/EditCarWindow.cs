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
using System.Net;
using System.IO;
using FtpLib;

namespace Qars_Admin.EditPanels
{
    public partial class EditCarWindow : Form
    {
        private DBConnect connect;
        private Car car;
        private List<Establishment> establishmentList;
        private List<String> establishmentNameList;
        private bool add;

        public EditCarWindow(Car car, List<Establishment> estList, DBConnect connect, bool add)
        {
            this.connect = connect;
            this.car = car;
            this.establishmentList = estList;
            this.establishmentNameList = new List<String>();
            this.add = add;


            // fill up the namesource for the combobox
            foreach (Establishment est in this.establishmentList)
            {
                this.establishmentNameList.Add(est.name);
            }

            InitializeComponent();
            try
            {
                // set the car ID
                this.CarIDBox.Text = this.car.carID.ToString();

                this.EsteblishmentComboBox.DataSource = this.establishmentNameList;
                // search for the esteblishment name and put it in the combobox
                foreach (Establishment est in this.establishmentList)
                {
                    if (this.car.establishmentID == est.establishmentID)
                    {
                        this.EsteblishmentComboBox.Text = est.name;
                        break;
                    }
                }

                //fill up more properties
                if (!add)
                {
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
                    this.FuelusageBox.Text = car.fuelusage.ToString();
                    this.StartpriceBox.Text = car.startprice.ToString();
                    this.RentalpriceBox.Text = car.rentalprice.ToString();
                    this.SellingpriceBox.Text = car.sellingprice.ToString();
                    this.DoorsBox.Text = car.doors.ToString();
                    this.SeatsBox.Text = car.seats.ToString();

                    //Add pictures to ListBox
                    foreach (CarPhoto photo in car.PhotoList)
                    {
                        imageLinkList.Items.Add(photo.Name);
                    }

                    this.DesciptionBox.Text = car.description.ToString();
                }

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

        private void TextBoxAlphabeticalChars_KeyPress(object sender, KeyEventArgs e)
        {
            if ((e.KeyData >= Keys.A && e.KeyData <= Keys.Z) || e.KeyData == Keys.Back || e.KeyData == Keys.Delete || e.KeyData == Keys.OemMinus || e.KeyData == Keys.RShiftKey || e.KeyData == Keys.LShiftKey || e.KeyData == Keys.Shift || e.KeyData == Keys.ShiftKey)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
                MessageBox.Show("U mag hier geen getallen invullen.");
            }
        }

        private void TextBoxNumOnly_KeyPress(object sender, KeyEventArgs e)
        {
            if ((e.KeyData >= Keys.D0 && e.KeyData <= Keys.D9) || (e.KeyData >= Keys.NumPad0 && e.KeyData <= Keys.NumPad9) || e.KeyData == Keys.OemPeriod || e.KeyData == Keys.OemMinus || e.KeyData == Keys.Back || e.KeyData == Keys.Delete)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
                MessageBox.Show("U mag hier geen letters invullen.");
            }
        }

        private void TextBoxFloatOnly_KeyPress(object sender, KeyEventArgs e)
        {
            if ((e.KeyData >= Keys.D0 && e.KeyData <= Keys.D9) || (e.KeyData >= Keys.NumPad0 && e.KeyData <= Keys.NumPad9) || e.KeyData == Keys.OemMinus || e.KeyData == Keys.Back || e.KeyData == Keys.Delete)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
                MessageBox.Show("U mag hier geen letters invullen.");
            }
        }

        private void checkFormat_Leave(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            StringBuilder sb = new StringBuilder(textbox.Text);
            sb.Replace("-", string.Empty);
            try
            {
                sb.Insert(2, "-");
                sb.Insert(5, "-");
            }
            catch (Exception)
            {

            }
            textbox.Text = sb.ToString();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Car car = this.getCarFromFields();
                if (!add)
                {
                    this.connect.UpdateCar(car);
                    this.Close();
                }
                else
                {
                    connect.InsertCar(car);
                    this.Close();
                }

                List<string> files = this.readFilesFromFTP(car);
                this.uploadCarPhoto(car, files);

                MessageBox.Show("De auto en de bijbehorende foto's zijn bijgewerkt.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Het format van de door u ingevulde tekst klopt niet." + ex);
            }
        }

        private void delete_Button_Click(object sender, EventArgs e)
        {
            try
            {
                Car car = this.getCarFromFields();

                this.connect.DeleteCar(car);
                MessageBox.Show(string.Format("De reserving met reserveringnummer: {0} is verwijderd.", car.carID));
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Het is niet gelukt om de auto te verwijderen, probeer het later opnieuw.");
            }
        }

        private Car getCarFromFields()
        {
            Car newCar = new Car();

            newCar.carID = this.car.carID;


            // search for the esteblishment if from combobox
            foreach (Establishment est in this.establishmentList)
            {
                if (EsteblishmentComboBox.Text == est.name)
                {
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
            newCar.fuelusage = Int32.Parse(this.FuelusageBox.Text);
            newCar.startprice = Int32.Parse(this.StartpriceBox.Text);
            newCar.rentalprice = Double.Parse(this.RentalpriceBox.Text);
            newCar.sellingprice = Double.Parse(this.SellingpriceBox.Text);
            newCar.doors = Int32.Parse(this.DoorsBox.Text);
            newCar.seats = Int32.Parse(this.DoorsBox.Text);

            newCar.description = this.DesciptionBox.Text;
            newCar.PhotoList = car.PhotoList;



            return newCar;
        }

        private void imageLinkList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarPhotoPictureBox.ImageLocation = car.PhotoList[imageLinkList.SelectedIndex].Photolink;
        }

        private void add_Button_Click(object sender, EventArgs e)
        {
            int highestCarID = connect.getHighestPhotoID();
            if (highestCarID != -1)
            {
                AddCarPhoto addphoto = new AddCarPhoto(car.carID, highestCarID, this);
                addphoto.ShowDialog();
            }
        }

        public void addCarPhoto(CarPhoto carPhoto)
        {
            car.PhotoList.Add(carPhoto);
            //Refresh list with photos
            imageLinkList.Items.Add(carPhoto.Name);
        }
        private void uploadCarPhoto(Car car, List<string> files)
        {
            string ftpServerIP = "ftp.pqrojectqars.herobo.com";
            string ftpUserID = "a8158354";
            string ftpPassword = "Quintor1";
            int i = 0;
            foreach (CarPhoto photo in car.PhotoList)
            {
                bool exists = false;
                foreach (string file in files)
                {
                    string file1 = photo.PhotoID + ".jpg";
                    string file2 = photo.PhotoID + ".png";
                    if (file1 == file || file2 == file)
                    {
                        exists = true;
                    }
                }
                
                Console.WriteLine(exists.ToString());
                if (!exists)
                {
                    Console.WriteLine(photo.Name);

                    string localphotolink = photo.Photolink;
                    bool JPG = true;
                    bool error = false;
                    //string localphotolink = photo.Photolink; //local file

                    FileInfo fi = new FileInfo(localphotolink);
                    long fileSize = fi.Length; //The size of the current file in bytes.file
                    if (fileSize > 2621440)
                    {
                        localphotolink = "";
                        MessageBox.Show("Uw gekozen foto is te groot");
                        break;
                    }
                    else
                    {
                        string extension = fi.Extension;
                        if (extension == ".jpg")
                        {
                            JPG = true;
                        }
                        else if (extension == ".png")
                        {
                            JPG = false;
                        }
                        else
                        {
                            error = true;
                        }
                        if (error == false)
                        {
                            try
                            {
                                string filename = "ftp://" + ftpServerIP + "/public_html/Images/" + car.brand + "/" + car.model + "/" + car.colour + "/" + photo.PhotoID + extension;
                                FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create(filename);
                                ftpReq.UseBinary = true;
                                ftpReq.Method = WebRequestMethods.Ftp.UploadFile;
                                ftpReq.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                                byte[] b = File.ReadAllBytes(localphotolink);

                                ftpReq.ContentLength = b.Length;
                                using (Stream s = ftpReq.GetRequestStream())
                                {
                                    s.Write(b, 0, b.Length);
                                }

                                FtpWebResponse ftpResp = (FtpWebResponse)ftpReq.GetResponse();
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show("Fout!" + e);
                            }
                        }
                    }
                }
            }
        }
        private List<string> readFilesFromFTP(Car car)
        {
            List<string> files = new List<string>();
            string ftpServerIP = "ftp.pqrojectqars.herobo.com";
            string ftpUserID = "a8158354";
            string ftpPassword = "Quintor1";
            FtpLib.FtpConnection ftp = new FtpLib.FtpConnection(ftpServerIP, ftpUserID, ftpPassword);
            ftp.Open();
            ftp.Login();

            string directory = string.Format("/public_html/Images/{0}/{1}/{2}/", car.brand, car.model, car.colour);
            if (ftp.DirectoryExists(directory))
            {
                ftp.SetCurrentDirectory(directory);
                foreach (var dir in ftp.GetDirectories(directory))
                {
                    Console.WriteLine(dir.Name);
                    foreach (var file in dir.GetFiles())
                    {
                        files.Add(file.Name);
                        Console.WriteLine(file.Name);
                        Console.WriteLine(file.LastAccessTime);
                    }
                }
            }
            else
            {
                string newDirectory = "public_html/Images/";

                //Check if brand directory exists, else create one
                if (!ftp.DirectoryExists(newDirectory + car.brand))
                {
                    newDirectory += car.brand;
                    ftp.CreateDirectory(newDirectory);
                    newDirectory += "/";
                }
                else
                {
                    newDirectory += car.brand + "/";
                }

                //Check if model directory exists, else create one
                if (!ftp.DirectoryExists(newDirectory + car.model))
                {
                    newDirectory += car.model;
                    ftp.CreateDirectory(newDirectory);
                    newDirectory += "/";
                }
                else
                {
                    newDirectory += car.model + "/";
                }

                //Check if colour directory exists, else create one
                if (!ftp.DirectoryExists(newDirectory + car.colour))
                {
                    newDirectory += car.colour;
                    ftp.CreateDirectory(newDirectory);
                    newDirectory += "/";
                }

            }
            return files;
        }
    }
}



