using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Frame
    {
        private string material;
        private int size;

        public Frame(string material, int size)
        {
            this.material = material;
            this.size = size;
        }

        public int Size { get { return size; } }

    }
}
