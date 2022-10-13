using ComprasService.DAL;
using Microsoft.AspNetCore.Mvc;

namespace lil.Sales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly IComprasProvider _comprasProvider;
        public ComprasController(IComprasProvider salesProvider)
        {
            _comprasProvider = salesProvider;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetAsync(string customerId)
        {
            var orders = await _comprasProvider.GetAsync(customerId);
            if (orders != null && orders.Any())
            {
                return Ok(orders);
            }
            return NotFound();
        }
    }
}
