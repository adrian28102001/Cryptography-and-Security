using System.Numerics;

namespace Lab1.AsymmetricCipher;

public class RsaCipher : IRsaCipher
{
    private int _d;
    private int _e;
    private readonly int _n;
    private readonly int _phi;

    public RsaCipher(int x, int y)
    {
        _n = x * y;
        _phi = (x - 1) * (y - 1);
    }

    public int Encrypt(int plainText)
    {
        for (_e = 2; _e < _phi; _e++)
        {
            if (Gcd(_e, _phi) == 1)
            {
                break;
            }
        }

        var ciphertext = (int) ((Math.Pow(plainText, _e)) % _n);
        Console.WriteLine("Encrypted message is : " + ciphertext);

        return ciphertext;
    }

    public BigInteger Decrypt(int cipherText) {
        BigInteger decryptedText;

        for (int i = 0; i <= 9; i++) {
            int x = 1 + (i * _phi);
            if (x % _e == 0) {
                _d = x / _e;
                break;
            }
        }
        BigInteger N = (_n);
        BigInteger cipher = cipherText;

        decryptedText = BigInteger.ModPow(cipher, _d, N);
        Console.Write("Decrypted message is : " + decryptedText);

        return decryptedText;
    }

    public void RunCiphers()
    {
        var encrypt = Encrypt(214);
        Decrypt(encrypt);
    }

    private static int Gcd(int e, int phi)
    {
        return e == 0 ? phi : Gcd(phi % e, e);
    }
}