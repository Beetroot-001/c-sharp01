using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Data;
using MyWebApi.Services;

namespace MyWebApi.Controllers
{
	[ApiController]
	[Route("api/people")]
	public class PeopleController : ControllerBase
	{
		private readonly IPeopleService peopleService;

		public PeopleController(IPeopleService peopleService)
		{
			this.peopleService = peopleService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllPeople()
		{
			var people = await peopleService.GetAll();

			return Ok(people);
		}

		[HttpGet("{id}")] // api/people/1
		public async Task<IActionResult> GetById(int id)
		{
			var person = await peopleService.GetById(id);

			return Ok(person);
		}

		[HttpPost]
		public async Task<IActionResult> CreatePerson([FromBody] Person person)
		{
			var createdPerson = await peopleService.Create(person);

			return Created("", createdPerson);
		}

		[HttpPatch("{id}")]
		public async Task<IActionResult> UpdatePersonById(int id, [FromBody] JsonPatchDocument<Person> jsonPatchDocument)
		{
			var updatedPerson = await peopleService.Update(id, jsonPatchDocument);

			return Ok(updatedPerson);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePerson(int id)
		{
			await peopleService.Delete(id);

			return NoContent();
		}

	}
}
