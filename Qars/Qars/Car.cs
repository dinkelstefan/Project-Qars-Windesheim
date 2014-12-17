using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qars
{
    public class Car
    {
        public int carID { get; set; }
        public int establishmentID { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string category { get; set; }
        public int modelyear { get; set; }
        public bool automatic { get; set; }
        public int kilometres { get; set; }
        public string colour { get; set; }
        public int doors { get; set; }
        public bool stereo { get; set; }
        public bool bluetooth { get; set; }
        public double horsepower { get; set; }
        public int length { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public bool navigation { get; set; }
        public bool cruisecontrol { get; set; }
        public bool parkingAssist { get; set; }
        public bool fourwheeldrive { get; set; }
        public bool cabrio { get; set; }
        public bool airco { get; set; }
        public int seats { get; set; }
        public string motdate { get; set; } //convert date to string
        public double storagespace { get; set; }
        public int gearsamount { get; set; }
        public int startprice { get; set; }
        public double rentalprice { get; set; }
        public double sellingprice { get; set; }
        public bool available { get; set; }
        public string description { get; set; }
        public int Fuelusage { get; set; }
        public string motor { get; set; }
        public List<CarPhoto> PhotoList { get; set; }

        public Car()
        {
            this.PhotoList = new List<CarPhoto>();
        }

        public override string ToString()
        {
            return string.Format("{0}.\t{1} {2}\t{3}\t{4}\t{5}", this.carID, this.brand, this.model, this.automatic.ToString(), this.category, this.establishmentID.ToString());
        }
    }
}
