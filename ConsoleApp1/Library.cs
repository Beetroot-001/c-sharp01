using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Library
    {
        private static Library LinksLibrary;
        public ReaderСard[] allReaderСards { get; set; } = new ReaderСard[1];

        public Books[] allLibraryBooks { get; set; } = new Books[1];   

        private int _countOfBooks;
        private int _countOfReadrCards;

        private Library()
        {
            _countOfBooks=0;
            _countOfReadrCards=0;
        }
        public static Library InitOrGetLibrary()
        {
            if(LinksLibrary == null)
            {
                LinksLibrary = new Library();
                return LinksLibrary;
            }
            return LinksLibrary;
        }

        public void GetAllReadersСards()
        {
            for (int i = 0; i < allReaderСards.Length; i++)
            {
                Console.Write($"{i+1}.\t");
                allReaderСards[i].readers.GetShortInformation();
                allReaderСards[i].GetInfoAboutReadBooks();
            }
        }

        public void GetAllLibraryBooks()
        {
            for (int i = 0; i < allLibraryBooks.Length; i++)
            {
                Console.WriteLine($"{i+1}.\t{allLibraryBooks[i].title}");
                allLibraryBooks[i].GetFullInformation();
            }
        }

        public void AddReaderСard(ReaderСard readerСard)
        {
            ReaderСard[] readerСards = new ReaderСard[allReaderСards.Length + 1];

            if (allReaderСards[0] == null)
                allReaderСards[0] = readerСard;
            else
            {
                for (int i = 0; i < readerСards.Length; i++)
                {
                    if (i < allReaderСards.Length)
                        readerСards[i] = allReaderСards[i];
                    else
                        readerСards[i] = readerСard;

                }
                allReaderСards = readerСards;
            }
            this._countOfReadrCards += 1;
        }

        public void AddBooks(Books book)
        {
            Books[] books = new Books[allLibraryBooks.Length + 1];

            if (allLibraryBooks[0] == null)
                allLibraryBooks[0] = book;
            else
            {
                for (int i = 0; i < books.Length; i++)
                {
                    if (i < allLibraryBooks.Length)
                        books[i] = allLibraryBooks[i];
                    else
                        books[i] = book;

                }
                allLibraryBooks = books;
            }
            this._countOfBooks += 1;
        }

        public void BookSearch(string valueSearch)
        {
            for (int i = 0; i < allLibraryBooks.Length; i++)
            {
                if (allLibraryBooks[i].title.Contains(valueSearch) || allLibraryBooks[i].authors.Contains(valueSearch) || allLibraryBooks[i].description.Contains(valueSearch))
                {
                    Console.WriteLine("Search Result: {0}",i);
                    allLibraryBooks[i].GetFullInformation();
                }
            }
        }
    }
}
