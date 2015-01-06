using Qars;
using Qars_Admin.Panels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qars_Admin
{
    //Beheerder             1
    //Backoffice            2
    //Franchisenemer        3
    //Allocatiemedewerker   4
    //Medewerker            5
    //Klant                 6

    public partial class AdminForm : Form
    {
        public User currentUser { get; private set; }
        private DBConnect databaseConnection;
        private List<Button> categories = new List<Button>();

        private CarAdminPanel carAdminPanel;
        private ReservationAdminPanel reservationAdminPanel;
        private UserAdminPanel userAdminPanel;
        private ForecastAdminPanel forecastAdminPanel;

        private System.Drawing.Point adminPanelPosition = new System.Drawing.Point(225, 8);
        private int yCoordinate = 50;

        public AdminForm(User currentUser, DBConnect dbConnect)
        {
            this.currentUser = currentUser;
            this.databaseConnection = dbConnect;
            addCategories();

            // make a car adminPanel
            this.carAdminPanel = new CarAdminPanel(this.databaseConnection);
            this.carAdminPanel.Location = this.adminPanelPosition;
            this.carAdminPanel.Size = new System.Drawing.Size(768, 509);
            this.carAdminPanel.TabIndex = 5;
            this.Controls.Add(this.carAdminPanel);

            //make a reservation adminPanel
            this.reservationAdminPanel = new ReservationAdminPanel(this.databaseConnection, this);
            this.reservationAdminPanel.Location = this.adminPanelPosition;
            this.reservationAdminPanel.Size = new System.Drawing.Size(768, 509);
            this.reservationAdminPanel.TabIndex = 6;
            this.Controls.Add(this.reservationAdminPanel);

            //make a customer adminPanel
            this.userAdminPanel = new UserAdminPanel(this.databaseConnection, this);
            this.userAdminPanel.Location = this.adminPanelPosition;
            this.userAdminPanel.Size = new System.Drawing.Size(768, 509);
            this.userAdminPanel.TabIndex = 6;
            this.Controls.Add(this.userAdminPanel);

            //make a forecast adminpanel
            this.forecastAdminPanel = new ForecastAdminPanel(this.databaseConnection);
            this.forecastAdminPanel.Location = this.adminPanelPosition;
            this.forecastAdminPanel.Size = new System.Drawing.Size(768, 509);
            this.forecastAdminPanel.TabIndex = 6;
            this.Controls.Add(this.forecastAdminPanel);

            InitializeComponent();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;


            // Confirm user wants to close
            switch (MessageBox.Show("Wilt u het programma afsluiten?", "Qars Administratie", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }
        private void addCategories()
        {
            fillButtonList();
            foreach (Button button in categories)
            {
                int[] levels = (int[])button.Tag;
                for (int i = 0; i < levels.Length; i++)
                {
                    if (levels[i] == currentUser.accountLevel)
                    {
                        button.Location = new Point(10, yCoordinate);
                        yCoordinate += 50;
                        Controls.Add(button);
                    }
                }
            }
        }
        private Button createButton(string buttonText, string buttonName, int[] userLevel)
        {
            Button button = new Button();

            button.Size = new Size(200, 40);
            button.Text = buttonText;
            button.Tag = userLevel;
            button.Name = buttonName;
            button.Click += new System.EventHandler(this.categorieButton_Click);

            return button;
        }
        private void fillButtonList()
        {
            categories.Add(this.createButton("Autos beheren", "autosBeheren", new[] { 1, 2, 3, 4 }));
            categories.Add(this.createButton("Reserveringen beheren", "reserveringenBeheren", new[] {1, 2, 3, 4 }));
            categories.Add(this.createButton("Klanten beheren", "klantenBeheren", new[] { 2, 3, 4 }));
            categories.Add(this.createButton("Algemene Voorwaarden beheren", "algemeneVoorwaardenBeheren", new[] { 3, 4 }));
            categories.Add(this.createButton("Schade melden", "schadeMelden", new[] {1, 2, 3, 4 }));
            categories.Add(this.createButton("Forecast weergeven", "forecastWeergeven", new[] {1, 2, 3, 4 }));
        }
        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void categorieButton_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            switch (b.Name)
            {
                case "autosBeheren":
                    carAdminPanel.BringToFront();
                    break;
                case "reserveringenBeheren":
                    reservationAdminPanel.BringToFront();
                    break;
                case "klantenBeheren":
                    userAdminPanel.BringToFront();
                    break;
                case "algemeneVoorwaardenBeheren":
                    Console.WriteLine("Nog niet aangemaakt");
                    break;
                case "schadeMelden":
                    Console.WriteLine("Nog niet aangemaakt");
                    break;
                case "forecastWeergeven":
                    forecastAdminPanel.BringToFront();
                    break;
            }

        }
    }
}
