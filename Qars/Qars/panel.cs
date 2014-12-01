using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qars
{
    public class panel : Panel
    {
        public List<Car> cars { get; set; }
        public List<Label> brand { get; set; }
        public List<Label> pk { get; set; }
        public List<Label> price { get; set; }
        public List<PictureBox> pictures { get; set; }
        public Graphics graphics;

        public panel(List<Car> list)
        {
            Height = 570;
            Width = 960;
            this.BackColor = Color.SlateGray;
            cars = list;

            this.Top = 70;
            this.Left = 221;

            brand = new List<Label>();
            pk = new List<Label>();
            price = new List<Label>();
            pictures = new List<PictureBox>();
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            //close button
            Button closeButton = new Button();
            closeButton.Text = "Close";
            closeButton.Width = Width;
            closeButton.BackColor = Color.White;
            closeButton.Click += closeClick;
            this.Controls.Add(closeButton);

            for (int i = 0; i < cars.Count; i++)
            {
                pictures.Add(new PictureBox());
                pictures[i].Left = (Width / cars.Count) * i + 1;
                //pictures[i].Image = Image.FromFile(cars[i].picPath);
                pictures[i].Width = (Width / cars.Count) - 2;
                pictures[i].Top = 30;
                pictures[i].Height = 200;
                pictures[i].SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(pictures[i]);

                brand.Add(new Label());
                brand[i].Text = "merk: " + cars[i].brand;
                brand[i].Left = (Width / cars.Count) * i + 1;
                brand[i].Top = 250;
                this.Controls.Add(brand[i]);

                pk.Add(new Label());
                pk[i].Text = "Aantal pk: " + cars[i].horsepower;
                pk[i].Left = (Width / cars.Count) * i + 1;
                pk[i].Top = 300;
                this.Controls.Add(pk[i]);

                price.Add(new Label());
                price[i].Text = "Prijs is: " + cars[i].rentalprice;
                price[i].Left = (Width / cars.Count) * i + 1;
                price[i].Top = 350;
                this.Controls.Add(price[i]);

            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            graphics = e.Graphics;
            Pen pen = new Pen(Color.Black);
            //styling lines can be put here.
            graphics.DrawLine(pen, new Point(0,28), new Point(Width,28));
            graphics.DrawLine(pen, new Point(0, 230), new Point(Width, 230));
            for (int i = 0; i < cars.Count; i++)
            {
                graphics.DrawLine(pen, new Point((Width / cars.Count) * i, 0), new Point((Width / cars.Count) * i, Height));
            }
            this.BringToFront();
        }

        public void closeClick(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}
