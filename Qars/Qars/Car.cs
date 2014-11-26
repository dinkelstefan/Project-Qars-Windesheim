using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qars
{
    class Car
    {
        public int carID { get; set; }
        public int establishmentID { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string category { get; set; }
        public string modelyear { get; set; }
        public bool automatic { get; set; }
        public int kilometres { get; set; }
        public string colour { get; set; }
        public int doors { get; set; }
        public bool stereo { get; set; }
        public bool bluetooth { get; set; }
        public double horsepower { get; set; }
        public string length { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public bool airco { get; set; }
        public int seats { get; set; }
        public string motdate { get; set; } //convert date to string
        public double storagespace { get; set; }
        public int gearsamount { get; set; }
        public float rentalprice { get; set; }
        public float sellingprice { get; set; }
        public bool available { get; set; }
        public string description { get; set; }

        //maak OF heel veel constructors OF setters.
        public Car() { }
    }
}
