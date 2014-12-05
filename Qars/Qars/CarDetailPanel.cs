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
        private Label fotoBeschrijving;
        private List<string> picturelink = new List<string>();
        private int currentCarNumber;

        public CarDetailPanel(int carNumber)
        {
            this.currentCarNumber = carNumber;
            this.Height = 568;
            this.Width = 1044;
            this.Top = 70;
            this.Left = 221;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = Color.White;

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
            availableAt.Width = 4000;
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
            Label hiredLabel = new Label();
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
            if (!VisualDemo.carList[carNumber].available)
            {
                hiredLabel.Top = 185;
                hiredLabel.Left = 525;
                hiredLabel.Width = 200;
                hiredLabel.Height = 30;
                hiredLabel.Font = new Font("Calibri", 14);
                this.Controls.Add(hiredLabel);

                foreach (var res in VisualDemo.reservationList)
                {
                    if (res.carID == carNumber)
                    {
                        hireButton.BackColor = Color.Orange;
                        hireButton.Text = "Verhuurd";
                    }
                }

                foreach (var rep in VisualDemo.damageList)
                {
                    if (rep.carID == carNumber && rep.repaired == false)
                    {
                        hireButton.Text = "Reparatie";
                        hireButton.BackColor = Color.Red;
                        hireButton.Enabled = false;
                    }
                }
            }

            int left = 22;

            foreach (CarPhoto photo in VisualDemo.carList[carNumber].PhotoList)
            {
                int top = 232;
                int height = 75;
                int width = 75;
                int i = 0;

                PictureBox pbox = new PictureBox();
                pbox.ImageLocation = photo.Photolink;
                pbox.SizeMode = PictureBoxSizeMode.StretchImage;
                pbox.Top = top;
                pbox.Left = left;
                pbox.Height = height;
                pbox.Width = width;
                left += 88;
                this.Controls.Add(pbox);

                pbox.MouseHover += new EventHandler(PictureHover);

                i++;
            }

            mainPicture = new PictureBox();
            mainPicture.Top = 22;
            mainPicture.Left = 22;
            mainPicture.Height = 185;
            mainPicture.Width = 350;
            if (VisualDemo.carList[carNumber].PhotoList.Count > 0)
            {
                mainPicture.ImageLocation = VisualDemo.carList[carNumber].PhotoList[0].Photolink;
            }

            mainPicture.SizeMode = PictureBoxSizeMode.StretchImage;

            Label fotoBeschrijvingBold = new Label();
            fotoBeschrijvingBold.Text = "Beschrijving: ";
            fotoBeschrijvingBold.Top = 211;
            fotoBeschrijvingBold.Left = 22;
            fotoBeschrijvingBold.Width = 88;
            fotoBeschrijvingBold.Height = 20;
            fotoBeschrijvingBold.Font = new Font("Calibri", 11, FontStyle.Bold);
            this.Controls.Add(fotoBeschrijvingBold);

            fotoBeschrijving = new Label();
            fotoBeschrijving.Top = 211;
            fotoBeschrijving.Left = 110;
            fotoBeschrijving.Width = 600;
            fotoBeschrijving.Height = 20;
            fotoBeschrijving.Font = new Font("Calibri", 11);
            fotoBeschrijving.Text = "NOT DONE YET. NEED HELP WITH CREATING EVENT.";
            this.Controls.Add(fotoBeschrijving);
            Label specifications = new Label();
            specifications.Text = "Specificaties";
            specifications.Top = 315;
            specifications.Left = 22;
            specifications.Width = 300;
            specifications.Height = 300;
            specifications.Font = new Font("Calibri", 20);

            int top1 = 355;
            int Left = 22;
            int count = 0;
            foreach (var item in specname)
            {
                if (count == 7 || count == 14 || count == 21)
                {
                    if (count == 14)
                    {
                        Left += 200;
                        top1 = 355;
                    }
                    else
                    {
                        Left += 240;
                        top1 = 355;
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
            CreateSpecInfo(this, VisualDemo.carList, carNumber);

            Label description = new Label();
            description.Text = "Beschrijving";
            description.Top = 20;
            description.Left = 700;
            description.Width = 165;
            description.Height = 32;
            description.Font = new Font("Calibri", 20);

            Label descriptioninfo = new Label();
            descriptioninfo.Text = VisualDemo.carList[carNumber].description;
            descriptioninfo.Top = 65;
            descriptioninfo.Left = 700;
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

            int top = 355;
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
                        top = 355;
                        left += 200;
                    }
                    else
                    {
                        top = 355;
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
                        item.Text = list[carnumber].horsepower.ToString() + " PK";
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
                        item.Text = list[carnumber].Fuelusage.ToString() + " liter per km";
                        item.Top = top;
                        item.Left = left;
                        item.Width = width + 7;
                        item.Height = height;
                        item.Font = new Font("Arial", 12);
                        panel.Controls.Add(item);

                        top += 30;

                        count++;
                        count2++;
                        break;
                    case 18:
                        item.Text = list[carnumber].motor;
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
        public void PictureText(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            string URL = mainPicture.ImageLocation;
        }
    }
}

