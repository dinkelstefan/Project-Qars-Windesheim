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
        private string[] specname = { "Categorie:", "Bouwjaar:", "Automaat:", "Kilometers:", "Kleur:", "Deuren:", "Stereo:", "Bluetooth:", "PK:", "Lengte:", "Breedte:", "Hoogte:", "Airco:", "Stoelen:", "APK:", "Ruimte:", "Versnellingen:" };
        private int currentCarNumber;
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
            hireButton.Click += new EventHandler(hireButtonClick);
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
                pbox.ImageLocation = item.Photolink; //TO DO: Bug test: Does it work for just 1 car or is this all cars?
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
            mainPicture.ImageLocation = @Form1.photos[0].Photolink; //foto's met stefan
            mainPicture.SizeMode = PictureBoxSizeMode.StretchImage;

            Label specifications = new Label();
            specifications.Text = "Specificaties";
            specifications.Top = 305;
            specifications.Left = 22;
            specifications.Width = 300;
            specifications.Height = 300;
            specifications.Font = new Font("Arial", 20);

            //Code for the Column Name
            int top1 = 350;
            int Left = 22;
            int count = 0;
            foreach (var item in specname)
            {
                if (count == 7 || count == 14 || count == 21)
                {
                    if (count == 14)
                    {
                        Left += 200;
                        top1 = 350;
                    }
                    else
                    {
                        Left += 240;
                        top1 = 350;
                    }
                }
                int width = 120;
                int height = 30;

                Label specLabel = new Label();
                specLabel.Text = item;
                specLabel.Top = top1;
                specLabel.Left = Left;
                specLabel.Width = width;
                specLabel.Font = new Font("Arial", 12, FontStyle.Bold);
                specLabel.Height = height;

                this.Controls.Add(specLabel);

                top1 += 30;
                count += 1;

            }
            //Create the information
            CreateSpecInfo(this, Form1.cars, carNumber);

            Label description = new Label();
            description.Text = "Beschrijving";
            description.Top = 305;
            description.Left = 690;
            description.Width = 165;
            description.Height = 32;
            description.Font = new Font("Arial", 20);

            Label descriptioninfo = new Label(); /*Maximum: ~686 characters */
            descriptioninfo.Text = Form1.cars[carNumber].description;
            descriptioninfo.Top = 350;
            descriptioninfo.Left = 690;
            descriptioninfo.Width = 300;
            descriptioninfo.Height = 300;
            descriptioninfo.Font = new Font("Arial", 9);

            //all controls.
            this.Controls.Add(carName);
            this.Controls.Add(kmPrice);
            this.Controls.Add(mainPicture);
            this.Controls.Add(sellPrice);
            this.Controls.Add(availableAt);
            this.Controls.Add(hireButton);
            this.Controls.Add(specifications);
            this.Controls.Add(description);
            this.Controls.Add(descriptioninfo);
        }


        private void CreateSpecInfo(Panel panel, List<Car> list, int carnumber)
        {
            List<Label> LabelList = new List<Label>();
            for (int i = 0; i <= 17; i++)
            {
                LabelList.Add(new Label());
            }

            int top = 350;
            int left = 140;
            int width = 105;
            int height = 30;
            int count = 0;
            int count2 = 0;

            foreach (var item in LabelList)
            {
                if (count == 7 || count == 14 || count == 21)
                {
                    if (count == 14)
                    {
                        top = 350;
                        left += 200;
                    }
                    else
                    {
                        top = 350;
                        left += 240;
                    }
                }
                switch (count2)
                {
                    case 0:
                        item.Text = list[carnumber].category;
                        item.Top = top;
                        item.Left = left;
                        item.Width = width;
                        item.Height = height;
                        item.Font = new Font("Arial", 12);
                        panel.Controls.Add(item);

                        top += 30;

                        count++;
                        count2++;
                        break;
                    case 1:
                        item.Text = list[carnumber].modelyear.ToString();
                        item.Top = top;
                        item.Left = left;
                        item.Width = width;
                        item.Height = height;
                        item.Font = new Font("Arial", 12);
                        panel.Controls.Add(item);

                        top += 30;

                        count++;
                        count2++;
                        break;
                    case 2:
                        if (list[carnumber].automatic)
                        {
                            item.Text = "Ja";
                        }
                        else
                        {
                            item.Text = "Nee";
                        }
                        item.Top = top;
                        item.Left = left;
                        item.Width = width;
                        item.Height = height;
                        item.Font = new Font("Arial", 12);
                        panel.Controls.Add(item);

                        top += 30;

                        count++;
                        count2++;
                        break;
                    case 3:
                        item.Text = list[carnumber].kilometres.ToString();
                        item.Top = top;
                        item.Left = left;
                        item.Width = width;
                        item.Height = height;
                        item.Font = new Font("Arial", 12);
                        panel.Controls.Add(item);

                        top += 30;

                        count++;
                        count2++;
                        break;
                    case 4:
                        item.Text = list[carnumber].colour;
                        item.Top = top;
                        item.Left = left;
                        item.Width = width;
                        item.Height = height;
                        item.Font = new Font("Arial", 12);
                        panel.Controls.Add(item);

                        top += 30;

                        count++;
                        count2++;
                        break;
                    case 5:
                        item.Text = list[carnumber].doors.ToString();
                        item.Top = top;
                        item.Left = left;
                        item.Width = width;
                        item.Height = height;
                        item.Font = new Font("Arial", 12);
                        panel.Controls.Add(item);

                        top += 30;

                        count++;
                        count2++;
                        break;
                    case 6:
                        if (list[carnumber].stereo)
                        {
                            item.Text = "Ja";
                        }
                        else
                        {
                            item.Text = "Nee";
                        }
                        item.Top = top;
                        item.Left = left;
                        item.Width = width;
                        item.Height = height;
                        item.Font = new Font("Arial", 12);
                        panel.Controls.Add(item);

                        top += 30;

                        count++;
                        count2++;
                        break;
                    case 7:
                        if (list[carnumber].automatic)
                        {
                            item.Text = "Ja";
                        }
                        else
                        {
                            item.Text = "Nee";
                        }
                        item.Top = top;
                        item.Left = left;
                        item.Width = width;
                        item.Height = height;
                        item.Font = new Font("Arial", 12);
                        panel.Controls.Add(item);

                        top += 30;

                        count++;
                        count2++;
                        break;
                    case 8:
                        item.Text = list[carnumber].horsepower.ToString();
                        item.Top = top;
                        item.Left = left;
                        item.Width = width;
                        item.Height = height;
                        item.Font = new Font("Arial", 12);
                        panel.Controls.Add(item);

                        top += 30;

                        count++;
                        count2++;
                        break;
                    case 9:
                        item.Text = list[carnumber].length + " cm";
                        item.Top = top;
                        item.Left = left;
                        item.Width = width;
                        item.Height = height;
                        item.Font = new Font("Arial", 12);
                        panel.Controls.Add(item);

                        top += 30;

                        count++;
                        count2++;
                        break;
                    case 10:
                        item.Text = list[carnumber].width + " cm";
                        item.Top = top;
                        item.Left = left;
                        item.Width = width;
                        item.Height = height;
                        item.Font = new Font("Arial", 12);
                        panel.Controls.Add(item);

                        top += 30;

                        count++;
                        count2++;
                        break;
                    case 11:
                        item.Text = list[carnumber].height + " cm";
                        item.Top = top;
                        item.Left = left;
                        item.Width = width;
                        item.Height = height;
                        item.Font = new Font("Arial", 12);
                        panel.Controls.Add(item);

                        top += 30;

                        count++;
                        count2++;
                        break;
                    case 12:
                        if (list[carnumber].automatic)
                        {
                            item.Text = "Ja";
                        }
                        else
                        {
                            item.Text = "Nee";
                        }
                        item.Top = top;
                        item.Left = left;
                        item.Width = width;
                        item.Height = height;
                        item.Font = new Font("Arial", 12);
                        panel.Controls.Add(item);

                        top += 30;

                        count++;
                        count2++;
                        break;
                    case 13:
                        item.Text = list[carnumber].doors.ToString();
                        item.Top = top;
                        item.Left = left;
                        item.Width = width;
                        item.Height = height;
                        item.Font = new Font("Arial", 12);
                        panel.Controls.Add(item);

                        top += 30;

                        count++;
                        count2++;
                        break;
                    case 14:
                        item.Text = list[carnumber].motdate;
                        item.Top = top;
                        item.Left = left;
                        item.Width = width;
                        item.Height = height;
                        item.Font = new Font("Arial", 12);
                        panel.Controls.Add(item);

                        top += 30;

                        count++;
                        count2++;
                        break;
                    case 15:
                        item.Text = list[carnumber].storagespace.ToString() + " Liter";
                        item.Top = top;
                        item.Left = left;
                        item.Width = width;
                        item.Height = height;
                        item.Font = new Font("Arial", 12);
                        panel.Controls.Add(item);

                        top += 30;

                        count++;
                        count2++;
                        break;
                    case 16:
                        if (list[carnumber].automatic)
                        {
                            item.Text = "N.V.T.";
                        }
                        else
                        {
                            item.Text = list[carnumber].gearsamount.ToString();
                        }
                        item.Top = top;
                        item.Left = left;
                        item.Width = width;
                        item.Height = height;
                        item.Font = new Font("Arial", 12);
                        panel.Controls.Add(item);

                        top += 30;

                        count++;
                        count2++;
                        break;
                }
            }
        }
            public void hireButtonClick(object sender, EventArgs e){
                RentCarPanel rentcarpanel = new RentCarPanel(this.currentCarNumber);
                this.Controls.Add(rentcarpanel);
                rentcarpanel.BringToFront();
                rentcarpanel.Show();
            }
        }
    }

