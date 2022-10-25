using Microsoft.EntityFrameworkCore;

namespace ProductoService.Models
{
    public partial class ProductoContext : DbContext
    {
        public ProductoContext()
        { }
        public ProductoContext(DbContextOptions<ProductoContext> options) : base(options)
        {

        }

        public DbSet<Producto> Productos { get; set; }


    }
}

