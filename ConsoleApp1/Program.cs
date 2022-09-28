using System;
using System.Security.Cryptography;

namespace ConsoleApp1
{
    internal class Program
    {
        static string pathPhoneBook = Path.Combine(Directory.GetCurrentDirectory(), "PhoneBook.csv");

        static void Main(string[] args)
        {
            // Основний try/catch для обробки всіх виключень що прийдуть
            try
            {
                while (true)
                {
                    DisplayMenu();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Samsing wrong...\t{ex.Message}\n{ex.StackTrace}");
                Console.Clear();
                DisplayMenu();
            }
        }
        static void DisplayMenu()
        {
            Console.WriteLine("\tPhone Book");

            Console.WriteLine("Press the number of the required operation");

            Console.WriteLine("1. Display the phone book");

            Console.WriteLine("2. Add new contact");

            Console.WriteLine("3. Edit contact");//Зробити можливість оновлення запису
                                                 //якщо це зміна, то ви виводете, зчитуєте дані і зберігаєте в файл (H/W)
            Console.WriteLine("4. Delete contact");//видалення Тобто, додаєте нові пункти меню, потім питаєте індекс і
                                                   //якщо видалення, то видаляєте по індексу, і зберігаєте файл (H/W)
            Console.WriteLine("5. Sort");//Зробити можливість сортування (Asc, Desc) та вибором по чому сортувати(H/W)

            Console.WriteLine("6. Search ");

            Console.WriteLine("7. Binary search\n");// бінарний пошук по прізвищу(Ex H/W)

            Console.WriteLine("0. Exit app");

            ConsoleKeyInfo consoleKeyInfo;

                consoleKeyInfo = Console.ReadKey();

                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.D1://Display the phone book
                    Console.Clear();

                    try
                    {
                        DisplayPhoneBook(GetStringArrayFromFile(pathPhoneBook));

                        Console.WriteLine("\nPress any key to continue");

                        Console.ReadKey();
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("FileNotFoundException cen not open file...");
                        Console.WriteLine("\nPress any key to continue");

                        Console.ReadKey();
                        Console.Clear();
                    }
                    break;

                case ConsoleKey.D2: //Add new contact
                        Console.Clear();

                        AddNewContact();
                        Console.WriteLine("\nNew contact add.\n\nPress any key to continue");

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case ConsoleKey.D3: //Edit contact
                        Console.Clear();

                        EditContact();
                        Console.WriteLine("\nContact Edit.\n\nPress any key to continue");

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case ConsoleKey.D4://Delete contact
                        Console.Clear();

                        DeleteContact();
                        Console.WriteLine("\nContact Delete.\n\nPress any key to continue");

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case ConsoleKey.D5://Sort
                        Console.Clear();

                        SortAscDesc();
                        Console.WriteLine("\nContact are sorting.\n\nPress any key to continue");

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case ConsoleKey.D6://Search
                        Console.Clear();

                        Search();
                        Console.WriteLine("\n\nPress any key to continue");

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case ConsoleKey.D7://Binary search

                        Console.Clear();

                        BinarySearch();

                        Console.WriteLine("\n\nPress any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case ConsoleKey.D0:// Exit app
                    default:
                        Environment.Exit(0);
                        break;
                }
        }
        //
        static (string number, string lastName, string firstName, string phoneNuber)[] GetStringArrayFromFile(string path)
        {
            string[] phoneBook;

            try
            {
                phoneBook = File.ReadAllLines(path);
            }
            catch (FileNotFoundException)
            {
                throw;
            }

            (string number, string lastName, string firstName, string phon)[] elementsOfArray = new (string number, string lastName, string firstName, string phon)[phoneBook.Length];

            for (int i = 0; i < phoneBook.Length; i++)
            {
                string[] itemelement = phoneBook[i].Split(',');
                elementsOfArray[i] = (itemelement[0], itemelement[1], itemelement[2], itemelement[3]);
            }

            return elementsOfArray;
        }
        //
        static void DisplayPhoneBook((string number, string lastName, string firstName, string phoneNuber)[] arrayPhonNumber)
        {
            for (int i = 0; i < arrayPhonNumber.Length; i++)
                DisplayPhoneBook(arrayPhonNumber[i]);
        }
        static void DisplayPhoneBook((string number, string lastName, string firstName, string phoneNuber) arrayPhonNumber)
        {
            Console.WriteLine($"{arrayPhonNumber.number,-8}{arrayPhonNumber.lastName,-15}{arrayPhonNumber.firstName,-15}{arrayPhonNumber.phoneNuber,-15}");
        }
        //
        static void AddNewContact()
        {
            Console.Write("Last name:\t");
            string lastName = Console.ReadLine() ?? "Format Exception";

            Console.Write("Firs name:\t");
            string firstName = Console.ReadLine() ?? "Format Exception";

            Console.Write("Phone number:\t");
            string phon = Console.ReadLine() ?? throw new FormatException();

            try
            {
                string[] newcontact = new[] { string.Join(',', GetStringArrayFromFile(pathPhoneBook).Length, lastName, firstName, phon) };
                File.AppendAllLines(pathPhoneBook, newcontact);
            }
            catch (FileNotFoundException ex)
            {
                throw ex;
            }
        }
        //
        static void Search()
        {
            Console.WriteLine("Enter your search parameters");
            string paramsSearch = Console.ReadLine() ?? throw new Exception(); ;

            (string number, string lastName, string firstName, string phoneNuber)[] searchArray;
            try
            {
                searchArray = GetStringArrayFromFile(pathPhoneBook);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }

            Console.WriteLine("\nSearch result:");
            DisplayPhoneBook(searchArray[0]);

            for (int i = 1; i < searchArray.Length; i++)
            {
                if (searchArray[i].lastName.Contains(paramsSearch, StringComparison.OrdinalIgnoreCase) || searchArray[i].firstName.Contains(paramsSearch, StringComparison.OrdinalIgnoreCase) || searchArray[i].number.Contains(paramsSearch, StringComparison.OrdinalIgnoreCase) || searchArray[i].phoneNuber.Contains(paramsSearch, StringComparison.OrdinalIgnoreCase))
                    DisplayPhoneBook(searchArray[i]);
            }
        }
        static void Search(string paramsSearch)
        {
            (string number, string lastName, string firstName, string phoneNuber)[] searchArray = GetStringArrayFromFile(pathPhoneBook);

            DisplayPhoneBook(searchArray[0]);

            for (int i = 1; i < searchArray.Length; i++)
            {
                if (searchArray[i].lastName.Contains(paramsSearch, StringComparison.OrdinalIgnoreCase) || searchArray[i].firstName.Contains(paramsSearch, StringComparison.OrdinalIgnoreCase) || searchArray[i].number.Contains(paramsSearch, StringComparison.OrdinalIgnoreCase) || searchArray[i].phoneNuber.Contains(paramsSearch, StringComparison.OrdinalIgnoreCase))
                    DisplayPhoneBook(searchArray[i]);
            }
        }
        //
        static void EditContact()
        {
            (string number, string lastName, string firstName, string phoneNuber)[] searchArray = GetStringArrayFromFile(pathPhoneBook);
            string[] editContact = new string[searchArray.Length];
            string paramsSearch;

            Console.WriteLine("Enter (first name or last name or number) of the contact you want to change");
            paramsSearch = Console.ReadLine() ?? throw new Exception();
            Search(paramsSearch);

            Console.Write("Select the order in Result:\t");
            string indexOrder = Console.ReadLine() ?? throw new Exception();

            Console.WriteLine(searchArray[int.Parse(indexOrder)]);

            Console.WriteLine("What do you want to change:\n\t1. LastName\n\t2. First Name\n\t3. Phone Number");
            ConsoleKeyInfo choice = Console.ReadKey();

            switch (choice.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Console.WriteLine("Rewrite Last Name:\t");

                    try
                    {
                        searchArray[int.Parse(indexOrder)].lastName = Console.ReadLine();
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                    editContact = TransformArray(searchArray);

                    try
                    {
                        File.WriteAllLines(pathPhoneBook, editContact);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                    break;

                case ConsoleKey.D2:

                    Console.Clear();
                    Console.WriteLine("Rewrite Firs Name:\t");
                    searchArray[int.Parse(indexOrder)].firstName = Console.ReadLine() ?? throw new Exception(); ;

                    editContact = TransformArray(searchArray);
                    File.WriteAllLines(pathPhoneBook, editContact);

                    break;

                case ConsoleKey.D3:

                    Console.Clear();
                    Console.WriteLine("Rewrite Phone Number:\t");

                    searchArray[int.Parse(indexOrder)].phoneNuber = Console.ReadLine() ?? throw new Exception(); ;

                    editContact = TransformArray(searchArray);

                    try
                    {
                        File.WriteAllLines(pathPhoneBook, editContact);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                    break;
                default:
                    break;
            }

        }
        //
        static void DeleteContact()
        {
            (string number, string lastName, string firstName, string phoneNuber)[] searchArray = GetStringArrayFromFile(pathPhoneBook);
            var DelArray = new (string number, string lastName, string firstName, string phoneNuber)[searchArray.Length - 1];
            string[] deleteContact = new string[searchArray.Length];
            string paramsSearch;

            Console.WriteLine("Enter (first name or last name or number) of the contact you want to delete");
            paramsSearch = Console.ReadLine() ?? throw new Exception(); ;
            Search(paramsSearch);

            Console.Write("Select the order in Result:\t");
            string indexOrder;

            try
            {
                indexOrder = Console.ReadLine();
            }
            catch (FormatException)
            {
                throw;
            }

            try
            {
                Console.WriteLine(searchArray[int.Parse(indexOrder)]);
            }
            catch (FormatException)
            {
                throw;
            }

            for (int i = 0; i < searchArray.Length && i < int.Parse(indexOrder); i++)
                DelArray[i] = searchArray[i];
            for (int i = int.Parse(indexOrder) + 1; i < searchArray.Length; i++)
            {
                DelArray[i - 1] = searchArray[i];
                DelArray[i - 1].number = $"{i - 1}";
            }
            deleteContact = TransformArray(DelArray);
            File.WriteAllLines(pathPhoneBook, deleteContact);
        }
        //
        static void SortAscDesc()
        {
            var searchArray = GetStringArrayFromFile(pathPhoneBook);
            Console.WriteLine("Select sort:\n\t1. Asc\n\t2. Desc");
            int sort;

            try
            {
                sort = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("try next time");
                sort = 0;
            }

            Console.WriteLine("Select a sort parameter:\n\t 1. Order\n\t2. Last Name\n\t3. First Name");
            ConsoleKeyInfo consoleKey = Console.ReadKey();

            if (sort == 1)
                SortAsc(searchArray, consoleKey.Key);
            else
                SortDesc(searchArray, consoleKey.Key);

            File.WriteAllLines(pathPhoneBook, TransformArray(searchArray));
        }
        //
        static void BinarySearch()
        {
            var searchArray = GetStringArrayFromFile(pathPhoneBook);

            SortAsc(searchArray, ConsoleKey.D3);

            Console.Write("enter the first name that needs to be found:\t");
            string nameFound = Console.ReadLine() ?? throw new FormatException();

            double first = 0;
            double last = searchArray.Length;
            double mid = (first + last) / 2;

            while (true)
            {
                if (1 >= Math.Floor(last))// для виходу якщо не знайшло
                {
                    Console.WriteLine("Contact not faund");
                    break;
                }
                if (searchArray.Length <= Math.Ceiling(first))// для виходу якщо не знайшло
                {
                    Console.WriteLine("Contact not faund");
                    break;
                }
                else if (nameFound == searchArray[(int)mid].firstName)
                {
                    DisplayPhoneBook(searchArray[(int)mid]);
                    break;
                }
                else if (nameFound.CompareTo(searchArray[(int)mid].firstName) < 0)
                {
                    last = mid - 1;
                    mid = (first + last) / 2;
                }
                else
                {
                    first = mid + 1;
                    mid = (first + last) / 2;
                }
            }
        }
        //
        static string[] TransformArray((string number, string lastName, string firstName, string phoneNuber)[] searchArray)
        {
            string[] result = new string[searchArray.Length];

            for (int i = 0; i < searchArray.Length; i++)
            {
                result[i] = string.Join(",", searchArray[i].number, searchArray[i].lastName, searchArray[i].firstName, searchArray[i].phoneNuber);
            }
            return result;
        }
        //
        static void SortAsc((string number, string lastName, string firstName, string phoneNuber)[] searchArray, ConsoleKey consoleKey)
        {
            for (int i = 0; i < searchArray.Length - 1; i++)
            {
                for (int j = 1; j < searchArray.Length - i - 1; j++)
                {
                    if (ConsoleKey.D1 == consoleKey && searchArray[j].number.CompareTo(searchArray[j + 1].number) > 0 || ConsoleKey.D2 == consoleKey && searchArray[j].lastName.CompareTo(searchArray[j + 1].lastName) > 0 || ConsoleKey.D3 == consoleKey && searchArray[j].firstName.CompareTo(searchArray[j + 1].firstName) > 0)
                    {
                        var temp = searchArray[j];
                        searchArray[j] = searchArray[j + 1];
                        searchArray[j + 1] = temp;
                    }
                }
            }

        }
        //
        static void SortDesc((string number, string lastName, string firstName, string phoneNuber)[] searchArray, ConsoleKey consoleKey)
        {
            for (int i = 0; i < searchArray.Length - 1; i++)
            {
                for (int j = 1; j < searchArray.Length - i - 1; j++)
                {
                    if (ConsoleKey.D1 == consoleKey && searchArray[j].number.CompareTo(searchArray[j + 1].number) < 0 || ConsoleKey.D2 == consoleKey && searchArray[j].lastName.CompareTo(searchArray[j + 1].lastName) < 0 || ConsoleKey.D3 == consoleKey && searchArray[j].firstName.CompareTo(searchArray[j + 1].firstName) < 0)
                    {
                        var temp = searchArray[j];
                        searchArray[j] = searchArray[j + 1];
                        searchArray[j + 1] = temp;
                    }
                }
            }
        }
    }
}