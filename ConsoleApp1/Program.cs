using Newtonsoft.Json;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));
		}
	}
}
