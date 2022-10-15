using Moq;
using Moq.Protected;
using PruebaSearch.Services;

namespace PruebaSearch.Tests
{
    public class PruebaSearchTestMoq
    {
        [SetUp]
        public void ParametrosSimulacionServicios()
        {
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            HttpResponseMessage result = new();

            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(result)
                .Verifiable();

            var httpClient1 = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("https://localhost:5000/")
            };
            var httpClient2 = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("https://localhost:5100/")
            };
            var httpClient3 = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("https://localhost:5200/")
            };

            var mockHttpClientFactory = new Mock<IHttpClientFactory>();

            mockHttpClientFactory.Setup(_ => _.CreateClient("Proveedores")).Returns(httpClient1);
            mockHttpClientFactory.Setup(_ => _.CreateClient("Productos")).Returns(httpClient2);
            mockHttpClientFactory.Setup(_ => _.CreateClient("Compras")).Returns(httpClient3);

            var service = new ComprasService(mockHttpClientFactory.Object);


        }

        

        [Test]
        public void Llamada()
        {
            Assert.Pass();
        }
    }
}