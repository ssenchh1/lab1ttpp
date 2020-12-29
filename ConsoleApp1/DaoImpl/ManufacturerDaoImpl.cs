using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace patterns1
{
    class ManufacturerDaoImpl : Subject, IManufacturerDao
    {
        public ManufacturerCountry CreateCountry(string name, Proxy proxy)
            {
                ManufacturerCountry country = null;
                string sqlexpression = string.Format(@"INSERT INTO manufacturercountry (CountryName) VALUES (""{0}"")", name);
                using (var connection = Connection.GetInstance().GetConnection())
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                    int number = command.ExecuteNonQuery();
                    Console.WriteLine($"Added {number} elements");
                }
                country = GetByName(name);
            NotifyAllObservers();
                return country;
            }

        public ManufacturerCountry CreateCountry(ManufacturerCountry manufacturer, Proxy proxy)
        {
            ManufacturerCountry country = null;
            string sqlexpression = string.Format(@"INSERT INTO manufacturercountry (CountryName) VALUES (""{0}"")", manufacturer.CountryName);
            using (var connection = Connection.GetInstance().GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                int number = command.ExecuteNonQuery();
                Console.WriteLine($"Added {number} elements");
            }
            country = GetByName(manufacturer.CountryName);
            NotifyAllObservers();
            return country;
        }

        public void DeleteCountry(ManufacturerCountry country, Proxy proxy)
            {
                string sqlExpression = string.Format(@"DELETE FROM manufacturercountry WHERE Id = {0} AND CountryName = ""{1}""", country.Id, country.CountryName);
                using (var connection = Connection.GetInstance().GetConnection())
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpression, connection);
                    var number = command.ExecuteNonQuery();
                    Console.WriteLine($"Deleted {number} rows");
                }
            NotifyAllObservers();
            }

        public List<ManufacturerCountry> GetAllCountries()
            {
                List<ManufacturerCountry> list = new List<ManufacturerCountry>();

                string sqlexpression = "SELECT * FROM manufacturercountry";
                using (var connection = Connection.GetInstance().GetConnection())
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                    var reader = command.ExecuteReader();
                    object[] obj = new object[reader.FieldCount];
                    if (reader.HasRows)
                    {
                        Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(1)}");
                        while (reader.Read())
                        {
                            object id = reader.GetValue(0);
                            object name = reader.GetValue(1);
                            list.Add(new ManufacturerCountry((int)id, (string)name));
                        }
                    }
                    reader.Close();
                }
                return list;
            }

        public ManufacturerCountry GetById(int id)
            {
                ManufacturerCountry country = null;
                string sqlexpression = String.Format("SELECT * FROM manufacturercountry WHERE ID = {0}", id);
                using (var connection = Connection.GetInstance().GetConnection())
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(1)}");
                        while (reader.Read())
                        {
                            country = new ManufacturerCountry((int)reader.GetValue(0), (string)reader.GetValue(1));
                        }
                    }
                    reader.Close();
                }
                return country;
            }

        public ManufacturerCountry GetByName(string countryname)
            {
                ManufacturerCountry country = null;
                string sqlexpression = String.Format(@"SELECT * FROM manufacturercountry WHERE CountryName = ""{0}""", countryname);
                using (var connection = Connection.GetInstance().GetConnection())
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(1)}");
                        while (reader.Read())
                        {
                            country = new ManufacturerCountry((int)reader.GetValue(0), (string)reader.GetValue(1));
                        }
                    }
                    reader.Close();
                }
                return country;
            }

        public void UpdateCountry(ManufacturerCountry manufacturerCountry, string newName, Proxy proxy)
        {
            string sqlexpression = string.Format(@"UPDATE manufacturercountry SET CountryName = ""{0}"" WHERE Id = {1}", newName, manufacturerCountry.Id);
            using (var connection = Connection.GetInstance().GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                var number = command.ExecuteNonQuery();
                Console.WriteLine($"{number} rows was updated");
            }
            NotifyAllObservers();
        }
    }
}
