namespace patterns1
{
    class Router
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public int CompanyName { get; set; }
        public int AntennaAmount { get; set; }
        public string MAC_Adress { get; set; }
        public int ManufacturerCountry { get; set; }
        public int EncryptionType { get; set; }

        public Router(uint id, string name, int compname, int antennas, string mac, int manufacturercountry, int encryption)
        {
            Id = id;
            Name = name;
            CompanyName = compname;
            AntennaAmount = antennas;
            MAC_Adress = mac;
            ManufacturerCountry = manufacturercountry;
            EncryptionType = encryption;
        }

        
        public override string ToString()
        {
            return $"Router info: Id: {Id},\n name: {Name},\n company: {CompanyName},\n antennas: {AntennaAmount},\n MAC: {MAC_Adress},\n enryption: {EncryptionType},\n made in {ManufacturerCountry}";
        }

        public class Builder
        {
            protected internal string Name;
            protected internal int CompanyName;
            protected internal int AntennaAmount;
            //must have

            internal string MAC_Adres = string.Empty;
            internal int ManufacturerCountry = 1;
            internal int EncryptionType = 1;

            public Builder(string name, int compname, int antenna)
            {
                Name = name;
                CompanyName = compname;
                AntennaAmount = antenna;
            }

            public Builder macAdr(string mac)
            {
                MAC_Adres = mac;
                return this;
            }

            public Builder manufacturerContry(int countryid)
            {
                ManufacturerCountry = countryid;
                return this;
            }

            public Builder Encryption(int encryption)
            {
                EncryptionType = encryption;
                return this;
            }

            public Router Built()
            {
                return new Router(this);
            }
        }

        private Router(Builder builder)
        {
            Name = builder.Name;
            CompanyName = builder.CompanyName;
            AntennaAmount = builder.AntennaAmount;
            MAC_Adress = builder.MAC_Adres;
            ManufacturerCountry = builder.ManufacturerCountry;
            EncryptionType = builder.EncryptionType;
        }

        //saving state
        public RouterMemento SaveState()
        {
            System.Console.WriteLine("Saving your router");
            return new RouterMemento(Id, Name, CompanyName, AntennaAmount, MAC_Adress, ManufacturerCountry, EncryptionType);
        }

        //restoring state
        public void RestoreState(RouterMemento routerMemento)
        {
            this.Id = routerMemento.Id;
            this.Name = routerMemento.Name;
            this.CompanyName = routerMemento.CompanyName;
            this.AntennaAmount = routerMemento.AntennaAmount;
            this.MAC_Adress = routerMemento.MAC_Adress;
            this.ManufacturerCountry = routerMemento.ManufacturerCountry;
            this.EncryptionType = routerMemento.EncryptionType;
        }

    }
}
