using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        private string Password { get; set; }
        public bool isRegistered;
        private decimal moneyBalUah = 5000;        
        public Customer(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public Customer(string name, string email)
        {
            Name = name;
            Email = email;           
        }

        public string EnterPassword()
        {
            return Password;
        }

        public void SetPassword(string password)
        {
            Password = password;
        }

        public void Buy(decimal value)
        {
            if (value < moneyBalUah)
            {
                moneyBalUah -= value;
            }
            else Console.WriteLine("Purchase declined, check your balance");
        }

        public void GetBalance()
        {
            Console.WriteLine(moneyBalUah);
        }
    }
}
