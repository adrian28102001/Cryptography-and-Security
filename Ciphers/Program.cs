using Lab1.CipherInterface;
using Lab1.CiphersController;

namespace Lab1;

public class Program
{
    private readonly ICiphersController _ciphersController;

    private Program(ICiphersController ciphersController)
    {
        _ciphersController = ciphersController;
    }

    public static void Main()
    {
        var ciphers = new List<ICipher>
        {
            new PlayfairCipher.PlayfairCipher(),
            new VigenereCipher.VigenereCipher(),
        };

        var program =
            new Program(
                new CiphersController.CiphersController(new CaesarCipher.CaesarCipher(), new AffineCipher.AffineCipher(), ciphers));
        
        program._ciphersController.RunCiphers();
    }
}