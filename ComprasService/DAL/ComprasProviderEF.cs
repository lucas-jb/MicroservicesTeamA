using ComprasService.Data;
using ComprasService.Models;
using Microsoft.EntityFrameworkCore;

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
            ////creo una lista de las ordenes de compra de un proveedor
            //var orders = _context.Orders.Where(c => c.ProveedorId == proveedorId).ToList();


            ////recorro cada una de las ordenes de compra de un proveedor
            //for (int i = 0;i<orders.Count;i++) 
            //{
            //    //busco en la tabla orderItems las orderItems que coincidan con cada Order que tengo en la lista
            //    List<OrderItem> orderItems = _context.OrderItems.Where(x => x.OrderId == orders[i].Id).ToList();
            //    orders[i].Items.Add(orderItems);
            //}
            //return (ICollection<Order>)await _context.Orders.FindAsync(proveedorId);

            //Var Customer_OrderDetails =
            //context.CustomerDetails.Include("OrderDetails").Include("LineItems").Include("ProducDetails").ToList();

            var orders = _context.Orders.Include("OrderItem").Where(c => c.ProveedorId == proveedorId).ToList();
            if (orders != null)
            {
                return await Task.FromResult((ICollection<Order>)orders);
            }
            return null;
            
        }
    }
}
