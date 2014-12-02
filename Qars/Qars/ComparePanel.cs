using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qars
{
    class ComparePanel : Panel
    {
        public List<Car> cars { get; set; }
        public List<Label> brand { get; set; }
        public List<Label> horsepower { get; set; }
        public List<Label> rentalprice { get; set; }
        public List<PictureBox> pictures { get; set; }
        public Graphics graphics;
        public int pictureHeight = 200;
        public int pictureWidth =  200;

        public ComparePanel(List<Car> list)
        {
            
            this.Font = new Font("Calibri", 10);
            Height = 570;//570
            Width = 1040;//960
            this.BackColor = Color.FromArgb(158, 158, 158);
            cars = list;

            this.Top = 70;
            this.Left = 221;

            brand = new List<Label>();
            horsepower = new List<Label>();
            rentalprice = new List<Label>();
            pictures = new List<PictureBox>();
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            //close button
            Button closeButton = new Button();
            closeButton.Text = "Close";
            closeButton.Width = Width;
            closeButton.BackColor = Color.White;
            closeButton.Click += closeClick;
            this.Controls.Add(closeButton);

            //categories
            List<Label> categories = new List<Label>();
            categories.Add(new Label());
            categories.Add(new Label());
            categories.Add(new Label());
            categories[0].Text = "Merk:";
            categories[0].Top = 250;
            categories[0].Width = 50;
            categories[0].TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(categories[0]);
            categories[1].Text = "Pk:";
            categories[1].Top = 300;
            categories[1].Width = 50;
            categories[1].TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(categories[1]);
            categories[2].Text = "Prijs:";
            categories[2].Top = 350;
            categories[2].Width = 50;
            categories[2].TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(categories[2]);

            

            for (int i = 0; i < cars.Count; i++)
            {
                // check if car has a photo
                if (cars[i].PhotoList.Count > 0)
                {
                    pictures.Add(new PictureBox());
                    pictures[i].Left = 300 * i + 100;
                    pictures[i].ImageLocation = cars[i].PhotoList[0].Photolink;
                    pictures[i].Width = pictureWidth;
                    pictures[i].Top = 30;
                    pictures[i].Height = pictureHeight;
                    pictures[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Controls.Add(pictures[i]);
                }

                brand.Add(new Label());
                brand[i].Text = cars[i].brand;
                brand[i].Left = 300 * i + 150;
                brand[i].Top = 250;
                brand[i].TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(brand[i]);

                horsepower.Add(new Label());
                horsepower[i].Text = cars[i].horsepower.ToString();
                horsepower[i].Left = 300 * i + 150;
                horsepower[i].Top = 300;
                horsepower[i].TextAlign = ContentAlignment.MiddleCenter;
                
                this.Controls.Add(horsepower[i]);

                rentalprice.Add(new Label());
                rentalprice[i].Text = cars[i].rentalprice + "\u20AC";
                rentalprice[i].Left = 300 * i + 150;
                rentalprice[i].Top = 350;
                rentalprice[i].TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(rentalprice[i]);
            }

            CheckHighestPk();
            CheckLowestPrice();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            graphics = e.Graphics;
            Pen pen = new Pen(Color.Black);
            //styling lines can be put here.
            graphics.DrawLine(pen, new Point(0,28), new Point(Width,28));
            graphics.DrawLine(pen, new Point(0, 230), new Point(Width, 230));
            graphics.DrawLine(pen, new Point(50, 0), new Point(50, Height));
            graphics.DrawLine(pen, new Point(350, 0), new Point(350, Height));
            graphics.DrawLine(pen, new Point(650, 0), new Point(650, Height));
            this.BringToFront();
        }

        public void closeClick(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        public void CheckHighestPk()
        {
            double[] comparePk = new double[cars.Count];
            for (int i = 0; i < comparePk.Length; i++)
            {
                comparePk[i] = cars[i].horsepower;
            }
            double maxValue = comparePk.Max();
            for (int i = 0; i < cars.Count; i++)
            {
                if (maxValue == cars[i].horsepower)
                {
                    horsepower[i].Text = horsepower[i].Text + " \u221A";
                    horsepower[i].Font = new Font("Calibri", 10, FontStyle.Bold);
                }
            }
        }

        public void CheckLowestPrice()
        {
            double[] comparePrice = new double[cars.Count];
            for (int i = 0; i < comparePrice.Length; i++)
            {
                comparePrice[i] = cars[i].rentalprice;
            }
            double minValue = comparePrice.Min();
            for (int i = 0; i < cars.Count; i++)
            {
                if (minValue == cars[i].rentalprice)
                {
                    rentalprice[i].Text = rentalprice[i].Text + " \u221A";
                    rentalprice[i].Font = new Font("Calibri", 10, FontStyle.Bold);
                }
            }
        }
    }
}
