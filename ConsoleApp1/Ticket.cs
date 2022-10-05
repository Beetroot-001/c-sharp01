using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Ticket
    {
        private Book[] readBooks;
        private string name;
        public int countOfRead { get; set; }

        public string Name { get { return name; } set { name = value; } }
        public int Id { get; set; }
        public Ticket(Reader reader)
        {
            Name = reader.name;
        }
        public void AddBookToReadList(Book book)
        {
            countOfRead++;
            Array.Resize(ref readBooks, countOfRead);
            readBooks[countOfRead-1] = book;

        }
        
        public void ReadList()
        {
            if (readBooks == null)
            {
                Console.WriteLine("No records at the moment!");
            }
            else
            {
                foreach (var book in readBooks)
                    Console.WriteLine(book.name + " " + book.writerName);
            }
        }

    }
}
