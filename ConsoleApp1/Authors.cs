using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Authors
    {
        private string _firstName, _lastName, _country, _isMarried;
        public int Age { get; }
        public int CountOfBooks { get; set; }
        public string[] Bestsellers { get; set; }

        public Authors(string firstName, string lastName, int age, string country, string job = "Unemployed", string isMarried = "Single", int countOfBook = 1, string[] bestseller = null)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            this.Age = age;
            this._country = country;
            this._isMarried = isMarried;
            this.CountOfBooks = countOfBook;
            this.Bestsellers = bestseller;
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
            Console.WriteLine($"First Name:\t{_firstName}\nLast Name:\t{_lastName}\nAge:\t{Age}\nCountry:\t{_country}\nMarital status\t{_isMarried}\nCount Of Book:\t{CountOfBooks}");
            DisplayBestsellers(Bestsellers);
        }

        public void GetShortInformation()
        {
            Console.WriteLine($"First Name:\t{_firstName}\nLast Name:\t{_lastName}\nAge:\t{Age}");
        }
    }
}
