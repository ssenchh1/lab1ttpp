using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using Microsoft.SqlServer.Server;
using MySqlX.XDevAPI;

namespace patterns1
{
    class CompanyDaoImpl : Subject, ICompanyDao
    {
        public Company CreateCompany(string name, Proxy proxy)
        {
            Company comp = null;
            if (proxy.CheckAccess())
            {
                string sqlexpression = string.Format(@"INSERT INTO Company (CompanyName) VALUES (""{0}"")", name);
                using (var connection = Connection.GetInstance().GetConnection())
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                    int number = command.ExecuteNonQuery();
                    Console.WriteLine($"Added {number} elements");
                }
                comp = GetByName(name);
                NotifyAllObservers();
            }
            return comp;
        }

        public Company CreateCompany(Company company, Proxy proxy)
        {
            Company comp = null;
            if (proxy.CheckAccess())
            {
                string sqlexpression = string.Format(@"INSERT INTO Company (CompanyName) VALUES (""{0}"")", company.Name);
                using (var connection = Connection.GetInstance().GetConnection())
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                    int number = command.ExecuteNonQuery();
                    Console.WriteLine($"Added {number} elements");
                }
                comp = GetByName(company.Name);
                NotifyAllObservers();
            }
            return comp;
        }

        public void DeleteCompany(Company company, Proxy proxy)
        {
            if (proxy.CheckAccess())
            {
                string sqlExpression = string.Format(@"DELETE FROM Company WHERE Id = {0} AND CompanyName = ""{1}""", company.Id, company.Name);
                using (var connection = Connection.GetInstance().GetConnection())
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpression, connection);
                    var number = command.ExecuteNonQuery();
                    Console.WriteLine($"Deleted {number} rows");
                }
                NotifyAllObservers();
            }
        }

        public List<Company> GetAllCompanies()
            {
                List<Company> list = new List<Company>();
                
                string sqlexpression = "SELECT * FROM Company";
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
                            var quantity = reader.GetValues(obj);
                            list.Add(new Company(obj));
                            Console.WriteLine($"{id}\t{name}");
                        }
                    }
                    reader.Close();
                }
                return list;
            }

        public Company GetById(int id)
            {
                Company comp = null;
                string sqlexpression = String.Format("SELECT * FROM Company WHERE ID = {0}", id);
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
                            comp = new Company((int)reader.GetValue(0), (string)reader.GetValue(1));
                        }
                    }
                    reader.Close();
                }
                return comp;
            }

        public Company GetByName(string companyname)
            {
                Company comp = null;
                string sqlexpression = String.Format(@"SELECT * FROM Company WHERE CompanyName = ""{0}""", companyname);
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
                            comp = new Company((int)reader.GetValue(0), (string)reader.GetValue(1));
                        }
                    }
                    reader.Close();
                }
                return comp;
            }

        public void UpdateCompany(Company company, string newName, Proxy proxy)
            {
            if (proxy.CheckAccess())
            {
                string sqlexpression = string.Format(@"UPDATE Company SET CompanyName = ""{0}"" WHERE Id = {1}", newName, company.Id);
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
}
