namespace ConsoleApp1
{
    public enum VehicleStateS
    {
        New,
        Working,
        Broken,
        Repeared
    }

    public enum VehicleType
    {
        Auto,
        Mechanic
    }

    public enum FuelType
    {
        None,
        Electro,
        Gas,
        Gasoline,
        Hybrid
    }

    interface Repeirable
    {
        void Repair(Mechanic tech);
    }

    class Car : Repeirable
    {
        FuelType _fuelType;
        VehicleType _vehicleType;
        int _seats;
        BreakSystem _breakSystem;
        MovingSystem _movingSystem;

        public FuelType Fuel => _fuelType;
        public VehicleType Type => _vehicleType;
        public int Seats => _seats;
        public BreakSystem BreakSystem => _breakSystem;
        public MovingSystem MovingSystem => _movingSystem;

        public Car(int seats, FuelType fuelType, VehicleType vehicleType)
        {
            _breakSystem = new BreakSystem("Breaking car system", VehicleStateS.New);
            _movingSystem = new MovingSystem("Moving car system", VehicleStateS.New);
            _fuelType = fuelType;
            _vehicleType = vehicleType;
            _seats = seats;
        }

        public void Repair(Mechanic tech)
        {
            if (!tech.AtWork)
                return;
            
        }
    }

    class Truck : Repeirable
    {
        float _canCaryKg;
        VehicleType _vehicleType;
        int _wheelCount;
        VehicleSystem[] parts;
        Car[] carry;

        public float CanCaryKg => _canCaryKg;
        public VehicleType Type => _vehicleType;
        public int Wheels => _wheelCount;
        public CoolingSystem CoolingSystem => (CoolingSystem)parts[0];
        public BreakSystem BreakSystem => (BreakSystem)parts[1];
        public MovingSystem MovingSystem => (MovingSystem)parts[2];

        public Car GetFirstCar => carry[0];
        public Car GetSecondCar => carry[1];
        public Truck(float canCaryKg, int wheel, VehicleType vehicleType)
        {
            parts = new VehicleSystem[] { new CoolingSystem("Cooling truck system", VehicleStateS.New),
                new BreakSystem("Breaking truck system", VehicleStateS.New),
                new MovingSystem("Moving truck system", VehicleStateS.New) };
            _wheelCount = wheel;
            _canCaryKg = canCaryKg;
            carry = new Car[2]; // new car object!
        }

        public void Repair(Mechanic tech)
        {
            if (!tech.AtWork)
                return;

        }
    }
}