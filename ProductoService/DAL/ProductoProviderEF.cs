using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using ProductoService.Models;
using ProductoService.Data;

namespace ProductoService.DAL
{
    public class ProductoProviderEF : IProductoProvider
    {
        private readonly ProductoContext _context;

        public ProductoProviderEF()
        {
            _context = new ProductoContext();
        }

        public async Task<Producto> GetAsync(int? id)
        {
            return await _context.Productos.FindAsync(id);
        }
    }
}
