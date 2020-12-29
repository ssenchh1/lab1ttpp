namespace patterns1
{
    class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Company()
        {
        }

        public Company(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Company(object[] company)
        {
            Id = (int)company[0];
            Name = (string)company[1];
        }

        public override string ToString()
        {
           return Id + "\t" + Name;
        }

        public class Builder
        {
            private Company newcompany;

            public Builder()
            {
                newcompany = new Company();
            }

            public Builder AddName(string name)
            {
                newcompany.Name = name;
                return this;
            }

            public Company Build()
            {
                return newcompany;
            }
        }
    }
}
