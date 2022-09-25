using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Reader
    {
        private string _name;
        private string _surname;
        private string _middlename;

        public Reader(string name, string surname, string middlename)
        {
            _name = name;
            _surname = surname;
            _middlename = middlename;
        }
        public string Name { get { return _name; } }
        public string Surname { get { return _surname; } }
        public string MiddleName { get { return _middlename; } }
    }
}
