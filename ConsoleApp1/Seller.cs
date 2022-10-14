using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Seller : Person, IInfo
    {
        public string Position { get; set; }
        public int WorkExperience { get; set; } = 0;
        public int ID { get; set; }
        public DateTime DateOfHire { get; set; }// Future fiction

        public Seller(string firstName, string lastName, string midlName, byte age, int phone, string email, DateTime dateOfHire, Discount discounts = null) : base(firstName, lastName, midlName, age, phone, email, discounts)
        {
            this.ID = IDSequence.GetNextId();
            DateOfHire = dateOfHire;
        }

        public string GetFullInfo()
        {
            return this.GetFullName() + $"\n Age:\t {this.Age}\nPhon:\t{this.Phone}\nE-mail:\t{this.Email}\nWork Experience:\t{WorkExperience} years\nID:\t{ID}";
        }
    }
}
