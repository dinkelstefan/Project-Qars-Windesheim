using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Net.Mail;
namespace Qars
{
    class DBConnect
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
            string query = " SELECT * FROM Car ";
            List<Car> localCarList = new List<Car>();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    localCarList.Add(new Car(dataReader.GetInt32("CarID"), dataReader.GetInt32("EstablishmentID"), dataReader.GetString("Brand"), dataReader.GetString("Model"), dataReader.GetString("Category"), dataReader.GetString("Modelyear"), dataReader.GetBoolean("Automatic"), dataReader.GetInt32("Kilometers"),
                    dataReader.GetString("Colour"), dataReader.GetInt32("Doors"), dataReader.GetBoolean("Stereo"), dataReader.GetBoolean("Bluetooth"), dataReader.GetDouble("Horsepower"), dataReader.GetString("Length"), dataReader.GetString("Width"), dataReader.GetString("Height"), dataReader.GetBoolean("Airco"),
                    dataReader.GetInt32("Seats"), dataReader.GetString("motdate"), dataReader.GetDouble("Storagespace"), dataReader.GetInt32("Gearsamount"), dataReader.GetFloat("Rentalprice"), dataReader.GetFloat("Sellingprice"), dataReader.GetBoolean("Available"), dataReader.GetString("Description").ToString()));
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

        public void insertReservation(Models.Reservation reservation)
        {
            string query = "Insert into Customer (Firstname, Lastname, Postalcode, City, Steetname, Streetnumber, Streetnumbersuffix, Phonenumber, Emailaddress)";
            query += String.Format("Values({0}{1},{2},{3},{4},{5},{6},{7},{8})", reservation.firstname, reservation.lastname, reservation.postalcode, reservation.city, reservation.streetname, reservation.streetnumber, reservation.streetnumbersuffix, reservation.phonenumber, reservation.email.ToString());

            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
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


