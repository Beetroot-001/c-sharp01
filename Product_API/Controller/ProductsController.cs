using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Product_API.Data;
using Product_API.Servises;

namespace Product_API.Controller
{
    [ApiController]//Додає додаткову валідацію даних, вказує бандінг і тд
    [Route("api/[controller]")]// замість того щоб писати префікс класу можна написати [controller] який автоматично його поставить, убереже наприклад як переіменувати цей контроллер

    public class ProductsController:ControllerBase
    {
        private readonly IProductServices productServices;

        public ProductsController(IProductServices productServices)
        {
            this.productServices = productServices;
        }

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

            return Created("", newProduct);//Першим параметром передається шлях до новоствореного ресурсу
        }

        [HttpDelete("{id}")]
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
