using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using PruebaSearch.Interfaces;
using PruebaSearch.Models;

namespace PruebaSearch.Services
{


    public class ProveedoresService : IProveedoresService
    {

        //Remaining Code has been removed for readability
        RetryPolicy _retryPolicy = Policy
            .Handle<Exception>()
            .WaitAndRetry(
                            3,
                            retryAttempt => TimeSpan.FromSeconds(5)
                            );


        private readonly IHttpClientFactory _httpClientFactory;

        public ProveedoresService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<Proveedor?> GetAsync(string id)
        {

            var client = _httpClientFactory.CreateClient("proveedoresService");

            var response = await _retryPolicy.Execute(() => client.GetAsync($"api/proveedor/{id}"));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var proveedor = JsonConvert.DeserializeObject<Proveedor>(content);

                return proveedor;
            }

            return null;


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
