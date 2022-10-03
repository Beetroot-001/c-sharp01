namespace ConsoleApp1
{
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

        public virtual void Repair(Mechanic tech)
        {
            if (!tech.AtWork)
            {
                Console.WriteLine("The Mechanic isn't at work!");
                return;
            }
            _state = VehicleStateS.Repeared;
            Console.WriteLine("Vehicle system broken successfully");
        }
	}

    class MovingSystem : VehicleSystem
    {
        private bool _isWheesMoving;
        private bool _isBouncing;

        public bool IsBroken => !(_isBouncing && _isWheesMoving);

        public MovingSystem(string name, VehicleStateS state) : base(name, state)
        {
            _isBouncing = true;
            _isWheesMoving = true;
        }

        public override void Break()
        {
            _isWheesMoving = _isBouncing = false;
            _state = VehicleStateS.Broken;
            Console.WriteLine("Moving system broken successfully");
        }
        public override void Repair(Mechanic tech)
        {   
            if (!tech.AtWork)
            {
                Console.WriteLine("The Mechanic isn't at work!");
                return;
            }
            if(_isWheesMoving && _isBouncing)
            {
                Console.WriteLine("The Moving system is alright");
                return;
            }
            _isWheesMoving = _isBouncing = true;
            Console.WriteLine("Moving system repeared successfully");
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

        public override void Repair(Mechanic tech)
        {
            if (!tech.AtWork)
            {
                Console.WriteLine("The Mechanic isn't at work!");
                return;
            }
            if (_isCooling)
            {
                Console.WriteLine("The Cooling system is alright");
                return;
            }
            _isCooling = true;
            Console.WriteLine("Cooling system repeared successfully");
        }
    }

    class BreakSystem : VehicleSystem
    {
        private bool _safeBreak;
        public bool SafeBreak => _safeBreak;

        public BreakSystem(string name, VehicleStateS state) : base(name, state)
        {
            _safeBreak = true;
        }

        public override void Break()
        {
            _safeBreak = false;
            _state = VehicleStateS.Broken;
            Console.WriteLine("Breaking system broken successfully");
        }
        public override void Repair(Mechanic tech)
        {
            if (!tech.AtWork)
            {
                Console.WriteLine("The Mechanic isn't at work!");
                return;
            }
            if (_safeBreak)
            {
                Console.WriteLine("The Break system is alright");
                return;
            }
            _safeBreak = true;
            Console.WriteLine("Break system repeared successfully");
        }

    }

}