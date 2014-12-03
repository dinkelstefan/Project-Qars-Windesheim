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

            try
            {
                //little check if the input is valid
                int streetnumber = Convert.ToInt32(streetnumberTextbox.Text);
                MailAddress email = new MailAddress(emailTextbox.Text);

                Models.Reservation reservation = new Models.Reservation(firstnameTextbox.Text, lastnameTextbox.Text, streetnameTextbox.Text, streetnumber, streetnumbersuffixTextbox.Text, postalcodeTextbox.Text, cityTextbox.Text, email, phonenumberTextbox.Text, startdateTextbox.Text, enddateTextbox.Text, commentTextbox.Text);

                //This creates the email
                Util.Mail mail = new Util.Mail();
                mail.addTo(emailTextbox.Text);
                mail.addSubject("Aanvraag van Audi A4");
                mail.addBody(buildEmailBody());

                //insert the reservation in the database
                DBConnect connection = new DBConnect();
                connection.insertReservation(reservation);

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

            //VisualDemo.carList[carnumber].(info);
            //modelLabel.Text = "Model:";       Delete?

            SellingspriceLabel.Text = "Verkoopprijs:";
            CategoryLabel.Text = "Categorie:";
            YearOfBuildLabel.Text = "Bouwjaar:";
            KilometerLabel.Text = "Kilometer:";
            PKLabel.Text = "Pk:";
            SpaceLabel.Text = "Ruimte:";

            label2.Text = VisualDemo.carList[carnumber].brand + " " + VisualDemo.carList[carnumber].model;
            label4.Text = VisualDemo.carList[carnumber].sellingprice.ToString();
            label5.Text = VisualDemo.carList[carnumber].category;
            label6.Text = VisualDemo.carList[carnumber].modelyear;
            label8.Text = VisualDemo.carList[carnumber].kilometres.ToString();
            label9.Text = VisualDemo.carList[carnumber].horsepower.ToString();  //deze 
            label7.Text = VisualDemo.carList[carnumber].automatic.ToString();
            if (label7.Text == "False")
            {
                label7.Text = "Nee";
            }
            else
            {
                label7.Text = "Ja";
            }
            label10.Text = VisualDemo.carList[carnumber].motdate;
            label12.Text = VisualDemo.carList[carnumber].storagespace.ToString() + " Liter";


        }
    }
}
