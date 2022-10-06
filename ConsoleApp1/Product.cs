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
        private int price;

        public Product(string name, string description, int quantity, int price)
        {
            this.name = name;
            this.description = description;
            this.quantity = quantity;
            this.price = price;
        }

        public string Name { get { return name; } set { name = value; } }
        public string Description { get { return description; } set { description = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }
        public int Price { get { return price; } set { price = value; } }
    
    }
}
