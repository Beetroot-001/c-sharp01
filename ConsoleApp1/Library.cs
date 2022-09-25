using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Library
    {
        public ReaderDatabase readerCards;

        public List<Book> books;

        public Library(ReaderDatabase readerCards, List<Book> books)
        {
            this.readerCards = readerCards;
            this.books = books;
        }

        public Library()
        {
            this.readerCards = new ReaderDatabase();
            this.books = new List<Book>();
        }

        public void AddBook(Book newBook)
        {
            books.Add(newBook);
        }

        public int SearchBook(string title)
        {
            foreach (var book in books)
            {
                if (book.Title == title)
                    return books.IndexOf(book);
            }
            return -1;
        }

        public bool BorrowBook(Reader reader, string title)
        {
            int found = SearchBook(title);
            if (found == -1 || books[found].Borrowed)
                return false;

            books[found].Borrowed = true;
            int record = readerCards.SearchRecord(reader);
            readerCards.Readers[record].AddBook(books[found]);
            return true;
        }
    }
}
