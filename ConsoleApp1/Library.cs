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



    }
}
