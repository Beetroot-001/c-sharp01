using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.XPath;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

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
            var path = Path.Combine(Directory.GetCurrentDirectory(), "phonebook.csv");
            if (!File.Exists(path))
                throw new FileNotFoundException("File with records not found");

            Console.WriteLine("\tThis is phonebook app");

            Console.WriteLine("\t1. Display phone book records");
            Console.WriteLine("\t2. Add new record");
            Console.WriteLine("\t3. Search records");
            Console.WriteLine("\t4. Delete record");
            Console.WriteLine("\t5. Sort records");
            Console.WriteLine("\t6. Binary search");
            Console.WriteLine("\t0. Exit app");

            Console.Write("Operation: ");
            var pressedKey = Console.ReadKey();
            switch (pressedKey.Key)
            {
                case ConsoleKey.D1:
                    DisplayPhoneBook(path);
                    break;
                case ConsoleKey.D2:
                    AddNewRecord(path);
                    break;
                case ConsoleKey.D3:
                    SearchRecords(path);
                    break;
                case ConsoleKey.D4:
                    DeleteRecords(path);
                    break;
                case ConsoleKey.D5:
                    SortRecords(path);
                    break;
                case ConsoleKey.D6:
                    BinarySearch(path);
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

            string[] records = File.ReadAllLines(path);
            (string, string, string)[] phoneBookRecords = new (string, string, string)[records.Length - 1];

            for (int i = 1; i < records.Length; i++)
            {
                var itemProperties = records[i].Split(',');

                phoneBookRecords[i - 1] = (itemProperties[0], itemProperties[1], itemProperties[2]);
            }

            return phoneBookRecords;
        }
        static void DisplayPhoneBook(string path)
        {
            (string firstName, string lastName, string phone)[] records = ReadPhoneBookRecords(path);

            if (records.Length == 0)
            {
                Console.WriteLine("There is no records in phonebook");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("List of phone book records");
            Console.WriteLine($"{"",-5}{"First Name",-15} {"Last Name",-15} {"Phone",-15}");

            for (int i = 0; i < records.Length; i++)
            {
                Console.WriteLine($"{i + 1,3}. {records[i].firstName,-15} {records[i].lastName,-15} {records[i].phone,-15}");
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
        }

        static void DeleteRecords(string path)
        {
            DisplayPhoneBook(path);

            Console.WriteLine();
            Console.WriteLine("Deleting records");
            Console.Write("Enter record index (0 to cancel): ");

            int index;

            if (!int.TryParse(Console.ReadLine() ?? "1", out index))
            {
                throw new Exception("Invalid input");
            }

            if (index > 0)
            {
                (string firstName, string lastName, string phone)[] phoneBookRecords = ReadPhoneBookRecords(path);

                if (index - 1 < phoneBookRecords.Length)
                {
                    (string firstName, string lastName, string phone)[] res =
                        new (string firstName, string lastName, string phone)[phoneBookRecords.Length - 1];

                    for (int i = index; i < phoneBookRecords.Length; i++)
                    {
                        res[i - 1] = phoneBookRecords[i];
                    }

                    string[] strRes = new string[res.Length + 1];
                    strRes[0] = "FirstName,LastName,PhoneNumber";

                    for (int i = 0; i < res.Length; i++)
                    {
                        strRes[i + 1] = $"{res[i].firstName},{res[i].lastName},{res[i].phone}";
                    }

                    if (File.GetAttributes(path) == FileAttributes.ReadOnly)
                    {
                        throw new Exception("File has read only status");
                    }
                    File.WriteAllLines(path, strRes);
                }
                else
                {
                    throw new IndexOutOfRangeException("Invalid input");
                }
            }
        }

        static void SortRecords(string path)
        {
            (string firstName, string lastName, string phone)[] rec = ReadPhoneBookRecords(path);

            Console.WriteLine("\t1. first name");
            Console.WriteLine("\t2. last name");
            Console.WriteLine("\t3. phone number");
            Console.Write("Sort by: ");
            var pressedKey = Console.ReadKey();
            int sortBy = 1;
            sortBy = pressedKey.Key switch
            {
                ConsoleKey.D1 => 1,
                ConsoleKey.D2 => 2,
                ConsoleKey.D3 => 3,
                _ => -1
            };

            Console.WriteLine();
            Console.WriteLine("\t1. ASC");
            Console.WriteLine("\t2. DSC");
            Console.Write("Sort order: ");

            pressedKey = Console.ReadKey();
            int order = 1;
            order = pressedKey.Key switch
            {
                ConsoleKey.D1 => 1,
                ConsoleKey.D2 => 2,
                _ => -1
            };

            SortRecords(rec, sortBy, order);

            string[] strRes = new string[rec.Length + 1];
            strRes[0] = "FirstName,LastName,PhoneNumber";

            for (int i = 0; i < rec.Length; i++)
            {
                strRes[i + 1] = $"{rec[i].firstName},{rec[i].lastName},{rec[i].phone}";
            }

            if (File.GetAttributes(path) == FileAttributes.ReadOnly)
            {
                throw new Exception("File has read only status");
            }
            File.WriteAllLines(path, strRes);
        }

        static void SortRecords((string firstName, string lastName, string phone)[] rec,
            int sortBy = 2,
            int order = 1)
        {

            Func<(string firstName, string lastName, string phone), int, string> SortBy =
                (a, b) => b == 1 ? a.firstName : b == 2 ?
                    a.lastName : a.phone;
            Func<string, string, int, bool> sorter = (a, b, o) => string.Compare(a, b, StringComparison.OrdinalIgnoreCase) < 0 && o == 1;

            if ((sortBy != -1 && order != -1))
            {
                throw new Exception("Invalid input");
            }

            for (int i = 1; i < rec.Length; i++)
            {
                for (int j = i; j > 0 && sorter(SortBy(rec[j - 1], sortBy), SortBy(rec[j], sortBy), order); j--)
                {
                    (string firstName, string lastName, string phone) temp = rec[j];
                    rec[j] = rec[j - 1];
                    rec[j - 1] = temp;
                }
            }            
        }

        static void BinarySearch(string path)
        {
            Console.WriteLine();
            Console.Write("Enter serching last name: ");
            string searchingStr = Console.ReadLine() ?? string.Empty;

            (string firstName, string lastName, string phone)[] rec = ReadPhoneBookRecords(path);
            SortRecords(rec);

            int start = 0;
            int end = rec.Length - 1;
            bool is_ok = false;

            while (start <= end)
            {
                int current = (start + end) / 2;


                if (string.Compare(searchingStr, rec[current].lastName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    Console.WriteLine($"{rec[current].firstName,-15} {rec[current].lastName,-15} {rec[current].phone,-15}");
                    is_ok = true;
                }
                if (string.Compare(searchingStr, rec[current].lastName, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    end = current - 1;
                }
                else
                {
                    start = current + 1;

                }
            }

            if (!is_ok)
            {
                throw new Exception($"There is on records {searchingStr}");
            }
        }
    }
}