using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Lights
{
    internal class HeadLight : Light
    {
        public HeadLight(Glass material, Frame frame, Bulbs bulb, Colors color) : base(material, frame, bulb, color)
        {
        }
    }
}
