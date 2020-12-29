using System;

namespace patterns1
{
    class Proxy : IProxySubject
    {
        private Client _client;
        private RealSubject _realSubject;

        public Proxy(RealSubject realSubject, Client client)
        {
            this._realSubject = realSubject;
            this._client = client;
        }

        public void Create()
        {
            if (this.CheckAccess())
            {
                this._realSubject.Create();

                this.LogAccess();
            }
        }

        public void Delete()
        {
            if (this.CheckAccess())
            {
                this._realSubject.Delete();

                this.LogAccess();
            }
        }

        public void Update()
        {
            if (this.CheckAccess())
            {
                this._realSubject.Update();

                this.LogAccess();
            }
        }

        public void Get()
        {
            this._realSubject.Get();
        }

        public bool CheckAccess()
        {
            // Некоторые реальные проверки должны проходить здесь.
            Console.WriteLine("Proxy: Checking access prior to firing a real request.");
            if (_client.role == 2)
                return true;
            else return false;
        }

        public void LogAccess()
        {
            Console.WriteLine("Proxy: Logging the time of request.");
        }
    } 
}
