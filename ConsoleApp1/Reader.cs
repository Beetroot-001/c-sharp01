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
        private Book[] readBooks;
        int numOfRead;
        int readTimes = 0;
        public Reader(int age, string name, string description)
        {
            this.age = age;
            this.name = name;
            this.description = description;
        }

        public void GetBook(Book book)
        {
            Array.Resize(ref readBooks, numOfRead + 1);
            readBooks[numOfRead] = book;
            numOfRead++;            
        }
        public void GetListOfRead()
        {
            foreach (Book book in readBooks)
            {
                Console.WriteLine(book.name + " " + book.writerName);
            }
        }
    }
}
