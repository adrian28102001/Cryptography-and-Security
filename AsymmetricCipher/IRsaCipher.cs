using System.Numerics;

namespace AsymmetricCipher;

public interface IRsaCipher
{
    int Encrypt(int plainText);
    BigInteger Decrypt(int cipherText);
    void RunCiphers();
}