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
        public List<Car> FillCars() //TO DO: NULL CHECK
        {
            string query = " SELECT * FROM Car A LEFT JOIN Photo B ON A.CarID = B.CarID ORDER BY A.CarID ";
            List<Car> localCarList = new List<Car>();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                int currentCarID = -1;


                while (dataReader.Read())
                {
                    // check if we are reading a new car
                    if (dataReader.GetInt32("CarID") != currentCarID)
                    {
                        currentCarID = dataReader.GetInt32("CarID");

                        // make a new car with 
                        Car newCar = new Car();
                        newCar.carID = SafeGetInt(dataReader, 0);
                        newCar.establishmentID = SafeGetInt(dataReader, 1);
                        newCar.brand = SafeGetString(dataReader, 2);
                        newCar.model = SafeGetString(dataReader, 3);
                        newCar.category = SafeGetString(dataReader, 4);
                        newCar.modelyear = SafeGetInt(dataReader, 5);
                        newCar.automatic = SafeGetBoolean(dataReader, 6);
                        newCar.kilometres = SafeGetInt(dataReader, 7);
                        newCar.colour = SafeGetString(dataReader, 8);
                        newCar.doors = SafeGetInt(dataReader, 9);
                        newCar.stereo = SafeGetBoolean(dataReader, 10);
                        newCar.bluetooth = SafeGetBoolean(dataReader, 11);
                        newCar.horsepower = SafeGetDouble(dataReader, 12);
                        newCar.length = SafeGetInt(dataReader, 13);
                        newCar.height = SafeGetInt(dataReader, 14);
                        newCar.width = SafeGetInt(dataReader, 15);
                        newCar.weight = SafeGetInt(dataReader, 16);
                        newCar.navigation = SafeGetBoolean(dataReader, 17);
                        newCar.parkingAssist = SafeGetBoolean(dataReader, 18);
                        newCar.fourwheeldrive = SafeGetBoolean(dataReader, 19);
                        newCar.cabrio = SafeGetBoolean(dataReader, 20);
                        newCar.airco = SafeGetBoolean(dataReader, 21);
                        newCar.seats = SafeGetInt(dataReader, 22);
                        newCar.motdate = SafeGetString(dataReader, 23);
                        newCar.storagespace = SafeGetDouble(dataReader, 24);
                        newCar.gearsamount = SafeGetInt(dataReader, 25);
                        newCar.motor = SafeGetString(dataReader, 26);
                        newCar.Fuelusage = SafeGetInt(dataReader, 27);
                        newCar.startprice = SafeGetInt(dataReader, 28);
                        newCar.rentalprice = SafeGetDouble(dataReader, 29);
                        newCar.sellingprice = SafeGetDouble(dataReader, 30);
                        newCar.available = SafeGetBoolean(dataReader, 31);
                        newCar.description = SafeGetString(dataReader, 32);

                        // see if the car has photos, and at the first one to the list
                        try
                        {
                            newCar.PhotoList.Add(new CarPhoto(dataReader.GetInt32("PhotoID"), dataReader.GetInt32("CarID"), dataReader.GetString("Name"), dataReader.GetString("Description"),
                                                        dataReader.GetString("Datetaken"), dataReader.GetString("Photolink")));
                        }
                        catch (System.Data.SqlTypes.SqlNullValueException)
                        {
                            Console.WriteLine(" car:" + newCar.carID + " has no photos");
                        }
                        localCarList.Add(newCar);
                    }
                    else
                    {
                        // if there is no new car, this means its adding pictures to an existing car
                        foreach (Car car in localCarList)
                        {
                            // find the existing car
                            if (car.carID == dataReader.GetInt32("CarID"))
                            {
                                //try adding photos to the existing car
                                try
                                {
                                    car.PhotoList.Add(new CarPhoto(dataReader.GetInt32("PhotoID"), dataReader.GetInt32("CarID"), dataReader.GetString("Name"), dataReader.GetString("Description"),
                                                                dataReader.GetString("Datetaken"), dataReader.GetString("Photolink")));
                                }
                                catch (System.Data.SqlTypes.SqlNullValueException)
                                {
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

        public List<Reservation> FillReservation()
        {
            string query = " SELECT * FROM Reservation ";
            List<Reservation> localReservationList = new List<Reservation>();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {

                    localReservationList.Add(new Reservation(dataReader.GetInt32("ReservationID"), dataReader.GetInt32("CarID"), dataReader.GetInt32("CustomerID"), dataReader.GetString("Startdate"),
                                                    dataReader.GetString("Enddate"), dataReader.GetBoolean("Confirmed"), dataReader.GetInt32("Kilometres"), dataReader.GetString("Pickupcity"), dataReader.GetString("Pickupstreetname"), dataReader.GetInt32("Pickupstreetnumber"), dataReader.GetString("Pickupstreetnumbersuffix"), dataReader.GetBoolean("Paid"), dataReader.GetString("Comment")));
                }

                dataReader.Close();
                this.CloseConnection();

                return localReservationList;
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
        public List<Establishment> FillEstablishment()
        {
            string query = " SELECT * FROM Establishment ";
            List<Establishment> localEstablishmentList = new List<Establishment>();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {

                    localEstablishmentList.Add(new Establishment(dataReader.GetInt32("EstablishmentID"), dataReader.GetString("Name"), dataReader.GetString("City"), dataReader.GetString("Postalcode"),
                                                    dataReader.GetString("Streetname"), dataReader.GetInt32("Streetnumber"), dataReader.GetString("Streetnumbersuffix"), dataReader.GetString("Phonenumber"), dataReader.GetString("Emailaddress"), dataReader.GetString("Leafletlink"), dataReader.GetString("Description")));
                }

                dataReader.Close();
                this.CloseConnection();

                return localEstablishmentList;
            }
            else
            {
                return null;
            }
        }


        public void insertReservation(Reservation2 reservation)
        {
            int ReservationID = 0;
            string query = "SELECT max(ReservationID) FROM Reservation";
            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    ReservationID = dataReader.GetInt32(0);
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

        public static string SafeGetString(MySqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            else
                return string.Empty;
        }
        public static int SafeGetInt(MySqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetInt32(colIndex);
            else
                return -1;
        }
        public static bool SafeGetBoolean(MySqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetBoolean(colIndex);
            else
                return false;
        }
        public static double SafeGetDouble(MySqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetDouble(colIndex);
            else
                return -1;
        }
    }
}


