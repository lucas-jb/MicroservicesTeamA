using PruebaSearch.Models;

namespace PruebaSearch.Interfaces
{
    public interface IProductosService
    {
        Task<Producto> GetAsync(string id);
    }
}
