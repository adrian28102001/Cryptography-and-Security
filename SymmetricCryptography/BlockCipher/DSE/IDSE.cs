using Lab1.CipherInterface;
using Symmetric_Cryptography.Interface;

namespace Symmetric_Cryptography.BlockCipher.DSE;

public interface IDSE : IRunCipher
{
    public string Encrypt(string plaintext, string key);
    public string Decrypt(string ciphertext, string key);
}