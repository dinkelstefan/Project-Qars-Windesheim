using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Qars;
using Qars_Admin.EditPanels;

namespace Qars_Admin.Panels
{
    public partial class ReservationAdminPanel : UserControl
    {
        private DBConnect databaseConnection;
        private List<Reservation> reservationList = new List<Reservation>();

        public ReservationAdminPanel(DBConnect connection)
        {
            this.databaseConnection = connection;
            InitializeComponent();

            this.RefreshList();
            
        }

        public void RefreshList(){
            List<simpleReservation> simpleReservationList = new List<simpleReservation>();
            this.reservationList = databaseConnection.SelectReservation();
            foreach (Reservation res in this.reservationList)
            {
                simpleReservationList.Add(new simpleReservation(res.reservationID, res.carID, res.startdate, res.enddate, res.kilometres, res.pickupcity, res.pickupstreetname, res.pickupstreetnumber, res.paid, res.confirmed));
            }

            this.reservationDataGridView.DataSource = simpleReservationList;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = this.reservationDataGridView.CurrentCell.RowIndex;
            List<simpleReservation> reservationList = this.reservationDataGridView.DataSource as List<simpleReservation>;
            int simpleReservationID = reservationList[rowIndex].reservationID;

            var query = from res in this.reservationList
                        where res.reservationID == simpleReservationID
                        select res;
 
            Reservation reservation = query.First();
            Console.WriteLine(reservation.customerID);

            //Open window for editing of the reservation
            EditReservationWindow window = new EditReservationWindow(reservation, databaseConnection);
            window.ShowDialog();

            this.RefreshList();
            reservationDataGridView.Rows[rowIndex].Selected = true;
        }
    }
}
