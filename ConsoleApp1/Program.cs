using ConsoleApp1.Test;

namespace ConsoleApp1
{
	public class Program
	{
		static void Main(string[] s)
		{
			//System.Timers.Timer timer = new System.Timers.Timer(2000);

			//timer.Start();

			//timer.Elapsed += (obj, e) =>
			//{
			//	var readedString = Console.ReadLine();
			//	Console.WriteLine("Readed: " + readedString);
			//};

			//Thread.Sleep(Timeout.Infinite);

			var program = new Program();
			program.WordCount("asd");

			var str = "word1 test, abs";

			Console.WriteLine(str.WordCount());
			Console.WriteLine(str.WordCount(specificWord: "test"));

			Console.WriteLine(StringExtensions.WordCount(str, "test"));
			Console.WriteLine(StringExtensions.WordCount<int>(6, "test"));

			int[] ints = new[] { 1, 2, 3, 4, 5, 6 };
			var result = ints.ChunkBy(3);

			DisplayCollection(result);

			Console.WriteLine("0".ToBool());
			Console.WriteLine("1".ToBool());
			Console.WriteLine("y".ToBool());
			Console.WriteLine("yes".ToBool());

			// Exception : Console.WriteLine("01".ToBool());

			var birthDay = new DateTime(1998, 12, 1);
			Console.WriteLine(birthDay.GetAge());

			Console.WriteLine(new DateTime(2022, 10, 19).IsWeekend());
			Console.WriteLine(new DateTime(2022, 10, 22).IsWorkDay());
			Console.WriteLine(new DateTime(2022, 10, 23).IsWeekend());
			Console.WriteLine(new DateTime(2022, 10, 24).IsWorkDay());

			var d1 = new DateTime(2022, 10, 19).GetNextWorkDay();
			var d2 = new DateTime(2022, 10, 22).GetNextWorkDay();
			var d3 = new DateTime(2022, 10, 23).GetNextWorkDay();
			var d4 = new DateTime(2022, 10, 24).GetNextWorkDay();

			var groups = ints.MyGroupBy((el) => el % 2);

			foreach (var item in GetStrings())
			{
				Console.WriteLine(item);
			}
		}

		public static void DisplayCollection<T>(IEnumerable<T> values)
		{
			var res = string.Join(',', values);

			Console.WriteLine(res);
		}

		public static void DisplayCollection<T>(IEnumerable<IEnumerable<T>> values)
		{
			foreach (var item in values)
			{
				DisplayCollection(item);
			}
		}

		public static IEnumerable<string> GetStrings()
		{
			yield return "1";
			yield return "2";
			yield return "3";
		}
	}
}