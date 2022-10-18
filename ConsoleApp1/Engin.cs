using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Engin
    {
        private string _enginType;

        Engin(string enginType)
        {
            _enginType = enginType;
        }

        public string EnginType 
        { 
            get => _enginType; 
        }
    }
}
