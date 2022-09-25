using System;
using System.Security.Cryptography;

namespace ConsoleApp1
{
    internal class Program
    {
        static string pathPhoneBook = Path.Combine(Directory.GetCurrentDirectory(), "PhoneBook.csv");

        static void Main(string[] args)
        {
            ConsoleKeyInfo consoleKeyInfo;
            while (true)
            {
                DisplayMenu();
                consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.D1://Display the phone book
                        Console.Clear();

                        DispleyPhonBook(GetStringArrayFromFail(pathPhoneBook));
                        Console.WriteLine("\nPress any key to continue");

                        Console.ReadKey();
                        Console.Clear();
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
        }
        //
        static (string number, string lastName, string firstName, string phoneNuber)[] GetStringArrayFromFail(string path)
        {
            string[] phoneBook = File.ReadAllLines(path);
            (string number, string lastName, string firstName, string phon)[] elementsOfArray = new (string number, string lastName, string firstName, string phon)[phoneBook.Length];

            for (int i = 0; i < phoneBook.Length; i++)
            {
                string[] itemelement = phoneBook[i].Split(',');
                elementsOfArray[i] = (itemelement[0], itemelement[1], itemelement[2], itemelement[3]);
            }

            return elementsOfArray;
        }
        //
        static void DispleyPhonBook((string number, string lastName, string firstName, string phoneNuber)[] arrayPhonNumber)
        {
            for (int i = 0; i < arrayPhonNumber.Length; i++)
            {
                Console.WriteLine($"{arrayPhonNumber[i].number,-8}{arrayPhonNumber[i].lastName,-15}{arrayPhonNumber[i].firstName,-15}{arrayPhonNumber[i].phoneNuber,-15}");
            }
        }
        static void DispleyPhonBook((string number, string lastName, string firstName, string phoneNuber) arrayPhonNumber)
        {
            Console.WriteLine($"{arrayPhonNumber.number,-8}{arrayPhonNumber.lastName,-15}{arrayPhonNumber.firstName,-15}{arrayPhonNumber.phoneNuber,-15}");
        }
        //
        static void AddNewContact()
        {
            Console.Write("Last name:\t");
            string lastName = Console.ReadLine();

            Console.Write("Firs name:\t");
            string firstName = Console.ReadLine();

            Console.Write("Phon nuber:\t");
            string phon = Console.ReadLine();

            string[] newcontact = new[] { string.Join(',', GetStringArrayFromFail(pathPhoneBook).Length, lastName, firstName, phon) };
            File.AppendAllLines(pathPhoneBook, newcontact);
        }
        //
        static void Search()
        {
            Console.WriteLine("Enter your search parameters");
            string paramsSearch = Console.ReadLine();

            (string number, string lastName, string firstName, string phoneNuber)[] searchArray = GetStringArrayFromFail(pathPhoneBook);

            Console.WriteLine("\nSearch result:");
            DispleyPhonBook(searchArray[0]);

            for (int i = 1; i < searchArray.Length; i++)
            {
                if (searchArray[i].lastName.Contains(paramsSearch, StringComparison.OrdinalIgnoreCase))
                    DispleyPhonBook(searchArray[i]);
                else if (searchArray[i].firstName.Contains(paramsSearch, StringComparison.OrdinalIgnoreCase))
                    DispleyPhonBook(searchArray[i]);
                else if (searchArray[i].number.Contains(paramsSearch, StringComparison.OrdinalIgnoreCase))
                    DispleyPhonBook(searchArray[i]);
                else if (searchArray[i].phoneNuber.Contains(paramsSearch, StringComparison.OrdinalIgnoreCase))
                    DispleyPhonBook(searchArray[i]);
            }
        }
        static void Search(string paramsSearch)
        {
            (string number, string lastName, string firstName, string phoneNuber)[] searchArray = GetStringArrayFromFail(pathPhoneBook);

            DispleyPhonBook(searchArray[0]);

            for (int i = 1; i < searchArray.Length; i++)
            {
                if (searchArray[i].lastName.Contains(paramsSearch, StringComparison.OrdinalIgnoreCase))
                    DispleyPhonBook(searchArray[i]);
                else if (searchArray[i].firstName.Contains(paramsSearch, StringComparison.OrdinalIgnoreCase))
                    DispleyPhonBook(searchArray[i]);
                else if (searchArray[i].number.Contains(paramsSearch, StringComparison.OrdinalIgnoreCase))
                    DispleyPhonBook(searchArray[i]);
                else if (searchArray[i].phoneNuber.Contains(paramsSearch, StringComparison.OrdinalIgnoreCase))
                    DispleyPhonBook(searchArray[i]);
            }
        }
        //
        static void EditContact()
        {
            (string number, string lastName, string firstName, string phoneNuber)[] searchArray = GetStringArrayFromFail(pathPhoneBook);
            string[] editContact = new string[searchArray.Length];
            string paramsSearch;

            Console.WriteLine("Enter (first name or last name or number) of the contact you want to change");
            paramsSearch = Console.ReadLine();
            Search(paramsSearch);

            Console.Write("Select the order in Result:\t");
            string indexOrder = Console.ReadLine();

            Console.WriteLine(searchArray[int.Parse(indexOrder)]);

            Console.WriteLine("What do you want to change:\n\t1. LastName\n\t2. First Name\n\t3. Phone Number");
            ConsoleKeyInfo choice = Console.ReadKey();
            switch (choice.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Console.WriteLine("Rewrite Last Name:\t");
                    searchArray[int.Parse(indexOrder)].lastName = Console.ReadLine();

                    editContact = TransformArray(searchArray);
                    File.WriteAllLines(pathPhoneBook, editContact);
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    Console.WriteLine("Rewrite Firs Name:\t");
                    searchArray[int.Parse(indexOrder)].firstName = Console.ReadLine();

                    editContact = TransformArray(searchArray);
                    File.WriteAllLines(pathPhoneBook, editContact);
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    Console.WriteLine("Rewrite Phone Number:\t");
                    searchArray[int.Parse(indexOrder)].phoneNuber = Console.ReadLine();

                    editContact = TransformArray(searchArray);
                    File.WriteAllLines(pathPhoneBook, editContact);
                    break;
                default:
                    break;
            }

        }
        //
        static void DeleteContact()
        {
            (string number, string lastName, string firstName, string phoneNuber)[] searchArray = GetStringArrayFromFail(pathPhoneBook);
            var DelArray = new (string number, string lastName, string firstName, string phoneNuber)[searchArray.Length - 1];
            string[] deleteContact = new string[searchArray.Length];
            string paramsSearch;

            Console.WriteLine("Enter (first name or last name or number) of the contact you want to delete");
            paramsSearch = Console.ReadLine();
            Search(paramsSearch);

            Console.Write("Select the order in Result:\t");
            string indexOrder = Console.ReadLine();

            Console.WriteLine(searchArray[int.Parse(indexOrder)]);

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
            var searchArray = GetStringArrayFromFail(pathPhoneBook);
            Console.WriteLine("Select sort:\n\t1. Asc\n\t2. Desc");
            int sort = int.Parse(Console.ReadLine());
            if (sort == 1)
            {
                Console.WriteLine("Select a sort parameter:\n\t 1. Order\n\t2. Last Name\n\t3. First Name");
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                switch (consoleKey.Key)
                {
                    case ConsoleKey.D1:
                        for (int i = 0; i < searchArray.Length - 1; i++)
                        {
                            for (int j = 1; j < searchArray.Length - i - 1; j++)
                                if (searchArray[j].number.CompareTo(searchArray[j + 1].number) > 0)
                                {
                                    var temp = searchArray[j];
                                    searchArray[j] = searchArray[j + 1];
                                    searchArray[j + 1] = temp;
                                }
                        }
                        break;
                    case ConsoleKey.D2:
                        for (int i = 0; i < searchArray.Length - 1; i++)
                        {
                            for (int j = 1; j < searchArray.Length - i - 1; j++)
                                if (searchArray[j].lastName.CompareTo(searchArray[j + 1].lastName) > 0)
                                {
                                    var temp = searchArray[j];
                                    searchArray[j] = searchArray[j + 1];
                                    searchArray[j + 1] = temp;
                                }
                        }
                        break;
                    case ConsoleKey.D3:
                        for (int i = 0; i < searchArray.Length - 1; i++)
                        {
                            for (int j = 1; j < searchArray.Length - i - 1; j++)
                                if (searchArray[j].firstName.CompareTo(searchArray[j + 1].firstName) > 0)
                                {
                                    var temp = searchArray[j];
                                    searchArray[j] = searchArray[j + 1];
                                    searchArray[j + 1] = temp;
                                }
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Select a sort parameter:\n\t 1. Order\n\t2. Last Name\n\t3. First Name");
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                switch (consoleKey.Key)
                {
                    case ConsoleKey.D1:
                        for (int i = 0; i < searchArray.Length - 1; i++)
                        {
                            for (int j = 1; j < searchArray.Length - i - 1; j++)
                                if (searchArray[j].number.CompareTo(searchArray[j + 1].number) < 0)
                                {
                                    var temp = searchArray[j];
                                    searchArray[j] = searchArray[j + 1];
                                    searchArray[j + 1] = temp;
                                }
                        }
                        break;
                    case ConsoleKey.D2:
                        for (int i = 0; i < searchArray.Length - 1; i++)
                        {
                            for (int j = 1; j < searchArray.Length - i - 1; j++)
                                if (searchArray[j].lastName.CompareTo(searchArray[j + 1].lastName) < 0)
                                {
                                    var temp = searchArray[j];
                                    searchArray[j] = searchArray[j + 1];
                                    searchArray[j + 1] = temp;
                                }
                        }
                        break;
                    case ConsoleKey.D3:
                        for (int i = 0; i < searchArray.Length - 1; i++)
                        {
                            for (int j = 1; j < searchArray.Length - i - 1; j++)
                                if (searchArray[j].firstName.CompareTo(searchArray[j + 1].firstName) < 0)
                                {
                                    var temp = searchArray[j];
                                    searchArray[j] = searchArray[j + 1];
                                    searchArray[j + 1] = temp;
                                }
                        }
                        break;
                    default:
                        break;
                }
            }

            File.WriteAllLines(pathPhoneBook, TransformArray(searchArray));

        }
        //
        static void BinarySearch()
        {
            var searchArray = GetStringArrayFromFail(pathPhoneBook);

            for (int i = 0; i < searchArray.Length - 1; i++)
            {
                for (int j = 1; j < searchArray.Length - i - 1; j++)
                    if (searchArray[j].firstName.CompareTo(searchArray[j + 1].firstName) > 0)
                    {
                        var temp = searchArray[j];
                        searchArray[j] = searchArray[j + 1];
                        searchArray[j + 1] = temp;
                    }
            }

            Console.Write("enter the first name that needs to be found:\t");
            string nameFound = Console.ReadLine();

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
                    DispleyPhonBook(searchArray[(int)mid]);
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

            //int[] ints = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };// test
            //int mid = ints.Length / 2;
            //int value = 2;
            //while (true)
            //{
            //    if (mid == value)
            //    {
            //        Console.WriteLine(value);
            //        break;
            //    }
            //    else if (mid > value)
            //    {
            //        mid = (ints[0] + mid) / 2;
            //    }
            //    else
            //    {
            //        mid = (ints.Length + mid) / 2;
            //    }

            //}
        }
        static string[] TransformArray((string number, string lastName, string firstName, string phoneNuber)[] searchArray)
        {
            string[] result = new string[searchArray.Length];
            for (int i = 0; i < searchArray.Length; i++)
            {
                result[i] = string.Join(",", searchArray[i].number, searchArray[i].lastName, searchArray[i].firstName, searchArray[i].phoneNuber);
            }
            return result;
        }// Перетворити з того що я зробив масиву в масив стрінгів(якщо вказати не всі пункти (firstName і тд) то файл перезапишиться неправильно і постійно викидатиме помилку
    }
}