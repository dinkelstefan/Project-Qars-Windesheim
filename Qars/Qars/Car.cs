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
        public int Fuelusage { get; set; }
        public string motor { get; set; }
        public List<CarPhoto> PhotoList { get; set; }

        public Car(int carID, int establishmentID, string brand, string model, string category, string modelyear, bool automatic, int kilometres, string colour, int doors, bool stereo, bool bluetooth, double horsepower, string length, string width, string height, bool airco, int seats, string motdate, double storagespace, int gearsamount, float rentalprice, float sellingprice, bool available, string description, int Fuelusage, string motor)
        {
            this.carID = carID;
            this.establishmentID = establishmentID;
            this.brand = brand;
            this.model = model;
            this.category = category;
            this.modelyear = modelyear;
            this.automatic = automatic;
            this.kilometres = kilometres;
            this.colour = colour;
            this.doors = doors;
            this.stereo = stereo;
            this.bluetooth = bluetooth;
            this.horsepower = horsepower;
            this.length = length;
            this.width = width;
            this.height = height;
            this.airco = airco;
            this.seats = seats;
            this.motdate = motdate;
            this.storagespace = storagespace;
            this.gearsamount = gearsamount;
            this.rentalprice = rentalprice;
            this.sellingprice = sellingprice;
            this.available = available;
            this.description = description;
            this.Fuelusage = Fuelusage;
            this.motor = motor;
            this.PhotoList = new List<CarPhoto>();

        }
    }
}
