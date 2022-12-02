namespace MyWebApi.Data
{
	public interface IPeopleRepo
	{
		Task<IEnumerable<Person>> GetAll();

		Task<Person> GetById(int id);

		Task<Person> Create(Person person);

		Task Delete(Person person);

		Task SaveChanges();
	}
}
