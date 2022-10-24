using ComprasService.Data;
using ComprasService.Models;

namespace ComprasService.DAL
{
    public class ComprasProviderEF : IComprasProvider
    {
        readonly DesignTimeOrderContextFactory factoriaDeContextos = new();
        private readonly OrderContext _context;

        public Task<ICollection<Order>> GetAsync(int proveedorId)
        {
            throw new NotImplementedException();
        }

        //public async Task<ICollection<Order>> GetAsync(int proveedorId)
        //{
        //    return await _context.Orders.FindAsync(proveedorId);
        //}
    }
}
