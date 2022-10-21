using ComprasService.Models;
using Microsoft.EntityFrameworkCore;

namespace ComprasService.Data
{
    public class OrderItemContext : DbContext
    {
        public OrderItemContext()
        { }
        public OrderItemContext(DbContextOptions<OrderItemContext> options) : base(options)
        { }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
