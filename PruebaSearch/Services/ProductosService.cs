using Newtonsoft.Json;
using PruebaSearch.Interfaces;
using PruebaSearch.Models;

namespace PruebaSearch.Services
{
    public class ProductosService : IProductosService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductosService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Producto> GetAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("productosService");
            var response = await client.GetAsync($"api/producto/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var product = JsonConvert.DeserializeObject<Producto>(content);

                return product;
            }

            return null;
        }
    }
}
