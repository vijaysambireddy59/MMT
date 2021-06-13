using Microsoft.EntityFrameworkCore;
using MMT.Common.Models;
using MMT.Data.Interfaces;
using System.Linq;
using MMT.Common;

namespace MMT.Data.Repositories
{
    public class OrderRepo : IOrderRepo
    {
        private readonly MMTContext _repositoryContext;
        public OrderRepo(MMTContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public Order GetOrder(string customerId)
        {
            return _repositoryContext.Orders
                .Include(c => c.OrderItems)
                .ThenInclude(y => y.Product)
                .Where(x => x.Customerid == customerId)
                .OrderByDescending(x => x.Orderdate).Take(1).Select(k => new Order()
                {
                    DeliveryExpected = k.Deliveryexpected.Value.ToString(Constants.DateFormat),
                    OrderDate = k.Orderdate.Value.ToString(Constants.DateFormat),
                    OrderNumber = k.Orderid,
                    OrderItems = k.OrderItems.Select(x => new OrderItem()
                    {
                        PriceEach = $"{(x.Price / x.Quantity):0.00}",
                        Quantity = x.Quantity,
                        Product = k.Containsgift.GetValueOrDefault(false) ? Constants.Gift : x.Product.Productname,
                    }).ToList()
                }).FirstOrDefault();
        }
    }
}
