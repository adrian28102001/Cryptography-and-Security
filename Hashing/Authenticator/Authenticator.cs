using Hashing.Encryption;
using Hashing.Helpers;
using Hashing.Models;
using Hashing.Storage;

namespace Hashing.Authenticator;

public class Authenticator : IAuthenticator
{
    private readonly PasswordHasher _passwordHasher;
    private readonly IUserStorage _userStorage;
    private readonly IDse _dse;

    public Authenticator(PasswordHasher passwordHasher, IUserStorage userStorage, IDse dse)
    {
        _passwordHasher = passwordHasher;
        _userStorage = userStorage;
        _dse = dse;
    }

    public void Register()
    {
        Console.Write("Enter a username to register: ");
        var username = Console.ReadLine();

        Console.Write("Enter a password to register: ");
        var password = Console.ReadLine();

        if (password != null)
        {
            var hash = _passwordHasher.Hash(password);

            var user = new User
            {
                Id = IdGenerator.GenerateId(),
                UserName = username,
                Password = hash,
                Message = ""
            };

            var result = _passwordHasher.Verify(password, user.Password);
            Console.WriteLine($"Hashed: {user.Password}");
            Console.WriteLine($"The password is: {(result ? "" : "not")} valid");

            _userStorage.Save(user);

            if (result)
            {
                Console.WriteLine("Registration successful, let's login");
                Login();
            }
        }

        var users = _userStorage.GetAll();
        foreach (var u in users)
        {
            u.GetDetails();
        }
    }

    public void Login()
    {
        Console.Write("Enter a username to login: ");
        var username = Console.ReadLine();

        if (username == null)
        {
            Console.WriteLine("The username you entered do not exist");
            Register();
        }

        var user = _userStorage.GetByName(username);
        if (user == null)
        {
            Console.WriteLine($"User with username {username} doesn't exists.");
            Register();
        }

        Console.Write("Enter a password login: ");
        var password = Console.ReadLine();

        var result = _passwordHasher.Verify(password!, user.Password);
        Console.WriteLine($"Hash: {user.Password}");
        Console.WriteLine($"The password is: {(result ? "" : "not")} valid");
        Console.WriteLine($"Authentication {(result ? "successful" : "failed")}!");

        if (result)
        {
            SetDigitalSignature(user);
        }
        else
        {
            Console.WriteLine("You have entered wrong credential, you can do better, login again");
            Login();
        }
    }

    public void SetDigitalSignature(User user)
    {
        Console.Write("Enter a message: ");
        var message = Console.ReadLine();

        if (message == null)
        {
            return;
        }

        var hash = _passwordHasher.Hash(message);

        var encryptedHash = _dse.Encrypt(hash);
        user.Message = encryptedHash;

        VerifyDigitalSignature(user);
    }

    public void VerifyDigitalSignature(User user)
    {
        Console.Write("Enter the message you have set already: ");
        var message = Console.ReadLine();

        var decryptedHash = _dse.Decrypt(user.Message);

        // Verify
        var result = _passwordHasher.Verify(message, decryptedHash);
        Console.WriteLine($"Hash: {user.Message}");
        Console.WriteLine($"The message is: {(result ? "" : "not")} valid");
        Console.WriteLine($"Digital signature check {(result ? "successful" : "failed")}!");

        if (result) return;

        Console.WriteLine("You have entered wrong message, try again");
        VerifyDigitalSignature(user);
    }
}