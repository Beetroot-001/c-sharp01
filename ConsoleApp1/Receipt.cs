using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Receipt
    {
        private List<Product> _products;
        private decimal _sum;
        private Buyer _buyer;

        public Receipt(Buyer buyer)
        {
            _products = new List<Product>();
            _buyer = buyer;
        }

        public Receipt(List<Product> products, decimal sum, Buyer buyer)
        {
            _products = products;
            _sum = _products.Aggregate(0.0m, (acum, item)=> acum += item.Price);
            _buyer = buyer;
        }

        public Decimal Sum
        {
            get => _sum;
        }

        public Buyer Buyer
        {
            get => _buyer;
            set => _buyer = value ?? throw new ArgumentNullException("Buyer can not be null");
        }

        public List<Product> Products
        {
            get => _products;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);

            _sum += product.Price;
        }

        public void RemoveProduct(int index)
        {
            _sum -= _products[index].Price;

            _products.RemoveAt(index);
        }

        public override string ToString()
        {
            string res = $"Sum: {Sum}\n";

            for (int i = 0; i < _products.Count; i++)
            {
                res += _products[i].ToString() + '\n';
            }

            return res;
        }
    }
}
