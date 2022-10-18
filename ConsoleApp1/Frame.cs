using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Frame
    {
        private string _frameType;
        private string _frameMaterial;

        Frame(string frameType, string frameMaterial)
        {
            _frameType = frameType;
            _frameMaterial = frameMaterial;
        }

        public string FrameType { 
            get => _frameType; 
        } 

        public string FrameMaterial
        {
            get => _frameMaterial;
        }
    }
}
