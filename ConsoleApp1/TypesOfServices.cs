using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public enum ServisType
    {
        RepairFrontdoor,
        BrakeInspection,
        TirePressureCheck,
        TireWearInspection,
        InspectSuspensionAndSteering,
        RoadTest,
        Diagnostics,
        Maintenance,
        FlatTireRepair,
        ScheduledMaintenance,
        FleetService,
        BatteryDiagnostics
    }

    public class TypesOfServices
    {
        public ServisType servise;

        public int id;

        public float Price;

        public int GetId() { return id; }

        public float GetPrice() { return Price; }

        public void Displayfullinform()
        {

        }
    }
}
