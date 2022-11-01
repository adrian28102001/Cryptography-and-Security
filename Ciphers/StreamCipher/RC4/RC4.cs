using System.Text;

namespace Lab1.StreamCipher.RC4;

public class RC4 : IRC4
{
    public void RunCipher()
    {
        Console.WriteLine("Enter Key for Password:");
        var passwordKey = Console.ReadLine();

        Console.WriteLine("Enter Message to Encrypt:");
        var plainText = Console.ReadLine();

        if (string.IsNullOrEmpty(passwordKey) || string.IsNullOrEmpty(plainText))
            return;

        var asciiKeyBytes = Encoding.ASCII.GetBytes(passwordKey);
        var sBox = Enumerable.Range(0, 256).ToArray();

        var j = 0;
        for (var i = 0; i < 256; i++)
        {
            j = (j + sBox[i] + asciiKeyBytes[i % asciiKeyBytes.Length]) % 256;
            sBox[j] = sBox[i];
            sBox[i] = j;
        }

        var encryptBytes = PseudoRandomRc4(sBox, Encoding.ASCII.GetBytes(plainText));
        Console.WriteLine("RC4 Encrypted Text: {0}", Encoding.ASCII.GetString(encryptBytes));
        var decryptedString = PseudoRandomRc4(sBox, encryptBytes);
        Console.WriteLine("RC4 Decrypted Text: {0}", Encoding.ASCII.GetString(decryptedString));
        Console.ReadLine();
    }
    public byte[] PseudoRandomRc4(int[] sBox, byte[] messageBytes)
    {
        var i = 0;
        var j = 0;
        var cnt = 0;
        var tempBox = new int[sBox.Length];
        var result = new byte[messageBytes.Length];

        Array.Copy(sBox, tempBox, tempBox.Length);

        foreach (var textByte in messageBytes)
        {
            i = (i + 1) % 256;
            j = (j + tempBox[i]) % 256;
            (tempBox[i], tempBox[j]) = (tempBox[j], tempBox[i]);
            var t = (tempBox[i] + tempBox[j]) % 256;
            var k = tempBox[t];

            var ss = textByte ^ k;
            result[cnt] = (byte) ss;
            cnt++;
        }

        return result;
    }
}