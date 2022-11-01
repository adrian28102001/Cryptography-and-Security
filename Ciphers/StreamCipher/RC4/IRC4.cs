using Lab1.Interface;

namespace Lab1.StreamCipher.RC4;

public interface IRC4 : IRunCipher
{
    byte[] PseudoRandomRc4(int[] sBox, byte[] messageBytes);
}