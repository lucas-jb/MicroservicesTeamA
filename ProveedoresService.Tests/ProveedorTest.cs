using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProveedoresService.Controllers;
using ProveedoresService.DAL;
namespace ProveedoresServices.Tests
{
    [TestClass]
    public class ProveedorTest
    {
        [TestMethod]
        public void GetAsyncReturnsOk()
        {
            var proveedorProvider = new ProveedorProvider();
            var provedorController = new ProveedorController(proveedorProvider);
            var result = provedorController.GetAsync(1).Result;


            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

        }
        [TestMethod]
        public void GetAsyncReturnsNotFound()
        {
            var proveedorProvider = new ProveedorProvider();
            var provedorController = new ProveedorController(proveedorProvider);
            var result = provedorController.GetAsync(1550).Result;


            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}