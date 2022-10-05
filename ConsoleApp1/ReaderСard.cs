using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ReaderСard
    {
        public Readers Readers { get; set; }
        public int CountOfBooks { get; set; }

        public Books[] AllReadBooks { get; set; }=new Books[1];

        public ReaderСard(Readers readers)
        {
            this.Readers = readers;
        }

        public void GetInfoAboutReadBooks()
        {
            Console.WriteLine("\t\tREAD BOOKS");
            Readers.GetShortInformation();
            Console.WriteLine();
            Console.WriteLine("\t\tBooks\n");
            for (int i = 0; i < AllReadBooks.Length; i++)
            {
                Console.WriteLine($"{i+1} Title: {AllReadBooks[i].Title}\tAuthor: {AllReadBooks[i].Authors} ");
            }
            Console.WriteLine($"Quantity of read books:\t{CountOfBooks}\n");
        }//вивід інформацію про прочитані книги

        public void AddReadBook(Books book)
        {
            Books[] books = new Books[AllReadBooks.Length + 1];
           
            if (AllReadBooks[0] == null)
                AllReadBooks[0] = book;
            else
            {
                for (int i = 0; i <= AllReadBooks.Length; i++)
                {
                    books[i]= i==AllReadBooks.Length ? AllReadBooks[i] : book;
                }
                AllReadBooks = books;
            }
            this.CountOfBooks += 1;
        }// додавання книг
    }
}
