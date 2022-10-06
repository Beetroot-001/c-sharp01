using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal interface IReceipt
    {
        public IProduct SoldProduct { get; }
        public IBuyer Buyer { get; }
        public int Quantity { get; }
    }
}
