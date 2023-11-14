using Foraging_Kentucky.Domain;

namespace Foraging_Kentucky.Data;
public interface IRepository<T> where T : class
{
    public Task<List<T>> GetListAsync();
    public Task Add(T type);
    public T Retrieve(string name);
    public bool CheckIfExists(string name);
    public Task AddUserToList(T type, User user);
    public Task Delete (T type);
    public Task Update(T type);
}

