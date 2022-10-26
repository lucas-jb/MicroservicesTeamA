using PruebaSearch.Models;

namespace PruebaSearch.Interfaces
{
    public interface IComprasService
    {
        Task<ICollection<Order>?> GetAsync(int proveedorId);
    }
}
