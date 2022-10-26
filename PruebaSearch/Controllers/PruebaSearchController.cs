using PruebaSearch.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using PruebaSearch.Models;

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
        public async Task<IActionResult> SearchAsync(int proveedorId)
        {
            if (proveedorId == null)
            {
                return BadRequest();
            }
            try
            {
                var proveedor = await _proveedoresService.GetAsync(proveedorId);
                var compras = await _comprasService.GetAsync(proveedorId);

                if (compras != null)
                {
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
                var result2 = new
                {
                    Proveedor = proveedor,
                    Compras = "No hay datos"
                };
                return Ok(result2);


            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("proveedores/{proveedorId}/{month}")]
        public async Task<IActionResult> SearchMonthAsync(int proveedorId, int month)
        {
            if (proveedorId == null)
            {
                return BadRequest();
            }
            try
            {
                var proveedor = await _proveedoresService.GetAsync(proveedorId);
                var compras = await _comprasService.GetAsync(proveedorId);

                List<Order> compraAux = new();

                foreach (var compra in compras)
                {
                    if (compra.OrderDate.Month.Equals(month))
                    {
                        compraAux.Add(compra);

                        foreach (var compraActual in compra.Items)
                        {
                            var product = await _productosService.GetAsync(compraActual.ProductoId);

                            compraActual.Producto = product;
                        }
                    }
                }
                
                var result = new
                {
                    Proveedor = proveedor,
                    Compras = compraAux
                };
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("proveedores/WithOutPurchases")]
        public async Task<IActionResult> SearchProviderWithOutPurchasesAsync()
        {
           
            try
            {
                var proveedores = await _proveedoresService.GetAllAsync();

               // var compras = await _comprasService.GetAsync(proveedorId);

                var compras2 = new Collection<Models.Order>();

                var proveedoresSinCompras = new Collection<Models.Proveedor>();

                foreach (var proveedor in proveedores)
                {
                    var compras = await _comprasService.GetAsync(proveedor.Id);
                    if (compras == null)
                    {
                        proveedoresSinCompras.Add(proveedor);
                    }
                }
                return Ok(proveedoresSinCompras);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
