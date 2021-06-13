using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMT.Data.Entities
{
    [Table("ORDERS")]
    public class OrderEntity
    {
        public OrderEntity()
        {
            OrderItems = new HashSet<OrderItemEntity>();
        }

        [Key]
        [Column("ORDERID")]
        public int Orderid { get; set; }

        [Column("CUSTOMERID")]
        public string Customerid { get; set; }

        [Column("ORDERDATE")]
        public DateTime? Orderdate { get; set; }

        [Column("DELIVERYEXPECTED")]
        public DateTime? Deliveryexpected { get; set; }

        [Column("CONTAINSGIFT")]
        public bool? Containsgift { get; set; }

        [Column("SHIPPINGMODE")]
        public string Shippingmode { get; set; }

        [Column("ORDERSOURCE")]
        public string Ordersource { get; set; }

        public virtual ICollection<OrderItemEntity> OrderItems { get; set; }
    }
}
