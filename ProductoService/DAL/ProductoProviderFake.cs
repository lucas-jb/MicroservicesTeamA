using ProductoService.Models;

namespace ProductoService.DAL
{
    public class ProductoProviderFake : IProductoProvider
    {
        private readonly List<Producto> _repo = new List<Producto>();

        public ProductoProviderFake()
        {
            for (int i = 0; i < 100; i++)
            {
                _repo.Add(new Producto()
                {
                    Id = (i + 1),
                    Name = $"Producto {i + 1}",
                    Price = (double)i * 3.14
                });
            }
        }

        public Task<Producto?> GetAsync(int id)
        {
            var product = _repo.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(product);
        }
    }
}
