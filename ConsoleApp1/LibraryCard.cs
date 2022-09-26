using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    //Library card contains info about reader and the list of books the reader assigned to his/her card
    //You can assign only those books which are available in the library
    //You can view the list of assigned books and the reader's info as well as remove any book from the list of assigned books 
    internal class LibraryCard
    {
        private static int nextId;
        private int id;
        private int readBooks;
        private Reader reader;
        private List<Book> books = Library.books;
        private List<Book> assignedBooks = new List<Book>();        
        private List<Book> allReadBooks = new List<Book>();


        public LibraryCard(Reader reader)
        {
           nextId++;
           id = nextId;         
           this.reader = reader;
        }

        public int ReadBooks {get {return readBooks;}}

        /// <summary>
        /// Add a book from available library to a particular reader card 
        /// </summary>
        /// <param name="query"></param>
        public void AssignBook(string query)
        {
            bool searchSuccess = false;
            List<Book> searchResult = new List<Book>();
            int counter = 0;

            foreach (var book in books)
            {
                if (book.BookTitle.Contains(query, StringComparison.InvariantCultureIgnoreCase))
                {
                    counter++;
                    Console.WriteLine("The following books satsify your search");
                    Console.WriteLine($"#{counter} {book.BookInfoShort()}");
                    searchResult.Add(book);
                    searchSuccess = true; 
                }
            }

            if (searchSuccess)
            {
                Console.WriteLine("Provide the index of the book to be assigned to your library card. 0 - to leave.");
                int option = int.Parse(Console.ReadLine());
                if (option == 0) return;              
                assignedBooks.Add(searchResult[option-1]);
                allReadBooks.Add(searchResult[option - 1]);
                readBooks++;
            }
            else
            {
                Console.WriteLine("The book you searched is not found. Look through other books available in the library");
                Library.ListofBooks();
            }
        }

        /// <summary>
        /// Remove a book from a particular card 
        /// </summary>
        public void RemoveBook()
        {
            Console.WriteLine("Provide the index of the book to be removed from your library card. 0 - to leave.");
            for (int i = 0; i < assignedBooks.Count; i++)
            {
                Console.WriteLine($"#{i+1} {assignedBooks[i].BookInfoShort()}");
            }

           int query = int.Parse(Console.ReadLine());

            if (query == 0)
            {
                return;
            }
            else if (query > assignedBooks.Count || query < 0)
            {
                Console.WriteLine("Please, select the book from the list.");
            }
            else
            {
                assignedBooks.RemoveAt(query-1);
            }
        }

        /// <summary>
        /// Display basic info about card owner
        /// </summary>
        public void LibraryCardShortInfo()
        {
            Console.WriteLine("**********************");         
            Console.WriteLine($"Reader id: {id}");
            Console.WriteLine(reader.ReaderInfo());
            Console.WriteLine($"Number of assigned books: {assignedBooks.Count}");
            Console.WriteLine("**********************");
        }

        /// <summary>
        /// Display the full info about card owner,including the list of assigned books with short description
        /// </summary>
        public void LibraryCardFullInfo()
        {
            Console.WriteLine("**********************");
            Console.WriteLine($"Reader id: {id}");
            Console.WriteLine(reader.ReaderInfo());
            Console.WriteLine("**********************");
            Console.WriteLine($"Number of all read books {ReadBooks}");
            Console.WriteLine($"Number of assigned books: {assignedBooks.Count}");
            Console.WriteLine("The list of assigned books:");

            foreach (var book in assignedBooks)
            {
                Console.WriteLine(book.BookInfoShort()); 
            }
        }
        /// <summary>
        /// Display the list of all books that card owner read
        /// </summary>
        public void AllReadBooks()
        {
            int exit = 1;
            while (exit != 0)
            {
                Console.WriteLine("The list of all read books. 0 - to leave.");

                if (allReadBooks.Count == 0)
                {
                    Console.WriteLine("You didn't read any book yet.");
                }
                foreach (var book in allReadBooks)
                {
                    Console.WriteLine(book.BookInfoShort());
                }
                exit = int.Parse(Console.ReadLine());
            }         
        }




    }
}
