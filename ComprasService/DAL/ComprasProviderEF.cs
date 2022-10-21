using ComprasService.Data;
using ComprasService.Models;

namespace ComprasService.DAL
{
    public class ComprasProviderEF : IComprasProvider
    {
        readonly DesignTimeOrderContextFactory factoriaDeContextosOrder = new();
        readonly DesignTimeOrderItemContextFactory factoriaDeContextosOrderItem = new();
        private readonly OrderContext _contextOrder;
        private readonly OrderItemContext _contextOrderItem;

        Task<ICollection<Order>> IComprasProvider.GetAsync(int proveedorId)
        {
            throw new NotImplementedException();
        }
        //public Task<ICollection<Order>> GetAsync(int proveedorId)
        //{
        //    return await _contextOrder.Orders.FindAsync(id);
        //}
    }
}
