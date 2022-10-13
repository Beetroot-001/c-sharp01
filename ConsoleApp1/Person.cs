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
        private string _firstName;
        private string _lastName;
        private string _middleName;

        public Person(string firstName, string lastName, string middleName)
        {
            _firstName = firstName;
            _lastName = lastName;
            _middleName = middleName;
        }

        public Person()
        {
            _firstName = string.Empty;
            _lastName = string.Empty;
            _middleName = string.Empty;
        }

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value ?? throw new ArgumentException("Argument can`t be null");
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = value ?? throw new ArgumentException("Argument can`t be null");
        }

        public string MiddleName
        {
            get => _middleName;
            set => _middleName = value ?? throw new ArgumentException("Argument can`t be null");
        }
    }
}
