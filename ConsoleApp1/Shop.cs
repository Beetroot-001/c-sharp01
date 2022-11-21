using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal abstract class Shop
    {
        public string Name { get; set; }

        public string Description { get; set; } = "";

        public string Address { get; set; } = "";

        protected Shop(string name)
        {
            this.Name = name;
        }

        public List<Buyer> Buyers { get; set; } = new List<Buyer>();

        public List<Product> Products { get; set; } = new List<Product>();

        public List<Receipt> Receipts { get; set; } = new List<Receipt>();

        public abstract Buyer AddBuyer(string phone);

        public abstract Buyer GetBuyer(string phone);

        public abstract Product AddProduct(Product product);

        public abstract Product GetProduct(Product product);

        public abstract Receipt AddReceipt(Receipt receipt);

    }
}
