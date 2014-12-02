using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Net.Mail;
using Qars.Models;
namespace Qars
{
    public class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "db4free.net";
            database = "qars1";
            uid = "qars1";
            password = "Quintor";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }


        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }


        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void Insert()
        {
            string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public void Update()
        {
            string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete()
        {
            string query = "DELETE FROM tableinfo WHERE name='John Smith'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
        public List<Car> FillCars()
        {
            string query = " SELECT * FROM Car A LEFT JOIN Photo B ON A.CarID = B.CarID ORDER BY A.CarID ";
            List<Car> localCarList = new List<Car>();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                int currentCarID = -1;


                while (dataReader.Read()) {
                    // check if we are reading a new car
                    if (dataReader.GetInt32("CarID") != currentCarID) {
                        currentCarID = dataReader.GetInt32("CarID");

                        // make a new car with 
                        Car newCar = new Car(dataReader.GetInt32("CarID"), dataReader.GetInt32("EstablishmentID"), dataReader.GetString("Brand"), dataReader.GetString("Model"), dataReader.GetString("Category"), dataReader.GetString("Modelyear"), dataReader.GetBoolean("Automatic"), dataReader.GetInt32("Kilometers"),
                        dataReader.GetString("Colour"), dataReader.GetInt32("Doors"), dataReader.GetBoolean("Stereo"), dataReader.GetBoolean("Bluetooth"), dataReader.GetDouble("Horsepower"), dataReader.GetString("Length"), dataReader.GetString("Width"), dataReader.GetString("Height"), dataReader.GetBoolean("Airco"),
                        dataReader.GetInt32("Seats"), dataReader.GetString("motdate"), dataReader.GetDouble("Storagespace"), dataReader.GetInt32("Gearsamount"), dataReader.GetFloat("Rentalprice"), dataReader.GetFloat("Sellingprice"), dataReader.GetBoolean("Available"), dataReader.GetString("Description").ToString(), dataReader.GetInt32("Fuelusage"), dataReader.GetString("motor"));

                        // see if the car has photos, and at the first one to the list
                        try {
                            newCar.PhotoList.Add(new CarPhoto(dataReader.GetInt32("PhotoID"), dataReader.GetInt32("CarID"), dataReader.GetString("Name"), dataReader.GetString("Description"),
                                                        dataReader.GetString("Datetaken"), dataReader.GetString("Photolink")));
                        } catch (System.Data.SqlTypes.SqlNullValueException) {
                            Console.WriteLine(" car:" + newCar.carID + " has no photos");
                        }
                        localCarList.Add(newCar);
                    } else {
                        // if there is no new car, this means its adding pictures to an existing car
                        foreach (Car car in localCarList) {
                            // find the existing car
                            if (car.carID == dataReader.GetInt32("CarID")) {
                                //try adding photos to the existing car
                                try {
                                    car.PhotoList.Add(new CarPhoto(dataReader.GetInt32("PhotoID"), dataReader.GetInt32("CarID"), dataReader.GetString("Name"), dataReader.GetString("Description"),
                                                                dataReader.GetString("Datetaken"), dataReader.GetString("Photolink")));
                                } catch (System.Data.SqlTypes.SqlNullValueException) {
                                    Console.WriteLine(" car:" + car.carID + " failed to load more photos");
                                }
                            }
                        }
                    }
                }
                dataReader.Close();
                this.CloseConnection();

                return localCarList;
            }
            else
            {
                return null;
            }
        }

        public List<CarPhoto> FillCarPhotos() //this needs improvement. How do I get all the pictures instead of just 1?
        {
            string query = " SELECT * FROM Photo ";
            List<CarPhoto> localPhotoList = new List<CarPhoto>();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    localPhotoList.Add(new CarPhoto(dataReader.GetInt32("PhotoID"), dataReader.GetInt32("CarID"), dataReader.GetString("Name"), dataReader.GetString("Description"),
                                                    dataReader.GetString("Datetaken"), dataReader.GetString("Photolink")));
                }

                dataReader.Close();
                this.CloseConnection();

                return localPhotoList;
            }
            else
            {
                return null;
            }
        }




        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM Car";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        public void insertReservation(Reservation reservation)
        {
            int ReservationID = 0;
            string query = "SELECT max(ReservationID) FROM Reservation";
            if (this.OpenConnection())
            {
                Console.WriteLine("hallo test");
                MySqlCommand cmd = new MySqlCommand(query, connection);
                Console.WriteLine("hallo test 2 Query geslaagd");


                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    ReservationID = dataReader.GetInt32(0);
                    Console.WriteLine("hallo");
                }
                this.CloseConnection();
            }

            Console.WriteLine(ReservationID);
            ReservationID++;
            string query2 = "INSERT INTO Reservation (ReservationID, CarID, CustomerID, Startdate, Enddate, Confirmed, Kilometres, Pickupcity, Pickupstreetname, Pickupstreetnumber, Pickupstreetnumbersuffix, Paid, Comment)";
            query2 += String.Format("VALUES({0},1,1,'{1}','{2}', 0, 5000,'Zwolle', 'Lubeckestraat', 1, null, 0, '{3}')", ReservationID, reservation.startdate, reservation.enddate, reservation.comment);
            Console.WriteLine(query2);
            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query2, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }


        public void DynamicQuery()
        {
            //Dynamicquery voor zoekfunctie
        }
    }
}


