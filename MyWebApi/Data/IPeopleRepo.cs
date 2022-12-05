namespace MyWebApi.Data
{
	public interface IPeopleRepo : IDisposable
	{
		Task<IEnumerable<Person>> GetAll();

		Task<Person> GetById(int id);

		Task<Person> Create(Person person);

		Task Delete(Person person);

		Task SaveChanges();

		int Prop { get; set; }
	}
}
