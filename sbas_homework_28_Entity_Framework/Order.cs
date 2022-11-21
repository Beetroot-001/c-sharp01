using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sbas_homework_28_Entity_Framework
{
    internal class Order
    {
        public Guid OrderId { get; set; }
        public Employees Employees { get; set; }
        public Customer Customers { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
