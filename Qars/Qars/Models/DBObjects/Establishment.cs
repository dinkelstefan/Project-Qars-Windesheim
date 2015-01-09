using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qars.Models.DBObjects
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

        public Establishment()
        {
        }


    }
}
