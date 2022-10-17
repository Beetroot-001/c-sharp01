namespace ConsoleApp1
{
	internal class Program
	{

        public delegate void Message();

		public static void Greeting()
		{
			Console.WriteLine("Hello");
		}
		
		public static void Greeting2()
		{
			Console.WriteLine("Motherfucker");
		}

		public static void Calc(int a, int b, string name)
		{
			int result = a + b;

			Console.WriteLine($"{name}, your result is {result}");
		}

		public static bool Fair(int a)
		{
			if (a%2 == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static int Calculate (int a)
		{
			return a * 5;
		}


		static void Main(string[] args)
		{
			Message mes;

			//mes = Greeting;
			//mes += Greeting2;

			//mes.Invoke();

			//Action<int, int, string> action = Calc;
			//Predicate<int> isFair;

			//isFair = Fair;

			//Console.WriteLine(isFair.Invoke(6));


			Func<int, int> func;

			func = Calculate;

			Console.WriteLine(func.Invoke(4));
		}
	}
}