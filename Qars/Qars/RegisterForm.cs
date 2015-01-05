using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qars
{
    public partial class RegisterForm : Form
    {
        string driverslicenselink = "";
        bool emailInvalid = false;
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void ChoosePictureButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = "JPG files (*.JPG)|*.jpg|PNG files(*.PNG)|*.PNG";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                driverslicenselink = openFileDialog1.FileName;
                DriversLicensePictureBox.ImageLocation = @driverslicenselink;
                DriversLicensePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                SelectedPictureLabel.Visible = true;
            }
        }

        private void CancelButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void RegisterButton1_Click(object sender, EventArgs e)
        {
            //Validate input and stuff
        }
        private void ValidateInput(string username, string password, string emailaddress, string phonenumber, string driverslicensephotolink, string firstname, string lastname, string age, string postalcode, string city, string streetname, string streetnumber, string streetnumbersuffix)
        {
            bool accountTaken = false;
            List<Label> LabelList = new List<Label>();
            List<String> InputList = new List<String>();
            List<Regex> RegExList = new List<Regex>();
            int validinput = 0;

            // Create all regexes, insert labels and information into lists
            Regex usernameRegEx = new Regex("^[\\Sa-zA-Z]{6,25}$");
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
                            if (user.firstname == firstname || user.emailaddress == emailaddress)
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
                                    //A file was selected, driverslicenselink is the path
                                    //upload the file!
                                    //if(file succesfully uploaded)
                                    //send email
                                }
                                else
                                {
                                    //no file selected
                                    //send email
                                }
                            }
                            else
                            {
                                //Checkbox isn't checked
                            }
                        }
                        else
                        {
                            //Account is taken
                        }
                    }
                    else
                    {
                        //There are no users
                    }
                }
                else
                {
                    //The emailaddress is invalid
                }
            }
            else
            {
                //The input doesn't match regex
            }
        }

        private void TOSLabel_Click(object sender, EventArgs e)
        {
            //Open TOS
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

    }
}
