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
        private string[] specname = { "Categorie:", "Bouwjaar:", "Automaat:", "Kilometers:", "Kleur:", "Deuren:", "Stereo:", "Bluetooth:", "Vermogen:", "Lengte:", "Breedte:", "Hoogte:", "Airco:", "Stoelen:", "APK:", "Ruimte:", "Versnellingen:", "Verbruik", "Motor" };
        private PictureBox mainPicture;
        private List<string> picturelink = new List<string>();
        private int currentCarNumber;

        public CarDetailPanel(int carNumber)
        {
            this.currentCarNumber = carNumber;
            //Properties of the panel
            this.Height = 568;
            this.Width = 1044;
            this.Top = 70;
            this.Left = 221;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = Color.White;

            //Text and other stuff
            Label carName = new Label();
            carName.Text = VisualDemo.carList[carNumber].brand + " " + VisualDemo.carList[carNumber].model;
            carName.Top = 20;
            carName.Left = 375;
            carName.Width = 300;
            carName.Height = 28;
            carName.Font = new Font("Calibri", 20);

            Label startprice = new Label();
            startprice.Text = "Beginprijs: € " + VisualDemo.carList[carNumber].startprice;
            startprice.Top = 70;
            startprice.Left = 375;
            startprice.Width = 200;
            startprice.Height = 27;
            startprice.Font = new Font("Calibri", 14);

            Label kmprice = new Label();
            kmprice.Text = "Prijs per Kilometer: € " + VisualDemo.carList[carNumber].rentalprice;
            kmprice.Top = 100;
            kmprice.Left = 375;
            kmprice.Width = 225;
            kmprice.Height = 27;
            kmprice.Font = new Font("Calibri", 14);


            Label availableAt = new Label();
            foreach (var bedrijf in VisualDemo.EstablishmentList)
            {
                if (VisualDemo.carList[carNumber].establishmentID == bedrijf.establishmentID)
                {
                    availableAt.Text = "Verkrijgbaar bij: " + bedrijf.name;

                }
            }
            availableAt.Top = 130;
            availableAt.Left = 375;
            availableAt.Width = 250;
            availableAt.Height = 27;
            availableAt.Font = new Font("Calibri", 14);

            Button backButton = new Button();
            backButton.Text = "Sluiten";
            backButton.BackColor = Color.Red;
            backButton.Top = -5;
            backButton.Left = 950;
            backButton.Width = 100;
            backButton.Height = 40;
            backButton.ForeColor = Color.White;
            backButton.Font = new Font("Calibri", 11, FontStyle.Bold);
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.Click += new EventHandler(BackButtonClick);

            Button hireButton = new Button();
            hireButton.Click += new EventHandler(hireButtonClick);
            hireButton.Text = "Huren";
            hireButton.BackColor = Color.Green;
            hireButton.Top = 180;
            hireButton.Left = 375;
            hireButton.Width = 150;
            hireButton.Height = 29;
            hireButton.ForeColor = Color.White;
            hireButton.Font = new Font("Calibri", 11, FontStyle.Bold);
            hireButton.FlatStyle = FlatStyle.Flat;
            if (!VisualDemo.carList[carNumber].available) //Niet beschikbaar. Kapot/Verhuurd!
            {
                hireButton.BackColor = Color.Orange;

                Label hiredLabel = new Label();
                hiredLabel.Top = 185;
                hiredLabel.Left = 525;
                hiredLabel.Width = 700;
                hiredLabel.Height = 30;
                hiredLabel.Font = new Font("Calibri", 12);
                this.Controls.Add(hiredLabel);



                //check if a reservation is current
                foreach (var res in VisualDemo.reservationList)
                {

                    if (res.carID == carNumber) //Auto is geserveerd. 
                    {
                        hiredLabel.Text = "Momenteel verhuurd";
                    }
                }
                /*
                //check if a car is being repaired
                foreach (var rep in VisualDemo.damageList)
                {
                    if (rep.carID == carNumber && rep.repaired == false) //car is broken down and not repaired
                    {
                        hiredLabel.Text = "Deze auto wordt gerepareerd."; //Do I need to add a "Available at"?
                        hiredLabel.BackColor = Color.Red;
                    }
                }
                */
            }

            int left = 22;

            foreach (CarPhoto photo in VisualDemo.carList[carNumber].PhotoList)
            {
                int top = 222;
                int height = 75;
                int width = 75;
                int i = 0;

                PictureBox pbox = new PictureBox();
                pbox.ImageLocation = photo.Photolink; //TO DO: Bug test: Does it work for just 1 car or is this all cars?
                pbox.SizeMode = PictureBoxSizeMode.StretchImage;
                pbox.Top = top;
                pbox.Left = left;
                pbox.Height = height;
                pbox.Width = width;
                left += 88;
                this.Controls.Add(pbox);
                i++;
                pbox.MouseHover += new EventHandler(PictureHover);
            }
            //Main picture box
            mainPicture = new PictureBox();
            mainPicture.Top = 22;
            mainPicture.Left = 22;
            mainPicture.Height = 185;
            mainPicture.Width = 350;

            // check if the car has a picture and add it as a main picture
            if (VisualDemo.carList[carNumber].PhotoList.Count > 0)
            {
                mainPicture.ImageLocation = VisualDemo.carList[carNumber].PhotoList[0].Photolink; //foto's met stefan
            }

            mainPicture.SizeMode = PictureBoxSizeMode.StretchImage;

            Label specifications = new Label();
            specifications.Text = "Specificaties";
            specifications.Top = 305;
            specifications.Left = 22;
            specifications.Width = 300;
            specifications.Height = 300;
            specifications.Font = new Font("Calibri", 20);

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
                specLabel.Font = new Font("Calibri", 12, FontStyle.Bold);
                specLabel.Height = height;

                this.Controls.Add(specLabel);

                top1 += 30;
                count += 1;

            }
            //Create the information
            CreateSpecInfo(this, VisualDemo.carList, carNumber);

            Label description = new Label();
            description.Text = "Beschrijving";
            description.Top = 20;
            description.Left = 690;
            description.Width = 165;
            description.Height = 32;
            description.Font = new Font("Calibri", 20);

            Label descriptioninfo = new Label(); /*Maximum: ~686 characters */
            descriptioninfo.Text = VisualDemo.carList[carNumber].description;
            descriptioninfo.Top = 65;
            descriptioninfo.Left = 690;
            descriptioninfo.Width = 300;
            descriptioninfo.Height = 300;
            descriptioninfo.Font = new Font("Calibri", 9);

            //all controls.
            this.Controls.Add(carName);
            this.Controls.Add(startprice);
            this.Controls.Add(kmprice);
            this.Controls.Add(mainPicture);
            this.Controls.Add(availableAt);
            this.Controls.Add(hireButton);
            this.Controls.Add(specifications);
            this.Controls.Add(description);
            this.Controls.Add(descriptioninfo);
            this.Controls.Add(backButton);
        }

        private void CreateSpecInfo(Panel panel, List<Car> list, int carnumber)
        {
            List<Label> LabelList = new List<Label>();
            for (int i = 0; i <= 18; i++)
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
                        item.Font = new Font("Calibri", 12);
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
                        item.Font = new Font("Calibri", 12);
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
                        item.Font = new Font("Calibri", 12);
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
                        item.Font = new Font("Calibri", 12);
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
                        item.Font = new Font("Calibri", 12);
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
                        item.Font = new Font("Calibri", 12);
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
                        item.Font = new Font("Calibri", 12);
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
                        item.Font = new Font("Calibri", 12);
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
                        item.Font = new Font("Calibri", 12);
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
                        item.Font = new Font("Calibri", 12);
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
                        item.Font = new Font("Calibri", 12);
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
                        item.Font = new Font("Calibri", 12);
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
                        item.Font = new Font("Calibri", 12);
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
                        item.Font = new Font("Calibri", 12);
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
                        item.Font = new Font("Calibri", 12);
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
                        item.Font = new Font("Calibri", 12);
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
                        item.Font = new Font("Calibri", 12);
                        panel.Controls.Add(item);

                        top += 30;

                        count++;
                        count2++;
                        break;
                    case 17:
                        item.Text = list[carnumber].Fuelusage.ToString() + " per k.m";
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
                    case 18:
                        item.Text = list[carnumber].motor;
                        Console.WriteLine(list[carnumber].motor);
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
        public void PictureHover(object sender, EventArgs e)
        {
            PictureBox smallbox = (PictureBox)sender;
            mainPicture.ImageLocation = smallbox.ImageLocation;
            Console.WriteLine("Ik hover nu");
        }

        public void BackButtonClick(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void hireButtonClick(object sender, EventArgs e)
        {
            RentCarPanel rentcarpanel = new RentCarPanel(this.currentCarNumber);
            this.Controls.Add(rentcarpanel);
            rentcarpanel.BringToFront();
            rentcarpanel.Show();
        }
    }
}

