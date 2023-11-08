using Foraging_Kentucky.Domain;

namespace Foraging_Kentucky.Data;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetListAsync();

    public void Add(T type);
}

