using System.Security.Cryptography;
using System.Text;
using EncryptorFactory.Domain;

namespace EncryptorFactory.Infrastructure;

public sealed class RsaEncryptor : IEncryptor
{
    private readonly RSA _rsa;

    public RsaEncryptor(RSA rsaWithKeyPair)
    {
        _rsa = rsaWithKeyPair ?? throw new ArgumentNullException(nameof(rsaWithKeyPair));
    }

    public string Encrypt(string plainText)
    {
        var bytes = Encoding.UTF8.GetBytes(plainText);
        var cipher = _rsa.Encrypt(bytes, RSAEncryptionPadding.OaepSHA256);
        return Convert.ToBase64String(cipher);
    }

    public string Decrypt(string cipherText)
    {
        var cipher = Convert.FromBase64String(cipherText);
        var plain = _rsa.Decrypt(cipher, RSAEncryptionPadding.OaepSHA256);
        return Encoding.UTF8.GetString(plain);
    }
}