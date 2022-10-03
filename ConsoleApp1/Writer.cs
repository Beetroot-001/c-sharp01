using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Writer
    {
        public string Name;
        public string wrInfo;
        public Writer(string writerName, string info)
        {
            Name = writerName;
            wrInfo = info;
        }
        public Book WriteBook(int pageCount, string name, string writerName)
        {   
            
            return new Book(pageCount, name, this.Name);
        }
    }
}
