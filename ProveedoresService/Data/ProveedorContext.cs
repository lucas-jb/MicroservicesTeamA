using Microsoft.EntityFrameworkCore;
using ProveedoresService.Models;
namespace ProveedoresService.Data
{
    public class ProveedorContext : DbContext
    {
        public ProveedorContext()
        { }
        public ProveedorContext(DbContextOptions<ProveedorContext> options) : base(options)
        { }
        public DbSet<Proveedor> Proveedores { get; set; }
    }
}
