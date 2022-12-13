using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Product_API.Data;
using Product_API.Filters;
using Product_API.Servises;

namespace Product_API.Controller
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductsController:ControllerBase
    {
        private readonly IProductServices productServices;

        public ProductsController(IProductServices productServices)
        {
            this.productServices = productServices;
        }

        [TypeFilter(typeof(MyActionFiltr))]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await productServices.GetAll();

            return Ok(products);
        }

        [HttpGet("{id}")]// api/products/1  
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var product = await productServices.GetById(id);

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            var newProduct = await productServices.Create(product);

            return Created("", newProduct);
        }

        [HttpDelete("{id}")]
        //[TypeFilter(typeof(MyCustomAuthorization))] // ЧОМУСЬ НЕ ДАЄ ЗАЙТИ В КОНТРОЛЕР
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            await productServices.Delete(id);

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateById([FromRoute] int id,JsonPatchDocument<Product> jsonPatchDocument)
        {
           var product = await productServices.Update(id,jsonPatchDocument);

            return Ok(product);
        }
    }
}
