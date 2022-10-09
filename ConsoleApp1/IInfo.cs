using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal interface IInfo
    {
        public int ID { get; set; }
        public string GetFullInfo();
    }
}
