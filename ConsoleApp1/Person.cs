using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MidlName { get; set; }
        public byte Age { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public Discount Discounts { get; set; }

        public Person(string firstName, string lastName, string midlName, byte age, int phone, string email, Discount discounts = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.MidlName = midlName;
            this.Age = age;
            this.Phone = phone;
            this.Email = email;
            this.Discounts = discounts;
        }


        public string GetFullName()
        {
            return $"First Name:\t{FirstName}\nLast Name:\t{LastName}\nMidl Name:\t{MidlName}";
        }

        public void Edit()
        {

        }

        public void GetPhone()
        {

        }

        public void GetDiscountsInfo()
        {

        }
    }
}
