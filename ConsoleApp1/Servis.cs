using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum ServisType
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

    public class Servis
    {
        ServisType servise;
        int id;
        float Price;

        public int GetId() { return id; }

        public float GetPrice() { return Price; }

        public void Getfullinform()
        {

        }
    }
}
