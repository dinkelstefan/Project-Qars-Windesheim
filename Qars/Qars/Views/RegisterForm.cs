using Qars.Models;
using Qars.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qars.Views
{

    public partial class RegisterForm : Form
    {
        bool JPG = true;
        string driverslicenselink = ""; //LOCAL FILE
        bool emailInvalid = false;
        bool buttonClicked = false;
        public RegisterForm()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            InitializeComponent();
        }

        private void ChoosePictureButton_Click(object sender, EventArgs e)
        {
            buttonClicked = true;
            bool error = false;
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = "JPG files (*.JPG)|*.jpg|PNG files(*.PNG)|*.PNG";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                driverslicenselink = openFileDialog1.FileName;
                FileInfo fi = new FileInfo(driverslicenselink);

                long fileSize = fi.Length; //The size of the current file in bytes.file
                if (fileSize > 2621440)
                {
                    WrongFileLabel.Visible = true;
                    driverslicenselink = "";
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
                        driverslicenselink = "";
                        error = true;
                    }
                    if (error == false)
                    {
                        DriversLicensePictureBox.ImageLocation = driverslicenselink;
                        DriversLicensePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        SelectedPictureLabel.Visible = true;
                    }

                }
            }
        }
        private void CancelButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void RegisterButton1_Click(object sender, EventArgs e)
        {
            bool validateResult = false;
            bool uploadPhotoResult = false;
            bool insertDataBaseResult = false;
            bool emailResult = false;

            //Validate input and stuff
            validateResult = ValidateInput(UsernameTextBox.Text, PasswordTextBox.Text, EmailTextBox.Text, PhoneNumberTextBox.Text, driverslicenselink, FirstNameTextBox.Text, SurnameTextBox.Text, AgeTextBox.Text, PostalCodeTextBox.Text, CityTextBox.Text, StreetNameTextBox.Text, StreetNumberTextBox.Text, StreetNumberSuffixTextBox.Text);
            if (validateResult == true)
                uploadPhotoResult = UploadDriversLicensePhoto(driverslicenselink, UsernameTextBox.Text);
            if (uploadPhotoResult == true)
                insertDataBaseResult = CompleteRegistration(UsernameTextBox.Text, PasswordTextBox.Text, EmailTextBox.Text, PhoneNumberTextBox.Text, driverslicenselink, FirstNameTextBox.Text, SurnameTextBox.Text, AgeTextBox.Text, PostalCodeTextBox.Text, CityTextBox.Text, StreetNameTextBox.Text, StreetNumberTextBox.Text, StreetNumberSuffixTextBox.Text);
            if (insertDataBaseResult == true)
                emailResult = SendEmail(UsernameTextBox.Text, PasswordTextBox.Text, EmailTextBox.Text, PhoneNumberTextBox.Text, driverslicenselink, FirstNameTextBox.Text, SurnameTextBox.Text, AgeTextBox.Text, PostalCodeTextBox.Text, CityTextBox.Text, StreetNameTextBox.Text, StreetNumberTextBox.Text, StreetNumberSuffixTextBox.Text);
            if (emailResult == true)
                MessageBox.Show("U heeft zich geregistreerd en u kan nu inloggen. U ontvangt z.s.m een email met daarin uw inloggegevens");
        }
        private bool ValidateInput(string username, string password, string emailaddress, string phonenumber, string driverslicensephotolink, string firstname, string lastname, string age, string postalcode, string city, string streetname, string streetnumber, string streetnumbersuffix)
        {
            bool accountTaken = false;
            accountTaken = false;
            List<Label> LabelList = new List<Label>();
            List<String> InputList = new List<String>();
            List<Regex> RegExList = new List<Regex>();
            int validinput = 0;

            // Create all regexes, insert labels and information into lists
            Regex usernameRegEx = new Regex("^[\\Sa-zA-Z0-9]{6,25}$");
            Regex passwordRegEx = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{6,255}$");
            Regex emailRegEx = new Regex("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            Regex phoneNumberRegEx = new Regex("^(\\s*|[0-9-+]{7,14})$");
            Regex firstnameRegEx = new Regex("^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ]{1,46}$");
            Regex lastNameRegEx = new Regex("^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ]{1,100}$");
            Regex ageRegEx = new Regex("^[0-9]{1,3}$");
            Regex postalCodeRegEx = new Regex("^[0-9a-zA-Z ]{7}");
            Regex cityRegEx = new Regex(String.Format("^[a-zA-Z\\u0080-\\u024F\\s\\/\\-\\)\\(\\`\\.\\\"\\\']+$"));
            Regex streetNameRegEx = new Regex("^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð  ]{1,95}$");
            Regex streetNumberRegEx = new Regex("^[0-9]{1,5}$");
            Regex streetNumberSuffixRegEx = new Regex("^[a-zA-Z]{0,1}$");

            //Put labels in list
            LabelList.Add(UsernameLabel);
            LabelList.Add(PasswordLabel);
            LabelList.Add(EmailLabel);
            LabelList.Add(PhoneNumberLabel);
            LabelList.Add(FirstNameLabel);
            LabelList.Add(LastnameLabel);
            LabelList.Add(AgeLabel);
            LabelList.Add(PostalcodeLabel);
            LabelList.Add(CityLabel);
            LabelList.Add(StreetnameLabel);
            LabelList.Add(StreetNumberLabel);
            LabelList.Add(StreetNumberSuffixLabel);

            //Add RegEx to List
            RegExList.Add(usernameRegEx);
            RegExList.Add(passwordRegEx);
            RegExList.Add(emailRegEx);
            RegExList.Add(phoneNumberRegEx);
            RegExList.Add(firstnameRegEx);
            RegExList.Add(lastNameRegEx);
            RegExList.Add(ageRegEx);
            RegExList.Add(postalCodeRegEx);
            RegExList.Add(cityRegEx);
            RegExList.Add(streetNameRegEx);
            RegExList.Add(streetNumberRegEx);
            RegExList.Add(streetNumberSuffixRegEx);

            //Insert Information in list
            InputList.Add(username);
            InputList.Add(password);
            InputList.Add(emailaddress);
            InputList.Add(phonenumber);
            InputList.Add(firstname);
            InputList.Add(lastname);
            InputList.Add(age);
            InputList.Add(postalcode);
            InputList.Add(city);
            InputList.Add(streetname);
            InputList.Add(streetnumber);
            InputList.Add(streetnumbersuffix);

            foreach (var item in LabelList)
                item.ForeColor = Color.Black;
            int counter = 0;
            //Validate input
            foreach (var item in RegExList) //Check regexes
            {
                if (item.IsMatch(InputList[counter])) //If the input matches the regex
                    validinput += 1;
                else
                    LabelList[counter].ForeColor = Color.Red;
                counter++;
            }
            if (validinput == 12) //Is all input correct
            {
                if (IsValidEmail(emailaddress)) //Is the email address correct
                {
                    List<User> userList = new DBConnect().SelectUsers(); //Fetch the latest amount of users
                    if (userList.Count != 0 || userList != null)
                    {
                        //check if the username is available
                        foreach (var user in userList)
                        {

                            if (user.username == username || user.emailaddress == emailaddress)
                            {
                                accountTaken = true;
                                break;
                            }
                        }

                        if (accountTaken == false)
                        {
                            if (TOSCheckBox.Checked)
                            {
                                if (driverslicenselink != "")
                                {
                                    //Upload file in UploadDriversLicensePhoto();
                                    return true;

                                }
                                else
                                {
                                    //Do nothing, a driverlicensephoto is not required
                                    return true;

                                }

                            }
                            else
                            {
                                TOSCheckBox.ForeColor = Color.Red;
                                TOSLabel.ForeColor = Color.Red;
                                MessageBox.Show("U moet akkoord gaan met de algemene voorwaarden");
                                return false;
                                //USer didn't agree with TOS
                            }
                        }
                        else
                        {
                            UsernameLabel.ForeColor = Color.Red;
                            EmailLabel.ForeColor = Color.Red;
                            MessageBox.Show("Deze gebruikersnaam/email combinatie is al in gebruik");
                            //Account is taken
                            return false;
                        }
                    }
                    else
                    {
                        //There are no users
                        //Exception catch
                        return false;
                    }
                }
                else
                {
                    //The emailaddress is invalid
                    EmailLabel.ForeColor = Color.Red;
                    MessageBox.Show("Uw emailadres klopt niet");
                    return false;
                }
            }
            else
            {
                //The input doesn't match regex
                MessageBox.Show("Er ging iets fout. Controleer de gegevens in het rood");
                return false;
            }
        }
        private void TOSLabel_Click(object sender, EventArgs e)
        {
            TermsOfService termsofserviceForm = new TermsOfService();
            termsofserviceForm.ShowDialog();

        }
        public bool IsValidEmail(string strIn)
        {
            emailInvalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;
            // Use IdnMapping class to convert Unicode domain names. 
            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            if (emailInvalid)
                return false;

            // Return true if strIn is in valid e-mail format. 
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                emailInvalid = true;
            }
            return match.Groups[1].Value + domainName;
        }
        private bool UploadDriversLicensePhoto(string Image, string username)
        {
            if (Image == "" && buttonClicked)
            {
                string extension = ".PNG";
                if (JPG)
                {
                    extension = ".JPG";
                }
                try
                {
                    string ftpServerIP = "ftp.pqrojectqars.herobo.com";
                    string ftpUserID = "a8158354";
                    string ftpPassword = "Quintor1";
                    ////string ftpURI = "";
                    string filename = "ftp://" + ftpServerIP + "/public_html/DriverLicense/" + username + extension;
                    FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create(filename);
                    ftpReq.UseBinary = true;
                    ftpReq.Method = WebRequestMethods.Ftp.UploadFile;
                    ftpReq.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                    byte[] b = File.ReadAllBytes(Image);

                    ftpReq.ContentLength = b.Length;
                    using (Stream s = ftpReq.GetRequestStream())
                    {
                        s.Write(b, 0, b.Length);
                    }

                    FtpWebResponse ftpResp = (FtpWebResponse)ftpReq.GetResponse();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);

                    return false;

                }
                driverslicenselink = "http://pqrojectqars.herobo.com/DriverLicense/" + username + extension;
                return true;
            }
            else
            {
                return true; //No photo was selected, so no photo has to be uploaded
            }
        }
        private bool SendEmail(string username, string password, string emailaddress, string phonenumber, string driverslicensephotolink, string firstname, string lastname, string age, string postalcode, string city, string streetname, string streetnumber, string streetnumbersuffix)
        {
            try
            {
                Util.Mail mail = new Util.Mail();
                mail.addTo(emailaddress);
                mail.addSubject("Uw registratie op Qars");
                mail.addBody(buildEmailBody(UsernameTextBox.Text, PasswordTextBox.Text, EmailTextBox.Text, PhoneNumberTextBox.Text, driverslicenselink, FirstNameTextBox.Text, SurnameTextBox.Text, AgeTextBox.Text, PostalCodeTextBox.Text, CityTextBox.Text, StreetNameTextBox.Text, StreetNumberTextBox.Text, StreetNumberSuffixTextBox.Text));
                mail.sendEmail();
            }
            catch (Exception)
            {
                MessageBox.Show("Wij konden u op dit moment geen email versturen. Neem alstublieft contact op met het bedrijf waarvan u de auto wilt huren");
                return false;
            }
            return true;
        }
        private bool CompleteRegistration(string username, string password, string emailaddress, string phonenumber, string driverslicensephotolink, string firstname, string lastname, string age, string postalcode, string city, string streetname, string streetnumber, string streetnumbersuffix)
        {
            User newUser = new User();
            newUser.username = username;
            newUser.password = password;
            newUser.emailaddress = emailaddress;
            newUser.phonenumber = phonenumber;
            newUser.driverslicenselink = driverslicensephotolink;
            newUser.firstname = firstname;
            newUser.lastname = lastname;
            newUser.age = Convert.ToInt32(age);
            newUser.postalcode = postalcode;
            newUser.city = city;
            newUser.streetname = streetname;
            newUser.streetnumber = Convert.ToInt32(streetnumber);
            newUser.streetnumbersuffix = streetnumbersuffix;

            DBConnect db = new DBConnect();
            if (db.InsertCustomer(newUser) == true)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Wij konden uw registratie nu niet verwerken. Probeer het later opnieuw of neem contact op met het bedrijf");
                return false;
            }
        }
        private string buildEmailBody(string username, string password, string emailaddress, string phonenumber, string driverslicensephotolink, string firstname, string lastname, string age, string postalcode, string city, string streetname, string streetnumber, string streetnumbersuffix)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(String.Format("Beste meneer/mevrouw {0},", lastname));
            builder.AppendLine("\n");
            builder.AppendLine("Bedankt voor uw registratie in het Qars systeem. Dit zijn uw ingevulde gegevens:");
            builder.AppendLine("Uw persoonlijke gegevens:");
            builder.AppendLine("\n");

            builder.AppendLine(String.Format("Voornaam:\t{0}", firstname));
            builder.AppendLine(String.Format("Achternaam:\t{0}", lastname));
            builder.AppendLine(String.Format("Leeftijd:\t{0}", age));
            builder.AppendLine(String.Format("Adres:\t\t{0} {1}{2}", streetname, streetnumber, streetnumbersuffix));
            builder.AppendLine(String.Format("Woonplaats:\t{0}", city));
            builder.AppendLine(String.Format("Postcode:\t{0}", postalcode));
            builder.AppendLine(String.Format("Email:\t\t{0}", emailaddress));
            builder.AppendLine(String.Format("Telefoon:\t{0}", phonenumber));
            builder.AppendLine("\n");
            builder.AppendLine("Uw inloggegevens zijn:");
            builder.AppendLine("\n");
            builder.AppendLine(string.Format("Gebruikersnaam:\t{0}", username));
            builder.AppendLine(string.Format("Wachtwoord:\t{0}", password));
            builder.AppendLine("\n");
            builder.AppendLine("Uw gegevens zijn beveiligd opgeslagen in onze databank. Wanneer u problemen ondervindt met de Qars applicatie, neem dan alstublieft contact op met de beheerders.");
            builder.AppendLine("\n");
            builder.AppendLine("Met vriendelijke groeten,");
            builder.AppendLine("\nQars");


            return builder.ToString();
        }

    }
}