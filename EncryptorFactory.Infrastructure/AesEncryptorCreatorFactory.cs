using System.Security.Cryptography;
using EncryptorFactory.Domain;

namespace EncryptorFactory.Infrastructure;

public sealed class AesEncryptorCreatorFactory : EncryptorCreatorFactory
{
    private readonly byte[] _key;
    private readonly byte[] _iv;

    public AesEncryptorCreatorFactory()
    {
        
        using var aes = Aes.Create();
        aes.KeySize = 256;
        aes.GenerateKey();
        aes.GenerateIV();
        _key = aes.Key;
        _iv = aes.IV;
    }

    public override IEncryptor Create() => new AesEncryptor(_key, _iv);
}       