using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace patterns1
{
    class EncryptionDaoImpl : Subject, IEncryptionDao
    {
        public EncryptionType CreateEncryption(string name, Proxy proxy)
            {
                EncryptionType encryption = null;
                string sqlexpression = string.Format(@"INSERT INTO encryptiontype (EncryptionName) VALUES (""{0}"")", name);
                using (var connection = Connection.GetInstance().GetConnection())
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                    int number = command.ExecuteNonQuery();
                    Console.WriteLine($"Added {number} elements");
                }
                encryption = GetByName(name);
            NotifyAllObservers();
                return encryption;
            }

        public void DeleteEncryption(EncryptionType encryption, Proxy proxy)
            {
                string sqlExpression = string.Format(@"DELETE FROM encryptiontype WHERE Id = {0} AND EncryptionName = ""{1}""", encryption.Id, encryption.EncryptionName);
                using (var connection = Connection.GetInstance().GetConnection())
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpression, connection);
                    var number = command.ExecuteNonQuery();
                    Console.WriteLine($"Deleted {number} rows");
                }
            NotifyAllObservers();
            }

        public List<EncryptionType> GetAllEncryptions()
            {
                List<EncryptionType> list = new List<EncryptionType>();

                string sqlexpression = "SELECT * FROM encryptiontype";
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
                            list.Add(new EncryptionType((int)id, (string)name));
                        }
                    }
                    reader.Close();
                }
                return list;
            }

        public EncryptionType GetById(int id)
            {
                EncryptionType encryptionType = null;
                string sqlexpression = String.Format("SELECT * FROM encryptiontype WHERE ID = {0}", id);
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
                            encryptionType = new EncryptionType((int)reader.GetValue(0), (string)reader.GetValue(1));
                        }
                    }
                    reader.Close();
                }
                return encryptionType;
            }

        public EncryptionType GetByName(string encryption)
            {
                EncryptionType encryptionType = null;
                string sqlexpression = String.Format(@"SELECT * FROM encryptiontype WHERE EncryptionName = ""{0}""", encryption);
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
                            encryptionType = new EncryptionType((int)reader.GetValue(0), (string)reader.GetValue(1));
                        }
                    }
                    reader.Close();
                }
                return encryptionType;
            }

        public void UpdateEncryption(EncryptionType encryption, string newName, Proxy proxy)
            {
                string sqlexpression = string.Format(@"UPDATE encryptiontype SET EncryptionName = ""{0}"" WHERE Id = {1}", newName, encryption.Id);
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
