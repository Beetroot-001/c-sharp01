using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Receipt
    {
        public Receipt(Bin bin)
        {
            bool empty = bin.NumOfGoods != 0 ? true : false;
            if (empty)
            {
                bin.customer.Buy(bin.TotalCost);
                Console.WriteLine("Purchase done!" + "\nRemaining balance: ");
                bin.customer.GetBalance();
            }
            else
            {                
            }
        }
    }
}
