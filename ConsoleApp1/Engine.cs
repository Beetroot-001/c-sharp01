using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Engine
    {
        public enum Type
        {
            InternalCombustion,
            Hybrid,
            Electric
        }
        private Type engineType;
        public Engine(Type engineType)
        {
            this.engineType = engineType;
        }
        public Type EngineType { get { return engineType; } }
    }
}
