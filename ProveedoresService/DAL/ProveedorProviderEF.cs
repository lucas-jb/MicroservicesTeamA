using ProveedoresService.Models;
using ProveedoresService.Data;
using Microsoft.EntityFrameworkCore;

namespace ProveedoresService.DAL
{
    public class ProveedorProviderEF : IProveedorProvider
    {
        private readonly ProveedorContext _context;
        public ProveedorProviderEF()
        {
            _context = new ProveedorContext();
        }

        public async Task<Proveedor> GetAsync(int id)
        {
            return await _context.Proveedores.FindAsync(id);
        }

        public async Task<List<Proveedor>> GetAllAsync()
        {
            return await _context.Proveedores.ToListAsync();
        }
    }
}


