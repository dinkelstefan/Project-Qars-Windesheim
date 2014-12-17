using Qars;
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

        private User currentUser;
        private List<Button> categories = new List<Button>();
        private int yCoordinate = 50;

        public AdminForm(User currentUser)
        {
            this.currentUser = currentUser;
            InitializeComponent();
            addCategories();
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
                        Controls.Add(button);
                    }
                }
            }
        }

        private Button createButton(string buttonText, string buttonName, int[] userLevel)
        {
            Button button = new Button();

            button.Size = new Size(200, 40);
            button.Location = new Point(10, yCoordinate);
            yCoordinate += 50;

            button.Text = buttonText;
            button.Name = buttonName;
            button.Tag = userLevel;

            return button;
        }

        private void fillButtonList()
        {
            categories.Add(this.createButton("Autos beheren", "autoBeheren", new[] {1,2} ));
            categories.Add(this.createButton("Reserveringen beheren", "reserveringBeheren", new[] { 3, 4 }));

            



        }
    }
}
