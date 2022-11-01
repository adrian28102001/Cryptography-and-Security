using System.Numerics;

namespace Lab1.AsymmetricCipher;

public interface IRsaCipher
{
    int Encrypt(int plainText);
    BigInteger Decrypt(int cipherText);
    void RunCiphers();
}