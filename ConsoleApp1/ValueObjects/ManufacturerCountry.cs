namespace patterns1
{
    class ManufacturerCountry
    {
        public int Id { get; set; }
        public string CountryName { get; set; }

        public ManufacturerCountry(int id, string name)
        {
            Id = id;
            CountryName = name;
        }

        public ManufacturerCountry()
        {
        }

        public override string ToString()
        {
            return Id + "\t" + CountryName;
        }

        public class Builder
        {
            private ManufacturerCountry country;

            public Builder()
            {
                country = new ManufacturerCountry();
            }

            public Builder AddName(string name)
            {
                country.CountryName = name;
                return this;
            }

            public ManufacturerCountry Build()
            {
                return country;
            }
        }
    }
}
