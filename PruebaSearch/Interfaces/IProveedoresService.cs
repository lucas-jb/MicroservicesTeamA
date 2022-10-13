using PruebaSearch.Models;

namespace PruebaSearch.Interfaces
{
    public interface IProveedoresService
    {
        Task<Proveedor> GetAsync (string id);
    }
}
