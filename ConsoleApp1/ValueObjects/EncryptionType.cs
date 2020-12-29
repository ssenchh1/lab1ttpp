namespace patterns1
{
    class EncryptionType
    {
        public int Id { get; set; }
        public string EncryptionName { get; set; }

        public EncryptionType()
        {
        }

        public EncryptionType(int id, string name)
        {
            Id = id;
            EncryptionName = name;
        }

        public override string ToString()
        {
            return Id + "\t" + EncryptionName;
        }

        public class Builder
        {
            private EncryptionType Encryption;

            public Builder()
            {
                Encryption = new EncryptionType();
            }

            public Builder AddName(string name)
            {
                Encryption.EncryptionName = name;
                return this;
            }

            public EncryptionType Build()
            {
                return Encryption;
            }
        }
    }
}
