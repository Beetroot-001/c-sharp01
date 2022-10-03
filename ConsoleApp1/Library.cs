using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Library
    {
        private static Library _library;

        public ReaderDatabase readerCards;
        public Book[] books;

        private Library()
        {
            this.readerCards = new ReaderDatabase();
            this.books = new Book[1];
        }

        public Library(ReaderDatabase readerCards, Book[] books)
        {
            this.readerCards = readerCards;
            this.books = books;
        }

        public static Library GetLibrary()
        {
            if(_library == null)
            {
                _library = new Library();
            }
            return _library;
        }
        public void DisplayBooks()
        {
            for (int i = 0; i < books.Length - 1; i++)
            {
                books[i].DisplayBookInfo();
            }
        }

        public void AddBook(Book newBook)
        {
            books[^1] = newBook;
            Array.Resize(ref books, books.Length + 1);
        }

        public bool TrySearchBook(string title, out int index)
        {
            for (int i = 0; i < books.Length - 1; i++)
            {
                if (books[i].Title == title)
                {
                    index = i;
                    return true;
                }
            }
            index = -1;
            return false;
        }

        public bool BorrowBook(Reader reader, string title)
        {
            int recordIndex = readerCards.SearchRecord(reader);
            int bookIndex;
            if (recordIndex == -1 || !TrySearchBook(title, out bookIndex))
            {
                return false;
            }
            readerCards.Readers[recordIndex].AddBook(books[bookIndex]);
            Book[] newArray = new Book[books.Length - 1];
            for (int i = 0, j = 0; i < books.Length; i++, j++)
            {
                if (i == bookIndex)
                {
                    i++;
                }
                newArray[j] = books[i];
            }
            books = newArray;
            return true;
        }

        public bool ReturnBook(Reader reader, string title)
        {
            int recordIndex = readerCards.SearchRecord(reader);
            Book book = readerCards.Readers[recordIndex].ReturnBook(title);
            if (recordIndex == -1 || book == null)
                return false;
            Book[] newArray = new Book[books.Length + 1];
            Array.Copy(books, newArray, books.Length - 1);
            newArray[books.Length - 1] = book;
            books = newArray;
            return true;
        }
    }
}
