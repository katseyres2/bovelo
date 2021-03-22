using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace MyLib
{
    public static class DatabaseManager
    {
        private const string CONNECTION = "server=localhost;user=root;database=bovelo;port=3306;password=Philippe98";
        
        public static class TableBike
        {
            public static DataTable Download()
            {
                var connection = new MySqlConnection(CONNECTION);

                var tableBike = new DataTable("tableBike");
                tableBike.Columns.Add("id", typeof(int));
                tableBike.Columns.Add("model", typeof(string));
                tableBike.Columns.Add("color", typeof(string));
                tableBike.Columns.Add("size", typeof(int));
                tableBike.Columns.Add("quantity", typeof(int));
                tableBike.Columns.Add("idCustomer", typeof(int));
                tableBike.Columns.Add("creationDate", typeof(DateTime));
                tableBike.Columns.Add("assemblingdate", typeof(DateTime));
                tableBike.Columns.Add("employee", typeof(string));

                try
                {
                    connection.Open();

                    var command = new MySqlCommand("SELECT * FROM table_bike", connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                        tableBike.Rows.Add(
                            reader[0], reader[1],
                            reader[2], reader[3],
                            reader[4], reader[5],
                            reader[6], reader[7],
                            reader[8]);

                    //foreach (DataRow dataRow in tableBike.Rows)
                    //{
                    //    Console.Out.WriteLine(String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}",
                    //        dataRow["id"],
                    //        dataRow["model"],
                    //        dataRow["color"],
                    //        dataRow["size"],
                    //        dataRow["quantity"],
                    //        dataRow["creationDate"],
                    //        dataRow["idCustomer"]));
                    //}

                    reader.Close();
                }
                catch (Exception)
                {
                    throw;
                }

                return tableBike;
            }
        
            public static bool Create(string model, string color, int size, int quantity, int idCustomer, string creationDate, string assemblingDate)
            {
                var connection = new MySqlConnection(CONNECTION);

                try
                {
                    connection.Open();

                    string request = $"INSERT INTO table_bike(bike_model, bike_color, bike_size, bike_quantity, bike_idcustomer, bike_creationdate, bike_assemblingdate) VALUES('{model}', '{color}', {size}, {quantity}, {idCustomer}, '{creationDate}', '{assemblingDate}')";

                    var command = new MySqlCommand(request, connection);
                    var reader = command.ExecuteReader();

                    reader.Close();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        
            public static DataTable OrderBy(string filter)
            {
                var connection = new MySqlConnection(CONNECTION);

                var tableBike = new DataTable("tableBike");
                tableBike.Columns.Add("id", typeof(int));
                tableBike.Columns.Add("model", typeof(string));
                tableBike.Columns.Add("color", typeof(string));
                tableBike.Columns.Add("size", typeof(int));
                tableBike.Columns.Add("quantity", typeof(int));
                tableBike.Columns.Add("idCustomer", typeof(int));
                tableBike.Columns.Add("creationDate", typeof(DateTime));
                tableBike.Columns.Add("assemblingdate", typeof(DateTime));
                tableBike.Columns.Add("idemployee", typeof(int));

                try
                {
                    connection.Open();

                    var command = new MySqlCommand($"SELECT * FROM table_bike ORDER BY {filter} ASC", connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                        tableBike.Rows.Add(
                            reader[0], reader[1],
                            reader[2], reader[3],
                            reader[4], reader[5],
                            reader[6], reader[7],
                            reader[8]);

                    foreach (DataRow dataRow in tableBike.Rows)
                    {
                        Console.Out.WriteLine(String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}",
                            dataRow["id"],
                            dataRow["model"],
                            dataRow["color"],
                            dataRow["size"],
                            dataRow["quantity"],
                            dataRow["creationDate"],
                            dataRow["idCustomer"]));
                    }

                    reader.Close();
                }
                catch (Exception)
                {
                    throw;
                }

                return tableBike;

            }
        
            public static DataTable Search(string databaseField, string value)
            {
                var connection = new MySqlConnection(CONNECTION);

                var tableBike = new DataTable("tableBike");
                tableBike.Columns.Add("id", typeof(int));
                tableBike.Columns.Add("model", typeof(string));
                tableBike.Columns.Add("color", typeof(string));
                tableBike.Columns.Add("size", typeof(int));
                tableBike.Columns.Add("quantity", typeof(int));
                tableBike.Columns.Add("idCustomer", typeof(int));
                tableBike.Columns.Add("creationDate", typeof(DateTime));
                tableBike.Columns.Add("assemblingdate", typeof(DateTime));
                tableBike.Columns.Add("employee", typeof(string));

                try
                {
                    connection.Open();

                    var command = new MySqlCommand($"SELECT * FROM table_bike WHERE {databaseField}={value}", connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                        tableBike.Rows.Add(
                            reader[0], reader[1],
                            reader[2], reader[3],
                            reader[4], reader[5],
                            reader[6], reader[7],
                            reader[8]);

                    reader.Close();
                }
                catch (Exception)
                {
                    throw;
                }

                return tableBike;
            }
        
            public static bool Update(string databaseParameter, string newValue, int id)
            {
                var connection = new MySqlConnection(CONNECTION);

                try
                {
                    connection.Open();

                    Console.Out.WriteLine($"{databaseParameter}, {newValue}, {id}");

                    var command = new MySqlCommand($"UPDATE table_bike SET {databaseParameter}={newValue} WHERE id_bike={id}", connection);
                    var reader = command.ExecuteReader();

                    reader.Close();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    throw;
                }

            }
        }

        public static class TableCustomer
        {
            public static DataTable Download()
            {
                var connection = new MySqlConnection(CONNECTION);

                var tableCustomer = new DataTable("tableCustomer");
                tableCustomer.Columns.Add("id", typeof(int));
                tableCustomer.Columns.Add("firstname", typeof(string));
                tableCustomer.Columns.Add("lastname", typeof(string));
                tableCustomer.Columns.Add("email", typeof(string));
                tableCustomer.Columns.Add("phoneNumber", typeof(string));
                tableCustomer.Columns.Add("country", typeof(string));
                tableCustomer.Columns.Add("zipcode", typeof(int));
                tableCustomer.Columns.Add("city", typeof(string));
                tableCustomer.Columns.Add("street", typeof(string));
                tableCustomer.Columns.Add("houseNumber", typeof(int));

                try
                {
                    connection.Open();

                    var command = new MySqlCommand("SELECT * FROM table_customer", connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                        tableCustomer.Rows.Add(
                            reader[0], reader[1],
                            reader[2], reader[3],
                            reader[4], reader[5],
                            reader[6], reader[7],
                            reader[8], reader[9]);

                    //foreach (DataRow dataRow in tableCustomer.Rows)
                    //{
                    //    Console.Out.WriteLine(string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}",
                    //        dataRow["id"],
                    //        dataRow["firstname"],
                    //        dataRow["lastname"],
                    //        dataRow["email"],
                    //        dataRow["phoneNumber"],
                    //        dataRow["country"],
                    //        dataRow["zipcode"],
                    //        dataRow["city"],
                    //        dataRow["street"],
                    //        dataRow["houseNumber"]));

                    //}

                    reader.Close();
                }
                catch (Exception)
                {
                    throw;
                }

                return tableCustomer;
            }
        
            public static DataTable Search(string customerName)
            {
                var connection = new MySqlConnection(CONNECTION);

                var tableCustomer = new DataTable("tableCustomer");
                tableCustomer.Columns.Add("id", typeof(int));
                tableCustomer.Columns.Add("firstname", typeof(string));
                tableCustomer.Columns.Add("lastname", typeof(string));
                tableCustomer.Columns.Add("email", typeof(string));
                tableCustomer.Columns.Add("phoneNumber", typeof(string));
                tableCustomer.Columns.Add("country", typeof(string));
                tableCustomer.Columns.Add("zipcode", typeof(int));
                tableCustomer.Columns.Add("city", typeof(string));
                tableCustomer.Columns.Add("street", typeof(string));
                tableCustomer.Columns.Add("houseNumber", typeof(int));

                try
                {
                    connection.Open();

                    var command = new MySqlCommand($"SELECT * FROM table_customer WHERE customer_firstname='{customerName}'", connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                        tableCustomer.Rows.Add(
                            reader[0], reader[1],
                            reader[2], reader[3],
                            reader[4], reader[5],
                            reader[6], reader[7],
                            reader[8], reader[9]);

                    reader.Close();
                }
                catch (Exception)
                {
                    throw;
                }

                return tableCustomer;
            }
        
            public static bool Create(string firstname, string lastname, string email, string phoneNumber, string country, int zipcode, string city, string street, int houseNumber)
            {
                var connection = new MySqlConnection(CONNECTION);

                try
                {
                    connection.Open();

                    string request = $"INSERT INTO table_customer(customer_firstname, customer_lastname, customer_email, customer_phonenumber, customer_country, customer_zipcode, customer_city, customer_street, customer_housenumber) VALUES('{firstname}', '{lastname}', '{email}', '{phoneNumber}', '{country}', {zipcode}, '{city}', '{street}', {houseNumber})";

                    var command = new MySqlCommand(request, connection);
                    var reader = command.ExecuteReader();

                    reader.Close();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static class TableStockParts
        {
            public static DataTable Download()
            {
                var connection = new MySqlConnection(CONNECTION);

                var tableStockParts = new DataTable("tableStockParts");
                tableStockParts.Columns.Add("id", typeof(int));
                tableStockParts.Columns.Add("name", typeof(string));
                tableStockParts.Columns.Add("sizeModel", typeof(int));
                tableStockParts.Columns.Add("whiteStock", typeof(int));
                tableStockParts.Columns.Add("blackStock", typeof(int));
                tableStockParts.Columns.Add("purpleStock", typeof(int));
                tableStockParts.Columns.Add("noColorStock", typeof(int));
                tableStockParts.Columns.Add("unitPrice", typeof(int));

                try
                {
                    connection.Open();

                    var command = new MySqlCommand("SELECT * FROM table_stockparts", connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                        tableStockParts.Rows.Add(
                            reader[0], reader[1],
                            reader[2], reader[3],
                            reader[4], reader[5],
                            reader[6], reader[7]);

                    //foreach (DataRow dataRow in tableStockParts.Rows)
                    //{
                    //    Console.Out.WriteLine(string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}",
                    //        dataRow["id"],
                    //        dataRow["name"],
                    //        dataRow["sizeModel"],
                    //        dataRow["whiteStock"],
                    //        dataRow["blackStock"],
                    //        dataRow["noColorStock"],
                    //        dataRow["unitPrice"]));
                    //}

                    reader.Close();
                }
                catch (Exception)
                {
                    throw;
                }

                return tableStockParts;
            }

            public static DataTable Search(string partName, int size)
            {
                var connection = new MySqlConnection(CONNECTION);

                var tableStockParts = new DataTable("tableStockParts");
                tableStockParts.Columns.Add("id", typeof(int));
                tableStockParts.Columns.Add("name", typeof(string));
                tableStockParts.Columns.Add("sizeModel", typeof(string));
                tableStockParts.Columns.Add("whiteStock", typeof(string));
                tableStockParts.Columns.Add("blackStock", typeof(string));
                tableStockParts.Columns.Add("purpleStock", typeof(string));
                tableStockParts.Columns.Add("noColorStock", typeof(int));
                tableStockParts.Columns.Add("unitPrice", typeof(string));

                try
                {
                    connection.Open();

                    var command = new MySqlCommand($"SELECT * FROM table_stockparts WHERE stockparts_name='{partName}' AND stockparts_sizemodel={size}", connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                        tableStockParts.Rows.Add(
                            reader[0], reader[1],
                            reader[2], reader[3],
                            reader[4], reader[5],
                            reader[6], reader[7]);

                    reader.Close();
                }
                catch (Exception)
                {
                    throw;
                }

                return tableStockParts;
            }

            public static bool Update(string partName, int quantity, int size=1, string color="noColor")
            {
                DataTable partTable = Search(partName, size);
                if (partTable.Rows.Count == 0)
                    size = 1;
                    partTable = Search(partName, size);

                var connection = new MySqlConnection(CONNECTION);

                try
                {
                    connection.Open();

                    var request = $"UPDATE table_stockparts SET stockparts_{color}stock={Convert.ToInt32(partTable.Rows[0][$"{color}Stock"]) - quantity} WHERE stockparts_name ='{partName}' AND stockparts_sizemodel={size}";
                    var command = new MySqlCommand(request, connection);
                    var reader = command.ExecuteReader();
                    
                    reader.Close();
                }
                catch (Exception)
                {
                    throw;
                }

                return true;
            }
                
        }

        public class TableModelBike
        {
            public static DataTable Download()
            {
                var connection = new MySqlConnection(CONNECTION);

                var parts = new List<string>()
                {
                    "stand", "brakekit", "gearkit", "frame_S01",
                    "frame_S02", "reinforcedframe_S01", "reinforcedframe_S02",
                    "cranksetkit", "sprocketcassette", "reflector", "chain",
                    "mudguard_S01", "mudguard_S02", "widemudguard_S01",
                    "widemudguard_S02", "innertube", "derailleur",
                    "brakedisk", "lighting", "fork_S01", "fork_S02",
                    "handlebar", "chainring", "tire_S01", "tire_S02",
                    "widetire_S01", "widetire_S02", "luggagerack",
                    "wheel_S01", "wheel_S02", "saddle"
                };

                var tableModelBike = new DataTable("tableModelBike");

                tableModelBike.Columns.Add("id", typeof(int));
                tableModelBike.Columns.Add("name", typeof(string));
                tableModelBike.Columns.Add("size", typeof(int));

                foreach (string part in parts)
                    tableModelBike.Columns.Add(part, typeof(int));

                try
                {
                    connection.Open();

                    var command = new MySqlCommand("select * from table_modelbike", connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                        tableModelBike.Rows.Add(
                            reader[0], reader[1], reader[2], reader[3],
                            reader[4], reader[5], reader[6], reader[7],
                            reader[8], reader[9], reader[10], reader[11],
                            reader[12], reader[13], reader[14], reader[15],
                            reader[16], reader[17], reader[18], reader[19],
                            reader[20], reader[21], reader[22], reader[23],
                            reader[24], reader[25], reader[26], reader[27],
                            reader[28], reader[29], reader[30], reader[31],
                            reader[32], reader[33]);

                    //foreach (DataRow dataRow in tableModelBike.Rows)
                    //{
                    //    Console.Out.WriteLine(string.Format(
                    //        "{0},   {1},    {2},    {3},    {4},    {5},    {6},    {7},    {8},    {9},    " +
                    //        "{10},  {11},   {12},   {13},   {14},   {15},   {16},   {17},   {18},   {19},   " +
                    //        "{20},  {21},   {22},   {23},   {24},   {25},   {26},   {27},   {28},   {29},   " +
                    //        "{30},  {31},   {32},   {33}",
                    //        dataRow["id"],
                    //        dataRow["name"],
                    //        dataRow["size"],
                    //        dataRow["stand"],
                    //        dataRow["brakekit"],
                    //        dataRow["gearkit"],
                    //        dataRow["frame_S01"],
                    //        dataRow["frame_S02"],
                    //        dataRow["reinforcedframe_S01"],
                    //        dataRow["reinforcedframe_S02"],
                    //        dataRow["cranksetkit"],
                    //        dataRow["sprocketcassette"],
                    //        dataRow["reflector"],
                    //        dataRow["chain"],
                    //        dataRow["mudguard_S01"],
                    //        dataRow["mudguard_S02"],
                    //        dataRow["widemudguard_S01"],
                    //        dataRow["widemudguard_S02"],
                    //        dataRow["innertube"],
                    //        dataRow["derailleur"],
                    //        dataRow["brakedisk"],
                    //        dataRow["lighting"],
                    //        dataRow["fork_S01"],
                    //        dataRow["fork_S02"],
                    //        dataRow["handlebar"],
                    //        dataRow["chainring"],
                    //        dataRow["tire_S01"],
                    //        dataRow["tire_S02"],
                    //        dataRow["widetire_S01"],
                    //        dataRow["widetire_S02"],
                    //        dataRow["luggagerack"],
                    //        dataRow["wheel_S01"],
                    //        dataRow["wheel_S02"],
                    //        dataRow["saddle"]));
                    //}

                    reader.Close();
                }
                catch (Exception)
                {
                    throw;
                }

                return tableModelBike;
            }
        
            public static DataTable Search(string name, int size)
            {
                var connection = new MySqlConnection(CONNECTION);

                var parts = new List<string>()
                {
                    "stand", "brakekit", "gearkit", "frame_S01",
                    "frame_S02", "reinforcedframe_S01", "reinforcedframe_S02",
                    "cranksetkit", "sprocketcassette", "reflector", "chain",
                    "mudguard_S01", "mudguard_S02", "widemudguard_S01",
                    "widemudguard_S02", "innertube", "derailleur",
                    "brakedisk", "lighting", "fork_S01", "fork_S02",
                    "handlebar", "chainring", "tire_S01", "tire_S02",
                    "widetire_S01", "widetire_S02", "luggagerack",
                    "wheel_S01", "wheel_S02", "saddle"
                };

                var tableModelBike = new DataTable("tableModelBike");

                tableModelBike.Columns.Add("id", typeof(int));
                tableModelBike.Columns.Add("name", typeof(string));
                tableModelBike.Columns.Add("size", typeof(int));

                foreach (string part in parts)
                    tableModelBike.Columns.Add(part, typeof(int));

                try
                {
                    connection.Open();

                    var command = new MySqlCommand($"SELECT * FROM table_modelbike WHERE modelbike_name='{name}' AND modelbike_size='{size}'", connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                        tableModelBike.Rows.Add(
                            reader[0], reader[1], reader[2], reader[3],
                            reader[4], reader[5], reader[6], reader[7],
                            reader[8], reader[9], reader[10], reader[11],
                            reader[12], reader[13], reader[14], reader[15],
                            reader[16], reader[17], reader[18], reader[19],
                            reader[20], reader[21], reader[22], reader[23],
                            reader[24], reader[25], reader[26], reader[27],
                            reader[28], reader[29], reader[30], reader[31],
                            reader[32], reader[33]);

                    //foreach (DataRow dataRow in tableModelBike.Rows)
                    //{
                    //    Console.Out.WriteLine(string.Format(
                    //        "{0},   {1},    {2},    {3},    {4},    {5},    {6},    {7},    {8},    {9},    " +
                    //        "{10},  {11},   {12},   {13},   {14},   {15},   {16},   {17},   {18},   {19},   " +
                    //        "{20},  {21},   {22},   {23},   {24},   {25},   {26},   {27},   {28},   {29},   " +
                    //        "{30},  {31},   {32},   {33}",
                    //        dataRow["id"],
                    //        dataRow["name"],
                    //        dataRow["size"],
                    //        dataRow["stand"],
                    //        dataRow["brakekit"],
                    //        dataRow["gearkit"],
                    //        dataRow["frame_S01"],
                    //        dataRow["frame_S02"],
                    //        dataRow["reinforcedframe_S01"],
                    //        dataRow["reinforcedframe_S02"],
                    //        dataRow["cranksetkit"],
                    //        dataRow["sprocketcassette"],
                    //        dataRow["reflector"],
                    //        dataRow["chain"],
                    //        dataRow["mudguard_S01"],
                    //        dataRow["mudguard_S02"],
                    //        dataRow["widemudguard_S01"],
                    //        dataRow["widemudguard_S02"],
                    //        dataRow["innertube"],
                    //        dataRow["derailleur"],
                    //        dataRow["brakedisk"],
                    //        dataRow["lighting"],
                    //        dataRow["fork_S01"],
                    //        dataRow["fork_S02"],
                    //        dataRow["handlebar"],
                    //        dataRow["chainring"],
                    //        dataRow["tire_S01"],
                    //        dataRow["tire_S02"],
                    //        dataRow["widetire_S01"],
                    //        dataRow["widetire_S02"],
                    //        dataRow["luggagerack"],
                    //        dataRow["wheel_S01"],
                    //        dataRow["wheel_S02"],
                    //        dataRow["saddle"]));
                    //}

                    reader.Close();
                }
                catch (Exception)
                {
                    throw;
                }

                return tableModelBike;
            }
        }

        public class TableEmployee
        {
            public static DataTable Download()
            {
                var connection = new MySqlConnection(CONNECTION);

                var tableEmployee = new DataTable("tableEmployee");
                tableEmployee.Columns.Add("id", typeof(int));
                tableEmployee.Columns.Add("firstname", typeof(string));
                tableEmployee.Columns.Add("lastname", typeof(string));
                tableEmployee.Columns.Add("status", typeof(string));

                try
                {
                    connection.Open();

                    var command = new MySqlCommand("SELECT * FROM table_employee", connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                        tableEmployee.Rows.Add(
                            reader[0], reader[1],
                            reader[2], reader[3]);

                    reader.Close();
                }
                catch (Exception)
                {
                    throw;
                }

                return tableEmployee;
            }
        
            public static DataTable Search(string databaseParameter, string value)
            {
                var connection = new MySqlConnection(CONNECTION);

                var tableEmployee = new DataTable("tableEmployee");
                tableEmployee.Columns.Add("id", typeof(int));
                tableEmployee.Columns.Add("firstname", typeof(string));
                tableEmployee.Columns.Add("lastname", typeof(string));
                tableEmployee.Columns.Add("status", typeof(string));

                try
                {
                    connection.Open();

                    var command = new MySqlCommand($"SELECT * FROM table_employee WHERE {databaseParameter}={value}", connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                        tableEmployee.Rows.Add(
                            reader[0], reader[1],
                            reader[2], reader[3]);

                    reader.Close();
                }
                catch (Exception)
                {
                    throw;
                }

                return tableEmployee;
            }
        }
    }
}
