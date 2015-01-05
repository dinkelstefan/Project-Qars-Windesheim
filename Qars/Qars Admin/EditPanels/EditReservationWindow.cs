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

namespace Qars_Admin.EditPanels
{
    public partial class EditReservationWindow : Form
    {
        private DBConnect connect;
        private Reservation reservation;
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
            //try
            //{
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
                
                this.connect.UpdateReservation(res);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Het format van de door u ingevulde tekst klopt niet.");
            //}

            

            this.Close();
        }
    }
}
