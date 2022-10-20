using Microsoft.EntityFrameworkCore;
using ProductoService.Models;
using System;

namespace ProductoService.Data
{
    public partial class ProductoContext : DbContext
    {
        public ProductoContext()
        { }
        public ProductoContext(DbContextOptions<ProductoContext> options) : base(options)
        {

        }

        public DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=tcp:serverproductos.database.windows.net,1433;Initial Catalog=ApiProductos;Persist Security Info=False;User ID=admin22;Password=Productos22;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                //var connectionString = "Server=tcp:serverproductos.database.windows.net,1433;Initial Catalog=ApiProductos;Persist Security Info=False;User ID=admin22;Password=Productos22;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            }
        }

    }
}
  
