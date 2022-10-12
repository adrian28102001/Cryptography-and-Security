using Lab1.CipherInterface;
using Symmetric_Cryptography.Interface;

namespace Symmetric_Cryptography.StreamCipher.RC4;

public interface IRC4 : IRunCipher
{
    byte[] PseudoRandomRc4(int[] sBox, byte[] messageBytes);
}