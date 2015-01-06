﻿
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
using System.Security.Cryptography;
using System.Diagnostics;
namespace Qars
{
    public class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DBConnect()
        {
            Initialize();
        }
        private void Initialize()
        {
            server = "db4free.net";
            database = "qars1";
            uid = "qars1";
            password = "Quintor";
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
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
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact administrator");
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

        // returns the logged in user
        // returns an empty user with an accountlevel of -2 if the user doesnt exsist
        // returns an empty user with an accountlevel of -1 if the password is wrong
        public User CheckUser(string username, string password)
        {
            // get the userlist from the DB
            List<User> userList = this.SelectUsers();


            // make an incorrectuser to return if account or password is false
            User incorrectUser = new User();
            // set the incorrect user withusername that doesnt exsist
            incorrectUser.accountLevel = -2;

            //loop trough users
            foreach (User user in userList)
            {
                // check if username exsists
                if (username == user.username)
                {
                    // check if password is correct
                    if (password == user.password)
                    {
                        //return the correct user
                        return user;
                    }
                    else
                    {
                        // set incorrect user with false password
                        incorrectUser.accountLevel = -1;
                    }
                }
            }
            return incorrectUser;
        }

        public int LogInUser(string username, string password)
        {
            int userID = 0;
            string usernameQuery = "";
            string passwordQuery = "";
            string query = String.Format("SELECT UserID, Username, Password FROM User WHERE Username = '{0}'", username);

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    userID = SafeGetInt(dataReader, 0);
                    usernameQuery = SafeGetString(dataReader, 1);
                    passwordQuery = SafeGetString(dataReader, 2);
                }
                dataReader.Close();
                this.CloseConnection();

                if (username == usernameQuery)
                {
                    if (PasswordHash.ValidatePassword(password, passwordQuery))
                    {
                        //log in == correct
                        return userID;
                    }
                    else
                    {
                        return 0;
                        //wrong password
                    }
                }
                else
                {
                    return 0;
                    //wrong username
                }
            }
            MessageBox.Show("Er zijn problemen met de server. Neem alstublieft contact op met een beheerder");
            return 0;
            //Can't open a connection to the database

        }
        public List<Car> SelectCar()
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
                    if (SafeGetInt(dataReader, 0) != currentCarID)
                    {
                        currentCarID = SafeGetInt(dataReader, 0);

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
                        newCar.cruisecontrol = SafeGetBoolean(dataReader, 18);
                        newCar.parkingAssist = SafeGetBoolean(dataReader, 19);
                        newCar.fourwheeldrive = SafeGetBoolean(dataReader, 20);
                        newCar.cabrio = SafeGetBoolean(dataReader, 21);
                        newCar.airco = SafeGetBoolean(dataReader, 22);
                        newCar.seats = SafeGetInt(dataReader, 23);
                        newCar.motdate = SafeGetString(dataReader, 24);
                        newCar.storagespace = SafeGetDouble(dataReader, 25);
                        newCar.gearsamount = SafeGetInt(dataReader, 26);
                        newCar.motor = SafeGetString(dataReader, 27);
                        newCar.Fuelusage = SafeGetInt(dataReader, 28);
                        newCar.startprice = SafeGetInt(dataReader, 29);
                        newCar.rentalprice = SafeGetDouble(dataReader, 30);
                        newCar.sellingprice = SafeGetDouble(dataReader, 31);
                        newCar.available = SafeGetBoolean(dataReader, 32);
                        newCar.description = SafeGetString(dataReader, 33);

                        // see if the car has photos, and at the first one to the list
                        try
                        {
                            newCar.PhotoList.Add(new CarPhoto(SafeGetInt(dataReader, 34), SafeGetInt(dataReader, 35), SafeGetString(dataReader, 36), SafeGetString(dataReader, 37), SafeGetString(dataReader, 38), SafeGetString(dataReader, 39)));
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
                            if (car.carID == SafeGetInt(dataReader, 0))
                            {
                                try
                                {
                                    car.PhotoList.Add(new CarPhoto(SafeGetInt(dataReader, 34), SafeGetInt(dataReader, 35), SafeGetString(dataReader, 36), SafeGetString(dataReader, 37), SafeGetString(dataReader, 38), SafeGetString(dataReader, 39)));
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
        public List<Reservation> SelectReservation()
        {
            List<Reservation> localReservationList = new List<Reservation>();
            string query = "Select * FROM Reservation";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {

                    // make a new car with 
                    Reservation newReservation = new Reservation();

                    newReservation.reservationID = SafeGetInt(dataReader, 0);
                    newReservation.carID = SafeGetInt(dataReader, 1);
                    newReservation.UserID = SafeGetInt(dataReader, 2);
                    newReservation.startdate = SafeGetString(dataReader, 3);
                    newReservation.enddate = SafeGetString(dataReader, 4);
                    newReservation.confirmed = SafeGetBoolean(dataReader, 5);
                    newReservation.kilometres = SafeGetInt(dataReader, 6);
                    newReservation.pickupcity = SafeGetString(dataReader, 7);
                    newReservation.pickupstreetname = SafeGetString(dataReader, 8);
                    newReservation.pickupstreetnumber = SafeGetInt(dataReader, 9);
                    newReservation.pickupstreetnumbersuffix = SafeGetString(dataReader, 10);
                    newReservation.paid = SafeGetBoolean(dataReader, 11);
                    newReservation.comment = SafeGetString(dataReader, 12);
                    localReservationList.Add(newReservation);
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
        public List<Establishment> SelectEstablishment()
        {
            string query = " SELECT * FROM Establishment ";
            List<Establishment> localEstablishmentList = new List<Establishment>();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Establishment newEstablishment = new Establishment();

                    newEstablishment.establishmentID = SafeGetInt(dataReader, 0);
                    newEstablishment.name = SafeGetString(dataReader, 1);
                    newEstablishment.city = SafeGetString(dataReader, 2);
                    newEstablishment.postalcode = SafeGetString(dataReader, 3);
                    newEstablishment.streetname = SafeGetString(dataReader, 4);
                    newEstablishment.streetnumber = SafeGetInt(dataReader, 5);
                    newEstablishment.streetnumbersuffix = SafeGetString(dataReader, 6);
                    newEstablishment.phonenumber = SafeGetString(dataReader, 7);
                    newEstablishment.emailaddress = SafeGetString(dataReader, 8);
                    newEstablishment.leafletlink = SafeGetString(dataReader, 9);
                    newEstablishment.description = SafeGetString(dataReader, 10);

                    localEstablishmentList.Add(newEstablishment);
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
        public List<Damage> SelectDamage()
        {
            string query = " SELECT * FROM Damage ";
            List<Damage> localDamageList = new List<Damage>();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Damage newDamage = new Damage();

                    newDamage.damageID = SafeGetInt(dataReader, 0);
                    newDamage.carID = SafeGetInt(dataReader, 1);
                    newDamage.description = SafeGetString(dataReader, 2);
                    newDamage.repaired = SafeGetBoolean(dataReader, 3);

                    localDamageList.Add(newDamage);
                }

                dataReader.Close();
                this.CloseConnection();

                return localDamageList;
            }
            else
            {
                return null;
            }
        }
        public List<User> SelectUsers()
        {
            string query = " SELECT * FROM User ";
            List<User> localUserList = new List<User>();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    User newUser = new User();

                    newUser.UserID = SafeGetInt(dataReader, 0);
                    newUser.accountLevel = SafeGetInt(dataReader, 1);
                    newUser.username = SafeGetString(dataReader, 2);
                    newUser.password = SafeGetString(dataReader, 3);
                    newUser.firstname = SafeGetString(dataReader, 4);
                    newUser.lastname = SafeGetString(dataReader, 5);
                    newUser.age = SafeGetInt(dataReader, 6);
                    newUser.postalcode = SafeGetString(dataReader, 7);
                    newUser.city = SafeGetString(dataReader, 8);
                    newUser.streetname = SafeGetString(dataReader, 9);
                    newUser.streetnumber = SafeGetInt(dataReader, 10);
                    newUser.streetnumbersuffix = SafeGetString(dataReader, 11);
                    newUser.phonenumber = SafeGetString(dataReader, 12);
                    newUser.emailaddress = SafeGetString(dataReader, 13);
                    newUser.driverslicenselink = SafeGetString(dataReader, 14);
                    newUser.Esthablishment = SafeGetInt(dataReader, 15);

                    localUserList.Add(newUser);
                }

                dataReader.Close();
                this.CloseConnection();

                return localUserList;
            }
            else
            {
                return null;
            }
        }
        public void UpdateUser(User user)
        {
            string query = "Update User ";
            query += string.Format("Set AccountLevel={0}, Username='{1}', Password='{2}',Firstname='{3}', Lastname='{4}',Age={5},Postalcode='{6}',City='{7}', Streetname='{8}', Streetnumber={9}, Streetnumbersuffix='{10}', Phonenumber='{11}', Emailaddress='{12}', Driverslicencelink='{13}', Establishment={14} ", user.accountLevel,user.username,user.password,user.firstname, user.lastname, user.age, user.postalcode, user.city, user.streetname,user.streetnumber,user.streetnumbersuffix, user.phonenumber, user.emailaddress, user.driverslicenselink, user.Esthablishment);
            query += string.Format("Where UserID = {0} ", user.UserID);

            Console.WriteLine(query);
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }

        }
        public bool InsertReservation(Reservation reservation)
        {
            int result = 0;
            int ReservationID = 0;
            string query = "SELECT max(ReservationID) FROM Reservation";

            try
            {
                if (this.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    ReservationID = (Int32)cmd.ExecuteScalar();
                    CloseConnection();
                }

                ReservationID++;
                string query2 = "INSERT INTO `Reservation`(`ReservationID`, `CarID`, `UserID`, `Startdate`, `Enddate`, `Confirmed`, `Kilometres`, `Pickupcity`, `Pickupstreetname`, `Pickupstreetnumber`, `Pickupstreetnumbersuffix`, `Paid`, `Comment`) VALUES(@reservationid,@carid,@UserID,@startdate,@enddate,@confirmed,@Kilometres,@pickupcity,@pickupstreetname,@pickupnumber,@pickupnumbersuffix,@paid,@comment)";
                if (this.OpenConnection())
                {
                    int convertConfirmedToInt = 0;
                    int convertPaidtoInt = 0;
                    MySqlCommand cmd = new MySqlCommand(query2, connection);
                    cmd.Parameters.AddWithValue("@reservationid", ReservationID);
                    cmd.Parameters.AddWithValue("@carid", reservation.carID);
                    cmd.Parameters.AddWithValue("@UserID", reservation.UserID);
                    cmd.Parameters.AddWithValue("@startdate", reservation.startdate);
                    cmd.Parameters.AddWithValue("@enddate", reservation.enddate);
                    cmd.Parameters.AddWithValue("@confirmed", convertConfirmedToInt);
                    cmd.Parameters.AddWithValue("@Kilometres", reservation.kilometres);
                    cmd.Parameters.AddWithValue("@pickupcity", reservation.pickupcity);
                    cmd.Parameters.AddWithValue("@pickupstreetname", reservation.pickupstreetname);
                    cmd.Parameters.AddWithValue("@pickupnumber", reservation.pickupstreetnumber);
                    cmd.Parameters.AddWithValue("@pickupnumbersuffix", reservation.pickupstreetnumbersuffix);
                    cmd.Parameters.AddWithValue("@paid", convertPaidtoInt);
                    cmd.Parameters.AddWithValue("@comment", reservation.comment);

                    result = cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool InsertCustomer(User customer)
        {
            int result = 0;
            int UserID = 0;
            string query = "SELECT max(UserID) FROM User";

            try
            {
                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    UserID = (Int32)cmd.ExecuteScalar();
                    UserID++;
                    CloseConnection();
                }
                string salt = createHash(customer.password);
                string query2 = "INSERT INTO `User` (`UserID`,`Accountlevel`,`Username`, `Password`,`Firstname`, `Lastname`, `Age`, `Postalcode`, `City`, `Streetname`, `Streetnumber`, `Streetnumbersuffix`, `Phonenumber`, `Emailaddress`, `Driverslicencelink`) VALUES (@UserID, @accountlevel,@username,@password,@firstname,@lastname, @age, @postalcode,@city,@streetname,@streetnumber,@streetnumbersuffix, @phonenumber, @emailaddress, @driverslicenselink)";
                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query2, connection);
                    cmd.Parameters.AddWithValue("@UserID", SafeInsertInt(UserID));
                    cmd.Parameters.AddWithValue("@accountlevel", 1); //Normal account level
                    cmd.Parameters.AddWithValue("@username", SafeInsertString(customer.username));
                    cmd.Parameters.AddWithValue("@password", SafeInsertString(salt));
                    cmd.Parameters.AddWithValue("@firstname", SafeInsertString(customer.firstname));
                    cmd.Parameters.AddWithValue("@lastname", SafeInsertString(customer.lastname));
                    cmd.Parameters.AddWithValue("@age", SafeInsertInt(customer.age));
                    cmd.Parameters.AddWithValue("@postalcode", SafeInsertString(customer.postalcode));
                    cmd.Parameters.AddWithValue("@city", SafeInsertString(customer.city));
                    cmd.Parameters.AddWithValue("@streetname", SafeInsertString(customer.streetname));
                    cmd.Parameters.AddWithValue("@streetnumber", SafeInsertInt(customer.streetnumber));
                    cmd.Parameters.AddWithValue("@streetnumbersuffix", SafeInsertString(customer.streetnumbersuffix));
                    cmd.Parameters.AddWithValue("@phonenumber", SafeInsertString(customer.phonenumber));
                    cmd.Parameters.AddWithValue("@emailaddress", SafeInsertString(customer.emailaddress));
                    cmd.Parameters.AddWithValue("@driverslicenselink", SafeInsertString(customer.driverslicenselink));//INSERT FTP LINK

                    result = cmd.ExecuteNonQuery();
                    CloseConnection();
                }
            }
            catch (Exception)
            {
                return false;
            }
            if (result > 0)
                return true;
            else
                return false;


        }

        //Check if there are discounts
        public List<Discount> CheckDiscounts()
        {
            string query = " SELECT * FROM Discount ";
            List<Discount> localDiscountList = new List<Discount>();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Discount newDiscount = new Discount();

                    newDiscount.discountID = SafeGetInt(dataReader, 0);
                    newDiscount.carID = SafeGetInt(dataReader, 1);
                    newDiscount.percentage = SafeGetInt(dataReader, 2);
                    newDiscount.validation = SafeGetString(dataReader, 3);

                    localDiscountList.Add(newDiscount);
                }

                dataReader.Close();
                this.CloseConnection();
               
                return localDiscountList;
            }
            else
            {
                return null;
            }
        }
        public void UpdateReservation(Reservation reservation) {
            string query = "Update Reservation ";
            query += string.Format("SET Startdate='{0}',Enddate='{1}', Confirmed={2}, Kilometres={3}, Pickupcity='{4}', Pickupstreetname='{5}', Pickupstreetnumber={6}, Pickupstreetnumbersuffix='{7}', Paid={8}, Comment='{9}' ", reservation.startdate, reservation.enddate, reservation.confirmed, reservation.kilometres, reservation.pickupcity, reservation.pickupstreetname, reservation.pickupstreetnumber, reservation.pickupstreetnumbersuffix, reservation.paid, reservation.comment);
            query += string.Format("Where ReservationID = " + reservation.reservationID);

            Console.WriteLine(query);
            if (this.OpenConnection() == true) {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                Console.WriteLine(cmd.CommandText);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }
        public void DeleteReservation(Reservation reservation) {
            string query = "DELETE FROM Reservation ";
            query += string.Format("WHERE ReservationID = {0}", reservation.reservationID);

            if (this.OpenConnection() == true) {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }
        public void UpdateCar(Car car) {
            string query = "Update Car ";
            query += string.Format("SET EstablishmentID={0},Brand='{1}', Model='{2}', Category='{3}', Modelyear={4}, Automatic={5}, Kilometers={6}, Colour='{7}', Doors={8}, Stereo={9}, Bluetooth={10}, Horsepower={11}, Length={12}, Width={13}, Height={14}, Weight={15}, Navigation={16}, Cruisecontrol={17}, Parkingassist={18}, 4WD={19}, Cabrio={20}, Airco={21}, Seats={22}, MOTDate='{23}', Storagespace={24}, Gearsamount={25}, Motor='{26}', Fuelusage={27}, Startprice={28}, Rentalprice={29}, Sellingprice={30}, Available={31}, Description='{32}' ", car.establishmentID, car.brand, car.model, car.category, car.modelyear, car.automatic, car.kilometres, car.colour, car.doors, car.stereo, car.bluetooth, car.horsepower, car.length, car.width, car.height, car.weight, car.navigation, car.cruisecontrol, car.parkingAssist, car.fourwheeldrive, car.cabrio, car.airco, car.seats, car.motdate, car.storagespace, car.gearsamount, car.motor, car.Fuelusage, car.startprice, car.rentalprice, car.sellingprice, car.available, car.description);
            query += string.Format("Where carID = " + car.carID);

            Console.WriteLine(query);
            if (this.OpenConnection() == true) {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }
        public void DeleteCar(Car car) {
            string query = "DELETE FROM Car ";
            query += string.Format("WHERE CarID = {0}", car.carID);

            if (this.OpenConnection() == true) {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }
        public void DeleteUser(User user)
        {
            string query = "DELETE From User ";
            query += "Where UserID=" + user.UserID;

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }
        public static string SafeGetString(MySqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            else
                return string.Empty;
        }
        public static string SafeInsertString(string input)
        {
            if (input == null || input == "")
            {
                input = "";
                return input;
            }
            else
            {
                return input;
            }
        }
        public static int SafeInsertInt(int input)
        {
            if (input == 0)
            {
                input = 0;
                return input;
            }
            else
            {
                return input;
            }
        }
        public static double SafeInsertDouble(double input)
        {
            if (input == 0.00 || input == 0)
            {
                input = 0;
                return input;
            }
            else
            {
                return input;
            }
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
        public string createHash(string password)
        {
            return PasswordHash.CreateHash(password);
        }
        private bool CompareStrings(string string1, string string2)// method to compare strings
        {
            return String.Compare(string1, string2, true, System.Globalization.CultureInfo.InvariantCulture) == 0 ? true : false;
        }

        public List<ToS> selectToS()
        {
            string query = " SELECT ToSID, ToS, date FROM ToS where ToSID = 0";
            List<ToS> ToSList = new List<ToS>();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    ToS tos = new ToS();
                    tos.ToSID = SafeGetInt(dataReader, 0);
                    tos.ToSInfo = SafeGetString(dataReader, 1);
                    tos.date = SafeGetString(dataReader, 2);


                    ToSList.Add(tos);
                }

                dataReader.Close();
                this.CloseConnection();

                return ToSList;
            }
            else
            {
                return null;
            }
        }
        public bool InsertToS(ToS tos)
        {
            int result = 0;
            try
            {
                string query = "UPDATE ToS SET ToS = @ToS";
                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@ToS", SafeInsertString(tos.ToSInfo));

                    result = cmd.ExecuteNonQuery();
                    CloseConnection();
                }
            }
            catch (Exception)
            {
                return false;
            }
            if (result > 0)
                return true;
            else
                return false;


        }
    }

}
