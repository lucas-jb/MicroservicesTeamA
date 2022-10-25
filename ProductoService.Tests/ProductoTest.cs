using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductoService.Controllers;
using ProductoService.DAL;

namespace ProductoService.Tests
{

    [TestClass]
    public class ProductoTest
    {
        [TestMethod]
        public void GetAsyncReturnsOk()
        {
            var productProvider = new ProductoProviderFake();
            var productController = new ProductoController(productProvider);

            var result = productController.GetAsync(1).Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetAsyncReturnsNotFound()
        {
            var productProvider = new ProductoProviderFake();
            var productController = new ProductoController(productProvider);

            var result = productController.GetAsync(1000).Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
