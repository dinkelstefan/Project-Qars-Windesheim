using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qars.Views
{
    public partial class searchWizard : UserControl
    {
        private string answerType = null;
        private string answerTransmission = null;
        private List<Car> copyList = new List<Car>();
        private List<Car> filteredList = new List<Car>();

        public searchWizard()
        {
            InitializeComponent();
        }
        private void selectCarType(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            this.answerType = rb.Text;
        }
        private void transissionType(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            this.answerTransmission = rb.Text;
        }
        private void searchClick(object sender, EventArgs e)
        {
            copyList = VisualDemo.carList;
            Console.WriteLine("-----------Zoek resultaat-----------------");
            if (answerType != null)
            {
                filteredList = filterType(copyList, answerType);
            }
            if (answerTransmission != null)
            {
                filteredList = filterTransmission(filteredList, answerTransmission);
            }

            if (filteredList.Count > 0)
            {
                printList(filteredList);
            }
            else
            {
                Console.WriteLine("Geen model gevonden dat voldoet aan de eisen");
                Console.WriteLine("-----------Toon alles----------------");
                printList(copyList);
                Console.WriteLine("-------------------------------------------");
            }

        }
        private List<Car> filterTransmission(List<Car> listToFilter, string transmission)
        {
            //initialize all the vars needed for this function
            bool auto;
            List<Car> localList = new List<Car>();

            //set auto to user input
            if (transmission == "Handgeschakeld")
            {
                auto = false;
            }
            else
            {
                auto = true;
            }

            foreach (Car car in listToFilter)
            {
                if (car.automatic == auto)
                {
                    localList.Add(car);
                }
            }

            return localList;
        }
        private List<Car> filterType(List<Car> listToFilter, string type)
        {
            //initialize all the vars needed for this function
            List<Car> localList = new List<Car>();

            foreach (Car car in listToFilter)
            {
                if (car.category == type)
                {
                    localList.Add(car);
                }

            }


            return localList;
        }
        private void printList(List<Car> list)
        {
            foreach (Car car in list)
            {
                Console.WriteLine(car.ToString());
            }
        }

    }
}
