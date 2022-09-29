namespace Lab1.AffineCipher;

public class AffineCipher : IAffineCipher
{
    public string Encrypt(string text, int a, int b)
    {
        var ciphertext = "";
        var chars = text.ToUpper().ToCharArray();

        foreach(var c in chars)
        {
            var x = Convert.ToInt32(c - 65);
            ciphertext += Convert.ToChar(((a * x + b) % 26) + 65);
        }
        return ciphertext;
    }

    public string Decrypt(string text, int a, int b)
    {
        var plaintext = "";

        var aInvers = MultiplicativeInverse(a);

        var chars = text.ToUpper().ToCharArray();

        foreach(var c in chars)
        {
            var x = Convert.ToInt32(c - 65);
            if (x - b < 0)
            {
                x += Convert.ToInt32(x) + 26;
            }
            plaintext += Convert.ToChar(((aInvers * (x - b)) % 26) + 65);
        }
        return plaintext;
    }

    private static int MultiplicativeInverse(int a)
    {
        for (var i = 1; i < 27; i++)
        {
            if ((a * i) % 26 == 1)
            {
                return i;
            }
        }
        throw new Exception("No Multiplicative Inverse Found");
    }


    public string CipherType()
    {
        return "Affine cipher";
    }
    
}