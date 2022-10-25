using ProductoService.Models;
using ProductoService.CrossCuting;
using ProductoService.CrossCuting.Exceptions;
using System.Reflection;
using System.Resources;

namespace ProductoService.DAL
{
    public class ProductoProviderEF : IProductoProvider
    {
        private readonly ProductoContext _context;
        readonly DesignTimeProductoContextFactory factoriaDeContextos = new();
        readonly ResourceManager resourceManager = new("ProductoService.Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
        readonly ILoggerManager LoggerManager;

        public ProductoProviderEF(ILoggerManager loggerManager)
        {
            this.LoggerManager = loggerManager;
            string[] args = new string[1];
            _context = factoriaDeContextos.CreateDbContext(args);
             
        }

        public async Task<Producto?> GetAsync(int id)
        {
            this.LoggerManager.LogInfo($"Busqueda del producto con Id: {id} ");
            if (_context.Productos is not null)
            {
                var productoEncontrado =await _context.Productos.FindAsync(id);
                if (productoEncontrado is null)
                {
                    this.LoggerManager.LogWarn($"El producto con Id: {id}, no se ha encontrado ");
                    //El log de Error lo lanzaremos cuando lo capturemos en el middleware.
                    throw new ProductoNotFoundException(resourceManager.GetString("ProductoNotFound") ?? "", id);

                }
                return productoEncontrado;
            }
            return null;
        }
    }
}
