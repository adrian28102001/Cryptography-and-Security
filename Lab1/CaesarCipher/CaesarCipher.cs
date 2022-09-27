namespace Lab1.CaesarCipher;

public class CaesarCipher : ICaesarCipher
{
    private static char Cipher(char ch, int key)
    {
        if (!char.IsLetter(ch))
            return ch;

        var offset = char.IsUpper(ch) ? 'A' : 'a';
        return (char) ((((ch + key) - offset) % 26) + offset);
    }

    public string CipherType()
    {
        return "Caesar cipher";
    }

    public string Encrypt(string input, int key)
    {
        var output = string.Empty;

        foreach (var ch in input)
        {
            output += Cipher(ch, key);
        }

        return output;
    }

    public string Decrypt(string input, int key)
    {
        return Encrypt(input, 26 - key);
    }
    
}