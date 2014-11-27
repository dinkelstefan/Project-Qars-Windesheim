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
        public List<Car> cars;
        public Form1()
        {
            InitializeComponent();
            CarDetailPanel CarDetailPanel = new CarDetailPanel();
            CarDetailPanel.Show();
            DBConnect connection = new DBConnect();
            cars = new List<Car>(connection.FillCars());

            foreach (Car c in cars)
            {
                Console.WriteLine(c.brand);
            }
        }
    }
}
