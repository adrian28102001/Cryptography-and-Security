using Hashing.Models;
using Hashing.Storage.Generic;

namespace Hashing.Storage;

public class UserStorage : IUserStorage
{
    private readonly IStorage<User> _storage;

    public UserStorage()
    {
        _storage = new Storage<User>();
    }

    public IList<User> GetAll()
    {
        return _storage.GetAll();
    }
    
    public User? GetByName(string name)
    {
        return _storage.GetByName(name);
    }
    
    public void Save(User entity)
    {
        _storage.Save(entity);
    }
}