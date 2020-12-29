namespace patterns1
{
    //Memento
    public class RouterMemento
    {
        public uint Id { get; private set; }
        public string Name { get; private set; }
        public int CompanyName { get; private set; }
        public int AntennaAmount { get; private set; }
        public string MAC_Adress { get; private set; }
        public int ManufacturerCountry { get; private set; }
        public int EncryptionType { get; private set; }

        public RouterMemento(uint id, string name, int compname, int ant, string mac, int manufac, int encr)
        {
            this.Id = id;
            this.Name = name;
            this.CompanyName = compname;
            this.AntennaAmount = ant;
            this.MAC_Adress = mac;
            this.ManufacturerCountry = manufac;
            this.EncryptionType = encr;
        }
    }
}
