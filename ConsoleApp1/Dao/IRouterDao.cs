using System.Collections.Generic;

namespace patterns1
{

    interface IRouterDao 
    {
        void UpdateRouter(Router oldRouter, string newmac, Proxy proxy);
        void DeleteRouter(Router router, Proxy proxy);
        Router CreateRouter(string name, int company, int antennas, string mac, int country, int encryption, Proxy proxy);
        Router CreateRouter(Router routertocopy, Proxy proxy);
        Router GetById(uint Id);
        Router GetByName(string routername);
        List<Router> GetByAntennas(int amount);
        List<Router> GetByCompany(int companyid);
        List<Router> GetByCompany(string companyName);
        List<Router> GetAllRouters();
    }
}
