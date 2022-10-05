namespace ConsoleApp1
{
    public class Transmission
    {
        private string type;

        public Transmission(string type)
        {
            Type = type;
        }

        public string Type
        {
            get => type;
            set
            {
                this.type = value;
            }
        }
    }
}