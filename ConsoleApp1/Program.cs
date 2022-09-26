using System;
using static System.Reflection.Metadata.BlobBuilder;

namespace ConsoleApp1
{
	internal class Program
	{
		/// <summary>
		/// The main menu of the library.
		/// </summary>
		static void DisplayMenu()
		{
			Console.WriteLine("0 - Leave the library");
			Console.WriteLine("1 - Select the reader card");
			Console.WriteLine("2 - Create a card and add a new reader to the library");
			Console.WriteLine("3 - Remove a card from the library");
			Console.WriteLine("4 - Add the book to the library");
			Console.WriteLine("5 - Show the list of books in the library");
		}

		/// <summary>
		/// Dispaly the list of all books in the library and the full info about a particular book.
		/// </summary>
		static void ShowBooks()
		{
			int index = -1;
            Console.Clear();
            Console.WriteLine("Select the book to see its full description. 0 - to leave");
            Library.ListofBooks();
            index = int.Parse(Console.ReadLine());

            while (index != 0)
			{
                Console.Clear();
                Library.ListofBooks();
				Console.WriteLine("*************************");
                Library.books[index - 1].BookInfoFull();
                Console.WriteLine("*************************");
                Console.WriteLine("Choose another book to see its full description. 0 - to leave.");
                index = int.Parse(Console.ReadLine());
            }
            Console.Clear();
            DisplayMenu();
        }

		/// <summary>
		/// Delete a reader card from library
		/// </summary>
		static void DeleteReaderCard()
		{
			Console.Clear();
            Console.WriteLine("Choose card id to delete. 0 - to leave.");
            Library.ListofCards();					
			int index = int.Parse(Console.ReadLine());
			Library.RemoveCard(--index);
        }

		/// <summary>
		/// Add a book from the library to the particular reader card 
		/// </summary>
		static void TakeBook()
		{
			Console.Clear();
			Console.WriteLine("Select your card id. 0 - to leave");
            Library.ListofCards();
            int id = int.Parse(Console.ReadLine());
			Console.Clear();

			if (id == 0)
			{
				return;
			}

			Console.WriteLine("0 - Leave");
			Console.WriteLine("1 - View the full information of this card");
			Console.WriteLine("2 - Take a new book");
			Console.WriteLine("3 - Return book to the library");
            int index = int.Parse(Console.ReadLine());

            switch (index)
			{
				case 0:					
					break;
				
				case 1:
					Console.Clear();
                    Console.WriteLine("0 - Leave");
                    Console.WriteLine("1 - Take a new book");
					Console.WriteLine("2 - Show the list of all read books");
                    Library.cards[index - 1].LibraryCardFullInfo();
                    index = int.Parse(Console.ReadLine());

					if (index == 0)
					{
						break;
					}
					else if (index == 1)
					{
                        goto case 2;
                    }
					else if (index == 2)
					{
                        Console.Clear();
                        Library.cards[id - 1].AllReadBooks();                        
                    }	
                    break;
				
				case 2:
                    Console.WriteLine("What book do you want to take?");
                    string query = Console.ReadLine();
                    Library.cards[id - 1].AssignBook(query);					
                    break;
				
				case 3:
					Library.cards[id - 1].RemoveBook();
					break;
            }
			Console.Clear();
			DisplayMenu();
        }

		/// <summary>
		/// Add a new reader to the library by creading a library card
		/// </summary>
		static void NewReader()
		{
			Console.WriteLine("Your first name");
			string name = Console.ReadLine();			
			
			Console.WriteLine("Your last name");
            string lastName = Console.ReadLine();
           
			Console.WriteLine("Your phone number");
            ulong phoneNumber = ulong.Parse(Console.ReadLine());

            Console.WriteLine("Your birthday. The format (year,month,day)");
			DateTime birthday = Convert.ToDateTime(Console.ReadLine());

			Library.AddCard(new LibraryCard(new Reader(name, lastName, phoneNumber, birthday)));
			Console.Clear();
			Console.WriteLine("The new reader was added.");
			DisplayMenu();
		}


		static void Main(string[] args)
		{
			Reader person1 = new Reader ("Alex", "Xanter", 342435, new DateTime (1991,6,22));
			Reader person2 = new Reader ("Petr", "Glance", 674675, new DateTime (1981,7,2));

			LibraryCard card1 = new LibraryCard(person1);
			LibraryCard card2 = new LibraryCard(person2);

			Book book1 = new Book(new Author("Dmitro Gluhovskii", "A very nice author"), "Metro2033", "Post-apocalyptic novel about Moscov metro", new[] { "chapter1", "chapter2", "chapter3" });
			Book book2 = new Book(new Author("Korney Chukovskii", "A very nice author"), "Tarakanishe", "Post-apocalyptic novel about Moscov metro", new[] { "chapter1" });
			Book book3 = new Book(new Author("Arkady and Boris Strugatsky", "A very nice author"), "The Inhabited Island", "The protagonist is a youngster, Maxim Kammerer, who comes from the version of Earth that exists in the Noon Universe and gets stranded on an unknown planet named Saraksh.", new[] { "chapter1" });
			Book book4 = new Book(new Author("George Orwell", "A very nice author"), "1984", " 1984 is a dystopian social science fiction novel and cautionary tale written by the English writer George Orwell.", new[] { "chapter1" });
			Book book5 = new Book(new Author("Ray Bradbury", "A very nice author"), "Fahrenheit 451", "Fahrenheit 451 presents an American society where books have been outlawed and \"firemen\" burn any that are found.", new[] { "chapter1" });		

			Library.AddBook(book1, book2,book3,book4, book5);
			bool exit = false;
			Library.AddCard(card1,card2);

			int query = 0;
            DisplayMenu();
            while (!exit)
			{
				query = int.Parse(Console.ReadLine());

				switch (query)
				{
					case 0:
						exit = true;
						break;
					case 1:
						TakeBook();
                        break;
					case 2:
						NewReader();
						break;
                    case 3:
						DeleteReaderCard();
                        break;
                    case 4:
						Library.AddBook();
						break;
					case 5:
						ShowBooks();
                        break;
                }
			}



          ///Static Class Library contains:
		  ///Class Book
		  ///Class Library Card
		  ///Class Book creates an instance of "book" using another Class Author + info of the book 






        }
    }
}