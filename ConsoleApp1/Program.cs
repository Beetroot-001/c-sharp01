namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// if
			int number = 6;

			if (number > 5 && number < 10 && number < 2)
			{
				Console.WriteLine("number between 5 and 10");
			}
			else if (number < 5)
			{
				Console.WriteLine("number < 5");
			}
			else
			{
				Console.WriteLine("number  = 5");
			}

			// switch

			number = 8;
			int newNumber = 0;
			switch (number)
			{
				default:
					newNumber = 0;
					break;
				case 5:
				case 8:
					newNumber = 5;
					break;
			}

			newNumber = 0;

			object dateTime = DateTime.Now;
			newNumber = dateTime switch
			{
				DateTime => 3,
				int => 4,
				_ => 0
			};

			Console.WriteLine(newNumber);

			// ternary operator
			int num = 5;
			int res = 0;
			if (num > 3)
			{
				res = num * 2;
			}
			else
			{
				res = num + 2;
			}
			Console.WriteLine("IF res = " + res);

			res = num > 3 ? num * 2 : num + 2;
			Console.WriteLine("??? res = " + res);

			// null coalescing operator
			object obj1 = null;
			if (obj1 == null)
			{
				obj1 = new object();
			}

			obj1 = null;
			obj1 = obj1 ?? new object();


			// loops
			Console.WriteLine("----loops-----");
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine($"Index: {i}");
			}

			int j = 0;
			while (j < 10)
			{
				Console.WriteLine($" WHILE Index: {j}");

				j++;
			}

			int x = 0;

			do
			{
				Console.WriteLine($"Do WHILE Index: {x}");
				x++;
			} while (x < 10);

			Console.WriteLine("break//////////////");
			for (int i = 0; i < 10; i++)
			{
				if (i > 5)
				{
					Console.WriteLine($"Before continue index: {i}");
					break;
					Console.WriteLine($"After continue index: {i}");

				}

				if (i > 5)
				{
					break;
				}

				Console.WriteLine($"index: {i}");
			}

			for (int i = 0; i <= 100; i = i + 2)
			{
				Console.WriteLine("Ok ??");
			}


			//int number2;
			//while (!int.TryParse(@string, out number2))
			//{
			//	Console.WriteLine("Can not parse try again");
			//	@string = Console.ReadLine();
			//}

			bool parseResult;
			int number2;
			do
			{
				string @string = Console.ReadLine();
				parseResult = int.TryParse(@string, out number2);
				Console.WriteLine("Can not parse try again");
			} while (!parseResult);
			Console.WriteLine("Parsed " + number2);
		}
	}
}