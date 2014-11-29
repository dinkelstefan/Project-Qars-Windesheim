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
        private List<PictureBox> pbox = new List<PictureBox>();
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

            int left = 22;
            foreach (var item in Form1.photos)
            {
                int top = 222;
                int height = 75;
                int width = 75;
                int i = 0;

                PictureBox pbox = new PictureBox();
                pbox.ImageLocation = @Form1.photos[i].Photolink; //TO DO: GET ALL PICTURES INSTEAD OF ONE!
                pbox.SizeMode = PictureBoxSizeMode.StretchImage;
                pbox.Top = top;
                pbox.Left = left;
                pbox.Height = height;
                pbox.Width = width;
                left += 88;
                this.Controls.Add(pbox);
                i++;
            }

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
             * -Establishment Information
             * -Change Main Picture Box's image when I click on another Picture Box Image
             * -Specifications about car
             * -Information about car
             * -Draw Line
            */

            Label specifications = new Label();
            specifications.Text = "Specificaties";
            specifications.Top = 325;
            specifications.Left = 22;
            specifications.Width = 300;
            specifications.Height = 300;
            specifications.Font = new Font("Arial", 20);

            foreach (var item in Form1.cars)
            {
                if (item.carID == carNumber)
                {
                    /* text(item.everything)
                     * top
                     * left
                     * height
                     * width
                     * font
                     * (x2 for Label Column & Column info)
                     * 
                     * label for column
                     * label for column info
                     * 
                */
                }
            }



            //all controls.
            this.Controls.Add(carName);
            this.Controls.Add(kmPrice);
            this.Controls.Add(mainPicture);
            this.Controls.Add(sellPrice);
            this.Controls.Add(availableAt);
            this.Controls.Add(hireButton);
            this.Controls.Add(specifications);

        }
        private void CarDetailPanel_Paint(object sender, PaintEventArgs e)
        {
            Pen blackpen = new Pen(Color.Black, 3);
            Graphics g = e.Graphics;
            g.DrawLine(blackpen, 0, 0, 200, 200);
            g.Dispose();
        }
    }
}


