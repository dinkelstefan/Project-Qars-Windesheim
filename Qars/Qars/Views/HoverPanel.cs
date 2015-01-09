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
    public class HoverPanel : Panel
    {
        public Label info = new Label();
        public VisualDemo vd;

        public HoverPanel(VisualDemo vd)
        {
            this.vd = vd;

            Height = 150;
            Width = 100;
            Top = 10;
            Left = 10;

            info.ForeColor = System.Drawing.Color.White;
            info.Top = 10;
            info.Left = 5;
            info.Width = 100;
            info.Height = 500;
            Controls.Add(info);

            BackColor = Color.FromArgb(162, 60, 75);

            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Visible = false;
        }

        public void SetInformation(int x, int y, Car c, Discount discount)
        {
            Car car = c;



            if ((x + Width > vd.Width) && (y + Height > vd.Height))
            {
                Left = x - 155;
                Top = y - 200;
            }
            else
            {
                if (x + Width < vd.Width)
                    Left = x;
                else
                    Left = x - 155;

                if (y + Height < vd.Height)
                    Top = y;
                else
                    Top = y - 200;
            }



            info.Text = c.brand + " " + c.model + "\n" +
                        "Huur: €";

            if (discount != null)
                info.Text += Math.Round((c.rentalprice * ((double)1 - ((double)discount.KMPercentage / 100))), 2).ToString();
            else
                info.Text += c.rentalprice;

            info.Text += "\n"
                       + c.category + "\n" + "Jaar: " + c.modelyear + "\n" +
                       "Vermogen: " + c.horsepower.ToString() + "\n" + "Deuren: " + c.doors + "\n" +
                       "Stoelen: " + c.seats.ToString() + "\n";

            if (c.fuelusage != -1)
                info.Text += "Verbruik: " + c.fuelusage.ToString() + " Km/L \n";

            info.Text += c.motor;

        }
    }
}
