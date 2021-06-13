using System.Threading.Tasks;

namespace MMT.Core
{
    public interface IMMTHttpClient
    {
        Task<T> GetAsync<T>(string url);
    }
}