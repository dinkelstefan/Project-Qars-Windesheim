using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qars
{
    public partial class RentCarPanel : UserControl
    {
        public int carnumber { get; set; }
        private String currentSelectedDateBox;
        public RentCarPanel(int carnumber)
        {
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
            }
            else if (enddateTextbox.Name == currentSelectedDateBox)
            {
                enddateTextbox.Text = date;
            }


        }

        private void openCalender(object sender, EventArgs e)
        {
            monthCalendar.MinDate = DateTime.Today;
            monthCalendar.Show();
            MaskedTextBox b = (MaskedTextBox)sender;
            currentSelectedDateBox = b.Name;

        }

        private void closeCalender(object sender, EventArgs e)
        {
            monthCalendar.Hide();

            if (currentSelectedDateBox == startdateTextbox.Name)
            {
                monthCalendar.MinDate = monthCalendar.SelectionStart.Date;
            }
        }

        private void rentCarClick(object sender, EventArgs e)
        {
            Util.Mail mail = new Util.Mail();
            //some variables that needs to be checked
            try
            {
                int streetnumber = Convert.ToInt32(streetnumberTextbox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Uw huisnummer klopt niet");
            }

            try
            { //check if emailaddress is valid
                MailAddress email = new MailAddress(emailTextbox.Text);
                mail.addTo(emailTextbox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Geen geldig emailadres");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("U heeft geen emailadres ingevuld");
            }

            MailAddress emailaddress = new MailAddress(emailTextbox.Text);
            Models.Reservation reservation = new Models.Reservation(firstnameTextbox.Text, lastnameTextbox.Text, streetnameTextbox.Text, Convert.ToInt32(streetnumberTextbox.Text), streetnumbersuffixTextbox.Text, postalcodeTextbox.Text, cityTextbox.Text, emailaddress, phonenumberTextbox.Text, startdateTextbox.Text, enddateTextbox.Text, commentTextbox.Text);

            DBConnect connection = new DBConnect();

            try
            {
                mail.addSubject("Aanvraag van Audi A4");
                mail.addBody(buildEmailBody());
                //connection.insertReservation(reservation);
                mail.sendEmail();

                MessageBox.Show("Er is email verstuurd met daarin uw gegevens");
            }
            catch (Exception)
            {
                MessageBox.Show("Fout tijdens het verwerken van uw aanvraag.");
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

            //Form1.cars[carnumber].(info);
            modelLabel.Text = "Model:";
            
            SellingspriceLabel.Text = "Verkoopprijs:";
            CategoryLabel.Text = "Categorie:";
            YearOfBuildLabel.Text = "Bouwjaar:";
            KilometerLabel.Text = "Kilometer:";
            PKLabel.Text = "Pk:";
            SpaceLabel.Text = "Ruimte:";

            label2.Text = Form1.cars[carnumber].brand + " " + Form1.cars[carnumber].model;
            label4.Text = Form1.cars[carnumber].sellingprice.ToString();
            label5.Text = Form1.cars[carnumber].category;
            label6.Text = Form1.cars[carnumber].modelyear;
            label8.Text = Form1.cars[carnumber].kilometres.ToString();
            label9.Text = Form1.cars[carnumber].horsepower.ToString();  //deze 
            label7.Text = Form1.cars[carnumber].automatic.ToString();
            if (label7.Text == "False")
            {
                label7.Text = "Nee";
            }
            else
            {
                label7.Text = "Ja";
            }
            label10.Text = Form1.cars[carnumber].motdate;
            label12.Text = Form1.cars[carnumber].storagespace.ToString() + "Liter";


        }
    }
}
