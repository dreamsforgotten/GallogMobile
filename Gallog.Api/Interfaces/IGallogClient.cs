using System.Threading.Tasks;

namespace Gallog.Api.Interfaces
{
    public interface IGallogClient
    {
        Task<T> GetItemsAsync<T>();
        Task<T> GetItemAsync<T>(string name);
    }
}
