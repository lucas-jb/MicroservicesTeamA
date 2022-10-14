using ComprasService.DAL;
using Microsoft.AspNetCore.Mvc;

namespace ComprasService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly IComprasProvider _comprasProvider;
        public ComprasController(IComprasProvider comprasProvider)
        {
            _comprasProvider = comprasProvider;
        }

        [HttpGet("{proveedorId}")]
        public async Task<IActionResult> GetAsync(string proveedorId)
        {
            var orders = await _comprasProvider.GetAsync(proveedorId);
            if (orders != null && orders.Any())
            {
                return Ok(orders);
            }
            return NotFound();
        }
    }
}
