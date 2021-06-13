using MMT.Common.Models;
using System.Threading.Tasks;

namespace MMT.Core
{
    public interface IUserAPIClient
    {
        Task<CustomerFullDetails> Get(string email);
    }
}