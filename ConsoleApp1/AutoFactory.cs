namespace ConsoleApp1
{
    abstract class AutoFactory
    {
        public abstract Repeirable GetVehicles(int count = 10);
    }
    class CarFactory : AutoFactory
    {
        public override Repeirable GetVehicles(int count = 10)
        {
            return new Car(100, FuelType.Electro, VehicleType.Auto);
        }
    }

    class TruckFactory : AutoFactory
    {
        public override Repeirable GetVehicles(int count = 10)
        {
            return new Truck(20000, 8, VehicleType.Auto);
        }
    }
}



