using Microsoft.AspNetCore.Mvc;
using PruebaSearch.Services;
namespace PruebaSearch.Tests
{
    [TestClass]
    public class ProveedorTest
    {
        [TestMethod]
        public void GetAsyncReturnsOk()
        {
            IHttpClientFactory client = new();
            var servicioCompras = new ComprasService(client);
            var provedorController = new ProveedorController(proveedorProvider);
            var result = provedorController.GetAsync(1).Result;


            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

        }
        [TestMethod]
        public void GetAsyncReturnsNotFound()
        {
            var proveedorProvider = new ProveedoresProvider();
            var provedorController = new ProveedorController(proveedorProvider);
            var result = provedorController.GetAsync(1550).Result;


            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}