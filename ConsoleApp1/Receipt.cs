using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Receipt
    {
        public Buyer Buyer { get; private set; }
        public List<Product> Producs { get; set; } = new List<Product>();
        
        public Receipt(Buyer buyer)
        {
            Buyer = buyer;
        }
    }
}
