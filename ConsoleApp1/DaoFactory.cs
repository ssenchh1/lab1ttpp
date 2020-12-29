using System;

namespace patterns1
{
    class DaoFactory : IDaoFactory
    {
        public ICompanyDao GetCompanyDao()
        {
            return new CompanyDaoImpl();
        }

        public IEncryptionDao GetEncryptionDao()
        {
            return new EncryptionDaoImpl();
        }

        public IManufacturerDao GetManufacturerDao()
        {
            return new ManufacturerDaoImpl();
        }

        public IRouterDao GetRouterDao()
        {
            return new RouterDaoImpl();
        }
    }
}
