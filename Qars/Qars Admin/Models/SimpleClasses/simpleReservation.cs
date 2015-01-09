using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qars_Admin.Models.SimpleClasses
{
    class simpleReservation
    {
        public int reservationID { get; set; }
        public int carID { get; set; }
        public int KlantID { get; set; }
        public string Begindatum { get; set; }
        public string Einddatum { get; set; }
        public double Kilometers { get; set; }
        public string Stad { get; set; }
        public string Straatnaam { get; set; }
        public double Huisnummer { get; set; }
        public bool Bevestigd { get; set; }
        public bool Betaald { get; set; }

        public simpleReservation(int reservationID, int carID, int klantID,string beginDatum, string eindDatum, double kilometers, string stad, string straatnaam, double huisnummer, bool betaald, bool bevestigd)
        {
            this.reservationID = reservationID;
            this.KlantID = klantID;
            this.carID = carID;
            this.Begindatum = beginDatum;
            this.Einddatum = eindDatum;
            this.Kilometers = kilometers;
            this.Stad = stad;
            this.Straatnaam = straatnaam;
            this.Huisnummer = huisnummer;
            this.Betaald = betaald;
            this.Bevestigd = bevestigd;
        }
    }
}
