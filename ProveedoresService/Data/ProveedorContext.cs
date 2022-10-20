using Microsoft.EntityFrameworkCore;
using ProveedoresService.Models;
namespace ProveedoresService.Data
{
    public class ProveedorContext : DbContext
    {
        public ProveedorContext()
        { }
        public ProveedorContext(DbContextOptions<ProveedorContext> options) : base(options)
        {

        }

        public DbSet<Proveedor> Proveedores { get; set; }

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
