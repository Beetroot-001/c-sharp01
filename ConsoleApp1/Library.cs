using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    static class Library
    {
        public static List<Book> books = new List<Book>();
        public static List<LibraryCard> cards = new List<LibraryCard>();

        /// <summary>
        /// Display the list of books available in the library
        /// </summary>
        public static void ListofBooks()
        {          
            int id = 1;
            foreach (var item in books)
            {               
                Console.WriteLine($"#{id} {item.BookInfoShort()}");
                id++;
            }
        }

        /// <summary>
        /// Add a book to the library
        /// </summary>
        /// <param name="newBook"></param>
        public static void AddBook(params Book [] newBook)
        {
            for (int i = 0; i < newBook.Length; i++)
            {
                books.Add(newBook[i]);
            }
        }

        /// <summary>
        /// Display the list of readers' cards
        /// </summary>
        public static void ListofCards()
        {
            if (cards.Count == 0)
            {
                Console.WriteLine("There are no readers yet in the library.");
            }
            
            foreach (var card in cards)
            {  
                card.LibraryCardShortInfo();              
            }          
        }

        /// <summary>
        /// Add a new reader card to the library 
        /// </summary>
        /// <param name="newCard"></param>
        public static void AddCard(params LibraryCard[] newCard)
        {
            for (int i = 0; i < newCard.Length; i++)
            {
                cards.Add(newCard[i]);
            }
        }  
        
        /// <summary>
        /// Remove a reader card from the library 
        /// </summary>
        /// <param name="removeCardIndex"></param>
        public static void RemoveCard(int removeCardIndex)
        {
            cards.RemoveAt(removeCardIndex);          
        }

        /// <summary>
		/// Dispaly the list of all books in the library and the full info about a particular book.
		/// </summary>
		public static void ShowBooks()
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
        /// The main menu of the library.
        /// </summary>
        public static void DisplayMenu()
        {
            Console.WriteLine("0 - Leave the library");
            Console.WriteLine("1 - Select the reader card");
            Console.WriteLine("2 - Create a card and add a new reader to the library");
            Console.WriteLine("3 - Remove a card from the library");
            Console.WriteLine("4 - Add the book to the library");
            Console.WriteLine("5 - Show the list of books in the library");
        }

        /// <summary>
        /// Delete a reader card from library
        /// </summary>
       public static void DeleteReaderCard()
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
       public static void TakeBook()
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
                        Library.cards[id - 1].ShowAllReadBooks();
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
            Library.DisplayMenu();
        }

        /// <summary>
        /// Add a new reader to the library by creading a library card
        /// </summary>
       public static void AddNewReader()
        {
            Console.WriteLine("Your first name");
            string name = Console.ReadLine();

            Console.WriteLine("Your last name");
            string lastName = Console.ReadLine();

            Console.WriteLine("Your phone number");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Your birthday. The format (year,month,day)");
            DateTime birthday = Convert.ToDateTime(Console.ReadLine());

            Library.AddCard(new LibraryCard(new Reader(name, lastName, phoneNumber, birthday)));
            Console.Clear();
            Console.WriteLine("The new reader was added.");
            Library.DisplayMenu();
        }


    }
}
