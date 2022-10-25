using ProductoService.Models;

namespace ProductoService.DAL
{
    public interface IProductoProvider
    {
        Task<Producto?> GetAsync(int id);
    }
}
