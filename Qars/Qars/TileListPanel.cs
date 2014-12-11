using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qars
{
    public class TileListPanel : Panel
    {
        public string name;
        public string model;
        public double carPrice;
        public string imageLink;
        public int carNumber;
        public VisualDemo vd;

        public TileListPanel(string cName, string cModel, double cPrice, string imageLink, int height, int width, int carNumber, bool available, VisualDemo vd)
        {
            this.name = cName;
            this.model = cModel;
            this.carPrice = cPrice;
            this.imageLink = imageLink;
            this.carNumber = carNumber;
            this.vd = vd;

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

            if (!available)
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

            this.Controls.Add(price);

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

        protected void pb_MouseHover(object sender, EventArgs e)
        {
            vd.hp.SetInformation(MousePosition.X - 320, MousePosition.Y - 180, VisualDemo.carList[carNumber]);
            vd.hp.Visible = true;
        }

        protected void pb_MouseLeave(object sender, EventArgs e)
        {
            vd.hp.Visible = false;
        }

        protected void pb_Paint(object sender, PaintEventArgs e)
        {

            SolidBrush blueBrush = new SolidBrush(Color.DarkOrange);
            Rectangle rect = new Rectangle(0, 0, 150, 30);
            e.Graphics.FillRectangle(blueBrush, rect);
            e.Graphics.DrawString("Niet Beschikbaar", new Font("Aharoni", 13, FontStyle.Bold), new SolidBrush(Color.Black), 0f, 6f);
        }

        private void pb_Click(object sender, EventArgs e)
        {
            vd.OpenDetails(carNumber);
        }

        public bool check = false;
        protected void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            check = !check;


            if (check)
                vd.AddCompare(carNumber);
            else
                vd.RemoveCompare(carNumber);

        }
    }
}
