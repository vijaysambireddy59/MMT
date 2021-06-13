using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MMT.Common.Dto;
using MMT.Common.Models;
using MMT.Core;
using MMT.Data.Interfaces;
using System.Threading.Tasks;

namespace MMT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IUserAPIClient _userApiClient;
        private readonly IOrderRepo _orderRepo;
        private readonly ILogger<OrderController> _logger;

        //Added logger just to show the how we can do.
        public OrderController(IUserAPIClient userApiClient, IOrderRepo orderRepo, ILogger<OrderController> logger)
        {
            _userApiClient = userApiClient;
            _orderRepo = orderRepo;
            _logger = logger;
        }

        [Route("GetCustomerOrder")]
        [HttpPost]
        public async Task<IActionResult> GetCustomerOrder([FromBody] CustomerDto customer)
        {
            var customerDetails = await _userApiClient.Get(customer.user);

            if (customerDetails == null || customerDetails.CustomerId != customer.customerId)
            {
                _logger.LogError("Invalid user data");
                return BadRequest("Invalid email or id");
            }

            var order = _orderRepo.GetOrder(customer.customerId);

            //We can have AutoMappers for Entites to models
            var customerAndOrders = new CustomerAndOrders
            {
                Customer = customerDetails
            };

            if (order != null)
            {
                customerAndOrders.Order = order;
                customerAndOrders.Order.DeliveryAddress = customerDetails.ToString();
            }

            _logger.LogDebug("[CustomerAndOrdersResponse]", customerAndOrders);

            return Ok(customerAndOrders);
        }
    }
}
