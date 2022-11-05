using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Base
    {
        public string Title { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
