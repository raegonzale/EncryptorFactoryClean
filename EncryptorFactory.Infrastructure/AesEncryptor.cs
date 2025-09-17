using System.Security.Cryptography;
using System.Text;
using EncryptorFactory.Domain;

namespace EncryptorFactory.Infrastructure;

public sealed class AesEncryptor : IEncryptor
{
    private readonly byte[] _key;
    private readonly byte[] _iv;

    public AesEncryptor(byte[] key, byte[] iv)
    {
        if (key is null || (key.Length != 16 && key.Length != 24 && key.Length != 32))
            throw new ArgumentException("AES key must be 16/24/32 bytes.", nameof(key));
        if (iv is null || iv.Length != 16)
            throw new ArgumentException("AES IV must be 16 bytes.", nameof(iv));

        _key = key;
        _iv = iv;
    }

    public string Encrypt(string plainText)
    {
        using var aes = Aes.Create();
        aes.Key = _key;
        aes.IV = _iv;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        using var enc = aes.CreateEncryptor();
        var plain = Encoding.UTF8.GetBytes(plainText);
        var cipher = enc.TransformFinalBlock(plain, 0, plain.Length);
        return Convert.ToBase64String(cipher);
    }

    public string Decrypt(string cipherText)
    {
        using var aes = Aes.Create();
        aes.Key = _key;
        aes.IV = _iv;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        using var dec = aes.CreateDecryptor();
        var cipher = Convert.FromBase64String(cipherText);
        var plain = dec.TransformFinalBlock(cipher, 0, cipher.Length);
        return Encoding.UTF8.GetString(plain);
    }
}