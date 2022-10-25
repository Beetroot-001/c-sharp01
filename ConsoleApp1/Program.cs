using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
	class Program
	{
		public static double Dist(double x1, double x2, double y1, double y2)
		{
			return Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2),2));
        }

		public static int StrSameness(string str1, string str2)
		{
			var str1group = str1.Split().GroupBy(x => x);
			var str2arr = str2.Split();


			return str1group.Aggregate(0, (cnt, curr) => str2arr.Contains(curr.Key) ? cnt++ : cnt);
		}

        static void Main(string[] args)
		{
			var people = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));

			//--== 1 ==--

			Person east = people.MaxBy(x => x.Longitude);
			Person west = people.MinBy(x => x.Longitude);
			Person north = people.MaxBy(x => x.Latitude);
			Person south = people.MinBy(x => x.Latitude);

			// --== 2 ==--

			var maxDist = people.Select(x => people.Max(a => Dist(x.Longitude, a.Longitude, x.Latitude, a.Latitude))).Max();
            var minDist = people.Select(x => people.Min(a => Dist(x.Longitude, a.Longitude, x.Latitude, a.Latitude))).Min();

			// --== 3 ==--

			(Person x1, Person x2) sameAbout = people.Select(x => (x,people.MaxBy(a => StrSameness(a.About, x.About)))).MaxBy(x => StrSameness(x.x.About, x.Item2.About));

			// --== 4 ==--

			var Friends = people.Aggregate(new List<Friend>(0), (acum, curr) => acum.Concat(curr.Friends.ToList()).ToList())
								.GroupBy(x => x)
								.ToDictionary(x => x.Key, a => new List<Person>())	
								.Select(x => (x.Key, people.Where(a => a.Friends.Contains(x.Key))))
								.ToDictionary(x => x.Key, x => x.Item2)
								.Where(x => x.Value.Count() > 1);
		}
	}
}
