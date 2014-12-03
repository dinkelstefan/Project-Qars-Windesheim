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
   public class HoverPanel : Panel
    {
       public Label info = new Label();
       public VisualDemo vd;

        public HoverPanel(VisualDemo vd)
        {
            this.vd = vd;

            Height = 200;
            Width = 150;
            Top = 10;
            Left = 10;

            info.Top = 10;
            info.Left = 5;
            info.Width = 100;
            info.Height = 500;
            Controls.Add(info);

            BackColor = Color.Gray;
            
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Visible = false;
        }

        public void SetInformation(int x, int y, Car c)
        {
            Car car = c;

            Debug.WriteLine(x + Width + " | " + vd.Width);

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
                        "Huur: " + c.rentalprice.ToString() + "\n"
                        + c.category + "\n" + "Jaar: " + c.modelyear + "\n" +
                        "Vermogen: " + c.horsepower.ToString() + "\n" + "Deuren: " + c.doors + "\n" +
                        "Stoelen: " + c.seats.ToString() + "\n" + "Verbruik: " + c.Fuelusage.ToString() + "\n"
                        + c.motor;
            
        }
    }
}
