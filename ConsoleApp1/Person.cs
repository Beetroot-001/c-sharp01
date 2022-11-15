using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Person
    {
        public Guid id { get; private set; } 
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public string Phone { get; set; } = "";


        protected Person()
        {
            id = Guid.NewGuid();
        }

        public Person(string firstName) : this() => FirstName = firstName;

        public Person(string firstName, string lastName) : this(firstName) => LastName = lastName;        
        
        public Person(string firstName, string lastName, string middleName) : this(firstName, lastName) => MiddleName = middleName;
    }
}
