using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    
    internal class Goods:IInfo
    { 
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public Discount Discounts { get; set; }
        public int ID { get; set; } 

        public Goods(string name, float price, int quantity, Discount discounts=null)
        {
            
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
            this.Discounts = discounts;
            this.ID = GetsID.GetID();
        }

        public float ChangePrice()
        {
            return Price;
        }

        public string GetFullInfo()
        {
            return "";
        }
    }
}
