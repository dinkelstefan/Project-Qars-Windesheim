using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qars
{
    public partial class Form1 : Form
    {
        static public List<Car> cars;
        public Form1()
        {
            InitializeComponent();

            DBConnect connection = new DBConnect();
            cars = new List<Car>(connection.FillCars());

            CarDetailPanel CarDetailPanel = new CarDetailPanel(0);
            this.Controls.Add(CarDetailPanel);
        }
    }
}
