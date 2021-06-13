using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMT.Data.Entities
{
    [Table("ORDERITEMS")]
    public class OrderItemEntity
    {
        [Key]
        [Column("ORDERITEMID")]
        public int Orderitemid { get; set; }

        [Column("ORDERID")]
        public int? Orderid { get; set; }

        [Column("PRODUCTID")]
        public int? Productid { get; set; }

        [Column("QUANTITY")]
        public int? Quantity { get; set; }

        [Column("PRICE")]
        public decimal? Price { get; set; }

        [Column("RETURNABLE")]
        public bool? Returnable { get; set; }


        public virtual OrderEntity Order { get; set; }
        public virtual ProductEntity Product { get; set; }
    }
}
