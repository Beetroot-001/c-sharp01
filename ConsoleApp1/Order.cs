using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Order
    {
        public Employee Employee { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Product> Orders { get; set; }
        public double Total { get => Orders.Sum(x=>x.Cost); }
        public DateTime CreatedOn { get; set; }
        public Employee CreatedBy { get; set; }
    }
}
