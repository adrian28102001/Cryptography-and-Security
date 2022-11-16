namespace Hashing.Encryption;

public interface IDse
{
    public string Encrypt(string plaintext);
    public string Decrypt(string ciphertext);
}