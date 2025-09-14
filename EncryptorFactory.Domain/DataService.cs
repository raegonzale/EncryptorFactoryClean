using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptorFactory.Domain;
public class DataService
{
    private readonly EncryptorCreatorFactory _creator;

    public DataService(EncryptorCreatorFactory creator)
    {
        _creator = creator;
    }
    public string Save(string plain) => _creator.Create().Encrypt(plain);
    public string Read(string cipher) => _creator.Create().Decrypt(cipher);
}
