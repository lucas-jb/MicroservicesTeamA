using ComprasService.Controllers;
using ComprasService.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComprasService.Tests
{


    [TestClass]
    public class CustomersTest
    {
        [TestMethod]
        public async Task GetAsyncReturnsOk()
        {
            var comprasProvider = new ComprasProvider();
            var comprasController = new ComprasController(comprasProvider);

            var result = await comprasController.GetAsync(3);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetAsyncReturnsNotFound()
        {
            var comprasProvider = new ComprasProvider();
            var comprasController = new ComprasController(comprasProvider);

            var result = await comprasController.GetAsync(5);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
