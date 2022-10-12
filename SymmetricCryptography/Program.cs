using Lab1.CiphersController;
using Symmetric_Cryptography.BlockCipher.DSE;
using Symmetric_Cryptography.Control;
using Symmetric_Cryptography.StreamCipher.RC4;

namespace Symmetric_Cryptography;

public class Program
{
    private readonly IControlCiphers _controlCiphers;

    private Program(IControlCiphers controlCiphers)
    {
        _controlCiphers = controlCiphers;
    }

    public static void Main()
    {
        var program = new Program(new ControlCipher(new RC4(), new DSE()));
        program._controlCiphers.RunCiphers();
    }
}

