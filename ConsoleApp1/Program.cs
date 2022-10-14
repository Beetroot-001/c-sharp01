using System.Collections;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var list = new List<int>();

			list.Add(1);
			list.Add(2);
			list.Add(3);
			Console.WriteLine($"Count: {list.Count}");
			Console.WriteLine($"Capacity: {list.Capacity}");
			list.Add(3);
			list.Add(3);
			Console.WriteLine($"Count: {list.Count}");
			Console.WriteLine($"Capacity: {list.Capacity}");

			list.AddRange(new[] { 5, 6, 7 });

			DisplayCollection(list);

			Console.WriteLine($"Contains 5: {list.Contains(5)}");

			int[] ints = new int[list.Count];
			list.CopyTo(ints);

			list.Insert(3, 33);
			list.Insert(3, 33);

			Console.WriteLine($"Remove 33: {list.Remove(33)}");
			Console.WriteLine($"Remove 33: {list.Remove(33)}");

			Console.WriteLine("Before reverse");
			DisplayCollection(list);
			list.Reverse();
			Console.WriteLine("After reverse");
			DisplayCollection(list);

			list.Clear();
			DisplayCollection(list);
			Console.WriteLine($"Count: {list.Count}");
			Console.WriteLine($"Capacity: {list.Capacity}");


			HashSet<int> hashSetInts = new HashSet<int>();
			hashSetInts.Add(1);
			hashSetInts.Add(2);
			hashSetInts.Add(3);
			hashSetInts.Add(4);

			DisplayCollection(hashSetInts);
			hashSetInts.Add(3);
			DisplayCollection(hashSetInts);

			hashSetInts.UnionWith(new[] { 3, 4, 5 });

			HashSet<Person> hashSetPersons = new HashSet<Person>();
			hashSetPersons.Add(new Person
			{
				Age = 18,
				Fullname = "A A"
			});

			hashSetPersons.Add(new Person
			{
				Age = 22,
				Fullname = "B B"
			});

			hashSetPersons.Add(new Person
			{
				Age = 22,
				Fullname = "B B"
			});

			DisplayCollection(hashSetPersons);


			Dictionary<string, Person> personDictionary = new Dictionary<string, Person>();

			personDictionary.Add("1213123", new Person() { Age = 1, Fullname = "C C" });
			personDictionary.TryAdd("1213123", new Person() { Age = 1, Fullname = "C C" });

			personDictionary["1213123"] = new Person() { Age = 1, Fullname = "C C" };

			DisplayCollection(personDictionary);


			var person1 = new Person() { Age = 18, Fullname = "Ivan Ivan" };
			var person2 = new Person() { Age = 16, Fullname = "Taras" };
			var person3 = new Person() { Age = 22, Fullname = "Mykola" };
			var person4 = new Person() { Age = 45, Fullname = "Petro" };

			var listPersons = new List<Person>();
			listPersons.Add(person1);
			listPersons.Add(person2);
			listPersons.Add(person3);
			listPersons.Add(person4);

			//var enumerable = new Person18YOEnumerable(listPersons);

			//foreach (var person in enumerable)
			//{
			//	Console.WriteLine(person);
			//}

			var enumerable = new Person18YOEnumerable(new PersonWithLetterAEnumerable(listPersons));

			IEnumerator<Person> test = ((IEnumerable<Person>)listPersons).GetEnumerator();

			var enumerator = enumerable.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Console.WriteLine(enumerator.Current);
				}
			}
			finally
			{
				enumerator.Dispose();
			}
		}

		public static IEnumerable<Person> Get18YOPersons(IEnumerable<Person> people)
		{
			foreach (var person in people)
			{
				if (person.Age > 18)
				{
					yield return person;
				}
			}
		}


		public static void DisplayCollection<T>(IEnumerable<T> values)
		{
			Console.WriteLine("----Collection----");
			foreach (var value in values)
			{
				Console.Write($"{value}, ");
			}
			Console.WriteLine();
		}
	}

	public class Person : IEquatable<Person>
	{
		public int Age { get; set; }
		public string Fullname { get; set; }

		public override string ToString()
		{
			return $"{{Age: {Age}, FullName: {Fullname}}}";
		}

		public override int GetHashCode()
		{
			HashCode hashCode = new HashCode();
			hashCode.Add(Age);
			hashCode.Add(Fullname);

			return hashCode.ToHashCode();
		}

		public override bool Equals(object? obj)
		{
			if (obj != null && obj is Person)
			{
				return Equals(obj);
			}

			return false;
		}

		public bool Equals(Person? other)
		{
			return this.Age == other.Age && this.Fullname == other.Fullname;
		}
	}

	public class PersonWithLetterAEnumerable : IEnumerable<Person>
	{
		private readonly IEnumerable<Person> people;

		public PersonWithLetterAEnumerable(IEnumerable<Person> people)
		{
			this.people = people;
		}

		public IEnumerator<Person> GetEnumerator()
		{
			throw new Exception();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}


	public class Person18YOEnumerable : IEnumerable<Person>
	{
		private readonly IEnumerable<Person> people;

		public Person18YOEnumerable(IEnumerable<Person> people)
		{
			this.people = people;
		}

		public IEnumerator<Person> GetEnumerator()
		{
			return new Person18YOEnumerator(people.GetEnumerator());
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	public class Person18YOEnumerator : IEnumerator<Person>
	{
		private readonly IEnumerator<Person> persons;

		public Person18YOEnumerator(IEnumerator<Person> persons)
		{
			this.persons = persons;
		}

		public Person Current { get; private set; }

		object IEnumerator.Current => Current;

		public bool MoveNext()
		{
			while (persons.MoveNext())
			{
				if (persons.Current.Age > 18)
				{
					Current = persons.Current;
					return true;
				}
			}

			return false;
		}

		public void Reset()
		{
			persons.Reset();
		}

		public void Dispose()
		{
			Reset();
		}
	}
}