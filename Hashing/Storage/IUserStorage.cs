using Hashing.Models;

namespace Hashing.Storage;

public interface IUserStorage
{
    IList<User> GetAll();
    User? GetByName(string name);
    void Save(User entity);
}