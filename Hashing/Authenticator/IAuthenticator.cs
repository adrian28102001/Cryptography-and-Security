using Hashing.Models;

namespace Hashing.Authenticator;

public interface IAuthenticator
{
    public void Register();
    public void Login();
    public void SetDigitalSignature(User user);
    public void VerifyDigitalSignature(User user);
}