namespace ConsoleApp1
{
    public class Wheels
    {
        private string manufacturer;
        private int size;

        public Wheels(string man, int size)
        {
            Manufacturer = man;
            Size = size;
        }

        public string Manufacturer
        {
            get => manufacturer;
            set
            {
                this.manufacturer = value;
            }
        }

        public int Size
        {
            get => size;
            set
            {
                this.size = value;
            }
        }
    }
}