using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class User
    {
        private string firstName = "";
        public string FirstName
        {
            get => firstName;
            set => firstName = value;
        }

        private string lastName = "";
        public string LastName
        {
            get => lastName;
            set => lastName = value;
        }

        private string middleName = "";
        public string MiddleName
        {
            get => middleName;
            set => middleName = value;
        }

        public int Age { get; set; }
        public string FullName { get => string.Format("{0} {1} {2}", FirstName, MiddleName, LastName); }


        public User(string firstName)
        {
            FirstName = firstName;
        }

        public User(string firstName, string lastName) : this(firstName)
        {
            LastName = lastName;
        }

        public User(string firstName, string lastName, string middleName) : this(firstName, lastName)
        {
            MiddleName = middleName;
        }

    }
}
