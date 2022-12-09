using System.Collections.Generic;

namespace MyWebApi.Data
{
	public class Person
	{
		public int Id { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }

		public int Age { get; set; }

		public ICollection<Person> Friends { get; set; }

		public Status Status { get; set; }
		public int StatusId { get; set; }
	}
}
