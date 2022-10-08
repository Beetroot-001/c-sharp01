using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.FIlters
{
    internal class Filter
    {
        public virtual string ThingToClean { get { return "something"; } }


        public string Operation { get { return $"This filter cleans {ThingToClean}"; } }
       
    }
}
