using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Qars.Models
{
    class Reservation
    {
        public string firstname;
        public string lastname;
        public string streetname;
        public int streetnumber;
        public string streetnumbersuffix;
        public string city;
        public string postalcode;
        public MailAddress email;
        public string phonenumber;
        public string startdate;
        public string enddate;
        public string comment;

        public Reservation(string Firstname, string Lastname, string Streetname, int Streetnumber, string Streetnumbersuffix, string City, string Postalcode, MailAddress Email, string Phonenumber, string Startdate, string Enddate, string Comment)
        {
            this.firstname = Firstname;
            this.lastname = Lastname;
            this.streetname = Streetname;
            this.streetnumber = Streetnumber;
            this.streetnumbersuffix = Streetnumbersuffix;
            this.city = City;
            this.postalcode = Postalcode;
            this.email = Email;
            this.phonenumber = Phonenumber;
            this.startdate = Startdate;
            this.enddate = Enddate;
            this.comment = Comment;
            //add some car stuff later
        }
    }
}
