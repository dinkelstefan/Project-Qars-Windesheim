using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
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

        //open connection to database

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
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

        //Update statement
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
        public List<string> Select() //this function needs to insert the number of the tile that was clicked on so it can load the correct values!
        {
            string query = "SELECT * FROM Car WHERE CarID = 1"; //this has to be a number given to the function

            //Create a list to store the result
            List<String> list = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list.Add(dataReader.GetInt32("CarID").ToString());
                    list.Add(dataReader.GetInt32("EstablishmentID").ToString());
                    list.Add(dataReader.GetString("Brand"));
                    list.Add(dataReader.GetString("Model"));
                    list.Add(dataReader.GetString("Category"));
                    list.Add(dataReader.GetString("Modelyear"));
                    list.Add(dataReader.GetBoolean("Automatic").ToString());
                    list.Add(dataReader.GetInt32("Kilometers").ToString());
                    list.Add(dataReader.GetString("Colour"));
                    list.Add(dataReader.GetInt32("Doors").ToString());
                    list.Add(dataReader.GetBoolean("Stereo").ToString());
                    list.Add(dataReader.GetBoolean("Bluetooth").ToString());
                    list.Add(dataReader.GetDouble("Horsepower").ToString());
                    list.Add(dataReader.GetString("Length"));
                    list.Add(dataReader.GetString("Width"));
                    list.Add(dataReader.GetString("Height"));
                    list.Add(dataReader.GetBoolean("Airco").ToString());
                    list.Add(dataReader.GetInt32("Seats").ToString());
                    list.Add(dataReader.GetValue(19).ToString()); //This doesn't work for MOTDate for some reason!
                    list.Add(dataReader.GetDouble("Storagespace").ToString());
                    list.Add(dataReader.GetInt32("Gearsamount").ToString());
                    list.Add(dataReader.GetFloat("Rentalprice").ToString());
                    list.Add(dataReader.GetFloat("Sellingprice").ToString());
                    list.Add(dataReader.GetBoolean("Available").ToString());
                    list.Add(dataReader.GetString("Description").ToString());

                }
                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
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
    }
}

//Backup

