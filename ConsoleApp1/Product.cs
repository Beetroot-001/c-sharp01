using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Product : IProduct
    {
        private string name;
        private string description;
        private int quantity;
        private Price price;
        public Product(string name, string description, int quantity, Price price)
        {
            this.name = name;
            this.description = description;
            this.quantity = quantity;
            this.price = price;
        }
        public string Name { get { return name; } set { name = value; } }
        public string Description { get { return description; } set { description = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }
        public string Price { get { return price.PriceInfo; } }
        public decimal PriceDigit { get { return price.PriceDigit; } set { price.PriceDigit = value; } }
    }
}
