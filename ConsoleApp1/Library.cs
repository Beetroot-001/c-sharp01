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
        public ReaderСard[] AllReaderСards { get; set; } = new ReaderСard[1];

        public Books[] AllLibraryBooks { get; set; } = new Books[1];   

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
            for (int i = 0; i < AllReaderСards.Length; i++)
            {
                Console.Write($"{i+1}.\t");
                AllReaderСards[i].Readers.GetShortInformation();
                AllReaderСards[i].GetInfoAboutReadBooks();
            }
        }

        public void GetAllLibraryBooks()
        {
            for (int i = 0; i < AllLibraryBooks.Length; i++)
            {
                Console.WriteLine($"{i+1}.\t{AllLibraryBooks[i].Title}");
                AllLibraryBooks[i].GetFullInformation();
            }
        }

        public void AddReaderСard(ReaderСard readerСard)
        {
            ReaderСard[] readerСards = new ReaderСard[AllReaderСards.Length + 1];

            if (AllReaderСards[0] == null)
                AllReaderСards[0] = readerСard;
            else
            {
                for (int i = 0; i < readerСards.Length; i++)
                {
                    if (i < AllReaderСards.Length)
                        readerСards[i] = AllReaderСards[i];
                    else
                        readerСards[i] = readerСard;

                }
                AllReaderСards = readerСards;
            }
            this._countOfReadrCards += 1;
        }

        public void AddBooks(Books book)
        {
            Books[] books = new Books[AllLibraryBooks.Length + 1];

            if (AllLibraryBooks[0] == null)
                AllLibraryBooks[0] = book;
            else
            {
                for (int i = 0; i < books.Length; i++)
                {
                    if (i < AllLibraryBooks.Length)
                        books[i] = AllLibraryBooks[i];
                    else
                        books[i] = book;

                }
                AllLibraryBooks = books;
            }
            this._countOfBooks += 1;
        }

        public void BookSearch(string valueSearch)
        {
            for (int i = 0; i < AllLibraryBooks.Length; i++)
            {
                if (AllLibraryBooks[i].Title.Contains(valueSearch) || AllLibraryBooks[i].Authors.Contains(valueSearch) || AllLibraryBooks[i].Description.Contains(valueSearch))
                {
                    Console.WriteLine("Search Result: {0}",i);
                    AllLibraryBooks[i].GetFullInformation();
                }
            }
        }
    }
}
