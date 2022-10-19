using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProductoService.Data
{
    public class DesignTimeProductoContextFactory : IDesignTimeDbContextFactory<ProductoContext>
    {
        public ProductoContext CreateDbContext(string[] args)
        {
            var dbContextBuilder = new DbContextOptionsBuilder<ProductoContext>();

            // this connection string is for local SQL database 
            // This database instance is generally installed with default Visual Studio components
            // If you use SQL Server Express, change connection string appropriately
            // NOTE: Do not hardcode connection strings in code.  
            // This is hard coded here to limit scope of demo.
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Producto; Integrated Security=True;";

            dbContextBuilder.UseSqlServer(connectionString);
            return new ProductoContext(dbContextBuilder.Options);
        }
    }
}
