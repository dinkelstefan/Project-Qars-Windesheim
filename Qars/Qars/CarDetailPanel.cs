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
        private List<string> picturelink = new List<string>();
        private int currentCarNumber;
        private string availableat;
        private PictureBox mainpicture;

        public CarDetailPanel(int carNumber)
        {   //properties of the panel
            this.currentCarNumber = carNumber;
            this.Height = 568;
            this.Width = 1044;
            this.Top = 70;
            this.Left = 221;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = Color.White;

            //all the labels, images and buttons
            Label carname = createLabel(VisualDemo.carList[carNumber].brand + " " + VisualDemo.carList[carNumber].model, 20, 375, 300, 28, 20, FontStyle.Regular);
            Label beginprice = createLabel("Beginprijs: € " + VisualDemo.carList[carNumber].startprice, 70, 375, 200, 27, 14, FontStyle.Regular);
            Label priceperkm = createLabel("Prijs per Kilometer: € " + VisualDemo.carList[carNumber].rentalprice, 100, 375, 225, 27, 14, FontStyle.Regular);
            Label establishment = createLabel(availableat, 130, 375, 327, 27, 14, FontStyle.Regular);
            Label specs = createLabel("Specificaties", 315, 22, 300, 32, 20, FontStyle.Regular);
            Label desc = createLabel("Beschrijving", 20, 700, 165, 32, 20, FontStyle.Regular);
            Label descinfo = createLabel(VisualDemo.carList[carNumber].description, 65, 700, 300, 300, 9, FontStyle.Regular);
            Button close = createButton("Sluiten", Color.Red, Color.White, -5, 950, 100, 40, 11, FontStyle.Bold, FlatStyle.Flat, BackButtonClick);
            Button hire = createButton("Huren", Color.Green, Color.White, 180, 375, 150, 29, 11, FontStyle.Bold, FlatStyle.Flat, hireButtonClick);

            mainpicture = createPictureBox("", PictureBoxSizeMode.StretchImage, 22, 22, 185, 350, null);
            CreateSpecInfo(this, VisualDemo.carList, carNumber);

            //Look up where the Car is available
            foreach (var company in VisualDemo.EstablishmentList)
            {
                if (VisualDemo.carList[carNumber].establishmentID == company.establishmentID)
                {
                    availableat = "Verkrijgbaar bij: " + company.name;
                }
            }

            //look up if the car is available
            foreach (var res in VisualDemo.reservationList)
            {
                if (!VisualDemo.carList[carNumber].available)
                {
                    if (res.carID == carNumber)
                    {
                        hire.BackColor = Color.Orange;
                        hire.Text = "Verhuurd";
                    }
                }
                //look up if the car is being repaired
                foreach (var rep in VisualDemo.damageList)
                {
                    if (rep.carID == carNumber && rep.repaired == false)
                    {
                        hire.Text = "Reparatie";
                        hire.BackColor = Color.Red;
                        hire.Enabled = false;
                    }
                }
            }

            //Create the small pictures
            int left = 22;
            foreach (CarPhoto photo in VisualDemo.carList[carNumber].PhotoList)
            {
                PictureBox pbox = createPictureBox(photo.Photolink, PictureBoxSizeMode.StretchImage, 232, left, 75, 75, PictureHover);
                left += 88;
            }
            //Select the main picture
            if (VisualDemo.carList[carNumber].PhotoList.Count > 0)
            {
                mainpicture.ImageLocation = VisualDemo.carList[carNumber].PhotoList[0].Photolink;
            }
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
                            createLabel("Categorie", top, left1, width, height, 12, FontStyle.Bold);
                            createLabel(list[carnumber].category, top, left, width, height, 12, FontStyle.Regular);
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
                            createLabel("Bouwjaar", top, left1, width, height, 12, FontStyle.Bold);
                            createLabel(list[carnumber].model.ToString(), top, left, width, height, 12, FontStyle.Regular);
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
                            Label label = new Label();
                            label.Text = "Versnellingen:";
                            label.Top = top;
                            label.Left = left1;
                            label.Width = width1;
                            label.Font = new Font("Calibri", 12, FontStyle.Bold);
                            label.Height = height;
                            this.Controls.Add(label);
                            item.Text = list[carnumber].gearsamount.ToString();
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
            mainpicture.ImageLocation = smallbox.ImageLocation;
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

        public Label createLabel(string text, int top, int left, int width, int height, int fontsize, FontStyle style)
        {
            Label label = new Label();
            label.Text = text;
            label.Top = top;
            label.Left = left;
            label.Width = width;
            label.Height = height;
            label.Font = new Font("Calibri", fontsize, style);
            this.Controls.Add(label);
            return label;
        }
        public Button createButton(string text, Color backcolor, Color forecolor, int top, int left, int width, int height, int fontsize, FontStyle fontstyle, FlatStyle flatstyle, EventHandler handler)
        {
            Button button = new Button();
            button.Text = text;
            button.BackColor = backcolor;
            button.Top = top;
            button.Left = left;
            button.Width = width;
            button.Height = height;
            button.ForeColor = forecolor;
            button.Font = new Font("Calibri", fontsize, fontstyle);
            button.FlatStyle = flatstyle;
            button.Click += new EventHandler(handler);
            this.Controls.Add(button);
            return button;
        }
        public PictureBox createPictureBox(string location, PictureBoxSizeMode sizemode, int top, int left, int height, int width, EventHandler handler)
        {
            PictureBox pbox = new PictureBox();
            pbox.ImageLocation = location;
            pbox.SizeMode = sizemode;
            pbox.Top = top;
            pbox.Left = left;
            pbox.Height = height;
            pbox.Width = width;
            pbox.MouseHover += new EventHandler(PictureHover);
            this.Controls.Add(pbox);
            return pbox;
        }

    }
}

