using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Wheels
{
    internal class Wheel
    {
        private Rim rim;
        private Tire tire;
        private int size;

        public Wheel(Rim rim, Tire tire, int size)
        {
            this.rim = rim;
            this.tire = tire;
            this.size = size;
        }

        public void Rotate()
        {
            Console.WriteLine("The wheel rotates");
        }

        public void Info()
        {
            Console.WriteLine($"Rim Material: {rim.Material}");
            Console.WriteLine($"Tire Material: {tire.Material}");
            Console.WriteLine($"Wheel Size: {size}");
        }

    }
}
