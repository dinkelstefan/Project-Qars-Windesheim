using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
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
        private VisualDemo qarsApplication;
        public RentCarPanel(int carID, VisualDemo qarsApp)
        {
            this.qarsApplication = qarsApp;
            InitializeComponent();
            this.carID = carID;
            createSpecInfo(qarsApplication.carList, carID);
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
            }
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
                            //Console.WriteLine("Als datum tussen begin en eind overeenkomen met bolded dan true!");
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
            }
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
                    Console.WriteLine(ts);
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

            try
            {
                //little check if the input is valid
                int streetnumber = Convert.ToInt32(streetnumberTextbox.Text);
                MailAddress email = new MailAddress(emailTextbox.Text);

                //this has to become the new Reservation Class
                Reservation reservation = new Reservation();
                reservation.carID = carID;
                reservation.customerID = -1; //CUSTOMER LOGGED IN NUMBER
                reservation.startdate = startdateTextbox.Text;
                reservation.enddate = enddateTextbox.Text;
                reservation.confirmed = false;
                reservation.kilometres = Convert.ToInt32(KilometerTextBox.Text);
                reservation.pickupcity = pickupCityTextbox.Text;
                reservation.pickupstreetname = pickupStreetTextbox.Text;
                reservation.pickupstreetnumber = Convert.ToInt32(pickupStreetnumberTextbox.Text);
                reservation.pickupstreetnumbersuffix = pickupStreetnumberSuffixTextbox.Text;
                reservation.paid = false;
                reservation.comment = commentTextbox.Text;

                DBConnect connection = new DBConnect();
                connection.InsertReservation(reservation);
                //This creates the email
                Util.Mail mail = new Util.Mail();
                mail.addTo(emailTextbox.Text);
                mail.addSubject("Aanvraag van" + qarsApplication.carList[carID].brand + qarsApplication.carList[carID].model);
                mail.addBody(buildEmailBody(firstnameTextbox.Text, lastnameTextbox.Text, streetnameTextbox.Text, streetnumberTextbox.Text, streetnumbersuffixTextbox.Text, cityTextbox.Text, postalcodeTextbox.Text, emailTextbox.Text, phonenumberTextbox.Text, startdateTextbox.Text, enddateTextbox.Text, commentTextbox.Text));
                mail.sendEmail();

                MessageBox.Show("Er is email verstuurd met daarin uw gegevens");
            }

            catch (DbException dbe)
            {
                MessageBox.Show("Fout tijdens het verwerken van uw aanvraag\n" + dbe.HelpLink + dbe.Message);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("U heeft niet alle velden ingevuld");
            }
            catch (FormatException)
            {
                MessageBox.Show("U heeft geen geldig emailadres ingevuld");
            }
            catch (Exception)
            {
                MessageBox.Show("U heeft niet alle velden correct ingevuld");
            }
            Regex firstname = new Regex("^[a-zA-Z]{1,20}$");
            Regex lastname = new Regex("^[a-zA-Z]{1,20}$");
            Regex streetname = new Regex("^[a-zA-Z]{1,20}$");
            Regex streetNumber = new Regex("^[0-9]{1,3}$");
            Regex streetNumberSuffix = new Regex("^[a-zA-Z]{0,1}$");
            Regex city = new Regex("^[a-zA-Z]{1,20}$");
            Regex rxEmail = new Regex("^[a-zA-Z0-9]{1,20}@[a-zA-Z0-9]{1,20}.[a-zA-Z]{2,3}$");
            Regex pickupCity = new Regex("^[a-zA-Z]{1,20}$");
            Regex pickupStreet = new Regex("^[a-zA-Z]{1,20}$");
            Regex pickupStreetnumber = new Regex("^[0-9]{1,3}$");
            Regex pickupStreetnumberSuffix = new Regex("^[a-zA-Z]{0,1}$");


            if (!firstname.IsMatch(firstnameTextbox.Text))     //dit zou vervangen kunnen worden door switch... en try-catch kan weg?
            {
                MessageBox.Show("De opgegeven vooraam is niet correct!");
            }
            if (!lastname.IsMatch(lastnameTextbox.Text))
            {
                MessageBox.Show("De opgegeven achternaam is niet correct!");
            }
            if (!streetname.IsMatch(streetnameTextbox.Text))
            {
                MessageBox.Show("De opgegeven straat is niet correct!");
            }
            if (!streetNumber.IsMatch(streetnumberTextbox.Text))
            {
                MessageBox.Show("Het opgegeven straatnummer is niet correct!");
            }
            if (!streetNumberSuffix.IsMatch(streetnumbersuffixTextbox.Text))
            {
                MessageBox.Show("De opgegeven toevoeging van het straatnummer is niet correct!");
            }
            if (!city.IsMatch(cityTextbox.Text))
            {
                MessageBox.Show("De opgegeven woonplaats is niet correct!");
            }
            if (!rxEmail.IsMatch(emailTextbox.Text))
            {
                MessageBox.Show("De opgegeven email is niet correct!");
            }
            if (collectRadioButtonYes.Checked == true)
            {
                if (!pickupCity.IsMatch(pickupCityTextbox.Text))
                {
                    MessageBox.Show("De opgegeven plaats (voor afhalen) is niet correct!");
                }
                if (!pickupStreet.IsMatch(pickupStreetTextbox.Text))
                {
                    MessageBox.Show("De opgegeven straat (voor afhalen) is niet correct!");
                }
                if (!pickupStreetnumber.IsMatch(pickupStreetnumberTextbox.Text))
                {
                    MessageBox.Show("Het opgegeven straatnummer (voor afhalen) is niet correct!");
                }
                if (!pickupStreetnumberSuffix.IsMatch(pickupStreetnumberSuffixTextbox.Text))
                {
                    MessageBox.Show("De opgegeven toevoeging van het straatnummer (voor afhalen) is niet correct!");
                }
            }

        }
        private string buildEmailBody(string firstname, string lastname, string streetname, string streetnumber, string streetnumbersuffix, string city, string postalcode, string email, string phonenumber, string startdate, string enddate, string comment)
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
            builder.AppendLine(String.Format("Adres:\t\t{0} {1}{2}", streetname, streetnumber, streetnumbersuffix));
            builder.AppendLine(String.Format("Woonplaats:\t{0}", city));
            builder.AppendLine(String.Format("Postcode:\t{0}", postalcode));
            builder.AppendLine(String.Format("Email:\t\t{0}", email));
            builder.AppendLine(String.Format("Telefoon:\t{0}", phonenumber));
            builder.Append("\n");
            builder.AppendLine(String.Format("Begin datum:\t{0}", startdate));
            builder.AppendLine(String.Format("Eind datum:\t{0}", enddate));
            if (collectRadioButtonYes.Checked && pickupCityTextbox.Text != "" && pickupStreetnumberTextbox.Text != "" && pickupStreetnumberSuffixTextbox.Text != "")//If pickupstreetnumber(suffix).textbox.text = empty, text = "". 
            {
                builder.AppendLine(String.Format("De auto zal op {0} worden opgehaald op het volgende adres:"));
                if (streetnumbersuffixTextbox.Text != "")
                {
                    builder.AppendLine(String.Format(pickupStreetTextbox.Text + " " + pickupStreetnumberTextbox.Text + pickupStreetnumberSuffixTextbox.Text + " te " + pickupCityTextbox.Text));
                }
                else
                {
                    builder.AppendLine(String.Format(pickupStreetTextbox.Text + " " + pickupStreetnumberTextbox.Text + " te " + pickupCityTextbox.Text));
                }
            }
            builder.Append("\n");
            builder.AppendLine("Opmerking:");
            builder.AppendLine(comment);

            //this part can be edited by the admin
            builder.Append("\n\n");
            builder.AppendLine("Met vriendelijke groeten,");
            builder.AppendLine("");
            builder.AppendLine("Qars");

            return builder.ToString();
        }
        private void closeRentCarPanel(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void radioYesButton_CheckedChanged(object sender, EventArgs e)
        {
            pickupCityTextbox.BackColor = TextBox.DefaultBackColor;
            pickupCityTextbox.Enabled = !pickupCityTextbox.Enabled;

            pickupStreetTextbox.BackColor = TextBox.DefaultBackColor;
            pickupStreetTextbox.Enabled = !pickupStreetnumberTextbox.Enabled;

            pickupStreetnumberTextbox.BackColor = TextBox.DefaultBackColor;
            pickupStreetnumberTextbox.Enabled = !pickupStreetnumberTextbox.Enabled;

            pickupStreetnumberSuffixTextbox.BackColor = TextBox.DefaultBackColor;
            pickupStreetnumberSuffixTextbox.Enabled = !pickupStreetnumberSuffixTextbox.Enabled;
        }
        private void radioNoButton_CheckedChanged(object sender, EventArgs e)
        {
            pickupCityTextbox.BackColor = Color.Gray;
            pickupCityTextbox.Enabled = !pickupCityTextbox.Enabled;

            pickupStreetTextbox.BackColor = Color.Gray;
            pickupStreetTextbox.Enabled = !pickupStreetTextbox.Enabled;

            pickupStreetnumberTextbox.BackColor = Color.Gray;
            pickupStreetnumberTextbox.Enabled = !pickupStreetnumberTextbox.Enabled;

            pickupStreetnumberSuffixTextbox.BackColor = Color.Gray;
            pickupStreetnumberSuffixTextbox.Enabled = pickupStreetnumberSuffixTextbox.Enabled;
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

    }
}