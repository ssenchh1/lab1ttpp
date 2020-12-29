using System.Collections.Generic;

namespace patterns1
{
    interface IEncryptionDao 
    {
        void UpdateEncryption(EncryptionType encryption, string newName, Proxy proxy);
        void DeleteEncryption(EncryptionType encryption, Proxy proxy);
        EncryptionType CreateEncryption(string name, Proxy proxy);
        EncryptionType GetByName(string encryption);
        EncryptionType GetById(int id);
        List<EncryptionType> GetAllEncryptions();
    }
}
