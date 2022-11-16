using Hashing.App;
using Hashing.Encryption;
using Hashing.Helpers;
using Hashing.Models;
using Hashing.Storage;

namespace Hashing;

public class Program
{
    private readonly IApp _app;

    public Program(IApp app)
    {
        _app = app;
    }
    
    public static void Main(string[] args)
    {
        var program = new Program(new App.App(new Authenticator.Authenticator(new PasswordHasher(16, 20),
            new UserStorage(), new Dse("adrian"))));
        program._app.Run();
    }
}