using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
	internal class Program
	{
		
		/// <summary>
		/// Read PhoneBook info from file to the array 
		/// </summary>
		/// <param name="path">path to the file to read</param>
		/// <returns></returns>
		static (string,string,string) [] ReadPhoneBook(string path)
		{
            string [] phoneBook = File.ReadAllLines(path);

			(string, string, string)[] phoneBookRecords = new (string, string, string)[phoneBook.Length-1];

            for (int i = 1; i < phoneBook.Length; i++)
			{
				var itemProperties = phoneBook[i].Split(',');
				phoneBookRecords[i-1] = (itemProperties[0], itemProperties[1], itemProperties[2]);
            }
			return phoneBookRecords;
        }

		/// <summary>
		/// Print to the concole all PhoneBook records
		/// </summary>
		/// <param name="phoneBookRecords">PhoneBook to print</param>
		static void PrintPhoneBook ((string firstName, string lastName, string phoneNumber)[] phoneBookRecords)
		{
            DisplayMenu();

			Console.WriteLine($"{"First Name",-20} {"Last Name",-20} {"Phone",-20}");

			foreach (var record in phoneBookRecords)
			{
				Console.WriteLine($"{record.firstName,-20} {record.lastName,-20} {record.phoneNumber,-20}");   
			}
		}
		
		/// <summary>
		/// Search a contact in the PhoneBook based on the query
		/// </summary>
		/// <param name="phoneBookRecords">PhoneBook to search</param>
		static void SearchPhoneBook((string firstName, string lastName, string phoneNumber)[] phoneBookRecords)
		{
            DisplayMenu();
            
			Console.WriteLine("Enter the search query");

			string searchQuery = Console.ReadLine() ?? string.Empty;

            Console.WriteLine($"{"First Name",-20} {"Last Name",-20} {"Phone",-20}");
            
			foreach (var record in phoneBookRecords)
			{
				if (record.firstName.Contains(searchQuery,StringComparison.OrdinalIgnoreCase)||
                    record.lastName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)||
                    record.phoneNumber.Contains(searchQuery, StringComparison.OrdinalIgnoreCase))                 
				{
                    Console.WriteLine($"{record.firstName,-20} {record.lastName,-20} {record.phoneNumber,-20}");
                }
			}
		}



		/// <summary>
		/// Add a new record to PhoneBook
		/// </summary>
		/// <param name="path">Path to the file where the PhoneBook stores</param>
		/// <param name="phoneBookRecords">array where the PhoneBook stores</param>
		static void RecordAdd(string path, ref (string, string, string)[] phoneBookRecords) 
		{
            DisplayMenu();
            Console.WriteLine("Enter 1 to return to main menu. The entered information will not be saved.");
			int exit = 0;
			
			while (exit!=1)                                              ///an ability to abort the process of adding a new record 
			{
                Console.WriteLine("Enter the first name");
                string firstName = Console.ReadLine() ?? String.Empty;
				int.TryParse(firstName, out exit);
				
				if (exit == 1)
				{
                    Console.Clear();
                    DisplayMenu();
                    break;
                }					
               
				Console.WriteLine("Enter the last name");
                var lastName = Console.ReadLine();
                int.TryParse(lastName, out exit);

                if (exit == 1)
                {
                    Console.Clear();
                    DisplayMenu();
                    break;
                }

                Console.WriteLine("Enter the phone number");
                var phoneNumber = Console.ReadLine();
                int.TryParse(phoneNumber, out exit);

                if (exit == 1)
                {
                    Console.Clear();
                    DisplayMenu();
                    break;
                }

                string[] newRecords = new[] { string.Join(',', new[] { firstName, lastName, phoneNumber }) };
                File.AppendAllLines(path, newRecords);

                phoneBookRecords = ReadPhoneBook(path);  /// to display the new record in the concole once it was added in the file
				exit = 1;
				
				Console.Clear();
				DisplayMenu();
				Console.WriteLine("The record was successfully added");
            }
        }


		/// <summary>
		/// Remove the indicated record from the PhoneBook
		/// </summary>
		/// <param name="deleteRecord">index of the record to delete</param>
		/// <param name="path">path to the file where the PhoneBook stores</param>
		/// <param name="phoneBookRecords">array where the PhoneBook stores</param>
		static void RecordRemove(string path, ref (string, string, string)[] phoneBookRecords)
		{
            PrintPhoneBook(phoneBookRecords);
            Console.WriteLine("Enter the index of record to delete. 0 - return to main menu.");

			int deleteRecord = 1;

            while (deleteRecord != 0)
			{
				var query = Console.ReadLine();
				int.TryParse(query, out deleteRecord);

                if (deleteRecord == 0)
                {
                    Console.Clear();
                    DisplayMenu();
                    break;
                }

                RemoveArrayIndex(((int)deleteRecord), ref phoneBookRecords);

				string[] newRec = new string[phoneBookRecords.Length + 1];

				newRec[0] = "FirstName,LastName,PhoneNumber";

				for (int i = 0; i < phoneBookRecords.Length; i++)
				{
					newRec[i + 1] = string.Join(',', new[] { phoneBookRecords[i].Item1, phoneBookRecords[i].Item2, phoneBookRecords[i].Item3 });
				}

				File.WriteAllLines(path, newRec);

				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("The record was successfully removed.");
				Console.ResetColor();
				PrintPhoneBook(phoneBookRecords);
                break;
			}
		}

        /// <summary>
        /// Update the record in PhoneBook
        /// </summary>
        /// <param name="path">path to the file where the PhoneBook stores</param>
        /// <param name="phoneBookRecords">array of PhoneBook</param>
		static void RecordUpdate(string path, ref (string firstName, string lastName, string phoneNumber)[] phoneBookRecords)
		{
			PrintPhoneBook(phoneBookRecords);
			Console.WriteLine("Enter the index of record to update. 0 - return to main menu.");
		
			int updateRecord = 1;

			while (updateRecord != 0)
			{
				var query = Console.ReadLine();
				int.TryParse(query, out updateRecord);

				if (updateRecord == 0)
				{
					Console.Clear();
					DisplayMenu();
					break;
				}

				if (updateRecord> phoneBookRecords.Length)
				{
					Console.WriteLine("There is no such record in the PhoneBook. Please, enter the correct record number.");
					break;
				}

				updateRecord--;

				int exit = 1;

                Console.WriteLine("Update the first name or enter 1 to skip this field");
                string firstName = Console.ReadLine() ?? string.Empty;
                int.TryParse(firstName, out exit);

                if (exit == 0)
                {
					phoneBookRecords[updateRecord].firstName = firstName;
                   
                }

                Console.WriteLine("Update the last name or enter 1 to skip this field");
                string lastName = Console.ReadLine() ?? string.Empty;
                int.TryParse(lastName, out exit);

                if (exit == 0)
                {
                    phoneBookRecords[updateRecord].lastName = lastName;
                   
                }

                Console.WriteLine("Update the phone number or enter 1 to skip this field");
                string phoneNumber = Console.ReadLine() ?? string.Empty;
                int.TryParse(phoneNumber, out exit);

                if (exit != 0)
                {
                    phoneBookRecords[updateRecord].phoneNumber = phoneNumber;
                    
                }


                string[] newRec = new string[phoneBookRecords.Length + 1];

                newRec[0] = "FirstName,LastName,PhoneNumber";

                for (int i = 0; i < phoneBookRecords.Length; i++)
                {
                    newRec[i + 1] = string.Join(',', new[] { phoneBookRecords[i].firstName, phoneBookRecords[i].lastName, phoneBookRecords[i].phoneNumber });
                }

                File.WriteAllLines(path, newRec);


				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("The record was successfully updated.");
				Console.ResetColor();
				PrintPhoneBook(phoneBookRecords);
				break;


			}

		}


		/// <summary>
		/// Remove the indicated element of array. The size of array decreases by 1.
		/// </summary>
		/// <param name="index">index of array to remove an element</param>
		/// <param name="array">array where to remove element</param>
		static void RemoveArrayIndex(int index, ref (string, string, string)[] array)
        {
            for (int i = index-1; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }

            Array.Resize(ref array, array.Length - 1);
        }

        /// <summary>
        /// sort PhoneBook by one of its parametrs
        /// </summary>
        enum SortOption
        {
            firstName,
            lastName,
            phoneNumber
        }
        /// <summary>
        /// Direct or reverse sort order
        /// </summary>
        enum SortOrder
        {
            Asc,
            Desc
        }

     /// <summary>
     /// Sort PhoneBook in the chosen order 
     /// </summary>
     /// <param name="phoneBookRecords">array of records to sort</param>
     /// <param name="sortOption">sort records by item</param>
     /// <param name="sortOrder">direct or reverse order</param>
        static void SortPhoneBook((string firstName, string lastName, string phoneNumber)[] phoneBookRecords, SortOption sortOption, SortOrder sortOrder, string path)
        {
            switch (sortOption)
            {
                case SortOption.firstName:

                    for (int i = 0; i < phoneBookRecords.Length; i++)
                    {
                        int minIndex = i;

                        for (int j = i + 1; j < phoneBookRecords.Length; j++)
                        {
                            if (sortOrder == SortOrder.Asc)
                            {
                                if (string.Compare(phoneBookRecords[j].firstName, phoneBookRecords[minIndex].firstName, true) < 0)
                                {
                                    minIndex = j;
                                }
                            }
                            else
                            {
                                if (string.Compare(phoneBookRecords[j].firstName, phoneBookRecords[minIndex].firstName, true) > 0)
                                {
                                    minIndex = j;
                                }
                            }
                        }

                        (string, string, string) tempValue = phoneBookRecords[minIndex];
                        phoneBookRecords[minIndex] = phoneBookRecords[i];
                        phoneBookRecords[i] = tempValue;
                    }
                    break;

                case SortOption.lastName:

                    for (int i = 0; i < phoneBookRecords.Length; i++)
                    {
                        int minIndex = i;

                        for (int j = i + 1; j < phoneBookRecords.Length; j++)
                        {
                            if (sortOrder == SortOrder.Asc)
                            {
                                if (string.Compare(phoneBookRecords[j].lastName, phoneBookRecords[minIndex].lastName, true) < 0)
                                {
                                    minIndex = j;
                                }
                            }
                            else
                            {
                                if (string.Compare(phoneBookRecords[j].lastName, phoneBookRecords[minIndex].lastName, true) > 0)
                                {
                                    minIndex = j;
                                }
                            }
                        }

                        (string, string, string) tempValue = phoneBookRecords[minIndex];
                        phoneBookRecords[minIndex] = phoneBookRecords[i];
                        phoneBookRecords[i] = tempValue;
                    }
                    break;

                case SortOption.phoneNumber:
                    for (int i = 0; i < phoneBookRecords.Length; i++)
                    {
                        int minIndex = i;

                        for (int j = i + 1; j < phoneBookRecords.Length; j++)
                        {
                            if (sortOrder == SortOrder.Asc)
                            {
                                if (string.Compare(phoneBookRecords[j].phoneNumber, phoneBookRecords[minIndex].phoneNumber, true) < 0)
                                {
                                    minIndex = j;
                                }
                            }
                            else
                            {
                                if (string.Compare(phoneBookRecords[j].phoneNumber, phoneBookRecords[minIndex].phoneNumber, true) > 0)
                                {
                                    minIndex = j;
                                }
                            }
                        }

                        (string, string, string) tempValue = phoneBookRecords[minIndex];
                        phoneBookRecords[minIndex] = phoneBookRecords[i];
                        phoneBookRecords[i] = tempValue;
                    }
                    break;
            }

            string[] newRec = new string[phoneBookRecords.Length + 1];

            newRec[0] = "FirstName,LastName,PhoneNumber";

            for (int i = 0; i < phoneBookRecords.Length; i++)
            {
                newRec[i + 1] = string.Join(',', new[] { phoneBookRecords[i].firstName, phoneBookRecords[i].lastName, phoneBookRecords[i].phoneNumber });
            }

            File.WriteAllLines(path, newRec);

           
            PrintPhoneBook(phoneBookRecords);


        }


        /// <summary>
        /// Binary search of Last Name 
        /// </summary>
        /// <param name="phoneBookRecords"></param>
        /// <param name="query"></param>
        /// <returns>returns the index of the lastname in the PhoneBook if it matches or -1 if there is no match </returns>
        static int BinarySearch((string firstName, string lastName, string phoneNumber)[] phoneBookRecords, string query, string path)
        {
           
            string [] s = new string [phoneBookRecords.Length];
            bool stringExists = false;

            for (int i = 0; i < phoneBookRecords.Length; i++)
            {
                s[i] = phoneBookRecords[i].lastName;
                if (string.Compare(query, s[i], true) == 0)
                {
                    stringExists = true;
                }

            }

            if (!stringExists)
            {
                return -1;
            }

            Array.Sort(s);
         

            int min = 0;
            int max = phoneBookRecords.Length;

            while (min <= max)
            {

                int midValue = (max + min) / 2;

                int result = string.Compare(query, s[midValue], true);

                switch (result)
                {
                    case 0:

                        return midValue;
                        break;

                    case -1:
                        max = midValue;
                        break;

                    case 1:
                        min = midValue;
                        break;
                }

            }
            return -1;

        }



        static void SearchLastName((string firstName, string lastName, string phoneNumber)[] phoneBookRecords, string path)
        {
            Console.WriteLine("Enter the last name");
            string query = Console.ReadLine() ?? String.Empty;

            int lastNameIndx = BinarySearch(phoneBookRecords, query, path);
           
            Console.Clear();
            DisplayMenu();
            if (lastNameIndx >= 0)
            {
                Console.WriteLine($"{"First Name",-20} {"Last Name",-20} {"Phone",-20}");
                Console.WriteLine($"{phoneBookRecords[lastNameIndx].Item1,-20} {phoneBookRecords[lastNameIndx].Item2,-20} {phoneBookRecords[lastNameIndx].Item3,-20}");
            }
            else
            {
                Console.WriteLine("No match");
            }

        }
            

        /// <summary>
        /// Requests sort parametrs and then sort PhoneBook by chosen parametrs
        /// </summary>
        /// <param name="phoneBookRecords"></param>
        /// <param name="path"></param>
        static void SortParameters((string firstName, string lastName, string phoneNumber)[] phoneBookRecords, string path)
        {
            Console.WriteLine("Choose sort filter\n" +
                "1 - Sort by first name direct order\n" +
                "2 - Sort by first name reverse order\n" +
                "3 - Sort by last name direct order\n" +
                "4 - Sort by last name reverse order\n" +
                "5 - Sort by phone number direct order\n" +
                "6 - Sort by phone number reverse order\n" +
                "0 - Return to Main Menu");

            var option = Console.ReadKey();
            
            Console.Clear();
            switch (option.Key)
            {              
                case ConsoleKey.D0:
                    Console.Clear();
                    DisplayMenu();
                    break;
                case ConsoleKey.D1:
                    SortPhoneBook(phoneBookRecords, SortOption.firstName, SortOrder.Asc, path);
                    break;
                case ConsoleKey.D2:
                    SortPhoneBook(phoneBookRecords, SortOption.firstName, SortOrder.Desc, path);
                    break;
                case ConsoleKey.D3:
                    SortPhoneBook(phoneBookRecords, SortOption.lastName, SortOrder.Asc, path);
                    break;
                case ConsoleKey.D4:
                    SortPhoneBook(phoneBookRecords, SortOption.lastName, SortOrder.Desc, path);
                    break;
                case ConsoleKey.D5:
                    SortPhoneBook(phoneBookRecords, SortOption.phoneNumber, SortOrder.Asc, path);
                    break; 
                case ConsoleKey.D6:
                    SortPhoneBook(phoneBookRecords, SortOption.phoneNumber, SortOrder.Desc, path);
                    break;
            }
        }


        /// <summary>
        /// Print to console PhoneBook menu
        /// </summary>

        static void DisplayMenu()
		{
            Console.WriteLine("0 - Exit" +
                "\n1 - Display PhoneBook" +
                "\n2 - Search in PhoneBook" +
                "\n3 - Add a new record in PhoneBook" +
                "\n4 - Delete record" +
                "\n5 - Update record" +
                "\n6 - Sort PhoneBook" +
                "\n7 - Search last name");
        }


		
		static void Main(string[] args)
		{
			string path = Path.Combine(Directory.GetCurrentDirectory(), "PhoneBook.csv");
            
			(string, string, string)[] phoneBookRecords = ReadPhoneBook(path);



            DisplayMenu();

            bool exit = false;
			while (!exit)
			{
			   var option = Console.ReadKey();

				switch (option.Key)
				{
					case ConsoleKey.D0:
						Console.Clear();
						Console.WriteLine("Bye! See you never!");						
						exit = true;
						break;
					
					case ConsoleKey.D1:
						Console.Clear();
                        PrintPhoneBook(phoneBookRecords);  ///Display to console all records from the PhoneBook
						break;
					
					case ConsoleKey.D2:
                        Console.Clear();
                        SearchPhoneBook(phoneBookRecords); ///Search a particular record in the PhoneBook
						break;
					
					case ConsoleKey.D3:
                        Console.Clear();
                        RecordAdd(path, ref phoneBookRecords); ///Add a new record in the end of list in PhoneBook
						break;
					
					case ConsoleKey.D4:
                        Console.Clear();
                        RecordRemove( path, ref phoneBookRecords); ///Delete a particular record from the list in PhoneBook
						break;

                    case ConsoleKey.D5:
                        Console.Clear();
						RecordUpdate(path, ref phoneBookRecords);///Update a particular record from the list in PhoneBook				
						break;
                   
                    case ConsoleKey.D6:
                        Console.Clear();
                        SortParameters(phoneBookRecords, path);
                        break;

                    case ConsoleKey.D7:
                        Console.Clear();
                        SearchLastName(phoneBookRecords,path);


                        break;

                        //              default:
                        //Console.Clear();
                        //DisplayMenu();
                        //Console.ForegroundColor = ConsoleColor.Red;
                        //Console.WriteLine($"Enter the valid option. {option.KeyChar} doesn't exist among the possible options.");
                        //Console.ResetColor();
                        //break;

                }

			
               

          


            }
			
			
			
			


			

        }
	}
}