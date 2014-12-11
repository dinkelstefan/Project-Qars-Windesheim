using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qars
{
    public class Reservation
    {
        public int reservationID { get; set; }
        public int carID { get; set; }
        public int customerID { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public bool confirmed { get; set; }
        public int kilometres { get; set; }
        public string pickupcity { get; set; }
        public string pickupstreetname { get; set; }
        public int pickupstreetnumber { get; set; }
        public string pickupstreetnumbersuffix { get; set; }
        public bool paid { get; set; }
        public string comment { get; set; }

        public Reservation()
        {
        }

    }
}
