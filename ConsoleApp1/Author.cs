using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Author
    {
        private string _name;
        private string _surname;
        private string _middlename;

        

        public Author(string name, string surname)
        {
            _name = name;
            _surname = surname;
            _middlename = "";
            BookWritten = 0;
        }

        public Author(string name, string surname, string middlename)
        {
            _name = name;
            _surname = surname;
            _middlename = middlename;
            BookWritten = 0;
        }

        public string Name { get { return _name; } }
        public string Surname { get { return _surname; } }
        public string MiddleName { get { return _middlename; } }
        public int BookWritten { get; set; }

        public void DisplayAuthorInfo()
        {
            Console.WriteLine("Author info: ");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Surname: {Surname}");
            Console.WriteLine($"MiddleName: {MiddleName}");
            Console.WriteLine($"Book written: {BookWritten}");
            Console.WriteLine();
        }
    }
}
