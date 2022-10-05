using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class AutoService
    {
        private int name;
        private int address;

        public Job Job
        {
            get; set;
        }

        public Customer Customer
        {
            get; set;
        }

        public Employee[] Employee
        {
            get; set;
        }

        public Manager Manager
        {
            get; set;
        }

        public void ProvideService()
        {
            throw new System.NotImplementedException();
        }
    }
}