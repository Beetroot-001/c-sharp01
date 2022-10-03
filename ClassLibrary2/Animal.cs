namespace ClassLibrary2
{

	public enum EyeColor
	{
		Blue,
		Grey,
		Green,
		Yellow
	}

	public enum EatingStyle
	{
		Meat = 1,
		Grass,
		Omnivore
	}

	public enum Mood
	{
		Sad = 1,
		Happy,
		Neutral

	}

	public abstract class Animal : IAnimal, IMovable
	{
		public static int MyProperty { get; set; }
		protected EyeColor EyeColor { get; set; }
		public EatingStyle EatingStyle { get; set; }
		public bool IsAlive { get; set; }
		public Mood Mood { get; set; }

		public abstract string TotalWeight { get; set; }

		public Animal(EyeColor eyeColor)
		{
			EyeColor = eyeColor;
			Console.WriteLine("CTR Animal");
		}

		public int SuperAlgorithm()
		{
			// some logic
			Say();
			// some logic
			return MyProperty;
		}

		public abstract string Say();

		public void SayHi()
		{

		}

		void IAnimal.Move()
		{
			Console.WriteLine("MOVE IAnimal");
		}

		void IMovable.Move()
		{
			Console.WriteLine("MOVE Icat");
		}

		public void Eat()
		{
			throw new NotImplementedException();
		}

	}

	public class Dog : Animal, IMovable
	{
		public Dog(EyeColor eyeColor) : base(eyeColor)
		{
		}

		public override string TotalWeight
		{
			get
			{
				return ((int)Mood + (int)this.EatingStyle).ToString();
			}
			set
			{
				TotalWeight = value;
			}
		}

		public override string Say()
		{

			return null as string;
		}

		public void SayGoodBy(IPrinter printer)
		{
			printer.Print("Dog says: gaf-gaf");
		}
	}

	public interface IPrinter
	{
		void Print(string stringToPrint);
	}

	public class ConsolePrinter : IPrinter
	{
		public void Print(string stringToPrint)
		{
			Console.WriteLine(stringToPrint);
		}
	}

	public class FilePrinter
	{
		public void Print(string stringToPrint)
		{
			File.WriteAllText("", stringToPrint);
		}
	}
}