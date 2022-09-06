namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			byte a = 1;
			short b = 10;
			int c = 10;
			//long d = 777;
			bool e = true;
			char f = 'a';
			float g = 3.14f; 
			double k = 5;
			//decimal l = 5.5;
			string m = "SSS"; 
			Console.ReadLine();

			Console.WriteLine(a - b + c + k);
			Console.WriteLine(e);
			Console.WriteLine(g);
			Console.WriteLine(f+m);
			Console.ReadLine();

			int x = 10;
			int y = 18;
			var result1 = Math.Abs(x)*Math.Sin(x);
			Console.WriteLine($"Math.Abs(x)*Math.Sin(x) = {result1}");
			Console.ReadLine();

			var result2 = 2* Math.PI * x;
			Console.WriteLine($"2* Math.PI * x = {result2}");
			Console.ReadLine();

			var result3 = Math.Max(x,y);
			Console.WriteLine($"Math.Max(x,y) = {result3}");
			Console.ReadLine();

			var result4 = -6*Math.Pow(x,3)+5*Math.Pow(x,2)-10*x+15;
			Console.WriteLine($"6*Math.Pow(x,3)+5*Math.Pow(x,2)-10*x+15 = {result4}");
			Console.ReadLine();

			DateTime newYear = new DateTime(2023,01,01);
			var leftToNewYear = newYear - DateTime.Now.Date;

			Console.WriteLine($"{newYear} newYear");
			Console.WriteLine($"{DateTime.Now.Date} DateTime.Now.Date");

			Console.WriteLine($"{leftToNewYear.Days} days left to New Year");
			Console.ReadLine();

			DateTime startYearDate = new DateTime(2022, 01, 01);
			DateTime today = DateTime.Now.Date;
			var passedFromNewYear = today -  startYearDate;
			Console.WriteLine($"{passedFromNewYear.Days}  days passed from New Year");
			Console.ReadLine();
		}
	}
}