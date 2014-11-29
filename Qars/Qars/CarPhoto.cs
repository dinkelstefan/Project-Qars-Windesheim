using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qars
{
    public class CarPhoto
    {
        public int PhotoID { get; set; }
        public int CarID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Datetaken { get; set; }
        public string Photolink { get; set; }


        public CarPhoto(int PhotoID, int CarID, string Name, string Description, string Datetaken, string Photolink)
        {
            this.PhotoID = PhotoID;
            this.CarID = CarID;
            this.Name = Name;
            this.Description = Description;
            this.Datetaken = Datetaken;
            this.Photolink = Photolink;
        }

    }
}
