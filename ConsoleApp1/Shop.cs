using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Shop
    {
        private List<Product> _products;
        private List<Buyer> _buyers;

        public Shop()
        {
            _products = new List<Product>();
            _buyers = new List<Buyer>();
        }

        public List<Product> Products
        {
            get => _products;
        }

        public List<Buyer> Buyers
        {
            get => _buyers;
        }

        public void AddProduct(Product product)
        {
            foreach(var item in _products)
            {
                if (item.Equals(product))
                {
                    item.Quantity += product.Quantity;
                    return;
                }
            }
            _products.Add(product);
        }

        public void AddBuyer(Buyer buyer)
        {
            _buyers.Add(buyer);
        }
    }
}
