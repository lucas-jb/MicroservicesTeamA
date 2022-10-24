using ComprasService.Data;
using ComprasService.Models;

namespace ComprasService.DAL
{
    public class ComprasProviderEF : IComprasProvider
    {
        readonly DesignTimeOrderContextFactory factoriaDeContextos = new();
        private readonly OrderContext _context;

        public ComprasProviderEF()
        {
            string[] args = new string[1];
            _context = factoriaDeContextos.CreateDbContext(args);
        }
        public async Task<ICollection<Order>> GetAsync(int proveedorId)
        {
            return (ICollection<Order>)await _context.Orders.FindAsync(proveedorId);
        }
    }
}
