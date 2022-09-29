namespace Lab1.CipherInterface;


public interface ICipher
{
    string CipherType();
    string Encrypt(string text, string key);
    string Decrypt(string text, string key);
}

