using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Seller:Person,IInfo
    {
        public Seller(string firstName, string lastName, string midlName, byte age, int phone, string email, Discount discounts = null) : base(firstName, lastName, midlName, age, phone, email, discounts)
        {
            this.ID = GetsID.GetID();
        }

        public string Position { get; set; }
        public int WorkExperience { get; set; }
        public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void GetFullInfo()
        {

        }
    }
}
