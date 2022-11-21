using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class InternetShop : Shop
    {
        public InternetShop(string name) : base(name) { }

        public override Buyer AddBuyer(string phone)
        {
            throw new NotImplementedException();
        }

        public override Buyer GetBuyer(string phone)
        {
            throw new NotImplementedException();
        }

        public override Product AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public override Product GetProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public override Receipt AddReceipt(Receipt receipt)
        {
            throw new NotImplementedException();
        }
    }
}
