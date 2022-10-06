namespace ConsoleApp1
{
    internal class Car
    {
        public Vehicle Vehicle { get; set; }
        public Wheel Wheel { get; set; }
        public string Location { get; set; }
        public int InventYear { get; }

        public Car(int inventYear)
        {
            InventYear = inventYear;
        }
    }
}
