using Qars.Models;
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
    public class CarDetailPanel : Panel
    {
        public int UserID { get; set; }
        private List<PictureBox> pbox = new List<PictureBox>();
        private List<string> picturelink = new List<string>();
        private int currentCarNumber;
        private PictureBox mainpicture;
        private VisualDemo qarsApplication;
        private string availableat;
        private Discount discount;
        public CarDetailPanel(int carNumber, int UserID, VisualDemo qarsApp, Discount dis)
        {   //properties of the panel

            this.currentCarNumber = carNumber;
            this.Height = 568;
            this.Width = 1016;
            this.Top = 70;
            this.Left = 250;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = Color.White;
            this.discount = dis;

            this.qarsApplication = qarsApp;
            this.UserID = qarsApp.userID;

            //Look up where the Car is available
            foreach (var company in this.qarsApplication.EstablishmentList)
            {
                if (this.qarsApplication.carList[carNumber].establishmentID == company.establishmentID)
                {
                    availableat = "Verkrijgbaar bij: " + company.name;
                }
            }

            //all the labels, images and buttons
            Label carname = createLabel(qarsApplication.carList[carNumber].brand + " " + this.qarsApplication.carList[carNumber].model, 20, 375, 300, 28, 20, FontStyle.Regular);

            Label beginprice = createLabel("Beginprijs:", 60, 374, 85, 25, 13, FontStyle.Regular);
            Label beginAmount = createLabel("€" + this.qarsApplication.carList[carNumber].startprice, 62, 455, Convert.ToInt32(20 * Math.Floor(Math.Log10(this.qarsApplication.carList[carNumber].startprice) + 1)), 27, 14, FontStyle.Regular);


            int lengthb = (this.qarsApplication.carList[carNumber].rentalprice.ToString()).Count();
            Label priceperkm = createLabel("Kilometerprijs:", 100, 375, 116, 25, 13, FontStyle.Regular);
            Label ppk = createLabel("€" + this.qarsApplication.carList[carNumber].rentalprice, 102, 488, 15 * lengthb, 27, 14, FontStyle.Regular);
  

            if (discount != null)
            {
                if (discount.percentage != 0)
                {
                    Label discountLabelB = new Label();
                    beginAmount.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Strikeout);
                    beginAmount.ForeColor = Color.Red;
                    discountLabelB.Font = new Font("Ariel", 12, FontStyle.Bold);
                    discountLabelB.Width = 155;
                    discountLabelB.Top = 62;
                    discountLabelB.Left = beginAmount.Left + (beginAmount.Width);
                    discountLabelB.ForeColor = System.Drawing.Color.Green;
                    discountLabelB.Text = "- " + discount.percentage + "%  =  €" + Math.Round(qarsApplication.carList[carNumber].startprice * ((double)1 - ((double)discount.percentage / 100)), 2);
                    this.Controls.Add(discountLabelB);
                }

                if (discount.KMPercentage != 0)
                {
                    Label discountLabelP = new Label();
                    ppk.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Strikeout);
                    ppk.ForeColor = Color.Red;
                    discountLabelP.Font = new Font("Ariel", 12, FontStyle.Bold);
                    discountLabelP.Width = 135;
                    discountLabelP.Top = 102;
                    discountLabelP.Left = ppk.Left + (ppk.Width);
                    discountLabelP.ForeColor = System.Drawing.Color.Green;
                    discountLabelP.Text = "- " + discount.KMPercentage + "%  =  €" + Math.Round(qarsApplication.carList[carNumber].rentalprice * ((double)1 - ((double)discount.KMPercentage / 100)), 2);
                    this.Controls.Add(discountLabelP);
                }
            }

            Label establishment = createLabel(availableat, 130, 375, 327, 27, 14, FontStyle.Regular);
            Label specs = createLabel("Specificaties", 315, 22, 300, 32, 20, FontStyle.Regular);
            Label desc = createLabel("Beschrijving", 20, 700, 165, 32, 20, FontStyle.Regular);
            Label descinfo = createLabel(this.qarsApplication.carList[carNumber].description, 65, 700, 300, 300, 9, FontStyle.Regular);
            Button close = createButton("Sluiten", Color.Red, Color.White, -5, 921, 100, 40, 11, FontStyle.Bold, FlatStyle.Flat, BackButtonClick);
            Button hire = createButton("Huren", Color.Green, Color.White, 180, 375, 150, 29, 11, FontStyle.Bold, FlatStyle.Flat, hireButtonClick);

            mainpicture = createPictureBox("", PictureBoxSizeMode.StretchImage, 22, 22, 185, 350, null);
            CreateSpecInfo(this.qarsApplication.carList, carNumber);

            List<Reservation> ReservationList = new DBConnect().SelectReservation(); //Get the most recent list
            List<User> UserList = new DBConnect().SelectUsers(); //Get the most recent list
            List<Reservation> tempReservationList = new List<Reservation>();
            bool carhasReservation = false;
            foreach (var res in ReservationList)
            {
                if (res.carID == carNumber)
                {
                    carhasReservation = true;
                    tempReservationList.Add(res);
                }
            }
            if (carhasReservation)
            {
                foreach (var item in tempReservationList)
                {
                    TimeSpan tisp = Convert.ToDateTime(item.enddate) - Convert.ToDateTime(item.startdate);
                    int differenceindays = tisp.Days;
                    for (int i = 0; i <= differenceindays; i++)
                    {
                        if (Convert.ToDateTime(item.startdate).AddDays(i) == DateTime.Today)
                        {
                            hire.Text = "Verhuurd";
                            hire.BackColor = Color.Orange;
                            break;
                        }
                    }
                }


                //look up if the car is being repaired
                foreach (var rep in this.qarsApplication.damageList)
                {

                    if (rep.carID == carNumber && rep.repaired == false)
                    {
                        if (qarsApplication.customerList[UserID].accountLevel == 4)//if rank is beheerder
                        {
                            hire.Text = "Reparatie";
                        }
                        else
                        {
                            hire.Text = "Niet beschikbaar";
                        }
                        hire.BackColor = Color.Red;
                        hire.Enabled = false;
                    }
                }


                //Create the small pictures
                int left = 22;
                foreach (CarPhoto photo in this.qarsApplication.carList[carNumber].PhotoList)
                {
                    PictureBox pbox = createPictureBox(photo.Photolink, PictureBoxSizeMode.StretchImage, 232, left, 75, 75, PictureHover);
                    left += 88;
                }
                //Select the main picture
                if (this.qarsApplication.carList[carNumber].PhotoList.Count > 0)
                {
                    mainpicture.ImageLocation = this.qarsApplication.carList[carNumber].PhotoList[0].Photolink;
                }
            }
        }


        private void CreateSpecInfo(List<Car> list, int carnumber)
        {
            int left1 = 22;
            int width1 = 120;

            int top = 355;
            int left = 140;
            int width = 105;
            int height = 30;

            int countFailure = 0;
            int countSuccess = 0;

            for (int i = 0; i < 26; i++)
            {

                if (countSuccess == 7 || countSuccess == 14 || countSuccess == 21)
                {
                    top = 355;
                    left += 240;
                    left1 += 240;
                }


                switch (countFailure)
                {
                    case 0:
                        if (list[carnumber].category == "")
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Categorie:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(list[carnumber].category, top, left, width, height, 12, FontStyle.Regular);
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 1:
                        if (list[carnumber].modelyear == -1)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Bouwjaar:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(list[carnumber].modelyear.ToString(), top, left, width, height, 12, FontStyle.Regular);
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 2:
                        if (!list[carnumber].automatic)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Automaat:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel("Ja", top, left, width, height, 12, FontStyle.Regular);
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 3:

                        if (!list[carnumber].automatic)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Versnellingen:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(list[carnumber].gearsamount.ToString(), top, left, width, height, 12, FontStyle.Regular);
                            top += 30;
                            countFailure++;
                            countSuccess++;

                            break;
                        }
                    case 4:
                        if (list[carnumber].motor == "")
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Motor:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(list[carnumber].motor, top, left, width, height, 12, FontStyle.Regular);
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 5:
                        if (list[carnumber].horsepower == -1)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Vermogen:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(list[carnumber].horsepower + " PK", top, left, width, height, 12, FontStyle.Regular);
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 6:
                        if (list[carnumber].fuelusage == -1)
                        {
                            countFailure++;
                            break;

                        }
                        else
                        {
                            createLabel("Verbruik:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(list[carnumber].fuelusage.ToString() + " liter per km", top, left, width, height, 12, FontStyle.Regular);
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 7:
                        if (list[carnumber].kilometres == -1)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Kilometers:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(list[carnumber].kilometres.ToString(), top, left, width, height, 12, FontStyle.Regular);
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 8:
                        if (list[carnumber].motdate == "")
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("APK:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(list[carnumber].motdate, top, left, width, height, 12, FontStyle.Regular);
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 9:
                        if (list[carnumber].length == -1)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Lengte:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(list[carnumber].length + " cm", top, left, width, height, 12, FontStyle.Regular);
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 10:
                        if (list[carnumber].width == -1)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Breedte:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(list[carnumber].width + " cm", top, left, width, height, 12, FontStyle.Regular);
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 11:
                        if (list[carnumber].height == -1)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Hoogte:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(list[carnumber].height + " cm", top, left, width, height, 12, FontStyle.Regular);
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 12:
                        if (list[carnumber].weight == -1)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Gewicht:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(list[carnumber].weight + " cm", top, left, width, height, 12, FontStyle.Regular);
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 13:
                        if (list[carnumber].colour == "")
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Kleur:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(list[carnumber].colour, top, left, width, height, 12, FontStyle.Regular);
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 14:
                        if (list[carnumber].doors == -1)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Deuren:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(list[carnumber].doors.ToString(), top, left, width, height, 12, FontStyle.Regular);
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 15:
                        if (!list[carnumber].stereo)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Stereo:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel("Ja", top, left, width, height, 12, FontStyle.Regular);
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 16:
                        if (!list[carnumber].bluetooth)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Bluetooth:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel("Ja", top, left, width, height, 12, FontStyle.Regular);
                            top += 30;
                            countFailure++;
                            countSuccess++;

                            break;
                        }
                    case 17:
                        if (!list[carnumber].navigation)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Navigatie:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel("Ja", top, left, width, height, 12, FontStyle.Regular);
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 18:
                        if (!list[carnumber].cruisecontrol)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Cruise Control:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel("Ja", top, left, width, height, 12, FontStyle.Regular);
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 19:
                        if (!list[carnumber].parkingAssist)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Parkeerhulp:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel("Ja", top, left, width, height, 12, FontStyle.Regular);
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 20:
                        if (!list[carnumber].fourwheeldrive)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("4WD:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel("Ja", top, left, width, height, 12, FontStyle.Regular);
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 21:
                        if (!list[carnumber].cabrio)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Cabrio:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel("Ja", top, left, width, height, 12, FontStyle.Regular);
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 22:
                        if (!list[carnumber].airco)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Airco:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel("Ja", top, left, width, height, 12, FontStyle.Regular);
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }

                    case 23:
                        if (list[carnumber].seats == -1)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Stoelen:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(list[carnumber].seats.ToString(), top, left, width, height, 12, FontStyle.Regular);
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 24:
                        if (list[carnumber].storagespace == -1)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Ruimte:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(list[carnumber].storagespace + " Liter", top, left, width, height, 12, FontStyle.Regular);
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 25:
                        if (list[carnumber].licenseplate == "")
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Kenteken:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(list[carnumber].licenseplate, top, left, width, height, 12, FontStyle.Regular);
                            top += 30;
                            countFailure++;
                            countSuccess++;
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
            this.Dispose();
        }

        public void hireButtonClick(object sender, EventArgs e)
        {
            RentCarPanel rentcarpanel = new RentCarPanel(this.currentCarNumber, UserID, this.qarsApplication);
            rentcarpanel.checkLogin(UserID);
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
