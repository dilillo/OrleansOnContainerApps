using Microsoft.AspNetCore.Mvc;
using OrleansExample3.Api.Infrastructure;
using OrleansExample3.Api.Models;

namespace OrleansExample3.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductOperations _productOperations;

        public ProductsController(IProductOperations grains)
        {
            _productOperations = grains;
        }

        [HttpGet("{serialNumber:required}")]
        public async Task<IActionResult> Get(string serialNumber) => Ok(await _productOperations.GetDetails(serialNumber));

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody]ProductRegistrationPatchRequestBodyModel model)
        {
            await _productOperations.Register(model.SerialNumber, model.RegisterTo);

            return Ok();
        }
    }
}