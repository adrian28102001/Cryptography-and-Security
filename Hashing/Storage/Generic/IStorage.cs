namespace Hashing.Storage.Generic;

public interface IStorage<T>
{
    public void Save(T entity);
    T? GetByName(string name);
    public IList<T> GetAll();
}