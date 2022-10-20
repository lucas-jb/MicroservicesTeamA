using Microsoft.AspNetCore.Mvc;
using ProveedoresService.DAL;
using System.Collections.ObjectModel;
using System;

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
            var proveedor = await proveedoresProvider.GetAsync(id);

            if (proveedor != null)
            {


                return Ok(proveedor);

            }

            return NotFound();


        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var proveedores = await proveedoresProvider.GetAllAsync();

            if (proveedores != null)
            {


                return Ok(proveedores);

            }

            return NotFound();


        }



    }

}
