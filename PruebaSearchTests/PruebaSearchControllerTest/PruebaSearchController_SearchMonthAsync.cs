using Microsoft.AspNetCore.Mvc;
using Moq;
using PruebaSearch.Controllers;
using PruebaSearch.Interfaces;
using PruebaSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PruebaSearchTests.PruebaSearchControllerTest
{
    [TestClass]
    public class PruebaSearchController_SearchMonthAsync
    {
        private readonly Mock<IProveedoresService> _MockproveedoresService = new();
        private readonly Mock<IProductosService> _MockproductosService = new();
        private readonly Mock<IComprasService> _MockcomprasService = new();

        //test 1
        [TestMethod]
        public async Task SearchMonthAsync_IsNullOrWhiteSpace_BadRequest()
        {
            var PruebasSearchController = new PruebaSearchController(_MockproveedoresService.Object, _MockproductosService.Object, _MockcomprasService.Object);
            var actionResult = await PruebasSearchController.SearchMonthAsync(It.IsAny<int>(), It.IsAny<int>());
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
            IList<Order> mockListCompras = new List<Order>()
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
            var actionResult = await PruebasSearchController.SearchMonthAsync(It.IsAny<int>(), It.IsAny<int>());
            _MockproveedoresService.Setup(c => c.GetAsync(It.IsAny<int>())).ReturnsAsync(new Proveedor());
            _MockcomprasService.Setup(c => c.GetAsync(It.IsAny<int>())).ReturnsAsync(mockListCompras);
            _MockproductosService.Setup(c => c.GetAsync(It.IsAny<int>())).ReturnsAsync(new Producto());

            var result = await PruebasSearchController.SearchMonthAsync(1,1);

            Assert.IsNotNull(result);
        }
    }
}
