using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Worker
    {
        public string FName { get; set; } = "";
         
        public string LName { get; set; } = "";

        public string MName { get; set; } = "";

        public string Id { get; set; } = "";

        public string FullName { get => string.Format("{0} {1} {2}", FName, MName, LName); }
    }
}
