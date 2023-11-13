using Foraging_Kentucky.Domain;

namespace Foraging_Kentucky.Data;
public interface IRepository<T> where T : class
{
    Task<List<T>> GetListAsync();
    public void Add(T type);
    public T Retrieve(string name);
    public bool CheckIfExists(string name);

    public void AddUserToList(T type, User user);
}

