using ProductoService.Models;

namespace ProductoService.DAL
{
    public class ProductProvider : IProductProvider
    {
        private readonly List<Product> _repo = new List<Product>();

        public ProductProvider()
        {
            for (int i = 0; i < 100; i++)
            {
                _repo.Add(new Product()
                {
                    Id = (i + 1).ToString(),
                    Name = $"Product {i + 1}",
                    Price = (double)i * 3.14
                });
            }
        }

        public Task<Product> GetAsync(string id)
        {
            var product = _repo.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(product);
        }
    }
}
