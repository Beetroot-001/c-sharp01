using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Buyer:Person,IInfo
    {
        public string Likes { get; set; }
        public string Activity { get; set; }
        public string Telegram { get; set; }
        public int ID { get; set; }

        public Buyer(string firstName, string lastName, string midlName, byte age, int phone, string email, Discount discounts = null) : base(firstName, lastName, midlName, age, phone, email, discounts)
        {
            this.ID = GetsID.GetID();
        }// Коректна реалізація базового класу чи можна якось скоротити?

        public string GetFullInfo()
        {
            return"";
        }
    }
}
