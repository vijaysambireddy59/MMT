namespace MMT.Common.Models
{
    public class CustomerAndOrders
    {
        public CustomerAndOrders()
        {
            Customer = new Customer();
        }

        public Customer Customer { get; set; }
        public Order Order { get; set; }
    }
}
