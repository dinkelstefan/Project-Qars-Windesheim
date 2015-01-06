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
        public HoverPanel hp;

        public List<Damage> damageList = new List<Damage>();
        public List<Establishment> EstablishmentList = new List<Establishment>();
        public List<Reservation> reservationList = new List<Reservation>();
        public List<Car> carList;
        public List<User> customerList;
        public List<Car> totalCarList { get; private set; }

        public List<Car> compareList = new List<Car>();
        public List<Discount> discountList;

        public DBConnect db = new DBConnect();

        public VisualDemo()
        {
			discountList = new List<Discount>(db.CheckDiscounts());
            totalCarList = db.SelectCar();
            carList = totalCarList;
            //this.Height = 1500;

            // searchWizard
            this.searchWizard = new Qars.Views.searchWizard(this);
            this.searchWizard.BringToFront();
            this.searchWizard.Location = new System.Drawing.Point(0, 71);
            this.searchWizard.Name = "searchWizard1";
           // this.searchWizard.Size = new System.Drawing.Size(250, 850);
            this.searchWizard.TabIndex = 11;
            this.searchWizard.Visible = true;
            this.Controls.Add(this.searchWizard);
            
            InitializeComponent();
            DoubleBuffered = true;
            hp = new HoverPanel(this);

            

            EstablishmentList = db.SelectEstablishment();
            reservationList = db.SelectReservation();
            damageList = db.SelectDamage();
            customerList = db.SelectUsers();

            updateTileView();

            this.Controls.Add(hp);
            hp.BringToFront();

            
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
                 List<double> discountPrices = new List<double>();

                foreach(Car car in compareList)
                {
                    var match = discountList.FirstOrDefault(DiscountToCheck => DiscountToCheck.carID == car.carID);

                    if(match != null)
                    {
                        discountPrices.Add(car.startprice * ((double)1 - ((double)match.percentage / 100)));
                        discountPrices.Add(car.rentalprice * ((double)1 - ((double)match.percentage / 100))); 
                    }
                    else
                    {
                        discountPrices.Add(car.startprice);
                        discountPrices.Add(car.startprice);
                    }
                }
            
            ComparePanel p = new ComparePanel(compareList, discountPrices);
            this.Controls.Add(p);
        }

        public void OpenDetails(int number, Discount d)
        {
            CarDetailPanel cp = new CarDetailPanel(number, this, d);
            this.Controls.Add(cp);
            cp.BringToFront();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            //searchWizard.Visible = !searchWizard.Visible;
            //updateTileView();
        }

        public void updateTileView()
        {

            int localY = 200;
            int localX = 10;
            int checkNumb = 0;

            List<TileListPanel> toRemove = new List<TileListPanel>();


            foreach (Control c in TileView.Controls)
            {
                if (c.GetType() == typeof(TileListPanel))
                {
                    toRemove.Insert(0, c as TileListPanel);
                }
            }

            foreach (TileListPanel tile in toRemove)
            {
                TileView.Controls.Remove(tile);
                tile.Dispose();
            }

            for (int i = 0; i < carList.Count; i++)
            {
                TileListPanel tp;
                if (carList[i].PhotoList.Count > 0)
                {           
                    var match = discountList.FirstOrDefault(DiscountToCheck => DiscountToCheck.carID == carList[i].carID);
                    tp = new TileListPanel(carList[i].brand, carList[i].model, carList[i].startprice, carList[i].PhotoList[0].Photolink, localY, localX, i, carList[i].available, this, match);
                    TileView.Controls.Add(tp);
                }
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

        private void showAllCars(object sender, EventArgs e)
        {
            carList = db.SelectCar();
            totalCarList = carList;
            updateTileView();
        }

       
    }
}