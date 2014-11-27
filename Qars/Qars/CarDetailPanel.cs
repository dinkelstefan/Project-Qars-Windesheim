using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qars
{
    class CarDetailPanel : Panel
    {

        public CarDetailPanel(int carNumber)
        {
            //Properties of the panel
            this.Height = 550;
            this.Width = 1034;
            this.Top = 100;
            this.Left = 200;
            this.BorderStyle = BorderStyle.FixedSingle;
            //this.BackColor = Color.Tomato;

            //Text and other stuff
            Label carName = new Label();
            carName.Text = Form1.cars[carNumber].brand + " " + Form1.cars[carNumber].model;
            carName.Top = 20;
            carName.Left = 375;
            carName.Width = 300;
            carName.Height = 28;
            carName.Font = new Font("Arial", 20);

            Label kmPrice = new Label();
            kmPrice.Text = "Gemiddelde prijs per K.M: € 20,-";/* Prijs per Kilometer */
            kmPrice.Top = 70;
            kmPrice.Left = 375;
            kmPrice.Width = 400;
            kmPrice.Height = 27;
            kmPrice.Font = new Font("Arial", 14);

            Label sellPrice = new Label();
            if (Form1.cars[carNumber].sellingprice == 0) //FIX THIS. IT HAS TO BE = 0
            {
                sellPrice.Text = "Verkoopprijs: N.V.T";
            }
            else
            {
                sellPrice.Text = "Verkoopprijs: € " + Form1.cars[carNumber].sellingprice;
            }
            sellPrice.Top = 110;
            sellPrice.Left = 375;
            sellPrice.Width = 400;
            sellPrice.Height = 27;
            sellPrice.Font = new Font("Arial", 14);

            Label availableAt = new Label();
            availableAt.Text = "Verkrijgbaar bij: " + Form1.cars[carNumber].establishmentID;
            availableAt.Top = 150;
            availableAt.Left = 375;
            availableAt.Width = 400;
            availableAt.Height = 27;
            availableAt.Font = new Font("Arial", 14);

            Button hireButton = new Button();
            hireButton.Text = "Huren";
            hireButton.BackColor = Color.Green;
            hireButton.Top = 180;
            hireButton.Left = 375;
            hireButton.Width = 150;
            hireButton.Height = 29;
            hireButton.ForeColor = Color.White;
            hireButton.Font = new Font("Old English", 10, FontStyle.Bold);
            hireButton.FlatStyle = FlatStyle.Flat;
            if (Form1.cars[carNumber].available == false)
            {
                hireButton.Enabled = false;
                hireButton.BackColor = Color.Red;
                hireButton.Text = "Niet beschikbaar"; //Later toevoegen: Auto is weer beschikbaar op: DATE
            }

            PictureBox mainPicture = new PictureBox();
            mainPicture.Top = 22;
            mainPicture.Left = 22;
            mainPicture.Height = 185;
            mainPicture.Width = 350;
            mainPicture.Image = Image.FromFile(@"C:\Users\Sander\Pictures\Themes\breath.jpg"); //Car photo. (All pictures)
            mainPicture.SizeMode = PictureBoxSizeMode.StretchImage;

            this.Controls.Add(carName);
            this.Controls.Add(kmPrice);
            this.Controls.Add(mainPicture);
            this.Controls.Add(sellPrice);
            this.Controls.Add(availableAt);
            this.Controls.Add(hireButton);
        }
    }
}

