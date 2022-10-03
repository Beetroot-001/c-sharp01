using ClassLibrary2;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//var animal = new Animal(); // imposible to create abstract class instances

			Cat cat = new Cat(EyeColor.Green);
			IMovable mCat = cat;
			mCat.Move();
			IAnimal aCat = cat;
			aCat.Move();
			
			IAnimal animalCat = new Cat(EyeColor.Blue)
			{
				Breed = Breed.Ashera,
				EatingStyle = EatingStyle.Grass
			};
			IAnimal animalDog = new Dog(EyeColor.Blue)
			{
				EatingStyle = EatingStyle.Grass,
				Mood = Mood.Happy
			};

			animalCat.Move();

			IMovable movableCat = (IMovable)animalCat;

			movableCat.Move();


			cat.Say();

			bool isDog = animalDog is Dog;
			//Dog anotherDog = (Dog)animalCat;

			//anotherDog.Say();

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

			DoSomethighWithAnimal(cat);
			DoSomethighWithAnimal(animalDog);

			Console.WriteLine(animalCat.TotalWeight);
			Console.WriteLine(animalDog.TotalWeight);

			Console.WriteLine($"{cat1.GetHashCode()} {cat2.GetHashCode()}");
			Console.WriteLine($"{cat1.GetHashCode()} {cat3.GetHashCode()}");
			Console.WriteLine(cat1.Equals(cat2));
			Console.WriteLine(cat1.Equals(cat3));
			Console.WriteLine(cat2.Equals(cat3));
			Console.WriteLine(cat2.Equals(new Dog(EyeColor.Yellow)));

			var dog12 = new Dog(EyeColor.Blue);
			var consolePrinter = new ConsolePrinter();

			dog12.SayGoodBy(consolePrinter);
		}


		static void DoSomethighWithAnimal(IAnimal animal)
		{
			Console.WriteLine(animal.TotalWeight);
			animal.SayHi();
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

		public override string TotalWeight
		{
			get
			{
				return ((int)Mood + (int)this.Breed).ToString();
			}
			set
			{
				TotalWeight = value;
			}
		}

		public override string Say()
		{
			return "Cat says: meow";
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