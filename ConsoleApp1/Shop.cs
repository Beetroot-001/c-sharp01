using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Shop
    {
        public ICollection<Employee> employees;
        public ICollection<Customer> customers;
        public ICollection<Order> orders;
    }
}
