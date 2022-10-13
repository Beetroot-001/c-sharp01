using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal interface IReceipt
    {
         IProduct SoldProduct { get; }
         IBuyer Buyer { get; }
         int Quantity { get; }
         string Sum { get; }
    }
}
