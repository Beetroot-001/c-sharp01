using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Battery
    {
        private int capacity;
        public Battery(int capacity)
        {
            if (capacity > 1000) capacity = 1000;
            this.capacity = capacity;
        }
        public int Capacity { get { return capacity; } }
    }
}
