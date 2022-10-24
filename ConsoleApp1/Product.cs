using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Product
    {
        private string _name;
        private decimal _price;
        private int _quantity;

        public Product(string name, decimal price, int quantity = 0)
        {
            _name = name;
            _price = price;
            _quantity = quantity;
        }

        public string Name
        {
            get => _name; 
            set => _name = value ?? throw new ArgumentNullException();
        }

        public decimal Price 
        { 
            get => _price;
            set => _price = value >= 0 ? value : throw new ArgumentException();
        }

        public int Quantity
        {
            get => _quantity;
            set => _quantity = value >= 0 ? value : throw new ArgumentException();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Receipt) { return false; }

            Product temp = obj as Product;

            return temp.Name == _name && temp._price == _price ? true : false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Name}\nPrice: {Price}\nQuantity: {Quantity}";
        }
    }
}
