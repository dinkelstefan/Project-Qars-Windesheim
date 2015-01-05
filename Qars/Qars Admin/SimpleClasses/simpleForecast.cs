using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qars_Admin.SimpleClasses
{
    class simpleForecast
    {
        public int ReservationID { get; set; }
        public int AutoID { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Merk { get; set; }
        public string Model { get; set; }
        public bool betaald { get; set; }
        public bool bevestigd { get; set; }

        public simpleForecast(int resID, int carID, string firstname, string lastname, string brand, string model, bool paid, bool confirmed)
        {
            this.ReservationID = resID;
            this.AutoID = carID;
            this.Voornaam = firstname;
            this.Achternaam = lastname;
            this.Merk = brand;
            this.Model = model;
            this.betaald = paid;
            this.bevestigd = confirmed;
        }
    }
}
