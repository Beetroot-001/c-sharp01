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

        public Book[] books;

        public Library(ReaderDatabase readerCards, Book[] books)
        {
            this.readerCards = readerCards;
            this.books = books;
        }

        public Library()
        {
            this.readerCards = new ReaderDatabase();
            this.books = new Book[1];
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

        public int SearchBook(string title)
        {
            for (int i = 0; i < books.Length -1; i++)
            {
                if (books[i].Title == title)
                    return i;
            }
            return -1;
        }

        public bool BorrowBook(Reader reader, string title)
        {
            int recordIndex = readerCards.SearchRecord(reader);
            int bookIndex = SearchBook(title);
            if (recordIndex == -1 || bookIndex == -1)
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
            {
                return false;
            }
            Book[] newArray = new Book[books.Length + 1];
            Array.Copy(books, newArray, books.Length -1);
            newArray[books.Length - 1] = book;
            books = newArray;
            return true;
        }
    }
}
