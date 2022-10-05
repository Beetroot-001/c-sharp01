namespace ConsoleApp1
{
    public class Vehicle
    {
        private Body body;
        private string brand;
        private string color;
        private int creationYear;
        private Engine engine;
        private string fuel;
        private int length;
        private string model;
        private int odometer;
        private Transmission transmission;
        private int weight;
        private Wheels wheels;

        public Vehicle(string brand, string model)
        {
            Brand = brand;
            Model = model;
        }

        public Vehicle(string brand, string model, Body body)
        {
            Brand = brand;
            Model = model;
            Body = body;
        }

        public Vehicle(string brand, string model, string color, int yearOfCreation)
        {
            Brand = brand;
            Model = model;
            Color = color;
            CreationYear = yearOfCreation;
        }

        public Vehicle(string brand, string model, Engine engine, string fuel, Transmission trans, Wheels wheels)
        {
            Brand = brand;
            Model = model;
            Engine = engine;
            Fuel = fuel;
            Transmission = trans;
            Wheels = wheels;
        }

        public Vehicle(string brand, string model, int length, int odometer, int weight)
        {
            Brand = brand;
            Model = model;
            Length = length;
            Odometer = odometer;
            Weight = weight;
        }

        public string Brand
        {
            get => brand;
            set
            {
                this.brand = value;
            }
        }

        public string Model
        {
            get => model;
            set
            {
                this.model = value;
            }
        }

        public string Color
        {
            get => color;
            set
            {
                this.color = value;
            }
        }

        public int CreationYear
        {
            get => creationYear;
            set
            {
                this.creationYear = value;
            }
        }

        public string Fuel
        {
            get => fuel;
            set
            {
                this.fuel = value;
            }
        }

        public int Odometer
        {
            get => odometer;
            set
            {
                this.odometer = value;
            }
        }

        public int Length
        {
            get => length;
            set
            {
                this.length = value;
            }
        }

        public int Weight
        {
            get => weight;
            set
            {
                this.weight = value;
            }
        }

        public Transmission Transmission
        {
            get => transmission;
            set
            {
                this.transmission = value;
            }
        }

        public Body Body
        {
            get => body;
            set
            {
                this.body = value;
            }
        }

        public Engine Engine
        {
            get => engine;
            set
            {
                this.engine = value;
            }
        }

        public Wheels Wheels
        {
            get => wheels;
            set
            {
                this.wheels = value;
            }
        }
    }
}