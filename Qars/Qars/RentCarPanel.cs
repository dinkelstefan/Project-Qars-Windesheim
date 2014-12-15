using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;     //nieuw toegevoegd
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Qars
{
    public partial class RentCarPanel : UserControl
    {
        DateTime[] bolddates;
        public int carID { get; set; }
        public int countlabel = 0;
        private String currentSelectedDateBox;
        bool secondDateChecked;
        DateTime startdatum;
        DateTime einddatum;
        bool reservationCollision = false;
        bool firstMessage = false;
        bool emailInvalid;
        private VisualDemo qarsApplication;
        public RentCarPanel(int carID, VisualDemo qarsApp)
        {
            this.qarsApplication = qarsApp;
            InitializeComponent();
            this.carID = carID;
            createSpecInfo(qarsApplication.carList, carID);

        }
        /*TO DO
         * If(User is logged in)
         * {
         * Insert all customer info into text fields
         * Disable all textfields except collect car and comment
         * }else{
         * MessageBox.Show("U moet ingelogd zijn om een auto te kunnen huren" Button = Registreer/Log in.
         * }
         * 
         * OTHER STUFF:
         * Validate Input(ON INPUT)
         * Send Email
         * Add reservation to database
         * Fix Calendar
         * */
        private void ValidateInput(string firstname, string lastname, string age, string streetname, string streetnumber, string streetnumbersuffix, string city, string postalcode, string email, string phonenumber, string startdate, string enddate, string kilometres, string pickupcity, string pickupstreetname, string pickupstreetnumber, string pickupstreetnumbersuffix, string comment)
        {
            int validinput = 0;
            if (pickupcity != "" || pickupstreetname != "" || pickupstreetnumber != "" || pickupstreetnumbersuffix != "")
            {
                //everything needs to be valid
            }
            //create 3 lists for the labels, input and regEx
            List<Label> LabelList = new List<Label>();
            List<String> InputList = new List<String>();
            List<Regex> RegExList = new List<Regex>();


            //Put labels in list
            LabelList.Add(firstnameLabel);
            LabelList.Add(lastnameLabel);
            LabelList.Add(ageLabel);
            LabelList.Add(streetnameLabel);
            LabelList.Add(streetnumberLabel);
            LabelList.Add(streetnumbersuffixlabel);
            LabelList.Add(citylabel);
            LabelList.Add(postalcodeLabel);
            LabelList.Add(phonenumberLabel);
            LabelList.Add(startdateLabel);
            LabelList.Add(enddateLabel);
            LabelList.Add(AmountofKilometerLabel);
            LabelList.Add(pickupCityLabel);
            LabelList.Add(pickupstreetnameLabel);
            LabelList.Add(pickupstreetnumberLabel);
            LabelList.Add(pickupstreetnumbersuffixLabel);


            //Regexes
            Regex firstnameRegEx = new Regex("^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ]{1,46}$");
            Regex lastNameRegEx = new Regex("^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ]{1,100}$");
            Regex ageRegEx = new Regex("^[0-9]{1,3}$");
            Regex streetNameRegEx = new Regex("^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð  ]{1,95}$"); //(pickup)Streetname
            Regex streetNumberRegEx = new Regex("^[0-9]{1,5}$"); //(pickup)streetnumber
            Regex streetNumberSuffixRegEx = new Regex("^[a-zA-Z]{0,1}$");//(pickup)streetnumbersuffix
            Regex cityRegEx = new Regex(String.Format("^[a-zA-Z\\u0080-\\u024F\\s\\/\\-\\)\\(\\`\\.\\\"\\\']+$")); //(pickup)City
            Regex postalCodeRegEx = new Regex("^[0-9a-zA-Z ]{7}");
            Regex phoneNumberRegEx = new Regex("^[0-9-+]{7,14}$");
            Regex dateRegEx = new Regex("^[0-9-]{10,10}$"); //startdate & enddate
            Regex kilometerRegEx = new Regex("^[0-9]{1,6}$");
            Regex pickupstreetNameRegEx = new Regex("^(\\s*|[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð\\D  ]{1,95})$"); //(pickup)Streetname
            Regex pickupstreetNumberRegEx = new Regex("^(\\s*|\\d{1,5})$"); //(pickup)streetnumber
            Regex pickupstreetNumberSuffixRegEx = new Regex("^(\\s*|[a-zA-Z])$");//(pickup)streetnumbersuffix
            Regex pickupcityRegEx = new Regex(String.Format("^(\\s*|[a-zA-Z\\u0080-\\u024F\\s\\/\\-\\)\\(\\`\\.\\\"\\']+)$")); //(pickup)City

            //Add RegEx to List
            RegExList.Add(firstnameRegEx);
            RegExList.Add(lastNameRegEx);
            RegExList.Add(ageRegEx);
            RegExList.Add(streetNameRegEx);
            RegExList.Add(streetNumberRegEx);
            RegExList.Add(streetNumberSuffixRegEx);
            RegExList.Add(cityRegEx);
            RegExList.Add(postalCodeRegEx);
            RegExList.Add(phoneNumberRegEx);
            RegExList.Add(dateRegEx);
            RegExList.Add(dateRegEx);
            RegExList.Add(kilometerRegEx);
            RegExList.Add(pickupcityRegEx);
            RegExList.Add(pickupstreetNameRegEx);
            RegExList.Add(pickupstreetNumberRegEx);
            RegExList.Add(pickupstreetNumberSuffixRegEx);

            //Insert Information in list
            InputList.Add(firstname);
            InputList.Add(lastname);
            InputList.Add(age);
            InputList.Add(streetname);
            InputList.Add(streetnumber);
            InputList.Add(streetnumbersuffix);
            InputList.Add(city);
            InputList.Add(postalcode);
            InputList.Add(phonenumber);
            InputList.Add(startdate);
            InputList.Add(enddate);
            InputList.Add(kilometres);
            InputList.Add(pickupcity);
            InputList.Add(pickupstreetname);
            InputList.Add(pickupstreetnumber);
            InputList.Add(pickupstreetnumbersuffix);

            foreach (var item in LabelList)
            {
                item.ForeColor = Color.Black;
            }
            int counter = 0;
            //Validate input
            foreach (var item in RegExList)
            {
                if (item.IsMatch(InputList[counter]))
                {
                    validinput += 1;
                }
                else
                {
                    LabelList[counter].ForeColor = Color.Red;
                }
                counter++;
            }
            if (IsValidEmail(email))
            {
                Console.WriteLine(validinput);
                if (validinput == 16)
                {
                    InsertIntoDatabase(carID, /*customerID FIX*/ -1, startdate, enddate, Convert.ToInt32(kilometres), pickupcity, pickupstreetname, Convert.ToInt32(pickupstreetnumber), pickupstreetnumbersuffix, comment);
                    SendEmail(carID, firstname, lastname, age, streetname, streetnumber, streetnumbersuffix, city, postalcode, email, phonenumber, startdate, enddate, pickupcity, pickupstreetname, Int32.Parse(pickupstreetnumber), pickupstreetnumbersuffix, comment);
                    MessageBox.Show("U ontvangt z.s.m een email met daarin uw reserveringbewijs");
                }
                else
                {
                    MessageBox.Show("Er ging iets verkeerd met het verzenden van uw gegevens!");
                }
            }
            else
            {
                MessageBox.Show("Er ging iets fout. Controleer de gegevens in het rood.");
                emailLabel.ForeColor = Color.Red;
            }
        }
        private void InsertIntoDatabase(int carID, int customerID, string startdate, string enddate, int kilometres, string pickupcity, string pickupstreetname, int pickupstreetnumber, string pickupstreetnumbersuffix, string comment)
        {
            Reservation reservation = new Reservation();

            reservation.carID = carID;
            reservation.customerID = customerID; //CUSTOMER LOGGED IN NUMBER. FIX THIS LATER
            reservation.startdate = startdate;
            reservation.enddate = enddate;
            reservation.confirmed = false;
            reservation.kilometres = kilometres;
            reservation.pickupcity = pickupcity;
            reservation.pickupstreetname = pickupstreetname;
            reservation.pickupstreetnumber = pickupstreetnumber;
            reservation.pickupstreetnumbersuffix = pickupstreetnumbersuffix;
            reservation.paid = false;
            reservation.comment = comment;

            DBConnect connection = new DBConnect();
            connection.InsertReservation(reservation);
        }
        private void SendEmail(int carID, string firstname, string lastname, string age, string streetname, string streetnumber, string streetnumbersuffix, string city, string postalcode, string email, string phonenumber, string startdate, string enddate, string pickupcity, string pickupstreetname, int pickupstreetnumber, string pickupstreetnumbersuffix, string comment)
        {
            Util.Mail mail = new Util.Mail();
            mail.addTo(email);
            mail.addSubject("Aanvraag van " + qarsApplication.carList[carID].brand + " " + qarsApplication.carList[carID].model);
            mail.addBody(buildEmailBody(firstname, lastname, age, streetname, streetnumber, streetnumbersuffix, city, postalcode, email, phonenumber, startdate, enddate, pickupcity, pickupstreetname, pickupstreetnumber, pickupstreetnumbersuffix, comment));
            mail.sendEmail();
        }
        private void createSpecInfo(List<Car> list, int carNumber)
        {

            InfoModelLabel.Text = qarsApplication.carList[carNumber].model + " " + qarsApplication.carList[carNumber].brand;
            InfoModelYearLabel.Text = qarsApplication.carList[carNumber].modelyear.ToString();
            InfoStartPriceLabel.Text = "€ " + qarsApplication.carList[carNumber].startprice;
            InfoCategoryLabel.Text = qarsApplication.carList[carNumber].category;
            if (qarsApplication.carList[carNumber].automatic)
            {
                InfoAutomaticLabel.Text = "Ja";
            }
            else
            {
                InfoAutomaticLabel.Text = "Nee";
            }
            if (qarsApplication.carList[carNumber].cruisecontrol)
            {
                InfoCruiseControlLabel.Text = "Ja";
            }
            if (qarsApplication.carList[carNumber].kilometres == -1)
            {
                InfoKilometresLabel.Text = "N.V.T";
            }
            else
            {
                InfoKilometresLabel.Text = qarsApplication.carList[carNumber].kilometres.ToString();

            }
            if (qarsApplication.carList[carNumber].horsepower == -1)
            {
                InfoHorsePowerLabel.Text = "N.V.T";
            }
            else
            {
                InfoHorsePowerLabel.Text = qarsApplication.carList[carNumber].horsepower + " PK";
            }
            if (qarsApplication.carList[carNumber].motdate == "")
            {
                InfoMOTDateLabel.Text = "N.V.T";
            }
            else
            {
                InfoMOTDateLabel.Text = qarsApplication.carList[carNumber].motdate;
            }
            if (qarsApplication.carList[carNumber].storagespace == -1)
            {
                InfoStorageSpaceLabel.Text = "N.V.T";
            }
            else
            {
                InfoStorageSpaceLabel.Text = qarsApplication.carList[carNumber].storagespace + " Liter";
            }

        }
        public bool IsValidEmail(string strIn)
        {
            emailInvalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names. 
            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
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
        private string buildEmailBody(string firstname, string lastname, string age, string streetname, string streetnumber, string streetnumbersuffix, string city, string postalcode, string email, string phonenumber, string startdate, string enddate, string pickupcity, string pickupstreetname, int pickupstreetnumber, string pickupstreetnumbersuffix, string comment)
        {
            StringBuilder builder = new StringBuilder();
            //This part can be edited by the admin
            builder.AppendLine(String.Format("Beste meneer/mevrouw {0}", lastname));
            builder.AppendLine("");
            builder.AppendLine("Bedank voor uw bestelling bij Qars. Wij gaan proberen om uw verzoek zo snel");
            builder.AppendLine("mogelijk te verwerken. Zodra uw verzoek is goed gekeurd ontvangt u een bevestiging");
            builder.AppendLine("");

            builder.AppendLine(String.Format("Voornaam:\t{0}", firstname));
            builder.AppendLine(String.Format("Achternaam:\t{0}", lastname));
            builder.AppendLine(String.Format("Leeftijd:\t{0}", age));
            builder.AppendLine(String.Format("Achternaam:\t{0}", lastname));
            builder.AppendLine(String.Format("Adres:\t\t{0} {1}{2}", streetname, streetnumber, streetnumbersuffix));
            builder.AppendLine(String.Format("Woonplaats:\t{0}", city));
            builder.AppendLine(String.Format("Postcode:\t{0}", postalcode));
            builder.AppendLine(String.Format("Email:\t\t{0}", email));
            builder.AppendLine(String.Format("Telefoon:\t{0}", phonenumber));
            builder.Append("\n");
            builder.AppendLine(String.Format("Begin datum:\t{0}", startdate));
            builder.AppendLine(String.Format("Eind datum:\t{0}", enddate));
            if (pickupcity == "" && pickupstreetname != "" && pickupstreetnumber != 0)
            {
                builder.AppendLine(String.Format("De auto zal op {0} worden opgehaald op het volgende adres:", enddate));
                if (streetnumbersuffix != "")
                {
                    builder.AppendLine(String.Format(pickupStreetNameTextbox.Text + " " + pickupStreetnumberTextbox.Text + pickupStreetnumberSuffixTextbox.Text + " te " + pickupCityTextbox.Text));
                }
                else
                {
                    builder.AppendLine(String.Format(pickupStreetNameTextbox.Text + " " + pickupStreetnumberTextbox.Text + " te " + pickupCityTextbox.Text));
                }
            }
            builder.Append("\n");
            if (comment != "")
            {
                builder.AppendLine("Opmerking:");
                builder.AppendLine(comment);
            }
            //this part can be edited by the admin
            builder.Append("\n\n");
            builder.AppendLine("Met vriendelijke groeten,");
            builder.AppendLine("");
            builder.AppendLine("Qars");

            return builder.ToString();
        }
        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            string day = monthCalendar.SelectionStart.Day.ToString();
            string month = monthCalendar.SelectionStart.Month.ToString();

            if (day.Length == 1)
            {
                day = "0" + day;
            }

            if (month.Length == 1)
            {
                month = "0" + month;
            }

            string date = day + month + monthCalendar.SelectionStart.Year.ToString();

            if (startdateTextbox.Name == currentSelectedDateBox)
            {
                startdateTextbox.Text = date;
                startdatum = monthCalendar.SelectionStart.Date;
            }
            else if (enddateTextbox.Name == currentSelectedDateBox)
            {
                enddateTextbox.Text = date;
                einddatum = monthCalendar.SelectionStart.Date;
                secondDateChecked = true;
            }
            if (secondDateChecked)
            {
                if (einddatum < startdatum)
                {
                    MessageBox.Show("De einddatum mag niet kleiner zijn dan de start datum");
                    enddateTextbox.Text = "";
                }
            }/*
            foreach (var bolddate in bolddates)      //loop through all bolded dates...
            {
                if (startdatum == bolddate)    //if the start WILL be a bolded date...
                {
                    MessageBox.Show("Deze begindatum kan niet worden gebruikt i.v.m reservering!");
                    startdateTextbox.Text = "";
                    firstMessage = true;
                }

                if (einddatum == bolddate)  //if the end date WILL be a bolded date...
                {
                    MessageBox.Show("Deze einddatum kan niet worden gebruikt i.v.m reservering!");
                    firstMessage = true;
                    enddateTextbox.Text = "";
                }
                if (startdatum <= einddatum)
                {
                    TimeSpan tisp = einddatum - startdatum;
                    int dateDiffer = tisp.Days;
                    for (int i = 0; i <= dateDiffer; i++) //Tel dagen op. Elke dag kijken of dag bolded is. Yes = message. no = cooL!
                    {
                        if (startdatum.AddDays(i) == bolddate)
                        {
                            reservationCollision = true;
                        }
                    }
                }

            }
            if (!firstMessage)  //checks if there is only 1 messagebox...
            {
                if (reservationCollision)
                {
                    MessageBox.Show("De datum tussen de datums: " + startdateTextbox.Text + " en " + enddateTextbox.Text + ", mogen niet gebruikt worden!");
                    //startdateTextbox.Text = "";
                    enddateTextbox.Text = "";
                    reservationCollision = false;

                }
            }*/
        }
        private void openCalender(object sender, EventArgs e)
        {
            foreach (var item in this.qarsApplication.reservationList) //loop through all the reservations
                if (carID == item.carID && item.confirmed) //Check if there is a reservation for the current car
                {
                    string startDateString = item.startdate;
                    string endDateString = item.enddate;
                    DateTime startDate = Convert.ToDateTime(startDateString);
                    DateTime endDate = Convert.ToDateTime(endDateString);

                    TimeSpan ts = endDate - startDate;
                    int differenceInDays = ts.Days;
                    for (int i = 1; i <= differenceInDays; i++)
                    {
                        monthCalendar.AddBoldedDate(startDate.AddDays(i));   //makes all dates between start and end bolded in calendar... 
                        if (i == differenceInDays)
                        {
                            monthCalendar.AddBoldedDate(startDate.AddDays(i + 1));  //makes the day after the end date of reservation bolded in calendar...
                        }
                    }

                    bolddates = monthCalendar.BoldedDates;       //put all bolded dates in DateTime array...
                }

            monthCalendar.UpdateBoldedDates();

            if (currentSelectedDateBox == startdateTextbox.Name)
            {
                monthCalendar.MinDate = DateTime.Today;
            }
            monthCalendar.Show();
            MaskedTextBox b = (MaskedTextBox)sender;
            currentSelectedDateBox = b.Name;
        }
        private void closeCalender(object sender, EventArgs e)
        {
            monthCalendar.Hide();
        }
        private void rentCarClick(object sender, EventArgs e)
        {
            ValidateInput(firstnameTextbox.Text, lastnameTextbox.Text, ageTextBox.Text, streetnameTextbox.Text, streetnumberTextbox.Text, streetnumbersuffixTextbox.Text, cityTextbox.Text, postalcodeTextbox.Text, emailTextbox.Text, phonenumberTextbox.Text,
                startdateTextbox.Text, enddateTextbox.Text, KilometerTextBox.Text, pickupCityTextbox.Text, pickupStreetNameTextbox.Text, pickupStreetnumberTextbox.Text, pickupStreetnumberSuffixTextbox.Text, commentTextbox.Text);
        }
        private void closeRentCarPanel(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}