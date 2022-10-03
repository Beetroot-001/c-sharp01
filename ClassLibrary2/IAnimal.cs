namespace ClassLibrary2
{
	public interface IAnimal
	{
		string TotalWeight { get; set; }
		void Move();
		void Eat();
	}

	interface IHiable
	{
		void SayHi();

	}

	class Fish : IAnimal
	{
		public string TotalWeight { get; set; }

		public void Eat()
		{

		}

		public void Move()
		{

		}

		public void SayHi()
		{
			throw new NotImplementedException();
		}
	}

	public interface IMovable
	{
		void Move();
	}
}
