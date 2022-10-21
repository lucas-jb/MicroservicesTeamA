using ProveedoresService.Models;
using ProveedoresService.Data;
using Microsoft.EntityFrameworkCore;

namespace ProveedoresService.DAL
{
    public class ProveedorProviderEF : IProveedorProvider
    {
        readonly DesignTimeProveedorContextFactory factoriaDeContextos = new();
        private readonly ProveedorContext _context;

        public ProveedorProviderEF()
        {
            string[] args = new string[1];
            _context = factoriaDeContextos.CreateDbContext(args);
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


