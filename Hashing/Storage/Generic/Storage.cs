using Hashing.Models;

namespace Hashing.Storage.Generic;

public class Storage<T> : IStorage<T> where T : BaseEntity
{
    private readonly List<T> _dataset;

    public Storage()
    {
        _dataset = new List<T>();
    }

    public IList<T> GetAll()
    {
        return _dataset;
    }

    public T? GetByName(string name)
    {
        return _dataset.Count == 0 ? null : _dataset.FirstOrDefault(u => u.UserName.Equals(name));
    }


    public void Save(T entity)
    {
        _dataset.Add(entity);
    }
}