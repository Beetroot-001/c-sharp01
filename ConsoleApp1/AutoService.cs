using ConsoleApp1.VehicleParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class AutoService
    {
        private static AutoService _instance;

        public List<Worker> Workers { get; set; } = new List<Worker>();

        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

        public void AddVehicle(Vehicle vehicle) { throw new NotImplementedException(); }

        public Vehicle GetVehicle(string id) { throw new NotImplementedException(); }

        public void AddWorker(Worker worker) { throw new NotImplementedException(); }

        public Worker GetWorker(string id) { throw new NotImplementedException(); }

        private AutoService() {}

        public static AutoService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AutoService();
            }
            return _instance;
        }
    }
}
