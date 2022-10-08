using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.VehicleParts
{
    internal class Engine
    {
        public enum FuelType
        {
            Diesel,
            Gas,
            Eletrical,
            Gasoline
        }

        public FuelType Fuel { get; set; }

        public double Volume { get; set; }
    }
}
