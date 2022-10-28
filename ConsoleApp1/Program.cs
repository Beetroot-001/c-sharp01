using Newtonsoft.Json;
using System.Globalization;
using System.Linq;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			//int[] ints = new[] { 1, 23, 45, 6, 7, };
			//var oddNumbers = ints.Where(x => x % 2 == 1).ToList();

			//var t = new
			//{
			//	a = 1,
			//	b = 2
			//};

			//var squaredNumbers = ints.Select(x => new { Number = x, Square = x * x }).ToList();

			//var anotherInts = new[] { 1, 1, 2, 3, 4, 5, 5 };
			//var groupedInts = anotherInts.GroupBy(x => x).ToDictionary(x => x.Key, x => x.ToList());


			//Console.WriteLine(string.Join(',', oddNumbers));
			//Console.WriteLine(string.Join(',', squaredNumbers));

			var people = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));

			// p1 p2
			// p1 p3
			// p1 ..
			// p2 p1
			// p2 p3
			// .....

			var sequence = people.Join(people, p => true, p => true, (p1, p2) => new
			{
				Person1 = p1,
				Person2 = p2,
			})
			.Where(x => x.Person1 != x.Person2)
			.Select(x =>
			{
				var personAboutWords1 = x.Person1.About.Split(' ');
				var personAboutWords2 = x.Person2.About.Split(' ');

				var sameWords = personAboutWords1.Intersect(personAboutWords2).ToList();
				return new
				{
					Person1 = x.Person1,
					Person2 = x.Person2,
					sameWords = sameWords
				};
			});

			var res = sequence.MaxBy(x => x.sameWords.Count);
			Console.WriteLine("P1: {0} P2 : {1}, Count: {2}", res.Person1, res.Person2, res.sameWords.Count);




			var males = people.Count(x => x.Gender == Gender.Male);
			Console.WriteLine($"Males: {males}");

			var females = people.Count(x => x.Gender == Gender.Female);
			Console.WriteLine($"Females: {females}");

			var grouped = people.GroupBy(x => x.Gender).ToDictionary(x => x.Key, x => x.Count());
			foreach (var item in grouped)
			{
				Console.WriteLine(item);
			}

			var youngest = people.Min(x => x.Age);
			var youngestPerson = people.MinBy(x => x.Age);
			Console.WriteLine($"Min age: {youngest}");

			var oldest = people.Max(x => x.Age);
			var oldestPerson = people.MaxBy(x => x.Age);
			Console.WriteLine($"Max age: {oldest}");

			var averageAge = people.Average(x =>
			{
				return x.Age;
			});
			Console.WriteLine($"Average age: {averageAge}");

			var nearestPerson = people.Select(x => new { Number = Math.Abs(x.Age - averageAge), person = x }).OrderBy(x => x.Number).First().person;
			Console.WriteLine();

			var isActiveCount = people.Count(x => x.IsActive);
			Console.WriteLine($"IsActiveCount : {isActiveCount}");

			CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
			var averageBalance = people.Average(x => decimal.Parse(x.Balance.Substring(1)));
			Console.WriteLine($"Avarage balance: {averageBalance}");

			var eyeColorGroups = people
				.GroupBy(x => x.EyeColor)
				.ToDictionary(x => x.Key, x => new { Count = x.Count() });

			var peopleWithSameName = people.GroupBy(x => x.Name.Split(' ')[0])
				.ToDictionary(x => x.Key, x => x);

			var firstRegistered = people.MinBy(x => x.Registered);
			var lastRegistered = people.MaxBy(x => x.Registered);

			//[ [1,2], [3], [4]]
			// [1,2,3,4]
			//
			var friends = people.Select(x => x.Friends);

			var res2 = Enumerable.Range(1, 5).Aggregate((current, accum) => current * accum);

			Console.WriteLine();


		}

		//Action<int> action = Method;

		//for (int i = 0; i < 10; i++)
		//{
		//	action(i);
		//}

		//public static void Method(int i)
		//{
		//	Console.WriteLine(i);
		//}


	}
}
