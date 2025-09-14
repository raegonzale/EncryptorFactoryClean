using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptorFactory.Domain;
public interface IEncryptor
{
    string Encrypt(string plainText);
    string Decrypt(string cipherText);
}
