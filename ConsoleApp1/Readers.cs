using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Readers
    {
        public string _firstName, _lastName, _country, _isMarried;
        public int age { get; }

        public Readers(string firstName,string lastName, int age, string country, string job = "unemployed",string isMarried = "Single")
        {
            this._firstName = firstName;
            this._lastName=lastName;
            this.age = age;
            this._country = country;
            this._isMarried = isMarried;
        }

        public void GetFullInformation()
        {
            Console.WriteLine($"First Name:\t{_firstName}\nLast Name:\t{_lastName}\nAge:\t{age}\nCountry:\t{_country}\nMarital status\t{_isMarried}");
        }

        public void GetShortInformation()
        {
            Console.WriteLine($"First Name:\t{_firstName}\nLast Name:\t{_lastName}\nAge:\t{age}");
        }
    }
}
