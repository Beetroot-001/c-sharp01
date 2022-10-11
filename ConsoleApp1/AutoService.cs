namespace ConsoleApp1
{
    class AutoService
    {
        private static AutoService _autoService;
        public Mechanic[] mechanics;
        public Janitor janitor;
        // public Vehicle[] toRepair;
        public VehicleToRepair toRepair;

        public static AutoService GetAutoService()
        {
            if (_autoService == null)
            {
                _autoService = new AutoService();
            }
            return _autoService;
        }
        private AutoService()
        {
            mechanics = new Mechanic[] { new Mechanic("John", "Milborn", "", 18), new Mechanic("Jo", "Johnes", "", 43) };
            janitor = new Janitor("Mark", "Me", "", 20);
            GenerateNewRepairable("Car");
        }

        public void GenerateNewRepairable(string type)
        {
            type = type.ToLower();
            if(type == "truck")
            {
                toRepair = new TruckFactory();
            }
            else
            {
                toRepair = new CarFactory();
            }
        }

        public bool TryRepair()
        {
            for (int i = 0; i < mechanics.Length; i++)
            {
                if (toRepair.TryToRepair(mechanics[i]))
                    return true;
            }
            return false;
        }

    }
}