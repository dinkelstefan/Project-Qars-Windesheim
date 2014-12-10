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
        public int imageWidth = 160;
        public int imageHeigth = 160;
        public int carNumber = 0; //This has to be the tile number!

        static public List<Damage> damageList = new List<Damage>();
        static public List<Establishment> EstablishmentList = new List<Establishment>();
        static public List<Reservation> reservationList = new List<Reservation>();
        static public List<Car> carList;
        static public List<Car> totalCarList { get; private set; }

        public List<Car> compareList = new List<Car>();

        public DBConnect db = new DBConnect();

        public VisualDemo()
        {
            InitializeComponent();
            DoubleBuffered = true;

            totalCarList = db.FillCars();
            carList = totalCarList;

            EstablishmentList = db.FillEstablishment();
            reservationList = db.FillReservation();
            damageList = db.FillDamage();

            updateTileView();
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
            this.Controls.Add(cp);
            cp.BringToFront();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchWizard1.Visible = !searchWizard1.Visible; 
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
                    tp = new TileListPanel(carList[i].brand, "€ " + carList[i].startprice, carList[i].PhotoList[0].Photolink, localY, localX, i, this);

                }
                else
                {
                    tp = new TileListPanel(carList[i].brand, "€ " + carList[i].startprice, "asd", localY, localX, i, this);
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

        private void showAllCars(object sender, EventArgs e)
        {
            if (searchWizard1.Visible == true)
            {
                searchWizard1.Visible = false;
            }
            carList = db.FillCars();
            totalCarList = carList;
            updateTileView();
        }
    }
}