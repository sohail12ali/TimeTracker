using Realms;
using System.Linq;
using System.Threading.Tasks;

namespace TimeTracker.Interfaces
{
    public interface IRealmServices
    {
        Task<IQueryable<T>> GetItemsAsync<T>() where T : RealmObject;

        Task<bool> AddItemAsync<T>(T item) where T : RealmObject;

        Task<bool> DeleteItemAsync<T>(T item) where T : RealmObject;

        Task<bool> DeleteAllItems<T>() where T : RealmObject;
    }
}