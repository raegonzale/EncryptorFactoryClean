using System.Security.Cryptography;

namespace EncryptorFactory.Domain;

public sealed class RsaEncriptorCreatorFactory : EncryptorCreatorFactory, IDisposable
{
    private readonly RSA _rsa;

    public RsaEncriptorCreatorFactory()
    {
        _rsa = RSA.Create(2048);
    }

    public override IEncryptor Create() => new RsaEncriptor(_rsa);

    public void Dispose() => _rsa?.Dispose();
}