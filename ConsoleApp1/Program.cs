using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    internal class Program
    {
        static string path = Path.Combine(Directory.GetCurrentDirectory(), "phonebook1.csv");
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
            //var path = Path.Combine(Directory.GetCurrentDirectory(), "phonebook.csv");


            Console.WriteLine("\tThis is phonebook app");

            Console.WriteLine("\t1. Display phone book records");
            Console.WriteLine("\t2. Add new record");
            Console.WriteLine("\t3. Search records");
            Console.WriteLine("\t4. Sort records");
            Console.WriteLine("\t5. Edit records");
            Console.WriteLine("\t6. Delete records");
            Console.WriteLine("\t0. Exit app");
            try
            {
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
                        Sort(path);
                        break;
                    case ConsoleKey.D5:
                        Edit(path);
                        break;
                    case ConsoleKey.D6:
                        DeleteRecord(path);
                        break;
                    case ConsoleKey.D0:
                    default:
                        //Environment.Exit(0);
                        break;
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception(ex.Message, ex);
            }

            Console.ReadKey();
            //Console.Clear();

        }

        private static void DeleteRecord(string path)
        {
            try
            {
                var records = ReadPhoneBookRecords(path);
                DisplayPhoneBook(records);
                Console.WriteLine("Choose a record to delete by index:");
                int choice = Int32.Parse(Console.ReadLine() ?? String.Empty);
                //if (choice > records.Length)
                //    Console.WriteLine("You have picked a wrong index!");
                //if (choice < records.Length)
                //{
                records[choice].Item1 = string.Empty;
                records[choice].Item2 = string.Empty;
                records[choice].Item3 = string.Empty;
                (string, string, string) temp = records[records.Length - 1];
                records[records.Length - 1] = records[choice];
                records[choice] = temp;
                Array.Resize(ref records, records.Length - 1);
                RecordString(records);
                //}
            }
            catch (IndexOutOfRangeException e)
            {
                throw new IndexOutOfRangeException("You picked a wrong index!", e);

            }
        }

        private static void Edit(string path)
        {
            var records = ReadPhoneBookRecords(path);
            DisplayPhoneBook(records);
            string name = string.Empty;
            string lastName = string.Empty;
            string num = string.Empty;
            Console.WriteLine("Choose the record to edit by index");
            Console.WriteLine();
            try
            {
                int index = Int32.Parse(Console.ReadLine() ?? null);
                
                //if (index > records.Length)
                //{
                //    Console.WriteLine("You picked a wrong index!");
                //    Edit(path);
                //}
                //else if (index < records.Length)
                //{
                    Console.WriteLine("\n 1. Change first name \n 2. Change last name \n 3. Change number");
                    int choice2 = Int32.Parse(Console.ReadLine() ?? string.Empty);
                    if (choice2 == 1)
                    {
                        Console.WriteLine($"Changing that {records[index].Item1} to:");
                        name = Console.ReadLine() ?? string.Empty;
                        records[index].Item1 = name;


                    }
                    else if (choice2 == 2)
                    {
                        Console.WriteLine($"Changing that {records[index].Item2} to:");
                        lastName = Console.ReadLine() ?? string.Empty;
                        records[index].Item2 = lastName;

                    }
                    else
                    {
                        Console.WriteLine($"Changing that {records[index].Item3} to:");
                        num = Console.ReadLine();
                        records[index].Item3 = num ?? string.Empty;

                    }

                //}


                RecordString(records);
            }

            catch (ArgumentNullException argumentNullException) { throw new Exception("You need to type something!", argumentNullException); }
            catch (ArgumentOutOfRangeException outOfRangeException) { throw new Exception("You picked a wrong index!", outOfRangeException); }

        }

        static (string, string, string)[] ReadPhoneBookRecords(string path)
        {
            (string, string, string)[] returnvalue = null;
            try
            {
                Console.WriteLine();

                string[] records = File.ReadAllLines(path);
                (string, string, string)[] phoneBookRecords = new (string, string, string)[records.Length - 1];

                for (int i = 1; i < records.Length; i++)
                {
                    var itemProperties = records[i].Split(',');

                    phoneBookRecords[i - 1] = (itemProperties[0], itemProperties[1], itemProperties[2]);
                }
                returnvalue = phoneBookRecords;

            }
            catch (FileNotFoundException fnf)
            {

                Console.WriteLine(fnf.Message);                
                string header = "First name,Second name,number";
                File.WriteAllText(path, header);
                
            }
            catch (OverflowException ae)
            {

                Console.WriteLine(ae.Message);
                string header = "First name,Second name,number";
                File.WriteAllText(path, header);

            }
            return returnvalue;
            
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
        public enum Order { Asc, Desc };
        public enum SortBy { firstName, lastName, phoneNum };

        static void Sort(string path)
        {
            Order order;

            Console.WriteLine("Enter sorting order: ");
            Console.WriteLine("1. Ascending");
            Console.WriteLine("2. Descending");
            ConsoleKey choice = Console.ReadKey().Key;
            if (choice == ConsoleKey.D1)
                order = Order.Asc;
            else
                order = Order.Desc;

            Console.WriteLine("Sort by: ");
            Console.WriteLine("1. First Name");
            Console.WriteLine("2. Last name");
            Console.WriteLine("3. Phone number");
            choice = Console.ReadKey().Key;

            SortBy sort;
            if (choice == ConsoleKey.D3)
            {
                sort = SortBy.phoneNum;
            }
            else if (choice == ConsoleKey.D2)
            {
                sort = SortBy.lastName;
            }
            else
            {
                sort = SortBy.firstName;
            }
            var records = ReadPhoneBookRecords(path);
            try
            {
                SortMethod(records, order, sort);
                string[] newOrder = new string[records.Length + 1];
                newOrder[0] = "FirstName,LastName,PhoneNumber";
                RecordString(records);
            }
            catch
            {

            }
            finally
            {
                Console.WriteLine("Sorting is done!");
            }

        }
        static void SortMethod((string name, string lastName, string phone)[] array, Order order, SortBy sort)
        {
            if (sort == SortBy.firstName && order == Order.Asc)
            {
                int x = array.Length;
                for (int i = 0; i < x - 1; i++)
                {
                    int min = i;
                    for (int j = i + 1; j < x; j++)
                    {
                        if (string.Compare(array[j].name, array[min].name, true) < 0)
                        {
                            min = j;
                        }
                    }
                    (string, string, string) temp = array[min];
                    array[min] = array[i];
                    array[i] = temp;

                }
            }
            else if (sort == SortBy.firstName && order == Order.Desc)
            {
                int x = array.Length;
                for (int i = 0; i < x - 1; i++)
                {
                    int min = i;
                    for (int j = i + 1; j < x; j++)
                    {
                        if (string.Compare(array[j].name, array[min].name, true) > 0)
                        {
                            min = j;
                        }
                    }
                    (string, string, string) temp = array[min];
                    array[min] = array[i];
                    array[i] = temp;

                }
            }
            else if (sort == SortBy.lastName && order == Order.Asc)
            {
                int x = array.Length;
                for (int i = 0; i < x - 1; i++)
                {
                    int min = i;
                    for (int j = i + 1; j < x; j++)
                    {
                        if (string.Compare(array[j].lastName, array[min].lastName, true) < 0)
                        {
                            min = j;
                        }
                    }
                    (string, string, string) temp = array[min];
                    array[min] = array[i];
                    array[i] = temp;
                }

            }
            else if (sort == SortBy.lastName && order == Order.Desc)
            {
                int x = array.Length;
                for (int i = 0; i < x - 1; i++)
                {
                    int min = i;
                    for (int j = i + 1; j < x; j++)
                    {
                        if (string.Compare(array[j].lastName, array[min].lastName, true) > 0)
                        {
                            min = j;
                        }
                    }
                    (string, string, string) temp = array[min];
                    array[min] = array[i];
                    array[i] = temp;
                }

            }
            else if (sort == SortBy.phoneNum && order == Order.Asc)
            {
                int x = array.Length;
                for (int i = 0; i < x - 1; i++)
                {
                    int min = i;
                    for (int j = i + 1; j < x; j++)
                    {
                        if (string.Compare(array[j].phone, array[min].phone, true) < 0)
                        {
                            min = j;
                        }
                    }
                    (string, string, string) temp = array[min];
                    array[min] = array[i];
                    array[i] = temp;
                }
            }
            else
            {
                int x = array.Length;
                for (int i = 0; i < x - 1; i++)
                {
                    int min = i;
                    for (int j = i + 1; j < x; j++)
                    {
                        if (string.Compare(array[j].phone, array[min].phone, true) > 0)
                        {
                            min = j;
                        }
                    }
                    (string, string, string) temp = array[min];
                    array[min] = array[i];
                    array[i] = temp;
                }
            }

        }
        public static void RecordString((string, string, string)[] records)
        {
            string[] newOrder = new string[records.Length + 1];
            foreach (var item in newOrder.Select((value, i) => new { i, value }))
            {
                var value = item.value;
                var index = item.i;
                if (index < records.Length)
                    newOrder[index + 1] = records[index].Item1 + ',' + records[index].Item2 + ',' + records[index].Item3;
            }
            File.WriteAllLines(path, newOrder);
        }

    }
}
