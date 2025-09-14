using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptorFactory.Domain;
public abstract class EncryptorCreatorFactory
{
    public abstract IEncryptor Create();
}