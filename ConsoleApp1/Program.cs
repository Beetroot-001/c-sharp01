using Newtonsoft.Json;
using System.Globalization;
using System.Linq;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));

			//find out who is located farthest north/south/west/east using latitude/longitude data
			var north = persons.MinBy(x => x.Longitude);
			var south = persons.MaxBy(x => x.Longitude);
			var west = persons.MinBy(x => x.Latitude);
			var east = persons.MaxBy(x => x.Latitude);

			//find max and min distance between 2 persons
			var distances = persons.SelectMany(x => persons.Where(x1 => x != x1).Select(y => GetDistance(x, y))).ToList();
			var max = distances.Max();
			var min = distances.Min();


			//find 2 persons whos ‘about’ have the most same words
			var about = persons.Join(persons, p1 => true, p2 => true, (p1, p2) => new
			{
				Person1 = p1,
				Person2 = p2,
			})
			.Where(x => x.Person1 != x.Person2)
			.Select(x =>
			{
				var personAboutWords1 = x.Person1.About.Split(' ');
				var personAboutWords2 = x.Person2.About.Split(' ');

				var sameWords = personAboutWords1.Intersect(personAboutWords2);
				return new
				{
					Person1 = x.Person1,
					Person2 = x.Person2,
					sameWords = sameWords,
				};
			});

			//find persons with same friends(compare by friend’s name)
			var same = persons.Join(persons, p1 => true, p2 => true, (p1, p2) => new
			{
				Person1 = p1,
				Person2 = p2,
			})
			.Where(x => x.Person1 != x.Person2)
			.Select(x =>
			{
				var person1 = x.Person1;
				var person2 = x.Person2;

				var sameFriends = person1.Friends.Select(x => x.Name).Intersect(person2.Friends.Select(x => x.Name));
				return new
				{
					Person1 = x.Person1,
					Person2 = x.Person2,
					sameFriends = sameFriends,
				};
			});
		}

		public static double GetDistance(Person one, Person two)
		{
			return Math.Sqrt(Math.Pow((one.Longitude - two.Longitude), 2) + Math.Pow((one.Latitude - two.Latitude), 2));
		}
	}
}
