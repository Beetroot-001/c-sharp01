using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Book
    {
        public int pageCount;
        public string name;
        private int readTimes=0;
        public string writerName;
        public bool isReadNow { get; set; }

        public void ReadBook(Book book)
        {
            book.readTimes++;                   
        }

        public Book(int pgCount, string bname, string writer)
        {
            pageCount = pgCount;
            name = bname;
            writerName = writer;            
        }

        public int ReadTimes 
        {
            get => readTimes;
        }

    }
}
