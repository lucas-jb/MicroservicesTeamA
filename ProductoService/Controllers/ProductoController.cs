using Microsoft.AspNetCore.Mvc;
using ProductoService.DAL;

namespace ProductoService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoProvider _productosProvider;

        public ProductoController(IProductoProvider productosProvider) 
        {
            this._productosProvider = productosProvider;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var result = await _productosProvider.GetAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}
