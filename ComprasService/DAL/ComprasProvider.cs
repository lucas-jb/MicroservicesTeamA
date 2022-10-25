using ComprasService.Models;

namespace ComprasService.DAL
{
    public class ComprasProvider : IComprasProvider
    {
        private readonly List<Order> repo = new List<Order>();
        public ComprasProvider() 
        {
            repo.Add(new Order
            {
                Id = 1,
                ProveedoresId = 1,
                OrderDate = DateTime.Now.AddMonths(-1),
                Total = 100,
                Items = new List<OrderItem>()
                {
                    new OrderItem() {OrderId = 1, Id = 1, Price = 50, ProductoId = 23, Quantity = 2},
                    new OrderItem() {OrderId = 1, Id = 2, Price = 80, ProductoId = 24, Quantity = 2}
                }
            });
            repo.Add(new Order
            {
                Id = 2,
                ProveedoresId = 1,
                OrderDate = DateTime.Now.AddMonths(-1),
                Total = 100,
                Items = new List<OrderItem>()
                {
                    new OrderItem() {OrderId = 2, Id = 3, Price = 50, ProductoId = 53, Quantity = 2},
                    new OrderItem() {OrderId = 2, Id = 4, Price = 80, ProductoId = 74, Quantity = 2}
                }
            });
            repo.Add(new Order
            {
                Id = 3,
                ProveedoresId = 2,
                OrderDate = DateTime.Now.AddMonths(-1),
                Total = 100,
                Items = new List<OrderItem>()
                {
                    new OrderItem() {OrderId = 3, Id = 5, Price = 50, ProductoId = 23, Quantity = 2},
                    new OrderItem() {OrderId = 3, Id = 6, Price = 80, ProductoId = 24, Quantity = 2}
                }
            });
            repo.Add(new Order
            {
                Id = 4,
                ProveedoresId = 3,
                OrderDate = DateTime.Now.AddMonths(-1),
                Total = 100,
                Items = new List<OrderItem>()
                {
                    new OrderItem() {OrderId = 4, Id = 7, Price = 50, ProductoId = 111, Quantity = 2},
                    new OrderItem() {OrderId = 4, Id = 8, Price = 30, ProductoId = 21, Quantity = 2},
                    new OrderItem() {OrderId = 4, Id = 9, Price = 30, ProductoId = 21, Quantity = 2}
                }
            });
        }
       

        public async Task<ICollection<Order>> GetAsync(int proveedorId)
        {
            var orders =  repo.Where(c => c.ProveedoresId == proveedorId).ToList();
            return await Task.FromResult((ICollection<Order>)orders);

        }
    }
}
