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
        //This needs a better solution. Help?
        static public List<Car> cars;
        static public List<CarPhoto> photos;

        public Form1()
        {
            InitializeComponent();

            DBConnect connection = new DBConnect();
            cars = new List<Car>(connection.FillCars());
            photos = new List<CarPhoto>(connection.FillCarPhotos());

            CarDetailPanel carDetailPanel = new CarDetailPanel(0); //tile number
            this.Controls.Add(carDetailPanel);
        }
    }
}
