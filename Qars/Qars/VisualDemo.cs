﻿using System;
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
        public int userID { get; set; }

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

        public DBConnect db = new DBConnect();

        public VisualDemo()
        {
            this.userID = 0;
            this.searchWizard = new Qars.Views.searchWizard(this);
            // 
            // searchWizard
            // 
            this.searchWizard.Location = new System.Drawing.Point(331, 121);
            this.searchWizard.Name = "searchWizard1";
            this.searchWizard.Size = new System.Drawing.Size(1565, 873);
            this.searchWizard.TabIndex = 11;
            this.searchWizard.Visible = false;
            this.Controls.Add(this.searchWizard);

            InitializeComponent();
            DoubleBuffered = true;
            hp = new HoverPanel(this);

            totalCarList = db.SelectCar();
            carList = totalCarList;

            EstablishmentList = db.SelectEstablishment();
            reservationList = db.SelectReservation();
            damageList = db.SelectDamage();
            customerList = db.SelectUsers();

            updateTileView();

            this.Controls.Add(hp);
            hp.BringToFront();
            ChangeAccountDetails(userID);

        }
        private void ChangeAccountDetails(int UserID)
        {
            if (userID != 0)
            {
                int hiredcarID = -1;
                string enddate = "";

                foreach (var reservation in reservationList)
                {
                    if (reservation.UserID == UserID)
                    {
                        if (reservation.confirmed == true)
                        {
                            EndDateInfo.Text = reservation.enddate;
                            ReservationPeriodEndLabel.Visible = true;
                            hiredcarID = reservation.carID;
                            enddate = reservation.enddate;
                            break;
                        }
                    }
                }
                if (hiredcarID != -1 && enddate != "")
                {
                    foreach (var car in carList)
                    {
                        if (car.carID == hiredcarID)
                        {
                            HiredCarLabel.Text = car.brand + " " + car.model;
                            HiredCarLabel.Visible = true;
                            ReservationLabel.Visible = true;

                            break;
                        }
                    }
                }
                WelcomeLabel.Text = string.Format("Hallo {0}", customerList[UserID].firstname);
                WelcomeInfoLabel.Text = "U bent nu ingelogd! \rWanneer u een auto wilt huren zullen uw persoonlijke gegevens ingevuld zijn";
            }
        }
        //backoffice/franchise      

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
            CarDetailPanel cp = new CarDetailPanel(number, userID, this);
            this.Controls.Add(cp);
            cp.BringToFront();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchWizard.Visible = !searchWizard.Visible;
            updateTileView();
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
                    tp = new TileListPanel(carList[i].brand, carList[i].model, carList[i].startprice, carList[i].PhotoList[0].Photolink, localY, localX, i, carList[i].available, this);
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
            if (searchWizard.Visible == true)
            {
                searchWizard.Visible = false;
            }
            carList = db.SelectCar();
            totalCarList = carList;
            updateTileView();
        }

        private void LogInOrRegisterButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(userID);
            LogInForm loginform = new LogInForm(this, userID);
            loginform.ShowDialog();
            userID = loginform.returnUserID();
            Console.WriteLine(userID);
            ChangeAccountDetails(userID);



        }
    }
}