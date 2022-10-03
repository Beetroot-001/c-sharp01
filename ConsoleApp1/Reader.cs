using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Reader
    {
        private string _name;
        private string _surname;
        private string _middlename;
        public Reader(string name, string surname)
        {
            _name = name;
            _surname = surname;
            _middlename = "";
        }
        public Reader(string name, string surname, string middlename)
        {
            _name = name;
            _surname = surname;
            _middlename = middlename;
        }
        public string Name => _name;
        public string Surname => _surname;
        public string MiddleName => _middlename;

        public void DisplayReaderInfo()
        {
            Console.WriteLine("Reader info: ");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Surname: {Surname}");
            Console.WriteLine($"MiddleName: {MiddleName}");
            Console.WriteLine();
        }
    }
}
