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
        public String brand { get; set; }
        public int pk { get; set; }
        public double price { get; set; }
        public String picPath { get; set; }
        public Car(int id, string brand, int pk, double price,String picPath)
        {
            carID = id;
            this.brand = brand;
            this.pk = pk;
            this.price = price;
            this.picPath = picPath;
        }
    }
}
