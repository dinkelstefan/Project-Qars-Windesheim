using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*TO DO:
 * 
 * Add more specs to specname
 * Make the panel only load in the values that are not null
 */
namespace Qars
{
    class CarDetailPanel : Panel
    {
        private List<PictureBox> pbox = new List<PictureBox>();
        private PictureBox mainPicture;
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

            Label specifications = new Label();
            specifications.Text = "Specificaties";
            specifications.Top = 315;
            specifications.Left = 22;
            specifications.Width = 300;
            specifications.Height = 300;
            specifications.Font = new Font("Calibri", 20);

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
            for (int i = 0; i <= 24; i++)
            {
                LabelList.Add(new Label());
            }

            int left1 = 22;
            int width1 = 120;

            int top = 355;
            int left = 140;
            int width = 105;
            int height = 30;

            int count = 0;
            int count2 = 0;
            foreach (var item in LabelList)
            {
                if (count2 == 7 || count2 == 14 || count2 == 21)
                {


                    top = 355;
                    left += 240;
                    left1 += 240;
                }


                switch (count)
                {
                    case 0:
                        if (list[carnumber].category == "")
                        {
                            count++;
                            continue;

                        }
                        else
                        {
                            Label label = new Label();
                            label.Text = "Categorie:";
                            label.Top = top;
                            label.Left = left1;
                            label.Width = width1;
                            label.Font = new Font("Calibri", 12, FontStyle.Bold);
                            label.Height = height;
                            this.Controls.Add(label);

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
                        }
                    case 1:
                        if (list[carnumber].modelyear == -1)
                        {
                            count++;
                            continue;
                        }
                        else
                        {
                            Label label = new Label();
                            label.Text = "Bouwjaar:";
                            label.Top = top;
                            label.Left = left1;
                            label.Width = width1;
                            label.Font = new Font("Calibri", 12, FontStyle.Bold);
                            label.Height = height;
                            this.Controls.Add(label);

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
                        }
                    case 2:
                        if (!list[carnumber].automatic)
                        {
                            count++;
                            continue;
                        }
                        else
                        {
                            Label label = new Label();
                            label.Text = "Automaat:";
                            label.Top = top;
                            label.Left = left1;
                            label.Width = width1;
                            label.Font = new Font("Calibri", 12, FontStyle.Bold);
                            label.Height = height;
                            this.Controls.Add(label);

                            item.Text = "Ja";
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
                        }
                    case 3:

                        if (!list[carnumber].automatic)
                        {
                            count++;
                            continue;
                        }
                        else
                        {
                            item.Text = list[carnumber].gearsamount.ToString();

                            Label label = new Label();
                            label.Text = "Versnellingen:";
                            label.Top = top;
                            label.Left = left1;
                            label.Width = width1;
                            label.Font = new Font("Calibri", 12, FontStyle.Bold);
                            label.Height = height;
                            this.Controls.Add(label);

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
                        }
                    case 4:
                        if (list[carnumber].motor == "")
                        {
                            count++;
                            continue;
                        }
                        else
                        {
                            Label label = new Label();
                            label.Text = "Motor:";
                            label.Top = top;
                            label.Left = left1;
                            label.Width = width1;
                            label.Font = new Font("Calibri", 12, FontStyle.Bold);
                            label.Height = height;
                            this.Controls.Add(label);

                            item.Text = list[carnumber].motor;
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
                        }
                    case 5:
                        if (list[carnumber].horsepower == -1)
                        {
                            count++;
                            continue;
                        }
                        else
                        {
                            Label label = new Label();
                            label.Text = "Vermogen:";
                            label.Top = top;
                            label.Left = left1;
                            label.Width = width1;
                            label.Font = new Font("Calibri", 12, FontStyle.Bold);
                            label.Height = height;
                            this.Controls.Add(label);

                            item.Text = list[carnumber].horsepower + " PK";
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
                        }
                    case 6:
                        if (list[carnumber].Fuelusage == -1)
                        {
                            count++;
                            continue;

                        }
                        else
                        {
                            Label label = new Label();
                            label.Text = "Verbruik:";
                            label.Top = top;
                            label.Left = left1;
                            label.Width = width1;
                            label.Font = new Font("Calibri", 12, FontStyle.Bold);
                            label.Height = height;
                            this.Controls.Add(label);

                            item.Text = list[carnumber].Fuelusage.ToString() + " liter per km";
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
                        }
                    case 7:
                        if (list[carnumber].kilometres == -1)
                        {
                            count++;
                            continue;
                        }
                        else
                        {
                            Label label = new Label();
                            label.Text = "Kilometers:";
                            label.Top = top;
                            label.Left = left1;
                            label.Width = width1;
                            label.Font = new Font("Calibri", 12, FontStyle.Bold);
                            label.Height = height;
                            this.Controls.Add(label);

                            item.Text = list[carnumber].kilometres.ToString();
                            item.Top = top;
                            item.Left = left;
                            item.Width = width;
                            item.Height = height;
                            item.Font = new Font("Calibri", 12);
                            panel.Controls.Add(item);

                            top += 30;
                            count2++;
                            count++;
                            break;
                        }
                    case 8:
                        if (list[carnumber].motdate == "")
                        {
                            count++;
                            continue;
                        }
                        else
                        {
                            Label label = new Label();
                            label.Text = "APK:";
                            label.Top = top;
                            label.Left = left1;
                            label.Width = width1;
                            label.Font = new Font("Calibri", 12, FontStyle.Bold);
                            label.Height = height;
                            this.Controls.Add(label);

                            item.Text = list[carnumber].motdate;
                            item.Top = top;
                            item.Left = left;
                            item.Width = width;
                            item.Height = height;
                            item.Font = new Font("Calibri", 12);
                            panel.Controls.Add(item);

                            top += 30;

                            count2++;
                            count++;
                            break;
                        }
                    case 9:
                        if (list[carnumber].length == -1)
                        {
                            count++;
                            continue;
                        }
                        else
                        {
                            Label label = new Label();
                            label.Text = "Lengte";
                            label.Top = top;
                            label.Left = left1;
                            label.Width = width1;
                            label.Font = new Font("Calibri", 12, FontStyle.Bold);
                            label.Height = height;
                            this.Controls.Add(label);

                            item.Text = list[carnumber].length + " cm";
                            item.Top = top;
                            item.Left = left;
                            item.Width = width;
                            item.Height = height;
                            item.Font = new Font("Calibri", 12);
                            panel.Controls.Add(item);

                            top += 30;

                            count2++;
                            count++;
                            break;
                        }
                    case 10:
                        if (list[carnumber].width == -1)
                        {
                            count++;
                            continue;
                        }
                        else
                        {
                            Label label = new Label();
                            label.Text = "Breedte:";
                            label.Top = top;
                            label.Left = left1;
                            label.Width = width1;
                            label.Font = new Font("Calibri", 12, FontStyle.Bold);
                            label.Height = height;
                            this.Controls.Add(label);

                            item.Text = list[carnumber].width + " cm";
                            item.Top = top;
                            item.Left = left;
                            item.Width = width;
                            item.Height = height;
                            item.Font = new Font("Calibri", 12);
                            panel.Controls.Add(item);

                            top += 30;
                            count2++;
                            count++;
                            break;
                        }
                    case 11:
                        if (list[carnumber].height == -1)
                        {
                            count++;
                            continue;
                        }
                        else
                        {
                            Label label = new Label();
                            label.Text = "Hoogte:";
                            label.Top = top;
                            label.Left = left1;
                            label.Width = width1;
                            label.Font = new Font("Calibri", 12, FontStyle.Bold);
                            label.Height = height;
                            this.Controls.Add(label);

                            item.Text = list[carnumber].height + " cm";
                            item.Top = top;
                            item.Left = left;
                            item.Width = width;
                            item.Height = height;
                            item.Font = new Font("Calibri", 12);
                            panel.Controls.Add(item);

                            top += 30;
                            count2++;
                            count++;
                            break;
                        }
                    case 12:
                        if (list[carnumber].weight == -1)
                        {
                            count++;
                            continue;
                        }
                        else
                        {
                            Label label = new Label();
                            label.Text = "Gewicht:";
                            label.Top = top;
                            label.Left = left1;
                            label.Width = width1;
                            label.Font = new Font("Calibri", 12, FontStyle.Bold);
                            label.Height = height;
                            this.Controls.Add(label);

                            item.Text = list[carnumber].weight.ToString() + " kg";
                            item.Top = top;
                            item.Left = left;
                            item.Width = width;
                            item.Height = height;
                            item.Font = new Font("Calibri", 12);
                            panel.Controls.Add(item);

                            top += 30;
                            count2++;
                            count++;
                            break;
                        }
                    case 13:
                        if (list[carnumber].colour == "")
                        {
                            count++;
                            continue;
                        }
                        else
                        {
                            Label label = new Label();
                            label.Text = "Kleur:";
                            label.Top = top;
                            label.Left = left1;
                            label.Width = width1;
                            label.Font = new Font("Calibri", 12, FontStyle.Bold);
                            label.Height = height;
                            this.Controls.Add(label);

                            item.Text = list[carnumber].colour;
                            item.Top = top;
                            item.Left = left;
                            item.Width = width;
                            item.Height = height;
                            item.Font = new Font("Calibri", 12);
                            panel.Controls.Add(item);

                            top += 30;
                            count2++;
                            count++;
                            break;
                        }
                    case 14:
                        if (list[carnumber].doors == -1)
                        {
                            count++;
                            continue;
                        }
                        else
                        {
                            Label label = new Label();
                            label.Text = "Deuren:";
                            label.Top = top;
                            label.Left = left1;
                            label.Width = width1;
                            label.Font = new Font("Calibri", 12, FontStyle.Bold);
                            label.Height = height;
                            this.Controls.Add(label);

                            item.Text = list[carnumber].doors.ToString();
                            item.Top = top;
                            item.Left = left;
                            item.Width = width;
                            item.Height = height;
                            item.Font = new Font("Calibri", 12);
                            panel.Controls.Add(item);

                            top += 30;
                            count2++;
                            count++;
                            break;
                        }
                    case 15:
                        if (!list[carnumber].stereo)
                        {
                            count++;
                            continue;
                        }
                        else
                        {
                            Label label = new Label();
                            label.Text = "Stereo:";
                            label.Top = top;
                            label.Left = left1;
                            label.Width = width1;
                            label.Font = new Font("Calibri", 12, FontStyle.Bold);
                            label.Height = height;
                            this.Controls.Add(label);

                            item.Text = list[carnumber].stereo.ToString();
                            item.Top = top;
                            item.Left = left;
                            item.Width = width;
                            item.Height = height;
                            item.Font = new Font("Calibri", 12);
                            panel.Controls.Add(item);

                            top += 30;
                            count2++;
                            count++;
                            break;
                        }
                    case 16:
                        if (!list[carnumber].bluetooth)
                        {
                            count++;
                            continue;
                        }
                        else
                        {
                            Label label = new Label();
                            label.Text = "Bluetooth:";
                            label.Top = top;
                            label.Left = left1;
                            label.Width = width1;
                            label.Font = new Font("Calibri", 12, FontStyle.Bold);
                            label.Height = height;
                            this.Controls.Add(label);

                            item.Text = list[carnumber].bluetooth.ToString();
                            item.Top = top;
                            item.Left = left;
                            item.Width = width;
                            item.Height = height;
                            item.Font = new Font("Calibri", 12);
                            panel.Controls.Add(item);

                            top += 30;
                            count2++;
                            count++;

                            break;
                        }
                    case 17:
                        if (!list[carnumber].navigation)
                        {
                            count++;
                            continue;
                        }
                        else
                        {

                            Label label = new Label();
                            label.Text = "Navigatie:";
                            label.Top = top;
                            label.Left = left1;
                            label.Width = width1;
                            label.Font = new Font("Calibri", 12, FontStyle.Bold);
                            label.Height = height;
                            this.Controls.Add(label);

                            item.Text = "Ja";
                            item.Top = top;
                            item.Left = left;
                            item.Width = width + 7;
                            item.Height = height;
                            item.Font = new Font("Calibri", 12);
                            panel.Controls.Add(item);

                            top += 30;
                            count2++;
                            count++;
                            break;
                        }
                    case 18:
                        if (!list[carnumber].parkingAssist)
                        {
                            count++;
                            continue;
                        }
                        else
                        {
                            Label label = new Label();
                            label.Text = "Parkeerhulp:";
                            label.Top = top;
                            label.Left = left1;
                            label.Width = width1;
                            label.Font = new Font("Calibri", 12, FontStyle.Bold);
                            label.Height = height;
                            this.Controls.Add(label);

                            item.Text = list[carnumber].parkingAssist.ToString();
                            item.Top = top;
                            item.Left = left;
                            item.Width = width;
                            item.Height = height;
                            item.Font = new Font("Calibri", 12);
                            panel.Controls.Add(item);

                            top += 30;
                            count2++;
                            count++;
                            break;
                        }
                    case 19:
                        if (!list[carnumber].fourwheeldrive)
                        {
                            count++;
                            continue;
                        }
                        else
                        {
                            Label label = new Label();
                            label.Text = "4WD:";
                            label.Top = top;
                            label.Left = left1;
                            label.Width = width1;
                            label.Font = new Font("Calibri", 12, FontStyle.Bold);
                            label.Height = height;
                            this.Controls.Add(label);

                            item.Text = "Ja";
                            item.Top = top;
                            item.Left = left;
                            item.Width = width;
                            item.Height = height;
                            item.Font = new Font("Calibri", 12);
                            panel.Controls.Add(item);

                            top += 30;
                            count2++;
                            count++;
                            break;
                        }
                    case 20:
                        if (!list[carnumber].cabrio)
                        {
                            count++;
                            continue;
                        }
                        else
                        {
                            Label label = new Label();
                            label.Text = "Cabrio:";
                            label.Top = top;
                            label.Left = left1;
                            label.Width = width1;
                            label.Font = new Font("Calibri", 12, FontStyle.Bold);
                            label.Height = height;
                            this.Controls.Add(label);

                            item.Text = "Ja";
                            item.Top = top;
                            item.Left = left;
                            item.Width = width;
                            item.Height = height;
                            item.Font = new Font("Calibri", 12);
                            panel.Controls.Add(item);

                            top += 30;
                            count2++;
                            count++;
                            break;
                        }
                    case 21:
                        if (!list[carnumber].airco)
                        {
                            count++;
                            continue;
                        }
                        else
                        {
                            Label label = new Label();
                            label.Text = "Airco:";
                            label.Top = top;
                            label.Left = left1;
                            label.Width = width1;
                            label.Font = new Font("Calibri", 12, FontStyle.Bold);
                            label.Height = height;
                            this.Controls.Add(label);

                            item.Text = list[carnumber].airco.ToString();
                            item.Top = top;
                            item.Left = left;
                            item.Width = width;
                            item.Height = height;
                            item.Font = new Font("Calibri", 12);
                            panel.Controls.Add(item);

                            top += 30;
                            count2++;
                            count++;
                            break;
                        }

                    case 22:
                        if (list[carnumber].seats == -1)
                        {
                            count++;
                            continue;
                        }
                        else
                        {
                            Label label = new Label();
                            label.Text = "Stoelen:";
                            label.Top = top;
                            label.Left = left1;
                            label.Width = width1;
                            label.Font = new Font("Calibri", 12, FontStyle.Bold);
                            label.Height = height;
                            this.Controls.Add(label);

                            item.Text = list[carnumber].seats.ToString();
                            item.Top = top;
                            item.Left = left;
                            item.Width = width;
                            item.Height = height;
                            item.Font = new Font("Calibri", 12);
                            panel.Controls.Add(item);

                            top += 30;
                            count2++;
                            count++;
                            break;
                        }
                    case 23:
                        if (list[carnumber].storagespace == -1)
                        {
                            count++;
                            continue;
                        }
                        else
                        {
                            Label label = new Label();
                            label.Text = "Ruimte:";
                            label.Top = top;
                            label.Left = left1;
                            label.Width = width1;
                            label.Font = new Font("Calibri", 12, FontStyle.Bold);
                            label.Height = height;
                            this.Controls.Add(label);

                            item.Text = list[carnumber].storagespace + " liter";
                            item.Top = top;
                            item.Left = left;
                            item.Width = width;
                            item.Height = height;
                            item.Font = new Font("Calibri", 12);
                            panel.Controls.Add(item);

                            top += 30;
                            count2++;
                            count++;
                            break;
                        }
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

    }
}

