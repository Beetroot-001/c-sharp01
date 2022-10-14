using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Receipt : IReceipt
    {
        public IProduct soldProduct;
        public IBuyer buyer;
        public int quantity;
        public Receipt (IProduct soldProduct, IBuyer buyer, int quantity)
        {
            this.soldProduct = soldProduct;
            this.buyer = buyer;
            this.quantity = quantity;
        }
        public IProduct SoldProduct { get { return soldProduct; } }
        public IBuyer Buyer { get { return buyer; } }
        public int Quantity { get { return quantity; } }
    }
}
