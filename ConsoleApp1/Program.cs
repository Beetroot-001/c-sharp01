using ClassLibrary2;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{

			//var animal = new Animal();

			//var dog = new Dog();

			Cat cat = new Cat(EyeColor.Green);
			Animal animalCat = new Cat(EyeColor.Blue);
			Animal animalDog = new Dog(EyeColor.Blue);

			cat.Say();
			animalCat.Say();
			animalDog.Say();

			bool isDog = animalDog is Dog;
			Dog anotherDog = (Dog)animalCat;

			anotherDog.Say();

			Console.WriteLine(cat);

			Console.WriteLine("Hash codes");

			var cat1 = new Cat(EyeColor.Grey)
			{
				Breed = Breed.Siamese,
				EatingStyle = EatingStyle.Omnivore,
				Mood = Mood.Happy
			};

			var cat2 = new Cat(EyeColor.Grey)
			{
				Breed = Breed.Siamese,
				EatingStyle = EatingStyle.Omnivore,
				Mood = Mood.Happy
			};

			var cat3 = new Cat(EyeColor.Blue)
			{
				Breed = Breed.Siamese,
				EatingStyle = EatingStyle.Grass,
				Mood = Mood.Neutral
			};

			Console.WriteLine($"{cat1.GetHashCode()} {cat2.GetHashCode()}");
			Console.WriteLine($"{cat1.GetHashCode()} {cat3.GetHashCode()}");
			Console.WriteLine(cat1.Equals(cat2));
			Console.WriteLine(cat1.Equals(cat3));
			Console.WriteLine(cat2.Equals(cat3));
			Console.WriteLine(cat2.Equals(new Dog(EyeColor.Yellow)));
		}
	}

	public enum Breed
	{
		Siamese,
		Asian,
		Ashera
	}


	public class Cat : Animal
	{
		public Breed Breed { get; set; }

		public Cat(EyeColor eyeColor) : base(eyeColor)
		{
			Console.WriteLine("CTR Cat");
		}

		public override int Say()
		{
			Console.WriteLine("Cat SAY");
			return 0;
		}

		public void Move()
		{
			throw new NotImplementedException();
		}


		public override string ToString()
		{
			return $"Breed {Breed} EyeColor {EyeColor}";
		}

		public override int GetHashCode()
		{
			return 17 * (int)Breed ^ (int)EyeColor ^ (int)Mood ^ (int)EatingStyle;
		}

		public override bool Equals(object? obj)
		{
			// check null

			if (obj == null)
			{
				return false;
			}

			if (ReferenceEquals(this, obj))
			{
				return true;
			}

			Cat other = obj as Cat;
			if (other == null) return false;

			return other.EyeColor == EyeColor && other.IsAlive == IsAlive && other.Breed == Breed;
		}
	}
}