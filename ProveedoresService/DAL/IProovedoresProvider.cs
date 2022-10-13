using ProveedoresService.Models;

namespace ProveedoresService.DAL
{
    public interface IProovedoresProvider
    {
        Task<Proveedor> GetAsync(int id);
    }
}
