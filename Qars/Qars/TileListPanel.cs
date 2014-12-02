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
    class TileListPanel : Panel
    {
        public string name;
        public double carPrice;
        public string imageLink;
        public int carNumber;
        public VisualDemo vd;

       public TileListPanel(string n, double p, string i, int h, int w, int carNumber, VisualDemo vd)
       {
           this.name = n;
           this.carPrice = p;
           this.imageLink = i;
           this.carNumber = carNumber;
           this.vd = vd;

           Height = 220;
           Width = 175;
           this.BackColor = Color.White;

           this.Top = h;
           this.Left = w;

           this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
           

           PictureBox pb = new PictureBox();
           
           pb.Height = 150;
           pb.Width = 150;
           pb.Left = 12;
           pb.Top = 10;

           pb.ImageLocation = imageLink;
           pb.SizeMode = PictureBoxSizeMode.StretchImage;
           this.Controls.Add(pb);

           Label name = new Label();
           name.Width = 200;
           name.Text = this.name;
           name.Font = new Font("Ariel", 10);
           name.Top = 160;
           name.Left = 10;

           this.Controls.Add(name);

           Label price = new Label();
           price.Width = 200;
           price.Text = "" + carPrice;
           price.Font = new Font("Ariel", 10);
           price.Top = 180;
           price.Left = 10;

           this.Controls.Add(price);

           CheckBox cb = new CheckBox();
           cb.Top = 200;
           cb.Left = 160;
           cb.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);

           this.Controls.Add(cb);
        }

       public bool check = false;
       protected void CheckBox_CheckedChanged(object sender, EventArgs e)
       {
           check = !check;

           if(check)
            vd.AddCompare(carNumber);
           else
               vd.RemoveCompare(carNumber);
       }
    }
}
