using System.Collections.Generic;

namespace patterns1
{
    interface IManufacturerDao 
    {
        void UpdateCountry(ManufacturerCountry manufacturerCountry, string newName, Proxy proxy);
        void DeleteCountry(ManufacturerCountry country, Proxy proxy);
        ManufacturerCountry CreateCountry(string name, Proxy proxy);
        ManufacturerCountry CreateCountry(ManufacturerCountry manufacturer, Proxy proxy);
        ManufacturerCountry GetByName(string countryname);
        ManufacturerCountry GetById(int id);
        List<ManufacturerCountry> GetAllCountries();
    }
}
