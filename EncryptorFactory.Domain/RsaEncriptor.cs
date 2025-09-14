using System.Security.Cryptography;
using System.Text;

namespace EncryptorFactory.Domain;

public sealed class RsaEncriptor : IEncryptor
{
    private readonly RSA _rsa;

    public RsaEncriptor(RSA rsaWithKeyPair)
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