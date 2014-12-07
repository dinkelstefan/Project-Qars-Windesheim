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

        //vars needed for price selection
        private bool[] answerPriceClass = new bool[] { true, true, true, true };
        private double[,] priceClasses = new double[4, 2] { { 15, 50 }, { 50, 100 }, { 100, 200 }, { 200, 99999 } };

        //vars needed for location selection
        private bool[] answerLocation = new bool[] { true, true, true, true, true };
        private int[] locations = new int[] { 1, 2, 3, 4, 5 };

        //vars needed for extras selection
        private bool[] answerExtra = new bool[] { false, false, false, false, false };
        private string[] extras = new string[] { "Bluetooth", "Cruise Control", "Navigatie", "Radio", "Airco" };


        private List<Car> copyList = new List<Car>();
        private List<Car> filteredList = new List<Car>();

        public searchWizard()
        {
            InitializeComponent();
        }
        private void search()
        {
            copyList = VisualDemo.carList;

            if (answerType != null)
            {
                filteredList = filterType(copyList);
            }
            if (answerTransmission != null)
            {
                filteredList = filterTransmission(filteredList);
            }

            filteredList = filterPriceClass(filteredList);
            filteredList = filterLocation(filteredList);

            // filteredList = filterExtras(filteredList);

            if (filteredList.Count > 0)
            {
                Console.WriteLine("-----------Zoek resultaat-----------------");
                printList(filteredList);
            }
            else
            {
                Console.WriteLine("Geen model gevonden dat voldoet aan de eisen");
                Console.WriteLine("-----------Toon alles----------------");
                printList(copyList);
                Console.WriteLine("-------------------------------------------");
            }

            setLabelCountNumerOfCarsFound();
        }
        private void selectCarType(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            this.answerType = rb.Text;
        }
        private void selectTransmissionType(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            this.answerTransmission = rb.Text;
        }
        private void selectPriceClass(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            //switch checkbox state between true and false
            switch (box.Name)
            {
                case "lowCheckBox":
                    answerPriceClass[0] = !answerPriceClass[0];
                    break;
                case "mediumCheckBox":
                    answerPriceClass[1] = !answerPriceClass[1];
                    break;
                case "highCheckBox":
                    answerPriceClass[2] = !answerPriceClass[2];
                    break;
                case "veryHighCheckBox":
                    answerPriceClass[3] = !answerPriceClass[3];
                    break;
            }
        }
        private void selectLocation(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            switch (box.Name)
            {
                case "zwolleCheckBox":
                    answerLocation[0] = !answerLocation[0];
                    break;
                case "arnhemCheckBox":
                    answerLocation[1] = !answerLocation[1];
                    break;
                case "amsterdamCheckBox":
                    answerLocation[2] = !answerLocation[2];
                    break;
                case "groningenCheckBox":
                    answerLocation[3] = !answerLocation[3];
                    break;
                case "leeuwardenCheckBox":
                    answerLocation[4] = !answerLocation[4];
                    break;
            }
        }
        private void selectExtra(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            switch (box.Name)
            {
                case "bluetoothCheckBox":
                    answerExtra[0] = !answerExtra[0];
                    break;
                case "cruiseControlCheckBox":
                    answerExtra[1] = !answerExtra[1];
                    break;
                case "navigationCheckBox":
                    answerExtra[2] = !answerExtra[2];
                    break;
                case "radioCheckBox":
                    answerExtra[3] = !answerExtra[3];
                    break;
                case "aircoCheckBox":
                    answerExtra[4] = !answerExtra[4];
                    break;
            }
        }
        private List<Car> filterTransmission(List<Car> listToFilter)
        {
            //initialize all the vars needed for this function
            bool auto;
            List<Car> localList = new List<Car>();

            //set auto to user input
            if (this.answerTransmission == "Handgeschakeld")
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
        private List<Car> filterType(List<Car> listToFilter)
        {
            //initialize all the vars needed for this function
            List<Car> localList = new List<Car>();

            foreach (Car car in listToFilter)
            {
                if (car.category == this.answerType)
                {
                    localList.Add(car);
                }

            }


            return localList;
        }
        private List<Car> filterPriceClass(List<Car> listToFilter)
        {
            //initialize vars needed for this function
            List<Car> localList = new List<Car>();

            foreach (Car car in listToFilter)
            {
                double price = car.startprice + (car.rentalprice * 100);
                for (int i = 0; i < answerPriceClass.Length; i++)
                {
                    if (answerPriceClass[i] == true && (price > priceClasses[i, 0] && price < priceClasses[i, 1]))
                    {
                        localList.Add(car);
                    }
                }
            }

            return localList;
        }
        private List<Car> filterLocation(List<Car> listToFilter)
        {
            //initialize vars needed for this function
            List<Car> localList = new List<Car>();
            foreach (Car car in listToFilter)
            {
                for (int i = 0; i < answerLocation.Length; i++)
                {
                    if (answerLocation[i] == true && car.establishmentID == locations[i])
                    {
                        localList.Add(car);
                    }
                }
            }

            return localList;
        }
        private List<Car> filterExtras(List<Car> listToFilter)
        {
            //initialize vars needed for this function
            List<Car> localList = new List<Car>();

            foreach (Car car in listToFilter)
            {
                for (int i = 0; i < answerExtra.Length; i++)
                {
                    if (answerExtra[i] == true && car.bluetooth == true)
                    {
                        localList = addCarToList(localList, car);
                    }
                    else if (answerExtra[i] == true && car.navigation == true)
                    {
                        localList = addCarToList(localList, car);
                    }
                    else if (answerExtra[i] == true && car.stereo == true)
                    {
                        localList = addCarToList(localList, car);
                    }
                    else if (answerExtra[i] == true && car.airco == true)
                    {
                        localList = addCarToList(localList, car);
                    }
                }
            }

            return localList;
        }
        private void searchClick(object sender, EventArgs e)
        {
            search();
        }
        private List<Car> addCarToList(List<Car> list, Car car)
        {
            bool exist = false;
            foreach (Car c in list)
            {
                if (c.carID == car.carID)
                {
                    exist = true;
                }
            }

            if (exist == false)
            {
                list.Add(car);
            }

            return list;
        }
        private void nextTabpage(object sender, EventArgs e)
        {
            this.searchWizardTabControl.SelectedIndex = this.searchWizardTabControl.SelectedIndex + 1;
            search();
        }
        private void previousTabPage(object sender, EventArgs e)
        {
            this.searchWizardTabControl.SelectedIndex = this.searchWizardTabControl.SelectedIndex - 1;
            search();
        }
        private void setLabelCountNumerOfCarsFound()
        {
            int countCar = copyList.Count;
            if (answerType != null)
            {
                countCar = filteredList.Count;
            }

            string labelText = string.Format("Aantal gevonden auto's: {0}", countCar);
            countCarLabel1.Text = labelText;
            countCarLabel2.Text = labelText;
            countCarLabel3.Text = labelText;
            countCarLabel4.Text = labelText;
            countCarLabel5.Text = labelText;
        }
        
        //REMOVE WHEN FINISHED
        private void printList(List<Car> list)
        {
            foreach (Car car in list)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
