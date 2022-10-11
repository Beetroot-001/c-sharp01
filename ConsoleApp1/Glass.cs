using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Glass
    {
       private int size;
       private int sickness;
        public Glass(int size, int sickness)
        {
            this.size = size;
            this.sickness = sickness;
        }
        public int Sickness { get { return sickness; } }
    }
}
