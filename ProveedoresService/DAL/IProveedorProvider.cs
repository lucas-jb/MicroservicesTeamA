using ProveedoresService.Models;

namespace ProveedoresService.DAL
{
    public interface IProveedorProvider
    {
        Task<Proveedor> GetAsync(int id);

        Task<List<Proveedor>> GetAllAsync();
    }
}
