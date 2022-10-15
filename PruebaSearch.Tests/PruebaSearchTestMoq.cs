using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PruebaSearch.Controllers;
using PruebaSearch.Interfaces;
using PruebaSearch.Models;


namespace PruebaSearch.Tests
{
    public class PruebaSearchTestMoq
    {
        private readonly Mock<IProveedoresService> _MockproveedoresService = new();
        private readonly Mock<IProductosService> _MockproductosService = new();
        private readonly Mock<IComprasService> _MockcomprasService = new();

        //[TestMethod]
        //public async Task SearchAsyn_IsNullOrWhiteSpace_BadRequest()
        //{
        //    //IProveedoresService proveedoresService, IProductosService productosService, IComprasService comprasService
        //    var PruebasSearchController = new PruebaSearchController(_MockproveedoresService.Object, _MockproductosService.Object, _MockcomprasService.Object);

        //    var result = await PruebasSearchController.SearchAsync("1");
        //    Assert.IsNull(result);
        //}


        //test 2
        [TestMethod]
        public async Task SearchAsyn_IsNotNullOrWhiteSpace_ReturnOkObject()
        {
            //Order _orden = new Order {
            //    Id = "2",
            //    OrderDate = new DateTime(2019, 05, 09, 9, 15, 0),
            //    ProveedorId = "2",
            //    Total = 1.2,
            //    Items = new List<OrderItem>()
            //};

            IList<Order> mockList = new List<Order>() { new Order() };

            var PruebasSearchController = new PruebaSearchController(_MockproveedoresService.Object, _MockproductosService.Object, _MockcomprasService.Object);
            _MockproveedoresService.Setup(c => c.GetAsync(It.IsAny<string>())).ReturnsAsync(new Proveedor());
            _MockcomprasService.Setup(c => c.GetAsync(It.IsAny<string>())).ReturnsAsync(mockList);
            _MockproductosService.Setup(c => c.GetAsync(It.IsAny<string>())).ReturnsAsync(new Producto());

            var result = await PruebasSearchController.SearchAsync("1");

            Assert.IsNotNull(result);
        }


        //    [SetUp]
        //    public void ParametrosSimulacionServicios()
        //    {

        //    //private readonly IProveedoresService _proveedoresService;
        //    //private readonly IProductosService _productosService;
        //    //private readonly IComprasService _comprasService;

        //    private readonly Mock<IProveedoresService> _MockproveedoresService = new();
        //    private readonly Mock<IProductosService> _MockproductosService = new();
        //    private readonly Mock<IComprasService> _MockcomprasService = new();

        //    var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

        //    HttpResponseMessage result = new();

        //    handlerMock
        //        .Protected()
        //            .Setup<Task<HttpResponseMessage>>(
        //                "SendAsync",
        //                ItExpr.IsAny<HttpRequestMessage>(),
        //                ItExpr.IsAny<CancellationToken>()
        //            )
        //            .ReturnsAsync(result)
        //            .Verifiable();

        //    var httpClient1 = new HttpClient(handlerMock.Object)
        //    {
        //        BaseAddress = new Uri("https://localhost:5000/")
        //    };
        //    var httpClient2 = new HttpClient(handlerMock.Object)
        //    {
        //        BaseAddress = new Uri("https://localhost:5100/")
        //    };
        //    var httpClient3 = new HttpClient(handlerMock.Object)
        //    {
        //        BaseAddress = new Uri("https://localhost:5200/")
        //    };

        //    var mockHttpClientFactory = new Mock<IHttpClientFactory>();

        //    mockHttpClientFactory.Setup(_ => _.CreateClient("Proveedores")).Returns(httpClient1);
        //    mockHttpClientFactory.Setup(_ => _.CreateClient("Productos")).Returns(httpClient2);
        //    mockHttpClientFactory.Setup(_ => _.CreateClient("Compras")).Returns(httpClient3);

        //    var service = new ComprasService(mockHttpClientFactory.Object);

        //}




        //[Test]
        //public void Llamada()
        //{
        //    Assert.Pass();
        //}
    }
}