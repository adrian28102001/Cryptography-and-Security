using Lab1.Interface;

namespace Lab1.BlockCipher.DSE;

public interface IDSE : IRunCipher
{
    public string Encrypt(string plaintext, string key);
    public string Decrypt(string ciphertext, string key);
}