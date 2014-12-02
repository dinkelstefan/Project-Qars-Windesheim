using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Qars
{
    public partial class VisualDemo : Form
    {
        public int imageWidth = 160;
        public int imageHeigth = 160;
        public int carNumber = 0; //This has to be the tile number!

        public List<Car> compareList = new List<Car>();

        static public List<CarPhoto> cPhotos = new List<CarPhoto>();
        //static public List<Car> cars = new List<Car>();
        static public List<Car> carList = new List<Car>();

        public DBConnect db = new DBConnect();

        public VisualDemo()
        {
            InitializeComponent();
            DoubleBuffered = true;

            carList = db.FillCars();
            cPhotos = db.FillCarPhotos();

            int localY = 200;
            int localX = 10;
            int checkNumb = 0;

            Debug.WriteLine(cPhotos[0].Photolink);

            for (int i = 0; i < carList.Count; i++)
            {
                TileListPanel tp;
                if (carList[i].PhotoList.Count > 0) {
                    tp = new TileListPanel(carList[i].brand, carList[i].rentalprice, carList[i].PhotoList[0].Photolink, localY, localX, i, this);
                } else {
                    tp = new TileListPanel(carList[i].brand, carList[i].rentalprice, "asd", localY, localX, i, this);
                }
                TileView.Controls.Add(tp);
                localX += 200;
                checkNumb++;

                if (checkNumb == 5)
                {
                    localY += 250;
                    localX = 10;
                    checkNumb = 0;
                }

            }
        }


        public void AddCompare(int number)
        {
            compareList.Add(carList[number]);

            if (compareList.Count > 1)
                button1.Visible = true;

            UpdateCompareLabel();
        }

        public void RemoveCompare(int number)
        {
            compareList.Remove(carList[number]);

            if (compareList.Count < 2)
                button1.Visible = false;

            UpdateCompareLabel();

        }

        public void UpdateCompareLabel()
        {
            label3.Text = "";

            if (compareList.Count > 0)
            {
                foreach (Car c in compareList)
                {
                    label3.Text += c.brand + " | ";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ComparePanel p = new ComparePanel(compareList);
            this.Controls.Add(p);
        }

        public void OpenDetails(int number)
        {
            CarDetailPanel cp = new CarDetailPanel(number);
            Debug.WriteLine("stuff");
            this.Controls.Add(cp);
            cp.BringToFront();
        }
    }
}