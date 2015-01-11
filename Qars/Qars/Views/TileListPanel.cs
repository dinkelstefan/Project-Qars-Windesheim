using Qars.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qars.Views
{
    public class TileListPanel : Panel
    {
        public string name;
        public string model;
        public double carPrice;
        public string imageLink;
        public int carNumber;
        private VisualDemo qarsApplication;
        public Discount discount;
        public bool available;

        //Create whole new panel
        public TileListPanel(string cName, string cModel, double cPrice, string imageLink, int height, int width, int carNumber, bool avail, VisualDemo qarsApp, Discount dis)
        {
            this.name = cName;
            this.model = cModel;
            this.carPrice = cPrice;
            this.imageLink = imageLink;
            this.carNumber = carNumber;
            this.qarsApplication = qarsApp;
            this.discount = dis;
            available = avail;

            //Set panel specs
            Height = 220;
            Width = 175;
            Top = height;
            Left = width;
            BackColor = Color.White;
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;


            PictureBox pb = new PictureBox();

            pb.Height = 150;
            pb.Width = 150;
            pb.Left = 12;
            pb.Top = 10;

            pb.ImageLocation = imageLink;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Click += new EventHandler(pb_Click);
            pb.MouseHover += new EventHandler(pb_MouseHover);
            pb.MouseLeave += new EventHandler(pb_MouseLeave);
            pb.Paint += new PaintEventHandler(pb_Paint);

            this.Controls.Add(pb);

            Label name = new Label();
            name.Width = 200;
            name.Text = this.name + " " + this.model;
            name.Font = new Font("Ariel", 10);
            name.Top = 160;
            name.Left = 10;

            this.Controls.Add(name);
            

            Label price = new Label();
            price.Width = 200;            
            price.Text = "€" + carPrice;
            price.Font = new Font("Ariel", 10);
            price.Top = 180;
            price.Left = 10;
            
            //Only show if car has discount values
            if (discount != null)
            {
                price.Font = new Font("Ariel", 10, FontStyle.Strikeout);
                price.ForeColor = System.Drawing.Color.Red;
                Label discountLabel = new Label();
                discountLabel.Font = new Font("Ariel", 10, FontStyle.Bold);
                discountLabel.Width = 200;
                discountLabel.Top = 180;
                discountLabel.Left = 40;
                discountLabel.ForeColor = System.Drawing.Color.Green;
                discountLabel.Text = " =  €" + carPrice * ((double)1 - ((double)discount.percentage / 100));
                this.Controls.Add(discountLabel);
            }

            this.Controls.Add(price);

            //Checkbox comparison
            Label verglijking = new Label();
            verglijking.Width = 48;
            verglijking.Text = "Vergelijk";
            verglijking.Font = new Font("Ariel", 7);
            verglijking.ForeColor = Color.Blue;
            verglijking.Top = 205;
            verglijking.Left = 112;

            this.Controls.Add(verglijking);

            CheckBox cb = new CheckBox();
            cb.Top = 200;
            cb.Left = 160;
            cb.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            this.Controls.Add(cb);
        }

        //Enter tooltip
        protected void pb_MouseHover(object sender, EventArgs e)
        {
            qarsApplication.hp.SetInformation(MousePosition.X - 320, MousePosition.Y - 180, this.qarsApplication.carList[carNumber], discount);
            qarsApplication.hp.Visible = true;
        }

        //Exit tooltip
        protected void pb_MouseLeave(object sender, EventArgs e)
        {
            qarsApplication.hp.Visible = false;
        }

        //Paint valaibility and discounts
        protected void pb_Paint(object sender, PaintEventArgs e)
        {
            if (!available)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.DarkOrange), new Rectangle(0, 0, 150, 30));
                e.Graphics.DrawString("Niet Beschikbaar", new Font("Aharoni", 13, FontStyle.Bold), new SolidBrush(Color.Black), 0f, 6f);
            }
            
            if(discount != null)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Green), new Rectangle(0, 120, 150, 30));

                if(discount.percentage > discount.KMPercentage)
                    e.Graphics.DrawString("Tot " + discount.percentage + "% korting!", new Font("Aharoni", 15, FontStyle.Bold), new SolidBrush(Color.Black), 0f, 130f);
                else
                    e.Graphics.DrawString("Tot " + discount.KMPercentage + "% korting!", new Font("Aharoni", 15, FontStyle.Bold), new SolidBrush(Color.Black), 0f, 130f);
            }
        }

        //Open car detail panel
        private void pb_Click(object sender, EventArgs e)
        {
            qarsApplication.OpenDetails(carNumber, discount, available);
        }

        //Checkbox check too prevent checkbox errors
        public bool check = false;
        protected void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            check = !check;


            if (check)
                qarsApplication.AddCompare(carNumber);
            else
                qarsApplication.RemoveCompare(carNumber);

        }
    }
}
