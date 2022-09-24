namespace ConsoleApp1
{
	class Person
	{
		public static int PersonInstancesCount = 0;

		public static string Description;

		public const int DEFAULT_AGE = 18;

		public string firstName = "No name (default)";
		public string FirstName
		{
			get { return this.firstName; }
			set
			{
				if (value.Length > 10)
				{
					throw new ArgumentOutOfRangeException("First name can not be > 10");
				}
				firstName = value;
			}
		}

		public string LastName { get; set; }

		public Person()
		{
			PersonInstancesCount++;

			this.firstName = "No name";

			Console.WriteLine("INSTANCE");
		}

		static Person()
		{
			Description = "Here is description";
			Console.WriteLine("STATIC");
		}

		public Person(string FirstName, string lastName)
		{
			PersonInstancesCount++;
			this.firstName = FirstName;
			this.LastName = lastName;
			Console.WriteLine("INSTANCE");
		}

		public Person(string FirstName, string lastName, int age) : this(FirstName, lastName)
		{
			this.firstName = FirstName;
			this.LastName = lastName;
			this.Age = age;
		}


		public int Age { get; }

		public string FullName
		{
			get
			{
				return $"{FirstName} {LastName}";
			}
		}


		public void Display()
		{
			Console.WriteLine(DEFAULT_AGE);
			Console.WriteLine(FullName);
		}

		static void DisplayInstancesCreatedCount()
		{
			Console.WriteLine(PersonInstancesCount);
		}
	}
}
