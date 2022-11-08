using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Element<T>
    {
        public T Data { get; set; }
        public Element<T> Next { get; set; }
    }
}
