using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Author : Person
    {
        string _AuthorInfo;

        public Author()
        {
            _AuthorInfo = string.Empty;
        }

        public Author(Person person, string info = "") : 
            base(person.FirstName, person.LastName, person.MiddleName)
        {
            _AuthorInfo = info;
        }

        public Author(string firstName, string lastName, string middleName, string info = "") : 
            base(firstName, lastName, middleName)
        {
            _AuthorInfo = info;
        }

        public string AuthorInfo 
        { 
            get => _AuthorInfo; 
            set => _AuthorInfo = value ?? throw new ArgumentException("Argument can`t be null"); 
        }
    }
}
