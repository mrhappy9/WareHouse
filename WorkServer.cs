using System;
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
        public void createInfoStringFields(string table,ref List<String> list, string subject) // fill up info into each string's block
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

            }catch(Exception ex) { throw new Exception("Error executing with sql statement", ex); }
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
            }catch(Exception ex) { throw new Exception("Error executing with sql statement", ex); }
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

            }catch(Exception ex) { throw new Exception("Error executing with sql statement", ex); }
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
            catch(Exception ex) { throw new Exception("Error executing with sql statement", ex); }
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
                                      "(@title, @brand, @material, @sex, @price, @quantity, @users_id);" ;
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
                MySqlCommand getlaptopsPcs= new MySqlCommand(connString, connection);
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


        ////////////////////////////////////////////////
        ///-------------Users List---------------///
        ////////////////////////////////////////////////
        
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
    }

}
