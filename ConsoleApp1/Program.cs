namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			byte a = 5;
			short b = 3;
			int c = 4;
			long d = 550;
			bool e = false;
			char f = 'S';
			float g = 3.14f;
			double h = 8;
			decimal j = 7.91M;
			string k = "tring";
			Console.ReadLine();

			Console.WriteLine($"Adding and subtraction (a + c - b)= {a + c - b}");
			Console.WriteLine($"Multiplication (a * b)= {a * b}");
			Console.WriteLine($"g = {g}"); 
			Console.WriteLine($"f + k = {f+k}");
            Console.ReadLine();

            int x = 3;
            int y = 4;

            var ex1 = -6 * Math.Pow(x, 3) + 5 * Math.Pow(x, 2) - 10 * x + 15;
            Console.WriteLine($"The first example (-6*x^3+5*x^2-10*x+15) = {ex1}");
            Console.ReadLine();

            var ex2 = Math.Abs(x) * Math.Sin(x);
            Console.WriteLine($"The second example (abs(x)*sin(x)) = {ex2}");
            Console.ReadLine();

            var ex3= 2 * Math.PI * x;
            Console.WriteLine($"The thirdth example (2*pi*x) = {ex3}");
            Console.ReadLine();

            var ex4 = Math.Max(x, y);
            Console.WriteLine($"The last example (max(x, y)) = {ex4}");
            Console.ReadLine();

            DateTime newYear = new DateTime(2023, 1, 1);
            var leftToNewYear = newYear - DateTime.Now.Date;
            Console.WriteLine($"NewYearDate {newYear}");
            Console.WriteLine($"DateTimeNow:{DateTime.Now.Date} ");
            Console.WriteLine($" Days left to The New Year:{leftToNewYear.Days} ");
            DateTime PreviousYearDate = new DateTime(2022, 1, 1);
            DateTime today = DateTime.Now.Date;
            var passedFromNewYear = today - PreviousYearDate;
            Console.WriteLine($"Days passed from  The New Year: {passedFromNewYear.Days} ");
            Console.ReadLine();
            







        }
    }
}
