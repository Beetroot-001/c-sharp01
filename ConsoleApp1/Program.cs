using Microsoft.VisualBasic.FileIO;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mechanic m = new("John", "John", "", 18);
            Console.WriteLine(m.Name);
            Console.WriteLine(m.AtWork);
            m.Work();
            Car testCar = new(4, FuelType.Gas, VehicleType.Auto);
            Console.WriteLine("First test Nothing is broken");
            testCar.Repair(m);
            Console.WriteLine("Second test Mechanic isn't working");
            m.GoHome();
            testCar.Repair(m);
            m.Work();
            Console.WriteLine();
            Console.WriteLine("MAIN TEST");
            AutoService autoService = AutoService.GetAutoService();
            //autoService.toRepair[0].BreakSystem.Break();
            //autoService.toRepair[0].Repair(autoService.mechanics[0]);
            if(autoService.TryRepair())
                Console.WriteLine( "Car test: Success!" );
            autoService.GenerateNewRepairable("truck");
            if (autoService.TryRepair())
                Console.WriteLine("Truck test: Success!");
        }
    }
}