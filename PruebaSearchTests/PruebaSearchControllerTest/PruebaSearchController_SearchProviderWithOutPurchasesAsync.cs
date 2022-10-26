using Moq;
using PruebaSearch.Controllers;
using PruebaSearch.Interfaces;
using PruebaSearch.Models;

namespace PruebaSearchTests.PruebaSearchControllerTest
{
    public class PruebaSearchController_SearchProviderWithOutPurchasesAsync
    {
        private readonly Mock<IProveedoresService> _MockproveedoresService = new();
        private readonly Mock<IProductosService> _MockproductosService = new();
        private readonly Mock<IComprasService> _MockcomprasService = new();

        //test 2
        [TestMethod]
        public async Task SearchProviderWithOutPurchasesAsync_ReturnOkObject()
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
            var actionResult = await PruebasSearchController.SearchProviderWithOutPurchasesAsync();
            _MockproveedoresService.Setup(c => c.GetAsync(It.IsAny<int>())).ReturnsAsync(new Proveedor());
            _MockcomprasService.Setup(c => c.GetAsync(It.IsAny<int>())).ReturnsAsync(mockListCompras);
            _MockproductosService.Setup(c => c.GetAsync(It.IsAny<int>())).ReturnsAsync(new Producto());

            var result = await PruebasSearchController.SearchProviderWithOutPurchasesAsync();

            Assert.IsNotNull(result);
        }
    }
}
