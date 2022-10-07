using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //Зробив базовий клас для автора та читача щоб не дублювати код з описом імені
    internal class Person
    {
        string _FirstName;
        string _LastName;
        string _MiddleName;

        public Person(string firstName, string lastName, string middleName)
        {
            _FirstName = firstName;
            _LastName = lastName;
            _MiddleName = middleName;
        }

        public Person()
        {
            _FirstName = string.Empty;
            _LastName = string.Empty;
            _MiddleName = string.Empty;
        }

        public string FirstName
        {
            get => _FirstName;

            set => _FirstName = value ?? throw new ArgumentException("Argument can`t be null");
        }

        public string LastName
        {
            get => _LastName;

            set => _LastName = value ?? throw new ArgumentException("Argument can`t be null");
        }

        public string MiddleName
        {
            get => _MiddleName;

            set => _MiddleName = value ?? throw new ArgumentException("Argument can`t be null");
        }
    }
}
