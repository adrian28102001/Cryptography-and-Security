namespace Lab1.AffineCipher;

public class AffineCipher : IAffineCipher
{
    public string Encrypt(char[] message, int firstKey, int secondKey)
    {
        var cipher = "";
        foreach (var t in message)
        {
            if (t != ' ')
            {
                cipher += (char) ((firstKey * (t - 'A') + secondKey) % 26 + 'A');
            }
            else 
            {
                cipher += t;
            }
        }

        return cipher;
    }

    public string Decrypt(string cipher, int firstKey, int secondKey)
    {
        var msg = "";
        var a_inv = 0;
        int flag;
 
        //Find a^-1 (the multiplicative inverse of a
        //in the group of integers modulo m.)
        for (var i = 0; i < 26; i++)
        {
            flag = firstKey * i % 26;
 
            // Check if (a*i)%26 == 1,
            // then i will be the multiplicative inverse of a
            if (flag == 1)
            {
                a_inv = i;
            }
        }
        foreach (var t in cipher)
        {
            if (t != ' ')
            {
                msg += (char) (a_inv *
                    (t + 'A' - secondKey) % 26 + 'A');
            }
            else //else simply append space character
            {
                msg += t;
            }
        }
 
        return msg;
    }

    public string CipherType()
    {
        return "Affine cipher";
    }
    
}