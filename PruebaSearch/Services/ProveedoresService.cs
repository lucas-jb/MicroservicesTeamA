using Azure;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
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

            var response = await client.GetAsync($"api/proveedor/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync();

                var proveedor = JsonConvert.DeserializeObject<Proveedor>(content.Result);

                return proveedor;
            }
            else
            {

                return null;
            }



        }

        public async Task<List<Proveedor?>> GetAllAsync()
        {
            var client = _httpClientFactory.CreateClient("proveedoresService");
            var response = await client.GetAsync($"api/proveedor/GetAll");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var proveedores = JsonConvert.DeserializeObject<List<Proveedor>>(content);

                return proveedores;
            }

            return null;
        }

    }
}
