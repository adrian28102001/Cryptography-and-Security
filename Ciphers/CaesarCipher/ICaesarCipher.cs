namespace Lab1.CaesarCipher;

public interface ICaesarCipher
{
    string CipherType();
    string Encrypt(string text, int key);
    string Decrypt(string text, int key);
}