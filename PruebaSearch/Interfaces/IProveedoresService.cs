using PruebaSearch.Models;

namespace PruebaSearch.Interfaces
{
    /// <summary>
    /// La interfaz me devuelve un proveedor que puede ser nullo 
    /// </summary>
    public interface IProveedoresService
    {
        Task<Proveedor?> GetAsync (int id);

        Task<List<Proveedor>?> GetAllAsync();
    }
}
