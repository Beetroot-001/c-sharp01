using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Lights
{
    internal class Light
    {
        private Glass material;
        private Frame frame;
        private Bulbs bulb;
        private Colors color;

        public Light(Glass material, Frame frame, Bulbs bulb, Colors color)
        {
            this.material = material;
            this.frame = frame;
            this.bulb = bulb;
            this.color = color;
        }

       public enum Bulbs
        {
            round,
            square
        }

        public enum Colors
        {
            red,
            white,
            yellow
        }

        public virtual string LightInfo { get { return $"It's a {bulb} {color} light {frame.Size} inches size"; } }

    }

   
}
