using Newtonsoft.Json;
using PruebaSearch.Interfaces;
using PruebaSearch.Models;

namespace PruebaSearch.Services
{
    public class ProveedoresService : IProveedoresService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProveedoresService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<Proveedor?> GetAsync(string id)
        {
            var client = _httpClientFactory.CreateClient("proveedoresService");
            var response = await client.GetAsync($"api/proveedores/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var proveedor = JsonConvert.DeserializeObject<Proveedor>(content);

                return proveedor;
            }

            return null;
        }
    }
}
