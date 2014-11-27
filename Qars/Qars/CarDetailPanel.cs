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
            this.Height = 568;
            this.Width = 1044;
            this.Top = 70;
            this.Left = 221;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = Color.White;

            //Text and other stuff
            Label carName = new Label();
            carName.Text = Form1.cars[carNumber].brand + " " + Form1.cars[carNumber].model;
            carName.Top = 20;
            carName.Left = 375;
            carName.Width = 300;
            carName.Height = 28;
            carName.Font = new Font("Arial", 20);

            Label kmPrice = new Label();
            kmPrice.Text = "Gemiddelde prijs per K.M: € 20,-"; //TO DO: Query to get the average price per Kilometre
            kmPrice.Top = 70;
            kmPrice.Left = 375;
            kmPrice.Width = 400;
            kmPrice.Height = 27;
            kmPrice.Font = new Font("Arial", 14);

            Label sellPrice = new Label();
            if (Form1.cars[carNumber].sellingprice == 0)
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
            availableAt.Text = "Verkrijgbaar bij: " + Form1.cars[carNumber].establishmentID; //TO DO: Query to get establishments
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
            hireButton.Font = new Font("Old English", 11, FontStyle.Bold);
            hireButton.FlatStyle = FlatStyle.Flat;
            if (!Form1.cars[carNumber].available)
            {
                hireButton.Enabled = false;
                hireButton.BackColor = Color.Red;
                hireButton.Text = "Niet beschikbaar"; //TO DO: Add "AVAILABLE AT: DATE"
            }


            //This has to be a lot cleaner but I don't know how. 
            //Listview didn't look pretty. How do I get all the individual photos/get a better solution?
            PictureBox smallPicture1 = new PictureBox();
            smallPicture1.Top = 220;
            smallPicture1.Left = 22;
            smallPicture1.Height = 75;
            smallPicture1.Width = 75;
            smallPicture1.ImageLocation = @Form1.photos[carNumber].Photolink;
            smallPicture1.SizeMode = PictureBoxSizeMode.StretchImage;

            PictureBox smallPicture2 = new PictureBox();
            smallPicture2.Top = 220;
            smallPicture2.Left = 110;//Left += 88
            smallPicture2.Height = 75;
            smallPicture2.Width = 75;
            smallPicture2.ImageLocation = @Form1.photos[carNumber].Photolink;
            smallPicture2.SizeMode = PictureBoxSizeMode.StretchImage;

            PictureBox smallPicture3 = new PictureBox();
            smallPicture3.Top = 220;
            smallPicture3.Left = 198;
            smallPicture3.Height = 75;
            smallPicture3.Width = 75;
            smallPicture3.ImageLocation = @Form1.photos[carNumber].Photolink;
            smallPicture3.SizeMode = PictureBoxSizeMode.StretchImage;

            PictureBox smallPicture4 = new PictureBox();
            smallPicture4.Top = 220;
            smallPicture4.Left = 286;
            smallPicture4.Height = 75;
            smallPicture4.Width = 75;
            smallPicture4.ImageLocation = @Form1.photos[carNumber].Photolink;
            smallPicture4.SizeMode = PictureBoxSizeMode.StretchImage;

            PictureBox smallPicture5 = new PictureBox();
            smallPicture1.Top = 220;
            smallPicture1.Left = 22;
            smallPicture1.Height = 75;
            smallPicture1.Width = 75;
            smallPicture1.ImageLocation = @Form1.photos[carNumber].Photolink;
            smallPicture1.SizeMode = PictureBoxSizeMode.StretchImage;

            //Main picture box
            PictureBox mainPicture = new PictureBox();
            mainPicture.Top = 22;
            mainPicture.Left = 22;
            mainPicture.Height = 185;
            mainPicture.Width = 350;
            mainPicture.ImageLocation = @Form1.photos[carNumber].Photolink; //foto's met stefan
            mainPicture.SizeMode = PictureBoxSizeMode.StretchImage;

            /*
             * TO DO:
             * -Change Main Picture Box's image when I click on another Small Picture Box Image
             * -Specifications about car
             * -Information about car
             * -Draw Line
            */

            //all controls.
            this.Controls.Add(carName);
            this.Controls.Add(kmPrice);
            this.Controls.Add(mainPicture);
            this.Controls.Add(sellPrice);
            this.Controls.Add(availableAt);
            this.Controls.Add(hireButton);
            this.Controls.Add(smallPicture1);
            this.Controls.Add(smallPicture2);
            this.Controls.Add(smallPicture3);
            this.Controls.Add(smallPicture4);
        }
    }
}

