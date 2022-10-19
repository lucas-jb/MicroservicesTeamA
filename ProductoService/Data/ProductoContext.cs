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
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Producto;Integrated Security=True;MultipleActiveResultSets=True");
            }
        }

    }
}
  
