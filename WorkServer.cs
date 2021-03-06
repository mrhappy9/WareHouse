﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Course1
{
    public class WorkServer
    {
        private static string connString = "server=localhost;user=root;database=warehouse;password=password;" +
                                           "Allow User Variables=True;";
        private MySqlConnection connection;
        public void createConnection()
        {
            connection = new MySqlConnection(connString);
            connection.Open();
        }
        public void loseConnection()
        {
            connection.Close();
        }

        public void addUser(string login, string password, string email)
        {
            createConnection();
            string add_to_sql = $@"INSERT INTO Users(Login, Password, Email) VALUES ({login}, {password}, {email});";
            string get_from_sql = "SELECT * FROM Underwear WHERE Price = 5800";
            try
            {
                MySqlCommand command = new MySqlCommand(connString, connection);
                command.CommandText = "INSERT INTO Users(Login, Password, Email) VALUES (@Login, @Password, @Email)";
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Email", email);
                command.ExecuteNonQuery();
                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }

        public bool logIn(string login, string password)
        {
            MySqlCommand command = new MySqlCommand(connString, connection);
            command.CommandText = "SELECT Login, Password FROM Users WHERE Login = @Login AND Password = @Password";
            command.Parameters.AddWithValue("@Login", login);
            command.Parameters.AddWithValue("@Password", password);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                return true;
            }
            return false;
        }
        public bool adminIn(string login, string password)
        {
            createConnection();
            try { 
                MySqlCommand command = new MySqlCommand(connString, connection);
                command.CommandText = "SELECT Login, Password FROM Admin WHERE Login = @Login AND Password = @Password";
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Password", password);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return true;
                }
                return false;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Error executing with sql statement", ex);
            }
        }
        public bool storeKeeperIn(string login, string password)
        {
            createConnection();
            try
            {
                MySqlCommand command = new MySqlCommand(connString, connection);
                command.CommandText = "SELECT Login, Password FROM StoreKeeper WHERE Login = @Login AND Password = @Password";
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Password", password);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return true;
                }
                return false;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Error executing with sql statement", ex);
            }
        }

        public bool CheckEmail(String email)  // for recovering form
        {
            MySqlCommand commandCheck = new MySqlCommand(connString, connection);
            commandCheck.CommandText = "SELECT Email FROM Users WHERE Email = @Email";
            commandCheck.Parameters.AddWithValue("@Email", email);
            MySqlDataReader reader = commandCheck.ExecuteReader();
            while (reader.Read())
            {
                return true;
            }
            return false;
        }

        public String getLogin(String email)// for recovering getting login for sending info 
        {
            createConnection();
            MySqlCommand commandLogin = new MySqlCommand(connString, connection);
            commandLogin.CommandText = "SELECT Login FROM Users WHERE Email = @Email";
            commandLogin.Parameters.AddWithValue("@Email", email);
            MySqlDataReader reader = commandLogin.ExecuteReader();
            while (reader.Read())
            {
                return reader[0].ToString();
            }
            return "";
        }

        public void updatePassword(String email, String newpassword)
        {
            try
            {
                createConnection();
                MySqlCommand updatePassword = new MySqlCommand(connString, connection);
                updatePassword.CommandText = "UPDATE Users SET Password = @Password WHERE Email = @Email";
                updatePassword.Parameters.AddWithValue("@Password", newpassword);
                updatePassword.Parameters.AddWithValue("@Email", email);
                updatePassword.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new Exception("Error executing with sql statement", ex);
            }
            loseConnection();
        }

        public String getEmailForManageUser(string login, string password)
        {
            try
            {
                createConnection();
                MySqlCommand getLogin = new MySqlCommand(connString, connection);
                getLogin.CommandText = "SELECT Email FROM Users WHERE Login = @Login AND Password = @Password";
                getLogin.Parameters.AddWithValue("@Login", login);
                getLogin.Parameters.AddWithValue("@Password", password);
                MySqlDataReader reader = getLogin.ExecuteReader();
                while (reader.Read())
                {
                    return reader[0].ToString();
                }
                return "";
            }
            catch (MySqlException ex)
            {
                throw new Exception("Error executing with sql statement", ex);
            }

        }
        public void createInfoStringFields(string table, ref List<String> list, string subject) // fill up info into each string's block
        {
            createConnection();
            MySqlCommand getList = new MySqlCommand(connString, connection);
            getList.CommandText = $"SELECT {subject} FROM {table}";
            MySqlDataReader reader = getList.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader[0].ToString());
            }
            loseConnection();
        }
        public void createInfoIntFields(string table, ref List<int> list, string subject) // fill up info into each int's block
        {
            createConnection();
            MySqlCommand getList = new MySqlCommand(connString, connection);
            getList.CommandText = $"SELECT {subject} FROM {table}";
            MySqlDataReader reader = getList.ExecuteReader();
            while (reader.Read())
            {
                list.Add(Convert.ToInt32(reader[0].ToString()));
            }
            loseConnection();
        }
        public void createInfoDoubleFields(string table, ref List<double> list, string subject) // fill up info into each int's block
        {
            createConnection();
            MySqlCommand getList = new MySqlCommand(connString, connection);
            getList.CommandText = $"SELECT {subject} FROM {table}";
            MySqlDataReader reader = getList.ExecuteReader();
            while (reader.Read())
            {
                list.Add(Convert.ToDouble(reader[0].ToString()));
            }
            loseConnection();
        }
        public void createInfoBooksArray(string table, ref List<String> titles, ref List<String> author, ref List<int> price, ref List<int> quantity)
        {
            try
            {
                createInfoStringFields(table, ref titles, "Name");
                createInfoStringFields(table, ref author, "Author");
                createInfoIntFields(table, ref price, "Price");
                createInfoIntFields(table, ref quantity, "Quantity");

            }
            catch (MySqlException ex)
            {
                throw new Exception("Error executing with sql statement", ex);
            }
        }

        public void createInfoLaptopsPcsArray(string table, ref List<String> titles, ref List<String> cpu, ref List<int> ram,
                                           ref List<int> hdd, ref List<int> ssd, ref List<String> gpu,
                                           ref List<String> os, ref List<int> price, ref List<int> quantity)
        {
            try
            {
                createInfoStringFields(table, ref titles, "Name");
                createInfoStringFields(table, ref cpu, "CPU");
                createInfoIntFields(table, ref ram, "RAM");
                createInfoIntFields(table, ref hdd, "HDD");
                createInfoIntFields(table, ref ssd, "SSD");
                createInfoStringFields(table, ref gpu, "GPU");
                createInfoStringFields(table, ref os, "OS");
                createInfoIntFields(table, ref price, "Price");
                createInfoIntFields(table, ref quantity, "Quantity");

            }
            catch (Exception ex) { throw new Exception("Error executing with sql statement", ex); }
        }
        public void createInfoHphonesArray(string table, ref List<String> titles, ref List<String> mic, ref List<String> type, ref List<int> workingHours,
                                           ref List<int> resistance, ref List<int> price, ref List<int> quantity)
        {
            try
            {
                createInfoStringFields(table, ref titles, "Name");
                createInfoStringFields(table, ref mic, "Microphone");
                createInfoStringFields(table, ref type, "Constaction_type");
                createInfoIntFields(table, ref workingHours, "Working_hours");
                createInfoIntFields(table, ref resistance, "Resistance");
                createInfoIntFields(table, ref price, "Price");
                createInfoIntFields(table, ref quantity, "Quantity");
            }
            catch (Exception ex) { throw new Exception("Error executing with sql statement", ex); }
        }

        public void createInfoTvsArray(string table, ref List<String> titles, ref List<double> screenDiagonal, ref List<String> resolution,
                                       ref List<String> features, ref List<int> price, ref List<int> quantity)
        {
            try
            {
                createInfoStringFields(table, ref titles, "Name");
                createInfoDoubleFields(table, ref screenDiagonal, "Screen_diagonal");
                createInfoStringFields(table, ref resolution, "Max_resolution");
                createInfoStringFields(table, ref features, "Features");
                createInfoIntFields(table, ref price, "Price");
                createInfoIntFields(table, ref quantity, "Quantity");

            }
            catch (Exception ex) { throw new Exception("Error executing with sql statement", ex); }
        }

        public void createInfoSmartWatchArray(string table, ref List<String> titles, ref List<String> compatibleOS, ref List<String> sensors,
                                              ref List<String> screenResolution, ref List<int> price, ref List<int> quantity)
        {
            try
            {
                createInfoStringFields(table, ref titles, "Name");
                createInfoStringFields(table, ref compatibleOS, "Compatible_OS");
                createInfoStringFields(table, ref sensors, "Sensors");
                createInfoStringFields(table, ref screenResolution, "Screen_resolution");
                createInfoIntFields(table, ref price, "Price");
                createInfoIntFields(table, ref quantity, "Quantity");

            }
            catch (Exception ex) { throw new Exception("Error executing with sql statement", ex); }
        }

        public void createInfoSmartPhones(string table, ref List<String> titles, ref List<int> internalMemory, ref List<int> ram,
                                          ref List<int> cameraResolution, ref List<double> screenDiagonal, ref List<int> capacity,
                                          ref List<int> price, ref List<int> quantity)
        {
            try
            {
                createInfoStringFields(table, ref titles, "Name");
                createInfoIntFields(table, ref internalMemory, "Internal_memory");
                createInfoIntFields(table, ref ram, "RAM");
                createInfoIntFields(table, ref cameraResolution, "Resolution_main_camera");
                createInfoDoubleFields(table, ref screenDiagonal, "Screen_diagonal");
                createInfoIntFields(table, ref capacity, "Capacity");
                createInfoIntFields(table, ref price, "Price");
                createInfoIntFields(table, ref quantity, "Quantity");

            }
            catch (Exception ex) { throw new Exception("Error executing with sql statement", ex); }
        }

        public void createInfoClothes(string table, ref List<String> titles, ref List<String> brand, ref List<String> materials,
                                      ref List<String> sex, ref List<int> price, ref List<int> quantity)
        {
            try
            {
                createInfoStringFields(table, ref titles, "Name");
                createInfoStringFields(table, ref brand, "Brand");
                createInfoStringFields(table, ref materials, "Material");
                createInfoStringFields(table, ref sex, "Sex");
                createInfoIntFields(table, ref price, "Price");
                createInfoIntFields(table, ref quantity, "Quantity");

            }
            catch (Exception ex) { throw new Exception("Error executing with sql statement", ex); }
        }

        /////////////////////////////////////////////////////////////
        ///creating Purchasing tables
        ////////////////////////////////////////////////////////////
        public int UsersId(string login)
        {
            createConnection();
            try
            {
                MySqlCommand command = new MySqlCommand(connString, connection);
                command.CommandText = "SELECT Users_id FROM Users WHERE Login = @login";
                command.Parameters.AddWithValue("@login", login);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return Convert.ToInt32(reader[0].ToString());
                }
                return 0;
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }

        public void createBookPurchaseTable(string title, string author, int price, int quantity, int users_id)
        {
            createConnection();
            try
            {
                MySqlCommand command = new MySqlCommand(connString, connection);
                command.CommandText = "INSERT INTO BookPurchase(Name, Author, Price, Quantity, Users_id) VALUES" +
                                      "(@title, @author, @price, @quantity, @users_id);";
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@author", author);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@users_id", users_id);
                command.ExecuteNonQuery();
                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        public void createClothesPurchaseTable(string title, string brand, string material, string sex, int price, int quantity, int users_id)
        {
            createConnection();
            try
            {
                MySqlCommand command = new MySqlCommand(connString, connection);
                command.CommandText = "INSERT INTO ClothesPurchase(Name, Brand, Material, Sex, Price, Quantity, Users_id) VALUES" +
                                      "(@title, @brand, @material, @sex, @price, @quantity, @users_id);";
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@brand", brand);
                command.Parameters.AddWithValue("@material", material);
                command.Parameters.AddWithValue("@sex", sex);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@users_id", users_id);
                command.ExecuteNonQuery();
                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        public void createLaptopsPcsPurchaseTable(string title, string cpu, int ram, int hdd, int ssd, string gpu, string os, int price, int quantity, int users_id)
        {
            createConnection();
            try
            {
                MySqlCommand command = new MySqlCommand(connString, connection);
                command.CommandText = "INSERT INTO LaptopsPcsPurchase(Name, CPU, RAM, HDD, SSD, GPU, OS, Price, Quantity, Users_id) VALUES" +
                                      "(@title, @cpu, @ram, @hdd, @ssd, @gpu, @os, @price, @quantity, @users_id);";
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@cpu", cpu);
                command.Parameters.AddWithValue("@ram", ram);
                command.Parameters.AddWithValue("@hdd", hdd);
                command.Parameters.AddWithValue("@ssd", ssd);
                command.Parameters.AddWithValue("@gpu", gpu);
                command.Parameters.AddWithValue("@os", os);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@users_id", users_id);
                command.ExecuteNonQuery();
                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        public void createHphonesPurchaseTable(string title, string mic, string type, int hours, int resistance, int price, int quantity, int users_id)
        {
            createConnection();
            try
            {
                MySqlCommand command = new MySqlCommand(connString, connection);
                command.CommandText = "INSERT INTO HeadPhonesPurchase(Name, Microphone, Constaction_type, Working_hours, Resistance, Price, Quantity, Users_id) VALUES" +
                                      "(@title, @mic, @type, @hours, @resistance, @price, @quantity, @users_id);";
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@mic", mic);
                command.Parameters.AddWithValue("@type", type);
                command.Parameters.AddWithValue("@hours", hours);
                command.Parameters.AddWithValue("@resistance", resistance);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@users_id", users_id);
                command.ExecuteNonQuery();
                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        public void createTvsPurchaseTable(string title, double diagonal, string resolution, string features, int price, int quantity, int users_id)
        {
            createConnection();
            try
            {
                MySqlCommand command = new MySqlCommand(connString, connection);
                command.CommandText = "INSERT INTO TvsPurchase(Name, Screen_diagonal, Max_resolution, Features, Price, Quantity, Users_id) VALUE" +
                                      "(@title, @diagonal, @resolution, @features, @price, @quantity, @users_id);";
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@diagonal", diagonal);
                command.Parameters.AddWithValue("@resolution", resolution);
                command.Parameters.AddWithValue("@features", features);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@users_id", users_id);
                command.ExecuteNonQuery();
                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        public void createSmartWathesTable(string title, string os, string sensors, string resolution, int price, int quantity, int users_id)
        {
            createConnection();
            try
            {
                MySqlCommand command = new MySqlCommand(connString, connection);
                command.CommandText = "INSERT INTO SmartWatchesPurchase(Name, Compatible_OS, Sensors, Screen_resolution, Price, Quantity, Users_id) VALUE" +
                                      "(@title, @os, @sensors, @resolution, @price, @quantity, @users_id);";
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@os", os);
                command.Parameters.AddWithValue("@sensors", sensors);
                command.Parameters.AddWithValue("@resolution", resolution);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@users_id", users_id);
                command.ExecuteNonQuery();
                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        public void createSmartPhonesTable(string title, int memory, int ram, int resolutionCamera, double screenDiagonal,
                                           int capacity, int price, int quantity, int users_id)
        {
            createConnection();
            try
            {
                MySqlCommand command = new MySqlCommand(connString, connection);
                command.CommandText = "INSERT INTO SmartPhonesPurchase(Name, Internal_memory, RAM, Resolution_main_camera, Screen_diagonal, Capacity, Price," +
                                      "Quantity, Users_id) VALUES" +
                                      "(@title, @memory, @ram, @resolutionCamera, @screenDiagonal, @capacity, @price, @quantity, @users_id);";
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@memory", memory);
                command.Parameters.AddWithValue("@ram", ram);
                command.Parameters.AddWithValue("@resolutionCamera", resolutionCamera);
                command.Parameters.AddWithValue("@screenDiagonal", screenDiagonal);
                command.Parameters.AddWithValue("@capacity", capacity);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@users_id", users_id);
                command.ExecuteNonQuery();
                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }

        ///////
        ///    Updating tables in the MySQL after order is confirmed
        //////

        public void updateQuantityItemsInTables(String table, String name, int newQuantityItems)
        {
            createConnection();
            try
            {
                MySqlCommand updateItems = new MySqlCommand(connString, connection);
                /*updateItems.CommandText = ($"UPDATE Childrenbooks SET Quantity = 1011 WHERE Name = '{name}'");*/
                updateItems.CommandText = ($"UPDATE {table} SET Quantity = {newQuantityItems} WHERE Name = '{name}';");
                /*updateItems.Parameters.AddWithValue("@table", table);
                updateItems.Parameters.AddWithValue("@newQuantityItems", newQuantityItems);
                updateItems.Parameters.AddWithValue("@name", name);*/
                updateItems.ExecuteNonQuery();
                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }

        ////////
        ///
        ///     For Admin user
        ///     
        ///////


        ////////////////////////////////////////////////
        ///-------------Changing books---------------///
        ////////////////////////////////////////////////
        public List<String> getParticularBook(string table, string name)
        {
            List<String> books = new List<String>();
            createConnection();
            try
            {
                MySqlCommand getBook = new MySqlCommand(connString, connection);
                getBook.CommandText = $" SELECT Author, Price, Quantity FROM {table} WHERE Name = '{name}'";
                MySqlDataReader reader = getBook.ExecuteReader();
                while (reader.Read())
                {
                    books.Add(reader[0].ToString());
                    books.Add(reader[1].ToString());
                    books.Add(reader[2].ToString());
                }
                loseConnection();
                return books;
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        public void updateBookTable(string table, string name, string author, int price, int quantity)
        {
            createConnection();
            try
            {
                MySqlCommand updateBook = new MySqlCommand(connString, connection);
                updateBook.CommandText = $"UPDATE {table} SET Author = '{author}', Price = {price}, Quantity = {quantity} " +
                                         $"WHERE Name = '{name}';";
                updateBook.ExecuteNonQuery();
                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        /////////////////////////////////////////////////end changing book/////////////////////////////////////


        ////////////////////////////////////////////////
        ///-------------Changing clothes---------------///
        ////////////////////////////////////////////////

        public List<String> getParticularClothes(string table, string name)
        {
            List<String> clothes = new List<String>();
            createConnection();
            try
            {
                MySqlCommand getClothes = new MySqlCommand(connString, connection);
                getClothes.CommandText = $" SELECT Brand, Material, Sex, Price, Quantity FROM {table} WHERE Name = '{name}'";
                MySqlDataReader reader = getClothes.ExecuteReader();
                while (reader.Read())
                {
                    clothes.Add(reader[0].ToString());
                    clothes.Add(reader[1].ToString());
                    clothes.Add(reader[2].ToString());
                    clothes.Add(reader[3].ToString());
                    clothes.Add(reader[4].ToString());
                }
                loseConnection();
                return clothes;
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        public void updateClothesTable(string table, string name, string brand, string material, string sex, int price, int quantity)
        {
            createConnection();
            try
            {
                MySqlCommand updateClothes = new MySqlCommand(connString, connection);
                updateClothes.CommandText = $"UPDATE {table} SET Brand = @brand , Material = '{material}', Sex = '{sex}', Price = {price}, Quantity = {quantity} " +
                                         $" WHERE Name = '{name}';";
                updateClothes.Parameters.AddWithValue("@brand", brand); // cause one of the brands named like Marc O'Polo
                updateClothes.ExecuteNonQuery();
                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }

        /////////////////////////////////////////////////end changing clothes///////////////////////////////////////////////////////////////////////////////


        ////////////////////////////////////////////////
        ///-------------Changing PcsLaptops---------------///
        ////////////////////////////////////////////////

        public List<String> getParticularLaptopsPcs(string table, string name)
        {
            List<String> laptopsPcs = new List<String>();
            createConnection();
            try
            {
                MySqlCommand getlaptopsPcs = new MySqlCommand(connString, connection);
                getlaptopsPcs.CommandText = $" SELECT CPU, GPU, OS, Price, Quantity FROM {table} WHERE Name = '{name}'";
                MySqlDataReader reader = getlaptopsPcs.ExecuteReader();
                while (reader.Read())
                {
                    laptopsPcs.Add(reader[0].ToString());
                    laptopsPcs.Add(reader[1].ToString());
                    laptopsPcs.Add(reader[2].ToString());
                    laptopsPcs.Add(reader[3].ToString());
                    laptopsPcs.Add(reader[4].ToString());
                }
                loseConnection();
                return laptopsPcs;
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        public void updatePcsLaptopsTable(string table, string name, string cpu, string gpu, string os, int price, int quantity)
        {
            createConnection();
            try
            {
                MySqlCommand updatePcsLaptops = new MySqlCommand(connString, connection);
                updatePcsLaptops.CommandText = $"UPDATE {table} SET CPU = @cpu , GPU = @gpu, OS = @os, Price = {price}, Quantity = {quantity} " +
                                         $" WHERE Name = '{name}';";
                updatePcsLaptops.Parameters.AddWithValue("@cpu", cpu);
                updatePcsLaptops.Parameters.AddWithValue("@gpu", gpu);
                updatePcsLaptops.Parameters.AddWithValue("@os", os);
                updatePcsLaptops.ExecuteNonQuery();
                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        /////////////////////////////////////////////////end pcsLaptops clothes///////////////////////////////////////////////////////////////////////////////


        ////////////////////////////////////////////////
        ///-------------HPhones PcsLaptops---------------///
        ////////////////////////////////////////////////

        public List<String> getParticularHPhones(string table, string name)
        {
            List<String> hPhones = new List<String>();
            createConnection();
            try
            {
                MySqlCommand gethPhones = new MySqlCommand(connString, connection);
                gethPhones.CommandText = $" SELECT Constaction_type, Microphone, Price, Quantity FROM {table} WHERE Name = '{name}'";
                MySqlDataReader reader = gethPhones.ExecuteReader();
                while (reader.Read())
                {
                    hPhones.Add(reader[0].ToString());
                    hPhones.Add(reader[1].ToString());
                    hPhones.Add(reader[2].ToString());
                    hPhones.Add(reader[3].ToString());
                }
                loseConnection();
                return hPhones;
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        public void updateHPhonesTable(string table, string name, string type, string mic, int price, int quantity)
        {
            createConnection();
            try
            {
                MySqlCommand updateHPhones = new MySqlCommand(connString, connection);
                updateHPhones.CommandText = $"UPDATE {table} SET Microphone = @mic , Constaction_type = @type, Price = {price}, Quantity = {quantity} " +
                                         $" WHERE Name = '{name}';";
                updateHPhones.Parameters.AddWithValue("@mic", mic);
                updateHPhones.Parameters.AddWithValue("@type", type);
                updateHPhones.ExecuteNonQuery();
                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        /////////////////////////////////////////////////end hPhones clothes///////////////////////////////////////////////////////////////////////////////


        ////////////////////////////////////////////////
        ///-------------TVS -------------------------///
        ////////////////////////////////////////////////

        public List<String> getParticularTvs(string table, string name)
        {
            List<String> tvs = new List<String>();
            createConnection();
            try
            {
                MySqlCommand getTvs = new MySqlCommand(connString, connection);
                getTvs.CommandText = $" SELECT Max_resolution, Features, Price, Quantity FROM {table} WHERE Name = '{name}'";
                MySqlDataReader reader = getTvs.ExecuteReader();
                while (reader.Read())
                {
                    tvs.Add(reader[0].ToString());
                    tvs.Add(reader[1].ToString());
                    tvs.Add(reader[2].ToString());
                    tvs.Add(reader[3].ToString());
                }
                loseConnection();
                return tvs;
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        public void updateTvsTable(string table, string name, string resolution, string features, int price, int quantity)
        {
            createConnection();
            try
            {
                MySqlCommand updateTvs = new MySqlCommand(connString, connection);
                updateTvs.CommandText = $"UPDATE {table} SET Max_resolution = @resolution , Features = @features, Price = {price}, Quantity = {quantity} " +
                                         $" WHERE Name = '{name}';";
                updateTvs.Parameters.AddWithValue("@resolution", resolution);
                updateTvs.Parameters.AddWithValue("@features", features);
                updateTvs.ExecuteNonQuery();
                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        /////////////////////////////////////////////////end tvs clothes///////////////////////////////////////////////////////////////////////////////


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///-------------USERS List---------------///
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<String> getUsersList()
        {
            List<String> users = new List<String>();
            createConnection();
            try
            {
                MySqlCommand getUsers = new MySqlCommand(connString, connection);
                getUsers.CommandText = "SELECT Login FROM Users;";
                MySqlDataReader reader = getUsers.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(reader[0].ToString());
                }
                loseConnection();
                return users;
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }

        public void forFlowUsersBook(string userLogin, ref List<String> name, ref List<String> author, ref List<int> price, ref List<int> quantity)
        {
            createConnection();
            try
            {
                MySqlCommand flowUsersBook = new MySqlCommand(connString, connection);
                flowUsersBook.CommandText = "SELECT b.Name, b.Author, b.Price, b.Quantity FROM BookPurchase b " +
                                            " JOIN Users u ON u.users_id = b.users_id " +
                                           $" WHERE u.login = '{userLogin}';";
                MySqlDataReader reader = flowUsersBook.ExecuteReader();
                while (reader.Read())
                {
                    name.Add(reader.GetString(0));
                    author.Add(reader.GetString(1));
                    price.Add(reader.GetInt32(2));
                    quantity.Add(reader.GetInt32(3));
                }
                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        public void forFlowUsersClothes(string userLogin, ref List<String> name, ref List<String> brand, ref List<String> material, ref List<String> sex,
                                        ref List<int> price, ref List<int> quantity)
        {
            createConnection();
            try
            {
                MySqlCommand forUsersClothes = new MySqlCommand(connString, connection);
                forUsersClothes.CommandText = "SELECT c.Name, c.Brand, c.Material, c.Sex, c.Price, c.Quantity FROM ClothesPurchase c " +
                                              " JOIN Users u ON u.users_id = c.users_id " +
                                             $" WHERE u.login = '{userLogin}';";
                MySqlDataReader reader = forUsersClothes.ExecuteReader();
                while (reader.Read())
                {
                    name.Add(reader.GetString(0));
                    brand.Add(reader.GetString(1));
                    material.Add(reader.GetString(2));
                    sex.Add(reader.GetString(3));
                    price.Add(reader.GetInt32(4));
                    quantity.Add(reader.GetInt32(5));
                }
                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        public void forFlowUsersLaptopsPcs(string userLogin, ref List<string> name, ref List<string> cpu, ref List<int> ram, ref List<int> hdd,
                                           ref List<int> ssd, ref List<string> gpu, ref List<String> os, ref List<int> price, ref List<int> quantity)
        {
            createConnection();
            try
            {
                MySqlCommand forUsersLaptopsPcs = new MySqlCommand(connString, connection);
                forUsersLaptopsPcs.CommandText = "SELECT l.Name, l.CPU, l.RAM, l.HDD, l.SSD, l.GPU, l.OS, l.Price, l.Quantity FROM LaptopsPcsPurchase l " +
                                                 " JOIN Users u ON u.users_id = l.users_id " +
                                                $" WHERE u.login = '{userLogin}';";
                MySqlDataReader reader = forUsersLaptopsPcs.ExecuteReader();
                while (reader.Read())
                {
                    name.Add(reader.GetString(0));
                    cpu.Add(reader.GetString(1));
                    ram.Add(reader.GetInt32(2));
                    hdd.Add(reader.GetInt32(3));
                    ssd.Add(reader.GetInt32(4));
                    gpu.Add(reader.GetString(5));
                    os.Add(reader.GetString(6));
                    price.Add(reader.GetInt32(7));
                    quantity.Add(reader.GetInt32(8));
                }
                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        public void forFlowUsersTvs(string userLogin, ref List<string> name, ref List<double> diagonal, ref List<string> resolution,
                                    ref List<string> features, ref List<int> price, ref List<int> quantity)
        {
            createConnection();
            try
            {
                MySqlCommand forUsersTvs = new MySqlCommand(connString, connection);
                forUsersTvs.CommandText = "SELECT t.Name, t.Screen_diagonal, t.Max_resolution, t.Features, t.Price, t.Quantity FROM TvsPurchase t " +
                                          " JOIN Users u ON u.users_id = t.users_id " +
                                         $" WHERE u.login = '{userLogin}';";
                MySqlDataReader reader = forUsersTvs.ExecuteReader();
                while (reader.Read())
                {
                    name.Add(reader.GetString(0));
                    diagonal.Add(reader.GetDouble(1));
                    resolution.Add(reader.GetString(2));
                    features.Add(reader.GetString(3));
                    price.Add(reader.GetInt32(4));
                    quantity.Add(reader.GetInt32(5));
                }
                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        public void forFlowUsersHeadPhones(string userLogin, ref List<String> name, ref List<String> mic, ref List<String> type,
                                         ref List<int> workingHours, ref List<int> resistance, ref List<int> price, ref List<int> quantity)
        {
            createConnection();
            try
            {
                MySqlCommand forUsersHeadPhones = new MySqlCommand(connString, connection);
                forUsersHeadPhones.CommandText = "SELECT h.Name, h.Microphone, h.Constaction_type, h.Working_hours, " +
                                                 " h.Resistance, h.Price, h.Quantity FROM HeadPhonesPurchase h " +
                                                 " JOIN Users u ON u.users_id = h.users_id " +
                                                $" WHERE u.login = '{userLogin}'";
                MySqlDataReader reader = forUsersHeadPhones.ExecuteReader();
                while (reader.Read())
                {
                    name.Add(reader.GetString(0));
                    mic.Add(reader.GetString(1));
                    type.Add(reader.GetString(2));
                    workingHours.Add(reader.GetInt32(3));
                    resistance.Add(reader.GetInt32(4));
                    price.Add(reader.GetInt32(5));
                    quantity.Add(reader.GetInt32(6));
                }
                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        public void forFlowUsersSmartWatches(string userLogin, ref List<String> name, ref List<String> compatible, ref List<String> sensors,
                                             ref List<String> resolution, ref List<int> price, ref List<int> quantity)
        {
            createConnection();
            try
            {
                MySqlCommand forUsersSmartWatches = new MySqlCommand(connString, connection);
                forUsersSmartWatches.CommandText = "SELECT s.Name, s.Compatible_OS, s.Sensors, s.Screen_resolution, " +
                                                   " s.Price, s.Quantity FROM SmartWatchesPurchase s " +
                                                   " JOIN Users u ON u.users_id = s.users_id " +
                                                  $" WHERE u.login = '{userLogin}';";
                MySqlDataReader reader = forUsersSmartWatches.ExecuteReader();
                while (reader.Read())
                {
                    name.Add(reader.GetString(0));
                    compatible.Add(reader.GetString(1));
                    sensors.Add(reader.GetString(2));
                    resolution.Add(reader.GetString(3));
                    price.Add(reader.GetInt32(4));
                    quantity.Add(reader.GetInt32(5));
                }
                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        public void forFlowUsersSmartPhones(string userLogin, ref List<String> name, ref List<int> internalMemory, ref List<int> ram, ref List<int> resolution,
                                                     ref List<int> diagonal, ref List<int> capacity, ref List<int> price, ref List<int> quantity)
        {
            createConnection();
            try
            {
                MySqlCommand forUsersSmartPhones = new MySqlCommand(connString, connection);
                forUsersSmartPhones.CommandText = "SELECT ss.Name, ss.Internal_memory, ss.RAM, ss.Resolution_main_camera, " +
                                                  " ss.Screen_diagonal, ss.Capacity, ss.Price, ss.Quantity FROM SmartPhonesPurchase ss " +
                                                  " JOIN Users u ON u.users_id = ss.users_id " +
                                                 $" WHERE u.login = '{userLogin}';";
                MySqlDataReader reader = forUsersSmartPhones.ExecuteReader();
                while (reader.Read())
                {
                    name.Add(reader.GetString(0));
                    internalMemory.Add(reader.GetInt32(1));
                    ram.Add(reader.GetInt32(2));
                    resolution.Add(reader.GetInt32(3));
                    diagonal.Add(reader.GetInt32(4));
                    capacity.Add(reader.GetInt32(5));
                    price.Add(reader.GetInt32(6));
                    quantity.Add(reader.GetInt32(7));
                }
                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }


        ////////////////////////////////////////////////////////////
        /// FOR StoreKeeper
        /////////////////////////////////////////////////////////
        public void newBookRecordOnTable(string tableName, string name, string author, int price, int quantity)
        {
            createConnection();
            try
            {
                MySqlCommand newBook = new MySqlCommand(connString, connection);
                newBook.CommandText = $"INSERT INTO {tableName} (Name, Author, Price, Quantity) VALUES " +
                                      $"('{name}', '{author}', {price}, {quantity});";
                newBook.ExecuteNonQuery();
                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        public void newClothesRecordOnTable(string tableName, string name, string brand, string material, string sex, int price, int quantity)
        {
            createConnection();
            try
            {
                MySqlCommand newClothes = new MySqlCommand(connString, connection);
                newClothes.CommandText = $"INSERT INTO {tableName} (Name, Brand, Material, Sex, Price, Quantity) VALUES " +
                                      $"('{name}', '{brand}',  '{material}', '{sex}', {price}, {quantity});";
                newClothes.ExecuteNonQuery();
                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        public void newPcsLaptopsRecordOnTable(string tableName, string name, string cpu, int ram, int ssd, string gpu, string os, int price, int quantity)
        {
            createConnection();
            try
            {
                MySqlCommand newPcsLaptops = new MySqlCommand(connString, connection);
                newPcsLaptops.CommandText = $"INSERT INTO {tableName} (Name, CPU, RAM, HDD, SSD, GPU, OS, Price, Quantity) VALUES " +
                                      $"('{name}', '{cpu}',  {ram}, 0, '{ssd}', '{gpu}', '{os}', {price}, {quantity});";
                newPcsLaptops.ExecuteNonQuery();
                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        public void newHPhonesRecordOnTable(string tableName, string name, string mic, string type, int hour, int resistance, int price, int quantity)
        {
            createConnection();
            try
            {
                MySqlCommand newHPhones = new MySqlCommand(connString, connection);
                newHPhones.CommandText = $"INSERT INTO {tableName} (Name, Microphone, Constaction_type, Working_hours, Resistance, Price, Quantity) VALUES " +
                                      $"('{name}', '{mic}', '{type}', {hour}, {resistance}, {price}, {quantity});";
                newHPhones.ExecuteNonQuery();
                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        public void newTvsRecordOnTable(string tableName, string name, double diagonal, string resolution, string features, int price, int quantity)
        {
            createConnection();
            try
            {
                MySqlCommand newTvs = new MySqlCommand(connString, connection);
                newTvs.CommandText = $"INSERT INTO {tableName} (Name, Screen_diagonal, Max_resolution, Features, Price, Quantity) VALUES " +
                                      $"('{name}', {diagonal}, '{resolution}', '{features}', {price}, {quantity});";
                newTvs.ExecuteNonQuery();
                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        ///////////////////////////////////////
        ////////for deleting//////////////////
        //////////////////////////////////////
        public List<String> getItemNames(string nameTable)
        {
            List<String> books = new List<String>();
            createConnection();
            try
            {
                MySqlCommand getBooks = new MySqlCommand(connString, connection);
                getBooks.CommandText = $"SELECT Name FROM {nameTable};";
                MySqlDataReader reader = getBooks.ExecuteReader();
                while (reader.Read())
                {
                    books.Add(reader[0].ToString());
                }
                loseConnection();
                return books;
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        public void deleteItem(string nameTable, string name)
        {
            createConnection();
            try
            {
                MySqlCommand deleteBook = new MySqlCommand(connString, connection);
                deleteBook.CommandText = $"DELETE FROM {nameTable} WHERE Name = '{name}';";
                deleteBook.ExecuteNonQuery();
                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        //////////////////////////////////////////////////////////////////
        /// For booking report
        /////////////////////////////////////////////////////////////////
        public void completeBookReport(DataGridView bookGrid, string bookPurchase)
        {
            void getDataFromBookTables(params string[] nameTable)
            {
                for (int i = 0; i < nameTable.Length; i++)
                {
                    createConnection();
                    try
                    {
                        MySqlCommand completeBook = new MySqlCommand(connString, connection);
                        completeBook.CommandText = $"SELECT Name, Author, Price, Quantity FROM {nameTable[i]}";
                        MySqlDataReader reader = completeBook.ExecuteReader();
                        while (reader.Read())
                        {
                            bookGrid.Rows.Add();
                            bookGrid["Name", bookGrid.Rows.Count - 1].Value = reader.GetString(0);
                            bookGrid["Author", bookGrid.Rows.Count - 1].Value = reader.GetString(1);
                            bookGrid["Price", bookGrid.Rows.Count - 1].Value = reader.GetInt32(2).ToString();
                            bookGrid["Quantity", bookGrid.Rows.Count - 1].Value = reader.GetInt32(3).ToString();
                        }

                        loseConnection();
                    }
                    catch (MySqlException e)
                    {
                        throw new Exception("Error executing into inster sql statement", e);
                    }
                }
            }
            if (bookPurchase == "BookPurchase")
                getDataFromBookTables(new string[] { "BookPurchase" });
            else
                getDataFromBookTables(new string[] { "Childrenbooks", "Textbooks", "Artbooks", "Notartbooks", "Comicbooks", "Foreignbooks" });
        }
        public void completeClothesReport(DataGridView clothesGrid, string clothesPurchase)
        {
            void getDataFromBookTables(params string[] nameTable)
            {
                for (int i = 0; i < nameTable.Length; i++)
                {
                    createConnection();
                    try
                    {
                        MySqlCommand completeClothes = new MySqlCommand(connString, connection);
                        completeClothes.CommandText = $"SELECT Name, Brand, Material, Sex, Price, Quantity FROM {nameTable[i]}";
                        MySqlDataReader reader = completeClothes.ExecuteReader();
                        while (reader.Read())
                        {
                            clothesGrid.Rows.Add();
                            clothesGrid["Name", clothesGrid.Rows.Count - 1].Value = reader.GetString(0);
                            clothesGrid["Brand", clothesGrid.Rows.Count - 1].Value = reader.GetString(1);
                            clothesGrid["Material", clothesGrid.Rows.Count - 1].Value = reader.GetString(2);
                            clothesGrid["Sex", clothesGrid.Rows.Count - 1].Value = reader.GetString(3);
                            clothesGrid["Price", clothesGrid.Rows.Count - 1].Value = reader.GetInt32(4).ToString();
                            clothesGrid["Quantity", clothesGrid.Rows.Count - 1].Value = reader.GetInt32(5).ToString();
                        }

                        loseConnection();
                    }
                    catch (MySqlException e)
                    {
                        throw new Exception("Error executing into inster sql statement", e);
                    }
                }
            }
            if (clothesPurchase == "ClothesPurchase")
                getDataFromBookTables(new string[] { "ClothesPurchase" });
            else
                getDataFromBookTables(new string[] { "Shoes", "Clothes", "Underwear", "Backpacks" });
        }
        public void completePcsLaptopsReport(DataGridView clothesGrid, string nameTable)
        {
            createConnection();
            try
            {
                MySqlCommand completeClothes = new MySqlCommand(connString, connection);
                completeClothes.CommandText = $"SELECT Name, CPU, RAM, HDD, SSD, GPU, OS, Price, Quantity FROM {nameTable}";
                MySqlDataReader reader = completeClothes.ExecuteReader();
                while (reader.Read())
                {
                    clothesGrid.Rows.Add();
                    clothesGrid["Name", clothesGrid.Rows.Count - 1].Value = reader.GetString(0);
                    clothesGrid["CPU", clothesGrid.Rows.Count - 1].Value = reader.GetString(1);
                    clothesGrid["RAM", clothesGrid.Rows.Count - 1].Value = reader.GetInt32(2).ToString();
                    clothesGrid["HDD", clothesGrid.Rows.Count - 1].Value = reader.GetInt32(3).ToString();
                    clothesGrid["SSD", clothesGrid.Rows.Count - 1].Value = reader.GetInt32(4).ToString();
                    clothesGrid["GPU", clothesGrid.Rows.Count - 1].Value = reader.GetString(5);
                    clothesGrid["OS", clothesGrid.Rows.Count - 1].Value = reader.GetString(6);
                    clothesGrid["Price", clothesGrid.Rows.Count - 1].Value = reader.GetInt32(7).ToString();
                    clothesGrid["Quantity", clothesGrid.Rows.Count - 1].Value = reader.GetInt32(8).ToString();
                }

                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        public void completeHPhonesReport(DataGridView hPhonesGrid, string nameTable)
        {
            createConnection();
            try
            {
                MySqlCommand completeHPhones = new MySqlCommand(connString, connection);
                completeHPhones.CommandText = $"SELECT Name, Microphone, Constaction_type, Working_hours, Resistance, Price, Quantity FROM {nameTable}";
                MySqlDataReader reader = completeHPhones.ExecuteReader();
                while (reader.Read())
                {
                    hPhonesGrid.Rows.Add();
                    hPhonesGrid["Name", hPhonesGrid.Rows.Count - 1].Value = reader.GetString(0);
                    hPhonesGrid["Microphone", hPhonesGrid.Rows.Count - 1].Value = reader.GetString(1);
                    hPhonesGrid["Constaction_type", hPhonesGrid.Rows.Count - 1].Value = reader.GetString(2);
                    hPhonesGrid["Working_hours", hPhonesGrid.Rows.Count - 1].Value = reader.GetInt32(3).ToString();
                    hPhonesGrid["Resistance", hPhonesGrid.Rows.Count - 1].Value = reader.GetInt32(4).ToString();
                    hPhonesGrid["Price", hPhonesGrid.Rows.Count - 1].Value = reader.GetInt32(5).ToString();
                    hPhonesGrid["Quantity", hPhonesGrid.Rows.Count - 1].Value = reader.GetInt32(6).ToString();
                }

                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
        public void completeTvsReport(DataGridView tvsGrid, string nameTable)
        {
            createConnection();
            try
            {
                MySqlCommand completeTvs = new MySqlCommand(connString, connection);
                completeTvs.CommandText = $"SELECT Name, Screen_diagonal, Max_resolution, Features, Price, Quantity FROM {nameTable}";
                MySqlDataReader reader = completeTvs.ExecuteReader();
                while (reader.Read())
                {
                    tvsGrid.Rows.Add();
                    tvsGrid["Name", tvsGrid.Rows.Count - 1].Value = reader.GetString(0);
                    tvsGrid["Screen_diagonal", tvsGrid.Rows.Count - 1].Value = reader.GetDouble(1).ToString();
                    tvsGrid["Max_resolution", tvsGrid.Rows.Count - 1].Value = reader.GetString(2);
                    tvsGrid["Features", tvsGrid.Rows.Count - 1].Value = reader.GetString(3);
                    tvsGrid["Price", tvsGrid.Rows.Count - 1].Value = reader.GetInt32(4).ToString();
                    tvsGrid["Quantity", tvsGrid.Rows.Count - 1].Value = reader.GetInt32(5).ToString();
                }
                loseConnection();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error executing into inster sql statement", e);
            }
        }
    }
}
