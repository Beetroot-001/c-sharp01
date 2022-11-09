namespace ConsoleApp1
{
	internal class Program
	{
		public const string Exceptions = "sql1.txt";

		static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.Unicode;

			var students = new[]
			{
				//"Sergiy Kuziv",
				//"Oleh Slobodeniuk",
				"Serhii Kropotov",
				"Popov Artem",
				"Maryna Bohdanova",
				//"Balitskyi Vladyslav",
				"Andrii Kovalenko",
				"Ponomarienko Andrii",
				"Nataliia Tyshchenko",
				"Rushynets Oleksii",
				//"Viktoriya Tsaruk",
				// "Bas Serhii",
			};

			Console.WriteLine("\tThe game is started!");
			var randomizer = new Random((int)DateTime.Now.Ticks);

			var questions = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), Exceptions));
			var studentIndex = 0;

			foreach (var question in questions)
			{
				Console.WriteLine("-------------------");
				Console.WriteLine(question);

				Console.WriteLine("...");
				Thread.Sleep(300);
				Console.WriteLine("...");
				Thread.Sleep(300);
				Console.WriteLine("...");
				Thread.Sleep(300);

				var student = students[studentIndex];

				Console.WriteLine($"Answering: {student}");

				if (++studentIndex > students.Length - 1)
					studentIndex = 0;

				Console.WriteLine("Press 0 to exit, in another case - continue");
				var consoleKey = Console.ReadKey();
				if (consoleKey.Key == ConsoleKey.D0)
				{
					Environment.Exit(0);
				}

				Console.Clear();
			}
		}
	}
}