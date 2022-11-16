using Hashing.Authenticator;
using Hashing.Models;

namespace Hashing.App;

public class App : IApp
{
    private readonly IAuthenticator _authenticator;

    public App(IAuthenticator authenticator)
    {
        _authenticator = authenticator;
    }

    public void Run()
    {
        Console.WriteLine("Welcome to Digital Signatures and Password Hashing!\n");
        _authenticator.Register();
    }
}