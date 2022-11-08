using System.Diagnostics;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter latitude:\t");
			string latitude = Console.ReadLine()?? throw new FormatException();

            Console.WriteLine("Enter longitude:\t");
            string longitude = Console.ReadLine() ?? throw new FormatException();

            var rezalt = SBas_homework_API.GetWeather(latitude, longitude).Result;

			Console.WriteLine($"Timezone:\t{rezalt.timezone.ToString()} |timezone_abbreviation:\t{rezalt.timezone.ToString()} |elevation:\t{rezalt.elevation}\n" +
                $"time:\t{rezalt.hourly_units.time.ToString()} |temperature:\t{rezalt.hourly_units.temperature_2m.ToString()}");
		}
	}
}