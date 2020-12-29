using System.Collections.Generic;

namespace patterns1
{
    interface ICompanyDao
    {
        void UpdateCompany(Company company, string newName, Proxy proxy);
        void DeleteCompany(Company company, Proxy proxy);
        Company CreateCompany(string name, Proxy proxy);
        Company CreateCompany(Company company, Proxy proxy);
        Company GetByName(string companyname);
        Company GetById(int id);
        List<Company> GetAllCompanies();
    }
}
