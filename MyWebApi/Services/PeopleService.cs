using Microsoft.AspNetCore.JsonPatch;
using MyWebApi.Data;

namespace MyWebApi.Services
{
	public class PeopleService : IPeopleService
	{
		private readonly IPeopleRepo peopleRepo;

		public PeopleService(IPeopleRepo peopleRepo)
		{
			this.peopleRepo = peopleRepo;
		}

		public Task<Person> Create(Person person)
		{
			if (string.IsNullOrEmpty(person.FirstName) || string.IsNullOrEmpty(person.LastName) || person.Age <= 0)
			{
				throw new Exception("Person is not valid");
			}

			return peopleRepo.Create(person);
		}

		public async Task Delete(int id)
		{
			var person = await peopleRepo.GetById(id);
			if(person == null)
			{
				throw new Exception("Person is not found");
			}

			await peopleRepo.Delete(person);
		}

		public Task<IEnumerable<Person>> GetAll()
		{
			return peopleRepo.GetAll();
		}

		public async Task<Person> GetById(int id)
		{
			var person = await peopleRepo.GetById(id);
			if (person == null)
			{
				throw new Exception("Person is not found");
			}

			return person;

		}

		public async Task<Person> Update(int id, JsonPatchDocument<Person> jsonPatch)
		{
			var person = await peopleRepo.GetById(id);
			if (person == null)
			{
				throw new Exception("Person is not found");
			}

			jsonPatch.ApplyTo(person);

			await peopleRepo.SaveChanges();

			return person;
		}
	}
}
