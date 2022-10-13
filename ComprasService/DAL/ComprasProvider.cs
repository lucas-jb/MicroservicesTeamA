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
                CustomerId = "1",
                OrderDate = DateTime.Now.AddMonths(-1),
                Total = 100,
                Items = new List<OrderItem>()
                {
                    new OrderItem() {OrderId = "0001", Id = 1, Price = 50, ProductId = "23", Quantity = 2},
                    new OrderItem() {OrderId = "0001", Id = 2, Price = 80, ProductId = "24", Quantity = 2}
                }
            });
            repo.Add(new Order
            {
                Id = "0002",
                CustomerId = "2",
                OrderDate = DateTime.Now.AddMonths(-1),
                Total = 100,
                Items = new List<OrderItem>()
                {
                    new OrderItem() {OrderId = "0001", Id = 1, Price = 50, ProductId = "23", Quantity = 2},
                    new OrderItem() {OrderId = "0002", Id = 2, Price = 80, ProductId = "24", Quantity = 2}
                }
            });
            repo.Add(new Order
            {
                Id = "0003",
                CustomerId = "3",
                OrderDate = DateTime.Now.AddMonths(-1),
                Total = 100,
                Items = new List<OrderItem>()
                {
                    new OrderItem() {OrderId = "0001", Id = 1, Price = 50, ProductId = "111", Quantity = 2},
                    new OrderItem() {OrderId = "0002", Id = 2, Price = 30, ProductId = "21", Quantity = 2},
                    new OrderItem() {OrderId = "0003", Id = 3, Price = 30, ProductId = "21", Quantity = 2}
                }
            });
        }
       

        public async Task<ICollection<Order>> GetAsync(string customerId)
        {
            var orders =  repo.Where(c => c.CustomerId == customerId).ToList();
            return await Task.FromResult((ICollection<Order>)orders);

        }
    }
}
