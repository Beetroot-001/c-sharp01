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

    class Vehicle
	{
        protected float _canCaryKg;
        protected FuelType _fuelType;
        protected VehicleType _vehicleType;
        protected int _seats;
        protected int _wheelCount;
		protected VehicleSystem[] parts;

		public float CanCaryKg => _canCaryKg;
		public FuelType Fuel => _fuelType;
		public VehicleType Type => _vehicleType;
		public int Seats => _seats;
		public int Wheels => _wheelCount;
		public CoolingSystem CoolingSystem => (CoolingSystem)parts[0];
		public BreakSystem BreakSystem => (BreakSystem)parts[1];
		public MovingSystem MovingSystem => (MovingSystem)parts[2];

        public Vehicle(float canCaryKg, int seats, FuelType fuelType, VehicleType vehicleType)
		{
			parts = new VehicleSystem[] { new CoolingSystem("Cooling System", VehicleStateS.New),
				new BreakSystem("Breaking system", VehicleStateS.New),
				new MovingSystem("Moving system", VehicleStateS.New) };
            _wheelCount = 4;
            _canCaryKg = canCaryKg;
			_fuelType = fuelType;
			_vehicleType = vehicleType;
			_seats = seats;
		}

		public void Repair(Mechanic tech)
		{
			foreach(var part in parts)
			{
				part.Repair(tech);
            }
		}
	}

    class Car : Vehicle
    {

        public Car(float canCaryKg, int seats, FuelType fuelType, VehicleType vehicleType) : base(canCaryKg, seats, fuelType, vehicleType)
        {
            _wheelCount = 4;
        }
    }

    class Truck : Vehicle
    {
        Car[] carry;
        public Car GetFirstCar => carry[0];
        public Car GetSecondCar => carry[1];
        public Truck(float canCaryKg, int seats, FuelType fuelType, VehicleType vehicleType) : base(canCaryKg, seats, fuelType, vehicleType)
        {
            _wheelCount = 8;
            _canCaryKg *= 10;
            carry = new Car[2];
        }

    }
}