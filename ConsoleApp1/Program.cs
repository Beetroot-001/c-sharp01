using System.Numerics;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using static ConsoleApp1.Program;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
            Console.WriteLine("\t4. Edit a record");
            Console.WriteLine("\t5. Delete a record");
            Console.WriteLine("\t6. Sort records by anything");
            Console.WriteLine("\t7. Binary search records by surname");
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
                case ConsoleKey.D4:
                    EditRecord(path);
                    break;
                case ConsoleKey.D5:
                    DeleteRecord(path);
                    break;
                case ConsoleKey.D6:
                    Sort(path);
                    break;
                case ConsoleKey.D7:
                    // binary search
                    int id;
                    string message = BinarySearch(path, out id) ? $"Surname is in phonebook! Id: {id + 1}" : "Surname was not found";
                    Console.WriteLine(message);
                    break;
                case ConsoleKey.D0:
                default:
                    Environment.Exit(0);
                    break;
            }
            Console.WriteLine("Press any key to continue");
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

        static int IdInput(int sizeLimit)
        {
            int input;
            bool succes = true;
            Console.WriteLine("Enter id of record: ");
            do
            {
                succes = int.TryParse(Console.ReadLine(), out input);
                string message = succes && (input < sizeLimit) ? "Id get successfully input" : "Invalid input Try again";
                Console.WriteLine(message);
            }
            while (!succes);

            return input;
        }

        static void DeleteSwap(string[] records, int id)
        {
            if (id == records.Length)
                return;
            string swap = records[^1];
            records[^1] = records[id];
            records[id] = swap;
        }
        public enum OrderBy
        {
            Ascending,
            Descending
        }

        public enum SortBy
        {
            Name,
            Surname,
            Phone
        }
        static void Sort(string path)
        {
            Console.WriteLine("Enter sorting order: ");
            Console.WriteLine("1. Ascending");
            Console.WriteLine("2. Descending");
            ConsoleKey pressed = Console.ReadKey().Key;
            OrderBy order = (pressed == ConsoleKey.D2) ? OrderBy.Descending : OrderBy.Ascending;

            Console.WriteLine("Sorting by: ");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Surname");
            Console.WriteLine("3. Phone");
            pressed = Console.ReadKey().Key;

            SortBy sort;
            if (pressed == ConsoleKey.D3)
            {
                sort = SortBy.Phone;
            }
            else if (pressed == ConsoleKey.D2)
            {
                sort = SortBy.Surname;
            }
            else
            {
                sort = SortBy.Name;
            }
            var records = ReadPhoneBookRecords(path);

            BubbleSort(records, order, sort);
            string[] recordsToWrite = new string[records.Length + 1];
            recordsToWrite[0] = "FirstName,LastName,PhoneNumber";
            for (int i = 1; i < recordsToWrite.Length; i++)
            {
                recordsToWrite[i] = records[i - 1].Item1 + "," + records[i - 1].Item2 + "," + records[i - 1].Item3;
            }
            DisplayPhoneBook(records);
            File.WriteAllLines(path, recordsToWrite);
        }
        static void SortBinary(string path)
        {
            var records = ReadPhoneBookRecords(path);

            BubbleSort(records, OrderBy.Ascending, SortBy.Surname);
            string[] recordsToWrite = new string[records.Length + 1];
            recordsToWrite[0] = "FirstName,LastName,PhoneNumber";
            for (int i = 1; i < recordsToWrite.Length; i++)
            {
                recordsToWrite[i] = records[i - 1].Item1 + "," + records[i - 1].Item2 + "," + records[i - 1].Item3;
            }
            File.WriteAllLines(path, recordsToWrite);
        }

        public static void BubbleSort((string name, string surname, string phone)[] array, OrderBy order, SortBy criteria)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if ((array[j].surname.CompareTo(array[j + 1].surname) >= 1 && order == OrderBy.Ascending && criteria == SortBy.Surname) ||
                        (array[j].surname.CompareTo(array[j + 1].surname) <= -1 && order == OrderBy.Descending && criteria == SortBy.Surname) ||
                        (array[j].phone.CompareTo(array[j + 1].phone) >= 1 && order == OrderBy.Ascending && criteria == SortBy.Phone) ||
                        (array[j].phone.CompareTo(array[j + 1].phone) <= -1 && order == OrderBy.Descending && criteria == SortBy.Phone) ||
                        (array[j].name.CompareTo(array[j + 1].name) >= 1 && order == OrderBy.Ascending && criteria == SortBy.Name) ||
                        (array[j].name.CompareTo(array[j + 1].name) <= -1 && order == OrderBy.Descending && criteria == SortBy.Name))
                    {
                        (string name, string surname, string phone) t = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = t;
                    }
                }
            }
        }

        static bool BinarySearch(string path, out int id)
        {
            // get the info to search
            Console.WriteLine("Enter surname to search: ");
            string search = Console.ReadLine() ?? "";
            (string firstname, string lastname, string phone)[] records;
            // sort at first
            SortBinary(path);
            // get the info u need 
            records = ReadPhoneBookRecords(path);
            
            // search 
            int l = 0;
            int r = records.Length - 1;
            int mid;
            while (l <= r)
            {
                mid = (l + r) / 2;
                if (search == records[mid].lastname)
                {
                    id = mid;
                    return true;
                }
                else if (search.CompareTo(records[mid].lastname) <= -1)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }
            id = -1;
            return false;
        }

        static void EditRecord(string path)
        {
            var records = File.ReadAllLines(path);
            int input = IdInput(records.Length);

            Console.WriteLine("Founded record: ");
            Console.WriteLine(records[input]);

            Console.Write("Enter new firstname: ");
            string newName = Console.ReadLine() ?? "";

            Console.Write("Enter new lastname: ");
            string newLast = Console.ReadLine() ?? "";

            Console.Write("Enter new phone: ");
            string newPhone = Console.ReadLine() ?? "";

            string newRecord = string.Join(',', newName, newLast, newPhone);
            records[input] = newRecord;
            File.WriteAllLines(path, records);
        }

        static void DeleteRecord(string path)
        {
            var records = File.ReadAllLines(path);
            int input = IdInput(records.Length);

            DeleteSwap(records, input);
            Array.Resize(ref records, records.Length - 1);

            File.WriteAllLines(path, records);
        }
    }
}