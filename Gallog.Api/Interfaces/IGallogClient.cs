using Gallog.Api.Models;
using System.Threading.Tasks;

namespace Gallog.Api.Interfaces
{
    public interface IGallogClient
    {
        Task<T> GetItemsAsync<T>() where T : ApiQueryable;
        Task<T> GetItemAsync<T>(string name) where T : ApiQueryable;
    }
}
