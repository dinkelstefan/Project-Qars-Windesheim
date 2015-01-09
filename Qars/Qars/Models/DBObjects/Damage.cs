using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qars.Models.DBObjects
{
    public class Damage
    {
        public int damageID { get; set; }
        public int carID { get; set; }
        public string description { get; set; }
        public bool repaired { get; set; }

        public Damage()
        {
        }
    }
}
