using System.Security.Cryptography;
using EncryptorFactory.Domain;

namespace EncryptorFactory.Infrastructure;
public sealed class RsaEncryptorCreatorFactory : EncryptorCreatorFactory, IDisposable
{
    private readonly RSA _rsa;

    public RsaEncryptorCreatorFactory()
    {
        _rsa = RSA.Create(2048);
    }

    public override IEncryptor Create() => new RsaEncryptor(_rsa);

    public void Dispose() => _rsa?.Dispose();
}