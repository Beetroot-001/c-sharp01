using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Library
    {
        public Book[] books;
        int bookCount = 0;
        public bool isReadNow;
        
        public void AddBook(Book book)
        {
            Array.Resize(ref books, bookCount+1);
            books[bookCount] = book;
            bookCount++;

        }
        public void DeleteBook(Book book)
        {
            for (int i = 0; i < books.Length - 1; i++)
            {
                if (books[i] == book)
                {

                }
            }
        }
        public void ShowLibrary()
        {
            foreach (Book book in books)
            {
                Console.WriteLine(bookCount + " " + book.name +" "+ book.writerName);
            }
        }
        public void SearchBook()
        {
            string input = Console.ReadLine() ?? string.Empty;
            foreach (Book book in books)
            {
                if (book.name.Contains(input, StringComparison.OrdinalIgnoreCase) || book.writerName.Contains(input,StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(bookCount + " " + book.name +" "+ book.writerName);
                }
            }
        }
    }
}
