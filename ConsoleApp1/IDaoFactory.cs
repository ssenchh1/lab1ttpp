namespace patterns1
{
    interface IDaoFactory
    {
        ICompanyDao GetCompanyDao();
        IManufacturerDao GetManufacturerDao();
        IEncryptionDao GetEncryptionDao();
        IRouterDao GetRouterDao();
    }
}
