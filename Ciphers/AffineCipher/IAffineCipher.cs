namespace Lab1.AffineCipher;

public interface IAffineCipher
{
    string Encrypt(string text, int a, int b);
    string Decrypt(string cipherText, int firstKey, int secondKey);
    string CipherType();
}