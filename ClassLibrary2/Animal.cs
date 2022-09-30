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
		Meat,
		Grass,
		Omnivore
	}

	public enum Mood
	{
		Sad,
		Happy,
		Neutral

	}

	public class Animal
	{
		public static int MyProperty { get; set; }
		protected EyeColor EyeColor { get; set; }
		public EatingStyle EatingStyle { get; set; }
		public bool IsAlive { get; set; }
		public Mood Mood { get; set; }

		public Animal(EyeColor eyeColor)
		{
			EyeColor = eyeColor;
			Console.WriteLine("CTR Animal");
		}

		public virtual int Say()
		{
			Console.WriteLine("Animal Say");
			return 0;
		}
	}

	public class Dog : Animal
	{
		public Dog(EyeColor eyeColor) : base(eyeColor)
		{
		}

		public new int Say()
		{
			Console.WriteLine("DOG Say: Bark");

			return 0;
		}
	}
}