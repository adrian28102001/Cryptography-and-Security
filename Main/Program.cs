
using Lab1.AffineCipher;
using Lab1.AsymmetricCipher;
using Lab1.BlockCipher.DSE;
using Lab1.CaesarCipher;
using Lab1.CipherInterface;
using Lab1.CiphersController;
using Lab1.Control;
using Lab1.PlayfairCipher;
using Lab1.StreamCipher.RC4;
using Lab1.VigenereCipher;

namespace Main;

public class Program
{
    private readonly IControlCiphers _controlCiphers;
    private readonly ICiphersController _ciphersController;
    private readonly IRsaCipher _rsaCipher;

    private Program(IControlCiphers controlCiphers, ICiphersController ciphersController)
    {
        _controlCiphers = controlCiphers;
        _ciphersController = ciphersController;
        _rsaCipher = new RsaCipher(79, 13);
    }

    public static void Main()
    {
        var ciphers = new List<ICipher>
        {
            new PlayfairCipher(),
            new VigenereCipher(),
        };
        var program = new Program(new ControlCipher(new RC4(), new DSE()),
            new CiphersController(new CaesarCipher(), new AffineCipher(), ciphers));


        program._controlCiphers.RunCiphers();
        program._ciphersController.RunCiphers();
        program._rsaCipher.RunCiphers();

    }
}