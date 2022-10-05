using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Readers
    {
        private string _firstName, _lastName, _country, _isMarried;
        public int Age { get; set; }

        public Readers(string firstName,string lastName, int age, string country, string job = "unemployed",string isMarried = "Single")
        {
            this._firstName = firstName;
            this._lastName=lastName;
            this.Age = age;
            this._country = country;
            this._isMarried = isMarried;
        }

        public void GetFullInformation()
        {
            Console.WriteLine($"First Name:\t{_firstName}\nLast Name:\t{_lastName}\nAge:\t{Age}\nCountry:\t{_country}\nMarital status\t{_isMarried}");
        }

        public void GetShortInformation()
        {
            Console.WriteLine($"First Name:\t{_firstName}\nLast Name:\t{_lastName}\nAge:\t{Age}");
        }
        public void Edit()
        {
            Console.WriteLine("Select the required option: \n1)\tFirst Name\n2)\tLast Name\n3)\tCountry\n4)\tMarried status");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();

            Console.WriteLine("Enter new data:\t");
            string newValue = Console.ReadLine()??"Some error";

            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.D1:
                    {
                        this._firstName = newValue;
                        break;
                    }
                case ConsoleKey.D2:
                    {
                        this._lastName = newValue;
                        break;
                    }
                case ConsoleKey.D3:
                    {
                        this._country = newValue;
                        break;
                    }
                case ConsoleKey.D4:
                    {
                        int newage;
                        if (!int.TryParse(newValue, out newage)) 
                            Console.WriteLine("error");

                        this.Age = newage;
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
