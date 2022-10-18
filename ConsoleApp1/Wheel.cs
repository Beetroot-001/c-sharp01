using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Wheel
    {
        private int _radius;
        private int _width;
        private string _tireTreadType;
        private int _pressureMax;
        private int _pressureCurrent;

        Wheel (int radius, int width, string tireTreadType, int pressureMax, int pressureCurrent)
        {
            _radius = radius;
            _width = width;
            _tireTreadType = tireTreadType;
            _pressureMax = pressureMax;
            _pressureCurrent = pressureCurrent;
        }   

        public int Radius 
        { 
            get => _radius; 
        }

        public int Width
        {
            get => _width;
        }

        public string TireTreadType
        {
            get => _tireTreadType;
        }

        public int Pressure
        {
            get => _pressureCurrent;
            set {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Pressuer can not be negative");
                }

                if (value > _pressureMax)
                {
                    throw new ArgumentOutOfRangeException("Pressure can not be above the max value");
                }

                _pressureCurrent = value;
            }
        }

        public int PressureMax 
        {
            get => _pressureMax;
        }
    }
}
