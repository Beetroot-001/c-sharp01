using System.Text.RegularExpressions;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{

			string record = "Anatolii,Levchenko,023232323";

			var res = Regex.Matches(record, @"\W+");

			foreach (var match in res)
			{
				Console.WriteLine(match.ToString());
			}


			while (true)
			{
				DisplayMenu();
			}
		}

		static void DisplayMenu()
		{
			var path = Path.Combine(Directory.GetCurrentDirectory(), "phonebook.csv");


			Console.WriteLine("\tThis is phonebook app");

			Console.WriteLine("\t1. Display phone book records");
			Console.WriteLine("\t2. Add new record");
			Console.WriteLine("\t3. Search records");
			Console.WriteLine("\t0. Exit app");

			var pressedKey = Console.ReadKey();
			switch (pressedKey.Key)
			{
				case ConsoleKey.D1:
					var records = ReadPhoneBookRecords(path);

					DisplayPhoneBook(records);
					break;
				case ConsoleKey.D2:
					AddNewRecord(path);
					break;
				case ConsoleKey.D3:
					SearchRecords(path);
					break;
				case ConsoleKey.D0:
				default:
					Environment.Exit(0);
					break;
			}

			Console.ReadKey();
			//Console.Clear();

		}

		static (string, string, string)[] ReadPhoneBookRecords(string path)
		{
			Console.WriteLine();
			string[] records = File.ReadAllLines(path);
			(string, string, string)[] phoneBookRecords = new (string, string, string)[records.Length - 1];

			for (int i = 1; i < records.Length; i++)
			{
				var itemProperties = records[i].Split(',');

				phoneBookRecords[i - 1] = (itemProperties[0], itemProperties[1], itemProperties[2]);
			}

			return phoneBookRecords;
		}

		static void DisplayPhoneBook((string firstName, string lastName, string phone)[] records)
		{
			Console.WriteLine();
			Console.WriteLine($"{"First Name",-15} {"Last Name",-15} {"Phone",-15}");

			foreach (var record in records)
			{
				Console.WriteLine($"{record.firstName,-15} {record.lastName,-15} {record.phone,-15}");
			}
		}

		static void AddNewRecord(string path)
		{
			Console.Write("First Name: ");
			var firstName = Console.ReadLine();

			Console.Write("Last Name: ");
			var lastName = Console.ReadLine();

			Console.Write("Phone: ");
			var phone = Console.ReadLine();

			string[] newRecords = new[] { string.Join(',', new[] { firstName, lastName, phone }) };

			File.AppendAllLines(path, newRecords);
		}

		static void SearchRecords(string path)
		{
			Console.WriteLine();
			Console.WriteLine("Enter search string: ");
			string searchText = Console.ReadLine() ?? "";

			(string firstName, string lastName, string phone)[] phoneBookRecords = ReadPhoneBookRecords(path);


			//(string firstName, string lastName, string phone)[] searchedRecords = new (string firstName, string lastName, string phone)[phoneBookRecords.Length];

			Console.WriteLine($"{"First Name",-15} {"Last Name",-15} {"Phone",-15}");
			foreach (var record in phoneBookRecords)
			{
				if (record.lastName.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
					record.firstName.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
					record.phone.Contains(searchText, StringComparison.OrdinalIgnoreCase))
				{
					Console.WriteLine($"{record.firstName,-15} {record.lastName,-15} {record.phone,-15}");
				}
			}

			//DisplayPhoneBook(searchedRecords);
		}
	}
}