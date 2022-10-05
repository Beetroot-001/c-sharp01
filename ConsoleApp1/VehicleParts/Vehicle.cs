using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.VehicleParts
{
    internal class Vehicle
    {
        public enum VehicleType
        {
            Auto,
            Motorcycle
        }
        
        public enum VehicleStatus
        {
            Arrived,
            InRepairing,
            GotRepaired,
            Issued
        }

        public string Id { get; set; }

        public VehicleType Type { get; set; }

        public VehicleStatus Status { get; set; }

        public Engine Engine { get; set; }
        public List<Wheel> Wheels { get; set; }

        public void ChangeStatus(VehicleStatus vehicleStatus)
        {
            throw new NotImplementedException();
        }

        public void IncludeMainWorker(Worker worker)
        {
            throw new NotImplementedException();
        }
    }
}
