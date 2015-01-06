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
using Qars.Util;

namespace Qars_Admin.EditPanels
{
    public partial class EditReservationWindow : Form
    {
        private DBConnect connect;
        private Reservation reservation;
        private bool confirmState;
        public EditReservationWindow(Reservation res, DBConnect connect)
        {
            InitializeComponent();
            try
            {
                this.connect = connect;
                this.reservation = res;
                this.startDateTextBox.Text = res.startdate;
                this.endDateTextBox.Text = res.enddate;
                this.confirmedCheckBox.Checked = res.confirmed;
                this.confirmState = res.confirmed;
                this.kilometersTextbox.Text = res.kilometres.ToString();
                this.cityTextBox.Text = res.pickupcity;
                this.streetnameTextBox.Text = res.pickupstreetname;
                this.streetnumberTextBox.Text = res.pickupstreetnumber.ToString();
                this.streetnumberSuffixTextBox.Text = res.pickupstreetnumbersuffix;
                this.paidCheckBox.Checked = res.paid;
                this.commentCheckBox.Text = res.comment;
            }
            catch (Exception e)
            {
                MessageBox.Show("Fout tijdens het laden van de reservering" + e);
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<User> userList = connect.SelectUsers();
                List<Car> carList = connect.SelectCar();
                Reservation res = this.getReservationFromFields();
                
                //Search for user by this reservation
                //var query = from u in userList
                //            where u.customerID == res.customerID
                //            select u;
                //User user = query.First();
                User user = userList[reservation.customerID];
                Car car = carList[reservation.carID];


                Console.WriteLine(user.firstname);

                //Build email when reservations is confirmed
                if ((reservation.confirmed != res.confirmed) && res.confirmed == true)
                {
                    Mail mail = new Mail();
                    mail.addTo(user.emailaddress);
                    mail.addSubject("Qars orderbevestiging: " + res.reservationID);
                    
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Beste " + user.firstname + ",\n");
                    sb.AppendLine("Uw order is zojuist bevestigd.\n");

                    sb.AppendLine("Ordernummber:\t" + res.reservationID);
                    sb.AppendLine("Merk:\t\t\t" + car.brand);
                    sb.AppendLine("Model:\t\t\t" + car.model);

                    sb.Append("\n");
                    sb.AppendLine("Begindatum:\t\t" + res.startdate);
                    sb.AppendLine("Einddatum:\t\t" + res.enddate);

                    sb.Append("\n\n");
                    sb.AppendLine("Met vriendelijke groeten,\n");
                    sb.AppendLine("Qars");
                    
                    mail.addBody(sb.ToString());
                    mail.sendEmail();
                    MessageBox.Show("Er is een email naar de klant gestuurd met een bevestiging van de reservering.");
                }

                this.connect.UpdateReservation(res);


                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Het format van de door u ingevulde tekst klopt niet.");
            }
        }

        private void delete_Button_Click(object sender, EventArgs e)
        {
            try
            {
                Reservation res = this.getReservationFromFields();

                this.connect.DeleteReservation(res);
                MessageBox.Show(string.Format("De reserving met reserveringnummer: {0} is verwijderd.", reservation.reservationID));
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Het format van de door u ingevulde tekst klopt niet.");
            }
        }

        private Reservation getReservationFromFields()
        {
            Reservation res = new Reservation();
            res.reservationID = this.reservation.reservationID;
            res.startdate = startDateTextBox.Text;
            res.enddate = endDateTextBox.Text;
            res.confirmed = confirmedCheckBox.Checked;
            res.kilometres = Int32.Parse(kilometersTextbox.Text);
            res.pickupcity = cityTextBox.Text;
            res.pickupstreetname = streetnameTextBox.Text;
            res.pickupstreetnumber = Int32.Parse(streetnumberTextBox.Text);
            res.pickupstreetnumbersuffix = streetnumberSuffixTextBox.Text;
            res.paid = paidCheckBox.Checked;
            res.comment = commentCheckBox.Text;

            return res;
        }

        private void TextBoxAlphabeticalChars_KeyPress(object sender, KeyEventArgs e)
        {
            if ((e.KeyData >= Keys.A && e.KeyData <= Keys.Z) || e.KeyData == Keys.Back || e.KeyData == Keys.Delete || e.KeyData == Keys.OemMinus)
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
            if ((e.KeyData >= Keys.D0 && e.KeyData <= Keys.D9) || (e.KeyData >= Keys.NumPad0 && e.KeyData <= Keys.NumPad9) || e.KeyData == Keys.OemMinus || e.KeyData == Keys.Back || e.KeyData == Keys.Delete)
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
            catch (Exception ex)
            {

            }
            textbox.Text = sb.ToString();
        }

    }
}
