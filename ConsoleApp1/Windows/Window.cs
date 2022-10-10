using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Windows
{
    internal class Window
    {
        private Glass material;
        private Frame frame;
        public Window(Glass material, Frame frame)
        {
            this.material = material;
            this.frame = frame;
        }
        public string WindowInfo { get {return $"It has {material.Sickness} inches sickness and {frame.Size} inches in size"; } }
    }
}
