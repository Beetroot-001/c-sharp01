using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Authors
    {
        public string _firstName, _lastName, _country, _isMarried;
        public int age { get; }
        public int countOfBooks { get; set; }
        public string[] bestsellers { get; set; }

        public Authors(string firstName, string lastName, int age, string country, string job = "Unemployed", string isMarried = "Single", int countOfBook = 1, string[] bestseller = null)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            this.age = age;
            this._country = country;
            this._isMarried = isMarried;
            this.countOfBooks = countOfBook;
            this.bestsellers = bestseller;
        }

        private void DisplayBestsellers(string[] bestsellers)
        {
            Console.Write("DisplayBestsellers:\t");
            for (int i = 0; i < bestsellers.Length; i++)
            {
                if (bestsellers[i] == bestsellers[bestsellers.Length-1])
                    Console.Write($"{bestsellers[i]}.");
                Console.Write($"{bestsellers[i]},");
            }
        }

        public void GetFullInformation()
        {
            Console.WriteLine($"First Name:\t{_firstName}\nLast Name:\t{_lastName}\nAge:\t{age}\nCountry:\t{_country}\nMarital status\t{_isMarried}\nCount Of Book:\t{countOfBooks}");
            DisplayBestsellers(bestsellers);
        }

        public void GetShortInformation()
        {
            Console.WriteLine($"First Name:\t{_firstName}\nLast Name:\t{_lastName}\nAge:\t{age}");
        }
    }
}
