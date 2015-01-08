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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Qars
{
    public partial class RentCarPanel : UserControl
    {
        DateTime[] bolddates;
        List<String> stringList;
        string[] emailspecinfo = { "Automaat:", "Cruise Control:", "Kilometers:", "Vermogen:", "APK Datum:", "Ruimte:\t" };
        public int carID { get; set; }
        public int UserID { get; set; }

        public int countlabel = 0;
        private VisualDemo qarsApplication;
        private String currentSelectedDateBox;
        DateTime startdate = DateTime.Today;
        DateTime enddate;
        bool carHasReservation = false;
        bool emailInvalid;
        int amountEndDateOpened = 0;
        public RentCarPanel(int carID, int UserID, VisualDemo qarsApp)
        {
            this.qarsApplication = qarsApp;
            this.UserID = qarsApp.userID;
            InitializeComponent();
            this.carID = carID;
            stringList = createSpecInfo(qarsApplication.carList, carID);
            getReservations();
        }
        public bool ValidateInput(string firstname, string lastname, string age, string streetname, string streetnumber, string streetnumbersuffix, string city, string postalcode, string email, string phonenumber, string startdate, string enddate, string kilometres, string pickupcity, string pickupstreetname, string pickupstreetnumber, string pickupstreetnumbersuffix, string comment)
        {
            bool correctDate = true;
            try //Make sure the date is valid
            {
                Convert.ToDateTime(startdate);
                Convert.ToDateTime(enddate);
            }
            catch (FormatException)
            {
                startdateLabel.ForeColor = Color.Red;
                enddateLabel.ForeColor = Color.Red;
                MessageBox.Show("Uw gekozen huurperiode is niet geen geldige periode");
                correctDate = false;
            }
            if (correctDate == true) //If date is valid
            {
                List<Label> LabelList = new List<Label>();
                List<String> InputList = new List<String>();
                List<Regex> RegExList = new List<Regex>();
                int validinput = 0;
                // Create all regexes, insert labels and information into lists
                Regex firstnameRegEx = new Regex("^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ]{1,46}$");
                Regex lastNameRegEx = new Regex("^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ]{1,100}$");
                Regex ageRegEx = new Regex("^[0-9]{1,3}$");
                Regex streetNameRegEx = new Regex("^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð  ]{1,95}$");
                Regex streetNumberRegEx = new Regex("^[0-9]{1,5}$");
                Regex streetNumberSuffixRegEx = new Regex("^[a-zA-Z]{0,1}$");
                Regex cityRegEx = new Regex(String.Format("^[a-zA-Z\\u0080-\\u024F\\s\\/\\-\\)\\(\\`\\.\\\"\\\']+$"));
                Regex postalCodeRegEx = new Regex("^[0-9a-zA-Z ]{7}");
                Regex emailRegEx = new Regex("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
                Regex phoneNumberRegEx = new Regex("^(\\s*|[0-9-+]{7,14})$");
                Regex dateRegEx = new Regex("^[0-9-]{10,10}$");
                Regex kilometerRegEx = new Regex("^[0-9]{1,6}$");
                Regex pickupstreetNameRegEx = new Regex("^(\\s*|[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð\\D  ]{1,95})$");
                Regex pickupstreetNumberRegEx = new Regex("^(\\s*|\\d{1,5})$");
                Regex pickupstreetNumberSuffixRegEx = new Regex("^(\\s*|[a-zA-Z])$");
                Regex pickupcityRegEx = new Regex(String.Format("^(\\s*|[a-zA-Z\\u0080-\\u024F\\s\\/\\-\\)\\(\\`\\.\\\"\\']+)$"));

                if (pickupcity != "" || pickupstreetname != "" || pickupstreetnumber != "" || pickupstreetnumbersuffix != "")
                {
                    pickupcityRegEx = new Regex("^[a-zA-Z\\u0080-\\u024F\\s\\/\\-\\)\\(\\`\\.\\\"\\']+$");
                    pickupstreetNameRegEx = new Regex("^([a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð\\D  ]{1,95})$");
                    pickupstreetNumberRegEx = new Regex("^\\d{1,5}$");
                    pickupstreetNumberSuffixRegEx = new Regex("^[a-zA-Z]{0,1}$");
                }
                //Put labels in list
                LabelList.Add(firstnameLabel);
                LabelList.Add(lastnameLabel);
                LabelList.Add(ageLabel);
                LabelList.Add(streetnameLabel);
                LabelList.Add(streetnumberLabel);
                LabelList.Add(streetnumbersuffixlabel);
                LabelList.Add(citylabel);
                LabelList.Add(postalcodeLabel);
                LabelList.Add(emailLabel);
                LabelList.Add(phonenumberLabel);
                LabelList.Add(startdateLabel);
                LabelList.Add(enddateLabel);
                LabelList.Add(AmountofKilometerLabel);
                LabelList.Add(pickupCityLabel);
                LabelList.Add(pickupstreetnameLabel);
                LabelList.Add(pickupstreetnumberLabel);
                LabelList.Add(pickupstreetnumbersuffixLabel);

                //Add RegEx to List
                RegExList.Add(firstnameRegEx);
                RegExList.Add(lastNameRegEx);
                RegExList.Add(ageRegEx);
                RegExList.Add(streetNameRegEx);
                RegExList.Add(streetNumberRegEx);
                RegExList.Add(streetNumberSuffixRegEx);
                RegExList.Add(cityRegEx);
                RegExList.Add(postalCodeRegEx);
                RegExList.Add(emailRegEx);
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
                InputList.Add(email);
                InputList.Add(phonenumber);
                InputList.Add(startdate);
                InputList.Add(enddate);
                InputList.Add(kilometres);
                InputList.Add(pickupcity);
                InputList.Add(pickupstreetname);
                InputList.Add(pickupstreetnumber);
                InputList.Add(pickupstreetnumbersuffix);

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
                if (IsValidEmail(email)) //Test if email is valid
                {
                    if (IsValidDate(Convert.ToDateTime(startdate), Convert.ToDateTime(enddate), bolddates, carHasReservation)) //check if the date is valid.
                    {
                        if (validinput == 17)
                            return true;
                        else
                            MessageBox.Show("Er ging iets fout. Controleer de gegevens in het rood.");
                        return false;
                    }
                    else
                    {
                        startdateLabel.ForeColor = Color.Red;
                        enddateLabel.ForeColor = Color.Red;
                        MessageBox.Show("Uw geselecteerde datum is niet correct!");
                        return false;
                    }
                }
                else
                {
                    emailLabel.ForeColor = Color.Red;
                    MessageBox.Show("Er ging iets fout. Controleer de gegevens in het rood.");
                    return false;
                }
            }
            return false;
        }
        private bool InsertIntoDatabase(int carID, int UserID, string startdate, string enddate, int kilometres, string pickupcity, string pickupstreetname, string pickupstreetnumber, string pickupstreetnumbersuffix, string comment)
        {
            int pickupstreetnumberint = 0;
            Reservation reservation = new Reservation();
            if (pickupstreetnumber == "")
            {
                pickupstreetnumberint = 0;
            }
            else
            {
                pickupstreetnumberint = Convert.ToInt32(pickupstreetnumber);
            }
            reservation.carID = carID;
            reservation.UserID = UserID;
            reservation.startdate = startdate;
            reservation.enddate = enddate;
            reservation.confirmed = false;
            reservation.kilometres = kilometres;
            reservation.pickupcity = pickupcity;
            reservation.pickupstreetname = pickupstreetname;
            reservation.pickupstreetnumber = pickupstreetnumberint;
            reservation.pickupstreetnumbersuffix = pickupstreetnumbersuffix;
            reservation.paid = false;
            reservation.comment = comment;

            DBConnect connection = new DBConnect();
            if (connection.InsertReservation(reservation) == true)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Wij kunnen uw bestelling momenteel niet verwerken. probeer het later opnieuw");
                return false;
            }
        }

        private bool SendEmail(int carID, string firstname, string lastname, string age, string streetname, string streetnumber, string streetnumbersuffix, string city, string postalcode, string email, string phonenumber, string startdate, string enddate, string kilometres, string pickupcity, string pickupstreetname, string pickupstreetnumber, string pickupstreetnumbersuffix, string comment)
        {
            try
            {
                int pickupstreetnumberint = 0;
                if (pickupstreetnumber == "")
                    pickupstreetnumberint = 0;
                else
                {
                    Convert.ToInt32(pickupstreetnumberint);
                }
                Util.Mail mail = new Util.Mail();
                mail.addTo(email);
                mail.addSubject("Aanvraag van " + qarsApplication.carList[carID].brand + " " + qarsApplication.carList[carID].model);
                mail.addBody(buildEmailBody(firstname, lastname, age, streetname, streetnumber, streetnumbersuffix, city, postalcode, email, phonenumber, startdate, enddate, kilometres, pickupcity, pickupstreetname, pickupstreetnumber, pickupstreetnumbersuffix, comment));
                mail.sendEmail();
            }
            catch (Exception)
            {
                MessageBox.Show("Wij konden u op dit moment geen email versturen. Neem alstublieft contact op met het bedrijf waarvan u de auto wilt huren");
                return false;
            }
            return true;
        }
        private List<String> createSpecInfo(List<Car> list, int carNumber)
        {//This is the "specificaties" part. It creates all the information and puts it in a list so it can be re used by BuildEmailBody()
            List<String> stringList = new List<String>();
            InfoModelLabel.Text = qarsApplication.carList[carNumber].brand + " " + qarsApplication.carList[carNumber].model;
            InfoModelYearLabel.Text = qarsApplication.carList[carNumber].modelyear.ToString();
            InfoStartPriceLabel.Text = "€ " + qarsApplication.carList[carNumber].startprice;
            InfoCategoryLabel.Text = qarsApplication.carList[carNumber].category;
            if (qarsApplication.carList[carNumber].automatic)
                InfoAutomaticLabel.Text = "Ja";
            if (qarsApplication.carList[carNumber].cruisecontrol)
                InfoCruiseControlLabel.Text = "Ja";
            if (qarsApplication.carList[carNumber].kilometres > -1)
                InfoKilometresLabel.Text = qarsApplication.carList[carNumber].kilometres.ToString();
            if (qarsApplication.carList[carNumber].horsepower > -1)
                InfoHorsePowerLabel.Text = qarsApplication.carList[carNumber].horsepower + " PK";
            if (qarsApplication.carList[carNumber].motdate != "")
                InfoMOTDateLabel.Text = qarsApplication.carList[carNumber].motdate;
            if (qarsApplication.carList[carNumber].storagespace > -1)
                InfoStorageSpaceLabel.Text = qarsApplication.carList[carNumber].storagespace + " Liter";

            stringList.Add(InfoAutomaticLabel.Text);
            stringList.Add(InfoCruiseControlLabel.Text);
            stringList.Add(InfoKilometresLabel.Text);
            stringList.Add(InfoHorsePowerLabel.Text);
            stringList.Add(InfoMOTDateLabel.Text);
            stringList.Add(InfoStorageSpaceLabel.Text);
            return stringList;
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
        private string buildEmailBody(string firstname, string lastname, string age, string streetname, string streetnumber, string streetnumbersuffix, string city, string postalcode, string email, string phonenumber, string startdate, string enddate, string kilometres, string pickupcity, string pickupstreetname, string pickupstreetnumber, string pickupstreetnumbersuffix, string comment)
        {
            int pickupstreetnumberint = 0;
            if (pickupstreetnumber == "")
                pickupstreetnumberint = 0;
            else
                Convert.ToInt32(pickupstreetnumberint);
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(String.Format("Beste meneer/mevrouw {0},", lastname));
            builder.AppendLine("\n");
            builder.AppendLine("bedankt voor uw bestelling bij Qars. Wij gaan proberen om uw verzoek zo snel mogelijk te verwerken.");
            builder.AppendLine("Zodra uw verzoek is goed gekeurd ontvangt u een bevestiging.");
            builder.AppendLine("\n");
            builder.AppendLine("Uw persoonlijke gegevens:");
            builder.AppendLine("\n");

            builder.AppendLine(String.Format("Voornaam:\t{0}", firstname));
            builder.AppendLine(String.Format("Achternaam:\t{0}", lastname));
            builder.AppendLine(String.Format("Leeftijd:\t{0}", age));
            builder.AppendLine(String.Format("Adres:\t\t{0} {1}{2}", streetname, streetnumber, streetnumbersuffix));
            builder.AppendLine(String.Format("Woonplaats:\t{0}", city));
            builder.AppendLine(String.Format("Postcode:\t{0}", postalcode));
            builder.AppendLine(String.Format("Email:\t\t{0}", email));
            builder.AppendLine(String.Format("Telefoon:\t{0}", phonenumber));
            builder.Append("\n");
            builder.AppendLine("De gegevens van uw gehuurde auto:");
            builder.AppendLine("\n");

            builder.AppendLine(String.Format("Model:\t\t{0} {1}", qarsApplication.carList[carID].brand, qarsApplication.carList[carID].model));
            builder.AppendLine(String.Format("Bouwjaar:\t{0}", qarsApplication.carList[carID].modelyear));
            builder.AppendLine(String.Format("Categorie:\t{0}", qarsApplication.carList[carID].category));

            for (int i = 0; i < emailspecinfo.Length; i++)
                builder.AppendLine(string.Format("{0}\t{1}", emailspecinfo[i], stringList[i]));

            builder.AppendLine("\n");
            builder.AppendLine("Voor meer gegevens over uw geselecteerde auto kunt u deze opzoeken in de Qars applicatie.");
            builder.AppendLine("\n");
            builder.AppendLine("De gegevens over de prijs: ");
            if (kilometres != "0")
                builder.AppendLine(String.Format("Startprijs:\t\t€ {0}", qarsApplication.carList[carID].startprice.ToString()));
            else
                builder.AppendLine(String.Format("Startprijs:\t€ {0}", qarsApplication.carList[carID].startprice.ToString()));
            if (kilometres == "0")
            {
                builder.AppendLine("Er moet onderling geregeld worden hoeveel u moet betalen voor het onbeperkt rijden. Maak hiervoor alstublieft een afspraak met het bedrijf.");
                builder.AppendLine("De contactgegevens kunt u vinden onderin de email");
            }
            else
                builder.AppendLine(string.Format("Prijs per Kilometer:\t€ {0}", qarsApplication.carList[carID].rentalprice.ToString()));

            builder.AppendLine("\n");
            builder.AppendLine("De gegevens over de huurperiode:");
            builder.AppendLine(String.Format("Begin van de huurperiode:\t{0}", startdate));
            builder.AppendLine(String.Format("Einde van de huurperiode:\t{0}", enddate));
            builder.AppendLine("\n");
            if (pickupcity != "" && pickupstreetname != "" && pickupstreetnumberint != 0)
            {
                builder.AppendLine(String.Format("De auto zal op {0} worden opgehaald op het volgende adres:", enddate));
                builder.AppendLine(pickupstreetname + " " + pickupstreetnumber + pickupstreetnumbersuffix + " te " + pickupcity);
            }
            else
                builder.AppendLine(String.Format("Op {0} moet u de auto teruggebracht hebben bij het bedrijf waar u de auto gehuurd hebt.", enddate));

            builder.Append("\n");
            if (comment != "")
            {
                builder.AppendLine(String.Format("Opmerking: {0}", comment));
            }
            builder.Append("\n");
            builder.AppendLine("Met vriendelijke groeten,");
            builder.AppendLine("\n");
            builder.AppendLine("Qars");
            builder.AppendLine("\n");
            builder.AppendLine("Heeft u geen auto besteld of bent u helemaal geen klant, neem dan alstublieft contact op met:");

            foreach (var company in this.qarsApplication.EstablishmentList)
            {
                bool entryFound = false;
                if (entryFound == false)
                {
                    if (this.qarsApplication.carList[carID].establishmentID == company.establishmentID)
                    {
                        entryFound = true;
                        builder.AppendLine(company.name);
                        builder.AppendLine(company.streetname + " " + company.streetnumber.ToString() + company.streetnumbersuffix);
                        builder.AppendLine(company.postalcode + " " + company.city);
                        builder.AppendLine("Telefoonnummer: " + company.phonenumber);
                        builder.AppendLine("Emailadres: " + company.emailaddress);
                    }
                }
                else
                    break;
            }
            return builder.ToString();
        }
        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            ErrorStartDateLabel.Visible = false;
            ErrorEndDateLabel.Visible = false;
            startdateLabel.ForeColor = Color.Black;
            enddateLabel.ForeColor = Color.Black;
            if (startdateTextbox.Name == currentSelectedDateBox) //If the StartDate Calendar has been selected
            {
                startdate = monthCalendar.SelectionStart.Date; //the startdate is the selected date
                startdateTextbox.Text = returnStartDateToString(); //Fill the textbox with the date
                isDateReserved(startdate, enddate, bolddates, carHasReservation); //Check if the selected period is valid
                isStartDateBold(startdate, bolddates, carHasReservation); //Check if the date is a bold date

            }
            else if (enddateTextbox.Name == currentSelectedDateBox)//If the EndDate Calendar has been selected
            {
                enddate = monthCalendar.SelectionStart.Date; //The enddate is the selected date
                enddateTextbox.Text = returnEndDateToString(); //Fill the textbox with the date
                isEndDateBold(enddate, bolddates, carHasReservation);//Check if the selected period is valid
                isDateReserved(startdate, enddate, bolddates, carHasReservation);//Check if the date is a bold date
            }
        }
        private void openCalender(object sender, EventArgs e)
        {
            BoldDatesLabel.Text = " Dikgedrukte datums\r zijn niet beschikbaar";
            BoldDatesLabel.Visible = true;
            monthCalendar.MinDate = DateTime.Today; //The minimum date is today

            MaskedTextBox b = (MaskedTextBox)sender; //b is assigned to the textbox on which the user clicked
            currentSelectedDateBox = b.Name; //The program now knows if the calendar is used for the startdate or for the enddate

            if (startdateTextbox.Name == currentSelectedDateBox) //If the Startcalendar has to be opened
            {
                ChooseDateLabel.Text = "Kies een startdatum";
                ChooseDateLabel.Visible = true;
                startdateTextbox.Text = returnStartDateToString(); //Fill the date with the startdate

                isStartDateBold(startdate, bolddates, carHasReservation); //Check if the selected date is a bold date

                if (amountEndDateOpened > 0) //If the enddate calendar has been opened
                {
                    monthCalendar.MaxDate = enddate; //the maximum date is the end date
                    isDateReserved(startdate, enddate, bolddates, carHasReservation); //Check if the selected date is reserved
                }
                enddateTextbox.Enabled = true;
            }
            else if (enddateTextbox.Name == currentSelectedDateBox) //If the EndCalendar has to be opened
            {
                ChooseDateLabel.Text = "Kies een einddatum";
                ChooseDateLabel.Visible = true;
                monthCalendar.MaxDate = DateTime.Today.AddYears(1);  //The maximum date is the maximum value a DateTime object can hold
                amountEndDateOpened += 1;

                if (amountEndDateOpened == 1) //If the enddate calendar has been opened for the first time, it must be the same as the startdate
                    enddate = startdate;
                enddateTextbox.Text = returnEndDateToString(); //The textbox is filled with the selected date
                monthCalendar.MinDate = startdate; //The minimum date is startdate

                isEndDateBold(enddate, bolddates, carHasReservation); //Check if the enddate is bold
                isDateReserved(startdate, enddate, bolddates, carHasReservation); //Check if the selected period has a reservation
            }
            bolddates = monthCalendar.BoldedDates; //Just in case, get all the bolddates and update the calendar
            monthCalendar.UpdateBoldedDates();
            monthCalendar.Show(); //Show the calendar
        }
        private void closeCalender(object sender, EventArgs e) //occurs when a date is selected
        {
            monthCalendar.Hide();
            ChooseDateLabel.Visible = false;
            BoldDatesLabel.Visible = false;

        }
        private void rentCarClick(object sender, EventArgs e)
        {
            string kilometres = "0";
            if (KilometerTextBox.Text == "" && UnlimitedKilometresCheckBox.Checked)
            {
                kilometres = "0";
            }
            else
            {
                kilometres = KilometerTextBox.Text;
            }

            try
            {
                if (carHasReservation)
                {
                    getReservations();
                }
            }
            catch (Exception) //All reservations have dissapeared
            {
                carHasReservation = false;
            }

            bool validateResult = false;
            bool databaseResult = false;
            bool emailResult = false;

            validateResult = ValidateInput(firstnameTextbox.Text, lastnameTextbox.Text, ageTextBox.Text, streetnameTextbox.Text, streetnumberTextbox.Text, streetnumbersuffixTextbox.Text, cityTextbox.Text, PostalCodeTextBox.Text, emailTextbox.Text, phonenumberTextbox.Text,
               startdateTextbox.Text, enddateTextbox.Text, kilometres, pickupCityTextbox.Text, pickupStreetNameTextbox.Text, pickupStreetnumberTextbox.Text, pickupStreetnumberSuffixTextbox.Text, commentTextbox.Text);

            if (validateResult == true)
                databaseResult = InsertIntoDatabase(carID, UserID, startdateTextbox.Text, enddateTextbox.Text, Convert.ToInt32(kilometres), pickupCityTextbox.Text, pickupStreetNameTextbox.Text, pickupStreetnumberTextbox.Text, pickupStreetnumberSuffixTextbox.Text, commentTextbox.Text);
            if (databaseResult == true)
                emailResult = SendEmail(carID, firstnameTextbox.Text, lastnameTextbox.Text, ageTextBox.Text, streetnameTextbox.Text, streetnumberTextbox.Text, streetnumbersuffixTextbox.Text, cityTextbox.Text, PostalCodeTextBox.Text, emailTextbox.Text, phonenumberTextbox.Text, startdateTextbox.Text, enddateTextbox.Text, kilometres, pickupCityTextbox.Text, pickupStreetNameTextbox.Text, pickupStreetnumberTextbox.Text, pickupStreetnumberSuffixTextbox.Text, commentTextbox.Text);
            if (emailResult == true)
                MessageBox.Show("U ontvangt z.s.m. een email met daarin uw reserveringsbewijs.");
        }
        private void closeRentCarPanel(object sender, EventArgs e)
        {
            this.Dispose();

        }
        private void WrongDate(int error)
        {
            startdateLabel.ForeColor = Color.Black;
            enddateLabel.ForeColor = Color.Black;

            if (error == 0) //wrong startdate error
            {
                startdateLabel.ForeColor = Color.Red;
                ErrorStartDateLabel.ForeColor = Color.Red;
                ErrorStartDateLabel.Text = "Deze startdatum is al gereserveerd!";
                ErrorEndDateLabel.Text = "";
                ErrorStartDateLabel.Visible = true;
            }
            if (error == 1) //wrong enddate error
            {
                enddateLabel.ForeColor = Color.Red;
                ErrorEndDateLabel.ForeColor = Color.Red;
                ErrorEndDateLabel.Text = "Deze einddatum is al gereserveerd!";
                ErrorEndDateLabel.Visible = true;
            }
            if (error == 2) //There's a bolddate in the chosen period
            {
                ErrorStartDateLabel.ForeColor = Color.Red;
                ErrorEndDateLabel.ForeColor = Color.Red;
                startdateLabel.ForeColor = Color.Red;
                enddateLabel.ForeColor = Color.Red;
                ErrorStartDateLabel.Text = "Tijdens uw geselecteerde periode";
                ErrorEndDateLabel.Text = " is er al een reservering geplaatst!";
                ErrorStartDateLabel.Visible = true;
                ErrorEndDateLabel.Visible = true;
            }
        }
        private void getReservations()
        {
            foreach (var item in qarsApplication.reservationList) //Loop through all the reservations
            {
                if (carID == item.carID && item.confirmed) //If there is a reservation for the current car
                {
                    carHasReservation = true;
                    DateTime startDate = Convert.ToDateTime(item.startdate);
                    DateTime endDate = Convert.ToDateTime(item.enddate);

                    TimeSpan ts = endDate - startDate;
                    int differenceInDays = ts.Days;

                    for (int i = 1; i <= differenceInDays; i++) //For all the days the reservation has, make them bold in the calendar
                    {
                        monthCalendar.AddBoldedDate(startDate.AddDays(i));
                        if (i == differenceInDays) //There has to be a 1 day gap between reservations, this makes sure this shows up
                            monthCalendar.RemoveBoldedDate(startDate.AddDays(i + 1));
                    }
                    bolddates = monthCalendar.BoldedDates;
                }
            }
        }
        public void checkLogin(int UserID)//Called in CarDetailPanel
        {
            if (UserID != 0) //If User is logged in
            {

                firstnameTextbox.Text = qarsApplication.customerList[UserID].firstname;
                firstnameTextbox.Enabled = false;
                lastnameTextbox.Text = qarsApplication.customerList[UserID].lastname;
                lastnameTextbox.Enabled = false;
                ageTextBox.Text = qarsApplication.customerList[UserID].age.ToString();
                ageTextBox.Enabled = false;
                streetnameTextbox.Text = qarsApplication.customerList[UserID].streetname.ToString();
                streetnameTextbox.Enabled = false;
                streetnumberTextbox.Text = qarsApplication.customerList[UserID].streetnumber.ToString();
                streetnumberTextbox.Enabled = false;
                streetnumbersuffixTextbox.Text = qarsApplication.customerList[UserID].streetnumbersuffix;
                streetnumbersuffixTextbox.Enabled = false;
                cityTextbox.Text = qarsApplication.customerList[UserID].city;
                cityTextbox.Enabled = false;
                PostalCodeTextBox.Text = qarsApplication.customerList[UserID].postalcode;
                PostalCodeTextBox.Enabled = false;
                emailTextbox.Text = qarsApplication.customerList[UserID].emailaddress;
                emailTextbox.Enabled = false;
                phonenumberTextbox.Text = qarsApplication.customerList[UserID].phonenumber;
                phonenumberTextbox.Enabled = false;
            }
        }
        private bool IsValidDate(DateTime startdate, DateTime enddate, DateTime[] bolddates, bool carHasReservation)
        {
            bool validDate = true;

            bool startdatebold = isStartDateBold(startdate, bolddates, carHasReservation);
            bool enddatebold = isEndDateBold(enddate, bolddates, carHasReservation);
            bool dateisbold = isDateReserved(startdate, enddate, bolddates, carHasReservation);
            if (startdatebold == true || enddatebold == true || dateisbold == true)
                validDate = false;

            if (validDate == false)
            {
                startdateLabel.ForeColor = Color.Red;
                enddateLabel.ForeColor = Color.Red;
                return false;
            }
            else
                return true;
        }
        private bool isStartDateBold(DateTime startdate, DateTime[] bolddates, bool carHasReservation)
        {
            if (carHasReservation == true)
            {
                foreach (var bolddate in bolddates) //loop through all the bolddates
                {
                    if (startdate == bolddate) //if the startdate is a bolded date
                    {
                        WrongDate(0);
                        return true;
                    }
                }
                return false;
            }
            else
                return false;
        }
        private bool isDateReserved(DateTime startdate, DateTime enddate, DateTime[] bolddates, bool carHasReservation)
        {
            if (carHasReservation == true)
            {
                TimeSpan tisp = enddate - startdate;
                int dateDiffer = tisp.Days;
                for (int i = 0; i <= dateDiffer; i++)
                {
                    foreach (var bolddate in bolddates)
                    {
                        if (startdate.AddDays(i) == bolddate)
                        {
                            WrongDate(2);
                            return true;
                        }
                    }
                }
                return false;
            }
            else
                return false;
        }
        private bool isEndDateBold(DateTime enddate, DateTime[] bolddates, bool carHasReservation)
        {
            if (carHasReservation == true) //If there is a reservation
            {
                foreach (var bolddate in bolddates)//loop through all bolded dates
                {
                    if (enddate == bolddate)//if the enddate is a bolded date
                    {
                        WrongDate(1);
                        return true;
                    }
                }
                return false;
            }
            else
                return false;
        }
        private string returnStartDateToString()
        {
            String day = startdate.Day.ToString();
            String month = startdate.Month.ToString();
            String year = startdate.Year.ToString();

            if (day.Length == 1) //part of the stringbuilder
                day = "0" + day;
            if (month.Length == 1) //part of the stringbuilder
                month = "0" + month;
            return day + "-" + month + "-" + year;
        }
        private string returnEndDateToString()
        {
            String day = enddate.Day.ToString();
            String month = enddate.Month.ToString();
            String year = enddate.Year.ToString();

            if (day.Length == 1) //part of the stringbuilder
                day = "0" + day;
            if (month.Length == 1) //part of the stringbuilder
                month = "0" + month;
            return day + "-" + month + "-" + year;
        }

        private void UnlimitedKilometresCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (UnlimitedKilometresCheckBox.Checked)
            {
                KilometerTextBox.Enabled = false;
                KilometerTextBox.Text = "";
            }
            else
            {
                KilometerTextBox.Enabled = true;
                KilometerTextBox.Text = "";
            }
        }
    }
}