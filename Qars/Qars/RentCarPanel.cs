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
        public int carnumber { get; set; }
        public int countlabel = 0;
        private String currentSelectedDateBox;
        bool secondDateChecked;
        DateTime startdatum;
        DateTime einddatum;
        bool reservationCollision = false;
        bool firstMessage = false;
        private VisualDemo qarsApplication;
        public RentCarPanel(int carnumber, VisualDemo qarsApp)
        {
            this.qarsApplication = qarsApp;
            InitializeComponent();
            this.carnumber = carnumber;
            fillCarInfoPanel();
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
                if (carnumber == item.carID && item.confirmed) //Check if there is a reservation for the current car
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

            //////if (bolddates.Contains(monthCalendar.MinDate))
            //////{
            //////    MessageBox.Show("Deze al geselecteerde datum: " + monthCalendar.MinDate.ToShortDateString() + " is al in gebruik! Zoek een andere datum.");
            //////}
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
                Models.Reservation2 reservation = new Models.Reservation2(firstnameTextbox.Text, lastnameTextbox.Text, streetnameTextbox.Text, streetnumber, streetnumbersuffixTextbox.Text, postalcodeTextbox.Text, cityTextbox.Text, email, phonenumberTextbox.Text, startdateTextbox.Text, enddateTextbox.Text, commentTextbox.Text);
                //Models.Customer customer = new Customer(Insert everything BUT the comment, startdate and enddate here!)

                //This creates the email
                Util.Mail mail = new Util.Mail();
                mail.addTo(emailTextbox.Text);
                mail.addSubject("Aanvraag van Audi A4");
                mail.addBody(buildEmailBody());
                /*
                //insert the reservation in the database
                DBConnect connection = new DBConnect();
                connection.insertReservation(reservation);
                */
                //The email can only be send when the insert function succeed
                mail.sendEmail();

                MessageBox.Show("Er is email verstuurd met daarin uw gegevens");
            }

            catch (DbException)
            {
                MessageBox.Show("Fout tijdens het verwerken van uw aanvraag");
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
            if (radioYesButton.Checked == true)
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

        private string buildEmailBody()
        {
            StringBuilder builder = new StringBuilder();
            //This part can be edited by the admin
            builder.AppendLine(String.Format("Beste meneer/mevrouw {0}", lastnameTextbox.Text));
            builder.AppendLine("");
            builder.AppendLine("Bedank voor uw bestelling bij Qars. Wij gaan proberen om uw verzoek zo snel");
            builder.AppendLine("mogelijk te verwerken. Zodra uw verzoek is goed gekeurd ontvangt u een bestiging");
            builder.AppendLine("");

            builder.AppendLine(String.Format("Voornaam:\t{0}", firstnameTextbox.Text));
            builder.AppendLine(String.Format("Achternaam:\t{0}", lastnameTextbox.Text));
            builder.AppendLine(String.Format("Adres:\t\t{0} {1}{2}", streetnameTextbox.Text, streetnumberTextbox.Text, streetnumbersuffixTextbox.Text));
            builder.AppendLine(String.Format("Woonplaats:\t{0}", cityTextbox.Text));
            builder.AppendLine(String.Format("Postcode:\t{0}", postalcodeTextbox.Text));
            builder.AppendLine(String.Format("Email:\t\t{0}", emailTextbox.Text));
            builder.AppendLine(String.Format("Telefoon:\t{0}", phonenumberTextbox.Text));
            builder.Append("\n");
            builder.AppendLine(String.Format("Begin datum:\t{0}", startdateTextbox.Text));
            builder.AppendLine(String.Format("Eind datum:\t{0}", enddateTextbox.Text));
            builder.Append("\n");
            builder.AppendLine("Opmerking:");
            builder.AppendLine(commentTextbox.Text);

            //this part can be edited by the admin
            builder.Append("\n\n");
            builder.AppendLine("Met vriendelijke groeten,");
            builder.AppendLine("");
            builder.AppendLine("Qars");

            return builder.ToString();
        }

        private void closeRentCarPanel(object sender, EventArgs e)
        {
            this.Visible = !this.Visible;
        }

        public void fillCarInfoPanel()
        {

            //this.qarsApplication.carList[carnumber].(info);
            ModelLabel.Text = "Model:";
            CategoryLabel.Text = "Categorie:";
            YearOfBuildLabel.Text = "Bouwjaar:";
            KilometerLabel.Text = "Kilometer:";
            PKLabel.Text = "Pk:";
            SpaceLabel.Text = "Ruimte:";
            AutoLabel.Text = "Automaat:";
            label5.Text = "";
            label2.Text = "";
            //label9.Text = "";
            //label4.Text = "";
            //label6.Text = "";


            List<Label> Labels = new List<Label>();        //maak formule met deze gegevens! (boven in staat de formule zo'n beetje)
            Labels.Add(label2);
            Labels.Add(label4);
            Labels.Add(label5);
            Labels.Add(label6);
            Labels.Add(label7);
            Labels.Add(label8);
            Labels.Add(label9);
            Labels.Add(label10);
            Labels.Add(label12);

            foreach (var label in Labels)
            {
                if (label.Text.Contains("-1"))    //|| label.Text.Contains("N.V.T")   kan er pas in wanneer de gegevens van de lijst komen...
                {
                    label.Text = "";
                }
            }

            int mover;
            int mover2;
            int mover3;
            int mover4;
            int mover5;
            int mover6;
            int mover7;
            int mover8;
            int mover9;

            int moverTop;
            int moverTop2;
            int moverTop3;
            int moverTop4;
            int moverTop5;
            int moverTop6;
            int moverTop7;
            int moverTop8;
            int moverTop9;

            if (label2.Text == "")
            {
                ModelLabel.Visible = false;
                label2.Visible = false;
                mover = label2.Top;
                mover2 = label4.Top;
                mover3 = label5.Top;
                mover4 = label6.Top;
                mover5 = label7.Top;
                mover6 = label8.Top;
                mover7 = label9.Top;
                mover8 = label10.Top;


                label4.Top = mover;
                label5.Top = mover2;
                label6.Top = mover3;
                label7.Top = mover4;
                label8.Top = mover5;
                label9.Top = mover6;
                label10.Top = mover7;
                label12.Top = mover8;

                moverTop = ModelLabel.Top;
                moverTop2 = SellingspriceLabel.Top;
                moverTop3 = CategoryLabel.Top;
                moverTop4 = YearOfBuildLabel.Top;
                moverTop5 = AutoLabel.Top;
                moverTop6 = KilometerLabel.Top;
                moverTop7 = PKLabel.Top;
                moverTop8 = ApkLabel.Top;

                SellingspriceLabel.Top = moverTop;
                CategoryLabel.Top = moverTop2;
                YearOfBuildLabel.Top = moverTop3;
                AutoLabel.Top = moverTop4;
                KilometerLabel.Top = moverTop5;
                PKLabel.Top = moverTop6;
                ApkLabel.Top = moverTop7;
                SpaceLabel.Top = moverTop8;
            }
            if (label4.Text == "")
            {
                SellingspriceLabel.Visible = false;
                label4.Visible = false;

                mover2 = label4.Top;
                mover3 = label5.Top;
                mover4 = label6.Top;
                mover5 = label7.Top;
                mover6 = label8.Top;
                mover7 = label9.Top;
                mover8 = label10.Top;

                label5.Top = mover2;
                label6.Top = mover3;
                label7.Top = mover4;
                label8.Top = mover5;
                label9.Top = mover6;
                label10.Top = mover7;
                label12.Top = mover8;

                moverTop2 = SellingspriceLabel.Top;
                moverTop3 = CategoryLabel.Top;
                moverTop4 = YearOfBuildLabel.Top;
                moverTop5 = AutoLabel.Top;
                moverTop6 = KilometerLabel.Top;
                moverTop7 = PKLabel.Top;
                moverTop8 = ApkLabel.Top;

                CategoryLabel.Top = moverTop2;
                YearOfBuildLabel.Top = moverTop3;
                AutoLabel.Top = moverTop4;
                KilometerLabel.Top = moverTop5;
                PKLabel.Top = moverTop6;
                ApkLabel.Top = moverTop7;
                SpaceLabel.Top = moverTop8;

            }
            if (label5.Text == "")
            {
                CategoryLabel.Visible = false;
                label5.Visible = false;

                mover3 = label5.Top;
                mover4 = label6.Top;
                mover5 = label7.Top;
                mover6 = label8.Top;
                mover7 = label9.Top;
                mover8 = label10.Top;

                label6.Top = mover3;
                label7.Top = mover4;
                label8.Top = mover5;
                label9.Top = mover6;
                label10.Top = mover7;
                label12.Top = mover8;

                moverTop3 = CategoryLabel.Top;
                moverTop4 = YearOfBuildLabel.Top;
                moverTop5 = AutoLabel.Top;
                moverTop6 = KilometerLabel.Top;
                moverTop7 = PKLabel.Top;
                moverTop8 = ApkLabel.Top;
                moverTop9 = SpaceLabel.Top;

                YearOfBuildLabel.Top = moverTop3;
                AutoLabel.Top = moverTop4;
                KilometerLabel.Top = moverTop5;
                PKLabel.Top = moverTop6;
                ApkLabel.Top = moverTop7;
                SpaceLabel.Top = moverTop8;
            }
            if (label6.Text == "")
            {
                YearOfBuildLabel.Visible = false;
                label6.Visible = false;

                mover4 = label6.Top;
                mover5 = label7.Top;
                mover6 = label8.Top;
                mover7 = label9.Top;
                mover8 = label10.Top;

                label7.Top = mover4;
                label8.Top = mover5;
                label9.Top = mover6;
                label10.Top = mover7;
                label12.Top = mover8;

                moverTop4 = YearOfBuildLabel.Top;
                moverTop5 = AutoLabel.Top;
                moverTop6 = KilometerLabel.Top;
                moverTop7 = PKLabel.Top;
                moverTop8 = ApkLabel.Top;

                AutoLabel.Top = moverTop4;
                KilometerLabel.Top = moverTop5;
                PKLabel.Top = moverTop6;
                ApkLabel.Top = moverTop7;
                SpaceLabel.Top = moverTop8;
            }
            if (label7.Text == "")
            {
                AutoLabel.Visible = false;
                label7.Visible = false;

                mover4 = label6.Top;
                mover5 = label7.Top;
                mover6 = label8.Top;
                mover7 = label9.Top;
                mover8 = label10.Top;

                label7.Top = mover4;
                label8.Top = mover5;
                label9.Top = mover6;
                label10.Top = mover7;
                label12.Top = mover8;

                moverTop5 = AutoLabel.Top;
                moverTop6 = KilometerLabel.Top;
                moverTop7 = PKLabel.Top;
                moverTop8 = ApkLabel.Top;

                KilometerLabel.Top = moverTop5;
                PKLabel.Top = moverTop6;
                ApkLabel.Top = moverTop7;
                SpaceLabel.Top = moverTop8;
            }
            if (label8.Text == "")
            {
                KilometerLabel.Visible = false;
                label8.Visible = false;

                mover5 = label7.Top;
                mover6 = label8.Top;
                mover7 = label9.Top;
                mover8 = label10.Top;

                label8.Top = mover5;
                label9.Top = mover6;
                label10.Top = mover7;
                label12.Top = mover8;

                moverTop6 = KilometerLabel.Top;
                moverTop7 = PKLabel.Top;
                moverTop8 = ApkLabel.Top;

                PKLabel.Top = moverTop6;
                ApkLabel.Top = moverTop7;
                SpaceLabel.Top = moverTop8;
            }
            if (label9.Text == "")
            {
                PKLabel.Visible = false;
                label9.Visible = false;

                mover6 = label8.Top;
                mover7 = label9.Top;
                mover8 = label10.Top;

                label9.Top = mover6;
                label10.Top = mover7;
                label12.Top = mover8;


                moverTop7 = PKLabel.Top;
                moverTop8 = ApkLabel.Top;

                ApkLabel.Top = moverTop7;
                SpaceLabel.Top = moverTop8;
            }
            if (label10.Text == "")
            {
                ApkLabel.Visible = false;
                label10.Visible = false;

                mover7 = label9.Top;
                mover8 = label10.Top;

                label10.Top = mover7;
                label12.Top = mover8;

                moverTop8 = ApkLabel.Top;

                SpaceLabel.Top = moverTop8;
            }
            if (label12.Text == "")
            {
                SpaceLabel.Visible = false;
                label12.Visible = false;

                mover8 = label10.Top;

                label12.Top = mover8;

                //moverTop8 = ApkLabel.Top;

                //SpaceLabel.Top = moverTop8;
            }


            label2.Text = this.qarsApplication.carList[carnumber].brand + " " + this.qarsApplication.carList[carnumber].model;
            //label4 (?)
            label5.Text = this.qarsApplication.carList[carnumber].category;
            label6.Text = this.qarsApplication.carList[carnumber].modelyear.ToString();
            label7.Text = this.qarsApplication.carList[carnumber].automatic.ToString();
            label8.Text = this.qarsApplication.carList[carnumber].kilometres.ToString();
            label9.Text = this.qarsApplication.carList[carnumber].horsepower.ToString();  //deze 

            if (this.qarsApplication.carList[carnumber].automatic)
            {
                label7.Text = "Ja";

            }
            else
            {
                label7.Text = "Nee";
            }
            label10.Text = this.qarsApplication.carList[carnumber].motdate;
            label12.Text = this.qarsApplication.carList[carnumber].storagespace.ToString() + " Liter";
        }



        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void radioYesButton_CheckedChanged(object sender, EventArgs e)
        {
            pickupCityTextbox.BackColor = TextBox.DefaultBackColor;
            pickupCityTextbox.ReadOnly = false;

            pickupStreetTextbox.BackColor = TextBox.DefaultBackColor;
            pickupStreetTextbox.ReadOnly = false;

            pickupStreetnumberTextbox.BackColor = TextBox.DefaultBackColor;
            pickupStreetnumberTextbox.ReadOnly = false;

            pickupStreetnumberSuffixTextbox.BackColor = TextBox.DefaultBackColor;
            pickupStreetnumberSuffixTextbox.ReadOnly = false;
        }

        private void radioNoButton_CheckedChanged(object sender, EventArgs e)
        {
            pickupCityTextbox.BackColor = Color.Gray;
            pickupCityTextbox.ReadOnly = true;

            pickupStreetTextbox.BackColor = Color.Gray;
            pickupStreetTextbox.ReadOnly = true;

            pickupStreetnumberTextbox.BackColor = Color.Gray;
            pickupStreetnumberTextbox.ReadOnly = true;

            pickupStreetnumberSuffixTextbox.BackColor = Color.Gray;
            pickupStreetnumberSuffixTextbox.ReadOnly = true;
        }
    }
}

