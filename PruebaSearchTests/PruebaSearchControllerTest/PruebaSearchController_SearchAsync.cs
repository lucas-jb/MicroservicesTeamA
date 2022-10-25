using Microsoft.AspNetCore.Mvc;
using Moq;
using PruebaSearch.Controllers;
using PruebaSearch.Interfaces;
using PruebaSearch.Models;
using System.Net;
using System.Runtime.InteropServices;

namespace PruebaSearchTests.PruebaSearchControllerTest
{
    [TestClass]
    public class PruebaSearchController_SearchAsync
    {
        private readonly Mock<IProveedoresService> _MockproveedoresService = new();
        private readonly Mock<IProductosService> _MockproductosService = new();
        private readonly Mock<IComprasService> _MockcomprasService = new();

        //test 1
        [TestMethod]
        public async Task SearchAsyn_IsNullOrWhiteSpace_BadRequest()
        {
            var PruebasSearchController = new PruebaSearchController(_MockproveedoresService.Object, _MockproductosService.Object, _MockcomprasService.Object);
            var actionResult = await PruebasSearchController.SearchAsync(It.IsAny<int>());
            var result = actionResult as BadRequestResult;

            if (result is not null)
            {
                Assert.AreEqual(result.StatusCode, (int)HttpStatusCode.BadRequest);
            }
           
        }

        //test 2
        [TestMethod]
        public async Task SearchAsyn_IsNotNullOrWhiteSpace_ReturnOkObject()
        {
            IList<Order> mockList = new List<Order>()
            {
            new Order()
                {
                Items = new List<OrderItem>()
                    {
                        new OrderItem()
                    }
                }
            };

            var PruebasSearchController = new PruebaSearchController(_MockproveedoresService.Object, _MockproductosService.Object, _MockcomprasService.Object);
            _MockproveedoresService.Setup(c => c.GetAsync(It.IsAny<int>())).ReturnsAsync(new Proveedor());
            _MockcomprasService.Setup(c => c.GetAsync(It.IsAny<int>())).ReturnsAsync(mockList);
            _MockproductosService.Setup(c => c.GetAsync(It.IsAny<int>())).ReturnsAsync(new Producto());

            var result = await PruebasSearchController.SearchAsync(1);

            Assert.IsNotNull(result);
        }


        //[TestMethod]
        //public async Task SearchAsyn_IsNotNullOrWhiteSpace_ThrowsException()
        //{
        //    IList<Order> mockList = new List<Order>()
        //    {
        //    new Order()
        //        {
        //        Items = new List<OrderItem>()
        //            {
        //                new OrderItem()
        //            }
        //        }
        //    };

        //    var PruebasSearchController = new PruebaSearchController(_MockproveedoresService.Object, _MockproductosService.Object, _MockcomprasService.Object);

        //    _MockproveedoresService.Setup(c => c.GetAsync(It.IsAny<string>())).Throws(new Exception());

        //    var result = await PruebasSearchController.SearchAsync("1");

        //    // Comprobar como es el assert de que ha lanzado una excepcion
        //    // FALTA COMPRAR QUE LANZA UNA EXCEPCION ! ! !

        //    Assert.ThrowsException<Exception>(() => result);

        //    // Comprobar como es el assert de que ha lanzado una excepcion
        //    Assert.ThrowsException(result);
        //}
    }
}