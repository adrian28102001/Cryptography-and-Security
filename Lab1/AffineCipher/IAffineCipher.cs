namespace Lab1.AffineCipher;

public interface IAffineCipher
{
    string Encrypt(char[] message, int firstKey, int secondKey);
    string Decrypt(string cipherText, int firstKey, int secondKey);
    string CipherType();
}