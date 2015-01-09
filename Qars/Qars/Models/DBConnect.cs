
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
using Qars.Models.DBObjects;
using Qars.Util;
namespace Qars.Models
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
        } //Hash this thing like the LogInUser thingy does it
        public int LogInUser(string username, string password)
        {
            int userID = 0;
            string usernameQuery = "";
            string passwordQuery = "";
            string query = String.Format("SELECT UserID, Username, Password FROM User WHERE Username = @username");

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
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
                        newCar.fuelusage = SafeGetInt(dataReader, 28);
                        newCar.startprice = SafeGetInt(dataReader, 29);
                        newCar.rentalprice = SafeGetDouble(dataReader, 30);
                        newCar.sellingprice = SafeGetDouble(dataReader, 31);
                        newCar.available = SafeGetBoolean(dataReader, 32);
                        newCar.description = SafeGetString(dataReader, 33);
                        newCar.LicensePlate = SafeGetString(dataReader, 34);
                        // see if the car has photos, and at the first one to the list
                        try
                        {
                            newCar.PhotoList.Add(new CarPhoto(SafeGetInt(dataReader, 35), SafeGetInt(dataReader, 36), SafeGetString(dataReader, 37), SafeGetString(dataReader, 38), SafeGetString(dataReader, 39), SafeGetString(dataReader, 40)));
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
                                    car.PhotoList.Add(new CarPhoto(SafeGetInt(dataReader, 35), SafeGetInt(dataReader, 36), SafeGetString(dataReader, 37), SafeGetString(dataReader, 38), SafeGetString(dataReader, 39), SafeGetString(dataReader, 40)));
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
                    newUser.Establishment = SafeGetInt(dataReader, 15);

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
            query += string.Format("Set AccountLevel=@accountlevel, Username=@username, Password=@password,Firstname=@firstname, Lastname=@lastname,Age=@age,Postalcode=@postalcode,City=@city, Streetname=@streetname, Streetnumber=@streetnumber, Streetnumbersuffix=@streetnumbersuffix, Phonenumber=@phonenumber, Emailaddress=@emailaddress, Driverslicencelink=@driverslicenselink, Establishment=@establishment");
            query += string.Format("Where UserID = @userID");

            Console.WriteLine(query);
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@userID", SafeInsertInt(user.UserID));
                cmd.Parameters.AddWithValue("@accountlevel", SafeInsertInt(user.accountLevel));
                cmd.Parameters.AddWithValue("@username", SafeInsertString(user.username));
                cmd.Parameters.AddWithValue("@password", SafeInsertString(PasswordHash.CreateHash(user.password)));
                cmd.Parameters.AddWithValue("@firstname", SafeInsertString(user.firstname));
                cmd.Parameters.AddWithValue("@lastname", SafeInsertString(user.lastname));
                cmd.Parameters.AddWithValue("@age", SafeInsertInt(user.age));
                cmd.Parameters.AddWithValue("@postalcode", SafeInsertString(user.postalcode));
                cmd.Parameters.AddWithValue("@city", SafeInsertString(user.city));
                cmd.Parameters.AddWithValue("@streetname", SafeInsertString(user.streetname));
                cmd.Parameters.AddWithValue("@streetnumber", user.streetnumber);
                cmd.Parameters.AddWithValue("@streetnumbersuffix", user.streetnumbersuffix);
                cmd.Parameters.AddWithValue("@phonenumber", SafeInsertString(user.phonenumber));
                cmd.Parameters.AddWithValue("@emailaddress", SafeInsertString(user.emailaddress));
                cmd.Parameters.AddWithValue("@driverslicenselink", SafeInsertString(user.driverslicenselink));
                cmd.Parameters.AddWithValue("@establishment", SafeInsertInt(user.Establishment)); //Isn't this a foreign key? Edit Database model!
                cmd.ExecuteNonQuery();
                CloseConnection();
            }

        }
        public bool InsertReservation(Reservation reservation)
        {
            int result = 0;
            int ReservationID = 0;
            string query = "SELECT count(*) FROM Reservation";

            try
            {

                if (connection.State != ConnectionState.Open)
                {
                    OpenConnection();
                }
                MySqlTransaction transaction = connection.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand(query, connection);

                ReservationID = Convert.ToInt32(cmd.ExecuteScalar());


                ReservationID++;
                string query2 = "INSERT INTO `Reservation`(`ReservationID`, `CarID`, `UserID`, `Startdate`, `Enddate`, `Confirmed`, `Kilometres`, `Pickupcity`, `Pickupstreetname`, `Pickupstreetnumber`, `Pickupstreetnumbersuffix`, `Paid`, `Comment`) VALUES(@reservationid,@carid,@UserID,@startdate,@enddate,@confirmed,@Kilometres,@pickupcity,@pickupstreetname,@pickupnumber,@pickupnumbersuffix,@paid,@comment)";

                int convertConfirmedToInt = 0;
                int convertPaidtoInt = 0;
                cmd.CommandText = query2;

                cmd.Parameters.AddWithValue("@reservationid", SafeInsertInt(reservation.reservationID));
                cmd.Parameters.AddWithValue("@carid", SafeInsertInt(reservation.carID));
                cmd.Parameters.AddWithValue("@UserID", SafeInsertInt(reservation.UserID));
                cmd.Parameters.AddWithValue("@startdate", SafeInsertString(reservation.startdate));
                cmd.Parameters.AddWithValue("@enddate", SafeInsertString(reservation.enddate));
                cmd.Parameters.AddWithValue("@confirmed", SafeInsertInt(convertConfirmedToInt));
                cmd.Parameters.AddWithValue("@Kilometres", SafeInsertInt(reservation.kilometres));
                cmd.Parameters.AddWithValue("@pickupcity", SafeInsertString(reservation.pickupcity));
                cmd.Parameters.AddWithValue("@pickupstreetname", SafeInsertString(reservation.pickupstreetname));
                cmd.Parameters.AddWithValue("@pickupnumber", SafeInsertInt(reservation.pickupstreetnumber));
                cmd.Parameters.AddWithValue("@pickupnumbersuffix", SafeInsertString(reservation.pickupstreetnumbersuffix));
                cmd.Parameters.AddWithValue("@paid", SafeInsertInt(convertPaidtoInt));
                cmd.Parameters.AddWithValue("@comment", SafeInsertString(reservation.comment));

                result = cmd.ExecuteNonQuery();
                transaction.Commit();

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.Source);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }
        public bool InsertCustomer(User customer)
        {
            int result = 0;
            int UserID = 0;
            string query = "SELECT COUNT(*) FROM User";

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    OpenConnection();
                }

                MySqlTransaction transaction = connection.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                UserID = (Int32)cmd.ExecuteScalar();
                UserID++;

                string salt = createHash(customer.password);
                string query2 = "INSERT INTO `User` (`UserID`,`Accountlevel`,`Username`, `Password`,`Firstname`, `Lastname`, `Age`, `Postalcode`, `City`, `Streetname`, `Streetnumber`, `Streetnumbersuffix`, `Phonenumber`, `Emailaddress`, `Driverslicencelink`) VALUES (@UserID, @accountlevel,@username,@password,@firstname,@lastname, @age, @postalcode,@city,@streetname,@streetnumber,@streetnumbersuffix, @phonenumber, @emailaddress, @driverslicenselink)";

                cmd.CommandText = query2;

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
                transaction.Commit();
            }

            catch (Exception)
            {
                return false;
            }
            finally
            {
                CloseConnection();
            }
            if (result > 0)
                return true;
            else
                return false;


        }
        public bool InsertCar(Car car) //Create LicensePlate input field in the form!
        {
            Console.WriteLine(car.brand);
            int queryresult = 0;

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    OpenConnection();
                }
                MySqlTransaction transaction = connection.BeginTransaction();
                string query = "Select max(CarID) From Car";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                int maxCarId = Convert.ToInt32(cmd.ExecuteScalar());
                maxCarId++;

                query = "INSERT INTO Car(CarID, EstablishmentID, Brand, Model, Category, Modelyear, Automatic, Kilometers, Colour, Doors, Stereo, Bluetooth, HorsePower, Length, Width, Height, Weight, Navigation, Cruisecontrol, Parkingassist, 4WD, Cabrio, Airco, Seats, MOTDate, Storagespace, Gearsamount, Motor, Fuelusage, Startprice, Rentalprice, Sellingprice, Available, Description, LicensePlate)";
                query += "Values(@maxCarId,@establishmentID,@brand, @model, @category, @modelyear, @automatic, @kilometres, @colour, @doors,@stereo,@bluetooth,@horsepower,@length,@width,@height,@weight,@navigation,@cruisecontrol,@parkingassist,@4wd,@cabrio,@airco,@seats,@motd,@storagespace,@gearsamount,@motor,@fuelusage,@startprice,@rentalprice,@sellingprice,@available,@description, @licenseplate); ";

                cmd.CommandText = query;

                cmd.Parameters.AddWithValue("@maxCarId", SafeInsertInt(maxCarId));
                cmd.Parameters.AddWithValue("@establishmentID", SafeInsertInt(1)); //Why is there no car.establishmentID link or something??
                cmd.Parameters.AddWithValue("@brand", SafeInsertString(car.brand));
                cmd.Parameters.AddWithValue("@model", SafeInsertString(car.model));
                cmd.Parameters.AddWithValue("@category", SafeInsertString(car.category));
                cmd.Parameters.AddWithValue("@modelyear", SafeInsertInt(car.modelyear));
                cmd.Parameters.AddWithValue("@automatic", car.automatic);
                cmd.Parameters.AddWithValue("@kilometres", SafeInsertInt(car.kilometres));
                cmd.Parameters.AddWithValue("@colour", SafeInsertString(car.colour));
                cmd.Parameters.AddWithValue("@doors", SafeInsertInt(car.doors));
                cmd.Parameters.AddWithValue("@stereo", car.stereo);
                cmd.Parameters.AddWithValue("@bluetooth", car.bluetooth);
                cmd.Parameters.AddWithValue("@horsepower", SafeInsertDouble(car.horsepower));
                cmd.Parameters.AddWithValue("@length", SafeInsertInt(car.length));
                cmd.Parameters.AddWithValue("@width", SafeInsertInt(car.width));
                cmd.Parameters.AddWithValue("@height", SafeInsertInt(car.height));
                cmd.Parameters.AddWithValue("@weight", SafeInsertInt(car.weight));
                cmd.Parameters.AddWithValue("@navigation", car.navigation);
                cmd.Parameters.AddWithValue("@cruisecontrol", car.cruisecontrol);
                cmd.Parameters.AddWithValue("@parkingassist", car.parkingAssist);
                cmd.Parameters.AddWithValue("@4wd", car.fourwheeldrive);
                cmd.Parameters.AddWithValue("@cabrio", car.cabrio);
                cmd.Parameters.AddWithValue("@motd", SafeInsertString(car.motdate));
                cmd.Parameters.AddWithValue("@seats", SafeInsertInt(car.seats));
                cmd.Parameters.AddWithValue("@storagespace", SafeInsertDouble(car.storagespace));
                cmd.Parameters.AddWithValue("@gearsamount", SafeInsertInt(car.gearsamount));
                cmd.Parameters.AddWithValue("@motor", SafeInsertString(car.motor));
                cmd.Parameters.AddWithValue("@fuelusage", SafeInsertInt(car.fuelusage));
                cmd.Parameters.AddWithValue("@startprice", SafeInsertDouble(car.startprice));
                cmd.Parameters.AddWithValue("@sellingprice", SafeInsertDouble(car.sellingprice));
                cmd.Parameters.AddWithValue("@rentalprice", SafeInsertDouble(car.rentalprice));
                cmd.Parameters.AddWithValue("@available", car.available);
                cmd.Parameters.AddWithValue("@description", SafeInsertString(car.description));
                cmd.Parameters.AddWithValue("@airco", car.airco);
                cmd.Parameters.AddWithValue("@licenseplate", SafeInsertString(car.LicensePlate)); //Create Licenseplate Label and textbox! 


                queryresult = cmd.ExecuteNonQuery();


                foreach (CarPhoto photo in car.PhotoList)
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    if (connection.State != ConnectionState.Open)
                    {
                        this.OpenConnection();
                    }

                    string file = photo.Photolink; ;
                    string fileExtension = "." + file.Split('.').Last();
                    Console.WriteLine(fileExtension);
                    string remoteLink = string.Format("http://pqrojectqars.herobo.com/Images/{0}/{1}/{2}/{3}", car.brand, car.model, car.colour, photo.PhotoID + fileExtension);

                    query = "INSERT INTO Photo(PhotoID, CarID, Name, Description, Datetaken, Photolink) ";
                    query += "VALUES(@PhotoID, @CarID, @Name, @Description, @Datetaken, @Photolink)";

                    command.CommandText = query;
                    command.Parameters.AddWithValue("@CarID", maxCarId);
                    command.Parameters.AddWithValue("@PhotoID", photo.PhotoID);
                    command.Parameters.AddWithValue("@Name", photo.Name);
                    command.Parameters.AddWithValue("@Description", photo.Description);
                    command.Parameters.AddWithValue("@Datetaken", photo.Datetaken);
                    command.Parameters.AddWithValue("@Photolink", remoteLink);

                    command.ExecuteNonQuery();
                    maxCarId++;
                }


                transaction.Commit();
                MessageBox.Show("De auto met de bijbehorende foto's is toegevoegd.");
                if (queryresult > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception w)
            {
                MessageBox.Show("Fout bij het toevoegen van de auto." + w);
            }
            finally
            {
                CloseConnection();
            }
            return false;
        }

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
                    newDiscount.KMPercentage = SafeGetInt(dataReader, 4);

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
        public void UpdateReservation(Reservation reservation)
        {
            string query = "Update Reservation ";
            query += string.Format("SET Startdate=@startdate,Enddate=@enddate, Confirmed=@confirmed, Kilometres=@kilometres, Pickupcity=@pickupcity, Pickupstreetname=@pickupstreetname, Pickupstreetnumber=@pickupstreetnumber, Pickupstreetnumbersuffix=@pickupstreetnumbersuffix, Paid=@paid, Comment=@comment ");
            query += string.Format("Where ReservationID = @resID");

            Console.WriteLine(query);
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@startdate", SafeInsertString(reservation.startdate));
                cmd.Parameters.AddWithValue("@enddate", SafeInsertString(reservation.enddate));
                cmd.Parameters.AddWithValue("@confirmed", reservation.confirmed);
                cmd.Parameters.AddWithValue("@kilometres", SafeInsertInt(reservation.kilometres));
                cmd.Parameters.AddWithValue("@pickupcity", SafeInsertString(reservation.pickupcity));
                cmd.Parameters.AddWithValue("@pickupstreetname", SafeInsertString(reservation.pickupstreetname));
                cmd.Parameters.AddWithValue("@pickupstreetnumber", SafeInsertInt(reservation.pickupstreetnumber));
                cmd.Parameters.AddWithValue("@pickupstreetnumbersuffix", SafeInsertString(reservation.pickupstreetnumbersuffix));
                cmd.Parameters.AddWithValue("@paid", reservation.paid);
                cmd.Parameters.AddWithValue("@comment", SafeInsertString(reservation.comment));
                cmd.Parameters.AddWithValue("@resID", SafeInsertInt(reservation.reservationID));

                Console.WriteLine(cmd.CommandText);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }
        public void DeleteReservation(Reservation reservation)
        {
            string query = "DELETE FROM Reservation ";
            query += string.Format("WHERE ReservationID = @reservationID");

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@reservationID", SafeInsertInt(reservation.reservationID));
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }
        public void UpdateCar(Car car)
        {
            string query = "Update Car ";
            query += string.Format("SET EstablishmentID=@establishmentID,Brand=@brand, Model=@model, Category=@category, Modelyear=@modelyear, Automatic=@automatic, Kilometers=@kilometres, Colour=@colour, Doors=@doors, Stereo=@stereo, Bluetooth=@bluetooth, Horsepower=@horsepower, Length=@length, Width=@width, Height=@height, Weight=@weight, Navigation=@navigation, Cruisecontrol=@cruisecontrol, Parkingassist=@parkingassist, 4WD=@4wd, Cabrio=@cabrio, Airco=@airco, Seats=@seats, MOTDate=@motd, Storagespace=@storagespace, Gearsamount=@gearsamount, Motor=@motor, Fuelusage=@fuelusage, Startprice=@startprice, Rentalprice=@rentalprice, Sellingprice=@sellingprice, Available=@available, Description=@description, LicensePlate=@licenseplate ");
            query += string.Format("Where carID = @carid");

            try
            {
                Console.WriteLine(query);
                if (this.OpenConnection() == true)
                {
                    MySqlTransaction transaction = connection.BeginTransaction();
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@carid", SafeInsertInt(car.carID));
                    cmd.Parameters.AddWithValue("@establishmentID", SafeInsertInt(car.establishmentID));
                    cmd.Parameters.AddWithValue("@brand", SafeInsertString(car.brand));
                    cmd.Parameters.AddWithValue("@model", SafeInsertString(car.model));
                    cmd.Parameters.AddWithValue("@category", SafeInsertString(car.category));
                    cmd.Parameters.AddWithValue("@modelyear", SafeInsertInt(car.modelyear));
                    cmd.Parameters.AddWithValue("@automatic", car.automatic);
                    cmd.Parameters.AddWithValue("@kilometres", SafeInsertInt(car.kilometres));
                    cmd.Parameters.AddWithValue("@colour", SafeInsertString(car.colour));
                    cmd.Parameters.AddWithValue("@doors", SafeInsertInt(car.doors));
                    cmd.Parameters.AddWithValue("@stereo", car.stereo);
                    cmd.Parameters.AddWithValue("@bluetooth", car.bluetooth);
                    cmd.Parameters.AddWithValue("@horsepower", SafeInsertDouble(car.horsepower));
                    cmd.Parameters.AddWithValue("@length", SafeInsertInt(car.length));
                    cmd.Parameters.AddWithValue("@width", SafeInsertInt(car.width));
                    cmd.Parameters.AddWithValue("@height", SafeInsertInt(car.height));
                    cmd.Parameters.AddWithValue("@weight", SafeInsertInt(car.weight));
                    cmd.Parameters.AddWithValue("@navigation", car.navigation);
                    cmd.Parameters.AddWithValue("@cruisecontrol", car.cruisecontrol);
                    cmd.Parameters.AddWithValue("@parkingassist", car.parkingAssist);
                    cmd.Parameters.AddWithValue("@4wd", car.fourwheeldrive);
                    cmd.Parameters.AddWithValue("@cabrio", car.cabrio);
                    cmd.Parameters.AddWithValue("@motd", SafeInsertString(car.motdate));
                    cmd.Parameters.AddWithValue("@seats", SafeInsertInt(car.seats));
                    cmd.Parameters.AddWithValue("@storagespace", SafeInsertDouble(car.storagespace));
                    cmd.Parameters.AddWithValue("@gearsamount", SafeInsertInt(car.gearsamount));
                    cmd.Parameters.AddWithValue("@motor", SafeInsertString(car.motor));
                    cmd.Parameters.AddWithValue("@fuelusage", SafeInsertInt(car.fuelusage));
                    cmd.Parameters.AddWithValue("@startprice", SafeInsertDouble(car.startprice));
                    cmd.Parameters.AddWithValue("@sellingprice", SafeInsertDouble(car.sellingprice));
                    cmd.Parameters.AddWithValue("@rentalprice", SafeInsertDouble(car.rentalprice));
                    cmd.Parameters.AddWithValue("@available", car.available);
                    cmd.Parameters.AddWithValue("@description", SafeInsertString(car.description));
                    cmd.Parameters.AddWithValue("@airco", car.airco);
                    cmd.Parameters.AddWithValue("@licenseplate", SafeInsertString(car.LicensePlate)); //Create Licenseplate Label and textbox! 

                    Console.WriteLine(cmd.CommandText);
                    cmd.ExecuteNonQuery();


                    List<int> PhotoIDs = new List<int>();
                    string query2 = "SELECT PhotoID From Photo";
                    cmd.CommandText = query2;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        PhotoIDs.Add(SafeGetInt(dataReader, 0));
                    }
                    dataReader.Close();
                    foreach (CarPhoto c in car.PhotoList)
                    {
                        bool exists = false;
                        foreach (int i in PhotoIDs)
                        {
                            if (c.PhotoID == i)
                            {
                                exists = true;
                                Console.WriteLine(c.PhotoID);
                            }
                        }

                        if (!exists)
                        {
                            query = "INSERT INTO Photo (PhotoID, CarID, Name, Description, Datetaken, Photolink) ";
                            query += "VALUES(@photoid, @carid2, @name, @description2, @datetaken, @photolink)";
                            cmd.CommandText = query;

                            string file = c.Photolink;
                            ;
                            string fileExtension = "." + file.Split('.').Last();
                            Console.WriteLine(fileExtension);
                            string remoteLink = string.Format("http://pqrojectqars.herobo.com/Images/{0}/{1}/{2}/{3}", car.brand, car.model, car.colour, c.PhotoID + fileExtension);

                            cmd.Parameters.AddWithValue("@photoid", c.PhotoID);
                            cmd.Parameters.AddWithValue("@carid2", c.CarID);
                            cmd.Parameters.AddWithValue("@name", c.Name);
                            cmd.Parameters.AddWithValue("@description2", c.Description);
                            cmd.Parameters.AddWithValue("@datetaken", c.Datetaken);
                            cmd.Parameters.AddWithValue("@photolink", remoteLink);

                            Console.WriteLine(cmd.CommandText);
                            cmd.ExecuteNonQuery();

                        }


                    }
                    transaction.Commit();

                }
            }
            catch (Exception e)
            {

                MessageBox.Show("Fout tijdens het updaten van de auto" + e);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void DeleteCar(Car car)
        {
            MySqlTransaction transaction = connection.BeginTransaction();
            try
            {
                string query = "DELETE FROM Car ";
                query += string.Format("WHERE CarID = @carid");

                if (connection.State != ConnectionState.Open)
                {
                    this.OpenConnection();
                }

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@carid", SafeInsertInt(car.carID));
                cmd.ExecuteNonQuery();

                query = "DELTE FROM Photo WHERE CarID = @carid";
                cmd.CommandText = query;

                cmd.Parameters.AddWithValue("@carid", SafeInsertInt(car.carID));
                cmd.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void DeleteUser(User user)
        {
            string query = "DELETE From User ";
            query += "Where UserID = @userid";

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    OpenConnection();
                }

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@userid", SafeInsertInt(user.UserID));
                cmd.ExecuteNonQuery();
                MessageBox.Show("De gebruiker met het nummer: " + user.UserID + " is verwijderd.");
            }
            catch (Exception)
            {
                MessageBox.Show("Deze klant kan niet verwijderd worden, omdat er waarschijnlijk nog reserveringen gepland staan. Als u de klant wilt verwijderen moeten eerst de reserveringen verwijdert worden.");
            }
            finally
            {
                CloseConnection();
            }
        }
        public void DeletePhoto(CarPhoto photo)
        {
            string query = "DELETE From Photo ";
            query += string.Format("WHERE PhotoID = {0}", photo.PhotoID);

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    OpenConnection();
                }
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Fout tijdens het verwijderen van de foto.");
            }
            finally
            {
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
            string query = " SELECT ToSID, ToS, date FROM ToS where ToSID = 0 LIMIT 1";
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

        public int getHighestPhotoID()
        {
            int maxPhotoID = -1;
            string query = "SELECT max(PhotoID) From Photo";

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                MySqlCommand cmd = new MySqlCommand(query, connection);
                maxPhotoID = Convert.ToInt32(cmd.ExecuteScalar());
                maxPhotoID++;
            }
            catch (Exception e)
            {
                MessageBox.Show("Fout bij het ophalen van het laatste fotonummer." + e);
            }
            finally
            {
                CloseConnection();
            }
            return maxPhotoID;
        }
    }

}
