namespace ConsoleApp1
{
    internal class Wheel
    {
        public int diamter;

        public WheelType WheelType { get; set; }
        public InUse InUse { get; set; }

        public Wheel(int diamter, WheelType wheelType, InUse inUse)
        {
            this.diamter = diamter;
            WheelType = wheelType;
            InUse = inUse;  
        }
    }

    public enum WheelType
    {
        ForWinter,
        ForSummer
    }

    public enum InUse
    {
        New,
        Used
    }
}
