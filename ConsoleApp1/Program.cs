using MySql.Data.MySqlClient;
using System;

namespace patterns1
{
    public interface IDao
    {

    }


    public interface IProxySubject
    {
        void Create();
        void Update();
        void Delete();
        void Get();
    }

    class RealSubject : IProxySubject
    {

        public void Create()
        {
            
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Get()
        {
            throw new NotImplementedException();
        }

        public void Request()
        {
            Console.WriteLine("RealSubj Handling request");
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }

    class Client
    {
        public int role { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Client client = new Client();
                //вход в систему
                Console.WriteLine("Log in - 1 or register - 2?");
                var input = Console.ReadLine();
                if (input == "1")
                    client = LoggingIn();
                else if (input == "2")
                {
                    Registration();
                    client.role = 1;
                }
                else
                    Environment.Exit(0);


                DaoFactory daofactory = new DaoFactory();
                var a = daofactory.GetRouterDao();

                RealSubject realSubject = new RealSubject();
                Proxy proxy = new Proxy(realSubject, client);

                //изменяем объект, а затем возвращаем предыдущее состояние
                RouterHistory routerHistory = new RouterHistory();
            
                Router router = new Router.Builder("tp link BIG", 4, 4).manufacturerContry(1).Encryption(2).macAdr("1234535312").Built();

                Console.WriteLine(router);
                routerHistory.History.Push(router.SaveState());

                Console.WriteLine();

                router.MAC_Adress = "NewMacAddres";
                Console.WriteLine(router);

                Console.WriteLine();

                router.RestoreState(routerHistory.History.Pop());
                Console.WriteLine(router);
                a.CreateRouter(router, proxy);
                a.UpdateRouter(router, "1111", proxy);


                Company company = new Company.Builder().AddName("microtk").Build();
                daofactory.GetCompanyDao().CreateCompany(company, proxy);

                ManufacturerCountry manufacturerCountry = new ManufacturerCountry.Builder().AddName("USA").Build();
                daofactory.GetManufacturerDao().CreateCountry(manufacturerCountry, proxy);
            }
            catch (Exception e)
            {
                Console.WriteLine("error" + e.Message + e.StackTrace);
            }
            finally
            {
                Connection.GetInstance().CloseConnection();
            }

            void Registration()
            {
                Console.WriteLine("Enter your login: ");
                var login = Console.ReadLine();
                Console.WriteLine("Enter your password: ");
                var password = Console.ReadLine();

                string sqlexpression = string.Format(@"INSERT INTO users (login, role_id, password) VALUES (""{0}"", ""{1}"", ""{2}"")", login, 1, password);
                using (var connection = Connection.GetInstance().GetConnection())
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                    int number = command.ExecuteNonQuery();
                    Console.WriteLine($"Added {number} elements");
                }
            }

            Client LoggingIn()
            {
                Console.WriteLine("Enter your login: ");
                var login = Console.ReadLine();
                Console.WriteLine("Enter your password: ");
                var password = Console.ReadLine();

                Client clt = null;
                string sqlexpression = String.Format(@"SELECT role_id FROM users WHERE login = ""{0}"" and password=""{1}"" limit 1", login, password);
                using (var connection = Connection.GetInstance().GetConnection())
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            clt = new Client();
                            clt.role = (int)reader.GetValue(0);
                        }
                    }
                    reader.Close();
                }
                return clt;
            }
            
        }
    }
}
