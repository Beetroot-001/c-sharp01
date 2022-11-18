using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Product
    {
        public Guid ProductId { get; set; }
        
        public string Title { get; set; }
        public int TypeId { get; set; }
        public Type Type { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public ICollection<Order>? OrderId { get; set; }

    }
}
