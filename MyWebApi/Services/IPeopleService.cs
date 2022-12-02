using Microsoft.AspNetCore.JsonPatch;
using MyWebApi.Data;

namespace MyWebApi.Services
{
	public interface IPeopleService
	{
		Task<IEnumerable<Person>> GetAll();

		Task<Person> GetById(int id);

		Task<Person> Create(Person person);

		Task Delete(int id);

		Task<Person> Update(int id, JsonPatchDocument<Person> jsonPatch);
	}
}
