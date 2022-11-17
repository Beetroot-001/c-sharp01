using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Order
    {
        public int Id { get; set; }
                
        public ICollection<Employee> Employee { get; set; }

        public Customer Customer { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
       
        public double Total { get => Products.Sum(x=> x.Cost); }

        public DateTime CreatedOn { get; set; }
        //public Guid CreatedById { get; set; }
        public Employee CreatedBy { get; set; }
    }
}
