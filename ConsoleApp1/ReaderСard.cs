using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ReaderСard
    {
        public Readers readers { get; set; }
        public int countOfBooks { get; set; }

        public Books[] allReadBooks { get; set; }=new Books[1];

        public ReaderСard(Readers readers)
        {
            this.readers = readers;
        }

        public void GetInfoAboutReadBooks()
        {
            Console.WriteLine("\t\tREAD BOOKS");
            readers.GetShortInformation();
            Console.WriteLine();
            Console.WriteLine("\t\tBooks\n");
            for (int i = 0; i < allReadBooks.Length; i++)
            {
                Console.WriteLine($"{i+1} Title: {allReadBooks[i].title}\tAuthor: {allReadBooks[i].authors} ");
            }
            Console.WriteLine($"Quantity of read books:\t{countOfBooks}\n");
        }//вивід інформацію про прочитані книги

        public void AddReadBook(Books book)
        {
            Books[] books = new Books[allReadBooks.Length + 1];
           
            if (allReadBooks[0] == null)
                allReadBooks[0] = book;
            else
            {
                for (int i = 0; i <= allReadBooks.Length; i++)
                {
                    if (i < allReadBooks.Length)
                        books[i] = allReadBooks[i];
                    else
                        books[i] = book;
                }
                allReadBooks = books;
            }
            this.countOfBooks += 1;
        }// додавання книг
    }
}
