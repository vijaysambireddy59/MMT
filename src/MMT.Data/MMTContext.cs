using Microsoft.EntityFrameworkCore;
using MMT.Data.Entities;

namespace MMT.Data
{
    public class MMTContext : DbContext
    {
        public MMTContext(DbContextOptions options)
            : base(options)
        {

        }
        public virtual DbSet<ProductEntity> Products { get; set; }
        public virtual DbSet<OrderEntity> Orders { get; set; }
        public virtual DbSet<OrderItemEntity> OrderItems { get; set; }
    }
}
