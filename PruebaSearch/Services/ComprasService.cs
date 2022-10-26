using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Newtonsoft.Json;
using PruebaSearch.Interfaces;
using PruebaSearch.Models;

namespace PruebaSearch.Services
{
    public class ComprasService : IComprasService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ComprasService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ICollection<Order>?> GetAsync(int proveedorId)
        {
            var client = _httpClientFactory.CreateClient("comprasService");
            var cadena = $"/api/compras/{proveedorId}";
            //$"api/Compras/{proveedorId}"
            var response = await client.GetAsync(cadena);
            
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var orders = JsonConvert.DeserializeObject<ICollection<Order>>(content);

                return orders;
            }

            return null;
        }
    }
}