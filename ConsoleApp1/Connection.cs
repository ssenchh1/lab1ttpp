using MySql.Data.MySqlClient;
using System;
using System.Security.Permissions;

namespace patterns1
{
    class Connection : IDisposable
        {
            static Connection _instance = null;
            private MySqlConnection connect  = null;

            private Connection()
            {
                connect = new MySqlConnection("Server=localhost;Database=marchdb;port=3306;User Id=root;password=root");
            }

            public static Connection GetInstance()
            {
                if (_instance == null)
                {
                    _instance = new Connection();
                    return _instance;
                }
                return _instance;
            }

            public void OpenConnection()
            {
                if (connect.State == System.Data.ConnectionState.Closed)
                    connect.Open();
            }

            public void CloseConnection()
            {
                if (connect.State == System.Data.ConnectionState.Open)
                    connect.Close();
            }

            public MySqlConnection GetConnection()
            {
                return connect;
            }

            public void Dispose()
            {
                connect.Close();
            }
        }
}
