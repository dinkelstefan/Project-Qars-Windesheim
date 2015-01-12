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
using FtpLib;
using System.Net;
using System.IO;
using Qars.Models;
using Qars.Models.DBObjects;
using System.Text.RegularExpressions;

namespace Qars_Admin.Views.EditPanels
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

                this.EstablishmentComboBox.DataSource = this.establishmentNameList;
                // search for the establishment name and put it in the combobox
                foreach (Establishment est in this.establishmentList)
                {
                    if (this.car.establishmentID == est.establishmentID)
                    {
                        this.EstablishmentComboBox.Text = est.name;
                        break;
                    }
                }

                //fill up more properties
                if (!add)
                {
                    this.BrandBox.Text = car.brand.ToString();
                    this.ModelBox.Text = car.model.ToString();
                    this.CategoryBox.Text = car.category.ToString();
                    this.AvailableBox.Checked = car.available;
                    this.licensePlateTextBox.Text = car.LicensePlate;
                    this.NavigationBox.Checked = car.navigation;
                    this.CruisecontrolBox.Checked = car.cruisecontrol;
                    this.ParkingassistBox.Checked = car.parkingAssist;
                    this.WheelDriveBox.Checked = car.fourwheeldrive;
                    this.CabrioBox.Checked = car.cabrio;
                    this.AircoBox.Checked = car.airco;
                    this.MOTDate.Text = car.motdate.ToString();
                    this.ColourBox.Text = car.colour.ToString();
                    this.StereoBox.Checked = car.stereo;
                    this.BluetoothBox.Checked = car.bluetooth;
                    this.AutomaticBox.Checked = car.automatic;
                    this.MotorBox.Text = car.motor.ToString();
                    this.StartpriceBox.Text = car.startprice.ToString();


                    if (car.modelyear.ToString() == "-1")
                        this.ModelyearBox.Text = "";
                    else
                        this.ModelyearBox.Text = car.modelyear.ToString();
                    if (car.kilometres.ToString() == "-1")
                        this.KilometersBox.Text = "";
                    else
                        this.KilometersBox.Text = car.kilometres.ToString();
                    if (car.horsepower.ToString() == "-1")
                        this.HorsePowerBox.Text = "";
                    else
                        this.HorsePowerBox.Text = car.horsepower.ToString();
                    if (car.width.ToString() == "-1")
                        this.WidthBox.Text = "";
                    else
                        this.WidthBox.Text = car.width.ToString();
                    if (car.length.ToString() == "-1")
                        this.LengthBox.Text = "";
                    else
                        this.LengthBox.Text = car.length.ToString();
                    if (car.height.ToString() == "-1")
                        this.HeightBox.Text = "";
                    else
                        this.HeightBox.Text = car.height.ToString();
                    if (car.weight.ToString() == "-1")
                        this.WeightBox.Text = "";
                    else
                        this.WeightBox.Text = car.weight.ToString();
                    if (car.storagespace.ToString() == "-1")
                        this.StorageBox.Text = "";
                    else
                        this.StorageBox.Text = car.storagespace.ToString();
                    if (car.gearsamount.ToString() == "-1")
                        this.GearsBox.Text = "";
                    else
                        this.GearsBox.Text = car.gearsamount.ToString();
                    if (car.fuelusage.ToString() == "-1")
                        this.FuelusageBox.Text = "";
                    else
                        this.FuelusageBox.Text = car.fuelusage.ToString();
                    if (car.rentalprice.ToString() == "-1")
                        this.RentalpriceBox.Text = "";
                    else
                        this.RentalpriceBox.Text = car.rentalprice.ToString();
                    if (car.sellingprice.ToString() == "-1")
                        this.SellingpriceBox.Text = "";
                    else
                        this.SellingpriceBox.Text = car.sellingprice.ToString();
                    if (car.doors.ToString() == "-1")
                        DoorsBox.Text = "";
                    else
                        this.DoorsBox.Text = car.doors.ToString();
                    if (car.seats.ToString() == "-1")
                        this.SeatsBox.Text = "";
                    else
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
            if ((e.KeyData >= Keys.A && e.KeyData <= Keys.Z) || e.KeyData == Keys.OemPeriod || e.KeyData == Keys.Back || e.KeyData == Keys.Delete || e.KeyData == Keys.OemMinus || Keys.Shift == Control.ModifierKeys || e.KeyData == Keys.CapsLock)
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
            if ((e.KeyData >= Keys.D0 && e.KeyData <= Keys.D9) || (e.KeyData >= Keys.NumPad0 && e.KeyData <= Keys.NumPad9) || e.KeyData == Keys.OemMinus || e.KeyData == Keys.Back || e.KeyData == Keys.OemPeriod || e.KeyData == Keys.Delete)
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
            bool result = validateInput();
            if (result)
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
                    this.uploadCarPhoto(ref car, files);

                    MessageBox.Show("De auto en de bijbehorende foto's zijn bijgewerkt.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Het format van de door u ingevulde tekst klopt niet." + ex);
                }
            }
            else
            {
                MessageBox.Show("Sommige velden zijn niet goed ingevuld! Controleer de gegevens in het rood.");
            }
        }

        private void delete_Button_Click(object sender, EventArgs e)
        {
            try
            {
                Car car = this.getCarFromFields();

                this.connect.DeleteCar(car);
                foreach (CarPhoto photo in car.PhotoList)
                {
                    string file = photo.Photolink;

                    string fileExtension = "." + file.Split('.').Last();
                    this.removeFileFromFTP(car, photo, fileExtension);
                }

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
                if (EstablishmentComboBox.Text == est.name)
                {
                    newCar.establishmentID = est.establishmentID;
                    break;
                }
            }
            if (ModelyearBox.Text == "")
                newCar.modelyear = -1;
            else
                newCar.modelyear = Int32.Parse(this.ModelyearBox.Text);
            if (GearsBox.Text == "")
                newCar.gearsamount = -1;
            else
                newCar.gearsamount = Int32.Parse(this.GearsBox.Text);
            if (HorsePowerBox.Text == "")
                newCar.horsepower = -1;
            else
                newCar.horsepower = newCar.horsepower = Double.Parse(this.HorsePowerBox.Text);
            if (FuelusageBox.Text == "")
                newCar.fuelusage = -1;
            else
                newCar.fuelusage = Int32.Parse(this.FuelusageBox.Text);
            if (KilometersBox.Text == "")
                newCar.kilometres = -1;
            else
                newCar.kilometres = Int32.Parse(this.KilometersBox.Text);
            if (LengthBox.Text == "")
                newCar.length = -1;
            else
                newCar.length = newCar.length = Int32.Parse(this.LengthBox.Text);
            if (WidthBox.Text == "")
                newCar.width = -1;
            else
                newCar.width = Int32.Parse(this.WidthBox.Text);
            if (HeightBox.Text == "")
                newCar.height = -1;
            else
                newCar.height = Int32.Parse(this.HeightBox.Text);
            if (WeightBox.Text == "")
                newCar.weight = -1;
            else
                newCar.weight = newCar.weight = Int32.Parse(this.WeightBox.Text);
            if (DoorsBox.Text == "")
                newCar.doors = -1;
            else
                newCar.doors = Int32.Parse(this.DoorsBox.Text);
            if (SeatsBox.Text == "")
                newCar.seats = -1;
            else
                newCar.seats = Int32.Parse(this.DoorsBox.Text);
            if (StorageBox.Text == "")
                newCar.storagespace = -1;
            else
                newCar.storagespace = newCar.storagespace = Double.Parse(this.StorageBox.Text);
            if (SellingpriceBox.Text == "")
                newCar.sellingprice = -1;
            else
                newCar.sellingprice = newCar.sellingprice = Double.Parse(this.SellingpriceBox.Text);
            if (RentalpriceBox.Text == "")
                newCar.rentalprice = -1;
            else
                newCar.rentalprice = Double.Parse(this.RentalpriceBox.Text);

            newCar.brand = this.UppercaseFirst(this.BrandBox.Text);
            newCar.model = this.UppercaseFirst(this.ModelBox.Text);
            newCar.category = this.CategoryBox.Text;
            newCar.automatic = this.AutomaticBox.Checked;
            newCar.colour = this.UppercaseFirst(this.ColourBox.Text);
            newCar.stereo = this.StereoBox.Checked;
            newCar.bluetooth = this.BluetoothBox.Checked;
            newCar.available = this.AvailableBox.Checked;
            newCar.LicensePlate = this.licensePlateTextBox.Text;
            newCar.navigation = this.NavigationBox.Checked;
            newCar.cruisecontrol = this.CruisecontrolBox.Checked;
            newCar.parkingAssist = this.ParkingassistBox.Checked;
            newCar.fourwheeldrive = this.WheelDriveBox.Checked;
            newCar.cabrio = this.CabrioBox.Checked;
            newCar.airco = this.AircoBox.Checked;
            newCar.motdate = this.MOTDate.Text;
            newCar.motor = this.MotorBox.Text;
            newCar.startprice = Int32.Parse(this.StartpriceBox.Text);
            newCar.description = this.DesciptionBox.Text;
            newCar.PhotoList = car.PhotoList;





            return newCar;
        }

        private void imageLinkList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (imageLinkList.SelectedIndex < imageLinkList.Items.Count && imageLinkList.SelectedIndex != -1)
            {
                CarPhotoPictureBox.ImageLocation = car.PhotoList[imageLinkList.SelectedIndex].Photolink;
            }
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
        private bool validateInput()
        {
            try
            {
                int validInputCounter = 0;
                List<Regex> RegexList = new List<Regex>();
                List<string> InputList = new List<string>();
                List<Label> LabelList = new List<Label>();
                Car newCar = new Car();


                Regex BrandRegex = new Regex("^[a-zA-Zs0-9àáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ]{1,45}$");
                Regex ModelRegex = new Regex("^[a-zA-ZS0-9àáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ]{1,100}$");
                Regex CategoryRegex = new Regex("^[0-9a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ]{1,100}$");
                Regex ModelyearRegex = new Regex("^(\\s*|[0-9-\\\\/]{0,15})$");
                Regex KilometresRegex = new Regex("^(\\s*|[0-9]{0,100})$");
                Regex ColourRegex = new Regex("^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ]{1,100}$");
                Regex HorsePowerRegex = new Regex("^(\\s*|[0-9.,]{0,100})$");
                Regex LengthRegex = new Regex("^(\\s*|[0-9]{0,100})$");
                Regex WidthRegex = new Regex("^(\\s*|[0-9]{0,100})$");
                Regex HeightRegex = new Regex("^(\\s*|[0-9]{0,100})$");
                Regex WeightRegex = new Regex("^(\\s*|[0-9]{0,100})$");
                Regex MOTDateRegex = new Regex("^(\\s*|[0-9-\\\\/]{0,20})$");
                Regex LicensePlateRegex = new Regex("^[a-zA-Z0-9- ]{1,20}$");
                Regex StorageSpaceRegex = new Regex("^(\\s*|[0-9.,]{0,100})$");
                Regex GearsRegex = new Regex("^(\\s*|[0-9]{0,10})$");
                Regex FuelRegex = new Regex("^(\\s*|[0-9a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ]{1,100})$");
                Regex FuelUsageRegex = new Regex("^(\\s*|[0-9]{0,10})$");
                Regex StartPriceRegex = new Regex("^[0-9]{1,100}$");
                Regex HirePriceRegex = new Regex("^(\\s*|[0-9.,]{0,100})$");
                Regex SellingPriceRegex = new Regex("^(\\s*|[0-9,.]{0,100})$");
                Regex DoorsRegex = new Regex("^(\\s*|[0-9]{0,10})$");
                Regex SeatsRegex = new Regex("^(\\s*|[0-9]{0,10})$");

                RegexList.Add(BrandRegex);
                RegexList.Add(ModelRegex);
                RegexList.Add(CategoryRegex);
                RegexList.Add(ModelyearRegex);
                RegexList.Add(KilometresRegex);
                RegexList.Add(ColourRegex);
                RegexList.Add(HorsePowerRegex);
                RegexList.Add(LengthRegex);
                RegexList.Add(WidthRegex);
                RegexList.Add(HeightRegex);
                RegexList.Add(WeightRegex);
                RegexList.Add(MOTDateRegex);
                RegexList.Add(LicensePlateRegex);
                RegexList.Add(StorageSpaceRegex);
                RegexList.Add(GearsRegex);
                RegexList.Add(FuelRegex);
                RegexList.Add(FuelUsageRegex);
                RegexList.Add(StartPriceRegex);
                RegexList.Add(HirePriceRegex);
                RegexList.Add(SellingPriceRegex);
                RegexList.Add(DoorsRegex);
                RegexList.Add(SeatsRegex);

                LabelList.Add(BrandLabel);
                LabelList.Add(ModelLabel);
                LabelList.Add(CategoryLabel);
                LabelList.Add(ModelYearLabel);
                LabelList.Add(KilometresLabel);
                LabelList.Add(ColourLabel);
                LabelList.Add(HorsePowerLabel);
                LabelList.Add(LengthLabel);
                LabelList.Add(WidthLabel);
                LabelList.Add(HeightLabel);
                LabelList.Add(WeightLabel);
                LabelList.Add(MOTDateLabel);
                LabelList.Add(LicensePlateLabel);
                LabelList.Add(StorageSpaceLabel);
                LabelList.Add(GearsLabel);
                LabelList.Add(FuelLabel);
                LabelList.Add(FuelUsageLabel);
                LabelList.Add(StartpriceLabel);
                LabelList.Add(HirePriceLabel);
                LabelList.Add(SellingPriceLabel);
                LabelList.Add(DoorsLabel);
                LabelList.Add(SeatsLabel);

                InputList.Add(BrandBox.Text);
                InputList.Add(ModelBox.Text);
                InputList.Add(CategoryBox.Text);
                InputList.Add(ModelyearBox.Text);
                InputList.Add(KilometersBox.Text);
                InputList.Add(ColourBox.Text);
                InputList.Add(HorsePowerBox.Text);
                InputList.Add(LengthBox.Text);
                InputList.Add(WidthBox.Text);
                InputList.Add(HeightBox.Text);
                InputList.Add(WeightBox.Text);
                InputList.Add(MOTDate.Text);
                InputList.Add(licensePlateTextBox.Text);
                InputList.Add(StorageBox.Text);
                InputList.Add(GearsBox.Text);
                InputList.Add(MotorBox.Text);
                InputList.Add(FuelusageBox.Text);
                InputList.Add(StartpriceBox.Text);
                InputList.Add(RentalpriceBox.Text);
                InputList.Add(SellingpriceBox.Text);
                InputList.Add(DoorsBox.Text);
                InputList.Add(SeatsBox.Text);

                for (int i = 0; i <= 21; i++)
                {
                    if (RegexList[i].IsMatch(InputList[i]))
                    {
                        validInputCounter++;
                    }
                    else
                    {
                        Console.WriteLine(LabelList[i].Name);
                        LabelList[i].ForeColor = Color.Red;
                    }
                }
                if (validInputCounter == 22)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void addCarPhoto(CarPhoto carPhoto)
        {
            car.PhotoList.Add(carPhoto);

            //Refresh list with photos
            imageLinkList.Items.Add(carPhoto.Name);
        }
        private void uploadCarPhoto(ref Car car, List<string> files)
        {
            string ftpServerIP = "ftp.pqrojectqars.herobo.com";
            string ftpUserID = "a8158354";
            string ftpPassword = "Quintor1";
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

                    string localphotolink = photo.Photolink;
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
                            error = false;
                        }
                        else if (extension == ".png")
                        {
                            error = false;
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
            try
            {

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
                        foreach (var file in dir.GetFiles())
                        {
                            files.Add(file.Name);
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
                    ftp.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Fout tijdens het ophalen van de foto's van de server");
            }
            return files;

        }
        private void removeFileFromFTP(Car car, CarPhoto photoToDelete, string extension)
        {
            string ftpServerIP = "ftp.pqrojectqars.herobo.com";
            string ftpUserID = "a8158354";
            string ftpPassword = "Quintor1";
            FtpLib.FtpConnection ftp = new FtpLib.FtpConnection(ftpServerIP, ftpUserID, ftpPassword);
            ftp.Open();
            ftp.Login();
            try
            {
                string directory = string.Format("/public_html/Images/{0}/{1}/{2}/", car.brand, car.model, car.colour);

                string newDirectory = "/public_html/Images/";
                //Check if brand directory exists
                if (ftp.DirectoryExists(newDirectory + car.brand))
                {
                    newDirectory += car.brand;
                    ftp.SetCurrentDirectory("/public_html/Images/" + car.brand + "/");
                    newDirectory += "/";
                }
                else
                {
                    newDirectory += car.brand + "/";
                }

                //Check if model directory exists
                if (ftp.DirectoryExists(newDirectory + car.model))
                {
                    newDirectory += car.model;
                    ftp.SetCurrentDirectory("/public_html/Images/" + car.brand + "/" + car.model + "/");
                    newDirectory += "/";
                }
                else
                {
                    newDirectory += car.model + "/";
                }

                //Check if colour directory exists
                if (ftp.DirectoryExists(newDirectory + car.colour))
                {
                    newDirectory += car.colour;
                    ftp.SetCurrentDirectory("/public_html/Images/" + car.brand + "/" + car.model + "/" + car.colour + "/");
                    newDirectory += "/";
                }
                ftp.RemoveFile(photoToDelete.PhotoID.ToString() + extension);
            }
            catch (Exception e)
            {
                MessageBox.Show("Het verwijderen van de foto van de server is niet gelukt " + e.Message);
            }
        }

        private void delete_Button_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Wilt u deze foto echt verwijderen?", "Foto verwijderen", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int index = imageLinkList.SelectedIndex;
                CarPhoto photo = car.PhotoList[index];
                string fileExtension = "." + photo.Photolink.Split('.').Last();

                try
                {
                    this.connect.DeletePhoto(photo);
                    this.removeFileFromFTP(car, photo, fileExtension);
                    this.imageLinkList.Items.Remove(imageLinkList.SelectedIndex);
                    MessageBox.Show("De foto is verwijderd.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Het verwijderen van de foto is niet gelukt. Foutbericht: " + ex);
                }
            }
        }
        private string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
    }
}



