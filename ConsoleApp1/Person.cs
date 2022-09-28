namespace ConsoleApp1
{
	class Person
	{
		public static int PersonInstancesCount = 0;

		public static string Description;

		public const int DEFAULT_AGE = 18;
		public const string ConstDefaultName = "";
		public readonly string DefaultName;

		private string _firstName = "No name (default)";

		public string FirstName
		{
			get { return this._firstName; }
			set
			{
				if (value.Length > 10)
				{
					throw new ArgumentOutOfRangeException("First name can not be > 10");
				}
				_firstName = value;
			}
		}

		public string LastName { get; set; } = "INIT 1";

		public Person()
		{
			PersonInstancesCount++;

			this._firstName = "No name";
			LastName = "INIT2";

			Console.WriteLine("INSTANCE");
		}

		static Person()
		{
			Description = "Here is description";
			Console.WriteLine("STATIC");

		}

		public Person(string FirstName, string lastName, string defaultName)
		{
			PersonInstancesCount++;
			this._firstName = FirstName;
			this.LastName = lastName;
			Console.WriteLine("INSTANCE");

			DefaultName = defaultName;
		}

		public Person(string FirstName, string lastName, int age) : this(FirstName, lastName, "")
		{
			this._firstName = FirstName;
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
			set
			{
				var array = value.Split(' ');

				FirstName = array[0];
				LastName = array[1];
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
