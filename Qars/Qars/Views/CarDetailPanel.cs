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
            CreateSpecInfo(this.qarsApplication.carList[carNumber], carNumber);
            //Look up where the Car is available
            foreach (var company in this.qarsApplication.EstablishmentList)
            {
                if (this.qarsApplication.carList[carNumber].establishmentID == company.establishmentID)
                {
                    availableat = "Verkrijgbaar bij: " + company.name;
                }
            }
            int left = 22;
            foreach (CarPhoto photo in this.qarsApplication.carList[carNumber].PhotoList)
            {
                PictureBox pbox = createPictureBox(photo.Photolink, PictureBoxSizeMode.StretchImage, 232, left, 75, 75, PictureHover);
                left += 88;
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

                //Select the main picture
                if (this.qarsApplication.carList[carNumber].PhotoList.Count > 0)
                {
                    mainpicture.ImageLocation = this.qarsApplication.carList[carNumber].PhotoList[0].Photolink;
                }
            }
        }


        private void CreateSpecInfo(Car car, int carnumber)
        {
            bool spec7 = false;
            bool spec14 = false;
            bool spec21 = false;
            int left1 = 22;
            int width1 = 120;

            int top = 355;
            int left = 140;
            int width = 105;
            int height = 30;

            int countFailure = 0;
            int countSuccess = 0;

            while (countFailure != 25)
            {

                if (countSuccess == 7 && spec7 == false)
                {
                    top = 355;
                    left += 240;
                    left1 += 240;
                    Console.WriteLine("Ik ben nu " + countSuccess + " En failure is " + countFailure);
                    spec7 = true;

                }
                else if (countSuccess == 14 && spec14 == false)
                {
                    top = 355;
                    left += 240;
                    left1 += 240;
                    Console.WriteLine("Ik ben nu " + countSuccess + " En failure is " + countFailure);
                    spec14 = true;
                }
                else if (countSuccess == 21 && spec21 == false)
                {
                    top = 355;
                    left += 240;
                    left1 += 240;
                    Console.WriteLine("Ik ben nu " + countSuccess + " En failure is " + countFailure);
                    spec21 = true;
                }


                switch (countFailure)
                {
                    case 0:
                        if (car.category == "")
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Categorie:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(car.category, top, left, width, height, 12, FontStyle.Regular);
                            Console.WriteLine(left.ToString() + " " + left1.ToString());
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 1:
                        if (car.modelyear == -1)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Bouwjaar:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(car.modelyear.ToString(), top, left, width, height, 12, FontStyle.Regular);
                            Console.WriteLine(left.ToString() + " " + left1.ToString());
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 2:
                        if (!car.automatic)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Automaat:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel("Ja", top, left, width, height, 12, FontStyle.Regular);
                            Console.WriteLine(left.ToString() + " " + left1.ToString());
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 3:

                        if (!car.automatic)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Versnellingen:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(car.gearsamount.ToString(), top, left, width, height, 12, FontStyle.Regular);
                            Console.WriteLine(left.ToString() + " " + left1.ToString());
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 4:
                        if (car.motor == "")
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Motor:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(car.motor, top, left, width, height, 12, FontStyle.Regular);
                            Console.WriteLine(left.ToString() + " " + left1.ToString());
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 5:
                        if (car.horsepower == -1)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Vermogen:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(car.horsepower + " PK", top, left, width, height, 12, FontStyle.Regular);
                            Console.WriteLine(left.ToString() + " " + left1.ToString());
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 6:
                        if (car.fuelusage == -1)
                        {
                            countFailure++;
                            break;

                        }
                        else
                        {
                            createLabel("Verbruik:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(car.fuelusage.ToString() + " liter per km", top, left, width, height, 12, FontStyle.Regular);
                            Console.WriteLine(left.ToString() + " " + left1.ToString());
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 7:
                        if (car.kilometres == -1)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Kilometers:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(car.kilometres.ToString(), top, left, width, height, 12, FontStyle.Regular);
                            Console.WriteLine(left.ToString() + " " + left1.ToString());
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 8:
                        if (car.motdate == "")
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("APK:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(car.motdate, top, left, width, height, 12, FontStyle.Regular);
                            Console.WriteLine(left.ToString() + " " + left1.ToString());
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 9:
                        if (car.length == -1)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Lengte:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(car.length + " cm", top, left, width, height, 12, FontStyle.Regular);
                            Console.WriteLine(left.ToString() + " " + left1.ToString());
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 10:
                        if (car.width == -1)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Breedte:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(car.width + " cm", top, left, width, height, 12, FontStyle.Regular);
                            Console.WriteLine(left.ToString() + " " + left1.ToString());
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 11:
                        if (car.height == -1)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Hoogte:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(car.height + " cm", top, left, width, height, 12, FontStyle.Regular);
                            Console.WriteLine(left.ToString() + " " + left1.ToString());
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 12:
                        if (car.weight == -1)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Gewicht:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(car.weight + " Kilo", top, left, width, height, 12, FontStyle.Regular);
                            Console.WriteLine(left.ToString() + " " + left1.ToString());
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 13:
                        if (car.colour == "")
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Kleur:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(car.colour, top, left, width, height, 12, FontStyle.Regular);
                            Console.WriteLine(left.ToString() + " " + left1.ToString());
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 14:
                        if (car.doors == -1)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Deuren:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(car.doors.ToString(), top, left, width, height, 12, FontStyle.Regular);
                            Console.WriteLine(left.ToString() + " " + left1.ToString());
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 15:
                        if (car.stereo)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Stereo:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel("Ja", top, left, width, height, 12, FontStyle.Regular);
                            Console.WriteLine(left.ToString() + " " + left1.ToString());
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 16:
                        if (car.bluetooth)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Bluetooth:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel("Ja", top, left, width, height, 12, FontStyle.Regular);
                            Console.WriteLine(left.ToString() + " " + left1.ToString());
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 17:
                        if (car.navigation)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Navigatie:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel("Ja", top, left, width, height, 12, FontStyle.Regular);
                            Console.WriteLine(left.ToString() + " " + left1.ToString());
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 18:
                        if (car.cruisecontrol)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Cruise Control:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel("Ja", top, left, width, height, 12, FontStyle.Regular);
                            Console.WriteLine(left.ToString() + " " + left1.ToString());
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 19:
                        if (car.parkingAssist)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Parkeerhulp:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel("Ja", top, left, width, height, 12, FontStyle.Regular);
                            Console.WriteLine(left.ToString() + " " + left1.ToString());
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 20:
                        if (car.fourwheeldrive)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("4WD:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel("Ja", top, left, width, height, 12, FontStyle.Regular);
                            Console.WriteLine(left.ToString() + " " + left1.ToString());
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 21:
                        if (car.cabrio)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Cabrio:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel("Ja", top, left, width, height, 12, FontStyle.Regular);
                            Console.WriteLine(left.ToString() + " " + left1.ToString());
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 22:
                        if (car.airco)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Airco:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel("Ja", top, left, width, height, 12, FontStyle.Regular);
                            Console.WriteLine(left.ToString() + " " + left1.ToString());
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }

                    case 23:
                        if (car.seats == -1)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Stoelen:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(car.seats.ToString(), top, left, width, height, 12, FontStyle.Regular);
                            Console.WriteLine(left.ToString() + " " + left1.ToString());
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 24:
                        if (car.storagespace == -1)
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Ruimte:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(car.storagespace + " Liter", top, left, width, height, 12, FontStyle.Regular);
                            Console.WriteLine(left.ToString() + " " + left1.ToString());
                            top += 30;
                            countFailure++;
                            countSuccess++;
                            break;
                        }
                    case 25:
                        if (car.LicensePlate == "")
                        {
                            countFailure++;
                            break;
                        }
                        else
                        {
                            createLabel("Kenteken:", top, left1, width1, height, 12, FontStyle.Bold);
                            createLabel(car.LicensePlate, top, left, width, height, 12, FontStyle.Regular);
                            Console.WriteLine(left.ToString() + " " + left1.ToString());
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
