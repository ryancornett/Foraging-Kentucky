using Foraging_Kentucky.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Foraging_Kentucky.Data;
public interface IRepository<T> where T : class
{
    public Task<List<T>> GetListAsync();
    public Task Add(T type);
    public Task<T> Retrieve(string name);
    public bool CheckIfExists(string name);
    public Task AddUserToItemList(Item item, User user);
    public Task AddItemToUserList(User user, Item item);
    public Task RemoveItemFromUserList(User user, Item item);
    public Task AddUserToRecipeAddedBy(Recipe recipe, User user);
    public Task Delete (T type);
    public Task Update(T type);
    public Task<List<T>> RetrieveByProperty(string value);
    public Task<List<T>> RetrieveByRecentlyAdded();
    public Task<List<T>> RetrieveByFirstAdded();
    public Task<List<T>> RetrieveByAlphabeticalOrder();
}

