using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class LibraryCard
    {
        private static int nextId;
        private int id;
        private Reader reader;
        private List<Book> books = Library.books;
        private List<Book> assignedBooks = new List<Book>();


        public LibraryCard(Reader reader)
        {
           nextId++;
           id = nextId;         
           this.reader = reader;
        }

      
        public void AssignBook(string query)
        {
            bool searchSuccess = false;

            foreach (var book in books)
            {
                if (book.BookTitle.Contains(query,StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("The following books satsify your search");
                    Console.WriteLine(book.BookInfoShort());
                    searchSuccess = true; 
                }
            }

            if (searchSuccess)
            {
                Console.WriteLine("Select the book you want to take. Provide the number of the desired book to be assigned to your library card. 0 - to leave.");
                
                 Console.ReadKey()
                
            }
            else
            {
                Console.WriteLine("The book you searched is not found. Look through other books available in the library");
                Library.ListofBooks();
            }

        }






        //public string LibraryCardInfo()
        //{
        //    return id + reader.ReaderInfo(); 
        //}






    }
}
