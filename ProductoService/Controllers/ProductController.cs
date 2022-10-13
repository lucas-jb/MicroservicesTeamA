using Microsoft.AspNetCore.Mvc;
using ProductoService.DAL;

namespace ProductoService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductProvider _productsProvider;

        public ProductController(IProductProvider productsProvider) 
        {
            this._productsProvider = productsProvider;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var result = await _productsProvider.GetAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}
