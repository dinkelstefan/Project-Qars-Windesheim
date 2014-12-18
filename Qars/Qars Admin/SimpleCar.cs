using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qars_Admin {
    class SimpleCar {
        public int AutoID { get; private set; }
        public string Vestiging { get; private set; }
        public string Merk { get; private set; }
        public string Type { get; private set; }
        public int Bouwjaar { get; private set; }
        public string Kleur { get; private set; }
        public int Kilometers { get; private set; }

        public SimpleCar(int id, string est, string brand, string type, int year, string color, int km) {
            this.AutoID = id;
            this.Vestiging = est;
            this.Merk = brand;
            this.Type = type;
            this.Bouwjaar = year;
            this.Kleur = color;
            this.Kilometers = km;
        }
    }
}
