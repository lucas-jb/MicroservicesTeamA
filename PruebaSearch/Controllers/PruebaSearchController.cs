using PruebaSearch.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PruebaSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaSearchController : ControllerBase
    {
        private readonly IProveedoresService _proveedoresService;
        private readonly IProductosService _productosService;
        private readonly IComprasService _comprasService;

        public PruebaSearchController(IProveedoresService proveedoresService, IProductosService productosService, IComprasService comprasService)
        {
            _proveedoresService = proveedoresService;
            _productosService = productosService;
            _comprasService = comprasService;
        }

        [HttpGet("proveedores/{proveedorId}")]
        public async Task<IActionResult> SearchAsync(string proveedorId)
        {
            if (string.IsNullOrWhiteSpace(proveedorId))
            {
                return BadRequest();
            }
            try
            {
                var proveedor = await _proveedoresService.GetAsync(proveedorId);
                var compras = await _comprasService.GetAsync(proveedorId);

                foreach (var compra in compras)
                {
                    foreach (var item in compra.Items)
                    {
                        var product = await _productosService.GetAsync(item.ProductoId);

                        item.Producto = product;
                    }
                }

                var result = new
                {
                    Proveedor = proveedor,
                    Compras = compras
                };
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
