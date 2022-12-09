using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Controllers
{
	[Route("api/products")]
	public class ProductController : ControllerBase
	{

		[HttpGet]
		public IActionResult GetAll()
		{
			return Ok(new[] { 1, 2, 3 });
		}

		[HttpPost]
		public IActionResult Create([FromBody] Product product)
		{
			if(!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Created("", product);
		}
	}

	public class Product
	{
		public int Id { get; set; }

		public string Name { get; set; }


		public string Email { get; set; }


		public string Description { get; set; }

		public double PricePerUnit { get; set; }

		public int Quantity { get; set; }
	}


}
