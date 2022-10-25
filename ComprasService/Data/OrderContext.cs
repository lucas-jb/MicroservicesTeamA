using ComprasService.Models;
using Microsoft.EntityFrameworkCore;

namespace ComprasService.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext()
        { }
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        { }
        public DbSet<ICollection<Order>> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

    }
}
