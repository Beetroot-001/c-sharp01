using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Vechicle
    {
        private string _class;
        private string _model;
        private int _wheelNumMax;
        private Wheel[] _wheels;
        private Frame _frame;
        private Engine _engin;

        Vechicle(string @class, string model, int wheelNumMax, Wheel[] wheels, Frame frame, Engine engin)
        {
            _class = @class;
            _model = model;
            _wheelNumMax = wheelNumMax;
            _wheels = wheels;
            _frame = frame;
            _engin = engin;
        }

        public String Class 
        { 
            get => _class; 
        }

        public string Model
        {
            get => _model;
        }

        public Wheel[] Wheels
        {
            get => _wheels;
        }

        public bool RemoveWheel(int wheelNum = 0)
        {
            if (wheelNum > _wheelNumMax || wheelNum < 0)
            {
                return false;
            }

            _wheels.Where((item, i) => i == wheelNum);
            return true;
        }

        public Frame Frame
        {
            get => _frame;
        }

        public Engine Engin
        {
            get => _engin;
        }
    }
}
