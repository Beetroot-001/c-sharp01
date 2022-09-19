namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var students = new[]
			{
				"Sergiy Kuziv",
				"Oleh Slobodeniuk",
				"Serhii Kropotov",
				"Popov Artem",
				"Maryna Bohdanova",
				"Balitskyi Vladyslav",
				"Andrii Kovalenko",
				"Ihor Kovalchuk",
				"Ponomarienko Andrii",
				"Nataliia Tyshchenko",
				"Rushynets Oleksii",
				"Viktoriya Tsaruk",
				"Bas Serhii",
			};

			Console.WriteLine("\tThe game is started!");
			var randomizer = new Random((int)DateTime.Now.Ticks);

			while (true)
			{
				Console.WriteLine("Press 0 to exit, in another case - continue");
				var consoleKey = Console.ReadKey();
				if (consoleKey.Key == ConsoleKey.D0) Environment.Exit(0);

				Console.Clear();
				Console.WriteLine("...");
				Thread.Sleep(300);
				Console.Clear();
				Console.WriteLine("...");
				Thread.Sleep(300);
				Console.Clear();
				Console.WriteLine("...");
				Thread.Sleep(300);
				Console.Clear();
				Console.WriteLine($"Answering: {students[randomizer.Next(0, students.Length)]}");
			}
		}
	}
}