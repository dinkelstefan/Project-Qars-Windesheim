using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qars_Admin.SimpleClasses
{
    class simpleUser
    {
        public int GebruikerID { get; set; }
        public int AccountLevel { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Woonplaats { get; set; }
        public string Telefoonnummer { get; set; }
        public string Emailadres { get; set; }

        public simpleUser(int gebID, int level, string username, string firstname, string lastname, string city, string tel, string email)
        {
            this.GebruikerID = gebID;
            this.AccountLevel = level;
            this.Gebruikersnaam = username;
            this.Voornaam = firstname;
            this.Achternaam = lastname;
            this.Woonplaats = city;
            this.Telefoonnummer = tel;
            this.Emailadres = email;
        }
    }
}
