using MMT.Common.Models;

namespace MMT.Data.Interfaces
{
    public interface IOrderRepo
    {
        Order GetOrder(string customerId);
    }
}