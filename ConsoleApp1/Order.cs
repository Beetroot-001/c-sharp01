using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Order
    {
        public int OrderId;
        public DateTime CreatedOn { get; set; }
        public ICollection<Product> Products { get; set; }
        public Customer CustomerId { get; set; }
        public Employee EmployeeId { get; set; }

    }
}
