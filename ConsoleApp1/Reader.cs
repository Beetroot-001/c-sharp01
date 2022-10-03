using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Reader
    {
        public int age;
        public string name;
        public string description;
        Book[] readBooks;
        int numOfRead;
        public Reader(int age, string name, string description) 
        {
            this.age = age;
            this.name = name;
            this.description = description;
        }

        public void GetBook(Book book, Ticket ticket)
        {
            int read = book.ReadBook(book);
            numOfRead++;
            Array.Resize(ref readBooks, numOfRead);
            for (int i = 0; i < readBooks.Length; i++)
            {
                if (readBooks[i] != book)
                {
                    readBooks[i] = book;
                }
                
            }
        }
        
    }
}
