namespace ConsoleApp1
{
    class Worker
	{
		private string _name;
		private string _surname;
		private string _middlename;
		private int _age;
		protected bool _atWork;
        protected int _salary;

		public string Name => _name;
		public string Surname => _surname;
		public string MiddleName => _middlename;
		public bool AtWork => _atWork;
		public int Age => _age;
		public int Salary => _salary;

		public Worker(string name, string surname, string middleName, int age)
		{
			_name = name;
			_surname = surname;
			_middlename = middleName;
			_age = age;
			_atWork = true;
			_salary = 1000;
		}

		public virtual void Work()
		{
			_atWork = true;
			Console.WriteLine("Worker is working!");
		}

		public virtual void GoHome()
		{
			_atWork = false;
			Console.WriteLine("Worker went home!");
		}

	}
    class Mechanic : Worker
    {
        public Mechanic(string name, string surname, string middleName, int age) : base(name, surname, middleName, age)
        {
            _salary = 2000;
        }

        public override void Work()
        {
            _atWork = true;
            Console.WriteLine("Mechanic is working!");
        }
        public override void GoHome()
        {
            _atWork = false;
            Console.WriteLine("Mechanic went home!");
        }
    }

    class LeadMechanic : Mechanic
    {
        public LeadMechanic(string name, string surname, string middleName, int age) : base(name, surname, middleName, age)
        {
            _salary = 3000;
        }
        public override void Work()
        {
            _atWork = true;
            Console.WriteLine("Lead is working!");
        }
        public override void GoHome()
        {
            _atWork = false;
            Console.WriteLine("Lead went home!");
        }
    }

    class Janitor : Worker
    {
        public Janitor(string name, string surname, string middleName, int age) : base(name, surname, middleName, age)
        {
            _salary = 1200;
        }
        public override void Work()
        {
            _atWork = true;
            Console.WriteLine("Janitor is cleaning!");
        }
        public override void GoHome()
        {
            _atWork = false;
            Console.WriteLine("Janitor went home!");
        }

    }
}