using Microsoft.AspNetCore.Mvc;
using ProveedoresService.DAL;

namespace ProveedoresService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProovedoresProvider proveedoresProvider;
        public ProveedorController(IProovedoresProvider proveedoresProvider)
        {

            this.proveedoresProvider = proveedoresProvider;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var customer = await proveedoresProvider.GetAsync(id);

            if (customer != null)
            {


                return Ok(customer);

            }

            return NotFound();


        }



    }

}
