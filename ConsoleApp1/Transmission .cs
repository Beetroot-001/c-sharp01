using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Transmission
    {
        private Type transmisionType;

        public Transmission(Type transmisionType)
        {
            this.transmisionType = transmisionType;
        }

        public enum Type
        {
            AutomaticTransmission,
            ManualTransmission,
            AutomatedManualTransmission,
            ContinuouslyVariableTransmission
        }

        public Type TransmisionType { get { return transmisionType; } }




    }
}
