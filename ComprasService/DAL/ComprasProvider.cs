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
                Id = "0001",
                ProveedorId = "1",
                OrderDate = DateTime.Now.AddMonths(-1),
                Total = 100,
                Items = new List<OrderItem>()
                {
                    new OrderItem() {OrderId = "0001", Id = 1, Price = 50, ProductoId = "23", Quantity = 2},
                    new OrderItem() {OrderId = "0001", Id = 2, Price = 80, ProductoId = "24", Quantity = 2}
                }
            });
            repo.Add(new Order
            {
                Id = "0001",
                ProveedorId = "1",
                OrderDate = DateTime.Now.AddMonths(-1),
                Total = 100,
                Items = new List<OrderItem>()
                {
                    new OrderItem() {OrderId = "0002", Id = 2, Price = 50, ProductoId = "53", Quantity = 2},
                    new OrderItem() {OrderId = "0003", Id = 3, Price = 80, ProductoId = "74", Quantity = 2}
                }
            });
            repo.Add(new Order
            {
                Id = "0002",
                ProveedorId = "2",
                OrderDate = DateTime.Now.AddMonths(-1),
                Total = 100,
                Items = new List<OrderItem>()
                {
                    new OrderItem() {OrderId = "0001", Id = 1, Price = 50, ProductoId = "23", Quantity = 2},
                    new OrderItem() {OrderId = "0002", Id = 2, Price = 80, ProductoId = "24", Quantity = 2}
                }
            });
            repo.Add(new Order
            {
                Id = "0003",
                ProveedorId = "3",
                OrderDate = DateTime.Now.AddMonths(-1),
                Total = 100,
                Items = new List<OrderItem>()
                {
                    new OrderItem() {OrderId = "0001", Id = 1, Price = 50, ProductoId = "111", Quantity = 2},
                    new OrderItem() {OrderId = "0002", Id = 2, Price = 30, ProductoId = "21", Quantity = 2},
                    new OrderItem() {OrderId = "0003", Id = 3, Price = 30, ProductoId = "21", Quantity = 2}
                }
            });
        }
       

        public async Task<ICollection<Order>> GetAsync(string proveedorId)
        {
            var orders =  repo.Where(c => c.ProveedorId == proveedorId).ToList();
            return await Task.FromResult((ICollection<Order>)orders);

        }
    }
}
