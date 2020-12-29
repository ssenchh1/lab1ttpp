using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace patterns1
{
    class RouterDaoImpl : Subject, IRouterDao
    {
        
        public Router CreateRouter(Router routertocopy, Proxy proxy)
        {
            Router router = null;
            string sqlexpression = string.Format(@"INSERT INTO router (name, CompanyName, AntennaAmount, MAC_Adres, ManufacturerCountry, EncriptionType) VALUES (""{0}"", {1}, {2}, ""{3}"", {4}, {5})", routertocopy.Name, routertocopy.CompanyName, routertocopy.AntennaAmount, routertocopy.MAC_Adress, routertocopy.ManufacturerCountry, routertocopy.EncryptionType);
            using (var connection = Connection.GetInstance().GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                int number = command.ExecuteNonQuery();
            }
            router = GetByName(routertocopy.Name);
            NotifyAllObservers();
            return router;
        }

        public Router CreateRouter(string name, int company, int antennas, string mac, int country, int encryption, Proxy proxy)
        {
            Router router = null;
            string sqlexpression = string.Format(@"INSERT INTO router (name, CompanyName, AntennaAmount, MAC_Adres, ManufacturerCountry, EncriptionType) VALUES (""{0}"", {1}, {2}, ""{3}"", {4}, {5})", name, company, antennas, mac, country, encryption);
            using (var connection = Connection.GetInstance().GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                int number = command.ExecuteNonQuery();
            }
            router = GetByName(name);
            NotifyAllObservers();
            return router;
        }

        public void DeleteRouter(Router router, Proxy proxy)
        {
            string sqlExpression = string.Format(@"DELETE FROM router WHERE Id = {0} AND CountryName = ""{1}""", router.Id, router.Name);
            using (var connection = Connection.GetInstance().GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlExpression, connection);
                var number = command.ExecuteNonQuery();
                Console.WriteLine($"Deleted {number} rows");
            }
            NotifyAllObservers();
        }

        public List<Router> GetAllRouters()
        {
            List<Router> list = new List<Router>();

            string sqlexpression = "SELECT * FROM router";
            using (var connection = Connection.GetInstance().GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine($"{reader.GetName(6)}\t{reader.GetName(0)}\t{reader.GetName(1)}\t{reader.GetName(2)}\t{reader.GetName(3)}\t{reader.GetName(5)}\t{reader.GetName(4)}");
                    while (reader.Read())
                    {
                        object id = reader.GetValue(6);
                        object name = reader.GetValue(0);
                        object companyname = reader.GetValue(1);
                        object antennaamount = reader.GetValue(2);
                        object mac = reader.GetValue(3);
                        object manufacturercountry = reader.GetValue(4);
                        object encryption = reader.GetValue(5);
                        list.Add(new Router((uint)id, (string)name, (int)companyname, (int)antennaamount, (string) mac, (int)manufacturercountry, (int)encryption));
                    }
                }
                reader.Close();
            }
            return list;
        }

        public List<Router> GetByAntennas(int amount)
        {
            List<Router> list = new List<Router>();

            string sqlexpression =string.Format("SELECT * FROM router WHERE AntennaAmount = {0}", amount);
            using (var connection = Connection.GetInstance().GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine($"{reader.GetName(6)}\t{reader.GetName(0)}\t{reader.GetName(1)}\t{reader.GetName(2)}\t{reader.GetName(3)}\t{reader.GetName(5)}\t{reader.GetName(4)}");
                    while (reader.Read())
                    {
                        object id = reader.GetValue(6);
                        object name = reader.GetValue(0);
                        object companyname = reader.GetValue(1);
                        object antennaamount = reader.GetValue(2);
                        object mac = reader.GetValue(3);
                        object manufacturercountry = reader.GetValue(4);
                        object encryption = reader.GetValue(5);
                        list.Add(new Router((uint)id, (string)name, (int)companyname, (int)antennaamount, (string)mac, (int)manufacturercountry, (int)encryption));
                    }
                }
                reader.Close();
            }
            return list;
        }

        public List<Router> GetByCompany(int companyid)
        {
            List<Router> list = new List<Router>();

            string sqlexpression = string.Format("SELECT * FROM router WHERE CompanyName = {0}", companyid);
            using (var connection = Connection.GetInstance().GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine($"{reader.GetName(6)}\t{reader.GetName(0)}\t{reader.GetName(1)}\t{reader.GetName(2)}\t{reader.GetName(3)}\t{reader.GetName(5)}\t{reader.GetName(4)}");
                    while (reader.Read())
                    {
                        object id = reader.GetValue(6);
                        object name = reader.GetValue(0);
                        object companyname = reader.GetValue(1);
                        object antennaamount = reader.GetValue(2);
                        object mac = reader.GetValue(3);
                        object manufacturercountry = reader.GetValue(4);
                        object encryption = reader.GetValue(5);
                        list.Add(new Router((uint)id, (string)name, (int)companyname, (int)antennaamount, (string)mac, (int)manufacturercountry, (int)encryption));
                    }
                }
                reader.Close();
            }
            return list;
        }

        public List<Router> GetByCompany(string companyName)
        {
            List<Router> list = new List<Router>();

            string sqlexpression = string.Format(@"SELECT r.name, r.CompanyName, r.AntennaAmount, r.MAC_Adres, r.ManufacturerCountry, r.EncriptionType, r.Id 
                                                 FROM `router` r
                                                 inner join `company` c on c.Id = r.CompanyName
                                                 WHERE c.CompanyName = ""{0}"" ", companyName);
            using (var connection = Connection.GetInstance().GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine($"{reader.GetName(6)}\t{reader.GetName(0)}\t{reader.GetName(1)}\t{reader.GetName(2)}\t{reader.GetName(3)}\t{reader.GetName(5)}\t{reader.GetName(4)}");
                    while (reader.Read())
                    {
                        object id = reader.GetValue(6);
                        object name = reader.GetValue(0);
                        object companyname = reader.GetValue(1);
                        object antennaamount = reader.GetValue(2);
                        object mac = reader.GetValue(3);
                        object manufacturercountry = reader.GetValue(4);
                        object encryption = reader.GetValue(5);
                        list.Add(new Router((uint)id, (string)name, (int)companyname, (int)antennaamount, (string)mac, (int)manufacturercountry, (int)encryption));
                    }
                }
                reader.Close();
            }
            return list;
        }

        public Router GetById(uint id)
        {
            Router router = null;
            string sqlexpression = String.Format("SELECT * FROM router WHERE ID = {0}", id);
            using (var connection = Connection.GetInstance().GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        object Id = reader.GetValue(6);
                        object name = reader.GetValue(0);
                        object companyname = reader.GetValue(1);
                        object antennaamount = reader.GetValue(2);
                        object mac = reader.GetValue(3);
                        object manufacturercountry = reader.GetValue(4);
                        object encryption = reader.GetValue(5);
                        router = new Router((uint)Id, (string)name, (int)companyname, (int)antennaamount, (string)mac, (int)manufacturercountry, (int)encryption);
                    }
                }
                reader.Close();
            }
            return router;
        }

        public Router GetByName(string routername)
        {
            Router router = null;
            string sqlexpression = String.Format(@"SELECT * FROM router WHERE name = ""{0}""", routername);
            using (var connection = Connection.GetInstance().GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        object Id = reader.GetValue(6);
                        object name = reader.GetValue(0);
                        object companyname = reader.GetValue(1);
                        object antennaamount = reader.GetValue(2);
                        object mac = reader.GetValue(3);
                        object manufacturercountry = reader.GetValue(4);
                        object encryption = reader.GetValue(5);
                        router = new Router((uint)Id, (string)name, (int)companyname, (int)antennaamount, (string)mac, (int)manufacturercountry, (int)encryption);
                    }
                }
                reader.Close();
            }
            return router;
        }

        public void UpdateRouter(Router oldRouter, string newmac, Proxy proxy)
        {
            string sqlexpression = string.Format(@"UPDATE router SET MAC_Adres = ""{0}"" WHERE Id = {1}", newmac, oldRouter.Id);
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
