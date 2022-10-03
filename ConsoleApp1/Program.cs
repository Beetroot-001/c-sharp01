using Microsoft.VisualBasic.FileIO;
using System.IO;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Mechanic m = new Mechanic("John", "John", "", 18);
            Console.WriteLine(m.Name);
			Console.WriteLine(m.AtWork);
			m.Work();
			Car testCar = new Car(10, 4, FuelType.Gas, VehicleType.Auto);
			Console.WriteLine("First test Nothing is broken");
			testCar.Repair(m);
            Console.WriteLine("Second test Mechanic isn't working");
            m.GoHome();
			testCar.Repair(m);
			m.Work();
			Console.WriteLine("Third test Actual repair");
			AutoService autoService = AutoService.GetAutoService();
			autoService.toRepair[0].BreakSystem.Break();
			autoService.toRepair[0].Repair(autoService.mechanics[0]);
        }
	}
	class AutoService
	{
		private static AutoService _autoService;
		public Mechanic[] mechanics;
		public Janitor janitor;
		public Vehicle[] toRepair;
			
		public static AutoService GetAutoService()
		{
			if(_autoService == null)
			{
				_autoService = new AutoService();
			}
			return _autoService;
		}
		private AutoService()
		{	
			mechanics = new Mechanic[] { new Mechanic("John", "Milborn", "", 18), new Mechanic("Jo", "Johnes", "", 43)};
			janitor = new Janitor("Mark", "Me", "", 20);
			toRepair = new Vehicle[] { new Car(10, 4, FuelType.Gas, VehicleType.Auto), 
				new Car(12, 2, FuelType.Gasoline, VehicleType.Mechanic),
				new Truck(100, 2, FuelType.Hybrid, VehicleType.Auto)
			};

		}

    }

    

}