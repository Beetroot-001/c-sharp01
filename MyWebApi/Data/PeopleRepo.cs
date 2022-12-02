using Microsoft.EntityFrameworkCore;

namespace MyWebApi.Data
{
	public class PeopleRepo : IPeopleRepo
	{
		private readonly ApplicationDbContext dbContext;

		public PeopleRepo(ApplicationDbContext applicationDbContext)
		{
			this.dbContext = applicationDbContext;
		}

		public async Task<Person> Create(Person person)
		{
			dbContext.Add(person);

			await dbContext.SaveChangesAsync();

			return person;
		}

		public async Task Delete(Person person)
		{
			dbContext.Remove(person);

			await dbContext.SaveChangesAsync();
		}

		public async Task<IEnumerable<Person>> GetAll()
		{
			var people = await dbContext.People.AsNoTracking().ToListAsync();

			return people;
		}

		public Task<Person> GetById(int id)
		{
			return dbContext.People.FirstOrDefaultAsync(x => x.Id == id);
		}

		public Task SaveChanges()
		{
			return dbContext.SaveChangesAsync();
		}
	}
}
