using ComprasService.Models;

namespace ComprasService.DAL
{
    public interface IComprasProvider
    {
        Task<ICollection<Order>> GetAsync(int proveedorId);
    }
}
