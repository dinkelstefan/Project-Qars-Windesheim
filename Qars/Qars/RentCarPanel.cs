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
        List<String> stringList;
        string[] emailspecinfo = { "Automaat:", "Cruise Control:", "Kilometers:", "Vermogen:", "APK Datum:", "Ruimte(in Liters):" };
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
        String startDateDay;
        String startDateMonth;
        String startDateYear;
        String fullStartDateString;
        String endDateDay;
        String endDateMonth;
        String endDateYear;
        String fullEndDateString;

        public RentCarPanel(int carID, int UserID, VisualDemo qarsApp)
        {
            this.UserID = UserID;
            this.qarsApplication = qarsApp;
            InitializeComponent();
            this.carID = carID;
            stringList = createSpecInfo(qarsApplication.carList, carID);
            getReservations();
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
         * Validate Calendar INPUT on Button_Click
         * */

        private void ValidateInput(string firstname, string lastname, string age, string streetname, string streetnumber, string streetnumbersuffix, string city, string postalcode, string email, string phonenumber, string startdate, string enddate, string kilometres, string pickupcity, string pickupstreetname, string pickupstreetnumber, string pickupstreetnumbersuffix, string comment)
        {

            List<Label> LabelList = new List<Label>();
            List<String> InputList = new List<String>();
            List<Regex> RegExList = new List<Regex>();
            int validinput = 0;

            Regex firstnameRegEx = new Regex("^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ]{1,46}$");
            Regex lastNameRegEx = new Regex("^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ]{1,100}$");
            Regex ageRegEx = new Regex("^[0-9]{1,3}$");
            Regex streetNameRegEx = new Regex("^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð  ]{1,95}$"); //(pickup)Streetname
            Regex streetNumberRegEx = new Regex("^[0-9]{1,5}$"); //(pickup)streetnumber
            Regex streetNumberSuffixRegEx = new Regex("^[a-zA-Z]{0,1}$");//(pickup)streetnumbersuffix
            Regex cityRegEx = new Regex(String.Format("^[a-zA-Z\\u0080-\\u024F\\s\\/\\-\\)\\(\\`\\.\\\"\\\']+$")); //(pickup)City
            Regex postalCodeRegEx = new Regex("^[0-9a-zA-Z ]{7}");
            Regex emailRegEx = new Regex("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            Regex phoneNumberRegEx = new Regex("^(\\s*|[0-9-+]{7,14})$");
            Regex dateRegEx = new Regex("^[0-9-]{10,10}$"); //startdate & enddate
            Regex kilometerRegEx = new Regex("^[0-9]{1,6}$");
            Regex pickupstreetNameRegEx = new Regex("^(\\s*|[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð\\D  ]{1,95})$"); //(pickup)Streetname
            Regex pickupstreetNumberRegEx = new Regex("^(\\s*|\\d{1,5})$"); //(pickup)streetnumber
            Regex pickupstreetNumberSuffixRegEx = new Regex("^(\\s*|[a-zA-Z])$");//(pickup)streetnumbersuffix
            Regex pickupcityRegEx = new Regex(String.Format("^(\\s*|[a-zA-Z\\u0080-\\u024F\\s\\/\\-\\)\\(\\`\\.\\\"\\']+)$")); //(pickup)City

            if (pickupcity != "" || pickupstreetname != "" || pickupstreetnumber != "" || pickupstreetnumbersuffix != "")
            {
                pickupcityRegEx = new Regex("^[a-zA-Z\\u0080-\\u024F\\s\\/\\-\\)\\(\\`\\.\\\"\\']+$");
                pickupstreetNameRegEx = new Regex("^([a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð\\D  ]{1,95})$"); //(pickup)Streetname
                pickupstreetNumberRegEx = new Regex("^\\d{1,5}$"); //(pickup)streetnumber
                pickupstreetNumberSuffixRegEx = new Regex("^[a-zA-Z]{0,1}$");//(pickup)streetnumbersuffix
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
            {
                item.ForeColor = Color.Black;
            }
            int counter = 0;
            //Validate input
            foreach (var item in RegExList) //Check regexes
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
                if (validinput == 17)
                {
                    InsertIntoDatabase(carID, /*UserID FIX FIX FIX THIS */ -1, startdate, enddate, Convert.ToInt32(kilometres), pickupcity, pickupstreetname, pickupstreetnumber, pickupstreetnumbersuffix, comment);
                    SendEmail(carID, firstname, lastname, age, streetname, streetnumber, streetnumbersuffix, city, postalcode, email, phonenumber, startdate, enddate, kilometres, pickupcity, pickupstreetname, pickupstreetnumber, pickupstreetnumbersuffix, comment);
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
        private void InsertIntoDatabase(int carID, int UserID, string startdate, string enddate, int kilometres, string pickupcity, string pickupstreetname, string pickupstreetnumber, string pickupstreetnumbersuffix, string comment)
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
            reservation.UserID = UserID; //CUSTOMER LOGGED IN NUMBER. FIX THIS LATER
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
            connection.InsertReservation(reservation);
        }
        private void SendEmail(int carID, string firstname, string lastname, string age, string streetname, string streetnumber, string streetnumbersuffix, string city, string postalcode, string email, string phonenumber, string startdate, string enddate, string kilometres, string pickupcity, string pickupstreetname, string pickupstreetnumber, string pickupstreetnumbersuffix, string comment)
        {
            int pickupstreetnumberint = 0;
            if (pickupstreetnumber == "")
            {
                pickupstreetnumberint = 0;
            }
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
        private List<String> createSpecInfo(List<Car> list, int carNumber)
        {
            List<String> stringList = new List<String>();
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
            else
            {
                InfoCruiseControlLabel.Text = "Nee";
            }
            if (qarsApplication.carList[carNumber].kilometres > -1)
            {
                InfoKilometresLabel.Text = qarsApplication.carList[carNumber].kilometres.ToString();
            }
            else
            {
                InfoKilometresLabel.Text = "N.V.T";
            }
            if (qarsApplication.carList[carNumber].horsepower > -1)
            {
                InfoHorsePowerLabel.Text = qarsApplication.carList[carNumber].horsepower + " PK";
            }
            else
            {
                InfoHorsePowerLabel.Text = "N.V.T";
            }
            if (qarsApplication.carList[carNumber].motdate != "")
            {
                InfoMOTDateLabel.Text = qarsApplication.carList[carNumber].motdate;
            }
            else
            {
                InfoMOTDateLabel.Text = "N.V.T";
            }
            if (qarsApplication.carList[carNumber].storagespace > -1)
            {
                InfoStorageSpaceLabel.Text = qarsApplication.carList[carNumber].storagespace + " Liter";
            }
            else
            {
                InfoStorageSpaceLabel.Text = "N.V.T";
            }
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
        private string buildEmailBody(string firstname, string lastname, string age, string streetname, string streetnumber, string streetnumbersuffix, string city, string postalcode, string email, string phonenumber, string startdate, string enddate, string kilometres, string pickupcity, string pickupstreetname, string pickupstreetnumber, string pickupstreetnumbersuffix, string comment)
        {
            int pickupstreetnumberint = 0;
            if (pickupstreetnumber == "")
            {
                pickupstreetnumberint = 0;
            }
            else
            {
                Convert.ToInt32(pickupstreetnumberint);
            }
            StringBuilder builder = new StringBuilder();
            //This part can be edited by the admin
            builder.AppendLine(String.Format("Beste meneer/mevrouw {0},", lastname));
            builder.AppendLine("");
            builder.AppendLine("bedankt voor uw bestelling bij Qars. Wij gaan proberen om uw verzoek zo snel mogelijk te verwerken.");
            builder.AppendLine("Zodra uw verzoek is goed gekeurd ontvangt u een bevestiging.");
            builder.AppendLine("");
            builder.AppendLine("Uw persoonlijke gegevens:");
            builder.AppendLine("");

            builder.AppendLine(String.Format("Voornaam:\t{0}", firstname));
            builder.AppendLine(String.Format("Achternaam:\t{0}", lastname));
            builder.AppendLine(String.Format("Leeftijd:\t{0}", age));
            builder.AppendLine(String.Format("Adres:\t{0} {1}{2}", streetname, streetnumber, streetnumbersuffix));
            builder.AppendLine(String.Format("Woonplaats:\t{0}", city));
            builder.AppendLine(String.Format("Postcode:\t{0}", postalcode));
            builder.AppendLine(String.Format("Email:\t{0}", email));
            builder.AppendLine(String.Format("Telefoon:\t{0}", phonenumber));
            builder.Append("\n");
            builder.AppendLine("De gegevens van uw gehuurde auto:");
            builder.AppendLine("");

            builder.AppendLine(String.Format("Model:\t{0} {1}", qarsApplication.carList[carID].model, qarsApplication.carList[carID].brand));
            builder.AppendLine(String.Format("Bouwjaar:\t{0}", qarsApplication.carList[carID].modelyear));
            builder.AppendLine(String.Format("Categorie:\t{0}", qarsApplication.carList[carID].category));

            for (int i = 0; i < emailspecinfo.Length; i++)
            {
                builder.AppendLine(string.Format("{0}\t{1}", emailspecinfo[i], stringList[i]));
            }
            builder.AppendLine("\n");
            builder.AppendLine("Voor meer gegevens over uw geselecteerde auto kunt u deze opzoeken in de Qars applicatie.");
            builder.AppendLine("\n");
            builder.AppendLine("De gegevens over de prijs: ");
            builder.AppendLine(String.Format("Startprijs:\t€ {0}", qarsApplication.carList[carID].startprice.ToString()));
            if (kilometres == "0")
            {
                builder.AppendLine("\n");
                builder.AppendLine("Er moet onderling geregeld worden hoeveel u moet betalen voor het onbeperkt rijden. Maak hiervoor alstublieft een afspraak met het bedrijf. De contactgegevens kunt u vinden onderin de email");
            }
            else
            {
                builder.AppendLine(string.Format("Prijs per Kilometer:\t€ {0}", qarsApplication.carList[carID].rentalprice.ToString()));
            }
            builder.AppendLine("\n");
            builder.AppendLine("De gegevens over de huurperiode:");
            builder.AppendLine("\n");
            builder.AppendLine(String.Format("Begin van de huurperiode:\t{0}", startdate));
            builder.AppendLine(String.Format("Einde van dehuurperiode:\t{0}", enddate));
            builder.AppendLine("\n");
            if (pickupcity != "" && pickupstreetname != "" && pickupstreetnumberint != 0)
            {
                builder.AppendLine(String.Format("De auto zal op {0} worden opgehaald op het volgende adres:", enddate));
                builder.AppendLine(pickupstreetname + " " + pickupstreetnumber + pickupstreetnumbersuffix + " te " + pickupcity);
            }
            else
            {
                builder.AppendLine(String.Format("Op {0} moet u de auto teruggebracht hebben bij het bedrijf waar u de auto gehuurd hebt.", enddate));
            }

            builder.Append("\n");
            if (comment != "")
            {
                builder.AppendLine("Opmerking:");
                builder.AppendLine(comment);
            }
            //TO DO: EDITABLE BY ADMIN
            builder.Append("\n\n");
            builder.AppendLine("Met vriendelijke groeten,");
            builder.AppendLine("");
            builder.AppendLine("Qars");
            //END Editable by Admin

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
                {
                    break;
                }
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
                startDateDay = monthCalendar.SelectionStart.Day.ToString();
                startDateMonth = monthCalendar.SelectionStart.Month.ToString();
                startDateYear = monthCalendar.SelectionStart.Year.ToString();
                if (startDateDay.Length == 1) //part of the stringbuilder
                {
                    startDateDay = "0" + startDateDay;
                }

                if (startDateMonth.Length == 1) //part of the stringbuilder
                {
                    startDateMonth = "0" + startDateMonth;
                }

                fullStartDateString = startDateDay + "-" + startDateMonth + "-" + startDateYear;//Date selected
                startdateTextbox.Text = fullStartDateString;
                startdate = monthCalendar.SelectionStart.Date;
                if (carHasReservation == true)
                {
                    TimeSpan tisp = enddate - startdate;
                    int dateDiffer = tisp.Days;
                    for (int i = 0; i <= dateDiffer; i++) //Tel dagen op. Elke dag kijken of dag bolded is. 
                    {
                        foreach (var bolddate in bolddates)
                        {
                            if (startdate.AddDays(i) == bolddate)
                            {
                                WrongDate(3);
                                break;
                            }
                        }
                    }
                }
                if (carHasReservation == true) //If there is a reservation
                {
                    foreach (var bolddate in bolddates)      //loop through all bolded dates
                    {
                        if (startdate == bolddate)//if the startdate is a bolded date
                        {
                            WrongDate(0); //give an error
                            break;
                        }
                    }
                }

            }
            else if (enddateTextbox.Name == currentSelectedDateBox)//If the EndDate Calendar has been selected
            {
                endDateDay = monthCalendar.SelectionStart.Day.ToString();
                endDateMonth = monthCalendar.SelectionStart.Month.ToString();
                endDateYear = monthCalendar.SelectionStart.Year.ToString();

                if (endDateDay.Length == 1) //part of the stringbuilder
                {
                    endDateDay = "0" + endDateDay;
                }

                if (endDateMonth.Length == 1) //part of the stringbuilder
                {
                    endDateMonth = "0" + endDateMonth;
                }

                fullEndDateString = endDateDay + "-" + endDateMonth + "-" + endDateYear; //Date selected
                enddateTextbox.Text = fullEndDateString;
                enddate = monthCalendar.SelectionStart.Date;

                if (carHasReservation == true) //If there is a reservation
                {
                    foreach (var bolddate in bolddates)      //loop through all bolded dates
                    {
                        if (enddate == bolddate)//if the enddate is a bolded date
                        {
                            WrongDate(1);
                            break;
                        }
                    }
                }
                if (carHasReservation == true)
                {
                    TimeSpan tisp = enddate - startdate;
                    int dateDiffer = tisp.Days;
                    for (int i = 0; i <= dateDiffer; i++) //Tel dagen op. Elke dag kijken of dag bolded is. 
                    {
                        foreach (var bolddate in bolddates)
                        {
                            if (startdate.AddDays(i) == bolddate)
                            {
                                WrongDate(3);
                                break;
                            }
                        }
                    }
                }

                if (enddate >= startdate) //If the date is correct
                {
                    if (enddateTextbox.Text == "  -  -" || startdateTextbox.Text == "  -  -")
                    {
                        WrongDate(2);
                    }
                }
            }
        }

        private void openCalender(object sender, EventArgs e)
        {
            monthCalendar.MinDate = DateTime.Today;
            MaskedTextBox b = (MaskedTextBox)sender;
            currentSelectedDateBox = b.Name;

            if (startdateTextbox.Name == currentSelectedDateBox) //startdatetextbox
            {
                ChooseDateLabel.Text = "Kies een startdatum";
                ChooseDateLabel.Visible = true;
                if (startdate.Day.ToString().Length == 1)
                {
                    startDateDay = "0" + startdate.Day;
                }
                else
                {
                    startDateDay = startdate.Day.ToString();
                }
                if (startdate.Month.ToString().Length == 1)
                {
                    startDateMonth = "0" + startdate.Month;
                }
                else
                {
                    startDateMonth = startdate.Month.ToString();
                }
                startDateYear = startdate.Year.ToString();

                fullStartDateString = startDateDay + "-" + startDateMonth + "-" + startDateYear;
                startdateTextbox.Text = fullStartDateString;

                if (carHasReservation == true)
                {
                    foreach (var item in bolddates)
                    {
                        if (startdate == item)
                        {
                            WrongDate(0);
                            break;
                        }
                    }
                }
                if (amountEndDateOpened > 0)
                {
                    monthCalendar.MaxDate = enddate;
                    if (carHasReservation == true)
                    {
                        TimeSpan tisp = enddate - startdate;
                        int dateDiffer = tisp.Days;
                        if (startdate <= enddate) //if the date is correct (Semi correct?)
                        {
                            for (int i = 0; i <= dateDiffer; i++) //Tel dagen op. Elke dag kijken of dag bolded is. 
                            {

                                foreach (var bolddate in bolddates)
                                {
                                    if (startdate.AddDays(i) == bolddate)
                                    {
                                        WrongDate(3);
                                        break;
                                    }

                                }
                            }
                        }
                    }
                }

                enddateTextbox.Enabled = true;
            }
            else if (enddateTextbox.Name == currentSelectedDateBox) //enddatetextbox
            {
                ChooseDateLabel.Text = "Kies een einddatum";
                ChooseDateLabel.Visible = true;
                DateTime MaxDate = DateTime.MaxValue;

                monthCalendar.MaxDate = MaxDate;
                amountEndDateOpened += 1;
                //als de einddatum voor de eerste keer open gaat moet de datum startdate zijn;
                if (amountEndDateOpened == 1)
                {
                    enddate = startdate;
                }
                if (enddate.Day.ToString().Length == 1)
                {
                    endDateDay = "0" + enddate.Day;
                }
                else
                {
                    endDateDay = enddate.Day.ToString();
                }
                if (enddate.Month.ToString().Length == 1)
                {
                    endDateMonth = "0" + enddate.Month;
                }
                else
                {
                    endDateMonth = enddate.Month.ToString();
                }
                endDateYear = enddate.Year.ToString();

                fullEndDateString = endDateDay + "-" + endDateMonth + "-" + endDateYear;
                enddateTextbox.Text = fullEndDateString;
                monthCalendar.MinDate = startdate;

                if (carHasReservation == true)
                {
                    foreach (var item in bolddates)
                    {
                        if (enddate == item) //If today is a bolddate
                        {
                            WrongDate(1);
                            break;
                        }
                    }
                }
                if (carHasReservation == true)
                {
                    TimeSpan tisp = enddate - startdate;
                    int dateDiffer = tisp.Days;
                    if (startdate <= enddate) //if the date is correct (Semi correct?)
                    {
                        for (int i = 0; i <= dateDiffer; i++) //Tel dagen op. Elke dag kijken of dag bolded is. 
                        {

                            foreach (var bolddate in bolddates)
                            {
                                if (startdate.AddDays(i) == bolddate)
                                {
                                    WrongDate(3);
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            bolddates = monthCalendar.BoldedDates;
            monthCalendar.UpdateBoldedDates();
            monthCalendar.Show();
        }

        private void closeCalender(object sender, EventArgs e) //occurs when a date is selected
        {
            ChooseDateLabel.ResetText();
            ChooseDateLabel.Visible = false;
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
            if (error == 2) //Enddate is sooner than the startdate
            {
                startdateLabel.ForeColor = Color.Red;
                enddateLabel.ForeColor = Color.Red;
                ErrorStartDateLabel.ForeColor = Color.Red;
                ErrorEndDateLabel.ForeColor = Color.Red;

                ErrorStartDateLabel.Text = "Uw geselecteerde huurperiode";
                ErrorEndDateLabel.Text = " is niet correct";
                ErrorStartDateLabel.Visible = true;
                ErrorEndDateLabel.Visible = true;
            }
            if (error == 3) //There's a bolddate in the chosen period
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
            foreach (var item in qarsApplication.reservationList)
            {
                if (carID == item.carID && item.confirmed)
                {
                    carHasReservation = true;
                    DateTime startDate = Convert.ToDateTime(item.startdate);
                    DateTime endDate = Convert.ToDateTime(item.enddate);

                    TimeSpan ts = endDate - startDate;
                    int differenceInDays = ts.Days;
                    for (int i = 1; i <= differenceInDays; i++)
                    {
                        monthCalendar.AddBoldedDate(startDate.AddDays(i));
                        //makes all dates between start and end bolded in calendar... 
                        if (i == differenceInDays)
                        {
                            monthCalendar.AddBoldedDate(startDate.AddDays(i + 1));  //makes the endDay after the end date of reservation bolded in calendar...
                        }
                    }
                    bolddates = monthCalendar.BoldedDates;
                }
            }
        }
        public bool checkLogin(int UserID)
        {
            if (UserID != -1) //If User is logged in
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
                postalcodeTextbox.Text = qarsApplication.customerList[UserID].postalcode;
                postalcodeTextbox.Enabled = false;
                emailTextbox.Text = qarsApplication.customerList[UserID].emailaddress;
                emailTextbox.Enabled = false;
                phonenumberTextbox.Text = qarsApplication.customerList[UserID].phonenumber;
                phonenumberTextbox.Enabled = false;
                return true;
            }
            else
            {
                LogInOrRegisterForm logInOrRegisterForm = new LogInOrRegisterForm();
                logInOrRegisterForm.ShowDialog();
                if (logInOrRegisterForm.DialogResult == DialogResult.Yes) //Login
                {
                    logInOrRegisterForm.Dispose();

                    /*LogInForm loginform = new LogInForm();
                     * loginform.Show();
                     */
                }
                else if (logInOrRegisterForm.DialogResult == DialogResult.Cancel) //Cancel
                {
                    logInOrRegisterForm.Dispose();

                }
                else if (logInOrRegisterForm.DialogResult == DialogResult.No) //Register
                {
                    logInOrRegisterForm.Dispose();

                    /*RegisterForm registerForm = new RegisterForm();
                     * registerForm.Show();
                   */
                }
                this.Dispose();
                return false;
            }
        }

    }
}


