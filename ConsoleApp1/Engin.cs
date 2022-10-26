using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Engine
    {
        public enum EngineType 
        { 
            SOMETYPES
        }

        private EngineType _enginType;

        public Engine(EngineType enginType)
        {
            _enginType = enginType;
        }

        public EngineType EnginType => _enginType;
    }
}
