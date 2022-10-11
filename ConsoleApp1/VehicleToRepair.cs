namespace ConsoleApp1
{
    abstract class VehicleToRepair
    {
        public abstract Repeirable GetVehicles(int count = 10);

        public bool TryToRepair(Mechanic mechanic)
        {
            return GetVehicles().Repair(mechanic) ? true : false;
        }
    }
    class CarFactory : VehicleToRepair
    {
        public override Repeirable GetVehicles(int count = 10)
        {
            return new Car(100, FuelType.Electro, VehicleType.Auto);
        }
    }

    class TruckFactory : VehicleToRepair
    {
        public override Repeirable GetVehicles(int count = 10)
        {
            Truck truck = new Truck(20000, 8, VehicleType.Auto);
            truck.AddCars(new Car(100, FuelType.Electro, VehicleType.Auto), new Car(110, FuelType.Gas, VehicleType.Mechanic));
            return truck;
        }
    }
}



