namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Mechanic m = new Mechanic("John", "John", "", 18);
			Console.WriteLine(m.Name);
		}
	}

	class Vehicle
	{
		private int _wheelCount;

	} 

	class Car : Vehicle
	{

	}

	class Bicycle : Vehicle
	{

	}

	class Truck : Vehicle
	{

	}

	public enum VehicleStateS
    {
		New,
		Working,
		Broken,
		Repeared
	}

	class VehicleSystem
	{
		private string _name;
		protected VehicleStateS _state;

		public string Name => _name;

		public VehicleStateS State => _state;

		public VehicleSystem(string name)
		{
			_name = name;
			_state = VehicleStateS.New;
		}
		public VehicleSystem(string name, VehicleStateS state) : this (name)
		{
			_name = name;
			_state = state;
		}

		public virtual void Break()
		{
            _state = VehicleStateS.Broken;
			Console.WriteLine("Vehicle system broken successfully");
        } 
	}

	class MovingSystem : VehicleSystem
	{
		private bool _isWheesMoving;
		private bool _isBouncing;
		public MovingSystem(string name, VehicleStateS state) : base(name, state)
		{
			_isBouncing = true;
			_isWheesMoving = true;
		}

        public bool IsBroken => !(_isBouncing && _isWheesMoving);
        public override void Break()
		{
            _isWheesMoving = _isBouncing = false;
			_state = VehicleStateS.Broken;
            Console.WriteLine("Moving system broken successfully");
        }
		
	}

	class CoolingSystem : VehicleSystem
	{
		private bool _isCooling;
        public bool IsBroken => !_isCooling;

        public CoolingSystem(string name, VehicleStateS state) : base(name, state)
		{
			_isCooling = true;
		}

		public override void Break()
		{
			_isCooling = false;
			_state = VehicleStateS.Broken;
            Console.WriteLine("Colling system broken successfully");
		}
	}

	class BreakSystem : VehicleSystem
	{	

		public BreakSystem(string name, VehicleStateS state) : base(name, state)
		{
		}
	}

}