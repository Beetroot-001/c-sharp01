namespace ConsoleApp1
{
    internal  class AutoService
    {
        public Vehicle Vehicle { get; set; }    
        public Wheel Wheel { get; set; }
        public string Location { get; set; }
        public DateTime WorkTime { get; set; }
        public Workers Workers { get; set; }
        public decimal TotalPriceForService { get; set; }



        public decimal FixCar(Vehicle vehicle, Workers workers)
        {
            return TotalPriceForService;
        }

        
    }

  
}
