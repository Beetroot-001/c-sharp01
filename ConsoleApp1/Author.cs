using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Author : Person
    {
        private string _authorInfo;

        public Author()
        {
            _authorInfo = string.Empty;
        }

        public Author(Person person, string info = "") : 
            base(person.FirstName, person.LastName, person.MiddleName)
        {
            _authorInfo = info;
        }

        public Author(string firstName, string lastName, string middleName, string info = "") : 
            base(firstName, lastName, middleName)
        {
            _authorInfo = info;
        }

        public string AuthorInfo 
        { 
            get => _authorInfo; 
            set => _authorInfo = value ?? throw new ArgumentException("Argument can`t be null"); 
        }
    }
}
