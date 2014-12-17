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
            categories.Add(this.createButton("Autos beheren", "autoBeheren", 1));
            categories.Add(this.createButton("Reserveringen beheren", "reserveringBeheren", 3));
            categories.Add(this.createButton("Vestigingen beheren", "vestigignBeheren", 5));

            foreach (Button panel in categories)
            {
                Controls.Add(panel);
            }

        }

        private Button createButton(string buttonText, string buttonName, int userLevel)
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
    }
}
