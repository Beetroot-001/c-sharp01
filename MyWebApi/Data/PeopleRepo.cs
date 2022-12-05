using Microsoft.EntityFrameworkCore;

namespace MyWebApi.Data
{
	public class PeopleRepo : IPeopleRepo, IDisposable
	{
		private readonly ApplicationDbContext dbContext;
		private bool disposedValue;

		public PeopleRepo(ApplicationDbContext applicationDbContext)
		{
			this.dbContext = applicationDbContext;
		}

		public int Prop { get; set; }

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

		public void Dispose()
		{
			if (!disposedValue)
			{
				this.dbContext.Dispose();
				disposedValue = true;
			}
		}
	}
}
