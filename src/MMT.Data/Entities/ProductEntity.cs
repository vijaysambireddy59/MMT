using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMT.Data.Entities
{
    [Table("PRODUCTS")]
    public class ProductEntity
    {
        public ProductEntity()
        {
            OrderItems = new HashSet<OrderItemEntity>();
        }

        [Key]
        [Column("PRODUCTID")]
        public int Productid { get; set; }

        [Column("PRODUCTNAME")]
        public string Productname { get; set; }

        [Column("PACKHEIGHT")]
        public decimal? Packheight { get; set; }

        [Column("PACKWIDTH")]
        public decimal? Packwidth { get; set; }

        [Column("PACKWEIGHT")]
        public decimal? Packweight { get; set; }

        [Column("COLOUR")]
        public string Colour { get; set; }

        [Column("SIZE")]
        public string Size { get; set; }

        public virtual ICollection<OrderItemEntity> OrderItems { get; set; }
    }
}
