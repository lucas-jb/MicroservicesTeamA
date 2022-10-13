using ProductoService.Models;

namespace ProductoService.DAL
{
    public interface IProductProvider
    {
        Task<Product> GetAsync(string id);
    }
}
