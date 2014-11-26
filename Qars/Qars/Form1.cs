using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qars
{
    public partial class Form1 : Form
    {
        public Form1()
        { // I might have to do all of this in Panel!
            InitializeComponent();
            CarDetailPanel CarDetailPanel = new CarDetailPanel();
            List<Car> cars = new List<Car>();
            DBConnect connection = new DBConnect();
            List<String> Queryresult = connection.Select(); //Create stringbuilder!
            foreach (var item in Queryresult)
            {
                //vind het tijlnummer waar op gedrukt was. Dit kan door bijvoorbeeld "Select * FROM Car WHERE CarID = tileview AND Category = de huidige categorie. ORDER BY CarID(zodat wij de volgorde hebben)
                Console.WriteLine(item.ToString());
                //Het tijlnummer wordt een nieuw auto object.
                //cars.add(New Car(QueryAuto(tile nummer));

                //To do: Oplossing voor het invullen van de constructor!
            }
            Console.WriteLine("Het aantal items in de lijst: " + Cars.Count);
            //int aantal = connection.Count();
            //hoeveel autos zijn er?
            //for (int i = 0; i < aantal; i++)
            //{
            //  cars.Add(new Car());
            //}
            //dan is de lijst vol met de gegevens van de auto 
        }
    }
}
