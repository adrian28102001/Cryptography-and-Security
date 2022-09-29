using Lab1.CipherInterface;

namespace Lab1.VigenereCipher;

public class VigenereCipher : ICipher
{
    private static int Mod(int a, int b)
    {
        return (a % b + b) % b;
    }

    private static string Cipher(string input, string key, bool encipher)
    {
        if (key.Any(t => !char.IsLetter(t)))
        {
            return null;
        }

        var output = string.Empty;
        var nonAlphaCharCount = 0;

        for (var i = 0; i < input.Length; ++i)
        {
            if (char.IsLetter(input[i]))
            {
                var cIsUpper = char.IsUpper(input[i]);
                var offset = cIsUpper ? 'A' : 'a';
                var keyIndex = (i - nonAlphaCharCount) % key.Length;
                var k = (cIsUpper ? char.ToUpper(key[keyIndex]) : char.ToLower(key[keyIndex])) - offset;
                k = encipher ? k : -k;
                var ch = (char) ((Mod(((input[i] + k) - offset), 26)) + offset);
                output += ch;
            }
            else
            {
                output += input[i];
                ++nonAlphaCharCount;
            }
        }

        return output;
    }

    public string CipherType()
    {
        return "Vigenere cipher";
    }

    public string Encrypt(string input, string key)
    {
        return Cipher(input, key, true);
    }

    public string Decrypt(string input, string key)
    {
        return Cipher(input, key, false);
    }
}