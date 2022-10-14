using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal interface IProduct
    {
         string Name { get; set; }
         string Description { get; set; }
         int Quantity { get; set; }
         int Price { get; set; }      
    }
}
