using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
	internal class Program
	{
		public static void method() { method(); }
		static void Main(string[] args)
		{
			Console.OutputEncoding = Encoding.Unicode;

			//string record = "Anatolii,Levchenko,023232323";

			//var res = Regex.Matches(record, @"\W+");

			//foreach (var match in res)
			//{
			//	Console.WriteLine(match.ToString());
			//}

			while (true)
			{
				try
				{
					DisplayMenu();
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Something bad happened, continue... {ex.GetType()}, Message : {ex.Message}");
					Console.WriteLine();
				}
			}
		}

		static void DisplayMenu()
		{
			var path = Path.Combine(Directory.GetCurrentDirectory(), "phonebook1.csv");

			Console.WriteLine("\tThis is phonebook app");

			Console.WriteLine("\t1. Display phone book records");
			Console.WriteLine("\t2. Add new record");
			Console.WriteLine("\t3. Search records");
			Console.WriteLine("\t4. Delete record");
			Console.WriteLine("\t0. Exit app");

			Console.Write("Operation: ");
			var pressedKey = Console.ReadKey();
			switch (pressedKey.Key)
			{
				case ConsoleKey.D1:
					//var records = ReadPhoneBookRecords(path);

					(string, string, string)[] records = new (string, string, string)[] { };
					bool isRead = TryReadPhoneBookRecords(path, ref records);
					if (isRead)
					{
						DisplayPhoneBook(records);
					}
					else
					{
						Console.WriteLine("Can not read records");
					}

					break;
				case ConsoleKey.D2:
					AddNewRecord(path);
					break;
				case ConsoleKey.D3:
					throw new NotSupportedException("Ще не зробили, спробуйте пізніше");
					// SearchRecords(path);
					break;
				case ConsoleKey.D4:
					Console.WriteLine();
					throw new NotImplementedException("Ще не зробили, спробуйте пізніше");
					break;
				case ConsoleKey.D5:
					Console.WriteLine();
					throw new NotImplementedException("Ще не зробили, спробуйте пізніше");
					break;
				case ConsoleKey.D0:
				default:
					Environment.Exit(0);
					break;
			}

			Console.ReadKey();
			Console.Clear();
		}

		static (string, string, string)[] ReadPhoneBookRecords(string path)
		{
			Console.WriteLine();
			if (string.IsNullOrEmpty(path))
			{
				var exception = new ArgumentException("Path can not be null or empty");
				var exception1 = new ArgumentNullException("Path can not be null or empty");
				var exception2 = new ArgumentOutOfRangeException("Path can not be null or empty");
				throw exception;
			}

			try
			{
				string[] records = File.ReadAllLines(path);
				(string, string, string)[] phoneBookRecords = new (string, string, string)[records.Length - 1];

				for (int i = 1; i < records.Length; i++)
				{
					var itemProperties = records[i].Split(',');

					phoneBookRecords[i - 1] = (itemProperties[0], itemProperties[1], itemProperties[2]);
				}

				return phoneBookRecords;
			}
			catch (FileNotFoundException ex)
			{
				Console.WriteLine($"Input/output Exception: {ex.Message}");
				Console.WriteLine($"Input/output Exception: {ex.StackTrace}");
				Console.WriteLine($"Input/output Exception: {ex.InnerException}");

				var ownException = new FileNotFoundException("File not found", ex);

				throw ownException;
			}
			catch (IOException ex)
			{
				Console.WriteLine($"Input/output Exception: {ex.Message}");

				throw;
			}
			finally
			{
				Console.WriteLine("Records are readed");
			}
		}

		static bool TryReadPhoneBookRecords(string path, ref (string, string, string)[] phoneBookRecords)
		{
			Console.WriteLine();
			if (string.IsNullOrEmpty(path))
			{
				var exception = new ArgumentException("Path can not be null or empty");
				throw exception;
			}

			try
			{
				string[] records = File.ReadAllLines(path);
				phoneBookRecords = new (string, string, string)[records.Length - 1];

				for (int i = 1; i < records.Length; i++)
				{
					var itemProperties = records[i].Split(',');

					phoneBookRecords[i - 1] = (itemProperties[0], itemProperties[1], itemProperties[2]);
				}

				return true;
			}
			catch (FileNotFoundException ex)
			{
				//Console.WriteLine($"Input/output Exception: {ex.Message}");
				//Console.WriteLine($"Input/output Exception: {ex.StackTrace}");
				//Console.WriteLine($"Input/output Exception: {ex.InnerException}");

				var ownException = new FileNotFoundException("File not found", ex);

				return false;
			}
			catch (IOException ex)
			{
				Console.WriteLine($"Input/output Exception: {ex.Message}");
				return false;
			}
			finally
			{
				//Console.WriteLine("Records are readed");
			}
		}

		static void DisplayPhoneBook((string firstName, string lastName, string phone)[] records)
		{
			Console.WriteLine();
			Console.WriteLine("List of phone book records");
			Console.WriteLine($"{"First Name",-15} {"Last Name",-15} {"Phone",-15}");

			foreach (var record in records)
			{
				Console.WriteLine($"{record.firstName,-15} {record.lastName,-15} {record.phone,-15}");
			}
		}

		static void AddNewRecord(string path)
		{
			Console.WriteLine();
			Console.WriteLine("Adding new record");

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
			Console.WriteLine("Searching records");
			Console.Write("Enter search string: ");
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