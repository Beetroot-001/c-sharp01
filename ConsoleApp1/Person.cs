using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Person
    {
        public Guid Id { get; private set; } 
        public string FirstName { get; set; } = "";
        public string? LastName { get; set; } = "";
        public string? MiddleName { get; set; } = "";
        public string? Phone { get; set; } = "";

        //public ICollection<Order> OrdersCompleted { get; set; } = new List<Order>();
        //public ICollection<Order> OrdersCreated { get; set; } = new List<Order>();

        protected Person()
        {
            Id = Guid.NewGuid();
        }

        public Person(string firstName) : this() => FirstName = firstName;

        public Person(string firstName, string lastName) : this(firstName) => LastName = lastName;        
        
        public Person(string firstName, string lastName, string middleName) : this(firstName, lastName) => MiddleName = middleName;
    }
}
