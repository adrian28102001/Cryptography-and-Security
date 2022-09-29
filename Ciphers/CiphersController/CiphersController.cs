using Lab1.AffineCipher;
using Lab1.CaesarCipher;
using Lab1.CipherInterface;

namespace Lab1.Ciphers;

public class CiphersController : ICiphersController
{
    private readonly ICaesarCipher _caesarCipher;
    private readonly IAffineCipher _affineCipher;
    private readonly IEnumerable<ICipher> _ciphers;

    public CiphersController(ICaesarCipher caesar, IAffineCipher affineCipher, IEnumerable<ICipher> ciphers)
    {
        _caesarCipher = caesar;
        _ciphers = ciphers;
        _affineCipher = affineCipher;
    }

    public void RunCiphers()
    {
        const string textToEncrypt = "Adrian";

        const int keyForCaesar = 4;
        var caesarEncrypt = _caesarCipher.Encrypt(textToEncrypt, keyForCaesar);
        var caesarDecrypt = _caesarCipher.Decrypt(caesarEncrypt, keyForCaesar);
        Print(textToEncrypt, keyForCaesar.ToString(), _caesarCipher.CipherType(), caesarEncrypt, caesarDecrypt);


        const int firstAffineKey = 3;
        const int secondAffineKey = 1;
        var affineEncrypt = _affineCipher.Encrypt(textToEncrypt, firstAffineKey, secondAffineKey);
        var affineDecrypt = _affineCipher.Decrypt(affineEncrypt, firstAffineKey, secondAffineKey);
        Print(textToEncrypt, firstAffineKey +","+ secondAffineKey, _affineCipher.CipherType(), affineEncrypt,
            affineDecrypt);

        const string stringKey = "cipher";
        foreach (var cipher in _ciphers)
        {
            var encrypt = cipher.Encrypt(textToEncrypt, stringKey);
            var decrypt = cipher.Decrypt(encrypt, stringKey);
            Print(textToEncrypt, stringKey, cipher.CipherType(), encrypt, decrypt);
        }
    }

    private static void Print(string initialText, string key, string encryptionType, string encryptedText,
        string decryptedText)
    {
        Console.WriteLine($"Initial text: {initialText} ");
        Console.WriteLine($"Key: {key} ");
        Console.WriteLine($"Text encrypted for {encryptionType}: {encryptedText} ");
        Console.WriteLine($"Text decrypted for {encryptionType}: {decryptedText} ");
        Console.WriteLine("\n");
    }
}