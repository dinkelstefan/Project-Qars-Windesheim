using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qars
{
    public class Establishment
    {

        public int establishmentID { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string postalcode { get; set; }
        public string streetname { get; set; }
        public int streetnumber { get; set; }
        public string streetnumbersuffix { get; set; }
        public string phonenumber { get; set; }
        public string emailaddress { get; set; }
        public string leafletlink { get; set; } //Link naar een folder van een company
        public string description { get; set; }

        public Establishment(int establishmentID, string name, string city, string postalcode, string streetname, int streetnumber, string streetnumbersuffix, string phonenumber, string emailaddress, string leafletlink, string description)
        {
            this.establishmentID = establishmentID;
            this.name = name;
            this.city = city;
            this.postalcode = postalcode;
            this.streetname = streetname;
            this.streetnumber = streetnumber;
            this.streetnumbersuffix = streetnumbersuffix;
            this.phonenumber = phonenumber;
            this.emailaddress = emailaddress;
            this.leafletlink = leafletlink;
            this.description = description;
        }


    }
}
