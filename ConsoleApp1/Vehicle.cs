using System.ComponentModel;

namespace ConsoleApp1
{
    public class Vehicle
    {
        private int price;
        private bool iSStolen;

        public CarType CarTypes { get; set; }
        public CarModel CarModels { get; set; }
        public WheelPosition Position { get; set; }
        public string Owner { get; set; }   

        //Question - during builyding this constructor studia set THIS to price and to iSStolen, why?
        public Vehicle(int price, bool iSStolen, CarType carTypes, CarModel carModels, WheelPosition position)
        {
            this.price = price;
            this.iSStolen = iSStolen;
            CarTypes = carTypes;
            CarModels = carModels;
            Position = position;    
        }
    }

   
    public enum CarType
    {
        [Description("Not allowed for passenger")]
        Truck,
        PassengerCar
    }

    public enum CarModel
    {
        Tesla,
        BMW,
        Hyundai,
        Masserati
    }
    
    public enum WheelPosition
    {
        Left,
        Right
    }
}

